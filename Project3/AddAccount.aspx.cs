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

namespace Project3
{
    public partial class AddAccount : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsernameDB.Visible = false;
            lblPasswordDB.Visible = false;
            lblUserTitleDB.Visible = false;
        }

        protected void btnAddAccount_Click(object sender, EventArgs e)
        {
            String username = "";
            String password  = "";
            Boolean IsReviewer = false;
            Boolean IsRepresentative = false;
            if ((txtUsername.Text != null) && (txtUsername.Text != ""))
            {
                username = txtUsername.Text.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a valid Username');", true);
            }

            if((txtPassword.Text != null) && (txtPassword.Text != ""))
            {
                password = txtPassword.Text.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Please enter a valid Password');", true);
            }

            if (chkReviewer.Checked && chkRepresentative.Checked)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Can only be a reviewer or representative. Not both.');", true);
            }
            else if (chkReviewer.Checked)
            {
                IsReviewer = true;
                //Add the new account to the table in the database
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddAccount";

                SqlParameter UsernameDB = new SqlParameter("@newUsername", username);
                SqlParameter PasswordDB = new SqlParameter("@newPassword", password);
                SqlParameter IsReviewerDB = new SqlParameter("@newIsReviewer", IsReviewer);
                SqlParameter IsRepresentativeDB = new SqlParameter("@newIsRepresentative", IsRepresentative);

                objCommand.Parameters.Add(UsernameDB);
                objCommand.Parameters.Add(PasswordDB);
                objCommand.Parameters.Add(IsReviewerDB);
                objCommand.Parameters.Add(IsRepresentativeDB);

                DBConnect objDB = new DBConnect();
                objDB.DoUpdateUsingCmdObj(objCommand);

                //Retrieving account and displaying it after creating account
                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "GetAccountByUsernameAndPassword";
                objCommand2.Parameters.AddWithValue("@PassedUsername", username);
                objCommand2.Parameters.AddWithValue("@PassedPassword", password);
                DBConnect objDB2 = new DBConnect();
                DataSet myDataSet = objDB2.GetDataSetUsingCmdObj(objCommand2);

                String UsernameFromDB = objDB2.GetField("Username", 0).ToString();
                String PasswordFromDB = objDB2.GetField("Password", 0).ToString();
                Boolean IsReviewerFromDB = (Boolean)objDB2.GetField("IsReviewer", 0);
                Boolean IsRepresentativeFromDB = (Boolean)objDB2.GetField("IsRepresentative", 0);

                lblUsernameDB.Visible = true;
                lblPasswordDB.Visible = true;
                lblUserTitleDB.Visible = true;

                lblUsernameDB.Text = UsernameFromDB;
                lblPasswordDB.Text = PasswordFromDB;
                if (IsReviewerFromDB)
                {
                    lblUserTitleDB.Text = "Account created was a Reviewer";
                }
                else if (IsRepresentativeFromDB)
                {
                    lblUserTitleDB.Text = "Account created was a Representative";
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Account was created. The page will redirect to the Login Page in 10 seconds.');", true);
                Response.AddHeader("REFRESH", "10;URL=HomePage.aspx");
            }
            else if (chkRepresentative.Checked)
            {
                IsRepresentative = true;
                //Add the new account to the table in the database
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddAccount";

                SqlParameter UsernameDB = new SqlParameter("@newUsername", username);
                SqlParameter PasswordDB = new SqlParameter("@newPassword", password);
                SqlParameter IsReviewerDB = new SqlParameter("@newIsReviewer", IsReviewer);
                SqlParameter IsRepresentativeDB = new SqlParameter("@newIsRepresentative", IsRepresentative);

                objCommand.Parameters.Add(UsernameDB);
                objCommand.Parameters.Add(PasswordDB);
                objCommand.Parameters.Add(IsReviewerDB);
                objCommand.Parameters.Add(IsRepresentativeDB);

                DBConnect objDB = new DBConnect();
                objDB.DoUpdateUsingCmdObj(objCommand);

                //Retrieving account and displaying it after creating account
                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "GetAccountByUsernameAndPassword";
                objCommand2.Parameters.AddWithValue("@PassedUsername", username);
                objCommand2.Parameters.AddWithValue("@PassedPassword", password);
                DBConnect objDB2 = new DBConnect();
                DataSet myDataSet = objDB2.GetDataSetUsingCmdObj(objCommand2);

                String UsernameFromDB = objDB2.GetField("Username", 0).ToString();
                String PasswordFromDB = objDB2.GetField("Password", 0).ToString();
                Boolean IsReviewerFromDB = (Boolean)objDB2.GetField("IsReviewer", 0);
                Boolean IsRepresentativeFromDB = (Boolean)objDB2.GetField("IsRepresentative", 0);

                lblUsernameDB.Visible = true;
                lblPasswordDB.Visible = true;
                lblUserTitleDB.Visible = true;

                lblUsernameDB.Text = UsernameFromDB;
                lblPasswordDB.Text = PasswordFromDB;
                if (IsReviewerFromDB)
                {
                    lblUserTitleDB.Text = "Account created was a Reviewer";
                }
                else if (IsRepresentativeFromDB)
                {
                    lblUserTitleDB.Text = "Account created was a Representative";
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Account was created. The page will redirect to the Login Page in 3 seconds.');", true);
                Response.AddHeader("REFRESH", "3;URL=HomePage.aspx");
            }

            
        }
    }
}