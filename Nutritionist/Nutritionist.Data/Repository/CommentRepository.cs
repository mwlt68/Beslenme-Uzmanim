using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nutritionist.Data.Entities;
using Nutritionist.Data.Entities.DbContexts;

namespace Nutritionist.Data.Repository
{
    public class CommentRepository : Repository<Comment, NutritionistDBContext>
    {
        public List<Comment> GetNutritionistAllComments(int nutritionistId)
        {
            using (var context =new NutritionistDBContext())
            {
                return context.Comments.Where(x => !x.DidDelete && x.IsActive.Value && x.NutritionstId == nutritionistId).ToList();
            }
        }
    }
}
