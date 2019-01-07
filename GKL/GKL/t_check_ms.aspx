<%@ Page Language="VB" AutoEventWireup="false" CodeFile="t_check_ms.aspx.vb" Inherits="t_check_ms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1"  />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>???果</title>

    <!--JS-->
    <script language="javascript" type="text/javascript" src="./js/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="./JidouTemp.js"></script>
    <script language="javascript" type="text/javascript" src="./t_check_ms.aspx.js"></script>

    <!--CSS-->
    <link href="tmp.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <div>
        <div class='title_div'>???果</div>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <hr />
<!--条件部-->
        <table class='jyouken_panel' cellpadding="0" cellspacing="0">
            <tr>
            <td>??No : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxChkNo_key" class="jq_chk_no_key" runat="server" style="width:200px;background-color: #FFAA00;"></asp:TextBox>
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
      <table class='ms_title' style="width:2266px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:210px;">
                  ??No 20
              </td>
              <td style="width:170px;">
                  ???目ID 10
              </td>
              <td style="width:30px;">
                  ??flg 1
              </td>
              <td style="width:210px;">
                  入力値1 20
              </td>
              <td style="width:210px;">
                  入力値2 20
              </td>
              <td style="width:210px;">
                  ???果 20
              </td>
              <td style="width:210px;">
                  ?考 200
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
              <td style="width:58px;">
                  基准説明 3
              </td>
              <td style="width:210px;">
                  登録者 20
              </td>
              <td style="">
                  登録日 3
              </td>
          </tr>
      </table>
</div>

<!--明細Body部-->
<div id="divGvw" class='jq_ms_div' runat ="server" style="overflow:scroll ; height:294px;margin-left:0px; width:1020px; margin-top :0px; border-collapse :collapse ;">
      <table class='ms_input' style="width:2266px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:210px;">
              <asp:TextBox ID="tbxChkNo" class="jq_chk_no_ipt" runat="server" maxLength="20" style="width:204px;background-color: #FFAA00;"></asp:TextBox>
          </td>
              <td style="width:170px;">
              <asp:TextBox ID="tbxChkMethodId" class="jq_chk_method_id_ipt" runat="server" maxLength="10" style="width:164px;"></asp:TextBox>
          </td>
              <td style="width:30px;">
              <asp:TextBox ID="tbxChkFlg" class="jq_chk_flg_ipt" runat="server" maxLength="1" style="width:24px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxIn1" class="jq_in_1_ipt" runat="server" maxLength="20" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxIn2" class="jq_in_2_ipt" runat="server" maxLength="20" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxChkResult" class="jq_chk_result_ipt" runat="server" maxLength="20" style="width:204px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxMark" class="jq_mark_ipt" runat="server" maxLength="200" style="width:204px;"></asp:TextBox>
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
              <td style="width:58px;">
              <asp:TextBox ID="tbxKjExplain" class="jq_kj_explain_ipt" runat="server" maxLength="3" style="width:52px;"></asp:TextBox>
          </td>
              <td style="width:210px;">
              <asp:TextBox ID="tbxInsUser" class="jq_ins_user_ipt" runat="server" maxLength="20" style="width:204px;"></asp:TextBox>
          </td>
              <td style="">
              <asp:TextBox ID="tbxInsDate" class="jq_ins_date_ipt" runat="server" maxLength="3" style="width:48px;"></asp:TextBox>
          </td>
          </tr>
      </table>
   <asp:GridView CssClass ="jq_ms" Width="2266px"  runat="server" ID="gvMs" EnableTheming="True" ShowHeader="False" AutoGenerateColumns="False" BorderColor="black" style=" margin-top :-1px; " TabIndex="-1" >
      <Columns>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_no")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_chk_no" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_method_id")%></ItemTemplate><ItemStyle Width="170px" HorizontalAlign="Left" CssClass="jq_chk_method_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_flg")%></ItemTemplate><ItemStyle Width="30px" HorizontalAlign="Left" CssClass="jq_chk_flg" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("in_1")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_in_1" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("in_2")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_in_2" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_result")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_chk_result" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("mark")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_mark" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_0")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_kj_0" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_1")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_kj_1" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_2")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_kj_2" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_explain")%></ItemTemplate><ItemStyle Width="58px" HorizontalAlign="Left" CssClass="jq_kj_explain" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("ins_user")%></ItemTemplate><ItemStyle Width="210px" HorizontalAlign="Left" CssClass="jq_ins_user" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("ins_date")%></ItemTemplate><ItemStyle  HorizontalAlign="Left" CssClass="jq_ins_date" /></asp:TemplateField>
      </Columns>
   </asp:GridView>
</div>

        <asp:TextBox ID="hidChkNo" runat="server" class="jq_chk_no_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidChkMethodId" runat="server" class="jq_chk_method_id_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidChkFlg" runat="server" class="jq_chk_flg_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidIn1" runat="server" class="jq_in_1_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidIn2" runat="server" class="jq_in_2_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidChkResult" runat="server" class="jq_chk_result_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidMark" runat="server" class="jq_mark_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidKj0" runat="server" class="jq_kj_0_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidKj1" runat="server" class="jq_kj_1_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidKj2" runat="server" class="jq_kj_2_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidKjExplain" runat="server" class="jq_kj_explain_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidInsUser" runat="server" class="jq_ins_user_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidInsDate" runat="server" class="jq_ins_date_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidOldRowIdx" runat="server" class="jq_hidOldRowIdx" style=" visibility:hidden;"></asp:TextBox>
    </div>
    </form>
</body>
</html>
