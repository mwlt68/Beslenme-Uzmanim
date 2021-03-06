using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Core.Models.User
{
    public class LoginRespose
    {
        public int UserId { get; set; }
        public int NutritionistId { get; set; }
        public String Token { get; set; }
    }
}
