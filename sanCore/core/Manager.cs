/*
 * Copyright 2025 sanCore, SanForge Studio
 * Created By: Sander Kerkhoff
 */

using System;
using System.IO;
using sanCore;


namespace sanCore
{
    public class Manager
    {
        // Admin variables
        private static bool isAdminLoggedIn = false;
        private static string adminUsername = "admin";
        private static string adminPassword = "123";

        public static void AdminAccess()
        {
            if (isAdminLoggedIn)
            {
                // Admin already logged in
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter admin username: ");
            Console.ResetColor();
            string enteredAdminUsername = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter admin password: ");
            Console.ResetColor();
            string enteredAdminPassword = Console.ReadLine();

            if (enteredAdminUsername == adminUsername && enteredAdminPassword == adminPassword)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                isAdminLoggedIn = true;
                Console.WriteLine("Admin Access Granted");
                Console.ResetColor();
            }
            else
            {
                Kernel.error("Admin Access Denied.");
            }
        }

        public static void AdminLogout()
        {
            if (isAdminLoggedIn)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                isAdminLoggedIn = false;
                Console.WriteLine("Admin logged out.");
                Console.ResetColor();
            }
            else
            {
                Kernel.error("No admin currently logged in.");
            }
        }

        public static bool IsAdminLoggedIn()
        {
            return isAdminLoggedIn;
        }
    }
}
