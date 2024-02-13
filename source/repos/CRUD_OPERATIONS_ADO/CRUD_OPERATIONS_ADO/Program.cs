using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUD_OPERATIONS_ADO
{
    internal class Program
    {

        static void Main(string[] args)
        {
            SqlConnection Con = null;
            Con = new SqlConnection("data source=.; database=student; integrated security=SSPI");


            Console.Write("\n\n");
            Console.Write("A simple CRUD operation program using ADO.NET methods:\n");
            Console.Write("------------------------------------------------");
            Console.Write("\n\n");

            Boolean x = true;
            while (x)
            {
                Console.Write("\nHere are the options :\n");
                Console.Write("1-Insert.\n2-Read.\n3-Update.\n4-Delete.\n5-Exit.\n");
                Console.Write("\nInput your choice :");
                int N = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                switch (N)
                {
                    case 1:
                        Insert(Con);
                        break;
                    case 2:
                        Read(Con);
                        break;
                    case 3:
                        Update(Con);
                        break;
                    case 4:
                        Delete(Con);
                        break;
                    case 5:
                        x = false;
                        break;
                    default:
                        Console.Write("Please input correct option\n");
                        break;
                }
            }

            Console.WriteLine("\nExited Successfully");
        }
        static void Insert(SqlConnection Con) {
            Console.WriteLine("Enter your id:");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");

            Console.WriteLine("Enter your name:");
            string Name = Console.ReadLine();
            Console.Write("\n");

            Console.WriteLine("Enter your email:");
            string Email = Console.ReadLine();
            Console.Write("\n");


            String SqlQuery = $"Select * from student where id={Id}";
            SqlCommand Cmd = new SqlCommand(SqlQuery, Con);
            Con.Open();

            SqlDataReader Sdr=Cmd.ExecuteReader();
           
            if (Sdr.Read())
            {
                Console.WriteLine($"Id ={Id} already exists.\n Try with another Id");
            }


            else
            {
                Con.Close(); // Closing the DataReader connection or else it will show error..
                Con.Open();// Reopening the connection
                Cmd.CommandText = $"Insert into student VALUES({Id},'{Name}','{Email}')";
                int Rows=Cmd.ExecuteNonQuery();
                Con.Close();

                if (Rows > 0)
                {
                    Console.WriteLine($"{Rows} Row(s) Inserted Successfully!");
                }
                else
                {
                    Console.WriteLine($"Failed to Insert");
                }
            }
 
        }

        static void Read(SqlConnection Con)
        {
            Console.Write("\n");
            string SqlQuery = $"Select * from  student";
            SqlCommand Cmd = new SqlCommand(SqlQuery, Con);

            Con.Open();
            SqlDataReader Sdr = Cmd.ExecuteReader();

            
            while (Sdr.Read())
            {
                Console.WriteLine(Sdr["id"] + " " + Sdr["name"] + " " + Sdr["email"]);
            }

            Con.Close();
          
        }
        static void Update(SqlConnection Con)
        {

            Console.WriteLine("Enter your id:");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");

            Console.WriteLine("Enter your new name:");
            string Name = Console.ReadLine();
            Console.Write("\n");

            Console.WriteLine("Enter your new email:");
            string Email = Console.ReadLine();
            Console.Write("\n");

            string SqlQuery = $"update student set name='{Name}',email='{Email}' where id={Id}";
            SqlCommand Cmd = new SqlCommand(SqlQuery, Con);


            Con.Open();
            int Rows = Cmd.ExecuteNonQuery();
            Con.Close();
            if (Rows > 0)
            {
                Console.WriteLine($"{Rows} Row(s) Updated Successfully!");
            }
            else
            {
                Console.WriteLine($"Failed to Update \n there is no such id with value {Id}");
            }

        
        }

        static void Delete(SqlConnection Con) {


            Console.WriteLine("Enter your id:");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");

            string SqlQuery = $"delete from student where id={Id}";
            SqlCommand Cmd = new SqlCommand(SqlQuery, Con);

            Con.Open();
            int Rows = Cmd.ExecuteNonQuery();
            Con.Close();
            if (Rows > 0)
            {
                Console.WriteLine($"{Rows} Row(s) deleted Successfully!");
            }
            else
            {
                Console.WriteLine($"Failed to Delete \n there is no such id with value {Id}");
            }

            
        }
      

    }

 }


    

