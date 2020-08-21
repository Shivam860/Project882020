<%@ Page Title="" Language="C#" MasterPageFile="~/Default_master.Master" AutoEventWireup="true" CodeBehind="Login_JobSeeker.aspx.cs" Inherits="Project882020.Login_JobSeeker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function validation() {
        var msgs = "";
        msgs += checkemail();
        msgs += checkpassword();

        if (msgs != "") {
            alert(msgs);
            return false;
        }

        function checkemail() {
            var CTR = document.getElementById('<%=textEmail.ClientID%>');
            if (CTR.value == "") {
                return 'Please Enter the Email \n';
            }
            else {
                return "";
            }
        }
        function checkpassword() {
            var CTR = document.getElementById('<%=textpass.ClientID%>');
            if (CTR.value == "") {
                return 'Please Enter the Password \n';
            }
            else {
                return "";
            }
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td><asp:DropDownList ID="ddlselect" runat="server">
            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
            <asp:ListItem Text="JobSeeker" Value="1"></asp:ListItem>
            <asp:ListItem Text="JobRecruter" Value="2"></asp:ListItem>
            </asp:DropDownList></td>
    </tr>

    <tr>
         <td>Email :</td>
         <td><asp:TextBox ID="textEmail" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
            <td>Password :</td>
            <td>
                <asp:TextBox ID="textpass" runat="server"></asp:TextBox></td>
        </tr>

    <tr>
            <td></td>
            <td>
                <asp:Button ID="btn_login" runat="server" Text="Login" OnClientClick="return validation()" OnClick="btn_login_Click" /></td>
        </tr>

        <tr>
        <td>
            <asp:Label ID="labmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
