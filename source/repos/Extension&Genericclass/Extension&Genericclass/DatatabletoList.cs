
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
namespace AdoNetConsoleApplication
{
    class DatatabletoList
    {
        public static void Data()
        {
            try
            {
               
                DataTable dataTable = new DataTable("Student");

             
                DataColumn ID = new DataColumn("ID");
                ID.DataType = typeof(int);
                ID.Unique = true;
                ID.AllowDBNull = false;
                dataTable.Columns.Add(ID);

                
                DataColumn Name = new DataColumn("Name");
                Name.MaxLength = 50;
                Name.AllowDBNull = false;
                dataTable.Columns.Add(Name);

                DataColumn Email = new DataColumn("Email");
                dataTable.Columns.Add(Email);

                
                dataTable.PrimaryKey = new DataColumn[] { ID };

               
                DataRow row1 = dataTable.NewRow();
                row1["Id"] = 101;
                row1["Name"] = "Anurag";
                row1["Email"] = "Anurag@dotnettutorials.net";
                dataTable.Rows.Add(row1);


                dataTable.Rows.Add(102, "Mohanty", "Mohanty@dotnettutorials.net");
                dataTable.Rows.Add(103, "Moh", "Moh@dotnettutorials.net");


                Console.WriteLine("Printing Details as DataTable:");
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"]);
                }



                Console.WriteLine("Printing Details as List:");
                List<Person> person = ConvertDataTable<Person>(dataTable);

                foreach (var item in person)
                {
                    Console.WriteLine(item.ID + "," + item.Name + "," + item.Email);
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
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
