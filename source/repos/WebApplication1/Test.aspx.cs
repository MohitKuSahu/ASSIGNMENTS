using System;
using System.Collections.Generic;
using System.Data;
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
            if (IsPostBack)
            {
                Response.Write("POSTBACK REQUEST");
            }


            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Email");
            table.Rows.Add("101", "Sachin Kumar", "sachin@example.com");
            table.Rows.Add("102", "Peter", "peter@example.com");
            table.Rows.Add("103", "Ravi Kumar", "ravi@example.com");
            table.Rows.Add("104", "Irfan", "irfan@example.com");
            DataList1.DataSource = table;   
            DataList1.DataBind();

         
          
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "")
            {
                Label2.Text = "Please Select a City";
            }
            else
                Label2.Text = "Your Choice is: " + DropDownList1.SelectedValue;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            // Value of TextBox1 and TextBox2 is assigned to the ViewState
            Session.Add("name", TextBox2.Text); // key value pair

            Session["password"] = TextBox3.Text; // array format



            // After clicking on Button, TextBox value will be cleared
            TextBox2.Text = TextBox3.Text = string.Empty;
            //Server.Transfer("Contact.aspx"); Server.Transfer(after redirect url remains unchanged)
            Response.Redirect("WebForm3.aspx"); // (URL change so that client is aware)


            //string url = "Contact.aspx";
            //Response.Write("<script type='text/javascript'>"+"window.open('" + url + "');</script>");// Redirect in  new tab
            
        }

      



    }
}