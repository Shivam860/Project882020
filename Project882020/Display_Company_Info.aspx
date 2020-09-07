<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display_Company_Info.aspx.cs" Inherits="Project882020.Display_Company_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="align-self:center">
            <table style="text-align:center">
                <tr>
                    <td>Company Name:</td>
                    <td><asp:Label ID="labName" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Company Url:</td>
                    <td><asp:Label ID="labUrl" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Company Email:</td>
                    <td><asp:Label ID="labEmail" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Contact Person:</td>
                    <td><asp:Label ID="labPerson" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Contact Number:</td>
                    <td><asp:Label ID="labNum" runat="server"></asp:Label></td>
                </tr>
               
                <tr>
                    <td>Comment:</td>
                    <td><asp:Label ID="labComm" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
