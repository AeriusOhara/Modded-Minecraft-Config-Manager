namespace Modded_Minecraft_Updater
{
    partial class addEditConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.configFileTextBox = new System.Windows.Forms.TextBox();
            this.setConfigFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.variableTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.replaceValueTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Config File:";
            // 
            // configFileTextBox
            // 
            this.configFileTextBox.Location = new System.Drawing.Point(12, 70);
            this.configFileTextBox.Name = "configFileTextBox";
            this.configFileTextBox.ReadOnly = true;
            this.configFileTextBox.Size = new System.Drawing.Size(151, 20);
            this.configFileTextBox.TabIndex = 3;
            this.configFileTextBox.TextChanged += new System.EventHandler(this.configFileTextBox_TextChanged);
            // 
            // setConfigFile
            // 
            this.setConfigFile.Location = new System.Drawing.Point(169, 70);
            this.setConfigFile.Name = "setConfigFile";
            this.setConfigFile.Size = new System.Drawing.Size(45, 20);
            this.setConfigFile.TabIndex = 4;
            this.setConfigFile.Text = "Set";
            this.setConfigFile.UseVisualStyleBackColor = true;
            this.setConfigFile.Click += new System.EventHandler(this.setConfigFile_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-14, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 2);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Setup your Config file change";
            // 
            // variableTextBox
            // 
            this.variableTextBox.Location = new System.Drawing.Point(12, 114);
            this.variableTextBox.Name = "variableTextBox";
            this.variableTextBox.Size = new System.Drawing.Size(202, 20);
            this.variableTextBox.TabIndex = 14;
            this.variableTextBox.TextChanged += new System.EventHandler(this.variableTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Find Variable with this text:";
            // 
            // replaceValueTextBox
            // 
            this.replaceValueTextBox.Location = new System.Drawing.Point(12, 159);
            this.replaceValueTextBox.Name = "replaceValueTextBox";
            this.replaceValueTextBox.Size = new System.Drawing.Size(202, 20);
            this.replaceValueTextBox.TabIndex = 16;
            this.replaceValueTextBox.TextChanged += new System.EventHandler(this.replaceValueTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Replace the variable\'s value with:";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 196);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(-8, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 2);
            this.label5.TabIndex = 18;
            this.label5.Text = "label5";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(197, 196);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // addEditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 237);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.replaceValueTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.variableTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.setConfigFile);
            this.Controls.Add(this.configFileTextBox);
            this.Controls.Add(this.label1);
            this.Name = "addEditConfig";
            this.Text = "Setup Config File";
            this.Load += new System.EventHandler(this.addEditConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox configFileTextBox;
        private System.Windows.Forms.Button setConfigFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox variableTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox replaceValueTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
    }
}