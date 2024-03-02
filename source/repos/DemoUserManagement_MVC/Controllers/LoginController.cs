using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUserManagement.Models;
using DemoUserManagement.Business;
using System.Web.Security;
using DemoUserManagement.Utils;

namespace DemoUserManagement_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {

            int UserID = BusinessLayer.IsUser(user.Email, user.Password);
            if (UserID > 0)
            {
                if (BusinessLayer.IsAdmin(UserID))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("UserList", "Home");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Edit", "Home", new { @id = UserID });
                }

            }
            else
            {
                ModelState.AddModelError("", "Invalid Username and password");
            }
            return View();



        }


        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }

        public ActionResult SignUp(UserModel user)
        {

            return View();
        }
    }
}