<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SinglePage.aspx.cs" Inherits="HTTP_5101_Assignment_Final.SinglePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 runat="server" id="title" class=""></h1>

        <p class="lead">By: <span runat="server" id="author"></span><span runat="server" id="state" class="badge badge-light" style="margin-left:10px"></span></p>

        <p runat="server" id="date"></p>
 
    
        <div class="bg-dark" ></div>
        <p runat="server" id="body" class=""></p>
    
    
</asp:Content>
