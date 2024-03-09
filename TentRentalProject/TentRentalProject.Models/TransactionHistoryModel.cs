using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentRentalProject.Utils;

namespace TentRentalProject.Models
{
    public class TransactionHistoryModel
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public int? TransactionParentID { get; set; }

        public List<TransactionHistoryModel> TransactionList { get; set; }
        public TransactionHistoryModel()
        {
            TransactionList = new List<TransactionHistoryModel>();
        }
    }
}
