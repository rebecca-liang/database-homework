using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccessLayer
{
    public class BookBusiness
    {
        DataBase db = new DataBase();

        /// <summary>
        /// 判断是否存在给出的ID的书
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns>返回0表示不存在该书，返回-1表示该书当前不可借阅,返回1表示该书当前可借阅</returns>   
        public int CheckBookByID(string bookID)
        {
            string cmdStr = "SELECT * FROM Book WHERE bookID='" + bookID + "'";
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
                return 0;
            else if (Convert.ToInt16(ds.Tables[0].Rows[0]["status"]) != 1)
                return -1;
            else return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerID"></param>
        /// <param name="bookID"></param>
        /// <returns>1:借阅成功  0：达到最大借阅册数5本</returns>

        public static int LendBook(string readerID, string bookID)
       {
           DataBase db = new DataBase();
           string getBorrowCount = "SELECT COUNT(*) FROM BorrowRec WHERE readerID='" + readerID + "' AND borrowStatus='True'";
           int borrowCount=db.GetRecordCount(getBorrowCount);
           if (borrowCount == 5)
               return 0;
           else
           {
               DateTime beginDate = DateTime.Now;
               string status = "true";
               string insertStr = "INSERT INTO BorrowRec(readerID,bookID,beginDate,borrowStatus)" + "  VALUES('" + readerID + "','" + bookID + "','" + beginDate + "','" + status + "')";

               string upBookStatus = "UPDATE Book  SET status=0 WHERE bookID='" + bookID + "'";

               int val = db.ExecuteNonQuery(insertStr);
               if (val == 1)
               {
                   db.ExecuteNonQuery(upBookStatus);

               }
               return val;
           } 
        }
        public int ReturnBook(string bookID)
        {
            string endDate = DateTime.Now.ToString ();
            string cmdText = "update Book set status=1 where bookID='"+bookID+"';Update borrowRec SET borrowStatus='False', endDate='"+endDate +"'  WHERE  borrowRecID IN(SELECT borrowRecID FROM borrowRec WHERE bookID='"+@bookID+"'  AND borrowStatus='True')";


           // SqlParameter param = new SqlParameter("@bookID", SqlDbType.NVarChar );
           // param.Value = bookID;
            int result = db.ExecuteNonQuery(cmdText);
            return result;
        }
    }
}
