
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic


Public Class MUserDA

    Public SqlHelperNew As New SqlHelperNew


    ''' <summary>
    ''' 
    ''' 用户MSInfoを検索する
    ''' </summary>
    '''<param name="userCd_key">用户CD</param>
    ''' <returns>用户MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelMUser(ByVal userCd_key As String) As Data.DataTable

        'SQLコメント
        '--**テーブル：用户MS : m_user
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("user_cd")                                                   '用户CD
        sb.AppendLine(", line_id")                                                 '生产线
        sb.AppendLine(", user_name")                                               '用户名
        sb.AppendLine("FROM m_user")
        sb.AppendLine("WHERE 1=1")
        If userCd_key <> "" Then
            sb.AppendLine("AND user_cd like @user_cd_key")   '用户CD
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@user_cd_key", SqlDbType.NVarChar, 13, "%" & userCd_key & "%"))

        Dim dsInfo As New Data.DataSet
        'FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_user", paramList.ToArray)

        SqlHelperNew.FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_user", paramList.ToArray)

        Return dsInfo.Tables("m_user")

    End Function


    ''' <summary>
    ''' 
    ''' 用户MSInfoを検索する
    ''' </summary>
    ''' <returns>用户MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function SelLineIds() As Data.DataTable

        'SQLコメント
        '--**テーブル：用户MS : m_user
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")

        sb.AppendLine("distinct line_id")                                                 '生产线
        '用户名
        sb.AppendLine("FROM m_user")

        Dim dsInfo As New Data.DataSet

        SqlHelperNew.FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_user")

        Return dsInfo.Tables(0)

    End Function

    ''' <summary>
    ''' 
    ''' 用户MSInfoを更新する
    ''' </summary>
    '''<param name="userCd_key">用户CD</param>
    '''<param name="userCd">用户CD</param>
    '''<param name="lineId">生产线</param>
    '''<param name="userName">用户名</param>
    ''' <returns>用户MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function UpdMUser(ByVal userCd_key As String, _
               ByVal userCd As String, _
               ByVal lineId As String, _
               ByVal userName As String) As Boolean

        'SQLコメント
        '--**テーブル：用户MS : m_user
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("UPDATE m_user")
        sb.AppendLine("SET")
        sb.AppendLine("user_cd=@user_cd")                                              '用户CD
        sb.AppendLine(", line_id=@line_id")                                            '生产线
        sb.AppendLine(", user_name=@user_name")   '用户名

        sb.AppendLine("FROM m_user")
        sb.AppendLine("WHERE 1=1")
        If userCd_key <> "" Then
            sb.AppendLine("AND user_cd=@user_cd_key")   '用户CD
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@user_cd_key", SqlDbType.nvarchar, 10, userCd_key))

        paramList.Add(SqlHelperNew.MakeParam("@user_cd", SqlDbType.nvarchar, 10, userCd))
        paramList.Add(SqlHelperNew.MakeParam("@line_id", SqlDbType.nvarchar, 10, lineId))
        paramList.Add(SqlHelperNew.MakeParam("@user_name", SqlDbType.nvarchar, 10, userName))


        SqlHelperNew.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' 用户MSInfoを登録する
    ''' </summary>
    '''<param name="userCd">用户CD</param>
    '''<param name="lineId">生产线</param>
    '''<param name="userName">用户名</param>
    ''' <returns>用户MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function InsMUser(ByVal userCd As String, _
               ByVal lineId As String, _
               ByVal userName As String) As Boolean

        'SQLコメント
        '--**テーブル：用户MS : m_user
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("INSERT INTO  m_user")
        sb.AppendLine("(")
        sb.AppendLine("user_cd")                                                   '用户CD
        sb.AppendLine(", line_id")                                                 '生产线
        sb.AppendLine(", user_name")                                               '用户名

        sb.AppendLine(")")
        sb.AppendLine("VALUES(")
        sb.AppendLine("@user_cd")                                                      '用户CD
        sb.AppendLine(", @line_id")                                                    '生产线
        sb.AppendLine(", @user_name")                                                  '用户名

        sb.AppendLine(")")
        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@user_cd", SqlDbType.nvarchar, 10, userCd))
        paramList.Add(SqlHelperNew.MakeParam("@line_id", SqlDbType.nvarchar, 10, lineId))
        paramList.Add(SqlHelperNew.MakeParam("@user_name", SqlDbType.nvarchar, 10, userName))


        SqlHelperNew.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' 用户MSInfoを削除する
    ''' </summary>
    '''<param name="userCd_key">用户CD</param>
    ''' <returns>用户MSInfo</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function DelMUser(ByVal userCd_key As String) As Boolean
        'SQLコメント
        '--**テーブル：用户MS : m_user
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("DELETE FROM m_user")
        sb.AppendLine("WHERE 1=1")
        If userCd_key <> "" Then
            sb.AppendLine("AND user_cd=@user_cd_key")   '用户CD
        End If

        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(SqlHelperNew.MakeParam("@user_cd_key", SqlDbType.nvarchar, 10, userCd_key))


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
