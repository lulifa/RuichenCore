using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RuichenCore.EFCore;
using RuichenCore.IRepository;
using RuichenCore.IService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuichenCore.Service
{
    public class UserService : IUserService
    {
        private readonly IServiceProvider provider;
        public UserService(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        protected IBaseRepository<User> userRepository => provider.GetService<IBaseRepository<User>>();

        public async Task<List<User>> GetList()
        {
            List<User> users = await userRepository.Query().ToListAsync();
            return users;
        }

        public async Task<User> GetSingle(object id)
        {
            User user = await userRepository.Find(id);
            return user;
        }
    }
}
