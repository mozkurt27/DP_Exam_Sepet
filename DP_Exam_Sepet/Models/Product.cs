using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Exam_Sepet.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ImagesId { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return $"{Name}:{Category.Name}";
        }

    }
}
