<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Test" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        <div>
           <%-- <asp:TextBox ID="textbox1" runat="server"></asp:TextBox> --%>
            

            
            UserName: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Password: <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Submit" />
        
        </div>
  

    </asp:Content>