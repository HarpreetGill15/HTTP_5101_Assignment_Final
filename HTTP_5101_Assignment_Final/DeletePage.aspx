﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="HTTP_5101_Assignment_Final.DeletePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Are you sure you want to delete <span id="title" runat="server"></span>?</h2>
        <asp:Button ID="yes_delete" runat="server" Text="Yes Delete" onclick="yes_delete_Click" CssClass="btn btn-danger"/>
        <asp:Button ID="go_back" runat="server" Text="Go Back" onclick="go_back_Click" CssClass="btn btn-success"/>
    </div>
</asp:Content>
