<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Users.aspx.cs" Inherits="DemoUserManagement.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanel">
            <ContentTemplate>
                <asp:GridView ID="userDetailsGridView" runat="server"
                    AutoGenerateColumns="false" AllowCustomPaging="True"
                    PageSize="4" OnPageIndexChanging="UserDetailsGridView_PageIndexChanging"
                    AllowSorting="True" OnSorting="userDetailsGridView_Sorting" AllowPaging="True" CssClass="gridview-style" EmptyDataText="no records  to display">
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="Password" HeaderText="Password" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                        <asp:BoundField DataField="FatherName" HeaderText="FatherName" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                    </Columns>
                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First"
                        LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />

                    <HeaderStyle BackColor="#E2E2E2" ForeColor="#333333" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
                </asp:GridView>
            </ContentTemplate>

        </asp:UpdatePanel>











    </div>
</asp:Content>
