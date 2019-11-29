<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="HTTP_5101_Assignment_Final.AddPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="newClassForm" runat="server">
        <div class="card text-dark bg-light mb-3" style="max-width: 75%;"  runat="server">
        <div class="card-header text-dark">Add New Page</div>
        <div class="card-body">
            <div class="form" runat="server">
                <div class="form-group row">
                    <label for="txtpage_title" class="col-sm-3 col-form-label">Page Title:</label>
                    <div class="col-sm-5">
                        <asp:TextBox runat="server" ID="txtpage_title" name="page_title"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="txtpage_title" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtpage_body" class="col-sm-3 col-form-label">Page Body:</label>
                    <div class="col-sm-5">     
                        <textarea class="form-control" id="txtpage_body" runat="server"></textarea>
                        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="txtpage_body" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="ddpage_author" class="col-sm-3 col-form-label">Page Author</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddpage_author" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>    
                <div class="form-group row">    
                    <label for="chkpublish" class="col-sm-3 col-form-label">Publish:</label>   
                    <div class="col-sm-5">
                        <asp:CheckBox ID="chkpublish" runat="server" />
                    </div> 
                 </div>
                <button type="button" onclick="location.href='Classes.aspx'" class="btn btn-primary">Go Back</button>
                <asp:Button runat="server" Text="Add New Entry" ID="addbutton" OnClick="AddButton_Click" CssClass="btn btn-warning"/>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
