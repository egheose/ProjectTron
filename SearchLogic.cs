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
                query = @"select ID,SURNAME,FIRSTNAME, MIDDLENAME,PRIMARY_PHONE_NO,OCCUPATION,DATE_BIRTH from Resident_info where ID LIKE '%"+value +"%'";
                //Run query against all database servers and save result in Global datatable
                MyGlobals.datatableGlobal = QueryMultiplyDBServers();
                conn.Close();
                return;
            }
            catch (TimeoutException ex)
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
                    query = @"select ID,SURNAME,FIRSTNAME, MIDDLENAME,PRIMARY_PHONE_NO,OCCUPATION,DATE_BIRTH from Resident_info where ID LIKE '%" + value + "%'";
                    //Run query against all database servers and save result in Global datatable
                    MyGlobals.datatableGlobal = QueryMultiplyDBServers();
                }
                    conn.Close();
                    return;
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
            try
            {
                MyGlobals.datatableGlobal.Clear();//Clears global datatable
                query = @"select HOSTNAME,ID ,SURNAME,FIRSTNAME, MIDDLENAME,PRIMARY_PHONE_NO,OCCUPATION from resident_info where ID IN ('" + filename + "');";
                //Run query against all database servers and save result in Global datatable
                MyGlobals.datatableGlobal = QueryMultiplyDBServers();
                conn.Close();
                return;
            }
            catch (TimeoutException ex)
            {
                MyGlobals.err_Message = "FS - " + ex.Message.ToString();//MyGlobals Class stores global variables and is located in the Root.master.cs file
                HttpContext.Current.Response.Redirect("error.aspx");
                return;
            }
        }

        //Overloaded Method to perform Multiple file search
        public void FileSearch(string[] filename)
        {
            try
            {
                MyGlobals.datatableGlobal.Clear();//Clears global datatable
                foreach (string value in filename)
                {
                    query = @"select HOSTNAME,ID ,SURNAME,FIRSTNAME, MIDDLENAME from resident_info where ID IN ('" + value + "');";
                    //Run query against all database servers and save result in Global datatable
                    MyGlobals.datatableGlobal.Rows.Add(QueryMultiplyDBServers());
                }
                conn.Close();
                return;
            }
            catch (Exception ex)
            {
                MyGlobals.err_Message = "BFS - " + ex.Message.ToString();//MyGlobals Class stores global variables and is located in the Root.master.cs file
                HttpContext.Current.Response.Redirect("error.aspx");
                return;
            }
        }

        public void AdvancedSearch()
        {
            MyGlobals.datatableGlobal.Clear();//Clears global datatable
        }
    }
}