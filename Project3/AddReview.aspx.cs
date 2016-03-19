using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Project3
{
    public partial class AddReview : System.Web.UI.Page
    {
        String UserTitle;
        String AccountID;
        String RestaurantID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["AccountID"] = "1";
            //Session["RestaurantID"] = "6";
            UserTitle = Session["UserTitle"].ToString();
            AccountID = Session["AccountID"].ToString();
            //RestaurantID = Session["RestaurantID"].ToString();

            if (!IsPostBack)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetReviewByAccountID";

                objCommand.Parameters.AddWithValue("@AccountID", AccountID);

                DBConnect objDB = new DBConnect();
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                gvReviews.DataSource = myDataSet;
                gvReviews.DataBind();

                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "GetRestaurants";

                DBConnect objDB2 = new DBConnect();
                DataSet myDataSet2 = objDB2.GetDataSetUsingCmdObj(objCommand2);

                gvRestaurants.DataSource = myDataSet2;
                gvRestaurants.DataBind();

            }

        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {
            String RestaurantID = gvRestaurants.SelectedRow.Cells[0].Text;

            int foodrating;
            int servicerating;
            int pricerating;
            bool res = int.TryParse(txtFoodRating.Text, out foodrating);
            bool res1 = int.TryParse(txtServiceRating.Text, out servicerating);
            bool res2 = int.TryParse(txtPriceRating.Text, out pricerating);
            if (res == false || res1 == false || res2 == false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a valid number for the Ratings');", true);
            }
            else
            {
                if(foodrating > 5 || foodrating < 1 || servicerating > 5 || servicerating < 1 || pricerating > 5 || pricerating < 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a number from 1-5 for the Ratings');", true);
                }
                else
                {
                    int FoodRating = int.Parse(txtFoodRating.Text);
                    int ServiceRating = int.Parse(txtServiceRating.Text);
                    int PriceRating = int.Parse(txtPriceRating.Text);
                    String ReviewComment = txtReviewComment.Text.ToString();

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "AddReview";

                    SqlParameter AccountIDDB = new SqlParameter("@AccountID", AccountID);
                    SqlParameter RestaurantIDDB = new SqlParameter("@RestaurantID", RestaurantID);
                    SqlParameter FoodRatingDB = new SqlParameter("@newFoodRating", FoodRating);
                    SqlParameter ServiceRatingDB = new SqlParameter("@newServiceRating", ServiceRating);
                    SqlParameter PriceRatingDB = new SqlParameter("@newPriceRating", PriceRating);
                    SqlParameter ReviewCommentDB = new SqlParameter("@newReviewComment", ReviewComment);

                    objCommand.Parameters.Add(AccountIDDB);
                    objCommand.Parameters.Add(RestaurantIDDB);
                    objCommand.Parameters.Add(FoodRatingDB);
                    objCommand.Parameters.Add(ServiceRatingDB);
                    objCommand.Parameters.Add(PriceRatingDB);
                    objCommand.Parameters.Add(ReviewCommentDB);

                    DBConnect objDB = new DBConnect();
                    objDB.DoUpdateUsingCmdObj(objCommand);

                    txtFoodRating.Text = "";
                    txtServiceRating.Text = "";
                    txtPriceRating.Text = "";
                    txtReviewComment.Text = "";

                    SqlCommand objCommand2 = new SqlCommand();
                    objCommand2.CommandType = CommandType.StoredProcedure;
                    objCommand2.CommandText = "GetReviewByAccountID";

                    objCommand2.Parameters.AddWithValue("@AccountID", AccountID);

                    DBConnect objDB2 = new DBConnect();
                    DataSet myDataSet2 = objDB2.GetDataSetUsingCmdObj(objCommand2);

                    gvReviews.DataSource = myDataSet2;
                    gvReviews.DataBind();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully added a review');</script>");
                }
            }    
        }

        protected void gvReviews_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvReviews.EditIndex = e.NewEditIndex;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewByAccountID";

            objCommand.Parameters.AddWithValue("@AccountID", AccountID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvReviews.DataSource = myDataSet;
            gvReviews.DataBind();


        }

        protected void gvReviews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvReviews.EditIndex = -1;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewByAccountID";

            objCommand.Parameters.AddWithValue("@AccountID", AccountID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvReviews.DataSource = myDataSet;
            gvReviews.DataBind();
        }

        protected void gvReviews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int ReviewID = int.Parse(gvReviews.Rows[rowIndex].Cells[0].Text);

            TextBox TBox;
            //TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[2].Controls[0];
            //int FoodRating = int.Parse(TBox.Text);

            //TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[3].Controls[0];
            //int ServiceRating = int.Parse(TBox.Text);

            //TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[4].Controls[0];
            //int PriceRating = int.Parse(TBox.Text);

            //TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[5].Controls[0];
            //String ReviewComment = TBox.Text.ToString();

            int foodrating;
            int servicerating;
            int pricerating;
            TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[2].Controls[0];
            bool res = int.TryParse(TBox.Text, out foodrating);

            TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[3].Controls[0];
            bool res1 = int.TryParse(TBox.Text, out servicerating);

            TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[4].Controls[0];
            bool res2 = int.TryParse(TBox.Text, out pricerating);

            TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[5].Controls[0];
            String ReviewComment = TBox.Text.ToString();

            if (res == false || res1 == false || res2 == false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a valid number for the Ratings');", true);
            }
            else
            {
                if (foodrating > 5 || foodrating < 1 || servicerating > 5 || servicerating < 1 || pricerating > 5 || pricerating < 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a number from 1-5 for the Ratings');", true);
                }
                else
                {
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "UpdateReview";

                    objCommand.Parameters.AddWithValue("@ReviewID", ReviewID);
                    objCommand.Parameters.AddWithValue("@ChangedFoodRating", foodrating);
                    objCommand.Parameters.AddWithValue("@ChangedServiceRating", servicerating);
                    objCommand.Parameters.AddWithValue("@ChangedPriceRating", pricerating);
                    objCommand.Parameters.AddWithValue("@ChangedReviewComment", ReviewComment);

                    DBConnect objDB = new DBConnect();
                    objDB.DoUpdateUsingCmdObj(objCommand);

                    gvReviews.EditIndex = -1;

                    //Rebind GV
                    SqlCommand objCommand2 = new SqlCommand();
                    objCommand2.CommandType = CommandType.StoredProcedure;
                    objCommand2.CommandText = "GetReviewByAccountID";

                    objCommand2.Parameters.AddWithValue("@AccountID", AccountID);

                    DBConnect objDB2 = new DBConnect();
                    DataSet myDataSet2 = objDB2.GetDataSetUsingCmdObj(objCommand2);

                    gvReviews.DataSource = myDataSet2;
                    gvReviews.DataBind();
                }
            }
        }

        protected void gvReviews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int ReviewID = int.Parse(gvReviews.Rows[rowIndex].Cells[0].Text);

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReview";

            objCommand.Parameters.AddWithValue("@PassedReviewID", ReviewID);

            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objCommand);

            //Rebind GV
            SqlCommand objCommand2 = new SqlCommand();
            objCommand2.CommandType = CommandType.StoredProcedure;
            objCommand2.CommandText = "GetReviewByAccountID";

            objCommand2.Parameters.AddWithValue("@AccountID", AccountID);

            DBConnect objDB2 = new DBConnect();
            DataSet myDataSet2 = objDB2.GetDataSetUsingCmdObj(objCommand2);

            gvReviews.DataSource = myDataSet2;
            gvReviews.DataBind();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully deleted a review');</script>");
        }

    }
}