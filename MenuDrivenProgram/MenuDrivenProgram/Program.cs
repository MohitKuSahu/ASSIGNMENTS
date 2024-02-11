using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDrivenProgram
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int num1, num2, opt;

            Console.Write("\n\n");  
            Console.Write("A menu driven program for a simple calculator:\n");  
            Console.Write("------------------------------------------------");  
            Console.Write("\n\n");

            Console.Write("Enter the first Integer :");  
            num1 = Convert.ToInt32(Console.ReadLine());  
            Console.Write("Enter the second Integer :");  
            num2 = Convert.ToInt32(Console.ReadLine());  

            Console.Write("\nHere are the options :\n");  
            Console.Write("1-Addition.\n2-Subtraction.\n3-Multiplication.\n4-Division.\n5-Exit.\n");
            Console.Write("\nInput your choice :");  
            opt = Convert.ToInt32(Console.ReadLine());  

            switch (opt)  
            {
                case 1:  
                    Console.Write($"The addition of {num1} and {num2} is {num1+num2}\n");
                    break;
                case 2:
                    Console.Write($"The subtraction of {num1} and {num2} is {num1 - num2}\n");
                    break;
                case 3:
                    Console.Write($"The multiplication of {num1} and {num2} is {num1 * num2}\n");
                    break;
                case 4:  
                    if (num2 == 0)  
                    {
                        Console.Write("The second integer is zero. Divide by zero.\n");
                    }
                    else
                    {
                        Console.Write($"The division of {num1} and {num2} is {num1 / num2}\n");
                    }
                    break;
                case 5:  
                    break;
                default:  
                    Console.Write("Input correct option\n");
                    break;
            }
        }
    }

 }

