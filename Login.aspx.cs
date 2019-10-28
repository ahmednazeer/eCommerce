using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WF_Day.Managers;

namespace E_Commerce_App
{
    public partial class Login : System.Web.UI.Page
    {
        //private CheckBox RememberMe;
        bool isChecked = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //isChecked = chkRememberMe.Checked;
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                isChecked = chkRememberMe.Checked;
                UserManager userManager = new UserManager();
                DataTable result = userManager.getLoginByEmail(txt_email.Value, txt_password.Value);
                if (result.Rows.Count > 0)
                {
                    int Id = result.Rows[0].Field<int>(0);
                    HttpCookie myCookie = new HttpCookie("userInfo");
                    myCookie.Values.Add("Id", Id.ToString());
                    if (isChecked)
                    {
                        myCookie.Expires.AddDays (10);
                    }
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("Home.aspx");
                }

            }
        }
    }
}