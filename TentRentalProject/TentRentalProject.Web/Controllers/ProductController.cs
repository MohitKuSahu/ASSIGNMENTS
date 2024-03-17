using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TentRentalProject.Models;
using TentRentalProject.Business;
using TentRentalProject.Utils;


namespace TentRentalProject.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? page)
        {
            List<ProductModel> product = BusinessLayer.GetAllProduct((int)Utility.Sort.Ascending);
            const int pageSize = 4;
            int currentPage = page ?? 1;
            int totalItems = product.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            currentPage = Math.Max(1, Math.Min(currentPage, totalPages));
            int itemsToSkip = (currentPage - 1) * pageSize;
            var productOnCurrentPage = product.Skip(itemsToSkip).Take(pageSize).ToList();

            ViewBag.Product = productOnCurrentPage;
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;
            return View();
        }
        [HttpPost]
        public ActionResult SaveDetails(ProductModel product)
        {

            if (BusinessLayer.InsertProduct(product))
            {
                TempData["Message"] = "Product added successfully!";
            }
            else
            {
                TempData["Message"] = "Product Already Exists!";
            }
            
            return RedirectToAction("Index", "Product");
        }

        public ActionResult ProductEdit(int id) { 

            var product=BusinessLayer.GetProductByID(id);
            return View(product);  
        }

        [HttpPost]
        public ActionResult ProductEdit(ProductModel product)
        {
            var products = BusinessLayer.UpdateProduct(product);
            TempData["Message"] = "Product Updated Successfuly";
            return RedirectToAction("Index", "Product");
        }
    }
}