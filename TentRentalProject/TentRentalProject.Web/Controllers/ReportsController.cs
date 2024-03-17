using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Util;
using TentRentalProject.Business;
using TentRentalProject.DataAccessLayer;
using TentRentalProject.Models;
using static TentRentalProject.Utils.Utility;

namespace TentRentalProject.Web.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        public ActionResult Summary()
        {
            List<ProductModel> product = BusinessLayer.GetAllProduct((int)Sort.Normal);
            ViewBag.Products = product;
            return View();
        }
        public ActionResult Details()
        {
            List<string> monthList = BusinessLayer.GetMonthNames();
            ViewBag.Months = new SelectList(monthList);  
            return View();
        }

        public ActionResult GetTransactionDetailsByMonth(string monthName)
        {
            List<ProductModel> product = BusinessLayer.GetAllProduct((int)Sort.Normal);

            List<TransactionHistoryModel> listOfTransactions = new List<TransactionHistoryModel>();
            if (Enum.TryParse(monthName, true, out Month selectedMonth))
            {
                int monthValue = (int)selectedMonth;
                List<TransactionHistoryModel> allTransactions = BusinessLayer.GetAllTransaction((int)Sort.Normal);
                foreach (var item in allTransactions)
                {
                    if (item.TransactionDateTime.Month == monthValue)
                    {
                       listOfTransactions.Add(item);
                    }
                }
                
            }
            var result = new
            {
                Products = product,
                Transactions = listOfTransactions
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTransactionDetailsByDate(DateTime? date)
        {

            if (!date.HasValue)
            {
                return Json(new { error = "Date parameter is required." }, JsonRequestBehavior.AllowGet);
            }
            List<ProductModel> product = BusinessLayer.GetAllProduct((int)Sort.Normal);

            List<TransactionHistoryModel> listOfTransactions = new List<TransactionHistoryModel>();
           
              List<TransactionHistoryModel> allTransactions = BusinessLayer.GetAllTransaction((int)Sort.Normal);
              foreach (var item in allTransactions)
              {
                    if (item.TransactionDateTime.Date == date.Value.Date)
                    {
                        listOfTransactions.Add(item);
                    }
              }

            
            var result = new
            {
                Products = product,
                Transactions = listOfTransactions
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}