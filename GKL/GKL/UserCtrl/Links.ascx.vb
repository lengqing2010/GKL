
Partial Class UserCtrl_Links
    Inherits System.Web.UI.UserControl

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

    Protected Sub lbRelation_Click(sender As Object, e As EventArgs) Handles lbRelation.Click
        Server.Transfer("t_cd_temp_relation.aspx")
    End Sub

    Protected Sub lbPlan_Click(sender As Object, e As EventArgs) Handles lbPlan.Click
        Server.Transfer("t_check_plan.aspx")
    End Sub

    Protected Sub lbTemp_Click(sender As Object, e As EventArgs) Handles lbTemp.Click
        Server.Transfer("m_temp.aspx")
    End Sub

    'Protected Sub lbPic_Click(sender As Object, e As EventArgs) Handles lbPic.Click

    'End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        '    'Me.lbPic.Attributes.Item("HREF") = ConfigurationManager.AppSettings("PicPath").ToString()

        '    Me.lbPic.Attributes.Item("onclick") = "window.open('AppDownLoad.aspx', 'newwindow', 'height=100, width=600, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=n o, status=no');return false;"


        'End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Server.Transfer("CheckItiran.aspx")
    End Sub

    Protected Sub lbMenu_Click(sender As Object, e As EventArgs) Handles lbMenu.Click
        Server.Transfer("Default.aspx")
    End Sub
End Class
