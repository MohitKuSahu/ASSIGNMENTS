using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Practice_Codes
{
    class GenericCollections
    {

        public static void Sorted()
        {
            SortedList<int, string> sortedList = new SortedList<int, string>();
            sortedList.Add(1, "One");
            sortedList.Add(5, "Five");
            sortedList.Add(2, "Two");
            sortedList.Add(4, "Four");
            sortedList.Add(3, "Three");

            Console.WriteLine("SortedList Elements: ");
            foreach (KeyValuePair<int, string> kvp in sortedList)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            Console.ReadKey();
        }

    }
} 
