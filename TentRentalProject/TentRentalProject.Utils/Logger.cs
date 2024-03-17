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
            string fileName = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + ".txt";
            string fileFolderPath = ConfigurationManager.AppSettings["LogFileFolderPath"];
            string filePath = Path.Combine(fileFolderPath, fileName);


            if (!Directory.Exists(fileFolderPath))
            {
                Directory.CreateDirectory(fileFolderPath);
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(inputData);
            }
        }
    }
   
}
