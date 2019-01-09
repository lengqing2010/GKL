
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

        End If


        Response.End()

    End Sub
End Class
