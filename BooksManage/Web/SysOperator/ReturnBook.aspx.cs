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


using BusinessLogicLayer;
namespace Web.SysOperator
{
    public partial class ReturnBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtBookID.Focus();

        }
        protected void ImageReset_Click(object sender, ImageClickEventArgs e)
        {
            txtBookID.Text = string.Empty;
            lblMsg.Text = string.Empty;
        }
        protected void imgbtnReturn_Click(object sender, ImageClickEventArgs e)
        {
            BookBusiness bookBuz = new BookBusiness();
            string bookID = txtBookID.Text.ToString().Trim();


            if (bookBuz.CheckBookByID(bookID) == 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "输入图书编号有误！！";

            }

            else
            {
                bookBuz.ReturnBook(bookID);
                lblMsg.Visible = true;
                lblMsg.Text = "还书成功！！";
            }


        }
    }
}
