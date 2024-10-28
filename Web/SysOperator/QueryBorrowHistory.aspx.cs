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

namespace Web.SysOperator
{
    public partial class QueryBorrowHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            Users user = new Users();
            string userID = txtReaderID.Text.Trim().ToString();
            DataSet dsBorrowHistory = user.GetBorrowHistory(userID);

            //dsBorrowBook = user.GetBorrowBook(userID);
            if (dsBorrowHistory.Tables[0].Rows.Count > 0)
            {
                this.gvBorrowHistory.DataSource = dsBorrowHistory;
                gvBorrowHistory.DataBind();
                // this.TrMsg.Visible = false;       //有借阅记录则显示列表，并不显示提示
            }
            else                                  //没有借阅记录则不显示gridview，并给出提示信息
            {
                //  this.TrGrid.Visible = false;
                // lblMsgNoBorrow.Text = "你好，你还没有借阅历史记录";

            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
            gridTable.Visible = true;

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.txtReaderID.Text = string.Empty;
        }
    }
}
