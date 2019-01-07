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

Public Class MCheckMethodDA

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
        '--**テーブル：??方法MS : m_check_method
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("chk_id")                                                    '??方法ID
        sb.AppendLine(", chk_name")                                                '??方法名
        sb.AppendLine(", chk_method")                                              '??方法
        sb.AppendLine(", chk_formula")                                             '??方公式
        sb.AppendLine(", verify_method_explain")   '核?方法?明

        sb.AppendLine("FROM m_check_method")
        sb.AppendLine("WHERE 1=1")
            If chkId_key<>"" Then
            sb.AppendLine("AND chk_id=@chk_id_key")   '??方法ID
        End If
    If chkName_key<>"" Then
            sb.AppendLine("AND chk_name=@chk_name_key")   '??方法名
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_id_key", SqlDbType.VarChar, 10, chkId_key))
    paramList.Add(MakeParam("@chk_name_key", SqlDbType.VarChar, 20, chkName_key))

    Dim dsInfo As New Data.DataSet
    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "m_check_method", paramList.ToArray)

    Return dsInfo.Tables("m_check_method")

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
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("UPDATE m_check_method")
    sb.AppendLine("SET")
    sb.AppendLine("chk_id=@chk_id")                                                '??方法ID
    sb.AppendLine(", chk_name=@chk_name")   '??方法名
    sb.AppendLine(", chk_method=@chk_method")   '??方法
    sb.AppendLine(", chk_formula=@chk_formula")   '??方公式
    sb.AppendLine(", verify_method_explain=@verify_method_explain")   '核?方法?明

    sb.AppendLine("FROM m_check_method")
    sb.AppendLine("WHERE 1=1")
        If chkId_key<>"" Then
            sb.AppendLine("AND chk_id=@chk_id_key")   '??方法ID
        End If
    If chkName_key<>"" Then
            sb.AppendLine("AND chk_name=@chk_name_key")   '??方法名
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_id_key", SqlDbType.VarChar, 10, chkId_key))
    paramList.Add(MakeParam("@chk_name_key", SqlDbType.VarChar, 20, chkName_key))

    paramList.Add(MakeParam("@chk_id", SqlDbType.VarChar, 10, chkId))
    paramList.Add(MakeParam("@chk_name", SqlDbType.VarChar, 20, chkName))
    paramList.Add(MakeParam("@chk_method", SqlDbType.VarChar, 1, chkMethod))
    paramList.Add(MakeParam("@chk_formula", SqlDbType.nvarchar, 80, chkFormula))
    paramList.Add(MakeParam("@verify_method_explain", SqlDbType.nvarchar, 200, verifyMethodExplain))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

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
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("INSERT INTO  m_check_method")
    sb.AppendLine("(")
        sb.AppendLine("chk_id")                                                    '??方法ID
        sb.AppendLine(", chk_name")                                                '??方法名
        sb.AppendLine(", chk_method")                                              '??方法
        sb.AppendLine(", chk_formula")                                             '??方公式
        sb.AppendLine(", verify_method_explain")   '核?方法?明

    sb.AppendLine(")")
    sb.AppendLine("VALUES(")
    sb.AppendLine("@chk_id")                                                       '??方法ID
    sb.AppendLine(", @chk_name")                                                   '??方法名
    sb.AppendLine(", @chk_method")                                                 '??方法
    sb.AppendLine(", @chk_formula")                                                '??方公式
    sb.AppendLine(", @verify_method_explain")   '核?方法?明

    sb.AppendLine(")")
    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_id", SqlDbType.VarChar, 10, chkId))
    paramList.Add(MakeParam("@chk_name", SqlDbType.VarChar, 20, chkName))
    paramList.Add(MakeParam("@chk_method", SqlDbType.VarChar, 1, chkMethod))
    paramList.Add(MakeParam("@chk_formula", SqlDbType.nvarchar, 80, chkFormula))
    paramList.Add(MakeParam("@verify_method_explain", SqlDbType.nvarchar, 200, verifyMethodExplain))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

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
    Dim sb As New StringBuilder
        'SQL文
    sb.AppendLine("DELETE FROM m_check_method")
    sb.AppendLine("WHERE 1=1")
        If chkId_key<>"" Then
            sb.AppendLine("AND chk_id=@chk_id_key")   '??方法ID
        End If
    If chkName_key<>"" Then
            sb.AppendLine("AND chk_name=@chk_name_key")   '??方法名
        End If

    'バラメタ格納
    Dim paramList As New List(Of SqlParameter)
    paramList.Add(MakeParam("@chk_id_key", SqlDbType.VarChar, 10, chkId_key))
    paramList.Add(MakeParam("@chk_name_key", SqlDbType.VarChar, 20, chkName_key))


    SQLHelper.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray) 

    Return True 

End Function

        ''' <summary>
        ''' GetIntValue
        ''' </summary>
        ''' <param name="v"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetIntValue(ByVal v As Object) As Object
    'EMAB障害対応情報の格納処理
    EMAB.AddMethodEntrance(MyClass.GetType.FullName & "." & MyMethod.GetCurrentMethod.Name )
            If v Is DBNull.Value Or v.ToString = "" Then
                Return DBNull.Value
    
            Else
                Return Convert.ToInt32(v)
            End If
    
        End Function

End Class
