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

Public Class MUserDA

    ''' <summary>
    ''' 
    ''' 社員MS情報を検索する
    ''' </summary>
    '''<param name="userCd_key">社員CD</param>
    ''' <returns>社員MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李さん 新規作成 </para>
    ''' </history>

    Public Function SelMUser(Byval userCd_key AS String) As Data.DataTable
        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           userCd_key)
        'SQLコメント
        '--**テーブル：社員MS : m_user
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("user_cd")                                                   '社員CD
        sb.AppendLine(", line_id")                                                 '生産ライン
        sb.AppendLine(", user_name")                                               '社員名

        sb.AppendLine("FROM m_user")
        sb.AppendLine("WHERE 1=1")
            If userCd_key<>"" Then
            sb.AppendLine("AND user_cd=@user_cd_key")   '社員CD
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@user_cd_key", SqlDbType.VarChar, 10, userCd_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_user", paramList.ToArray)

    Return dsInfo.Tables("m_user")

End Function

    ''' <summary>
    ''' 
    ''' 社員MS情報を更新する
    ''' </summary>
    '''<param name="userCd_key">社員CD</param>
'''<param name="userCd">社員CD</param>
'''<param name="lineId">生産ライン</param>
'''<param name="userName">社員名</param>
    ''' <returns>社員MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李さん 新規作成 </para>
    ''' </history>

Public Function UpdMUser(Byval userCd_key AS String, _
           Byval userCd AS String, _
           Byval lineId AS String, _
           Byval userName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           userCd_key, _
           userCd, _
           lineId, _
           userName)
    'SQLコメント
    '--**テーブル：社員MS : m_user
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_user")
    sb.AppendLine("SET")
    sb.AppendLine("user_cd=@user_cd")                                              '社員CD
    sb.AppendLine(", line_id=@line_id")                                            '生産ライン
    sb.AppendLine(", user_name=@user_name")   '社員名

    sb.AppendLine("FROM m_user")
    sb.AppendLine("WHERE 1=1")
        If userCd_key<>"" Then
            sb.AppendLine("AND user_cd=@user_cd_key")   '社員CD
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@user_cd_key", SqlDbType.VarChar, 10, userCd_key))

    paramList.Add(MakeParam("@user_cd", SqlDbType.VarChar, 10, userCd))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@user_name", SqlDbType.nvarchar, 10, userName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 社員MS情報を登録する
    ''' </summary>
    '''<param name="userCd">社員CD</param>
'''<param name="lineId">生産ライン</param>
'''<param name="userName">社員名</param>
    ''' <returns>社員MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李さん 新規作成 </para>
    ''' </history>

Public Function InsMUser(Byval userCd AS String, _
           Byval lineId AS String, _
           Byval userName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           userCd, _
           lineId, _
           userName)
    'SQLコメント
    '--**テーブル：社員MS : m_user
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_user")
    sb.AppendLine("(")
        sb.AppendLine("user_cd")                                                   '社員CD
        sb.AppendLine(", line_id")                                                 '生産ライン
        sb.AppendLine(", user_name")                                               '社員名

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@user_cd")                                                      '社員CD
    sb.AppendLine(", @line_id")                                                    '生産ライン
    sb.AppendLine(", @user_name")                                                  '社員名

    sb.AppendLine(")")
    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@user_cd", SqlDbType.VarChar, 10, userCd))
    paramList.Add(MakeParam("@line_id", SqlDbType.VarChar, 10, lineId))
    paramList.Add(MakeParam("@user_name", SqlDbType.nvarchar, 10, userName))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

    ''' <summary>
    ''' 
    ''' 社員MS情報を削除する
    ''' </summary>
    '''<param name="userCd_key">社員CD</param>
    ''' <returns>社員MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李さん 新規作成 </para>
    ''' </history>

Public Function DelMUser(Byval userCd_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           userCd_key)
    'SQLコメント
    '--**テーブル：社員MS : m_user
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_user")
    sb.AppendLine("WHERE 1=1")
        If userCd_key<>"" Then
            sb.AppendLine("AND user_cd=@user_cd_key")   '社員CD
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@user_cd_key", SqlDbType.VarChar, 10, userCd_key))


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
