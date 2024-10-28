using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public  class BookTypeInfo
    {
       private string  _bookTypeName;
       private string _bookTypeDesc;

       BookTypeInfo() 
       {
       }
       
       public string BookTypeName
       {
           get { return _bookTypeName; }
           set { _bookTypeName = value; }
       }
       public string BookTypeDesc
       {
           get { return _bookTypeDesc; }
           set { _bookTypeDesc = value; }
       }

    }
}
