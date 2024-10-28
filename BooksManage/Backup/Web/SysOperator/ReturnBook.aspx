<%@ Page Language="C#" MasterPageFile="~/SysOperator/OperatorMasterPage.Master" AutoEventWireup="true" CodeBehind="ReturnBook.aspx.cs" Inherits="Web.SysOperator.ReturnBook" Title="还书操作" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="0" border="0" 
        style="height: 168px; width: 224px">
        <tr>
            <td colspan="2" align="center">
                还书操作
            </td>
        </tr>
        <tr>
            <td colspan="2">
                请输入图书编号：
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtBookID" runat="server" Width="214px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 64px; height: 25px">
                <asp:ImageButton ID="imgbtnReturn" ImageUrl="~/Images/ReturnBook.GIF" runat="server"
                    OnClick="imgbtnReturn_Click" Width="71px" />
            </td>
            <td style="height: 25px">
                <asp:ImageButton ID="ImageReset" ImageUrl="~/Images/RESET.GIF" runat="server" 
                    OnClick="ImageReset_Click" Width="67px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>


</asp:Content>
