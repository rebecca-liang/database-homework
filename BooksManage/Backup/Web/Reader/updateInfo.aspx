<%@ Page Language="C#" MasterPageFile="~/Reader/ReaderMasterPage.Master" AutoEventWireup="true" CodeBehind="updateInfo.aspx.cs" Inherits="Web.Reader.updateInfo" Title="我的基本信息" %>
<%@ Register Src="~/Common/controls/userDetails.ascx" TagName="baseInfo" TagPrefix="uc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<center>
<uc1:baseInfo id="readerInfo" runat="server"/>
</center>
</asp:Content>
