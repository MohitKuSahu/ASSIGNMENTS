using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TentRentalProject.Business;
using TentRentalProject.Models;
using TentRentalProject.Utils;

namespace TentRentalProject.Web.Controllers
{
    
    public class CustomerController : Controller
    {
        [Authorize]
        public ActionResult Index(int? page)
        {
            List<CustomerModel> Customer = BusinessLayer.GetAllCustomer((int)Utility.Sort.Ascending);
            const int pageSize = 5;
            int currentPage = page ?? 1;
            int totalItems = Customer.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            currentPage = Math.Max(1, Math.Min(currentPage, totalPages));
            int itemsToSkip = (currentPage - 1) * pageSize;
            var customerOnCurrentPage = Customer.Skip(itemsToSkip).Take(pageSize).ToList();

            ViewBag.Customer = customerOnCurrentPage;
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;
            return View();
        }
        [HttpPost]
        public ActionResult SaveDetails(CustomerModel customer)
        {

            Tuple<int,bool> list=BusinessLayer.InsertCustomer(customer);

            if (list.Item2)
            {
                TempData["Message"] = "Customer added successfully!";
            }
            else
            {
                TempData["Message"] = "Customer Already Exists!";
            }

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult CustomerEdit(int id)
        {

            var customer = BusinessLayer.GetCustomerByID(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult CustomerEdit(CustomerModel product)
        {
            var customers = BusinessLayer.UpdateCustomer(product);
            TempData["Message"] = "Customer Updated Successfuly";
            return RedirectToAction("Index", "Customer");
        }
    }
}