using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using BusinessLogicLayer;
using DataAccessLayer;

namespace Web.Common.controls
{
    public partial class ModifyPassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Users LoginUser = new Users();
            LoginUser.UserID = Session["UserID"].ToString();
            DataSet ds = LoginUser.GetUserInfoByID(LoginUser.UserID);


            string correctPwd = ds.Tables[0].Rows[0]["userPassword"].ToString();
            if (txtCurrPwd.Text != correctPwd)
            {
                Page.RegisterStartupScript("ggg", "<script>showError( );</script>");//注意这是调用js函数的方法

            }
            else
                if (txtNewPwd.Text != txtConfimPwd.Text)
                {
                    Page.RegisterStartupScript("chec=", "<script>checkPS( );</script>");//注意这是调用js函数的方法

                }
                else
                    if (txtNewPwd.Text == string.Empty)
                    {
                        Page.RegisterStartupScript("ch=", "<script>emptyError( );</script>");//注意这是调用js函数的方法

                    }
               else
                 update();

                   
        }

        public void update()
        {
            string newPwd = txtNewPwd.Text.Trim();
            string updateStrsql = "UPDATE Users SET userPassword='" + newPwd + "'WHERE userID='"+ Session["UserID"].ToString()+"'";
            DataBase db = new DataBase();
            int cnt= db.ExecuteNonQuery(updateStrsql);
            if (cnt==1)
                Response.Write("<script languge=javascript> alert('密码修改成功！');</script>");
            else
                Response.Write("<script languge=javascript> alert('密码修改失败！');</script>");
        }
    }
}