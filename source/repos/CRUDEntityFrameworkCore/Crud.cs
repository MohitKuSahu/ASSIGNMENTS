using CRUDEntityFrameworkCore.Models_Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
//Crud Operation Using Console
namespace CRUDEntityFrameworkCore
{
    public class Crud
    {
        enum Op
        {
            ViewEmployees = 1,
            InsertEmployees,
            UpdateEmployees,
            DeleteEmployees,
            ViewBranch,
            InsertBranch,
            UpdateBranch,
            DeleteBranch,
            ViewDepartment,
            InsertDepartment,
            UpdateDepartment,
            DeleteDepartment
        }
        public static void CrudOperations()
        {

            using (var context = new EmployeelistContext())
            {

                Console.Write("\n\n");
                Console.WriteLine("A simple CRUD operation program using EDM method:");
                Console.Write("------------------------------------------------");
                Console.Write("\n\n");
                Console.Write("\nHere are the options :\n");
                Console.WriteLine("------------------------------------------------");


                Boolean x = true;
                while (x)
                {
                    Console.WriteLine("Press " + $"{(int)(Op.ViewEmployees)}" + " for viewing Employees Table");
                    Console.WriteLine("Press " + $"{(int)(Op.InsertEmployees)}" + " for insering details in Employees Table");
                    Console.WriteLine("Press " + $"{(int)(Op.UpdateEmployees)}" + " for updating details in Employees Table");
                    Console.WriteLine("Press " + $"{(int)(Op.DeleteEmployees)}" + " for deleting details in Employees Table");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Press" + $"{(int)(Op.ViewBranch)}" + " for viewing Branch Table");
                    Console.WriteLine("Press" + $"{(int)(Op.InsertBranch)}" + " for insering details in Branch Table");
                    Console.WriteLine("Press " + $"{(int)(Op.UpdateBranch)}" + " for updating details in Branch Table");
                    Console.WriteLine("Press " + $"{(int)(Op.DeleteBranch)}" + " for deleting details in Branch Table");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Press " + $"{(int)(Op.ViewDepartment)}" + " for viewing Department Table");
                    Console.WriteLine("Press " + $"{(int)(Op.InsertDepartment)}" + " for insering details in Department Table");
                    Console.WriteLine("Press " + $"{(int)(Op.UpdateDepartment)}" + " for updating details in Department Table");
                    Console.WriteLine("Press " + $"{(int)(Op.DeleteDepartment)}" + " for deleting details in Department Table");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Press any other number to exit");


                    Console.Write("\nInput your choice :");
                    int N = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                    switch (N)
                    {
                        case (int)Op.ViewEmployees:
                            var AllEmployees = context.Employees.ToList();

                            foreach (Employee emp in AllEmployees)
                            {
                                Console.WriteLine(emp.EmployeeId + " " + emp.EmployeeName + " " + emp.BranchId + " " + emp.DepartmentId);
                            }

                            Console.Write("\n\n");
                            break;

                        case (int)Op.InsertEmployees:
                            Console.Write("Enter Employees ID:");
                            int Emp_Id = Convert.ToInt32(Console.ReadLine());

                            if (context.Employees.Any(e => e.EmployeeId == Emp_Id))
                            {
                                Console.Write("Emp_id already exist");
                                break;
                            }

                            Console.Write("Enter Employees Name:");
                            string? Emp_Name = Console.ReadLine();

                            Console.Write("Enter Branch ID:");
                            int branch_Id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Department ID:");
                            int dept_Id = Convert.ToInt32(Console.ReadLine());



                            var Emp = new Employee()
                            {
                                EmployeeId = Emp_Id,
                                EmployeeName = Emp_Name,
                                BranchId = branch_Id,
                                DepartmentId = dept_Id

                            };

                            context.Employees.Add(Emp);
                            context.SaveChanges();
                            Console.WriteLine("Inserted Successfully!!!");

                            Console.Write("\n\n");
                            break;

                        case (int)Op.UpdateEmployees:
                            Console.Write("Enter your Employees ID:");
                            int Id = Convert.ToInt32(Console.ReadLine());

                            if (!context.Employees.Any(e => e.EmployeeId == Id))
                            {
                                Console.Write("Emp_id does not exist");
                                break;
                            }
                            var EmployeesToUpdate = context.Employees.Find(Id);

                            Console.Write("Enter your new Employees Name:");
                            string? EmployeesName = Console.ReadLine();


                            Console.Write("Enter yur new Branch ID:");
                            int BranchID = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Department ID:");
                            int DepartmentID = Convert.ToInt32(Console.ReadLine());


                                EmployeesToUpdate.EmployeeName = EmployeesName;
                                EmployeesToUpdate.BranchId = BranchID;
                                EmployeesToUpdate.DepartmentId = DepartmentID;
                                context.SaveChanges();
                                Console.WriteLine("Updated Successfully!!!");
                          
                            Console.Write("\n\n");
                            break;


                        case (int)Op.DeleteEmployees:

                            Console.Write("Enter your Employees ID:");
                            int DeleteId = Convert.ToInt32(Console.ReadLine());

                            if (!context.Employees.Any(e => e.EmployeeId == DeleteId))
                            {
                                Console.Write("Emp_id does not exist");
                                break;
                            }

                            var EmployeesToDelete = context.Employees.Find(DeleteId);
                           
                                context.Employees.Remove(EmployeesToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Deleted Successfully!!!");
                            
                           
                            Console.Write("\n\n");
                            break;


                        case (int)Op.ViewBranch:
                            var AllBranch = context.Branches.ToList();

                            foreach (Branch emp in AllBranch)
                            {
                                Console.WriteLine(emp.BranchId + " " + emp.BranchName + " " + emp.DepartmentId);
                            }
                            Console.Write("\n\n");
                            break;


                        case (int)(Op.InsertBranch):
                            Console.Write("Enter Branch ID:");
                            int Branch_Id = Convert.ToInt32(Console.ReadLine());


                            if (context.Branches.Any(e => e.BranchId == Branch_Id))
                            {
                                Console.Write("Branch_id already exist! Try with another Id");
                                break;
                            }

                            Console.Write("Enter Branch Name:");
                            string? Branch_Name = Console.ReadLine();

                            Console.Write("Enter Department ID:");
                            int Department_Id = Convert.ToInt32(Console.ReadLine());



                            var Bran = new Branch()
                            {
                                BranchId = Branch_Id,
                                BranchName = Branch_Name,
                                DepartmentId = Department_Id

                            };

                            context.Branches.Add(Bran);
                            
                                context.SaveChanges();
                                Console.WriteLine("Inserted Successfully!!!");
                           
                            Console.Write("\n\n");
                            break;


                        case (int)Op.UpdateBranch:
                            Console.Write("Enter your Branch ID:");
                            int BranchId = Convert.ToInt32(Console.ReadLine());

                            if (!context.Branches.Any(e => e.BranchId == BranchId))
                            {
                                Console.Write("Branch_id does not exist");
                                break;
                            }

                            var BranchToUpdate = context.Branches.Find(BranchId);


                            Console.Write("Enter your new Branch Name:");
                            string? BranchName = Console.ReadLine();


                            Console.Write("Enter your new Department ID:");
                            int DepartmentId = Convert.ToInt32(Console.ReadLine());

                                BranchToUpdate.BranchName = BranchName;
                                BranchToUpdate.DepartmentId = DepartmentId;
                                context.SaveChanges();
                                Console.WriteLine("Updated Successfully!!!");
                           
                            Console.Write("\n\n");
                            break;


                        case (int)Op.DeleteBranch:
                            Console.Write("Enter your Branch ID:");
                            int DeleteBranchId = Convert.ToInt32(Console.ReadLine());

                            if (!context.Branches.Any(e => e.BranchId == DeleteBranchId))
                            {
                                Console.Write("Emp_id does not exist");
                                break;
                            }

                            var BranchToDelete = context.Branches.Find(DeleteBranchId);
                           
                                context.Branches.Remove(BranchToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Deleted Successfully!!!");
                           
                            
                            Console.Write("\n\n");
                            break;


                        case (int)Op.ViewDepartment:
                            var AllDepartment = context.Departments.ToList();

                            foreach (Department emp in AllDepartment)
                            {
                                Console.WriteLine(emp.DepartmentId + " " + emp.DepartmentName + " ");
                            }
                            Console.Write("\n\n");
                            break;

                        case (int)Op.InsertDepartment:
                            Console.Write("Enter Department ID:");
                            int Dept_Id = Convert.ToInt32(Console.ReadLine());

                            if (context.Departments.Any(e => e.DepartmentId == Dept_Id))
                            {
                                Console.Write("Dept_id already exist! Try with another Id");
                                break;
                            }

                            Console.Write("Enter Department Name:");
                            string? Dept_Name = Console.ReadLine();

                            var Dep = new Department()
                            {
                                DepartmentId = Dept_Id,
                                DepartmentName = Dept_Name
                            };

                            context.Departments.Add(Dep);
                           
                                context.SaveChanges();
                                Console.WriteLine("Inserted Successfully!!!");
                           
                            Console.Write("\n\n");
                            break;

                        case (int)Op.UpdateDepartment:
                            Console.Write("Enter your Department ID:");
                            int Department_ID = Convert.ToInt32(Console.ReadLine());

                            if (!context.Departments.Any(e => e.DepartmentId == Department_ID))
                            {
                                Console.Write("Dept_id does not exist");
                                break;
                            }

                            var DepartmentToUpdate = context.Departments.Find(Department_ID);


                            Console.Write("Enter your new Department Name:");
                            string? DepartmentName = Console.ReadLine();
                            
                                DepartmentToUpdate.DepartmentName = DepartmentName;
                                context.SaveChanges();
                                Console.WriteLine("Updated Successfully!!!");
                            
                            
                            Console.Write("\n\n");
                            break;

                        case (int)Op.DeleteDepartment:
                            Console.Write("Enter your Department ID:");
                            int DeleteDepartmentId = Convert.ToInt32(Console.ReadLine());

                            if (!context.Departments.Any(e => e.DepartmentId == DeleteDepartmentId))
                            {
                                Console.Write("Emp_id does not exist");
                                break;
                            }


                            var DepartmentToDelete = context.Departments.Find(DeleteDepartmentId);

                           
                                context.Departments.Remove(DepartmentToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Deleted Successfully!!!");
                            
                            Console.Write("\n\n");
                            break;

                        default:
                            x = false;
                            Console.Write("\n\n");
                            break;

                    }



                }
            }

            Console.WriteLine("Exited Successfully");


        }
    }
}
