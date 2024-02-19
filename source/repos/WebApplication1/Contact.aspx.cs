using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // If ViewState values are not null, assign them to TextBoxes
            //if (Session["name"] != null)
            //{
            //    TextBox2.Text = Session["name"].ToString();
            //}

            //if (Session["password"] != null)
            //{
            //    TextBox3.Text = Session["password"].ToString();
            //}
        }
    }
}