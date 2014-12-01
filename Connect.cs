using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace DownloadApp
{

    public class Connect
    {
        public SqlConnection conn,sqlCon;
        public SqlCommand com, comm,sqlCmd;
        public SqlDataReader datreader;
        public SqlDataAdapter da;
        public DataSet ds;
        public string query = "";
        public string db = "";
        public DataTable dtResult;

        public Connect()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["log"].ConnectionString);//("Data Source=localhost;Initial Catalog=Utilities;Integrated Security=True");
            ds = new DataSet();
            da = new SqlDataAdapter();
            dtResult = new DataTable();
        }

        public void read()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            //Opens Connection
            conn.Open();
            comm = conn.CreateCommand();
            comm.Connection = conn;
            comm.CommandText = query;
        }

        public void read2()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            try
            {
                //Opens Connection
                conn.Open();
                com = new SqlCommand(query, conn);
            }
            catch (SqlException ex)
            {
                MyGlobals.err_Message = ex.Message.ToString();//MyGlobals Class stores global variables and is located in the Root.master.cs file
                HttpContext.Current.Response.Redirect("error.aspx");
                return;
            }
        }
        public void run()
        {
            da.SelectCommand = comm;
            da.Fill(ds, db);

            datreader = comm.ExecuteReader();
        }
        public void run2()
        {
            datreader = comm.ExecuteReader();
        }

        public DataTable QueryMultiplyDBServers()
        {
            DataTable result = new DataTable();
            if (conn.State == ConnectionState.Open)
                conn.Close();

            try
            {
                for (int i = 0; i < MyGlobals.lstSQLConStr.Count; i++)
                {
                    using (sqlCon = new SqlConnection(MyGlobals.lstSQLConStr[i]))
                    {
                        sqlCon.Open();

                        using (sqlCmd = new SqlCommand(query, sqlCon))
                        {
                            sqlCmd.CommandType = CommandType.Text;

                            using (SqlDataReader dataReader = sqlCmd.ExecuteReader())
                            {
                                result.Load(dataReader);
                            }
                        }
                    }
                }//End For loop
            }
            catch (SqlException ex)
            {
                MyGlobals.err_Message = ex.Message.ToString();//MyGlobals Class stores global variables and is located in the Root.master.cs file
                HttpContext.Current.Response.Redirect("error.aspx");
            }
            return result;
        }//End QueryMultipleDBServers
    }
}