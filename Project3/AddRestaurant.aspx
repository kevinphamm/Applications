<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRestaurant.aspx.cs" Inherits="Project3.AddRestaurant" %>

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
                <li><a href="MainPage.aspx">Main Page</a></li>
                <li><a href="AddAccount.aspx">Add Account</a></li>
                <li class="active"><a href="AddRestaurant.aspx">Add Restaurant</a></li>
                <li><a href="AddReview.aspx">Manage Review</a></li>
                <li><a href="AddReservation.aspx">Add Reservation</a></li>
            </ul>
        </div>
    </nav>
    <form id="AddRestaurantForm" runat="server">
        <div class="container">
            <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h2>Add Restaurant Page</h2>
                </div>
            </div>
            <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:Label ID="lblRestaurantName" runat="server" Text="Enter a restaurant name"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtRestaurantName" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblTypeOfCuisine" runat="server" Text="Enter the type of cuisine"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTypeOfCuisine" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnAddRestaurant" CssClass="btn-sm btn-primary btn-block" runat="server" type="submit" Text="Add Restaurant" OnClick="btnAddRestaurant_Click" />
                </div>
            </div>
        </div>
    <div>
        
    </div>
    </form>

    <footer class="footer" id="page_footer">
        <nav class="navbarfooter navbar-default navbar-fixed-bottom">
            <div class="navbar-text pull-left">
                <p>&copy; Kevin Pham 2016</p>
            </div>
                <ul class="nav navbar-nav">
                    <li><a href="HomePage.aspx">Home Page</a></li>
                    <li><a href="MainPage.aspx">Main Page</a></li>
                    <li><a href="AddAccount.aspx">Add Account</a></li>
                    <li><a href="AddRestaurant.aspx">Add Restaurant</a></li>
                    <li><a href="AddReview.aspx">Manage Review</a></li>
                    <li><a href="AddReservation.aspx">Add Reservation</a></li>
                </ul>
                
        </nav> 
    </footer>
</body>
</html>
