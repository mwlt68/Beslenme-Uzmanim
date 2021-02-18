using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Core.Models
{
    public enum Controllers
    {
        Home,
        User,
        Nutritionist,
        Article,
        Comment
    }
    public enum Methods
    {
        // Get SiteDatasCount
        SiteDatasCount,
        Login,
        Register,
        DeleteUser,
        NutRegister,
        // Get NutDetail/{id}
        NutDetail,
        // Get NutList
        NutList,
        // Delete NutDelete
        NutDelete,
        AddArticle,
        // Get ArticleDetail/{id}
        ArticleDetail,
        // Get ArticleList
        ArticleList,
        // GEt TakeFewArticles/{count}
        TakeFewArticles,
        DeleteArticle,
        AddComment,
        // Get CommentList/{nutritionistId}
        CommentList,
        // Delete DeleteComment
        DeleteComment,
    }
    public class MyApiRequestModel
    {
        public Controllers controller;
        public Methods method;

        public MyApiRequestModel(Controllers controller, Methods method)
        {
            this.controller = controller;
            this.method = method;
        }
    }
}
