using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Ionic.Zip;
using System.Net;
using System.ComponentModel;
using System.IO;

namespace DownloadApp
{
    class Download : Connect
    {
       public static string Password, year, month, day;
       public static string downloadPath;
       public static string filename;
       public static string[] e_dt;
       public static string[] s_dt;
       public int[] sd = new int[3] { 0, 0, 0 }; int cnt1, cnt2 = 0;
       public int[] ed = new int[3] { 0, 0, 0 };


       public Download()
       {
           
       }

       
       public Download(DateTime st, DateTime en)
       {
           int interval = 1;
           //foreach (DateTime day in EachDay(st, en))
           for (DateTime dateTime = st; dateTime <= en; dateTime += TimeSpan.FromDays(interval))
           {
               filename = Regex.Replace(dateTime.ToString("yyyy-MM-dd"), "/", "-");
               downloadPath = @"C:\DEBUG\" + filename + ".zip";
               DownLoadFileInBackground("http://registration.lagosresidents.gov.ng/data/C615C710E503E0F5702F6EE8DD79F6EF/" + filename);
               Extract exFile = new Extract();
               exFile.ExtractFile(dateTime.ToString("yyyy-MM-dd"));
              
           }
           
           
       }
       public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
       {
           for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
               yield return day;
       }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

       public void GetDateRange(string from, string to)
        {
            s_dt = Regex.Split(from, "-");
            foreach (string val in s_dt)
            {
                sd[cnt1] = Int32.Parse(val);
                cnt1++;
            }


            e_dt = Regex.Split(to, "-");
            foreach (string value in e_dt)
            {
                ed[cnt2] = Int32.Parse(value);
                cnt2++;

            }
        }

       public static AutoResetEvent ma = new AutoResetEvent(false);
       // Sample call : DownLoadFileInBackground (URL);
       public void DownLoadFileInBackground(string address)
       {
           try
           {
               WebClient client = new WebClient();
               Uri uri = new Uri(address);
               client.DownloadFile(uri, downloadPath);
               //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback);


               //Log Failure
               query = "insert into Utilities.dbo.Log values('" + filename + "','Success'," + null + ",'" + DateTime.Now.ToString() + "')";
               read(); run2();
               conn.Close();
               return;
           }
           catch (Exception e)
           {
               string err = e.Message;
               err = Regex.Replace(err, @"\'+", " ");
               //Log Failure
               query = "insert into Utilities.dbo.Log values('" + filename + "','Failed','" + err + "','" + DateTime.Now.ToString() + "')";
               read(); run2();
               conn.Close();
               return;
           }
       }

       static int count, cnt = 0;
       private void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)
       {
           if (e.Error != null)
           {
               count++;
               if (count <= 1)
               {
                   string err = e.Error.Message;
                   err = Regex.Replace(err, "'+", " ");
                   //Log Failure
                   query = "insert into Utilities.dbo.Log values('" + filename + "','Failed','" + err + "','" + DateTime.Now.ToString() + "')";
                   read(); run2();
                   conn.Close();
               }
           }
           else if (!e.Cancelled)
           {
               cnt++;
               if (cnt <= 1)
               {
                   //Log Success
                   query = "insert into Utilities.dbo.Log values('" + filename + "','Passed','" + null + "','" + DateTime.Now.ToString() + "')";
                   read(); run2();
                   conn.Close();
               }
           }
           return;
       }

       public static void DeleteZip(string ZipToDelete)
       {
           File.Delete(ZipToDelete);
       }
    }
}