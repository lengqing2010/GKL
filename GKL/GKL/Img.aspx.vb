Imports System.Data

Partial Class Img
    Inherits System.Web.UI.Page

    Private MPictureBC As New MPictureBC

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim bt As Byte()
   
                bt = DirectCast(MPictureBC.GetLineListPic(Request.QueryString("pic_id"), Request.QueryString("line_id")), Byte())
                Response.BinaryWrite(bt)
      
            Response.End()
        Catch ex As Exception
        End Try

    End Sub






End Class
