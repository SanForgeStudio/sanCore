/*
 * Copyright 2025 sanCore, SanForge Studio
 * Created By: Sander Kerkhoff
 */

using System;
using Sys = Cosmos.System;
using Cosmos.HAL;
using Cosmos.System.Graphics;
using System.IO;

namespace sanCore
{
    public class Kernel : Sys.Kernel
    {
        public string version = "2";
        private static DateTime bootTime = DateTime.Now;

        public static string GetUptime()
        {
            TimeSpan uptime = DateTime.Now - bootTime;
            return $"{(int)uptime.TotalMinutes} min {uptime.Seconds} sec";
        }

        protected override void BeforeRun()
        {
            VGAScreen.SetTextMode(Cosmos.HAL.Drivers.Video.VGADriver.TextSize.Size80x25);
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
 
            Console.ForegroundColor = ConsoleColor.Red;
            DrawSplash();
            WaitMS(300);
            Console.WriteLine("Initializing sanCore OS components...");
            WaitMS(400);
            Console.WriteLine("Preparing kernel environment...");
            WaitMS(300);
            BootMessage();
            WaitMS(300);
            Console.WriteLine("Starting...");
            WaitMS(2000);
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Directory.GetCurrentDirectory() + "> ");
            Console.ResetColor();
            core.Command.AcceptCmd();
        }

        private void DrawSplash()
        {
            string[] logo = new string[]
            {
                "                                        ",
                "                :-=++==-:.              ",
                "             =%@@@@@@@@@@@@*-           ",
                "          .+@@@@@@@@@@#+:.              ",
                "         *@@@@@@@@@%=.                  ",
                "        *@@@@@@@@@@.         ::---:     ",
                "       +@@@@@@@@@@#      :*%@@@@%=      ",
                "      .@@@@@@@@@@@#    :%@@@@@@-        ",
                "      =@@@@@@@@@@@@   *@@@@@@%.         ",
                "      +@@@@@@@@@@@@*.#@@@@@@@*          ",
                "      *@@@@%##*###%@@@@@@@@@@@+         ",
                "    -#@#=:          .-+*@@@@@@@#::*%-   ",
                "    +*:  .:-=+++==-:.    .-+#@@@@@*-    ",
                "     .=#@@@@@@@@@@@@@@%#=:              ",
                "   :#@@%*=-:.. ...:-=+*#@@@@#+===*@%=   ",
                "    -*-                  .=*%@@@@@#=.   ",
                "                              ...      ",
                "Created By: Sander Kerkhoff",
                ""
            };

            foreach (string line in logo)
            {
                Console.WriteLine(line);
            }
        }

        public void BootMessage()
        {
            Console.WriteLine("sanCore loaded with success...");
        }

        public static void error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void WaitMS(int ms) => Cosmos.HAL.Global.PIT.Wait((uint)ms);
        public static void Wait(int secs)
        {
            for (int i = 0; i < secs; i++) WaitMS(1000);
        }
    }
}
