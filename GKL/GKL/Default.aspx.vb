
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub lbUser_Click(sender As Object, e As EventArgs) Handles lbUser.Click
        Server.Transfer("m_user.aspx")
    End Sub


    Protected Sub lbProject_Click(sender As Object, e As EventArgs) Handles lbProject.Click
        Server.Transfer("m_project.aspx")
    End Sub

    Protected Sub lbTools_Click(sender As Object, e As EventArgs) Handles lbTools.Click
        Server.Transfer("m_tools.aspx")
    End Sub

    Protected Sub lbCheckMethod_Click(sender As Object, e As EventArgs) Handles lbCheckMethod.Click
        Server.Transfer("m_check_method.aspx")
    End Sub
End Class
