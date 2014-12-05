using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DownloadApp 
{
    public partial class _Default : System.Web.UI.Page 
    {
        Connect cn = new Connect();
        protected void Page_Load(object sender, EventArgs e) 
        {
            //try
            //{
            //    cn.query = " select top 1 [id],[filename],[status],[Exception],[date] from Utilities.dbo.Log order by id desc";

            //    cn.db = "log";
            //    cn.read(); cn.run();
            //    if (cn.datreader.HasRows)
            //    {
            //        while (cn.datreader.Read())
            //        {
            //            lblStatus.Text = cn.datreader["status"].ToString().ToUpper();
            //            lblFilename.Text = cn.datreader["filename"].ToString() + ".zip";
            //            lblDate.Text = cn.datreader["date"].ToString();

            //        }
            //    }

            //    cn.conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MyGlobals.err_Message = ex.Message.ToString();
            //    Message((ex.Message.ToString().Substring(0,5)) +"...");
            //}
        }

        public void Message(String msg)
        {
            string script = "window.onload = function(){ alert('";
            script += msg;
            script += "');";
            script += "window.location = 'error.aspx";
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }
    }
}