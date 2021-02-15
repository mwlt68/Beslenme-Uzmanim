using System;
using System.Collections.Generic;
using System.Text;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using UserListModel = Nutritionist.Core.Models.User.List;

namespace Nutritionist.Core.Models.Comment
{
    public class List
    {
        public int Id { get; set; }

        public int NutritionstId { get; set; }
        public int UserId { get; set; }

        public string CommentContent { get; set; }

        public DateTime UpdateDate { get; set; }

        public virtual UserListModel User { get; set; }
        public virtual NutritionistListModel Nutritionist{ get; set; }
    }
}
