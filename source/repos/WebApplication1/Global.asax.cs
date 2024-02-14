using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["TotalRequests"] = 0;
        }

        void Application_End(object sender, EventArgs e)
        {
            // Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Exception ex = Server.GetLastError();
            // Log the error or redirect to a custom error page
        }


        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session starts
            Session["UserLoggedIn"] = false;
        }


        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends
        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
            // Code that runs at the beginning of each request
            Application.Lock();
            Application["TotalRequests"] = (int)Application["TotalRequests"] + 1;
            Application.UnLock();
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            // Code that runs at the end of each request
        }

    }
}

