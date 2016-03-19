<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="Project3.AddReview" %>

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
                <li class="active"><a href="AddReview.aspx">Manage Review</a></li>
                <li><a href="AddReservation.aspx">Add Reservation</a></li>
            </ul>
        </div>
    </nav> 
    <form id="AddReviewForm" runat="server">
        <div class="container">
            <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h2>Manage Review Page</h2>
                </div>
            </div>
            <div class="row" >
                <div class="col-lg-6 col-md-6 col-sm-6">
                    Creating a Review<br />
                    1. Enter all the information in the required fields<br />
                    2. Click the add review button to create a new review for the specified restaurant<br />
                    <br />
                    <asp:Label ID="lblFoodRating" runat="server" Text="Enter a value (1-5) for the quality of the food"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtFoodRating" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblServiceRating" runat="server" Text="Enter a value (1-5) for the quality of the service"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtServiceRating" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblPriceRating" runat="server" Text="Enter a value (1-5) for the quality of the price"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPriceRating" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblReviewComment" runat="server" Text="Enter your comments for the overall experience"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtReviewComment" runat="server" Height="150px" TextMode="MultiLine" Width="350px" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <h4>Please select the restaurant you want to add the review to</h4>
                    <asp:GridView ID="gvRestaurants" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="btnAddReview_Click">
                    <Columns>
                    <asp:BoundField DataField="RestaurantID" HeaderText="Restaurant ID" />
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="TypeOfCuisine" HeaderText="Type of Cuisine" />
                    <asp:CommandField ButtonType="Button" HeaderText="Add Review"
                        ShowSelectButton="True" ></asp:CommandField>
                    </Columns>
                    </asp:GridView>
                </div>               
            </div>
            <hr />
            <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h4>This is the list of review you've made. (If any)</h4>
                    <asp:GridView ID="gvReviews" runat="server" AutoGenerateColumns="False" OnRowEditing="gvReviews_RowEditing" OnRowCancelingEdit="gvReviews_RowCancelingEdit" OnRowUpdating="gvReviews_RowUpdating" OnRowDeleting="gvReviews_RowDeleting" ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="ReviewID" HeaderText="Review ID" ReadOnly ="true" />
                        <asp:BoundField DataField="RestaurantID" HeaderText="Restaurant ID" ReadOnly="true" />
                        <asp:BoundField DataField="FoodRating" HeaderText="Food Rating (1-5)" />
                        <asp:BoundField DataField="ServiceRating" HeaderText="Service Rating (1-5)" />
                        <asp:BoundField DataField="PriceRating" HeaderText="Price Rating (1-5)" />
                        <asp:BoundField DataField="ReviewComment" HeaderText="Comments" />
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
