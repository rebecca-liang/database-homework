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
using Model;

namespace Web.SysAdmin
{
    public partial class ModifyBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTable();
            }
          
        }
        public void BindTable()
        {
         
            BLLBook bllBook = new BLLBook();
            string bookID = Request["bookID"].ToString();
            BookInfo bookIf= bllBook.GetBookInfo(bookID);

            //绑定所有文本框
            this.txtName.Text = bookIf.BookName;
            this.txtIndex.Text = bookIf.BookIndex;
            
            this.txtAuthor.Text = bookIf.Author;
            this.txtPublish.Text = bookIf.Publish;
            this.txtPrice.Text = bookIf.Price.ToString("F02");//显示小数点后2位

            this.txtSubject.Text = bookIf.Keyword;
            this.txtDescription.Text = bookIf.Abstrac;

            //绑定图书类型
            int bookType = bookIf.BookTypeID;
            switch(bookType){
                case 1:
                    this.rblClassify.SelectedIndex=0;
                    break;
                case 2:
                    this.rblClassify.SelectedIndex=1;
                    break;
                case 3:
                     this.rblClassify.SelectedIndex=2;
                     break;
                case 4:
                    this.rblClassify.SelectedIndex=3;
                     break;
            }


            //绑定出版时间
            DateTime publishDate = bookIf.PublishDate;
            int year = publishDate.Year;
            int month = publishDate.Month;
            int day = publishDate.Day;
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
            //显示对应的值
            ddlYear.SelectedValue = year.ToString();
            ddlMonth.SelectedValue = month.ToString();
            ddlDay.SelectedValue = day.ToString();

        }

        protected void imgBtnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            //取得各个控件的值,创建bookInfo对象
            BookInfo bkInfo = new BookInfo();
            bkInfo.BookID = Request["bookID"].ToString().Trim();
            bkInfo.BookName = txtName.Text.Trim();
            bkInfo.BookIndex = txtIndex.Text.Trim();
            bkInfo.Author = txtAuthor.Text.Trim();
            bkInfo.Publish = txtPublish.Text.Trim();
            bkInfo.Price = Convert.ToDouble(txtPrice.Text.Trim());
            bkInfo.Keyword = txtSubject.Text.Trim();
            bkInfo.Abstrac = txtDescription.Text.Trim();

            bkInfo.BookTypeID = Convert.ToInt16(rblClassify.SelectedValue) + 1;
            bkInfo.PublishDate = Convert.ToDateTime(ddlYear.SelectedItem.Text + "-" + ddlMonth.SelectedItem.Text + "-" + ddlDay.SelectedItem.Text);
            //交给BBL处理
            BLLBook bllBook = new BLLBook();
            if (bllBook.UpdateBookInfo(bkInfo))
                lblMessage.Text = "修改成功!!";
               //  Response.Write("<scritp language=javascript> alert('修改成功')</scritp>");
            else
                Response.Write("<scritp language=javascript> alert('修改失败')</scritp>");
               // lblMessage.Text = "修改失败!!";
           // BindTable();6
        }

        protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("BookList.aspx");
        }
    }
}
