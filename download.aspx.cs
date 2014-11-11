using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Ionic.Zip;
using System.Security.Cryptography;
using System.Text;

namespace DownloadApp
{
    public partial class download : System.Web.UI.Page
    {
        static string Password, year, month, day, extractTo;

        protected void Page_Load(object sender, EventArgs e)
        {
            //string Today = GetCurrentDate().ToString();
            Download dl = new Download();
            extractTo = @"C:\DEBUG\" + year + " - " + month + " - " + day + ".zip";
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

        }

    }
}