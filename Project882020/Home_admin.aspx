<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Home_admin.aspx.cs" Inherits="Project882020.Home_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome <asp:Label ID="labmsg"  runat="server" ForeColor="Black"></asp:Label></h1>
    <asp:GridView ID="gv_home" runat="server"></asp:GridView>
</asp:Content>
