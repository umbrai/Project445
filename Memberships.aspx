﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Memberships.aspx.cs" Inherits="Project445.Memberships" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Memberships</title>
    <style type="text/css">
        .membership-table {
            width: 70%;
            margin: 50px auto;
            border-collapse: collapse;
        }
        .membership-table th, .membership-table td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        .membership-table th {
            background-color: #f2f2f2;
            text-align: left;
        }
        .membership-table tr:hover {
            background-color: #f1f1f1;
        }
        .membership-description {
            max-width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align:center;">Our Membership Plans</h1>
        <asp:GridView ID="gvMemberships" runat="server" CssClass="membership-table" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Membership Plan" />
                <asp:BoundField DataField="Duration" HeaderText="Duration" />
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <div class="membership-description">
                            <%# Eval("Description") %>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            </Columns>
            <HeaderStyle BackColor="#f2f2f2" />
        </asp:GridView>
    </form>
</body>
</html>