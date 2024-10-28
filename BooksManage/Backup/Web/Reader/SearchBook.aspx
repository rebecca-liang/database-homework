<%@ Page Language="C#" MasterPageFile="~/Reader/ReaderMasterPage.Master" AutoEventWireup="true"
    CodeBehind="SearchBook.aspx.cs" Inherits="Web.Reader.SearchBook" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                图书种类：
            </td>
            <td>
                <asp:DropDownList ID="ddlBookType" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                查询途径：
            </td>
            <td>
                <asp:DropDownList ID="ddlQueryType" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="bookName">题名</asp:ListItem>
                    <asp:ListItem Value="author">作者</asp:ListItem>
                    <asp:ListItem Value="keyword">主题词</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                查询内容：
            </td>
            <td>
                <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" Text="搜索" runat="server" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:GridView ID="BookList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="841px" Height="142px" OnRowDataBound="BookList_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="bookName" HeaderText="题名" />
                        <asp:BoundField DataField="bookIndex" HeaderText="索书号" />
                        <asp:BoundField DataField="author" HeaderText="作者" />
                        <asp:BoundField DataField="publish" HeaderText="出版社" />
                        <asp:BoundField DataField="status" HeaderText="图书状态" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
