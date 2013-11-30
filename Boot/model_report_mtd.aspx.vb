
Partial Class model_report
    Inherits basePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Panel1.Visible = False
            ddlYear.DataValueField = "mon_year"
            ddlYear.DataTextField = "mon_year"
            ddlYear.DataSource = ClsDB.getMtdYear()
            ddlYear.DataBind()

            ddlMonth.DataValueField = "mon_year"
            ddlMonth.DataTextField = "mon_name"
            ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
            ddlMonth.DataBind()

            ddllo.DataValueField = "location_id"
            ddllo.DataTextField = "location_name"
            ddllo.DataSource = ClsDB.getLocation()
            ddllo.DataBind()
            ddllo.Items.Insert(0, New ListItem("All", ""))

            ClsDB.getCurrentcyToDDL(ddlRate)

            '    Dim dt As New Data.DataTable
            '    Dim dn As System.Data.DataRow
            '    Dim dataModel As Data.DataTable
            '    dataModel = ClsDB.getMtdModel


            '    For Each dr In dataModel.Rows
            '        Dim dv As Data.DataTable
            '        dv = ClsDB.getMtdModelByID(dr("cost_store"))
            '        dt.Columns.Add(dr("store_name"))
            '        dn = dt.NewRow
            '        dn(dr("store_name")) = dv.Rows(0)("sumtotal").ToString
            '        dt.Rows.Add(dn)
            '    Next


            '    'If dn Is Nothing Then
            '    '    dt.Columns.Add(dr("store_name"))
            '    '    dn = dt.NewRow
            '    '    dn(i) = dv.Rows(0)("sumtotal").ToString
            '    '    dt.Rows.Add(dn)
            '    'Else
            '    '    dn = dt.Rows(
            '    '    dn(i) = dv.Rows(0)("sumtotal").ToString
            '    '    dt.Rows.Add(dn)

            '    'End If

            '    'i += 1

            '    GridView1.DataSource = dt
            '    GridView1.DataBind()

        End If
    End Sub

    Protected Sub ddlYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYear.TextChanged
        ddlMonth.DataValueField = "mon_year"
        ddlMonth.DataTextField = "mon_name"
        ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
        ddlMonth.DataBind()
    End Sub

    Protected Sub SearchBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchBt.Click
        'Threading.Thread.Sleep(upPG.DisplayAfter)
        If ddlBy.SelectedIndex = 0 Then
            lblReportName.Text = "MTD Model Report"
        Else
            lblReportName.Text = "YTD Model Report"
        End If
        Panel1.Visible = True
        Pftb.Visible = True

        hdfIndex.Value = 0
        Dim reportYear As String = ""
        Dim iYear As Integer = Integer.Parse(ddlYear.SelectedValue)
        If ddlMonth.SelectedValue < 4 Then
            reportYear = Convert.ToString(iYear - 1).Substring(2, 2) + iYear.ToString.Substring(2, 2)
        Else
            reportYear = iYear.ToString.Substring(2, 2) + (iYear + 1).ToString.Substring(2, 2)
        End If

        If ddlBy.SelectedIndex = 0 Then
            odsMtd.SelectParameters("years").DefaultValue = ddlYear.SelectedValue
            odsMtd.SelectParameters("mon").DefaultValue = ddlMonth.SelectedValue
            odsMtd.SelectParameters("locate").DefaultValue = ddllo.SelectedValue
            odsMtd.SelectParameters("rate").DefaultValue = ddlRate.SelectedValue
            'DataList2.DataSourceID = odsMtd.ID

            Dim dsMtd As New Data.DataSet
            dsMtd = clsBts.getModelMtd(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddllo.SelectedValue, ddlRate.SelectedValue)
            If dsMtd.Tables(0).Rows.Count > 0 Then
                DataList2.DataSource = dsMtd.Tables("mtd")
                DataList2.DataBind()

                dl.DataSource = dsMtd.Tables("total")
                dl.DataBind()
            End If

          
        Else
            Dim start_year As String
            If ddlMonth.SelectedValue < 4 Then
                start_year = "1/4/" + (ddlYear.SelectedValue - 1).ToString
            Else
                start_year = "1/4/" + ddlYear.SelectedValue.ToString
            End If
            odsYtd.SelectParameters("years").DefaultValue = ddlYear.SelectedValue
            odsYtd.SelectParameters("mon").DefaultValue = ddlMonth.SelectedValue
            odsYtd.SelectParameters("rate").DefaultValue = ddlRate.SelectedValue
            odsYtd.SelectParameters("locate").DefaultValue = ddllo.SelectedValue
            odsYtd.SelectParameters("start_time").DefaultValue = start_year
            DataList2.DataSourceID = odsYtd.ID
            DataList2.DataBind()
        End If

        Dim month_dif As Integer = 1
        If ddlBy.SelectedIndex = 1 Then
            If ddlMonth.SelectedValue < 4 Then
                month_dif = ddlMonth.SelectedValue + 9
            Else
                month_dif = ddlMonth.SelectedValue - 3
            End If
        End If
        DataList2.Visible = True
        Pftb.Visible = True
       
        ClsManage.Script(Page, "settb('b');settb('e');settb('f');settb('g');settb('h');settb('s');settb('aa');")
        'ClsManage.Script(Page, "document.getElementById('" + hdfExcel.ClientID + "').value =  document.getElementById('" + temp_body.ClientID + "').innerHTML; ")


        ''YOY
        'Dim dtTotalYoy As New Data.DataTable
        'If ddlBy.SelectedIndex = 0 Then
        '    dtTotalYoy = ClsDB.getYoyMtdTotal(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddllo.SelectedValue, ddlRate.SelectedValue)
        'Else
        '    dtTotalYoy = ClsDB.getYoyYtdTotal(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddllo.SelectedValue, ddlRate.SelectedValue)
        'End If
        'If dtTotalYoy.Rows.Count > 0 Then
        '    Dim iCount As Integer = 1000
        '    For i As Integer = 0 To 107
        '        If Not (i = 5) Then 'ยกเว้น lblYoy1005
        '            If iCount = 1004 Or iCount = 1020 Or iCount = 1106 Then
        '                Dim thisPb As Double = 0 : Dim prePb As Double = 0 : Dim pb As Double = 0
        '                If Not (IsDBNull(dtTotalYoy.Rows(1)(0)) Or IsDBNull(dtTotalYoy.Rows(1)(i)) Or IsDBNull(dtTotalYoy.Rows(0)(0)) Or IsDBNull(dtTotalYoy.Rows(0)(i))) Then
        '                    thisPb = dtTotalYoy.Rows(0)(i) / dtTotalYoy.Rows(0)(0)
        '                    prePb = dtTotalYoy.Rows(1)(i) / dtTotalYoy.Rows(1)(0)
        '                    pb = (thisPb - prePb) * 10000
        '                End If
        '                ' CType(Master.FindControl("ContentPlaceHolder1").FindControl("lblYoy" + iCount.ToString), Label).Text = Math.Round(pb, 0).ToString("#,##0") + " bp"
        '            Else
        '                ' CType(Master.FindControl("ContentPlaceHolder1").FindControl("lblYoy" + iCount.ToString), Label).Text = ClsManage.convert2PercenLFLGrowth(dtTotalYoy.Rows(2)(i))
        '            End If
        '            iCount += 1
        '        End If
        '    Next
        '    'lblRGyoy.Text = lblYoy1000.Text
        'End If

        'LFL Total
        'Dim dtTotalLfl As New Data.DataTable
        'If ddlBy.SelectedIndex = 0 Then
        '    dtTotalLfl = ClsDB.getLFLGrowth(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddllo.SelectedValue)
        '    If dtTotalLfl.Rows.Count > 0 Then
        '        'lblRGlfl.Text = ClsManage.convert2PercenLFLGrowth(dtTotalLfl.Select("store_id = 0 ")(0)("Rev1"))
        '        'lblSTFGlfl.Text = ClsManage.convert2PercenLFLGrowth(dtTotalLfl.Select("store_id = 0 ")(0)("loss1"))
        '    End If
        'Else
        '    dtTotalLfl = ClsDB.getLFLGrowthYtdTotal(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddllo.SelectedValue)
        '    If dtTotalLfl.Rows.Count > 0 Then
        '        'lblRGlfl.Text = ClsManage.convert2PercenLFLGrowth(dtTotalLfl.Rows(0)("Rev1"))
        '        'lblSTFGlfl.Text = ClsManage.convert2PercenLFLGrowth(dtTotalLfl.Rows(0)("loss1"))
        '    End If
        'End If

        ' Store Trading Profit/Loss
        'Dim dtLoss As New Data.DataTable
        'If ddlBy.SelectedIndex = 0 Then
        '    dtLoss = ClsDB.getYoyMtd(ddlYear.SelectedValue - 1, ddlMonth.SelectedValue, ddllo.SelectedValue, ddlRate.SelectedValue)
        'Else
        '    dtLoss = ClsDB.getYoyYtd(ddlYear.SelectedValue - 1, ddlMonth.SelectedValue, ddllo.SelectedValue, ddlRate.SelectedValue)
        'End If

        'If dtLoss.Rows.Count > 0 Then
        '    Dim sumLoss As Double = dtLoss.Compute("Sum(SumLoss)", "")
        '    'Dim sumLossNow As Double = IIf(LbSumStoreTradingProfit__Loss.Text = "", 0, LbSumStoreTradingProfit__Loss.Text)
        '    Dim perLoss As Double = 0
        '    'If sumLoss <> 0 And sumLossNow <> 0 Then
        '    '    perLoss = (sumLossNow / sumLoss) - 1
        '    'End If
        '    'lblSTFGyoy.Text = ClsManage.convert2PercenLFLGrowth(perLoss)
        'End If
    End Sub

    Protected Sub linkExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkExcel.Click
        Try
            Dim sw As New IO.StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            temp_body.RenderControl(htw)
            ClsDB.ExportToExcel(htw.InnerWriter.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DataList2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList2.ItemDataBound
        Dim reportYear As String = ""
        Dim reportYtd As String = IIf(ddlBy.SelectedIndex = 1, "YTD ", "") 'ถ้าเป็น ytd ให้โชว์
        Dim iYear As Integer = Integer.Parse(ddlYear.SelectedValue)
        If ddlMonth.SelectedValue < 4 Then
            reportYear = reportYtd + MonthName(ddlMonth.SelectedValue, True).ToString + " " + Convert.ToString(iYear - 1).Substring(2, 2) + iYear.ToString.Substring(2, 2)
        Else
            reportYear = reportYtd + MonthName(ddlMonth.SelectedValue, True).ToString + " " + iYear.ToString.Substring(2, 2) + (iYear + 1).ToString.Substring(2, 2)
        End If


        Dim drv As Data.DataRowView = e.Item.DataItem
        Dim l As String = "|"

        'Head
        Dim sbHeadItem As New StringBuilder
        sbHeadItem.Append(reportYear) '0
        sbHeadItem.Append(l + e.Item.DataItem("store_name")) '1
        sbHeadItem.Append(l + e.Item.DataItem("cnum").ToString) '2
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("sumtotalarea").ToString)) '3
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("Sumsalearea").ToString)) '4
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("productivity").ToString)) '5
        sbHeadItem.Append(l + e.Item.DataItem("yoy_growth").ToString) '6
        sbHeadItem.Append(l + e.Item.DataItem("lfl_growth").ToString) '7

        Dim tbHead As New StringBuilder
        tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='2'><div style='width:175px'><strong>{0}</strong></div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center'><div style='width:110px'><strong>{1}</strong></div></TD><TD align='center'><div style='width:65px;'><strong>% Sale</strong></div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:110px'><strong>{2}</strong></div></TD><TD align='center'><div style='width:65px;'><strong></strong></div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'><div style='width:110px;'>{3}</div></TD><TD align='center' class='rbg2'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:110px'>{4}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:110px'>{5}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:110px'></div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{6}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{7}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:110px'></div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")

        Dim htmlHead As String = String.Format(tbHead.ToString, sbHeadItem.ToString.Split(l))


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

        Dim tbBody As New StringBuilder
        tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:110px'>{3}</div></TD><TD align='right'><div style='width:65px;'>{4}%</div></TD><TD class='tdyoy2'>{5}</TD></TR>")
        tbBody.Append("<TR id='aa1c{1}'><TD align='right'><div style='width:110px'>{6}</div></TD><TD align='right'><div style='width:65px;'>{7}%</div></TD><TD class='tdyoy2'>{8}</TD></TR>")
        tbBody.Append("<TR id='aa2c{1}'><TD align='right'><div style='width:110px'>{9}</div></TD><TD align='right'><div style='width:65px;'>{10}%</div></TD><TD class='tdyoy2'>{11}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>{12}</div></TD><TD align='right'><div style='width:65px;'>{13}%</div></TD><TD class='tdyoy2'>{14}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{15}</div></TD><TD align='right'><div style='width:65px;'>{16}%</div></TD><TD class='tdyoy2'>{17}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>{18}</div></TD><TD align='right'><div style='width:65px;'>{19}%</div></TD><TD class='tdyoy2'>{20}</TD></TR>")
        tbBody.Append("<TR id='b1c{1}'><TD align='right'><div style='width:110px'>{21}</div></TD><TD align='right'><div style='width:65px;'>{22}%</div></TD><TD class='tdyoy2'>{23}</TD></TR>")
        tbBody.Append("<TR id='b2c{1}'><TD align='right'><div style='width:110px'>{24}</div></TD><TD align='right'><div style='width:65px;'>{25}%</div></TD><TD class='tdyoy2'>{26}</TD></TR>")
        tbBody.Append("<TR id='b3c{1}'><TD align='right'><div style='width:110px'>{27}</div></TD><TD align='right'><div style='width:65px;'>{28}%</div></TD><TD class='tdyoy2'>{29}</TD></TR>")
        tbBody.Append("<TR id='b4c{1}'><TD align='right'><div style='width:110px'>{30}</div></TD><TD align='right'><div style='width:65px;'>{31}%</div></TD><TD class='tdyoy2'>{32}</TD></TR>")
        tbBody.Append("<TR id='b5c{1}'><TD align='right'><div style='width:110px'>{33}</div></TD><TD align='right'><div style='width:65px;'>{34}%</div></TD><TD class='tdyoy2'>{35}</TD></TR>")
        tbBody.Append("<TR id='b6c{1}'><TD align='right'><div style='width:110px'>{36}</div></TD><TD align='right'><div style='width:65px;'>{37}%</div></TD><TD class='tdyoy2'>{38}</TD></TR>")
        tbBody.Append("<TR id='b7c{1}'><TD align='right'><div style='width:110px'>{39}</div></TD><TD align='right'><div style='width:65px;'>{40}%</div></TD><TD class='tdyoy2'>{41}</TD></TR>")
        tbBody.Append("<TR id='b8c{1}'><TD align='right'><div style='width:110px'>{42}</div></TD><TD align='right'><div style='width:65px;'>{43}%</div></TD><TD class='tdyoy2'>{44}</TD></TR>")
        tbBody.Append("<TR id='b9c{1}'><TD align='right'><div style='width:110px'>{45}</div></TD><TD align='right'><div style='width:65px;'>{46}%</div></TD><TD class='tdyoy2'>{47}</TD></TR>")
        tbBody.Append("<TR id='b10c{1}'><TD align='right'><div style='width:110px'>{48}</div></TD><TD align='right'><div style='width:65px;'>{49}%</div></TD><TD class='tdyoy2'>{50}</TD></TR>")
        tbBody.Append("<TR id='b11c{1}'><TD align='right'><div style='width:110px'>{51}</div></TD><TD align='right'><div style='width:65px;'>{52}%</div></TD><TD class='tdyoy2'>{53}</TD></TR>")
        tbBody.Append("<TR id='b12c{1}'><TD align='right'><div style='width:110px'>{54}</div></TD><TD align='right'><div style='width:65px;'>{55}%</div></TD><TD class='tdyoy2'>{56}</TD></TR>")
        tbBody.Append("<TR id='b13c{1}'><TD align='right'><div style='width:110px'>{57}</div></TD><TD align='right'><div style='width:65px;'>{58}%</div></TD><TD class='tdyoy2'>{59}</TD></TR>")
        tbBody.Append("<TR id='b14c{1}'><TD align='right'><div style='width:110px'>{60}</div></TD><TD align='right'><div style='width:65px;'>{61}%</div></TD><TD class='tdyoy2'>{62}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:110px'>{63}</div></TD><TD align='right'><div style='width:65px;'>{64}%</div></TD><TD class='tdyoy2'>{65}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;border-bottom:1px solid #2c2b2b;' class='rbg2'><TD align='right'><div style='width:110px'>{66}</div></TD><TD align='right'><div style='width:65px;'>{67}%</div></TD><TD class='tdyoy2'>{68}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{69}</div></TD><TD align='right'><div style='width:65px;'>{70}%</div></TD><TD class='tdyoy2'>{71}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:110px'>{72}</div></TD><TD align='right'><div style='width:65px;'>{73}%</div></TD><TD class='tdyoy2'>{74}</TD></TR>")
        tbBody.Append("<TR id='e1c{1}'><TD align='right'><div style='width:110px'>{75}</div></TD><TD align='right'><div style='width:65px;'>{76}%</div></TD><TD class='tdyoy2'>{77}</TD></TR>")
        tbBody.Append("<TR id='e2c{1}'><TD align='right'><div style='width:110px'>{78}</div></TD><TD align='right'><div style='width:65px;'>{79}%</div></TD><TD class='tdyoy2'>{80}</TD></TR>")
        tbBody.Append("<TR id='e3c{1}'><TD align='right'><div style='width:110px'>{81}</div></TD><TD align='right'><div style='width:65px;'>{82}%</div></TD><TD class='tdyoy2'>{83}</TD></TR>")
        tbBody.Append("<TR id='e4c{1}'><TD align='right'><div style='width:110px'>{84}</div></TD><TD align='right'><div style='width:65px;'>{85}%</div></TD><TD class='tdyoy2'>{86}</TD></TR>")
        tbBody.Append("<TR id='e5c{1}'><TD align='right'><div style='width:110px'>{87}</div></TD><TD align='right'><div style='width:65px;'>{88}%</div></TD><TD class='tdyoy2'>{89}</TD></TR>")
        tbBody.Append("<TR id='e6c{1}'><TD align='right'><div style='width:110px'>{90}</div></TD><TD align='right'><div style='width:65px;'>{91}%</div></TD><TD class='tdyoy2'>{92}</TD></TR>")
        tbBody.Append("<TR id='e7c{1}'><TD align='right'><div style='width:110px'>{93}</div></TD><TD align='right'><div style='width:65px;'>{94}%</div></TD><TD class='tdyoy2'>{95}</TD></TR>")
        tbBody.Append("<TR id='e8c{1}'><TD align='right'><div style='width:110px'>{96}</div></TD><TD align='right'><div style='width:65px;'>{97}%</div></TD><TD class='tdyoy2'>{98}</TD></TR>")
        tbBody.Append("<TR id='e9c{1}'><TD align='right'><div style='width:110px'>{99}</div></TD><TD align='right'><div style='width:65px;'>{100}%</div></TD><TD class='tdyoy2'>{101}</TD></TR>")
        tbBody.Append("<TR id='e10c{1}'><TD align='right'><div style='width:110px'>{102}</div></TD><TD align='right'><div style='width:65px;'>{103}%</div></TD><TD class='tdyoy2'>{104}</TD></TR>")
        tbBody.Append("<TR id='e11c{1}'><TD align='right'><div style='width:110px'>{105}</div></TD><TD align='right'><div style='width:65px;'>{106}%</div></TD><TD class='tdyoy2'>{107}</TD></TR>")
        tbBody.Append("<TR id='e12c{1}'><TD align='right'><div style='width:110px'>{108}</div></TD><TD align='right'><div style='width:65px;'>{109}%</div></TD><TD class='tdyoy2'>{110}</TD></TR>")
        tbBody.Append("<TR id='e13c{1}'><TD align='right'><div style='width:110px'>{111}</div></TD><TD align='right'><div style='width:65px;'>{112}%</div></TD><TD class='tdyoy2'>{113}</TD></TR>")
        tbBody.Append("<TR id='e14c{1}'><TD align='right'><div style='width:110px'>{114}</div></TD><TD align='right'><div style='width:65px;'>{115}%</div></TD><TD class='tdyoy2'>{116}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:110px'>{117}</div></TD><TD align='right'><div style='width:65px;'>{118}%</div></TD><TD class='tdyoy2'>{119}</TD></TR>")
        tbBody.Append("<TR id='f1c{1}'><TD align='right'><div style='width:110px'>{120}</div></TD><TD align='right'><div style='width:65px;'>{121}%</div></TD><TD class='tdyoy2'>{122}</TD></TR>")
        tbBody.Append("<TR id='f2c{1}'><TD align='right'><div style='width:110px'>{123}</div></TD><TD align='right'><div style='width:65px;'>{124}%</div></TD><TD class='tdyoy2'>{125}</TD></TR>")
        tbBody.Append("<TR id='f3c{1}'><TD align='right'><div style='width:110px'>{126}</div></TD><TD align='right'><div style='width:65px;'>{127}%</div></TD><TD class='tdyoy2'>{128}</TD></TR>")
        tbBody.Append("<TR id='f4c{1}'><TD align='right'><div style='width:110px'>{129}</div></TD><TD align='right'><div style='width:65px;'>{130}%</div></TD><TD class='tdyoy2'>{131}</TD></TR>")
        tbBody.Append("<TR id='f5c{1}'><TD align='right'><div style='width:110px'>{132}</div></TD><TD align='right'><div style='width:65px;'>{133}%</div></TD><TD class='tdyoy2'>{134}</TD></TR>")
        tbBody.Append("<TR id='f6c{1}'><TD align='right'><div style='width:110px'>{135}</div></TD><TD align='right'><div style='width:65px;'>{136}%</div></TD><TD class='tdyoy2'>{137}</TD></TR>")
        tbBody.Append("<TR id='f7c{1}'><TD align='right'><div style='width:110px'>{138}</div></TD><TD align='right'><div style='width:65px;'>{139}%</div></TD><TD class='tdyoy2'>{140}</TD></TR>")
        tbBody.Append("<TR id='f8c{1}'><TD align='right'><div style='width:110px'>{141}</div></TD><TD align='right'><div style='width:65px;'>{142}%</div></TD><TD class='tdyoy2'>{143}</TD></TR>")
        tbBody.Append("<TR id='f9c{1}'><TD align='right'><div style='width:110px'>{144}</div></TD><TD align='right'><div style='width:65px;'>{145}%</div></TD><TD class='tdyoy2'>{146}</TD></TR>")
        tbBody.Append("<TR id='f10c{1}'><TD align='right'><div style='width:110px'>{147}</div></TD><TD align='right'><div style='width:65px;'>{148}%</div></TD><TD class='tdyoy2'>{149}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:110px'>{150}</div></TD><TD align='right'><div style='width:65px;'>{151}%</div></TD><TD class='tdyoy2'>{152}</TD></TR>")
        tbBody.Append("<TR id='g1c{1}'><TD align='right'><div style='width:110px'>{153}</div></TD><TD align='right'><div style='width:65px;'>{154}%</div></TD><TD class='tdyoy2'>{155}</TD></TR>")
        tbBody.Append("<TR id='g2c{1}'><TD align='right'><div style='width:110px'>{156}</div></TD><TD align='right'><div style='width:65px;'>{157}%</div></TD><TD class='tdyoy2'>{158}</TD></TR>")
        tbBody.Append("<TR id='g3c{1}'><TD align='right'><div style='width:110px'>{159}</div></TD><TD align='right'><div style='width:65px;'>{160}%</div></TD><TD class='tdyoy2'>{161}</TD></TR>")
        tbBody.Append("<TR id='g4c{1}'><TD align='right'><div style='width:110px'>{162}</div></TD><TD align='right'><div style='width:65px;'>{163}%</div></TD><TD class='tdyoy2'>{164}</TD></TR>")
        tbBody.Append("<TR id='g5c{1}'><TD align='right'><div style='width:110px'>{165}</div></TD><TD align='right'><div style='width:65px;'>{166}%</div></TD><TD class='tdyoy2'>{167}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:110px'>{168}</div></TD><TD align='right'><div style='width:65px;'>{169}%</div></TD><TD class='tdyoy2'>{170}</TD></TR>")
        tbBody.Append("<TR id='h1c{1}'><TD align='right'><div style='width:110px'>{171}</div></TD><TD align='right'><div style='width:65px;'>{172}%</div></TD><TD class='tdyoy2'>{173}</TD></TR>")
        tbBody.Append("<TR id='h2c{1}'><TD align='right'><div style='width:110px'>{174}</div></TD><TD align='right'><div style='width:65px;'>{175}%</div></TD><TD class='tdyoy2'>{176}</TD></TR>")
        tbBody.Append("<TR id='h3c{1}'><TD align='right'><div style='width:110px'>{177}</div></TD><TD align='right'><div style='width:65px;'>{178}%</div></TD><TD class='tdyoy2'>{179}</TD></TR>")
        tbBody.Append("<TR id='h4c{1}'><TD align='right'><div style='width:110px'>{180}</div></TD><TD align='right'><div style='width:65px;'>{181}%</div></TD><TD class='tdyoy2'>{182}</TD></TR>")
        tbBody.Append("<TR id='h5c{1}'><TD align='right'><div style='width:110px'>{183}</div></TD><TD align='right'><div style='width:65px;'>{184}%</div></TD><TD class='tdyoy2'>{185}</TD></TR>")
        tbBody.Append("<TR id='h6c{1}'><TD align='right'><div style='width:110px'>{186}</div></TD><TD align='right'><div style='width:65px;'>{187}%</div></TD><TD class='tdyoy2'>{188}</TD></TR>")
        tbBody.Append("<TR id='h7c{1}'><TD align='right'><div style='width:110px'>{189}</div></TD><TD align='right'><div style='width:65px;'>{190}%</div></TD><TD class='tdyoy2'>{191}</TD></TR>")
        tbBody.Append("<TR id='h8c{1}'><TD align='right'><div style='width:110px'>{192}</div></TD><TD align='right'><div style='width:65px;'>{193}%</div></TD><TD class='tdyoy2'>{194}</TD></TR>")
        tbBody.Append("<TR id='h9c{1}'><TD align='right'><div style='width:110px'>{195}</div></TD><TD align='right'><div style='width:65px;'>{196}%</div></TD><TD class='tdyoy2'>{197}</TD></TR>")
        tbBody.Append("<TR id='h10c{1}'><TD align='right'><div style='width:110px'>{198}</div></TD><TD align='right'><div style='width:65px;'>{199}%</div></TD><TD class='tdyoy2'>{200}</TD></TR>")
        tbBody.Append("<TR id='h11c{1}'><TD align='right'><div style='width:110px'>{201}</div></TD><TD align='right'><div style='width:65px;'>{202}%</div></TD><TD class='tdyoy2'>{203}</TD></TR>")
        tbBody.Append("<TR id='h12c{1}'><TD align='right'><div style='width:110px'>{204}</div></TD><TD align='right'><div style='width:65px;'>{205}%</div></TD><TD class='tdyoy2'>{206}</TD></TR>")
        tbBody.Append("<TR id='h13c{1}'><TD align='right'><div style='width:110px'>{207}</div></TD><TD align='right'><div style='width:65px;'>{208}%</div></TD><TD class='tdyoy2'>{209}</TD></TR>")
        tbBody.Append("<TR id='h14c{1}'><TD align='right'><div style='width:110px'>{210}</div></TD><TD align='right'><div style='width:65px;'>{211}%</div></TD><TD class='tdyoy2'>{212}</TD></TR>")
        tbBody.Append("<TR id='h15c{1}'><TD align='right'><div style='width:110px'>{213}</div></TD><TD align='right'><div style='width:65px;'>{214}%</div></TD><TD class='tdyoy2'>{215}</TD></TR>")
        tbBody.Append("<TR id='h16c{1}'><TD align='right'><div style='width:110px'>{216}</div></TD><TD align='right'><div style='width:65px;'>{217}%</div></TD><TD class='tdyoy2'>{218}</TD></TR>")
        tbBody.Append("<TR id='h17c{1}'><TD align='right'><div style='width:110px'>{219}</div></TD><TD align='right'><div style='width:65px;'>{220}%</div></TD><TD class='tdyoy2'>{221}</TD></TR>")
        tbBody.Append("<TR id='h18c{1}'><TD align='right'><div style='width:110px'>{222}</div></TD><TD align='right'><div style='width:65px;'>{223}%</div></TD><TD class='tdyoy2'>{224}</TD></TR>")
        tbBody.Append("<TR id='h19c{1}'><TD align='right'><div style='width:110px'>{225}</div></TD><TD align='right'><div style='width:65px;'>{226}%</div></TD><TD class='tdyoy2'>{227}</TD></TR>")
        tbBody.Append("<TR id='h20c{1}'><TD align='right'><div style='width:110px'>{228}</div></TD><TD align='right'><div style='width:65px;'>{229}%</div></TD><TD class='tdyoy2'>{230}</TD></TR>")
        tbBody.Append("<TR id='h21c{1}'><TD align='right'><div style='width:110px'>{231}</div></TD><TD align='right'><div style='width:65px;'>{232}%</div></TD><TD class='tdyoy2'>{233}</TD></TR>")
        tbBody.Append("<TR id='h22c{1}'><TD align='right'><div style='width:110px'>{234}</div></TD><TD align='right'><div style='width:65px;'>{235}%</div></TD><TD class='tdyoy2'>{236}</TD></TR>")
        tbBody.Append("<TR id='h23c{1}'><TD align='right'><div style='width:110px'>{237}</div></TD><TD align='right'><div style='width:65px;'>{238}%</div></TD><TD class='tdyoy2'>{239}</TD></TR>")
        tbBody.Append("<TR id='h24c{1}'><TD align='right'><div style='width:110px'>{240}</div></TD><TD align='right'><div style='width:65px;'>{241}%</div></TD><TD class='tdyoy2'>{242}</TD></TR>")
        tbBody.Append("<TR id='h25c{1}'><TD align='right'><div style='width:110px'>{243}</div></TD><TD align='right'><div style='width:65px;'>{244}%</div></TD><TD class='tdyoy2'>{245}</TD></TR>")
        tbBody.Append("<TR id='h26c{1}'><TD align='right'><div style='width:110px'>{246}</div></TD><TD align='right'><div style='width:65px;'>{247}%</div></TD><TD class='tdyoy2'>{248}</TD></TR>")
        tbBody.Append("<TR id='h27c{1}'><TD align='right'><div style='width:110px'>{249}</div></TD><TD align='right'><div style='width:65px;'>{250}%</div></TD><TD class='tdyoy2'>{251}</TD></TR>")
        tbBody.Append("<TR id='h28c{1}'><TD align='right'><div style='width:110px'>{252}</div></TD><TD align='right'><div style='width:65px;'>{253}%</div></TD><TD class='tdyoy2'>{254}</TD></TR>")
        tbBody.Append("<TR id='h29c{1}'><TD align='right'><div style='width:110px'>{255}</div></TD><TD align='right'><div style='width:65px;'>{256}%</div></TD><TD class='tdyoy2'>{257}</TD></TR>")
        tbBody.Append("<TR id='h30c{1}'><TD align='right'><div style='width:110px'>{258}</div></TD><TD align='right'><div style='width:65px;'>{259}%</div></TD><TD class='tdyoy2'>{260}</TD></TR>")
        tbBody.Append("<TR id='h31c{1}'><TD align='right'><div style='width:110px'>{261}</div></TD><TD align='right'><div style='width:65px;'>{262}%</div></TD><TD class='tdyoy2'>{263}</TD></TR>")
        tbBody.Append("<TR id='h32c{1}'><TD align='right'><div style='width:110px'>{264}</div></TD><TD align='right'><div style='width:65px;'>{265}%</div></TD><TD class='tdyoy2'>{266}</TD></TR>")
        tbBody.Append("<TR id='h33c{1}'><TD align='right'><div style='width:110px'>{267}</div></TD><TD align='right'><div style='width:65px;'>{268}%</div></TD><TD class='tdyoy2'>{269}</TD></TR>")
        tbBody.Append("<TR id='h34c{1}'><TD align='right'><div style='width:110px'>{270}</div></TD><TD align='right'><div style='width:65px;'>{271}%</div></TD><TD class='tdyoy2'>{272}</TD></TR>")
        tbBody.Append("<TR id='h35c{1}'><TD align='right'><div style='width:110px'>{273}</div></TD><TD align='right'><div style='width:65px;'>{274}%</div></TD><TD class='tdyoy2'>{275}</TD></TR>")
        tbBody.Append("<TR id='h36c{1}'><TD align='right'><div style='width:110px'>{276}</div></TD><TD align='right'><div style='width:65px;'>{277}%</div></TD><TD class='tdyoy2'>{278}</TD></TR>")
        tbBody.Append("<TR id='h37c{1}'><TD align='right'><div style='width:110px'>{279}</div></TD><TD align='right'><div style='width:65px;'>{280}%</div></TD><TD class='tdyoy2'>{281}</TD></TR>")
        tbBody.Append("<TR id='h38c{1}'><TD align='right'><div style='width:110px'>{282}</div></TD><TD align='right'><div style='width:65px;'>{283}%</div></TD><TD class='tdyoy2'>{284}</TD></TR>")
        tbBody.Append("<TR id='h39c{1}'><TD align='right'><div style='width:110px'>{285}</div></TD><TD align='right'><div style='width:65px;'>{286}%</div></TD><TD class='tdyoy2'>{287}</TD></TR>")
        tbBody.Append("<TR id='h40c{1}'><TD align='right'><div style='width:110px'>{288}</div></TD><TD align='right'><div style='width:65px;'>{289}%</div></TD><TD class='tdyoy2'>{290}</TD></TR>")
        tbBody.Append("<TR id='h41c{1}'><TD align='right'><div style='width:110px'>{291}</div></TD><TD align='right'><div style='width:65px;'>{292}%</div></TD><TD class='tdyoy2'>{293}</TD></TR>")
        tbBody.Append("<TR id='h42c{1}'><TD align='right'><div style='width:110px'>{294}</div></TD><TD align='right'><div style='width:65px;'>{295}%</div></TD><TD class='tdyoy2'>{296}</TD></TR>")
        tbBody.Append("<TR id='h43c{1}'><TD align='right'><div style='width:110px'>{297}</div></TD><TD align='right'><div style='width:65px;'>{298}%</div></TD><TD class='tdyoy2'>{299}</TD></TR>")
        tbBody.Append("<TR id='h44c{1}'><TD align='right'><div style='width:110px'>{300}</div></TD><TD align='right'><div style='width:65px;'>{301}%</div></TD><TD class='tdyoy2'>{302}</TD></TR>")
        tbBody.Append("<TR id='h45c{1}'><TD align='right'><div style='width:110px'>{303}</div></TD><TD align='right'><div style='width:65px;'>{304}%</div></TD><TD class='tdyoy2'>{305}</TD></TR>")
        tbBody.Append("<TR id='h46c{1}'><TD align='right'><div style='width:110px'>{306}</div></TD><TD align='right'><div style='width:65px;'>{307}%</div></TD><TD class='tdyoy2'>{308}</TD></TR>")
        tbBody.Append("<TR id='h47c{1}'><TD align='right'><div style='width:110px'>{309}</div></TD><TD align='right'><div style='width:65px;'>{310}%</div></TD><TD class='tdyoy2'>{311}</TD></TR>")
        tbBody.Append("<TR id='h48c{1}'><TD align='right'><div style='width:110px'>{312}</div></TD><TD align='right'><div style='width:65px;'>{313}%</div></TD><TD class='tdyoy2'>{314}</TD></TR>")
        tbBody.Append("<TR id='h49c{1}'><TD align='right'><div style='width:110px'>{315}</div></TD><TD align='right'><div style='width:65px;'>{316}%</div></TD><TD class='tdyoy2'>{317}</TD></TR>")
        tbBody.Append("<TR id='h50c{1}'><TD align='right'><div style='width:110px'>{318}</div></TD><TD align='right'><div style='width:65px;'>{319}%</div></TD><TD class='tdyoy2'>{320}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:110px'>{321}</div></TD><TD align='right'><div style='width:65px;'>{322}%</div></TD><TD class='tdyoy2'>{323}</TD></TR>")

        Dim htmlBody As String = String.Format(tbBody.ToString, sbBodyItem.ToString.Split(l))

        'Foot
        Dim sbFootItem As New StringBuilder
        sbFootItem.Append(e.Item.DataItem("yoy_loss_growth").ToString) '0
        sbFootItem.Append(l + e.Item.DataItem("lfl_loss_growth").ToString) '1

        Dim tbFoot As New StringBuilder
        tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{0}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{1}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        tbFoot.Append("</TABLE>")
        Dim htmlFoot As String = String.Format(tbFoot.ToString, sbFootItem.ToString.Split(l))
        CType(e.Item.FindControl("label2"), Label).Text = htmlHead + htmlBody + htmlFoot

    End Sub

    Protected Sub dl_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dl.ItemDataBound

        Dim reportYear As String = ""
        Dim reportYtd As String = IIf(ddlBy.SelectedIndex = 1, "YTD ", "") 'ถ้าเป็น ytd ให้โชว์
        Dim iYear As Integer = Integer.Parse(ddlYear.SelectedValue)
        If ddlMonth.SelectedValue < 4 Then
            reportYear = reportYtd + MonthName(ddlMonth.SelectedValue, True).ToString + " " + Convert.ToString(iYear - 1).Substring(2, 2) + iYear.ToString.Substring(2, 2)
        Else
            reportYear = reportYtd + MonthName(ddlMonth.SelectedValue, True).ToString + " " + iYear.ToString.Substring(2, 2) + (iYear + 1).ToString.Substring(2, 2)
        End If


        Dim drv As Data.DataRowView = e.Item.DataItem
        Dim l As String = "|"

        'Head
        Dim sbHeadItem As New StringBuilder
        sbHeadItem.Append(reportYear) '0
        sbHeadItem.Append(l + e.Item.DataItem("store_name")) '1
        sbHeadItem.Append(l + e.Item.DataItem("cnum").ToString) '2
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("sumtotalarea").ToString)) '3
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("Sumsalearea").ToString)) '4
        sbHeadItem.Append(l + ClsManage.convert2Currency3(e.Item.DataItem("productivity").ToString)) '5
        sbHeadItem.Append(l + e.Item.DataItem("yoy_growth").ToString) '6
        sbHeadItem.Append(l + e.Item.DataItem("lfl_growth").ToString) '7

        Dim tbHead As New StringBuilder
        tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='3'><div style='width:175px'><strong>{0}</strong></div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center'><div style='width:110px'><strong>{1}</strong></div></TD><TD align='center'><div style='width:65px;'><strong>% Sale</strong></div></TD> <TD align='center'><div style='width:85px;'><strong>% YOY</strong></div></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:110px'><strong>{2}</strong></div></TD><TD align='center'><div style='width:65px;'><strong></strong></div></TD><TD></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'><div style='width:110px;'>{3}</div></TD><TD align='center' class='rbg2'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:110px'>{4}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:110px'>{5}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:110px'></div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{6}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{7}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")
        tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:110px'></div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")

        Dim htmlHead As String = String.Format(tbHead.ToString, sbHeadItem.ToString.Split(l))

        hdfIndex.Value = Integer.Parse(hdfIndex.Value) + 1
        Dim sbBodyItem As New StringBuilder
        Dim sumTotalRevenue As Double = 0
        Dim valSumItem As Double = 0
        sumTotalRevenue = e.Item.DataItem("SumTotalRevenue")
        sbBodyItem.Append(hdfIndex.Value + l + hdfIndex.Value + l + hdfIndex.Value)

        Dim drYoy As Data.DataRow
        drYoy = clsBts.getYoyMtdTotal(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddllo.SelectedValue, ddlRate.SelectedValue).Rows(2)
        Dim valYoy As String = ""

        For i As Integer = 0 To drv.Row.ItemArray.Count - 1
            If drv.DataView.Table.Columns(i).ColumnName.Contains("Sum") Then
                If Not (drv.DataView.Table.Columns(i).ColumnName = "Sumtotalarea" Or drv.DataView.Table.Columns(i).ColumnName = "Sumsalearea") Then

                    valSumItem = drv.Row.ItemArray(i)
                    If drv.DataView.Table.Columns(i).ColumnName = "SumGrossProfit" Or drv.DataView.Table.Columns(i).ColumnName = "SumAdjustedGrossMargin" Or drv.DataView.Table.Columns(i).ColumnName = "SumStoreTradingProfit__Loss" Then
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

        Dim tbBody As New StringBuilder
        tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:110px'>{3}</div></TD><TD align='right'><div style='width:65px;'>{4}%</div></TD><TD class='tdyoy1'>{5}</TD></TR>")
        tbBody.Append("<TR id='aa1c{1}'><TD align='right'><div style='width:110px'>{6}</div></TD><TD align='right'><div style='width:65px;'>{7}%</div></TD><TD class='tdyoy1'>{8}</TD></TR>")
        tbBody.Append("<TR id='aa2c{1}'><TD align='right'><div style='width:110px'>{9}</div></TD><TD align='right'><div style='width:65px;'>{10}%</div></TD><TD class='tdyoy1'>{11}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>{12}</div></TD><TD align='right'><div style='width:65px;'>{13}%</div></TD><TD class='tdyoy1'>{14}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{15}</div></TD><TD align='right'><div style='width:65px;'>{16}%</div></TD><TD class='tdyoy1'>{17}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>{18}</div></TD><TD align='right'><div style='width:65px;'>{19}%</div></TD><TD class='tdyoy1'>{20}</TD></TR>")
        tbBody.Append("<TR id='b1c{1}'><TD align='right'><div style='width:110px'>{21}</div></TD><TD align='right'><div style='width:65px;'>{22}%</div></TD><TD class='tdyoy1'>{23}</TD></TR>")
        tbBody.Append("<TR id='b2c{1}'><TD align='right'><div style='width:110px'>{24}</div></TD><TD align='right'><div style='width:65px;'>{25}%</div></TD><TD class='tdyoy1'>{26}</TD></TR>")
        tbBody.Append("<TR id='b3c{1}'><TD align='right'><div style='width:110px'>{27}</div></TD><TD align='right'><div style='width:65px;'>{28}%</div></TD><TD class='tdyoy1'>{29}</TD></TR>")
        tbBody.Append("<TR id='b4c{1}'><TD align='right'><div style='width:110px'>{30}</div></TD><TD align='right'><div style='width:65px;'>{31}%</div></TD><TD class='tdyoy1'>{32}</TD></TR>")
        tbBody.Append("<TR id='b5c{1}'><TD align='right'><div style='width:110px'>{33}</div></TD><TD align='right'><div style='width:65px;'>{34}%</div></TD><TD class='tdyoy1'>{35}</TD></TR>")
        tbBody.Append("<TR id='b6c{1}'><TD align='right'><div style='width:110px'>{36}</div></TD><TD align='right'><div style='width:65px;'>{37}%</div></TD><TD class='tdyoy1'>{38}</TD></TR>")
        tbBody.Append("<TR id='b7c{1}'><TD align='right'><div style='width:110px'>{39}</div></TD><TD align='right'><div style='width:65px;'>{40}%</div></TD><TD class='tdyoy1'>{41}</TD></TR>")
        tbBody.Append("<TR id='b8c{1}'><TD align='right'><div style='width:110px'>{42}</div></TD><TD align='right'><div style='width:65px;'>{43}%</div></TD><TD class='tdyoy1'>{44}</TD></TR>")
        tbBody.Append("<TR id='b9c{1}'><TD align='right'><div style='width:110px'>{45}</div></TD><TD align='right'><div style='width:65px;'>{46}%</div></TD><TD class='tdyoy1'>{47}</TD></TR>")
        tbBody.Append("<TR id='b10c{1}'><TD align='right'><div style='width:110px'>{48}</div></TD><TD align='right'><div style='width:65px;'>{49}%</div></TD><TD class='tdyoy1'>{50}</TD></TR>")
        tbBody.Append("<TR id='b11c{1}'><TD align='right'><div style='width:110px'>{51}</div></TD><TD align='right'><div style='width:65px;'>{52}%</div></TD><TD class='tdyoy1'>{53}</TD></TR>")
        tbBody.Append("<TR id='b12c{1}'><TD align='right'><div style='width:110px'>{54}</div></TD><TD align='right'><div style='width:65px;'>{55}%</div></TD><TD class='tdyoy1'>{56}</TD></TR>")
        tbBody.Append("<TR id='b13c{1}'><TD align='right'><div style='width:110px'>{57}</div></TD><TD align='right'><div style='width:65px;'>{58}%</div></TD><TD class='tdyoy1'>{59}</TD></TR>")
        tbBody.Append("<TR id='b14c{1}'><TD align='right'><div style='width:110px'>{60}</div></TD><TD align='right'><div style='width:65px;'>{61}%</div></TD><TD class='tdyoy1'>{62}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:110px'>{63}</div></TD><TD align='right'><div style='width:65px;'>{64}%</div></TD><TD class='tdyoy1'>{65}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;border-bottom:1px solid #2c2b2b;' class='rbg2'><TD align='right'><div style='width:110px'>{66}</div></TD><TD align='right'><div style='width:65px;'>{67}%</div></TD><TD class='tdyoy1'>{68}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{69}</div></TD><TD align='right'><div style='width:65px;'>{70}%</div></TD><TD class='tdyoy1'>{71}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:110px'>{72}</div></TD><TD align='right'><div style='width:65px;'>{73}%</div></TD><TD class='tdyoy1'>{74}</TD></TR>")
        tbBody.Append("<TR id='e1c{1}'><TD align='right'><div style='width:110px'>{75}</div></TD><TD align='right'><div style='width:65px;'>{76}%</div></TD><TD class='tdyoy1'>{77}</TD></TR>")
        tbBody.Append("<TR id='e2c{1}'><TD align='right'><div style='width:110px'>{78}</div></TD><TD align='right'><div style='width:65px;'>{79}%</div></TD><TD class='tdyoy1'>{80}</TD></TR>")
        tbBody.Append("<TR id='e3c{1}'><TD align='right'><div style='width:110px'>{81}</div></TD><TD align='right'><div style='width:65px;'>{82}%</div></TD><TD class='tdyoy1'>{83}</TD></TR>")
        tbBody.Append("<TR id='e4c{1}'><TD align='right'><div style='width:110px'>{84}</div></TD><TD align='right'><div style='width:65px;'>{85}%</div></TD><TD class='tdyoy1'>{86}</TD></TR>")
        tbBody.Append("<TR id='e5c{1}'><TD align='right'><div style='width:110px'>{87}</div></TD><TD align='right'><div style='width:65px;'>{88}%</div></TD><TD class='tdyoy1'>{89}</TD></TR>")
        tbBody.Append("<TR id='e6c{1}'><TD align='right'><div style='width:110px'>{90}</div></TD><TD align='right'><div style='width:65px;'>{91}%</div></TD><TD class='tdyoy1'>{92}</TD></TR>")
        tbBody.Append("<TR id='e7c{1}'><TD align='right'><div style='width:110px'>{93}</div></TD><TD align='right'><div style='width:65px;'>{94}%</div></TD><TD class='tdyoy1'>{95}</TD></TR>")
        tbBody.Append("<TR id='e8c{1}'><TD align='right'><div style='width:110px'>{96}</div></TD><TD align='right'><div style='width:65px;'>{97}%</div></TD><TD class='tdyoy1'>{98}</TD></TR>")
        tbBody.Append("<TR id='e9c{1}'><TD align='right'><div style='width:110px'>{99}</div></TD><TD align='right'><div style='width:65px;'>{100}%</div></TD><TD class='tdyoy1'>{101}</TD></TR>")
        tbBody.Append("<TR id='e10c{1}'><TD align='right'><div style='width:110px'>{102}</div></TD><TD align='right'><div style='width:65px;'>{103}%</div></TD><TD class='tdyoy1'>{104}</TD></TR>")
        tbBody.Append("<TR id='e11c{1}'><TD align='right'><div style='width:110px'>{105}</div></TD><TD align='right'><div style='width:65px;'>{106}%</div></TD><TD class='tdyoy1'>{107}</TD></TR>")
        tbBody.Append("<TR id='e12c{1}'><TD align='right'><div style='width:110px'>{108}</div></TD><TD align='right'><div style='width:65px;'>{109}%</div></TD><TD class='tdyoy1'>{110}</TD></TR>")
        tbBody.Append("<TR id='e13c{1}'><TD align='right'><div style='width:110px'>{111}</div></TD><TD align='right'><div style='width:65px;'>{112}%</div></TD><TD class='tdyoy1'>{113}</TD></TR>")
        tbBody.Append("<TR id='e14c{1}'><TD align='right'><div style='width:110px'>{114}</div></TD><TD align='right'><div style='width:65px;'>{115}%</div></TD><TD class='tdyoy1'>{116}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:110px'>{117}</div></TD><TD align='right'><div style='width:65px;'>{118}%</div></TD><TD class='tdyoy1'>{119}</TD></TR>")
        tbBody.Append("<TR id='f1c{1}'><TD align='right'><div style='width:110px'>{120}</div></TD><TD align='right'><div style='width:65px;'>{121}%</div></TD><TD class='tdyoy1'>{122}</TD></TR>")
        tbBody.Append("<TR id='f2c{1}'><TD align='right'><div style='width:110px'>{123}</div></TD><TD align='right'><div style='width:65px;'>{124}%</div></TD><TD class='tdyoy1'>{125}</TD></TR>")
        tbBody.Append("<TR id='f3c{1}'><TD align='right'><div style='width:110px'>{126}</div></TD><TD align='right'><div style='width:65px;'>{127}%</div></TD><TD class='tdyoy1'>{128}</TD></TR>")
        tbBody.Append("<TR id='f4c{1}'><TD align='right'><div style='width:110px'>{129}</div></TD><TD align='right'><div style='width:65px;'>{130}%</div></TD><TD class='tdyoy1'>{131}</TD></TR>")
        tbBody.Append("<TR id='f5c{1}'><TD align='right'><div style='width:110px'>{132}</div></TD><TD align='right'><div style='width:65px;'>{133}%</div></TD><TD class='tdyoy1'>{134}</TD></TR>")
        tbBody.Append("<TR id='f6c{1}'><TD align='right'><div style='width:110px'>{135}</div></TD><TD align='right'><div style='width:65px;'>{136}%</div></TD><TD class='tdyoy1'>{137}</TD></TR>")
        tbBody.Append("<TR id='f7c{1}'><TD align='right'><div style='width:110px'>{138}</div></TD><TD align='right'><div style='width:65px;'>{139}%</div></TD><TD class='tdyoy1'>{140}</TD></TR>")
        tbBody.Append("<TR id='f8c{1}'><TD align='right'><div style='width:110px'>{141}</div></TD><TD align='right'><div style='width:65px;'>{142}%</div></TD><TD class='tdyoy1'>{143}</TD></TR>")
        tbBody.Append("<TR id='f9c{1}'><TD align='right'><div style='width:110px'>{144}</div></TD><TD align='right'><div style='width:65px;'>{145}%</div></TD><TD class='tdyoy1'>{146}</TD></TR>")
        tbBody.Append("<TR id='f10c{1}'><TD align='right'><div style='width:110px'>{147}</div></TD><TD align='right'><div style='width:65px;'>{148}%</div></TD><TD class='tdyoy1'>{149}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:110px'>{150}</div></TD><TD align='right'><div style='width:65px;'>{151}%</div></TD><TD class='tdyoy1'>{152}</TD></TR>")
        tbBody.Append("<TR id='g1c{1}'><TD align='right'><div style='width:110px'>{153}</div></TD><TD align='right'><div style='width:65px;'>{154}%</div></TD><TD class='tdyoy1'>{155}</TD></TR>")
        tbBody.Append("<TR id='g2c{1}'><TD align='right'><div style='width:110px'>{156}</div></TD><TD align='right'><div style='width:65px;'>{157}%</div></TD><TD class='tdyoy1'>{158}</TD></TR>")
        tbBody.Append("<TR id='g3c{1}'><TD align='right'><div style='width:110px'>{159}</div></TD><TD align='right'><div style='width:65px;'>{160}%</div></TD><TD class='tdyoy1'>{161}</TD></TR>")
        tbBody.Append("<TR id='g4c{1}'><TD align='right'><div style='width:110px'>{162}</div></TD><TD align='right'><div style='width:65px;'>{163}%</div></TD><TD class='tdyoy1'>{164}</TD></TR>")
        tbBody.Append("<TR id='g5c{1}'><TD align='right'><div style='width:110px'>{165}</div></TD><TD align='right'><div style='width:65px;'>{166}%</div></TD><TD class='tdyoy1'>{167}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:110px'>{168}</div></TD><TD align='right'><div style='width:65px;'>{169}%</div></TD><TD class='tdyoy1'>{170}</TD></TR>")
        tbBody.Append("<TR id='h1c{1}'><TD align='right'><div style='width:110px'>{171}</div></TD><TD align='right'><div style='width:65px;'>{172}%</div></TD><TD class='tdyoy1'>{173}</TD></TR>")
        tbBody.Append("<TR id='h2c{1}'><TD align='right'><div style='width:110px'>{174}</div></TD><TD align='right'><div style='width:65px;'>{175}%</div></TD><TD class='tdyoy1'>{176}</TD></TR>")
        tbBody.Append("<TR id='h3c{1}'><TD align='right'><div style='width:110px'>{177}</div></TD><TD align='right'><div style='width:65px;'>{178}%</div></TD><TD class='tdyoy1'>{179}</TD></TR>")
        tbBody.Append("<TR id='h4c{1}'><TD align='right'><div style='width:110px'>{180}</div></TD><TD align='right'><div style='width:65px;'>{181}%</div></TD><TD class='tdyoy1'>{182}</TD></TR>")
        tbBody.Append("<TR id='h5c{1}'><TD align='right'><div style='width:110px'>{183}</div></TD><TD align='right'><div style='width:65px;'>{184}%</div></TD><TD class='tdyoy1'>{185}</TD></TR>")
        tbBody.Append("<TR id='h6c{1}'><TD align='right'><div style='width:110px'>{186}</div></TD><TD align='right'><div style='width:65px;'>{187}%</div></TD><TD class='tdyoy1'>{188}</TD></TR>")
        tbBody.Append("<TR id='h7c{1}'><TD align='right'><div style='width:110px'>{189}</div></TD><TD align='right'><div style='width:65px;'>{190}%</div></TD><TD class='tdyoy1'>{191}</TD></TR>")
        tbBody.Append("<TR id='h8c{1}'><TD align='right'><div style='width:110px'>{192}</div></TD><TD align='right'><div style='width:65px;'>{193}%</div></TD><TD class='tdyoy1'>{194}</TD></TR>")
        tbBody.Append("<TR id='h9c{1}'><TD align='right'><div style='width:110px'>{195}</div></TD><TD align='right'><div style='width:65px;'>{196}%</div></TD><TD class='tdyoy1'>{197}</TD></TR>")
        tbBody.Append("<TR id='h10c{1}'><TD align='right'><div style='width:110px'>{198}</div></TD><TD align='right'><div style='width:65px;'>{199}%</div></TD><TD class='tdyoy1'>{200}</TD></TR>")
        tbBody.Append("<TR id='h11c{1}'><TD align='right'><div style='width:110px'>{201}</div></TD><TD align='right'><div style='width:65px;'>{202}%</div></TD><TD class='tdyoy1'>{203}</TD></TR>")
        tbBody.Append("<TR id='h12c{1}'><TD align='right'><div style='width:110px'>{204}</div></TD><TD align='right'><div style='width:65px;'>{205}%</div></TD><TD class='tdyoy1'>{206}</TD></TR>")
        tbBody.Append("<TR id='h13c{1}'><TD align='right'><div style='width:110px'>{207}</div></TD><TD align='right'><div style='width:65px;'>{208}%</div></TD><TD class='tdyoy1'>{209}</TD></TR>")
        tbBody.Append("<TR id='h14c{1}'><TD align='right'><div style='width:110px'>{210}</div></TD><TD align='right'><div style='width:65px;'>{211}%</div></TD><TD class='tdyoy1'>{212}</TD></TR>")
        tbBody.Append("<TR id='h15c{1}'><TD align='right'><div style='width:110px'>{213}</div></TD><TD align='right'><div style='width:65px;'>{214}%</div></TD><TD class='tdyoy1'>{215}</TD></TR>")
        tbBody.Append("<TR id='h16c{1}'><TD align='right'><div style='width:110px'>{216}</div></TD><TD align='right'><div style='width:65px;'>{217}%</div></TD><TD class='tdyoy1'>{218}</TD></TR>")
        tbBody.Append("<TR id='h17c{1}'><TD align='right'><div style='width:110px'>{219}</div></TD><TD align='right'><div style='width:65px;'>{220}%</div></TD><TD class='tdyoy1'>{221}</TD></TR>")
        tbBody.Append("<TR id='h18c{1}'><TD align='right'><div style='width:110px'>{222}</div></TD><TD align='right'><div style='width:65px;'>{223}%</div></TD><TD class='tdyoy1'>{224}</TD></TR>")
        tbBody.Append("<TR id='h19c{1}'><TD align='right'><div style='width:110px'>{225}</div></TD><TD align='right'><div style='width:65px;'>{226}%</div></TD><TD class='tdyoy1'>{227}</TD></TR>")
        tbBody.Append("<TR id='h20c{1}'><TD align='right'><div style='width:110px'>{228}</div></TD><TD align='right'><div style='width:65px;'>{229}%</div></TD><TD class='tdyoy1'>{230}</TD></TR>")
        tbBody.Append("<TR id='h21c{1}'><TD align='right'><div style='width:110px'>{231}</div></TD><TD align='right'><div style='width:65px;'>{232}%</div></TD><TD class='tdyoy1'>{233}</TD></TR>")
        tbBody.Append("<TR id='h22c{1}'><TD align='right'><div style='width:110px'>{234}</div></TD><TD align='right'><div style='width:65px;'>{235}%</div></TD><TD class='tdyoy1'>{236}</TD></TR>")
        tbBody.Append("<TR id='h23c{1}'><TD align='right'><div style='width:110px'>{237}</div></TD><TD align='right'><div style='width:65px;'>{238}%</div></TD><TD class='tdyoy1'>{239}</TD></TR>")
        tbBody.Append("<TR id='h24c{1}'><TD align='right'><div style='width:110px'>{240}</div></TD><TD align='right'><div style='width:65px;'>{241}%</div></TD><TD class='tdyoy1'>{242}</TD></TR>")
        tbBody.Append("<TR id='h25c{1}'><TD align='right'><div style='width:110px'>{243}</div></TD><TD align='right'><div style='width:65px;'>{244}%</div></TD><TD class='tdyoy1'>{245}</TD></TR>")
        tbBody.Append("<TR id='h26c{1}'><TD align='right'><div style='width:110px'>{246}</div></TD><TD align='right'><div style='width:65px;'>{247}%</div></TD><TD class='tdyoy1'>{248}</TD></TR>")
        tbBody.Append("<TR id='h27c{1}'><TD align='right'><div style='width:110px'>{249}</div></TD><TD align='right'><div style='width:65px;'>{250}%</div></TD><TD class='tdyoy1'>{251}</TD></TR>")
        tbBody.Append("<TR id='h28c{1}'><TD align='right'><div style='width:110px'>{252}</div></TD><TD align='right'><div style='width:65px;'>{253}%</div></TD><TD class='tdyoy1'>{254}</TD></TR>")
        tbBody.Append("<TR id='h29c{1}'><TD align='right'><div style='width:110px'>{255}</div></TD><TD align='right'><div style='width:65px;'>{256}%</div></TD><TD class='tdyoy1'>{257}</TD></TR>")
        tbBody.Append("<TR id='h30c{1}'><TD align='right'><div style='width:110px'>{258}</div></TD><TD align='right'><div style='width:65px;'>{259}%</div></TD><TD class='tdyoy1'>{260}</TD></TR>")
        tbBody.Append("<TR id='h31c{1}'><TD align='right'><div style='width:110px'>{261}</div></TD><TD align='right'><div style='width:65px;'>{262}%</div></TD><TD class='tdyoy1'>{263}</TD></TR>")
        tbBody.Append("<TR id='h32c{1}'><TD align='right'><div style='width:110px'>{264}</div></TD><TD align='right'><div style='width:65px;'>{265}%</div></TD><TD class='tdyoy1'>{266}</TD></TR>")
        tbBody.Append("<TR id='h33c{1}'><TD align='right'><div style='width:110px'>{267}</div></TD><TD align='right'><div style='width:65px;'>{268}%</div></TD><TD class='tdyoy1'>{269}</TD></TR>")
        tbBody.Append("<TR id='h34c{1}'><TD align='right'><div style='width:110px'>{270}</div></TD><TD align='right'><div style='width:65px;'>{271}%</div></TD><TD class='tdyoy1'>{272}</TD></TR>")
        tbBody.Append("<TR id='h35c{1}'><TD align='right'><div style='width:110px'>{273}</div></TD><TD align='right'><div style='width:65px;'>{274}%</div></TD><TD class='tdyoy1'>{275}</TD></TR>")
        tbBody.Append("<TR id='h36c{1}'><TD align='right'><div style='width:110px'>{276}</div></TD><TD align='right'><div style='width:65px;'>{277}%</div></TD><TD class='tdyoy1'>{278}</TD></TR>")
        tbBody.Append("<TR id='h37c{1}'><TD align='right'><div style='width:110px'>{279}</div></TD><TD align='right'><div style='width:65px;'>{280}%</div></TD><TD class='tdyoy1'>{281}</TD></TR>")
        tbBody.Append("<TR id='h38c{1}'><TD align='right'><div style='width:110px'>{282}</div></TD><TD align='right'><div style='width:65px;'>{283}%</div></TD><TD class='tdyoy1'>{284}</TD></TR>")
        tbBody.Append("<TR id='h39c{1}'><TD align='right'><div style='width:110px'>{285}</div></TD><TD align='right'><div style='width:65px;'>{286}%</div></TD><TD class='tdyoy1'>{287}</TD></TR>")
        tbBody.Append("<TR id='h40c{1}'><TD align='right'><div style='width:110px'>{288}</div></TD><TD align='right'><div style='width:65px;'>{289}%</div></TD><TD class='tdyoy1'>{290}</TD></TR>")
        tbBody.Append("<TR id='h41c{1}'><TD align='right'><div style='width:110px'>{291}</div></TD><TD align='right'><div style='width:65px;'>{292}%</div></TD><TD class='tdyoy1'>{293}</TD></TR>")
        tbBody.Append("<TR id='h42c{1}'><TD align='right'><div style='width:110px'>{294}</div></TD><TD align='right'><div style='width:65px;'>{295}%</div></TD><TD class='tdyoy1'>{296}</TD></TR>")
        tbBody.Append("<TR id='h43c{1}'><TD align='right'><div style='width:110px'>{297}</div></TD><TD align='right'><div style='width:65px;'>{298}%</div></TD><TD class='tdyoy1'>{299}</TD></TR>")
        tbBody.Append("<TR id='h44c{1}'><TD align='right'><div style='width:110px'>{300}</div></TD><TD align='right'><div style='width:65px;'>{301}%</div></TD><TD class='tdyoy1'>{302}</TD></TR>")
        tbBody.Append("<TR id='h45c{1}'><TD align='right'><div style='width:110px'>{303}</div></TD><TD align='right'><div style='width:65px;'>{304}%</div></TD><TD class='tdyoy1'>{305}</TD></TR>")
        tbBody.Append("<TR id='h46c{1}'><TD align='right'><div style='width:110px'>{306}</div></TD><TD align='right'><div style='width:65px;'>{307}%</div></TD><TD class='tdyoy1'>{308}</TD></TR>")
        tbBody.Append("<TR id='h47c{1}'><TD align='right'><div style='width:110px'>{309}</div></TD><TD align='right'><div style='width:65px;'>{310}%</div></TD><TD class='tdyoy1'>{311}</TD></TR>")
        tbBody.Append("<TR id='h48c{1}'><TD align='right'><div style='width:110px'>{312}</div></TD><TD align='right'><div style='width:65px;'>{313}%</div></TD><TD class='tdyoy1'>{314}</TD></TR>")
        tbBody.Append("<TR id='h49c{1}'><TD align='right'><div style='width:110px'>{315}</div></TD><TD align='right'><div style='width:65px;'>{316}%</div></TD><TD class='tdyoy1'>{317}</TD></TR>")
        tbBody.Append("<TR id='h50c{1}'><TD align='right'><div style='width:110px'>{318}</div></TD><TD align='right'><div style='width:65px;'>{319}%</div></TD><TD class='tdyoy1'>{320}</TD></TR>")
        tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:110px'>{321}</div></TD><TD align='right'><div style='width:65px;'>{322}%</div></TD><TD class='tdyoy1'>{323}</TD></TR>")

        Dim htmlBody As String = String.Format(tbBody.ToString, sbBodyItem.ToString.Split(l))

        'Foot
        Dim sbFootItem As New StringBuilder
        sbFootItem.Append(e.Item.DataItem("yoy_loss_growth").ToString) '0
        sbFootItem.Append(l + e.Item.DataItem("lfl_loss_growth").ToString) '1

        Dim tbFoot As New StringBuilder
        tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{0}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")
        tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:110px'>{1}</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD></TD></TR>")
        tbFoot.Append("</TABLE>")
        Dim htmlFoot As String = String.Format(tbFoot.ToString, sbFootItem.ToString.Split(l))

        CType(e.Item.FindControl("lbl"), Label).Text = htmlHead + htmlBody + htmlFoot
    End Sub
End Class
