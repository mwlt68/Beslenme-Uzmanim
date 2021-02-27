using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritionist.Web.Models
{
    public class DeleteModel
    {
        public int Id { get; set; }
        public String Controller { get; set; }
        public String Action { get; set; }
        public String Title{ get; set; }
        public String Message{ get; set; }

    }
}
