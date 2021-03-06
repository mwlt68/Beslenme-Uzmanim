using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritionist.Web.Infrastructure
{
    public class ReadOnlyValues
    {
        // JWT
        public static readonly String AuthenticationScheme= "Bearer"; 
        // Session Values
        public static readonly String UserIdSession = "UserId"; //int
        public static readonly String TokenSession = "Token"; //String
        public static readonly String NutritionistIdSession = "NutId"; //int
    }
}
