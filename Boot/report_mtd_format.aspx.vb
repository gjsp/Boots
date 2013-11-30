
Partial Class report_mtd_format
    Inherits basePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            ddlYear.DataValueField = "mon_year"
            ddlYear.DataTextField = "mon_year"
            ddlYear.DataSource = ClsDB.getMtdYear()
            ddlYear.DataBind()

            ddlMonth.DataValueField = "mon_year"
            ddlMonth.DataTextField = "mon_name"
            ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
            ddlMonth.DataBind()

            ddlYear2.DataValueField = "mon_year"
            ddlYear2.DataTextField = "mon_year"
            ddlYear2.DataSource = ClsDB.getMtdYear()
            ddlYear2.DataBind()

            ddlMonth2.DataValueField = "mon_year"
            ddlMonth2.DataTextField = "mon_name"
            ddlMonth2.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
            ddlMonth2.DataBind()

            ddllo.DataValueField = "location_id"
            ddllo.DataTextField = "location_name"
            ddllo.DataSource = ClsDB.getLocation()
            ddllo.DataBind()
            ddllo.Items.Insert(0, New ListItem("All", ""))

            ddlstore.DataValueField = "store_id"
            ddlstore.DataTextField = "store_name"
            ddlstore.DataSource = ClsDB.getStore()
            ddlstore.DataBind()
            ddlstore.Items.Insert(0, New ListItem("All", ""))

            ClsDB.getCurrentcyToDDL(ddlRate)

        End If
    End Sub


    Protected Sub SearchBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchBt.Click
        Try
            Dim ds As New Data.DataSet

            Dim bDate As String = "1/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue
            Dim eDate As String = "1/" + ddlMonth2.SelectedValue + "/" + ddlYear2.SelectedValue

            ds = clsBts.getModelByFormat(bDate, eDate, ddllo.SelectedValue, ddlstore.SelectedValue, ddlRate.SelectedValue)
            ucModel.ReportType = clsBts.reportType.ByFormat.ToString
          
            ucModel.ReportName = "Model By Store Report"
            ucModel.iMonth = ddlMonth.SelectedValue
            ucModel.iYear = ddlYear.SelectedValue
            ucModel.iMonth2 = ddlMonth2.SelectedValue
            ucModel.iYear2 = ddlYear2.SelectedValue
            ucModel.ItemScrollWidth = 1100
            ucModel.LoadReport(ds)
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub ddlYear2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear2.SelectedIndexChanged
        ddlMonth2.DataValueField = "mon_year"
        ddlMonth2.DataTextField = "mon_name"
        ddlMonth2.DataSource = ClsDB.getMtdMonth(ddlYear2.SelectedValue)
        ddlMonth2.DataBind()
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        ddlMonth.DataValueField = "mon_year"
        ddlMonth.DataTextField = "mon_name"
        ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
        ddlMonth.DataBind()
    End Sub
End Class
