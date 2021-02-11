using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nutritionist.Data.Entities.DbContexts;
using NutritionistEntity = Nutritionist.Data.Entities.Nutritionist;

namespace Nutritionist.Data.Repository
{
    public class NutritionistRepository : Repository<Entities.Nutritionist, NutritionistDBContext>
    {
        public void RemoveWithForeignKeys(NutritionistEntity nutritionist)
        {
            using (var context = new NutritionistDBContext())
            {
                
                nutritionist.DidDelete = true;
                nutritionist.UpdateDate = DateTime.Now;
                context.Nutritionists.Update(nutritionist);
                foreach (var comment in nutritionist.Comments)
                {
                    comment.IsActive = false;
                    comment.UpdateDate = DateTime.Now;
                    context.Comments.Update(comment);
                }
                foreach (var article in nutritionist.Articles)
                {
                    article.IsActive = false;
                    article.UpdateDate = DateTime.Now;
                    context.Articles.Update(article);
                }
                context.SaveChanges();
            }
        }
        public NutritionistEntity GetNutritionistFromUserId(int userId)
        {
            using (var context = new NutritionistDBContext())
            {
                return context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value && x.UserId == userId).FirstOrDefault();
            }
        }
    }
}
