using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeCrud.Utils;

namespace EmployeeCrud.Business
{
    public class BusinessLayer
    {
        
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
    }
}

