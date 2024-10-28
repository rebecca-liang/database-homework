using System;
using System.Collections.Generic;
using System.Text;

using System.Data ;
using System.Data.SqlClient ;
using Model;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public   class BLLBook
    {
       // #region 私有成员
       // private string _bookID;
       // private string _bookName;
       // private string _bookIndex;
       // private int _bookTypeID;
       // private string _author;
       // private string _publish;
       // private double  _price;
       // private  DateTime  _publishDate;
       // private string _abstract;
       // private string _keyword;
       // private int _bookStatus;
       // private DateTime _registeDate;
       //#endregion
       
        
        
       // public BLLBook()
       // {
       // }
        
       // public BLLBook(string bookID,string bookName,string bookIndex,int bookType,string author,string publish,double price,DateTime publishDate,string abstrac,string keyword,int bookStatus,DateTime registeDate)
       // {
       //     this._bookID = bookID;
       //     this._bookName = bookName;
       //     this._bookIndex = bookIndex;
       //     this._bookTypeID = bookType;
       //     this._author = author;
       //     this._publish = publish;
       //     this._price=price ;
       //     this._publishDate=publishDate ;
       //     this._abstract = abstrac;
       //     this._keyword = keyword;
       //     this._bookStatus = bookStatus;
       //     this._registeDate = registeDate;

       // }


       //  #region 属性
       // public string BookID
       // {
       //     set
       //     {
       //         this._bookID = value;

       //     }
       //     get
       //     {
       //         return this._bookID;
       //     }

       // }
       // public string BookName
       // {
       //     set
       //     {
       //         this._bookName = value; 
       //     }
       //     get
       //     {
       //         return this._bookName;             

       //     }

       // }
       // public string BookIndex
       // {
       //     set
       //     {
       //         this._bookIndex = value;

       //     }
       //     get
       //     {
       //         return this._bookIndex;
       //     }

       // }
       // public string BookTypeID
       // {
       //     set
       //     {
       //         this._bookTypeID = value;
       //     }
       //     get
       //     {
       //         return this._bookTypeID;
       //     }

       // }
       // public string Author
       // {
       //     set
       //     {
       //         this._author = value;
       //     }
       //     get
       //     {
       //         return this._author;
       //     }

       // }
       // public string Publish

       // {
       //     set
       //     {
       //         this._publish = value;
       //     }
       //     get
       //     {
       //         return this._publish;
       //     }

       // }
       // public double Price
       // {
       //     set
       //     {
       //         this._price =value ;
       //     }
       //    get 
       //    {
       //        return this._price ;
       //    }
       // }
       // public DateTime PublishDate
       // {
       //     set 
       //     {
       //         this._publishDate =value;
       //     }
       //     get
       //     {
       //         return this._publishDate ;
       //     }
       // }
       // public string Abstrac
       // {
       //     set
       //     {
       //         this._abstract = value;
       //     }
       //     get
       //     {
       //         return this._abstract;
       //     }

       // }
       // public string Keyword
       // {
       //     set
       //     {
       //         this._keyword = value;
       //     }
       //     get
       //     {
       //         return this._keyword;
       //     }

       // }
       // public int  BookStatus
       // {
       //     set
       //     {
       //         this._bookStatus = value;
       //     }
       //     get
       //     {
       //         return this._bookStatus;
       //     }

       // }
       // public DateTime  RegisteDate
       // {
       //     set
       //     {
       //         this._registeDate = value;
       //     }
       //     get
       //     {
       //         return this._registeDate;
       //     }

       // }       
       
       // #endregion


        public BLLBook()
        {
        }
       
        
        DALBook dalBook = new DALBook();
        public bool AddBook(BookInfo bkInfo)
        {

            return dalBook.AddBook(bkInfo); 
            
        }

        public DataSet SearchBook(int type, string queryByCol, string content)
        {
            return dalBook.SearchBook(type, queryByCol, content);
        }

        public DataSet QueryBooks()
        {
            DataBase db = new DataBase();
            return db.GetDataSet("Proc_GetBooks");

        }
        public bool DeleteByProc(string XBookID)
        {
            DataBase db = new DataBase();
            SqlParameter[] para = new SqlParameter[1];
            para[0]= db.MakeInParam("@bookID", SqlDbType.NVarChar, 50, XBookID);
            int count = -1;
            count = db.RunProc("Proc_DeleteBook", para);
            if (count > 0)
                return true;
            else
                return false;
        }

        public BookInfo GetBookInfo(string XBookID)
        {
            DataSet ds= dalBook.GetBookInfoByID(XBookID);
            BookInfo bookInfo = new BookInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                bookInfo.BookID = GetSafeData.ValidateDataRow_S(dr, "bookID");
                bookInfo.BookName = GetSafeData.ValidateDataRow_S(dr, "bookName");
                bookInfo.BookIndex = GetSafeData.ValidateDataRow_S(dr, "bookIndex");
                bookInfo.BookTypeID = GetSafeData.ValidateDataRow_N(dr, "bookTypeID");
                bookInfo.Author = GetSafeData.ValidateDataRow_S(dr, "author");
                bookInfo.Publish = GetSafeData.ValidateDataRow_S(dr, "publish");
                bookInfo.Price = GetSafeData.ValidateDataRow_F(dr, "price");
                bookInfo.PublishDate = GetSafeData.ValidateDataRow_T(dr, "publishDate");
                bookInfo.Abstrac=GetSafeData.ValidateDataRow_S(dr,"abstract");
                bookInfo.Keyword=GetSafeData.ValidateDataRow_S(dr,"keyword");
                bookInfo.BookStatus=GetSafeData.ValidateDataRow_N(dr,"status"); 
                bookInfo.RegisteDate = GetSafeData.ValidateDataRow_T(dr, "registeDate");

            }
            return bookInfo;
        }

        public bool UpdateBookInfo(BookInfo bk)
        {
            return dalBook.updateBook(bk);

        }
    }

}
