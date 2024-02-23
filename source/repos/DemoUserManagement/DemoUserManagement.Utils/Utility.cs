using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUserManagement.Models;
using System.Web;

namespace DemoUserManagement.Utils
{
    public class Utility
    {
        public enum ObjectType
        {
            UserForm = 1,
        }

        public enum AddressType
        {
            Present = 0,
            Permanent = 1
        }
        public enum DocumentType
        { 
            Photo = 1,
            Others = 2
        }

        public static class SessionManager
        {
            public static SessionModel GetSessionModel()
            {
                SessionModel sessionModel = HttpContext.Current.Session["SessionModel"] as SessionModel;
                return sessionModel ?? new SessionModel();
            }

            public static void SetSessionModel(SessionModel sessionModel)
            {
                HttpContext.Current.Session["SessionModel"] = sessionModel;
            }
        }
    }
}
