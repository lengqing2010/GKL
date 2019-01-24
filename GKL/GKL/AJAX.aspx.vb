
Partial Class AJAX
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim kbn As String = Request.QueryString("kbn")

        If kbn = "pic" Then
            Dim BC As New MPictureBC
            Dim dt As Data.DataTable = BC.SelMPicture(Request.QueryString("pic_id"), Request.QueryString("line_id"))
            If dt.Rows.Count > 0 Then
                Response.Write(dt.Rows(0).Item("pic_name"))
            End If
        ElseIf kbn = "chk_method" Then
            Dim BC As New MCheckMethodBC
            Dim dt As Data.DataTable = BC.SelMCheckMethod(Request.QueryString("chk_id"), "")
            If dt.Rows.Count > 0 Then
                Response.Write(dt.Rows(0).Item("chk_name"))
            End If
        ElseIf kbn = "tool" Then
            Dim BC As New MToolsBC
            Dim dt As Data.DataTable = BC.SelMTools(Request.QueryString("tool_id"), Request.QueryString("line_id"))
            If dt.Rows.Count > 0 Then
                Response.Write(dt.Rows(0).Item("tool_name"))
            End If
        ElseIf kbn = "chk_tmp" Then

            Dim BC As New MTempBC
            Dim dt As Data.DataTable = BC.SelMTemp(Request.QueryString("line_id"), Request.QueryString("temp_id"), "")
            If dt.Rows.Count <= 0 Then
                Response.Write("1")
                Response.End()
            End If
            dt = BC.SelMTemp(Request.QueryString("line_id"), Request.QueryString("temp_id_new"), "")
            If dt.Rows.Count > 0 Then
                Response.Write("2")
                Response.End()
            End If

            Dim BC2 As New MTempNameBC
            Dim dt2 As Data.DataTable = BC2.SelMTempName(Request.QueryString("line_id"), Request.QueryString("temp_id_new"))
            If dt2.Rows.Count <= 0 Then
                Response.Write("3")
                Response.End()
            End If
        ElseIf kbn = "user" Then
            Dim BC As New MUserBC
            Dim dt As Data.DataTable = BC.SelMUser(Request.QueryString("user_cd"), "ajax")
            If dt.Rows.Count > 0 Then
                Response.Write(dt.Rows(0).Item("user_name") & "," & dt.Rows(0).Item("line_id"))
                Response.End()
            End If
        ElseIf kbn = "chk_ms_upd" Then

            Dim chkNo_key As String = Request.Form("chkNo_key")
            Dim in1 As String = Request.Form("in1")
            Dim chkResult As String = Request.Form("chkResult")
            Dim mark As String = Request.Form("mark")
            Dim kj0 As String = Request.Form("kj0")
            Dim kj1 As String = Request.Form("kj1")
            Dim kj2 As String = Request.Form("kj2")
            Dim insUser As String = Request.Form("insUser")
            Dim line_id As String = Request.Form("line_id")
            Dim chk_method_id As String = Request.Form("chk_method_id")
            Dim BC As New TCheckMsBC
            BC.UpdTCheckMs(chkNo_key, _
                               in1, _
                               chkResult, _
                               mark, _
                               kj0, _
                               kj1, _
                               kj2, _
                               insUser, _
                               line_id, chk_method_id)
        ElseIf kbn = "lines" Then
            Response.Write(Common.LineIds)

        ElseIf kbn = "tempsIds" Then

            Dim line_id As String = Request.QueryString("line_id")
            Response.Write(Common.TempIds(line_id))

        End If


        Response.End()

    End Sub
End Class
