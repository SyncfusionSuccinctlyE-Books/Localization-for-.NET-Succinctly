using System;
using System.Collections.Generic;

namespace Weeks
{
using System.Globalization;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        SecondExample();


        Console.ReadLine();
    }

    private static void SecondExample()
    {
        var theDate = new DateTime(2013, 12, 31);

        var calendar = CultureInfo.CurrentCulture.Calendar;
        var week = calendar.GetWeekOfYear(theDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        Console.WriteLine("ISO week: " + week);
    }

    private static void FirstExample()
    {
        var theDate = new DateTime(2012, 1, 1);

        Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE");
        var calendar = CultureInfo.CurrentCulture.Calendar;
        var formatRules = CultureInfo.CurrentCulture.DateTimeFormat;
        var week = calendar.GetWeekOfYear(theDate, formatRules.CalendarWeekRule, formatRules.FirstDayOfWeek);
        Console.WriteLine("SE week: " + week);


        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        calendar = CultureInfo.CurrentCulture.Calendar;
        formatRules = CultureInfo.CurrentCulture.DateTimeFormat;
        week = calendar.GetWeekOfYear(theDate, formatRules.CalendarWeekRule, formatRules.FirstDayOfWeek);
        Console.WriteLine("US week: " + week);
    }
}
}
