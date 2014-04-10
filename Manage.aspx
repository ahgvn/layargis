<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Manage the settings of your Layar/ArcGIS webservice</h2>
        ArcGIS for Server endpoint: <asp:TextBox runat="server" ID="txtURL" Width="500px"></asp:TextBox>
        <hr />
        <asp:Button runat="server" ID="btnStore" Text="Save" onclick="btnStore_Click" />
    </div>
    </form>
</body>
</html>
