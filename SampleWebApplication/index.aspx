<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SampleWebApplication.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sample Web Application</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LnkGridView" Text="Grid View" runat="server" OnClick="LnkGridView_Click" />
         | 
        <asp:LinkButton ID="LnkListView" Text="List View" runat="server" OnClick="LnkListView_Click"/>
    </div>
    </form>
</body>
</html>
