<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Project882020.Registration" %>

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
            <td></td>
            <td>
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClientClick="return validation()" OnClick="btn_submit_Click" /></td>
        </tr>

              
        <tr>
            
            <td colspan="2">
                <asp:GridView ID="gv" runat="server" OnRowCommand="gv_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="User ID">
                            <ItemTemplate>
                                <%#Eval("id") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <%#Eval("name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <%#Eval("gender").ToString() == "1" ? "male" :Eval("gender").ToString() == "2" ? "Female" : "others"%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Email">
                            <ItemTemplate>
                                <%#Eval("email") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Course">
                            <ItemTemplate>
                                <%#Eval("c_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Password">
                            <ItemTemplate>
                                <%#Eval("password") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <%#Eval("city_name") %>, <%#Eval("state_name") %>,<%#Eval("country_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />

                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
