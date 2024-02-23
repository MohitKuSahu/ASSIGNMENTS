using DemoUserManagement.DAL;
using DemoUserManagement.Models;
using DemoUserManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagement.Web;

namespace DemoUserManagement
{
    public partial class LoginForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            int UserID=BusinessLayer.IsUser(email, password);
            if (UserID > 0) {
                lblMessage.Visible = false;
                if (BusinessLayer.IsAdmin(UserID))
                {
                    Response.Redirect("Users.aspx");
                }
                else
                {
                    Response.Redirect("UserDetails.aspx");
                }
               
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid email or password.";
            }
        }
        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetails.aspx");
           
        }
    }
}