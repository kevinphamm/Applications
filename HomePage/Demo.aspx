<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="HomePage.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblDisplay" runat="server" style="z-index: 1; left: 560px; top: 113px; position: absolute; height: 3px" Text="Label"></asp:Label>
        <asp:TextBox ID="txtInput" runat="server" style="z-index: 1; left: 555px; top: 141px; position: absolute"></asp:TextBox>
    
    </div>
        <p>
            &nbsp;</p>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" style="z-index: 1; left: 582px; top: 186px; position: absolute" Text="Submit" />
    </form>
</body>
</html>
