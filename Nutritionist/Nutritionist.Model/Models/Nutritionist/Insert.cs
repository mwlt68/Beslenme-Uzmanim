using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Abstractions;
using System.Text;

namespace Nutritionist.Core.Models.Nutritionist
{
    public class Insert
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Departman is required")]

        public string Departman { get; set; }
        [Required(ErrorMessage = "Profile Image is required")]

        public IFormFile ProfileImage { get; set; }

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
    }
}
