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
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace Modded_Minecraft_Updater
{
    public partial class performUpdate : Form
    {
        public performUpdate()
        {
            InitializeComponent();

            this.buttonOK.Enabled = false;
        }

        private void performUpdate_Load(object sender, EventArgs e)
        {
            // Query for which folders we are supposed to be monitoring
            string query = "";
            query = "SELECT * FROM `ConfigChanges` ORDER BY `configFile` ASC;";
            SQLiteCommand cmd = new SQLiteCommand(query, MyGlobals.dblink);
            SQLiteDataReader reader = cmd.ExecuteReader();

            // For every config change we found
            while(reader.Read())
            {
                bool foundOption = false;
                int lineNo = 1;

                // Try or fail to do the following
                try
                {
                    string relativeFilePath = MyGlobals.getRelativePath(reader["configFile"].ToString());

                    // Read the file
                    StreamReader file = new StreamReader(MyGlobals.workingDirectory + reader["configFile"].ToString()); 
                    
                    string line = String.Empty;
                    string newLine = String.Empty;
                    string originalLine = String.Empty;
                    string replaceStringWith = String.Empty;
                    string[] splitNewLine;
                    try
                    {
                        while((line = file.ReadLine()) != null)
                        {
                            // If the line we're reading contains the variable name we're currently checking for
                            if(line.Contains(reader["variable"].ToString()) && line.Contains('='))
                            {
                                newLine = line;
                                splitNewLine = newLine.Split('=');
                                replaceStringWith = newLine.Replace(splitNewLine[1], reader["changeTo"].ToString());
                                // If the changed string no longer matches the old string, success!
                                if(replaceStringWith != line)
                                {
                                    originalLine = line;
                                    Log(reader["configFile"].ToString());
                                    Log("[o] Successfull change!");
                                    Log("OLD> " + line);
                                    Log("NEW> " + replaceStringWith);

                                    foundOption = true;
                                }
                                else
                                {
                                    Log(reader["configFile"].ToString());
                                    Log("[o] No change needed!");
                                }
                            }
                            lineNo++;
                        }
                    }
                    catch(IndexOutOfRangeException ex)
                    {
                        MessageBox.Show("Index out of Bounds while handling the file [" + reader["configFile"].ToString() + "] and looking for variable [" + reader["variable"].ToString() + "] LINE [" + lineNo + "] Error:\n\n" + ex);
                    }
                    file.Close();

                    // If we found the variable
                    if(foundOption)
                    {
                        // Read the entire file
                        var fileContents = File.ReadAllText(MyGlobals.workingDirectory + reader["configFile"].ToString());
                        // Replace the line we're asked to edit
                        fileContents = fileContents.Replace(originalLine, replaceStringWith);
                        // Write the changes to the file
                        File.WriteAllText(MyGlobals.workingDirectory + relativeFilePath, fileContents);

                        foundOption = false;
                    }
                    Log("");
                }
                catch(EndOfStreamException)
                {
                    MessageBox.Show("Something went wrong, very likely the file was missing!");
                }
            }

            // Now move over the mods and configs if we have any
            if(MyGlobals.moveOverConfigs)
            {
                foreach(var file in Directory.GetFiles("config\\"))
                {
                    File.Copy(file, Path.Combine(MyGlobals.workingDirectory + "config\\", Path.GetFileName(file)), true);
                }

                foreach(var dir in Directory.GetDirectories("config\\"))
                {
                    // Dir has already stored: config\\dir, hence why config is no longer used downstairs in the strings
                    Directory.CreateDirectory(MyGlobals.workingDirectory + dir + "\\");

                    foreach(var file in Directory.GetFiles(dir + "\\"))
                    {
                        File.Copy(file, Path.Combine(MyGlobals.workingDirectory + dir + "\\", Path.GetFileName(file)), true);
                    }
                }
            }

            if(MyGlobals.moveOverMods)
            {
                foreach(var file in Directory.GetFiles("mods\\"))
                {
                    File.Copy(file, Path.Combine(MyGlobals.workingDirectory + "mods\\", Path.GetFileName(file)), true);
                }
            }

            foreach(var file in Directory.GetFiles("files\\"))
            {
                File.Copy(file, Path.Combine(MyGlobals.workingDirectory, Path.GetFileName(file)), true);
            }

            this.buttonOK.Enabled = true;
        }

        private void Log(string str)
        {
            logBox.Text += str + "\r\n";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
