using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
     class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter("D://mindfire1.txt");
       
            Console.WriteLine("Enter the Text that you want to write on File");
           
            string inputData = Console.ReadLine();
      
            streamWriter.Write(inputData);
            Console.WriteLine("Data Has Been Written to the File");
            
            streamWriter.Flush();
           
            streamWriter.Close();
            Console.ReadKey();

         }
    }
}
