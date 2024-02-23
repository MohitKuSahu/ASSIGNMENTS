
using DemoUserManagement.Models;
using DemoUserManagement.UserControl;
using DemoUserManagement.Business;
using DemoUserManagement.Web.User_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Services;
using DemoUserManagement.Utils;

namespace DemoUserManagement.Web
{
    public class BasePage : System.Web.UI.Page
    {
        public void Page_Init(object sender, EventArgs e)
        {

            SessionModel session = Utility.SessionManager.GetSessionModel();
            if (session != null && session.UserId != 0)
            {
                bool isAdmin = session.IsAdmin;
                if (IsLoginPage())
                {
                    if (isAdmin)
                    {
                        Response.Redirect("UserList.aspx");
                    }
                    else
                    {
                        Response.Redirect("RegisterForm.aspx?UserId=" + session.UserId);
                    }
                }
                else if (IsUserListPage())
                {
                    if (!isAdmin)
                    {
                        Response.Redirect("RegisterForm.aspx?UserId=" + session.UserId);
                    }
                }
                else if (IsRegisterForm())
                {
                    RedirectIfUnauthorized(session.UserId);
                }
            }
            string requestedUser = Request.QueryString["UserId"];

            if (!string.IsNullOrEmpty(requestedUser) && int.TryParse(requestedUser, out int requestedId) && session.UserId == 0)
            {
                Response.Redirect("Login.aspx");
            }

        }

        private void RedirectIfUnauthorized(int userId)
        {
            string requestedUserId = Request.QueryString["UserId"];

            if (!string.IsNullOrEmpty(requestedUserId) && int.TryParse(requestedUserId, out int requestedId))
            {
                if (userId != requestedId)
                {
                    Response.Redirect("RegisterForm.aspx?UserId=" + userId);
                }
            }
        }

        private bool IsLoginPage()
        {
            if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Contains("login.aspx"))
                return true;
            else
                return false;
        }

        private bool IsRegisterForm()
        {
            if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Contains("registerform.aspx"))
                return true;
            else
                return false;
        }

        private bool IsUserListPage()
        {
            if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Contains("userlist.aspx"))
                return true;
            else
                return false;
        }

        public bool IsSessionValid()
        {
            SessionModel session = Utility.SessionManager.GetSessionModel();
            return session.UserId.ToString() != null;
        }

        public bool IsUserFile(int objectId)
        {
            SessionModel session = Utility.SessionManager.GetSessionModel();
            if (!session.IsAdmin)
            {
                if (session.UserId != objectId)
                {
                    return false;
                }
            }
            return true;
        }

        [WebMethod]
        public static void AddNotes(string noteData, int objectId, int objectType)
        {
         
           BusinessLayer.InsertNotes(noteData, objectId, objectType);
        }

        [WebMethod]
        public static List<DocumentModel> GetDocumentTypes()
        {
            return BusinessLayer.GetDocumentType();
        }

        [WebMethod]
        public static bool EmailExists(string email)
        {
            return Business.BusinessLayer.EmailExists(email);
        }

        [WebMethod]
        public static bool CheckUserEmail(string userId, string email)
        {
            return BusinessLayer.CheckUserEmail(userId, email);
        }
    }
}