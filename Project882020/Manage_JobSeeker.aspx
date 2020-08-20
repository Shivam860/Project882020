<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker_master.Master" AutoEventWireup="true" CodeBehind="Manage_JobSeeker.aspx.cs" Inherits="Project882020.Manage_JobSeeker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>
            <asp:TextBox ID="textSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Search"/>
        </td>
    </tr>
    <tr>
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
    <tr>
        <td>
            <asp:Label ID="labmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
