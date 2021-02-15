using Nutritionist.Data.Entities;
using Nutritionist.Data.Entities.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace Nutritionist.Data.Repository
{
    /*
                     var query =
                    from article in context.Articles.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == id)
                    from nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == article.NutritionistId)
                    select article;
     */
    public class ArticleRepository : Repository<Article, NutritionistDBContext>
    {
        public Article GetById(int id)
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from article in context.Articles.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == id)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on article.NutritionistId equals nutritionist.Id
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    select article;
                return query.FirstOrDefault();
            }
        }
        public List<Article> GetAll()
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from article in context.Articles.Where(x => !x.DidDelete && x.IsActive.Value)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on article.NutritionistId equals nutritionist.Id
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    select article;
                return query.ToList();
            }
        }
        public List<Article> TakeArticles(int count)
        {
            using (var context=new NutritionistDBContext())
            {
                var query =
                    from article in context.Articles.Where(x => !x.DidDelete && x.IsActive.Value)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on article.NutritionistId equals nutritionist.Id
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    select article;
                return query.OrderBy(u => u.Id).Take(count).ToList();
            }
        }
        public List<Article> GetArticlesFromNutritionistId(int nutritionistId)
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from article in context.Articles.Where(x => !x.DidDelete && x.IsActive.Value)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionistId)
                    on article.NutritionistId equals nutritionist.Id
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    select article;
                return query.ToList();
            }
        }
        public int GetArticlesCount()
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from article in context.Articles.Where(x => !x.DidDelete && x.IsActive.Value )
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on article.NutritionistId equals nutritionist.Id
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    select article;
                return query.Count();
            }
        }

    }

}
