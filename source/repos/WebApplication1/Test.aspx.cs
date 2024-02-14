using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Test : System.Web.UI.Page
    {

        protected void Page_load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    Response.Write("POSTBACK REQUEST");
            //}
        }
        //protected void Page_preinit(object sender, EventArgs e)
        //{
        //    Response.Write("Page preinit \n");
        //}

        //protected void Page_init(object sender, EventArgs e)
        //{
        //    Response.Write("Page init \n");
        //}

        //protected void Page_initcomplete(object sender, EventArgs e)
        //{
        //    Response.Write("Page initcomplete \n");
        //}






        //protected void Page_loadcomplete(object sender, EventArgs e)
        //{
        //    Response.Write("Page loadcomplete \n");
        //}


        //protected void Page_UnLoad(object sender, EventArgs e)
        //{

        //}

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Value of TextBox1 and TextBox2 is assigned to the ViewState
            Session.Add("name", TextBox2.Text); // key value pair

            Session["password"] = TextBox3.Text; // array format



            // After clicking on Button, TextBox value will be cleared
            TextBox2.Text = TextBox3.Text = string.Empty;
            //Response.Redirect("Contact.aspx");

            string url = "Contact.aspx";
            Response.Write("<script type='text/javascript'>"+"window.open('" + url + "');</script>");// Redirect in  new tab
        }

      
    }
}