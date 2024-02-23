using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static DemoUserManagement.Utils.Utility;

namespace DemoUserManagement
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                UsersNavItem.Visible = false;
                LogoutLink.Visible = false;
                string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
                HtmlAnchor li = (HtmlAnchor)FindControl(pageName + "Link");
                if (li != null)
                {
                    li.Attributes.Add("class", "active");
                }
                SessionModel session = SessionManager.GetSessionModel();
                if (session.UserId != 0)
                {
                    LogoutLink.Visible = true;
                    if (session.IsAdmin)
                    {
                        UsersNavItem.Visible = true;
                    }
                }
            }
        }

      
    }
}