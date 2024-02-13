using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Utils
{
    public class Utility
    {

        public enum Op
        {
            ViewEmployee = 1,
            InsertEmployee,
            UpdateEmployee,
            DeleteEmployee,
            SearchEmployee,
            ViewBranch,
            InsertBranch,
            UpdateBranch,
            DeleteBranch,
            ViewDepartment,
            InsertDepartment,
            UpdateDepartment,
            DeleteDepartment
        }
    }
}
