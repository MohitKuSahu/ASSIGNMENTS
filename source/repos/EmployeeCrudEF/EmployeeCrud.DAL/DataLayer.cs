
using EmployeeCrud.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.DAL
{
    public class DataLayer
    {
        public static List<EmployeeInsert> ViewEmployee(string fileName)
        {
            List<EmployeeInsert> allEmployee = new List<EmployeeInsert>();

            try
            {
                using (EMPLOYEELISTEntities1 emp = new EMPLOYEELISTEntities1())
                {
                    var employees = emp.Employees.ToList();
                    foreach (var employ in employees)
                    {

                        EmployeeInsert employeeInsert = new EmployeeInsert()
                        {
                            EmployeeID = employ.EmployeeID,
                            EmployeeName = employ.EmployeeName,
                            BranchID = (int)employ.BranchID,
                            DepartmentID = (int)employ.DepartmentID
                        };
                        allEmployee.Add(employeeInsert); 
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allEmployee;
        }

        public static bool InsertEmployee(EmployeeInsert emp1, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
                {
                    Employee emp = new Employee
                    {
                        EmployeeID = emp1.EmployeeID,
                        EmployeeName = emp1.EmployeeName,
                        BranchID = emp1.BranchID,
                        DepartmentID = emp1.DepartmentID
                    };

                    context.Employees.Add(emp);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool UpdateEmployee(int EmployeeId, EmployeeInsert EmployeeUpdate, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
                {
                    Employee EmployeeToUpdate = context.Employees.Find(EmployeeId);

                    if (EmployeeToUpdate != null)
                    {
                        EmployeeToUpdate.EmployeeName = EmployeeUpdate.EmployeeName;
                        EmployeeToUpdate.BranchID = EmployeeUpdate.BranchID;
                        EmployeeToUpdate.DepartmentID = EmployeeUpdate.DepartmentID;

                        context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool DeleteEmployee(int EmployeeId, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
                {
                    Employee EmployeeToDelete = context.Employees.Find(EmployeeId);

                    if (EmployeeToDelete != null)
                    {
                        context.Employees.Remove(EmployeeToDelete);
                        context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static List<EmployeeInsert> SearchEmployee(string searchString)
        {
            List<EmployeeInsert> search = new List<EmployeeInsert>();

            using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
            {
                var Employees = from s in context.Employees
                                where s.EmployeeName.Contains(searchString)
                                select new EmployeeInsert
                                {
                                    EmployeeID = s.EmployeeID,
                                    BranchID = (int)s.BranchID,
                                    DepartmentID = (int)s.DepartmentID,

                                };

                search.AddRange(Employees);
            }

            return search;
        }

        public static List<BranchInsert> ViewBranch(string fileName)
        {
            List<BranchInsert> allBranchs = null;
            try
            {
                using (EMPLOYEELISTEntities1 Context = new EMPLOYEELISTEntities1())
                {
                    List<Branch> allSem = Context.Branches.ToList();
                    allBranchs = new List<BranchInsert>();
                    foreach (var Branch in allSem)
                    {
                        BranchInsert bran = new BranchInsert
                        {
                            BranchID = Branch.BranchID,
                            BranchName = Branch.BranchName,
                            DepartmentID = (int)Branch.DepartmentID
                        };
                        allBranchs.Add(bran);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allBranchs;
        }


        public static bool InsertBranch(BranchInsert emp1, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
                {
                    Branch bran = new Branch
                    {
                        BranchName = emp1.BranchName,
                        BranchID = emp1.BranchID,
                        DepartmentID = emp1.DepartmentID
                    };

                    context.Branches.Add(bran);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool UpdateBranch(int BranchId, BranchInsert BranchUpdate, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 bran = new EMPLOYEELISTEntities1())
                {
                    Branch BranchToUpdate = bran.Branches.Find(BranchId);

                    if (BranchToUpdate != null)
                    {
                        BranchToUpdate.BranchName = BranchUpdate.BranchName;
                        BranchToUpdate.DepartmentID = BranchUpdate.DepartmentID;

                        bran.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool DeleteBranch(int BranchId, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 bran = new EMPLOYEELISTEntities1())
                {
                    Branch BranchToDelete = bran.Branches.Find(BranchId);

                    if (BranchToDelete != null)
                    {
                        bran.Branches.Remove(BranchToDelete);
                        bran.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static List<DepartmentInsert> ViewDepartment(string fileName)
        {
            List<DepartmentInsert> allDepartments = null;
            try
            {
                using (EMPLOYEELISTEntities1 Context = new EMPLOYEELISTEntities1())
                {
                    List<Department> allDep = Context.Departments.ToList();
                    allDepartments = new List<DepartmentInsert>();
                    foreach (var Department in allDep)
                    {
                        DepartmentInsert bran = new DepartmentInsert
                        {
                            DepartmentName = Department.DepartmentName,
                            DepartmentID = (int)Department.DepartmentID
                        };
                        allDepartments.Add(bran);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allDepartments;
        }

        public static bool InsertDepartment(DepartmentInsert emp1, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
                {
                    Department bran = new Department
                    {
                        DepartmentName = emp1.DepartmentName,
                        DepartmentID = emp1.DepartmentID
                    };

                    context.Departments.Add(bran);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool UpdateDepartment(int BranchId, DepartmentInsert DepartmentUpdate, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
                {
                    Department DepartmentToUpdate = context.Departments.Find(BranchId);

                    if (DepartmentToUpdate != null)
                    {

                        DepartmentToUpdate.DepartmentName = DepartmentUpdate.DepartmentName;

                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool DeleteDepartment(int DepartmentId, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
                {
                    Department DepartmentToDelete = context.Departments.Find(DepartmentId);

                    if (DepartmentToDelete != null)
                    {
                        context.Departments.Remove(DepartmentToDelete);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

    }
}














