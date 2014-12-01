using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using System.Data;

namespace DownloadApp {
    public partial class RootMaster : System.Web.UI.MasterPage 
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            ASPxSplitter1.GetPaneByName("Header").Size = ASPxWebControl.GlobalTheme == "Moderno" ? 95 : 83;
            ASPxSplitter1.GetPaneByName("Header").MinSize = ASPxWebControl.GlobalTheme == "Moderno" ? 95 : 83;
            ASPxLabel2.Text = DateTime.Now.Year + Server.HtmlDecode(" &copy; Copyright by [Lasrra & Dimension Data]");
        }
    }
        public static class MyGlobals
        {
            //public const int Total = 5; // cannot change because it's a const 
            public static string err_Message = "ID_"; // Stores error message thrown from any page           
            public static List<string> lstSQLConStr = new List<string>();//stores All database connection settings
            public static DataTable datatableGlobal = new DataTable();
        }
}