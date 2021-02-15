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
        public NutritionistEntity GetById(int id)
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == id)
                    join user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    on nutritionist.UserId equals user.Id
                    select nutritionist;
                return query.FirstOrDefault();
            }
        }
        public List<NutritionistEntity> GetAll()
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    join user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    on nutritionist.UserId equals user.Id
                    select nutritionist;
                return query.ToList();
            }
        }
        public NutritionistEntity GetNutritionistFromUserId(int userId)
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value && x.UserId == userId)
                    join user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    on nutritionist.UserId equals user.Id
                    select nutritionist;
                return query.FirstOrDefault();
            }
        }
        public int GetNutritionistsCount()
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    join user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    on nutritionist.UserId equals user.Id
                    select nutritionist;
                return query.Count();
            }
        }
    }
}
