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
    ''' ?片MS情報を検索する
    ''' </summary>
    '''<param name="picId_key">?片ID</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>?片MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

    Public Function SelMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key)
        'SQLコメント
        '--**テーブル：?片MS : m_picture
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("pic_id")                                                    '?片ID
        sb.AppendLine(", line_id")                                                 '生??
        sb.AppendLine(", pic_name")                                                '?片名称

        sb.AppendLine("FROM m_picture")
        sb.AppendLine("WHERE 1=1")
            If picId_key<>"" Then
            sb.AppendLine("AND pic_id=@pic_id_key")   '?片ID
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@pic_id_key", SqlDbType.VarChar, 10, picId_key))
    paramList.Add(MakeParam("@line_id_key", SqlDbType.VarChar, 10, lineId_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_picture", paramList.ToArray)

    Return dsInfo.Tables("m_picture")

End Function

    ''' <summary>
    ''' 
    ''' ?片MS情報を更新する
    ''' </summary>
    '''<param name="picId_key">?片ID</param>
'''<param name="lineId_key">生??</param>
'''<param name="picId">?片ID</param>
'''<param name="lineId">生??</param>
'''<param name="picName">?片名称</param>
    ''' <returns>?片MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String, _
           Byval picId AS String, _
           Byval lineId AS String, _
           Byval picName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key, _
           picId, _
           lineId, _
           picName)
    'SQLコメント
    '--**テーブル：?片MS : m_picture
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_picture")
    sb.AppendLine("SET")
    sb.AppendLine("pic_id=@pic_id")                                                '?片ID
    sb.AppendLine(", line_id=@line_id")                                            '生??
    sb.AppendLine(", pic_name=@pic_name")   '?片名称

    sb.AppendLine("FROM m_picture")
    sb.AppendLine("WHERE 1=1")
        If picId_key<>"" Then
            sb.AppendLine("AND pic_id=@pic_id_key")   '?片ID
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If

    'バラメタ格納
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
    ''' ?片MS情報を登録する
    ''' </summary>
    '''<param name="picId">?片ID</param>
'''<param name="lineId">生??</param>
'''<param name="picName">?片名称</param>
    ''' <returns>?片MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsMPicture(Byval picId AS String, _
           Byval lineId AS String, _
           Byval picName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId, _
           lineId, _
           picName)
    'SQLコメント
    '--**テーブル：?片MS : m_picture
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_picture")
    sb.AppendLine("(")
        sb.AppendLine("pic_id")                                                    '?片ID
        sb.AppendLine(", line_id")                                                 '生??
        sb.AppendLine(", pic_name")                                                '?片名称

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@pic_id")                                                       '?片ID
    sb.AppendLine(", @line_id")                                                    '生??
    sb.AppendLine(", @pic_name")                                                   '?片名称

    sb.AppendLine(")")
    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@pic_id", SqlDbType.VarChar, 10, picId))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@pic_name", SqlDbType.nvarchar, 200, picName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' ?片MS情報を削除する
    ''' </summary>
    '''<param name="picId_key">?片ID</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>?片MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル：?片MS : m_picture
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_picture")
    sb.AppendLine("WHERE 1=1")
        If picId_key<>"" Then
            sb.AppendLine("AND pic_id=@pic_id_key")   '?片ID
        End If
    If lineId_key<>"" Then
            sb.AppendLine("AND line_id=@line_id_key")   '生??
        End If

    'バラメタ格納
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
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name )
            If v Is DBNull.Value Or v.ToString = "" Then
                Return DBNull.Value
    
            Else
                Return Convert.ToInt32(v)
            End If
    
        End Function

End Class
