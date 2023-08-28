/*
 * Copyright 2023 sanDigitals
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <https://www.gnu.org/licenses/>.
 *
 */

using System;
using Sys = Cosmos.System;
using System.IO;
using System.Collections.Generic;

namespace sanCore
{
    public class Kernel : Sys.Kernel
    {
        public ConsoleColor themecolor;

        public int currentTheme;

        public string version = "1";

        protected override void BeforeRun()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            if (!File.Exists("0:\\settings.ini"))
            {
                File.Create("0:\\settings.ini");
                using (StreamWriter writer = new StreamWriter("0:\\settings.ini"))
                {
                    currentTheme = 1;
                    writer.WriteLine("theme = " + currentTheme);
                }
            }
            string[] settings = File.ReadAllLines("0:\\settings.ini");

            string theme_settings = settings[0];
            var theme = theme_settings.Substring(theme_settings.Length - 1);
            Int32.TryParse(theme, out int x);
            currentTheme = x;

            OSinit();
        }

        protected override void Run()
        {
            inputText();
            Command.AcceptCmd();
        }

        protected void inputText()
        {
            Console.ForegroundColor = themecolor;
            Console.Write(Directory.GetCurrentDirectory() + ">");
            Console.ResetColor();
        }

        public static void error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        protected void ColorSettings(int theme)
        {
            theme = theme - 1;

            ConsoleColor[] theme_set = new ConsoleColor[4] { ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Red };


            ConsoleColor[][] all_theme_sets = new ConsoleColor[][] { theme_set };


            themecolor = all_theme_sets[theme][1];

        }

        public void OSinit()
        {
            Console.Clear();
            ColorSettings(currentTheme);
            Console.ForegroundColor = themecolor; ;
            Console.WriteLine("                                        ");
            Console.WriteLine("                :-=++==-:.              ");
            Console.WriteLine("             =%@@@@@@@@@@@@*-           ");
            Console.WriteLine("          .+@@@@@@@@@@#+:.              ");
            Console.WriteLine("         *@@@@@@@@@%=.                  ");
            Console.WriteLine("        *@@@@@@@@@@.         ::---:     ");
            Console.WriteLine("       +@@@@@@@@@@#      :*%@@@@%=      ");
            Console.WriteLine("      .@@@@@@@@@@@#    :%@@@@@@-        ");
            Console.WriteLine("      =@@@@@@@@@@@@   *@@@@@@%.         ");
            Console.WriteLine("      +@@@@@@@@@@@@*.#@@@@@@@*          ");
            Console.WriteLine("      *@@@@%##*###%@@@@@@@@@@@+         ");
            Console.WriteLine("    -#@#=:          .-+*@@@@@@@#::*%-   ");
            Console.WriteLine("    +*:  .:-=+++==-:.    .-+#@@@@@*-    ");
            Console.WriteLine("     .=#@@@@@@@@@@@@@@%#=:              ");
            Console.WriteLine("   :#@@%*=-:.. ...:-=+*#@@@@#+===*@%=   ");
            Console.WriteLine("    -*-                  .=*%@@@@@#=.   ");
            Console.WriteLine("                              ...      ");
            WaitMS(4000); // Delay
            BootMessage(); // Display booting message
            WaitMS(4000); // Delay

        }

        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        // Booting message function
        public void BootMessage()
        {
            Console.WriteLine("SanCore Booted with success...");
        }

        // PIT wait wrappers
        public static void WaitNS(int ns) { Cosmos.HAL.Global.PIT.Wait((uint)ns); }
        public static void WaitMS(int ms) { Cosmos.HAL.Global.PIT.Wait((uint)ms); }
        public static void Wait(int secs) { for (int i = 0; i < secs; i++) { WaitMS(1000); } }
    }
}
