
#region Copyright
/*
  Copyright (C) 2015 Tyler Manifold
  
  This file is part of Extractor.
  
  Extractor is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Extractor is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with Extractor.  If not, see <http://www.gnu.org/licenses/>.

  Extractor is a simple, recursive file extraction program.
 
  Email: tdmanifold@gmail.com

*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Extractor
{
    public static class Global
    {
        public static bool global_fixNames;
        public static bool global_deleteZips;
        public static bool global_viewFiles;
        public static bool global_ignoreDeleteWarning;

        // Gets the ini variable from a file stream by
        //  looking through the line it is passed.
        // Determines the index of the equal sign in the statement
        //  and returns the variable name that comes before it.
        public static string GetINIVariable(string line)
        {

            string var_name = null;

            int equ_index = line.IndexOf("=");

            var_name = line.Substring(0, equ_index);

            return var_name;
        }

        // To be used in conjunction with GetINIVariable:
        //  Gets the value of the variable from the file stream
        //   by searching the line it is passed and determining
        //   the index of the equal sign in the statement,
        //   and returns the value that follows.
        public static string GetINIVarValue(string ini_var)
        {
            string ini_val = null;
            int equ_index = ini_var.IndexOf("=");

            ini_val = ini_var.Substring(equ_index + 1, ini_var.Length - equ_index -1);

            return ini_val;
        }

        // Initializes the .ini file if it doesn't already exist
        //  If it does exist, grab the values from it and pass them to the form
        public static void InitFromINI()
        {

            // initialize the .ini file
            if (!File.Exists("./extractor.ini"))
            {
                using (StreamWriter sw = new StreamWriter("./extractor.ini"))
                {
                    global_fixNames = false;
                    global_deleteZips = false;
                    sw.WriteLine("bDeleteZips=" + global_deleteZips);
                    sw.WriteLine("bFixNames=" + global_fixNames);
                    sw.WriteLine("bViewFiles=" + global_viewFiles);
                    sw.WriteLine("bIgnoreDeleteWarning=" + global_ignoreDeleteWarning);
                    sw.Close();
                }
            }
            else // the .ini file already exists
            {
                string line = null;

                // open the ini file in a new read stream
                using (StreamReader sr = new StreamReader("./extractor.ini"))
                {
                    // look until EOF
                    while (sr.Peek() >= 0)
                    {
                        line = sr.ReadLine();

                        string ini_var = GetINIVariable(line);
                        string ini_var_val = GetINIVarValue(line);

                        switch (ini_var)
                        {
                            // assign values based on what variable is being read from the .ini
                            case "bDeleteZips":
                                {
                                    if (ini_var_val.ToLower() == "true")
                                    {
                                        global_deleteZips = true;
                                    }
                                    else
                                    {
                                        global_deleteZips = false;
                                    }
                                    break;
                                }
                            case "bFixNames":
                                {
                                    if (ini_var_val.ToLower() == "true")
                                    {
                                        global_fixNames = true;
                                    }
                                    else
                                    {
                                        global_fixNames = false;
                                    }
                                    break;
                                }
                            case "bViewFiles":
                                {
                                    if (ini_var_val.ToLower() == "true")
                                    {
                                        global_viewFiles = true;
                                    }
                                    else
                                    {
                                        global_viewFiles = false;
                                    }
                                    break;
                                }
                            case "bIgnoreDeleteWarning":
                                {
                                    if (ini_var_val.ToLower() == "true")
                                    {
                                        global_ignoreDeleteWarning = true;
                                    }
                                    else
                                    {
                                        global_ignoreDeleteWarning = false;
                                    }
                                    break;
                                }
                        }
                    }

                    sr.Close();
                }
            }
        }
    }
}
