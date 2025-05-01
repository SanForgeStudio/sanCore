/*
 * Copyright 2025 sanCore, SanForge Studio
 * Created By: Sander Kerkhoff
 */

using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using System.IO;
using sanCore;
using sanCore.commands;

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

            // If writing, allow 'note stop' and 'note read', otherwise treat as note content
            if (NoteManager.IsWriting())
            {
                if (input.StartsWith("note stop") || input.StartsWith("note read"))
                {
                    // Fall through to switch-case to handle these commands
                }
                else
                {
                    NoteManager.WriteLine(input);
                    return;
                }
            }

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
                    ClockManager.ShowClock();
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

                case "cd": // works but needs way to exit cd mode
                    if (input.Contains(" "))
                    {
                        if (!input.EndsWith(" "))
                        {
                            var targetDir = input.Split(" ")[1];
                            cd.changedir(targetDir);
                        }
                        else
                        {
                            Kernel.error("No path in argument. Usage: cd 'path'");
                        }
                    }
                    else
                    {
                        Directory.SetCurrentDirectory("0:\\");
                    }
                    break;


                case "author": // works
                    Console.WriteLine("");
                    Console.WriteLine("--------------");
                    Console.WriteLine("Made By: Sander Kerkhoff");
                    Console.WriteLine("--------------");
                    Console.WriteLine("");
                    break;

                case "help":
                    Console.WriteLine("Available Commands:");
                    Console.WriteLine("-------------------");
                    Console.WriteLine("shutdown       - Turns off the computer.");
                    Console.WriteLine("reboot         - Restarts the computer.");
                    Console.WriteLine("hello          - Greets the user.");
                    Console.WriteLine("adminaccess    - Enables admin mode.");
                    Console.WriteLine("adminlogout    - Disables admin mode.");
                    Console.WriteLine("touch (path)   - Creates a file at specified path.");
                    Console.WriteLine("clock          - Displays current system clock.");
                    Console.WriteLine("clear          - Clears the console.");
                    Console.WriteLine("echo (text)    - Prints the text to the console.");
                    Console.WriteLine("syscheck       - Runs system diagnostics.");
                    Console.WriteLine("author         - Shows the author information.");
                    Console.WriteLine("say (text)     - Makes the OS say something.");
                    Console.WriteLine("uptime         - Shows system uptime.");
                    Console.WriteLine("history        - Displays previously entered commands.");
                    Console.WriteLine("cd             - Changes current directory to specified path.");
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
