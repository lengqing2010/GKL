﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="t_cd_temp_relation.aspx.vb" Inherits="t_cd_temp_relation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1"  />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>t_cd_temp_relation</title>

    <!--JS-->
    <script language="javascript" type="text/javascript" src="./js/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="./JidouTemp.js"></script>
    <script language="javascript" type="text/javascript" src="./t_cd_temp_relation.aspx.js"></script>

    <!--CSS-->
    <link href="tmp.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <div>
        <div class='title_div'><%Response.Write(Common.SetTitle("关联商品与模板"))%>
            <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="jq_back" />
        </div>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        
<!--条件部-->
        <table class='jyouken_panel' cellpadding="0" cellspacing="0">
            <tr>
            <td>生产线 : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxLineId_key" class="jq_line_id_key" runat="server" style="width:160px;background-color: #FFAA00;"></asp:TextBox>
            </td>
            <td></td>
            </tr>
            <tr>
            <td>模板CD : &nbsp;</td>
            <td>
                <asp:TextBox ID="tbxTempId_key" class="jq_temp_id_key" runat="server" style="width:160px;background-color: #FFAA00;"></asp:TextBox>

                         </td>
            <td></td>
            </tr>
            <tr>
            <td>商品CD : &nbsp;</td>
            <td>
                 <asp:TextBox ID="tbxCode_key" class="jq_code_key" runat="server" style="width:200px;background-color: #FFAA00;"></asp:TextBox>

                          </td>
            <td>
            <asp:Button ID="btnSelect" runat="server" Text="検索" CssClass="jq_sel" Height="24px" />
                </td>
            </tr>
        </table>
        <br /> 
        <div style="width:560px; text-align:right;">

    <!--Button部-->
            <asp:Button ID="btnUpdate" runat="server" Text="更新" CssClass="jq_upd" />
            <asp:Button ID="btnInsert" runat="server" Text="登録" CssClass="jq_ins" />
            <asp:Button ID="btnDelete" runat="server" Text="削除" CssClass="jq_del" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            第
            <asp:DropDownList ID="ddlPageIdx" runat="server" AutoPostBack="true" Width="60px">
            </asp:DropDownList>
            /
            <asp:Label ID="lblAllPageText" runat="server" Text="0"></asp:Label>
            页
        </div>


<!--明細Title部-->
<div id="divGvwTitle" class='jq_title_div' runat ="server" style="overflow:hidden ;margin-left:0px; width:1004px; margin-top :0px; border-collapse :collapse ;">
      <table class='ms_title' style="width:560px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:70px;">
                  生产线
              </td>
              <td style="width:210px;">
                  商品CD
              </td>
              <td style="">
                  模板CD
              </td>
          </tr>
      </table>
      <table class='ms_input' style="width:560px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:70px;">
              <asp:TextBox ID="tbxLineId" class="jq_line_id_ipt" runat="server" maxLength="10" style="width:64px;background-color: #FFAA00;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxCode" class="jq_code_ipt" runat="server" maxLength="20" style="width:204px;background-color: #FFAA00;"></asp:TextBox>
          </td>
              <td style="">
              <asp:TextBox ID="tbxTempId" class="jq_temp_id_ipt" runat="server" maxLength="10" style="width:95%;background-color: #FFAA00;"></asp:TextBox>
          </td>
          </tr>
      </table>

</div>

<!--明細Body部-->
<div id="divGvw" class='jq_ms_div' runat ="server" style="overflow:scroll ; height:294px;margin-left:0px; width:580px; margin-top :0px; border-collapse :collapse ;">

   <asp:GridView CssClass ="jq_ms" Width="560px"  runat="server" ID="gvMs" EnableTheming="True" ShowHeader="False" AutoGenerateColumns="False" BorderColor="black" style=" margin-top :-1px; " TabIndex="-1" >
      <Columns>
          <asp:TemplateField><ItemTemplate ><%#Eval("line_id")%></ItemTemplate><ItemStyle Width="70px" HorizontalAlign="Left" CssClass="jq_line_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("code")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_code" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("temp_id")%></ItemTemplate><ItemStyle  HorizontalAlign="Left" CssClass="jq_temp_id" /></asp:TemplateField>
      </Columns>
   </asp:GridView>
      <br />

</div>
        <br />

        <div style="width:560px; text-align:right;">
            <asp:FileUpload ID="GetUploadFileContent" runat="server" Width="500" />
            <asp:Button ID="btnUpload" runat="server" Text="导入" />
        </div>

        <asp:TextBox ID="hidLineId" runat="server" class="jq_line_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidCode" runat="server" class="jq_code_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidTempId" runat="server" class="jq_temp_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidOldRowIdx" runat="server" class="jq_hidOldRowIdx" style=" visibility:hidden;"></asp:TextBox>
    </div>
    </form>
</body>
</html>
