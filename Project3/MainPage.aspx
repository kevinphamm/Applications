<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Project3.MainPage" %>

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
                <li class="active"><a href="MainPage.aspx">Main Page</a></li>
                <li><a href="AddAccount.aspx">Add Account</a></li>
                <li><a href="AddRestaurant.aspx">Add Restaurant</a></li>
                <li><a href="AddReview.aspx">Manage Review</a></li>
                <li><a href="AddReservation.aspx">Add Reservation</a></li>
            </ul>
        </div>
    </nav> 
    <form id="MainPageForm" runat="server">
        <div class="container">
            <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h2>Main Page</h2>
                </div>
            </div>
            <div class="row" >
                <div class="col-lg-4 col-md-4 col-sm-6">
                    <h4>Search Function</h4>
                    <p>Please type in the type of cuisine in the search</p>
                    
                    <div>
                    <asp:Button ID="btnAddRestaurant" CssClass="btn-sm btn-primary btn-block" runat="server" Text="Add a Restaurant" OnClick="btnAddRestaurant_Click" />
                    &nbsp;&nbsp;&nbsp;
    
                    <asp:Button ID="btnAddReview" CssClass="btn-sm btn-primary btn-block" runat="server" Text="Add/Modify/Delete a Review" OnClick="btnAddReview_Click"  />
                    &nbsp;&nbsp;&nbsp;
    
                    <asp:Button ID="btnAddReservation" CssClass="btn-sm btn-primary btn-block" runat="server" Text="Add a Reservation" OnClick="btnAddReservation_Click" />
                    <br />
                    <br />
    
                    <asp:Label ID="lblSearch" runat="server" Text="Search restaurants by entering in the type of cuisine"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" ></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSearch" CssClass="btn-sm btn-primary btn-block" runat="server" Text="Search" OnClick="btnSearch_Click" />

                    </div>
                
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6">
                    <h4>List of Restaurants</h4>
                    <p>Please click on the select button to show the reviews for the particular restaurant. If you are a representative, then a list a reservations will appear for you to manage.</p>
                    <asp:GridView ID="gvRestaurant" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvRestaurant_SelectedIndexChanged">
                    <Columns>
                    <asp:BoundField DataField="RestaurantID" HeaderText="Restaurant ID" />
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="TypeOfCuisine" HeaderText="Type of Cuisine" />
                    <asp:CommandField ButtonType="Button" HeaderText="Show Reviews"
                    ShowSelectButton="True"></asp:CommandField>
                    </Columns>
                    </asp:GridView>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6">
                    <h4>List of Reviews</h4>
                    <asp:GridView ID="gvReview" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                    <Columns>
                    <asp:BoundField DataField="ReviewID" HeaderText="Review ID" />
                    <asp:BoundField DataField="RestaurantID" HeaderText="Restaurant ID" />
                    <asp:BoundField DataField="FoodRating" HeaderText="Food Rating (1-5)" />
                    <asp:BoundField DataField="ServiceRating" HeaderText="Service Rating (1-5)" />
                    <asp:BoundField DataField="PriceRating" HeaderText="Price Rating (1-5)" />
                    <asp:BoundField DataField="ReviewComment" HeaderText="Comments" />
                    </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Label ID="lblAvgFoodRating" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblAvgServiceRating" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblAvgPriceRating" runat="server"></asp:Label>
                    <br />
                </div>

                <div class="col-lg-4 col-md-4 col-sm-6">
                    <h4>List of Reservations</h4>
                    <p>Reservations will only be shown to the restaurant representatives</p>
                    <asp:GridView ID="gvReservations" runat="server" AutoGenerateColumns="False" OnRowEditing="gvReservations_RowEditing" OnRowCancelingEdit="gvReservations_RowCancelingEdit" OnRowUpdating="gvReservations_RowUpdating" OnRowDeleting="gvReservations_RowDeleting" ForeColor="Black">
                    <Columns>
                    <asp:BoundField DataField="ReservationID" HeaderText="Reservation ID" ReadOnly="true" />
                    <asp:BoundField DataField="RestaurantID" HeaderText="Restaurant ID" ReadOnly="true" />
                    <asp:BoundField DataField="AccountID" HeaderText="Account ID" ReadOnly="true" />
                    <asp:BoundField DataField="TimeOfReservation" HeaderText="Time Of Reservation" />
                    <asp:CommandField ButtonType="Button" HeaderText="Delete Review"
                            ShowDeleteButton="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit Review"
                            ShowEditButton="True" />
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
