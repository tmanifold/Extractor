
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extractor
{
    public partial class frmProgressForm : Form
    {
        public frmProgressForm()
        {
            InitializeComponent();
         
        }

        private void lstProgressListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProgressForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
