Imports Microsoft.VisualBasic

Public Class Common
    Public Shared Sub ShowMsg(ByVal page As Page, ByVal msg As String)

        Dim csScript As New StringBuilder

        With csScript
            .AppendLine("alert('" & msg & "');")
        End With

        'ページ応答で、クライアント側のスクリプト ブロックを出力します
        page.ClientScript.RegisterStartupScript(page.GetType(), "ShowMessage", csScript.ToString, True)

    End Sub
End Class
