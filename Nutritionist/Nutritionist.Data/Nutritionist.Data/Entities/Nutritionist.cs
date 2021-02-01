using System;
using System.Collections.Generic;

#nullable disable

namespace Nutritionist.Data.Nutritionist.Data.Entities
{
    public partial class Nutritionist
    {
        public Nutritionist()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Departman { get; set; }
        public byte[] ProfileImage { get; set; }
        public string ShortIntroduce { get; set; }
        public string Introduce { get; set; }
        public string WorkingHours { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string LinkedinLink { get; set; }
        public string YoutubeLink { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public bool DidDelete { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
