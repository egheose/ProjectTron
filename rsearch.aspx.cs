using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DownloadApp
{
    public partial class rsearch : System.Web.UI.Page
    {
            SearchLogic sl=new SearchLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRsearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Contains(',') || tbSearch.Text.Length > 15)
            {
                string[] query = Regex.Split(tbSearch.Text, ",");
                sl.recordSearch(query);
                resultGrid.DataSource = MyGlobals.datatableGlobal;
            }
            else
            {
                sl.recordSearch(tbSearch.Text.Trim());
                resultGrid.DataSource = MyGlobals.datatableGlobal;
            }
        }
    }
}