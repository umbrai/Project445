<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project445.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login or Register</title>
    <style type="text/css">
        /* General styles */
        body {
            font-family: Arial, sans-serif;
        }

        .container {
            width: 400px;
            margin: 0 auto;
            padding-top: 50px;
        }

        .tab-container {
            display: flex;
            justify-content: space-around;
            margin-bottom: 20px;
        }

        .tab-container button {
            flex: 1;
            padding: 10px;
            background-color: #f0f0f0;
            border: 1px solid #ccc;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .tab-container button.active {
            background-color: #4285F4;
            color: white;
        }

        .form-container {
            display: none;
        }

        .form-container.active {
            display: block;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 5px;
            margin-bottom: 15px;
            box-sizing: border-box;
        }

        button.submit-btn {
            width: 100%;
            padding: 10px;
            background-color: #4285F4;
            color: white;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        button.submit-btn:hover {
            background-color: #0056b3;
        }

        .captcha-section {
            text-align: center;
        }

        .message {
            text-align: center;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
             <div class="button-group">
                <asp:Button ID="Button2" runat="server" Text="Go to Staff Login" CssClass="btn" OnClick="StaffLoginButton_Click" />
            </div>

    <div class="tab-container">
        <button type="button" class="tab-btn active" onclick="showTab('login')">Login</button>
        <button type="button" class="tab-btn" onclick="showTab('register')">Register</button>
    </div>

            

    <!-- Login Form -->
    <div id="login" class="form-container active">
        <asp:Label ID="lblLoginMessage" runat="server" CssClass="message"></asp:Label>
        <label for="txtLoginUserID">User ID:</label>
        <asp:TextBox ID="txtLoginUserID" runat="server"></asp:TextBox>

        <label for="txtLoginPassword">Password:</label>
        <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" onkeypress="handleEnter(event)"></asp:TextBox>

        <label for="txtRegisterCaptcha">Enter CAPTCHA:</label>
        <div class="captcha-section">
            <img src="Captcha.aspx" alt="CAPTCHA" />
            <asp:TextBox ID="txtRegisterCaptcha" runat="server" onkeypress="handleEnter(event)"></asp:TextBox>
        </div>

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="submit-btn" />
    </div>

    <!-- Register Form -->
    <div id="register" class="form-container">
        <asp:Label ID="lblRegisterMessage" runat="server" CssClass="message"></asp:Label>
        <label for="txtRegisterUserID">User ID:</label>
        <asp:TextBox ID="txtRegisterUserID" runat="server"></asp:TextBox>

        <label for="txtRegisterPassword">Password:</label>
        <asp:TextBox ID="txtRegisterPassword" runat="server" TextMode="Password" ></asp:TextBox>

        

        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="submit-btn" />
    </div>
</div>

    </form>

    <script type="text/javascript">
        function showTab(tab) {
            const tabs = document.querySelectorAll('.tab-container button');
            const forms = document.querySelectorAll('.form-container');

            tabs.forEach(t => t.classList.remove('active'));
            forms.forEach(f => f.classList.remove('active'));

            document.getElementById(tab).classList.add('active');
            event.target.classList.add('active');
        }

        function handleEnter(event) {
            if (event.key === "Enter") {
                event.preventDefault(); // Prevent the default form submission behavior
                document.getElementById('<%= btnLogin.ClientID %>').click(); 
            }
        }
    </script>
</body>
</html>
