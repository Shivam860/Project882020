<%@ Page Title="" Language="C#" MasterPageFile="~/Default_master.Master" AutoEventWireup="true" CodeBehind="REG_JobSeeker.aspx.cs" Inherits="Project882020.REG_JobSeeker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validation() {
            var msgs = "";
            msgs = checkname();
            msgs += checkemail();
            msgs += checkcourse();
            msgs += checkcountry();
            msgs += checkstate();
            msgs += checkpassword();

            if (msgs != "") {
                alert(msgs);
                return false;
            }
        }
        function checkname() {
            var CTR = document.getElementById('<%=textName.ClientID%>');
            if (CTR.value == "") {
                return 'Please Enter the Name  \n';
            }
            else {
                return "";
            }
        }

        function checkgender() {
            
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

        function checkcourse() {
            var CTR = document.getElementById('<%=ddlcourse.ClientID%>');
             if (CTR.value == "0") {
                 return 'Please Select the course \n';
             }
             else {
                 return "";
             }
        }

        function checkcountry() {
            var CTR = document.getElementById('<%=ddlcountry.ClientID%>');
             if (CTR.value == "0") {
                 return 'Please select the Country \n';
             }
             else {
                 return "";
             }
        }

        function checkstate() {
            var CTR = document.getElementById('<%=ddlstate.ClientID%>');
             if (CTR.value == "0") {
                 return 'Please select the state \n';
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

        function checkcity() {
            
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name :</td>
            <td>
                <asp:TextBox ID="textName" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Gender :</td>
            <td>
                <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td>Email :</td>
            <td>
                <asp:TextBox ID="textEmail" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Course :</td>
            <td>
                <asp:DropDownList ID="ddlcourse" runat="server"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>Country :</td>
            <td>
                <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>State :</td>
            <td>
                <asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>

         <tr>
            <td>City :</td>
            <td>
                <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>Password :</td>
            <td>
                <asp:TextBox ID="textpass" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClientClick="return validation()" OnClick="btn_submit_Click" />

            </td>&nbsp;&nbsp;&nbsp;&nbsp;
              <td>
                  <a href="Login.aspx">Login</a>
              </td>          

        </tr>

        <tr>
        <td>
            <asp:Label ID="labmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    </table>

</asp:Content>
