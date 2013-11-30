

Partial Class uc_ucFullPerformance
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

    Private _ReportTopicTotal As String
    Public Property ReportTopicTotal() As String
        Get
            Return ViewState("_ReportTopicTotal").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("_ReportTopicTotal") = value
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
                Dim brTopic As String = "<br/>"
                'If ds.Tables(clsBts.reportPart.Total.ToString).Rows(0)("store_name").ToString.Contains("<br/>") Then
                '    brTopic = "<br/>"
                'End If
                'lblTopicTable.Text = String.Format(clsHtml.htmlModelTopic, ReportType + " Model Report", brTopic
                ReportName = "<br/><br/>" + ReportName + "<br/><br/><br/>"
                lblTopicTable.Text = String.Format(clsHtml.htmlFullPfmTopic, ReportName, brTopic)
                ReportTopic = ""
                'Dim reportYtd As String = IIf(ReportType = clsBts.reportType.YTD.ToString, ReportType + " ", "") 'ถ้าเป็น ytd ให้โชว์
                'If Integer.Parse(iMonth) < 4 Then
                '    ReportTopic = reportYtd + MonthName(iMonth, True).ToString + " " + Convert.ToString(iYear - 1).Substring(2, 2) + iYear.ToString.Substring(2, 2)
                'Else
                '    ReportTopic = reportYtd + MonthName(iMonth, True).ToString + " " + iYear.ToString.Substring(2, 2) + (iYear + 1).ToString.Substring(2, 2)
                'End If

                'If ReportType = clsBts.reportType.ByFormat.ToString Then
                '    If iMonth = iMonth2 And iYear = iYear2 Then
                '        ReportTopic = MonthName(iMonth, True).ToString + " " + iYear.ToString.Substring(2, 2)
                '    Else
                '        ReportTopic = MonthName(iMonth, True).ToString + " " + iYear.ToString.Substring(2, 2) + " - " + MonthName(iMonth2, True).ToString + " " + iYear2.ToString.Substring(2, 2)
                '    End If
                'End If
                'ReportTopic = "" '"TOTAL (" + ReportTopic + ") Not Full year"

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
        If drv("rankyear").ToString.Substring(4, 2) <> "01" Then Exit Sub

        Dim l As String = "|"
        Dim html As New StringBuilder

        For Each dr As Data.DataRowView In drv.DataView
            If dr("costcenter_code") = e.Item.DataItem("rankyear").ToString.Substring(0, 4) Then
                hdfIndex.Value = Integer.Parse(hdfIndex.Value) + 1
                Dim sbBodyItem As New StringBuilder
                Dim sumTotalRevenue As Double = 0
                Dim valSumItem As Double = 0
                sumTotalRevenue = dr("SumTotalRevenue")
                Dim betweenDate As String = CDate(dr("beginDate")).ToString("dd-MM-yy") + ".." + CDate(dr("endDate")).ToString("dd-MM-yy")

                sbBodyItem.Append(betweenDate + l + hdfIndex.Value + l + dr("count_month").ToString + " Months")
                For i As Integer = 0 To drv.Row.ItemArray.Count - 1
                    If drv.DataView.Table.Columns(i).ColumnName.Contains("Sum") Then
                        If Not (drv.DataView.Table.Columns(i).ColumnName = "Sumtotalarea" Or drv.DataView.Table.Columns(i).ColumnName = "Sumsalearea") Then
                            valSumItem = dr(i)

                            sbBodyItem.Append(l + ClsManage.convert2Currency3(valSumItem.ToString) + _
                                             l + IIf(sumTotalRevenue = 0, "0.0", ClsManage.convert2Currency4((valSumItem / sumTotalRevenue) * 100).ToString) + _
                                             l + "" _
                                             )
                        End If
                    End If
                Next

                sbBodyItem.Append(l + ClsManage.convert2Currency3(dr("costcenter_total_area").ToString)) '3
                sbBodyItem.Append(l + ClsManage.convert2Currency3(dr("costcenter_sale_area").ToString)) '4
                sbBodyItem.Append(l + ClsManage.convert2Currency3(dr("productivity").ToString)) '5
                sbBodyItem.Append(l + dr("yoy_growth").ToString) '6
                sbBodyItem.Append(l + dr("lfl_growth").ToString) '7

                Dim htmlBody As String = String.Format(clsHtml.htmlFullPfmItem(clsHtml.tablePart.body), sbBodyItem.ToString.Split(l))

                Dim sbFootItem As New StringBuilder
                sbFootItem.Append(dr("yoy_loss_growth").ToString) '0
                sbFootItem.Append(l + dr("lfl_loss_growth").ToString) '1
                Dim htmlFoot As String = String.Format(clsHtml.htmlFullPfmItem(clsHtml.tablePart.foot), sbFootItem.ToString.Split(l))
                If html.ToString = "" Then
                    html.Append(htmlBody + htmlFoot)
                Else
                    html.Append(l + htmlBody + htmlFoot)
                End If
            End If
        Next



        Dim htmlMultiTd As String = ""
        Dim iRow As Integer = 0
        For Each subHtml As String In html.ToString.Split(l)
            htmlMultiTd += "<TD>{" + iRow.ToString + "}</TD>"
            iRow += 1
        Next

        'case ปีเดียว costcenter ชื่อยาวเกินไปอาจตกบรรทัดใหม่
        Dim costcenterName As String = e.Item.DataItem("costcenter_name").ToString
        Dim iLength As Integer = 20
        If iRow = 1 And costcenterName.Length > iLength Then
            costcenterName = String.Format("<span title='{1}'>{0}</span>", costcenterName.Substring(0, iLength) + "..", costcenterName)
        End If

        Dim sbHeadItem As New StringBuilder
        ReportTopic = CDate(e.Item.DataItem("costcenter_opendt")).ToString("dd-MMM-yy") + "<br>" + _
            e.Item.DataItem("costcenter_code").ToString + "<br>" + _
            costcenterName + "<br>" + _
            e.Item.DataItem("store_name").ToString + "<br>" + _
            e.Item.DataItem("location_name").ToString
        sbHeadItem.Append(ReportTopic)

        Dim htmlMainTbl As String = ""
        htmlMainTbl = "<TABLE cellspacing='0' cellpadding='0' class='tbPFItem2' >"
        htmlMainTbl += "<TR><TD align='center' class='rbg1' style='font-weight:bold' colspan = '" + iRow.ToString + "'>" + ReportTopic + "</TD></TR><TR>"
        htmlMainTbl += htmlMultiTd
        htmlMainTbl += "</TR></TABLE>"

        CType(e.Item.FindControl("lbl"), Label).Text = String.Format(htmlMainTbl.ToString, html.ToString.Split(l))

    End Sub

    Protected Sub dlTotal_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlTotal.ItemDataBound

        If Not e.Item.DataItem("yearno").ToString.Contains("1") Then Exit Sub
        If e.Item.DataItem("yearno").ToString.Contains(clsBts.FullTotal.Yoy.ToString) Then Exit Sub

        Dim drv As Data.DataRowView = e.Item.DataItem
        Dim l As String = "|"

        Dim sumTotalRevenue As Double = 0
        Dim valSumItem As Double = 0
        Dim html As New StringBuilder

        For Each dr As Data.DataRowView In drv.DataView
            If dr("yearno").ToString.Contains(drv("location_name").ToString) And Not dr("yearno").ToString.Contains(clsBts.FullTotal.Yoy.ToString) Then
                hdfIndex.Value = Integer.Parse(hdfIndex.Value) + 1
                Dim sbBodyItem As New StringBuilder
                sbBodyItem.Append(hdfIndex.Value + l + hdfIndex.Value + l + hdfIndex.Value)
                Dim valYoy As String = ""

                'Yoy
                Dim drYoy As Data.DataRow = drv.DataView.Table.NewRow
                For Each drv_ As Data.DataRowView In drv.DataView
                    If drv_("yearno") = dr("yearno").ToString + clsBts.FullTotal.Yoy.ToString Then 'And Not dr("yearno").ToString.Contains("1") Then
                        drYoy = drv_.Row
                    End If
                Next

                For i As Integer = 0 To drv.Row.ItemArray.Count - 1
                    If dr.DataView.Table.Columns(i).ColumnName.Contains("Sum") Then
                        If Not (drv.DataView.Table.Columns(i).ColumnName = "Sumtotalarea" Or drv.DataView.Table.Columns(i).ColumnName = "Sumsalearea") Then
                            sumTotalRevenue = dr("SumTotalRevenue")
                            valSumItem = dr(i)

                            If Not dr("yearno").ToString.Contains("1") Then
                                If drv.DataView.Table.Columns(i).ColumnName = "SumGrossProfit" Or drv.DataView.Table.Columns(i).ColumnName = "SumAdjustedGrossMargin" Or drv.DataView.Table.Columns(i).ColumnName = "SumStoreTradingProfit__Loss" Or drv.DataView.Table.Columns(i).ColumnName = "SumMarginAdjustments" Then
                                    Dim bp As Double = drYoy(drv.DataView.Table.Columns(i).ColumnName)
                                    valYoy = Math.Round(bp, 0).ToString("#,##0") + " bp"
                                Else
                                    valYoy = ClsManage.convert2PercenLFLGrowth(drYoy(drv.DataView.Table.Columns(i).ColumnName).ToString)
                                End If
                            Else
                                valYoy = ""
                            End If
                            sbBodyItem.Append(l + ClsManage.convert2Currency3(valSumItem.ToString) + _
                                              l + IIf(sumTotalRevenue = 0, "0.0", ClsManage.convert2Currency4((valSumItem / sumTotalRevenue) * 100).ToString) + _
                                              l + valYoy)
                        End If
                    End If
                Next
                sbBodyItem.Append(l + "")
                sbBodyItem.Append(l + dr("rankyear").ToString + "<br>" + dr("count_month").ToString + " Months")
                sbBodyItem.Append(l + ClsManage.convert2Currency3(dr("costcenter_total_area").ToString))
                sbBodyItem.Append(l + ClsManage.convert2Currency3(dr("costcenter_sale_area").ToString))
                sbBodyItem.Append(l + ClsManage.convert2Currency3(dr("productivity").ToString))
                sbBodyItem.Append(l + dr("yoy_growth").ToString) '6
                sbBodyItem.Append(l + dr("lfl_growth").ToString) '7

                Dim showYoy As Boolean = True
                If dr("yearno").ToString.Contains("1") Then showYoy = False

                Dim htmlBody As String = String.Format(clsHtml.htmlFullPfmTotal(clsHtml.tablePart.body, showYoy), sbBodyItem.ToString.Split(l))

                Dim sbFootItem As New StringBuilder
                sbFootItem.Append(dr("yoy_loss_growth").ToString) '0
                sbFootItem.Append(l + dr("lfl_loss_growth").ToString) '1
                Dim htmlFoot As String = String.Format(clsHtml.htmlFullPfmTotal(clsHtml.tablePart.foot, showYoy), sbFootItem.ToString.Split(l))

                If html.ToString = "" Then
                    html.Append(htmlBody + htmlFoot)
                Else
                    html.Append(l + htmlBody + htmlFoot)
                End If

            End If
        Next

        Dim htmlMultiTd As String = ""
        Dim iRow As Integer = 0
        For Each subHtml As String In html.ToString.Split(l)
            htmlMultiTd += "<TD>{" + iRow.ToString + "}</TD>"
            iRow += 1
        Next
        Dim topic As String = e.Item.DataItem("location_name").ToString + " (" + e.Item.DataItem("location_count").ToString + ")"
        Dim htmlMainTbl As String = ""
        htmlMainTbl = "<TABLE cellspacing='0' cellpadding='0' class='tbPFTotal2' >"
        htmlMainTbl += "<TR><TD align='center' class='rbg1' style='font-weight:bold' colspan = '" + iRow.ToString + "'>" + topic + "</TD></TR><TR>"
        htmlMainTbl += htmlMultiTd
        htmlMainTbl += "</TR></TABLE>"

        CType(e.Item.FindControl("lbl"), Label).Text = String.Format(htmlMainTbl.ToString, html.ToString.Split(l))


    End Sub

    Protected Sub linkExcel_Click(sender As Object, e As System.EventArgs) Handles linkExcel.Click
        Try
            Dim sw As New IO.StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            temp_body.RenderControl(htw)
            clsBts.ExportToExcel(sw.ToString, ReportTopic)

            'Response.Clear()
            'Response.Buffer = True
            'Response.AddHeader("content-disposition", "attachment;filename=fertilizer.xls")
            'Response.Charset = String.Empty
            'Response.ContentType = "application/vnd.ms-excel"
            'Dim sw As System.IO.StringWriter = New System.IO.StringWriter()
            'Dim hw As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(sw)




            'temp_body.RenderControl(hw)
            'Dim style As String = "<style>.td {mso-number-format:\@;}</style>"
            'Response.Write(style)

            'Dim data_temp As String = sw.ToString
            'data_temp = data_temp.Replace("class='rbg0'", "style='color: #FFFFFF;background: #376091' ")
            'data_temp = data_temp.Replace("class='rbg1'", "style='color: #FFFFFF;background: #376091' ")
            'data_temp = data_temp.Replace("class='rbg2'", "style='color: #000000;background: #B8CCE4' ")
            'data_temp = data_temp.Replace("class='rbg3'", "style='color: #000000;background: #FFFF99' ")
            'data_temp = data_temp.Replace("class='rbg4'", "style='color: #000000;background: #B8CCE4' ")

            'data_temp = data_temp.Replace("class='tdyoy1'", "style='text-align:right';")
            'data_temp = data_temp.Replace("class='tball2'", "style='font-family:Arial;font-size:10px;'")
            'data_temp = data_temp.Replace("class='tbTotal'", "style='font-family:Arial;font-size:10px;'")
            'data_temp = data_temp.Replace("<table", "<style> TD { mso-number-format:\@; } </style> <table ")

            'Response.Output.Write(data_temp)
            'Response.Flush()
            'Response.End()

        Catch ex As Exception
            ClsManage.alert(Page, ex.Message, , , "err")
        End Try
    End Sub


End Class
