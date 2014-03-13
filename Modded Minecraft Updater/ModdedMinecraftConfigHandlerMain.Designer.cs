namespace Modded_Minecraft_Updater
{
    partial class ModdedMinecraftConfigHandlerMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.configChangesList = new System.Windows.Forms.ListView();
            this.inConfigFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textVar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.changeTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inConfigFileFullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setFolderButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.moveOverConfigs = new System.Windows.Forms.CheckBox();
            this.moveOverMods = new System.Windows.Forms.CheckBox();
            this.editConfigBtn = new System.Windows.Forms.Button();
            this.removeConfigBtn = new System.Windows.Forms.Button();
            this.addConfigBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.performUpdateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // configChangesList
            // 
            this.configChangesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.inConfigFile,
            this.textVar,
            this.changeTo,
            this.inConfigFileFullPath});
            this.configChangesList.FullRowSelect = true;
            this.configChangesList.HideSelection = false;
            this.configChangesList.Location = new System.Drawing.Point(12, 81);
            this.configChangesList.MultiSelect = false;
            this.configChangesList.Name = "configChangesList";
            this.configChangesList.Size = new System.Drawing.Size(510, 200);
            this.configChangesList.TabIndex = 0;
            this.configChangesList.UseCompatibleStateImageBehavior = false;
            this.configChangesList.View = System.Windows.Forms.View.Details;
            this.configChangesList.SelectedIndexChanged += new System.EventHandler(this.configChangesList_SelectedIndexChanged);
            this.configChangesList.DoubleClick += new System.EventHandler(this.configChangesList_DoubleClick);
            this.configChangesList.Leave += new System.EventHandler(this.configChangesList_Leave);
            // 
            // inConfigFile
            // 
            this.inConfigFile.Text = "In Config File";
            this.inConfigFile.Width = 194;
            // 
            // textVar
            // 
            this.textVar.Text = "Variable";
            this.textVar.Width = 143;
            // 
            // changeTo
            // 
            this.changeTo.Text = "Change To";
            this.changeTo.Width = 151;
            // 
            // inConfigFileFullPath
            // 
            this.inConfigFileFullPath.Text = "";
            this.inConfigFileFullPath.Width = 0;
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(98, 55);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.ReadOnly = true;
            this.folderTextBox.Size = new System.Drawing.Size(343, 20);
            this.folderTextBox.TabIndex = 1;
            this.folderTextBox.Text = "Click the button on the right configure...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Work in Folder:";
            // 
            // setFolderButton
            // 
            this.setFolderButton.Location = new System.Drawing.Point(447, 54);
            this.setFolderButton.Name = "setFolderButton";
            this.setFolderButton.Size = new System.Drawing.Size(75, 21);
            this.setFolderButton.TabIndex = 3;
            this.setFolderButton.Text = "Set";
            this.setFolderButton.UseVisualStyleBackColor = true;
            this.setFolderButton.Click += new System.EventHandler(this.setFolderButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Your Config Files";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-14, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(560, 2);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // moveOverConfigs
            // 
            this.moveOverConfigs.AutoSize = true;
            this.moveOverConfigs.Location = new System.Drawing.Point(12, 330);
            this.moveOverConfigs.Name = "moveOverConfigs";
            this.moveOverConfigs.Size = new System.Drawing.Size(259, 17);
            this.moveOverConfigs.TabIndex = 11;
            this.moveOverConfigs.Text = "Also move over Config files from the Config folder.";
            this.moveOverConfigs.UseVisualStyleBackColor = true;
            this.moveOverConfigs.CheckedChanged += new System.EventHandler(this.moveOverConfigs_CheckedChanged);
            // 
            // moveOverMods
            // 
            this.moveOverMods.AutoSize = true;
            this.moveOverMods.Location = new System.Drawing.Point(12, 353);
            this.moveOverMods.Name = "moveOverMods";
            this.moveOverMods.Size = new System.Drawing.Size(218, 17);
            this.moveOverMods.TabIndex = 12;
            this.moveOverMods.Text = "Also move .zip/.jar files from Mods folder.";
            this.moveOverMods.UseVisualStyleBackColor = true;
            this.moveOverMods.CheckedChanged += new System.EventHandler(this.moveOverMods_CheckedChanged);
            // 
            // editConfigBtn
            // 
            this.editConfigBtn.Enabled = false;
            this.editConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editConfigBtn.Location = new System.Drawing.Point(88, 287);
            this.editConfigBtn.Name = "editConfigBtn";
            this.editConfigBtn.Size = new System.Drawing.Size(51, 23);
            this.editConfigBtn.TabIndex = 15;
            this.editConfigBtn.Text = "Edit";
            this.editConfigBtn.UseVisualStyleBackColor = true;
            this.editConfigBtn.Click += new System.EventHandler(this.editConfigBtn_Click);
            // 
            // removeConfigBtn
            // 
            this.removeConfigBtn.Enabled = false;
            this.removeConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.removeConfigBtn.Location = new System.Drawing.Point(50, 287);
            this.removeConfigBtn.Name = "removeConfigBtn";
            this.removeConfigBtn.Size = new System.Drawing.Size(32, 23);
            this.removeConfigBtn.TabIndex = 14;
            this.removeConfigBtn.Text = "-";
            this.removeConfigBtn.UseVisualStyleBackColor = true;
            this.removeConfigBtn.Click += new System.EventHandler(this.removeConfigBtn_Click);
            // 
            // addConfigBtn
            // 
            this.addConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addConfigBtn.Location = new System.Drawing.Point(12, 287);
            this.addConfigBtn.Name = "addConfigBtn";
            this.addConfigBtn.Size = new System.Drawing.Size(32, 23);
            this.addConfigBtn.TabIndex = 13;
            this.addConfigBtn.Text = "+";
            this.addConfigBtn.UseVisualStyleBackColor = true;
            this.addConfigBtn.Click += new System.EventHandler(this.addConfigBtn_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(-14, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(560, 2);
            this.label4.TabIndex = 16;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(-13, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(560, 2);
            this.label5.TabIndex = 17;
            this.label5.Text = "label5";
            // 
            // performUpdateBtn
            // 
            this.performUpdateBtn.Location = new System.Drawing.Point(217, 386);
            this.performUpdateBtn.Name = "performUpdateBtn";
            this.performUpdateBtn.Size = new System.Drawing.Size(100, 30);
            this.performUpdateBtn.TabIndex = 18;
            this.performUpdateBtn.Text = "Perform Update";
            this.performUpdateBtn.UseVisualStyleBackColor = true;
            this.performUpdateBtn.Click += new System.EventHandler(this.performUpdate_Click);
            // 
            // ModdedMinecraftConfigHandlerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 429);
            this.Controls.Add(this.performUpdateBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.editConfigBtn);
            this.Controls.Add(this.removeConfigBtn);
            this.Controls.Add(this.addConfigBtn);
            this.Controls.Add(this.moveOverMods);
            this.Controls.Add(this.moveOverConfigs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.setFolderButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.configChangesList);
            this.Name = "ModdedMinecraftConfigHandlerMainForm";
            this.Text = "Modded Minecraft Config Handler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView configChangesList;
        private System.Windows.Forms.ColumnHeader inConfigFile;
        private System.Windows.Forms.ColumnHeader textVar;
        private System.Windows.Forms.ColumnHeader changeTo;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setFolderButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox moveOverConfigs;
        private System.Windows.Forms.CheckBox moveOverMods;
        private System.Windows.Forms.Button editConfigBtn;
        private System.Windows.Forms.Button removeConfigBtn;
        private System.Windows.Forms.Button addConfigBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button performUpdateBtn;
        private System.Windows.Forms.ColumnHeader inConfigFileFullPath;
    }
}

