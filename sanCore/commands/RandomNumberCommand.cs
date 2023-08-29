using System;
using System.IO;

namespace sanCore.Commands
{
    public class RandomNumberCommand
    {
        public static void Execute(string args)
        {
            if (string.IsNullOrWhiteSpace(args))
            {
                Console.WriteLine("Usage: random <min> <max>");
                return;
            }

            string[] argArray = args.Split(' ');

            if (argArray.Length != 2 || !int.TryParse(argArray[0], out int min) || !int.TryParse(argArray[1], out int max))
            {
                Console.WriteLine("Invalid input. Usage: random <min> <max>");
                return;
            }

            Random random = new Random();
            int randomNumber = random.Next(min, max + 1);

            Console.WriteLine($"Random number between {min} and {max}: {randomNumber}");
        }
    }
}
