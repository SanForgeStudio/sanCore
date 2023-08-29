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
    public class Grep
    {
        public bool find(string to_find, List<string> list)
        {
            foreach (string x in list)
            {
                if (x == to_find)
                    return true;
            }
            return false;
        }

        public void grep(string file, string to_find, List<string> flags)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File could not be found");
                return;
            }
            string[] lines = File.ReadAllLines(file);
            int instances = 0;
            bool flag = false;

            foreach (string line in lines)
            {
                if (find("-c", flags))
                {
                    flag = true;
                    if (line.Contains(to_find))
                        instances++;
                }

                if (find("-w", flags))
                {
                    flag = true;
                    if (line == to_find)
                        Console.WriteLine(line);
                    return;
                }

                if (flag == false)
                    if (line.Contains(to_find))
                        Console.WriteLine(line);
            }
            if (find("-c", flags))
                Console.WriteLine(instances);
        }
    };
}