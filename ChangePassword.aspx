<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Project445.ChangePassword" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Change Password</title>
    <style>
        .container {
            margin: 50px auto;
            padding: 20px;
            max-width: 500px;
            background-color: #f8f8f8;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            font-weight: bold;
        }
        .form-group input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .form-group button {
            padding: 10px 15px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .form-group button:hover {
            background-color: #0056b3;
        }
        .message {
            margin-top: 15px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="formChangePassword" runat="server">
        <div class="container">
            <h2>Change Password</h2>
            <div class="form-group">
                <label for="txtCurrentPassword">Current Password</label>
                <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" />
            </div>
            <div class="form-group">
                <label for="txtNewPassword">New Password</label>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" />
            </div>
            <div class="form-group">
                <label for="txtConfirmNewPassword">Confirm New Password</label>
                <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
            </div>
            <div class="message">
                <asp:Label ID="lblMessage" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
