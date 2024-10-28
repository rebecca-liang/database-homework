<%@ Page Language="C#" MasterPageFile="~/SysAdmin/sysAdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="Web.SysAdmin.ModifyPassword" Title="修改密码" %>
<%@ Register Src="~/Common/controls/ModifyPassword.ascx"  TagName="changePassword" TagPrefix="uc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
  <uc1:changePassword  id="readerChangPwd" runat="server" />

</center>

</asp:Content>
