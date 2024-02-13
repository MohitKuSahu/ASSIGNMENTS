using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Models
{
    public class BranchInsert
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public int DepartmentID { get; set; }
    }
}
