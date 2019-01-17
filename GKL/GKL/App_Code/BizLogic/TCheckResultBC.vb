﻿Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic

Public Class TCheckResultBC
Public DA AS NEW TCheckResultDA

    ''' <summary>
    ''' 
    ''' 检查结果Infoを検索する
    ''' </summary>
    '''<param name="chkNo_key">检查No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生产线</param>
'''<param name="makeNo_key">作番</param>
    ''' <returns>检查结果Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function SelTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String) As Data.DataTable

    'SQLコメント
    Return DA.SelTCheckResult( _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)
End Function

    ''' <summary>
    ''' 
    ''' 检查结果Infoを更新する
    ''' </summary>
    '''<param name="chkNo_key">检查No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生产线</param>
'''<param name="makeNo_key">作番</param>
'''<param name="chkNo">检查No</param>
'''<param name="nen">年</param>
'''<param name="planNo">计划No</param>
'''<param name="lineId">生产线</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="suu">数量</param>
'''<param name="tempId">检查模板编号</param>
'''<param name="chkResult">检查结果</param>
'''<param name="chkUser">检查者</param>
'''<param name="chkStartDate">检查開始日</param>
'''<param name="chkEndDate">检查完了日</param>
'''<param name="parentChkNo">父检查No</param>
'''<param name="status">状态</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>检查结果Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function UpdTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String, _
           Byval chkNo AS String, _
           Byval nen AS String, _
           Byval planNo AS String, _
           Byval lineId AS String, _
           Byval makeNo AS String, _
           Byval code AS String, _
           Byval suu AS String, _
           Byval tempId AS String, _
           Byval chkResult AS String, _
           Byval chkUser AS String, _
           Byval chkStartDate AS String, _
           Byval chkEndDate AS String, _
           Byval parentChkNo AS String, _
           Byval status AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
   
    'SQLコメント
    '--**テーブル：检查结果 : t_check_result
    Return DA.UpdTCheckResult( _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key, _
           chkNo, _
           nen, _
           planNo, _
           lineId, _
           makeNo, _
           code, _
           suu, _
           tempId, _
           chkResult, _
           chkUser, _
           chkStartDate, _
           chkEndDate, _
           parentChkNo, _
           status, _
           insUser, _
           insDate)

End Function

    ''' <summary>
    ''' 
    ''' 检查结果Infoを登録する
    ''' </summary>
    '''<param name="chkNo">检查No</param>
'''<param name="nen">年</param>
'''<param name="planNo">计划No</param>
'''<param name="lineId">生产线</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="suu">数量</param>
'''<param name="tempId">检查模板编号</param>
'''<param name="chkResult">检查结果</param>
'''<param name="chkUser">检查者</param>
'''<param name="chkStartDate">检查開始日</param>
'''<param name="chkEndDate">检查完了日</param>
'''<param name="parentChkNo">父检查No</param>
'''<param name="status">状态</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>检查结果Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

    Public Function InsTCheckResult(ByVal chkNo As String, _
               ByVal nen As String, _
               ByVal chk_times As String, _
               ByVal planNo As String, _
               ByVal lineId As String, _
               ByVal makeNo As String, _
               ByVal code As String, _
               ByVal suu As String, _
               ByVal tempId As String, _
               ByVal chkResult As String, _
               ByVal chkUser As String, _
               ByVal chkYoteiDate As String, _
               ByVal chkStartDate As String, _
               ByVal chkEndDate As String, _
               ByVal parentChkNo As String, _
               ByVal status As String, _
               ByVal insUser As String, _
               ByVal insDate As String) As Boolean
       
        '--**テーブル：检查结果 : t_check_result
        Return DA.InsTCheckResult( _
               chkNo, _
               nen, _
               chk_times, _
               planNo, _
               lineId, _
               makeNo, _
               code, _
               suu, _
               tempId, _
               chkResult, _
               chkUser, _
               chkYoteiDate, _
               chkStartDate, _
               chkEndDate, _
               parentChkNo, _
               status, _
               insUser, _
               insDate)

    End Function

    ''' <summary>
    ''' 
    ''' 检查结果Infoを削除する
    ''' </summary>
    '''<param name="chkNo_key">检查No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生产线</param>
'''<param name="makeNo_key">作番</param>
    ''' <returns>检查结果Info</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  作成者：李さん 新規作成 </para>
    ''' </history>

Public Function DelTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String) As Boolean
    
    'SQLコメント
    '--**テーブル：检查结果 : t_check_result
    Return DA.DelTCheckResult( _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)


    End Function

    Public Function SelTCheckResult(ByVal lineId_key As String, ByVal startDate As String, ByVal endDate As String, ByVal make_no As String, ByVal code As String) As Data.DataTable
        Return DA.SelTCheckResult( _
                                   lineId_key, _
                                   startDate, _
                                   endDate, make_no, code)

    End Function

    Public Function DeleteCheckResult(ByVal chkNo_key As String, _
       ByVal lineId_key As String, _
       ByVal insUser As String) As Boolean

        Return DA.DeleteCheckResult(chkNo_key, _
                                    lineId_key, _
                                    insUser)
    End Function

End Class
