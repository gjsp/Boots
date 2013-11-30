
Partial Class manage_area
    Inherits basePage

    Protected Sub ImgDel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value
        ClsDB.DelAreaById(id)
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("ImgDel"), ImageButton).Attributes.Add("onclick", "return confirm('Do you want to delete.');")
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
        daStore = ClsDB.getAreaById(id)

        EditTxt.Text = daStore.Rows(0)("area_name").ToString
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
            ClsDB.InsertArea(AddTxt.Text)
            Return True
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Function
    Protected Sub AddBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddBt.Click
        Try
            If saveData() Then
                ClsManage.alert(Page, "Save Complete", , "manage_area.aspx")
            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Function updateData() As Boolean
        Try
            ClsDB.UpdateArea(HdID.Value, EditTxt.Text)
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
