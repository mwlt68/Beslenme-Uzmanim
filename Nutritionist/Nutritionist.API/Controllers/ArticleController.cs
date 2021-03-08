using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Services;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using ArticleInsertModel = Nutritionist.Core.Models.Article.Insert;
using ArticleUpdateModel = Nutritionist.Core.Models.Article.Update;
using Nutritionist.Core.StaticDatas;
using Nutritionist.Core.ActionFilters;
using Microsoft.AspNetCore.Authorization;

namespace Nutritionist.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class ArticleController : ControllerBase
    {
        ArticleService articleService;
        NutritionistService nutritionistService;
        UserService userService;
        public ArticleController()
        {
            articleService = new ArticleService();
            nutritionistService = new NutritionistService();
            userService = new UserService();
        }
        [ValidateModelState]
        [HttpPost("Add")]
        [Authorize(Policy = "MustNutritionist")]
        public ActionResult<BaseResponseModel> PostAddArticle([FromForm] ArticleInsertModel articleInsertModel)
        {
            try
            {
                var result = articleService.AddArticle(articleInsertModel);
                if (result)
                {
                    return new SuccessResponseModel<bool>(true);
                }
                else
                {
                    return new BaseResponseModel(ReadOnlyValues.ArticleNotAdd);
                }
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }

        [ValidateModelState]
        [HttpPost("Edit")]
        [Authorize(Policy = "MustNutritionist")]
        public BaseResponseModel PostEdit([FromForm] ArticleUpdateModel articleUpdateModel)
        {
            try
            {
                var result = articleService.EditArticle(articleUpdateModel);
                if (result)
                {
                    return new SuccessResponseModel<bool>(result);

                }
                else
                {
                    return new BaseResponseModel(ReadOnlyValues.ArticleNotFound);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(ex.Message);
            }
        }

        [HttpGet("Detail/{id}")]
        public ActionResult<BaseResponseModel> GetArticleDetail(int id)
        {
            try
            {
                ArticleDetailModel articleDetail = articleService.GetArticleDetail(id);
                if (articleDetail != null)
                {
                    var nutritionistListModel=nutritionistService.GetNutritionistListModel(articleDetail.NutritionistId);
                    if (nutritionistListModel != null)
                    {
                        nutritionistListModel.User= userService.GetUserListModel(nutritionistListModel.UserId);
                        articleDetail.Nutritionist = nutritionistListModel;
                        return new SuccessResponseModel<ArticleDetailModel>(articleDetail);
                    }
                }
                return new BaseResponseModel(ReadOnlyValues.ArticleNotFound);

            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
       
       [HttpGet("List")]
       public ActionResult<BaseResponseModel> GetArticlesList()
       {
           try
           {
               List<ArticleListModel> articlesListModel = articleService.GetArticlesList();
                if (articlesListModel != null)
                {
                    foreach (var article in articlesListModel)
                    {
                        var nutListModel = nutritionistService.GetNutritionistListModel(article.NutritionistId);
                        if (nutListModel != null)
                        {
                            var nutUserModel = userService.GetUserListModel(nutListModel.UserId);
                            if (nutListModel != null )
                            {
                                nutListModel.User = nutUserModel;
                                article.Nutritionist = nutListModel;
                            }

                        }
                    }
                    return new SuccessResponseModel<List<ArticleListModel>>(articlesListModel);
                }
                return new BaseResponseModel(ReadOnlyValues.ArticlesNotFound);
            }
           catch (Exception ex)
           {

               return new BaseResponseModel(ex.Message);
           }
       }
        [HttpGet("NutArticleList/{nutritionistId}")]
        public ActionResult<BaseResponseModel> GetNutritionistArticlesList(int nutritionistId)
        {
            try
            {
                List<ArticleListModel> articlesListModel = articleService.GetNutritionistArticles(nutritionistId);
                if (articlesListModel != null)
                {
                    foreach (var article in articlesListModel)
                    {
                        var nutListModel = nutritionistService.GetNutritionistListModel(article.NutritionistId);
                        if (nutListModel != null)
                        {
                            var nutUserModel = userService.GetUserListModel(nutListModel.UserId);
                            if (nutListModel != null)
                            {
                                nutListModel.User = nutUserModel;
                                article.Nutritionist = nutListModel;


                            }

                        }
                    }
                    return new SuccessResponseModel<List<ArticleListModel>>(articlesListModel);
                }
                return new BaseResponseModel(ReadOnlyValues.ArticlesNotFound);
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpDelete("Delete/{articleId}")]
        [Authorize(Policy = "MustNutritionist")]

        public ActionResult<BaseResponseModel> DeleteArticle(int articleId)
        {
            try
            {
                bool res = articleService.RemoveArticle(articleId);
                if (res)
                {
                    return new SuccessResponseModel<bool>(res);
                }
                else
                {
                    return new BaseResponseModel(ReadOnlyValues.ArticleNotFound);
                }
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
        
      [HttpGet("TakeFewArticles/{count}")]
      public ActionResult<BaseResponseModel> TakeFewArticles(int count)
      {
          try
          {
                List<ArticleListModel> articlesListModel = articleService.GetArticlesList(true,count);
                if (articlesListModel != null)
                {
                    foreach (var article in articlesListModel)
                    {
                        var nutListModel = nutritionistService.GetNutritionistListModel(article.NutritionistId);
                        if (nutListModel != null)
                        {
                            var nutUserModel = userService.GetUserListModel(nutListModel.UserId);
                            if (nutListModel != null)
                            {
                                nutListModel.User = nutUserModel;
                                article.Nutritionist = nutListModel;


                            }

                        }
                    }
                    return new SuccessResponseModel<List<ArticleListModel>>(articlesListModel);
                }
                return new BaseResponseModel(ReadOnlyValues.ArticleNotFound);
            }
          catch (Exception ex)
          {

              return new BaseResponseModel(ex.Message);
          }
      }



    }
}
