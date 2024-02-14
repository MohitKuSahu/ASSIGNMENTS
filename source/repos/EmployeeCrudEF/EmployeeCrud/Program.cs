using EmployeeCrud.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace EmployeeCrud
{
    internal class Program
    {
        static string fileName = "";
        static void Main(string[] args)
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

            Console.Write("\n\n");
            Console.WriteLine("A simple CRUD operation  using EDM layers method:");
            Console.Write("------------------------------------------------");
            Console.Write("\n\n");
            Console.Write("\nHere are the options :\n");
            Console.WriteLine("------------------------------------------------");


            Boolean x = true;
            while (x)
            {
                Console.WriteLine("Press " + $"{(int)(Utility.Op.ViewEmployee)}" + " for viewing Employee Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.InsertEmployee)}" + " for insering details in Employee Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.UpdateEmployee)}" + " for updating details in Employee Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.DeleteEmployee)}" + " for deleting details in Employee Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.SearchEmployee)}" + " for searching particular details in Employee Table");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Press" + $"{(int)(Utility.Op.ViewBranch)}" + " for viewing Branch Table");
                Console.WriteLine("Press" + $"{(int)(Utility.Op.InsertBranch)}" + " for insering details in Branch Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.UpdateBranch)}" + " for updating details in Branch Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.DeleteBranch)}" + " for deleting details in Branch Table");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.ViewDepartment)}" + " for viewing Department Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.InsertDepartment)}" + " for insering details in Department Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.UpdateDepartment)}" + " for updating details in Department Table");
                Console.WriteLine("Press " + $"{(int)(Utility.Op.DeleteDepartment)}" + " for deleting details in Department Table");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Press any other number to exit");


                Console.Write("\nInput your choice :");
                int N = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");
                switch (N)
                {
                    case (int)(Utility.Op.ViewEmployee):
                        List<EmployeeInsert> allEmployee = Business.BusinessLayer.ViewEmployee(fileName);

                        if (allEmployee != null && allEmployee.Count > 0)
                        {
                            Console.WriteLine("All Employee:");
                            foreach (var emp in allEmployee)
                            {
                                Console.WriteLine($"Employee ID: {emp.EmployeeID}, Name: {emp.EmployeeName}, Branch ID:{emp.BranchID} , Department ID:{emp.DepartmentID}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Employee found.");
                        }
                        break;

                    case (int)(Utility.Op.InsertEmployee):
                        InsertEmployee();
                        break;

                    case (int)(Utility.Op.UpdateEmployee):
                        UpdateEmployee();
                        break;

                    case (int)(Utility.Op.DeleteEmployee):
                        DeleteEmployee();
                        break;

                    case (int)(Utility.Op.SearchEmployee):
                        SearchEmployee();
                        break;

                    case (int)(Utility.Op.ViewBranch):
                        List<BranchInsert> allBranchs = Business.BusinessLayer.ViewBranch(fileName);
                        if (allBranchs != null && allBranchs.Count > 0)
                        {
                            Console.WriteLine("All Branchs:");
                            foreach (var Branch in allBranchs)
                            {
                                Console.WriteLine($"Branch ID: {Branch.BranchID}, Branch Name: {Branch.BranchName}, Department ID: {Branch.DepartmentID}, ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Branches found.");
                        }
                        break;

                    case (int)(Utility.Op.InsertBranch):
                        InsertBranch();
                        break;

                    case (int)(Utility.Op.UpdateBranch):
                        UpdateBranch();
                        break;

                    case (int)(Utility.Op.DeleteBranch):
                        DeleteBranch();
                        break;

                    case (int)(Utility.Op.ViewDepartment):
                        List<DepartmentInsert> allDepartments = Business.BusinessLayer.ViewDepartment(fileName);

                        if (allDepartments != null && allDepartments.Count > 0)
                        {
                            Console.WriteLine("All Departments:");
                            foreach (var emp in allDepartments)
                            {
                                Console.WriteLine($"Department ID:{emp.DepartmentID} , Department Name: {emp.DepartmentName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Departments found.");
                        }
                        break;

                        

                    case (int)(Utility.Op.InsertDepartment):
                        InsertDepartment();
                        break;

                    case (int)(Utility.Op.UpdateDepartment):
                        UpdateDepartment();
                        break;

                    case (int)(Utility.Op.DeleteDepartment):
                        DeleteDepartment();
                        break;

                    default:
                        x = false;
                        Console.Write("\n\n");
                        break;
                }

                Console.WriteLine("Exited Successfully..");

            }
        }
        private static void SearchEmployee()
        {
            try
            {
                Console.WriteLine("Enter the employee Name:");
                string searchString = Console.ReadLine();

                List<EmployeeInsert> searchResults = Business.BusinessLayer.SearchEmployee(searchString);

                if (searchResults.Count > 0)
                {
                    Console.WriteLine("Search Results:");
                    foreach (var emp in searchResults)
                    {
                        Console.WriteLine($"Employee ID: {emp.EmployeeID} Name: {emp.EmployeeName} Branch ID:{emp.BranchID} Department ID:{emp.DepartmentID}");
                    }
                }
                else
                {
                    Console.WriteLine("No Employees matched.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void InsertEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID:");
                int Emp_Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Name:");
                string Emp_Name = Console.ReadLine();


                Console.Write("Enter Branch ID:");
                int branch_Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Department ID:");
                int dept_Id = Convert.ToInt32(Console.ReadLine());


                EmployeeInsert Employee = new EmployeeInsert
                {
                    EmployeeID = Emp_Id,
                    EmployeeName = Emp_Name,
                    BranchID = branch_Id,
                    DepartmentID = dept_Id
                };
                Business.BusinessLayer.InsertEmployee(Employee, fileName);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter your Employee ID:");
                int Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter your new Employee Name:");
                string EmployeeName = Console.ReadLine();


                Console.Write("Enter yur new Branch ID:");
                int BranchID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Department ID:");
                int DepartmentID = Convert.ToInt32(Console.ReadLine());

                EmployeeInsert EmployeeInput = new EmployeeInsert
                {
                    EmployeeName = EmployeeName,
                    BranchID = BranchID,
                    DepartmentID = DepartmentID
                };
                bool isUpdated = Business.BusinessLayer.UpdateEmployee(Id, EmployeeInput, fileName);
                if (isUpdated)
                {
                    Console.WriteLine("Employee updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update Employee. Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter your Employee ID:");
                int DeleteId = Convert.ToInt32(Console.ReadLine());
                bool isDeleted = Business.BusinessLayer.DeleteEmployee(DeleteId, fileName);

                if (isDeleted)
                {
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete Employee. Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void InsertBranch()
        {
            try
            {
                Console.Write("Enter Branch ID:");
                int Branch_Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Branch Name:");
                string Branch_Name = Console.ReadLine();

                Console.Write("Enter Department ID:");
                int Department_Id = Convert.ToInt32(Console.ReadLine());

                BranchInsert Bran = new BranchInsert()
                {
                    BranchID = Branch_Id,
                    BranchName = Branch_Name,
                    DepartmentID = Department_Id

                };
                bool isInserted = Business.BusinessLayer.InsertBranch(Bran, fileName);

                if (isInserted)
                {
                    Console.WriteLine("Branch added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add Branch.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void UpdateBranch()
        {
            try
            {
                Console.Write("Enter your Branch ID:");
                int BranchId = Convert.ToInt32(Console.ReadLine());



                Console.Write("Enter your new Branch Name:");
                string BranchName = Console.ReadLine();


                Console.Write("Enter your new Department ID:");
                int DepartmentId = Convert.ToInt32(Console.ReadLine());

                BranchInsert BranchInput = new BranchInsert
                {
                    BranchName = BranchName,
                    DepartmentID = DepartmentId
                };

                bool isUpdated = Business.BusinessLayer.UpdateBranch(BranchId, BranchInput, fileName);

                if (isUpdated)
                {
                    Console.WriteLine("Branch updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update Branch. Branch not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void DeleteBranch()
        {
            try
            {
                Console.Write("Enter your Branch ID:");
                int DeleteBranchId = Convert.ToInt32(Console.ReadLine());
                bool isDeleted = Business.BusinessLayer.DeleteBranch(DeleteBranchId, fileName);

                if (isDeleted)
                {
                    Console.WriteLine("Branch deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete Branch. Branch not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void InsertDepartment()
        {
            try
            {
                Console.Write("Enter Department ID:");
                int Dept_Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Department Name:");
                string Dept_Name = Console.ReadLine();


                DepartmentInsert Bran = new DepartmentInsert()
                {

                    DepartmentName = Dept_Name,
                    DepartmentID = Dept_Id

                };
                bool isInserted = Business.BusinessLayer.InsertDepartment(Bran, fileName);
                if (isInserted)
                {
                    Console.WriteLine("Department Inserted Successfully");
                }
                else
                {
                    Console.WriteLine("Department Not Inserted");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void UpdateDepartment()
        {
            try
            {
                Console.Write("Enter your Department ID:");
                int Department_ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter your new Department Name:");
                string Department_Name = Console.ReadLine();

                DepartmentInsert Input = new DepartmentInsert
                {
                    DepartmentName = Department_Name,

                };

                bool isUpdated = Business.BusinessLayer.UpdateDepartment(Department_ID, Input, fileName);
                if (isUpdated)
                {
                    Console.WriteLine("Department updated successfully.");
                }
                else
                {
                    Console.WriteLine("Department not found or update failed.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void DeleteDepartment()
        {
            try
            {
                Console.Write("Enter your Department ID:");
                int DeleteDepartmentId = Convert.ToInt32(Console.ReadLine());

                bool isDeleted = Business.BusinessLayer.DeleteDepartment(DeleteDepartmentId, fileName);

                if (isDeleted)
                {
                    Console.WriteLine("Department deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Department not found or delete failed.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }




    }
}


