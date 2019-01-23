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
        <div class='title_div' style="width:1000px; ">
            <table style=" border:none; width:1000px">
                <tr>
                    <td style=" border:none; width:150px;">检查明細</td>
                    <td style=" border:none;">
                        <div style="font-size:12px; border:none;">
                            &nbsp;&nbsp;&nbsp;&nbsp;作番：<asp:Label ID="lblMake_no" runat="server" Text="001" ></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;CODE：<asp:Label ID="lblCode" runat="server" Text="001" ></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;检查者：<asp:Label ID="lblUser" runat="server" Text="001" ></asp:Label>
                            &nbsp;&nbsp;<asp:Label ID="lblUserName" runat="server" Text="001" ></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;（生产线：<asp:Label ID="lblLine_id" runat="server" Text="001" ></asp:Label>）
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnComplete" runat="server" Text="完了" Width="100" height="24" OnClick="btnComplete_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnModoru" runat="server" Text="返回" Width="100" height="24" OnClick="btnModoru_Click"/>
                        </div>
                    </td>
                </tr>
            </table>


        </div>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

       
        
<!--条件部-->
        <table class='jyouken_panel' style="width:1000px" cellpadding="0" cellspacing="0">
            <tr>
                <td>

                </td>
                <td>

                </td>
                <td style="text-align:right;"><asp:Label ID="lblSou" runat="server" Text="" Width="400px" ></asp:Label></td>
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
<div id="divGvw" class='jq_ms_div' runat ="server" style="overflow:auto ; height:580px;margin-left:0px; width:1024px; margin-top :0px; border-collapse :collapse ;">
     
   <asp:GridView CssClass ="jq_ms" Width="1000px"  runat="server" ID="gvMs" EnableTheming="True" ShowHeader="False" AutoGenerateColumns="False" BorderColor="black" style=" margin-top :-1px; " TabIndex="-1" >
      <Columns>
          <asp:BoundField DataField="project_name" HeaderText="" ControlStyle-Width="80px" ItemStyle-Width="80px" />
          <asp:BoundField DataField="chk_km_name" HeaderText=""  ControlStyle-Width="100px" ItemStyle-Width="100px" />
          <asp:TemplateField><ItemTemplate ><%#Eval("pic_sign")%></ItemTemplate><ItemStyle Width="30px" HorizontalAlign="Left" CssClass="jq_chk_flg" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("chk_name")%></ItemTemplate><ItemStyle Width="110px" HorizontalAlign="Left" CssClass="jq_in_1" /></asp:TemplateField>
          <asp:TemplateField><ItemTemplate ><%#Eval("kj_explain_Expr")%></ItemTemplate><ItemStyle Width="180px" HorizontalAlign="Left" CssClass="jq_in_2" /></asp:TemplateField>
          <asp:TemplateField>
              <ItemTemplate >
                  <asp:TextBox ID="tbxIn1" runat="server" Text='<%#Eval("in_1")%>' CssClass="jq_in1" Width="98%" AutoCompleteType="Disabled"></asp:TextBox>                  
              </ItemTemplate>              
          <ItemStyle Width="160px" HorizontalAlign="Left" CssClass="jq_chk_result" /></asp:TemplateField>
          <asp:TemplateField>
              <ItemTemplate >
                <asp:TextBox ID="tbxresult" runat="server" Text='<%#Eval("chk_result")%>' CssClass="jq_result" BorderStyle="None" TabIndex="-1" Width="92%"></asp:TextBox>
              </ItemTemplate>
              <ItemStyle Width="40px" HorizontalAlign="Left" /></asp:TemplateField>
          <asp:TemplateField>
              <ItemTemplate >
                <asp:TextBox ID="tbxMark" runat="server" Text='<%#Eval("mark")%>' CssClass="jq_mark" Width="98%" AutoCompleteType="Disabled"></asp:TextBox>
              </ItemTemplate><ItemStyle HorizontalAlign="Left" CssClass="jq_kj_0" /></asp:TemplateField>
      </Columns>
   </asp:GridView>
</div>
<table style="width:1000px;">
    <td >

        <img id="gvMs_ctl02_imgLook" class="JQ_IMG" style="border-width:0px;" />
    </td>
    <td style="width:250px; vertical-align:top; text-align:center; ">


        <table class="keyboard">
            <tr>
                <td style="width:60px;"><input type="button" value="7" /></td>
                <td style="width:60px;"><input type="button" value="8" /></td>
                <td style="width:60px;"><input type="button" value="9" /></td>
                <td rowspan="2"><input type="button" value="删除" /></td>
            </tr>
            <tr>
                <td><input type="button" value="4" /></td>
                <td><input type="button" value="5" /></td>
                <td><input type="button" value="6" /></td>
            </tr>
            <tr>
                <td><input type="button" value="1" /></td>
                <td><input type="button" value="2" /></td>
                <td><input type="button" value="3" /></td>
                <td rowspan="2" ><input type="button" value="回车" /></td>
            </tr>
            <tr>
                <td colspan="2"><input type="button" value="0" /></td>
                <td><input type="button" value="." /></td>
            </tr>
            <tr>
                <td colspan="2"><input type="button" value="NG" /></td>
                <td colspan="2"><input type="button" value="OK" /></td>
            </tr>
        </table>


    </td>
</table>
        <input type="text" id="SC" style="height:4px;width:4px; font-size:1px;" />

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
        <asp:TextBox ID="hidInsDate" runat="server" class="jq_ins_date_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidOldRowIdx" runat="server" class="jq_hidOldRowIdx" style=" visibility:hidden;"></asp:TextBox>

        <asp:TextBox ID="hidLineId" runat="server" class="jq_chk_no_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidInsUser" runat="server" class="jq_ins_user_ipt" style=" visibility:hidden;"></asp:TextBox>
        <asp:TextBox ID="hidLineIdKey" runat="server" class="jq_ins_user_ipt" style=" visibility:hidden;"></asp:TextBox>
   
    </div>
    </form>
</body>
</html>
