<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="236px">
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <p>
            Id:</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Name:</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 29px" Text="Submit" />
        <br />
        <br />
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Height="341px" Width="391px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
