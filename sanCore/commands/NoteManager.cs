/*
 * Copyright 2025 sanCore, SanForge Studio
 * Created By: Sander Kerkhoff
 */


using System;
using System.IO;
using System.Text;

namespace sanCore.commands
{
    public static class NoteManager
    {
        private static bool isWriting = false;
        private static StringBuilder noteBuffer = new StringBuilder();
        private static string currentNoteName = "";

        public static void StartNote(string filename)
        {
            if (isWriting)
            {
                Console.WriteLine("Already writing a note. Stop the current one first.");
                return;
            }

            currentNoteName = filename;
            noteBuffer.Clear();
            isWriting = true;
            Console.WriteLine($"Started writing note: {filename}");
        }

        public static void WriteLine(string line)
        {
            if (isWriting)
            {
                noteBuffer.AppendLine(line);
            }
            else
            {
                Console.WriteLine("Not currently writing a note. Use 'note create' first.");
            }
        }

        public static void StopNote()
        {
            if (!isWriting)
            {
                Console.WriteLine("No active note writing session.");
                return;
            }

            string path = $"0:\\{currentNoteName}.txt";
            File.WriteAllText(path, noteBuffer.ToString());
            Console.WriteLine($"Note saved as: {currentNoteName}.txt");

            isWriting = false;
            noteBuffer.Clear();
            currentNoteName = "";
        }

        public static void ReadNote(string filename)
        {
            string path = $"0:\\{filename}.txt";
            if (File.Exists(path))
            {
                Console.WriteLine($"Contents of {filename}.txt:");
                Console.WriteLine("--------------------------------");
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("--------------------------------");
            }
            else
            {
                Console.WriteLine("Note not found.");
            }
        }

        public static bool IsWriting()
        {
            return isWriting;
        }
    }
}
