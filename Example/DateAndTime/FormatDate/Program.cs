using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace FormatDate
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentTime = DateTime.Now;
            DateFormats();
            Console.Write("Press enter");
            Console.ReadLine();
            Console.Clear();

            var swedish = new CultureInfo("sv-se");
            Console.WriteLine("Swedish: {0}", currentTime.ToString(swedish));

            var us = new CultureInfo("en-us");
            Console.WriteLine("US: {0}", currentTime.ToString(us));

            var china = new CultureInfo("zh-CN");
            Console.WriteLine("China: {0}", currentTime.ToString(china));

            Console.ReadLine();
        }

        public static void DateFormats()
        {
            var currentTime = DateTime.Now;
            Console.WriteLine("Full formats");
            Console.WriteLine(currentTime.ToString());
            Console.WriteLine(currentTime.ToString("R"));
            Console.WriteLine();
            Console.WriteLine("Time");
            Console.WriteLine(currentTime.ToShortTimeString());
            Console.WriteLine(currentTime.ToLongTimeString());

            Console.WriteLine();
            Console.WriteLine("Date");
            Console.WriteLine(currentTime.ToShortDateString());
            Console.WriteLine(currentTime.ToLongDateString());
            Console.WriteLine();

        }
    }
}
