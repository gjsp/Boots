
Partial Class add_costcenter
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


            ddlblock.SelectedValue = "N"
            Pbl.Visible = False
        End If
    End Sub

    Protected Sub CancelBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelBt.Click
        Response.Redirect("manage_costcenter.aspx")
    End Sub
    Function saveData() As Boolean
        Try
            If ddlblock.SelectedValue = "Y" Then
                ClsDB.InsertCostcenter(TxtCode.Text, TxtName.Text, ddlStore.SelectedValue, ddlLocation.SelectedValue, ddlProvince.SelectedValue, TxtSale.Text, TxtTotal.Text, TxtOpendt.Text, ddlArea.SelectedValue, TxtBlockdt.Text, ddlMarket.SelectedValue, RemarkTxt.Text)
            Else
                ClsDB.InsertCostcenter(TxtCode.Text, TxtName.Text, ddlStore.SelectedValue, ddlLocation.SelectedValue, ddlProvince.SelectedValue, TxtSale.Text, TxtTotal.Text, TxtOpendt.Text, ddlArea.SelectedValue, "", ddlMarket.SelectedValue, RemarkTxt.Text)
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
                ClsManage.alert(Page, "Code must not Duplicate")
            Else
                If saveData() Then
                    ClsManage.alert(Page, "Save Complete", , "manage_costcenter.aspx")
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
