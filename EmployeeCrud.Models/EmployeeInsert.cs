using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Models
{
    public class EmployeeInsert
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int BranchID { get; set; }
        public int DepartmentID { get; set; }
    }
}
