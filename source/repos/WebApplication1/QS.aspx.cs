using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class QS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender,  EventArgs e)
        {
            Response.Redirect("QS2.aspx?name="+Server.UrlEncode(TextBox1.Text)+"&id="+Server.UrlEncode(TextBox2.Text)+"&email="+Server.UrlEncode(TextBox3.Text));
        }
    }
}