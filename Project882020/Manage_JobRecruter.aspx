<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Manage_JobRecruter.aspx.cs" Inherits="Project882020.Manage_JobRecruter" %>
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
            <asp:GridView ID="gv_manager_recruter" runat="server" OnRowCommand="gv_manager_recruter_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <%#Eval("r_cname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Company Url">
                            <ItemTemplate>
                                <%#Eval("r_url") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <%#Eval("r_email") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Password">
                            <ItemTemplate>
                                <%#Eval("r_password") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Contact Person">
                            <ItemTemplate>
                                <%#Eval("r_contactperson") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Contact Number">
                            <ItemTemplate>
                                <%#Eval("r_contactnumber") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <%#Eval("r_companyaddress") %>,<%#Eval("r_city") %>,<%#Eval("r_state") %>,<%#Eval("r_country") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comment">
                            <ItemTemplate>
                                <%#Eval("comment") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" CommandName="A" Text="Delete" CommandArgument='<%#Eval("r_id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("r_id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                    <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Button ID="btn_approve" runat="server" Text="Apporve" CommandName="C" CommandArgument='<%#Eval("r_id") %>'/>
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
            <asp:Label ID="labmasg" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
