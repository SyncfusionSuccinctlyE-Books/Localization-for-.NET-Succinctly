using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace StandardMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            var date = DateTime.Now;

            Console.WriteLine("'{0}' (String)", date.ToString());
            Console.WriteLine();

            Console.WriteLine("'{0}' (Long time)", date.ToLongTimeString());
            Console.WriteLine("'{0}' (Short time)", date.ToShortTimeString());
            Console.WriteLine();

            Console.WriteLine("'{0}' (Long date)", date.ToLongDateString());
            Console.WriteLine("'{0}' (Short date)", date.ToShortDateString());

            Console.ReadLine();
        }


    }
}
