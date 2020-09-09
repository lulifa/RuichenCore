using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RuichenCore.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuichenCore.Extension
{
    public static class BearerJwtPack
    {
        public static void AddBeaerJwtServices(this IServiceCollection services)
        {
            string issuer = SectionManager.GetSection("Ruichen", "Jwt", "Issuer");
            string audience = SectionManager.GetSection("Ruichen", "Jwt", "Audience");
            string secret = SectionManager.GetSection("Ruichen", "Jwt", "Secret");
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                RequireExpirationTime = true
            };

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenValidationParameters;
                o.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.Response.Headers.Add("Token-Error", context.ErrorDescription);
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        string token = context.Request.Headers["Authorization"].ToString();
                        if (token != null)
                        {
                            token = token.Replace("Bearer ", string.Empty);
                        }
                        else
                        {
                            token = string.Empty;
                        }
                        JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                        if (jwtSecurityToken.Issuer != issuer)
                        {
                            context.Response.Headers.Add("Token-Error-Iss", "issuer is wrong");
                        }
                        if (jwtSecurityToken.Audiences.All(item => item != audience))
                        {
                            context.Response.Headers.Add("Token-Error-Aud", "audience is wrong!");
                        }
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
