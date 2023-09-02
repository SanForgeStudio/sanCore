using System;
using System.IO;

namespace sanCore
{
    public class Manager
    {
        // Admin variables
        private static bool isAdminLoggedIn = false;
        private static string adminUsername = "admin";
        private static string adminPassword = "123";

        // User variables
        private static bool isUserLoggedIn = false;
        private static string userUsername = "";
        private static string enteredUserUsername = ""; // Declare it at the class level
        private static string userFilename = "user.txt";



        public static void AdminAccess()
        {
            if (isAdminLoggedIn)
            {
                // Perform admin functions
            }
            else
            {
                Console.Write("Enter admin username: ");
                string enteredAdminUsername = Console.ReadLine();
                Console.Write("Enter admin password: ");
                string enteredAdminPassword = Console.ReadLine();

                if (enteredAdminUsername == adminUsername && enteredAdminPassword == adminPassword)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    isAdminLoggedIn = true;
                    Console.WriteLine("Admin login successful. You can now perform admin functions.");
                    Console.ResetColor();
                }
                else
                {
                    Kernel.error("Incorrect admin username or password. Access denied.");
                }
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

        /// 
        /// Admin systems and logic END here
        ///








        /// 
        /// User systems and logic BEGIN here
        ///



        public static void DisplayUserInfo2()
        {
            if (isUserLoggedIn)
            {
                // Display user info using enteredUserUsername
                Console.WriteLine($"Current User: {enteredUserUsername}");
            }
            else
            {
                Console.WriteLine("Current User: No user currently logged in.");
            }
        }


        public static void DisplayUserInfo()
        {
            if (isUserLoggedIn)
            {
                // Display user info using enteredUserUsername
                Console.WriteLine($"Current User: {enteredUserUsername}");
            }
            else
            {
                Kernel.error("No user currently logged in.");
            }
        }

        public static string UserAccess()
        {
            if (isUserLoggedIn)
            {
                // Perform user functions
            }
            else
            {
                if (!File.Exists(userFilename))
                {
                    CreateUser();
                }

                Console.Write("Enter user username: ");
                enteredUserUsername = Console.ReadLine(); // Assign the value here

                if (ValidateUser(enteredUserUsername))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    isUserLoggedIn = true;
                    Console.WriteLine($"Welcome, {enteredUserUsername}!");
                    Console.ResetColor();
                }
                else
                {
                    Kernel.error("Invalid user username. Access denied.");
                }
            }

            return enteredUserUsername;
        }

        public static void UserLogout()
        {
            if (isUserLoggedIn)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                isUserLoggedIn = false;
                Console.WriteLine("User logged out.");
                Console.ResetColor();
            }
            else
            {
                Kernel.error("No user currently logged in.");
            }
        }

        private static void CreateUser()
        {
            Console.Write("Create a new user username: ");
            string newUserUsername = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(userFilename))
            {
                writer.WriteLine(newUserUsername);
            }

            Console.WriteLine($"User '{newUserUsername}' created and saved.");
        }

        private static bool ValidateUser(string enteredUsername)
        {
            if (File.Exists(userFilename))
            {
                string savedUsername = File.ReadAllText(userFilename).Trim();
                return enteredUsername == savedUsername;
            }

            return false;
        }




    }





}
