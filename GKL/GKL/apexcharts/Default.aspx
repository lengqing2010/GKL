<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="apexcharts_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script language="javascript" type="text/javascript" src="../js/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="../JidouTemp.js"></script>
    <style>
    body {
      background: #000524;
    }

    #wrapper {
      padding-top: 60px;
      background: #000524;
      border: 1px solid #000;
      box-shadow: 0 22px 35px -16px rgba(0, 0, 0, 0.71);
      max-width: 1050px;
      margin: 35px auto;
    }

    #chart-bar {
      position: relative;
      margin-top: -38px;
    }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <script src="js/apexcharts.js"></script>
        <div style="color:#fff;">
            生产线：
            <asp:TextBox ID="tbxLineId_key" class="jq_line_id_key" runat="server" style="width:160px;background-color: #FFAA00;" list="line_id_list"></asp:TextBox>
            开始检查日：
            <asp:TextBox ID="tbxDate_key" class="" runat="server" maxLength="20" style="width:100px;background-color: #FFAA00;"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="検索" />
        </div>
        <div id="wrapper">
          <div id="chart-area">

          </div>
          <div id="chart-bar">

          </div>
        </div>



<script>


    <%
    Response.Write(GetGraData())
    %>

    var options1 = {
        chart: {
            id: "chart2",
            type: "area",
            height: 600,
            foreColor: "#fff",//
            toolbar: {
                autoSelected: "pan",
                show: true
            }
        },
        colors: ['#fff', '#00BAEC'],
        stroke: {
            width: 2
        },
        grid: {
            borderColor: ['red', 'blue'],
            yaxis: {
                lines: {
                    show: true
                }
            }
        },
        dataLabels: {
            enabled: true
        },
        fill: {
            gradient: {
                enabled: true,
                opacityFrom: 0.55,
                opacityTo: 0
            }
        },
        markers: {
            size: 5,
            colors: ["#000524"],
            strokeColor: "#00BAEC",
            strokeWidth: 3
        },
        series: [
          {
              name: "计划检查",
              data: data
          },
          {
              name: "实际检查",
              data: data2
          }
        ],
        tooltip: {
            theme: "dark"
        },
        xaxis: {
            type: "datetime"
        },
        yaxis: {
            min: 0,
            tickAmount: 1
        }
    };

    var chart1 = new ApexCharts(document.querySelector("#chart-area"), options1);

    chart1.render();


    function generateDayWiseTimeSeries(baseval, count, yrange) {
        var i = 0;
        var series = [];
        while (i < count) {
            var x = baseval;
            var y =
                Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;

            series.push([x, y]);
            baseval += 86400000;
            i++;
        }
        return series;
    }
</script>
    </form>
</body>
</html>
