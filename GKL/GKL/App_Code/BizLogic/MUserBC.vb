
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic

Public Class MUserBC

    Public DA As New MUserDA

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
        Return DA.SelMUser( _
               userCd_key)

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
        Return DA.UpdMUser( _
            userCd_key, _
            userCd, _
            lineId, _
            userName)

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
        Return DA.InsMUser( _
               userCd, _
               lineId, _
               userName)
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
        Return DA.DelMUser( _
               userCd_key)
    End Function

End Class
