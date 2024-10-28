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

namespace Web.SysAdmin
{
    public partial class sysAdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dispUserName();
            }

        }

        void dispUserName()
        {
            try
            {
                Users LoginUser = new Users();
                LoginUser.UserID = Session["UserID"].ToString();
                DataSet ds = LoginUser.GetUserInfoByID(LoginUser.UserID);
                //labUser.Text = ds.Tables[0].Rows[0]["userName"].ToString();
            }
            catch (System.Exception ex)
            {
                Response.Redirect("~/login.aspx");

            }

        }
    }
}
