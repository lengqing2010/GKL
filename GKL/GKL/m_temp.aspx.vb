Imports System.Data
Imports System.Text
Imports System.IO
Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Partial Class m_temp
    Inherits System.Web.UI.Page

   Public BC AS NEW MTempBC
    ''' <summary>
    ''' PAGE LOAD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
                               MyMethod.GetCurrentMethod.Name)

        Me.lblMsg.Text = ""
        If Not IsPostBack Then

            '固定項目設定
            KoteiInit()

            '明細項目設定
            MsInit()
        End If

    End Sub
    ''' <summary>
    ''' 固定項目設定
    ''' </summary>
    public Sub KoteiInit()
      'EMAB障害対応情報の格納処理
       EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
       MyMethod.GetCurrentMethod.Name)
       Me.tbxLineId.Attributes.Item("itType") = "varchar"
       Me.tbxLineId.Attributes.Item("itLength") = "10"
       Me.tbxLineId.Attributes.Item("itName") = "生??"
       Me.tbxTempId.Attributes.Item("itType") = "nvarchar"
       Me.tbxTempId.Attributes.Item("itLength") = "10"
       Me.tbxTempId.Attributes.Item("itName") = "??模板?号"
       Me.tbxChkMethodId.Attributes.Item("itType") = "varchar"
       Me.tbxChkMethodId.Attributes.Item("itLength") = "10"
       Me.tbxChkMethodId.Attributes.Item("itName") = "???目ID"
       Me.tbxProjectId.Attributes.Item("itType") = "varchar"
       Me.tbxProjectId.Attributes.Item("itLength") = "10"
       Me.tbxProjectId.Attributes.Item("itName") = "工程ID"
       Me.tbxProjectName.Attributes.Item("itType") = "varchar"
       Me.tbxProjectName.Attributes.Item("itLength") = "40"
       Me.tbxProjectName.Attributes.Item("itName") = "工程名"
       Me.tbxPicId.Attributes.Item("itType") = "varchar"
       Me.tbxPicId.Attributes.Item("itLength") = "10"
       Me.tbxPicId.Attributes.Item("itName") = "?片ID"
       Me.tbxPicName.Attributes.Item("itType") = "varchar"
       Me.tbxPicName.Attributes.Item("itLength") = "200"
       Me.tbxPicName.Attributes.Item("itName") = "?片名称"
       Me.tbxChkKmName.Attributes.Item("itType") = "varchar"
       Me.tbxChkKmName.Attributes.Item("itLength") = "200"
       Me.tbxChkKmName.Attributes.Item("itName") = "???目"
       Me.tbxPicSign.Attributes.Item("itType") = "varchar"
       Me.tbxPicSign.Attributes.Item("itLength") = "10"
       Me.tbxPicSign.Attributes.Item("itName") = "?片??"
       Me.tbxChkId.Attributes.Item("itType") = "varchar"
       Me.tbxChkId.Attributes.Item("itLength") = "10"
       Me.tbxChkId.Attributes.Item("itName") = "??方法ID"
       Me.tbxChkName.Attributes.Item("itType") = "varchar"
       Me.tbxChkName.Attributes.Item("itLength") = "20"
       Me.tbxChkName.Attributes.Item("itName") = "??方法名"
       Me.tbxToolId.Attributes.Item("itType") = "varchar"
       Me.tbxToolId.Attributes.Item("itLength") = "40"
       Me.tbxToolId.Attributes.Item("itName") = "治具ID"
       Me.tbxKj0.Attributes.Item("itType") = "varchar"
       Me.tbxKj0.Attributes.Item("itLength") = "100"
       Me.tbxKj0.Attributes.Item("itName") = "基准"
       Me.tbxKj1.Attributes.Item("itType") = "varchar"
       Me.tbxKj1.Attributes.Item("itLength") = "20"
       Me.tbxKj1.Attributes.Item("itName") = "工差1"
       Me.tbxKj2.Attributes.Item("itType") = "varchar"
       Me.tbxKj2.Attributes.Item("itLength") = "20"
       Me.tbxKj2.Attributes.Item("itName") = "工差2"
       Me.tbxKjExplain.Attributes.Item("itType") = "nvarchar"
       Me.tbxKjExplain.Attributes.Item("itLength") = "200"
       Me.tbxKjExplain.Attributes.Item("itName") = "基准説明"

    End Sub

    ''' <summary>
    ''' 明細項目設定
    ''' </summary>
    public Sub MsInit()
      'EMAB障害対応情報の格納処理
       EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
       MyMethod.GetCurrentMethod.Name)
            '明細設定
            Dim dt As DataTable = GetMsData()
            Me.gvMs.DataSource = dt
            Me.gvMs.DataBind()

    End Sub

    ''' <summary>
    ''' 検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSelect_Click(sender As Object, e As System.EventArgs) Handles btnSelect.Click
        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
                               MyMethod.GetCurrentMethod.Name)

        MsInit()
    End Sub

    ''' <summary>
    ''' 明細データ取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMsData() As Data.DataTable

      'EMAB障害対応情報の格納処理
       EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
       MyMethod.GetCurrentMethod.Name)
       Return BC.SelMTemp(tbxLineId_key.Text, tbxTempId_key.Text, tbxChkMethodId_key.Text)
    End Function

    ''' <summary>
    ''' データ存在チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsHaveData() As Boolean

      'EMAB障害対応情報の格納処理
       EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
       MyMethod.GetCurrentMethod.Name)
       Return BC.SelMTemp(tbxLineId.Text, tbxTempId.Text, tbxChkMethodId.Text).Rows.Count > 0
    End Function

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click

        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
                               MyMethod.GetCurrentMethod.Name)

            Try
       BC.UpdMTemp(hidlineId.Text, hidtempId.Text, hidchkMethodId.Text,tbxlineId.Text, tbxtempId.Text, tbxchkMethodId.Text, tbxprojectId.Text, tbxprojectName.Text, tbxpicId.Text, tbxpicName.Text, tbxchkKmName.Text, tbxpicSign.Text, tbxchkId.Text, tbxchkName.Text, tbxtoolId.Text, tbxkj0.Text, tbxkj1.Text, tbxkj2.Text, tbxkjExplain.Text)
        MsInit()
            Catch ex As Exception
                Common.ShowMsg(Me.Page, ex.Message)
                Exit Sub
            End Try
Me.hidOldRowIdx.Text = ""
    End Sub
    ''' <summary>
    ''' 登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnInsert_Click(sender As Object, e As System.EventArgs) Handles btnInsert.Click
        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
                               MyMethod.GetCurrentMethod.Name)

        'データ存在チェック
            If IsHaveData() Then
                Common.ShowMsg(Me.Page, "データ存在しました。")
                Exit Sub
            End If
            Try
            BC.InsMTemp(tbxlineId.Text, tbxtempId.Text, tbxchkMethodId.Text, tbxprojectId.Text, tbxprojectName.Text, tbxpicId.Text, tbxpicName.Text, tbxchkKmName.Text, tbxpicSign.Text, tbxchkId.Text, tbxchkName.Text, tbxtoolId.Text, tbxkj0.Text, tbxkj1.Text, tbxkj2.Text, tbxkjExplain.Text)
                MsInit()
            Catch ex As Exception
                Common.ShowMsg(Me.Page, ex.Message)
                Exit Sub
            End Try
Me.hidOldRowIdx.Text = ""
    End Sub

    ''' <summary>
    ''' 削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click

        'EMAB障害対応情報の格納処理
        EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
                               MyMethod.GetCurrentMethod.Name)

            Try
       BC.DelMTemp(hidlineId.Text, hidtempId.Text, hidchkMethodId.Text)
        MsInit()
            Catch ex As Exception
                Common.ShowMsg(Me.Page, ex.Message)
                Exit Sub
            End Try
Me.hidOldRowIdx.Text = ""
    End Sub

End Class
