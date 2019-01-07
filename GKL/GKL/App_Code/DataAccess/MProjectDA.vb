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

Public Class MProjectDA

    ''' <summary>
    ''' 
    ''' 工程MSInfoを検索する
    ''' </summary>
    '''<param name="projectId_key">工程ID</param>
'''<param name="lineId_key">生产线</param>
    ''' <returns>工程MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelMProject(Byval projectId_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           projectId_key, _
           lineId_key)
        'SQLコメント
        '--**テーブル：工程MS : m_project
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("project_id")                                                '工程ID
        sb.AppendLine(", line_id")                                                 '生产线
        sb.AppendLine(", project_name")                                            '工程名

        sb.AppendLine("FROM m_project")
        sb.AppendLine("WHERE 1=1")
            If projectId_key<>"" Then
            sb.AppendLine("AND project_id=@project_id_key")   '工程ID
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@project_id_key", SqlDbType.VarChar, 10, projectId_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_project", paramList.ToArray)

    Return dsInfo.Tables("m_project")

End Function

    ''' <summary>
    ''' 
    ''' 工程MSInfoを更新する
    ''' </summary>
    '''<param name="projectId_key">工程ID</param>
'''<param name="lineId_key">生产线</param>
'''<param name="projectId">工程ID</param>
'''<param name="lineId">生产线</param>
'''<param name="projectName">工程名</param>
    ''' <returns>工程MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function UpdMProject(Byval projectId_key AS String, _
           Byval lineId_key AS String, _
           Byval projectId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           projectId_key, _
           lineId_key, _
           projectId, _
           lineId, _
           projectName)
    'SQLコメント
    '--**テーブル：工程MS : m_project
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_project")
    sb.AppendLine("SET")
    sb.AppendLine("project_id=@project_id")   '工程ID
    sb.AppendLine(", line_id=@line_id")                                            '生产线
    sb.AppendLine(", project_name=@project_name")   '工程名

    sb.AppendLine("FROM m_project")
    sb.AppendLine("WHERE 1=1")
        If projectId_key<>"" Then
            sb.AppendLine("AND project_id=@project_id_key")   '工程ID
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@project_id_key", SqlDbType.VarChar, 10, projectId_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    paramList.Add(MakeParam("@project_id", SqlDbType.VarChar, 10, projectId))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@project_name", SqlDbType.nvarchar, 40, projectName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 工程MSInfoを登録する
    ''' </summary>
    '''<param name="projectId">工程ID</param>
'''<param name="lineId">生产线</param>
'''<param name="projectName">工程名</param>
    ''' <returns>工程MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function InsMProject(Byval projectId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           projectId, _
           lineId, _
           projectName)
    'SQLコメント
    '--**テーブル：工程MS : m_project
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_project")
    sb.AppendLine("(")
        sb.AppendLine("project_id")                                                '工程ID
        sb.AppendLine(", line_id")                                                 '生产线
        sb.AppendLine(", project_name")                                            '工程名

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@project_id")                                                   '工程ID
    sb.AppendLine(", @line_id")                                                    '生产线
    sb.AppendLine(", @project_name")                                               '工程名

    sb.AppendLine(")")
    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@project_id", SqlDbType.VarChar, 10, projectId))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@project_name", SqlDbType.nvarchar, 40, projectName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 工程MSInfoを削除する
    ''' </summary>
    '''<param name="projectId_key">工程ID</param>
'''<param name="lineId_key">生产线</param>
    ''' <returns>工程MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelMProject(Byval projectId_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           projectId_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル：工程MS : m_project
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_project")
    sb.AppendLine("WHERE 1=1")
        If projectId_key<>"" Then
            sb.AppendLine("AND project_id=@project_id_key")   '工程ID
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@project_id_key", SqlDbType.VarChar, 10, projectId_key))
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
