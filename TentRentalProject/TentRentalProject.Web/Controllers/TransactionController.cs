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
    [Authorize]
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index(int? page)
        {
            List<TransactionHistoryModel> Transaction = BusinessLayer.GetAllTransaction((int)Utility.Sort.Descending);
            const int pageSize = 5;
            int currentPage = page ?? 1;
            int totalItems = Transaction.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            currentPage = Math.Max(1, Math.Min(currentPage, totalPages));
            int itemsToSkip = (currentPage - 1) * pageSize;
            var transactionOnCurrentPage = Transaction.Skip(itemsToSkip).Take(pageSize).ToList();

            ViewBag.Transaction = transactionOnCurrentPage;
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteAllTransactions()
        {
            BusinessLayer.DeleteAllTransactions();
            return RedirectToAction("Index", "Home");
        }
    }
}