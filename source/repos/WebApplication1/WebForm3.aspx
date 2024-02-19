<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                 UserName: <asp:TextBox ID="TextBox2" runat="server" Width="158px"></asp:TextBox>
<br />
Password: <asp:TextBox ID="TextBox3" runat="server" Width="159px"></asp:TextBox>
<br />
<asp:Button ID="Button3" runat="server" onclick="Button3_Click"  Text="Restore" Width="152px" />



        </div>
    </form>
</body>
</html>
