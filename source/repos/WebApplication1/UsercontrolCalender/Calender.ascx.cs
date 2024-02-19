using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Calender : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ShowDate.Text = "You Selected: " + Calendar1.SelectedDate.ToString("D");
            Calendar1.Visible = false; //visibility
        }
    }
}