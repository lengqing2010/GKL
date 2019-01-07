﻿Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.Data
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic

Public Class TCheckPlanDA

    ''' <summary>
    ''' 
    ''' ????情報を検索する
    ''' </summary>
    '''<param name="planNo_key">??No</param>
'''<param name="chkNo_key">??No</param>
'''<param name="makeNo_key">作番</param>
'''<param name="code_key">コード</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>????情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

    Public Function SelTCheckPlan(Byval planNo_key AS String, _
           Byval chkNo_key AS String, _
           Byval makeNo_key AS String, _
           Byval code_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key)
        'SQLコメント
        '--**テーブル：???? : t_check_plan
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("plan_no")                                                   '??No
        sb.AppendLine(", chk_no")                                                  '??No
        sb.AppendLine(", make_no")                                                 '作番
        sb.AppendLine(", code")                                                    'コード
        sb.AppendLine(", line_id")                                                 '生??
        sb.AppendLine(", suu")                                                     '数量
        sb.AppendLine(", yotei_chk_date")   '????日
        sb.AppendLine(", status")                                                  '状?
        sb.AppendLine(", ins_user")                                                '登録者
        sb.AppendLine(", ins_date")                                                '登録日

        sb.AppendLine("FROM t_check_plan")
        sb.AppendLine("WHERE 1=1")
            If planNo_key<>"" Then
            sb.AppendLine("AND plan_no=@plan_no_key")   '??No
        End If
    If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If
    If code_key<>"" Then
            sb.AppendLine("AND code=@code_key")   'コード
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@plan_no_key", SqlDbType.VarChar, 20, planNo_key))
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
    paramList.Add(MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))
    paramList.Add(MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "t_check_plan", paramList.ToArray)

    Return dsInfo.Tables("t_check_plan")

End Function

    ''' <summary>
    ''' 
    ''' ????情報を更新する
    ''' </summary>
    '''<param name="planNo_key">??No</param>
'''<param name="chkNo_key">??No</param>
'''<param name="makeNo_key">作番</param>
'''<param name="code_key">コード</param>
'''<param name="lineId_key">生??</param>
'''<param name="planNo">??No</param>
'''<param name="chkNo">??No</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="lineId">生??</param>
'''<param name="suu">数量</param>
'''<param name="yoteiChkDate">????日</param>
'''<param name="status">状?</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>????情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdTCheckPlan(Byval planNo_key AS String, _
           Byval chkNo_key AS String, _
           Byval makeNo_key AS String, _
           Byval code_key AS String, _
           Byval lineId_key AS String, _
           Byval planNo AS String, _
           Byval chkNo AS String, _
           Byval makeNo AS String, _
           Byval code AS String, _
           Byval lineId AS String, _
           Byval suu AS String, _
           Byval yoteiChkDate AS String, _
           Byval status AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key, _
           planNo, _
           chkNo, _
           makeNo, _
           code, _
           lineId, _
           suu, _
           yoteiChkDate, _
           status, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???? : t_check_plan
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE t_check_plan")
    sb.AppendLine("SET")
    sb.AppendLine("plan_no=@plan_no")                                              '??No
    sb.AppendLine(", chk_no=@chk_no")                                              '??No
    sb.AppendLine(", make_no=@make_no")                                            '作番
    sb.AppendLine(", code=@code")                                                  'コード
    sb.AppendLine(", line_id=@line_id")                                            '生??
    sb.AppendLine(", suu=@suu")                                                    '数量
    sb.AppendLine(", yotei_chk_date=@yotei_chk_date")   '????日
    sb.AppendLine(", status=@status")                                              '状?
    sb.AppendLine(", ins_user=@ins_user")   '登録者
    sb.AppendLine(", ins_date=@ins_date")   '登録日

    sb.AppendLine("FROM t_check_plan")
    sb.AppendLine("WHERE 1=1")
        If planNo_key<>"" Then
            sb.AppendLine("AND plan_no=@plan_no_key")   '??No
        End If
    If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If
    If code_key<>"" Then
            sb.AppendLine("AND code=@code_key")   'コード
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@plan_no_key", SqlDbType.VarChar, 20, planNo_key))
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
    paramList.Add(MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))
    paramList.Add(MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    paramList.Add(MakeParam("@plan_no", SqlDbType.VarChar, 20, planNo))
    paramList.Add(MakeParam("@chk_no", SqlDbType.VarChar, 20, chkNo))
    paramList.Add(MakeParam("@make_no", SqlDbType.VarChar, 20, makeNo))
    paramList.Add(MakeParam("@code", SqlDbType.VarChar, 20, code))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@suu", SqlDbType.VarChar, 10, suu))
    paramList.Add(MakeParam("@yotei_chk_date", SqlDbType.VarChar, 20, yoteiChkDate))
    paramList.Add(MakeParam("@status", SqlDbType.VarChar, 1, status))
    paramList.Add(MakeParam("@ins_user", SqlDbType.VarChar, 20, insUser))
    paramList.Add(MakeParam("@ins_date", SqlDbType.VarChar, 20, insDate))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' ????情報を登録する
    ''' </summary>
    '''<param name="planNo">??No</param>
'''<param name="chkNo">??No</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="lineId">生??</param>
'''<param name="suu">数量</param>
'''<param name="yoteiChkDate">????日</param>
'''<param name="status">状?</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>????情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsTCheckPlan(Byval planNo AS String, _
           Byval chkNo AS String, _
           Byval makeNo AS String, _
           Byval code AS String, _
           Byval lineId AS String, _
           Byval suu AS String, _
           Byval yoteiChkDate AS String, _
           Byval status AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           planNo, _
           chkNo, _
           makeNo, _
           code, _
           lineId, _
           suu, _
           yoteiChkDate, _
           status, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???? : t_check_plan
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  t_check_plan")
    sb.AppendLine("(")
        sb.AppendLine("plan_no")                                                   '??No
        sb.AppendLine(", chk_no")                                                  '??No
        sb.AppendLine(", make_no")                                                 '作番
        sb.AppendLine(", code")                                                    'コード
        sb.AppendLine(", line_id")                                                 '生??
        sb.AppendLine(", suu")                                                     '数量
        sb.AppendLine(", yotei_chk_date")   '????日
        sb.AppendLine(", status")                                                  '状?
        sb.AppendLine(", ins_user")                                                '登録者
        sb.AppendLine(", ins_date")                                                '登録日

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@plan_no")                                                      '??No
    sb.AppendLine(", @chk_no")                                                     '??No
    sb.AppendLine(", @make_no")                                                    '作番
    sb.AppendLine(", @code")                                                       'コード
    sb.AppendLine(", @line_id")                                                    '生??
    sb.AppendLine(", @suu")                                                        '数量
    sb.AppendLine(", @yotei_chk_date")                                             '????日
    sb.AppendLine(", @status")                                                     '状?
    sb.AppendLine(", @ins_user")                                                   '登録者
    sb.AppendLine(", @ins_date")                                                   '登録日

    sb.AppendLine(")")
    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@plan_no", SqlDbType.VarChar, 20, planNo))
    paramList.Add(MakeParam("@chk_no", SqlDbType.VarChar, 20, chkNo))
    paramList.Add(MakeParam("@make_no", SqlDbType.VarChar, 20, makeNo))
    paramList.Add(MakeParam("@code", SqlDbType.VarChar, 20, code))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@suu", SqlDbType.VarChar, 10, suu))
    paramList.Add(MakeParam("@yotei_chk_date", SqlDbType.VarChar, 20, yoteiChkDate))
    paramList.Add(MakeParam("@status", SqlDbType.VarChar, 1, status))
    paramList.Add(MakeParam("@ins_user", SqlDbType.VarChar, 20, insUser))
    paramList.Add(MakeParam("@ins_date", SqlDbType.VarChar, 20, insDate))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' ????情報を削除する
    ''' </summary>
    '''<param name="planNo_key">??No</param>
'''<param name="chkNo_key">??No</param>
'''<param name="makeNo_key">作番</param>
'''<param name="code_key">コード</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>????情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelTCheckPlan(Byval planNo_key AS String, _
           Byval chkNo_key AS String, _
           Byval makeNo_key AS String, _
           Byval code_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル：???? : t_check_plan
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM t_check_plan")
    sb.AppendLine("WHERE 1=1")
        If planNo_key<>"" Then
            sb.AppendLine("AND plan_no=@plan_no_key")   '??No
        End If
    If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If
    If makeNo_key<>"" Then
            sb.AppendLine("AND make_no=@make_no_key")   '作番
        End If
    If code_key<>"" Then
            sb.AppendLine("AND code=@code_key")   'コード
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@plan_no_key", SqlDbType.VarChar, 20, planNo_key))
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))
    paramList.Add(MakeParam("@make_no_key", SqlDbType.VarChar, 20, makeNo_key))
    paramList.Add(MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))


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