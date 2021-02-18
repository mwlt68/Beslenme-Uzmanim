using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Web.Infrastructure;
using Nutritionist.Web.Models;
using Nutritionist.Core.Models;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using CommentListModel = Nutritionist.Core.Models.Comment.List;
using CommentInsertModel = Nutritionist.Core.Models.Comment.Insert;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
using ArticleInsertModel = Nutritionist.Core.Models.Article.Insert;
using UserListModel = Nutritionist.Core.Models.User.List;
using UserLoginModel = Nutritionist.Core.Models.User.Login;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;
using Nutritionist.Core.Models.Other;
using System.IO;
using Nutritionist.Web.Models.ApiModelsCombines;

namespace Nutritionist.Web.Controllers
{
    public class HomeController : BaseController
    {
        private int homeArticleCount=4;

        public IActionResult Index()
        {
            var articleListBaseModels = Get<List<ArticleListModel>>(new MyApiRequestModel(Core.Models.Controllers.Article, Methods.TakeFewArticles), homeArticleCount.ToString());
            var siteDataCountsBaseModel = Get<SiteDatasCount>(new MyApiRequestModel(Core.Models.Controllers.Home, Methods.SiteDatasCount));
            if (articleListBaseModels != null && articleListBaseModels is SuccessResponseModel<List<ArticleListModel>> &&
                siteDataCountsBaseModel != null && siteDataCountsBaseModel is SuccessResponseModel<SiteDatasCount>)
            {
                var articleListModels = (articleListBaseModels as SuccessResponseModel<List<ArticleListModel>>).responseObj;
                var siteDataCounts = (siteDataCountsBaseModel as SuccessResponseModel<SiteDatasCount>).responseObj;
                HomeContIndexModel homeContIndexModel = new HomeContIndexModel(articleListModels, siteDataCounts);
                return View(homeContIndexModel);
            }
            else return Error();
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var response = Post<UserDetailModel>(new MyApiRequestModel(Core.Models.Controllers.User, Methods.Login),userLoginModel);

            if (response != null && response is SuccessResponseModel<UserDetailModel>)
            {
                return Index();
            }
            else return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

/*
 Api Http Get Methods
            int id = 2;
            var data = Get<NutritionistDetailModel>(new MyApiRequestModel(Core.Models.Controllers.Nutritionist, Methods.NutDetail),id.ToString());
            var data2 = Get<SiteDatasCount>(new MyApiRequestModel(Core.Models.Controllers.Home, Methods.SiteDatasCount));
            var data3 = Get<List<NutritionistListModel>>(new MyApiRequestModel(Core.Models.Controllers.Nutritionist, Methods.NutList));
            var data4 = Get<List<CommentListModel>>(new MyApiRequestModel(Core.Models.Controllers.Comment, Methods.CommentList),"8");
            var data5 = Get<ArticleDetailModel>(new MyApiRequestModel(Core.Models.Controllers.Article, Methods.ArticleDetail),id.ToString());
            var data6 = Get<List<ArticleListModel>>(new MyApiRequestModel(Core.Models.Controllers.Article, Methods.ArticleList));
            var data7 = Get<List<ArticleListModel>>(new MyApiRequestModel(Core.Models.Controllers.Article, Methods.TakeFewArticles),id.ToString());
 Api Http Get Methods
            var data = Post<UserDetailModel>(new MyApiRequestModel(Core.Models.Controllers.User, Methods.Login),new UserLoginModel() { Username= "ahmet1234",Password= "ahmet123" });
            var data = Post<bool>(new MyApiRequestModel(Core.Models.Controllers.User, Methods.Register), new UserInsertModel() {  FirstName="Mehmet ALi" ,SecondName="Erbilen",ConfirmPassword= "mehmet6923", Username = "mehmet123", Password = "mehmet6923"});
            var data = Post<bool>(new MyApiRequestModel(Core.Models.Controllers.Comment, Methods.AddComment), new CommentInsertModel() 
            {
                UserId=12,
                NutritionstId=2,
                CommentContent= "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır"

            });
 Api Http Delete Methods
            var data = Delete<bool>(new MyApiRequestModel(Core.Models.Controllers.Comment, Methods.DeleteComment),"4","9");
            var data1 = Delete<bool>(new MyApiRequestModel(Core.Models.Controllers.Nutritionist, Methods.NutDelete),"3");
            var data = Delete<bool>(new MyApiRequestModel(Core.Models.Controllers.User, Methods.DeleteUser),"11");
            var data2 = Delete<bool>(new MyApiRequestModel(Core.Models.Controllers.Article, Methods.DeleteArticle),"2");
            
 */
