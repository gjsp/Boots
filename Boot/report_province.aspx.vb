
Partial Class report_province
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

            'ddlstore.DataValueField = "costcenter_id"
            'ddlstore.DataTextField = "con_name"
            'ddlstore.DataSource = ClsDB.getCostcenterInReport()
            'ddlstore.DataBind()
            ddlprovince.DataValueField = "province_id"
            ddlprovince.DataTextField = "province_name"
            ddlprovince.DataSource = ClsDB.getProvinceOname()
            ddlprovince.DataBind()
            ddlProvince.Items.Add(New ListItem("--All--", ""))
            ddlprovince.SelectedValue = "ALL"


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

    Protected Sub SearchBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchBt.Click
        Try
            Dim ds As New Data.DataSet
            Dim bDate As String = ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue
            Dim eDate As String = ddlMonth2.SelectedValue + "/" + ddlYear2.SelectedValue

            ds = clsProvince.getProvince(bDate, eDate, ddlProvince.SelectedValue, ddlRate.SelectedValue)
            ucProvince1.ReportType = "Store Report"
            ucProvince1.ReportTopic = ddlProvince.SelectedItem.Text '.Substring(0, 4)
            ucProvince1.iMonth = ddlMonth.SelectedValue
            ucProvince1.iYear = ddlYear.SelectedValue
            ucProvince1.ItemScrollWidth = 940
            ucProvince1.LoadReport(ds)
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub ddlYear2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear2.SelectedIndexChanged
        ddlMonth2.DataValueField = "mon_year"
        ddlMonth2.DataTextField = "mon_name"
        ddlMonth2.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
        ddlMonth2.DataBind()
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        ddlMonth.DataValueField = "mon_year"
        ddlMonth.DataTextField = "mon_name"
        ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
        ddlMonth.DataBind()
    End Sub
End Class
