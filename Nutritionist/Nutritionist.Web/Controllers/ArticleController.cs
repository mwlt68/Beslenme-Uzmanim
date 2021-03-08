using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Web.Infrastructure;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using ArticleUpdateModel = Nutritionist.Core.Models.Article.Update;
using Nutritionist.Core.Models;
using Nutritionist.Core.Models.ResponseModels;
using AutoMapper;
using Nutritionist.Web.Models;
using Microsoft.AspNetCore.Http;

namespace Nutritionist.Web.Controllers
{
    public class ArticleController : BaseController
    {
        public ArticleController(IMapper mapper) : base(mapper)
        {
        }

        public IActionResult Detail(int id)
        {
            var articleDetailBaseModels = Get<ArticleDetailModel>(MyApiRequestModel.GetArticleDetail, false, id.ToString());
            var checkArticleBaseResponseError = CheckBaseControllerError(articleDetailBaseModels);
            if (checkArticleBaseResponseError == null)
            {
                return View(ReadOnlyValues.ArticleDetailViewPath, articleDetailBaseModels.tobject);
            }
            else
            {
                return Error(checkArticleBaseResponseError);
            }
        }
        public IActionResult NutritionistArticleList(String nutritionistId)
        {
            var nutritionistArticleListModels = Get<List<ArticleListModel>>(MyApiRequestModel.GetNutritionistArticlesList, false, nutritionistId);
            var checkNutArticleListBaseResponseError = CheckBaseControllerError(nutritionistArticleListModels);

            if (checkNutArticleListBaseResponseError == null)
            {
                return View(ReadOnlyValues.NutritionistArticlesViewPath, nutritionistArticleListModels.tobject);
            }
            else
            {
                return Error(checkNutArticleListBaseResponseError);
            }
        }
        public IActionResult List()
        {
            var articleListBaseModels = Get<List<ArticleListModel>>(MyApiRequestModel.GetArticlesList, false);
            var checkArticlesBaseResponseError = CheckBaseControllerError(articleListBaseModels);
            if (checkArticlesBaseResponseError == null)
            {
                return View(ReadOnlyValues.ArticleListViewPath, articleListBaseModels.tobject);
            }
            else
            {
                return Error(checkArticlesBaseResponseError);
            }
        }

        [HttpGet]
        public IActionResult Edit(String id)
        {
            var nutritionistId = HttpContext.Session.GetInt32(ReadOnlyValues.NutritionistIdSession);
            if (!nutritionistId.HasValue)
            {
                return View(ReadOnlyValues.HomeLoginViewPath);
            }
            var articleDetailResponse = Get<ArticleDetailModel>(MyApiRequestModel.GetArticleDetail, false, id);
            var checkArticleDetailBaseControllerError = CheckBaseControllerError(articleDetailResponse);
            if (checkArticleDetailBaseControllerError == null)
            {
                var articleUpdateModel = mapper.Map<ArticleDetailModel, ArticleUpdateModel>(articleDetailResponse.tobject);
                return View(ReadOnlyValues.ArticleEditViewPath, articleUpdateModel);
            }
            else
            {
                return Error(checkArticleDetailBaseControllerError);
            }
        }

        [HttpPost]
        public IActionResult Edit(ArticleUpdateModel articleUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var editRes = PostMultipartForm<bool>(MyApiRequestModel.PostArticleEdit, articleUpdateModel,true);
                var checkEditBaseControllerError = CheckBaseControllerError(editRes);
                if (checkEditBaseControllerError == null)
                {
                    return Detail(articleUpdateModel.Id);
                }
                else
                {
                    return Error(checkEditBaseControllerError);
                }
            }
            else
            {
                return Edit(articleUpdateModel.Id.ToString());
            }

        }
        public IActionResult Delete(String id)
        {
            var nutritionistId = HttpContext.Session.GetInt32(ReadOnlyValues.NutritionistIdSession);
            if (!nutritionistId.HasValue)
            {
                return View(ReadOnlyValues.HomeLoginViewPath);
            }
            else
            {
                var articleDeleteResponse = Delete<bool>(MyApiRequestModel.DeleteArticle, true, id);
                var checkArticleDeleteBaseControllerError = CheckBaseControllerError(articleDeleteResponse);
                if (checkArticleDeleteBaseControllerError == null)
                {

                    return NutritionistArticleList(nutritionistId.Value.ToString());
                }
                else
                {
                    return Error(checkArticleDeleteBaseControllerError);
                }
            }

        }
    }
}
