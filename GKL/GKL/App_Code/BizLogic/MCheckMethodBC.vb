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

Public Class MCheckMethodBC
Public DA AS NEW MCheckMethodDA

    ''' <summary>
    ''' 
    ''' ??方法MS情報を検索する
    ''' </summary>
    '''<param name="chkId_key">??方法ID</param>
'''<param name="chkName_key">??方法名</param>
    ''' <returns>??方法MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelMCheckMethod(Byval chkId_key AS String, _
           Byval chkName_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkId_key, _
           chkName_key)
    'SQLコメント
    Return DA.SelMCheckMethod( _
           chkId_key, _
           chkName_key)
End Function

    ''' <summary>
    ''' 
    ''' ??方法MS情報を更新する
    ''' </summary>
    '''<param name="chkId_key">??方法ID</param>
'''<param name="chkName_key">??方法名</param>
'''<param name="chkId">??方法ID</param>
'''<param name="chkName">??方法名</param>
'''<param name="chkMethod">??方法</param>
'''<param name="chkFormula">??方公式</param>
'''<param name="verifyMethodExplain">核?方法?明</param>
    ''' <returns>??方法MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdMCheckMethod(Byval chkId_key AS String, _
           Byval chkName_key AS String, _
           Byval chkId AS String, _
           Byval chkName AS String, _
           Byval chkMethod AS String, _
           Byval chkFormula AS String, _
           Byval verifyMethodExplain AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkId_key, _
           chkName_key, _
           chkId, _
           chkName, _
           chkMethod, _
           chkFormula, _
           verifyMethodExplain)
    'SQLコメント
    '--**テーブル：??方法MS : m_check_method
    Return DA.UpdMCheckMethod( _
           chkId_key, _
           chkName_key, _
           chkId, _
           chkName, _
           chkMethod, _
           chkFormula, _
           verifyMethodExplain)

End Function

    ''' <summary>
    ''' 
    ''' ??方法MS情報を登録する
    ''' </summary>
    '''<param name="chkId">??方法ID</param>
'''<param name="chkName">??方法名</param>
'''<param name="chkMethod">??方法</param>
'''<param name="chkFormula">??方公式</param>
'''<param name="verifyMethodExplain">核?方法?明</param>
    ''' <returns>??方法MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsMCheckMethod(Byval chkId AS String, _
           Byval chkName AS String, _
           Byval chkMethod AS String, _
           Byval chkFormula AS String, _
           Byval verifyMethodExplain AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkId, _
           chkName, _
           chkMethod, _
           chkFormula, _
           verifyMethodExplain)
    'SQLコメント
    '--**テーブル：??方法MS : m_check_method
    Return DA.InsMCheckMethod( _
           chkId, _
           chkName, _
           chkMethod, _
           chkFormula, _
           verifyMethodExplain)

End Function

    ''' <summary>
    ''' 
    ''' ??方法MS情報を削除する
    ''' </summary>
    '''<param name="chkId_key">??方法ID</param>
'''<param name="chkName_key">??方法名</param>
    ''' <returns>??方法MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelMCheckMethod(Byval chkId_key AS String, _
           Byval chkName_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           chkId_key, _
           chkName_key)
    'SQLコメント
    '--**テーブル：??方法MS : m_check_method
    Return DA.DelMCheckMethod( _
           chkId_key, _
           chkName_key)


End Function

End Class
