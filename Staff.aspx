<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Project445.Staff" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Staff Management</title>
    <style>
        .dropdown-menu {
            position: absolute;
            top: 40px;
            right: 10px;
            background-color: white;
            border: 1px solid #ccc;
            border-radius: 4px;
            padding: 10px;
            z-index: 1000;
        }

        .dropdown-item {
            display: block;
            padding: 5px 10px;
            text-align: left;
            cursor: pointer;
        }

        .dropdown-item:hover {
            background-color: #f0f0f0;
        }



        .container {
            padding: 20px;
            font-family: Arial, sans-serif;
        }
        .form-section, .list-section {
            margin-bottom: 20px;
        }
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
        }
        button {
            padding: 10px 15px;
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
        }
        button:hover {
            background-color: #0056b3;
        }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        table th, table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        table th {
            background-color: #f4f4f4;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Staff Management</h2>
            <!-- Add New Staff -->
            <div class="form-section">
                <h3>Add New Staff</h3>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter username"></asp:TextBox>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                <button type="button" runat="server" onserverclick="AddStaff_Click">Add Staff</button>
            </div>

             
            <div style="position: absolute; top: 10px; right: 10px;" class="user-dropdown">
                
                <div class="dropdown-menu">
                    <asp:Label 
                        ID="lblLoggedInUser" 
                        runat="server" 
                        CssClass="dropdown-item">
                    </asp:Label>
                    <asp:Button 
                        ID="btnLogout" 
                        runat="server" 
                        Text="Logout" 
                        OnClick="btnLogout_Click" 
                        CssClass="dropdown-item" />
                </div>
            </div>



            <!-- Existing Staff -->
            <div class="list-section">
                <h3>Existing Staff</h3>
                <asp:GridView ID="gvStaff" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvStaff_RowDeleting" DataKeyNames="Username">
                    <Columns>
                        <asp:BoundField DataField="Username" HeaderText="Username" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </form>
</body>
</html>
