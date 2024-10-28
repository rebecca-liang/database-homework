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


namespace Web.Common.controls
{
    public partial class userDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }
        public void BindData()
        {

            Users LoginUser = new Users();
            LoginUser.UserID = Session["UserID"].ToString();
            DataSet ds = LoginUser.GetUserInfoByID(LoginUser.UserID);

            lblID.Text = Session["UserID"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["userName"].ToString();

            string gender = ds.Tables[0].Rows[0]["userGender"].ToString();
            if (gender=="True")
            lblGender.Text = "男";
            else
            lblGender.Text = "女";
            int power = Convert.ToInt32(ds.Tables[0].Rows[0]["roleID"]);
            switch (power)
            {
                case 1:
                    lblPower.Text = "管理员";
                    break;
                case 2:
                    lblPower.Text = "操作员";
                    break;

                case 3:
                    lblPower.Text = "读者";
                    break;
                default:
                    break;

            }             
           
            txtAddress.Text = ds.Tables[0].Rows[0]["userAddress"].ToString();
            txtDept.Text = ds.Tables[0].Rows[0]["userDepartment"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["userPhone"].ToString();


        }

        protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Write("<script language=javascript>alert('TODO:')</script>")
            string userID = Convert.ToString(Session["userID"]);
            Users user=new Users();
            user.UserDepartment=txtDept.Text.Trim();
            user.UserAddress=txtAddress.Text.Trim();
            user.UserPhone=txtPhone.Text.Trim();

            if (user.UpdateUserComm(userID) == true)
                Response.Write("<script language=javascript>alert('修改成功！') </script>");
            else
                Response.Write("<script language=javascript>alert('修改失败！') </script>");

            //gridviewUserList.EditIndex = -1;//善后处理，重新绑定
            //BindGrdUserList();


        }
    }
}
