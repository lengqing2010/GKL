Imports Microsoft.VisualBasic

Public Class Common
    Public Shared Sub ShowMsg(ByVal page As Page, ByVal msg As String)

        Dim csScript As New StringBuilder

        With csScript
            .AppendLine("alert('" & msg & "');")
        End With

        'ページ応答で、クライアント側のスクリプト ブロックを出力します
        page.ClientScript.RegisterStartupScript(page.GetType(), "ShowMessage", csScript.ToString, True)

    End Sub

    Public Shared Function GetPageData(ByVal inDt As Data.DataTable, ByVal pageIdx As Integer, ByRef outDt As Data.DataTable, ByRef pageListDt As Data.DataTable) As Data.DataTable

        Dim onePageRowCnt As Integer = 100
        Dim mxPageIdx As Integer = Math.Ceiling(inDt.Rows.Count / onePageRowCnt)

        Dim dt As Data.DataTable = inDt.Clone
        For i = (pageIdx - 1) * onePageRowCnt To (pageIdx) * onePageRowCnt - 1
            If i < inDt.Rows.Count Then
                dt.Rows.Add(inDt.Rows(i).ItemArray)
            End If

        Next
        outDt = dt

        Dim dt2 As New Data.DataTable
        dt2.Columns.Add("idx")
        For i As Integer = 1 To mxPageIdx
            Dim dr As Data.DataRow = dt2.NewRow
            dr.Item(0) = i.ToString
            dt2.Rows.Add(dr)
        Next
        pageListDt = dt2
        Return Nothing
    End Function

    Public Shared Function SetTitle(ByVal txt As String) As String

        Dim str As String
        str = "检查系统 <" & txt & ">"
        Return str

    End Function

    Public Shared Function LineIds() As String
        Dim dt As Data.DataTable = (New MUserBC).SelLineIds()
        Dim sb As New StringBuilder
        For i As Integer = 0 To dt.Rows.Count - 1
            sb.AppendLine("<option value=""" & dt.Rows(i).Item(0).ToString & """></option>")
        Next
        Return sb.ToString
    End Function

    Public Shared Function TempIds(ByVal line_id As String) As String
        Dim dt As Data.DataTable = (New MTempBC).SelTempIds(line_id)
        Dim sb As New StringBuilder
        For i As Integer = 0 To dt.Rows.Count - 1
            sb.AppendLine("<option value=""" & dt.Rows(i).Item(0).ToString & """></option>")
        Next
        Return sb.ToString
    End Function

End Class
