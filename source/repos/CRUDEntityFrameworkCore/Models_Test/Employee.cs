using System;
using System.Collections.Generic;

namespace CRUDEntityFrameworkCore.Models_Test;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public int? BranchId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
