<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Links.ascx.vb" Inherits="UserCtrl_Links" %>
<table cellpadding="0" cellspacing="0" style="margin:0px 0px 0px auto;">
<tr> 
<td><asp:LinkButton ID="lbMenu" runat="server">MENU</asp:LinkButton> </td>       
<td><asp:LinkButton ID="lbUser" runat="server">用户MS</asp:LinkButton> </td>
<td><asp:LinkButton ID="lbProject" runat="server">工程MS</asp:LinkButton> </td>
<td><asp:LinkButton ID="lbTools" runat="server">治具MS</asp:LinkButton> </td>
<td><%--<asp:LinkButton ID="lbPic" runat="server">图片MS</asp:LinkButton>--%><a href="APP/PictureImport.zip">图片MS</a> </td>
<td><asp:LinkButton ID="lbCheckMethod" runat="server">检查方法MS</asp:LinkButton> </td>
<td><asp:LinkButton ID="lbTemp" runat="server">模板MS</asp:LinkButton> </td>
<td><asp:LinkButton ID="lbRelation" runat="server">关联商品与模板</asp:LinkButton> </td>
<td><asp:LinkButton ID="lbPlan" runat="server">检查计划</asp:LinkButton> </td>
<td><asp:LinkButton ID="LinkButton1" runat="server">检查一览</asp:LinkButton> </td>
<td><asp:LinkButton ID="LinkButton2" runat="server">帐票出力</asp:LinkButton> </td>
</tr>
</table>
<datalist id="line_id_list"></datalist>