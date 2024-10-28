using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;


using Model;

namespace DataAccessLayer
{
   public  class DALBook
    {
        public DALBook()
        {
        }
        public bool AddBook(BookInfo bkInfo)
        {
            DataBase db = new DataBase();
            SqlParameter[] param = new SqlParameter[]{
            new SqlParameter("@bookID",bkInfo.BookID ),  
            new SqlParameter("@bookName",bkInfo.BookName ),
            new SqlParameter("@bookIndex",bkInfo.BookIndex ),
            new SqlParameter("@bookTypeID",bkInfo .BookTypeID ),
            new SqlParameter("@author",bkInfo .Author ),
            new SqlParameter("@publish",bkInfo .Publish ),
            new SqlParameter("@price",bkInfo.Price ),
            new SqlParameter("@publishDate",bkInfo.PublishDate ),
            new SqlParameter("@abstract",bkInfo .Abstrac ),
            new SqlParameter("@keyword",bkInfo .Keyword ),
            new SqlParameter("@status",bkInfo.BookStatus),
            new SqlParameter("@registeDate",bkInfo.RegisteDate ) };


            int linecount=db.RunProc("Proc_AddBook", param);
            if (linecount == -1)
                return false;
            else
                return true; 
        }
       public DataSet SearchBook(int typeID, string queryByCol, string content)
       {
           DataSet ds = new DataSet();
           DataBase db = new DataBase();
           SqlParameter[] Params = new SqlParameter[3];
           Params[0] = db.MakeInParam("@bookTypeID",SqlDbType.Int , 20, typeID);
           Params[1] = db.MakeInParam("@queryByCol",SqlDbType .NVarChar, 50,queryByCol);
           Params[2] = db.MakeInParam("@Content", SqlDbType .NVarChar ,50 ,content);
           ds=db.GetDataSet("Proc_SearchBook", Params);
           return ds;

       }

       public DataSet GetBookInfoByID(string XBookID)
       {
           DataSet ds = new DataSet();
           DataBase db = new DataBase();
           SqlParameter[] param = new SqlParameter[1];
           param[0] = db.MakeInParam("@bookID", SqlDbType.NVarChar, 50, XBookID);
           ds=db.GetDataSet("Proc_GetBookInfoByID", param);
           return ds;

       }
       //更新一本书的信息，status和registerdate是不可更该的
       public bool updateBook(BookInfo bkInfo)
       {
           DataBase db = new DataBase();
           SqlParameter[] param = new SqlParameter[]{
            new SqlParameter("@bookID",bkInfo.BookID), 
            new SqlParameter("@bookName",bkInfo.BookName ),
            new SqlParameter("@bookIndex",bkInfo.BookIndex ),
            new SqlParameter("@bookTypeID",bkInfo .BookTypeID ),
            new SqlParameter("@author",bkInfo .Author ),
            new SqlParameter("@publish",bkInfo .Publish ),
            new SqlParameter("@price",bkInfo.Price ),
            new SqlParameter("@publishDate",bkInfo.PublishDate ),
            new SqlParameter("@abstract",bkInfo .Abstrac ),
            new SqlParameter("@keyword",bkInfo .Keyword )};


           int linecount = db.RunProc("Proc_UpdateBookByID", param);
           if (linecount == -1)
               return false;
           else
               return true;

       }



    }
}
