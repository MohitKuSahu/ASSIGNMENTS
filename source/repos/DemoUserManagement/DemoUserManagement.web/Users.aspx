<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Users.aspx.cs" Inherits="DemoUserManagement.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>

   <asp:GridView ID="userDetailsGridView" runat="server" 
       AutoGenerateColumns="false" AllowCustomPaging="True" 
       PageSize="10" OnPageIndexChanging="UserDetailsGridView_PageIndexChanging" 
       AllowSorting="True" OnSorting="userDetailsGridView_Sorting" AllowPaging="True"  CssClass="gridview-style" EmptyDataText="no records  to display" >
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"  />
        <asp:BoundField DataField="LastName" HeaderText="Last Name"  />   
        <asp:BoundField DataField="Password" HeaderText="Password"  />
        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number"  />
        <asp:BoundField DataField="FatherName" HeaderText="FatherName"  />
        <asp:BoundField DataField="Email" HeaderText="Email"  />
    </Columns>
    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" 
        LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />  
</asp:GridView>


  <asp:GridView ID="addressGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
    <Columns>
         <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID"/>       
        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"/>
        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type"/>
        <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
        <asp:BoundField DataField="CountryID" HeaderText="CountryID" SortExpression="CountryID" />
         <asp:BoundField DataField="StateID" HeaderText="StateID" SortExpression="StateID" />
    </Columns>
</asp:GridView>

           
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FORMConnectionString %>" ProviderName="<%$ ConnectionStrings:FORMConnectionString.ProviderName %>" SelectCommand="SELECT [ID], [Address], [Type], [UserID], [CountryID], [StateID] FROM [AddressDetails]"></asp:SqlDataSource>

           
          



              
        </div>
    </asp:Content>
