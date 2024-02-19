using DemoUserManagement.DAL;
using DemoUserManagement.Models;
using DemoUserManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            List<UserModel> users = BusinessLayer.GetAllUsers();
            UserModel user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null) {
                lblMessage.Visible = false; // Hide error message
                Response.Redirect("Users.aspx");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid email or password.";
            }
        }
    }
}