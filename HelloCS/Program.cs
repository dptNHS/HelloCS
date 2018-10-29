using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = null;
            while (true)
            {
                Console.WriteLine("Hello, what is your name?");
                userName = Console.ReadLine();
                if (!string.IsNullOrEmpty(userName))
                {
                    break;
                }
            }
            var greeting = "Good Morning";
            if(DateTime.Now.Hour >= 12)
            {
                greeting = "Good Afternoon";
            }
            Console.WriteLine(
                string.Format("{0} {1}", greeting, userName));

            Console.ReadLine();
        }
    }
}
