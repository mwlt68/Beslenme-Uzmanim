using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Services;
using Nutritionist.Core.Models.Other;
using Nutritionist.Core.Models.ResponseModels;

namespace Nutritionist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        ArticleService articleService;
        UserService userService;
        NutritionistService nutritionistService;
        public HomeController()
        {
            articleService = new ArticleService();
            userService = new UserService();
            nutritionistService = new NutritionistService();
        }
        
        [HttpGet("SiteDatasCount")]
        public ActionResult<BaseResponseModel> GetSiteDatasCount()
        {
            try
            {
                SiteDatasCount siteDatasCount = new SiteDatasCount();
                siteDatasCount.userCount = userService.GetUserCount();
                siteDatasCount.articleCount = articleService.GetArticleCount();
                siteDatasCount.nutritionistCount = nutritionistService.GetNutritionistCount();
                return new SuccessResponseModel<SiteDatasCount>(siteDatasCount);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }

        }
    }
}
