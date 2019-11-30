<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="HTTP_5101_Assignment_Final.UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Changes to <span id="pagename" runat="server"></span></h2>
        <p class="lead">Update your page info as well as publishing or unpublishing your page</p>
        <div class="alert alert-success" id="alert" runat="server">
            <p id="output" runat="server"></p>
        </div>
        <div class="form" id="updatepageForm" runat="server">
                <div class="form-group row">
                    <label for="txtpage_title" class="col-sm-2 col-form-label">Page Title:</label>
                    <div class="col-sm-5">
                        <asp:TextBox runat="server" ID="txtpage_title" name="txtpage_title"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="txtpage_title" Text="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="ddpage_author" class="col-sm-2 col-form-label">Page Author</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddpage_author" runat="server">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                </div> 
                <div class="form-group row">
                    <label for="txtpage_body" class="col-sm-2 col-form-label">Page Body:</label>
                    <div class="col-sm-5">     
                        <textarea class="form-control" id="txtpage_body" runat="server"></textarea>
                        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="txtpage_body" Text="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                
                <asp:Button runat="server" Text="Publish" ID="publish_button" OnClick="publish_button_Click" CssClass="btn btn-primary" />
                <asp:Button runat="server" Text="Un Publish" ID="unpublish_button" OnClick="unpublish_button_Click" CssClass="btn btn-warning" />
                <asp:Button runat="server" Text="Update" ID="add_button" OnClick="UpdateButton_Click" cssClass="btn btn-primary"/>
            </div>
    </div>
</asp:Content>
