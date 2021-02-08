using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Data.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
        public bool DidDelete { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
