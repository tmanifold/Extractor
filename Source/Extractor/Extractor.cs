
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

using System.IO;
using System.IO.Compression;
using System.Diagnostics;

using tar_cs;
using NUnrar;
using NUnrar.Archive;
using NUnrar.Common;

namespace Extractor
{
    public partial class Form_Extractor : Form
    {

        public static string source  = null;
        public static Stack<string> parents = new Stack<string>();

        public static string destination = null;    // specifies the directory where all selected files will be extracted to

        private static bool fixNames;
        private static bool deleteZips;
        private static bool viewFiles;

        public static frmProgressForm prg;

        private static int depth = 0;
  
        public Form_Extractor(bool fix, bool clean, bool view)
        {
            InitializeComponent();
            fixNames = fix;
            deleteZips = clean;
            viewFiles = view;
        }
        private void Form_Unzipper_Load(object sender, EventArgs e)
        {
            chkFixNamesCheckBox.Checked = fixNames;
            chkDeleteZipsCheckBox.Checked = deleteZips;
            chkViewFilesCheckBox.Checked = viewFiles;

            chkDeleteZipsCheckBox.Update();
            chkFixNamesCheckBox.Update();
            chkViewFilesCheckBox.Update();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            depth = 0;
            fixNames = chkFixNamesCheckBox.Checked;
            deleteZips = chkDeleteZipsCheckBox.Checked;
            viewFiles = chkViewFilesCheckBox.Checked;

            destination = txtDestination_TextBox.Text;

            DialogResult result = DialogResult.Yes;

            try
            {
                // Warn the user about file deletion
                if (deleteZips)
                {
                    if (!Global.global_ignoreDeleteWarning)
                    {
                        result = MessageBox.Show("WARNING:\n"
                            + "Selecting this option will cause certain files to be deleted. If you do not understand what will be deleted or why, leave this unselected.\n"
                            + "The author of this application may not be held responsible for lost data.\n\n"
                            + "Continue?\n"
                            + "Select CANCEL to continue and ignore this warning in the future.", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        // let the user change their mind
                        if (result == DialogResult.No)
                        {
                            deleteZips = false;
                            chkDeleteZipsCheckBox.Checked = false;
                            Global.global_deleteZips = false;
                        }
                        // let the user irresponsibly ignore my gracious warnings
                        else if (result == DialogResult.Cancel)
                        {
                            Global.global_ignoreDeleteWarning = true;
                            UpdateINI();
                        }
                    }
                }

                if (result != DialogResult.No)
                {
                    if (!Directory.Exists(destination))
                    {
                        Directory.CreateDirectory(destination);
                    }

                    btnExtract_Button.Text = "Extracting";

                    prg = new frmProgressForm();
                    prg.lstProgressListBox.Items.Clear();

                    foreach (string path in parents)
                    {
                        depth = 0;
                        if (File.Exists(path))
                        {
                            if (PathIsValid(path))
                            {
                                prg.Visible = true;
                                Unzip(path);  
                            }
                            else
                            {
                                MessageBox.Show("Selection is invalid. Please select one or more valid archives.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }


                    btnExtract_Button.Text = "Extract";

                    prg.lstProgressListBox.Items.Add("Done!");



                    if (viewFiles)
                    {
                        ViewFiles(destination);
                    }

                    parents.Clear();
                    txtSource_TextBox.Text = "";
                    txtDestination_TextBox.Text = "";
                }
            }
            catch (System.ArgumentException) {}

        }

        private void txtSource_TextBox_TextChanged(object sender, EventArgs e) { }

        private void btnSourceDialogButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.ShowDialog();

            try
            {
                foreach (string file in dlg.FileNames)
                {
                    //txtDestination_TextBox.Text = destination;
                    parents.Push(file);
                    txtSource_TextBox.Text = txtSource_TextBox.Text + "\"" + file + "\";";
                    destination = Path.GetDirectoryName(file);
                    txtDestination_TextBox.Text = destination;
                    
                }
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("Invalid source(s) selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDestinationDialogButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.ShowDialog();

            destination = browser.SelectedPath;
            txtDestination_TextBox.Text = destination;
            
        }


        private void txtDestination_TextBox_TextChanged(object sender, EventArgs e)
        {
            destination = txtDestination_TextBox.Text;
        }

        private void chkDeleteZipsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            deleteZips = chkDeleteZipsCheckBox.Checked;
            UpdateINI();
        }

        private void chkFixNamesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fixNames = chkFixNamesCheckBox.Checked;
            UpdateINI();
        }

        private void chkViewFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            viewFiles = chkViewFilesCheckBox.Checked;
            UpdateINI();
        }

        public static void Unzip(string file_path)
        {
            string parent = Directory.GetParent(file_path).ToString();
            string target = null;
//            string target = destination + "\\" + Path.GetFileNameWithoutExtension(file_path);         // specifies the path to which individual archives will be extracted to within the destination directory

            switch (depth)
            {
                case 0:
                    {
                        target = Path.Combine(destination, Path.GetFileNameWithoutExtension(file_path));
                        break;
                    }
                case 1:
                    {
                        target = Path.Combine(parent, Path.GetFileNameWithoutExtension(file_path));
                        break;
                    }
                default: { break; }
            }
            
            // Message box for debugging purposes
            // MessageBox.Show("file_path: " + file_path + "\n\ntarget: " + target + "\n\ndestination: " + destination + "\n\nparent: " + parent);

            // make the directory names easier to look at if
            // chkFixNamesCheckBox is true
            if (fixNames)
            {
                target = FixNames(target);
            }
            
            if (!Directory.Exists(target))
            {
                DirectoryInfo dir = Directory.CreateDirectory(target);
            }

            string ext = Path.GetExtension(file_path);
            switch (ext)
            {
                case ".zip":
                    {
                        // process for zip files

                        using (ZipArchive arch = ZipFile.OpenRead(file_path))
                        {
                            try
                            {
                                ZipFile.ExtractToDirectory(file_path, target);
                            }
                            catch (System.IO.IOException) { }

                        }
                        break;
                    }
                case ".gz":
                    {
                        using (FileStream gz_arch = File.OpenRead(file_path))
                        {
                            string target_file = Path.GetFileNameWithoutExtension(file_path);
                            using (FileStream decompressedFileStream = File.Create(Path.Combine(target, target_file)))
                            {
                                using (GZipStream gz = new GZipStream(gz_arch, CompressionMode.Decompress))
                                {
                                    gz.CopyTo(decompressedFileStream);
                                }
                            }
                        }
                        break;
                    }
                case ".tar":
                    {
                        using (FileStream tarchive = File.OpenRead(file_path))
                        {
                            try
                            {
                                TarReader reader = new TarReader(tarchive);
                                reader.ReadToEnd(target);
                            }
                            catch (System.IO.IOException) { }
                        }

                        break;
                    }
                case ".rar":
                    {
                        if (RarArchive.IsRarFile(file_path))
                        {
                            //RarArchive rarchive = RarArchive.Open(file_path);
                            try
                            {
                                RarArchive.WriteToDirectory(file_path, target, ExtractOptions.ExtractFullPath);
                            }
                            catch (System.IO.IOException) { }
                            catch (System.UnauthorizedAccessException) { }              
                        }                        
                        break;
                    }
                default: { break; }
            }
            UpdateProgressListBox(file_path + " -> " + target);
            depth = 1;
            RecurseDirectories(target);
        }

        public static void RecurseDirectories(string file_path)
        {

            string[] files = Directory.GetFiles(file_path);
            foreach (string file in files)
            {
                if (PathIsValid(file))
                {
                    Unzip(file);

                    if (deleteZips)
                    {
                        DeleteZip(file);
                    }

                }
                if (file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    DeleteTxt(file);
                }
            }
            
            string[] dirs = Directory.GetDirectories(file_path);
            foreach (string subdirectory in dirs)
            {
                RecurseDirectories(subdirectory);
            }
        }

        // updates the extraction progress form listbox as files are processed
        public static void UpdateProgressListBox(string item)
        {
            prg.lstProgressListBox.Items.Add(item);
            prg.lstProgressListBox.Update();

            // weird hack to auto scroll as the listbox is updated
            prg.lstProgressListBox.SelectedIndex = prg.lstProgressListBox.Items.Count - 1;
            prg.lstProgressListBox.SelectedIndex = -1;

            int file_count = Convert.ToInt32(prg.lblFileCountLabel.Text);
            file_count++;
           
            prg.lblFileCountLabel.Text = file_count.ToString();
            prg.lblFileCountLabel.Update();
            prg.label1.Update();
        }


        // Fixes directory names by making them suck less.
        //  Looks for the string "attempt" within the name
        //  and only keeps the stuff before it.
        // If "attempt string is not found, the original
        //  name is kept.
        private static string FixNames(string name)
        {
            int attempt_index;
            string fixedName = " ";
            if (name.IndexOf("attempt") > 0)
            {
                attempt_index = name.IndexOf("attempt") - 1;
                fixedName = name.Substring(0, attempt_index);
            }
            else
            {
                fixedName = name;
            }
            
            return fixedName;
        }


        private static bool PathIsValid(string path)
        {
            bool valid_path;
            if (path.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                valid_path = true;
            }

            // To be implemented later when support for .tar and .rar files is added

            else if (path.EndsWith(".tar", StringComparison.OrdinalIgnoreCase))
            {
                valid_path = true;
            }
            else if (path.EndsWith(".gz", StringComparison.OrdinalIgnoreCase))
            {
                valid_path = true;
            }
            else if (path.EndsWith(".rar", StringComparison.OrdinalIgnoreCase))
            {
                valid_path = true;
            }

            else
            {
                valid_path = false;
            }

            return valid_path;
        }

        private static bool FileIsStudentText(string file)
        {
            bool is_student_text = false;

            if (file.IndexOf("attempt") > 0 && file.EndsWith(".txt"))
            {
                is_student_text = true;
            }

            return is_student_text;
        }

        private static void UpdateINI()
        {
            using (StreamWriter sw = new StreamWriter("./extractor.ini"))
            {
                sw.Write("");
                sw.WriteLine("bDeleteZips=" + deleteZips);
                sw.WriteLine("bFixNames=" + fixNames);
                sw.WriteLine("bViewFiles=" + viewFiles);
                sw.WriteLine("bIgnoreDeleteWarning=" + Global.global_ignoreDeleteWarning);
                sw.Close();
            }
        }

        private static void ViewFiles(string path)
        {
            Process.Start("explorer.exe", path);
        }

        private static void DeleteTxt(string path)
        {
            if (File.Exists(path) && FileIsStudentText(path))
            {
                File.Delete(path); 
            }
        }

        private static void DeleteZip(string path)
        {
            string ext = Path.GetExtension(path);

            if (File.Exists(path))
            {
                switch (ext)
                {
                    case ".gz":
                    case ".rar":
                    case ".tar":
                    case ".zip":
                        {
                            try
                            {
                                File.Delete(path);
                            }
                            catch (System.IO.IOException) { }
                            break;
                        }

                    default: { break;  }
                }
            }
        }

#region Deprecated
        /*
        // Begins the extraction process.
        //  Starts with the 'root' zip file, then calls BatchExtract(string, bool)
        //   to handle the rest.
        //  Calls Cleanup(string) if chkDeleteZipsCheckBox is true.
                private static void Extract(bool fixNames, bool cleanup)
                {
                    try
                    {   
                        if (!Directory.Exists(destination))
                        {
                            if (MessageBox.Show(destination + " Does not exist and will be created", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                DirectoryInfo di = Directory.CreateDirectory(destination);
                            }
                        }                

                        // Open the main assignment ZipFile
                        using (ZipArchive archive = ZipFile.OpenRead(source))
                        {
                            // Step through each file within the assignment Zip
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                // Make sure to only grab files with the zip extension
                                if (entry.FullName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                                {                           
                                    // extract entries from the file if they don't already exist.
                                    if (!File.Exists(Path.Combine(destination, entry.FullName)))
                                    {

                                        entry.ExtractToFile(Path.Combine(destination, entry.FullName));
                                    }

                                    BatchExtract(destination, fixNames);
                                }
                            }
                        }
                        if (cleanup)
                        {
                            CleanUp(destination);
                        }

                    }
                    catch (InvalidDataException ex)
                    {
                        MessageBox.Show("Must select a .zip file\n\n Details:\n" + ex.ToString(), "Invalid File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        //MessageBox.Show(destination + " not found.\n\n Details:\n" + ex.ToString(), "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        MessageBox.Show("File '" + source + "' not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            
                }
         

        // Accepts a directory path as an argument.
        // this directory path should be the target directory [destination]
        // for the extracted files.
                private static void BatchExtract(string rt, bool fixNames)
                {
                    // store the file paths of the zip files in the target directory
                    string[] files = Directory.GetFiles(rt, "*.zip", SearchOption.TopDirectoryOnly);

                    foreach (string file in files)
                    {
                        // strip the .zip extension from the file name
                        //  because an exception was being thrown when attempting
                        //  to create directories using the value of [file]
                        string f = Path.GetFileNameWithoutExtension(file);
                        string p;

                        // make the directory names easier to look at if
                        // chkFixNamesCheckBox is true
                        if (fixNames)
                        {
                            f = FixNames(f);
                        }
                        // otherwise keep the default name
                        p = Path.Combine(destination, f);
                
               
                        // if the directory doesn't exist already, create it.
                       if (!Directory.Exists(f))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(p);
                        }

                        using (ZipArchive archive = ZipFile.OpenRead(file))
                        {
                            try
                            {
                                ZipFile.ExtractToDirectory(file, Path.Combine(p));
                        
                            }
                            // Ignore a weird exception that was being thrown
                            //  saying certain files already exist
                            catch (System.IO.IOException)
                            {
                                continue;
                            }
                        }
                    }            
                }
        
        // Cleans up the target directory [destination] by looking
        //  for files with the .zip extension, then deleting them
                private static void CleanUp(string rt)
                {
                    // Allocates all files in the target directory ending with
                    //  the .zip extension in an array
                    string[] files = Directory.GetFiles(rt, "*.zip");

                    try
                    {
                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }
                    }
                    catch (System.IO.FileNotFoundException e) // just in case
                    {
                        MessageBox.Show(e.ToString(), "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
 */
 #endregion
    }
}
