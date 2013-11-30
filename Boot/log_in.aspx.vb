
Partial Class log_in
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("mode") IsNot Nothing Then
                If Request.QueryString("mode").ToString = "logout" Then
                    Session.Clear()
                End If
            End If
            txt_username.Focus()
        End If
    End Sub
    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        'If txt_username.Text = "" Then
        '    clsManage.alert("กรุณากรอกรหัสผู้ใช้งาน !!!", Page)
        '    Exit Sub
        'End If

        'If txt_password.Text = "" Then
        '    clsManage.alert("กรุณากรอกรหัสผ่าน !!!", Page)
        '    Exit Sub
        'End If

        Try
            Dim dt As Data.DataTable
            dt = clsDB.getUserLogin(txt_username.Text.Trim, txt_password.Text.Trim)
            If dt.Rows.Count > 0 Then
                Session("user_id") = dt.Rows(0)("users_id")
                Session("user_name") = dt.Rows(0)("users_name")
                Session("user_type") = dt.Rows(0)("users_type")
                Response.Redirect("Home.aspx")
            Else

                ClsManage.alert(Page, "Username Or Password Invalid Please Try Again.")
            End If

        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

End Class
