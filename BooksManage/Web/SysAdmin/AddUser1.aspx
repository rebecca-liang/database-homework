<%@ Page Language="C#" MasterPageFile="~/SysAdmin/sysAdminMasterPage.master" AutoEventWireup="true"
    CodeFile="AddUser.aspx.cs" Inherits="SysAdmin_AddUser" Title="添加用户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;
            width: 300px;" bgcolor="#f1f0f4" bordercolor="#2c6ed5" cellpadding="0" align="left"
            border="1">
            <tr>
                <td align="center" height="40" colspan="2">
                    <font size="4"><b>添加用户信息</b></font><br />
                    <font color="red">加*号为必填项目</font>
                </td>
            </tr>
            <tr height="35">
                <td>
                    用户编号：
                </td>
                <td style="width: 273px">
                    <asp:TextBox ID="txtUserID" runat="server" Width="150px"></asp:TextBox><font face="宋体">*<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserID" ErrorMessage="该项不能为空"></asp:RequiredFieldValidator>
                    </font>
                </td>
            </tr>
            <tr height="35">
                <td>
                    初始密码：
                </td>
                <td style="width: 273px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox><font
                        face="宋体">*<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage="该项不能为空"></asp:RequiredFieldValidator></font>
                </td>
            </tr>
            <tr height="35">
                <td>
                    确认密码：
                </td>
                <td style="width: 273px">
                    <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" Width="150px"></asp:TextBox><font
                        face="宋体">*
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPwd" ErrorMessage="与密码不一致" ></asp:CompareValidator></font>
                </td>
            </tr>
            <tr height="35">
                <td style="height: 23px">
                    用户类型：
                </td>
                <td style="height: 23px; width: 273px;">
                    <asp:DropDownList ID="ddlUserRole" runat="server" DataSourceID="SqlDataSource1" DataTextField="roleName"
                        DataValueField="roleID" AutoPostBack="false">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT * FROM [Role]"></asp:SqlDataSource>
                    *
                </td>
            </tr>
            <tr height="35">
                <td style="height: 23px">
                    姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：
                </td>
                <td style="height: 23px; width: 273px;">
                    <asp:TextBox ID="txtUserName" runat="server" Width="150px"></asp:TextBox><font face="宋体">*<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserName" ErrorMessage="该项不能为空"></asp:RequiredFieldValidator></font>
                </td>
            </tr>
            <tr height="35">
                <td>
                    性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：
                </td>
                <td style="width: 273px">
                    <asp:RadioButtonList ID="rblUserSex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="true">男</asp:ListItem>
                        <asp:ListItem Value="false">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    出生时间：
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server">
                    </asp:DropDownList>
                    年
                    <asp:DropDownList ID="ddlMonth" runat="server">
                    </asp:DropDownList>
                    月
                    <asp:DropDownList ID="ddlDay" runat="server">
                    </asp:DropDownList>
                    日
                </td>
            </tr>
            <tr height="35">
                <td style="height: 25px">
                    所在单位：
                </td>
                <td style="width: 273px; height: 25px;">
                    <asp:TextBox ID="txtUserDepart" runat="server" Width="150px"></asp:TextBox><font
                        face="宋体">*<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="txtUserDepart" ErrorMessage="该项不能为空"></asp:RequiredFieldValidator></font>
                </td>
            </tr>
            <tr>
                <td>
                    电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话：
                </td>
                <td style="width: 273px">
                    <asp:TextBox ID="txtUserTelephone" runat="server" Width="150px"></asp:TextBox><font
                        face="宋体">*<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="txtUserTelephone" ErrorMessage="该项不能为空"></asp:RequiredFieldValidator></font>
                </td>
            </tr>
            <tr height="35">
                <td style="height: 25px">
                    用户住址：
                </td>
                <td style="height: 25px; width: 273px;">
                    <asp:TextBox ID="txtUserAddress" runat="server" Width="150px"></asp:TextBox><font
                        face="宋体">*<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtUserAddress" ErrorMessage="该项不能为空"></asp:RequiredFieldValidator></font>
                </td>
            </tr>
            <tr height="35">
                <td align="center" colspan="2">
                    <font face="宋体">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
                        <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/Images/ADD.GIF" OnClick="imgBtnAdd_Click" />&nbsp;&nbsp;
                        &nbsp;
                        <asp:ImageButton ID="imgBtnReset" runat="server" 
                        ImageUrl="~/Images/RESET.GIF" CausesValidation="False" 
                        onclick="imgBtnReset_Click" /></font>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
