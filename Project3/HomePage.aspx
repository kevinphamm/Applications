<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project3.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.12.0.min.js"></script>
    <link href="jquery-ui-1.11.4.custom/jquery-ui.css" rel="stylesheet" />
    <script src="jquery-ui-1.11.4.custom/jquery-ui.min.js"></script>
    <script src="js/jquery.maskedinput.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.js"></script>
    <link href="css/StyleSheet1.css" rel="stylesheet" />
</head>
<body>


    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4"><br /></div>
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4">
                <h2 class="text-center login-title">Welcome! Sign in to view the Main page.</h2>
                <form id="LoginForm" runat="server">
                <div>  
                <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                <br />
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Button ID="btnLogin" CssClass="btnLogin btn-lg btn-primary btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Button ID="btnUser" CssClass="btnLogin btn-lg btn-primary btn-block" runat="server" Text="Login as User" OnClick="btnUser_Click" />
                <asp:Button ID="btnAddAccount" CssClass="btnLogin btn-lg btn-primary btn-block" runat="server" Text="Add Account" OnClick="btnAddAccount_Click" />
                </div>
                </form>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
        </div>
    </div>

</body>
</html>
