<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_Commerce_App.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
        <div class="form-group " style="margin-top:30px;">
            <label>Email</label>
            <input type="text" runat="server" class="form-control" id="txt_email" name="txt_email" />

            <asp:RequiredFieldValidator ID="val_email" runat="server" ErrorMessage="Email Address Is Required" ControlToValidate="txt_email" Display="None"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="reg_email" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="txt_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Visible="true" Display="None"></asp:RegularExpressionValidator>

        </div>
        <div class="form-group">
            <label>Password</label>
            <input type="password" runat="server" class="form-control" id="txt_password" name="txt_password"/>
            <asp:RequiredFieldValidator ID="val_passsword" runat="server" Display="None" ErrorMessage="Password Is Required" ControlToValidate="txt_password"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <input  id="chkRememberMe" type="checkbox"  runat="server"/>
            <label style="margin-right:20px;">Remember Me</label>
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success" OnClick="btnLogin_Click" Text="Login" />
            <br />
            <asp:HyperLink ID="lnkSignUp" runat="server" NavigateUrl="Register.aspx">Create New Account</asp:HyperLink>
        </div>
        <div class="form-group">

        </div>

        <div class="form-group">
            <asp:ValidationSummary ID="val_sum" runat="server" ForeColor="Red" />
        </div>
    

</asp:Content>
