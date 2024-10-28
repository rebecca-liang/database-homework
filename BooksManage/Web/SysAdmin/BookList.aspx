<%@ Page Language="C#" MasterPageFile="~/SysAdmin/sysAdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="BookList.aspx.cs" Inherits="Web.SysAdmin.BookList" Title="图书列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridviewBookList" runat="server"  DataKeyNames="bookID" 
        AutoGenerateColumns="False" OnRowDeleting="GridviewBookList_RowDeleting"
        Width="766px" Height="409px">
        <Columns>
            <asp:BoundField HeaderText="题名" DataField="bookName"  ItemStyle-Wrap="false">
<ItemStyle Wrap="False"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="作者" DataField="author" ItemStyle-Wrap="false">
<ItemStyle Wrap="False"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="出版社" DataField="publish" ItemStyle-Wrap="false">
<ItemStyle Wrap="False"></ItemStyle>
            </asp:BoundField>
            <asp:CommandField HeaderText="删除" DeleteText="删除" ShowDeleteButton="True" >
                <ItemStyle Wrap="False" />
            </asp:CommandField>
            <asp:HyperLinkField HeaderText="详细" DataNavigateUrlFields="bookID" DataNavigateUrlFormatString="ModifyBook.aspx?bookID={0}"
                Text="详细..."  ItemStyle-Wrap="false" >
<ItemStyle Wrap="False"></ItemStyle>
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
