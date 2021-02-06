using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Core.ActionFilters;
using Nutritionist.Services;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserLoginModel = Nutritionist.Core.Models.User.Login;

namespace Nutritionist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService;
        public UserController()
        {
            userService = new UserService();
        }

        [ValidateModelState]
        [HttpPost("Login")]
        public UserDetailModel Login([FromQuery] UserLoginModel userLoginModel)
        {
            try
            {
                var result = userService.UserLogin(userLoginModel);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [ValidateModelState]
        [HttpPost("Register")]
        public bool Register([FromQuery] UserInsertModel userInsertModel)
        {
            try
            {
                var result = userService.UserRegister(userInsertModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
