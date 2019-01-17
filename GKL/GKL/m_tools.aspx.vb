Imports System.Data
Imports System.Text
Imports System.IO

Partial Class m_tools
    Inherits System.Web.UI.Page

   Public BC AS NEW MToolsBC
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

       Me.tbxToolId.Attributes.Item("itType") = "varchar"
       Me.tbxToolId.Attributes.Item("itLength") = "40"
       Me.tbxToolId.Attributes.Item("itName") = "治具ID"
       Me.tbxLineId.Attributes.Item("itType") = "varchar"
       Me.tbxLineId.Attributes.Item("itLength") = "10"
       Me.tbxLineId.Attributes.Item("itName") = "生产线"
       Me.tbxProjectName.Attributes.Item("itType") = "nvarchar"
       Me.tbxProjectName.Attributes.Item("itLength") = "40"
       Me.tbxProjectName.Attributes.Item("itName") = "工程"
       Me.tbxToolName.Attributes.Item("itType") = "nvarchar"
       Me.tbxToolName.Attributes.Item("itLength") = "80"
       Me.tbxToolName.Attributes.Item("itName") = "治具显示文本"

    End Sub

    ''' <summary>
    ''' 明細項目設定
    ''' </summary>
    public Sub MsInit()

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


       Return BC.SelMTools(tbxToolId_key.Text, tbxLineId_key.Text)
    End Function

    ''' <summary>
    ''' データ存在チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsHaveData() As Boolean
        Return BC.SelMTools(tbxToolId.Text, tbxLineId.Text).Rows.Count > 0
    End Function

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click


            Try
       BC.UpdMTools(hidtoolId.Text, hidlineId.Text,tbxtoolId.Text, tbxlineId.Text, tbxprojectName.Text, tbxtoolName.Text)
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
            BC.InsMTools(tbxtoolId.Text, tbxlineId.Text, tbxprojectName.Text, tbxtoolName.Text)
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
       BC.DelMTools(hidtoolId.Text, hidlineId.Text)
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
End Class
