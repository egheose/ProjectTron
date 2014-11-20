using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Connect
{
    public SqlConnection conn;
    public SqlCommand com,comm;
    public SqlDataReader datreader;
    public SqlDataAdapter da;
    public DataSet ds;
    public string query = "";
    public string db = "";
	public Connect()
	{
        conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);//("Data Source=localhost;Initial Catalog=Utilities;Integrated Security=True");
        ds = new DataSet();
        da = new SqlDataAdapter();
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
             //HttpContext.Current.Response.Redirect("db_error.aspx");
             return;
         }         
     }
    public void run()
    {
        da.SelectCommand = comm;
        da.Fill(ds,db);

        datreader = comm.ExecuteReader();
    }
    public void run2()
    {
        datreader = comm.ExecuteReader();
    }
}