<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MENU</title>
        <!--JS-->
    <script language="javascript" type="text/javascript" src="./js/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="./JidouTemp.js"></script>
    <script language="javascript" type="text/javascript" src="./t_check_plan.aspx.js"></script>

    <!--CSS-->
    <link href="tmp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class='title_div'> <%Response.Write(Common.SetTitle("ＭＥＮＵ"))%>
         
        </div>
        <div style="font-size:24px; margin-left:20px; height:400px;">
      <table  class='jyouken_panel' cellpadding="0" cellspacing="0" style="font-size:24px;">

            <tr>

                <td style="        border-bottom:solid 8px #ccedf6;">
                    Ｍａｓｔｅｒ</td>

                <td>


                    &nbsp;</td>

                <td style="        border-bottom:solid 8px #ccedf6;">

                    生产计划作成

                </td>

                <td style="        ">

                    &nbsp;</td>

                <td style="        border-bottom:solid 8px #ccedf6;">

                    检查</td>

                <td style="        ">

                    &nbsp;</td>

                <td style="        border-bottom:solid 8px #ccedf6;">

                    帐票</td>

            </tr>


            <tr>

                <td style="vertical-align:top; padding:10px 20px 10px 20px; width:150px">
                    <asp:LinkButton ID="lbUser" runat="server">用户MS</asp:LinkButton><br />
                    <asp:LinkButton ID="lbProject" runat="server">工程MS</asp:LinkButton><br />
                    <asp:LinkButton ID="lbTools" runat="server">治具MS</asp:LinkButton><br />
                    <asp:LinkButton ID="lbPic" runat="server">图片MS</asp:LinkButton><br />
                    <asp:LinkButton ID="lbCheckMethod" runat="server">检查方法MS</asp:LinkButton><br />


                </td>

                <td style="vertical-align:top;padding:10px 20px 10px 20px; width:10px">


                </td>

                <td style="vertical-align:top;padding:10px 20px 10px 20px; width:150px">
                    <asp:LinkButton ID="lbTemp" runat="server">模板MS</asp:LinkButton><br />
                    <asp:LinkButton ID="lbRelation" runat="server">关联商品与模板</asp:LinkButton><br />
                    <asp:LinkButton ID="lbPlan" runat="server">检查计划</asp:LinkButton><br />

                    &nbsp;</td>

                <td style="vertical-align:top;padding:10px 20px 10px 20px; width:10px">
                    &nbsp;

                </td>

                <td style="vertical-align:top;padding:10px 20px 10px 20px; width:150px">
                    <asp:LinkButton ID="LinkButton1" runat="server">检查一览</asp:LinkButton><br /></td>

                <td style="vertical-align:top;padding:10px 20px 10px 20px; width:10px">
                    &nbsp;</td>

                <td style="vertical-align:top;padding:10px 20px 10px 20px; width:150px">
                    <asp:LinkButton ID="LinkButton2" runat="server">帐票出力</asp:LinkButton><br /></td>

            </tr>


        </table>

        </div>
  
    <div>

    </div>
    </form>
</body>
</html>
