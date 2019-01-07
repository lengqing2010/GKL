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

Public Class MTempNameBC
Public DA AS NEW MTempNameDA

    ''' <summary>
    ''' 
    ''' 模板名称MS情報を検索する
    ''' </summary>
    '''<param name="tempId_key">??模板?号</param>
    ''' <returns>模板名称MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelMTempName(Byval tempId_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           tempId_key)
    'SQLコメント
    Return DA.SelMTempName( _
           tempId_key)
End Function

    ''' <summary>
    ''' 
    ''' 模板名称MS情報を更新する
    ''' </summary>
    '''<param name="tempId_key">??模板?号</param>
'''<param name="tempId">??模板?号</param>
'''<param name="tempName">模板名称</param>
    ''' <returns>模板名称MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdMTempName(Byval tempId_key AS String, _
           Byval tempId AS String, _
           Byval tempName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           tempId_key, _
           tempId, _
           tempName)
    'SQLコメント
    '--**テーブル：模板名称MS : m_temp_name
    Return DA.UpdMTempName( _
           tempId_key, _
           tempId, _
           tempName)

End Function

    ''' <summary>
    ''' 
    ''' 模板名称MS情報を登録する
    ''' </summary>
    '''<param name="tempId">??模板?号</param>
'''<param name="tempName">模板名称</param>
    ''' <returns>模板名称MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsMTempName(Byval tempId AS String, _
           Byval tempName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           tempId, _
           tempName)
    'SQLコメント
    '--**テーブル：模板名称MS : m_temp_name
    Return DA.InsMTempName( _
           tempId, _
           tempName)

End Function

    ''' <summary>
    ''' 
    ''' 模板名称MS情報を削除する
    ''' </summary>
    '''<param name="tempId_key">??模板?号</param>
    ''' <returns>模板名称MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelMTempName(Byval tempId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           tempId_key)
    'SQLコメント
    '--**テーブル：模板名称MS : m_temp_name
    Return DA.DelMTempName( _
           tempId_key)


End Function

End Class
