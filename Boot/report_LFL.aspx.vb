
Partial Class report_LFL
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

            ddllo.DataValueField = "location_id"
            ddllo.DataTextField = "location_name"
            ddllo.DataSource = ClsDB.getLocation()
            ddllo.DataBind()
            ddllo.Items.Insert(0, New ListItem("All", ""))

            ClsDB.getCurrentcyToDDL(ddlRate)

        End If
    End Sub

    Protected Sub ddlYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYear.TextChanged
        ddlMonth.DataValueField = "mon_year"
        ddlMonth.DataTextField = "mon_name"
        ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
        ddlMonth.DataBind()
    End Sub

    Protected Sub SearchBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchBt.Click
        Try
            Dim ds As New Data.DataSet
            If ddlBy.SelectedIndex = 0 Then
                ds = clsBts.getModelMtd(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddllo.SelectedValue, ddlRate.SelectedValue)
                ucModel.ReportType = clsBts.reportType.MTD.ToString
            ElseIf ddlBy.SelectedIndex = 1 Then
                ds = clsBts.getModelYtd(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddllo.SelectedValue, ddlRate.SelectedValue)
                ucModel.ReportType = clsBts.reportType.YTD.ToString
            End If
            ucModel.ReportName = ucModel.ReportType + " Model Report"
            ucModel.iMonth = ddlMonth.SelectedValue
            ucModel.iYear = ddlYear.SelectedValue
            ucModel.ItemScrollWidth = 1100
            ucModel.LoadReport(ds)
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

End Class
