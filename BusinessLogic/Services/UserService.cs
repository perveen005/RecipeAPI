using BusinessEntities;
using BusinessLogic.Interface;
using DataAccess.DataContext;
using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService:IUserService
    {
        readonly IUserData userData;

         public UserService(IUserData userData, RecipieDbContext recipieDbContext)
        {
            this.userData = userData;
            this.recipieDbContext = recipieDbContext;
        }
        RecipieDbContext recipieDbContext;

        public async Task<bool> AddUser(User user)
        {
            return await this.userData.AddUser(user);
        }



        public async Task<Guid> LoginUser(User user)
        {
            return await this.userData.LoginUser(user);
            
        }


    }
}
