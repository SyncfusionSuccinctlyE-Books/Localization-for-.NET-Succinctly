using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = 1000000.50;
            var value = d.ToString(CultureInfo.InvariantCulture);

            var se = new CultureInfo("sv-se");
            var us = new CultureInfo("en-us");
            var number = 1000000.5;

            //Console.WriteLine("SE: {0}", number.ToString("N", se));
            //Console.WriteLine("US: {0}", number.ToString("N", us));


            Console.WriteLine("SE: {0}", number.ToString(@"#,#.0", se));
            Console.WriteLine("US: {0}", number.ToString(@"#,#.0", us));

            Console.ReadLine();
        }
    }
}
