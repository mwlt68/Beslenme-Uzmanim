using System;
using System.Collections.Generic;
using System.Text;
using Nutritionist.Data.Entities.DbContexts;

namespace Nutritionist.Data.Repository
{
    public class NutritionistRepository : Repository<Entities.Nutritionist, NutritionistDBContext>
    {
    }
}
