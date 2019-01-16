<%@ Page Language="C#" AutoEventWireup="true" CodeFile="t_check_ms.aspx.cs" Inherits="t_check_ms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1"  />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>检查明細</title>

    <!--JS-->
    <script language="javascript" type="text/javascript" src="./js/jquery-1.4.1.min.js"></script>
<%--    <script language="javascript" type="text/javascript" src="./JidouTemp.js"></script>--%>
    <script language="javascript" type="text/javascript" src="./t_check_ms.aspx.js"></script>

    <!--CSS-->
    <link href="tmp_chk.css" rel="stylesheet" type="text/css" />
    </head>
<body>
<form id="form1" runat="server">
    <div>
        <div class='title_div'>检查明細</div>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

        <asp:Label ID="lblLine_id" runat="server" Text="001" ></asp:Label>
        
<!--条件部-->
        <table class='jyouken_panel' cellpadding="0" cellspacing="0">
            <tr>
            <td>检查No : &nbsp;</td>
            <td>
              <asp:TextBox ID="tbxChkNo_key" class="jq_chk_no_key" runat="server" style="width:200px;background-color: #FFAA00;"></asp:TextBox>
                <input type="text" id="ScanText" /><input type="button" />
            </td>
            <td></td>
            </tr>
        </table>
<!--明細Title部-->
<div id="divGvwTitle" class='jq_title_div' runat ="server" style="overflow:hidden ;margin-left:0px; width:1000px; margin-top :0px; border-collapse :collapse ;">
      <table class='ms_title' style="width:1000px" cellpadding="0" cellspacing="0">
          <tr>
              <td style="width:80px;">
                  工程名
              </td>
              <td style="width:100px;">
                  检查项目
              </td>
              <td style="width:30px;">
                  图片标记
              </td>
              <td style="width:110px;">
                  检查方法
              </td>
              <td style="width:180px;">
                  基准説明
              </td>
              <td style="width:160px;">
                  输入值
              </td>
              <td style="width:40px;">
                  结果
              </td>
              <td style="">
                  备考
              </td>
          </tr>
      </table>
</div>

<!--明細Body部-->
<div id="divGvw" class='jq_ms_div' runat ="server" style="overflow:scroll ; height:294px;margin-left:0px; width:1020px; margin-top :0px; border-collapse :collapse ;">
     
   <asp:GridView CssClass ="jq_ms" Width="1000px"  runat="server" ID="gvMs" EnableTheming="True" ShowHeader="False" AutoGenerateColumns="False" BorderColor="black" style=" margin-top :-1px; " TabIndex="-1" >
      <Columns>
          <asp:BoundField DataField="project_name" HeaderText="" ControlStyle-Width="80px" ItemStyle-Width="80px" />
          <asp:BoundField DataField="chk_km_name" HeaderText=""  ControlStyle-Width="100px" ItemStyle-Width="100px" />
         <%-- <asp:TemplateField><ItemTemplate ><%#Eval("project_name")%></ItemTemplate><ItemStyle Width="80px" HorizontalAlign="Left" CssClass="jq_chk_no" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_km_name")%></ItemTemplate><ItemStyle Width="100px" HorizontalAlign="Left" CssClass="jq_chk_method_id" /></asp:TemplateField>
     --%>
          <asp:TemplateField><ItemTemplate ><%#Eval("pic_sign")%></ItemTemplate><ItemStyle Width="30px" HorizontalAlign="Left" CssClass="jq_chk_flg" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_name")%></ItemTemplate><ItemStyle Width="110px" HorizontalAlign="Left" CssClass="jq_in_1" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("verify_method_explain")%></ItemTemplate><ItemStyle Width="180px" HorizontalAlign="Left" CssClass="jq_in_2" /></asp:TemplateField>
          <asp:TemplateField>
              <ItemTemplate >
                  <asp:TextBox ID="tbxIn1" runat="server" Text='<%#Eval("in_1")%>' CssClass="jq_in1" Width="98%"></asp:TextBox>                  
              </ItemTemplate>              
          <ItemStyle Width="160px" HorizontalAlign="Left" CssClass="jq_chk_result" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate >

              <asp:TextBox ID="tbxresult" runat="server" Text='<%#Eval("chk_result")%>' CssClass="jq_result" Width="92%"></asp:TextBox>
                             </ItemTemplate><ItemStyle Width="40px" HorizontalAlign="Left" CssClass="jq_mark" /></asp:TemplateField>
          <asp:TemplateField>
              <ItemTemplate >
                <asp:TextBox ID="tbxMark" runat="server" Text='<%#Eval("mark")%>' CssClass="jq_mark" Width="98%"></asp:TextBox>
              </ItemTemplate><ItemStyle HorizontalAlign="Left" CssClass="jq_kj_0" /></asp:TemplateField>
      </Columns>
   </asp:GridView>
</div>
<table style="width:1000px;">
    <td >

        <img id="gvMs_ctl02_imgLook" class="JQ_IMG" src="" style="border-width:0px;">
    </td>
    <td style="width:250px; vertical-align:top; text-align:center; ">


        <table class="keyboard">
            <tr>
                <td style="width:60px;">7</td>
                <td style="width:60px;">8</td>
                <td style="width:60px;">9</td>
                <td rowspan="2">删除</td>
            </tr>
            <tr>
                <td>4</td>
                <td>5</td>
                <td>6</td>
            </tr>
            <tr>
                <td>1</td>
                <td>2</td>
                <td>3</td>
                <td rowspan="2" >回车</td>
            </tr>
            <tr>
                <td colspan="2">0</td>
                <td>.</td>
            </tr>
            <tr>
                <td colspan="2">NG</td>
                <td colspan="2">OK</td>
            </tr>
        </table>


    </td>
</table>
        

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
