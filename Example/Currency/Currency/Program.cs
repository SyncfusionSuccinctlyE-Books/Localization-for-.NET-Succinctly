using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Currency
{

    class Program
    {
        // ReSharper disable ConvertToConstant.Local

        static void Main(string[] args)
        {
decimal shoppingCartTotal = 100;

var us = new RegionInfo("en-US");
Console.WriteLine("Is it {1}{0} ..", shoppingCartTotal, us.CurrencySymbol);

var sv = new RegionInfo("sv-SE");
Console.WriteLine(".. or {0} {1}", shoppingCartTotal, sv.CurrencySymbol);

            Console.ReadLine();

        }
    }
}
