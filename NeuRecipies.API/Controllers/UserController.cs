using BusinessEntities;
using BusinessLogic.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using NeuRecipies.API.Models;

namespace NeuRecipies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

       

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody]AddUserModel addUserModel)

        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            try
            {



                User user = new User();


                user.Email = addUserModel.Email;
                user.Name = addUserModel.Name;
                user.Password = BCrypt.Net.BCrypt.HashPassword(addUserModel.Password);

                bool newUser = await userService.AddUser(user);

                if (!newUser)
                {
                    return BadRequest("User already exist");
                }
                else
                {


                    return Ok("Account Created");
                }
                    

                    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                //return BadRequest(ex.Message,'user already exist');
            }
        }


        [HttpPost]

        //public async Task<IActionResult> LoginAsync(UserModel userModel)
        //{
        //    try
        //    { UserEntity userEntity = new UserEntity();


        //        userEntity.Email = userModel.Email;
        //        userEntity.Password = userModel.Password;
        //        //return Ok(await userService.LoginUser(userEntity));
        //        bool isLoginSuccesful = await userService.LoginUser(userEntity);
        //        if (!isLoginSuccesful)
        //        {
        //            return BadRequest("Invalid Email or Password");
        //        }
        //        else
        //        {
        //            return Ok();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        //    }

        //}









        public async Task<IActionResult> LoginAsync(LoginModel loginModel)
        {
            try
            {
                User user = new User();


                user.Email = loginModel.Email;
                user.Password = loginModel.Password;
                //return Ok(await userService.LoginUser(userEntity));
                Guid isLoginSuccesful = await userService.LoginUser(user);
                if (isLoginSuccesful==Guid.Empty)
                {
                    return BadRequest("Invalid Email or Password");
                }
                else
                {
                    return Ok(await userService.LoginUser(user));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

    }
}
