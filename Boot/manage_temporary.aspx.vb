
Partial Class manage_temporary
    Inherits basePage
    Protected Sub ImgDel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value
        ClsDB.DelTempcById(id)
        GridView1.DataBind()
        Panel1.Visible = False
        Panel2.Visible = False
        TxtEnddt.Text = String.Empty
        TxtOpendt.Text = String.Empty
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
        daStore = ClsDB.getTempcByTid(id)
        If daStore.Rows(0)("tempc_start") IsNot DBNull.Value Then
            TxtEOpendt.Text = DateValue(daStore.Rows(0)("tempc_start")).ToString("d/M/yyyy")
        Else
            TxtEOpendt.Text = ""
        End If
        If daStore.Rows(0)("tempc_finish") IsNot DBNull.Value Then
            TxtEEnddt.Text = DateValue(daStore.Rows(0)("tempc_finish")).ToString("d/M/yyyy")
        Else
            TxtEEnddt.Text = ""
        End If
        HdID.Value = id

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Panel1.Visible = False
            Panel2.Visible = False

            ddlstore.DataValueField = "costcenter_id"
            ddlstore.DataTextField = "con_name"
            ddlstore.DataSource = ClsDB.getCostcenterInReport()
            ddlstore.DataBind()

            ObjectDataSource1.SelectParameters("id").DefaultValue = ddlstore.SelectedValue
            GridView1.EmptyDataText = "No Data"
            GridView1.DataBind()
        End If
    End Sub

    Function saveData() As Boolean
        Try
            ClsDB.InsertTempc(ddlstore.SelectedValue, TxtOpendt.Text, TxtEnddt.Text)
            Return True
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Function

    Protected Sub AddBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddBt.Click
        Try
            If saveData() Then
                ClsManage.alert(Page, "Save Complete", , )
                GridView1.DataBind()
                Panel1.Visible = False
                Panel2.Visible = False
                TxtEnddt.Text = String.Empty
                TxtOpendt.Text = String.Empty
            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Function updateData() As Boolean
        Try
            ClsDB.UpdateTempc(HdID.Value, TxtEOpendt.Text, TxtEEnddt.Text)
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
                TxtEnddt.Text = String.Empty
                TxtOpendt.Text = String.Empty
            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub ddlstore_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstore.TextChanged
        ObjectDataSource1.SelectParameters("id").DefaultValue = ddlstore.SelectedValue
        GridView1.EmptyDataText = "No Data"
        GridView1.DataBind()
    End Sub

    Protected Sub ddlstore_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstore.SelectedIndexChanged
        ObjectDataSource1.SelectParameters("id").DefaultValue = ddlstore.SelectedValue
        GridView1.EmptyDataText = "No Data"
        GridView1.DataBind()
    End Sub
End Class
