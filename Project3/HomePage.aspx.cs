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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text.ToString();
            String password = txtPassword.Text.ToString();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPassword";
            objCommand.Parameters.AddWithValue("@username", username);
            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if(myDataSet.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Username was not found. Please enter a valid username');", true);
            }
            else
            {
                String accountID = objDB.GetField("AccountID", 0).ToString();
                String UsernameDB = objDB.GetField("Username", 0).ToString();
                String PasswordDB = objDB.GetField("Password", 0).ToString();
                Boolean IsReviewer = (Boolean)objDB.GetField("IsReviewer", 0);
                Boolean IsRepresentative = (Boolean)objDB.GetField("IsRepresentative", 0);

                if(UsernameDB.Equals(username) && PasswordDB.Equals(password))
                {
                    if(IsReviewer == true)
                    {
                        Session["UserTitle"] = "Reviewer";
                        Session["AccountID"] = accountID;
                    }
                    else if(IsRepresentative == true)
                    {
                        Session["UserTitle"] = "Representative";
                        Session["AccountID"] = accountID;
                    }
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Incorrect Password');", true);
                }
            }      
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {

            Session["UserTitle"] = "Default User";
            Session["AccountID"] = "0";
            Response.Redirect("MainPage.aspx");
        }

        protected void btnAddAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAccount.aspx");
        }
    }
}