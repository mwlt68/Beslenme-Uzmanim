using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nutritionist.Core.Models.User
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(24, ErrorMessage = "Must be between 8 and 24 characters", MinimumLength = 8)]

        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(24, ErrorMessage = "Must be between 8 and 24 characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
