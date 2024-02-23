<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="DemoUserManagement.LoginForm" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style type="text/css">
    body {
        font-family: Arial, sans-serif;
        background-color: #f4f4f4;
        margin: 0;
        padding: 0;
    }

    .login-container {
        max-width: 400px;
        margin: auto;
        padding: 20px;
        background-color: #ffffff;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        border-radius: 5px;
        margin-top: 50px;
    }

    h2 {
        text-align: center;
        color: #333333;
    }

    .login-input {
        width: 100%;
        padding: 10px;
        margin-top: 10px;
        margin-bottom: 15px;
        box-sizing: border-box;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

    .login-button {
        width: 100%;
        padding: 10px;
        background-color: #4caf50;
        color: #ffffff;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .login-button:hover {
        background-color: #45a049;
    }

    .signup-button {
        width: 100%;
        padding: 10px;
        background-color: #337ab7;
        color: #ffffff;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .signup-button:hover {
        background-color: #286090;
    }

    .login-container div {
        text-align: center;
        margin-top: 15px;
    }

    .error-message {
        color: red;
        margin-top: 10px;
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

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-button" OnClick="BtnLogin_Click" />
            <div>
            <asp:Button ID="btnSignup" runat="server" Text="New User? SignUP " CssClass="signup-button" OnClick="BtnSignup_Click" CausesValidation="false" />
            </div>
        </div>
    </form>
</body>
</html>
