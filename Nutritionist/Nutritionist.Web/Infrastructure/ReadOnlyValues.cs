using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritionist.Web.Infrastructure
{
    public class ReadOnlyValues
    {
        #region ViewData

        public static readonly String LoginError= "Login_Error";

        #endregion

        #region Session
        // JWT
        public static readonly String AuthenticationScheme= "Bearer"; 
        // Session Values
        public static readonly String UserIdSession = "UserId"; //int
        public static readonly String TokenSession = "Token"; //String
        public static readonly String NutritionistIdSession = "NutId"; //int

        #endregion
        #region ViewPath

        public static readonly String HomeLoginViewPath = "~/Views/Home/Login.cshtml";
        public static readonly String UserEditViewPath = "~/Views/User/Edit.cshtml";
        public static readonly String NutritionistAddViewPath = "~/Views/Nutritionist/Add.cshtml";
        public static readonly String NutritionistListViewPath = "~/Views/Nutritionist/List.cshtml";
        public static readonly String NutritionistDetailViewPath = "~/Views/Nutritionist/Detail.cshtml";
        public static readonly String NutritionistAddArticleViewPath = "~/Views/Nutritionist/AddArticle.cshtml";
        public static readonly String HomeIndexViewPath = "~/Views/Home/Index.cshtml";
        public static readonly String HomeUserRegisterViewPath = "~/Views/Home/UserRegister.cshtml";
        public static readonly String ArticleDetailViewPath = "~/Views/Article/Detail.cshtml";
        public static readonly String NutritionistArticlesViewPath = "~/Views/Nutritionist/NutritionistArticles.cshtml";
        public static readonly String ArticleListViewPath = "~/Views/Article/List.cshtml";
        public static readonly String ArticleEditViewPath = "~/Views/Article/Edit.cshtml";
        public static readonly String SharedErrorViewPath = "~/Views/Shared/Error.cshtml";

        #endregion

    }
}
