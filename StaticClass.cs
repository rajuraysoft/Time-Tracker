using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Configuration;

namespace ScreenCapture
{
    class StaticClass
    {
    }
    public static class staticstring
    {
        //Live DB
        

        //Time tracker DB
        public static string sConnString = "";

        //PMS live DB
        public static string sConnStringLive = "";

        public static string susername = "";
        public static string spassword = "";
        public static string sUserid = "";
        public static string screenshotallow = "";
        public static string screenshotuploadonline = "";
        public static string slocalFilename = Application.StartupPath + "\\log.ray";
        public static string scurrenttime = "";
        public static string FTPAddress,  FTPusername, FTPpassword = "";


        #region
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file

            //string key = (string)settingsReader.GetValue("SecurityKeyWithValue",typeof(String));

            string key = "";

            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            //string key = (string)settingsReader.GetValue("SecurityKey",typeof(String));

            string key = "RaysoftIndia2017";

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        public static string ConnectionCheck()
        {
            sConnString = "";
            //MessageBox.Show("u1");

            string pathToExe = Application.StartupPath + "\\ScreenCapture.exe.config";
            if (string.IsNullOrEmpty(pathToExe))
            {
                MessageBox.Show("Please Install UpworkRunningNotification EXE", "UpworkRunningNotification - SQl server check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (File.Exists(pathToExe))
            {
                sConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Timetracker"].ToString();
                sConnStringLive = System.Configuration.ConfigurationManager.ConnectionStrings["pms"].ToString();
               /* XmlDocument objXmlDoc = new XmlDocument();
                objXmlDoc.Load(pathToExe);
                XmlElement objElement = objXmlDoc.DocumentElement;
                XmlNode objAppSettingNode = objElement.SelectSingleNode("connectionStrings");
                foreach (XmlNode appSetting in objAppSettingNode)
                {
                    if (appSetting.Name.Equals("add"))
                    {
                        string Con = appSetting.Attributes["connectionString"].Value;
                        string sServer = "", sDatabase = "", sUser = "", sPassword = "";
                        string[] ss = Regex.Split(Con, ";");
                        if (ss.Length > 0)
                        {
                            string s1 = ss[0].Replace("SERVER=", "");
                            if (!string.IsNullOrEmpty(s1))
                            {
                                //sServer = DataEncrypterDecrypter.CryptoEngine.Decrypt(s1, staticstring.sKey);                            
                                sServer =s1;
                            }
                            else
                            {
                                sServer = "";
                            }

                            //MessageBox.Show("Server: " + sServer);

                            s1 = ss[1].Replace("Database=", "");
                            if (!string.IsNullOrEmpty(s1))
                            {
                                //sDatabase = DataEncrypterDecrypter.CryptoEngine.Decrypt(s1, staticstring.sKey);
                                sDatabase =s1;
                            }
                            else
                            {
                                sDatabase = "";
                            }
                            //MessageBox.Show("sDatabase: " + sDatabase);

                            s1 = ss[2].Replace("uid=", "");
                            if (!string.IsNullOrEmpty(s1))
                            {
                                //sUser = DataEncrypterDecrypter.CryptoEngine.Decrypt(s1, staticstring.sKey);
                                sUser =s1;
                            }
                            else
                            {
                                sUser = "";
                            }

                            // MessageBox.Show("sUser: " + sUser);

                            s1 = ss[3].Replace("Pwd=", "");

                            if (!string.IsNullOrEmpty(s1))
                            {
                                //sPassword = DataEncrypterDecrypter.CryptoEngine.Decrypt(s1, staticstring.sKey);
                                sPassword = s1;
                            }
                            else
                            {
                                sPassword = "";
                            }

                            // MessageBox.Show("sPassword: " + sPassword);


                            sConnString = "SERVER=" + sServer + ";Database=" + sDatabase + ";uid=" + sUser + ";Pwd=" + sPassword + ";;Convert Zero Datetime=true;";
                            

                        }

                    }
                }*/
            }
            return sConnString;
        }

        public static bool IsFileinUse(string filepath)
        {
            FileInfo file = new FileInfo(filepath);   
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
    }
}
