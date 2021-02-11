using Nutritionist.Data.Entities;
using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ArticleListModel= Nutritionist.Core.Models.Article.List;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using ArticleInsertModel = Nutritionist.Core.Models.Article.Insert;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;

namespace Nutritionist.Services
{
    public class ArticleService:BaseServices
    {
        private ArticleRepository articleRepository = new ArticleRepository();
        private NutritionistService nutritionistService = new NutritionistService();

        // TODO: Maybe this get methods can convert to pagination structure.

        public void AddArticle(ArticleInsertModel articleInsertModel)
        {
            Article article = mapper.Map<ArticleInsertModel, Article>(articleInsertModel);
            articleRepository.Add(article);
        }
        public bool SoftDeleteArticle(int articleId)
        {
            Article article=articleRepository.GetById(articleId);
            if (article != null)
            {
                articleRepository.Remove(article);
                return true;
            }
            return false;
        }

        // If fewAticles is true, the method returns as many articles as requested(count). Else returns the number of all articles.
        public List<ArticleListModel> GetArticles(bool fewAticles=false,int count=0)
        {
            List<ArticleListModel> articleModels;
            List<Article> articles;
            if (fewAticles && count>0)
            {
                articles = articleRepository.TakeArticles(count);
            }
            else
            {
                articles = articleRepository.GetAll();
            }
            articleModels =ArrayMap<Article, ArticleListModel>(articles);
            return GetArticlesNutritionist(articleModels);
        }

        // This method will return nutritionist articles.
        public List<ArticleListModel> GetNutritionistArticles(int nutritionistId)
        {
            var articles= articleRepository.GetArticlesFromNutritionistId(nutritionistId);
            List<ArticleListModel> articleModels = ArrayMap<Article, ArticleListModel>(articles);
            return GetArticlesNutritionist(articleModels);
        }

        // This method will return any article detail.
        public ArticleDetailModel GetArticleDetail(int articleId)
        {
            var article = articleRepository.GetById(articleId);
            ArticleDetailModel articleModel = mapper.Map<Article, ArticleDetailModel>(article);
            var nutritionistListModel = nutritionistService.GetNutritionistListModel(articleModel.NutritionistId);
            if (nutritionistListModel != null)
            {
                articleModel.Nutritionist = nutritionistListModel;
                return articleModel;
            }
            return null;
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

        private List<ArticleListModel> GetArticlesNutritionist(List <ArticleListModel> articleListModels)
        {
            List<ArticleListModel> articlesResult = new List<ArticleListModel>();
            foreach (var articleModel in articleListModels)
            {
                var nutritionistListModel = nutritionistService.GetNutritionistListModel(articleModel.NutritionistId);
                if (nutritionistListModel != null)
                {
                    ArticleListModel articleListModel = articleModel;
                    articleListModel.Nutritionist = nutritionistListModel;
                    articlesResult.Add(articleListModel);
                }
            }
            return articleListModels;
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
        }
    }
}
