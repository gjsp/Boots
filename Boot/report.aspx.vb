
Partial Class report
    Inherits basePage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("user_id") IsNot Nothing Then
                If Session("user_name").ToString.ToLower = "admin" Then
                    pnAdmin.Visible = True
                Else
                    pnAdmin.Visible = False
                End If
            End If

        End If
    End Sub
End Class
