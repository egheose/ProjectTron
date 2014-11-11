using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Ionic.Zip;
using System.IO;

namespace DownloadApp
{
    class Extract : Download
    {
        Connect cn = new Connect();
        public void ExtractFile()
        {
            string zipToUnpack = @"C:\DEBUG\" + year + "-" + month + "-" + day + ".zip";
            string unpackDirectory = @"C:\DEBUG\" + year + "-" + month + "-" + day;//Extracted Files";
            using (MD5 md5Hash = MD5.Create())
            {
                Password = GetMd5Hash(md5Hash, year + "l4ssra" + month + "lasrr4" + day);
            }
            try
            {
                using (ZipFile zip = ZipFile.Read(zipToUnpack))
                {
                    //Loops throgh zipfile and extrats & decrypt all contents
                    foreach (ZipEntry e in zip)
                    {
                        try
                        {
                            e.ExtractWithPassword(unpackDirectory, Password);
                        }
                        catch (ZipException ex)
                        {
                            //Log exception
                            string err = ex.Message;
                            err = Regex.Replace(err, "'@][+", " ");
                            //Log Exception
                            cn.query = "insert into Utilities.dbo.Log values('" + zipToUnpack + "','Error','" + err + "','" + DateTime.Now.ToString() + "')";
                            cn.read(); cn.run2();
                            cn.conn.Close();
                            return;
                        }
                    }
                }
            }
            catch(Exception Filex)
            {
                string err = Filex.Message;
                err = Regex.Replace(err, "'@][+", " ");
                //Log Exception
                cn.query = "insert into Utilities.dbo.Log values('" + zipToUnpack + "','Error','" + err + "','" + DateTime.Now.ToString() + "')";
                cn.read(); cn.run2();
                cn.conn.Close();
            }
            finally
            {
                DeleteZip(downloadPath);
                Environment.Exit(0);
            }
        }


        public void ExtractFile(string file)
        {
            string zipToUnpack = @"C:\DEBUG\" + file + ".zip";
            string unpackDirectory = @"C:\DEBUG\" + file;//Extracted Files";

            string[] s_dt = Regex.Split(file, "-");
            using (MD5 md5Hash = MD5.Create())
            {
                Password = s_dt[0] + "l4ssra" + s_dt[1] + "lasrr4" + Int32.Parse(s_dt[2]);
                //Password = Regex.Replace(Password, "@'+0", " ");
                Password = GetMd5Hash(md5Hash, s_dt[0] + "l4ssra" + s_dt[1] + "lasrr4" + Int32.Parse(s_dt[2]));
            }
            try
            {
                using (ZipFile zip = ZipFile.Read(zipToUnpack))
                {
                    //Loops throgh zipfile and extrats & decrypt all contents
                    foreach (ZipEntry e in zip)
                    {
                        e.ExtractWithPassword(unpackDirectory, ExtractExistingFileAction.OverwriteSilently, Password);
                    }
                }
            }
            catch (Exception Filex)
            {
                string err = Filex.Message;
                err = Regex.Replace(err, "'@][+", " ");
                //Log Exception
                cn.query = "insert into Utilities.dbo.Log values('" + zipToUnpack + "','Error','" + err + "','" + DateTime.Now.ToString() + "')";
                cn.read(); cn.run2();
                cn.conn.Close();
            }
            finally
            {
                DeleteZip(downloadPath);
                Environment.Exit(0);
            }
        }
    }
}
