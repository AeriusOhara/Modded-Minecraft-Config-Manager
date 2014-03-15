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
    public partial class ModdedMinecraftConfigHandlerMainForm : Form
    {
        public ModdedMinecraftConfigHandlerMainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyGlobals.initSQLite();
            checkTables();

            if (!Directory.Exists("files")) MyGlobals.createDirectory("files");
            if (!Directory.Exists("configs")) MyGlobals.createDirectory("configs");
            if (!Directory.Exists("mods")) MyGlobals.createDirectory("mods");

            populateConfigChanges();
            populateInterface();
        }

        private bool checkTables()
        {
            string query = String.Empty;

            // The table that holds the Config changes we'll monitor
            query = "CREATE TABLE IF NOT EXISTS [ConfigChanges](";
            query += "[configFile] TEXT NULL,";
            query += "[variable] TEXT NULL,";
            query += "[changeTo] TEXT NULL";
            query += ");";
            MyGlobals.executeQuery(query);

            query = String.Empty;

            // The table that holds the Settings
            query = "CREATE TABLE IF NOT EXISTS [Settings](";
            query += "[name] TEXT NULL,";
            query += "[value] TEXT NULL";
            query += ");";
            MyGlobals.executeQuery(query);

            return true;
        }

        private void populateConfigChanges()
        {
            // Clear the ItemView List
            configChangesList.Items.Clear();

            // Query for which folders we are supposed to be monitoring
            string query = "";
            query = "SELECT * FROM `ConfigChanges` ORDER BY `configFile` ASC;";
            SQLiteCommand cmd = new SQLiteCommand(query, MyGlobals.dblink);
            SQLiteDataReader reader = cmd.ExecuteReader();

            // For every config change we found
            while (reader.Read())
            {
                // Insert it to the ListView
                // Create a string array containing the folder and path
                string[] tmpRow = { Path.GetFileName(reader["configFile"].ToString()), reader["variable"].ToString(), reader["changeTo"].ToString(), reader["configFile"].ToString() };

                // Create a listViewItem from the array
                var listViewItem = new ListViewItem(tmpRow);

                // Add it to the list
                configChangesList.Items.Add(listViewItem);
            }

            if (configChangesList.Items.Count == 0)
            {
                performUpdateBtn.Enabled = false;
            }
            else
            {
                performUpdateBtn.Enabled = true;
            }
        }

        private void populateInterface()
        {
            // Disable default buttons
            this.editConfigBtn.Enabled = false;
            this.removeConfigBtn.Enabled = false;

            if (MyGlobals.settingExists("workingFolder"))
            {
                string workingFolder = MyGlobals.getSetting("workingFolder");
                this.folderTextBox.Text = workingFolder;
                MyGlobals.workingDirectory = workingFolder + Path.DirectorySeparatorChar;
            }

            if (MyGlobals.settingExists("moveOverConfigs") && MyGlobals.getSetting("moveOverConfigs") == "true")
            {
                // Remove the event temporarily so it doesn't invoke the checkChanged 
                // function when we change it here
                moveOverConfigs.CheckedChanged -= moveOverConfigs_CheckedChanged;
                this.moveOverConfigs.CheckState = CheckState.Checked;
                // Re-add the event
                moveOverConfigs.CheckedChanged += moveOverConfigs_CheckedChanged;

                MyGlobals.moveOverConfigs = true;
            }

            if (MyGlobals.settingExists("moveOverMods") && MyGlobals.getSetting("moveOverMods") == "true")
            {
                // Remove the event temporarily so it doesn't invoke the checkChanged 
                // function when we change it here
                moveOverMods.CheckedChanged -= moveOverMods_CheckedChanged;
                this.moveOverMods.CheckState = CheckState.Checked;
                // Re-add the event
                moveOverMods.CheckedChanged += moveOverMods_CheckedChanged;

                MyGlobals.moveOverMods = true;
            }
        }

        private void setFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = MyGlobals.workingDirectory;
            folderDialog.Description = "Select the ROOT Folder of your Modded Minecraft Installation. This is the folder that has the folders\n\"mods\" and \"config\".";
            folderDialog.ShowNewFolderButton = false;
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                // If a folder was selected and OK was pressed
                string selectedPath = folderDialog.SelectedPath + "\\";
                string selectedName = Path.GetFileName(selectedPath);
                MyGlobals.workingDirectory = selectedPath;

                string query = String.Empty;
                if (MyGlobals.settingExists("workingFolder"))
                {
                    query = "UPDATE `Settings` SET `value`=\"" + selectedPath + "\" WHERE `name`=\"workingFolder\";";
                }
                else
                {
                    query = "INSERT INTO `Settings` (`name`, `value`) VALUES (\"workingFolder\", \"" + selectedPath + "\");";
                }
                MyGlobals.executeQuery(query);

                folderTextBox.Text = selectedPath;
            }
        }

        private void addConfigBtn_Click(object sender, EventArgs e)
        {
            addEditConfig addEditForm = new addEditConfig();
            if (addEditForm.ShowDialog(this) == DialogResult.OK)
            {
                populateConfigChanges();
            }
        }

        private void removeConfigBtn_Click(object sender, EventArgs e)
        {
            // The remove query
            string query = String.Empty;
            query = "DELETE FROM `ConfigChanges` WHERE ";
            query += "`configFile`=\"" + MyGlobals.curSelectedConfigFileFullPath + "\" AND ";
            query += "`variable`=\"" + MyGlobals.curSelectedVariableName + "\" AND ";
            query += "`changeTo`=\"" + MyGlobals.curSelectedReplaceValue + "\";";

            MyGlobals.executeQuery(query);

            // Populate the changes
            populateConfigChanges();

            // Check the buttons (which have to be enabled/disabled)
            checkEditRemoveButtons();
        }

        private void editConfigBtn_Click(object sender, EventArgs e)
        {
            MyGlobals.editingConfigEntry = true;

            addEditConfig addEditForm = new addEditConfig();
            if (addEditForm.ShowDialog(this) == DialogResult.OK)
            {
                populateConfigChanges();
            }

            MyGlobals.editingConfigEntry = false;
        }

        private void configChangesList_DoubleClick(object sender, EventArgs e)
        {
            if (configChangesList.SelectedItems.Count > 0)
            {
                MyGlobals.editingConfigEntry = true;

                addEditConfig addEditForm = new addEditConfig();
                if (addEditForm.ShowDialog(this) == DialogResult.OK)
                {
                    populateConfigChanges();
                }

                MyGlobals.editingConfigEntry = false;
            }
        }

        private void moveOverConfigs_CheckedChanged(object sender, EventArgs e)
        {
            MyGlobals.toggleSetting("moveOverConfigs");
        }

        private void moveOverMods_CheckedChanged(object sender, EventArgs e)
        {
            MyGlobals.toggleSetting("moveOverMods");
        }

        private void performUpdate_Click(object sender, EventArgs e)
        {
            performUpdate update = new performUpdate();
            update.ShowDialog(this);
        }

        private void configChangesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configChangesList.SelectedItems.Count > 0)
            {
                // Clear Globals
                MyGlobals.curSelectedConfigFile = String.Empty;
                MyGlobals.curSelectedVariableName = String.Empty;
                MyGlobals.curSelectedReplaceValue = String.Empty;
                MyGlobals.curSelectedConfigFileFullPath = String.Empty;

                // Grab the values of the selected row
                MyGlobals.curSelectedConfigFile = this.configChangesList.FocusedItem.SubItems[0].Text;
                MyGlobals.curSelectedVariableName = this.configChangesList.FocusedItem.SubItems[1].Text;
                MyGlobals.curSelectedReplaceValue = this.configChangesList.FocusedItem.SubItems[2].Text;
                MyGlobals.curSelectedConfigFileFullPath = this.configChangesList.FocusedItem.SubItems[3].Text;

                checkEditRemoveButtons();
            }
        }

        private void configChangesList_Leave(object sender, EventArgs e)
        {
            checkEditRemoveButtons();
        }

        private void checkEditRemoveButtons()
        {
            if (configChangesList.SelectedItems.Count > 0)
            {
                this.removeConfigBtn.Enabled = true;
                this.editConfigBtn.Enabled = true;
            }
            else
            {
                this.removeConfigBtn.Enabled = false;
                this.editConfigBtn.Enabled = false;
            }
        }
    }

    public static class MyGlobals
    {
        // The SQLite connection
        public static SQLiteConnection dblink = null;

        public static string workingDirectory = String.Empty;
        public static bool moveOverConfigs = false;
        public static bool moveOverMods = false;
        public static bool editingConfigEntry = false;
        public static string curSelectedConfigFile = String.Empty;
        public static string curSelectedVariableName = String.Empty;
        public static string curSelectedReplaceValue = String.Empty;
        public static string curSelectedConfigFileFullPath = String.Empty;

        public static bool createDirectory(string directory)
        {
            try
            {
                Directory.CreateDirectory(directory);

                return true;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);

                return false;
            }
        }

        public static string getRelativePath(string location)
        {
            string tmpFilePath = location;
            string[] splitFilePath = tmpFilePath.Split(Path.DirectorySeparatorChar);
            string relativeFilePath = String.Empty;
            bool found = false;

            // Try and grab the relative path
            // For example, if we'd get C:\minecraft\config\hillarious.cfg
            // we'd want to get the part: config\hillarious.cfg
            int i = 0;
            foreach (string str in splitFilePath)
            {
                if (str == "config")
                {
                    found = true;
                }

                if (found)
                {
                    relativeFilePath += splitFilePath[i];
                    relativeFilePath += "\\";
                }
                i++;
            }
            relativeFilePath = relativeFilePath.Trim(Path.DirectorySeparatorChar);

            return relativeFilePath;
        }

        public static bool initSQLite()
        {
            // Check if our database exixts, if not, create it
            MyGlobals.dblink = null;
            try
            {
                MyGlobals.dblink = new SQLiteConnection("Data Source=data.s3db;Version=3;FailIfMissing=True;");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                MyGlobals.dblink.Open();
            }
            catch (SQLiteException ex)
            {
                SQLiteConnection.CreateFile("data.s3db");

                // Try to open the file once more, now we've created it
                try
                {
                    // Open the file
                    MyGlobals.dblink.Open();
                }
                catch (SQLiteException ex3)
                {
                    //MessageBox.Show(ex3.ToString());
                    // Couldn't open the database file, which means it wasn't
                    // created, no administrative priviledges perhaps? Throw
                    // an error
                    MessageBox.Show("Could not create the database file directory!\r\nTry running this application with Administrative Privileges.\n\nException: " + ex3);
                }
            }

            return false;
        }

        public static bool executeQuery(string query)
        {
            SQLiteCommand sqlcmd;
            sqlcmd = MyGlobals.dblink.CreateCommand();
            sqlcmd.CommandText = query;
            try
            {
                sqlcmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Failed to execute SQL Query (Exception: " + ex + ")\n\nThe Query given was:\n" + query);
            }
            return true;
        }

        public static bool isNumber(string text)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(text);
        }

        public static string getSetting(string name)
        {
            // Grab the Setting from the database
            string query2 = "SELECT `Value` FROM `Settings` WHERE `Name`=\"" + name + "\";";
            SQLiteCommand cmd = new SQLiteCommand(query2, MyGlobals.dblink);
            SQLiteDataReader reader = cmd.ExecuteReader();

            // For every entry we found
            while (reader.Read())
            {
                // Return the value we got
                return reader["Value"].ToString();
            }

            // Was not found, return NULL
            return "NULL";
        }

        public static void setSetting(string name, string value)
        {
            // Change the value of the Setting stored in the database
            string query = "UPDATE `Settings` SET `Value`=\"" + value + "\" WHERE `Name`=\"" + name + "\";";
            executeQuery(query);
        }

        public static void addSetting(string name, string value)
        {
            // Grab the latest Large Patch file entry, and then delete all other Large type file entries
            string query = "INSERT INTO `Settings` (`Name`, `Value`) VALUES (\"" + name + "\", \"" + value + "\");";
            executeQuery(query);
        }

        public static bool settingExists(string name)
        {
            // Grab the latest Large Patch file entry, and then delete all other Large type file entries
            string query2 = "SELECT `Value` FROM `Settings` WHERE `Name`=\"" + name + "\";";
            SQLiteCommand cmd = new SQLiteCommand(query2, MyGlobals.dblink);
            SQLiteDataReader reader = cmd.ExecuteReader();

            // For every entry we found
            while (reader.Read())
            {
                // Setting exists
                return true;
            }

            // Setting didn't exist
            return false;
        }

        public static void toggleSetting(string setting)
        {
            string value = String.Empty;

            if (settingExists(setting))
            {
                value = getSetting(setting);

                if (value == "true")
                {
                    setSetting(setting, "false");
                }
                else if (value == "false")
                {
                    setSetting(setting, "true");
                }
                else
                {
                    string error = "An error occured for toggleSetting()\n";
                    error += "Value for setting [" + setting + "] was not true or false, but was: " + value;

                    MessageBox.Show(error);
                }
            }
            else
            {
                addSetting(setting, "true");
            }
        }

        public static int getIntFromString(string text)
        {
            int i;
            if (Int32.TryParse(text, out i))
            {
                return i;
            }

            return -1;
        }
    }
}
