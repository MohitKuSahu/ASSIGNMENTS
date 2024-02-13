using AdoNetConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    delegate void calculator(int x, int y);
    class Delegates
    {
       
        public static void add(int a, int b)
        {
            Console.Write(a + b);
        }
        public static void mul(int a,int b)
        {
            Console.Write(a * b);
        }
    }
  
}
