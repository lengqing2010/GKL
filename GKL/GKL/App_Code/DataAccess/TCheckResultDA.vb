Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.Data
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic

Public Class TCheckResultDA

    ''' <summary>
    ''' 
    ''' ???果情報を検索する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生??</param>
'''<param name="makeNo_key">作番</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

    Public Function SelTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String) As Data.DataTable
        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)
        'SQLコメント
        '--**テーブル：???果 : t_check_result
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("chk_no")                                                    '??No
        sb.AppendLine(", nen")                                                     '年
        sb.AppendLine(", plan_no")                                                 '??No
        sb.AppendLine(", line_id")                                                 '生??
        sb.AppendLine(", make_no")                                                 '作番
        sb.AppendLine(", code")                                                    'コード
        sb.AppendLine(", suu")                                                     '数量
        sb.AppendLine(", temp_id")                                                 '??模板?号
        sb.AppendLine(", chk_result")                                              '???果
        sb.AppendLine(", chk_user")                                                '??者
        sb.AppendLine(", chk_start_date")   '??開始日
        sb.AppendLine(", chk_end_date")                                            '??完了日
        sb.AppendLine(", parent_chk_no")   '父??No
        sb.AppendLine(", status")                                                  '状?
        sb.AppendLine(", ins_user")                                                '登録者
        sb.AppendLine(", ins_date")                                                '登録日

        sb.AppendLine("FROM t_check_result")
        sb.AppendLine("WHERE 1=1")
            If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If
    If nen_key<>"" Then
            sb.AppendLine("AND nen=@nen_key")   '年
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
    paramList.Add(MakeParam("@nen_key", SqlDbType.VarChar, 4, nen_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
    paramList.Add(MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "t_check_result", paramList.ToArray)

    Return dsInfo.Tables("t_check_result")

End Function

    ''' <summary>
    ''' 
    ''' ???果情報を更新する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生??</param>
'''<param name="makeNo_key">作番</param>
'''<param name="chkNo">??No</param>
'''<param name="nen">年</param>
'''<param name="planNo">??No</param>
'''<param name="lineId">生??</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="suu">数量</param>
'''<param name="tempId">??模板?号</param>
'''<param name="chkResult">???果</param>
'''<param name="chkUser">??者</param>
'''<param name="chkStartDate">??開始日</param>
'''<param name="chkEndDate">??完了日</param>
'''<param name="parentChkNo">父??No</param>
'''<param name="status">状?</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String, _
           Byval chkNo AS String, _
           Byval nen AS String, _
           Byval planNo AS String, _
           Byval lineId AS String, _
           Byval makeNo AS String, _
           Byval code AS String, _
           Byval suu AS String, _
           Byval tempId AS String, _
           Byval chkResult AS String, _
           Byval chkUser AS String, _
           Byval chkStartDate AS String, _
           Byval chkEndDate AS String, _
           Byval parentChkNo AS String, _
           Byval status AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key, _
           chkNo, _
           nen, _
           planNo, _
           lineId, _
           makeNo, _
           code, _
           suu, _
           tempId, _
           chkResult, _
           chkUser, _
           chkStartDate, _
           chkEndDate, _
           parentChkNo, _
           status, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???果 : t_check_result
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE t_check_result")
    sb.AppendLine("SET")
    sb.AppendLine("chk_no=@chk_no")                                                '??No
    sb.AppendLine(", nen=@nen")                                                    '年
    sb.AppendLine(", plan_no=@plan_no")                                            '??No
    sb.AppendLine(", line_id=@line_id")                                            '生??
    sb.AppendLine(", make_no=@make_no")                                            '作番
    sb.AppendLine(", code=@code")                                                  'コード
    sb.AppendLine(", suu=@suu")                                                    '数量
    sb.AppendLine(", temp_id=@temp_id")                                            '??模板?号
    sb.AppendLine(", chk_result=@chk_result")   '???果
    sb.AppendLine(", chk_user=@chk_user")   '??者
    sb.AppendLine(", chk_start_date=@chk_start_date")   '??開始日
    sb.AppendLine(", chk_end_date=@chk_end_date")   '??完了日
    sb.AppendLine(", parent_chk_no=@parent_chk_no")   '父??No
    sb.AppendLine(", status=@status")                                              '状?
    sb.AppendLine(", ins_user=@ins_user")   '登録者
    sb.AppendLine(", ins_date=@ins_date")   '登録日

    sb.AppendLine("FROM t_check_result")
    sb.AppendLine("WHERE 1=1")
        If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If
    If nen_key<>"" Then
            sb.AppendLine("AND nen=@nen_key")   '年
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
    paramList.Add(MakeParam("@nen_key", SqlDbType.VarChar, 4, nen_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
    paramList.Add(MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))

    paramList.Add(MakeParam("@chk_no", SqlDbType.VarChar, 20, chkNo))
    paramList.Add(MakeParam("@nen", SqlDbType.VarChar, 4, nen))
    paramList.Add(MakeParam("@plan_no", SqlDbType.VarChar, 20, planNo))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@make_no", SqlDbType.VarChar, 20, makeNo))
    paramList.Add(MakeParam("@code", SqlDbType.VarChar, 20, code))
    paramList.Add(MakeParam("@suu", SqlDbType.VarChar, 10, suu))
    paramList.Add(MakeParam("@temp_id", SqlDbType.VarChar, 10, tempId))
    paramList.Add(MakeParam("@chk_result", SqlDbType.VarChar, 1, chkResult))
    paramList.Add(MakeParam("@chk_user", SqlDbType.VarChar, 20, chkUser))
    paramList.Add(MakeParam("@chk_start_date", SqlDbType.date, 3, IIf(chkStartDate = "" , DBNull.Value, chkStartDate)))
    paramList.Add(MakeParam("@chk_end_date", SqlDbType.date, 3, IIf(chkEndDate = "" , DBNull.Value, chkEndDate)))
    paramList.Add(MakeParam("@parent_chk_no", SqlDbType.VarChar, 20, parentChkNo))
    paramList.Add(MakeParam("@status", SqlDbType.VarChar, 1, status))
    paramList.Add(MakeParam("@ins_user", SqlDbType.VarChar, 20, insUser))
    paramList.Add(MakeParam("@ins_date", SqlDbType.date, 3, IIf(insDate = "" , DBNull.Value, insDate)))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' ???果情報を登録する
    ''' </summary>
    '''<param name="chkNo">??No</param>
'''<param name="nen">年</param>
'''<param name="planNo">??No</param>
'''<param name="lineId">生??</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="suu">数量</param>
'''<param name="tempId">??模板?号</param>
'''<param name="chkResult">???果</param>
'''<param name="chkUser">??者</param>
'''<param name="chkStartDate">??開始日</param>
'''<param name="chkEndDate">??完了日</param>
'''<param name="parentChkNo">父??No</param>
'''<param name="status">状?</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsTCheckResult(Byval chkNo AS String, _
           Byval nen AS String, _
           Byval planNo AS String, _
           Byval lineId AS String, _
           Byval makeNo AS String, _
           Byval code AS String, _
           Byval suu AS String, _
           Byval tempId AS String, _
           Byval chkResult AS String, _
           Byval chkUser AS String, _
           Byval chkStartDate AS String, _
           Byval chkEndDate AS String, _
           Byval parentChkNo AS String, _
           Byval status AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo, _
           nen, _
           planNo, _
           lineId, _
           makeNo, _
           code, _
           suu, _
           tempId, _
           chkResult, _
           chkUser, _
           chkStartDate, _
           chkEndDate, _
           parentChkNo, _
           status, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???果 : t_check_result
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  t_check_result")
    sb.AppendLine("(")
        sb.AppendLine("chk_no")                                                    '??No
        sb.AppendLine(", nen")                                                     '年
        sb.AppendLine(", plan_no")                                                 '??No
        sb.AppendLine(", line_id")                                                 '生??
        sb.AppendLine(", make_no")                                                 '作番
        sb.AppendLine(", code")                                                    'コード
        sb.AppendLine(", suu")                                                     '数量
        sb.AppendLine(", temp_id")                                                 '??模板?号
        sb.AppendLine(", chk_result")                                              '???果
        sb.AppendLine(", chk_user")                                                '??者
        sb.AppendLine(", chk_start_date")   '??開始日
        sb.AppendLine(", chk_end_date")                                            '??完了日
        sb.AppendLine(", parent_chk_no")   '父??No
        sb.AppendLine(", status")                                                  '状?
        sb.AppendLine(", ins_user")                                                '登録者
        sb.AppendLine(", ins_date")                                                '登録日

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@chk_no")                                                       '??No
    sb.AppendLine(", @nen")                                                        '年
    sb.AppendLine(", @plan_no")                                                    '??No
    sb.AppendLine(", @line_id")                                                    '生??
    sb.AppendLine(", @make_no")                                                    '作番
    sb.AppendLine(", @code")                                                       'コード
    sb.AppendLine(", @suu")                                                        '数量
    sb.AppendLine(", @temp_id")                                                    '??模板?号
    sb.AppendLine(", @chk_result")                                                 '???果
    sb.AppendLine(", @chk_user")                                                   '??者
    sb.AppendLine(", @chk_start_date")                                             '??開始日
    sb.AppendLine(", @chk_end_date")                                               '??完了日
    sb.AppendLine(", @parent_chk_no")                                              '父??No
    sb.AppendLine(", @status")                                                     '状?
    sb.AppendLine(", @ins_user")                                                   '登録者
    sb.AppendLine(", @ins_date")                                                   '登録日

    sb.AppendLine(")")
    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_no", SqlDbType.VarChar, 20, chkNo))
    paramList.Add(MakeParam("@nen", SqlDbType.VarChar, 4, nen))
    paramList.Add(MakeParam("@plan_no", SqlDbType.VarChar, 20, planNo))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@make_no", SqlDbType.VarChar, 20, makeNo))
    paramList.Add(MakeParam("@code", SqlDbType.VarChar, 20, code))
    paramList.Add(MakeParam("@suu", SqlDbType.VarChar, 10, suu))
    paramList.Add(MakeParam("@temp_id", SqlDbType.VarChar, 10, tempId))
    paramList.Add(MakeParam("@chk_result", SqlDbType.VarChar, 1, chkResult))
    paramList.Add(MakeParam("@chk_user", SqlDbType.VarChar, 20, chkUser))
    paramList.Add(MakeParam("@chk_start_date", SqlDbType.date, 3, IIf(chkStartDate = "" , DBNull.Value, chkStartDate)))
    paramList.Add(MakeParam("@chk_end_date", SqlDbType.date, 3, IIf(chkEndDate = "" , DBNull.Value, chkEndDate)))
    paramList.Add(MakeParam("@parent_chk_no", SqlDbType.VarChar, 20, parentChkNo))
    paramList.Add(MakeParam("@status", SqlDbType.VarChar, 1, status))
    paramList.Add(MakeParam("@ins_user", SqlDbType.VarChar, 20, insUser))
    paramList.Add(MakeParam("@ins_date", SqlDbType.date, 3, IIf(insDate = "" , DBNull.Value, insDate)))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' ???果情報を削除する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生??</param>
'''<param name="makeNo_key">作番</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)
    'SQLコメント
    '--**テーブル：???果 : t_check_result
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM t_check_result")
    sb.AppendLine("WHERE 1=1")
        If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If
    If nen_key<>"" Then
            sb.AppendLine("AND nen=@nen_key")   '年
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
    paramList.Add(MakeParam("@nen_key", SqlDbType.VarChar, 4, nen_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
    paramList.Add(MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

        ''' <summary>
        ''' GetIntValue
        ''' </summary>
        ''' <param name="v"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetIntValue(ByVal v As Object) As Object
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name )
            If v Is DBNull.Value Or v.ToString = "" Then
                Return DBNull.Value
    
            Else
                Return Convert.ToInt32(v)
            End If
    
        End Function

End Class
