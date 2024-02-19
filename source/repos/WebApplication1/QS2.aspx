<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QS2.aspx.cs" Inherits="WebApplication1.QS2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .auto-style1 {
        width: 463px;
        height: 127px;
        margin-top: 0px;
    }
    .auto-style2 {
        width: 260px;
    }
    .auto-style3 {
        width: 226px;
    }
    .auto-style4 {
        margin-left: 18px;
    }
    .auto-style5 {
        margin-left: 122px;
    }
   
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table cellpadding="3" cellspacing="4" class="auto-style1" border="1">
     <tr>
         <td class="auto-style2">STUDENT NAME</td>
         <td class="auto-style3">
             <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Width="182px"></asp:TextBox>
         </td>
     </tr>
     <tr>
         <td class="auto-style2">STUDENT ID</td>
         <td class="auto-style3">
             <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style4" Width="182px"></asp:TextBox>
         </td>
     </tr>
     <tr>
         <td class="auto-style2">STUDENT EMAIL</td>
         <td class="auto-style3">
             <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style4" Width="182px"></asp:TextBox>
         </td>
     </tr>
 </table>
        </div>
    </form>
</body>
</html>
