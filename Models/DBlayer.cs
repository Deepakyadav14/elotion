using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data;

namespace elotion.Models
{
    public class DBlayer
    {
        SqlConnection conn;
      public   DBlayer()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        
        }   
        public int Execute(string proc, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand(proc,conn);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter p in para)
            {
                cmd.Parameters.Add(p);
            }
            conn.Open();
           int a= cmd.ExecuteNonQuery();
            conn.Close();
            return a;
        }
        public DataTable Fetch(string proc, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand(proc, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter p in para)
            {
                cmd.Parameters.Add(p);
            }
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
    }
}