using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
namespace AdoNetConsoleApplication
{
    class Datatables
    {
        public static void data()
        {
            try
            {
                //Creating data table instance
                DataTable dataTable = new DataTable("Student");

                //Add the DataColumn using all properties
                DataColumn ID = new DataColumn("ID");
                ID.DataType = typeof(int);
                ID.Unique = true;
                ID.AllowDBNull = false;
                dataTable.Columns.Add(ID);

                //Add the DataColumn few properties
                DataColumn Name = new DataColumn("Name");
                Name.MaxLength = 50;
                Name.AllowDBNull = false;
                dataTable.Columns.Add(Name);

                //Add the DataColumn using defaults
                DataColumn Email = new DataColumn("Email");
                dataTable.Columns.Add(Email);

                //Setting the Primary Key
                dataTable.PrimaryKey = new DataColumn[] { ID };

                //Add New DataRow by creating the DataRow object
                DataRow row1 = dataTable.NewRow();
                row1["Id"] = 101;
                row1["Name"] = "Anurag";
                row1["Email"] = "Anurag@dotnettutorials.net";
                dataTable.Rows.Add(row1);

                //Adding new DataRow by simply adding the values
                dataTable.Rows.Add(102, "Mohanty", "Mohanty@dotnettutorials.net");
                dataTable.Rows.Add(103, "Moh", "Moh@dotnettutorials.net");

                List<Person> person = ConvertDataTable<Person>(dataTable);
  
                    foreach (var item in person)
                    {
                        Console.WriteLine(item.ID+","+item.Name+","+item.Email);
                    }
                

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

            Console.ReadKey();
        }


        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow dr)
        {
           Type temp = typeof(T);
           T obj = Activator.CreateInstance<T>();
           foreach (DataColumn column in dr.Table.Columns)
            {
              foreach (PropertyInfo pro in temp.GetProperties())
              {
                 if (pro.Name == column.ColumnName)
                   pro.SetValue(obj, dr[column.ColumnName], null);
                else
                  continue;
              }
            }
          return obj;
        }





      

    }
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set;}
        public string Email { get; set;}
     }
}
