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

Public Class MUserBC
Public DA AS NEW MUserDA

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

Public Function SelMUser(Byval userCd_key AS String) As Data.DataTable
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           userCd_key)
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

Public Function UpdMUser(Byval userCd_key AS String, _
           Byval userCd AS String, _
           Byval lineId AS String, _
           Byval userName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           userCd_key, _
           userCd, _
           lineId, _
           userName)
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

Public Function InsMUser(Byval userCd AS String, _
           Byval lineId AS String, _
           Byval userName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           userCd, _
           lineId, _
           userName)
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

Public Function DelMUser(Byval userCd_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           userCd_key)
    'SQLコメント
    '--**テーブル：用户MS : m_user
    Return DA.DelMUser( _
           userCd_key)


End Function

End Class
