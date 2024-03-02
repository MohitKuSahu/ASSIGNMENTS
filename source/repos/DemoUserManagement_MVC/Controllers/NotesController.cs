using DemoUserManagement.Business;
using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUserManagement_MVC.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public JsonResult SaveNote(string NoteText,int UserID)
        {
            int ObjectType = (int)Utility.ObjectType.UserForm;
            if (BusinessLayer.InsertNotes(NoteText, UserID, ObjectType))
            {
                return Json(new { success = true, message = "Note saved successfully" });
            }

            return Json(new { success = false, message = "Failed to save note" });
        }
    }
}