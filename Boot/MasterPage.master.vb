
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user_type") = "ADMIN" Then
            users_admin.Visible = True
            users_admin2.Visible = True
        Else
            users_admin.Visible = False
            users_admin2.Visible = False
        End If
    End Sub
End Class

