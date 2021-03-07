using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Core.Models;
using Nutritionist.Web.Infrastructure;
using Nutritionist.Web.Models;
using UserDetail = Nutritionist.Core.Models.User.Detail;
using UserUpdate = Nutritionist.Core.Models.User.Update;

namespace Nutritionist.Web.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMapper mapper) : base(mapper)
        {
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var userId = HttpContext.Session.GetInt32(ReadOnlyValues.UserIdSession);
            if (!userId.HasValue)
            {
                return View("~/Views/Home/Login.cshtml");
            }
            var userDetailResponse=Get<UserDetail>(MyApiRequestModel.GetUserDetail,false, userId.Value.ToString());
            var checkUserDetailBaseControllerError = CheckBaseControllerError(userDetailResponse);
            if (checkUserDetailBaseControllerError == null)
            {
                var userUpdateModel = mapper.Map<UserDetail, UserUpdate>(userDetailResponse.tobject);
                return View("~/Views/User/Edit.cshtml", userUpdateModel);
            }
            else
            {
                return Error(checkUserDetailBaseControllerError);
            }
        }

        [HttpPost]
        public IActionResult Edit(UserUpdate userUpdate) 
        {
            if (ModelState.IsValid)
            {
                var editRes = Post<bool>(MyApiRequestModel.PostEditUser, userUpdate, withToken: true);
                var checkEditBaseControllerError = CheckBaseControllerError(editRes);
                if (checkEditBaseControllerError == null)
                {
                    return View("~/Views/Home/Login.cshtml");
                }
                else
                {
                    return Error(checkEditBaseControllerError);
                }
            }
            else
            {
                return Edit();
            }

        }
       
        public IActionResult Delete()
        {
            var userId = HttpContext.Session.GetInt32(ReadOnlyValues.UserIdSession);
            if (!userId.HasValue)
            {
                return View("~/Views/Home/Login.cshtml");
            }
            else
            {
                if (userId.Value >= 0)
                {
                    var userDeleteResponse = Delete<bool>(MyApiRequestModel.DeleteUser, true, userId.Value.ToString());
                    var checkUserDeleteBaseControllerError = CheckBaseControllerError(userDeleteResponse);
                    if (checkUserDeleteBaseControllerError == null)
                    {

                        return View("~/Views/Home/Login.cshtml");
                    }
                    else
                    {
                        return Error(checkUserDeleteBaseControllerError);
                    }
                }
                else
                {
                    return Error(ErrorViewModel.GetDefaultException);
                }
            }

            
        }
        
    }
}
