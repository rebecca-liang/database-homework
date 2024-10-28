<%@ Page Language="C#" MasterPageFile="~/SysAdmin/sysAdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="ModifyBook.aspx.cs" Inherits="Web.SysAdmin.ModifyBook" Title="修改图书" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <center>
        <table  id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td align="center" colspan="2">
                    <font size="5" face="黑体">修改图书</font>
                </td>
            </tr>
            <tr>
                <td>
                    书名：
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="193px"></asp:TextBox>*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="此项不能为空"
                        ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 23px">
                    索取号：
                </td>
                <td style="height: 23px">
                    <asp:TextBox ID="txtIndex" runat="server" Width="192px"></asp:TextBox>*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtIndex"
                        ErrorMessage="此项不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    图书类型：
                </td>
                <td>
                    <asp:RadioButtonList ID="rblClassify" runat="server" Font-Size="9pt" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True">社会科学</asp:ListItem>
                        <asp:ListItem Value="1">自然科学</asp:ListItem>
                        <asp:ListItem Value="2">综合性图书</asp:ListItem>
                        <asp:ListItem Value="3">哲学</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    作者名：
                </td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server" Width="192px"></asp:TextBox>*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="此项不能为空"
                        ControlToValidate="txtAuthor"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    出版社：
                </td>
                <td>
                    <asp:TextBox ID="txtPublish" runat="server" Width="192px"></asp:TextBox>*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="此项不能为空"
                        ControlToValidate="txtPublish"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    定价(元)：
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" Width="192px"></asp:TextBox>*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="此项不能为空"
                        ControlToValidate="txtPrice"></asp:RequiredFieldValidator><br>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="输入有误，请重输"
                        ValidationExpression="(\d{1,}\.\d*)|(\d{1,})" ControlToValidate="txtPrice"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    出版时间：
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
            <tr>
                <td>
                    主题词：
                </td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server" Width="252px"></asp:TextBox>*
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSubject"
                        ErrorMessage="此项不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    说明：
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="334px" TextMode="MultiLine"
                        Height="64px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
                    <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/Images/Update.GIF" OnClick="imgBtnUpdate_Click" />
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnReturn" runat="server" 
                        ImageUrl="~/Images/RETURN.GIF" onclick="imgBtnReturn_Click" />
                </td>
            </tr>
        </table>
    </div>
    </center>
</asp:Content>
