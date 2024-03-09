using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TentRentalProject.Business;
using TentRentalProject.Models;
using TentRentalProject.Utils;

namespace TentRentalProject.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ProductModel> product = BusinessLayer.GetAllProduct((int)(Utility.Sort.Normal));
            ViewBag.Product = product;
            return View();
        
        }
        [HttpPost]
        public ActionResult SaveDetails(ContainerModel userDetails)
        {
            int custID=BusinessLayer.InsertCustomer(userDetails.Customer);
            int transactionID = BusinessLayer.GetTransactionID();
           
                foreach (var item in userDetails.TransactionHistory.TransactionList)
                {
                    if (item.Quantity > 0)
                    {
                        item.CustomerID = custID;

                        if (item.TransactionType.Equals("OUT"))
                        {
                            item.TransactionID = transactionID;
                            item.TransactionParentID = null;
                            if(!BusinessLayer.UpdateProductOut(item.ProductID, item.Quantity))
                            {
                                BusinessLayer.DeleteTransactionByProductID(transactionID);
                                return View("~/Views/Shared/Error1.cshtml");
                            }
                        }
                        else 
                        {
                            item.TransactionID = transactionID;
                            item.TransactionParentID = BusinessLayer.FindTransactionID(custID,item.ProductID);
                            if((!BusinessLayer.UpdateProductIn(item.ProductID, item.Quantity)) && item.TransactionParentID==null)
                            {
                                BusinessLayer.DeleteTransactionByProductID(transactionID);
                                return View("~/Views/Shared/Error2.cshtml");
                            }
                        }
                        BusinessLayer.InsertTransaction(item);
                    }
                }
         
            
          
            return RedirectToAction("Index", "Transaction");
        }


    }
}