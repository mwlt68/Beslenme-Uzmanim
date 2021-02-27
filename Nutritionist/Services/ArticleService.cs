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
            return articleListModels;
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
            return articleModels;
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
        /*
                private List<ArticleListModel> GetArticlesNutritionist(List<ArticleListModel> articleListModels)
        {
            List<ArticleListModel> articlesResult = new List<ArticleListModel>();
            foreach (var articleModel in articleListModels)
            {
                var nutritionistEntity = nutritionistRepository.GetById(articleModel.NutritionistId);
                if (nutritionistEntity != null)
                {
                    NutritionistListModel nutritionistListModel = mapper.Map<Data.Entities.Nutritionist, NutritionistListModel>(nutritionistEntity);
                    ArticleListModel articleListModel = articleModel;
                    articleListModel.Nutritionist = nutritionistListModel;
                    articlesResult.Add(articleListModel);
                }
            }
            return articleListModels;
        }

        // This method will return nutritionist articles.
        public List<ArticleListModel> GetNutritionistArticles(int nutritionistId)
        {
            var articles= articleRepository.GetArticlesFromNutritionistId(nutritionistId);
            List<ArticleListModel> articleModels = ArrayMap<Article, ArticleListModel>(articles);
            return GetArticlesNutritionist(articleModels);
        }
        


        //If forNutritionist is true method will return count of   nutritionist`s articles.Else return all articles count.
        public int GetArticlesCount(bool forNutritionist,int nutritionistId=-1)
        {
            if (forNutritionist && nutritionistId > 0)
            {
                return articleRepository.TakeArticlesCount(nutritionistId);
            }
            else
            {
                return articleRepository.GetCount();
            }
        }


        public int GetArticleCount()
        {
            return articleRepository.GetCount();
        }
        public bool RemoveArticle(int articleId, int nuritionistId)
        {
            var article = articleRepository.GetById(articleId);
            if (article != null && article.NutritionistId == nuritionistId)
            {
                articleRepository.Remove(article);
                return true;
            }
            else return false;
        }*/
    }
}
