using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Nutritionist.Data.Entities
{
    public partial class Comment : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int NutritionstId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Content is required")]

        public string CommentContent { get; set; }
        [Required(ErrorMessage = "DidDelete is required")]

        public bool DidDelete { get; set; }
        [Required(ErrorMessage = "IsActive is required")]

        public bool IsActive { get; set; }
        [Required(ErrorMessage = "CreateDate is required")]

        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "UpdateDate is required")]

        public DateTime UpdateDate { get; set; }

        public virtual Nutritionist Nutritionst { get; set; }
        public virtual User User { get; set; }
    }
}
