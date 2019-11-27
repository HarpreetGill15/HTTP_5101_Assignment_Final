<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListWebPages.aspx.cs" Inherits="HTTP_5101_Assignment_Final.ListWebPages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Dashboard</h1>
    <div class="card">
        <asp:Label runat="server" for="webpage_search">Search Page:</asp:Label>
        <asp:TextBox ID="webpage_search" runat="server"></asp:TextBox>
        <asp:Button runat="server" Text="Search!"/>
    </div>
    <div id="list_pages" runat="server">

    </div>
</asp:Content>
