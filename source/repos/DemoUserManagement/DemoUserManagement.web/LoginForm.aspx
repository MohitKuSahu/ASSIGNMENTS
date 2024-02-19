<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="LoginForm.aspx.cs" Inherits="DemoUserManagement.LoginForm" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .login-container {
            width: 300px;
            margin: auto;
            margin-top: 100px;
        }

        .login-input {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
        }

        .login-button {
            width: 100%;
            padding: 10px;
            background-color: #4caf50;
            color: white;
            border: none;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="login-input" placeholder="Email" AutoPostBack="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="Email is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="login-input" placeholder="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-button" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
