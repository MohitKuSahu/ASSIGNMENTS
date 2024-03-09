using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentRentalProject.Models
{
    public class ContainerModel
    {
        public UserModel User { get; set; }
        public CustomerModel Customer { get; set; }
        public ProductModel Product { get; set; }
        public TransactionHistoryModel TransactionHistory { get; set; }

    }
}
