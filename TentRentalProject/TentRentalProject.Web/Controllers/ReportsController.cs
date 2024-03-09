using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TentRentalProject.Business;
using TentRentalProject.Models;
using TentRentalProject.Utils;

namespace TentRentalProject.Web.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            List<ProductModel> product = BusinessLayer.GetAllProduct((int)Utility.Sort.Normal);
            ViewBag.Products = product;

            List<TransactionHistoryModel> transactions = BusinessLayer.GetAllTransaction((int)Utility.Sort.Normal);
            ViewBag.Transactions = transactions;

            //Created a boolean list for checking, if transaction exists for a particular ProductID  
            List<bool> checkTransaction = new List<bool>();   
            foreach (var item in  product)
            {
                checkTransaction.Add(BusinessLayer.ifTransactionExistsByProductID(item.ProductID));
            }
            ViewBag.CheckTransaction = checkTransaction;   
            
            return View();
        }
    }
}