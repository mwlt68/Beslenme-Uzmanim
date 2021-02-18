using System;
using System.Collections.Generic;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
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
