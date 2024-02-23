using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DemoUserManagement
{
    /// <summary>
    /// Summary description for FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpPostedFile file = context.Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    string guidString = context.Request["guidString"];

                    if (!string.IsNullOrEmpty(guidString))
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string newFileName = guidString + "_" + fileExtension;

                        string uploadFolder = System.Configuration.ConfigurationManager.AppSettings["Path"];

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        string FilePath = Path.Combine(uploadFolder, newFileName);
                        file.SaveAs(FilePath);

                        context.Response.Write("File uploaded successfully");

                    }
                    else
                    {
                        context.Response.Write("GUID not found in the request");

                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}