
Partial Class edit_costcenter
    Inherits basePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            ddlStore.DataValueField = "store_id"
            ddlStore.DataTextField = "store_name"
            ddlStore.DataSource = ClsDB.getStore()
            ddlStore.DataBind()

            ddlLocation.DataValueField = "location_id"
            ddlLocation.DataTextField = "location_name"
            ddlLocation.DataSource = ClsDB.getLocation()
            ddlLocation.DataBind()

            ddlProvince.DataValueField = "province_id"
            ddlProvince.DataTextField = "province_name"
            ddlProvince.DataSource = ClsDB.getProvince()
            ddlProvince.DataBind()

            ddlArea.DataValueField = "area_id"
            ddlArea.DataTextField = "area_name"
            ddlArea.DataSource = ClsDB.getArea()
            ddlArea.DataBind()

            ddlMarket.DataValueField = "market_id"
            ddlMarket.DataTextField = "market_name"
            ddlMarket.DataSource = ClsDB.getMarket()
            ddlMarket.DataBind()

            If Request.QueryString("id") IsNot Nothing Then
                Dim data As Data.DataTable
                data = ClsDB.getCostcenterByid(Request.QueryString("id"))
                If data.Rows.Count > 0 Then
                    TxtCode.Text = data.Rows(0)("costcenter_code").ToString
                    TxtName.Text = data.Rows(0)("costcenter_name").ToString
                    ddlStore.SelectedValue = data.Rows(0)("costcenter_store").ToString
                    ddlLocation.SelectedValue = data.Rows(0)("costcenter_location").ToString
                    ddlProvince.SelectedValue = data.Rows(0)("costcenter_province").ToString
                    ddlArea.SelectedValue = data.Rows(0)("costcenter_areas").ToString
                    TxtTotal.Text = ClsManage.convert2Currency(data.Rows(0)("costcenter_total_area")).ToString
                    TxtSale.Text = ClsManage.convert2Currency(data.Rows(0)("costcenter_sale_area")).ToString
                    TxtOpendt.Text = DateValue(data.Rows(0)("costcenter_opendt")).ToString("d/M/yyyy")
                    ddlMarket.SelectedValue = data.Rows(0)("costcenter_market").ToString
                    RemarkTxt.Text = data.Rows(0)("costcenter_remark").ToString

                    If data.Rows(0)("costcenter_blockdt") Is DBNull.Value Then
                        Pbl.Visible = False
                        ddlblock.SelectedValue = "N"
                    Else
                        Pbl.Visible = True
                        TxtBlockdt.Text = DateValue(data.Rows(0)("costcenter_blockdt")).ToString("d/M/yyyy")
                        ddlblock.SelectedValue = "Y"
                    End If

                End If
            End If

           

        End If
    End Sub

    Protected Sub CancelBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelBt.Click
        Response.Redirect("manage_costcenter.aspx")
    End Sub
    Function saveData() As Boolean
        Try
            If ddlblock.SelectedValue = "Y" Then
                ClsDB.UpdateCostcenter(Request.QueryString("id"), TxtCode.Text, TxtName.Text, ddlStore.SelectedValue, ddlLocation.SelectedValue, ddlProvince.SelectedValue, TxtSale.Text, TxtTotal.Text, TxtOpendt.Text, ddlArea.SelectedValue, TxtBlockdt.Text, ddlMarket.SelectedValue, RemarkTxt.Text)
            Else
                ClsDB.UpdateCostcenter(Request.QueryString("id"), TxtCode.Text, TxtName.Text, ddlStore.SelectedValue, ddlLocation.SelectedValue, ddlProvince.SelectedValue, TxtSale.Text, TxtTotal.Text, TxtOpendt.Text, ddlArea.SelectedValue, "", ddlMarket.SelectedValue, RemarkTxt.Text)
            End If
            Return True
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Function

    Protected Sub SaveBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveBt.Click
        Try
            Dim data_chk As Data.DataTable
            data_chk = ClsDB.getCostcenterByCode(TxtCode.Text)

            If data_chk.Rows.Count > 0 Then
                If data_chk.Rows(0)("costcenter_id") = Request.QueryString("id") Then
                    If saveData() Then
                        ClsManage.alert(Page, "Update Complete", , "manage_costcenter.aspx")
                    End If
                Else
                    ClsManage.alert(Page, "Code must not Duplicate")
                End If
            Else
                If saveData() Then
                    ClsManage.alert(Page, "Update Complete", , "manage_costcenter.aspx")
                End If
            End If

        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub ddlblock_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlblock.TextChanged
        If ddlblock.SelectedValue = "Y" Then
            Pbl.Visible = True
        Else
            Pbl.Visible = False
        End If
    End Sub
End Class
