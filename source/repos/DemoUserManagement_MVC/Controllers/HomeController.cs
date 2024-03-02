using DemoUserManagement.Business;
using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using DemoUserManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Printing;
using System.Web.UI;
using System.IO;

namespace DemoUserManagement_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly FORMEntities context = new FORMEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserDetails()
        {

            List<string> countries = BusinessLayer.GetAllCountries();
            ViewBag.Countries = new SelectList(countries);
            return View();
        }

        public ActionResult UserList(int? page)
        {
            List<UserModel> users = BusinessLayer.GetAllUsers();
            const int pageSize = 5;
            int currentPage = page ?? 1;
            int totalItems = users.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            currentPage = Math.Max(1, Math.Min(currentPage, totalPages));
            int itemsToSkip = (currentPage - 1) * pageSize;
            var usersOnCurrentPage = users.Skip(itemsToSkip).Take(pageSize).ToList();

            ViewBag.Users = usersOnCurrentPage;
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;
            return View();
        }
        // GET : EDIT
        public ActionResult Edit(int id)
        {
            List<NoteModel> notes = BusinessLayer.GetUserNotes();
            ViewBag.Notes = notes;
            List<DocumentModel> documents = BusinessLayer.GetUserDocuments();
            ViewBag.Documents = documents;

            var userDetailEntity = context.UserDetails.FirstOrDefault(s => s.UserID == id);
            if (userDetailEntity == null)
            {
                return HttpNotFound();
            }

            List<AddressModel> list = BusinessLayer.GetAddresses(id);
 
            ContainerModel containerModel = new ContainerModel
            {
                User = BusinessLayer.GetUserById(userDetailEntity.UserID),
            };

            ViewBag.ObjectId = userDetailEntity.UserID;
            return View(containerModel);
        }

        [HttpPost]
        public ActionResult Edit(ContainerModel std)
        {
            var student = context.UserDetails.Where(s => s.UserID == std.User.UserID).FirstOrDefault();
            var address=context.AddressDetails.Where(s => s.UserID==std.User.UserID).FirstOrDefault();
            context.UserDetails.Remove(student);
            context.AddressDetails.Remove(address);

            List<AddressModel> addresses = new List<AddressModel> {
                std.PresentAddress, std.PermanentAddress
            };
            BusinessLayer.InsertUser(std.User, addresses);

            return RedirectToAction("UserList");
        }


        public JsonResult GetStatesForCountry(string selectedCountry)
        {
            List<string> states = BusinessLayer.GetStatesForCountry(selectedCountry);
            return Json(states, JsonRequestBehavior.AllowGet);
        }   
        public ActionResult SaveDetails(ContainerModel userDetails)
        {
            userDetails.PresentAddress.Type = (int)(Utility.AddressType.Present);
            userDetails.PermanentAddress.Type = (int)(Utility.AddressType.Permanent);

            Tuple<int, int> PresentList = BusinessLayer.GetCountryAndStateId(userDetails.PresentCountry.CountryName, userDetails.PresentState.StateName);
            userDetails.PresentAddress.CountryID = PresentList.Item1;
            userDetails.PresentAddress.StateID = PresentList.Item2;

            Tuple<int, int> PermanentList = BusinessLayer.GetCountryAndStateId(userDetails.PermanentCountry.CountryName, userDetails.PermanentState.StateName);
            userDetails.PermanentAddress.CountryID = PermanentList.Item1;
            userDetails.PermanentAddress.StateID = PermanentList.Item2;


            List<AddressModel> addresses = new List<AddressModel> {
                userDetails.PresentAddress, userDetails.PermanentAddress
            };

            BusinessLayer.InsertUser(userDetails.User, addresses);
            return RedirectToAction("Login", "Login");
        }
       


    }
                
}