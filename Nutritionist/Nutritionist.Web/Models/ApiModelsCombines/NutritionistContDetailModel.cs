using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
using CommentListModel = Nutritionist.Core.Models.Comment.List;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;

namespace Nutritionist.Web.Models.ApiModelsCombines
{
    public class NutritionistContDetailModel
    {
        public NutritionistContDetailModel(List<CommentListModel> comments, NutritionistDetailModel nutritionist)
        {
            this.comments = comments;
            this.nutritionist = nutritionist;
        }

        public List<CommentListModel> comments { get; set; }
        public NutritionistDetailModel nutritionist{ get; set; }
    }
}
