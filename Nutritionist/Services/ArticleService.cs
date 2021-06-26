using Nutritionist.Data.Entities;
using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ArticleListModel= Nutritionist.Core.Models.Article.List;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using ArticleInsertModel = Nutritionist.Core.Models.Article.Insert;
using ArticleUpdateModel = Nutritionist.Core.Models.Article.Update;
using Nutritionist.Core.Helper;
using System.Linq;

namespace Nutritionist.Services
{
    public class ArticleService:BaseServices
    {
        private ArticleRepository articleRepository = new ArticleRepository();
        private NutritionistRepository nutritionistRepository = new NutritionistRepository();

        // TODO: Maybe this get methods can convert to pagination structure.

        public bool AddArticle(ArticleInsertModel articleInsertModel)
        {
            Article article = mapper.Map<ArticleInsertModel, Article>(articleInsertModel);
            articleRepository.Add(article);
            return true;
        }
        public bool RemoveArticle(int articleId)
        {
            Article article=articleRepository.GetById(articleId);
            if (article != null)
            {
                articleRepository.Remove(article);
                return true;
            }
            return false;
        }
        // This method will return any article detail.
        public ArticleDetailModel GetArticleDetail(int articleId)
        {
            var article = articleRepository.GetById(articleId);
            ArticleDetailModel articleDetailModel = mapper.Map<Article, ArticleDetailModel>(article);
            return articleDetailModel;
        }
        // If fewAticles is true, the method returns as many articles as requested(count). Else returns the number of all articles.
        public List<ArticleListModel> GetArticlesList(bool fewAticles = false, int count = 0)
        {
            List<ArticleListModel> articleListModels;
            List<Article> articles;
            if (fewAticles && count > 0)
            {
                articles = articleRepository.TakeArticles(count);
            }
            else
            {
                articles = articleRepository.GetAll();
            }
            articleListModels = ArrayMap<Article, ArticleListModel>(articles);
            var result = articleListModels.OrderByDescending(si => si.UpdateDate).ToList(); ;
            return result;
        }
        public int GetArticleCount()
        {
            return articleRepository.GetArticlesCount();
        }
        // This method will return nutritionist articles.
        public List<ArticleListModel> GetNutritionistArticles(int nutritionistId)
        {
            var articles = articleRepository.GetArticlesFromNutritionistId(nutritionistId);
            List<ArticleListModel> articleModels = ArrayMap<Article, ArticleListModel>(articles);
            var result = articleModels.OrderByDescending(si => si.UpdateDate).ToList(); ;
            return result;
        }
        public bool EditArticle(ArticleUpdateModel articleUpdateModel)
        {
            var article = articleRepository.GetById(articleUpdateModel.Id);
            if (articleUpdateModel != null && article != null)
            {
                article.Title = articleUpdateModel.Title;
                article.Body= articleUpdateModel.Body;
                article.Image = StaticFunctions.GetBytesFromFile(articleUpdateModel.Image);
                articleRepository.Update(article);
                return true;
            }
            else return false;
        }
       
    }
}
