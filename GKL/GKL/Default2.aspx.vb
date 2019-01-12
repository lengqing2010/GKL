
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyNumber As Double = 2.000000001
        MsgBox(Math.Ceiling(MyNumber))
    End Sub
End Class
