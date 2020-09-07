<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker_master.Master" AutoEventWireup="true" CodeBehind="ViewJobs_User.aspx.cs" Inherits="Project882020.ViewJobs_User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ApplyForm(jp_id) {
            document.getElementById('iframe_pop').src = 'ApplyForm.aspx?JID=' + jp_id;
            $('#div_overlay').fadeIn(500); $('#div_popup').fadeIn(500);
        }
        function Display_Company_Info(r_id) {
            document.getElementById('iframe_pop').src = 'Display_Company_Info.aspx?JID=' + r_id;
            $('#div_overlay').fadeIn(500); $('#div_popup').fadeIn(500);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table>
        <tr>
            <td>
                <asp:DropDownList ID="ddljobuser" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="textSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btn_search" runat="server"  Text="Search" OnClick="btn_search_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gv_Jobuser" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Company Name">
                            <ItemTemplate>
                                <a href="javascript:void(0);"  onclick="Display_Company_Info('<%#Eval("r_id") %>')"><%#Eval("r_cname") %></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Profile">
                            <ItemTemplate>
                                <%#Eval("j_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Min Salary">
                            <ItemTemplate>
                                <%#Eval("minsalary") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Max Salary">
                            <ItemTemplate>
                                <%#Eval("maxsalary") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vacancy">
                            <ItemTemplate>
                                <%#Eval("jp_novacancy") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comment">
                            <ItemTemplate>
                                <%#Eval("jp_comment") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:void(0);"  onclick="ApplyForm('<%#Eval("jp_id") %>')">Apply</a>
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

     <%--------------------------popup apply----------------------------%>
    <div id="div_overlay" style="position: fixed; left: 0px; top: 0px; right: 0px; bottom: 0px; background: black; opacity: 0.2; display: none"></div>
    <div id="div_popup" style="position: fixed; display: none; left: 0px; top: 150px; right: 0px; bottom: 0px;">
        <center>
    <div style="overflow:auto;width:500px;height:300px;background:white;">
    <div style="float:right"><a href="javascript:void(0);" onclick="$('#div_overlay').fadeOut(1000);$('#div_popup').fadeOut(1000);">close</a></div>
    <iframe id="iframe_pop" src="ApplyForm.aspx" style="border:none" width="500px" height="300px"></iframe>
    </div></center>
    </div>

     <%--------------------------popup Info----------------------------%>
    <div id="div_overlay" style="position: fixed; left: 0px; top: 0px; right: 0px; bottom: 0px; background: black; opacity: 0.2; display: none"></div>
    <div id="div_popup" style="position: fixed; display: none; left: 0px; top: 150px; right: 0px; bottom: 0px;">
        <center>
    <div style="overflow:auto;width:500px;height:300px;background:white;">
    <div style="float:right"><a href="javascript:void(0);" onclick="$('#div_overlay').fadeOut(1000);$('#div_popup').fadeOut(1000);">close</a></div>
    <iframe id="iframe_pop" src="Display_Company_Info.aspx" style="border:none" width="500px" height="300px"></iframe>
    </div></center>
    </div>
</asp:Content>
