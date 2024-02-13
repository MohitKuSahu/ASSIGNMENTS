using CRUD_EntityFramework;
using CrudEntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EntityFramework
{
    internal class Program
    {
        static String fileName = "";
        enum Op
        {
            ViewEmployee = 1,
            InsertEmployee,
            UpdateEmployee,
            DeleteEmployee,
            ViewBranch,
            InsertBranch,
            UpdateBranch,
            DeleteBranch,
            ViewDepartment,
            InsertDepartment,
            UpdateDepartment,
            DeleteDepartment
        }
        static void Main(String[] args)
        {
            fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            try
            {
                Crud();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            Console.ReadKey();
        }

        static void Crud()
        {
    
            using (var context = new EMPLOYEELISTEntities())
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
                    Console.WriteLine("Press " + $"{(int)(Op.ViewEmployee)}" + " for viewing Employee Table");
                    Console.WriteLine("Press " + $"{(int)(Op.InsertEmployee)}" + " for insering details in Employee Table");
                    Console.WriteLine("Press " + $"{(int)(Op.UpdateEmployee)}" + " for updating details in Employee Table");
                    Console.WriteLine("Press " + $"{(int)(Op.DeleteEmployee)}" + " for deleting details in Employee Table");
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
                        case (int)Op.ViewEmployee:
                            var AllEmployee= context.Employees.ToList();
                            
                            foreach(Employee emp in AllEmployee)
                            {
                                Console.WriteLine(emp.EmployeeID+" "+emp.EmployeeName+" "+emp.BranchID+" "+emp.DepartmentID); 
                            }

                            Console.Write("\n\n");
                        break;


                        case (int)Op.InsertEmployee:
                            Console.Write("Enter Employee ID:");
                            int Emp_Id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Employee Name:");
                            string Emp_Name = Console.ReadLine();


                            Console.Write("Enter Branch ID:");
                            int branch_Id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Department ID:");
                            int dept_Id = Convert.ToInt32(Console.ReadLine());

                            var Emp = new Employee()
                            {
                                EmployeeID = Emp_Id,    
                                EmployeeName = Emp_Name,    
                                BranchID= branch_Id,    
                                DepartmentID = dept_Id
                        
                            };

                            context.Employees.Add(Emp);
                            try
                            {
                                context.SaveChanges();
                                Console.WriteLine("Inserted Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again");
                            }
                            Console.Write("\n\n");
                        break;



                       case (int)Op.UpdateEmployee:
                            Console.Write("Enter your Employee ID:");
                            int Id = Convert.ToInt32(Console.ReadLine());
                            var EmployeeToUpdate = context.Employees.Find(Id);

                            Console.Write("Enter your new Employee Name:");
                            string EmployeeName = Console.ReadLine();


                            Console.Write("Enter yur new Branch ID:");
                            int BranchID = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Department ID:");
                            int DepartmentID = Convert.ToInt32(Console.ReadLine());



                            try
                            {
                                EmployeeToUpdate.EmployeeName = EmployeeName;
                                EmployeeToUpdate.BranchID = BranchID;
                                EmployeeToUpdate.DepartmentID = DepartmentID;
                                context.SaveChanges();
                                Console.WriteLine("Updated Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again");
                            }
                            Console.Write("\n\n");
                            break;

                            

                        case (int)Op.DeleteEmployee:

                            Console.Write("Enter your Employee ID:");
                            int DeleteId = Convert.ToInt32(Console.ReadLine());
                            var EmployeeToDelete = context.Employees.Find(DeleteId);

                            try
                            {
                                context.Employees.Remove(EmployeeToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Deleted Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again");
                            }
                            Console.Write("\n\n");
                            break;




                        case (int)Op.ViewBranch:
                            var AllBranch = context.Branches.ToList();

                            foreach (Branch emp in AllBranch)
                            {
                                Console.WriteLine(emp.BranchID + " " + emp.BranchName + " " + emp.DepartmentID);
                            }
                            Console.Write("\n\n");
                            break;




                        case (int)(Op.InsertBranch):
                            Console.Write("Enter Branch ID:");
                            int Branch_Id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Branch Name:");
                            string Branch_Name = Console.ReadLine();

                            Console.Write("Enter Department ID:");
                            int Department_Id = Convert.ToInt32(Console.ReadLine());

                            var Bran = new Branch()
                            {
                                BranchID = Branch_Id,
                                BranchName = Branch_Name,
                                DepartmentID = Department_Id

                            };

                            context.Branches.Add(Bran);
                            try
                            {
                                context.SaveChanges();
                                Console.WriteLine("Inserted Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again");
                            }
                            Console.Write("\n\n");
                            break;




                        case (int)Op.UpdateBranch:
                            Console.Write("Enter your Branch ID:");
                            int BranchId = Convert.ToInt32(Console.ReadLine());
                            var BranchToUpdate = context.Branches.Find(BranchId);


                            Console.Write("Enter your new Branch Name:");
                            string BranchName = Console.ReadLine();


                            Console.Write("Enter your new Department ID:");
                            int DepartmentId = Convert.ToInt32(Console.ReadLine());


                            try
                            {
                                BranchToUpdate.BranchName = BranchName;
                                BranchToUpdate.DepartmentID = DepartmentId;
                                context.SaveChanges();
                                Console.WriteLine("Updated Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again");
                            }
                            Console.Write("\n\n");
                            break;





                        case (int)Op.DeleteBranch:
                            Console.Write("Enter your Branch ID:");
                            int DeleteBranchId = Convert.ToInt32(Console.ReadLine());
                            var BranchToDelete = context.Branches.Find(DeleteBranchId);

                   

                            try
                            {
                                context.Branches.Remove(BranchToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Deleted Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again");
                            }
                            Console.Write("\n\n");
                            break;



                        case (int)Op.ViewDepartment:
                            var AllDepartment = context.Departments.ToList();

                            foreach(Department emp in AllDepartment)
                            {
                                Console.WriteLine(emp.DepartmentID + " " + emp.DepartmentName + " " );
                            }
                            Console.Write("\n\n");
                            break;



                        case (int)Op.InsertDepartment:
                            Console.Write("Enter Department ID:");
                            int Dept_Id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Department Name:");
                            string Dept_Name = Console.ReadLine();

                            var Dep = new Department()
                            {
                                DepartmentID = Dept_Id,
                                DepartmentName = Dept_Name
                            };

                            context.Departments.Add(Dep);
                            try
                            {
                                context.SaveChanges();
                                Console.WriteLine("Inserted Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again");
                            }
                            Console.Write("\n\n");
                            break;



                        case (int)Op.UpdateDepartment:
                            Console.Write("Enter your Department ID:");
                            int Department_ID = Convert.ToInt32(Console.ReadLine());
                            var DepartmentToUpdate = context.Departments.Find(Department_ID);


                            Console.Write("Enter your new Department Name:");
                            string DepartmentName = Console.ReadLine();
                            try
                            {
                                DepartmentToUpdate.DepartmentName = DepartmentName;
                                context.SaveChanges();
                                Console.WriteLine("Updated Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again");
                            }
                            Console.Write("\n\n");
                            break;

                        case (int)Op.DeleteDepartment:
                            Console.Write("Enter your Department ID:");
                            int DeleteDepartmentId = Convert.ToInt32(Console.ReadLine());

                            var DepartmentToDelete = context.Departments.Find(DeleteDepartmentId);

                            try
                            {
                                context.Departments.Remove(DepartmentToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Deleted Successfully!!!");
                            }
                            catch (Exception ex)
                            {
                                Logger.AddData(ex, fileName);
                                Console.WriteLine("OOPS!! Error try again \n");
                            }
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



