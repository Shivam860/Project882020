<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruter_master.Master" AutoEventWireup="true" CodeBehind="rec_jobpost.aspx.cs" Inherits="Project882020.rec_jobpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Job Profile :</td>
            <td><asp:DropDownList ID="ddlJp" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Min Experience :</td>
            <td><asp:TextBox ID="textMinExp" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Max Experience :</td>
            <td><asp:TextBox ID="textMaxExp" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Min Salary :</td>
            <td>
                <asp:TextBox ID="textMinSalary" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Max Salary :</td>
            <td><asp:TextBox ID="textMaxSalary" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>No Of Vacancy</td>
            <td><asp:TextBox ID="textVacancy" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Comment :</td>
            <td><asp:TextBox ID="textComment" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_submit_jobPost" runat="server" Text="Submit" OnClick="btn_submit_jobPost_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labjobpost" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
