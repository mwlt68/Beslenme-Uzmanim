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

        // If fewAticles is true, the method returns as many articles as requested(count). Else returns the number of all articles.
        public IEnumerable<ArticleListModel> GetArticles(bool fewAticles,int count=0)
        {
            IEnumerable<ArticleListModel> articleModels;
            IEnumerable<Article> articles;
            if (fewAticles && count>0)
            {
                articles = articleRepository.TakeArticles(count);
            }
            else
            {
                articles = articleRepository.GetAll();
            }
            articleModels = mapper.Map<IEnumerable<Article>, IEnumerable<ArticleListModel>>(articles);
            return GetArticlesUser(articleModels);
        }

        // This method will return nutritionist articles.
        public IEnumerable<ArticleListModel> GetNutritionistArticles(int nutritionistId)
        {
            var articles= articleRepository.GetArticlesFromNutritionistId(nutritionistId);
            IEnumerable<ArticleListModel> articleModels = mapper.Map<IEnumerable<Article>, IEnumerable<ArticleListModel>>(articles);
            return GetArticlesUser(articleModels);
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
            }
            return articleModel;
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

        private IEnumerable<ArticleListModel> GetArticlesUser(IEnumerable <ArticleListModel> articleListModels)
        {
            foreach (var articleModel in articleListModels)
            {
                var nutritionistListModel = nutritionistService.GetNutritionistListModel(articleModel.NutritionistId);
                if (nutritionistListModel != null)
                {
                    articleModel.Nutritionist = nutritionistListModel;
                }
            }
            return articleListModels;
        }
        public int GetArticleCount()
        {
            return articleRepository.GetCount();
        }
    }
}
