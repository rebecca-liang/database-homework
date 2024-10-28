using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;


using DataAccessLayer;



namespace BusinessLogicLayer
{
   public  class BookBusiness
    {  
       
       DataAccessLayer.BookBusiness bb = new DataAccessLayer.BookBusiness();
      
       public int CheckBookByID(string bookID)
       {
        
           return bb.CheckBookByID(bookID);
       }
       public static  int LendBook(string readerID, string bookID)
       {
           int val = DataAccessLayer.BookBusiness.LendBook(readerID, bookID);
           return val;
       }

       public int ReturnBook(string bookID)
       {
           return bb.ReturnBook(bookID);
           
       }



    }
}
