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
    ''' 模板MSInfoを検索する
    ''' </summary>
    '''<param name="lineId_key">生产线</param>
'''<param name="tempId_key">检查模板编号</param>
'''<param name="chkMethodId_key">检查项目ID</param>
    ''' <returns>模板MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelMTemp(ByVal lineId_key As String, _
           ByVal tempId_key As String, _
           ByVal chkMethodId_key As String) As Data.DataTable
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name, _
           lineId_key, _
           tempId_key, _
           chkMethodId_key)
        'SQLコメント
        '--**テーブル：模板MS : m_temp
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("line_id")                                                   '生产线
        sb.AppendLine(", temp_id")                                                 '检查模板编号
        sb.AppendLine(", chk_method_id")   '检查项目ID
        sb.AppendLine(", project_id")                                              '工程ID
        sb.AppendLine(", project_name")                                            '工程名
        sb.AppendLine(", pic_id")                                                  '图片ID
        sb.AppendLine(", pic_name")                                                '图片名称
        sb.AppendLine(", chk_km_name")                                             '检查项目
        sb.AppendLine(", pic_sign")                                                '图片标记
        sb.AppendLine(", chk_id")                                                  '检查方法ID
        sb.AppendLine(", chk_name")                                                '检查方法名
        sb.AppendLine(", tool_id")                                                 '治具ID
        sb.AppendLine(", kj_0")                                                    '基准
        sb.AppendLine(", kj_1")                                                    '工差1
        sb.AppendLine(", kj_2")                                                    '工差2
        sb.AppendLine(", kj_explain")                                              '基准説明

        sb.AppendLine("FROM m_temp")
        sb.AppendLine("WHERE 1=1")
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
        If tempId_key <> "" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '检查模板编号
        End If
        If chkMethodId_key <> "" Then
            sb.AppendLine("AND chk_method_id=@chk_method_id_key")   '检查项目ID
        End If

        '僶儔儊僞奿擺
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
    ''' 模板MSInfoを更新する
    ''' </summary>
    '''<param name="lineId_key">生产线</param>
    '''<param name="tempId_key">检查模板编号</param>
    '''<param name="chkMethodId_key">检查项目ID</param>
    '''<param name="lineId">生产线</param>
    '''<param name="tempId">检查模板编号</param>
    '''<param name="chkMethodId">检查项目ID</param>
    '''<param name="projectId">工程ID</param>
    '''<param name="projectName">工程名</param>
    '''<param name="picId">图片ID</param>
    '''<param name="picName">图片名称</param>
    '''<param name="chkKmName">检查项目</param>
    '''<param name="picSign">图片标记</param>
    '''<param name="chkId">检查方法ID</param>
    '''<param name="chkName">检查方法名</param>
    '''<param name="toolId">治具ID</param>
    '''<param name="kj0">基准</param>
    '''<param name="kj1">工差1</param>
    '''<param name="kj2">工差2</param>
    '''<param name="kjExplain">基准説明</param>
    ''' <returns>模板MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function UpdMTemp(ByVal lineId_key As String, _
               ByVal tempId_key As String, _
               ByVal chkMethodId_key As String, _
               ByVal lineId As String, _
               ByVal tempId As String, _
               ByVal chkMethodId As String, _
               ByVal projectId As String, _
               ByVal projectName As String, _
               ByVal picId As String, _
               ByVal picName As String, _
               ByVal chkKmName As String, _
               ByVal picSign As String, _
               ByVal chkId As String, _
               ByVal chkName As String, _
               ByVal toolId As String, _
               ByVal kj0 As String, _
               ByVal kj1 As String, _
               ByVal kj2 As String, _
               ByVal kjExplain As String) As Boolean
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name, _
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
        sb.AppendLine("line_id=@line_id")                                              '生产线
        sb.AppendLine(", temp_id=@temp_id")                                            '检查模板编号
        sb.AppendLine(", chk_method_id=@chk_method_id")   '检查项目ID
        sb.AppendLine(", project_id=@project_id")   '工程ID
        sb.AppendLine(", project_name=@project_name")   '工程名
        sb.AppendLine(", pic_id=@pic_id")                                              '图片ID
        sb.AppendLine(", pic_name=@pic_name")   '图片名称
        sb.AppendLine(", chk_km_name=@chk_km_name")   '检查项目
        sb.AppendLine(", pic_sign=@pic_sign")   '图片标记
        sb.AppendLine(", chk_id=@chk_id")                                              '检查方法ID
        sb.AppendLine(", chk_name=@chk_name")   '检查方法名
        sb.AppendLine(", tool_id=@tool_id")                                            '治具ID
        sb.AppendLine(", kj_0=@kj_0")                                                  '基准
        sb.AppendLine(", kj_1=@kj_1")                                                  '工差1
        sb.AppendLine(", kj_2=@kj_2")                                                  '工差2
        sb.AppendLine(", kj_explain=@kj_explain")   '基准説明

        sb.AppendLine("FROM m_temp")
        sb.AppendLine("WHERE 1=1")
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
        If tempId_key <> "" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '检查模板编号
        End If
        If chkMethodId_key <> "" Then
            sb.AppendLine("AND chk_method_id=@chk_method_id_key")   '检查项目ID
        End If

        '僶儔儊僞奿擺
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
    ''' 模板MSInfoを登録する
    ''' </summary>
    '''<param name="lineId">生产线</param>
    '''<param name="tempId">检查模板编号</param>
    '''<param name="chkMethodId">检查项目ID</param>
    '''<param name="projectId">工程ID</param>
    '''<param name="projectName">工程名</param>
    '''<param name="picId">图片ID</param>
    '''<param name="picName">图片名称</param>
    '''<param name="chkKmName">检查项目</param>
    '''<param name="picSign">图片标记</param>
    '''<param name="chkId">检查方法ID</param>
    '''<param name="chkName">检查方法名</param>
    '''<param name="toolId">治具ID</param>
    '''<param name="kj0">基准</param>
    '''<param name="kj1">工差1</param>
    '''<param name="kj2">工差2</param>
    '''<param name="kjExplain">基准説明</param>
    ''' <returns>模板MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function InsMTemp(ByVal lineId As String, _
               ByVal tempId As String, _
               ByVal chkMethodId As String, _
               ByVal projectId As String, _
               ByVal projectName As String, _
               ByVal picId As String, _
               ByVal picName As String, _
               ByVal chkKmName As String, _
               ByVal picSign As String, _
               ByVal chkId As String, _
               ByVal chkName As String, _
               ByVal toolId As String, _
               ByVal kj0 As String, _
               ByVal kj1 As String, _
               ByVal kj2 As String, _
               ByVal kjExplain As String) As Boolean
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name, _
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
        sb.AppendLine("line_id")                                                   '生产线
        sb.AppendLine(", temp_id")                                                 '检查模板编号
        sb.AppendLine(", chk_method_id")   '检查项目ID
        sb.AppendLine(", project_id")                                              '工程ID
        sb.AppendLine(", project_name")                                            '工程名
        sb.AppendLine(", pic_id")                                                  '图片ID
        sb.AppendLine(", pic_name")                                                '图片名称
        sb.AppendLine(", chk_km_name")                                             '检查项目
        sb.AppendLine(", pic_sign")                                                '图片标记
        sb.AppendLine(", chk_id")                                                  '检查方法ID
        sb.AppendLine(", chk_name")                                                '检查方法名
        sb.AppendLine(", tool_id")                                                 '治具ID
        sb.AppendLine(", kj_0")                                                    '基准
        sb.AppendLine(", kj_1")                                                    '工差1
        sb.AppendLine(", kj_2")                                                    '工差2
        sb.AppendLine(", kj_explain")                                              '基准説明

        sb.AppendLine(")")
        sb.AppendLine("VALUES(")
        sb.AppendLine("@line_id")                                                      '生产线
        sb.AppendLine(", @temp_id")                                                    '检查模板编号
        sb.AppendLine(", @chk_method_id")                                              '检查项目ID
        sb.AppendLine(", @project_id")                                                 '工程ID
        sb.AppendLine(", @project_name")                                               '工程名
        sb.AppendLine(", @pic_id")                                                     '图片ID
        sb.AppendLine(", @pic_name")                                                   '图片名称
        sb.AppendLine(", @chk_km_name")                                                '检查项目
        sb.AppendLine(", @pic_sign")                                                   '图片标记
        sb.AppendLine(", @chk_id")                                                     '检查方法ID
        sb.AppendLine(", @chk_name")                                                   '检查方法名
        sb.AppendLine(", @tool_id")                                                    '治具ID
        sb.AppendLine(", @kj_0")                                                       '基准
        sb.AppendLine(", @kj_1")                                                       '工差1
        sb.AppendLine(", @kj_2")                                                       '工差2
        sb.AppendLine(", @kj_explain")                                                 '基准説明

        sb.AppendLine(")")
        '僶儔儊僞奿擺
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
    ''' 模板MSInfoを削除する
    ''' </summary>
    '''<param name="lineId_key">生产线</param>
    '''<param name="tempId_key">检查模板编号</param>
    '''<param name="chkMethodId_key">检查项目ID</param>
    ''' <returns>模板MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelMTemp(Byval lineId_key AS String, _
           Byval tempId_key AS String, _
           Byval chkMethodId_key AS String) As Boolean
    'EMAB　ＥＲＲ
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
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
    If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '检查模板编号
        End If
    If chkMethodId_key<>"" Then
            sb.AppendLine("AND chk_method_id=@chk_method_id_key")   '检查项目ID
        End If

    '僶儔儊僞奿擺
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
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name )
            If v Is DBNull.Value Or v.ToString = "" Then
                Return DBNull.Value
    
            Else
                Return Convert.ToInt32(v)
            End If
    
        End Function

End Class
