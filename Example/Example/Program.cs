using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {

            var current = DateTime.Now;
            Console.WriteLine("Swedish culture: '{0}'", current);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            Console.WriteLine("UI do not affect dates '{0}'", current);
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Console.WriteLine("Now it's changed: '{0}'", current);

            Console.ReadLine();
        }

    }
}
