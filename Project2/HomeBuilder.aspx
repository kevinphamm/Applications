<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeBuilder.aspx.cs" Inherits="Project2.HomeBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        
    </style>
</head>
<body>
    <form id="HomeBuilderForm" runat="server">
    <div>
    
        <strong>First Name:</strong>&nbsp;
        <asp:TextBox ID="txtFirstName" runat="server" style="margin-left: 28px" Width="150px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvalFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter your first name."></asp:RequiredFieldValidator>
        <br />
        <br />
        <strong>Last Name:</strong>
        <asp:TextBox ID="txtLastName" runat="server" style="margin-left: 33px" Width="150px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvalLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter your last name."></asp:RequiredFieldValidator>
        <br />
        <br />
        <strong>Address: 
        <asp:TextBox ID="txtAddress" runat="server" style="margin-left: 53px" Width="150px"></asp:TextBox>
        </strong>
        <asp:RequiredFieldValidator ID="revalAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter your address"></asp:RequiredFieldValidator>
        <br />
        <br />
        <strong>Phone Number:&nbsp; </strong>&nbsp;<asp:TextBox ID="txtPhoneNumber" runat="server" Width="149px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvalPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Please enter your phone number."></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblDirections" runat="server" Text="Select from the rooms below to start building your house:"></asp:Label>
        </div>
        <asp:GridView ID="gvRooms" runat="server" AutoGenerateColumns="False" style="height: 133px; width: 187px">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBoxRoom" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="RoomID" HeaderText="Room ID" />
                <asp:BoundField DataField="Description" HeaderText="Room Description" />
                <asp:BoundField DataField="Price" HeaderText="Price per Sqft" />
                <asp:TemplateField HeaderText="Length">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLength" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Width">
                    <ItemTemplate>
                        <asp:TextBox ID="txtWidth" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblBedroom" runat="server" Text="Bedroom Upgrades:"></asp:Label>
        <asp:Button ID="btnTest" runat="server" OnClick="btnTest_Click" style="position: relative; top: -103px; left: 654px" Text="Testing GridView" />
        <asp:GridView ID="gvBedroom" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBoxBedroom" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Kitchen Upgrade" HeaderText="Upgrade Description" />
                <asp:BoundField DataField="Kitchen Price" HeaderText="Upgrade Price" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblBathroom" runat="server" Text="Bathroom Upgrades:"></asp:Label>
        <asp:GridView ID="gvBathroom" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBoxBathroom" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Bathroom Upgrade" HeaderText="Upgrade Description" />
                <asp:BoundField DataField="Bathroom Price" HeaderText="Upgrade Price" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblBasement" runat="server" Text="Basement Upgrades:"></asp:Label>
        <asp:GridView ID="gvBasement" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBoxBasement" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Basement Upgrade" HeaderText="Upgrade Description" />
                <asp:BoundField DataField="Basement Price" HeaderText="Upgrade Price" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblLivingRoom" runat="server" Text="Living Room Upgrades:"></asp:Label>
        <asp:GridView ID="gvLivingRoom" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBoxLivingRoom" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LivingRoom Upgrade" HeaderText="Upgrade Description" />
                <asp:BoundField DataField="LivingRoom Price" HeaderText="Upgrade Price" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblKitchen" runat="server" Text="Kitchen Upgrades:"></asp:Label>
        <asp:GridView ID="gvKitchen" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBoxKitchen" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Kitchen Upgrade" HeaderText="Upgrade Description" />
                <asp:BoundField DataField="Kitchen Price" HeaderText="Upgrade Price" />
            </Columns>
        </asp:GridView>
        <br />
        <hr />
        <asp:Label ID="lblOutputFirstName" runat="server" Text="First Name: " Visible="False"></asp:Label><br />
        <asp:Label ID="lblOutputLastName" runat="server" Text="Last Name: " Visible="False"></asp:Label><br />
        <asp:Label ID="lblOutputAddress" runat="server" Text="Address: " Visible="False"></asp:Label><br />
        <asp:Label ID="lblOutputPhoneNumber" runat="server" Text="Phone Number: " Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblOutput" runat="server" Text="Output Gridview" Visible="False"></asp:Label>
        <asp:GridView ID="gvHouse" runat="server" AutoGenerateColumns="false" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="CompleteDescription" HeaderText="Description" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="UpgradeCost" HeaderText="Upgrade Costs" />
                <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" />
            </Columns>
        </asp:GridView>
    </form>

        
</body>
</html>
