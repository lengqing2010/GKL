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
    Return DA.SelMUser( _
           userCd_key)
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
    Return DA.UpdMUser( _
           userCd_key, _
           userCd, _
           lineId, _
           userName)

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
    Return DA.InsMUser( _
           userCd, _
           lineId, _
           userName)

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
    Return DA.DelMUser( _
           userCd_key)


End Function

End Class
