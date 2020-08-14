<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Project882020.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList>
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
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" /></td>
        </tr>

              
        <tr>
            <td></td>
            <td>
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
