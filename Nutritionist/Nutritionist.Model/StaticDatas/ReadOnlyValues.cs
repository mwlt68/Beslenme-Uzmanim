using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Core.StaticDatas
{
    public static class ReadOnlyValues
    {
        #region ResponseModel
        public static readonly String SuccessMessage = "Request worked successfully.";
        public static readonly String ErrorMessage = "Request not worked successfully.";
        public static readonly String UnexpectedErrorMessage = "Beklenmedik bir hata meydana geldi.";
        #endregion
        #region ResponseMessage
        public static readonly String NutritionistNotFound = "Nutritionist detail does not found !";
        public static readonly String NutritionistsNotFound = "Nutritionists do not found !";
        public static readonly String ArticleNotFound = "Article does not found !";
        public static readonly String ArticlesNotFound = "Articles do not found !";
        public static readonly String CommentNotFound = "Comment does not found !";
        public static readonly String CommentsNotFound = "Comments do not found !";
        public static readonly String UserNotFound = "User does not found !";
        public static readonly String UsersNotFound = "Users do not found !";
        #endregion
    }
    
    
}
