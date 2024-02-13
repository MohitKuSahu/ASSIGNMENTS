using ConsoleApp1;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;
namespace AdoNetConsoleApplication
{
    
    class Program
    {
      
       public static void Main(string[] args)
        {
            // new Program().CreateTable();
            //Datatables.data();
            Listclass.list();
        }
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=student; integrated security=SSPI");

                // Opening Connection  
                con.Open();

                // writing sql query  
                string sqlQuery = "Insert into student values('103', 'Ronaldo ', 'ronald@example.com', '1/12/2017')";
                //Establishing connection
                SqlCommand cm1 = new SqlCommand(sqlQuery, con);
                cm1.ExecuteNonQuery();


                cm1.CommandText = "update student set name='Messi' where id=101";
                cm1.ExecuteNonQuery();

                cm1.CommandText = "select *from student";
                cm1.ExecuteNonQuery();

               SqlDataReader reader= cm1.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " + reader["name"]+" " + reader["email"]+" " + reader["join_date"]);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
           
            finally
            {
                con.Close();
            }
        }
    }
}  
