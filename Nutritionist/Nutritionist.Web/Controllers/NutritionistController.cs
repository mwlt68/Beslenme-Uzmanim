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

namespace Nutritionist.Web.Controllers
{
    public class NutritionistController : BaseController
    {
        public IActionResult Detail(int id)
        {
            var nutDetailBaseModels = Get<NutritionistDetailModel>(new MyApiRequestModel(Core.Models.Controllers.Nutritionist, Methods.NutDetail),id.ToString());
            if (nutDetailBaseModels != null && nutDetailBaseModels is SuccessResponseModel<NutritionistDetailModel> )
            {
                var nutDetailModel = (nutDetailBaseModels as SuccessResponseModel<NutritionistDetailModel>).responseObj;
                var commentListsBaseModel = Get<List<CommentListModel>>(new MyApiRequestModel(Core.Models.Controllers.Comment, Methods.CommentList),nutDetailModel.Id.ToString());
                if (commentListsBaseModel != null && commentListsBaseModel is SuccessResponseModel<List<CommentListModel>> )
                {
                    var commentListsModel = (commentListsBaseModel as SuccessResponseModel<List<CommentListModel>>).responseObj;
                    NutritionistContDetailModel nutritionistContDetailModel = new NutritionistContDetailModel(commentListsModel, nutDetailModel);
                    return View(nutritionistContDetailModel);
                }
                    
            }
            return View();
        }
    }
}
