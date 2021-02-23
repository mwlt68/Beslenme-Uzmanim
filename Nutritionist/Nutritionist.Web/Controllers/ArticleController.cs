using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Web.Infrastructure;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using ArticleInsertModel = Nutritionist.Core.Models.Article.Insert;
using Nutritionist.Core.Models;
using Nutritionist.Core.Models.ResponseModels;

namespace Nutritionist.Web.Controllers
{
    public class ArticleController : BaseController
    {
        public IActionResult Detail(int id)
        {
            var articleDetailBaseModels = Get<ArticleDetailModel>(MyApiRequestModel.GetArticleDetail, id.ToString());
            var checkArticleBaseResponseError = CheckBaseControllerError(articleDetailBaseModels);
            if (checkArticleBaseResponseError == null)
            {
                return View(articleDetailBaseModels.tobject);
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
                return View(articleListBaseModels.tobject);
            }
            else
            {
                return Error(checkArticlesBaseResponseError);
            }
        }
    }
}
