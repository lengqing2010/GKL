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

Public Class TCheckResultBC
Public DA AS NEW TCheckResultDA

    ''' <summary>
    ''' 
    ''' ???果情報を検索する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生??</param>
'''<param name="makeNo_key">作番</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)
    'SQLコメント
    Return DA.SelTCheckResult( _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)
End Function

    ''' <summary>
    ''' 
    ''' ???果情報を更新する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生??</param>
'''<param name="makeNo_key">作番</param>
'''<param name="chkNo">??No</param>
'''<param name="nen">年</param>
'''<param name="planNo">??No</param>
'''<param name="lineId">生??</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="suu">数量</param>
'''<param name="tempId">??模板?号</param>
'''<param name="chkResult">???果</param>
'''<param name="chkUser">??者</param>
'''<param name="chkStartDate">??開始日</param>
'''<param name="chkEndDate">??完了日</param>
'''<param name="parentChkNo">父??No</param>
'''<param name="status">状?</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
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
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
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
    'SQLコメント
    '--**テーブル：???果 : t_check_result
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
    ''' ???果情報を登録する
    ''' </summary>
    '''<param name="chkNo">??No</param>
'''<param name="nen">年</param>
'''<param name="planNo">??No</param>
'''<param name="lineId">生??</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="suu">数量</param>
'''<param name="tempId">??模板?号</param>
'''<param name="chkResult">???果</param>
'''<param name="chkUser">??者</param>
'''<param name="chkStartDate">??開始日</param>
'''<param name="chkEndDate">??完了日</param>
'''<param name="parentChkNo">父??No</param>
'''<param name="status">状?</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsTCheckResult(Byval chkNo AS String, _
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
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
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
    'SQLコメント
    '--**テーブル：???果 : t_check_result
    Return DA.InsTCheckResult( _
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
    ''' ???果情報を削除する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
'''<param name="nen_key">年</param>
'''<param name="lineId_key">生??</param>
'''<param name="makeNo_key">作番</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelTCheckResult(Byval chkNo_key AS String, _
           Byval nen_key AS String, _
           Byval lineId_key AS String, _
           Byval makeNo_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)
    'SQLコメント
    '--**テーブル：???果 : t_check_result
    Return DA.DelTCheckResult( _
           chkNo_key, _
           nen_key, _
           lineId_key, _
           makeNo_key)


End Function

End Class
