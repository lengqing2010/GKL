Imports System.Data
Imports System.Text
Imports System.IO

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
       
       
       Me.tbxLineId.Attributes.Item("itType") = "varchar"
       Me.tbxLineId.Attributes.Item("itLength") = "10"
       Me.tbxLineId.Attributes.Item("itName") = "生产线"
       Me.tbxTempId.Attributes.Item("itType") = "nvarchar"
       Me.tbxTempId.Attributes.Item("itLength") = "10"
       Me.tbxTempId.Attributes.Item("itName") = "检查模板编号"
       Me.tbxChkMethodId.Attributes.Item("itType") = "varchar"
       Me.tbxChkMethodId.Attributes.Item("itLength") = "10"
       Me.tbxChkMethodId.Attributes.Item("itName") = "检查项目ID"
       Me.tbxProjectId.Attributes.Item("itType") = "varchar"
       Me.tbxProjectId.Attributes.Item("itLength") = "10"
       Me.tbxProjectId.Attributes.Item("itName") = "工程ID"
       Me.tbxProjectName.Attributes.Item("itType") = "varchar"
       Me.tbxProjectName.Attributes.Item("itLength") = "40"
       Me.tbxProjectName.Attributes.Item("itName") = "工程名"
       Me.tbxPicId.Attributes.Item("itType") = "varchar"
       Me.tbxPicId.Attributes.Item("itLength") = "10"
       Me.tbxPicId.Attributes.Item("itName") = "图片ID"
       Me.tbxPicName.Attributes.Item("itType") = "varchar"
       Me.tbxPicName.Attributes.Item("itLength") = "200"
       Me.tbxPicName.Attributes.Item("itName") = "图片名称"
       Me.tbxChkKmName.Attributes.Item("itType") = "varchar"
       Me.tbxChkKmName.Attributes.Item("itLength") = "200"
       Me.tbxChkKmName.Attributes.Item("itName") = "检查项目"
       Me.tbxPicSign.Attributes.Item("itType") = "varchar"
       Me.tbxPicSign.Attributes.Item("itLength") = "10"
       Me.tbxPicSign.Attributes.Item("itName") = "图片标记"
       Me.tbxChkId.Attributes.Item("itType") = "varchar"
       Me.tbxChkId.Attributes.Item("itLength") = "10"
       Me.tbxChkId.Attributes.Item("itName") = "检查方法ID"
       Me.tbxChkName.Attributes.Item("itType") = "varchar"
       Me.tbxChkName.Attributes.Item("itLength") = "20"
       Me.tbxChkName.Attributes.Item("itName") = "检查方法名"
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
      'EMAB　ＥＲＲ
       
       
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
       
       
       Return BC.SelMTemp(tbxLineId_key.Text, tbxTempId_key.Text, tbxChkMethodId_key.Text)
    End Function

    ''' <summary>
    ''' データ存在チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsHaveData() As Boolean

      'EMAB　ＥＲＲ
       
       
       Return BC.SelMTemp(tbxLineId.Text, tbxTempId.Text, tbxChkMethodId.Text).Rows.Count > 0
    End Function

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click


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
            BC.InsMTemp(tbxLineId.Text, tbxTempId.Text, tbxChkMethodId.Text, tbxProjectId.Text, tbxProjectName.Text, tbxPicId.Text, tbxPicName.Text, tbxChkKmName.Text, tbxPicSign.Text, tbxChkId.Text, tbxChkName.Text, tbxToolId.Text, tbxKj0.Text, tbxKj1.Text, tbxKj2.Text, tbxKjExplain.Text)
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
            BC.DelMTemp(hidLineId.Text, hidTempId.Text, hidChkMethodId.Text)
            MsInit()
        Catch ex As Exception
            Common.ShowMsg(Me.Page, ex.Message)
            Exit Sub
        End Try
        Me.hidOldRowIdx.Text = ""
    End Sub

    Protected Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click

        If Me.tbxLineId.Text.Trim = "" Then
            Common.ShowMsg(Me.Page, "请输入生产线")
            Exit Sub
        End If
        If Me.tbxTempId.Text.Trim = "" Then
            Common.ShowMsg(Me.Page, "请输模板编号")
            Exit Sub
        End If
        If Me.tbxTempId_new.Text.Trim = "" Then
            Common.ShowMsg(Me.Page, "请输新模板编号")
            Exit Sub
        End If

        Try
            BC.CopyTemp(tbxLineId.Text.Trim, Me.tbxTempId.Text.Trim, Me.tbxTempId_new.Text.Trim)
        Catch ex As Exception
            Common.ShowMsg(Me.Page, ex.Message)
            Exit Sub
        End Try


    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Server.Transfer("Default.aspx")
    End Sub
End Class
