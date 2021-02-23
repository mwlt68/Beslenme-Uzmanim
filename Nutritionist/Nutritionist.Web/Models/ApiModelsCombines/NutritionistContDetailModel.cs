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
        public NutritionistContDetailModel(List<CommentListModel> comments, List<ArticleListModel> articles, NutritionistDetailModel nutritionist)
        {
            this.comments = comments;
            this.nutritionist = nutritionist;
            this.articles = articles;
        }

        public List<CommentListModel> comments { get; set; }
        public List<ArticleListModel> articles { get; set; }
        public NutritionistDetailModel nutritionist{ get; set; }
    }
}
