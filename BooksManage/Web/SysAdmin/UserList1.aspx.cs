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

public partial class SysAdmin_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrdUserList();
           
        }

    }


    public void BindGrdUserList()
    {
        Users user = new Users();
      //  DataSet userDS = user.qu
      // gridviewUserList.DataSource = userDS;

        

    }
}
