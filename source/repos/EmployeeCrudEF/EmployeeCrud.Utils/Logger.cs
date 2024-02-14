using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace EmployeeCrud.Utils
{
    public class Logger
    {
        public static void AddData(Exception inputData, string fileName)
        {
            string logToFileSetting = ConfigurationManager.AppSettings["LogToFile"];
            string logToTableSetting = ConfigurationManager.AppSettings["LogToTable"];

            bool logToFile = !string.IsNullOrEmpty(logToFileSetting) && bool.TryParse(logToFileSetting, out bool logToFileValue) && logToFileValue;
            bool logToTable = !string.IsNullOrEmpty(logToTableSetting) && bool.TryParse(logToTableSetting, out bool logToTableValue) && logToTableValue;


            if (logToFile)
            {
                LogToFile(inputData, fileName);
            }

            if (logToTable)
            {
                LogToTable(inputData);
            }
        }

        private static void LogToFile(Exception inputData, string fileName)
        {
            fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string file = ConfigurationManager.AppSettings["LogFileFolderPath"];
            file = Path.Combine(file, fileName);
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(inputData);
            }
        }

        private static void LogToTable(Exception inputData)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["db1"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();

                    string query = "INSERT INTO ErrorLog (ErrorMessage, LogTime) VALUES (@ErrorMessage, @LogTime)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ErrorMessage", inputData.Message);
                        command.Parameters.AddWithValue("@LogTime", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                Console.WriteLine(); 
            }
        }
    }
}

