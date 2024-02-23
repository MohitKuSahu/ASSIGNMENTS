using DemoUserManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement
{
    public partial class _Default : Page
    {
        public int testing = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                testing = 10;
            }
            else
            {
                var test2 = testing;
            }
        }
      
    }
}