<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListWebPages.aspx.cs" Inherits="HTTP_5101_Assignment_Final.ListWebPages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .addbutton{
            float:right;
        }
        .displayTable{
            padding:15px;
        }
    </style>
    <h1>Dashboard</h1>
    <p class="lead">Here is your dashboard where you can view all your pages and search for pages.</p>
    <div class="card">
        <div class="form-inline">
            <div class="form-group">
                <label for="webpage_search">Search for Page:</label>
                <asp:TextBox class="form-control" id="webpage_search" runat="server"></asp:TextBox>
            
            </div>
            <asp:Button runat="server" Text="Search!" CssClass="btn"/>
            <asp:Button runat="server" Text="Add a Page" onClick="addPage" CssClass="btn btn-primary addbutton"/>
        </div>
    </div>
    <h2>Your Pages</h2>
    <p>You can also edit and delete a page. Along with adding a webpage</p>
    <div id="list_pages" runat="server" class="bg-dark displayTable">

    </div>
</asp:Content>
