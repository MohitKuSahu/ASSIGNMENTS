using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using DemoUserManagement.Business;
using static DemoUserManagement.Utils.Utility;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Xml;
using System;
using System.Linq;
using System.Web.Services.Description;
using System.Data.Entity.Core.Common.CommandTrees;


namespace DemoUserManagement.Web.User_Control
{
    public partial class DocumentUserControl : System.Web.UI.UserControl
    {
        public int ObjectId { get; set; }
        public Utility.ObjectType ObjectTypeName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ObjectId"] = ObjectId;
                BindGridView();
            }
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileUpload.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    string guid = Guid.NewGuid().ToString();
                    string folderPath = Server.MapPath("~/Output/");
                    string filePath = Path.Combine(folderPath, guid + fileExtension);

                    fileUpload.SaveAs(filePath);




                    DocumentModel document = new DocumentModel
                    {
                        ObjectID = Convert.ToInt32(ViewState["ObjectId"]),
                        ObjectType = (int)ObjectType.UserForm,
                        DocumentOriginalName = filename,
                        DocumentGuidName = guid + fileExtension,
                        TimeStamp = DateTime.Now.ToString("d")
                    };

                    BusinessLayer.AddDocument(document);



              
                    BindGridView();


                }

                catch (Exception ex)
                {
                    Logger.AddData(ex);
                }
            }
        }

        protected void DocumentGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DocumentGrid.PageIndex = e.NewPageIndex;
                BindGridView();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        protected void DocumentGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string sortExpression = e.SortExpression;
                string sortDirection = GetSortDirection();
                ViewState["SortExpression"] = sortExpression;
                ViewState["SortDirection"] = sortDirection;

                BindGridView();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        private void BindGridView()
        {
            try
            {
                int CurrentPageIndex = DocumentGrid.PageIndex;
                int PageSize = DocumentGrid.PageSize;
                string SortExpression = ViewState["SortExpression"] as string ?? "DocumentID";
                string SortDirection = ViewState["SortDirection"] as string ?? "ASC";


                DocumentGrid.VirtualItemCount = BusinessLayer.GetTotalDocuments(Convert.ToInt32(ViewState["ObjectId"]));

                List<DocumentModel> ListofDocuments = BusinessLayer.GetDocuments(CurrentPageIndex,PageSize, Convert.ToInt32(ViewState["ObjectId"]));
                if (!string.IsNullOrEmpty(SortExpression))
                {
                    if (SortDirection == "ASC")
                    {
                        ListofDocuments = ListofDocuments.OrderBy(n => GetPropertyValue(n, SortExpression)).ToList();
                    }
                    else
                    {
                        ListofDocuments = ListofDocuments.OrderByDescending(n => GetPropertyValue(n, SortExpression)).ToList();
                    }
                }
                DocumentGrid.DataSource = ListofDocuments;
                DocumentGrid.DataBind();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        private string GetSortDirection()
        {
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = "ASC";
            }
            else
            {
                if (ViewState["SortDirection"].ToString() == "ASC")
                {
                    ViewState["SortDirection"] = "DESC";
                }
                else
                {
                    ViewState["SortDirection"] = "ASC";
                }
            }

            return ViewState["SortDirection"].ToString();
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            Type objType = obj.GetType();
            PropertyInfo propInfo = objType.GetProperty(propertyName);

            if (propInfo != null)
            {
                return propInfo.GetValue(obj);
            }
            else
            {
                return null;
            }
        }

    }
}