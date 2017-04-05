using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            var amountSek = new Money(500, "sv-se");
            var amountUsd = new Money(500, "en-us");

            Console.WriteLine("Is '{0}' equal '{1}'? {2}", amountSek, amountUsd, amountSek.Equals(amountUsd));


            amountSek += 500;
            Console.WriteLine("New amount: " + amountSek);

            Console.ReadLine();
        }
    }
}
