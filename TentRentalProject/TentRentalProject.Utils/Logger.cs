using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace TentRentalProject.Utils
{
    public class Logger
    {
        public static void AddData(Exception inputData)
        {
            string logToFileSetting = ConfigurationManager.AppSettings["LogToFile"];

            bool logToFile = !string.IsNullOrEmpty(logToFileSetting) && bool.TryParse(logToFileSetting, out bool logToFileValue) && logToFileValue;
            string fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (logToFile)
            {
                LogToFile(inputData, fileName);
            }
        }

        private static void LogToFile(Exception inputData, string fileName)
        {
            string file = ConfigurationManager.AppSettings["LogFileFolderPath"];
            file = Path.Combine(file, fileName);
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(inputData);
            }
        }
    }
   
}
