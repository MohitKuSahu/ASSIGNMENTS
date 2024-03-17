using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TentRentalProject.Business;
using TentRentalProject.DataAccessLayer;
using TentRentalProject.Models;
using TentRentalProject.Utils;
using static TentRentalProject.Utils.Utility;

namespace TentRentalProject.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> list = BusinessLayer.GetAllProductTitle();
            ViewBag.Products = new SelectList(list);
            return View();

        }
        [HttpPost]
        public ActionResult SaveDetails(ContainerModel userDetails)
        {
            Tuple<int, bool> list = BusinessLayer.InsertCustomer(userDetails.Customer);

            int transactionID = BusinessLayer.GetTransactionID();

            foreach (var item in userDetails.TransactionHistory.TransactionList)
            {
                if (item.Quantity > 0)
                {
                    item.CustomerID = list.Item1;

                    if (item.TransactionType == null)
                    {
                        return View("~/Views/Shared/Error3.cshtml");
                    }
                    if (item.TransactionType.Equals("OUT"))
                    {
                        item.TransactionID = transactionID;
                        item.TransactionParentID = null;
                        if (!BusinessLayer.UpdateProductOut(item.ProductID, item.Quantity))
                        {
                            BusinessLayer.DeleteTransactionByProductID(transactionID);
                            return View("~/Views/Shared/Error1.cshtml");
                        }
                    }
                    else if (item.TransactionType.Equals("IN"))
                    {
                        item.TransactionID = transactionID;
                        item.TransactionParentID = BusinessLayer.FindTransactionID(list.Item1, item.ProductID);
                        if ((!BusinessLayer.UpdateProductIn(item.ProductID, item.Quantity)) || item.TransactionParentID == null)
                        {
                            BusinessLayer.DeleteTransactionByProductID(transactionID);
                            return View("~/Views/Shared/Error2.cshtml");
                        }

                    }

                    BusinessLayer.InsertTransaction(item);
                }
            }


            //return RedirectToAction("Index", "Transaction");
            return Json(new { redirectUrl = Url.Action("Index", "Transaction") });
        }

        public ActionResult GetProductDetails(string productTitle)
        {
            List<ProductModel> allproduct = BusinessLayer.GetAllProduct((int)Sort.Normal);
            List<ProductModel> selectedProduct= new List<ProductModel>();
            foreach (var item in allproduct)
            {
                if (item.ProductTitle == productTitle)
                {
                    selectedProduct.Add(item);  
                }
            }
            var result = new
            {
                Products = selectedProduct,
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

       
    }
}