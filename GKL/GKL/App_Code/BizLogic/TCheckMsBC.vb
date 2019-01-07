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

Public Class TCheckMsBC
Public DA AS NEW TCheckMsDA

    ''' <summary>
    ''' 
    ''' ???果情報を検索する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelTCheckMs(Byval chkNo_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key)
    'SQLコメント
    Return DA.SelTCheckMs( _
           chkNo_key)
End Function

    ''' <summary>
    ''' 
    ''' ???果情報を更新する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
'''<param name="chkNo">??No</param>
'''<param name="chkMethodId">???目ID</param>
'''<param name="chkFlg">??flg</param>
'''<param name="in1">入力値1</param>
'''<param name="in2">入力値2</param>
'''<param name="chkResult">???果</param>
'''<param name="mark">?考</param>
'''<param name="kj0">基准</param>
'''<param name="kj1">工差1</param>
'''<param name="kj2">工差2</param>
'''<param name="kjExplain">基准説明</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdTCheckMs(Byval chkNo_key AS String, _
           Byval chkNo AS String, _
           Byval chkMethodId AS String, _
           Byval chkFlg AS String, _
           Byval in1 AS String, _
           Byval in2 AS String, _
           Byval chkResult AS String, _
           Byval mark AS String, _
           Byval kj0 AS String, _
           Byval kj1 AS String, _
           Byval kj2 AS String, _
           Byval kjExplain AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key, _
           chkNo, _
           chkMethodId, _
           chkFlg, _
           in1, _
           in2, _
           chkResult, _
           mark, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???果 : t_check_ms
    Return DA.UpdTCheckMs( _
           chkNo_key, _
           chkNo, _
           chkMethodId, _
           chkFlg, _
           in1, _
           in2, _
           chkResult, _
           mark, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain, _
           insUser, _
           insDate)

End Function

    ''' <summary>
    ''' 
    ''' ???果情報を登録する
    ''' </summary>
    '''<param name="chkNo">??No</param>
'''<param name="chkMethodId">???目ID</param>
'''<param name="chkFlg">??flg</param>
'''<param name="in1">入力値1</param>
'''<param name="in2">入力値2</param>
'''<param name="chkResult">???果</param>
'''<param name="mark">?考</param>
'''<param name="kj0">基准</param>
'''<param name="kj1">工差1</param>
'''<param name="kj2">工差2</param>
'''<param name="kjExplain">基准説明</param>
'''<param name="insUser">登録者</param>
'''<param name="insDate">登録日</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsTCheckMs(Byval chkNo AS String, _
           Byval chkMethodId AS String, _
           Byval chkFlg AS String, _
           Byval in1 AS String, _
           Byval in2 AS String, _
           Byval chkResult AS String, _
           Byval mark AS String, _
           Byval kj0 AS String, _
           Byval kj1 AS String, _
           Byval kj2 AS String, _
           Byval kjExplain AS String, _
           Byval insUser AS String, _
           Byval insDate AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo, _
           chkMethodId, _
           chkFlg, _
           in1, _
           in2, _
           chkResult, _
           mark, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain, _
           insUser, _
           insDate)
    'SQLコメント
    '--**テーブル：???果 : t_check_ms
    Return DA.InsTCheckMs( _
           chkNo, _
           chkMethodId, _
           chkFlg, _
           in1, _
           in2, _
           chkResult, _
           mark, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain, _
           insUser, _
           insDate)

End Function

    ''' <summary>
    ''' 
    ''' ???果情報を削除する
    ''' </summary>
    '''<param name="chkNo_key">??No</param>
    ''' <returns>???果情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelTCheckMs(Byval chkNo_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkNo_key)
    'SQLコメント
    '--**テーブル：???果 : t_check_ms
    Return DA.DelTCheckMs( _
           chkNo_key)


End Function

End Class
