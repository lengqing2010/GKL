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

Public Class MToolsDA

    ''' <summary>
    ''' 
    ''' Infoを検索する
    ''' </summary>
    '''<param name="toolId_key">tool_id</param>
'''<param name="lineId_key">line_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId_key, _
           lineId_key)
        'SQLコメント
        '--**テーブル： : m_tools
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("tool_id")                                                   'tool_id
        sb.AppendLine(", line_id")                                                 'line_id
        sb.AppendLine(", project_name")                                            'project_name
        sb.AppendLine(", tool_name")                                               'tool_name

        sb.AppendLine("FROM m_tools")
        sb.AppendLine("WHERE 1=1")
            If toolId_key<>"" Then
            sb.AppendLine("AND tool_id=@tool_id_key")   'tool_id
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@tool_id_key", SqlDbType.VarChar, 40, toolId_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_tools", paramList.ToArray)

    Return dsInfo.Tables("m_tools")

End Function

    ''' <summary>
    ''' 
    ''' Infoを更新する
    ''' </summary>
    '''<param name="toolId_key">tool_id</param>
'''<param name="lineId_key">line_id</param>
'''<param name="toolId">tool_id</param>
'''<param name="lineId">line_id</param>
'''<param name="projectName">project_name</param>
'''<param name="toolName">tool_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function UpdMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String, _
           Byval toolId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String, _
           Byval toolName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId_key, _
           lineId_key, _
           toolId, _
           lineId, _
           projectName, _
           toolName)
    'SQLコメント
    '--**テーブル： : m_tools
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_tools")
    sb.AppendLine("SET")
    sb.AppendLine("tool_id=@tool_id")                                              'tool_id
    sb.AppendLine(", line_id=@line_id")                                            'line_id
    sb.AppendLine(", project_name=@project_name")   'project_name
    sb.AppendLine(", tool_name=@tool_name")   'tool_name

    sb.AppendLine("FROM m_tools")
    sb.AppendLine("WHERE 1=1")
        If toolId_key<>"" Then
            sb.AppendLine("AND tool_id=@tool_id_key")   'tool_id
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@tool_id_key", SqlDbType.VarChar, 40, toolId_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    paramList.Add(MakeParam("@tool_id", SqlDbType.VarChar, 40, toolId))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@project_name", SqlDbType.nvarchar, 40, projectName))
    paramList.Add(MakeParam("@tool_name", SqlDbType.nvarchar, 80, toolName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' Infoを登録する
    ''' </summary>
    '''<param name="toolId">tool_id</param>
'''<param name="lineId">line_id</param>
'''<param name="projectName">project_name</param>
'''<param name="toolName">tool_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function InsMTools(Byval toolId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String, _
           Byval toolName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId, _
           lineId, _
           projectName, _
           toolName)
    'SQLコメント
    '--**テーブル： : m_tools
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_tools")
    sb.AppendLine("(")
        sb.AppendLine("tool_id")                                                   'tool_id
        sb.AppendLine(", line_id")                                                 'line_id
        sb.AppendLine(", project_name")                                            'project_name
        sb.AppendLine(", tool_name")                                               'tool_name

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@tool_id")                                                      'tool_id
    sb.AppendLine(", @line_id")                                                    'line_id
    sb.AppendLine(", @project_name")                                               'project_name
    sb.AppendLine(", @tool_name")                                                  'tool_name

    sb.AppendLine(")")
    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@tool_id", SqlDbType.VarChar, 40, toolId))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@project_name", SqlDbType.nvarchar, 40, projectName))
    paramList.Add(MakeParam("@tool_name", SqlDbType.nvarchar, 80, toolName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' Infoを削除する
    ''' </summary>
    '''<param name="toolId_key">tool_id</param>
'''<param name="lineId_key">line_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル： : m_tools
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_tools")
    sb.AppendLine("WHERE 1=1")
        If toolId_key<>"" Then
            sb.AppendLine("AND tool_id=@tool_id_key")   'tool_id
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@tool_id_key", SqlDbType.VarChar, 40, toolId_key))
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
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name )
            If v Is DBNull.Value Or v.ToString = "" Then
                Return DBNull.Value
    
            Else
                Return Convert.ToInt32(v)
            End If
    
        End Function

End Class
