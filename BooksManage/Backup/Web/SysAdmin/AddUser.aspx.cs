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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindRB();
            else { };

        }
        private void BindRB()
        {
            for (int i = 1950; i < 2010; i++)
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
        }
        protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            UserInfo usInfo = new UserInfo();
            usInfo.UserID = txtUserID.Text.Trim();
            usInfo.UserName = txtUserName.Text.Trim();
            usInfo.UserPassword = txtPassword.Text.Trim();
            usInfo.Gender = Convert.ToBoolean(rblUserSex.SelectedItem.Value);
            usInfo.UserDepartment = txtUserDepart.Text.Trim();
            usInfo.UserAddress = txtUserAddress.Text.Trim();
            usInfo.UserPhone = txtUserTelephone.Text.Trim();
            usInfo.UserBirthdate = Convert.ToDateTime(ddlYear.SelectedItem.Text + "-" + ddlMonth.SelectedItem.Text + "-" + ddlDay.SelectedItem.Text);
            usInfo.RoleID = Convert.ToInt16(ddlUserRole.SelectedItem.Value);

            string InsertStr = "INSERT INTO Users VALUES('" + usInfo.UserID + "','" + usInfo.UserName + "','" + usInfo.UserPassword + "','" + usInfo.Gender + "','" + usInfo.UserDepartment + "','" + usInfo.UserAddress + "','" + usInfo.UserPhone + "','" + usInfo.UserBirthdate + "'," + usInfo.RoleID + ")";
            Users bllUser = new Users();

            if (bllUser.AddUser(InsertStr))
                lblMessage.Text = "Add user success!!";
            else
                lblMessage.Text = "Can't add!!";

            clearAll();





        }


        protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
        {
            clearAll();
        }

        public void clearAll() //清空所有输入框
        {
            this.txtUserID.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtConfirmPwd.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtUserDepart.Text = string.Empty;
            this.txtUserAddress.Text = string.Empty;
            this.txtUserTelephone.Text = string.Empty;

        }
    }
}
