﻿Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.Data
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic

Public Class TCheckPlanBC
Public DA AS NEW TCheckPlanDA

    ''' <summary>
    ''' 
    ''' ????情報を検索する
    ''' </summary>
    '''<param name="planNo_key">??No</param>
'''<param name="chkNo_key">??No</param>
'''<param name="makeNo_key">作番</param>
'''<param name="code_key">コード</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>????情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelTCheckPlan(Byval planNo_key AS String, _
           Byval chkNo_key AS String, _
           Byval makeNo_key AS String, _
           Byval code_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key)
    'SQLコメント
    Return DA.SelTCheckPlan( _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key)
End Function

    ''' <summary>
    ''' 
    ''' ????情報を更新する
    ''' </summary>
    '''<param name="planNo_key">??No</param>
'''<param name="chkNo_key">??No</param>
'''<param name="makeNo_key">作番</param>
'''<param name="code_key">コード</param>
'''<param name="lineId_key">生??</param>
'''<param name="planNo">??No</param>
'''<param name="chkNo">??No</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="lineId">生??</param>
'''<param name="suu">数量</param>
'''<param name="yoteiChkDate">????日</param>
'''<param name="status">状?</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>????情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdTCheckPlan(Byval planNo_key AS String, _
           Byval chkNo_key AS String, _
           Byval makeNo_key AS String, _
           Byval code_key AS String, _
           Byval lineId_key AS String, _
           Byval planNo AS String, _
           Byval chkNo AS String, _
           Byval makeNo AS String, _
           Byval code AS String, _
           Byval lineId AS String, _
           Byval suu AS String, _
           Byval yoteiChkDate AS String, _
           Byval status AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key, _
           planNo, _
           chkNo, _
           makeNo, _
           code, _
           lineId, _
           suu, _
           yoteiChkDate, _
           status, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???? : t_check_plan
    Return DA.UpdTCheckPlan( _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key, _
           planNo, _
           chkNo, _
           makeNo, _
           code, _
           lineId, _
           suu, _
           yoteiChkDate, _
           status, _
           insUser, _
           insDate)

End Function

    ''' <summary>
    ''' 
    ''' ????情報を登録する
    ''' </summary>
    '''<param name="planNo">??No</param>
'''<param name="chkNo">??No</param>
'''<param name="makeNo">作番</param>
'''<param name="code">コード</param>
'''<param name="lineId">生??</param>
'''<param name="suu">数量</param>
'''<param name="yoteiChkDate">????日</param>
'''<param name="status">状?</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>????情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsTCheckPlan(Byval planNo AS String, _
           Byval chkNo AS String, _
           Byval makeNo AS String, _
           Byval code AS String, _
           Byval lineId AS String, _
           Byval suu AS String, _
           Byval yoteiChkDate AS String, _
           Byval status AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           planNo, _
           chkNo, _
           makeNo, _
           code, _
           lineId, _
           suu, _
           yoteiChkDate, _
           status, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???? : t_check_plan
    Return DA.InsTCheckPlan( _
           planNo, _
           chkNo, _
           makeNo, _
           code, _
           lineId, _
           suu, _
           yoteiChkDate, _
           status, _
           insUser, _
           insDate)

End Function

    ''' <summary>
    ''' 
    ''' ????情報を削除する
    ''' </summary>
    '''<param name="planNo_key">??No</param>
'''<param name="chkNo_key">??No</param>
'''<param name="makeNo_key">作番</param>
'''<param name="code_key">コード</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>????情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelTCheckPlan(Byval planNo_key AS String, _
           Byval chkNo_key AS String, _
           Byval makeNo_key AS String, _
           Byval code_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル：???? : t_check_plan
    Return DA.DelTCheckPlan( _
           planNo_key, _
           chkNo_key, _
           makeNo_key, _
           code_key, _
           lineId_key)


End Function

End Class