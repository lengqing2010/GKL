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

Public Class MTempBC
Public DA AS NEW MTempDA

    ''' <summary>
    ''' 
    ''' 模板MS情報を検索する
    ''' </summary>
    '''<param name="lineId_key">生??</param>
'''<param name="tempId_key">??模板?号</param>
'''<param name="chkMethodId_key">???目ID</param>
    ''' <returns>模板MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelMTemp(Byval lineId_key AS String, _
           Byval tempId_key AS String, _
           Byval chkMethodId_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key, _
           chkMethodId_key)
    'SQLコメント
    Return DA.SelMTemp( _
           lineId_key, _
           tempId_key, _
           chkMethodId_key)
End Function

    ''' <summary>
    ''' 
    ''' 模板MS情報を更新する
    ''' </summary>
    '''<param name="lineId_key">生??</param>
'''<param name="tempId_key">??模板?号</param>
'''<param name="chkMethodId_key">???目ID</param>
'''<param name="lineId">生??</param>
'''<param name="tempId">??模板?号</param>
'''<param name="chkMethodId">???目ID</param>
'''<param name="projectId">工程ID</param>
'''<param name="projectName">工程名</param>
'''<param name="picId">?片ID</param>
'''<param name="picName">?片名称</param>
'''<param name="chkKmName">???目</param>
'''<param name="picSign">?片??</param>
'''<param name="chkId">??方法ID</param>
'''<param name="chkName">??方法名</param>
'''<param name="toolId">治具ID</param>
'''<param name="kj0">基准</param>
'''<param name="kj1">工差1</param>
'''<param name="kj2">工差2</param>
'''<param name="kjExplain">基准説明</param>
    ''' <returns>模板MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdMTemp(Byval lineId_key AS String, _
           Byval tempId_key AS String, _
           Byval chkMethodId_key AS String, _
           Byval lineId AS String, _
           Byval tempId AS String, _
           Byval chkMethodId AS String, _
           Byval projectId AS String, _
           Byval projectName AS String, _
           Byval picId AS String, _
           Byval picName AS String, _
           Byval chkKmName AS String, _
           Byval picSign AS String, _
           Byval chkId AS String, _
           Byval chkName AS String, _
           Byval toolId AS String, _
           Byval kj0 AS String, _
           Byval kj1 AS String, _
           Byval kj2 AS String, _
           Byval kjExplain AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key, _
           chkMethodId_key, _
           lineId, _
           tempId, _
           chkMethodId, _
           projectId, _
           projectName, _
           picId, _
           picName, _
           chkKmName, _
           picSign, _
           chkId, _
           chkName, _
           toolId, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain)
    'SQLコメント
    '--**テーブル：模板MS : m_temp
    Return DA.UpdMTemp( _
           lineId_key, _
           tempId_key, _
           chkMethodId_key, _
           lineId, _
           tempId, _
           chkMethodId, _
           projectId, _
           projectName, _
           picId, _
           picName, _
           chkKmName, _
           picSign, _
           chkId, _
           chkName, _
           toolId, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain)

End Function

    ''' <summary>
    ''' 
    ''' 模板MS情報を登録する
    ''' </summary>
    '''<param name="lineId">生??</param>
'''<param name="tempId">??模板?号</param>
'''<param name="chkMethodId">???目ID</param>
'''<param name="projectId">工程ID</param>
'''<param name="projectName">工程名</param>
'''<param name="picId">?片ID</param>
'''<param name="picName">?片名称</param>
'''<param name="chkKmName">???目</param>
'''<param name="picSign">?片??</param>
'''<param name="chkId">??方法ID</param>
'''<param name="chkName">??方法名</param>
'''<param name="toolId">治具ID</param>
'''<param name="kj0">基准</param>
'''<param name="kj1">工差1</param>
'''<param name="kj2">工差2</param>
'''<param name="kjExplain">基准説明</param>
    ''' <returns>模板MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsMTemp(Byval lineId AS String, _
           Byval tempId AS String, _
           Byval chkMethodId AS String, _
           Byval projectId AS String, _
           Byval projectName AS String, _
           Byval picId AS String, _
           Byval picName AS String, _
           Byval chkKmName AS String, _
           Byval picSign AS String, _
           Byval chkId AS String, _
           Byval chkName AS String, _
           Byval toolId AS String, _
           Byval kj0 AS String, _
           Byval kj1 AS String, _
           Byval kj2 AS String, _
           Byval kjExplain AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId, _
           tempId, _
           chkMethodId, _
           projectId, _
           projectName, _
           picId, _
           picName, _
           chkKmName, _
           picSign, _
           chkId, _
           chkName, _
           toolId, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain)
    'SQLコメント
    '--**テーブル：模板MS : m_temp
    Return DA.InsMTemp( _
           lineId, _
           tempId, _
           chkMethodId, _
           projectId, _
           projectName, _
           picId, _
           picName, _
           chkKmName, _
           picSign, _
           chkId, _
           chkName, _
           toolId, _
           kj0, _
           kj1, _
           kj2, _
           kjExplain)

End Function

    ''' <summary>
    ''' 
    ''' 模板MS情報を削除する
    ''' </summary>
    '''<param name="lineId_key">生??</param>
'''<param name="tempId_key">??模板?号</param>
'''<param name="chkMethodId_key">???目ID</param>
    ''' <returns>模板MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelMTemp(Byval lineId_key AS String, _
           Byval tempId_key AS String, _
           Byval chkMethodId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           lineId_key, _
           tempId_key, _
           chkMethodId_key)
    'SQLコメント
    '--**テーブル：模板MS : m_temp
    Return DA.DelMTemp( _
           lineId_key, _
           tempId_key, _
           chkMethodId_key)


End Function

End Class
