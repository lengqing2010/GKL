<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckItiran.aspx.cs" Inherits="CheckItiran" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1"  />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>检查一览</title>

    <!--JS-->
    <script language="javascript" type="text/javascript" src="./js/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="./JidouTemp.js"></script>
    <script language="javascript" type="text/javascript" src="./CheckItiran.aspx.js"></script>

    <!--CSS-->
    <link href="tmp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class='title_div'>
            <%Response.Write(Common.SetTitle("检查一览"));%>
            <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="jq_back" OnClick="btnBack_Click" />
        </div>
<!--条件部-->
        <table class='jyouken_panel' cellpadding="0" cellspacing="0">
            <tr>

            <td>检查者No</td>
            <td>
                <asp:TextBox ID="tbxCheckUser" class="jq_make_no_key" runat="server" style="width:100px;background-color: #FFAA00;" ></asp:TextBox>
            </td>
            <td>
<%--                <asp:Label ID="lblUserName" runat="server" Width="80px"></asp:Label>--%>
                <asp:TextBox ID="lblUserName" class="" runat="server" style="width:100px;background-color: #FFAA00;" ></asp:TextBox>
                </td>
            <td>生产线 : </td>
            <td>
              <asp:TextBox ID="tbxLineId_key" class="jq_line_id_key" runat="server" style="width:80px;background-color: #fff;" Text="SRM1312A" ></asp:TextBox>
                </td>

            <td>作番 : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxMakeNo_key" class="jq_make_no_ipt" runat="server" style="width:100px;background-color: #FFAA00;" ></asp:TextBox>
                </td>
            <td>
                CODE:</td>
            <td>
                <asp:TextBox ID="tbxCode_key" class="jq_code_ipt" runat="server" maxLength="20" style="width:180px;background-color: #FFAA00;"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnInsert" runat="server" Text="新规检查" CssClass="jq_ins" height="24" Width="100" OnClick="btnInsert_Click" />
                </td>
            </tr>
            <tr>
            <td>检查日：</td>
            <td><asp:TextBox ID="tbxDate_key" class="" runat="server" maxLength="20" style="width:100px;background-color: #FFAA00;"></asp:TextBox></td>
            <td colspan="2">未入力时 7日内</td>
            <td>&nbsp;</td>
            <td></td>
            <td>
        <asp:Button ID="btnSelect" runat="server" Text="検索" CssClass="jq_sel" OnClick="btnSelect_Click" height="24" Width="60"/>

                </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            </tr>
        </table>

<!--Button部-->
        <div style="width:1000px; text-align:right;">

    <!--Button部-->
            <asp:Button ID="btnUpdate" runat="server" Text="继续检查" CssClass="jq_upd"  Width="100" OnClick="btnUpdate_Click" />
            &nbsp;<asp:Button ID="btnComlete" runat="server" Text="强制完了" CssClass="" height="24" Width="100" OnClick="btnComlete_Click"  />
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="削除" CssClass="jq_del" Width="100" OnClick="btnDelete_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            第
            <asp:DropDownList ID="ddlPageIdx" runat="server" AutoPostBack="true" Width="60px" OnSelectedIndexChanged="ddlPageIdx_SelectedIndexChanged">
            </asp:DropDownList>
            /
            <asp:Label ID="lblAllPageText" runat="server" Text="0"></asp:Label>
            页
        </div>
<!--明細Title部-->
<div id="divGvwTitle" class='jq_title_div' runat ="server" style="overflow:hidden ;margin-left:0px; width:1004px; margin-top :0px; border-collapse :collapse ;">
      <table class='ms_title' style="width:1000px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:130px;">
                  检查No
              </td>
              <td style="width:110px;">
                  作番
              </td>
              <td style="width:160px;">
                  コード
              </td>
              <td style="width:40px;">
                  数量
              </td>
              <td style="width:40px;">
                  次数 
              </td>
              <td style="width:70px;">
                  检查模板编号
              </td>
              <td style="width:30px;">
                  检查结果
              </td>
              <td style="width:110px;">
                  检查者
              </td>
              <td style="width:68px;">
                  预定检查日
              </td>
              <td style="">
                  状态
              </td>
          </tr>
      </table>

</div>

<!--明細Body部-->
<div id="divGvw" class='jq_ms_div' runat ="server" style="overflow:scroll ; height:294px;margin-left:0px; width:1020px; margin-top :0px; border-collapse :collapse ;">

   <asp:GridView CssClass ="jq_ms" Width="1000px"  runat="server" ID="gvMs" EnableTheming="True" ShowHeader="False" AutoGenerateColumns="False" BorderColor="black" style=" margin-top :-1px; " TabIndex="-1" >
      <Columns>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_no")%></ItemTemplate><ItemStyle Width="130px" HorizontalAlign="Left" CssClass="jq_chk_no" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("make_no")%></ItemTemplate><ItemStyle Width="110px" HorizontalAlign="Left" CssClass="jq_make_no" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("code")%></ItemTemplate><ItemStyle Width="160px" HorizontalAlign="Left" CssClass="jq_code" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("suu")%></ItemTemplate><ItemStyle Width="40px" HorizontalAlign="Left" CssClass="jq_suu" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_times")%></ItemTemplate><ItemStyle Width="40px" HorizontalAlign="Left" CssClass="jq_chk_times" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("temp_id")%></ItemTemplate><ItemStyle Width="70px" HorizontalAlign="Left" CssClass="jq_temp_id" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_result")%></ItemTemplate><ItemStyle Width="30px" HorizontalAlign="Left" CssClass="jq_chk_result" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_user")%></ItemTemplate><ItemStyle Width="110px" HorizontalAlign="Left" CssClass="jq_chk_user" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("yotei_chk_date")%></ItemTemplate><ItemStyle Width="68px" HorizontalAlign="Left" CssClass="jq_chk_start_date" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("status")%></ItemTemplate><ItemStyle  HorizontalAlign="Left" CssClass="jq_status" /></asp:TemplateField>

      </Columns>
   </asp:GridView>
</div>

<asp:TextBox ID="hidChkNo" runat="server" class="jq_chk_no_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidNen" runat="server" class="jq_nen_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidPlanNo" runat="server" class="jq_plan_no_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidLineId" runat="server" class="jq_line_id_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidMakeNo" runat="server" class="jq_make_no_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidCode" runat="server" class="jq_code_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidSuu" runat="server" class="jq_suu_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidTempId" runat="server" class="jq_temp_id_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidChkResult" runat="server" class="jq_chk_result_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidChkUser" runat="server" class="jq_chk_user_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidChkStartDate" runat="server" class="jq_chk_start_date_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidChkEndDate" runat="server" class="jq_chk_end_date_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidParentChkNo" runat="server" class="jq_parent_chk_no_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidStatus" runat="server" class="jq_status_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidInsUser" runat="server" class="jq_ins_user_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidInsDate" runat="server" class="jq_ins_date_ipt" style=" visibility:hidden;"></asp:TextBox>
<asp:TextBox ID="hidOldRowIdx" runat="server" class="jq_hidOldRowIdx" style=" visibility:hidden;"></asp:TextBox>

<asp:TextBox ID="hidchk_times" runat="server" class="jq_chk_times_ipt" style=" visibility:hidden;"></asp:TextBox>

            <script language="javascript">

              </script>


    </form>
</body>
</html>
