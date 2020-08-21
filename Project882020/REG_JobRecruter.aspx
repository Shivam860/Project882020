<%@ Page Title="" Language="C#" MasterPageFile="~/Default_master.Master" AutoEventWireup="true" CodeBehind="REG_JobRecruter.aspx.cs" Inherits="Project882020.REG_JobRecruter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Company Name :</td>
            <td>
                <asp:TextBox  ID="textName" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Company URL :</td>
            <td>
                <asp:TextBox  ID="textURL" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Email :</td>
            <td>
                <asp:TextBox  ID="textEmail" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Password :</td>
            <td>
                <asp:TextBox  ID="textPass" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Contact Person :</td>
            <td>
                <asp:TextBox  ID="textPerson" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Contact Number :</td>
            <td>
                <asp:TextBox  ID="textNumber" runat="server"></asp:TextBox>
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
            <td>Address :</td>
            <td>
                <asp:TextBox  ID="textAddress" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Comment :</td>
            <td>
                <asp:TextBox  ID="textComment" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button ID="Btn_save_recruter" runat="server" Text="Submit" OnClick="Btn_save_recruter_Click" />
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="labmsg" runat="server" ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
