﻿Imports System.Data
Imports System.Text
Imports System.IO

Imports MyMethod = System.Reflection.MethodBase
Partial Class t_check_plan
    Inherits System.Web.UI.Page

   Public BC AS NEW TCheckPlanBC
    ''' <summary>
    ''' PAGE LOAD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Me.lblMsg.Text = ""
        If Not IsPostBack Then

            '固定項目設定
            KoteiInit()

            '明細項目設定
            MsInit()
        End If

    End Sub
    ''' <summary>
    ''' 固定項目設定
    ''' </summary>
    public Sub KoteiInit()

       Me.tbxPlanNo.Attributes.Item("itType") = "varchar"
       Me.tbxPlanNo.Attributes.Item("itLength") = "20"
       Me.tbxPlanNo.Attributes.Item("itName") = "计划No"
       Me.tbxChkNo.Attributes.Item("itType") = "varchar"
       Me.tbxChkNo.Attributes.Item("itLength") = "20"
       Me.tbxChkNo.Attributes.Item("itName") = "检查No"
       Me.tbxMakeNo.Attributes.Item("itType") = "varchar"
       Me.tbxMakeNo.Attributes.Item("itLength") = "20"
       Me.tbxMakeNo.Attributes.Item("itName") = "作番"
       Me.tbxCode.Attributes.Item("itType") = "varchar"
       Me.tbxCode.Attributes.Item("itLength") = "20"
       Me.tbxCode.Attributes.Item("itName") = "コード"
       Me.tbxLineId.Attributes.Item("itType") = "varchar"
       Me.tbxLineId.Attributes.Item("itLength") = "10"
        Me.tbxLineId.Attributes.Item("itName") = "生产线"

        Me.tbxSuu.Attributes.Item("itType") = "int"
       Me.tbxSuu.Attributes.Item("itLength") = "10"
        Me.tbxSuu.Attributes.Item("itName") = "数量"

       Me.tbxYoteiChkDate.Attributes.Item("itType") = "date"
        Me.tbxYoteiChkDate.Attributes.Item("itLength") = "10"
        Me.tbxYoteiChkDate.Attributes.Item("itName") = "预订检查日"

       Me.tbxStatus.Attributes.Item("itType") = "varchar"
       Me.tbxStatus.Attributes.Item("itLength") = "1"
        Me.tbxStatus.Attributes.Item("itName") = "状态"

       Me.tbxInsUser.Attributes.Item("itType") = "nvarchar"
       Me.tbxInsUser.Attributes.Item("itLength") = "20"
        Me.tbxInsUser.Attributes.Item("itName") = "向先"
        Me.tbxInsDate.Attributes.Item("itType") = "nvarchar"
        Me.tbxInsDate.Attributes.Item("itLength") = "500"
        Me.tbxInsDate.Attributes.Item("itName") = "备注"

    End Sub


    Public Sub MsInit(Optional ByVal pageIdx As Integer = 1)

        '明細設定

        Dim dtMs As New DataTable
        Dim dtPageIdx As New DataTable
        Common.GetPageData(GetMsData(), pageIdx, dtMs, dtPageIdx)

        Me.gvMs.DataSource = dtMs
        Me.gvMs.DataBind()

        ddlPageIdx.DataValueField = "idx"
        ddlPageIdx.DataTextField = "idx"
        Me.ddlPageIdx.DataSource = dtPageIdx
        Me.ddlPageIdx.DataBind()

        lblAllPageText.Text = ddlPageIdx.Items.Count

        If ddlPageIdx.Items.Count > pageIdx Then
            ddlPageIdx.SelectedIndex = pageIdx - 1
        End If
    End Sub


    ''' <summary>
    ''' 検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSelect_Click(sender As Object, e As System.EventArgs) Handles btnSelect.Click

        MsInit()
    End Sub

    ''' <summary>
    ''' 明細データ取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMsData() As Data.DataTable

        Return BC.SelTCheckPlan(tbxPlanNo_key.Text, tbxChkNo_key.Text, tbxMakeNo_key.Text, tbxCode_key.Text, tbxLineId_key.Text, Me.tbxCheckDate_key.Text)
    End Function

    ''' <summary>
    ''' データ存在チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsHaveData() As Boolean

        Return BC.SelTCheckPlan(tbxPlanNo.Text, tbxChkNo.Text, tbxMakeNo.Text, tbxCode.Text, tbxLineId.Text, Me.tbxCheckDate_key.Text).Rows.Count > 0
    End Function

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click


            Try
       BC.UpdTCheckPlan(hidplanNo.Text, hidchkNo.Text, hidmakeNo.Text, hidcode.Text, hidlineId.Text,tbxplanNo.Text, tbxchkNo.Text, tbxmakeNo.Text, tbxcode.Text, tbxlineId.Text, tbxsuu.Text, tbxyoteiChkDate.Text, tbxstatus.Text, tbxinsUser.Text, tbxinsDate.Text)
        MsInit()
            Catch ex As Exception
                Common.ShowMsg(Me.Page, ex.Message)
                Exit Sub
            End Try
Me.hidOldRowIdx.Text = ""
    End Sub
    ''' <summary>
    ''' 登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnInsert_Click(sender As Object, e As System.EventArgs) Handles btnInsert.Click

        'データ存在チェック
            If IsHaveData() Then
                Common.ShowMsg(Me.Page, "数据已经存在")
                Exit Sub
            End If
            Try
            BC.InsTCheckPlan(tbxplanNo.Text, tbxchkNo.Text, tbxmakeNo.Text, tbxcode.Text, tbxlineId.Text, tbxsuu.Text, tbxyoteiChkDate.Text, tbxstatus.Text, tbxinsUser.Text, tbxinsDate.Text)
                MsInit()
            Catch ex As Exception
                Common.ShowMsg(Me.Page, ex.Message)
                Exit Sub
            End Try
Me.hidOldRowIdx.Text = ""
    End Sub

    ''' <summary>
    ''' 削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click


        Try
            BC.DelTCheckPlan(hidPlanNo.Text, hidChkNo.Text, hidMakeNo.Text, hidCode.Text, hidLineId.Text)
            MsInit()
        Catch ex As Exception
            Common.ShowMsg(Me.Page, ex.Message)
            Exit Sub
        End Try
        Me.hidOldRowIdx.Text = ""
    End Sub

    Protected Sub Upload()

        If GetUploadFileContent.PostedFile.InputStream.Length < 1 Then
            'Msg.Text = "请选择文件"
            Common.ShowMsg(Me.Page, "请选择文件")
            Exit Sub

            Return
        End If

        Dim FileName As String = GetUploadFileContent.FileName
        Dim FilePath As String = GetUploadFileContent.PostedFile.FileName

        Dim dt As New DataTable
        dt.Columns.Add("plan_no")
        dt.Columns.Add("chk_no")
        dt.Columns.Add("make_no")
        dt.Columns.Add("code")
        dt.Columns.Add("line_id")
        dt.Columns.Add("suu")
        dt.Columns.Add("yotei_chk_date")
        dt.Columns.Add("status")
        dt.Columns.Add("xiangxian")
        dt.Columns.Add("mark")

        Dim arr() As String

        Dim FileLen As Integer = GetUploadFileContent.PostedFile.ContentLength
        Dim input As Byte() = New Byte(FileLen - 1) {}
        Dim UpLoadStream As System.IO.Stream = GetUploadFileContent.PostedFile.InputStream
        UpLoadStream.Read(input, 0, FileLen)
        UpLoadStream.Position = 0
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(UpLoadStream, System.Text.Encoding.[Default])
        'Msg.Text = "您上传的文件内容是：<br/><br/>" & sr.ReadToEnd()

        arr = sr.ReadToEnd.Split(vbNewLine)


        sr.Close()
        UpLoadStream.Close()
        UpLoadStream = Nothing
        sr = Nothing

        'Dim idx As String = Now.ToString("yyyyMM")
        Dim ymd As String = Now.ToString("yyMMdd")

        Dim str As String

        For Each str In arr
            If str.Trim <> "" Then

                Dim dr As DataRow
                dr = dt.NewRow

                '生产线，作番，计划数量，商品CODE，计划日期，不用，向先，备注
                Dim make_no As String = str.Split(",")(1).Replace(vbCr, "").Replace(vbLf, "").Trim
                Dim yoteiYMD As String = str.Split(",")(4).Replace(vbCr, "").Replace(vbLf, "").Trim
                dr.Item("plan_no") = Left(yoteiYMD.Replace("/", ""), 6)
                dr.Item("chk_no") = ymd & "_" & make_no

                '作番
                dr.Item("make_no") = make_no
                '商品CODE
                dr.Item("code") = str.Split(",")(3).Replace(vbCr, "").Replace(vbLf, "").Trim
                '生产线
                dr.Item("line_id") = str.Split(",")(0).Replace(vbCr, "").Replace(vbLf, "").Trim
                '计划数量
                dr.Item("suu") = str.Split(",")(2).Replace(vbCr, "").Replace(vbLf, "").Trim
                '计划日期
                dr.Item("yotei_chk_date") = yoteiYMD


                dr.Item("status") = "0"
                dr.Item("xiangxian") = str.Split(",")(6).Replace(vbCr, "").Replace(vbLf, "").Trim
                dr.Item("mark") = str.Split(",")(7).Replace(vbCr, "").Replace(vbLf, "").Trim

                dt.Rows.Add(dr)


            End If
        Next

        Try



            If dt.Rows.Count > 0 Then

                '戻りデータセット
                Dim dsInfo As New Data.DataSet

                Using conn As New SqlClient.SqlConnection(DataAccessManager.Connection)

                    conn.Open()

                    'Dim sqlTransaction As SqlTransaction = conn.BeginTransaction()
                    't_check_plan
                    Dim sql As String
                    'sql = "TRUNCATE TABLE #t_check_plan_junbi"
                    sql = "SELECT * INTO #t_check_plan_junbi FROM t_check_plan WHERE 1<>1"
                    Dim SqlCommand As System.Data.SqlClient.SqlCommand = conn.CreateCommand()
                    SqlCommand.CommandText = sql
                    SqlCommand.CommandTimeout = 0
                    'SqlCommand.Transaction = sqlTransaction
                    SqlCommand.ExecuteNonQuery()



                    Dim bCopy As New SqlClient.SqlBulkCopy(conn)
                    bCopy.BulkCopyTimeout = 30
                    bCopy.DestinationTableName = "#t_check_plan_junbi"
                    bCopy.WriteToServer(dt)

                    'Dim sb2 As New StringBuilder
                    'With sb2
                    '    .AppendLine("SELECT Distinct temp_id")
                    '    .AppendLine("FROM #t_check_plan_junbi ")
                    '    .AppendLine("WHERE temp_id not in (select temp_id from m_temp_name)")
                    'End With

                    'Dim dataAdatpter As System.Data.SqlClient.SqlDataAdapter = Nothing
                    'Dim command As System.Data.SqlClient.SqlCommand = conn.CreateCommand()
                    'command = New System.Data.SqlClient.SqlCommand(sb2.ToString(), conn)
                    'command.CommandTimeout = 320
                    ''実行
                    'dataAdatpter = New System.Data.SqlClient.SqlDataAdapter(command)
                    'dataAdatpter.Fill(dsInfo)
                    'If dsInfo.Tables(0).Rows.Count > 0 Then
                    'Else
                    Dim sb As New StringBuilder
                    With sb
                        .AppendLine("DELETE")
                        .AppendLine("FROM t_check_plan ")
                        .AppendLine("WHERE  ")
                        .AppendLine("EXISTS (")
                        .AppendLine("               SELECT 1")
                        .AppendLine("               FROM   #t_check_plan_junbi t")
                        .AppendLine("               WHERE  t_check_plan.plan_no = t.plan_no")
                        '.AppendLine("                      AND t_check_plan.chk_no = t.chk_no")
                        .AppendLine("                      AND t_check_plan.make_no = t.make_no")
                        .AppendLine("                      AND t_check_plan.code = t.code")
                        .AppendLine("                      AND t_check_plan.line_id = t.line_id")
                        .AppendLine("           )")
                        .AppendLine("")
                        .AppendLine("INSERT INTO t_check_plan SELECT * FROM #t_check_plan_junbi")
                    End With
                    SqlCommand.Dispose()
                    Dim SqlCommand2 As System.Data.SqlClient.SqlCommand = conn.CreateCommand()
                    SqlCommand2.CommandText = sb.ToString
                    'SqlCommand2.Transaction = sqlTransaction
                    SqlCommand2.CommandTimeout = 0
                    SqlCommand2.ExecuteNonQuery()
                    SqlCommand2.Dispose()
                    'End If

                    'sqlTransaction.Commit()

                End Using

                Common.ShowMsg(Me.Page, "导入的数据" & dt.Rows.Count & "件")

            Else
                Common.ShowMsg(Me.Page, "没有导入的数据")
                Exit Sub
            End If
        Catch ex As Exception
            Common.ShowMsg(Me.Page, ex.Message)
        End Try


    End Sub


    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Upload()
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Server.Transfer("Default.aspx")
    End Sub
End Class
