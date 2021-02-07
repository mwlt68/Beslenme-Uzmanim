using System;
using System.Collections.Generic;
using System.Text;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;

namespace Nutritionist.Core.Models.Nutritionist
{
    public class Detail
    {
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
        public DateTime CreateDate { get; set; }
        public virtual UserDetailModel User { get; set; }


    }
}
