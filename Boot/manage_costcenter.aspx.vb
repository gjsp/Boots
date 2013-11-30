
Partial Class manage_costcenter
    Inherits basePage

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("ImgDel"), ImageButton).Attributes.Add("onclick", "return confirm('Do you want to delete.');")
            e.Row.Cells(7).Text = ClsManage.convert2Currency(e.Row.DataItem("costcenter_total_area")).ToString
            e.Row.Cells(8).Text = ClsManage.convert2Currency(e.Row.DataItem("costcenter_sale_area")).ToString
            e.Row.Cells(9).Text = DateValue(e.Row.DataItem("costcenter_opendt")).ToString("d/M/yyyy")
            If e.Row.DataItem("costcenter_blockdt") Is DBNull.Value Then
                e.Row.Cells(10).Text = "None"
            Else
                e.Row.Cells(10).Text = DateValue(e.Row.DataItem("costcenter_blockdt")).ToString("d/M/yyyy")
            End If


        End If
    End Sub

    Protected Sub ImgDel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value
        ClsDB.DelCostcenter(id)
        GridView1.DataBind()
    End Sub

    Protected Sub Imgedit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value
        Response.Redirect("edit_costcenter.aspx?id=" + id)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ddlarea.DataValueField = "area_id"
            ddlarea.DataTextField = "area_name"
            ddlarea.DataSource = ClsDB.getArea()
            ddlarea.DataBind()
            ddlarea.Items.Add(New ListItem("All", "0"))
            ddlarea.SelectedValue = 0


            ddllocation.DataValueField = "location_id"
            ddllocation.DataTextField = "location_name"
            ddllocation.DataSource = ClsDB.getLocation()
            ddllocation.DataBind()
            ddllocation.Items.Add(New ListItem("All", "0"))
            ddllocation.SelectedValue = 0

            ddlprovince.DataValueField = "province_id"
            ddlprovince.DataTextField = "province_name"
            ddlprovince.DataSource = ClsDB.getProvinceOname()
            ddlprovince.DataBind()
            ddlprovince.Items.Add(New ListItem("All", "0"))
            ddlprovince.SelectedValue = 0

            ddlstore.DataValueField = "store_id"
            ddlstore.DataTextField = "store_name"
            ddlstore.DataSource = ClsDB.getStore()
            ddlstore.DataBind()
            ddlstore.Items.Add(New ListItem("All", "0"))
            ddlstore.SelectedValue = 0

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ObjectDataSource1.SelectParameters("title").DefaultValue = SearchTxt.Text
        ObjectDataSource1.SelectParameters("area").DefaultValue = ddlarea.SelectedValue
        ObjectDataSource1.SelectParameters("location").DefaultValue = ddllocation.SelectedValue
        ObjectDataSource1.SelectParameters("province").DefaultValue = ddlprovince.SelectedValue
        ObjectDataSource1.SelectParameters("store").DefaultValue = ddlstore.SelectedValue
        GridView1.EmptyDataText = "No Data"
        GridView1.DataBind()
    End Sub


End Class
