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

Public Class MProjectBC
Public DA AS NEW MProjectDA

    ''' <summary>
    ''' 
    ''' 工程MS情報を検索する
    ''' </summary>
    '''<param name="projectId_key">工程ID</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>工程MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelMProject(Byval projectId_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           projectId_key, _
           lineId_key)
    'SQLコメント
    Return DA.SelMProject( _
           projectId_key, _
           lineId_key)
End Function

    ''' <summary>
    ''' 
    ''' 工程MS情報を更新する
    ''' </summary>
    '''<param name="projectId_key">工程ID</param>
'''<param name="lineId_key">生??</param>
'''<param name="projectId">工程ID</param>
'''<param name="lineId">生??</param>
'''<param name="projectName">工程名</param>
    ''' <returns>工程MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdMProject(Byval projectId_key AS String, _
           Byval lineId_key AS String, _
           Byval projectId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           projectId_key, _
           lineId_key, _
           projectId, _
           lineId, _
           projectName)
    'SQLコメント
    '--**テーブル：工程MS : m_project
    Return DA.UpdMProject( _
           projectId_key, _
           lineId_key, _
           projectId, _
           lineId, _
           projectName)

End Function

    ''' <summary>
    ''' 
    ''' 工程MS情報を登録する
    ''' </summary>
    '''<param name="projectId">工程ID</param>
'''<param name="lineId">生??</param>
'''<param name="projectName">工程名</param>
    ''' <returns>工程MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsMProject(Byval projectId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           projectId, _
           lineId, _
           projectName)
    'SQLコメント
    '--**テーブル：工程MS : m_project
    Return DA.InsMProject( _
           projectId, _
           lineId, _
           projectName)

End Function

    ''' <summary>
    ''' 
    ''' 工程MS情報を削除する
    ''' </summary>
    '''<param name="projectId_key">工程ID</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>工程MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelMProject(Byval projectId_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           projectId_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル：工程MS : m_project
    Return DA.DelMProject( _
           projectId_key, _
           lineId_key)


End Function

End Class
