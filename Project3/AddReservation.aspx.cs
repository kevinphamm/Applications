using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Project3
{
    public partial class AddReservation : System.Web.UI.Page
    {
        String UserTitle;
        String AccountID;
        String RestaurantID;
        //ArrayList ArrayOfTimes = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            //populateTimeArray();
            //ddlTime.DataSource = ArrayOfTimes;
            //ddlTime.DataBind();

            UserTitle = Session["UserTitle"].ToString();
            AccountID = Session["AccountID"].ToString();
            //RestaurantID = Session["RestaurantID"].ToString();
            if (!IsPostBack)
            {
                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "GetRestaurants";

                DBConnect objDB2 = new DBConnect();
                DataSet myDataSet2 = objDB2.GetDataSetUsingCmdObj(objCommand2);

                gvRestaurants.DataSource = myDataSet2;
                gvRestaurants.DataBind();
            }

        }

        protected void btnAddReservation_Click(object sender, EventArgs e)
        {
            String RestaurantID = gvRestaurants.SelectedRow.Cells[0].Text;

            if (txtTimeOfReservation.Text.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a valid time frame');", true);
            }
            else
            {
                String TimeOfReservation = txtTimeOfReservation.Text.ToString();

                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddReservation";

                SqlParameter AccountIDDB = new SqlParameter("@AccountID", AccountID);
                SqlParameter RestaurantIDDB = new SqlParameter("@RestaurantID", RestaurantID);
                SqlParameter TimeOfReservationDB = new SqlParameter("@TimeOfReservation", TimeOfReservation);

                objCommand.Parameters.Add(AccountIDDB);
                objCommand.Parameters.Add(RestaurantIDDB);
                objCommand.Parameters.Add(TimeOfReservationDB);

                DBConnect objDB = new DBConnect();
                objDB.DoUpdateUsingCmdObj(objCommand);

                txtTimeOfReservation.Text = "";

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Successfully added a reservation');</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully added a reservation');</script>");
            }
            
        }

    
    }
}