using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoProject.Models;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Guts"] = "Guts";
            //return RedirectToAction("Use"); redirect to different view...

            return View();
             
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Use()
        {
            ViewBag.Massage = "Hello! I am called from controller class  via ViewBag";
            ViewData["Message"] = "Hello! I am called from controller class  via ViewData";
            ViewData["Time"] = DateTime.Now.ToString();
            Student stud = new Student
            {
                Id = 883,
                Name = "Mohit",
                Email = "Mohitsahu7482378@gmail.com"
            };
            ViewData["Student"] = stud;
            ViewBag.Student= stud;
            return View();
        }
        public string Welcome()
        {

            return "Hello, this is welcome action message";
        }
     

      
    }
}