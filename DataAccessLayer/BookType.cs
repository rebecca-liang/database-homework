using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class dalBookType
    {

       public  DataSet GetDS()
        {
            
            string  connStr= ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
           
            SqlDataAdapter ada = new SqlDataAdapter("Proc_SelectBookType", conn);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            return ds;
        }
    }
}
