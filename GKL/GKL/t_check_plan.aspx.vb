Imports System.Data
Imports System.Text
Imports System.IO
Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Partial Class t_check_plan
    Inherits System.Web.UI.Page

   Public BC AS NEW TCheckPlanBC
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
       Me.tbxPlanNo.Attributes.Item("itType") = "varchar"
       Me.tbxPlanNo.Attributes.Item("itLength") = "20"
       Me.tbxPlanNo.Attributes.Item("itName") = "??No"
       Me.tbxChkNo.Attributes.Item("itType") = "varchar"
       Me.tbxChkNo.Attributes.Item("itLength") = "20"
       Me.tbxChkNo.Attributes.Item("itName") = "??No"
       Me.tbxMakeNo.Attributes.Item("itType") = "varchar"
       Me.tbxMakeNo.Attributes.Item("itLength") = "20"
       Me.tbxMakeNo.Attributes.Item("itName") = "作番"
       Me.tbxCode.Attributes.Item("itType") = "varchar"
       Me.tbxCode.Attributes.Item("itLength") = "20"
       Me.tbxCode.Attributes.Item("itName") = "コード"
       Me.tbxLineId.Attributes.Item("itType") = "varchar"
       Me.tbxLineId.Attributes.Item("itLength") = "10"
       Me.tbxLineId.Attributes.Item("itName") = "生??"
       Me.tbxSuu.Attributes.Item("itType") = "varchar"
       Me.tbxSuu.Attributes.Item("itLength") = "10"
       Me.tbxSuu.Attributes.Item("itName") = "数量"
       Me.tbxYoteiChkDate.Attributes.Item("itType") = "varchar"
       Me.tbxYoteiChkDate.Attributes.Item("itLength") = "20"
       Me.tbxYoteiChkDate.Attributes.Item("itName") = "????日"
       Me.tbxStatus.Attributes.Item("itType") = "varchar"
       Me.tbxStatus.Attributes.Item("itLength") = "1"
       Me.tbxStatus.Attributes.Item("itName") = "状?"
       Me.tbxInsUser.Attributes.Item("itType") = "varchar"
       Me.tbxInsUser.Attributes.Item("itLength") = "20"
       Me.tbxInsUser.Attributes.Item("itName") = "登録者"
       Me.tbxInsDate.Attributes.Item("itType") = "varchar"
       Me.tbxInsDate.Attributes.Item("itLength") = "20"
       Me.tbxInsDate.Attributes.Item("itName") = "登録日"

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
       Return BC.SelTCheckPlan(tbxPlanNo_key.Text, tbxChkNo_key.Text, tbxMakeNo_key.Text, tbxCode_key.Text, tbxLineId_key.Text)
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
       Return BC.SelTCheckPlan(tbxPlanNo.Text, tbxChkNo.Text, tbxMakeNo.Text, tbxCode.Text, tbxLineId.Text).Rows.Count > 0
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
       BC.UpdTCheckPlan(hidplanNo.Text, hidchkNo.Text, hidmakeNo.Text, hidcode.Text, hidlineId.Text,tbxplanNo.Text, tbxchkNo.Text, tbxmakeNo.Text, tbxcode.Text, tbxlineId.Text, tbxsuu.Text, tbxyoteiChkDate.Text, tbxstatus.Text, tbxinsUser.Text, tbxinsDate.Text)
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
            BC.InsTCheckPlan(tbxplanNo.Text, tbxchkNo.Text, tbxmakeNo.Text, tbxcode.Text, tbxlineId.Text, tbxsuu.Text, tbxyoteiChkDate.Text, tbxstatus.Text, tbxinsUser.Text, tbxinsDate.Text)
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
       BC.DelTCheckPlan(hidplanNo.Text, hidchkNo.Text, hidmakeNo.Text, hidcode.Text, hidlineId.Text)
        MsInit()
            Catch ex As Exception
                Common.ShowMsg(Me.Page, ex.Message)
                Exit Sub
            End Try
Me.hidOldRowIdx.Text = ""
    End Sub

End Class
