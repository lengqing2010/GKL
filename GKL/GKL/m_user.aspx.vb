Imports System.Data
Imports System.Text
Imports System.IO
Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Partial Class m_user
    Inherits System.Web.UI.Page

   Public BC AS NEW MUserBC
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
        Me.tbxUserCd.Attributes.Item("itType") = "nvarchar"
        Me.tbxUserCd.Attributes.Item("itLength") = "10"
        Me.tbxUserCd.Attributes.Item("itName") = "用户CD"
        Me.tbxLineId.Attributes.Item("itType") = "nvarchar"
        Me.tbxLineId.Attributes.Item("itLength") = "10"
        Me.tbxLineId.Attributes.Item("itName") = "生产线"
        Me.tbxUserName.Attributes.Item("itType") = "nvarchar"
        Me.tbxUserName.Attributes.Item("itLength") = "10"
        Me.tbxUserName.Attributes.Item("itName") = "用户名"

    End Sub

    ''' <summary>
    ''' 明細項目設定
    ''' </summary>
    Public Sub MsInit(Optional ByVal pageIdx As Integer = 1)
        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
        MyMethod.GetCurrentMethod.Name)
        '明細設定
        'Dim dt As DataTable = GetMsData()
        'Me.gvMs.DataSource = dt
        'Me.gvMs.DataBind()


        'EMAB　ＥＲＲ
        EMAB.AddMethodEntrance(Request.ApplicationPath & "." & MyClass.GetType.BaseType.FullName & "." & _
        MyMethod.GetCurrentMethod.Name)
        '明細設定

        Dim dtMs, dtPageIdx As DataTable
        Common.GetPageData(GetMsData(), pageIdx, dtMs, dtPageIdx)

        Me.gvMs.DataSource = dtMs
        Me.gvMs.DataBind()

        ddlPageIdx.DataValueField = "idx"
        ddlPageIdx.DataTextField = "idx"
        Me.ddlPageIdx.DataSource = dtPageIdx
        Me.ddlPageIdx.DataBind()

        lblAllPageText.Text = ddlPageIdx.Items.Count

        If ddlPageIdx.Items.Count > pageIdx Then
            ddlPageIdx.SelectedIndex = pageIdx - 1
        End If


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
        Return BC.SelMUser(tbxUserCd_key.Text)
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
        Return BC.SelMUser(tbxUserCd.Text).Rows.Count > 0
    End Function

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click


            Try
       BC.UpdMUser(hiduserCd.Text,tbxuserCd.Text, tbxlineId.Text, tbxuserName.Text)
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
        If tbxLineId.Text = "" Then
            Common.ShowMsg(Me.Page, "数据没有输入")
            Exit Sub

        End If

        'データ存在チェック
            If IsHaveData() Then
            Common.ShowMsg(Me.Page, "数据已经存在")
                Exit Sub
            End If
            Try
            BC.InsMUser(tbxuserCd.Text, tbxlineId.Text, tbxuserName.Text)
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
       BC.DelMUser(hiduserCd.Text)
        MsInit()
            Catch ex As Exception
                Common.ShowMsg(Me.Page, ex.Message)
                Exit Sub
            End Try
Me.hidOldRowIdx.Text = ""
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Server.Transfer("Default.aspx")
    End Sub

    Protected Sub ddlPageIdx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPageIdx.SelectedIndexChanged
        MsInit(Me.ddlPageIdx.SelectedValue)
    End Sub
End Class
