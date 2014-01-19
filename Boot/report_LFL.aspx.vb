
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
            Dim bDate As String = "1/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue
            Dim eDate As String = bDate

            Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
            Dim endDate As DateTime = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing)

            If ddlBy.SelectedIndex = 0 Then
                ds = clsLFL.getMtdLFL(beginDate, endDate, ddlRate.SelectedValue)
                ucLFL.ReportType = clsBts.reportType.MTD.ToString
            ElseIf ddlBy.SelectedIndex = 1 Then
                bDate = "1/4/" + IIf(beginDate.Month < 4, (beginDate.Year - 1).ToString, beginDate.Year.ToString)
                beginDate = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
                ds = clsLFL.getYtdLFL(beginDate, endDate, ddlRate.SelectedValue)
                ucLFL.ReportType = clsBts.reportType.YTD.ToString
            End If
            ucLFL.ReportName = ucLFL.ReportType + " LFL Report"
            ucLFL.iMonth = ddlMonth.SelectedValue
            ucLFL.iYear = ddlYear.SelectedValue
            ucLFL.ItemScrollWidth = 0
            ucLFL.ExcelTopic = ddlBy.SelectedValue + " " + ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedItem.Text + "&nbsp;&nbsp;&nbsp;&nbsp;Currency Rate " + ddlRate.SelectedItem.Text
            ucLFL.LoadReport(ds)
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

End Class
