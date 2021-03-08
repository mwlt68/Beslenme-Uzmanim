using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Web.Infrastructure;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistUpdateModel = Nutritionist.Core.Models.Nutritionist.Update;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
using CommentListModel = Nutritionist.Core.Models.Comment.List;
using CommentInsertModel = Nutritionist.Core.Models.Comment.Insert;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
using ArticleInsertModel = Nutritionist.Core.Models.Article.Insert;
using UserListModel = Nutritionist.Core.Models.User.List;
using UserLoginModel = Nutritionist.Core.Models.User.Login;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;
using Nutritionist.Core.Models;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Web.Models.ApiModelsCombines;
using Nutritionist.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Nutritionist.Web.Controllers
{
    public class NutritionistController : BaseController
    {
        public NutritionistController(IMapper mapper) : base(mapper)
        {
        }

        public IActionResult Add()
        {
            return View(ReadOnlyValues.NutritionistAddViewPath);
        }
        [HttpPost]
        public IActionResult Add(NutritionistInsertModel nutritionistInsertModel)
        {

            if (!ModelState.IsValid)
            {
                return Add();
            }
            else
            {
                var userId = HttpContext.Session.GetInt32(ReadOnlyValues.UserIdSession);
                if (!userId.HasValue)
                {
                    return View(ReadOnlyValues.HomeLoginViewPath);
                }
                nutritionistInsertModel.UserId = userId.Value;
                var nutritionistInsertModels = PostMultipartForm<bool>(MyApiRequestModel.PostNutritionistRegister, nutritionistInsertModel);
                var checkNutritionistInsertBaseResponseError = CheckBaseControllerError(nutritionistInsertModels);
                if (checkNutritionistInsertBaseResponseError == null)
                {
                    return View(ReadOnlyValues.HomeLoginViewPath);
                }
                else
                {
                    return Error(checkNutritionistInsertBaseResponseError);
                }
            }

        }
        public IActionResult List()
        {
            var nutritionistListModels = Get<List<NutritionistListModel>>(MyApiRequestModel.GetNutritionistsList, false);
            var checkNutBaseResponseError = CheckBaseControllerError(nutritionistListModels);

            if (checkNutBaseResponseError == null)
            {
                return View(ReadOnlyValues.NutritionistListViewPath, nutritionistListModels.tobject);
            }
            else
            {
            }
                return Error(checkNutBaseResponseError);
        }

        public IActionResult Detail(int id)
        {
            var nutDetailBaseModels = Get<NutritionistDetailModel>(MyApiRequestModel.GetNutritionistDetail, false, id.ToString());
            var checkNutBaseResponseError=CheckBaseControllerError(nutDetailBaseModels);
            if (checkNutBaseResponseError == null)
            {
                var commentListBaseModels = Get<List<CommentListModel>>(MyApiRequestModel.GetCommentList, false, nutDetailBaseModels.tobject.Id.ToString());
                var checkCommentBaseResponseError = CheckBaseControllerError(nutDetailBaseModels);
                var articleListBaseModels = Get<List<ArticleListModel>>(MyApiRequestModel.GetNutritionistArticlesList, false, nutDetailBaseModels.tobject.Id.ToString());
                var checkArticleBaseResponseError = CheckBaseControllerError(articleListBaseModels);
                if (checkCommentBaseResponseError == null && checkArticleBaseResponseError == null)
                {
                    NutritionistContDetailModel nutritionistContDetailModel = 
                        new NutritionistContDetailModel(commentListBaseModels.tobject,articleListBaseModels.tobject,nutDetailBaseModels.tobject);
                    return View(ReadOnlyValues.NutritionistDetailViewPath, nutritionistContDetailModel);
                }
                else
                {
                    return Error(checkCommentBaseResponseError, checkArticleBaseResponseError);
                }

            }
            else
            {
                return Error(checkNutBaseResponseError);
            }
        }
        public IActionResult AddArticle()
        {
            var nutritionistId = HttpContext.Session.GetInt32(ReadOnlyValues.NutritionistIdSession);
            if (!nutritionistId.HasValue)
            {
                return View(ReadOnlyValues.HomeLoginViewPath);
            }
            return View(ReadOnlyValues.NutritionistAddArticleViewPath);
        }
        [HttpPost]
        public IActionResult AddArticle(ArticleInsertModel articleInsertModel)
        {
            if (ModelState.IsValid)
            {
                var nutritionistId = HttpContext.Session.GetInt32(ReadOnlyValues.NutritionistIdSession);
                if (!nutritionistId.HasValue)
                {
                    return View(ReadOnlyValues.HomeLoginViewPath);
                }
                articleInsertModel.NutritionistId = nutritionistId.Value;
                var articleInsertModels = PostMultipartForm<bool>(MyApiRequestModel.PostArticleAdd, articleInsertModel, true);
                var checkArticleInsertBaseResponseError = CheckBaseControllerError(articleInsertModels);

                if (checkArticleInsertBaseResponseError == null)
                {
                    return Detail(articleInsertModel.NutritionistId);
                }
                else if (!ModelState.IsValid)
                {
                    return AddArticle();
                }
                else
                {
                    return Error(checkArticleInsertBaseResponseError);
                }
            }
            else
            {
                return AddArticle();
            }
            
        }

        [HttpPost]
        public IActionResult AddComment(String commentContent, String nutritionistId)
        {
            var userId = HttpContext.Session.GetInt32(ReadOnlyValues.UserIdSession);
            if (!userId.HasValue)
            {
                return View(ReadOnlyValues.HomeLoginViewPath);
            }
            int nutritionistIdInt = Int32.Parse(nutritionistId);
            if (String.IsNullOrEmpty(commentContent)|| nutritionistIdInt < 0 || commentContent.Trim().Length <= 0)
            {
                return Detail(nutritionistIdInt);
            }
            else
            {
                CommentInsertModel comment = new CommentInsertModel() {
                    CommentContent = commentContent,
                    NutritionstId = nutritionistIdInt,
                    UserId = userId.Value,
                };
                var commentInsertModels = Post<bool>(MyApiRequestModel.PostAddComment, comment,withToken:true);
                var checkCommentInsertBaseResponseError = CheckBaseControllerError(commentInsertModels);
                if (checkCommentInsertBaseResponseError == null)
                {
                    return Detail(nutritionistIdInt);
                }
                else
                {
                    return Error(checkCommentInsertBaseResponseError);
                }
            }
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var nutritionistId = HttpContext.Session.GetInt32(ReadOnlyValues.NutritionistIdSession);
            if (!nutritionistId.HasValue)
            {
                return View(ReadOnlyValues.HomeLoginViewPath);
            }
            var nutDetailResponse = Get<NutritionistDetailModel>(MyApiRequestModel.GetNutritionistDetail, false, nutritionistId.Value.ToString());
            var checkNutDetailBaseControllerError = CheckBaseControllerError(nutDetailResponse);
            if (checkNutDetailBaseControllerError == null)
            {
                var nutUpdateModel= mapper.Map<NutritionistDetailModel, NutritionistUpdateModel>(nutDetailResponse.tobject);
                return View("~/Views/Nutritionist/Edit.cshtml", nutUpdateModel);
            }
            else
            {
                return Error(checkNutDetailBaseControllerError);
            }
        }

        [HttpPost]
        public IActionResult Edit(NutritionistUpdateModel nutritionistUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var editRes = PostMultipartForm<bool>(MyApiRequestModel.PostEditNutritionist, nutritionistUpdateModel,true);
                var checkEditBaseControllerError = CheckBaseControllerError(editRes);
                if (checkEditBaseControllerError == null)
                {
                    return Detail(nutritionistUpdateModel.Id);
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
            var nutritionistId = HttpContext.Session.GetInt32(ReadOnlyValues.NutritionistIdSession);
            if (!nutritionistId.HasValue)
            {
                return View(ReadOnlyValues.HomeLoginViewPath);
            }
            if (nutritionistId.Value >= 0)
            {
                var nutDeleteResponse = Delete<bool>(MyApiRequestModel.DeleteNutritionist, true, nutritionistId.Value.ToString());
                var checkNutDeleteBaseControllerError = CheckBaseControllerError(nutDeleteResponse);
                if (checkNutDeleteBaseControllerError == null)
                {

                    return View(ReadOnlyValues.HomeLoginViewPath);
                }
                else
                {
                    return Error(checkNutDeleteBaseControllerError);
                }
            }
            else
            {
                return Error(ErrorViewModel.GetDefaultException);
            }
        }
        public IActionResult CommentDelete(String id)
        {
            var userId = HttpContext.Session.GetInt32(ReadOnlyValues.UserIdSession);
            if (!userId.HasValue)
            {
                return View(ReadOnlyValues.HomeLoginViewPath);
            }
            if (userId.Value >= 0)
            {
                var nutDeleteResponse = Delete<bool>(MyApiRequestModel.DeleteComment, true, id);
                var checkNutDeleteBaseControllerError = CheckBaseControllerError(nutDeleteResponse);
                if (checkNutDeleteBaseControllerError == null)
                {

                    return Detail(userId.Value);
                }
                else
                {
                    return Error(checkNutDeleteBaseControllerError);
                }
            }
            else
            {
                return Error(ErrorViewModel.GetDefaultException);
            }
        }


    }
}
