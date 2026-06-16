namespace QuizApp
{
    partial class AdminLogin
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.textBox3 = new MetroFramework.Controls.MetroTextBox();
            this.textBox4 = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Location = new System.Drawing.Point(406, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 312);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 30);
            this.button1.Style = MetroFramework.MetroColorStyle.Teal;
            this.button1.TabIndex = 2;
            this.button1.Text = "Login";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Login";
            // 
            // textBox3
            // 
            // 
            // 
            // 
            this.textBox3.CustomButton.Image = null;
            this.textBox3.CustomButton.Location = new System.Drawing.Point(154, 2);
            this.textBox3.CustomButton.Name = "";
            this.textBox3.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox3.CustomButton.TabIndex = 1;
            this.textBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox3.CustomButton.UseSelectable = true;
            this.textBox3.CustomButton.Visible = false;
            this.textBox3.Lines = new string[0];
            this.textBox3.Location = new System.Drawing.Point(95, 151);
            this.textBox3.MaxLength = 32767;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '●';
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox3.SelectedText = "";
            this.textBox3.SelectionLength = 0;
            this.textBox3.SelectionStart = 0;
            this.textBox3.ShortcutsEnabled = true;
            this.textBox3.Size = new System.Drawing.Size(172, 20);
            this.textBox3.Style = MetroFramework.MetroColorStyle.Teal;
            this.textBox3.TabIndex = 0;
            this.textBox3.UseSelectable = true;
            this.textBox3.UseSystemPasswordChar = true;
            this.textBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox4
            // 
            // 
            // 
            // 
            this.textBox4.CustomButton.Image = null;
            this.textBox4.CustomButton.Location = new System.Drawing.Point(154, 2);
            this.textBox4.CustomButton.Name = "";
            this.textBox4.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox4.CustomButton.TabIndex = 1;
            this.textBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox4.CustomButton.UseSelectable = true;
            this.textBox4.CustomButton.Visible = false;
            this.textBox4.Lines = new string[0];
            this.textBox4.Location = new System.Drawing.Point(95, 81);
            this.textBox4.MaxLength = 32767;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox4.SelectedText = "";
            this.textBox4.SelectionLength = 0;
            this.textBox4.SelectionStart = 0;
            this.textBox4.ShortcutsEnabled = true;
            this.textBox4.Size = new System.Drawing.Size(172, 20);
            this.textBox4.Style = MetroFramework.MetroColorStyle.Teal;
            this.textBox4.TabIndex = 0;
            this.textBox4.UseSelectable = true;
            this.textBox4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::QuizApp.Properties.Resources.management_consulting;
            this.pictureBox1.Location = new System.Drawing.Point(62, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 312);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AdminLogin";
            this.Text = "AdminLogin";
            this.Load += new System.EventHandler(this.AdminLogin_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroTextBox textBox3;
        private MetroFramework.Controls.MetroTextBox textBox4;
        private MetroFramework.Controls.MetroButton button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroLabel label2;
    }
}