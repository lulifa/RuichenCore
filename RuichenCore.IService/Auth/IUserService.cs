using RuichenCore.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuichenCore.IService
{
    public interface IUserService
    {
        Task<List<User>> GetList();
        Task<User> GetSingle(object id);
        Task<int> Update(User user);
    }
}
