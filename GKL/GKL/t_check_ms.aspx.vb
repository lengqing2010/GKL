Imports System.Data
Imports System.Text
Imports System.IO
Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Partial Class t_check_ms
    Inherits System.Web.UI.Page

   Public BC AS NEW TCheckMsBC
    ''' <summary>
    ''' PAGE LOAD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


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
      'EMAB　ＥＲＲ
       EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
       MyMethod.GetCurrentMethod.Name)
       Me.tbxChkNo.Attributes.Item("itType") = "varchar"
       Me.tbxChkNo.Attributes.Item("itLength") = "20"
       Me.tbxChkNo.Attributes.Item("itName") = "检查No"
       Me.tbxChkMethodId.Attributes.Item("itType") = "varchar"
       Me.tbxChkMethodId.Attributes.Item("itLength") = "10"
       Me.tbxChkMethodId.Attributes.Item("itName") = "检查项目ID"
       Me.tbxChkFlg.Attributes.Item("itType") = "varchar"
       Me.tbxChkFlg.Attributes.Item("itLength") = "1"
       Me.tbxChkFlg.Attributes.Item("itName") = "检查flg"
       Me.tbxIn1.Attributes.Item("itType") = "varchar"
       Me.tbxIn1.Attributes.Item("itLength") = "20"
       Me.tbxIn1.Attributes.Item("itName") = "入力値1"
       Me.tbxIn2.Attributes.Item("itType") = "varchar"
       Me.tbxIn2.Attributes.Item("itLength") = "20"
       Me.tbxIn2.Attributes.Item("itName") = "入力値2"
       Me.tbxChkResult.Attributes.Item("itType") = "varchar"
       Me.tbxChkResult.Attributes.Item("itLength") = "20"
       Me.tbxChkResult.Attributes.Item("itName") = "检查结果"
       Me.tbxMark.Attributes.Item("itType") = "nvarchar"
       Me.tbxMark.Attributes.Item("itLength") = "200"
       Me.tbxMark.Attributes.Item("itName") = "备考"
       Me.tbxKj0.Attributes.Item("itType") = "nvarchar"
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
       Me.tbxInsUser.Attributes.Item("itType") = "varchar"
       Me.tbxInsUser.Attributes.Item("itLength") = "20"
       Me.tbxInsUser.Attributes.Item("itName") = "登録者"
       Me.tbxInsDate.Attributes.Item("itType") = "date"
       Me.tbxInsDate.Attributes.Item("itLength") = "3"
       Me.tbxInsDate.Attributes.Item("itName") = "登録日"

    End Sub

    ''' <summary>
    ''' 明細項目設定
    ''' </summary>
    public Sub MsInit()
      'EMAB　ＥＲＲ
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

        MsInit()
    End Sub

    ''' <summary>
    ''' 明細データ取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMsData() As Data.DataTable

      'EMAB　ＥＲＲ
       EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
       MyMethod.GetCurrentMethod.Name)
       Return BC.SelTCheckMs(tbxChkNo_key.Text)
    End Function

    ''' <summary>
    ''' データ存在チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsHaveData() As Boolean

      'EMAB　ＥＲＲ
       EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
       MyMethod.GetCurrentMethod.Name)
       Return BC.SelTCheckMs(tbxChkNo.Text).Rows.Count > 0
    End Function

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click


            Try
       BC.UpdTCheckMs(hidchkNo.Text,tbxchkNo.Text, tbxchkMethodId.Text, tbxchkFlg.Text, tbxin1.Text, tbxin2.Text, tbxchkResult.Text, tbxmark.Text, tbxkj0.Text, tbxkj1.Text, tbxkj2.Text, tbxkjExplain.Text, tbxinsUser.Text, tbxinsDate.Text)
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

        'データ存在チェック
            If IsHaveData() Then
                Common.ShowMsg(Me.Page, "データ存在しました。")
                Exit Sub
            End If
            Try
            BC.InsTCheckMs(tbxchkNo.Text, tbxchkMethodId.Text, tbxchkFlg.Text, tbxin1.Text, tbxin2.Text, tbxchkResult.Text, tbxmark.Text, tbxkj0.Text, tbxkj1.Text, tbxkj2.Text, tbxkjExplain.Text, tbxinsUser.Text, tbxinsDate.Text)
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


            Try
       BC.DelTCheckMs(hidchkNo.Text)
        MsInit()
            Catch ex As Exception
                Common.ShowMsg(Me.Page, ex.Message)
                Exit Sub
            End Try
Me.hidOldRowIdx.Text = ""
    End Sub

End Class
