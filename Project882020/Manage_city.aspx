<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Manage_city.aspx.cs" Inherits="Project882020.Manage_city" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
         <tr>
            <td>Country :</td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>State :</td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>City :</td>
            <td>
                <asp:TextBox ID="textCity" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btn_submit" Text="Submit" runat="server" OnClick="btn_submit_Click" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gv_city" runat="server" OnRowCommand="gv_city_RowCommand" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Country">
                            <ItemTemplate>
                                <%#Eval("countryname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="State">
                            <ItemTemplate>
                                <%#Eval("sname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <%#Eval("cname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" Text="Delete" runat="server" CommandArgument='<%#Eval("cid") %>'/>
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
