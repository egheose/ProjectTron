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
            MyGlobals.lstSQLConStr.Clear();
            lblNotFound.Visible = false;
            //Add All database connection string here
            //MyGlobals.lstSQLConStr.Add(@"Server=172.16.2.54;Database=myDataBase;User Id=samuel;Password=Codename47;");//RLSR-CRPDB-01
            MyGlobals.lstSQLConStr.Add(@"Server=172.16.2.55;Database=crdb;User Id=samuel;Password=Codename47!;");//RLSR-CRPDB-02
            //MyGlobals.lstSQLConStr.Add(@"Server=172.16.2.56;Database=hubdb;User Id=samuel;Password=Codename47;");//RLSR-HUB-01
            //MyGlobals.lstSQLConStr.Add(@"Server=172.16.2.57;Database=hubdb;User Id=samuel;Password=Codename47;");//RLSR-HUB-02
            //MyGlobals.lstSQLConStr.Add(@"Server=172.16.2.58;Database=hubdb;User Id=samuel;Password=Codename47;");//RLSR-HUB-03
            //MyGlobals.lstSQLConStr.Add(@"Server=172.16.2.59;Database=hubdb;User Id=samuel;Password=Codename47;");//RLSR-HUB-04
            MyGlobals.lstSQLConStr.Add(@"Server=172.16.2.60;Database=hubdb;User Id=samuel;Password=Codename47!;");//RLSR-HUB-05
        }

        protected void btnRsearch_Click(object sender, EventArgs e)
        {
            lblNotFound.Visible = false;
            MyGlobals.datatableGlobal.Clear();//Clears global datatable

            if (!isSearchFieldEmpty())
            {
                resultGrid.DataSource = MyGlobals.datatableGlobal;
                if (tbSearch.Text.Contains(','))
                {
                    string input = tbSearch.Text;
                    if (input.EndsWith(","))
                    {
                        input = input.TrimEnd(',');
                    }
                    string[] query = Regex.Split(input, ",");
                    sl.recordSearch(query);
                    BindData();
                    if (resultGrid.Rows.Count < 1 && MyGlobals.datatableGlobal.Rows.Count < 1)
                    {
                        lblNotFound.Text = "<br/><br/><br/><br/><br/><br/><br/><br/><br/>   No Record(s) Found.";
                        lblNotFound.Visible = true; lblNotFound.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    string input = tbSearch.Text;
                    if (input.EndsWith(","))
                    {
                        input = input.TrimEnd(',');
                    }
                    sl.recordSearch(input.Trim());
                    BindData();
                    if (resultGrid.Rows.Count < 1)
                    {
                        lblNotFound.Text = "<br/><br/><br/><br/><br/><br/><br/><br/><br/>   No Record(s) Found.";
                        lblNotFound.Visible = true; lblNotFound.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void BindData()
        {
            try
            {

                resultGrid.DataSource = MyGlobals.datatableGlobal;
                resultGrid.DataBind();
            }
            catch (OutOfMemoryException)
            {
                lblNotFound.Text = "<br/><br/><br/><br/><br/><br/><br/><br/><br/>   Maximum Result Set Exceeded - Your search returned over 100,000 records and has maxed out memory, Please narrow your search and try again";
                lblNotFound.Visible = true; lblNotFound.ForeColor = System.Drawing.Color.Red;
            }
        }
        private bool isSearchFieldEmpty()
        {
            if (tbSearch.Text == "")
            {
                lblNotFound.Text = "<br/><br/><br/><br/><br/><br/><br/><br/><br/> <br/><br/>    (Search Field Cannot Be Empty) - No Record(s) Found";
                lblNotFound.Visible = true; lblNotFound.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void resultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            resultGrid.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void lnkbtnAdvSearch_Click(object sender, EventArgs e)
        {
            SearchPanel.Visible = false;
            advSearchPanel.Visible = true;
        }

        protected void linkBtnNormalSearch_Click(object sender, EventArgs e)
        {
            SearchPanel.Visible = true;
            advSearchPanel.Visible = false;
        }

        protected void btnAdvSearch_Click(object sender, EventArgs e)
        {
            lblNF.Visible = false;
            MyGlobals.datatableGlobal.Clear();//Clears global datatable

            if (!isAllSearchFieldEmpty())
            {
                resultGrid.DataSource = MyGlobals.datatableGlobal;
                string[] input = { tbSurname.Text, tbMname.Text, tbFname.Text, tbPhone.Text, tbCompany.Text, tbDOB.Text };
                sl.AdvancedSearch(input);
                BindData_Adv();
                    if (advResultGrid.Rows.Count < 1)
                    {
                        lblNF.Text = "<br/><br/>  No Record(s) Found.";
                        lblNF.Visible = true; lblNF.ForeColor = System.Drawing.Color.Red;
                    }
            }
        }

        private void BindData_Adv()
        {            
                try
            {

                advResultGrid.DataSource = MyGlobals.datatableGlobal;
                advResultGrid.DataBind();
            }
            catch (OutOfMemoryException)
            {
                lblNF.Text = "  Maximum Result Set Exceeded - Your search returned over 100,000 records and has maxed out memory, Please narrow your search and try again";
                lblNF.Visible = true; lblNF.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool isAllSearchFieldEmpty()
        {
            if (tbSurname.Text == "" && tbFname.Text == "" && tbMname.Text == "" && tbCompany.Text == ""
                && tbDOB.Text == "" && tbPhone.Text == "")
            {
                lblNF.Text = @"(All Search Fields Cannot Be Empty) - At Least one is required";
                lblNF.Visible = true; lblNF.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void advResultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            advResultGrid.PageIndex = e.NewPageIndex;
            BindData_Adv();
        }
    }
}