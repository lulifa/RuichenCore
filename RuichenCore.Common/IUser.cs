using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.Common
{
    public interface IUser
    {
        string UserId { get; }
        string Token { get; }
    }
}
