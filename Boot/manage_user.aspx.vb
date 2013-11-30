
Partial Class manage_user
    Inherits basePage
    Protected Sub ImgDel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value
        ClsDB.DelUsersDataById(id)
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("ImgDel"), ImageButton).Attributes.Add("onclick", "return confirm('Do you want to delete.');")
            e.Row.Cells(1).Text = "****"
        End If
    End Sub

    Protected Sub AddNewBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddNewBt.Click
        Panel2.Visible = False
        If Panel1.Visible = True Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If
    End Sub

    Protected Sub Imgedit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value

        Panel1.Visible = False
        Panel2.Visible = True

        Dim daStore As Data.DataTable
        daStore = ClsDB.getUserDataById(id)

        EditTxt.Text = daStore.Rows(0)("users_name").ToString
        EditPassTxt.Text = daStore.Rows(0)("users_pass").ToString
        HdID.Value = id

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Panel1.Visible = False
            Panel2.Visible = False
        End If
    End Sub

    Function saveData() As Boolean
        Try
            ClsDB.InsertUserData(AddUserTxt.Text.Trim, AddPassTxt.Text.Trim)
            Return True
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Function

    Protected Sub AddBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddBt.Click
        Try
            Dim da As Data.DataTable
            da = ClsDB.getUserDataByName(AddUserTxt.Text)
            If da.Rows.Count > 0 Then
                ClsManage.alert(Page, "Duplicate User", , )
            Else
                If saveData() Then
                    ClsManage.alert(Page, "Save Complete", , "manage_user.aspx")
                End If
            End If
            
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Function updateData() As Boolean
        Try
            ClsDB.UpdateUserdata(HdID.Value, EditPassTxt.Text.Trim)
            Return True
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Function

    Protected Sub EditBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBt.Click
        Try
            If updateData() Then
                ClsManage.alert(Page, "Update Complete", , )
                GridView1.DataBind()
                Panel2.Visible = False
            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub
End Class
