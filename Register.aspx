<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="E_Commerce_App.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <form method="post" action="Register.aspx" class="form col-md-6" id="reg_form">
        <div class="form-group ">
            <label>Email</label>
            <input type="text" runat="server" class="form-control" id="txt_email" name="txt_email" />

            <asp:RequiredFieldValidator ID="val_email" runat="server" ErrorMessage="Email Address Is Required" ControlToValidate="txt_email" Display="None"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="reg_email" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="txt_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Visible="true" Display="None"></asp:RegularExpressionValidator>

        </div>
        <div class="form-group">
            <label>First Name</label>
            <input type="text" runat="server" class="form-control" id="txt_fName" name="txt_fName"/>
            <asp:RequiredFieldValidator ID="val_first_name" runat="server" Display="None" ErrorMessage="First Name Is Required" ControlToValidate="txt_fName"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <label>Last Name</label>
            <input type="text" runat="server" class="form-control" id="txt_lName" name="txt_lName"/>
            <asp:RequiredFieldValidator ID="val_last_name" runat="server" Display="None" ErrorMessage="Last Name Is Required" ControlToValidate="txt_lName"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <label>Password</label>
            <input type="password" runat="server" class="form-control" id="txt_password" name="txt_password"/>
            <asp:RequiredFieldValidator ID="val_passsword" runat="server" Display="None" ErrorMessage="Username Is Required" ControlToValidate="txt_password"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Repeat Password</label>
            <input type="password" runat="server" class="form-control" id="txt_repeatPassword" name="txt_repeatPassword"/>
            <asp:RequiredFieldValidator ID="val_repeat_password" runat="server" Display="None" ErrorMessage="Please Repeat Passsword" ControlToValidate="txt_repeatPassword"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="val_compare_password" runat="server" Display="None" ErrorMessage="Password Mismatch" ControlToCompare="txt_password" ControlToValidate="txt_repeatPassword"></asp:CompareValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="Button1"  runat="server" BorderStyle="Groove" CssClass="btn-info" OnClick="Button1_Click" Text="Button" />
&nbsp;</div>
        <div class="form-group">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        </div>
    </form>
</asp:Content>
