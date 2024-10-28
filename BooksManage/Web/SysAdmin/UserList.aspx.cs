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

namespace Web.SysAdmin
{
public partial class UserList : System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)
{
   // Response.Write("debugMsg:page load");
    if (!IsPostBack)
    {
        Response.Write("!IsPostBack");
        BindGrdUserList();
        lblDebugMsg.Text = "";
    }
  
}


public void BindGrdUserList()
{
    Users user = new Users();
    DataSet userDS = user.QueryUsers();
    gridviewUserList.DataSource = userDS;
    this.lblDebugMsg.Text += " -->before DataBind   ";
    gridviewUserList.DataBind();
    this.lblDebugMsg.Text += "  -->after DataBind   ";
    lblDisplay(userDS);
}

public void lblDisplay(DataSet userDS)//修改每行两个label要最终显示的数据
{
    for (int i = 0; i < gridviewUserList.Rows.Count; i++)
    {
        Label labelRole = (Label)gridviewUserList.Rows[i].FindControl("lblRole");
        Label labelGender=(Label)gridviewUserList.Rows[i].FindControl("lblGender");
        if (labelRole != null)  //当edit事件时只加载<EditItemTemplate>而不加载<ItemTemplate>，找不到lblGender 
        {
            DataRowView drv = userDS.Tables[0].DefaultView[i];
            if ( drv["roleID"].ToString().Trim( ) =="1")
                labelRole.Text = "系统管理员";
            if (drv["roleID"].ToString().Trim( ) == "2")
                labelRole.Text = "系统操作员";
            if (drv["roleID"].ToString().Trim( ) == "3")
                labelRole.Text = "读者";

        }
        if (labelGender != null)
        {
            DataRowView drv = userDS.Tables[0].DefaultView[i];
            if (drv["userGender"].ToString().Trim() == "False")
                labelGender.Text = "女";
            if (drv["userGender"].ToString().Trim() == "True")
                labelGender.Text = "男";

        }   
    }
}


//GridView控件RowDeleting事件
protected void gridviewUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
    string userID = gridviewUserList.DataKeys[e.RowIndex].Values[0].ToString();//取得所在行的userID,与gridview的DataKeyNames属性有关
    Users user = new Users();
   
    if (user.DeleteByProc(userID))

        Response.Write("<script language=javascript>alert('删除成功！')</script>");

    else
        Response.Write("<script language=javascript>alert('删除失败！')</script>");
    gridviewUserList.EditIndex = -1;
    BindGrdUserList();

}
//点击编辑时触发
protected void gridviewUserList_RowEditing(object sender, GridViewEditEventArgs e)
{
    this.lblDebugMsg.Text += "  -->RowEditing   ";

    gridviewUserList.EditIndex = e.NewEditIndex; //GridView编辑项索引等于单击行的索引
    BindGrdUserList();

}
//取消更新时触发
protected void gridviewUserList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
{
    gridviewUserList.EditIndex = -1;
    BindGrdUserList();
}

protected void gridviewUserList_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
    string userID = gridviewUserList.DataKeys[e.RowIndex].Values[0].ToString();
    Users user = new Users();
    //user.UserName = txtName.text;只能用findcontrol()获得新值，无法直接txtName（无智能提示）
    user.UserName = ((TextBox)gridviewUserList.Rows[e.RowIndex].FindControl("txtName")).Text.Trim();
    user.RoleID = Convert.ToInt32(((DropDownList)gridviewUserList.Rows[e.RowIndex].FindControl("ddlRole")).SelectedValue);
    user.UserGender = Convert.ToBoolean(((DropDownList)gridviewUserList.Rows[e.RowIndex].FindControl("ddlGender")).SelectedValue);
    user.UserDepartment = ((TextBox)gridviewUserList.Rows[e.RowIndex].FindControl("txtDept")).Text.Trim();
    user.UserAddress = ((TextBox)gridviewUserList.Rows[e.RowIndex].FindControl("txtAddress")).Text.Trim();

    if (user.UpdateByProc(userID) == true)
        Response.Write("<script language=javascript>alert('修改成功！') </script>");
    else
    Response.Write("<script language=javascript>alert('修改失败！') </script>");
   
    gridviewUserList.EditIndex = -1;//善后处理，重新绑定
    BindGrdUserList();
}

protected void gridviewUserList_DataBinding(object sender, EventArgs e)
{
    this.lblDebugMsg.Text += "  -->DataBinding   ";

}

protected void gridviewUserList_DataBound(object sender, EventArgs e)
{
    this.lblDebugMsg.Text += "  -->DataBound   ";

}

protected void gridviewUserList_RowCreated(object sender, GridViewRowEventArgs e)
{
    this.lblDebugMsg.Text += "  -->RowCreated   ";

}

protected void gridviewUserList_RowDataBound(object sender, GridViewRowEventArgs e)
{
    this.lblDebugMsg.Text += "  -->RowDataBound   ";

    DropDownList ddlRl = (DropDownList)e.Row.FindControl("ddlRole");
    DropDownList ddl = (DropDownList)e.Row.FindControl("ddlGender");//edit时才能找到
    if (ddlRl != null)
    {
        ddlRl.SelectedValue = ((HiddenField)e.Row.FindControl("hdfRole")).Value;//设置默认显示对应的值
    }
    if (ddl != null)
    {
        ListItem item1 = new ListItem("男", "True");
        ListItem item2 = new ListItem("女", "False");
        ddl.Items.Add(item1);
        ddl.Items.Add(item2);
        ddl.SelectedValue = ((HiddenField)e.Row.FindControl("hdfGender")).Value;
    }     


    
}

protected void gridviewUserList_RowCommand(object sender, GridViewCommandEventArgs e)
{
    this.lblDebugMsg.Text += "  -->_RowCommand   ";

}

public DataSet getDataSet()//edit时为角色的dropdownlist提供数据源
{
    DataAccessLayer.DataBase db = new DataAccessLayer.DataBase();
    DataSet ds = db.GetDataSet("Proc_GetRole");
    return ds;
}


}
}
