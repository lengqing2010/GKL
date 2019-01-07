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
    ''' Infoを検索する
    ''' </summary>
    '''<param name="toolId_key">tool_id</param>
'''<param name="lineId_key">line_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function SelMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
    'EMAB　ＥＲＲ
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
    ''' Infoを更新する
    ''' </summary>
    '''<param name="toolId_key">tool_id</param>
'''<param name="lineId_key">line_id</param>
'''<param name="toolId">tool_id</param>
'''<param name="lineId">line_id</param>
'''<param name="projectName">project_name</param>
'''<param name="toolName">tool_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function UpdMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String, _
           Byval toolId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String, _
           Byval toolName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId_key, _
           lineId_key, _
           toolId, _
           lineId, _
           projectName, _
           toolName)
    'SQLコメント
    '--**テーブル： : m_tools
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
    ''' Infoを登録する
    ''' </summary>
    '''<param name="toolId">tool_id</param>
'''<param name="lineId">line_id</param>
'''<param name="projectName">project_name</param>
'''<param name="toolName">tool_name</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function InsMTools(Byval toolId AS String, _
           Byval lineId AS String, _
           Byval projectName AS String, _
           Byval toolName AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId, _
           lineId, _
           projectName, _
           toolName)
    'SQLコメント
    '--**テーブル： : m_tools
    Return DA.InsMTools( _
           toolId, _
           lineId, _
           projectName, _
           toolName)

End Function

    ''' <summary>
    ''' 
    ''' Infoを削除する
    ''' </summary>
    '''<param name="toolId_key">tool_id</param>
'''<param name="lineId_key">line_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelMTools(Byval toolId_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           toolId_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル： : m_tools
    Return DA.DelMTools( _
           toolId_key, _
           lineId_key)


End Function

End Class
