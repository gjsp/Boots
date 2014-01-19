
Partial Class report_model_area
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
                ds = clsBts.getModelMtdArea(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddlRate.SelectedValue)
                ucReport.ReportType = clsBts.reportType.MTD.ToString
            Else
                ds = clsBts.getModelYtdArea(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddlRate.SelectedValue)
                ucReport.ReportType = clsBts.reportType.YTD.ToString
            End If
            ucReport.ReportName = ucReport.ReportType + " Area Report"
            ucReport.iMonth = ddlMonth.SelectedValue
            ucReport.iYear = ddlYear.SelectedValue
            ucReport.ItemScrollWidth = 1100
            ucReport.ExcelTopic = ddlBy.SelectedItem.Text + " " + ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedItem.Text + "&nbsp;&nbsp;&nbsp;&nbsp;Currency Rate " + ddlRate.SelectedItem.Text
            ucReport.LoadReport(ds)
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

End Class
