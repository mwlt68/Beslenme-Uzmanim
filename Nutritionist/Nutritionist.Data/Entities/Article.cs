using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Nutritionist.Data.Entities
{
    public partial class Article :IEntity
    {
        [Key]
        public int Id { get; set; }

        public int NutritionistId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150, ErrorMessage = "Must be less then 150 characters")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Body is required")]

        public string Body { get; set; }
        [Required(ErrorMessage = "Image is required")]

        public byte[] Image { get; set; }
        [Required(ErrorMessage = "DidDelete is required")]

        public bool DidDelete { get; set; }
        [Required(ErrorMessage = "IsActive is required")]

        public bool IsActive { get; set; }
        [Required(ErrorMessage = "CreateDate is required")]

        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "UpdateDate is required")]

        public DateTime UpdateDate { get; set; }

        public virtual Nutritionist Nutritionist { get; set; }
    }
}
