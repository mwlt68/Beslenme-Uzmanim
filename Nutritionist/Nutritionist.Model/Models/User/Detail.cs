using Nutritionist.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Core.Models.User
{
    public class Detail
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public override string ToString()
        {
            return StaticFunctions.DefaultUpperCase(FirstName) + " " + StaticFunctions.DefaultUpperCase(SecondName);
        }
    }
}
