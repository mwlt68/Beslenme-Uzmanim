using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public IActionResult Edit(String id)
        {

            var userDetailResponse=Get<UserDetail>(MyApiRequestModel.GetUserDetail,id);
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
                var editRes = Post<bool>(MyApiRequestModel.PostEditUser, userUpdate);
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
                return Edit(userUpdate.Id.ToString());
            }

        }
        [HttpGet]
        public IActionResult Delete()
        {
            DeleteModel deleteModel = new DeleteModel() 
            {
                Id=12,
                Controller="User",
                Action="Delete",
                Message="Hesabının geçiçi olarak kapatılacaktır.",
                Title="Hesabı Kapat"
            };
            return View("~/Views/Shared/Delete.cshtml", deleteModel);
        }
        [HttpPost]
        public IActionResult Delete(String id)
        {
            int userId ;
            var chechParse=Int32.TryParse(id,out userId);
            if (chechParse)
            {
                if (userId >= 0)
                {
                    var userDeleteResponse = Delete<bool>(MyApiRequestModel.DeleteUser, userId.ToString());
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
            else
            {
                return Error(ErrorViewModel.GetDefaultException);
            }

        }
    }
}
