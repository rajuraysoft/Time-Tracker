namespace ScreenCapture
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOnoffline = new System.Windows.Forms.Label();
            this.timer_idle = new System.Windows.Forms.Timer(this.components);
            this.cboxProject = new System.Windows.Forms.ComboBox();
            this.lblProjectid = new System.Windows.Forms.Label();
            this.timer_Currenttime = new System.Windows.Forms.Timer(this.components);
            this.lblStarttime = new System.Windows.Forms.Label();
            this.lblCurrenttime = new System.Windows.Forms.Label();
            this.lblTodayTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblLasttime = new System.Windows.Forms.Label();
            this.timer_onoffbuttonevent = new System.Windows.Forms.Timer(this.components);
            this.txtProject = new CustomControls.RJControls.RJTextBox();
            this.btnlogout = new System.Windows.Forms.Button();
            this.pboxLSC = new System.Windows.Forms.PictureBox();
            this.bthonoff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLSC)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Location = new System.Drawing.Point(6, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 3);
            this.panel3.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(14, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current Session";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(14, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Today";
            // 
            // lblOnoffline
            // 
            this.lblOnoffline.AutoSize = true;
            this.lblOnoffline.ForeColor = System.Drawing.Color.DimGray;
            this.lblOnoffline.Location = new System.Drawing.Point(249, 128);
            this.lblOnoffline.Name = "lblOnoffline";
            this.lblOnoffline.Size = new System.Drawing.Size(44, 16);
            this.lblOnoffline.TabIndex = 11;
            this.lblOnoffline.Text = "Online";
            // 
            // timer_idle
            // 
            this.timer_idle.Tick += new System.EventHandler(this.timer_idle_Tick);
            // 
            // cboxProject
            // 
            this.cboxProject.FormattingEnabled = true;
            this.cboxProject.Location = new System.Drawing.Point(7, 16);
            this.cboxProject.Name = "cboxProject";
            this.cboxProject.Size = new System.Drawing.Size(317, 24);
            this.cboxProject.TabIndex = 13;
            this.cboxProject.SelectedIndexChanged += new System.EventHandler(this.cboxProject_SelectedIndexChanged);
            // 
            // lblProjectid
            // 
            this.lblProjectid.AutoSize = true;
            this.lblProjectid.Location = new System.Drawing.Point(281, 43);
            this.lblProjectid.Name = "lblProjectid";
            this.lblProjectid.Size = new System.Drawing.Size(12, 16);
            this.lblProjectid.TabIndex = 15;
            this.lblProjectid.Text = ".";
            this.lblProjectid.Visible = false;
            // 
            // timer_Currenttime
            // 
            this.timer_Currenttime.Tick += new System.EventHandler(this.timer_Currenttime_Tick);
            // 
            // lblStarttime
            // 
            this.lblStarttime.AutoSize = true;
            this.lblStarttime.Location = new System.Drawing.Point(119, 128);
            this.lblStarttime.Name = "lblStarttime";
            this.lblStarttime.Size = new System.Drawing.Size(12, 16);
            this.lblStarttime.TabIndex = 16;
            this.lblStarttime.Text = ".";
            this.lblStarttime.Visible = false;
            // 
            // lblCurrenttime
            // 
            this.lblCurrenttime.AutoSize = true;
            this.lblCurrenttime.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrenttime.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrenttime.Location = new System.Drawing.Point(19, 154);
            this.lblCurrenttime.Name = "lblCurrenttime";
            this.lblCurrenttime.Size = new System.Drawing.Size(122, 25);
            this.lblCurrenttime.TabIndex = 17;
            this.lblCurrenttime.Text = "0 hrs 00 m";
            // 
            // lblTodayTime
            // 
            this.lblTodayTime.AutoSize = true;
            this.lblTodayTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTodayTime.Location = new System.Drawing.Point(19, 208);
            this.lblTodayTime.Name = "lblTodayTime";
            this.lblTodayTime.Size = new System.Drawing.Size(75, 19);
            this.lblTodayTime.TabIndex = 18;
            this.lblTodayTime.Text = "0:00 hrs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(14, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Latest screen capture";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(6, 444);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 3);
            this.panel1.TabIndex = 9;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.DimGray;
            this.lblUser.Location = new System.Drawing.Point(21, 465);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(16, 16);
            this.lblUser.TabIndex = 21;
            this.lblUser.Text = "..";
            // 
            // lblLasttime
            // 
            this.lblLasttime.AutoSize = true;
            this.lblLasttime.ForeColor = System.Drawing.Color.DimGray;
            this.lblLasttime.Location = new System.Drawing.Point(177, 266);
            this.lblLasttime.Name = "lblLasttime";
            this.lblLasttime.Size = new System.Drawing.Size(12, 16);
            this.lblLasttime.TabIndex = 23;
            this.lblLasttime.Text = ".";
            // 
            // timer_onoffbuttonevent
            // 
            this.timer_onoffbuttonevent.Tick += new System.EventHandler(this.timer_onoffbuttonevent_Tick);
            // 
            // txtProject
            // 
            this.txtProject.BackColor = System.Drawing.Color.White;
            this.txtProject.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtProject.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtProject.BorderRadius = 0;
            this.txtProject.BorderSize = 2;
            this.txtProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProject.ForeColor = System.Drawing.Color.Black;
            this.txtProject.Location = new System.Drawing.Point(7, 58);
            this.txtProject.Margin = new System.Windows.Forms.Padding(4);
            this.txtProject.Multiline = true;
            this.txtProject.Name = "txtProject";
            this.txtProject.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtProject.PasswordChar = false;
            this.txtProject.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtProject.PlaceholderText = "";
            this.txtProject.Size = new System.Drawing.Size(317, 46);
            this.txtProject.TabIndex = 25;
            this.txtProject.Texts = "";
            this.txtProject.UnderlinedStyle = false;
            this.txtProject.Leave += new System.EventHandler(this.txtProject_Leave);
            this.txtProject._TextChanged += new System.EventHandler(this.txtProject__TextChanged);
            this.txtProject.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProject_KeyUp);
            this.txtProject.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProject_KeyPress);
            // 
            // btnlogout
            // 
            this.btnlogout.BackgroundImage = global::ScreenCapture.Properties.Resources.logout;
            this.btnlogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnlogout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnlogout.FlatAppearance.BorderSize = 0;
            this.btnlogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnlogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Location = new System.Drawing.Point(238, 462);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(83, 27);
            this.btnlogout.TabIndex = 22;
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // pboxLSC
            // 
            this.pboxLSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxLSC.Location = new System.Drawing.Point(17, 285);
            this.pboxLSC.Name = "pboxLSC";
            this.pboxLSC.Size = new System.Drawing.Size(294, 134);
            this.pboxLSC.TabIndex = 20;
            this.pboxLSC.TabStop = false;
            // 
            // bthonoff
            // 
            this.bthonoff.BackColor = System.Drawing.Color.White;
            this.bthonoff.BackgroundImage = global::ScreenCapture.Properties.Resources.off;
            this.bthonoff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bthonoff.FlatAppearance.BorderSize = 0;
            this.bthonoff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bthonoff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bthonoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthonoff.Location = new System.Drawing.Point(226, 147);
            this.bthonoff.Name = "bthonoff";
            this.bthonoff.Size = new System.Drawing.Size(85, 42);
            this.bthonoff.TabIndex = 12;
            this.bthonoff.UseVisualStyleBackColor = false;
            this.bthonoff.Click += new System.EventHandler(this.bthonoff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(331, 501);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.lblLasttime);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pboxLSC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTodayTime);
            this.Controls.Add(this.lblCurrenttime);
            this.Controls.Add(this.lblStarttime);
            this.Controls.Add(this.lblProjectid);
            this.Controls.Add(this.cboxProject);
            this.Controls.Add(this.bthonoff);
            this.Controls.Add(this.lblOnoffline);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLSC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOnoffline;
        private System.Windows.Forms.Button bthonoff;
        private System.Windows.Forms.Timer timer_idle;
        private System.Windows.Forms.ComboBox cboxProject;
        private System.Windows.Forms.Label lblProjectid;
        private System.Windows.Forms.Timer timer_Currenttime;
        private System.Windows.Forms.Label lblStarttime;
        private System.Windows.Forms.Label lblCurrenttime;
        private System.Windows.Forms.Label lblTodayTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pboxLSC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Label lblLasttime;
        private System.Windows.Forms.Timer timer_onoffbuttonevent;
        private CustomControls.RJControls.RJTextBox txtProject;
    }
}

