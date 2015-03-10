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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Extractor
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.InitFromINI();
            Application.Run(new Form_Extractor(Global.global_fixNames, Global.global_deleteZips, Global.global_viewFiles));
        }


    }
}
