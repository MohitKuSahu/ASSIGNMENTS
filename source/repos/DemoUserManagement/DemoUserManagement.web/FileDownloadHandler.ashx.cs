using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DemoUserManagement
{
    /// <summary>
    /// Summary description for FileDownloadHandler
    /// </summary>
    public class FileDownloadHandler : IHttpHandler
    {
       
        public void ProcessRequest(HttpContext context)
        {


            //download file
            string fileName = context.Request.QueryString["fileName"];

            string filePath = System.Configuration.ConfigurationManager.AppSettings.Get("Path") + fileName;

            context.Response.ContentType = MimeMapping.GetMimeMapping(fileName);

            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);

            context.Response.WriteFile(filePath);

            context.Response.End();
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