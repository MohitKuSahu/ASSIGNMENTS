using System;
using System.Threading;
using System.Threading.Tasks;

namespace C_sharp_Practice_Codes
{
    class Mutex
    {
        public static void Print()
        {
            using (System.Threading.Mutex mute = new System.Threading.Mutex(false, "MutexDemo"))
            {
                //Checking if Other External Thread is Running
                if (!mute.WaitOne(5000, false))
                {
                    Console.WriteLine("An Instance of the Application is Already Running");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Application Is Running.......");
                Console.ReadKey();
            }
        }
    }

  

}