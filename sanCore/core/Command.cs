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
using System.Net;
using System.Collections.Generic;
using Sys = Cosmos.System;
using System.IO;
using System.Net.NetworkInformation;

namespace sanCore
{
    class Command
    {

    private static ConsoleColor themecolor;


    public static void AcceptCmd()
        {
            bool isAdminLoggedIn = false;
            string adminUsername = "admin";
            string adminPassword = "123";


            Kernel kernel = new Kernel();

            while (true)
            {



                var input = Console.ReadLine();
                string cmd = input.Split(" ")[0];
                switch (cmd)
                {
                    case "shutdown":
                        Sys.Power.Shutdown();
                        break;
                    case "reboot":
                        Sys.Power.Reboot();
                        break;



                    case "ls":
                        string[] dirDirectories = Directory.GetDirectories(Directory.GetCurrentDirectory());
                        foreach (var dir in dirDirectories)
                        {
                            Console.WriteLine(dir + " | Directory");
                        }
                        string[] dirFiles = Directory.GetFiles(Directory.GetCurrentDirectory());
                        foreach (var file in dirFiles)
                        {
                            Console.WriteLine(file + " | File");
                        }
                        break;

                    case "cd":
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

                    case "beep":
                        var targetFreqRaw = input.Remove(0, input.IndexOf(' ') + 1);
                        int targetFreq = int.Parse(targetFreqRaw);
                        if (targetFreq < 37 || targetFreq > 32767)
                        {
                            Kernel.error("Frequency cant be less than 37hz or larger than 32767hz");
                        }
                        else
                        {
                            Console.Beep(targetFreq, 1000);
                        }
                        break;

                    case "cat":
                        var targetCat = input.Remove(0, input.IndexOf(' ') + 1);
                        if (!File.Exists(targetCat))
                        {
                            Console.WriteLine("Could not find file");
                            break;
                        }
                        string[] lines = File.ReadAllLines(targetCat);

                        foreach (string line in lines)
                        {
                            Console.WriteLine(line);
                        }
                        break;

                    case "grep":
                        List<string> flags = new List<string>();
                        foreach (string x in input.Split(" "))
                        {
                            flags.Add(x);
                        }
                        if (flags.Count > 1)
                            if (flags[1] == "-h")
                            {
                                Console.WriteLine("sanCore implementation of grep\nUsage: grep PATTERN FILENAME\n\nOptional switches:\n    -c Count each PATTERN instance\n    -w force PATTERN to match only whole words");
                                break;
                            }

                        if (flags.Count < 3)
                        {
                            Console.WriteLine("Too few arguments, excpected at least 2");
                            break;
                        }
                        Grep gp = new Grep();
                        gp.grep(flags[2], flags[1], flags);
                        break;

                    case "mkdir":
                        if (input.Contains(" "))
                        {
                            if (input.EndsWith(" "))
                            {
                                Kernel.error("no path specified");
                            }
                            else
                            {
                                var mkdirPath = input.Split(" ")[1];
                                FScreate.makeDir(mkdirPath);
                            }
                        }
                        else
                        {
                            Kernel.error("no path specified");
                        }
                        var dirPath = input.Remove(0, input.IndexOf(' ') + 1);
                        Directory.CreateDirectory(dirPath);
                        break;

                    case "touch":
                        var touchPath = input.Remove(0, input.IndexOf(' ') + 1);
                        File.Create(touchPath);
                        break;

                    case "write":
                        var writePath = input.Split(" ")[1];
                        var writeText = input.Split(" ")[2];
                        if (File.Exists(writePath))
                        {
                            File.AppendAllText(writePath, writeText);
                        }
                        break;

                    case "writeline":
                        var writelinePath = input.Split(" ")[1];
                        var writelineText = input.Split(" ")[2];
                        if (File.Exists(writelinePath))
                        {
                            File.AppendAllText(writelinePath, Environment.NewLine + writelineText);
                        }
                        break;

                    case "rm":
                        if (input.Contains(" "))
                        {
                            if (input.EndsWith(" "))
                            {
                                Kernel.error("no path specified");
                            }
                            else
                            {
                                var rmPath = input.Split(" ")[1];
                                rm.remove(rmPath);
                            }
                        }
                        else
                        {
                            Kernel.error("no path specified");
                        }
                        break;

                    case "clear":
                        Console.Clear();
                        break;

                    case "hello":
                        Console.WriteLine("Hello User! Thanks for using sanCore!");
                        break;


                    case "reinit":
                        kernel.OSinit();
                        break;

                    case "echo":
                        var echoMsg = input.Remove(0, input.IndexOf(' ') + 1);
                        Console.WriteLine(echoMsg);
                        break;

                    case "adminaccess":
                        if (isAdminLoggedIn)
                        {
                            Console.WriteLine("Admin access granted. Welcome back, You can now perform admin functions.");
                        }
                        else
                        {
                            Console.Write("Enter admin username: ");
                            string enteredAdminUsername = Console.ReadLine();
                            Console.Write("Enter admin password: ");
                            string enteredAdminPassword = Console.ReadLine();

                            if (enteredAdminUsername == adminUsername && enteredAdminPassword == adminPassword)
                            {
                                isAdminLoggedIn = true;
                                Console.WriteLine("Admin login successfull. You can now perform admin functions.");
                            }
                            else
                            {
                                Kernel.error("Incorrect admin username or password. Access denied.");
                            }
                        }
                        break;


                    case "info":

                        Console.WriteLine("sanCore Operating System");
                        Console.WriteLine("Version: " + kernel.version);
                        Console.WriteLine("Created by: SanDigitals");

                        long totalRAM = Cosmos.Core.CPU.GetAmountOfRAM();
                        Console.WriteLine("System RAM: " + totalRAM + " bytes (" + (totalRAM / (1024 * 1024)) + " MB)");

                        string rootDrive = "0";
                        long totalSize = Sys.FileSystem.VFS.VFSManager.GetTotalSize(rootDrive);
                        long freeSpace = Sys.FileSystem.VFS.VFSManager.GetTotalFreeSpace(rootDrive);

                        Console.WriteLine("Root Drive Size: " + totalSize + " bytes (" + (totalSize / (1024 * 1024)) + " MB)");
                        Console.WriteLine("Root Drive Free Space: " + freeSpace + " bytes (" + (freeSpace / (1024 * 1024)) + " MB)");
                        break;


                    case "AI":
                        ActivateAI();
                        break;

                        case "ai":
                        ActivateAI();
                        break;


                    case "help":
                        if (input.Contains(" "))
                        {
                            if (input.EndsWith(" "))
                            {
                                Kernel.error("no page specified. select a page 1-3");
                            }
                            else
                            {
                                var helpPage = input.Split(" ")[1];
                                switch (helpPage)
                                {
                                    case "1":
                                        Console.WriteLine("Power Commands\n--------------\nshutdown: Turns the OS and computer off.\n\nreboot: Reboots the computer.\n\nConsole Commands\n----------------\nreinit: Reinitializes the OS (pseudo-reboot).\n\nclear: Clears the console.\n\necho (message): Prints the specified message to the console.");
                                        break;

                                    case "2":
                                        Console.WriteLine("Filesystem Commands\n-------------------\nls: Shows all subdirectories and files within current directory.\n\ncd (path): Changes current directory to specified path.\n\nrm (path): Removes specified directory or file.\n\nmkdir (path): Creates new directory in specified path.\n\ntouch (path): Creates new file in specified path.\n\ncat (path): Prints all the lines of specified file.\n\ngrep (pattern) (path): type grep -h for more information.");
                                        break;

                                    case "3":
                                        Console.WriteLine("WIP filesystem commands\n-----------------------\nwrite (path) (text): Writes to specified text to specified file.\n\nwriteline (path) (text): Creates new line and writes specified text to a file.\n\nOther Commands\n--------------\nbeep (frequency): Plays a sound with the specified frequency.");
                                        break;

                                    default:
                                        Kernel.error(helpPage + " isnt a help page, select a page 1-3");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Kernel.error("no page specified. select a page 1-3");
                        }
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

        private static void ActivateAI()
        {
            AI.AI ai = new AI.AI();
            Console.WriteLine("AI activated. You can ask me questions. Type 'exit' to exit.");
            TalkToAI(ai);
            Console.WriteLine("AI deactivated.");
        }

        private static void TalkToAI(AI.AI ai)
        {
            string question;
            do
            {
                Console.Write("You: ");
                question = Console.ReadLine();
                if (question.ToLower() != "exit")
                {
                    string answer = ai.AnswerQuestion(question);
                    Console.WriteLine("AI System: " + answer);
                }
            } while (question.ToLower() != "exit");
        }
    }
}
