using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;

namespace Project3
{
    public partial class MainPage : System.Web.UI.Page
    {
        String UserTitle;
        String AccountID;
        String RestaurantID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserTitle"] = "Reviewer";
            UserTitle = Session["UserTitle"].ToString();
            AccountID = Session["AccountID"].ToString();
            if (!IsPostBack)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetRestaurants";

                DBConnect objDB = new DBConnect();
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                gvRestaurant.DataSource = myDataSet;
                gvRestaurant.DataBind();
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String SearchedTypeOfCuisine = txtSearch.Text.ToString();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantByTypeOfCuisine";

            objCommand.Parameters.AddWithValue("@TypeOfCuisine", SearchedTypeOfCuisine);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvRestaurant.DataSource = myDataSet;
            gvRestaurant.DataBind();

            txtSearch.Text = "";
            gvReview.Visible = false;
            
        }

        protected void gvRestaurant_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvReview.Visible = true;
            RestaurantID = gvRestaurant.SelectedRow.Cells[0].Text;
            Session["RestaurantID"] = RestaurantID;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "getReviewByRestaurantID";

            objCommand.Parameters.AddWithValue("@RestaurantID", RestaurantID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvReview.DataSource = myDataSet;
            gvReview.DataBind();

            int count = gvReview.Rows.Count;

            double TotalFoodRating = 0;
            double TotalServiceRating = 0;
            double TotalPriceRating = 0;

            for (int i = 0; i < count; i++)
            {
                TotalFoodRating = TotalFoodRating + double.Parse(gvReview.Rows[i].Cells[2].Text);
                TotalServiceRating = TotalServiceRating + double.Parse(gvReview.Rows[i].Cells[3].Text);
                TotalPriceRating = TotalPriceRating + double.Parse(gvReview.Rows[i].Cells[4].Text);
            }

            double avgFoodRating = TotalFoodRating / count;
            double avgServiceRating = TotalServiceRating / count;
            double avgPriceRating = TotalPriceRating / count;

            gvReview.Columns[0].FooterText = "Average Food Ratings: ";
            gvReview.Columns[2].FooterText = string.Format("{0:f2}", avgFoodRating);
            gvReview.Columns[3].FooterText = string.Format("{0:f2}", avgServiceRating);
            gvReview.Columns[4].FooterText = string.Format("{0:f2}", avgPriceRating);
            gvReview.Columns[0].FooterStyle.ForeColor = Color.Black;
            gvReview.Columns[2].FooterStyle.ForeColor = Color.Black;
            gvReview.Columns[3].FooterStyle.ForeColor = Color.Black;
            gvReview.Columns[4].FooterStyle.ForeColor = Color.Black;

            gvReview.DataBind();

            lblAvgFoodRating.Text = "Average Food Rating: " + string.Format("{0:f2}", avgFoodRating);
            lblAvgServiceRating.Text = "Average Service Rating: " + string.Format("{0:f2}", avgServiceRating);
            lblAvgPriceRating.Text = "Average Price Rating: " + string.Format("{0:f2}", avgPriceRating);
            lblAvgFoodRating.ForeColor = Color.Black;
            lblAvgServiceRating.ForeColor = Color.Black;
            lblAvgPriceRating.ForeColor = Color.Black;

            if (UserTitle.Equals("Representative"))
            {
                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "GetReservationByRestaurantID";

                objCommand2.Parameters.AddWithValue("@RestaurantID", RestaurantID);

                DBConnect objDB2 = new DBConnect();
                DataSet myDataSet2 = objDB2.GetDataSetUsingCmdObj(objCommand2);

                gvReservations.DataSource = myDataSet2;
                gvReservations.DataBind();

            }
            //txtSearch.Text = RestaurantID;
        }

        protected void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            Session["UserTitle"] = UserTitle;
            Session["AccountID"] = AccountID;
            Response.Redirect("AddRestaurant.aspx");
        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {
            Session["UserTitle"] = UserTitle;
            Session["AccountID"] = AccountID;
            Response.Redirect("AddReview.aspx");
        }

        protected void btnAddReservation_Click(object sender, EventArgs e)
        {
            Session["UserTitle"] = UserTitle;
            Session["AccountID"] = AccountID;
            Response.Redirect("AddReservation.aspx");
        }

        protected void gvReservations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int ReservationID = int.Parse(gvReservations.Rows[rowIndex].Cells[0].Text);

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReservation";

            objCommand.Parameters.AddWithValue("@PassedReservationID", ReservationID);

            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objCommand);

            String PassedRestaurantID = Session["RestaurantID"].ToString();

            SqlCommand objCommand2 = new SqlCommand();
            objCommand2.CommandType = CommandType.StoredProcedure;
            objCommand2.CommandText = "GetReservationByRestaurantID";

            objCommand2.Parameters.AddWithValue("@RestaurantID", PassedRestaurantID);

            DBConnect objDB2 = new DBConnect();
            DataSet myDataSet2 = objDB2.GetDataSetUsingCmdObj(objCommand2);

            gvReservations.DataSource = myDataSet2;
            gvReservations.DataBind();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully deleted a reservation');</script>");

        }

        protected void gvReservations_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String PassedRestaurantID = Session["RestaurantID"].ToString();
            gvReservations.EditIndex = e.NewEditIndex;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservationByRestaurantID";

            objCommand.Parameters.AddWithValue("@RestaurantID", PassedRestaurantID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvReservations.DataSource = myDataSet;
            gvReservations.DataBind();
        }

        protected void gvReservations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            String PassedRestaurantID = Session["RestaurantID"].ToString();
            gvReservations.EditIndex = -1;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservationByRestaurantID";

            objCommand.Parameters.AddWithValue("@RestaurantID", PassedRestaurantID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvReservations.DataSource = myDataSet;
            gvReservations.DataBind();
        }

        protected void gvReservations_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int ReservationID = int.Parse(gvReservations.Rows[rowIndex].Cells[0].Text);

            TextBox TBox;

            TBox = (TextBox)gvReservations.Rows[rowIndex].Cells[3].Controls[0];
            String TimeOfReservation = TBox.Text.ToString();

            if (TimeOfReservation.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a valid time for reservation');", true);
            }
            else
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UpdateReservation";

                objCommand.Parameters.AddWithValue("@PassedReservationID", ReservationID);
                objCommand.Parameters.AddWithValue("@newTimeOfReservation", TimeOfReservation);

                DBConnect objDB = new DBConnect();
                objDB.DoUpdateUsingCmdObj(objCommand);

                gvReservations.EditIndex = -1;

                String PassedRestaurantID = Session["RestaurantID"].ToString();

                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "GetReservationByRestaurantID";

                objCommand2.Parameters.AddWithValue("@RestaurantID", PassedRestaurantID);

                DBConnect objDB2 = new DBConnect();
                DataSet myDataSet2 = objDB2.GetDataSetUsingCmdObj(objCommand2);

                gvReservations.DataSource = myDataSet2;
                gvReservations.DataBind();

            }

        }
    }
}