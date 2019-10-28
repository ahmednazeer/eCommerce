using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_App
{
    public partial class Logout : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"] != null)//already loged in
                Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("Home.aspx");
            

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}