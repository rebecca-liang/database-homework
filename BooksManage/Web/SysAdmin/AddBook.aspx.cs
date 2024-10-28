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
    public partial class AddBook : System.Web.UI.Page
    {
        BLLBook bllBook = new BLLBook();   //BLLBook必须Public


        protected void Page_Load(object sender, EventArgs e)
        {
            //foreach (Control ctrl in Page.Controls)
            //{
            //    ctrl.EnableViewState = false;
            //}
           
            if (!this.IsPostBack)
            {
                for (int i = 1999; i < 2010; i++)
                {
                    ddlYear.Items.Add(i.ToString());
                }
                for (int i = 1; i < 13; i++)
                {
                    ddlMonth.Items.Add(i.ToString());
                }
                for (int i = 1; i < 32; i++)
                {
                    ddlDay.Items.Add(i.ToString());
                }
                ddlYear.SelectedIndex = 0;
                ddlMonth.SelectedIndex = 0;
                ddlDay.SelectedIndex = 0;
            }
            else
            { }


        }



        protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BookInfo bkInfo = new BookInfo();
            bkInfo.BookID = txtISBN.Text.Trim();
            bkInfo.BookName = txtName.Text.Trim();
            bkInfo.BookIndex = txtIndex.Text.Trim();

            bkInfo.BookTypeID = Convert.ToInt16(rblClassify.SelectedValue) + 1;

            bkInfo.Author = txtAuthor.Text.Trim();
            bkInfo.Publish = txtPublish.Text.Trim();
            bkInfo.Price = Convert.ToDouble(txtPrice.Text.Trim());
            bkInfo.PublishDate =Convert.ToDateTime(ddlYear.SelectedItem.Text + "-" + ddlMonth.SelectedItem.Text + "-" + ddlDay.SelectedItem.Text);
            bkInfo.Abstrac = txtDescription.Text.Trim();
            bkInfo.Keyword = txtSubject.Text.Trim();
            bkInfo.BookStatus = 1;
            bkInfo.RegisteDate = DateTime.Now;


            if (bllBook.AddBook(bkInfo))
                lblMessage.Text = "Add Success!!";
            else
                lblMessage.Text = "Not Add!!";

        }
    }
}
