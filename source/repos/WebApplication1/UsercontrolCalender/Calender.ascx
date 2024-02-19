<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calender.ascx.cs" Inherits="WebApplication1.Calender" %>

  <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>    
        <asp:Label runat="server" ID="ShowDate" ></asp:Label>  
