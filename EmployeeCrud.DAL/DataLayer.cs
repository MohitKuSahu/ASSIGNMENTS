using EmployeeCrud.Models;
using EmployeeCrud.Utils;
using EmployeeLayer.DAL;
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
            List<EmployeeInsert> allEmployeesDisplay = new List<EmployeeInsert>();
            try
            {
                using (EMPLOYEELISTEntities1 stud = new EMPLOYEELISTEntities1())
                {
                    List<Employee> allEmployees = stud.Employees.ToList();
                    var mapper = Mapper.ViewMapper();
                    allEmployeesDisplay = mapper.Map<List<Employee>, List<EmployeeInsert>>(allEmployees);
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allEmployeesDisplay;
        }

        public static bool InsertEmployee(EmployeeInsert emp1, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 context = new EMPLOYEELISTEntities1())
                {
                    var mapper = Mapper.InsertMapper();
                    Employee Employee = mapper.Map<EmployeeInsert, Employee>(emp1);

                    context.Employees.Add(Employee);
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
                using (EMPLOYEELISTEntities1 stud = new EMPLOYEELISTEntities1())
                {
                    Employee EmployeeToUpdate = stud.Employees.Find(EmployeeId);
                    var mapper = Mapper.UpdateMapper();
                    if (EmployeeToUpdate != null)
                    {
                        mapper.Map(EmployeeUpdate, EmployeeToUpdate);
                        stud.SaveChanges();
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
            List<BranchInsert> displayBranchs = new List<BranchInsert>();
            try
            {
                using (EMPLOYEELISTEntities1 stud = new EMPLOYEELISTEntities1())
                {
                    List<Branch> allBranchs = stud.Branches.ToList();
                    var mapper = Mapper.ViewMapper();
                    displayBranchs = mapper.Map<List<Branch>, List<BranchInsert>>(allBranchs);
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return displayBranchs;
        }


        public static bool InsertBranch(BranchInsert emp1, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 stud = new EMPLOYEELISTEntities1())
                {
                    var mapper = Mapper.InsertMapper();
                    Branch Branch = mapper.Map<BranchInsert, Branch>(emp1);
                    stud.Branches.Add(Branch);
                    stud.SaveChanges();
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
                using (EMPLOYEELISTEntities1 stud = new EMPLOYEELISTEntities1())
                {
                    Branch BranchToUpdate = stud.Branches.Find(BranchId);
                    var mapper = Mapper.UpdateMapper();
                    if (BranchToUpdate != null)
                    {
                        mapper.Map(BranchUpdate, BranchToUpdate);

                        stud.SaveChanges();
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
            List<DepartmentInsert> displayDepartments = new List<DepartmentInsert>();
            try
            {
                using (EMPLOYEELISTEntities1 stud = new EMPLOYEELISTEntities1())
                {
                    List<Department> allDepartments = stud.Departments.ToList();
                    var mapper = Mapper.ViewMapper();
                    displayDepartments = mapper.Map<List<Department>, List<DepartmentInsert>>(allDepartments);
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return displayDepartments;
        }

        public static bool InsertDepartment(DepartmentInsert emp1, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 stud = new EMPLOYEELISTEntities1())
                {
                    var mapper = Mapper.InsertMapper();
                    Department Department = mapper.Map<DepartmentInsert, Department>(emp1);
                    stud.Departments.Add(Department);
                    stud.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool UpdateDepartment(int DepartmentId, DepartmentInsert DepartmentUpdate, string fileName)
        {
            try
            {
                using (EMPLOYEELISTEntities1 stud = new EMPLOYEELISTEntities1())
                {
                    Department DepartmentToUpdate = stud.Departments.Find(DepartmentId);
                    var mapper = Mapper.UpdateMapper();
                    if (DepartmentToUpdate != null)
                    {
                        mapper.Map(DepartmentUpdate, DepartmentToUpdate);

                        stud.SaveChanges();
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

        public static List<CombinedData> GetCombinedData(string fileName)
        {
            try
            {
                using (var context = new EMPLOYEELISTEntities1())
                {


                    var combinedData = from emp in context.Employees
                                       join branch in context.Branches on emp.BranchID equals branch.BranchID
                                       join dep in context.Departments on emp.DepartmentID equals dep.DepartmentID
                                       select new CombinedData
                                       {
                                           EmployeeID = emp.EmployeeID,
                                           EmployeeName = emp.EmployeeName,
                                           BranchName = branch.BranchName,
                                           DepartmentName = dep.DepartmentName,
                                       };

                    return combinedData.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return null;
            }

        }
    }
}

