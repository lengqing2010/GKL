﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="m_tools.aspx.vb" Inherits="m_tools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1"  />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>治具MS</title>

    <!--JS-->
    <script language="javascript" type="text/javascript" src="./js/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="./JidouTemp.js"></script>
    <script language="javascript" type="text/javascript" src="./m_tools.aspx.js"></script>

    <!--CSS-->
    <link href="tmp.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <div>
        <div class='title_div'>治具MS
            <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="jq_back" />
        </div>

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <hr />
<!--条件部-->
        <table class='jyouken_panel' cellpadding="0" cellspacing="0">
            <tr>
            <td>生产线 : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxLineId_key" class="jq_line_id_key" runat="server" style="width:160px;background-color: #FFAA00;"></asp:TextBox>
            </td>
            <td>
        
                </td>
            </tr>
            <tr>
            <td>治具ID : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxToolId_key" class="jq_tool_id_key" runat="server" style="width:200px;background-color: #FFAA00;"></asp:TextBox>
            </td>
            <td><asp:Button ID="btnSelect" runat="server" Text="検索" CssClass="jq_sel"  Height="20" Width="50"/></td>
            </tr>

        </table>
        <br /> <hr />

<!--Button部-->
        <div style="width:820px; text-align:right;">

            <asp:Button ID="btnUpdate" runat="server" Text="更新" CssClass="jq_upd" />
            <asp:Button ID="btnInsert" runat="server" Text="登録" CssClass="jq_ins" />
            <asp:Button ID="btnDelete" runat="server" Text="削除" CssClass="jq_del" />
        </div>
 <br /> <hr />

<!--明細Title部-->
<div id="divGvwTitle" class='jq_title_div' runat ="server" style="overflow:hidden ;margin-left:0px; width:1004px; margin-top :0px; border-collapse :collapse ;">
      <table class='ms_title' style="width:815px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:210px;">
                  治具ID
              </td>
              <td style="width:170px;">
                  生产线
              </td>
              <td style="width:210px;">
                  工程
              </td>
              <td style="">
                  治具显示文本
              </td>
          </tr>
      </table>
</div>

<!--明細Body部-->
<div id="divGvw" class='jq_ms_div' runat ="server" style="overflow:scroll ; height:294px;margin-left:0px; width:1020px; margin-top :0px; border-collapse :collapse ;">
      <table class='ms_input' style="width:815px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:210px;">
              <asp:TextBox ID="tbxToolId" class="jq_tool_id_ipt" runat="server" maxLength="40" style="width:204px;background-color: #FFAA00;"></asp:TextBox>
          </td>
              <td style="width:170px;">
              <asp:TextBox ID="tbxLineId" class="jq_line_id_ipt" runat="server" maxLength="10" style="width:164px;background-color: #FFAA00;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxProjectName" class="jq_project_name_ipt" runat="server" maxLength="40" style="width:204px;"></asp:TextBox>
          </td>
              <td style="">
              <asp:TextBox ID="tbxToolName" class="jq_tool_name_ipt" runat="server" maxLength="80" style="width:200px;"></asp:TextBox>
          </td>
          </tr>
      </table>
   <asp:GridView CssClass ="jq_ms" Width="815px"  runat="server" ID="gvMs" EnableTheming="True" ShowHeader="False" AutoGenerateColumns="False" BorderColor="black" style=" margin-top :-1px; " TabIndex="-1" >
      <Columns>
          <asp:TemplateField><ItemTemplate ><%#Eval("tool_id")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_tool_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("line_id")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_line_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("project_name")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_project_name" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("tool_name")%></ItemTemplate><ItemStyle  HorizontalAlign="Left" CssClass="jq_tool_name" /></asp:TemplateField>
      </Columns>
   </asp:GridView>
</div>

        <asp:TextBox ID="hidToolId" runat="server" class="jq_tool_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidLineId" runat="server" class="jq_line_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidProjectName" runat="server" class="jq_project_name_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidToolName" runat="server" class="jq_tool_name_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidOldRowIdx" runat="server" class="jq_hidOldRowIdx" style=" visibility:hidden;"></asp:TextBox>
    </div>
    </form>
</body>
</html>
