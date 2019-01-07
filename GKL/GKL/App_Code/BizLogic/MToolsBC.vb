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

Public Class MToolsBC
Public DA AS NEW MToolsDA

    ''' <summary>
    ''' 
    ''' 治具MS情報を検索する
    ''' </summary>
    '''<param name="toolId_key">治具ID</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>治具MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId_key, _
           lineId_key)
    'SQLコメント
    Return DA.SelMTools( _
           toolId_key, _
           lineId_key)
End Function

    ''' <summary>
    ''' 
    ''' 治具MS情報を更新する
    ''' </summary>
    '''<param name="toolId_key">治具ID</param>
'''<param name="lineId_key">生??</param>
'''<param name="toolId">治具ID</param>
'''<param name="lineId">生??</param>
'''<param name="projectName">工程</param>
'''<param name="toolName">治具?示文本</param>
    ''' <returns>治具MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String, _
           Byval toolId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String, _
           Byval toolName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId_key, _
           lineId_key, _
           toolId, _
           lineId, _
           projectName, _
           toolName)
    'SQLコメント
    '--**テーブル：治具MS : m_tools
    Return DA.UpdMTools( _
           toolId_key, _
           lineId_key, _
           toolId, _
           lineId, _
           projectName, _
           toolName)

End Function

    ''' <summary>
    ''' 
    ''' 治具MS情報を登録する
    ''' </summary>
    '''<param name="toolId">治具ID</param>
'''<param name="lineId">生??</param>
'''<param name="projectName">工程</param>
'''<param name="toolName">治具?示文本</param>
    ''' <returns>治具MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsMTools(Byval toolId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String, _
           Byval toolName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId, _
           lineId, _
           projectName, _
           toolName)
    'SQLコメント
    '--**テーブル：治具MS : m_tools
    Return DA.InsMTools( _
           toolId, _
           lineId, _
           projectName, _
           toolName)

End Function

    ''' <summary>
    ''' 
    ''' 治具MS情報を削除する
    ''' </summary>
    '''<param name="toolId_key">治具ID</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>治具MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル：治具MS : m_tools
    Return DA.DelMTools( _
           toolId_key, _
           lineId_key)


End Function

End Class
