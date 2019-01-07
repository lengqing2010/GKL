﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="m_temp.aspx.vb" Inherits="m_temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1"  />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>模板MS</title>

    <!--JS-->
    <script language="javascript" type="text/javascript" src="./js/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="./JidouTemp.js"></script>
    <script language="javascript" type="text/javascript" src="./m_temp.aspx.js"></script>

    <!--CSS-->
    <link href="tmp.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <div>
        <div class='title_div'>模板MS</div>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <hr />
<!--条件部-->
        <table class='jyouken_panel' cellpadding="0" cellspacing="0">
            <tr>
            <td>生?? : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxLineId_key" class="jq_line_id_key" runat="server" style="width:160px;background-color: #FFAA00;"></asp:TextBox>
            </td>
            <td></td>
            </tr>
            <tr>
            <td>??模板?号 : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxTempId_key" class="jq_temp_id_key" runat="server" style="width:160px;background-color: #FFAA00;"></asp:TextBox>
            </td>
            <td></td>
            </tr>
            <tr>
            <td>???目ID : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxChkMethodId_key" class="jq_chk_method_id_key" runat="server" style="width:160px;background-color: #FFAA00;"></asp:TextBox>
            </td>
            <td></td>
            </tr>
        </table>
        <br /> <hr />

<!--Button部-->
        <asp:Button ID="btnSelect" runat="server" Text="検索" CssClass="jq_sel" />
        <asp:Button ID="btnUpdate" runat="server" Text="更新" CssClass="jq_upd" />
        <asp:Button ID="btnInsert" runat="server" Text="登録" CssClass="jq_ins" />
        <asp:Button ID="btnDelete" runat="server" Text="削除" CssClass="jq_del" />
 <br /> <hr />

<!--明細Title部-->
<div id="divGvwTitle" class='jq_title_div' runat ="server" style="overflow:hidden ;margin-left:0px; width:1004px; margin-top :0px; border-collapse :collapse ;">
      <table class='ms_title' style="width:3155px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:170px;">
                  生?? 10
              </td>
              <td style="width:170px;">
                  ??模板?号 10
              </td>
              <td style="width:170px;">
                  ???目ID 10
              </td>
              <td style="width:170px;">
                  工程ID 10
              </td>
              <td style="width:210px;">
                  工程名 40
              </td>
              <td style="width:170px;">
                  ?片ID 10
              </td>
              <td style="width:210px;">
                  ?片名称 200
              </td>
              <td style="width:210px;">
                  ???目 200
              </td>
              <td style="width:170px;">
                  ?片?? 10
              </td>
              <td style="width:170px;">
                  ??方法ID 10
              </td>
              <td style="width:210px;">
                  ??方法名 20
              </td>
              <td style="width:210px;">
                  治具ID 40
              </td>
              <td style="width:210px;">
                  基准 100
              </td>
              <td style="width:210px;">
                  工差1 20
              </td>
              <td style="width:210px;">
                  工差2 20
              </td>
              <td style="">
                  基准説明 200
              </td>
          </tr>
      </table>
</div>

<!--明細Body部-->
<div id="divGvw" class='jq_ms_div' runat ="server" style="overflow:scroll ; height:294px;margin-left:0px; width:1020px; margin-top :0px; border-collapse :collapse ;">
      <table class='ms_input' style="width:3155px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:170px;">
              <asp:TextBox ID="tbxLineId" class="jq_line_id_ipt" runat="server" maxLength="10" style="width:164px;background-color: #FFAA00;"></asp:TextBox>
          </td>
              <td style="width:170px;">
              <asp:TextBox ID="tbxTempId" class="jq_temp_id_ipt" runat="server" maxLength="10" style="width:164px;background-color: #FFAA00;"></asp:TextBox>
          </td>
              <td style="width:170px;">
              <asp:TextBox ID="tbxChkMethodId" class="jq_chk_method_id_ipt" runat="server" maxLength="10" style="width:164px;background-color: #FFAA00;"></asp:TextBox>
          </td>
              <td style="width:170px;">
              <asp:TextBox ID="tbxProjectId" class="jq_project_id_ipt" runat="server" maxLength="10" style="width:164px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxProjectName" class="jq_project_name_ipt" runat="server" maxLength="40" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:170px;">
              <asp:TextBox ID="tbxPicId" class="jq_pic_id_ipt" runat="server" maxLength="10" style="width:164px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxPicName" class="jq_pic_name_ipt" runat="server" maxLength="200" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxChkKmName" class="jq_chk_km_name_ipt" runat="server" maxLength="200" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:170px;">
              <asp:TextBox ID="tbxPicSign" class="jq_pic_sign_ipt" runat="server" maxLength="10" style="width:164px;"></asp:TextBox>
          </td>
              <td style="width:170px;">
              <asp:TextBox ID="tbxChkId" class="jq_chk_id_ipt" runat="server" maxLength="10" style="width:164px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxChkName" class="jq_chk_name_ipt" runat="server" maxLength="20" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxToolId" class="jq_tool_id_ipt" runat="server" maxLength="40" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxKj0" class="jq_kj_0_ipt" runat="server" maxLength="100" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxKj1" class="jq_kj_1_ipt" runat="server" maxLength="20" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxKj2" class="jq_kj_2_ipt" runat="server" maxLength="20" style="width:204px;"></asp:TextBox>
          </td>
              <td style="">
              <asp:TextBox ID="tbxKjExplain" class="jq_kj_explain_ipt" runat="server" maxLength="200" style="width:200px;"></asp:TextBox>
          </td>
          </tr>
      </table>
   <asp:GridView CssClass ="jq_ms" Width="3155px"  runat="server" ID="gvMs" EnableTheming="True" ShowHeader="False" AutoGenerateColumns="False" BorderColor="black" style=" margin-top :-1px; " TabIndex="-1" >
      <Columns>
          <asp:TemplateField><ItemTemplate ><%#Eval("line_id")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_line_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("temp_id")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_temp_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_method_id")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_chk_method_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("project_id")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_project_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("project_name")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_project_name" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("pic_id")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_pic_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("pic_name")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_pic_name" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_km_name")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_chk_km_name" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("pic_sign")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_pic_sign" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_id")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_chk_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_name")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_chk_name" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("tool_id")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_tool_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_0")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_kj_0" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_1")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_kj_1" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_2")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_kj_2" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_explain")%></ItemTemplate><ItemStyle  HorizontalAlign="Left" CssClass="jq_kj_explain" /></asp:TemplateField>
      </Columns>
   </asp:GridView>
</div>

        <asp:TextBox ID="hidLineId" runat="server" class="jq_line_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidTempId" runat="server" class="jq_temp_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidChkMethodId" runat="server" class="jq_chk_method_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidProjectId" runat="server" class="jq_project_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidProjectName" runat="server" class="jq_project_name_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidPicId" runat="server" class="jq_pic_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidPicName" runat="server" class="jq_pic_name_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidChkKmName" runat="server" class="jq_chk_km_name_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidPicSign" runat="server" class="jq_pic_sign_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidChkId" runat="server" class="jq_chk_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidChkName" runat="server" class="jq_chk_name_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidToolId" runat="server" class="jq_tool_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidKj0" runat="server" class="jq_kj_0_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidKj1" runat="server" class="jq_kj_1_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidKj2" runat="server" class="jq_kj_2_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidKjExplain" runat="server" class="jq_kj_explain_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidOldRowIdx" runat="server" class="jq_hidOldRowIdx" style=" visibility:hidden;"></asp:TextBox>
    </div>
    </form>
</body>
</html>
