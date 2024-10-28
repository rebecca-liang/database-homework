<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassword.ascx.cs" Inherits="Web.Common.controls.ModifyPassword" %>

<script language="javascript" type="text/javascript">
 function showError()
 {
  //alert("enter showErrow");
  var createTd=document.createElement("td");
  var newDiv=document.createElement("div");
  newDiv.innerHTML = "<font color='Red'>密码不正确!</font>";
 
  createTd.appendChild(newDiv);  
  document.getElementById("currPwd").appendChild(createTd);
  
}


function checkPS()
{
  var createTd=document.createElement("td");
  var newDiv=document.createElement("div");
  newDiv.innerHTML = "<font color='Red'>两次密码不一致，请重新输入!</font>";
 
  createTd.appendChild(newDiv);  
  document.getElementById("trConfimPwd").appendChild(createTd);
}

function emptyError()
{
  var createTd=document.createElement("td");
  var newDiv=document.createElement("div");
  newDiv.innerHTML = "<font color='Red'>密码不能为空!</font>";
 
  createTd.appendChild(newDiv);  
  document.getElementById("trConfimPwd").appendChild(createTd);
  
}
</script>

<table>

    <tr id="currPwd">
       <td>请输入当前密码：
       </td>
       <td>
           <asp:TextBox ID="txtCurrPwd" runat="server" TextMode="Password"></asp:TextBox>
       </td>
    </tr>
    <tr>
       <td>请输入新密码：<font size=4 color="red" ></font>
       </td>
       <td>
            <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>
       </td>
    </tr>
     <tr id="trConfimPwd">
       <td>确认密码：
       </td>
       <td>
             <asp:TextBox ID="txtConfimPwd" runat="server" TextMode="Password"></asp:TextBox>
       </td>
    </tr>
    <tr>
       <td align="center">
            <asp:Button   ID="btnSave" Text="保存" runat="server" onclick="btnSave_Click"/>
       </td>
       <td align="center">
            <asp:Button   ID="btnCancle" Text="取消" runat="server"/>  
       </td>
    </tr>
    
</table>