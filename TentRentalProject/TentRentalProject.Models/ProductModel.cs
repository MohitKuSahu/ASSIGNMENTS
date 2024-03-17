using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TentRentalProject.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public int QuantityTotal { get; set; }
        public int QuantityBooked { get; set; }
        public decimal Price { get; set; }

        [NotMapped] 
        public int AvailableQuantity
        {
            get { return QuantityTotal - QuantityBooked; } 
        }
    }
}
