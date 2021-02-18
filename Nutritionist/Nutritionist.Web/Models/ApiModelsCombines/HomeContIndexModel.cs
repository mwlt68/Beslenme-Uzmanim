using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using Nutritionist.Core.Models.Other;

namespace Nutritionist.Web.Models.ApiModelsCombines
{
    public class HomeContIndexModel
    {
        public HomeContIndexModel(List<ArticleListModel> articlesList, SiteDatasCount siteDataCounts)
        {
            this.articlesList = articlesList;
            this.siteDataCounts = siteDataCounts;
        }

        public List<ArticleListModel> articlesList { get; set; }
        public SiteDatasCount siteDataCounts { get; set; }

    }
}
