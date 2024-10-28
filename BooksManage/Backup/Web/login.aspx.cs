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

namespace Web
{
    public partial class login : System.Web.UI.Page
    {
               
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userID"] =null;
            this.txtUserID.Focus();
           

            if (!IsPostBack)
            {
                if (!Object.Equals(Request.Cookies["UserID"], null))
                {
                    HttpCookie readcookie = Request.Cookies["UserID"];
                    this.txtUserID.Text = readcookie.Value;
                }
            }

        }
      
       
        //登录按钮事件
        protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
        {

            Users user = new Users();                          //创建Users对象user
            string pwdMd5 = txtPwd.Text.ToString().Trim();

            if (user.CheckPassword(txtUserID.Text.Trim())) //根据用户编号查询用户密码
            {
                if (user.UserPassword == pwdMd5)           //输入密码与用户密码相同
                {
                    Session["userID"] = txtUserID.Text.Trim();
                    if (user.RoleID == 1)                  //如果该用户是系统管理员
                    {
                        //存储用户编号
                        Response.Redirect("sysAdmin/AdminMain.aspx");//转向总管理员操作界面
                    }
                    else if (user.RoleID == 2)//用户是系统操作员
                    {
                        Response.Redirect("sysOperator/LendBook.aspx");//转向借书还书界面
                    }
                    if (user.RoleID == 3)//用户是读者
                    {
                        Response.Redirect("Reader/ReaderDefault.aspx");
                    }
                }
                else//密码错误，给出提示
                {
                    lblMessage.Text = "您输入的密码错误！";
                }
            }
            else//用户不存在，给出提示
            {
                lblMessage.Text = "该用户不存在！";

               
            }
            //       }
        }
        //protected void ChangeCode_Click(object sender, EventArgs e)
        //{

        //}
       
        private void CreateCookie()
        {
            HttpCookie cookie = new HttpCookie("UserID");
            if (this.cbxRemeberUser.Checked)
            {
                cookie.Value = this.txtUserID.Text;
            }
            cookie.Expires = DateTime.MaxValue;
            Response.AppendCookie(cookie);
        } 
        
    }
   
}
