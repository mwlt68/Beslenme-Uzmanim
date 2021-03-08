using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Core.ActionFilters;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Services;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistUpdateModel = Nutritionist.Core.Models.Nutritionist.Update;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using Nutritionist.Core.StaticDatas;
using Microsoft.AspNetCore.Authorization;

namespace Nutritionist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionistController : ControllerBase
    {
        private NutritionistService nutritionistService;
        private UserService userService;
        public NutritionistController()
        {
            nutritionistService = new NutritionistService();
            userService = new UserService();
        }

        [ValidateModelState]
        [HttpPost("NutRegister")]
        public BaseResponseModel PostRegister([FromForm] NutritionistInsertModel nutritionistInsertModel)
        {
            try
            {
                var result = nutritionistService.NutritionistRegister(nutritionistInsertModel);
                return new SuccessResponseModel<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }
        [ValidateModelState]
        [HttpPost("Edit")]
        [Authorize(Policy = "MustNutritionist")]

        public BaseResponseModel PostEdit([FromForm] NutritionistUpdateModel nutritionistUpdateModel)
        {
            try
            {
                var result = nutritionistService.EditNutritionist(nutritionistUpdateModel);
                if (result)
                {
                    return new SuccessResponseModel<bool>(result);

                }
                else
                {
                    return new BaseResponseModel(ReadOnlyValues.NutritionistNotFound);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpGet("Detail/{id}")]
        public BaseResponseModel GetNutritionistDetail(int id)
        {
            try
            {
                var nutritionistDetail = nutritionistService.GetNutritionistDetailModel(id);
                if (nutritionistDetail != null)
                {
                    var userDetailModel = userService.GetUserDetailModel(nutritionistDetail.UserId);
                    if (userDetailModel != null)
                    {
                        nutritionistDetail.User = userDetailModel;
                        return new SuccessResponseModel<NutritionistDetailModel>(nutritionistDetail);
                    }

                }
                return new BaseResponseModel(ReadOnlyValues.NutritionistNotFound);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }

        [HttpGet("List")]

        public BaseResponseModel GetNutritionistsList( )
        {
            try
            {
                var nutritionistsListModel = nutritionistService.GetNutritionistListModels();
                if (nutritionistsListModel != null )
                {
                    foreach (var nutList in nutritionistsListModel)
                    {
                        var userListModel = userService.GetUserListModel(nutList.UserId);
                        if (userListModel != null)
                        {
                            nutList.User = userListModel; 
                        }
                    }
                    return new SuccessResponseModel<List<NutritionistListModel>>(nutritionistsListModel);
                }
                else return new BaseResponseModel(ReadOnlyValues.NutritionistsNotFound);

            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpDelete("Delete/{nutritionistId}")]
        [Authorize(Policy = "MustNutritionist")]
        public BaseResponseModel DeleteNutritionist(int nutritionistId)
        {
            try
            {
                var result = nutritionistService.RemoveNutritionist(nutritionistId);
                return new SuccessResponseModel<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }

        /*
        private bool ChechNutritionistAuthorize(int nutritionistId)
        {
            var currentUser = HttpContext.User;
            var nutritionistIdClaim=Int32.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "NutritionistId").Value);
            if (nutritionistIdClaim == nutritionistId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
    }
}
