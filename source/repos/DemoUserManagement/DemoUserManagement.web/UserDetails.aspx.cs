using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagement.Business;
using System.Web.Services.Description;

namespace DemoUserManagement
{
    public partial class UserDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack && (Request.QueryString.Count == 0))
            {
                LoadCountriesAndStates();
            }

         


        }
        private void LoadCountriesAndStates()
        {
           
            List<string> countries = BusinessLayer.GetAllCountries();

           
            ddlPresentCountry.DataSource = countries;
            ddlPresentCountry.DataBind();

            ddlPermanentCountry.DataSource = countries;
            ddlPermanentCountry.DataBind();

            List<string> states = BusinessLayer.GetStatesForCountry(countries[0]);

            ddlPermanentState.DataSource = states;
            ddlPermanentState.DataBind();

            ddlPresentState.DataSource = states;
            ddlPresentState.DataBind();

        }
        public void DdlPresentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            string selectedCountry = ddlPresentCountry.SelectedValue;

            List<string> StatesForCountry = BusinessLayer.GetStatesForCountry(selectedCountry);

            ddlPresentState.DataSource = StatesForCountry;
            ddlPresentState.DataBind();
        }


        public void DdlPermanentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            string selectedCountry = ddlPermanentCountry.SelectedValue;

            List<string> StatesForCountry = BusinessLayer.GetStatesForCountry(selectedCountry);

            ddlPermanentState.DataSource = StatesForCountry;
            ddlPermanentState.DataBind();

        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

                   

            (UserModel UserInfo, List<AddressModel> ListofAddresses) = TakeValuesFromForm();

            
            if (Request.QueryString["id"] != null)
            {
                UpdateUser(UserInfo, ListofAddresses, int.Parse(Request.QueryString["id"]));
            }
            else
            {
                InsertNewUser(UserInfo, ListofAddresses);
            }

        }
        private void ClearTextBoxes(Control parent)
        {
           
            foreach (Control control in parent.Controls)
            {
               
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }

              
                if (control.HasControls())
                {
                    ClearTextBoxes(control);
                }
            }
        }
        public void InsertNewUser(UserModel NewUser, List<AddressModel> ListofAddresses)
        {
            Dictionary<string, int> InsertedUser = BusinessLayer.InsertUser(NewUser, ListofAddresses);
          

            string docFileName = string.Empty;
            string photoFileName = string.Empty;
            if (docUpload.HasFile)
            {
                docFileName = SaveFile(docUpload);
                BusinessLayer.InsertDocument(docUpload.FileName, docFileName, InsertedUser["UserID"], (int)Utility.ObjectType.UserForm, (int)Utility.DocumentType.Others);

            }

            if (PHOTO.HasFile)
            {
                photoFileName = SaveFile(PHOTO);
                BusinessLayer.InsertDocument(PHOTO.FileName, photoFileName, InsertedUser["UserID"], (int)Utility.ObjectType.UserForm, (int)Utility.DocumentType.Photo);

            }
            if (InsertedUser["flag"] == 1 && InsertedUser["RoleId"] == 1) Response.Redirect("~/Users.aspx");
            else if (InsertedUser["flag"] == 1 && InsertedUser["RoleId"] == 2) UpdateUser(NewUser, ListofAddresses, InsertedUser["UserID"]);

        }
        public void UpdateUser(UserModel UserInfo, List<AddressModel> ListofAddresses, int IdToUpdate)
        {
            if (BusinessLayer.UpdateUser(UserInfo, ListofAddresses, IdToUpdate)) Response.Redirect("~/Users.aspx?id=" + IdToUpdate);
        }
        public (UserModel, List<AddressModel>) TakeValuesFromForm()
        {

            string formattedDateOfBirth = DateTime.Parse(dob.Text).ToString("yyyy-MM-dd");

            UserModel UserInfo = new UserModel
            {
                FirstName =fname.Text,
                MiddleName = mname.Text,
                LastName = lname.Text,
                FatherName = fathername.Text,   
                MotherName = mothername.Text,
                GuardianName=gname.Text,
                Password = password.Text,
                PhoneNumber = phn.Text,
                AlternatePhoneNumber = altn.Text,
                Email = email.Text,
                DOB = formattedDateOfBirth,
                Documents=documentsInput.Text,
                Status = Status.SelectedValue,
                Gender=Gender.SelectedValue,
                WorkExperience = WorkExperience.Text,
                Board10th = Board10.Text,
                Board12th= Board12.Text,
                Percentage10th=int.Parse(percent10.Text),
                Percentage12th=int.Parse(percent12.Text),
                PercentageBTECH=int.Parse(percentB_Tech.Text),
                Institute10th=institutename10.Text,
                Institute12th=institutename12.Text,
                InstituteBTECH= institutenameB_Tech.Text,
                BloodGroup=bloodGroupInput.Text
            };

            List<int> ids = BusinessLayer.GetCountryAndStateID(ddlPresentCountry.SelectedValue, ddlPresentState.SelectedValue);


            AddressModel PresentAddress = new AddressModel
            {
                Address = address1.Text,
                Type = (int)Utility.AddressType.Present,
                CountryID = ids[0],
                StateID = ids[1]
               

            };

            List<int> ids2 = BusinessLayer.GetCountryAndStateID(ddlPermanentCountry.SelectedValue, ddlPermanentState.SelectedValue);

            AddressModel PermanentAddress = new AddressModel
            {
                Address = address1_.Text,
                Type = (int)Utility.AddressType.Permanent,
                CountryID = ids2[0],
                StateID = ids2[1]

            };
            List<AddressModel> ListofAddresses = new List<AddressModel> { PresentAddress, PermanentAddress };   
            return (UserInfo, ListofAddresses);
        }
        protected string SaveFile(FileUpload fileUpload)
        {
            string ExternalFolderPath = System.Configuration.ConfigurationManager.AppSettings.Get("ServerPath");
            if (!Directory.Exists(ExternalFolderPath))
            {
                Directory.CreateDirectory(ExternalFolderPath);
            }


           
            Guid uniqueGuid = Guid.NewGuid();

            string fileExtension = Path.GetExtension(fileUpload.FileName);

        
            string uniqueFileName = uniqueGuid.ToString() + fileExtension;

            fileUpload.SaveAs(ExternalFolderPath + uniqueFileName);

            return uniqueFileName;
        }
        public void PopulateValuesIntoForm(int UserId)
        {
            UserModel UserDetails = BusinessLayer.GetUserDetails(UserId);
            List<AddressModel> ListofAddresses = BusinessLayer.GetAddresses(int.Parse(Request.QueryString["id"]));

            fname.Text = UserDetails.FirstName;
            mname.Text = UserDetails.MiddleName;
            lname.Text = UserDetails.LastName;
            password.Text = UserDetails.Password;
            phn.Text = UserDetails.PhoneNumber;
            altn.Text = UserDetails.AlternatePhoneNumber;
            email.Text = UserDetails.Email;
            dob.Text = UserDetails.DOB;
            Status.SelectedValue = UserDetails.Status;
          

    
            //permanent address
            List<string> Names = BusinessLayer.GetCountryAndStateNames(ListofAddresses[1].CountryID, ListofAddresses[1].StateID);

           
            List<string> countries = BusinessLayer.GetAllCountries();
            for (int i = 0; i < countries.Count; i++) ddlPermanentCountry.Items.Add(countries[i]);
            ddlPermanentCountry.SelectedValue = Names[0];

            List<string> StatesForCountry = BusinessLayer.GetStatesForCountry(Names[0]);
            for (int i = 0; i < StatesForCountry.Count; i++) ddlPermanentState.Items.Add(StatesForCountry[i]);
            ddlPermanentState.SelectedValue = Names[1];

           address1_.Text = ListofAddresses[1].Address;

            // present address
            List<string> Names2 = BusinessLayer.GetCountryAndStateNames(ListofAddresses[0].CountryID, ListofAddresses[0].StateID);

            List<string> countries2 = BusinessLayer.GetAllCountries();
            for (int i = 0; i < countries2.Count; i++) ddlPresentCountry.Items.Add(countries2[i]);
            ddlPresentCountry.SelectedValue = Names2[0];

            List<string> StatesForCountry2 = BusinessLayer.GetStatesForCountry(Names2[0]);
            for (int i = 0; i < StatesForCountry2.Count; i++) ddlPresentState.Items.Add(StatesForCountry2[i]);
            ddlPresentState.SelectedValue = Names2[1];

            address1.Text = ListofAddresses[0].Address;

        }

    }
}