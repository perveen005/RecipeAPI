using BusinessEntities;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
     public interface IUserService
    {
        Task<bool> AddUser(User user);



        Task<Guid> LoginUser(User user);
    }
}
