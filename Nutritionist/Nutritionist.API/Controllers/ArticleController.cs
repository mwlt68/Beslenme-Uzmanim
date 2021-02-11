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

namespace Nutritionist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        ArticleService articleService;
        public ArticleController()
        {
            articleService = new ArticleService();
        }

        [HttpPost("AddArticle")]
        public ActionResult<BaseResponseModel> AddArticle([FromForm] ArticleInsertModel articleInsertModel)
        {
            try
            {
                articleService.AddArticle(articleInsertModel);
                return Ok(new SuccessResponseModel<bool>(true));
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }

        [HttpGet("ArticleDetail")]
        public ActionResult<BaseResponseModel> GetArticleDetail(int id)
        {
            try
            {
                var articleDetail= articleService.GetArticleDetail(id);
                return Ok(new SuccessResponseModel<ArticleDetailModel>(articleDetail));
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpGet("GetArticles")]
        public ActionResult<BaseResponseModel> GetArticles()
        {
            try
            {
                List<ArticleListModel> articles = articleService.GetArticles().ToList();
                return Ok(new SuccessResponseModel<List<ArticleListModel>>(articles));
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpGet("TakeFewArticles")]
        public ActionResult<BaseResponseModel> TakeFewArticles(int count)
        {
            try
            {
                List<ArticleListModel> articles = articleService.GetArticles(true, count).ToList();
                return Ok(new SuccessResponseModel<List<ArticleListModel>>(articles));
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpDelete("DeleteArticle")]
        public ActionResult<BaseResponseModel> DeleteArticle(int articleId)
        {
            try
            {
                bool res = articleService.SoftDeleteArticle(articleId);
                if (res)
                {
                    return Ok(new SuccessResponseModel<bool>(res));
                }
                else
                {
                    return new BaseResponseModel("Article cannot found !");
                }
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }


    }
}
