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

namespace Modded_Minecraft_Updater
{
    public partial class addEditConfig : Form
    {
        public addEditConfig()
        {
            InitializeComponent();

            buttonOK.Enabled = false;

            if(MyGlobals.editingConfigEntry)
            {
                configFileTextBox.Text = MyGlobals.curSelectedConfigFileFullPath;
                variableTextBox.Text = MyGlobals.curSelectedVariableName;
                replaceValueTextBox.Text = MyGlobals.curSelectedReplaceValue;
            }
        }

        private void setConfigFile_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog fileBrowser = new OpenFileDialog())
            {
                fileBrowser.Title = "Browse for .cfg files";
                fileBrowser.Filter = "CFG files|*.cfg";
                fileBrowser.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                fileBrowser.Multiselect = false;

                if(fileBrowser.ShowDialog() == DialogResult.OK)
                {
                    string filePath = fileBrowser.FileName;
                    configFileTextBox.Text = filePath;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Make sure the text boxes aren't empty
            string error = string.Empty;
            error = checkTextBoxes();
            
            // If no errors were encountered
            if(error == String.Empty)
            {
                string query = String.Empty;

                // The action we take next depends on if we're Editing an entry or not
                if(!MyGlobals.editingConfigEntry)
                {
                    // Inputs were OK, insert them into the database
                    query = "INSERT INTO `ConfigChanges` (`configFile`, `variable`, `changeTo`) ";
                    query += "VALUES (";
                    query += "'" + MyGlobals.getRelativePath(configFileTextBox.Text) + "', ";
                    query += "'" + variableTextBox.Text + "', ";
                    query += "'" + replaceValueTextBox.Text + "'";
                    query += ");";

                    MyGlobals.executeQuery(query);
                }
                else
                {
                    // Inputs were OK, save the changes to the current entry we're editing
                    query = "UPDATE `ConfigChanges` SET ";
                    query += "`configFile`='" + MyGlobals.getRelativePath(configFileTextBox.Text) + "', ";
                    query += "`variable`='" + variableTextBox.Text + "', ";
                    query += "`changeTo`='" + replaceValueTextBox.Text + "' ";
                    query += "WHERE ";
                    query += "`configFile`='" + MyGlobals.getRelativePath(MyGlobals.curSelectedConfigFileFullPath) + "' AND ";
                    query += "`variable`='" + MyGlobals.curSelectedVariableName + "' AND ";
                    query += "`changeTo`='" + MyGlobals.curSelectedReplaceValue + "';";

                    MyGlobals.executeQuery(query);

                    MyGlobals.curSelectedConfigFileFullPath = MyGlobals.workingDirectory + MyGlobals.getRelativePath(configFileTextBox.Text);
                    MyGlobals.curSelectedConfigFile = Path.GetFileName(MyGlobals.workingDirectory + MyGlobals.getRelativePath(configFileTextBox.Text));
                    MyGlobals.curSelectedVariableName = variableTextBox.Text;
                    MyGlobals.curSelectedReplaceValue = replaceValueTextBox.Text;
                }

                this.Close();
            }
            else
            {
                // An error has occured, display what's wrong
                string errorMsg = "An error was encountered, please fix the following error(s).\n" + error;
                MessageBox.Show(errorMsg);
            }
        }

        private String checkTextBoxes()
        {
            // Make sure the text boxes aren't empty
            string error = string.Empty;
            if(String.IsNullOrEmpty(configFileTextBox.Text) || String.IsNullOrWhiteSpace(configFileTextBox.Text))
            {
                error += "- You must select a Config file first.\n";
            }
            if(String.IsNullOrEmpty(variableTextBox.Text) || String.IsNullOrWhiteSpace(variableTextBox.Text))
            {
                error += "- You don't have a Variable Name set up.\n";
            }
            if(String.IsNullOrEmpty(replaceValueTextBox.Text) || String.IsNullOrWhiteSpace(replaceValueTextBox.Text))
            {
                error += "- You don't have a Value entered to replace the Variable with.\n";
            }
            
            // If no errors were encountered
            if(error == String.Empty)
            {
                buttonOK.Enabled = true;
            }
            else
            {
                buttonOK.Enabled = false;
            }

            return error;
        }

        private void configFileTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxes();
        }

        private void variableTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxes();
        }

        private void replaceValueTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxes();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addEditConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
