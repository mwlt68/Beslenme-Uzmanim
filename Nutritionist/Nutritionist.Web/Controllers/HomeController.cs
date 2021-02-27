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
using AutoMapper;

namespace Nutritionist.Web.Controllers
{
    public class HomeController : BaseController
    {
        private int homeArticleCount=4;

        public HomeController(IMapper mapper) : base(mapper)
        {
        }

        public IActionResult Index()
        {
            var siteDataCountsBaseModel = Get<SiteDatasCount>(MyApiRequestModel.GetSiteDatasCount);
            var checkSiteDatasBaseResponseError = CheckBaseControllerError(siteDataCountsBaseModel);
            if (checkSiteDatasBaseResponseError == null)
            {
                var articleListBaseModel = Get<List<ArticleListModel>>(MyApiRequestModel.GetTakeFewArticles, homeArticleCount.ToString());
                var checkArticleListBaseResponseError = CheckBaseControllerError(articleListBaseModel);

                if (checkArticleListBaseResponseError == null)
                {
                    HomeContIndexModel homeContIndexModel = new HomeContIndexModel(articleListBaseModel.tobject, siteDataCountsBaseModel.tobject);
                    return View("~/Views/Home/Index.cshtml",homeContIndexModel);
                }
                else
                {
                    return Error(checkArticleListBaseResponseError);
                }

            }
            else
            {
                return Error(checkSiteDatasBaseResponseError);
            }
            
        }
        public IActionResult UserRegister()
        {
            return View("~/Views/Home/UserRegister.cshtml");

        }
        [HttpPost]
        public IActionResult UserRegister(UserInsertModel userInsertModel)
        {
            
            var userRegister = Post<bool>(MyApiRequestModel.PostUserRegister, userInsertModel);
            var checkUserBaseResponseError = CheckBaseControllerError(userRegister);

            if (checkUserBaseResponseError == null )
            {
                return Login();
            }
            else
            {
                return Error(checkUserBaseResponseError);
            }
        }
        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");

        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var userDetailModel = Post<UserDetailModel>(MyApiRequestModel.PostUserLogin,userLoginModel);
            var checkUserDetailBaseResponseError = CheckBaseControllerError(userDetailModel);

            if (checkUserDetailBaseResponseError == null)
            {
                return Index();
            }
            else return View();

        }
        public IActionResult Privacy()
        {
            return View();
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
