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
        static string Password, f_date,t_date, extractTo;
        Download dl = new Download();

        protected void Page_Load(object sender, EventArgs e)
        {
            //string Today = GetCurrentDate().ToString();
            //extractTo = @"C:\DEBUG\" +f_date + ".zip";
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DateTime from_dt = Convert.ToDateTime(ASPxDateEdit1.Text);
            DateTime to_dt = Convert.ToDateTime(ASPxDateEdit2.Text);
            f_date = from_dt.ToString("yyyy-MM-dd");//date from
            t_date = to_dt.ToString("yyyy-MM-dd");//date to
            ASPxLabel5.Text = from_dt.ToString("yyyy-MM-dd") + to_dt.ToString("yyyy-MM-dd");

            // 1. Pass from date and to date to Download overloaded constructor
            dl.GetDateRange(f_date, t_date);

            dl = new Download(new DateTime(dl.sd[0], dl.sd[1], dl.sd[2]), new DateTime(dl.ed[0], dl.ed[1], dl.ed[2]));
        }

    }
}