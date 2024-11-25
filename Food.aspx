<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Food.aspx.cs" Inherits="Project445.Food" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu</title>
    <style type="text/css">
        .menu-table {
            width: 80%;
            margin: 50px auto;
            border-collapse: collapse;
        }
        .menu-table th, .menu-table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
            vertical-align: middle;
        }
        .menu-table th {
            background-color: #f2f2f2;
        }
        .menu-table tr:hover {
            background-color: #f1f1f1;
        }
        .menu-table img {
            max-width: 100px;
            height: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="gvMenuItems" runat="server" CssClass="menu-table" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="imgMenuItem" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' AlternateText='<%# Eval("Name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Menu Item" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            </Columns>
            <HeaderStyle BackColor="#f2f2f2" />
        </asp:GridView>
    </form>
</body>
</html>
