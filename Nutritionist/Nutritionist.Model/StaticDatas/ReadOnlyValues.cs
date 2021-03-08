using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Core.StaticDatas
{
    public static class ReadOnlyValues
    {
        #region ResponseModel
        public static readonly String SuccessMessage = "Başarılı bir şekilde çalıştı.";
        public static readonly String ErrorMessage = "Çalışma sırasında hata meydana geldi.";
        public static readonly String UnexpectedErrorMessage = "Beklenmedik bir hata meydana geldi.";
        #endregion
        #region ResponseMessage
        public static readonly String NutritionistNotFound = "Beslenme uzmanı bulunamadı !";
        public static readonly String NutritionistsNotFound = "Beslenme uzmanları bulunamadı !";
        public static readonly String ArticleNotFound = "Makale bulunamadı !";
        public static readonly String ArticlesNotFound = "Makaleler bulunamadı !";
        public static readonly String ArticleNotAdd = "Makale eklenemedi !";
        public static readonly String CommentNotFound = "Yorum bulunamadı !";
        public static readonly String CommentsNotFound = "Yorumlar bulunamadı !";
        public static readonly String UserNotFound = "Kullanıcı bulunamadı!";
        public static readonly String UsersNotFound = "Kullanıcılar bulunamadı !";
        public static readonly String UsernameOrPasswordError = "Kullanıcı adı yada şifre hatalı !";
        #endregion

    }


}
