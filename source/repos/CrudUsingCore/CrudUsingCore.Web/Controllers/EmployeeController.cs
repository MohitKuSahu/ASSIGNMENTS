using CrudUsingCore.BL;
using CrudUsingCore.Utils;
using CrudUsingCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrudUsingCore.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IBL _BAL;
        private readonly ILog _Log;

        public EmployeeController(IBL BAL, ILog Log)
        {
            _BAL = BAL;
            _Log = Log;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details()
        {
            try
            {
                int a = 9;
                int b = 0;
                int c = a / b;
                ViewBag.Employees = await _BAL.ListEmployeeAsync();
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                TempData["Message"] = "There is Problem loading Employee Details.";
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var emp = await _BAL.GetEmployeeByIdAsync(id);
                return View(emp);
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                TempData["Message"] = "There is Problem in loading this employee detail";
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _BAL.DeleteByIdAsync(id))
                {
                    TempData["Message"] = "Employee Deleted Successfully";
                }
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                TempData["Message"] = "Employee Not Deleted";
            }
            return RedirectToAction("Details", "Employee");
        }


        [HttpPost]
        public async Task<IActionResult> Add(EmployeeModel model)
        {
            try
            {
                if (await _BAL.AddEmployeeAsync(model))
                {
                    TempData["Message"] = "Employee Successfully Added";
                }
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                TempData["Message"] = "Employee Not Added";
            }

            return RedirectToAction("Details", "Employee");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeModel model)
        {
            try
            {
                if (await _BAL.UpdateEmployeeAsync(model))
                {
                    TempData["Message"] = "Employee Successfully Updated";
                }
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                TempData["Message"] = "Employee Not Updated";
            }
            return RedirectToAction("Details", "Employee");
        }
    }
}
