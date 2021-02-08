using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Nutritionist.Data.Entities
{
    public partial class User : IEntity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(24, ErrorMessage = "Must be between 8 and 24 characters", MinimumLength = 8)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(24, ErrorMessage = "Must be between 8 and 24 characters", MinimumLength = 8)]
        public string Password { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "SecondName is required")]
        public string SecondName { get; set; }
        public bool DidDelete { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
