using BusinessEntities;
using DataAccess.DataContext;
using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserData:IUserData
    {
       public UserData(RecipieDbContext recipieDbContext)
        {
            this.recipieDbContext = recipieDbContext;
        }
        RecipieDbContext recipieDbContext;

        public async Task<bool> AddUser(User user)
        {
            bool isUserExist= recipieDbContext.Users.Any(x=> x.Email==user.Email);
            if ( !isUserExist)
            {
                //User users = new Models.User
                //{
                  
                //    Email = user.Email,
                //    Name = user.Name,
                //    Password = user.Password,

                //};
                recipieDbContext.Users.Add(user);
                await recipieDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }



        public async Task<Guid> LoginUser(User user)
        {
            User userAvailable = await recipieDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == user.Email );

            if (userAvailable != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(user.Password, userAvailable.Password);
                if (verified)
                {
                    return userAvailable.Id;
                }
            }
            return Guid.Empty;
           
        }

    }
}
