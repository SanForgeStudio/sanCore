/*
 * Copyright 2025 sanCore, SanForge Studio
 * Created By: Sander Kerkhoff
 */

using System;
using Cosmos.HAL;

namespace sanCore.commands
{
    public static class ClockManager
    {
        public static void ShowClock()
        {

            string time = $"{RTC.Hour:D2}:{RTC.Minute:D2}:{RTC.Second:D2}";
            string date = $"{RTC.DayOfTheMonth:D2}-{RTC.Month:D2}-{RTC.Year:D4}";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("System Clock");
            Console.ResetColor();
            Console.WriteLine("-------------------");
            Console.WriteLine($"Time: {time}");
            Console.WriteLine($"Date: {date}");
            Console.WriteLine("-------------------");
        }
    }
}
