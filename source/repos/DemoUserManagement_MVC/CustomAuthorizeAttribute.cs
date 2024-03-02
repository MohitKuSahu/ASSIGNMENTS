using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUserManagement_MVC
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string UserRole { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);

            if (!isAuthorized)
            {
                return false;
            }
            var user = httpContext.User;

            if (!string.IsNullOrEmpty(UserRole) && !user.IsInRole(UserRole))
            {
                return false;
            }

            return true;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
         
            filterContext.Result = new RedirectResult("/Login/Login");
        }
    }

}