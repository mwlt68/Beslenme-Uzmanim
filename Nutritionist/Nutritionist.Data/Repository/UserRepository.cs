using Nutritionist.Data.Entities;
using Nutritionist.Data.Entities.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Data.Repository
{
    public class UserRepository :Repository<User, NutritionistDBContext>
    {
    }
}
