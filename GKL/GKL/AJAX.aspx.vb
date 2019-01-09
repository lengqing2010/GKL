
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

        End If


        Response.End()

    End Sub
End Class
