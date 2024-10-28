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
public partial class SearchBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBookType();
        }
    }
    BLLBook bllBook = new BLLBook();


    void BindBookType()
    {
        bllBookType BBLbt = new bllBookType();
        ArrayList arrBT = new ArrayList();
        DataSet ds = BBLbt.GetBookType();
        ListItem li = new ListItem("全部", "0");
        ddlBookType.Items.Add(li);
        DataTable dt = ds.Tables[0];


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem lis = new ListItem();
            lis.Value = dt.Rows[i][0].ToString();
            lis.Text = dt.Rows[i][1].ToString();
            ddlBookType.Items.Add(lis);
        }


        ddlBookType.SelectedIndex = 0;
        //ddlBookType.DataBind();





    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int typeID = Convert.ToInt16(ddlBookType.SelectedValue);
        string queryByCol = ddlQueryType.SelectedItem.Value.ToString().Trim();
        string content = txtContent.Text.ToString().Trim();

        DataSet ds = bllBook.SearchBook(typeID, queryByCol, content);
        BookList.DataSource = ds;
        BookList.DataBind();



    }
    protected void BookList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string str = e.Row.Cells[4].Text;
            switch (str)
            {
                case "0":

                    e.Row.Cells[4].Text = "已借出";
                    break;
                case "1":

                    e.Row.Cells[4].Text = "在架上";
                    break;

                case "3":

                    e.Row.Cells[4].Text = "维护中";
                    break;

            }


        }
    }
}
}
