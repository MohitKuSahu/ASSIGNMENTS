﻿using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUserManagement.DAL;
using DemoUserManagement.Utils;
using static DemoUserManagement.Utils.Utility;

namespace DemoUserManagement.Business
{
    public class BusinessLayer
    {
        
       
        public static Dictionary<string, int> InsertUser(UserModel NewUser, List<AddressModel> ListofAddresses)
        {
            return DAL.DAL.InsertUser(NewUser, ListofAddresses);

        }

        public static UserModel GetUserDetails(int id)
        {
            return DAL.DAL.GetUserDetails(id);
        }

        public static List<AddressModel> GetAddresses(int UserId)
        {
            return DAL.DAL.GetAddresses(UserId);
        }


        public static bool UpdateUser(UserModel UserInfo, List<AddressModel> ListofAddresses, int IdToUpdate)
        {
            return DAL.DAL.UpdateUser(UserInfo, ListofAddresses, IdToUpdate);

        }

        public static  bool InsertNotes(string InputNoteText, int UserId, int ObjectType)
        {
            return DAL.DAL.InsertNotes(InputNoteText, UserId, ObjectType);
        }

        public static List<NoteModel> GetNotes(int UserId, int ObjectType)
        {
            return DAL.DAL.GetNotes(UserId, ObjectType);
        }

        public static  List<UserModel> GetAllUsers()
        {
            return DAL.DAL.GetAllUsers();
        }

        public static List<string> GetAllCountries()
        {
            return DAL.DAL.GetAllCountries();
        }

        public static List<string> GetStatesForCountry(string SelectedCountry)
        {
            return DAL.DAL.GetStatesForCountry(SelectedCountry);
        }

        public static List<AddressModel> GetAllUsersAddresses()
        {
            return DAL.DAL.GetAllUsersAddresses();
        }

        public static List<int> GetCountryAndStateID(string CountryName, string StateName)
        {
            return DAL.DAL.GetCountryAndStateID(CountryName, StateName);
        }

        public static List<string> GetCountryAndStateNames(int CountryID, int StateID)
        {
            return DAL.DAL.GetCountryAndStateNames(CountryID, StateID);
        }

        public static List<UserModel> GetSortedAndPagedUsers(string SortExpression, string SortDirection, int PageIndex, int PageSize)
        {
            return DAL.DAL.GetSortedAndPagedUsers(SortExpression, SortDirection, PageIndex, PageSize);
        }

        public static int TotalUsers()
        {
            return DAL.DAL.TotalUsers();
        }


        public static bool InsertDocument(string FileName, string uniqueGuid, int ObjectID, int ObjectType, int DocumentType)
        {
            return DAL.DAL.InsertDocument(FileName, uniqueGuid, ObjectID, ObjectType, DocumentType);
        }

        public static List<DocumentModel> GetDocumentType()
        {
            List<Document> documentTypes = DAL.DAL.GetDocumentType();
            List<DocumentModel> docType = documentTypes.Select(doc => new DocumentModel
            {
                DocumentID = doc.DocumentID,
                DocumentType = doc.DocumentType
            }).ToList();

            return docType;
        }

        public static void AddDocument(DocumentModel doc)
        {
            DAL.DAL.AddDocuments(doc);
        }

        public static List<DocumentModel> GetUploadedDocuments(int pageIndex, int pageSize, int objectId)
        {
            return DAL.DAL.GetDocuments(pageIndex, pageSize, objectId);
        }

        public static int GetTotalDocuments(int objectId)
        {
            return DAL.DAL.GetTotalDocuments(objectId);
        }
    }
}
