
Partial Class manage_currency
    Inherits basePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Panel1.Visible = False
            Panel2.Visible = False
            HdTemp.Value = ""
            AddRateTxt.Attributes.Add("onkeypress", "return Numbers(event);")
            btnDelRate.Attributes.Add("onclick", "return confirm('Do you want to delete?');")
            'ddlYear.Attributes.Add("onclick", "showRate(this);")
            gvMonthRate.EmptyDataText = ClsManage.EmptyDataText

            ddlYear.DataValueField = "mon_year"
            ddlYear.DataTextField = "mon_year"
            ddlYear.DataSource = ClsDB.getMtdYear()
            ddlYear.DataBind()
            ddlYear.Items.Insert(0, New ListItem("--Select--", ""))
        End If
    End Sub

    Protected Sub ImgDel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
        Dim id As String = GridView1.DataKeys(i).Value
        ClsDB.DelCurrencyById(id)
        GridView1.DataBind()
        btnCancelUpdate_Click(Nothing, Nothing)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("ImgDel"), ImageButton).Attributes.Add("onclick", "return confirm('Do you want to delete?');")
        End If
    End Sub

    Protected Sub AddNewBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddNewBt.Click
        Try
            Panel2.Visible = False
            If Panel1.Visible = True Then
                Panel1.Visible = False
            Else
                Panel1.Visible = True
            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub Imgedit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            ddlYear.SelectedIndex = 0
            ddlYear_SelectedIndexChanged(Nothing, Nothing)
            Dim i As Integer = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow).RowIndex
            Dim id As String = GridView1.DataKeys(i).Value

            Panel1.Visible = False
            Panel2.Visible = True
            btnAddRate.Enabled = False
            btnAddRate.Text = "Edit"
            Dim dt As Data.DataTable
            dt = ClsDB.getCurrentcyByName(id)

            EditTxt.Text = dt.Rows(0)("crc_name").ToString
            EditCountryTxt.Text = dt.Rows(0)("crc_country").ToString
            EditRateTxt.Text = dt.Rows(0)("crc_rate").ToString

            HdID.Value = id
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Function saveData() As Boolean
        Try
            ClsDB.InsertCurrentcy(AddTxt.Text, AddCountryTxt.Text, AddRateTxt.Text)
            Return True
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Function

    Function validateDupCurrencyName(name As String) As Boolean
        Dim dt As New Data.DataTable
        dt = ClsDB.getCurrentcyByName(name)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    Protected Sub AddBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddBt.Click
        Try
            If AddTxt.Text.Trim = "" Then ClsManage.alert(Page, ClsManage.msgRequiredFill) : Exit Sub
            If AddCountryTxt.Text.Trim = "" Then ClsManage.alert(Page, ClsManage.msgRequiredFill) : Exit Sub

            If Not validateDupCurrencyName(AddTxt.Text.Trim) Then
                ClsManage.alert(Page, "Duplicate cerrentcy")
                Exit Sub
            End If
            If saveData() Then
                AddTxt.Text = ""
                AddCountryTxt.Text = ""
                AddRateTxt.Text = ""
                Panel1.Visible = False
                GridView1.DataBind()
            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Function updateData() As Boolean
        Try
            ClsDB.UpdateCurrentcy(HdID.Value, EditTxt.Text, EditCountryTxt.Text, EditRateTxt.Text)
            Return True
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Function

    Protected Sub EditBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBt.Click
        Try
            If EditTxt.Text.Trim = "" Then ClsManage.alert(Page, ClsManage.msgRequiredFill) : Exit Sub
            If EditCountryTxt.Text.Trim = "" Then ClsManage.alert(Page, ClsManage.msgRequiredFill) : Exit Sub

            If Not validateDupCurrencyName(AddTxt.Text.Trim) Then
                ClsManage.alert(Page, "Duplicate cerrentcy")
                Exit Sub
            End If
            If updateData() Then
                'ClsManage.alert(Page, "Update Complete", , )
                GridView1.DataBind()
                Panel2.Visible = False
            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        Try
            If ddlYear.SelectedIndex = 0 Then
                btnAddRate.Enabled = False
            Else
                btnAddRate.Enabled = True
                gvMonthRate.Columns(1).Visible = True
                gvMonthRate.Columns(2).Visible = False
            End If
            btnSaveRate.Enabled = False
            btnAddRate.Text = "Edit"
            HdTemp.Value = ""
            btnDelRate.Visible = False
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub btnAddRate_Click(sender As Object, e As System.EventArgs) Handles btnAddRate.Click
        Try
            If btnAddRate.Text = "Edit" Then
                gvMonthRate.Columns(1).Visible = False
                gvMonthRate.Columns(2).Visible = True
                btnSaveRate.Enabled = True
                If gvMonthRate.Rows.Count = 0 Then
                    HdTemp.Value = EditRateTxt.Text
                End If
                btnAddRate.Text = "Cancel"
                If gvMonthRate.Rows.Count > 0 Then
                    btnDelRate.Visible = True
                End If

            Else
                'Cancel
                btnAddRate.Text = "Edit"
                btnDelRate.Visible = False
                gvMonthRate.Columns(1).Visible = True
                gvMonthRate.Columns(2).Visible = False
                btnSaveRate.Enabled = False
                HdTemp.Value = ""
                gvMonthRate.DataBind()
            End If

        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveRate_Click(sender As Object, e As System.EventArgs) Handles btnSaveRate.Click
        Try
            Dim rate(11) As String
            Dim i As Integer = 0
            Dim iRate As Double = 0
            For Each gvRow As GridViewRow In gvMonthRate.Rows
                If IsNumeric(CType(gvRow.FindControl("txtRate"), TextBox).Text) Then
                    rate(i) = CType(gvRow.FindControl("txtRate"), TextBox).Text
                    i += 1
                Else
                    ClsManage.alert(Page, "Please enter only number", , , "number")
                    Exit Sub
                End If

            Next
            ClsDB.InsertCurrentcyRate(HdID.Value, rate, ddlYear.SelectedValue)
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        Finally
            btnAddRate_Click(Nothing, Nothing)
        End Try
    End Sub

    Protected Sub gvMonthRate_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMonthRate.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.FindControl("txtRate"), TextBox).Attributes.Add("onkeypress", "return Numbers(event);")
        End If
    End Sub

    Protected Sub btnDelRate_Click(sender As Object, e As System.EventArgs) Handles btnDelRate.Click
        Try
            If ClsDB.DelCurrencyRate(HdID.Value, ddlYear.SelectedValue) > 0 Then
                btnAddRate_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub btnCancelUpdate_Click(sender As Object, e As System.EventArgs) Handles btnCancelUpdate.Click
        Panel2.Visible = False
    End Sub
End Class
