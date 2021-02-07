using System;
using System.Collections.Generic;
using System.Text;
using UserListModel = Nutritionist.Core.Models.User.List;

namespace Nutritionist.Core.Models.Nutritionist
{
    public class List
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Departman { get; set; }

        public byte[] ProfileImage { get; set; }

        public string ShortIntroduce { get; set; }
        public virtual UserListModel User { get; set; }

    }
}
