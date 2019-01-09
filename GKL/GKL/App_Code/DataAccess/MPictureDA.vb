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

Public Class MPictureDA

    ''' <summary>
    ''' 
    ''' Infoを検索する
    ''' </summary>
    '''<param name="picId_key">pic_id</param>
'''<param name="lineId_key">line_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key)
        'SQLコメント
        '--**テーブル： : m_picture
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("pic_id")                                                    'pic_id
        sb.AppendLine(", line_id")                                                 'line_id
        sb.AppendLine(", pic_name")                                                'pic_name

        sb.AppendLine("FROM m_picture")
        sb.AppendLine("WHERE 1=1")
            If picId_key<>"" Then
            sb.AppendLine("AND pic_id=@pic_id_key")   'pic_id
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If
        sb.AppendLine("ORDER BY line_id,pic_id")
    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@pic_id_key", SqlDbType.VarChar, 10, picId_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_picture", paramList.ToArray)

    Return dsInfo.Tables("m_picture")

    End Function


    Public Function GetLineListPic(ByVal picId_key As String, ByVal lineId_key As String)

        '--**テーブル： : m_picture
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("pic_id ")                                                    'pic_id
        sb.AppendLine(", line_id ")                                                 'line_id
        sb.AppendLine(", pic_name ")                                                'pic_name
        sb.AppendLine(", pic_conn ")
        sb.AppendLine("FROM m_picture")
        sb.AppendLine("WHERE 1=1")
        If picId_key <> "" Then
            sb.AppendLine("AND pic_id='" & picId_key & "'")   'pic_id
        End If
        If lineId_key <> "" Then
            sb.AppendLine("AND line_id='" & lineId_key & "'")   'line_id
        End If
        sb.AppendLine("ORDER BY line_id,pic_id")
        Dim dsInfo As New Data.DataSet
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_picture")
        Return dsInfo.Tables(0).Rows(0).Item("pic_conn")

    End Function

    ''' <summary>
    ''' 
    ''' Infoを更新する
    ''' </summary>
    '''<param name="picId_key">pic_id</param>
'''<param name="lineId_key">line_id</param>
'''<param name="picId">pic_id</param>
'''<param name="lineId">line_id</param>
'''<param name="picName">pic_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function UpdMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String, _
           Byval picId AS String, _
           Byval lineId AS String, _
           Byval picName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key, _
           picId, _
           lineId, _
           picName)
    'SQLコメント
    '--**テーブル： : m_picture
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_picture")
    sb.AppendLine("SET")
    sb.AppendLine("pic_id=@pic_id")                                                'pic_id
    sb.AppendLine(", line_id=@line_id")                                            'line_id
    sb.AppendLine(", pic_name=@pic_name")   'pic_name

    sb.AppendLine("FROM m_picture")
    sb.AppendLine("WHERE 1=1")
        If picId_key<>"" Then
            sb.AppendLine("AND pic_id=@pic_id_key")   'pic_id
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@pic_id_key", SqlDbType.VarChar, 10, picId_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    paramList.Add(MakeParam("@pic_id", SqlDbType.VarChar, 10, picId))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@pic_name", SqlDbType.nvarchar, 200, picName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' Infoを登録する
    ''' </summary>
    '''<param name="picId">pic_id</param>
'''<param name="lineId">line_id</param>
'''<param name="picName">pic_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function InsMPicture(Byval picId AS String, _
           Byval lineId AS String, _
           Byval picName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId, _
           lineId, _
           picName)
    'SQLコメント
    '--**テーブル： : m_picture
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_picture")
    sb.AppendLine("(")
        sb.AppendLine("pic_id")                                                    'pic_id
        sb.AppendLine(", line_id")                                                 'line_id
        sb.AppendLine(", pic_name")                                                'pic_name

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@pic_id")                                                       'pic_id
    sb.AppendLine(", @line_id")                                                    'line_id
    sb.AppendLine(", @pic_name")                                                   'pic_name

    sb.AppendLine(")")
    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@pic_id", SqlDbType.VarChar, 10, picId))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@pic_name", SqlDbType.nvarchar, 200, picName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' Infoを削除する
    ''' </summary>
    '''<param name="picId_key">pic_id</param>
'''<param name="lineId_key">line_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル： : m_picture
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_picture")
    sb.AppendLine("WHERE 1=1")
        If picId_key<>"" Then
            sb.AppendLine("AND pic_id=@pic_id_key")   'pic_id
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   'line_id
        End If

    '僶儔儊僞奿擺
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@pic_id_key", SqlDbType.VarChar, 10, picId_key))
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
