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

Public Class TCdTempRelationBC
Public DA AS NEW TCdTempRelationDA

    ''' <summary>
    ''' 
    ''' Infoを検索する
    ''' </summary>
    '''<param name="lineId_key">line_id</param>
'''<param name="code_key">code</param>
'''<param name="tempId_key">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function SelTCdTempRelation(Byval lineId_key AS String, _
           Byval code_key AS String, _
           Byval tempId_key AS String) As Data.DataTable
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           code_key, _
           tempId_key)
    'SQLコメント
    Return DA.SelTCdTempRelation( _
           lineId_key, _
           code_key, _
           tempId_key)
End Function

    ''' <summary>
    ''' 
    ''' Infoを更新する
    ''' </summary>
    '''<param name="lineId_key">line_id</param>
'''<param name="code_key">code</param>
'''<param name="tempId_key">temp_id</param>
'''<param name="lineId">line_id</param>
'''<param name="code">code</param>
'''<param name="tempId">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function UpdTCdTempRelation(Byval lineId_key AS String, _
           Byval code_key AS String, _
           Byval tempId_key AS String, _
           Byval lineId AS String, _
           Byval code AS String, _
           Byval tempId AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           code_key, _
           tempId_key, _
           lineId, _
           code, _
           tempId)
    'SQLコメント
    '--**テーブル： : t_cd_temp_relation
    Return DA.UpdTCdTempRelation( _
           lineId_key, _
           code_key, _
           tempId_key, _
           lineId, _
           code, _
           tempId)

End Function

    ''' <summary>
    ''' 
    ''' Infoを登録する
    ''' </summary>
    '''<param name="lineId">line_id</param>
'''<param name="code">code</param>
'''<param name="tempId">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function InsTCdTempRelation(Byval lineId AS String, _
           Byval code AS String, _
           Byval tempId AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId, _
           code, _
           tempId)
    'SQLコメント
    '--**テーブル： : t_cd_temp_relation
    Return DA.InsTCdTempRelation( _
           lineId, _
           code, _
           tempId)

End Function

    ''' <summary>
    ''' 
    ''' Infoを削除する
    ''' </summary>
    '''<param name="lineId_key">line_id</param>
'''<param name="code_key">code</param>
'''<param name="tempId_key">temp_id</param>
    ''' <returns>Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelTCdTempRelation(Byval lineId_key AS String, _
           Byval code_key AS String, _
           Byval tempId_key AS String) As Boolean
    'EMAB　ＥＲＲ
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           code_key, _
           tempId_key)
    'SQLコメント
    '--**テーブル： : t_cd_temp_relation
    Return DA.DelTCdTempRelation( _
           lineId_key, _
           code_key, _
           tempId_key)


End Function

End Class
