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
    ''' 模板名称MSInfoを検索する
    ''' </summary>
    '''<param name="lineId_key">生产线</param>
'''<param name="tempId_key">检查模板编号</param>
    ''' <returns>模板名称MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/09  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelMTempName(Byval lineId_key AS String, _
           Byval tempId_key AS String) As Data.DataTable
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key)
        'SQLコメント
        '--**テーブル：模板名称MS : m_temp_name
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("line_id")                                                   '生产线
        sb.AppendLine(", temp_id")                                                 '检查模板编号
        sb.AppendLine(", temp_name")                                               '模板名称

        sb.AppendLine("FROM m_temp_name")
        sb.AppendLine("WHERE 1=1")
            If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
    If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '检查模板编号
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
    paramList.Add(MakeParam("@temp_id_key", SqlDbType.VarChar, 10, tempId_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_temp_name", paramList.ToArray)

    Return dsInfo.Tables("m_temp_name")

End Function

    ''' <summary>
    ''' 
    ''' 模板名称MSInfoを更新する
    ''' </summary>
    '''<param name="lineId_key">生产线</param>
'''<param name="tempId_key">检查模板编号</param>
'''<param name="lineId">生产线</param>
'''<param name="tempId">检查模板编号</param>
'''<param name="tempName">模板名称</param>
    ''' <returns>模板名称MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/09  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function UpdMTempName(Byval lineId_key AS String, _
           Byval tempId_key AS String, _
           Byval lineId AS String, _
           Byval tempId AS String, _
           Byval tempName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key, _
           lineId, _
           tempId, _
           tempName)
    'SQLコメント
    '--**テーブル：模板名称MS : m_temp_name
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_temp_name")
    sb.AppendLine("SET")
    sb.AppendLine("line_id=@line_id")                                              '生产线
    sb.AppendLine(", temp_id=@temp_id")                                            '检查模板编号
    sb.AppendLine(", temp_name=@temp_name")   '模板名称

    sb.AppendLine("FROM m_temp_name")
    sb.AppendLine("WHERE 1=1")
        If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
    If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '检查模板编号
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
    paramList.Add(MakeParam("@temp_id_key", SqlDbType.VarChar, 10, tempId_key))

    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@temp_id", SqlDbType.VarChar, 10, tempId))
    paramList.Add(MakeParam("@temp_name", SqlDbType.nvarchar, 200, tempName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 模板名称MSInfoを登録する
    ''' </summary>
    '''<param name="lineId">生产线</param>
'''<param name="tempId">检查模板编号</param>
'''<param name="tempName">模板名称</param>
    ''' <returns>模板名称MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/09  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function InsMTempName(Byval lineId AS String, _
           Byval tempId AS String, _
           Byval tempName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId, _
           tempId, _
           tempName)
    'SQLコメント
    '--**テーブル：模板名称MS : m_temp_name
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_temp_name")
    sb.AppendLine("(")
        sb.AppendLine("line_id")                                                   '生产线
        sb.AppendLine(", temp_id")                                                 '检查模板编号
        sb.AppendLine(", temp_name")                                               '模板名称

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@line_id")                                                      '生产线
    sb.AppendLine(", @temp_id")                                                    '检查模板编号
    sb.AppendLine(", @temp_name")                                                  '模板名称

    sb.AppendLine(")")
    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@temp_id", SqlDbType.VarChar, 10, tempId))
    paramList.Add(MakeParam("@temp_name", SqlDbType.nvarchar, 200, tempName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 模板名称MSInfoを削除する
    ''' </summary>
    '''<param name="lineId_key">生产线</param>
'''<param name="tempId_key">检查模板编号</param>
    ''' <returns>模板名称MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/09  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelMTempName(Byval lineId_key AS String, _
           Byval tempId_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key)
    'SQLコメント
    '--**テーブル：模板名称MS : m_temp_name
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_temp_name")
    sb.AppendLine("WHERE 1=1")
        If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生产线
        End If
    If tempId_key<>"" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   '检查模板编号
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
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
