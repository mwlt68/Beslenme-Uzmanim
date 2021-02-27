using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nutritionist.Core.Models.Article
{
    public class Update
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150, ErrorMessage = "Must be less then 150 characters")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Body is required")]

        public string Body { get; set; }

        public IFormFile Image { get; set; }
    }
}
