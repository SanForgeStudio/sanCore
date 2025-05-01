/*
 * Copyright 2025 sanCore, SanForge Studio
 * Created By: Sander Kerkhoff
 */

using System;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.HAL;
using System.Collections.Generic;
using sanCore.core;
using sanCore;

namespace sanCore
{
    public static class CommandHistory
    {
        private static List<string> history = new List<string>();

        public static void Add(string command)
        {
            if (!string.IsNullOrWhiteSpace(command))
                history.Add(command);
        }

        public static void Show()
        {
            if (history.Count == 0)
            {
                Console.WriteLine("No commands in history.");
                return;
            }

            Console.WriteLine("Command History:");
            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {history[i]}");
            }
        }
    }
}
