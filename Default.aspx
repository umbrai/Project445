<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project445.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Welcome to Movie Application</title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #f0f0f0;
        }
        .button-container {
            text-align: center;
        }
        .btn {
            display: block;
            width: 300px;
            padding: 20px;
            font-size: 20px;
            margin: 20px auto;
            color: white;
            background-color: #007bff;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            text-transform: uppercase;
        }
        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome to the Movie Application</h1>
            <div class="intro-text">
                <p>This application provides movie information, including upcoming movies and currently playing movies in theaters.</p>
                <p>End users can search for movies, view details, and explore different movie categories.</p>
                <p>To access additional features, please sign up for a Member account or log in as a Staff user.</p>
                <p><strong>Testing Instructions:</strong> The TA/grader can sign up with a sample Member account or use a provided Staff account for testing. Please use the following test cases:
                    <ul>
                        <li>Test Case 1: Search for a movie title (e.g., "Avatar").</li>
                        <li>Test Case 2: Access the Member page features (requires login).</li>
                        <li>Test Case 3: Access the Staff page features (requires login as a Staff user).</li>
                    </ul>
                </p>
            </div>

        <div class="button-container">
            <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn" OnClick="LoginButton_Click" />
            <asp:Button ID="ContinueButton" runat="server" Text="Continue Without Login" CssClass="btn" OnClick="ContinueButton_Click" />
        </div>
    </form>
</body>
</html>
