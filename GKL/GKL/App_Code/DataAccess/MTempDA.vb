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

Public Class MTempDA

    ''' <summary>
    ''' 
    ''' 模板MS情報を検索する
    ''' </summary>
    '''<param name="lineId_key">生??</param>
'''<param name="tempId_key">??模板?号</param>
'''<param name="chkMethodId_key">???目ID</param>
    ''' <returns>模板MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

    Public Function SelMTemp(Byval lineId_key AS String, _
           Byval tempId_key AS String, _
           Byval chkMethodId_key AS String) As Data.DataTable
        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key, _
           chkMethodId_key)
        'SQLコメント
        '--**テーブル：模板MS : m_temp
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("line_id")                                                   '生??
        sb.AppendLine(", temp_id")                                                 '??模板?号
        sb.AppendLine(", chk_method_id")   '???目ID
        sb.AppendLine(", project_id")                                              '工程ID
        sb.AppendLine(", project_name")                                            '工程名
        sb.AppendLine(", pic_id")                                                  '?片ID
        sb.AppendLine(", pic_name")                                                '?片名称
        sb.AppendLine(", chk_km_name")                                             '???目
        sb.AppendLine(", pic_sign")                                                '?片??
        sb.AppendLine(", chk_id")                                                  '??方法ID
        sb.AppendLine(", chk_name")                                                '??方法名
        sb.AppendLine(", tool_id")                                                 '治具ID
        sb.AppendLine(", kj_0")                                                    '基准
        sb.AppendLine(", kj_1")                                                    '工差1
        sb.AppendLine(", kj_2")                                                    '工差2
        sb.AppendLine(", kj_explain")                                              '基准説明

        sb.AppendLine("FROM m_temp")
        sb.AppendLine("WHERE 1=1")
            If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If
    If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '??模板?号
        End If
    If chkMethodId_key<>"" Then
            sb.AppendLine("AND chk_method_id=@chk_method_id_key")   '???目ID
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
    paramList.Add(MakeParam("@temp_id_key", SqlDbType.nvarchar, 10, tempId_key))
    paramList.Add(MakeParam("@chk_method_id_key", SqlDbType.VarChar, 10, chkMethodId_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_temp", paramList.ToArray)

    Return dsInfo.Tables("m_temp")

End Function

    ''' <summary>
    ''' 
    ''' 模板MS情報を更新する
    ''' </summary>
    '''<param name="lineId_key">生??</param>
'''<param name="tempId_key">??模板?号</param>
'''<param name="chkMethodId_key">???目ID</param>
'''<param name="lineId">生??</param>
'''<param name="tempId">??模板?号</param>
'''<param name="chkMethodId">???目ID</param>
'''<param name="projectId">工程ID</param>
'''<param name="projectName">工程名</param>
'''<param name="picId">?片ID</param>
'''<param name="picName">?片名称</param>
'''<param name="chkKmName">???目</param>
'''<param name="picSign">?片??</param>
'''<param name="chkId">??方法ID</param>
'''<param name="chkName">??方法名</param>
'''<param name="toolId">治具ID</param>
'''<param name="kj0">基准</param>
'''<param name="kj1">工差1</param>
'''<param name="kj2">工差2</param>
'''<param name="kjExplain">基准説明</param>
    ''' <returns>模板MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdMTemp(Byval lineId_key AS String, _
           Byval tempId_key AS String, _
           Byval chkMethodId_key AS String, _
           Byval lineId AS String, _
           Byval tempId AS String, _
           Byval chkMethodId AS String, _
           Byval projectId AS String, _
           Byval projectName AS String, _
           Byval picId AS String, _
           Byval picName AS String, _
           Byval chkKmName AS String, _
           Byval picSign AS String, _
           Byval chkId AS String, _
           Byval chkName AS String, _
           Byval toolId AS String, _
           Byval kj0 AS String, _
           Byval kj1 AS String, _
           Byval kj2 AS String, _
           Byval kjExplain AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key, _
           chkMethodId_key, _
           lineId, _
           tempId, _
           chkMethodId, _
           projectId, _
           projectName, _
           picId, _
           picName, _
           chkKmName, _
           picSign, _
           chkId, _
           chkName, _
           toolId, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain)
    'SQLコメント
    '--**テーブル：模板MS : m_temp
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_temp")
    sb.AppendLine("SET")
    sb.AppendLine("line_id=@line_id")                                              '生??
    sb.AppendLine(", temp_id=@temp_id")                                            '??模板?号
    sb.AppendLine(", chk_method_id=@chk_method_id")   '???目ID
    sb.AppendLine(", project_id=@project_id")   '工程ID
    sb.AppendLine(", project_name=@project_name")   '工程名
    sb.AppendLine(", pic_id=@pic_id")                                              '?片ID
    sb.AppendLine(", pic_name=@pic_name")   '?片名称
    sb.AppendLine(", chk_km_name=@chk_km_name")   '???目
    sb.AppendLine(", pic_sign=@pic_sign")   '?片??
    sb.AppendLine(", chk_id=@chk_id")                                              '??方法ID
    sb.AppendLine(", chk_name=@chk_name")   '??方法名
    sb.AppendLine(", tool_id=@tool_id")                                            '治具ID
    sb.AppendLine(", kj_0=@kj_0")                                                  '基准
    sb.AppendLine(", kj_1=@kj_1")                                                  '工差1
    sb.AppendLine(", kj_2=@kj_2")                                                  '工差2
    sb.AppendLine(", kj_explain=@kj_explain")   '基准説明

    sb.AppendLine("FROM m_temp")
    sb.AppendLine("WHERE 1=1")
        If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If
    If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '??模板?号
        End If
    If chkMethodId_key<>"" Then
            sb.AppendLine("AND chk_method_id=@chk_method_id_key")   '???目ID
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
    paramList.Add(MakeParam("@temp_id_key", SqlDbType.nvarchar, 10, tempId_key))
    paramList.Add(MakeParam("@chk_method_id_key", SqlDbType.VarChar, 10, chkMethodId_key))

    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@temp_id", SqlDbType.nvarchar, 10, tempId))
    paramList.Add(MakeParam("@chk_method_id", SqlDbType.VarChar, 10, chkMethodId))
    paramList.Add(MakeParam("@project_id", SqlDbType.VarChar, 10, projectId))
    paramList.Add(MakeParam("@project_name", SqlDbType.VarChar, 40, projectName))
    paramList.Add(MakeParam("@pic_id", SqlDbType.VarChar, 10, picId))
    paramList.Add(MakeParam("@pic_name", SqlDbType.VarChar, 200, picName))
    paramList.Add(MakeParam("@chk_km_name", SqlDbType.VarChar, 200, chkKmName))
    paramList.Add(MakeParam("@pic_sign", SqlDbType.VarChar, 10, picSign))
    paramList.Add(MakeParam("@chk_id", SqlDbType.VarChar, 10, chkId))
    paramList.Add(MakeParam("@chk_name", SqlDbType.VarChar, 20, chkName))
    paramList.Add(MakeParam("@tool_id", SqlDbType.VarChar, 40, toolId))
    paramList.Add(MakeParam("@kj_0", SqlDbType.VarChar, 100, kj0))
    paramList.Add(MakeParam("@kj_1", SqlDbType.VarChar, 20, kj1))
    paramList.Add(MakeParam("@kj_2", SqlDbType.VarChar, 20, kj2))
    paramList.Add(MakeParam("@kj_explain", SqlDbType.nvarchar, 200, kjExplain))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 模板MS情報を登録する
    ''' </summary>
    '''<param name="lineId">生??</param>
'''<param name="tempId">??模板?号</param>
'''<param name="chkMethodId">???目ID</param>
'''<param name="projectId">工程ID</param>
'''<param name="projectName">工程名</param>
'''<param name="picId">?片ID</param>
'''<param name="picName">?片名称</param>
'''<param name="chkKmName">???目</param>
'''<param name="picSign">?片??</param>
'''<param name="chkId">??方法ID</param>
'''<param name="chkName">??方法名</param>
'''<param name="toolId">治具ID</param>
'''<param name="kj0">基准</param>
'''<param name="kj1">工差1</param>
'''<param name="kj2">工差2</param>
'''<param name="kjExplain">基准説明</param>
    ''' <returns>模板MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsMTemp(Byval lineId AS String, _
           Byval tempId AS String, _
           Byval chkMethodId AS String, _
           Byval projectId AS String, _
           Byval projectName AS String, _
           Byval picId AS String, _
           Byval picName AS String, _
           Byval chkKmName AS String, _
           Byval picSign AS String, _
           Byval chkId AS String, _
           Byval chkName AS String, _
           Byval toolId AS String, _
           Byval kj0 AS String, _
           Byval kj1 AS String, _
           Byval kj2 AS String, _
           Byval kjExplain AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId, _
           tempId, _
           chkMethodId, _
           projectId, _
           projectName, _
           picId, _
           picName, _
           chkKmName, _
           picSign, _
           chkId, _
           chkName, _
           toolId, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain)
    'SQLコメント
    '--**テーブル：模板MS : m_temp
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_temp")
    sb.AppendLine("(")
        sb.AppendLine("line_id")                                                   '生??
        sb.AppendLine(", temp_id")                                                 '??模板?号
        sb.AppendLine(", chk_method_id")   '???目ID
        sb.AppendLine(", project_id")                                              '工程ID
        sb.AppendLine(", project_name")                                            '工程名
        sb.AppendLine(", pic_id")                                                  '?片ID
        sb.AppendLine(", pic_name")                                                '?片名称
        sb.AppendLine(", chk_km_name")                                             '???目
        sb.AppendLine(", pic_sign")                                                '?片??
        sb.AppendLine(", chk_id")                                                  '??方法ID
        sb.AppendLine(", chk_name")                                                '??方法名
        sb.AppendLine(", tool_id")                                                 '治具ID
        sb.AppendLine(", kj_0")                                                    '基准
        sb.AppendLine(", kj_1")                                                    '工差1
        sb.AppendLine(", kj_2")                                                    '工差2
        sb.AppendLine(", kj_explain")                                              '基准説明

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@line_id")                                                      '生??
    sb.AppendLine(", @temp_id")                                                    '??模板?号
    sb.AppendLine(", @chk_method_id")                                              '???目ID
    sb.AppendLine(", @project_id")                                                 '工程ID
    sb.AppendLine(", @project_name")                                               '工程名
    sb.AppendLine(", @pic_id")                                                     '?片ID
    sb.AppendLine(", @pic_name")                                                   '?片名称
    sb.AppendLine(", @chk_km_name")                                                '???目
    sb.AppendLine(", @pic_sign")                                                   '?片??
    sb.AppendLine(", @chk_id")                                                     '??方法ID
    sb.AppendLine(", @chk_name")                                                   '??方法名
    sb.AppendLine(", @tool_id")                                                    '治具ID
    sb.AppendLine(", @kj_0")                                                       '基准
    sb.AppendLine(", @kj_1")                                                       '工差1
    sb.AppendLine(", @kj_2")                                                       '工差2
    sb.AppendLine(", @kj_explain")                                                 '基准説明

    sb.AppendLine(")")
    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@temp_id", SqlDbType.nvarchar, 10, tempId))
    paramList.Add(MakeParam("@chk_method_id", SqlDbType.VarChar, 10, chkMethodId))
    paramList.Add(MakeParam("@project_id", SqlDbType.VarChar, 10, projectId))
    paramList.Add(MakeParam("@project_name", SqlDbType.VarChar, 40, projectName))
    paramList.Add(MakeParam("@pic_id", SqlDbType.VarChar, 10, picId))
    paramList.Add(MakeParam("@pic_name", SqlDbType.VarChar, 200, picName))
    paramList.Add(MakeParam("@chk_km_name", SqlDbType.VarChar, 200, chkKmName))
    paramList.Add(MakeParam("@pic_sign", SqlDbType.VarChar, 10, picSign))
    paramList.Add(MakeParam("@chk_id", SqlDbType.VarChar, 10, chkId))
    paramList.Add(MakeParam("@chk_name", SqlDbType.VarChar, 20, chkName))
    paramList.Add(MakeParam("@tool_id", SqlDbType.VarChar, 40, toolId))
    paramList.Add(MakeParam("@kj_0", SqlDbType.VarChar, 100, kj0))
    paramList.Add(MakeParam("@kj_1", SqlDbType.VarChar, 20, kj1))
    paramList.Add(MakeParam("@kj_2", SqlDbType.VarChar, 20, kj2))
    paramList.Add(MakeParam("@kj_explain", SqlDbType.nvarchar, 200, kjExplain))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 模板MS情報を削除する
    ''' </summary>
    '''<param name="lineId_key">生??</param>
'''<param name="tempId_key">??模板?号</param>
'''<param name="chkMethodId_key">???目ID</param>
    ''' <returns>模板MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelMTemp(Byval lineId_key AS String, _
           Byval tempId_key AS String, _
           Byval chkMethodId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key, _
           chkMethodId_key)
    'SQLコメント
    '--**テーブル：模板MS : m_temp
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_temp")
    sb.AppendLine("WHERE 1=1")
        If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If
    If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '??模板?号
        End If
    If chkMethodId_key<>"" Then
            sb.AppendLine("AND chk_method_id=@chk_method_id_key")   '???目ID
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
    paramList.Add(MakeParam("@temp_id_key", SqlDbType.nvarchar, 10, tempId_key))
    paramList.Add(MakeParam("@chk_method_id_key", SqlDbType.VarChar, 10, chkMethodId_key))


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
