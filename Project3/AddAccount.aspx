<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="Project3.AddAccount" %>

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
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <ul class="nav navbar-nav">
                <li><a href="HomePage.aspx"><img class="navLogo img-responsive" src="Images/TempleLogo.png" alt="Temple Logo"/></a></li>
                <li><a href="HomePage.aspx">Home Page</a></li>
                <li class="active"><a href="AddAccount.aspx">Add Account</a></li>
            </ul>
        </div>
    </nav> 

    <form id="AddAccountForm" runat="server">
        <div class="container">
            <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h2>Add Account Page</h2>
                </div>
            </div>
            <div class="row" >
                <div class="col-lg-11 col-md-11 col-sm-11">
                    <asp:Label ID="lblUsername" runat="server" Text="Enter a username"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="Enter a password"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:CheckBox ID="chkReviewer" runat="server" Text="Are you a Reviewer?" />
                    <br />
                    <asp:CheckBox ID="chkRepresentative" runat="server" Text="Are you a Representative?" />
                    <br />
                    <br />
                    <asp:Button ID="btnAddAccount" CssClass="btn-sm btn-primary btn-block" runat="server" type="submit" Text="Add Account" OnClick="btnAddAccount_Click" />
                </div>
                <div class="col-lg-1 col-md-1 col-sm-1">
                    <asp:Label ID="lblUsernameDB" runat="server" Text="Username DB"></asp:Label>
                    <br />
                    <asp:Label ID="lblPasswordDB" runat="server" Text="Password DB"></asp:Label>
                    <br />
                    <asp:Label ID="lblUserTitleDB" runat="server" Text="User Title"></asp:Label>
                </div>
            </div>
        </div>
    </form>
    </body>

    <footer class="footer" id="page_footer">
        <nav class="navbarfooter navbar-default navbar-fixed-bottom">
            <div class="navbar-text pull-left">
                <p>&copy; Kevin Pham 2016</p>
            </div>
                <ul class="nav navbar-nav">
                    <li><a href="HomePage.aspx">Home Page</a></li>
                    <li><a href="AddAccount.aspx">Add Account</a></li>
                </ul>
                
        </nav> 
    </footer>
</html>
