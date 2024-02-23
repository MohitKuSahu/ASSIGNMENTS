using System;
using DemoUserManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagement.Utils;
using DemoUserManagement.Business;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using System.IO;
using System.Drawing;
using System.Xml.Linq;
using System.Web.SessionState;
using static DemoUserManagement.Utils.Utility;
using DemoUserManagement.UserControl;
using DemoUserManagement.Web;

namespace DemoUserManagement
{
    public partial class UserDetails2 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["UserId"]))
                {
                    if (int.TryParse(Request.QueryString["UserId"], out int userId))
                    {
                        SessionModel session = SessionManager.GetSessionModel();

                        if (session.IsAdmin == false)
                        {

                            NotesUserControl.ObjectId = session.UserId;
                            DocumentUserControl.ObjectId = session.UserId;
                        }
                        else if (session.IsAdmin == true)
                        {
                            NotesUserControl.ObjectId = userId;
                            DocumentUserControl.ObjectId = userId;
                        }
                    }
                    DocumentUserControl.ObjectTypeName = ObjectType.UserForm;
                    NotesUserControl.ObjectTypeName = ObjectType.UserForm;

                    NotesUserControl.Visible = true;
                    DocumentUserControl.Visible = true;
                }
                else
                {
                    NotesUserControl.Visible = false;
                    DocumentUserControl.Visible = false;
                }
            }
        }



        [WebMethod]
        public static void SubmitFormData(UserModel user, List<AddressModel> ListofAddresses)
        {
            try
            {
                BusinessLayer.InsertUser(user, ListofAddresses); ;
                HttpContext.Current.Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        [WebMethod]
        public static UserModel GetUserDetails(int userId)
        {
            try
            {
                return BusinessLayer.GetUserById(userId);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
                throw;
            }
        }

        [WebMethod]
        public static void UpdateFormData(UserModel user,List<AddressModel> ListofAddresses)
        {
            try
            {
                SessionModel session = SessionManager.GetSessionModel();
                if (session.UserId.ToString() != null)
                {
                 
                    int userId = session.UserId;
                    BusinessLayer.UpdateUser(user,ListofAddresses, userId);
                    HttpContext.Current.Response.Redirect("Login.aspx", false);
                }
                else
                {
                    HttpContext.Current.Response.Write("Session expired or invalid.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }


        [WebMethod]
        public static void AddNotes(string noteData, int objectId, string objectType)
        {
            NoteModel note = new NoteModel
            {
                ObjectID = objectId,
                NoteText = noteData,
                ObjectType = (int)ObjectType.UserForm,
                CreatedDate = DateTime.Now.ToString("d"),
            };

            Business.BusinessLayer noteBLL = new Business.BusinessLayer();
            noteBLL.AddNote(note);
        }


        [WebMethod]
        public static List<string> GetCountries()
        {
           
            List<string> countries = BusinessLayer.GetAllCountries();
            return countries;
        }

        [WebMethod]
        public static List<string> GetStatesForCountry(string selectedCountry)
        {
           
            List<string> states = BusinessLayer.GetStatesForCountry(selectedCountry);
            return states;
        }

      


        [WebMethod]
        public static string SaveFile(string fileContent, string fileExtension)
        {
            string ExternalFolderPath = System.Configuration.ConfigurationManager.AppSettings.Get("Path");

            if (!Directory.Exists(ExternalFolderPath))
            {
                Directory.CreateDirectory(ExternalFolderPath);
            }

            Guid uniqueGuid = Guid.NewGuid();
            string uniqueFileName = uniqueGuid.ToString() + fileExtension;

            byte[] contentBytes = Convert.FromBase64String(fileContent);

            File.WriteAllBytes(Path.Combine(ExternalFolderPath, uniqueFileName), contentBytes);

            return uniqueFileName;
        }

        [WebMethod]
        public static void PopulateValuesIntoForm(int UserId)
        {
            UserModel UserDetails = BusinessLayer.GetUserDetails(UserId);
            List<AddressModel> ListofAddresses = BusinessLayer.GetAddresses(int.Parse(HttpContext.Current.Request.QueryString["id"]));

            HttpContext.Current.Session["fname"] = UserDetails.FirstName;
            HttpContext.Current.Session["mname"] = UserDetails.MiddleName;
            HttpContext.Current.Session["lname"] = UserDetails.LastName;
            HttpContext.Current.Session["password"] = UserDetails.Password;
            HttpContext.Current.Session["phn"] = UserDetails.PhoneNumber;
            HttpContext.Current.Session["altn"] = UserDetails.AlternatePhoneNumber;
            HttpContext.Current.Session["email"] = UserDetails.Email;
            HttpContext.Current.Session["dob"] = UserDetails.DOB;
            HttpContext.Current.Session["Status"] = UserDetails.Status;

            List<string> Names = BusinessLayer.GetCountryAndStateNames(ListofAddresses[1].CountryID, ListofAddresses[1].StateID);

            HttpContext.Current.Session["ddlPermanentCountry"] = Names[0];

            List<string> StatesForCountry = BusinessLayer.GetStatesForCountry(Names[0]);
            HttpContext.Current.Session["ddlPermanentState"] = Names[1];

            HttpContext.Current.Session["address1_"] = ListofAddresses[1].Address;

            List<string> Names2 = BusinessLayer.GetCountryAndStateNames(ListofAddresses[0].CountryID, ListofAddresses[0].StateID);

            HttpContext.Current.Session["ddlPresentCountry"] = Names2[0];

            List<string> StatesForCountry2 = BusinessLayer.GetStatesForCountry(Names2[0]);
            HttpContext.Current.Session["ddlPresentState"] = Names2[1];

            HttpContext.Current.Session["address1"] = ListofAddresses[0].Address;
        }

    }


}