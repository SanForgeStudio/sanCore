/*
 * Copyright 2025 sanCore, SanForge Studio
 * Created By: Sander Kerkhoff
 */

using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using System.IO;
using sanCore;

namespace sanCore.core
{
    class Command
    {
        public static void AcceptCmd()
        {
            Kernel kernel = new Kernel();
            var input = Console.ReadLine();
            CommandHistory.Add(input);
            string cmd = input.Split(" ")[0];

            switch (cmd)
            {
                case "shutdown": // Only shuts off the BIOS not Hardware.
                    Sys.Power.Shutdown();
                    break;

                case "reboot": // does not work properly
                    Sys.Power.Reboot();
                    break;

                case "hello": // works
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Hello User! Thanks for using sanCore!");
                    break;

                
                case "adminaccess": // works
                    Manager.AdminAccess();
                    break;


                case "adminlogout": // works
                    Manager.AdminLogout();
                    break;
               
                case "touch":
                    var touchPath = input.Remove(0, input.IndexOf(' ') + 1);
                    File.Create(touchPath);
                    break;

                case "clock": // works
                    sanCore.core.ClockManager.ShowClock();
                    break;


                case "clear": // works
                    Console.Clear();
                    break;

                case "echo": // works
                    var echoMsg = input.Remove(0, input.IndexOf(' ') + 1);
                    Console.WriteLine(echoMsg);
                    break;

                case "syscheck": // works
                    HardwareProfiler.RunSystemCheck();
                    break;


                case "author": // works
                    Console.WriteLine("");
                    Console.WriteLine("--------------");
                    Console.WriteLine("Made By: Sander Kerkhoff");
                    Console.WriteLine("--------------");
                    Console.WriteLine("");
                    break;

                case "help": // works
                    if (input.Contains(" "))
                    {
                        if (input.EndsWith(" "))
                        {
                            Kernel.error("no page specified. Select a page 1-3");
                        }
                        else
                        {
                            var helpPage = input.Split(" ")[1];
                            switch (helpPage)
                            {
                                case "1":
                                    Console.WriteLine("Power Commands\n--------------\nshutdown: Turns the OS and computer off.\n\nreboot: Reboots the computer.\n\nConsole Commands\n----------------\nreinit: Reinitializes the OS (pseudo-reboot).\n\nclear: Clears the console.\n\necho (message): Prints the specified message to the console.\n\ntheme (themeID): Changes the theme of the console.");
                                    break;
                                case "2":
                                    Console.WriteLine("Filesystem Commands\n-------------------\nls: Shows all subdirectories and files within current directory.\n\ncd (path): Changes current directory to specified path.\n\nrm (path): Removes specified directory or file.\n\nmkdir (path): Creates new directory in specified path.\n\ntouch (path): Creates new file in specified path.\n\ncat (path): Prints all the lines of specified file.\n\ngrep (pattern) (path): type grep -h for more information.");
                                    break;
                                case "3":
                                    Console.WriteLine("WIP filesystem commands\n-----------------------\nwrite (path) (text): Writes specified text to file.\n\nwriteline (path) (text): Creates new line and writes text.\n\nOther Commands\n--------------\nbeep (frequency): Plays a sound.");
                                    break;
                                default:
                                    Kernel.error(helpPage + " isn't a help page, select 1-3");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Kernel.error("no page specified. select 1-3");
                    }
                    break;

                case "say": // works
                    string sayMsg = input.Remove(0, input.IndexOf(' ') + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"sanCore says: \"{sayMsg}\"");
                    Console.ResetColor();
                    break;

                case "uptime": // works
                    Console.WriteLine("System uptime: " + Kernel.GetUptime());
                    break;

                case "history": // works
                    CommandHistory.Show();
                    break;

           
                default:
                    if (string.IsNullOrWhiteSpace(input))
                        break;
                    else
                        Kernel.error(cmd + " is not recognized as a command");
                    break;
            }
        }
    }
}
