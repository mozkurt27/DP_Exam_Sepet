using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Exam_Sepet.Models
{
    public class SoldProduct
    {
        
        public int SoldID { get; set; }
        public AppUser User { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }

        public int Adet { get; set; }

        public decimal Toplam { get; set; }

        public string PaymentType { get; set; }






        public override string ToString()
        {
            return $"{SoldID}:{User.Username}:{Category}:{Product.Name}:{Product.Price}:{Adet}:{Toplam}:{PaymentType}";
        }
    }
}
