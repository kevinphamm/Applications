<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReservation.aspx.cs" Inherits="Project3.AddReservation" %>

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
                <li><a href="AddRestaurant.aspx">Add Restaurant</a></li>
                <li><a href="AddReview.aspx">Manage Review</a></li>
                <li class="active"><a href="AddReservation.aspx">Add Reservation</a></li>
            </ul>
        </div>
    </nav> 
    <form id="AddReservationForm" runat="server">
        <div class="container">
            <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h2>Add Reservation Page</h2>
                </div>
            </div>
            <div class="row" >
                <div class="col-lg-4 col-md-4 col-sm-6">
                    <h4>Enter the time of reservation</h4>
                    <asp:Label ID="lblTimeOfReservation" runat="server" Text="Enter a time for your reservation"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTimeOfReservation" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6">
                    <h4>Select the restaurant you want to add the time of reservation to</h4>
                    <asp:GridView ID="gvRestaurants" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="btnAddReservation_Click">
                    <Columns>
                    <asp:BoundField DataField="RestaurantID" HeaderText="Restaurant ID" />
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="TypeOfCuisine" HeaderText="Type of Cuisine" />
                    <asp:CommandField ButtonType="Button" HeaderText="Add Reservation"
                    ShowSelectButton="True" ></asp:CommandField>
                    </Columns>
                    </asp:GridView>
                </div>
            </div>
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
