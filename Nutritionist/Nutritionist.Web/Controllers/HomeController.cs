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
using UserLoginResposeModel = Nutritionist.Core.Models.User.LoginRespose;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;
using Nutritionist.Core.Models.Other;
using System.IO;
using Nutritionist.Web.Models.ApiModelsCombines;
using AutoMapper;
using Microsoft.AspNetCore.Http;

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
            var siteDataCountsBaseModel = Get<SiteDatasCount>(MyApiRequestModel.GetSiteDatasCount, false);
            var checkSiteDatasBaseResponseError = CheckBaseControllerError(siteDataCountsBaseModel);
            if (checkSiteDatasBaseResponseError == null)
            {
                var articleListBaseModel = Get<List<ArticleListModel>>(MyApiRequestModel.GetTakeFewArticles, false,homeArticleCount.ToString());
                var checkArticleListBaseResponseError = CheckBaseControllerError(articleListBaseModel);

                if (checkArticleListBaseResponseError == null)
                {
                    HomeContIndexModel homeContIndexModel = new HomeContIndexModel(articleListBaseModel.tobject, siteDataCountsBaseModel.tobject);
                    return View(ReadOnlyValues.HomeIndexViewPath, homeContIndexModel);
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
            return View(ReadOnlyValues.HomeUserRegisterViewPath);

        }
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove(ReadOnlyValues.UserIdSession);
            HttpContext.Session.Remove(ReadOnlyValues.NutritionistIdSession);
            HttpContext.Session.Remove(ReadOnlyValues.TokenSession);
            return Index();
        }
        [HttpPost]
        public IActionResult UserRegister(UserInsertModel userInsertModel)
        {
            if (ModelState.IsValid)
            {
                var userRegister = Post<bool>(MyApiRequestModel.PostUserRegister, userInsertModel);
                var checkUserBaseResponseError = CheckBaseControllerError(userRegister);

                if (checkUserBaseResponseError == null)
                {
                    return Login();
                }
                else
                {
                    return Error(checkUserBaseResponseError);
                }
            }
            else
                return UserRegister();
           
        }
        public IActionResult Login()
        {
            return View(ReadOnlyValues.HomeLoginViewPath);

        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var userLoginResModel = Post<UserLoginResposeModel>(MyApiRequestModel.PostUserLogin, userLoginModel);
                var checkUserDetailBaseResponseError = CheckBaseControllerError(userLoginResModel);

                if (checkUserDetailBaseResponseError == null)
                {
                    ViewData[ReadOnlyValues.LoginError] = null;
                    HttpContext.Session.SetInt32(ReadOnlyValues.UserIdSession, userLoginResModel.tobject.UserId);
                    HttpContext.Session.SetInt32(ReadOnlyValues.NutritionistIdSession, userLoginResModel.tobject.NutritionistId);
                    HttpContext.Session.SetString(ReadOnlyValues.TokenSession, userLoginResModel.tobject.Token);
                    return Index();
                }
                else 
                {
                    ViewData[ReadOnlyValues.LoginError] = userLoginResModel.errorViewModel.Description;
                    return Login();
                } 
            }
            else
                return Login();

        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}

