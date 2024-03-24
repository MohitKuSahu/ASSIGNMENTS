using System;
using System.Collections.Generic;

namespace CRUDEntityFrameworkCore.Models_Test;

public partial class Branch
{
    public int BranchId { get; set; }

    public string? BranchName { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
