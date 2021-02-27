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
using UserUpdateModel = Nutritionist.Core.Models.User.Update;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Core.StaticDatas;

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
        public BaseResponseModel PostUserLogin([FromBody] UserLoginModel userLoginModel)
        {
            try
            {
                var result = userService.UserLogin(userLoginModel);
                return new SuccessResponseModel<UserDetailModel>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }

        [ValidateModelState]
        [HttpPost("Register")]
        public BaseResponseModel PostUserRegister([FromBody] UserInsertModel userInsertModel)
        {
            try
            {
                var result = userService.UserRegister(userInsertModel);
                if (result)
                {
                    return new SuccessResponseModel<bool>(result);
                }
                else
                {
                    return new BaseResponseModel(ReadOnlyValues.UnexpectedErrorMessage);
                }

            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpGet("Detail/{userId}")]
        public ActionResult<BaseResponseModel> GetUserDetail(int userId)
        {
            try
            {
                var  userDetail = userService.GetUserDetailModel(userId);
                if (userDetail != null)
                {
                    return new SuccessResponseModel<UserDetailModel>(userDetail);
                }
                else
                {
                    return new BaseResponseModel(ReadOnlyValues.UserNotFound);
                }
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpDelete("DeleteUser/{userId}")]
        public ActionResult<BaseResponseModel> DeleteUser(int userId)
        {
            try
            {
                bool res = userService.RemoveUser(userId);
                if (res)
                {
                    return new SuccessResponseModel<bool>(res);
                }
                else
                {
                    return new BaseResponseModel(ReadOnlyValues.UserNotFound);
                }
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
        [ValidateModelState]
        [HttpPost("Edit")]
        public BaseResponseModel PostUserEdit([FromBody] UserUpdateModel userUpdateModel)
        {
            try
            {
                var result = userService.EditUser(userUpdateModel);
                if (result)
                {
                    return new SuccessResponseModel<bool>(result);
                }
                else
                {
                    return new BaseResponseModel(ReadOnlyValues.UnexpectedErrorMessage);
                }

            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }
    }
}
