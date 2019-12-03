<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListWebPages.aspx.cs" Inherits="HTTP_5101_Assignment_Final.ListWebPages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .badge{
            font-size:90%;
            margin:0 5px;
        }
    </style>
    <h1>Dashboard</h1>
    <p class="lead">Here is your dashboard where you can view all your pages and search for pages.</p>
        <div class="form-inline mb-4">
            <div class="form-group">
                <label for="webpage_search">Search for Page:</label>
                <asp:TextBox class="form-control" id="webpage_search" runat="server"></asp:TextBox>
            
            </div>
            <asp:Button runat="server" Text="Search!" CssClass="btn btn-primary"/>
            
        </div>
    <asp:Button runat="server" Text="Add a Page" onClick="addPage" CssClass="btn btn-primary float-right"/>
    <h2>Your Pages</h2>
    <p>You can also edit and delete a page. Along with adding a webpage</p>
    <div id="list_pages" runat="server" class="bg-light displayTable">

    </div>
</asp:Content>
