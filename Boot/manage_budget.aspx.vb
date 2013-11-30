
Partial Class manage_budget
    Inherits basePage

    Protected Sub ImgDel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        'Dim id As String = GridView1.DataKeys(i).Value
        'ClsDB.DelTempcById(id)
        'GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("ImgDel"), ImageButton).Attributes.Add("onclick", "return confirm('Do you want to delete.');")
        End If
    End Sub

    Protected Sub AddNewBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddNewBt.Click
        Response.Redirect("add_budget.aspx?sid=" + ddlstore.SelectedValue)
    End Sub

    Protected Sub Imgedit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            ddlstore.DataValueField = "costcenter_id"
            ddlstore.DataTextField = "con_name"
            ddlstore.DataSource = ClsDB.getCostcenterInReport()
            ddlstore.DataBind()

            ObjectDataSource1.SelectParameters("id").DefaultValue = ddlstore.SelectedValue
            GridView1.EmptyDataText = "No Data"
            GridView1.DataBind()
        End If
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
