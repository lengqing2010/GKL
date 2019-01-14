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
    ''' 检查结果Infoを検索する
    ''' </summary>
    '''<param name="chkNo_key">检查No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生产线</param>
'''<param name="makeNo_key">作番</param>
    ''' <returns>检查结果Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String) As Data.DataTable
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)
        'SQLコメント
        '--**テーブル：检查结果 : t_check_result
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("chk_no")                                                    '检查No
        sb.AppendLine(", nen")                                                     '年
        sb.AppendLine(", plan_no")                                                 '计划No
        sb.AppendLine(", line_id")                                                 '生产线
        sb.AppendLine(", make_no")                                                 '作番
        sb.AppendLine(", code")                                                    'コード
        sb.AppendLine(", suu")                                                     '数量
        sb.AppendLine(", temp_id")                                                 '检查模板编号
        sb.AppendLine(", chk_result")                                              '检查结果
        sb.AppendLine(", chk_user")                                                '检查者
        sb.AppendLine(", chk_start_date")   '检查開始日
        sb.AppendLine(", chk_end_date")                                            '检查完了日
        sb.AppendLine(", parent_chk_no")   '父检查No
        sb.AppendLine(", status")                                                  '状态
        sb.AppendLine(", ins_user")                                                '登録者
        sb.AppendLine(", ins_date")                                                '登録日

        sb.AppendLine("FROM t_check_result")
        sb.AppendLine("WHERE 1=1")
            If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '检查No
        End If
    If nen_key<>"" Then
            sb.AppendLine("AND nen=@nen_key")   '年
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If

    '僶儔儊僞奿擺
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
    ''' 检查结果Infoを更新する
    ''' </summary>
    '''<param name="chkNo_key">检查No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生产线</param>
'''<param name="makeNo_key">作番</param>
'''<param name="chkNo">检查No</param>
'''<param name="nen">年</param>
'''<param name="planNo">计划No</param>
'''<param name="lineId">生产线</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="suu">数量</param>
'''<param name="tempId">检查模板编号</param>
'''<param name="chkResult">检查结果</param>
'''<param name="chkUser">检查者</param>
'''<param name="chkStartDate">检查開始日</param>
'''<param name="chkEndDate">检查完了日</param>
'''<param name="parentChkNo">父检查No</param>
'''<param name="status">状态</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>检查结果Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
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
    'EMAB　ＥＲＲ
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
    '--**テーブル：检查结果 : t_check_result
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE t_check_result")
    sb.AppendLine("SET")
    sb.AppendLine("chk_no=@chk_no")                                                '检查No
    sb.AppendLine(", nen=@nen")                                                    '年
    sb.AppendLine(", plan_no=@plan_no")                                            '计划No
    sb.AppendLine(", line_id=@line_id")                                            '生产线
    sb.AppendLine(", make_no=@make_no")                                            '作番
    sb.AppendLine(", code=@code")                                                  'コード
    sb.AppendLine(", suu=@suu")                                                    '数量
    sb.AppendLine(", temp_id=@temp_id")                                            '检查模板编号
    sb.AppendLine(", chk_result=@chk_result")   '检查结果
    sb.AppendLine(", chk_user=@chk_user")   '检查者
    sb.AppendLine(", chk_start_date=@chk_start_date")   '检查開始日
    sb.AppendLine(", chk_end_date=@chk_end_date")   '检查完了日
    sb.AppendLine(", parent_chk_no=@parent_chk_no")   '父检查No
    sb.AppendLine(", status=@status")                                              '状态
    sb.AppendLine(", ins_user=@ins_user")   '登録者
    sb.AppendLine(", ins_date=@ins_date")   '登録日

    sb.AppendLine("FROM t_check_result")
    sb.AppendLine("WHERE 1=1")
        If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '检查No
        End If
    If nen_key<>"" Then
            sb.AppendLine("AND nen=@nen_key")   '年
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If

    '僶儔儊僞奿擺
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
    paramList.Add(MakeParam("@chk_user", SqlDbType.nvarchar, 20, chkUser))
    paramList.Add(MakeParam("@chk_start_date", SqlDbType.date, 3, IIf(chkStartDate = "" , DBNull.Value, chkStartDate)))
    paramList.Add(MakeParam("@chk_end_date", SqlDbType.date, 3, IIf(chkEndDate = "" , DBNull.Value, chkEndDate)))
    paramList.Add(MakeParam("@parent_chk_no", SqlDbType.VarChar, 20, parentChkNo))
    paramList.Add(MakeParam("@status", SqlDbType.VarChar, 1, status))
    paramList.Add(MakeParam("@ins_user", SqlDbType.nvarchar, 20, insUser))
    paramList.Add(MakeParam("@ins_date", SqlDbType.date, 3, IIf(insDate = "" , DBNull.Value, insDate)))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 检查结果Infoを登録する
    ''' </summary>
    '''<param name="chkNo">检查No</param>
'''<param name="nen">年</param>
'''<param name="planNo">计划No</param>
'''<param name="lineId">生产线</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="suu">数量</param>
'''<param name="tempId">检查模板编号</param>
'''<param name="chkResult">检查结果</param>
'''<param name="chkUser">检查者</param>
'''<param name="chkStartDate">检查開始日</param>
'''<param name="chkEndDate">检查完了日</param>
'''<param name="parentChkNo">父检查No</param>
'''<param name="status">状态</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>检查结果Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function InsTCheckResult(ByVal chkNo As String, _
               ByVal nen As String, _
               ByVal chk_times As String, _
               ByVal planNo As String, _
               ByVal lineId As String, _
               ByVal makeNo As String, _
               ByVal code As String, _
               ByVal suu As String, _
               ByVal tempId As String, _
               ByVal chkResult As String, _
               ByVal chkUser As String, _
               ByVal chkYoteiDate As String, _
               ByVal chkStartDate As String, _
               ByVal chkEndDate As String, _
               ByVal parentChkNo As String, _
               ByVal status As String, _
               ByVal insUser As String, _
               ByVal insDate As String) As Boolean
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name, _
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
        '--**テーブル：检查结果 : t_check_result
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("INSERT INTO  t_check_result")
        sb.AppendLine("(")
        sb.AppendLine("chk_no")                                                    '检查No
        sb.AppendLine(", nen")                                                     '年
        sb.AppendLine(", chk_times")                                                     'chk_times
        sb.AppendLine(", plan_no")                                                 '计划No
        sb.AppendLine(", line_id")                                                 '生产线
        sb.AppendLine(", make_no")                                                 '作番
        sb.AppendLine(", code")                                                    'コード
        sb.AppendLine(", suu")                                                     '数量
        sb.AppendLine(", temp_id")                                                 '检查模板编号
        sb.AppendLine(", chk_result")                                              '检查结果
        sb.AppendLine(", chk_user")                                                '检查者
        sb.AppendLine(", yotei_chk_date")
        sb.AppendLine(", chk_start_date")   '检查開始日
        sb.AppendLine(", chk_end_date")                                            '检查完了日
        sb.AppendLine(", parent_chk_no")   '父检查No
        sb.AppendLine(", status")                                                  '状态
        sb.AppendLine(", ins_user")                                                '登録者
        sb.AppendLine(", ins_date")                                                '登録日

        sb.AppendLine(")")
        sb.AppendLine("VALUES(")
        sb.AppendLine("@chk_no")                                                       '检查No
        sb.AppendLine(", @nen")                                                        '年
        sb.AppendLine(", " & chk_times & "")                                                        'chk_times
        sb.AppendLine(", @plan_no")                                                    '计划No
        sb.AppendLine(", @line_id")                                                    '生产线
        sb.AppendLine(", @make_no")                                                    '作番
        sb.AppendLine(", @code")                                                       'コード
        sb.AppendLine(", @suu")                                                        '数量
        sb.AppendLine(", @temp_id")                                                    '检查模板编号
        sb.AppendLine(", @chk_result")                                                 '检查结果
        sb.AppendLine(", @chk_user")                                                   '检查者
        sb.AppendLine(", '" & chkYoteiDate & "'")
        sb.AppendLine(", @chk_start_date")                                             '检查開始日
        sb.AppendLine(", @chk_end_date")                                               '检查完了日
        sb.AppendLine(", @parent_chk_no")                                              '父检查No
        sb.AppendLine(", @status")                                                     '状态
        sb.AppendLine(", @ins_user")                                                   '登録者
        sb.AppendLine(", @ins_date")                                                   '登録日

        sb.AppendLine(")")


        'sb.AppendLine("Declare @chk_no varchar(20)")
        'sb.AppendLine("Declare @temp_id varchar(10)")
        'sb.AppendLine("Declare @ins_user varchar(20)")
        'sb.AppendLine("Declare @line_id varchar(20)")
        'sb.AppendLine("set @chk_no = ''")
        'sb.AppendLine("set @temp_id = '312M0001'")
        'sb.AppendLine("set @ins_user = '3003017'")
        'sb.AppendLine("set @line_id = '" & lineId & "'")
        sb.AppendLine("INSERT INTO t_check_ms")
        sb.AppendLine("Select ")
        sb.AppendLine("	@chk_no chk_no")
        sb.AppendLine("	,chk_method_id")
        sb.AppendLine("	,'0' chk_flg")
        sb.AppendLine("	,'' in_1")
        sb.AppendLine("	,'' in_2")
        sb.AppendLine("	,'' chk_result")
        sb.AppendLine("	,'' mark")
        sb.AppendLine("	,kj_0")
        sb.AppendLine("	,kj_1")
        sb.AppendLine("	,kj_2")
        sb.AppendLine("	,kj_explain")
        sb.AppendLine("	,@ins_user ins_user")
        sb.AppendLine("	,GETDATE() ins_date")
        sb.AppendLine("FROM m_temp")
        sb.AppendLine("WHERE temp_id = @temp_id")
        sb.AppendLine("AND line_id=@line_id")


        '僶儔儊僞奿擺
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
        paramList.Add(MakeParam("@chk_user", SqlDbType.NVarChar, 20, chkUser))
        paramList.Add(MakeParam("@chk_start_date", SqlDbType.Date, 3, IIf(chkStartDate = "", DBNull.Value, chkStartDate)))
        paramList.Add(MakeParam("@chk_end_date", SqlDbType.Date, 3, IIf(chkEndDate = "", DBNull.Value, chkEndDate)))
        paramList.Add(MakeParam("@parent_chk_no", SqlDbType.VarChar, 20, parentChkNo))
        paramList.Add(MakeParam("@status", SqlDbType.VarChar, 1, status))
        paramList.Add(MakeParam("@ins_user", SqlDbType.NVarChar, 20, insUser))
        paramList.Add(MakeParam("@ins_date", SqlDbType.Date, 3, IIf(insDate = "", DBNull.Value, insDate)))


        SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' 检查结果Infoを削除する
    ''' </summary>
    '''<param name="chkNo_key">检查No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生产线</param>
'''<param name="makeNo_key">作番</param>
    ''' <returns>检查结果Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)
    'SQLコメント
    '--**テーブル：检查结果 : t_check_result
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM t_check_result")
    sb.AppendLine("WHERE 1=1")
        If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '检查No
        End If
    If nen_key<>"" Then
            sb.AppendLine("AND nen=@nen_key")   '年
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If

    '僶儔儊僞奿擺
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
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name )
            If v Is DBNull.Value Or v.ToString = "" Then
                Return DBNull.Value
    
            Else
                Return Convert.ToInt32(v)
            End If
    
        End Function




    Public Function SelTCheckResult(ByVal lineId_key As String, ByVal startDate As String, ByVal endDate As String, ByVal make_no As String, ByVal code As String) As Data.DataTable

        'SQLコメント
        '--**テーブル：检查结果 : t_check_result
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT * FROM (")
        sb.AppendLine("SELECT ")
        sb.AppendLine("	t_check_plan.[chk_no]+'_1' as chk_no")
        sb.AppendLine("	,substring( t_check_plan.[yotei_chk_date],1,4) as nen")
        sb.AppendLine("	,ISNULL(t_check_result.[chk_times],0) [chk_times]")
        sb.AppendLine("	,t_check_plan.[plan_no]")
        sb.AppendLine("      ,t_check_plan.[line_id] as [line_id]")
        sb.AppendLine("      ,t_check_plan.[make_no]")
        sb.AppendLine("      ,t_check_plan.[code] as [code]")
        sb.AppendLine("      ,t_check_plan.[suu]")
        sb.AppendLine("      ,t_cd_temp_relation.temp_id ")
        sb.AppendLine("      ,ISNULL(t_check_result.chk_result,'') chk_result")
        sb.AppendLine("      ,ISNULL(t_check_result.chk_user,'') chk_user")
        sb.AppendLine("      ,ISNULL(t_check_result.chk_start_date,NULL) chk_start_date")
        sb.AppendLine("      ,ISNULL(t_check_result.chk_end_date,NULL) chk_end_date")
        sb.AppendLine("      ,ISNULL(t_check_result.parent_chk_no,'') parent_chk_no")
        'sb.AppendLine("      ,ISNULL(t_check_result.[status],'') [status]")
        sb.AppendLine("      ,CASE WHEN ISNULL(t_check_result.[status],'0') = '0' THEN N'待检查'")
        sb.AppendLine("		WHEN ISNULL(t_check_result.[status],'1') = '1' THEN N'临时保存'")
        sb.AppendLine("		WHEN ISNULL(t_check_result.[status],'1') = '2' THEN N'完了'   ")
        sb.AppendLine("		WHEN ISNULL(t_check_result.[status],'1') = '9' THEN N'删除'")
        sb.AppendLine("	   ELSE")
        sb.AppendLine("		''")
        sb.AppendLine("	   END  [status]")
        sb.AppendLine("      ,ISNULL(t_check_result.ins_user,'') ins_user")
        sb.AppendLine("      ,ISNULL(t_check_result.ins_date,NULL) AS ins_date")

        sb.AppendLine("      ,ISNULL(t_check_plan.yotei_chk_date,NULL) AS yotei_chk_date")

        sb.AppendLine("  FROM t_check_plan")
        sb.AppendLine("  LEFT JOIN t_cd_temp_relation ")
        sb.AppendLine("	  ON t_check_plan.line_id = t_cd_temp_relation.line_id ")
        sb.AppendLine("	  AND t_check_plan.code = t_cd_temp_relation.code ")
        sb.AppendLine("  LEFT JOIN t_check_result")
        sb.AppendLine("		ON t_check_plan.plan_no = t_check_result.plan_no ")
        sb.AppendLine("		AND t_check_plan.[chk_no]+'_1' = t_check_result.[chk_no] ")

        sb.AppendLine("  WHERE t_check_result.chk_no is null")
        sb.AppendLine("  AND t_check_plan.line_id= '" & lineId_key & "'")

        If startDate <> "" Then
            sb.AppendLine("  AND t_check_plan.yotei_chk_date >= '" & startDate & "'")
            sb.AppendLine("  AND t_check_plan.yotei_chk_date <= '" & endDate & "'")
        End If


        If make_no <> "" Then
            sb.AppendLine("	  AND t_check_plan.make_no = '" & make_no & "' ")
        End If
        If code <> "" Then
            sb.AppendLine("	  AND t_check_plan.code = '" & code & "' ")
        End If


        sb.AppendLine("UNION ALL")
        sb.AppendLine("  SELECT ")
        sb.AppendLine("		t_check_result.[chk_no]")
        sb.AppendLine("      ,t_check_result.[nen]")
        sb.AppendLine("      ,t_check_result.[chk_times]")
        sb.AppendLine("      ,t_check_result.[plan_no]")
        sb.AppendLine("      ,t_check_result.[line_id]")
        sb.AppendLine("      ,t_check_result.[make_no]")
        sb.AppendLine("      ,t_check_result.[code]")
        sb.AppendLine("      ,t_check_result.[suu]")
        sb.AppendLine("      ,t_check_result.[temp_id]")
        sb.AppendLine("      ,t_check_result.[chk_result]")
        sb.AppendLine("      ,t_check_result.[chk_user]")
        sb.AppendLine("      ,t_check_result.[chk_start_date]")
        sb.AppendLine("      ,t_check_result.[chk_end_date]")
        sb.AppendLine("      ,t_check_result.[parent_chk_no]")
        'sb.AppendLine("      ,t_check_result.[status]")
        sb.AppendLine("      ,CASE WHEN ISNULL(t_check_result.[status],'0') = '0' THEN N'待检查'")
        sb.AppendLine("		WHEN ISNULL(t_check_result.[status],'1') = '1' THEN N'临时保存'")
        sb.AppendLine("		WHEN ISNULL(t_check_result.[status],'1') = '2' THEN N'完了'   ")
        sb.AppendLine("		WHEN ISNULL(t_check_result.[status],'1') = '9' THEN N'删除'")
        sb.AppendLine("	   ELSE")
        sb.AppendLine("		''")
        sb.AppendLine("	   END  [status]")

        sb.AppendLine("      ,t_check_result.[ins_user]")
        sb.AppendLine("      ,t_check_result.[ins_date]")
        sb.AppendLine("      ,t_check_result.yotei_chk_date")
        sb.AppendLine("   FROM t_check_result")
        sb.AppendLine("  LEFT JOIN t_check_plan")
        sb.AppendLine("		ON t_check_plan.plan_no = t_check_result.plan_no ")
        sb.AppendLine("		AND t_check_plan.[chk_no] +'_1'= t_check_result.[chk_no] ")
        sb.AppendLine("  WHERE 1=1")

        sb.AppendLine("  AND t_check_result.line_id= '" & lineId_key & "'")
        If startDate <> "" Then
            sb.AppendLine("  AND t_check_result.yotei_chk_date >= '" & startDate & "'")
            sb.AppendLine("  AND t_check_result.yotei_chk_date <= '" & endDate & "'")
        End If

        If make_no <> "" Then
            sb.AppendLine("	  AND t_check_result.make_no = '" & make_no & "' ")
        End If
        If code <> "" Then
            sb.AppendLine("	  AND t_check_result.code = '" & code & "' ")
        End If

        sb.AppendLine(") a")
        sb.AppendLine("  ORDER BY yotei_chk_date DESC, chk_no,chk_times")

        Dim dsInfo As New Data.DataSet
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "t_check_result")

        Return dsInfo.Tables("t_check_result")

    End Function

End Class
