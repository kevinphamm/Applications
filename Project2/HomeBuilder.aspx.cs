using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Globalization;
using System.Drawing;

namespace Project2
{
    public partial class HomeBuilder : System.Web.UI.Page
    {
        Home newHome = new Home();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DBConnect objDB = new DBConnect();
            if (!IsPostBack)
            {
                String strSQLRooms = "SELECT * FROM Rooms";
                gvRooms.DataSource = objDB.GetDataSet(strSQLRooms);
                gvRooms.DataBind();

                String strSQLBedroom = "SELECT * FROM Bedroom";
                gvBedroom.DataSource = objDB.GetDataSet(strSQLBedroom);
                gvBedroom.DataBind();

                String strSQLBathroom = "SELECT * FROM Bathroom";
                gvBathroom.DataSource = objDB.GetDataSet(strSQLBathroom);
                gvBathroom.DataBind();

                String strSQLBasement = "SELECT * FROM Basement";
                gvBasement.DataSource = objDB.GetDataSet(strSQLBasement);
                gvBasement.DataBind();

                String strSQLLivingRoom = "SELECT * FROM LivingRoom";
                gvLivingRoom.DataSource = objDB.GetDataSet(strSQLLivingRoom);
                gvLivingRoom.DataBind();

                String strSQLKitchen = "SELECT * FROM Kitchen";
                gvKitchen.DataSource = objDB.GetDataSet(strSQLKitchen);
                gvKitchen.DataBind();
            }
            
            
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //Adding rooms to the house
            foreach (GridViewRow gvrow in gvRooms.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkBoxRoom");
                int rowIndex = gvrow.RowIndex;
                if (chk.Checked)
                {
                    TextBox TBox;
                    String description = gvRooms.Rows[rowIndex].Cells[2].Text;
                    double price = double.Parse(gvRooms.Rows[rowIndex].Cells[3].Text);

                    TBox = (TextBox)gvRooms.Rows[rowIndex].FindControl("txtLength");
                    double length = double.Parse(TBox.Text);

                    TBox = (TextBox)gvRooms.Rows[rowIndex].FindControl("txtWidth");
                    double width = double.Parse(TBox.Text);

                    newHome.AddRoom(description, price, length, width);
                }
            }

            //Adding upgrades for the bedrooms
            foreach (GridViewRow gvrow in gvBedroom.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkBoxBedroom");
                int rowIndex = gvrow.RowIndex;
                if (chk.Checked)
                {
                    String description = gvBedroom.Rows[rowIndex].Cells[1].Text;
                    double price = double.Parse(gvBedroom.Rows[rowIndex].Cells[2].Text);

                    foreach (GridViewRow gvroomsrow in gvRooms.Rows)
                    {
                        CheckBox chkroom = (CheckBox)gvroomsrow.FindControl("chkBoxRoom");
                        int roomrowIndex = gvroomsrow.RowIndex;
                        String roomdescription = gvRooms.Rows[roomrowIndex].Cells[2].Text;
                        if (chkroom.Checked == true && roomdescription.Equals("Master Bedroom"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                        if (chkroom.Checked == true && roomdescription.Equals("Bedroom 1"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                        if (chkroom.Checked == true && roomdescription.Equals("Bedroom 2"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                        if (chkroom.Checked == true && roomdescription.Equals("Bedroom 3"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                        
                    }
                }
            }

            //Adding upgrades to the bathroom
            foreach (GridViewRow gvrow in gvBathroom.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkBoxBathroom");
                int rowIndex = gvrow.RowIndex;
                if (chk.Checked)
                {
                    String description = gvBathroom.Rows[rowIndex].Cells[1].Text;
                    double price = double.Parse(gvBathroom.Rows[rowIndex].Cells[2].Text);

                    foreach (GridViewRow gvroomsrow in gvRooms.Rows)
                    {
                        CheckBox chkroom = (CheckBox)gvroomsrow.FindControl("chkBoxRoom");
                        int roomrowIndex = gvroomsrow.RowIndex;
                        String roomdescription = gvRooms.Rows[roomrowIndex].Cells[2].Text;
                        if (chkroom.Checked == true && roomdescription.Equals("Bathroom 1"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                        if (chkroom.Checked == true && roomdescription.Equals("Bathroom 2"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                    }
                }
            }

            //Adding upgrades to the basement
            foreach (GridViewRow gvrow in gvBasement.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkBoxBasement");
                int rowIndex = gvrow.RowIndex;
                if (chk.Checked)
                {
                    String description = gvBasement.Rows[rowIndex].Cells[1].Text;
                    double price = double.Parse(gvBasement.Rows[rowIndex].Cells[2].Text);

                    foreach (GridViewRow gvroomsrow in gvRooms.Rows)
                    {
                        CheckBox chkroom = (CheckBox)gvroomsrow.FindControl("chkBoxRoom");
                        int roomrowIndex = gvroomsrow.RowIndex;
                        String roomdescription = gvRooms.Rows[roomrowIndex].Cells[2].Text;
                        if (chkroom.Checked == true && roomdescription.Equals("Basement"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                    }
                }
            }

            //Adding upgrades to the living room
            foreach (GridViewRow gvrow in gvLivingRoom.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkBoxLivingRoom");
                int rowIndex = gvrow.RowIndex;
                if (chk.Checked)
                {
                    String description = gvLivingRoom.Rows[rowIndex].Cells[1].Text;
                    double price = double.Parse(gvLivingRoom.Rows[rowIndex].Cells[2].Text);

                    foreach (GridViewRow gvroomsrow in gvRooms.Rows)
                    {
                        CheckBox chkroom = (CheckBox)gvroomsrow.FindControl("chkBoxRoom");
                        int roomrowIndex = gvroomsrow.RowIndex;
                        String roomdescription = gvRooms.Rows[roomrowIndex].Cells[2].Text;
                        if (chkroom.Checked == true && roomdescription.Equals("Living Room"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                    }
                }
            }

            //Adding upgrades to the kitchen
            foreach (GridViewRow gvrow in gvKitchen.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkBoxKitchen");
                int rowIndex = gvrow.RowIndex;
                if (chk.Checked)
                {
                    String description = gvKitchen.Rows[rowIndex].Cells[1].Text;
                    double price = double.Parse(gvKitchen.Rows[rowIndex].Cells[2].Text);

                    foreach (GridViewRow gvroomsrow in gvRooms.Rows)
                    {
                        CheckBox chkroom = (CheckBox)gvroomsrow.FindControl("chkBoxRoom");
                        int roomrowIndex = gvroomsrow.RowIndex;
                        String roomdescription = gvRooms.Rows[roomrowIndex].Cells[2].Text;
                        if (chkroom.Checked == true && roomdescription.Equals("Kitchen"))
                        {
                            newHome.addUpgrade(roomdescription, description, price);
                        }
                    }
                }
            }


            ShowHouse();

            lblDirections.Visible = false;
            gvRooms.Visible = false;

            lblBedroom.Visible = false;
            gvBedroom.Visible = false;

            lblBathroom.Visible = false;
            gvBathroom.Visible = false;

            lblBasement.Visible = false;
            gvBasement.Visible = false;

            lblLivingRoom.Visible = false;
            gvLivingRoom.Visible = false;

            lblKitchen.Visible = false;
            gvKitchen.Visible = false;

            txtFirstName.Visible = false;
            txtLastName.Visible = false;
            txtAddress.Visible = false;
            txtPhoneNumber.Visible = false;

            btnTest.Enabled = false;

            lblOutputFirstName.Text += txtFirstName.Text;
            lblOutputLastName.Text += txtLastName.Text;
            lblOutputAddress.Text += txtAddress.Text;
            lblOutputPhoneNumber.Text += txtPhoneNumber.Text;

            lblOutputFirstName.Visible = true;
            lblOutputLastName.Visible = true;
            lblOutputAddress.Visible = true;
            lblOutputPhoneNumber.Visible = true;
            lblOutput.Visible = true;

            //To Display the GrandTotal row, look at the notes on code packet
            int count = gvHouse.Rows.Count;
            double GrandTotal = 0;
            for (int i = 0; i < count; i++)
            {
                GrandTotal = GrandTotal + double.Parse(gvHouse.Rows[i].Cells[3].Text, NumberStyles.Currency);
            }

            gvHouse.Columns[0].FooterText = "Grand Total: ";
            gvHouse.Columns[3].FooterText = GrandTotal.ToString("C2");
            gvHouse.Columns[0].FooterStyle.ForeColor = Color.Red;
            gvHouse.Columns[3].FooterStyle.ForeColor = Color.Red;

            gvHouse.DataBind();
        }
        public void ShowHouse()
        {
            gvHouse.DataSource = newHome.arrRooms;
            gvHouse.DataBind();
        }
    }
}