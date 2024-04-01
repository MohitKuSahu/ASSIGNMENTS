using System;
using System.Configuration;
using System.IO;

namespace CrudEntityFramework
{
    internal class Logger
    {
        public static void AddData(Exception inputData, String fileName)
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = Path.Combine(_fileFolderPath, fileName);

            if (!Directory.Exists(_fileFolderPath))
            {
                Directory.CreateDirectory(_fileFolderPath);
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(DateTime.Now + "==>" + inputData.Message);

                if (inputData.InnerException != null)
                {
                    writer.WriteLine(inputData.InnerException.Message);
                }

                writer.WriteLine();
            }
        }
    }
}
 
