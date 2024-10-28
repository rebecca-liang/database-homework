using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BookInfo
    {
         #region 私有成员
        private string _bookID;
        private string _bookName;
        private string _bookIndex;
        private int _bookTypeID;
        private string _author;
        private string _publish;
        private double  _price;
        private  DateTime  _publishDate;
        private string _abstract;
        private string _keyword;
        private int _bookStatus;
        private DateTime _registeDate;
       #endregion
       
        
        
        public BookInfo()
        {
        }

        public BookInfo(string bookID, string bookName, string bookIndex, int bookType, string author, string publish, double price, DateTime publishDate, string abstrac, string keyword, int bookStatus, DateTime registeDate)
        {
            this._bookID = bookID;
            this._bookName = bookName;
            this._bookIndex = bookIndex;
            this._bookTypeID = bookType;
            this._author = author;
            this._publish = publish;
            this._price=price ;
            this._publishDate=publishDate ;
            this._abstract = abstrac;
            this._keyword = keyword;
            this._bookStatus = bookStatus;
            this._registeDate = registeDate;

        }


         #region 属性
        public string BookID
        {
            set
            {
                this._bookID = value;

            }
            get
            {
                return this._bookID;
            }

        }
        public string BookName
        {
            set
            {
                this._bookName = value; 
            }
            get
            {
                return this._bookName;             

            }

        }
        public string BookIndex
        {
            set
            {
                this._bookIndex = value;

            }
            get
            {
                return this._bookIndex;
            }

        }
        public int BookTypeID
        {
            set
            {
                this._bookTypeID = value;
            }
            get
            {
                return this._bookTypeID;
            }

        }
        public string Author
        {
            set
            {
                this._author = value;
            }
            get
            {
                return this._author;
            }

        }
        public string Publish

        {
            set
            {
                this._publish = value;
            }
            get
            {
                return this._publish;
            }

        }
        public double Price
        {
            set
            {
                this._price =value ;
            }
           get 
           {
               return this._price ;
           }
        }
        public DateTime PublishDate
        {
            set 
            {
                this._publishDate =value;
            }
            get
            {
                return this._publishDate ;
            }
        }
        public string Abstrac
        {
            set
            {
                this._abstract = value;
            }
            get
            {
                return this._abstract;
            }

        }
        public string Keyword
        {
            set
            {
                this._keyword = value;
            }
            get
            {
                return this._keyword;
            }

        }
        public int  BookStatus
        {
            set
            {
                this._bookStatus = value;
            }
            get
            {
                return this._bookStatus;
            }

        }
        public DateTime  RegisteDate
        {
            set
            {
                this._registeDate = value;
            }
            get
            {
                return this._registeDate;
            }

        }       
       
        #endregion
    }
}
