using Nutritionist.Data.Entities;
using Nutritionist.Data.Entities.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace Nutritionist.Data.Repository
{
    public class ArticleRepository : Repository<Article, NutritionistDBContext>
    {
        public List<Article> TakeArticles(int count)
        {
            using (var context=new NutritionistDBContext())
            {
                return context.Articles.Where(x => !x.DidDelete && x.IsActive.Value).OrderBy(u => u.Id).Take(count).ToList();
            }
        }
        public List<Article> GetArticlesFromNutritionistId(int nutritionistId)
        {
            using (var context = new NutritionistDBContext())
            {
                return context.Articles.Where(x => !x.DidDelete && x.IsActive.Value && x.NutritionistId == nutritionistId).ToList();
            }
        }
        public int TakeArticlesCount(int nutritionistId)
        {
            using (var context = new NutritionistDBContext())
            {
                return context.Articles.Where(x => !x.DidDelete && x.IsActive.Value && x.NutritionistId == nutritionistId).Count();
            }
        }
    }

}
