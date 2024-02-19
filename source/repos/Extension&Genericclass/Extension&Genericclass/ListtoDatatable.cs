using System;
using System.Collections.Generic;
using System.Data; 

public class ListtoDatatable
{

    public static void List()
    {

        List<Person> person = new List<Person>
        {
            new Person { ID = 1, Name = "John", Email = "Mohanty@dotnettutorials.net" },
            new Person { ID = 2, Name = "Jane", Email = "Moh@dotnettutorials.net" }
        };

        Console.WriteLine("Printing Details as List:");
        foreach (var item in person)
        {
            Console.WriteLine(item.ID + "," + item.Name + "," + item.Email);
        }


        Console.WriteLine("Printing Details as DataTable:");
        DataTable dataTable = ToDataTable(person);
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"]);
        }

    }


    public static DataTable ToDataTable<T>(List<T> list)
    {
        DataTable dataTable = new DataTable();


        if (list.Count == 0)
            return dataTable;


        var properties = typeof(T).GetProperties();


        foreach (var property in properties)
        {
            dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
        }


        foreach (var item in list)
        {
            DataRow row = dataTable.NewRow();

            foreach (var property in properties)
            {
                row[property.Name] = property.GetValue(item) ?? DBNull.Value;
            }

            dataTable.Rows.Add(row);
        }

        return dataTable;
    }


}

class Person
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
