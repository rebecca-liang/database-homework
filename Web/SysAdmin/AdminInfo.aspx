<%@ Page Language="C#" MasterPageFile="~/SysAdmin/sysAdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminInfo.aspx.cs" Inherits="Web.SysAdmin.AdminInfo" Title="个人信息" %>
<%@ Register Src="~/Common/controls/userDetails.ascx" TagName="baseInfo" TagPrefix="uc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
   <uc1:baseInfo id="readerInfo" runat="server"/>
</center>
</asp:Content>
