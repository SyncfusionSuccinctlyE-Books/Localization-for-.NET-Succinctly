using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List_timezones
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                Console.WriteLine(timeZone.DisplayName);
            }

            Console.ReadLine();
        }
    }
}
