



Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic

Public Class TCheckPlanDA
    Public SqlHelperNew As New SqlHelperNew
    ''' <summary>
    ''' 
    ''' 检查计划Infoを検索する
    ''' </summary>
    '''<param name="planNo_key">计划No</param>
    '''<param name="chkNo_key">检查No</param>
    '''<param name="makeNo_key">作番</param>
    '''<param name="code_key">コード</param>
    '''<param name="lineId_key">生产线</param>
    ''' <returns>检查计划Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelTCheckPlan(ByVal planNo_key As String, _
           ByVal chkNo_key As String, _
           ByVal makeNo_key As String, _
           ByVal code_key As String, _
           ByVal lineId_key As String, _
           ByVal tbxCheckDate_key As String) As Data.DataTable

        'SQLコメント
        '--**テーブル：检查计划 : t_check_plan
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("plan_no")                                                   '计划No
        sb.AppendLine(", chk_no")                                                  '检查No
        sb.AppendLine(", make_no")                                                 '作番
        sb.AppendLine(", code")                                                    'コード
        sb.AppendLine(", line_id")                                                 '生产线
        sb.AppendLine(", suu")                                                     '数量
        sb.AppendLine(", yotei_chk_date")   '预订检查日
        sb.AppendLine(", status")                                                  '状态
        sb.AppendLine(", xiangxian")                                                '登録者
        sb.AppendLine(", mark")                                                '登録日

        sb.AppendLine("FROM t_check_plan")
        sb.AppendLine("WHERE 1=1")
        If planNo_key <> "" Then
            sb.AppendLine("AND plan_no=@plan_no_key")   '计划No
        End If
        If chkNo_key <> "" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '检查No
        End If
        If makeNo_key <> "" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If
        If code_key <> "" Then
            sb.AppendLine("AND code=@code_key")   'コード
        End If
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If

        If tbxCheckDate_key <> "" Then
            sb.AppendLine("AND yotei_chk_date='" & tbxCheckDate_key & "'")   '生产线
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@plan_no_key", SqlDbType.VarChar, 20, planNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
        paramList.Add(SqlHelperNew.MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

        Dim dsInfo As New Data.DataSet
        SqlHelperNew.FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "t_check_plan", paramList.ToArray)

        Return dsInfo.Tables("t_check_plan")

    End Function

    ''' <summary>
    ''' 
    ''' 检查计划Infoを更新する
    ''' </summary>
    '''<param name="planNo_key">计划No</param>
    '''<param name="chkNo_key">检查No</param>
    '''<param name="makeNo_key">作番</param>
    '''<param name="code_key">コード</param>
    '''<param name="lineId_key">生产线</param>
    '''<param name="planNo">计划No</param>
    '''<param name="chkNo">检查No</param>
    '''<param name="makeNo">作番</param>
    '''<param name="code">コード</param>
    '''<param name="lineId">生产线</param>
    '''<param name="suu">数量</param>
    '''<param name="yoteiChkDate">预订检查日</param>
    '''<param name="status">状态</param>
    '''<param name="insUser">登録者</param>
    '''<param name="insDate">登録日</param>
    ''' <returns>检查计划Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function UpdTCheckPlan(ByVal planNo_key As String, _
               ByVal chkNo_key As String, _
               ByVal makeNo_key As String, _
               ByVal code_key As String, _
               ByVal lineId_key As String, _
               ByVal planNo As String, _
               ByVal chkNo As String, _
               ByVal makeNo As String, _
               ByVal code As String, _
               ByVal lineId As String, _
               ByVal suu As String, _
               ByVal yoteiChkDate As String, _
               ByVal status As String, _
               ByVal insUser As String, _
               ByVal insDate As String) As Boolean

        'SQLコメント
        '--**テーブル：检查计划 : t_check_plan
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("UPDATE t_check_plan")
        sb.AppendLine("SET")
        sb.AppendLine("plan_no=@plan_no")                                              '计划No
        sb.AppendLine(", chk_no=@chk_no")                                              '检查No
        sb.AppendLine(", make_no=@make_no")                                            '作番
        sb.AppendLine(", code=@code")                                                  'コード
        sb.AppendLine(", line_id=@line_id")                                            '生产线
        sb.AppendLine(", suu=@suu")                                                    '数量
        sb.AppendLine(", yotei_chk_date=@yotei_chk_date")   '预订检查日
        sb.AppendLine(", status=@status")                                              '状态
        sb.AppendLine(", xiangxian=@xiangxian")   '登録者
        sb.AppendLine(", mark=@mark")   '登録日

        sb.AppendLine("FROM t_check_plan")
        sb.AppendLine("WHERE 1=1")
        If planNo_key <> "" Then
            sb.AppendLine("AND plan_no=@plan_no_key")   '计划No
        End If
        If chkNo_key <> "" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '检查No
        End If
        If makeNo_key <> "" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If
        If code_key <> "" Then
            sb.AppendLine("AND code=@code_key")   'コード
        End If
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@plan_no_key", SqlDbType.VarChar, 20, planNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
        paramList.Add(SqlHelperNew.MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

        paramList.Add(SqlHelperNew.MakeParam("@plan_no", SqlDbType.VarChar, 20, planNo))
        paramList.Add(SqlHelperNew.MakeParam("@chk_no", SqlDbType.VarChar, 20, chkNo))
        paramList.Add(SqlHelperNew.MakeParam("@make_no", SqlDbType.VarChar, 20, makeNo))
        paramList.Add(SqlHelperNew.MakeParam("@code", SqlDbType.VarChar, 20, code))
        paramList.Add(SqlHelperNew.MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
        paramList.Add(SqlHelperNew.MakeParam("@suu", SqlDbType.VarChar, 10, suu))
        paramList.Add(SqlHelperNew.MakeParam("@yotei_chk_date", SqlDbType.VarChar, 20, IIf(yoteiChkDate = "", DBNull.Value, CDate(yoteiChkDate).ToString("yyyy/MM/dd"))))
        paramList.Add(SqlHelperNew.MakeParam("@status", SqlDbType.VarChar, 1, status))
        paramList.Add(SqlHelperNew.MakeParam("@xiangxian", SqlDbType.NVarChar, 20, insUser))
        paramList.Add(SqlHelperNew.MakeParam("@mark", SqlDbType.NVarChar, 500, IIf(insDate = "", DBNull.Value, insDate)))


        SqlHelperNew.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' 检查计划Infoを登録する
    ''' </summary>
    '''<param name="planNo">计划No</param>
    '''<param name="chkNo">检查No</param>
    '''<param name="makeNo">作番</param>
    '''<param name="code">コード</param>
    '''<param name="lineId">生产线</param>
    '''<param name="suu">数量</param>
    '''<param name="yoteiChkDate">预订检查日</param>
    '''<param name="status">状态</param>
    '''<param name="insUser">登録者</param>
    '''<param name="insDate">登録日</param>
    ''' <returns>检查计划Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function InsTCheckPlan(ByVal planNo As String, _
               ByVal chkNo As String, _
               ByVal makeNo As String, _
               ByVal code As String, _
               ByVal lineId As String, _
               ByVal suu As String, _
               ByVal yoteiChkDate As String, _
               ByVal status As String, _
               ByVal insUser As String, _
               ByVal insDate As String) As Boolean

        'SQLコメント
        '--**テーブル：检查计划 : t_check_plan
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("INSERT INTO  t_check_plan")
        sb.AppendLine("(")
        sb.AppendLine("plan_no")                                                   '计划No
        sb.AppendLine(", chk_no")                                                  '检查No
        sb.AppendLine(", make_no")                                                 '作番
        sb.AppendLine(", code")                                                    'コード
        sb.AppendLine(", line_id")                                                 '生产线
        sb.AppendLine(", suu")                                                     '数量
        sb.AppendLine(", yotei_chk_date")   '预订检查日
        sb.AppendLine(", status")                                                  '状态
        sb.AppendLine(", xiangxian")                                                '登録者
        sb.AppendLine(", mark")                                                '登録日

        sb.AppendLine(")")
        sb.AppendLine("VALUES(")
        sb.AppendLine("@plan_no")                                                      '计划No
        sb.AppendLine(", @chk_no")                                                     '检查No
        sb.AppendLine(", @make_no")                                                    '作番
        sb.AppendLine(", @code")                                                       'コード
        sb.AppendLine(", @line_id")                                                    '生产线
        sb.AppendLine(", @suu")                                                        '数量
        sb.AppendLine(", @yotei_chk_date")                                             '预订检查日
        sb.AppendLine(", @status")                                                     '状态
        sb.AppendLine(", @xiangxian")                                                   '登録者
        sb.AppendLine(", @mark")                                                   '登録日

        sb.AppendLine(")")
        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@plan_no", SqlDbType.VarChar, 20, planNo))
        paramList.Add(SqlHelperNew.MakeParam("@chk_no", SqlDbType.VarChar, 20, chkNo))
        paramList.Add(SqlHelperNew.MakeParam("@make_no", SqlDbType.VarChar, 20, makeNo))
        paramList.Add(SqlHelperNew.MakeParam("@code", SqlDbType.VarChar, 20, code))
        paramList.Add(SqlHelperNew.MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
        paramList.Add(SqlHelperNew.MakeParam("@suu", SqlDbType.VarChar, 10, suu))
        paramList.Add(SqlHelperNew.MakeParam("@yotei_chk_date", SqlDbType.VarChar, 20, IIf(yoteiChkDate = "", DBNull.Value, CDate(yoteiChkDate).ToString("yyyy/MM/dd"))))
        paramList.Add(SqlHelperNew.MakeParam("@status", SqlDbType.VarChar, 1, status))
        paramList.Add(SqlHelperNew.MakeParam("@xiangxian", SqlDbType.NVarChar, 20, insUser))
        paramList.Add(SqlHelperNew.MakeParam("@mark", SqlDbType.NVarChar, 500, IIf(insDate = "", DBNull.Value, insDate)))


        SqlHelperNew.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' 检查计划Infoを削除する
    ''' </summary>
    '''<param name="planNo_key">计划No</param>
    '''<param name="chkNo_key">检查No</param>
    '''<param name="makeNo_key">作番</param>
    '''<param name="code_key">コード</param>
    '''<param name="lineId_key">生产线</param>
    ''' <returns>检查计划Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function DelTCheckPlan(ByVal planNo_key As String, _
               ByVal chkNo_key As String, _
               ByVal makeNo_key As String, _
               ByVal code_key As String, _
               ByVal lineId_key As String) As Boolean

        'SQLコメント
        '--**テーブル：检查计划 : t_check_plan
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("DELETE FROM t_check_plan")
        sb.AppendLine("WHERE 1=1")
        If planNo_key <> "" Then
            sb.AppendLine("AND plan_no=@plan_no_key")   '计划No
        End If
        If chkNo_key <> "" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '检查No
        End If
        If makeNo_key <> "" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If
        If code_key <> "" Then
            sb.AppendLine("AND code=@code_key")   'コード
        End If
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@plan_no_key", SqlDbType.VarChar, 20, planNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))
        paramList.Add(SqlHelperNew.MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
        paramList.Add(SqlHelperNew.MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))


        SqlHelperNew.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' GetIntValue
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetIntValue(ByVal v As Object) As Object

        If v Is DBNull.Value Or v.ToString = "" Then
            Return DBNull.Value

        Else
            Return Convert.ToInt32(v)
        End If

    End Function

End Class
