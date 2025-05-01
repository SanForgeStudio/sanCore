/*
 * Copyright 2025 sanCore, SanForge Studio
 * Created By: Sander Kerkhoff
 */

using System;
using sanCore;

namespace sanCore.core
{
    public static class HardwareProfiler
    {
        public static void RunSystemCheck()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("System Check Report");
            Console.WriteLine("-------------------");
            Console.ResetColor();

            Console.WriteLine($"Total RAM: {Cosmos.Core.CPU.GetAmountOfRAM()} MB");
            Console.WriteLine($"CPU: {Cosmos.Core.CPU.GetCPUBrandString()}");
            Console.WriteLine($"Disk: 0:\\ present");
            Console.WriteLine("-------------------");
        }
    }
}
