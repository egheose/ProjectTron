using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DownloadApp
{
    public class SearchLogic : Connect
    {
        public SearchLogic()
        {

        }

        //Method to perform database(record) search
        public void recordSearch(string value)
        {
            try
            {
                MyGlobals.datatableGlobal.Clear();//Clears global datatable
                query = "select * from XXX where ID='" + value + "'";
                //Run query against all database servers and save result in Global datatable
                MyGlobals.datatableGlobal = QueryMultiplyDBServers();
                conn.Close();
            }
            catch (Exception ex)
            {
                MyGlobals.err_Message = "RS - " + ex.Message.ToString();//MyGlobals Class stores global variables and is located in the Root.master.cs file
                HttpContext.Current.Response.Redirect("error.aspx");
                return;
            }
        }

        //Method to perform database(Bulk) search
        public void recordSearch(string[] BulkQuery)
        {
            try
            {
                MyGlobals.datatableGlobal.Clear();//Clears global datatable
                foreach (string value in BulkQuery)
                {
                    query = "select * from XXX where ID='" + value + "'";
                    //Run query against all database servers and save result in Global datatable
                    MyGlobals.datatableGlobal = QueryMultiplyDBServers();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MyGlobals.err_Message = "BRS - " +ex.Message.ToString();//MyGlobals Class stores global variables and is located in the Root.master.cs file
                HttpContext.Current.Response.Redirect("error.aspx");
                return;
            }
        }

        //Method to perform file searching
        public void FileSearch(string filename)
        {
            MyGlobals.datatableGlobal.Clear();//Clears global datatable
        }

        public void AdvancedSearch()
        {
            MyGlobals.datatableGlobal.Clear();//Clears global datatable
        }
    }
}