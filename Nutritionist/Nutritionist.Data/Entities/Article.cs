using System;
using System.Collections.Generic;

#nullable disable

namespace Nutritionist.Data.Entities
{
    public partial class Article : IEntity
    {
        public int Id { get; set; }
        public int NutritionistId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public byte[] Image { get; set; }
        public bool DidDelete { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Nutritionist Nutritionist { get; set; }
    }
}
