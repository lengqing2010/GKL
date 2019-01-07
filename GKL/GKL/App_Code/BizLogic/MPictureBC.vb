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

Public Class MPictureBC
Public DA AS NEW MPictureDA

    ''' <summary>
    ''' 
    ''' ?片MS情報を検索する
    ''' </summary>
    '''<param name="picId_key">?片ID</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>?片MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function SelMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String) As Data.DataTable
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key)
    'SQLコメント
    Return DA.SelMPicture( _
           picId_key, _
           lineId_key)
End Function

    ''' <summary>
    ''' 
    ''' ?片MS情報を更新する
    ''' </summary>
    '''<param name="picId_key">?片ID</param>
'''<param name="lineId_key">生??</param>
'''<param name="picId">?片ID</param>
'''<param name="lineId">生??</param>
'''<param name="picName">?片名称</param>
    ''' <returns>?片MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function UpdMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String, _
           Byval picId AS String, _
           Byval lineId AS String, _
           Byval picName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key, _
           picId, _
           lineId, _
           picName)
    'SQLコメント
    '--**テーブル：?片MS : m_picture
    Return DA.UpdMPicture( _
           picId_key, _
           lineId_key, _
           picId, _
           lineId, _
           picName)

End Function

    ''' <summary>
    ''' 
    ''' ?片MS情報を登録する
    ''' </summary>
    '''<param name="picId">?片ID</param>
'''<param name="lineId">生??</param>
'''<param name="picName">?片名称</param>
    ''' <returns>?片MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function InsMPicture(Byval picId AS String, _
           Byval lineId AS String, _
           Byval picName AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId, _
           lineId, _
           picName)
    'SQLコメント
    '--**テーブル：?片MS : m_picture
    Return DA.InsMPicture( _
           picId, _
           lineId, _
           picName)

End Function

    ''' <summary>
    ''' 
    ''' ?片MS情報を削除する
    ''' </summary>
    '''<param name="picId_key">?片ID</param>
'''<param name="lineId_key">生??</param>
    ''' <returns>?片MS情報</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <para>2019/01/07  李松涛さん 新規作成 </para>
    ''' </history>

Public Function DelMPicture(Byval picId_key AS String, _
           Byval lineId_key AS String) As Boolean
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name , _
           picId_key, _
           lineId_key)
    'SQLコメント
    '--**テーブル：?片MS : m_picture
    Return DA.DelMPicture( _
           picId_key, _
           lineId_key)


End Function

End Class
