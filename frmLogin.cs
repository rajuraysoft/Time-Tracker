using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;

namespace ScreenCapture
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        string sConn = "", sConnLive="";
        MySqlConnection connection, connectionLive;
        MySqlCommand oCommand, oCommandLive;
        
        MySqlDataAdapter adapter;
        DataSet dsResult2 = new DataSet();

        string susername = "", spassword = "", sUserid = "", sCurrentVersion = "";
        protected override void OnResize(EventArgs e)
        {
            //297,448 
            this.Width = 353;
            this.Height = 515; 
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            staticstring.sConnString = staticstring.ConnectionCheck();
            sConn = staticstring.sConnString;
            sConnLive = staticstring.sConnStringLive;

            System.Net.ServicePointManager.Expect100Continue = false;  //Unable to write data to the transport connection an existing connection was forcibly closed by the remote host
            connection = new MySqlConnection(sConn);
            connectionLive = new MySqlConnection(sConnLive);

            label2.Text = "© Copyright " + DateTime.Now.Year + " by";

            string sversion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            lblVer.Text = "Ver " + sversion;

            dsResult2 = new DataSet();

            /* oCommand = new MySqlCommand();
             oCommand.CommandText = "SELECT * FROM tbl_timetracker ";
             oCommand.Connection = connection;
             if (oCommand.Connection.State == ConnectionState.Closed)
             {
                     oCommand.Connection.Open();
             }

             string slver = oCommand.ExecuteScalar().ToString();
             */

            try
            {
                oCommand = new MySqlCommand();
                oCommand.CommandText = "SELECT * FROM tbl_timetracker_setting";
                oCommand.Connection = connection;
                if (oCommand.Connection.State == ConnectionState.Closed)
                {
                    oCommand.Connection.Open();
                }
                MySqlDataAdapter da1 = new MySqlDataAdapter(oCommand);
                dsResult2 = new DataSet();
                da1.Fill(dsResult2);
                if (dsResult2 != null && dsResult2.Tables.Count > 0 && dsResult2.Tables[0].Rows.Count > 0)
                {
                    staticstring.screenshotallow = dsResult2.Tables[0].Rows[0]["screenshotallow"].ToString();
                    staticstring.screenshotuploadonline = dsResult2.Tables[0].Rows[0]["screenshotuploadonline"].ToString();
                    sCurrentVersion = dsResult2.Tables[0].Rows[0]["timetracker_ver"].ToString();

                    staticstring.FTPAddress = dsResult2.Tables[0].Rows[0]["FTPAddress"].ToString();                    
                    staticstring.FTPusername = dsResult2.Tables[0].Rows[0]["FTPusername"].ToString();
                    staticstring.FTPpassword = dsResult2.Tables[0].Rows[0]["FTPpassword"].ToString();

                }
                oCommand.Connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Time tracker",  MessageBoxButtons.OK);
            }


            if (sCurrentVersion != sversion)
            {
                notifyIcon1.Icon = new System.Drawing.Icon(Application.StartupPath + "\\notification-icons.ico");
                notifyIcon1.Text = "Time Tracker";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Time Tracker";
                notifyIcon1.BalloonTipText = " New version Available, kindly update";
                notifyIcon1.ShowBalloonTip(50000);


            }
        }

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://raysoftindia.com/");
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            susername = ""; spassword = ""; StringBuilder sb = new StringBuilder(); lblError.Visible = false;
            if (string.IsNullOrEmpty(txtusername.Texts.Trim()) || txtusername.Texts.Trim() == "Enter Username")
            {
                errorProvider1.SetError(pictureBox2, "Enter Username Name");
            }
            else
            {
                susername = txtusername.Texts.Trim();
            }
            if (string.IsNullOrEmpty(txtpassword.Texts.Trim()) || txtpassword.Texts.Trim() == "Enter Password")
            {
                errorProvider2.SetError(pictureBox3, "Please Enter Password");
            }
            else
            {
                spassword = MD5Hash(txtpassword.Texts.Trim());
            }
            if (susername != "" && spassword != "")
            {
                DataSet dsResult1 = new DataSet();

                try
                {
                    
                    /*sb.AppendLine("SELECT tbl_users.id,firstname,lastname , tbl_attendance.id AS attendance_id");
                    sb.AppendLine("FROM tbl_users");
                    sb.AppendLine("LEFT JOIN `tbl_attendance` ON tbl_attendance.userid=tbl_users.id AND tbl_attendance.date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                    sb.AppendLine("WHERE email_id='" + susername + "' AND password='" + spassword + "' AND status=1");
                    */

                    sb.AppendLine("SELECT * FROM tbl_users WHERE email_id='" + susername + "' AND password='" + spassword + "' AND status=1");
                   
                    
                    oCommand = new MySqlCommand();
                    oCommand.CommandText = sb.ToString();
                    oCommand.Connection = connection;
                    if (oCommand.Connection.State == ConnectionState.Closed)
                    {
                        oCommand.Connection.Open();
                    }
                    MySqlDataAdapter da = new MySqlDataAdapter(oCommand);

                    da.Fill(dsResult1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (dsResult1 != null && dsResult1.Tables.Count > 0 && dsResult1.Tables[0].Rows.Count > 0)
                {

                    
                    sUserid = dsResult1.Tables[0].Rows[0]["id"].ToString();
                    
                    if (!string.IsNullOrEmpty(sUserid) && sUserid != "0")
                    {
                        string sRole = dsResult1.Tables[0].Rows[0]["role"].ToString();
                        sb = new StringBuilder();
                        sb.Append("SELECT COUNT(*) AS countattendance FROM tbl_attendance WHERE userid=" + sUserid + " AND tbl_attendance.date='"+DateTime.Now.ToString("yyyy-MM-dd")+"'");
                        

                        oCommandLive = new MySqlCommand();
                        oCommandLive.CommandText = sb.ToString();
                        oCommandLive.Connection = connectionLive;
                        if (oCommandLive.Connection.State == ConnectionState.Closed)
                        {
                            oCommandLive.Connection.Open();
                        }

                        int countattendance = Convert.ToInt32(oCommandLive.ExecuteScalar().ToString());
                        if (countattendance > 0)
                        {

                            staticstring.susername = dsResult1.Tables[0].Rows[0]["firstname"].ToString() + " " + dsResult1.Tables[0].Rows[0]["lastname"].ToString();
                            staticstring.sUserid = sUserid;

                            this.Hide();
                            Form1 form1 = new Form1();
                            form1.Show();
                        }
                        else
                        {
                            lblError.Visible = true;
                        }
                        oCommandLive.Connection.Close();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Email or password.", "Raysoft Time Tracker");
                }
            }
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtusername.Text.Trim()))
            {
                errorProvider1.Clear(); lblError.Visible = false;
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpassword.Text.Trim()))
            {
                errorProvider2.Clear(); lblError.Visible = false;
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text.Trim()))
            {
                txtusername.Text = "Enter Username";
            }
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtusername.Text == "Enter Username")
            {
                txtusername.Text = "";
            }
            if ((e.KeyChar == 13))
            {
                btnlogin_Click(null, null);
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpassword.Text == "Enter Password")
            {
                txtpassword.Text = "";
            }
            if ((e.KeyChar == 13))
            {
                btnlogin_Click(null, null);
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpassword.Text.Trim()))
            {
                txtpassword.Text = "Enter Password";
            }
        }

        private void btnlogin_Paint(object sender, PaintEventArgs e)
        {
           
        }

        

      


    }
}
