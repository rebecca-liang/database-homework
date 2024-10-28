<%@ Page Language="C#" MasterPageFile="~/SysOperator/OperatorMasterPage.Master" AutoEventWireup="true" CodeBehind="QueryBorrowInfo.aspx.cs" Inherits="Web.SysOperator.BorrowInfo" Title="查询当前借阅信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align=center>
     <tr>
        <td colspan="2" align="center">
          <asp:Label runat="server" ID="lbl1" Font-Bold="True" Height="30px"> 查询当前借阅信息</asp:Label>     
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
   
   
   
   
    <table  id="borrowInfoTable" width="100%" border="1" runat="server" visible="false">
        <tr>
            <td align="center" style="height: 25px">
                该读者的书刊借阅信息
            </td>
        </tr>
        <tr  id="TrGrid" runat="server" >
            <td width="100%" >
                <asp:GridView ID="gvBorrowBookList" runat="server" Width="755px" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    OnRowDataBound="gvBorrowBookList_RowDataBound">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="bookName" HeaderText="题名" />
                        <asp:BoundField DataField="beginDate" HeaderText="借阅日期" />
                        <asp:TemplateField HeaderText="应归还日期">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="publish" HeaderText="出版社" />
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            
        </tr>
        <tr  id="TrMsg" runat="server">
            <td align="center"  >
               <asp:Label ID="lblMsgNoBorrow" runat="server" ForeColor="Red" ></asp:Label>
            </td>
        </tr>
    </table>



</asp:Content>
