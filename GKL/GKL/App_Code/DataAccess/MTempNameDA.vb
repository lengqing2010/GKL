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

Public Class MTempNameDA

    ''' <summary>
    ''' 
    ''' Infoを検索する
    ''' </summary>
    '''<param name="tempId_key">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelMTempName(Byval tempId_key AS String) As Data.DataTable
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           tempId_key)
        'SQLコメント
        '--**テーブル： : m_temp_name
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("temp_id")                                                   'temp_id
        sb.AppendLine(", temp_name")                                               'temp_name

        sb.AppendLine("FROM m_temp_name")
        sb.AppendLine("WHERE 1=1")
            If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   'temp_id
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@temp_id_key", SqlDbType.VarChar, 10, tempId_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_temp_name", paramList.ToArray)

    Return dsInfo.Tables("m_temp_name")

End Function

    ''' <summary>
    ''' 
    ''' Infoを更新する
    ''' </summary>
    '''<param name="tempId_key">temp_id</param>
'''<param name="tempId">temp_id</param>
'''<param name="tempName">temp_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function UpdMTempName(Byval tempId_key AS String, _
           Byval tempId AS String, _
           Byval tempName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           tempId_key, _
           tempId, _
           tempName)
    'SQLコメント
    '--**テーブル： : m_temp_name
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_temp_name")
    sb.AppendLine("SET")
    sb.AppendLine("temp_id=@temp_id")                                              'temp_id
    sb.AppendLine(", temp_name=@temp_name")   'temp_name

    sb.AppendLine("FROM m_temp_name")
    sb.AppendLine("WHERE 1=1")
        If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   'temp_id
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@temp_id_key", SqlDbType.VarChar, 10, tempId_key))

    paramList.Add(MakeParam("@temp_id", SqlDbType.VarChar, 10, tempId))
    paramList.Add(MakeParam("@temp_name", SqlDbType.nvarchar, 200, tempName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' Infoを登録する
    ''' </summary>
    '''<param name="tempId">temp_id</param>
'''<param name="tempName">temp_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function InsMTempName(Byval tempId AS String, _
           Byval tempName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           tempId, _
           tempName)
    'SQLコメント
    '--**テーブル： : m_temp_name
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_temp_name")
    sb.AppendLine("(")
        sb.AppendLine("temp_id")                                                   'temp_id
        sb.AppendLine(", temp_name")                                               'temp_name

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@temp_id")                                                      'temp_id
    sb.AppendLine(", @temp_name")                                                  'temp_name

    sb.AppendLine(")")
    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@temp_id", SqlDbType.VarChar, 10, tempId))
    paramList.Add(MakeParam("@temp_name", SqlDbType.nvarchar, 200, tempName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' Infoを削除する
    ''' </summary>
    '''<param name="tempId_key">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelMTempName(Byval tempId_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           tempId_key)
    'SQLコメント
    '--**テーブル： : m_temp_name
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_temp_name")
    sb.AppendLine("WHERE 1=1")
        If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   'temp_id
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@temp_id_key", SqlDbType.VarChar, 10, tempId_key))


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
