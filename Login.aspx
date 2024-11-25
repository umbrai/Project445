<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project445.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page with CAPTCHA</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
        }
        .login-container {
            width: 350px;
            margin: 0 auto;
            padding-top: 50px;
        }
        .login-container h2 {
            text-align: center;
        }
        .login-container div {
            margin-bottom: 15px;
        }
        .login-container label {
            display: block;
        }
        .login-container input[type="text"],
        .login-container input[type="password"] {
            width: 100%;
            padding: 5px;
            box-sizing: border-box;
        }
        .login-container img {
            display: block;
            margin: 10px auto;
        }
        .login-container button {
            width: 100%;
            padding: 10px;
        }
        .message {
            text-align: center;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>

            <div>
                <asp:Label ID="lblUserID" runat="server" Text="User ID:" AssociatedControlID="txtUserID"></asp:Label>
                <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <!-- Text-based CAPTCHA -->
            <asp:Panel ID="panelTextCaptcha" runat="server">
                <img src="Captcha.aspx" alt="CAPTCHA Image" />
                <asp:Label ID="lblCaptcha" runat="server" Text="Enter the text shown above:" AssociatedControlID="txtCaptcha"></asp:Label>
                <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
            </asp:Panel>

            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
