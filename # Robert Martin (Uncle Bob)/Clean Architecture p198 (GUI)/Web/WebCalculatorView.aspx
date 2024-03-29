<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCalculatorView.aspx.cs" Inherits="Web.WebCalculatorView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 71px">
    <form id="form1" runat="server">
        <div style="height: 40px">
            <asp:TextBox ID="firstNumberTextBox" runat="server"></asp:TextBox>
        </div>
        <asp:TextBox ID="secondNumberTextBox" runat="server"></asp:TextBox>
        <p style="height: 35px">
            <asp:Label ID="resultLabel" runat="server" Text="Label"></asp:Label>
        </p>
        <asp:Button ID="calculateButton" runat="server" Text="+" />
    </form>
</body>
</html>
