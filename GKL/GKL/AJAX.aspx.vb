
Partial Class AJAX
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim BC As New MPictureBC
        Dim dt As Data.DataTable = BC.SelMPicture(Request.QueryString("pic_id"), Request.QueryString("line_id"))

        If dt.Rows.Count > 0 Then

            Response.Write(dt.Rows(0).Item("pic_name"))
        End If

        Response.End()

    End Sub
End Class
