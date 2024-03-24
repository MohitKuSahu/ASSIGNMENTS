using System;
using System.Collections.Generic;

namespace CrudUsingCore.DAL.Models;

public partial class EmployeeesList
{
    public int EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? TechStack { get; set; }
}
