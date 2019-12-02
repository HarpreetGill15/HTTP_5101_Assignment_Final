<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SinglePage.aspx.cs" Inherits="HTTP_5101_Assignment_Final.SinglePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1{
            font-size:60px;
        }
        .lead{
            font-size:15px;
            margin-bottom:0;
        }
        p{
            margin:0;
        }
        .content{
            margin-top:20px;
            font-size:25px;
        }
    </style>
    <h1 runat="server" id="title" class="mt-2"></h1>

        <p class="lead">By: <span runat="server" id="author"></span><span runat="server" id="state" class="badge badge-light" style="margin-left:10px"></span></p>

        <p runat="server" id="date"></p>
 
    
    
        <p runat="server" id="body" class="content"></p>
    
    
</asp:Content>
