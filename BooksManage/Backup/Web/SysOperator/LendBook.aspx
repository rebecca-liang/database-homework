<%@ Page Language="C#" MasterPageFile="~/SysOperator/OperatorMasterPage.Master" AutoEventWireup="true" CodeBehind="LendBook.aspx.cs" Inherits="Web.SysOperator.LendBook" Title="借书界面" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center>  
<table  cellpadding ="0" border ="0" 
        style="height: 302px; width: 201px" >
    
     <tr>
      <td colspan ="2" align ="center" >
          借书操作
      </td>
    </tr>
   
    
    
     <tr>
        <td colspan ="2" style="height: 25px">
            请输入读者编号：
        </td> 
    </tr>
     <tr>
        <td colspan ="2" style="height: 25px">
            <asp:TextBox ID="txtReaderID" runat="server" Width="192px" ></asp:TextBox>
         </td>
    </tr>
    <tr>
        <td colspan ="2">
            请输入图书编号：
        </td> 
    </tr>
     <tr>
        <td colspan ="2">
            <asp:TextBox ID="txtBookID" runat="server" Height="20px" Width="192px" ></asp:TextBox>
         </td>
    </tr>
    
    <tr>
        <td style="width: 64px; height: 25px">
            <asp:ImageButton ID="imgbtnLend" ImageUrl ="~/Images/Borrow.GIF"  runat="server" OnClick="imgbtnLend_Click"  />
         </td>
         <td style="height: 25px">
             <asp:ImageButton ID="ImageReset" ImageUrl ="~/Images/RESET.GIF"  runat="server" OnClick="ImageReset_Click" />
         </td>
    </tr>
    
    <tr>
        <td colspan ="2">
            <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
         </td>
    </tr>
    
   
    
</table>
</center>  

</asp:Content>
