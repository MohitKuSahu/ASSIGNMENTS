using DemoUserManagement.Business;
using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagement.Utils.Utility;

namespace DemoUserManagement_MVC.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UploadFile(HttpPostedFileBase fileUpload,int ObjectId)
        {
            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                try
                {
                    string filename = Path.GetFileName(fileUpload.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    string guid = Guid.NewGuid().ToString();
                    string folderPath = Server.MapPath("~/Output/");
                    string filePath = Path.Combine(folderPath, guid + fileExtension);

                    fileUpload.SaveAs(filePath);

                    DocumentModel document = new DocumentModel
                    {
                        ObjectID = ObjectId, 
                        ObjectType = (int)ObjectType.UserForm,
                        DocumentOriginalName = filename,
                        DocumentGuidName = guid + fileExtension,
                        TimeStamp = DateTime.Now.ToString("d")
                    };

                    BusinessLayer.AddDocument(document);

                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error uploading file: " + ex.Message });
                }
            }

         
            return Json(new { success = true, message = "file uploaded." });
        }
        public ActionResult DownloadFile(string fileName)
        {
            string filePath = Path.Combine(Server.MapPath("~/Output/"), fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

            return HttpNotFound("File not found");
        }


    }
}