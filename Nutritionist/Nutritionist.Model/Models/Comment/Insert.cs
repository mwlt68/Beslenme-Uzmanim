using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nutritionist.Core.Models.Comment
{
    public class Insert
    {
        [Required(ErrorMessage = "Nutritions is required")]
        public int NutritionstId { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Content is required")]

        public string CommentContent { get; set; }
    }
}
