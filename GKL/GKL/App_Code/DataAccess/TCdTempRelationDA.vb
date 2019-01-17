



Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic

Public Class TCdTempRelationDA
    Public SqlHelperNew As New SqlHelperNew
    ''' <summary>
    ''' 
    ''' Infoを検索する
    ''' </summary>
    '''<param name="lineId_key">line_id</param>
    '''<param name="code_key">code</param>
    '''<param name="tempId_key">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelTCdTempRelation(ByVal lineId_key As String, _
           ByVal code_key As String, _
           ByVal tempId_key As String) As Data.DataTable

        'SQLコメント
        '--**テーブル： : t_cd_temp_relation
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("line_id")                                                   'line_id
        sb.AppendLine(", code")                                                    'code
        sb.AppendLine(", temp_id")                                                 'temp_id

        sb.AppendLine("FROM t_cd_temp_relation")
        sb.AppendLine("WHERE 1=1")
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If
        If code_key <> "" Then
            sb.AppendLine("AND code=@code_key")   'code
        End If
        If tempId_key <> "" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   'temp_id
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
        paramList.Add(SqlHelperNew.MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
        paramList.Add(SqlHelperNew.MakeParam("@temp_id_key", SqlDbType.VarChar, 10, tempId_key))

        Dim dsInfo As New Data.DataSet
        SqlHelperNew.FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "t_cd_temp_relation", paramList.ToArray)

        Return dsInfo.Tables("t_cd_temp_relation")

    End Function

    ''' <summary>
    ''' 
    ''' Infoを更新する
    ''' </summary>
    '''<param name="lineId_key">line_id</param>
    '''<param name="code_key">code</param>
    '''<param name="tempId_key">temp_id</param>
    '''<param name="lineId">line_id</param>
    '''<param name="code">code</param>
    '''<param name="tempId">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function UpdTCdTempRelation(ByVal lineId_key As String, _
               ByVal code_key As String, _
               ByVal tempId_key As String, _
               ByVal lineId As String, _
               ByVal code As String, _
               ByVal tempId As String) As Boolean

        'SQLコメント
        '--**テーブル： : t_cd_temp_relation
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("UPDATE t_cd_temp_relation")
        sb.AppendLine("SET")
        sb.AppendLine("line_id=@line_id")                                              'line_id
        sb.AppendLine(", code=@code")                                                  'code
        sb.AppendLine(", temp_id=@temp_id")                                            'temp_id

        sb.AppendLine("FROM t_cd_temp_relation")
        sb.AppendLine("WHERE 1=1")
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If
        If code_key <> "" Then
            sb.AppendLine("AND code=@code_key")   'code
        End If
        If tempId_key <> "" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   'temp_id
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
        paramList.Add(SqlHelperNew.MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
        paramList.Add(SqlHelperNew.MakeParam("@temp_id_key", SqlDbType.VarChar, 10, tempId_key))

        paramList.Add(SqlHelperNew.MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
        paramList.Add(SqlHelperNew.MakeParam("@code", SqlDbType.VarChar, 20, code))
        paramList.Add(SqlHelperNew.MakeParam("@temp_id", SqlDbType.VarChar, 10, tempId))


        SqlHelperNew.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' Infoを登録する
    ''' </summary>
    '''<param name="lineId">line_id</param>
    '''<param name="code">code</param>
    '''<param name="tempId">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function InsTCdTempRelation(ByVal lineId As String, _
               ByVal code As String, _
               ByVal tempId As String) As Boolean

        'SQLコメント
        '--**テーブル： : t_cd_temp_relation
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("INSERT INTO  t_cd_temp_relation")
        sb.AppendLine("(")
        sb.AppendLine("line_id")                                                   'line_id
        sb.AppendLine(", code")                                                    'code
        sb.AppendLine(", temp_id")                                                 'temp_id

        sb.AppendLine(")")
        sb.AppendLine("VALUES(")
        sb.AppendLine("@line_id")                                                      'line_id
        sb.AppendLine(", @code")                                                       'code
        sb.AppendLine(", @temp_id")                                                    'temp_id

        sb.AppendLine(")")
        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
        paramList.Add(SqlHelperNew.MakeParam("@code", SqlDbType.VarChar, 20, code))
        paramList.Add(SqlHelperNew.MakeParam("@temp_id", SqlDbType.VarChar, 10, tempId))


        SqlHelperNew.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' Infoを削除する
    ''' </summary>
    '''<param name="lineId_key">line_id</param>
    '''<param name="code_key">code</param>
    '''<param name="tempId_key">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function DelTCdTempRelation(ByVal lineId_key As String, _
               ByVal code_key As String, _
               ByVal tempId_key As String) As Boolean

        'SQLコメント
        '--**テーブル： : t_cd_temp_relation
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("DELETE FROM t_cd_temp_relation")
        sb.AppendLine("WHERE 1=1")
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If
        If code_key <> "" Then
            sb.AppendLine("AND code=@code_key")   'code
        End If
        If tempId_key <> "" Then
            sb.AppendLine("AND temp_id=@temp_id_key")   'temp_id
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))
        paramList.Add(SqlHelperNew.MakeParam("@code_key", SqlDbType.VarChar, 20, code_key))
        paramList.Add(SqlHelperNew.MakeParam("@temp_id_key", SqlDbType.VarChar, 10, tempId_key))


        SqlHelperNew.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' GetIntValue
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetIntValue(ByVal v As Object) As Object
 
        If v Is DBNull.Value Or v.ToString = "" Then
            Return DBNull.Value

        Else
            Return Convert.ToInt32(v)
        End If

    End Function

End Class
