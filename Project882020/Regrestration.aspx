<%@ Page Title="" Language="C#" MasterPageFile="~/Default_master.Master" AutoEventWireup="true" CodeBehind="Regrestration.aspx.cs" Inherits="Project882020.Regrestration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:ImageButton ID="btn" runat="server" OnClick="btn_Click" ImageUrl="~/pictures/hireme.jpg" Width="200px" Height="200px"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btn_rec" runat="server" OnClick="btn_rec_Click" ImageUrl="~/pictures/iamhiring.jpeg" Width="200px" Height="200px"/>
            </td>
            
        </tr>
        <tr>
            <td style="text-align:center;font-size:40px">
                <a href="Login.aspx" >SignIn</a>
            </td>
        </tr>
    </table>
</asp:Content>
