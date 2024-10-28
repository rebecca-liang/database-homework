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


using System.Data.SqlClient;
using BusinessLogicLayer;

namespace Web.Reader
{
    public partial class BorrowInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        void BindData()
        {
            string userID = Session["userID"].ToString();
            DataSet dsBorrowBook = new DataSet();
            Users user = new Users();

            dsBorrowBook = user.GetBorrowBook(userID);
            if (dsBorrowBook.Tables[0].Rows.Count > 0)
            {
                gvBorrowBookList.DataSource = dsBorrowBook;
                gvBorrowBookList.DataBind();
                this.TrMsg.Visible = false;       //有借阅记录则显示列表，并不显示提示
            }
            else                                  //没有借阅记录则不显示gridview，并给出提示信息
            {
                this.TrGrid.Visible = false;               
                lblMsgNoBorrow.Text = "你好，你还没有借阅记录"; 

            }

        }

        protected void gvBorrowBookList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime shouldEndDate = Convert.ToDateTime(e.Row.Cells[1].Text).AddDays(30);
                DateTime today=DateTime.Today;
                if (today.CompareTo(shouldEndDate) > 0)           //今天比应归还日期晚
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;

                    ClientScriptManager CSM = Page.ClientScript;  //加载页面时给出图书过期提示框
                    string ScriptName = "showMsg";
                    if (!CSM.IsClientScriptBlockRegistered(ScriptName))
                    {
                        string StrScript = "<script>";
                        StrScript += "alert('您有过期的图书，请尽快归还');";
                        StrScript += "</script>";
                        CSM.RegisterStartupScript(this.GetType(), ScriptName, StrScript);
                     }
                    //Page.RegisterStartupScript("", "<script>alert('您有过期的图书，请尽快归还');</script>");
                }
                else
                { }
                ((Label)e.Row.Cells[2].FindControl("lblEndDate")).Text = (Convert.ToDateTime(e.Row.Cells[1].Text).AddDays(30)).ToString();
            
            }


        }
    }
}
