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
using UserLoginResponseModel = Nutritionist.Core.Models.User.LoginRespose;
using UserUpdateModel = Nutritionist.Core.Models.User.Update;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Core.StaticDatas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace Nutritionist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        UserService userService;
        NutritionistService nutritionistService;
        private IConfiguration _config;
        public UserController(IConfiguration config)
        {
            userService = new UserService();
            nutritionistService = new NutritionistService();
            _config = config;
        }
        [ValidateModelState]
        [HttpPost("Login")]
        public ActionResult <BaseResponseModel> PostUserLogin([FromBody] UserLoginModel userLoginModel)
        {
            try
            {
                int userId = userService.GetIdFromUserLogin(userLoginModel);
                if (userId >=0 )
                {
                    int nutId = nutritionistService.CheckNutritionistFromUserId(userId);
                    var tokenString = GenerateJSONWebToken(userId, nutId);
                    var loginResponse = new UserLoginResponseModel() {UserId=userId,NutritionistId=nutId,Token= tokenString };
                    var responseModel= new SuccessResponseModel<UserLoginResponseModel>(loginResponse);
                    return Ok(responseModel);
                }
                else return new BaseResponseModel("Kullanıcı bulunamadı !");
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
        
        public BaseResponseModel GetUserDetail(int userId)
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
        [Authorize]
        public BaseResponseModel DeleteUser(int userId)
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
        [Authorize]
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

        private string GenerateJSONWebToken(int userId,int nutritionistId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("userId", userId.ToString()));

            if(nutritionistId >= 0)
            {
                claims.Add(new Claim("nutritionistId", nutritionistId.ToString()));
            }

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMonths(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
