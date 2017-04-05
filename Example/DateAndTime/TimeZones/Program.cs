using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TimeZones
{
    class Program
    {
        static void Main(string[] args)
        {
            var zone = TimeZone.CurrentTimeZone;
            Console.WriteLine("I'm in timezone '{0}'", zone.StandardName);
            Console.WriteLine("Daylight saving time is on? {0}",
                zone.IsDaylightSavingTime(DateTime.Now));

            Console.ReadLine();
        }

        public static void FormatDateWithoutChachingCulture()
        {
            var culture = new CultureInfo("en-us");

        }
    }
}
