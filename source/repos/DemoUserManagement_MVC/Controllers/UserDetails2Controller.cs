using DemoUserManagement.Business;
using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUserManagement_MVC.Controllers
{
    public class UserDetails2Controller : Controller
    {
        // GET: UserDetails2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserDetails2()
        {
            return View();
        }
        public JsonResult GetStatesForCountry(string selectedCountry)
        {
            List<string> states = BusinessLayer.GetStatesForCountry(selectedCountry);
            return Json(states, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveDetails(UserModel user,List<AddressModel> list)
        {
            BusinessLayer.InsertUser(user,list);
            return RedirectToAction("Login", "Login");
        }
        
    }
}