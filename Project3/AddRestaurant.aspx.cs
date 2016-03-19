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
    public partial class AddRestaurant : System.Web.UI.Page
    {
        String UserTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserTitle = Session["UserTitle"].ToString();
        }

        protected void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            if(txtRestaurantName.Text.Equals("") || txtTypeOfCuisine.Text.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a restaurant name and the type of cuisine');", true);
            }
            else
            {
                String RestaurantName = txtRestaurantName.Text.ToString();
                String TypeOfCuisine = txtTypeOfCuisine.Text.ToString();

                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddRestaurant";

                SqlParameter RestaurantNameDB = new SqlParameter("@newRestaurantName", RestaurantName);
                SqlParameter TypeOfCuisineDB = new SqlParameter("@newTypeOfCuisine", TypeOfCuisine);

                objCommand.Parameters.Add(RestaurantNameDB);
                objCommand.Parameters.Add(TypeOfCuisineDB);

                DBConnect objDB = new DBConnect();
                objDB.DoUpdateUsingCmdObj(objCommand);

                txtRestaurantName.Text = "";
                txtTypeOfCuisine.Text = "";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully added a Restaurant');</script>");
            }
        }
    }
}