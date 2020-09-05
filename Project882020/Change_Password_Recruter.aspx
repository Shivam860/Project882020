<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruter_master.Master" AutoEventWireup="true" CodeBehind="Change_Password_Recruter.aspx.cs" Inherits="Project882020.Change_Password_Recruter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function validation() {
        var msgs = "";
        msgs += checkoldpassword();
        msgs += checknewpassword();
        msgs += checkconpassword();

        if (msgs != "") {
            alert(msgs);
            return false;
        }

        function checkoldpassword() {
            var op = document.getElementById('<%=textOldPass.ClientID%>');
            if (op.value == "") {
                return 'Please Enter the Old Password \n';
            }
            else {
                return "";
            }
        }
        function checknewpassword() {
            var np1 = document.getElementById('<%=textNewPass.ClientID%>');
            if (np1.value == "") {
                return 'Please Enter the New Password Colounm \n';
            }
            else {
                return "";
            }
        }
        function checkconpassword() {
            var np2 = document.getElementById('<%=textConPass.ClientID%>');
            var np1 = document.getElementById('<%=textNewPass.ClientID%>');
            if (np2.value == "") {
                return 'Please Enter the Conferm Password Colounm \n';
            }
            else if (np1.value == np2.value) {
                return "";
            }
            else {
                return 'Please Enter the Conferm Password correct \n';
            }
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table>
        <tr>
             <td>Old Password :</td>
             <td><asp:TextBox ID="textOldPass" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>New Password :</td>
            <td><asp:TextBox ID="textNewPass" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Conferm Password :</td>
            <td><asp:TextBox ID="textConPass" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="btn_changePass" runat="server" Text="Change" OnClientClick="return validation()" OnClick="btn_changePass_Click"/></td>
        </tr>

        <tr>
            <td><asp:Label ID="labmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
</table>
</asp:Content>
