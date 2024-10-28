<%@ Page Language="C#" MasterPageFile="~/Reader/ReaderMasterPage.Master" AutoEventWireup="true" CodeBehind="BorrowHistory.aspx.cs" Inherits="Web.Reader.BorrowHistory" Title="借阅历史" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvBorrowHistory" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderWidth="1px" 
        CellPadding="3" GridLines="Vertical" BorderStyle="None" Height="196px" 
        Width="526px" >
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="bookName" HeaderText="题名"  HeaderStyle-Wrap="false" >
<HeaderStyle Wrap="False"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="bookIndex" HeaderText="索书号" 
                HeaderStyle-Wrap="false" >
<HeaderStyle Wrap="False"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="author" HeaderText="作者"  HeaderStyle-Wrap="false">
<HeaderStyle Wrap="False"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="abstract" HeaderText="介绍" HeaderStyle-Wrap="false" >
<HeaderStyle Wrap="False"></HeaderStyle>
            </asp:BoundField>
        </Columns>
        
    
    
        <PagerStyle BackColor="#999999" ForeColor="Black" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#DCDCDC" />      
    
    
    </asp:GridView>

</asp:Content>
