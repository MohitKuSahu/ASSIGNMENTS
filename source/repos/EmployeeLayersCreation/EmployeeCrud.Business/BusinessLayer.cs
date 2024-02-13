using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeCrud.Models;
using EmployeeCrud.Utils;

namespace EmployeeCrud.Business
{
    public class BusinessLayer
    {
        public static List<CombinedData> GetCombinedDatas(string fileName)
        {
            return DAL.DataLayer.GetCombinedData(fileName); 
        }

        public static List<EmployeeInsert> ViewEmployee(string fileName)
        {
            return DAL.DataLayer.ViewEmployee(fileName);
        }

        public static bool InsertEmployee(EmployeeInsert emp1, string fileName)
        {
            return DAL.DataLayer.InsertEmployee(emp1, fileName);
        }

        public static bool UpdateEmployee(int EmployeeId, EmployeeInsert EmployeeInput, string fileName)
        {
            return DAL.DataLayer.UpdateEmployee(EmployeeId, EmployeeInput, fileName);
        }

        public static bool DeleteEmployee(int EmployeeId, string fileName)
        {
            return DAL.DataLayer.DeleteEmployee(EmployeeId, fileName);
        }

        public static List<EmployeeInsert> SearchEmployee(string searchString)
        {
            return DAL.DataLayer.SearchEmployee(searchString);
        }

        public static List<BranchInsert> ViewBranch(string fileName)
        {
            return DAL.DataLayer.ViewBranch(fileName);
        }
       
        public static bool InsertBranch(BranchInsert Branch1, string fileName)
        {
            return DAL.DataLayer.InsertBranch(Branch1, fileName);
        }

        public static bool UpdateBranch(int BranchId, BranchInsert Branch, string fileName)
        {
            return DAL.DataLayer.UpdateBranch(BranchId, Branch, fileName);
        }

        public static bool DeleteBranch(int BranchId, string fileName)
        {
            return DAL.DataLayer.DeleteBranch(BranchId, fileName);
        }

        public static List<DepartmentInsert> ViewDepartment(string fileName)
        {
            return DAL.DataLayer.ViewDepartment(fileName);

        }

        public static bool InsertDepartment(DepartmentInsert Dept1, string fileName)
        {
            bool res = DAL.DataLayer.InsertDepartment(Dept1, fileName);
            return res;
        }

        public static bool UpdateDepartment(int DepartmentId, DepartmentInsert newDepartmentName, string fileName)
        {
            return DAL.DataLayer.UpdateDepartment(DepartmentId, newDepartmentName, fileName);
        }

        public static bool DeleteDepartment(int DepartmentId, string fileName)
        {
            return DAL.DataLayer.DeleteDepartment(DepartmentId, fileName);
        }
        public static void ExportDataToExcel<T>(List<T> dataList, string fileName)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            FileInfo fileInfo = new FileInfo(fileName);
            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Count > 0 ? excelPackage.Workbook.Worksheets[0] : excelPackage.Workbook.Worksheets.Add("Sheet1");
                var properties = dataList[0].GetType().GetProperties();
                for (int j = 0; j < properties.Length; j++)
                {
                    worksheet.Cells[1, j + 1].Value = properties[j].Name;
                    worksheet.Cells[1, j + 1].Style.Font.Bold = true;
                }

                worksheet.Cells[1, properties.Length + 1].Value = "Date and Time";
                worksheet.Cells[1, properties.Length + 1].Style.Font.Bold = true;

                for (int i = 0; i < dataList.Count; i++)
                {
                    properties = dataList[i].GetType().GetProperties();
                    for (int j = 0; j < properties.Length; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = properties[j].GetValue(dataList[i]);
                    }
                    worksheet.Cells[i + 2, properties.Length + 1].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }

                excelPackage.Save();
            }
        }

        public static void ExportDataToCsv<T>(List<T> data, string fileName)
        {
            if (data == null || data.Count == 0)
            {
                Console.WriteLine("No data to export.");
                return;
            }

            var csvContent = new StringBuilder();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                csvContent.Append(property.Name).Append(",");
            }
            csvContent.AppendLine();

            foreach (var item in data)
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(item);
                    csvContent.Append(value).Append(",");
                }
                csvContent.AppendLine();
            }

            File.WriteAllText(fileName, csvContent.ToString());
        }
    }
}

