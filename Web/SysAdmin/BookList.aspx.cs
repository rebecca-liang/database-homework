using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;


using Model;
using BusinessLogicLayer;

namespace Web.SysAdmin
{
    public partial class BookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookList();
            }
        }

        public void BindBookList()
        {
            BLLBook book = new BLLBook();
            DataSet dsBooks = book.QueryBooks();
            GridviewBookList.DataSource = dsBooks;
            GridviewBookList.DataBind();     
            
            //dsBooks.WriteXml(Server.MapPath("test.xml"),XmlWriteMode.WriteSchema);
        }
 
        protected void GridviewBookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string bookID = GridviewBookList.DataKeys[e.RowIndex].Values[0].ToString();
            BLLBook book = new BLLBook();
            if (book.DeleteByProc(bookID))
                Response.Write("<script language=javascript> alert('删除成功！')</script>");
            else
                Response.Write("<script language=javascript> alert('删除失败！')</script>");
            GridviewBookList.EditIndex = -1;
            BindBookList();
        }



    }
}
