using DemoUserManagement.Business;
using DemoUserManagement.DAL;
using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
        public ActionResult SaveDetails(ContainerModel userDetails)
        {
            userDetails.PresentAddress.Type = 1;
            userDetails.PermanentAddress.Type = 0;

            Tuple<int, int> PresentList = BusinessLayer.GetCountryAndStateId(userDetails.PresentCountry.CountryName, userDetails.PresentState.StateName);
            userDetails.PresentAddress.CountryID = PresentList.Item1;
            userDetails.PresentAddress.StateID = PresentList.Item2;

            Tuple<int, int> PermanentList = BusinessLayer.GetCountryAndStateId(userDetails.PermanentCountry.CountryName, userDetails.PermanentState.StateName);
            userDetails.PermanentAddress.CountryID = PermanentList.Item1;
            userDetails.PermanentAddress.StateID = PermanentList.Item2;


            List<AddressModel> addresses = new List<AddressModel> {
                userDetails.PresentAddress, userDetails.PermanentAddress
            };

            if (Request.Files.Count == 2)
            {
                HttpPostedFileBase file1 = Request.Files[0];
                HttpPostedFileBase file2 = Request.Files[1];

                if (file1 != null && file2 != null)
                {
                    userDetails.User.FileName = SaveFile(file1);
                    userDetails.User.Profile = SaveFile(file2);
                }
            }
            BusinessLayer.InsertUser(userDetails.User, addresses);
            return RedirectToAction("Login", "Login");
        }
        public JsonResult GetCountries()
        {
            List<string> countries = BusinessLayer.GetAllCountries();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        private string SaveFile(HttpPostedFileBase file)
        {
            string uploadFolder = Server.MapPath("~/Output/");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string fileName = Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadFolder, fileName);

            file.SaveAs(filePath);

            return fileName;
        }


    }
}