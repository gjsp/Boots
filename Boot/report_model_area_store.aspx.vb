
Partial Class report_model_area_store
    Inherits basePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            ddlarea.DataValueField = "area_id"
            ddlarea.DataTextField = "area_name"
            ddlarea.DataSource = ClsDB.getArea()
            ddlarea.DataBind()
            'ddlarea.Items.Add(New ListItem("All", ""))
            ddlarea.Items.Insert(0, New ListItem("--All--", ""))
            ddlarea.SelectedValue = "ALL"


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
            Dim eDate As String = "1/" + ddlMonth2.SelectedValue + "/" + ddlYear2.SelectedValue

            ds = clsAreas.getAreaByStore(bDate, eDate, ddlarea.SelectedValue, ddlRate.SelectedValue)
            ucAreaStore1.ReportType = clsBts.reportType.MTD.ToString

            ucAreaStore1.ReportName = "Area By Store report"
            ucAreaStore1.iMonth = ddlMonth.SelectedValue
            ucAreaStore1.iYear = ddlYear.SelectedValue
            ucAreaStore1.ItemScrollWidth = 1100
            ucAreaStore1.ExcelTopic = "Area " + ddlarea.SelectedValue + " " + ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedItem.Text + "&nbsp;&nbsp;&nbsp;&nbsp;Currency Rate " + ddlRate.SelectedItem.Text
            ucAreaStore1.LoadReport(ds)
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

End Class
