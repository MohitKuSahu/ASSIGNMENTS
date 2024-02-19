using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DemoUserManagement.Utils.Utility;

namespace DemoUserManagement.DAL
{
    public class DAL
    {

        public static Dictionary<string, int> InsertUser(UserModel userModel, List<AddressModel> ListofAddresses)
        {


            Dictionary<string, int> InsertedUser = new Dictionary<string, int>();

            InsertedUser["flag"] = 0; // flag - 0 

                using (var context = new FORMEntities())
                {

                    var newUser = new UserDetail
                    {
                        FirstName = userModel.FirstName,
                        MiddleName = userModel.MiddleName,
                        LastName = userModel.LastName,
                        FatherName = userModel.FatherName,
                        MotherName = userModel.MotherName,
                        Email = userModel.Email,
                        Password = userModel.Password,
                        DOB = userModel.DOB,
                        BloodGroup = userModel.BloodGroup,
                        PhoneNumber = userModel.PhoneNumber,
                        AlternatePhoneNumber = userModel.AlternatePhoneNumber,
                        GuardianName = userModel.GuardianName,
                        Gender = userModel.Gender,
                        Status = userModel.Status,
                        WorkExperience = userModel.WorkExperience,
                        Board10th = userModel.Board10th,
                        Board12th = userModel.Board12th,
                        Institue12th = userModel.Institute12th,
                        institue10th = userModel.Institute10th,
                        InstitueBTECH = userModel.InstituteBTECH,
                        Percentage10th = userModel.Percentage10th,
                        Percentage12th = userModel.Percentage12th,
                        PercentageBTECH = userModel.PercentageBTECH,
                        Documents = userModel.Documents,
                    };

                    // pass it to context API 
                    context.UserDetails.Add(newUser);
                    context.SaveChanges();


                int RoleId = 1;
                InsertedUser["RoleId"] = RoleId;
                InsertedUser["UserID"] = newUser.UserID;


                    var PresentAddress = new AddressDetail
                    {
                        Address = ListofAddresses[0].Address,
                        ID = ListofAddresses[0].ID,
                        Type = ListofAddresses[0].Type,
                        CountryID = ListofAddresses[0].CountryID,
                        StateID = ListofAddresses[0].StateID,
                        UserID = newUser.UserID
                    };


                    var PermanentAddress = new AddressDetail
                    {
                        Address = ListofAddresses[1].Address,
                        ID = ListofAddresses[1].ID,
                        Type = ListofAddresses[1].Type,
                        CountryID = ListofAddresses[1].CountryID,
                        StateID = ListofAddresses[1].StateID,
                        UserID = newUser.UserID,
                    };





                    context.AddressDetails.Add(PermanentAddress);
                    context.AddressDetails.Add(PresentAddress);

                    context.SaveChanges();
                    InsertedUser["flag"] = 1; // flag = 1;
                }
            
           
            return InsertedUser;
        }

        public static List<UserModel> GetAllUsers()
        {
            List<UserModel> userList = new List<UserModel>();

            try
            {
                using (var context = new FORMEntities())
                {
                    userList = context.UserDetails
                        .Select(userModel => new UserModel
                        {
                            FirstName = userModel.FirstName,
                            MiddleName = userModel.MiddleName,
                            LastName = userModel.LastName,
                            FatherName = userModel.FatherName,
                            MotherName = userModel.MotherName,
                            Email = userModel.Email,
                            Password = userModel.Password,
                            DOB = userModel.DOB,
                            BloodGroup = userModel.BloodGroup,
                            PhoneNumber = userModel.PhoneNumber,
                            AlternatePhoneNumber = userModel.AlternatePhoneNumber,
                            GuardianName = userModel.GuardianName,
                            Gender = userModel.Gender,
                            Status = userModel.Status,
                            WorkExperience = userModel.WorkExperience,
                            Board10th = userModel.Board10th,
                            Board12th = userModel.Board12th,
                            Institute12th = userModel.Institue12th,
                            Institute10th = userModel.institue10th,
                            InstituteBTECH = userModel.InstitueBTECH,
                            Percentage10th = (int)userModel.Percentage10th,
                            Percentage12th = (int)userModel.Percentage12th,
                            PercentageBTECH = (int)userModel.PercentageBTECH,
                            Documents = userModel.Documents,
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return userList;
        }

        public static  List<AddressModel> GetAllUsersAddresses()
        {
            List<AddressModel> ListOfAddresses = new List<AddressModel>();

            try
            {
                using (var context = new FORMEntities())
                {
                    // Retrieve all address details and project them to AddressDetailsModel
                    ListOfAddresses = context.AddressDetails
                        .Select(addressDetailEntity => new AddressModel
                        {
                            UserID = addressDetailEntity.UserID,
                            Address = addressDetailEntity.Address,
                            Type = addressDetailEntity.Type,
                            CountryID = addressDetailEntity.CountryID,
                            StateID = addressDetailEntity.StateID
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return ListOfAddresses;
        }

        public static  UserModel GetUserDetails(int UserId)
        {
            UserModel users = null;
            try
            {
                using (var context = new FORMEntities())
                {

                    var userDetailEntity = context.UserDetails.FirstOrDefault(u => u.UserID == UserId);


                    users = new UserModel
                    {
                        FirstName = userDetailEntity.FirstName,
                        MiddleName = userDetailEntity.MiddleName,
                        LastName = userDetailEntity.LastName,
                        FatherName = userDetailEntity.FatherName,
                        MotherName = userDetailEntity.MotherName,
                        Email = userDetailEntity.Email,
                        Password = userDetailEntity.Password,
                        DOB = userDetailEntity.DOB,
                        BloodGroup = userDetailEntity.BloodGroup,
                        PhoneNumber = userDetailEntity.PhoneNumber,
                        AlternatePhoneNumber = userDetailEntity.AlternatePhoneNumber,
                        GuardianName = userDetailEntity.GuardianName,
                        Gender = userDetailEntity.Gender,
                        Status = userDetailEntity.Status,
                        WorkExperience = userDetailEntity.WorkExperience,
                        Board10th = userDetailEntity.Board10th,
                        Board12th = userDetailEntity.Board12th,
                        Institute12th = userDetailEntity.Institue12th,
                        Institute10th = userDetailEntity.institue10th,
                        InstituteBTECH = userDetailEntity.InstitueBTECH,
                        Percentage10th = (int)userDetailEntity.Percentage10th,
                        Percentage12th = (int)userDetailEntity.Percentage12th,
                        PercentageBTECH = (int)userDetailEntity.PercentageBTECH,
                        Documents = userDetailEntity.Documents,
                    };

                }

            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return users;
        }

        public static List<AddressModel> GetAddresses(int userId)
        {
            List<AddressModel> listOfAddresses = new List<AddressModel>();

            try
            {
                using (var context = new FORMEntities())
                {
                    // Retrieve addresses based on UserId and project them to AddressDetailsModel
                    listOfAddresses = context.AddressDetails
                        .Where(a => a.UserID == userId)
                        .Select(addressDetailEntity => new AddressModel
                        {
                            Address = addressDetailEntity.Address,
                            Type = addressDetailEntity.Type,
                            UserID = addressDetailEntity.UserID,
                            StateID = addressDetailEntity.StateID,
                            CountryID = addressDetailEntity.CountryID
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return listOfAddresses;
        }

        public static  bool UpdateUser(UserModel UserInfo, List<AddressModel> ListofAddresses, int IdToUpdate)
        {

            bool flag = false;

            try
            {
                using (var context = new FORMEntities())
                {
                    // Retrieve the user details from the database based on the user ID
                    var existingUser = context.UserDetails.FirstOrDefault(u => u.UserID == IdToUpdate);


                    // Update user details
                    existingUser.FirstName = UserInfo.FirstName;
                    existingUser.MiddleName = UserInfo.MiddleName;
                    existingUser.LastName = UserInfo.LastName;
                    existingUser.FatherName = UserInfo.FatherName;
                    existingUser.MotherName = UserInfo.MotherName;
                    existingUser.Email = UserInfo.Email;
                    existingUser.Password = UserInfo.Password;
                    existingUser.DOB = UserInfo.DOB;
                    existingUser.BloodGroup = UserInfo.BloodGroup;
                    existingUser.PhoneNumber = UserInfo.PhoneNumber;
                    existingUser.AlternatePhoneNumber = UserInfo.AlternatePhoneNumber;
                    existingUser.GuardianName = UserInfo.GuardianName;
                    existingUser.Gender = UserInfo.Gender;
                    existingUser.Status = UserInfo.Status;
                    existingUser.WorkExperience = UserInfo.WorkExperience;
                    existingUser.Board10th = UserInfo.Board10th;
                    existingUser.Board12th = UserInfo.Board12th;
                    existingUser.Institue12th = UserInfo.Institute12th;
                    existingUser.institue10th = UserInfo.Institute10th;
                    existingUser.Institue12th = UserInfo.InstituteBTECH;
                    existingUser.Percentage10th = UserInfo.Percentage10th;
                    existingUser.Percentage12th = UserInfo.Percentage12th;
                    existingUser.PercentageBTECH = UserInfo.PercentageBTECH;
                    existingUser.Documents = UserInfo.Documents;

                    var presentAddress = context.AddressDetails.FirstOrDefault(a => a.UserID == IdToUpdate && a.Type == (int)Utility.AddressType.Present);
                    var permanentAddress = context.AddressDetails.FirstOrDefault(a => a.UserID == IdToUpdate && a.Type == (int)Utility.AddressType.Permanent);

                    // Update addresses 
                    presentAddress.Address = ListofAddresses[0].Address;
                    permanentAddress.Address = ListofAddresses[1].Address;


                    context.SaveChanges();
                    flag = true;
                }


            }
            catch (DbUpdateException ex)
            {
                Logger.AddData(ex);
            }

            return flag;
        }

       
        public static bool InsertNotes(string InputNoteText, int UserId, int ObjectType)
        {
            bool flag = false;

            try
            {
                using (var context = new FORMEntities())
                {
                    Note newNote = new Note
                    {

                        NoteText = InputNoteText,
                        ObjectID = UserId,
                        ObjectType = ObjectType,
                        CreatedDate = DateTime.Now.ToString("yyyy-MM-dd")
                    };


                    // Add the new note to the context
                    context.Notes.Add(newNote);

                    // Save changes to the database
                    context.SaveChanges();
                    flag = true;
                    // Refresh the displayed notes

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public static List<NoteModel> GetNotes(int UserId, int ObjectType)
        {

            List<NoteModel> ListofNotes = new List<NoteModel>();
            try
            {
                using (var context = new FORMEntities())
                {

                    var userNotes = context.Notes
                        .Where(n => n.ObjectID == UserId && n.ObjectType == ObjectType)
                        .ToList();

                    ListofNotes = userNotes.Select(note => new NoteModel
                    {
                        ObjectType = note.ObjectType,
                        ObjectID = note.ObjectID,
                        NoteText = note.NoteText,
                        NoteID = note.NoteID,
                        CreatedDate = note.CreatedDate

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return ListofNotes;
        }

        public static List<NoteModel> GetAllNotes(int pageIndex, int pageSize, int objectId)
        {
            List<NoteModel> notes = new List<NoteModel>();

            using (var context = new FORMEntities())
            {
                notes = context.Notes
                    .Where(n => n.ObjectID == objectId)
                    .OrderBy(n => n.NoteID)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .Select(n => new NoteModel
                    {
                        NoteID = (int)n.NoteID,
                        NoteText = n.NoteText,
                        ObjectID = n.ObjectID,
                        ObjectType = (int)n.ObjectType,
                        CreatedDate = n.CreatedDate.ToString()
                    })
                    .ToList();
            }
            return notes;
        }
       
        public static List<string> GetAllCountries()
        {
            List<string> countriesList = new List<string>();
            try
            {
                using (var context = new FORMEntities())
                {
                    // Retrieve all countries from the Country table
                    var countries = context.Countries
                        .Select(c => c.CountryName)
                        .ToList();

                    // Now, 'countries' contains a list of all country names
                    countriesList.AddRange(countries);
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return countriesList;
        }

        public static List<string> GetStatesForCountry(string CountryName)
        {
            List<string> statesList = new List<string>();
            try
            {
                using (var context = new FORMEntities())
                {
                    // Retrieve the states for the selected country from the State table
                    statesList = context.States
                        .Where(s => s.Country.CountryName == CountryName)
                        .Select(s => s.StateName)
                        .ToList();

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return statesList;
        }


        public static List<int> GetCountryAndStateID(string CountryName, string StateName)
        {
            List<int> ids = new List<int>();


            try
            {
                using (var context = new FORMEntities())
                {
                    var country = context.Countries.FirstOrDefault(c => c.CountryName == CountryName);
                    var state = context.States.FirstOrDefault(s => s.StateName == StateName);
                    ids.Add(country.CountryID);
                    ids.Add(state.StateID);

                }

            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return ids;

        }

        public static List<UserModel> GetSortedAndPagedUsers(string sortExpression, string sortDirection, int pageIndex, int pageSize)
        {
            List<UserModel> UsersList = new List<UserModel>();
            using (var context = new FORMEntities())
            {
                IQueryable<UserDetail> query = context.UserDetails;

                // Apply dynamic sorting
                query = ApplySorting(query, sortExpression, sortDirection);

                // Apply paging
                List<UserDetail> users = query.Skip(pageIndex * pageSize).Take(pageSize).ToList();

                // Map the result to UserDetailsModel and return the result
                UsersList = users.Select(userModel => new UserModel
                {
                    UserID = userModel.UserID,
                    FirstName = userModel.FirstName,
                    MiddleName = userModel.MiddleName,
                    LastName = userModel.LastName,
                    FatherName = userModel.FatherName,
                    MotherName = userModel.MotherName,
                    Email = userModel.Email,
                    Password = userModel.Password,
                    DOB = userModel.DOB,
                    BloodGroup = userModel.BloodGroup,
                    PhoneNumber = userModel.PhoneNumber,
                    AlternatePhoneNumber = userModel.AlternatePhoneNumber,
                    GuardianName = userModel.GuardianName,
                    Gender = userModel.Gender,
                    Status = userModel.Status,
                    WorkExperience = userModel.WorkExperience,
                    Board10th = userModel.Board10th,
                    Board12th = userModel.Board12th,
                    Institute12th = userModel.Institue12th,
                    Institute10th = userModel.institue10th,
                    InstituteBTECH = userModel.InstitueBTECH,
                    Percentage10th = (int)userModel.Percentage10th,
                    Percentage12th = (int)userModel.Percentage12th,
                    PercentageBTECH = (int)userModel.PercentageBTECH,
                    Documents = userModel.Documents,

                }).ToList();

                return UsersList;
            }
        }

        private static IQueryable<UserDetail> ApplySorting(IQueryable<UserDetail> query, string sortExpression, string sortDirection)
        {
            switch (sortExpression)
            {
                case "UserID":
                    query = (sortDirection == "ASC") ? query.OrderBy(u => u.UserID) : query.OrderByDescending(u => u.UserID);
                    break;
                case "FirstName":
                    query = (sortDirection == "ASC") ? query.OrderBy(u => u.FirstName) : query.OrderByDescending(u => u.FirstName);
                    break;
                case "LastName":
                    query = (sortDirection == "ASC") ? query.OrderBy(u => u.LastName) : query.OrderByDescending(u => u.LastName);
                    break;
                    // Add more cases as needed for other properties
            }

            return query;
        }

        public static int TotalUsers()
        {
            int length = 0;
            try
            {
                using (var context = new FORMEntities())
                {
                    length = context.UserDetails.ToList().Count;

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return length;
        }

        public static List<string> GetCountryAndStateNames(int countryID, int stateID)
        {
            List<string> names = new List<string>();

            try
            {
                using (var context = new FORMEntities())
                {
                    var country = context.Countries.FirstOrDefault(c => c.CountryID == countryID);
                    var state = context.States.FirstOrDefault(s => s.StateID == stateID);

                    names.Add(country.CountryName);
                    names.Add(state.StateName);
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }


            return names;
        }

        public static  bool InsertDocument(string FileName, string uniqueGuid, int ObjectID, int ObjectType, int DocumentType)
        {
            bool flag = false;
            try
            {
                using (var context = new FORMEntities())
                {

                    Document TempDocument = new Document
                    {
                        DocumentOriginalName = FileName,
                        DocumentGuidName = uniqueGuid,
                        ObjectType = ObjectType,
                        ObjectID = ObjectID,
                        DocumentType = DocumentType,
                        TimeStamp = DateTime.Now.ToString(),
                    };

                    // Add the document to the context and save changes
                    context.Documents.Add(TempDocument);
                    context.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return flag;
        }

        public static List<DocumentModel> GetDocuments(int pageIndex, int pageSize, int objectId)
        {
            List<DocumentModel> documents = new List<DocumentModel>();

            using (var context = new FORMEntities())
            {
                documents = context.Documents
                    .Where(n => n.ObjectID == objectId)
                    .OrderBy(n => n.DocumentID)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .Select(n => new DocumentModel
                    {
                        DocumentID = n.DocumentID,
                        ObjectID = n.ObjectID,
                        ObjectType = n.ObjectType,
                        DocumentType = n.DocumentType,
                        DocumentGuidName = n.DocumentGuidName,
                        DocumentOriginalName = n.DocumentOriginalName,
                        TimeStamp = n.TimeStamp.ToString(),
                    })
                    .ToList();
            }
            return documents;
        }

        public static int GetTotalDocuments(int objectId)
        {
            int totalDoc = 0;

            try
            {
                using (var context = new FORMEntities())
                {
                    totalDoc = context.Documents.Count(n => n.ObjectID == objectId); ;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return totalDoc;
        }

        public static void AddDocuments(DocumentModel document)
        {
            using (var context = new FORMEntities())
            {
                Document doc = new Document
                {
                    DocumentID = document.DocumentID,
                    ObjectID = document.ObjectID,
                    ObjectType = document.ObjectType,
                    DocumentType = document.DocumentType,
                    DocumentGuidName = document.DocumentGuidName,
                    DocumentOriginalName = document.DocumentOriginalName,
                    TimeStamp = document.TimeStamp.ToString(),
                };

                context.Documents.Add(doc);
                context.SaveChanges();
            }
        }
        public static List<Document> GetDocumentType()
        {
            List<Document> docTypeList = new List<Document>();
            try
            {
                using (FORMEntities context = new FORMEntities())
                {
                    docTypeList=context.Documents.ToList();
                }
            }
            catch (Exception e)
            {
                Logger.AddData(e);
            }
            return docTypeList;
        }


    }
}
















