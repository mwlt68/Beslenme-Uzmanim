using System;
using System.Collections.Generic;

#nullable disable

namespace Nutritionist.Data.Nutritionist.Data.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int NutritionstId { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public bool DidDelete { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Nutritionist Nutritionst { get; set; }
        public virtual User User { get; set; }
    }
}
