Imports Microsoft.VisualBasic

Public Class basePage
    Inherits System.Web.UI.Page

    'Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    'End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        '... add custom logic here ...
        'Session("user_id") = dt.Rows(0)("users_id")
        'Session("user_name") = dt.Rows(0)("users_name")
        If Session("user_id") Is Nothing Then
            ClsManage.alert(Page, "Please Login.", , "log_in.aspx")
        End If
        'Be sure to call the base class's OnLoad method!
        MyBase.OnLoad(e)
    End Sub


End Class
