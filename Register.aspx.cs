using E_Commerce_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WF_Day.Managers;

namespace E_Commerce_App
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UserManager userManager = new UserManager();
                string email = txt_email.Value;
                string password = txt_password.Value;
                string firstName = txt_fName.Value;
                string lastName = txt_lName.Value;
                User user = new User
                {
                    Email = email,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                };
                int numOfRowsAffected= userManager.addUser(user);

                if (numOfRowsAffected == 1)
                    Response.Redirect("Login.aspx");
                Response.Redirect("Register.aspx");


            }

        }


    }
}