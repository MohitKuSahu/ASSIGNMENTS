using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.Utils
{
    public class Logger
    {
        public static void AddData(Exception inputData)
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string logToFileSetting = ConfigurationManager.AppSettings["LogToFile"];
      

            bool logToFile = !string.IsNullOrEmpty(logToFileSetting) && bool.TryParse(logToFileSetting, out bool logToFileValue) && logToFileValue;


            if (logToFile)
            {
                LogToFile(inputData, fileName);
            }

        }

        private static void LogToFile(Exception inputData, string fileName)
        {
            string file = ConfigurationManager.AppSettings["LogFileFolderPath"] + fileName;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(inputData);
            }
        }

       
    }

}
