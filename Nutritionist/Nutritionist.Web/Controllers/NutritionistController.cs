using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Web.Infrastructure;
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
using Nutritionist.Core.Models;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Web.Models.ApiModelsCombines;
using Nutritionist.Web.Models;

namespace Nutritionist.Web.Controllers
{
    public class NutritionistController : BaseController
    {
        public IActionResult List()
        {
            var nutritionistListModels = Get<List<NutritionistListModel>>(MyApiRequestModel.GetNutritionistsList);
            var checkNutBaseResponseError = CheckBaseControllerError(nutritionistListModels);

            if (checkNutBaseResponseError == null)
            {
                return View("~/Views/Nutritionist/List.cshtml",nutritionistListModels.tobject);
            }
            else
            {
            }
                return Error(checkNutBaseResponseError);
        }
        public IActionResult Detail(int id)
        {
            var nutDetailBaseModels = Get<NutritionistDetailModel>(MyApiRequestModel.GetNutritionistDetail,id.ToString());
            var checkNutBaseResponseError=CheckBaseControllerError(nutDetailBaseModels);
            if (checkNutBaseResponseError == null)
            {
                var commentListBaseModels = Get<List<CommentListModel>>(MyApiRequestModel.GetCommentList, nutDetailBaseModels.tobject.Id.ToString());
                var checkCommentBaseResponseError = CheckBaseControllerError(nutDetailBaseModels);
                var articleListBaseModels = Get<List<ArticleListModel>>(MyApiRequestModel.GetNutritionistArticlesList, nutDetailBaseModels.tobject.Id.ToString());
                var checkArticleBaseResponseError = CheckBaseControllerError(articleListBaseModels);
                if (checkCommentBaseResponseError == null && checkArticleBaseResponseError == null)
                {
                    NutritionistContDetailModel nutritionistContDetailModel = 
                        new NutritionistContDetailModel(commentListBaseModels.tobject,articleListBaseModels.tobject,nutDetailBaseModels.tobject);
                    return View("~/Views/Nutritionist/Detail.cshtml", nutritionistContDetailModel);
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
            return View("~/Views/Nutritionist/AddArticle.cshtml");
        }
        [HttpPost]
        public IActionResult AddArticle(ArticleInsertModel articleInsertModel)
        {
            articleInsertModel.NutritionistId = 2;
            var articleInsertModels = PostMultipartForm<bool>(MyApiRequestModel.PostArticleAdd,articleInsertModel);
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
    }
}
