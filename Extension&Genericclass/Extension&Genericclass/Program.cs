using AdoNetConsoleApplication;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Genericclass
{
     class Program
    {
        static void Main(string[] args)
        {

            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
                con.Open();
                ListtoDatatable.List();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                DatatabletoList.Data();
            } catch (Exception e)
            {
                Console.WriteLine("OOPS! Error ");
            }
            finally
            {
                con.Close();
            }
        }
       
}
}
