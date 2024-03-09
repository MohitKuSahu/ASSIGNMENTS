using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TentRentalProject.Business;
using TentRentalProject.Models;

namespace TentRentalProject.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult CheckDetails(UserModel user)
        {
            int UserID = BusinessLayer.IsUser(user.Email, user.Password);
            if (UserID > 0)
            {
                if (BusinessLayer.IsAdmin(UserID))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index","Reports");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index","Welcome");
                }

            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or password");
            }
            return View("Index", user);
        }
       
        public ActionResult SaveDetails(UserModel user) { 

            BusinessLayer.InsertUser(user);
            return RedirectToAction("Index");
        }

    }
}