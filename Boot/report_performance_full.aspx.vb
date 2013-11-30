
Partial Class report_performance_full
    Inherits basePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Y.2009/10

            clsPfm.getDDLFullYear(ddlYear)
            ClsDB.getCurrentcyToDDL(ddlRate)
        End If
    End Sub

    Protected Sub SearchBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchBt.Click
        Try
            Dim ds As New Data.DataSet
            Dim bDate As String = "1/4/" + ddlYear.SelectedValue

            ds = clsPfm.getPerformanceFull(bDate, ddlRate.SelectedValue)
            ucFullPer.ReportType = clsBts.reportType.ByFormat.ToString
            ucFullPer.ReportName = "Full Year Store Performance Report"
            ucFullPer.ReportTopicTotal = ddlYear.SelectedItem.Text

            ucFullPer.iMonth = 4
            ucFullPer.iYear = ddlYear.SelectedValue
           
            ucFullPer.ItemScrollWidth = 980
            ucFullPer.LoadReport(ds)
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

End Class
