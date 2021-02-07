using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Services;
using Nutritionist.Core.Models.Other;

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

        [HttpGet]
        public SiteDatasCount GetSiteDatasCount()
        {
            SiteDatasCount siteDatasCount = new SiteDatasCount();
            siteDatasCount.userCount = userService.GetUserCount();
            siteDatasCount.articleCount = articleService.GetArticleCount();
            siteDatasCount.nutritionistCount = nutritionistService.GetNutritionistCount();
            return siteDatasCount;
        }
    }
}
