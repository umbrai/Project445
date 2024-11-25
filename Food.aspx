<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Food.aspx.cs" Inherits="Project445.Food" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
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
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align:center;">Our Menu</h1>
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
</asp:Content>
