<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="HTTP_5101_Assignment_Final.DeletePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Are you sure you want to delete <span id="page" runat="server"></span></h2>

        <asp:Button ID="yes_delete" runat="server" Text="Button" onclick="yes_delete_Click"/>
        <asp:Button ID="go_back" runat="server" Text="Button" onclick="go_back_Click"/>
    </div>
</asp:Content>
