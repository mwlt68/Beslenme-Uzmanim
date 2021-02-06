using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Nutritionist.Data.Entities
{
    public partial class Nutritionist : IEntity
    {
        public Nutritionist()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Departman is required")]

        public string Departman { get; set; }
        [Required(ErrorMessage = "Profile Image is required")]

        public byte[] ProfileImage { get; set; }

        [Required(ErrorMessage = "ShortIntroduce is required")]

        [StringLength(150, ErrorMessage = "Must be less then 150 characters")]

        public string ShortIntroduce { get; set; }
        [Required(ErrorMessage = "Introduce is required")]

        public string Introduce { get; set; }
        [Required(ErrorMessage = "WorkingHours is required")]

        public string WorkingHours { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]

        public string Address { get; set; }
        public string LinkedinLink { get; set; }
        public string YoutubeLink { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }

        [Required(ErrorMessage = "DidDelete is required")]

        public bool DidDelete { get; set; }
        [Required(ErrorMessage = "IsActive is required")]

        public bool IsActive { get; set; }
        [Required(ErrorMessage = "CreateDate is required")]

        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "UpdateDate is required")]

        public DateTime UpdateDate { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
