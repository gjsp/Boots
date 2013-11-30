

Partial Class uc_ucAreaStore
    Inherits System.Web.UI.UserControl

    Private _iMonth As String
    Public Property iMonth() As String
        Get
            Return IIf(ViewState("_iMonth").ToString() <> "", ViewState("_iMonth").ToString(), "")
        End Get
        Set(ByVal value As String)
            ViewState("_iMonth") = value
        End Set
    End Property

    Private _iYear As String
    Public Property iYear() As String
        Get
            Return _iYear
        End Get
        Set(ByVal value As String)
            _iYear = value
        End Set
    End Property

    Private _iMonth2 As String
    Public Property iMonth2() As String
        Get
            Return _iMonth2
        End Get
        Set(ByVal value As String)
            _iMonth2 = value
        End Set
    End Property

    Private _iYear2 As String
    Public Property iYear2() As String
        Get
            Return _iYear2
        End Get
        Set(ByVal value As String)
            _iYear2 = value
        End Set
    End Property

    Private _Local As String
    Public Property Local() As String
        Get
            Return _Local
        End Get
        Set(ByVal value As String)
            _Local = value
        End Set
    End Property

    Private _Rate As String
    Public Property Rate() As String
        Get
            Return _Rate
        End Get
        Set(ByVal value As String)
            _Rate = value
        End Set
    End Property

    Private _ItemScrollWidth As Integer
    Public Property ItemScrollWidth() As Integer
        Get
            Return _ItemScrollWidth
        End Get
        Set(ByVal value As Integer)
            _ItemScrollWidth = value
        End Set
    End Property

    Private _ReportTopic As String
    Public Property ReportTopic() As String
        Get
            Return ViewState("_ReportTopic").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("_ReportTopic") = value
        End Set
    End Property

    Private _ReportType As String
    Public Property ReportType() As String
        Get
            Return _ReportType
        End Get
        Set(ByVal value As String)
            _ReportType = value
        End Set
    End Property

    Private _ReportName As String
    Public Property ReportName() As String
        Get
            Return _ReportName
        End Get
        Set(ByVal value As String)
            _ReportName = value
        End Set
    End Property

    Public Sub LoadReport(ds As Data.DataSet)
        Try
            If ds.Tables(clsBts.reportPart.Item.ToString).Rows.Count = 0 Then
                pnMain.Visible = False
                pnNothing.Visible = True
                lblNodata.Text = "<div style='color:red;text-align:center;border:solid 1px silver;'>No Data</div>"
            Else
                pnMain.Visible = True
                pnNothing.Visible = False
                hdfIndex.Value = 0

                'for add 1 row
                Dim brTopic As String = ""
                If ds.Tables(clsBts.reportPart.Total.ToString).Rows(0)("store_name").ToString.Contains("<br/>") Then
                    brTopic = "<br/>"
                End If
                'lblTopicTable.Text = String.Format(clsHtml.htmlModelTopic, ReportType + " Model Report", brTopic)
                lblTopicTable.Text = String.Format(clsHtml.htmlModelTopic, ReportName, brTopic)

                Dim reportYtd As String = IIf(ReportType = clsBts.reportType.YTD.ToString, ReportType + " ", "") 'ถ้าเป็น ytd ให้โชว์
                If Integer.Parse(iMonth) < 4 Then
                    ReportTopic = reportYtd + MonthName(iMonth, True).ToString + " " + Convert.ToString(iYear - 1).Substring(2, 2) + iYear.ToString.Substring(2, 2)
                Else
                    ReportTopic = reportYtd + MonthName(iMonth, True).ToString + " " + iYear.ToString.Substring(2, 2) + (iYear + 1).ToString.Substring(2, 2)
                End If

                If ReportType = clsBts.reportType.ByFormat.ToString Then
                    If iMonth = iMonth2 And iYear = iYear2 Then
                        ReportTopic = MonthName(iMonth, True).ToString + " " + iYear.ToString.Substring(2, 2)
                    Else
                        ReportTopic = MonthName(iMonth, True).ToString + " " + iYear.ToString.Substring(2, 2) + " - " + MonthName(iMonth2, True).ToString + " " + iYear2.ToString.Substring(2, 2)
                    End If
                End If

                If ItemScrollWidth() <> 0 Then
                    div_item.Attributes.Add("style", String.Format("width:{0}px", ItemScrollWidth().ToString))
                End If

                dlTotal.DataSource = ds.Tables(clsBts.reportPart.Total.ToString)
                dlTotal.DataBind()

                dlItem.DataSource = ds.Tables(clsBts.reportPart.Item.ToString)
                dlItem.DataBind()


                ClsManage.Script(Page, "settb('b');settb('e');settb('f');settb('g');settb('h');settb('s');settb('aa');")

            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub dlItem_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlItem.ItemDataBound
       
        Dim drv As Data.DataRowView = e.Item.DataItem
        Dim tooltip As String = String.Format("<span title='{1}'>{0}</span>", e.Item.DataItem("store_name"), e.Item.DataItem("costcenter_name"))
        Dim l As String = "|"

        'Head
        Dim sbHeadItem As New StringBuilder
        ReportTopic = e.Item.DataItem("area_name")
        sbHeadItem.Append(ReportTopic) '0
        sbHeadItem.Append(l + tooltip)
        'sbHeadItem.Append(l + "=""" + e.Item.DataItem("store_name").ToString.Replace("</br>", " "" & char(10) & "" ") + """")
        sbHeadItem.Append(l + e.Item.DataItem("cnum").ToString) '2
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("sumtotalarea").ToString)) '3
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("Sumsalearea").ToString)) '4
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("productivity").ToString)) '5
        sbHeadItem.Append(l + e.Item.DataItem("yoy_growth").ToString) '6
        sbHeadItem.Append(l + e.Item.DataItem("lfl_growth").ToString) '7

            Dim tblClass As Boolean = False
            If e.Item.DataItem("store_name").ToString.Contains("Total") Then
                tblClass = True
            End If
            Dim htmlHead As String = String.Format(clsHtml.htmlModelItem(clsHtml.tablePart.head, tblClass), sbHeadItem.ToString.Split(l))

            'Body
            hdfIndex.Value = Integer.Parse(hdfIndex.Value) + 1
            Dim sbBodyItem As New StringBuilder
            Dim sumTotalRevenue As Double = 0
            Dim valSumItem As Double = 0
            sumTotalRevenue = e.Item.DataItem("SumTotalRevenue")
            sbBodyItem.Append(hdfIndex.Value + l + hdfIndex.Value + l + hdfIndex.Value)
            For i As Integer = 0 To drv.Row.ItemArray.Count - 1
                If drv.DataView.Table.Columns(i).ColumnName.Contains("Sum") Then
                    If Not (drv.DataView.Table.Columns(i).ColumnName = "Sumtotalarea" Or drv.DataView.Table.Columns(i).ColumnName = "Sumsalearea") Then
                        valSumItem = drv.Row.ItemArray(i)

                        sbBodyItem.Append(l + ClsManage.convert2Currency3(valSumItem.ToString) + _
                                         l + IIf(sumTotalRevenue = 0, "0.0", ClsManage.convert2Currency4((valSumItem / sumTotalRevenue) * 100).ToString) + _
                                         l + "" _
                                         )
                    End If
                End If
            Next
            Dim htmlBody As String = String.Format(clsHtml.htmlModelItem(clsHtml.tablePart.body), sbBodyItem.ToString.Split(l))

            'Foot
            Dim sbFootItem As New StringBuilder
            sbFootItem.Append(e.Item.DataItem("yoy_loss_growth").ToString) '0
            sbFootItem.Append(l + e.Item.DataItem("lfl_loss_growth").ToString) '1
            Dim htmlFoot As String = String.Format(clsHtml.htmlModelItem(clsHtml.tablePart.foot), sbFootItem.ToString.Split(l))

            CType(e.Item.FindControl("lbl"), Label).Text = htmlHead + htmlBody + htmlFoot
    End Sub

    Protected Sub dlTotal_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlTotal.ItemDataBound

        If e.Item.DataItem("store_name") = clsBts.reportPart.Total.ToString + "Yoy" Then Exit Sub 'datatable มีrow ที่เป็น yoy ไม่ต้องโชว์

        Dim drv As Data.DataRowView = e.Item.DataItem
        Dim l As String = "|"

        'Head
        Dim sbHeadItem As New StringBuilder
        sbHeadItem.Append(ReportTopic) '0
        sbHeadItem.Append(l + e.Item.DataItem("store_name")) '1
        sbHeadItem.Append(l + e.Item.DataItem("cnum").ToString) '2
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("sumtotalarea").ToString)) '3
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("Sumsalearea").ToString)) '4
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("productivity").ToString)) '5
        sbHeadItem.Append(l + e.Item.DataItem("yoy_growth").ToString) '6
        sbHeadItem.Append(l + e.Item.DataItem("lfl_growth").ToString) '7
        Dim htmlHead As String = String.Format(clsHtml.htmlModelTotal(clsHtml.tablePart.head), sbHeadItem.ToString.Split(l))

        'Body
        hdfIndex.Value = Integer.Parse(hdfIndex.Value) + 1
        Dim sbBodyItem As New StringBuilder
        Dim sumTotalRevenue As Double = 0
        Dim valSumItem As Double = 0
        sumTotalRevenue = e.Item.DataItem("SumTotalRevenue")
        sbBodyItem.Append(hdfIndex.Value + l + hdfIndex.Value + l + hdfIndex.Value)

        Dim drYoy As Data.DataRow = drv.DataView.Table.NewRow
        For Each drv_ As Data.DataRowView In drv.DataView
            If drv_("store_id") = e.Item.DataItem("store_id") And drv_("store_name") = "TotalYoy" Then
                drYoy = drv_.Row
            End If
        Next

        Dim valYoy As String = ""
        For i As Integer = 0 To drv.Row.ItemArray.Count - 1
            If drv.DataView.Table.Columns(i).ColumnName.Contains("Sum") Then
                If Not (drv.DataView.Table.Columns(i).ColumnName = "Sumtotalarea" Or drv.DataView.Table.Columns(i).ColumnName = "Sumsalearea") Then

                    valSumItem = drv.Row.ItemArray(i)
                    If drv.DataView.Table.Columns(i).ColumnName = "SumGrossProfit" Or drv.DataView.Table.Columns(i).ColumnName = "SumAdjustedGrossMargin" Or drv.DataView.Table.Columns(i).ColumnName = "SumStoreTradingProfit__Loss" Or drv.DataView.Table.Columns(i).ColumnName = "SumMarginAdjustments" Then
                        Dim bp As Double = drYoy(drv.DataView.Table.Columns(i).ColumnName)
                        valYoy = Math.Round(bp, 0).ToString("#,##0") + " bp"
                    Else
                        valYoy = ClsManage.convert2PercenLFLGrowth(drYoy(drv.DataView.Table.Columns(i).ColumnName).ToString)
                    End If
                    sbBodyItem.Append(l + ClsManage.convert2Currency3(valSumItem.ToString) + _
                                      l + IIf(sumTotalRevenue = 0, "0.0", ClsManage.convert2Currency4((valSumItem / sumTotalRevenue) * 100).ToString) + _
                                      l + valYoy)
                End If
            End If
        Next
        Dim htmlBody As String = String.Format(clsHtml.htmlModelTotal(clsHtml.tablePart.body), sbBodyItem.ToString.Split(l))

        'Foot
        Dim sbFootItem As New StringBuilder
        sbFootItem.Append(e.Item.DataItem("yoy_loss_growth").ToString) '0
        sbFootItem.Append(l + e.Item.DataItem("lfl_loss_growth").ToString) '1
        Dim htmlFoot As String = String.Format(clsHtml.htmlModelTotal(clsHtml.tablePart.foot), sbFootItem.ToString.Split(l))

        CType(e.Item.FindControl("lbl"), Label).Text = htmlHead + htmlBody + htmlFoot
    End Sub

    Protected Sub linkExcel_Click(sender As Object, e As System.EventArgs) Handles linkExcel.Click
        Try
            Dim sw As New IO.StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            temp_body.RenderControl(htw)
            clsBts.ExportToExcel(sw.ToString, ReportTopic)

           
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message, , , "err")
        End Try
    End Sub

End Class
