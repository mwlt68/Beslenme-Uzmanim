using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Core.Models.User
{
    public class Insert
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
