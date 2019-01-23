
Partial Class apexcharts_Default
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            tbxDate_key.Text = System.DateTime.Now.ToString("yyyy/MM/dd")
            tbxDate_key.Attributes("itType") = "date"
            tbxDate_key.Attributes("itLength") = "20"
            tbxDate_key.Attributes("itName") = "登録日"
        End If


    End Sub




    Public Function GetGraData() As String


        Dim startDate As Date = CDate(tbxDate_key.Text)
        Dim startEnd As Date = DateAdd(DateInterval.Month, 1, startDate)

        Dim sb0 As New StringBuilder

        With sb0
            .AppendLine("    var myDate;")
            .AppendLine("    var tm;")
            .AppendLine("    var data = [];")
            .AppendLine("    var data2 = [];")
            .AppendLine("    myDate = new Date(" & startDate.Year & ", " & startDate.Month & ", " & startDate.Day & ");")
            .AppendLine("    tm = myDate.getTime();")
        End With

        Dim sb As New StringBuilder
        Dim BC As New TCheckResultBC



        Dim dt As Data.DataTable = BC.SelTCheckResult(tbxLineId_key.Text.Trim, startDate.ToString("yyyy/MM/dd"), startEnd.ToString("yyyy/MM/dd"), "", "")

        Dim iDate As Date = startDate

        While iDate <= startEnd

            Dim drs() As Data.DataRow = dt.Select("yotei_chk_date='" & iDate.ToString("yyyy/MM/dd") & "'")


            '加一天
            If sb.Length > 0 Then
                sb.AppendLine("tm = tm + 86400000;")

            End If


            '计划
            sb.AppendLine("data.push([tm, " & dt.Select("yotei_chk_date='" & iDate.ToString("yyyy/MM/dd") & "'").Length & "]);")
            '实际
            sb.AppendLine("data2.push([tm, " & dt.Select("yotei_chk_date='" & iDate.ToString("yyyy/MM/dd") & "' AND chk_times=1").Length & "]);")

            iDate = DateAdd(DateInterval.Day, 1, iDate)
        End While

        Return sb0.ToString & vbNewLine & sb.ToString


    End Function
End Class
