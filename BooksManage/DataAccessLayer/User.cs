using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Model;


namespace DataAccessLayer
{
    public class DALUser
    {
        UserInfo  ui=new UserInfo ();
        //  ui.UserID;
        DataBase DB = new DataBase();

        public DataSet  GetBorrowBook(string userID)
        {
            SqlParameter[]  Params=new SqlParameter []{ DB.MakeInParam("Proc_GetBorrowBook",SqlDbType .NVarChar ,userID .Length ,userID )};
            DataSet  ds=DB.GetDataSet("Proc_GetBorrowBook",Params);
            return ds;

        }

    }
}
