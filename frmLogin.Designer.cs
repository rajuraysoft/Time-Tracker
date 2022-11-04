namespace ScreenCapture
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblError = new System.Windows.Forms.Label();
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            this.txtpassword = new CustomControls.RJControls.RJTextBox();
            this.txtusername = new CustomControls.RJControls.RJTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log in and get to work";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(12, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 37);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ScreenCapture.Properties.Resources.user3;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 29);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.Controls.Add(this.txtpassword);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(12, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 37);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::ScreenCapture.Properties.Resources.password1;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 29);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(4, 350);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 3);
            this.panel3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "© Copyright 2020 by";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "All Rights Reserved.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(186, 400);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(116, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = " Raysoft Technologies.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(64, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Raysoft Technologies";
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.Location = new System.Drawing.Point(157, 377);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(23, 13);
            this.lblVer.TabIndex = 12;
            this.lblVer.Text = "Ver";
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.White;
            this.btnlogin.BackgroundImage = global::ScreenCapture.Properties.Resources.login;
            this.btnlogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnlogin.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(4, 387);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(57, 26);
            this.btnlogin.TabIndex = 6;
            this.btnlogin.Text = "       Login";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Visible = false;
            this.btnlogin.Paint += new System.Windows.Forms.PaintEventHandler(this.btnlogin_Paint);
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ScreenCapture.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(138, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 54);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblError.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(55, 295);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(227, 51);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "Kindly check-in  your attendance \r\n       (check-in is missing) \r\n      and use y" +
                "our tracker.";
            this.lblError.Visible = false;
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.DarkBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.DarkBlue;
            this.rjButton1.BackgroundImage = global::ScreenCapture.Properties.Resources.login;
            this.rjButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton1.BorderColor = System.Drawing.Color.Purple;
            this.rjButton1.BorderRadius = 15;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(75, 255);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(186, 37);
            this.rjButton1.TabIndex = 13;
            this.rjButton1.Text = "  Login";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseCompatibleTextRendering = true;
            this.rjButton1.UseVisualStyleBackColor = true;
            this.rjButton1.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.Color.White;
            this.txtpassword.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtpassword.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtpassword.BorderRadius = 10;
            this.txtpassword.BorderSize = 2;
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.Color.Black;
            this.txtpassword.Location = new System.Drawing.Point(36, 4);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtpassword.Multiline = false;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtpassword.PasswordChar = true;
            this.txtpassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtpassword.PlaceholderText = "";
            this.txtpassword.Size = new System.Drawing.Size(273, 31);
            this.txtpassword.TabIndex = 5;
            this.txtpassword.Texts = "Enter Password";
            this.txtpassword.UnderlinedStyle = false;
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            this.txtpassword._TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // txtusername
            // 
            this.txtusername.BackColor = System.Drawing.Color.White;
            this.txtusername.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtusername.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtusername.BorderRadius = 10;
            this.txtusername.BorderSize = 2;
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.ForeColor = System.Drawing.Color.Black;
            this.txtusername.Location = new System.Drawing.Point(36, 3);
            this.txtusername.Margin = new System.Windows.Forms.Padding(4);
            this.txtusername.Multiline = false;
            this.txtusername.Name = "txtusername";
            this.txtusername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtusername.PasswordChar = false;
            this.txtusername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtusername.PlaceholderText = "";
            this.txtusername.Size = new System.Drawing.Size(273, 31);
            this.txtusername.TabIndex = 4;
            this.txtusername.Texts = "Enter Username";
            this.txtusername.UnderlinedStyle = false;
            this.txtusername.Leave += new System.EventHandler(this.txtusername_Leave);
            this.txtusername._TextChanged += new System.EventHandler(this.txtusername_TextChanged);
            this.txtusername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusername_KeyPress);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(337, 476);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Raysoft";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVer;
        private CustomControls.RJControls.RJButton rjButton1;
        private CustomControls.RJControls.RJTextBox txtusername;
        private CustomControls.RJControls.RJTextBox txtpassword;
        private System.Windows.Forms.Label lblError;
    }
}