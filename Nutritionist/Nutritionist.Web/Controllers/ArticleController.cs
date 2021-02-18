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
            var articleDetailBaseModel = Get<ArticleDetailModel>(new MyApiRequestModel(Core.Models.Controllers.Article, Methods.ArticleDetail), id.ToString());
            if (articleDetailBaseModel != null && articleDetailBaseModel is SuccessResponseModel<ArticleDetailModel>)
            {
                var articleDetailModel = (articleDetailBaseModel as SuccessResponseModel<ArticleDetailModel>).responseObj;
                return View(articleDetailModel);
            }
            return View();
        }
    }
}
