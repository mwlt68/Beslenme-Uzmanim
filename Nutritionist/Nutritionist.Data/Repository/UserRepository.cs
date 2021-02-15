using Nutritionist.Data.Entities;
using Nutritionist.Data.Entities.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nutritionist.Data.Repository
{
    public class UserRepository :Repository<User, NutritionistDBContext>
    {
        public User GetById(int id)
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == id)
                    select user;
                return query.FirstOrDefault();
            }
        }

        public User GetUserFromNutritionist(int nutritionistId)
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on nutritionistId equals nutritionist.Id
                    select user;
                return query.FirstOrDefault();
            }
        }
        public User UserLogin(String username,String hashedPassword)
        {

            using (var context = new NutritionistDBContext())
            {
                var query =
                    from user in context.Users.Where(x => x.Username == username && x.Password == hashedPassword && !x.DidDelete && x.IsActive.Value)
                    select user;
                return query.FirstOrDefault();
            }
        }
        public int GetUsersCount()
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    select user;
                return query.Count();
            }
        }
        /*
        public List<User> GetAll()
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from user in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    select user;
                return query.ToList();
            }
        }
         */
    }
}
