using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nutritionist.Core.Models.Article
{
    public class Insert
    {

        public int NutritionistId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150, ErrorMessage = "Must be less then 150 characters")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Body is required")]

        public string Body { get; set; }
        [Required(ErrorMessage = "Image is required")]

        public IFormFile Image { get; set; }
    }
}
