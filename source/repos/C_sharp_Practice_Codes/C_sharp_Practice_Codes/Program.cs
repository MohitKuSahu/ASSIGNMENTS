using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_sharp_Practice_Codes
{
    internal class Program
    {

        public async static void SomeMethod()  //async method
        {
            Console.WriteLine("Some Method Started......");
            //Thread.Sleep(TimeSpan.FromSeconds(10));
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("\n");
            Console.WriteLine("Some Method End");
        }

        public delegate string greeto(string name);
        static void Main(string[] args)
        {

            Console.WriteLine("Main Method Started......");
            SomeMethod();
            Console.WriteLine("Main Method End");
            Console.ReadKey();




            Class1.Linq();

            greeto obj= (name)=>
            {
                return "Hello @" + name + " welcome to Dotnet Tutorials";
            };

            string msg = obj.Invoke("BOOM");
            Console.WriteLine(msg);

            Mutex.Print();
            GenericCollections.Sorted();

        }
        
    }
} 
