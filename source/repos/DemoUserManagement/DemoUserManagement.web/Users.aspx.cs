using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagement.Business;
using DemoUserManagement.Models;
using DemoUserManagement.Web;


namespace DemoUserManagement
{
    public partial class Users : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                ViewState["SortDirection"] = "ASC";


                ViewState["SortExpression"] = "UserID";

                BindGridView();
            }



        }


        public void BindGridView()
        {

            int currentPageIndex = userDetailsGridView.PageIndex;
            int pageSize = userDetailsGridView.PageSize;
            string sortExpression = ViewState["SortExpression"].ToString();
            string sortDirection = ViewState["SortDirection"]?.ToString() ?? "ASC";

            int totalCount = GetTotalCount();

            userDetailsGridView.VirtualItemCount = totalCount;

            userDetailsGridView.DataSource = BusinessLayer.GetSortedAndPagedUsers(sortExpression, sortDirection, currentPageIndex * pageSize, pageSize);
            userDetailsGridView.DataBind();





        }
        private int GetTotalCount()
        {
            int TotalCount = 0;
            TotalCount = BusinessLayer.TotalUsers();
            return TotalCount;
        }



        protected void UserDetailsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
         
            userDetailsGridView.PageIndex = e.NewPageIndex;

      
            BindGridView(); 
        }

        protected void userDetailsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
         
            string SortDirection = ViewState["SortDirection"]?.ToString() ?? "ASC";

          
            SortDirection = SortDirection == "ASC" ? "DESC" : "ASC";

          
            ViewState["SortDirection"] = SortDirection;

            ViewState["SortExpression"] = e.SortExpression;

            BindGridView();

        }

    }
}