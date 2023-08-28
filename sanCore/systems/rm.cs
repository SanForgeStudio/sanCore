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
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace sanCore
{
    class rm
    {
        public static void remove(string rmPath)
        {
            if (rmPath.Contains(":\\"))
            {
                if (Directory.Exists(rmPath))
                {
                    Directory.Delete(rmPath);
                }
                else if (File.Exists(rmPath))
                {
                    File.Delete(rmPath);
                }
                else
                {
                    Kernel.error(rmPath + " doesn't exist");
                }
            }
            else
            {
                if (Directory.GetCurrentDirectory().EndsWith("\\"))
                {
                    if (Directory.Exists(Directory.GetCurrentDirectory() + rmPath))
                    {
                        Directory.Delete(Directory.GetCurrentDirectory() + rmPath);
                    }
                    else if (File.Exists(rmPath))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + rmPath);
                    }
                    else
                    {
                        Kernel.error(rmPath + " doesn't exist");
                    }
                }
                else
                {
                    if (Directory.Exists(Directory.GetCurrentDirectory() + "\\" + rmPath))
                    {
                        Directory.Delete(Directory.GetCurrentDirectory() + "\\" + rmPath);
                    }
                    else if (File.Exists(rmPath))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\" + rmPath);
                    }
                    else
                    {
                        Kernel.error(rmPath + " doesn't exist");
                    }
                }
            }
        }
    }
}
