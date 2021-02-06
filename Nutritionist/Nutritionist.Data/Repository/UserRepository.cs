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
        public User UserLogin(String username,String hashedPassword)
        {

            using (var context = new NutritionistDBContext())
            {
                User user =  context.Users.Where(x => x.Username == username && x.Password == hashedPassword && !x.DidDelete && x.IsActive).FirstOrDefault();
                return user;
            }
        }
    }
}
