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

namespace Nutritionist.Web.Controllers
{
    public class ArticleController : BaseController
    {
        public ArticleController(IMapper mapper) : base(mapper)
        {
        }

        public IActionResult Detail(int id)
        {
            var articleDetailBaseModels = Get<ArticleDetailModel>(MyApiRequestModel.GetArticleDetail, id.ToString());
            var checkArticleBaseResponseError = CheckBaseControllerError(articleDetailBaseModels);
            if (checkArticleBaseResponseError == null)
            {
                return View("~/Views/Article/Detail.cshtml",articleDetailBaseModels.tobject);
            }
            else
            {
                return Error(checkArticleBaseResponseError);
            }
        }
        public IActionResult List()
        {
            var articleListBaseModels = Get<List<ArticleListModel>>(MyApiRequestModel.GetArticlesList);
            var checkArticlesBaseResponseError = CheckBaseControllerError(articleListBaseModels);
            if (checkArticlesBaseResponseError == null)
            {
                return View("~/Views/Article/List.cshtml", articleListBaseModels.tobject);
            }
            else
            {
                return Error(checkArticlesBaseResponseError);
            }
        }

        [HttpGet]
        public IActionResult Edit(String id)
        {

            var articleDetailResponse = Get<ArticleDetailModel>(MyApiRequestModel.GetArticleDetail, id);
            var checkArticleDetailBaseControllerError = CheckBaseControllerError(articleDetailResponse);
            if (checkArticleDetailBaseControllerError == null)
            {
                var articleUpdateModel = mapper.Map<ArticleDetailModel, ArticleUpdateModel>(articleDetailResponse.tobject);
                return View("~/Views/Article/Edit.cshtml", articleUpdateModel);
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
                var editRes = PostMultipartForm<bool>(MyApiRequestModel.PostArticleEdit, articleUpdateModel);
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

        [HttpGet]
        public IActionResult Delete()
        {
            DeleteModel deleteModel = new DeleteModel()
            {
                Id = 3,
                Controller = "Article",
                Action = "Delete",
                Message = "Makaleniz geçici olarak silinecektir.",
                Title = "Makaleyi Kaldır"
            };
            return View("~/Views/Shared/Delete.cshtml", deleteModel);
        }
        [HttpPost]
        public IActionResult Delete(String id)
        {
            int articleId;
            var chechParse = Int32.TryParse(id, out articleId);
            if (chechParse)
            {
                if (articleId >= 0)
                {
                    var articleDeleteResponse = Delete<bool>(MyApiRequestModel.DeleteArticle, articleId.ToString());
                    var checkArticleDeleteBaseControllerError = CheckBaseControllerError(articleDeleteResponse);
                    if (checkArticleDeleteBaseControllerError == null)
                    {

                        return List();
                    }
                    else
                    {
                        return Error(checkArticleDeleteBaseControllerError);
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
