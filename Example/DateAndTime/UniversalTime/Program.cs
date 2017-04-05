using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniversalTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentTime = DateTime.Now;
            Console.WriteLine("Local time: '{0}'", currentTime);

            var universal = currentTime.ToUniversalTime();
            Console.WriteLine("Universal time '{0}'", universal);

            var localAgain = universal.ToLocalTime();
            Console.WriteLine("Local time '{0}'", localAgain);

            Console.ReadLine();
        }
    }
}
