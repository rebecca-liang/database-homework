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
    public partial class LendBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtReaderID.Focus();

        }

        protected void imgbtnLend_Click(object sender, ImageClickEventArgs e)
        {
            string bookID = txtBookID.Text.ToString().Trim();
            string userID = txtReaderID.Text.ToString().Trim();
            BookBusiness BB = new BookBusiness();
            if (BB.CheckBookByID(bookID) == 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "不存在该书籍！！";


            }
            else if (BB.CheckBookByID(bookID) == -1)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "该书籍已借出或在维护中！！";
            }

            else
            {


                int val = BookBusiness.LendBook(userID, bookID);

                if (val == 1)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "借阅成功";

                    txtReaderID.Text = string.Empty;
                    txtBookID.Text = string.Empty;
                    //lblMsg.Text = string.Empty;

                }
                if (val == 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "借阅失败，该读者已达到最大借阅册数";

                    txtReaderID.Text = string.Empty;
                    txtBookID.Text = string.Empty;
                    //lblMsg.Text = string.Empty;
 
                }

            }

        }
        protected void ImageReset_Click(object sender, ImageClickEventArgs e)
        {
            txtReaderID.Text = string.Empty;
            txtBookID.Text = string.Empty;
            lblMsg.Text = string.Empty;
        }
    }
}
