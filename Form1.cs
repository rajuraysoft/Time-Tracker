using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Net;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Diagnostics; // Idle check
using System.Drawing.Imaging; // Image resize


namespace ScreenCapture
{
    public partial class Form1 : Form
    {
        //System Start Up 
        RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);  // check windows is run

        // Idle check
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);


        //Local Value
        string sConn = staticstring.sConnString;
        MySqlConnection connection;
        MySqlCommand oCommand;


        MySqlDataAdapter adapter;
        Random rand = new Random();
        string username = "", sbtnonoff = "off", savepath = "";  //scurrenttime = "",
        string tslastworkingtime = "00:00:00";
        int iIdleTime = 0, iInsertid = 0, idletime = 5, screenshottime1 = 5, screenshottime2 = 9;



        internal struct LASTINPUTINFO //Idle Time local value
        {
            public uint cbSize;

            public uint dwTime;
        }

        public Form1()
        {

            reg.SetValue("ScreenCapture.exe", Application.ExecutablePath); // if windows is run my app (ScreenCapture) is run    

            InitializeComponent();
        }

        protected override void OnResize(EventArgs e) //Screen size fixed
        {
            this.Width = 347;
            this.Height = 539;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Visible = false; pboxLSC.Visible = false;
            connection = new MySqlConnection(sConn);

            lblOnoffline.Text = "Offline"; staticstring.scurrenttime = "";
            bthonoff.BackgroundImage = Properties.Resources.off;

            bthonoff.Visible = false; //Select Project after enable

            lblUser.Text = staticstring.susername;

            //this.Opacity = 0; // Form display hide

            //this.ShowInTaskbar = false; // Hide taskbar

            username = staticstring.susername;

            getproject();
            //getuser();

            SetFolderPermission();
            //CaptureMyScreen();

            getidletime_screenshot();


        }

        private void cboxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtProject.MaximumSize = new Size(250, 0);
            //txtProject.AutoSize = true;

            lblProjectid.Text = cboxProject.SelectedValue.ToString();

            if (lblProjectid.Text.ToString() == "0" || lblProjectid.Text.ToString() == "-1")
            {
                txtProject.Texts = "";
            }


            if (cboxProject.Text.ToString() != "Select Project" && lblProjectid.Text.ToString() != "-1")
            {
                if ((lblProjectid.Text.ToString() == "0" || lblProjectid.Text.ToString() == "-1")  && string.IsNullOrEmpty(txtProject.Texts.Trim()))
                {
                    txtProject.Enabled = true; //txtProject.ActiveControl = null;
                }
                else
                {
                    txtProject.Enabled = false;
                }

                if (lblProjectid.Text.ToString() == "0" && string.IsNullOrEmpty(txtProject.Text.Trim()))
                {
                    bthonoff.Visible = false;
                }
                else
                {
                    txtProject.Texts = cboxProject.Text;
                    bthonoff.Visible = true; txtProject.Enabled = false;
                }
            }
            else
            {
                txtProject.Texts = ""; txtProject.Enabled = true;
                bthonoff.Visible = false;

            }
        }


        private void bthonoff_Click(object sender, EventArgs e)
        {
            if (sbtnonoff == "off")
            {
                //sbtnonoff = "on"; lblOnoffline.Text = "Online";
                bthonoff.BackgroundImage = Properties.Resources.on;
                cboxProject.Enabled = false; txtProject.Enabled = true;
            }
            else
            {
                //sbtnonoff = "off"; lblOnoffline.Text = "Offline";
                bthonoff.BackgroundImage = Properties.Resources.off;
                cboxProject.Enabled = true; 
            }

            timer_onoffbuttonevent.Enabled = true; timer_onoffbuttonevent.Interval = 1000;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            CaptureMyScreen();
        }
        private void timer_idle_Tick(object sender, EventArgs e)
        {
            if (sbtnonoff == "on")
            {
                if (GetIdleTime() > idletime)  //5000 is 5 5 secc
                {
                    //iIdleTime = iIdleTime + 5000;
                    staticstring.scurrenttime = DateTime.Now.ToString();
                }
            }
        }



        public void getproject()
        {
            try
            {
                string calculate_date = DateTime.Now.ToString("yyyy-MM-dd");
                oCommand = new MySqlCommand();
                //oCommand.CommandText = "SELECT Project_name,id FROM`tbl_projects` WHERE active_status=1 ORDER BY  id DESC LIMIT 500";
                oCommand.CommandText = "SELECT id,Project_Name FROM tbl_projects WHERE Start_Date<='" + calculate_date + "' AND Actual_TD>='" + calculate_date + "' AND active_status=1 ORDER BY id DESC";
                oCommand.Connection = connection;
                if (oCommand.Connection.State == ConnectionState.Closed)
                {
                    oCommand.Connection.Open();
                }
                MySqlDataAdapter da = new MySqlDataAdapter(oCommand);
                DataTable dtable = new DataTable();
                DataSet dsResult1 = new DataSet();

                da.Fill(dtable);
                DataView dv = dtable.DefaultView;
                dv.Sort = "Project_name asc";

                DataTable sortedDT = dv.ToTable();
                DataRow dr = sortedDT.NewRow();
                dr[0] = -1;
                dr[1] = "Select Project";
                sortedDT.Rows.InsertAt(dr, 0);
                dr = sortedDT.NewRow();
                dr[0] = 0;
                dr[1] = "Others";
                sortedDT.Rows.InsertAt(dr, 1);
                dr = sortedDT.NewRow();
                dr[0] = 1;
                dr[1] = "BD Work";
                sortedDT.Rows.InsertAt(dr, 2);

                da.Fill(dsResult1);
                if (dsResult1 != null && dsResult1.Tables.Count > 0 && dsResult1.Tables[0].Rows.Count > 0)
                {
                    cboxProject.ValueMember = "id";

                    cboxProject.DisplayMember = "Project_name";
                    cboxProject.DataSource = sortedDT;



                }

                oCommand.Connection.Close();
            }
            catch
            {
            }
        }

        public void getidletime_screenshot()
        {
            try
            {
                oCommand = new MySqlCommand();
                oCommand.CommandText = "SELECT * FROM`tbl_idletime_screenshot`";
                oCommand.Connection = connection;
                if (oCommand.Connection.State == ConnectionState.Closed)
                {
                    oCommand.Connection.Open();
                }
                MySqlDataAdapter da = new MySqlDataAdapter(oCommand);

                DataSet dsResult1 = new DataSet();

                da.Fill(dsResult1);

                if (dsResult1 != null && dsResult1.Tables.Count > 0 && dsResult1.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dsResult1.Tables[0].Rows[0]["idletime"].ToString()))
                    {
                        idletime = (Convert.ToInt32(dsResult1.Tables[0].Rows[0]["idletime"].ToString()) * 60 * 1000);
                    }
                    if (!string.IsNullOrEmpty(dsResult1.Tables[0].Rows[0]["screenshot_time1"].ToString()))
                    {
                        screenshottime1 = (Convert.ToInt32(dsResult1.Tables[0].Rows[0]["screenshot_time1"].ToString()) * 60 * 1000);
                    }
                    if (!string.IsNullOrEmpty(dsResult1.Tables[0].Rows[0]["screenshot_time2"].ToString()))
                    {
                        screenshottime2 = (Convert.ToInt32(dsResult1.Tables[0].Rows[0]["screenshot_time2"].ToString()) * 60 * 1000);
                    }

                }

                oCommand.Connection.Close();
            }
            catch
            {
            }
        }
        public void getuser()
        {
            string sfile = Application.StartupPath + "\\ScreenCaptureun.csharp";
            bool exists = System.IO.Directory.Exists(sfile);
            if (!exists)
            {
                string[] lines = System.IO.File.ReadAllLines(sfile);
                if (lines.Length > 0)
                {
                    username = lines[0].ToLower().Replace("name:", "").Trim();
                }
            }
        }
        public void SetFolderPermission()
        {
            try
            {
                string sfolder = Application.StartupPath + "\\images";
                bool exists = System.IO.Directory.Exists(sfolder);
                if (!exists)
                {
                    DirectoryInfo di = System.IO.Directory.CreateDirectory(sfolder);


                    var directoryInfo = new DirectoryInfo(sfolder);
                    var directorySecurity = directoryInfo.GetAccessControl();
                    var currentUserIdentity = WindowsIdentity.GetCurrent();
                    var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                                  FileSystemRights.FullControl,
                                                                  InheritanceFlags.ObjectInherit |
                                                                  InheritanceFlags.ContainerInherit,
                                                                  PropagationFlags.None,
                                                                  AccessControlType.Allow);

                    directorySecurity.AddAccessRule(fileSystemRule);
                    directoryInfo.SetAccessControl(directorySecurity);
                }
            }
            catch
            {
            }

        }

        private void CaptureMyScreen()
        {

            try
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                //Creating a new Bitmap object

                Bitmap captureBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);


                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);

                //Creating a Rectangle object which will  

                //capture our Current Screen

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;



                //Creating a New Graphics Object

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);



                //Copying Image from The Screen

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);



                //Saving the Image File (I am here Saving it in My E drive).
                savepath = "";
                savepath = Application.StartupPath + "\\images\\" + staticstring.sUserid + "_" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH-mm-ss") + ".jpg";
                captureBitmap.Save(savepath, ImageFormat.Jpeg);

                image_size_reduce(savepath); //image resize

                pboxLSC.BackgroundImage = (Image)captureBitmap;

                label1.Visible = true; pboxLSC.Visible = true;
                lblLasttime.Text = DateTime.Now.ToString("HH:mm:ss");

                if (staticstring.screenshotuploadonline == "1")
                {
                    // File Uplad FTP 
                    
                    uploadFile(staticstring.FTPAddress, savepath, staticstring.FTPusername, staticstring.FTPpassword);

                    File.Delete(savepath); // Local File Del
                }

                int fortimerinterval = rand.Next(screenshottime1, screenshottime2); // take screenshot 5 min to 9 min random Time 

                timer1.Enabled = true;
                timer1.Interval = fortimerinterval;


            }

            catch (Exception ex)
            {

                string s = ex.Message;
                //MessageBox.Show(ex.Message);

            }

        }

        private void uploadFile(string FTPAddress, string filePath, string username, string password)
        {
            try
            {
                //Create FTP request
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;

                //Load the file
                FileStream stream = File.OpenRead(filePath);
                byte[] buffer = new byte[stream.Length];

                stream.Read(buffer, 0, buffer.Length);
                stream.Close();

                //Upload file
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();

                //MessageBox.Show("Uploaded Successfully");
            }
            catch
            {
            }
        }

        public void start_workTime(string button)
        {
            if (sbtnonoff == "on")
            {
                timer_Currenttime.Enabled = true;
                timer_Currenttime.Interval = 1000;

                timer_idle.Start();
            }
        }

        public static uint GetIdleTime()
        {
            LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
            LastUserAction.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(LastUserAction);
            GetLastInputInfo(ref LastUserAction);
            return ((uint)Environment.TickCount - LastUserAction.dwTime);
        }

        private void timer_Currenttime_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt1 = DateTime.Parse(staticstring.scurrenttime);
                DateTime dt2 = DateTime.Parse(DateTime.Now.ToString());
                TimeSpan span = dt2 - dt1;
                staticstring.scurrenttime = dt2.ToString();

                TimeSpan dt3 = TimeSpan.Parse(span.ToString()) + TimeSpan.Parse(tslastworkingtime);
                if (span.Seconds > 55)
                {
                    string ss = "";
                }
                tslastworkingtime = dt3.ToString();
                lblCurrenttime.Text = dt3.Hours.ToString("00") + " hrs " + dt3.Minutes.ToString("00") + " m";

                string stime = "";
                try
                {
                    // Get total Time
                    oCommand = new MySqlCommand();
                    oCommand.CommandText = "SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(totaltime))),'%H:%i' ) as time FROM  `tbl_timetracking` where userid=" + staticstring.sUserid + " and date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    oCommand.Connection = connection;
                    if (oCommand.Connection.State == ConnectionState.Closed)
                    {
                        oCommand.Connection.Open();
                    }
                    stime = oCommand.ExecuteScalar().ToString();
                }
                catch
                {
                    if (oCommand.Connection.State == ConnectionState.Open)
                    {
                        oCommand.Connection.Close();
                    }
                }
                if (string.IsNullOrEmpty(stime))
                {
                    lblTodayTime.Text = dt3.Hours.ToString("00") + ":" + dt3.Minutes.ToString("00") + " hrs";
                }
                else
                {
                    lblTodayTime.Text = stime + " hrs";
                }


                oCommand.Connection.Close();

                start_workTime(sbtnonoff);
            }
            catch
            {
                try
                {
                    if (oCommand.Connection.State == ConnectionState.Open)
                    {
                        oCommand.Connection.Close();
                    }
                }
                catch
                {
                }
            }

            start_workTime(sbtnonoff);
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (sbtnonoff == "on")
                {
                    timer_Currenttime.Enabled = false;
                    timer1.Enabled = false;

                    //Kill 
                    try
                    {
                        
                        foreach (var process in Process.GetProcesses())
                        {
                            if (process.ProcessName.Contains("InterceptKeys"))
                            {
                                process.Kill(); break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string sException = ex.Message;
                    }

                    string slog = "";
                    if (File.Exists(Application.StartupPath + "\\images\\log.ray"))
                    {   
                        try
                        {
                            //Read Log File

                            foreach (var process in Process.GetProcesses())
                            {
                                if (process.MainWindowTitle.Contains("log.ray"))
                                {
                                    process.Kill(); break;
                                }
                            }


                            StreamReader sr = new StreamReader(Application.StartupPath + "\\images\\log.ray");
                            slog = sr.ReadToEnd().ToString().Replace("'", "''"); sr.Close();
                            //,keylog='"+slog.Replace("'","''")+"'
                            //Delete Log File
                            File.Delete(Application.StartupPath + "\\images\\log.ray");
                        }
                        catch (Exception ex)
                        {
                            string sException = ex.Message;
                        }

                        oCommand = new MySqlCommand();
                        oCommand.CommandText = "select count(*) as totalcount from tbl_keylog  where id_timetracking=" + iInsertid;
                        oCommand.Connection = connection;
                        if (oCommand.Connection.State == ConnectionState.Closed)
                        {
                            oCommand.Connection.Open();
                        }
                        object result = oCommand.ExecuteScalar();
                        int icount = Convert.ToInt32(result);

                        oCommand.Connection = connection;
                        if (oCommand.Connection.State == ConnectionState.Closed)
                        {
                            oCommand.Connection.Open();
                        }
                        if (icount == 0 && !string.IsNullOrEmpty(slog))
                        {
                            oCommand.CommandText = "Insert into tbl_keylog (id_timetracking,keylog) values(" + iInsertid + ",'" + slog + "');";
                            oCommand.ExecuteNonQuery();
                        }
                        else if (icount >0 && !string.IsNullOrEmpty(slog))
                        {
                            oCommand.CommandText = "Update tbl_keylog set keylog='"+slog.Replace("'","''")+" where id_timetracking="+ iInsertid ;
                            oCommand.ExecuteNonQuery();
                        }

                        oCommand.Connection.Close();
                        
                    }

                    oCommand = new MySqlCommand();
                    oCommand.CommandText = "Update tbl_timetracking set endtime='" + DateTime.Now.ToString("HH:mm:ss") + "',totalTime='" + tslastworkingtime + "' where id=" + iInsertid;
                    oCommand.Connection = connection;
                    if (oCommand.Connection.State == ConnectionState.Closed)
                    {
                        oCommand.Connection.Open();
                    }
                    oCommand.ExecuteNonQuery();

                    oCommand.Connection.Close();
                }
                sbtnonoff = "off";
                Application.Exit();
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnlogout_Click(null, null);
        }

        private void timer_onoffbuttonevent_Tick(object sender, EventArgs e)
        {
            timer_onoffbuttonevent.Enabled = false;
            if (sbtnonoff == "off")
            {
                sbtnonoff = "on"; lblOnoffline.Text = "Online";
                //bthonoff.BackgroundImage = Properties.Resources.on;

                lblStarttime.Text = DateTime.Now.ToString("HH:mm:ss"); staticstring.scurrenttime = DateTime.Now.ToString();

                try
                {
                    //Insert DB
                    oCommand = new MySqlCommand();
                    oCommand.CommandText = "insert into tbl_timetracking (userid,projectid,date,starttime,projectname ) values(" + staticstring.sUserid + "," + lblProjectid.Text + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + lblStarttime.Text + "','" + txtProject.Texts.ToString().Replace("'", "''") + "');";
                    oCommand.Connection = connection;

                    if (oCommand.Connection.State == ConnectionState.Closed)
                    {
                        oCommand.Connection.Open();
                    }
                    oCommand.ExecuteNonQuery();
                    iInsertid = (int)oCommand.LastInsertedId;
                    oCommand.Connection.Close();

                    timer_Currenttime.Enabled = true;
                    timer_Currenttime.Interval = 1000;

                    if (staticstring.screenshotallow == "1")
                    {
                        CaptureMyScreen();
                    }

                    //Key hook software start
                    Process.Start(Application.StartupPath + "\\InterceptKeys.exe");

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Id   " + iInsertid);
                    sb.AppendLine("Userid   " + staticstring.sUserid);
                    sb.AppendLine("Username   " + staticstring.susername);
                    sb.AppendLine("Projectid   " + lblProjectid.Text);

                }
                catch
                {
                    try
                    {
                        if (oCommand.Connection.State == ConnectionState.Open)
                        {
                            oCommand.Connection.Close();
                        }
                    }
                    catch
                    {

                    }
                }

            }
            else
            {
                try
                {
                    sbtnonoff = "off"; lblOnoffline.Text = "Offline";
                    //bthonoff.BackgroundImage = Properties.Resources.off;


                    timer_Currenttime.Enabled = false;
                    timer1.Enabled = false;


                    oCommand = new MySqlCommand();
                    oCommand.CommandText = "Update tbl_timetracking set endtime='" + DateTime.Now.ToString("HH:mm:ss") + "',totalTime='" + tslastworkingtime + "' where id=" + iInsertid;
                    oCommand.Connection = connection;
                    if (oCommand.Connection.State == ConnectionState.Closed)
                    {
                        oCommand.Connection.Open();
                    }
                    oCommand.ExecuteNonQuery();

                    //oCommand.Connection.Close();

                    staticstring.scurrenttime = "00:00:00"; tslastworkingtime = "00:00:00"; lblCurrenttime.Text = "00 hrs 0 m";

                    

                    try
                    {
                        //Read Log File
                        StreamReader sr = new StreamReader(Application.StartupPath + "\\images\\log.ray");

                        string slog = sr.ReadToEnd().ToString().Replace("'", "''"); sr.Close();
                        //Insert Log File
                        oCommand.CommandText = "Insert into tbl_keylog (id_timetracking,keylog) values(" + iInsertid + ",'" + slog + "');";
                        oCommand.Connection = connection;
                        if (oCommand.Connection.State == ConnectionState.Closed)
                        {
                            oCommand.Connection.Open();
                        }
                        oCommand.ExecuteNonQuery();
                        oCommand.Connection.Close();

                        foreach (var process in Process.GetProcesses())
                        {
                            if (process.MainWindowTitle.Contains("log.ray"))
                            {
                                process.Kill(); break;
                            }
                        }

                        //Delete Log File
                        File.Delete(Application.StartupPath + "\\images\\log.ray");
                    }
                    catch (Exception ex)
                    {
                        string sException = ex.Message;
                    }


                    Process[] workers = Process.GetProcessesByName("InterceptKeys");
                    foreach (Process worker in workers)
                    {
                        worker.Kill();
                        worker.WaitForExit();
                        worker.Dispose();
                    }


                }
                catch
                {
                    try
                    {
                        if (oCommand.Connection.State == ConnectionState.Open)
                        {
                            oCommand.Connection.Close();

                        }

                        oCommand = new MySqlCommand();
                        oCommand.CommandText = "Update tbl_timetracking set endtime='" + DateTime.Now.ToString("HH:mm:ss") + "',totalTime='" + tslastworkingtime + "' where id=" + iInsertid;
                        oCommand.Connection = connection;
                        if (oCommand.Connection.State == ConnectionState.Closed)
                        {
                            oCommand.Connection.Open();
                        }
                        oCommand.ExecuteNonQuery();

                        oCommand.Connection.Close();

                        staticstring.scurrenttime = "00:00:00"; tslastworkingtime = "00:00:00"; lblCurrenttime.Text = "00 hrs 0 m";
                    }
                    catch
                    {
                    }
                }
            }
            start_workTime(sbtnonoff);
        }

        #region image_size_reduce
        public void image_size_reduce(string sfilepath)
        {
            try
            {
                using (Bitmap bmp1 = new Bitmap(sfilepath))
                {

                    Bitmap bmp2 = new Bitmap(bmp1);
                    bmp1.Dispose();
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                    // Create an Encoder object based on the GUID  
                    // for the Quality parameter category.  
                    System.Drawing.Imaging.Encoder myEncoder =
                        System.Drawing.Imaging.Encoder.Quality;

                    // Create an EncoderParameters object.  
                    // An EncoderParameters object has an array of EncoderParameter  
                    // objects. In this case, there is only one  
                    // EncoderParameter object in the array.  
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    bmp2.Save(sfilepath, jpgEncoder, myEncoderParameters);
                }
            }
            catch
            {
            }
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        #endregion image_size_reduce

        private void txtProject_Leave(object sender, EventArgs e)
        {
            if (lblProjectid.Text.ToString() == "0" && !string.IsNullOrEmpty(txtProject.Texts.Trim()))
            {
                bthonoff.Visible = true;
            }
        }

        private void txtProject_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblProjectid.Text.ToString() == "0" && !string.IsNullOrEmpty(txtProject.Texts.Trim()))
            {
                bthonoff.Visible = true;
            }
        }

        private void txtProject_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtProject__TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProject.Texts.Trim()))
            {
                bthonoff.Visible = false; //Select Project after enable
            }
            else
            {
                bthonoff.Visible = true; //Select Project after enable
            }
        }

        private void btnReloadproject_Click(object sender, EventArgs e)
        {

        }

       

        
    }
}

