using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;

namespace Nutritionist.Core.Models.Article
{
    public class List
    {
        public int Id { get; set; }

        public int NutritionistId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public byte[] Image { get; set; }

        public virtual NutritionistListModel Nutritionist { get; set; }

    }
}
