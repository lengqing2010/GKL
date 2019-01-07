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

Public Class TCheckMsDA

    ''' <summary>
    ''' 
    ''' ???果情報を検索する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

    Public Function SelTCheckMs(Byval chkNo_key AS String) As Data.DataTable
        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key)
        'SQLコメント
        '--**テーブル：???果 : t_check_ms
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("chk_no")                                                    '??No
        sb.AppendLine(", chk_method_id")   '???目ID
        sb.AppendLine(", chk_flg")                                                 '??flg
        sb.AppendLine(", in_1")                                                    '入力値1
        sb.AppendLine(", in_2")                                                    '入力値2
        sb.AppendLine(", chk_result")                                              '???果
        sb.AppendLine(", mark")                                                    '?考
        sb.AppendLine(", kj_0")                                                    '基准
        sb.AppendLine(", kj_1")                                                    '工差1
        sb.AppendLine(", kj_2")                                                    '工差2
        sb.AppendLine(", kj_explain")                                              '基准説明
        sb.AppendLine(", ins_user")                                                '登録者
        sb.AppendLine(", ins_date")                                                '登録日

        sb.AppendLine("FROM t_check_ms")
        sb.AppendLine("WHERE 1=1")
            If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "t_check_ms", paramList.ToArray)

    Return dsInfo.Tables("t_check_ms")

End Function

    ''' <summary>
    ''' 
    ''' ???果情報を更新する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
'''<param name="chkNo">??No</param>
'''<param name="chkMethodId">???目ID</param>
'''<param name="chkFlg">??flg</param>
'''<param name="in1">入力値1</param>
'''<param name="in2">入力値2</param>
'''<param name="chkResult">???果</param>
'''<param name="mark">?考</param>
'''<param name="kj0">基准</param>
'''<param name="kj1">工差1</param>
'''<param name="kj2">工差2</param>
'''<param name="kjExplain">基准説明</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdTCheckMs(Byval chkNo_key AS String, _
           Byval chkNo AS String, _
           Byval chkMethodId AS String, _
           Byval chkFlg AS String, _
           Byval in1 AS String, _
           Byval in2 AS String, _
           Byval chkResult AS String, _
           Byval mark AS String, _
           Byval kj0 AS String, _
           Byval kj1 AS String, _
           Byval kj2 AS String, _
           Byval kjExplain AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           chkNo, _
           chkMethodId, _
           chkFlg, _
           in1, _
           in2, _
           chkResult, _
           mark, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???果 : t_check_ms
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE t_check_ms")
    sb.AppendLine("SET")
    sb.AppendLine("chk_no=@chk_no")                                                '??No
    sb.AppendLine(", chk_method_id=@chk_method_id")   '???目ID
    sb.AppendLine(", chk_flg=@chk_flg")                                            '??flg
    sb.AppendLine(", in_1=@in_1")                                                  '入力値1
    sb.AppendLine(", in_2=@in_2")                                                  '入力値2
    sb.AppendLine(", chk_result=@chk_result")   '???果
    sb.AppendLine(", mark=@mark")                                                  '?考
    sb.AppendLine(", kj_0=@kj_0")                                                  '基准
    sb.AppendLine(", kj_1=@kj_1")                                                  '工差1
    sb.AppendLine(", kj_2=@kj_2")                                                  '工差2
    sb.AppendLine(", kj_explain=@kj_explain")   '基准説明
    sb.AppendLine(", ins_user=@ins_user")   '登録者
    sb.AppendLine(", ins_date=@ins_date")   '登録日

    sb.AppendLine("FROM t_check_ms")
    sb.AppendLine("WHERE 1=1")
        If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))

    paramList.Add(MakeParam("@chk_no", SqlDbType.VarChar, 20, chkNo))
    paramList.Add(MakeParam("@chk_method_id", SqlDbType.VarChar, 10, chkMethodId))
    paramList.Add(MakeParam("@chk_flg", SqlDbType.VarChar, 1, chkFlg))
    paramList.Add(MakeParam("@in_1", SqlDbType.VarChar, 20, in1))
    paramList.Add(MakeParam("@in_2", SqlDbType.VarChar, 20, in2))
    paramList.Add(MakeParam("@chk_result", SqlDbType.VarChar, 20, chkResult))
    paramList.Add(MakeParam("@mark", SqlDbType.VarChar, 200, mark))
    paramList.Add(MakeParam("@kj_0", SqlDbType.VarChar, 100, kj0))
    paramList.Add(MakeParam("@kj_1", SqlDbType.VarChar, 20, kj1))
    paramList.Add(MakeParam("@kj_2", SqlDbType.VarChar, 20, kj2))
    paramList.Add(MakeParam("@kj_explain", SqlDbType.date, 3, IIf(kjExplain = "" , DBNull.Value, kjExplain)))
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
'''<param name="chkMethodId">???目ID</param>
'''<param name="chkFlg">??flg</param>
'''<param name="in1">入力値1</param>
'''<param name="in2">入力値2</param>
'''<param name="chkResult">???果</param>
'''<param name="mark">?考</param>
'''<param name="kj0">基准</param>
'''<param name="kj1">工差1</param>
'''<param name="kj2">工差2</param>
'''<param name="kjExplain">基准説明</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsTCheckMs(Byval chkNo AS String, _
           Byval chkMethodId AS String, _
           Byval chkFlg AS String, _
           Byval in1 AS String, _
           Byval in2 AS String, _
           Byval chkResult AS String, _
           Byval mark AS String, _
           Byval kj0 AS String, _
           Byval kj1 AS String, _
           Byval kj2 AS String, _
           Byval kjExplain AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo, _
           chkMethodId, _
           chkFlg, _
           in1, _
           in2, _
           chkResult, _
           mark, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???果 : t_check_ms
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  t_check_ms")
    sb.AppendLine("(")
        sb.AppendLine("chk_no")                                                    '??No
        sb.AppendLine(", chk_method_id")   '???目ID
        sb.AppendLine(", chk_flg")                                                 '??flg
        sb.AppendLine(", in_1")                                                    '入力値1
        sb.AppendLine(", in_2")                                                    '入力値2
        sb.AppendLine(", chk_result")                                              '???果
        sb.AppendLine(", mark")                                                    '?考
        sb.AppendLine(", kj_0")                                                    '基准
        sb.AppendLine(", kj_1")                                                    '工差1
        sb.AppendLine(", kj_2")                                                    '工差2
        sb.AppendLine(", kj_explain")                                              '基准説明
        sb.AppendLine(", ins_user")                                                '登録者
        sb.AppendLine(", ins_date")                                                '登録日

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@chk_no")                                                       '??No
    sb.AppendLine(", @chk_method_id")                                              '???目ID
    sb.AppendLine(", @chk_flg")                                                    '??flg
    sb.AppendLine(", @in_1")                                                       '入力値1
    sb.AppendLine(", @in_2")                                                       '入力値2
    sb.AppendLine(", @chk_result")                                                 '???果
    sb.AppendLine(", @mark")                                                       '?考
    sb.AppendLine(", @kj_0")                                                       '基准
    sb.AppendLine(", @kj_1")                                                       '工差1
    sb.AppendLine(", @kj_2")                                                       '工差2
    sb.AppendLine(", @kj_explain")                                                 '基准説明
    sb.AppendLine(", @ins_user")                                                   '登録者
    sb.AppendLine(", @ins_date")                                                   '登録日

    sb.AppendLine(")")
    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_no", SqlDbType.VarChar, 20, chkNo))
    paramList.Add(MakeParam("@chk_method_id", SqlDbType.VarChar, 10, chkMethodId))
    paramList.Add(MakeParam("@chk_flg", SqlDbType.VarChar, 1, chkFlg))
    paramList.Add(MakeParam("@in_1", SqlDbType.VarChar, 20, in1))
    paramList.Add(MakeParam("@in_2", SqlDbType.VarChar, 20, in2))
    paramList.Add(MakeParam("@chk_result", SqlDbType.VarChar, 20, chkResult))
    paramList.Add(MakeParam("@mark", SqlDbType.VarChar, 200, mark))
    paramList.Add(MakeParam("@kj_0", SqlDbType.VarChar, 100, kj0))
    paramList.Add(MakeParam("@kj_1", SqlDbType.VarChar, 20, kj1))
    paramList.Add(MakeParam("@kj_2", SqlDbType.VarChar, 20, kj2))
    paramList.Add(MakeParam("@kj_explain", SqlDbType.date, 3, IIf(kjExplain = "" , DBNull.Value, kjExplain)))
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
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelTCheckMs(Byval chkNo_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key)
    'SQLコメント
    '--**テーブル：???果 : t_check_ms
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM t_check_ms")
    sb.AppendLine("WHERE 1=1")
        If chkNo_key<>"" Then
            sb.AppendLine("AND chk_no=@chk_no_key")   '??No
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_no_key", SqlDbType.VarChar, 20, chkNo_key))


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
