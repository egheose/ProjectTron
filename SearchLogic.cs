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
        public void recordSearch(string query)
        {
            MyGlobals.datatableGlobal.Clear();//Clears global datatable
        }

        //Method to perform database(Bulk) search
        public void recordSearch(string[] BulkQuery)
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