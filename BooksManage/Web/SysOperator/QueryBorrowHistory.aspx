<%@ Page Language="C#" MasterPageFile="~/SysOperator/OperatorMasterPage.Master" AutoEventWireup="true" CodeBehind="QueryBorrowHistory.aspx.cs" Inherits="Web.SysOperator.QueryBorrowHistory" Title="查询历史借阅信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align=center>
     <tr>
        <td colspan="2" align="center">
          <asp:Label runat="server" ID="lbl1" Font-Bold="True" Height="30px"> 查询历史借阅信息</asp:Label>     
        </td>
     </tr>
     <tr>
        <td>读者编号：</td>
        <td><asp:TextBox ID="txtReaderID" runat="server"></asp:TextBox></td>
     </tr>
     
      <tr>
         <td  align="center">
            <asp:Button ID="btnQuery" runat="server"  Text="查询" onclick="btnQuery_Click"/>
         </td>
         <td  align="center">
            <asp:Button ID="btnReset" runat="server"  Text="重置" onclick="btnReset_Click" />
         </td>
      </tr>   
      
   </table>
   
   <table id="gridTable" runat="server" visible="false" style="width: 541px">
     <tr>
           <td align="center" style="height: 25px">
                该读者的书刊借阅历史信息
            </td>
      </tr>
    <tr>
        <td>
             <asp:GridView ID="gvBorrowHistory" runat="server" AutoGenerateColumns="False" 
                   BackColor="White" BorderColor="#999999" BorderWidth="1px" 
                   CellPadding="3" GridLines="Vertical" BorderStyle="None" Width="572px" >
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

        </td>
    </tr>
   </table>



</asp:Content>
