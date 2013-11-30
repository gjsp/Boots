
Partial Class report_performance
    Inherits basePage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'divEndDate.Visible = False
            ddlBy.Attributes.Add("onchange", "swepDate(this);")
            ddlYear.AutoPostBack = True
            ddlYear2.AutoPostBack = True

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
            gv.EmptyDataText = "<div style='color:red;text-align:center;border:solid 0px silver;width:650px'>No Data</div>"

        End If
    End Sub

    Protected Sub SearchBt_Click(sender As Object, e As System.EventArgs) Handles SearchBt.Click
        Try
            Dim bDate As String = "1/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue
            Dim eDate As String = "1/" + ddlMonth2.SelectedValue + "/" + ddlYear2.SelectedValue
            ods.SelectParameters("rate").DefaultValue = ddlRate.SelectedValue
            ods.SelectParameters("bdate").DefaultValue = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
            ods.SelectParameters("eDate").DefaultValue = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing)
            ods.SelectParameters("by").DefaultValue = ddlBy.SelectedItem.Text
            gv.DataSourceID = ods.ID
            gv.DataBind()
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub gv_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        'If e.Row.RowType = DataControlRowType.Header Then

        '    Dim creatCels As New SortedList

        '    creatCels.Add("00", "Summary,5,1")
        '    creatCels.Add("01", ",1,1")
        '    creatCels.Add("02", ",1,1")
        '    creatCels.Add("03", ",1,1")
        '    creatCels.Add("04", ",1,1")
        '    creatCels.Add("05", ",1,1")

        '    getMultiHeader(e, creatCels)

        'End If


        If e.Row.RowType = DataControlRowType.Header Then
            Me.ViewState("item") = Nothing
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Me.ViewState("item") Is Nothing Then
                Dim drv As Data.DataRowView = e.Row.DataItem
                Me.ViewState("item") = drv.DataView.Table
            End If

            If e.Row.DataItem("TradingProfit") < 0 Then
                e.Row.Cells(gv.Columns.Count - 3).Text = String.Format("<span style='color:red'>({0})</span>", clsPfm.convert2TradingProfit(e.Row.DataItem("TradingProfit").ToString))
            Else
                e.Row.Cells(gv.Columns.Count - 3).Text = clsPfm.convert2TradingProfit(e.Row.DataItem("TradingProfit").ToString)
            End If

            If e.Row.DataItem("InDate") = "y" Then
                e.Row.Attributes.Add("style", "background-color:#FFFF99")
            End If
        End If

        If e.Row.RowType = DataControlRowType.Footer Then

            'Dim formatQuan As String = "##0"
            'Dim formatAmount As String = "##0"
            If Me.ViewState("item") IsNot Nothing Then
                Dim dt As New Data.DataTable
                dt = Me.ViewState("item")
                Dim dtSum As New Data.DataTable
                dtSum = dt.Clone
                Dim dr As Data.DataRow = dtSum.NewRow
                Dim month_diff As Integer = dt.Rows(0)("monthdiff")
                'P:Profit marker,L:loss Maker
                Dim num_P1 As Integer = 0 : Dim num_L1 As Integer = 0
                Dim num_P2 As Integer = 0 : Dim num_L2 As Integer = 0

                Dim sumArea_P1 As Double = 0 : Dim sumArea_P2 As Double = 0
                Dim sumArea_L1 As Double = 0 : Dim sumArea_L2 As Double = 0

                Dim TotalRevenue_P1 As Double = 0 : Dim TotalRevenue_P2 As Double = 0
                Dim TotalRevenue_L1 As Double = 0 : Dim TotalRevenue_L2 As Double = 0

                Dim sumGross_P1 As Double = 0 : Dim sumGross_P2 As Double = 0
                Dim sumGross_L1 As Double = 0 : Dim sumGross_L2 As Double = 0

                Dim sumAdjGross_P1 As Double = 0 : Dim sumAdjGross_P2 As Double = 0
                Dim sumAdjGross_L1 As Double = 0 : Dim sumAdjGross_L2 As Double = 0

                Dim sumOPEX_P1 As Double = 0 : Dim sumOPEX_P2 As Double = 0
                Dim sumOPEX_L1 As Double = 0 : Dim sumOPEX_L2 As Double = 0

                Dim sumTP_P1 As Double = 0 : Dim sumTP_P2 As Double = 0 'Trading Profit
                Dim sumTP_L1 As Double = 0 : Dim sumTP_L2 As Double = 0

                Dim lastRevenue_P1 As Double = 0 : Dim lastRevenue_P2 As Double = 0
                Dim lastRevenue_L1 As Double = 0 : Dim lastRevenue_L2 As Double = 0

                Dim thisRevenue_P1 As Double = 0 : Dim thisRevenue_P2 As Double = 0
                Dim thisRevenue_L1 As Double = 0 : Dim thisRevenue_L2 As Double = 0

                For Each dr In dt.Rows
                    If dr("TradingProfit") < 0 Then
                        If dr("store_name").ToString <> clsBts.storeNoCount Then num_L1 += 1
                        sumArea_L1 += ClsManage.convert2zero(dr("costcenter_sale_area").ToString)
                        TotalRevenue_L1 += ClsManage.convert2zero(dr("TotalRevenue").ToString)
                        sumGross_L1 += ClsManage.convert2zero(dr("GrossProfit").ToString)
                        sumAdjGross_L1 += ClsManage.convert2zero(dr("AdjustedGrossMargin").ToString)
                        sumOPEX_L1 += ClsManage.convert2zero(dr("OPEX").ToString)
                        sumTP_L1 += ClsManage.convert2zero(dr("TradingProfit").ToString)
                        If dr("% LFL").ToString <> "N/A" Then
                            lastRevenue_L1 += ClsManage.convert2zero(dr("lastRevenue").ToString)
                            thisRevenue_L1 += ClsManage.convert2zero(dr("TotalRevenue").ToString)
                        End If
                    Else
                        If dr("store_name").ToString <> clsBts.storeNoCount Then num_P1 += 1
                        sumArea_P1 += ClsManage.convert2zero(dr("costcenter_sale_area").ToString)
                        TotalRevenue_P1 += ClsManage.convert2zero(dr("TotalRevenue").ToString)
                        sumGross_P1 += ClsManage.convert2zero(dr("GrossProfit").ToString)
                        sumAdjGross_P1 += ClsManage.convert2zero(dr("AdjustedGrossMargin").ToString)
                        sumOPEX_P1 += ClsManage.convert2zero(dr("OPEX").ToString)
                        sumTP_P1 += ClsManage.convert2zero(dr("TradingProfit").ToString)

                        If dr("% LFL").ToString <> "N/A" Then
                            lastRevenue_P1 += ClsManage.convert2zero(dr("lastRevenue").ToString)
                            thisRevenue_P1 += ClsManage.convert2zero(dr("TotalRevenue").ToString)
                        End If

                    End If

                    If dr("InDate") = "n" Then
                        If dr("TradingProfit") < 0 Then
                            If dr("store_name").ToString <> clsBts.storeNoCount Then num_L2 += 1
                            sumArea_L2 += ClsManage.convert2zero(dr("costcenter_sale_area").ToString)
                            TotalRevenue_L2 += ClsManage.convert2zero(dr("TotalRevenue").ToString)
                            sumGross_L2 += ClsManage.convert2zero(dr("GrossProfit").ToString)
                            sumAdjGross_L2 += ClsManage.convert2zero(dr("AdjustedGrossMargin").ToString)
                            sumOPEX_L2 += ClsManage.convert2zero(dr("OPEX").ToString)
                            sumTP_L2 += ClsManage.convert2zero(dr("TradingProfit").ToString)

                            If dr("% LFL").ToString <> "N/A" Then
                                lastRevenue_L2 += ClsManage.convert2zero(dr("lastRevenue").ToString)
                                thisRevenue_L2 += ClsManage.convert2zero(dr("TotalRevenue").ToString)
                            End If
                        Else

                            If dr("store_name").ToString <> clsBts.storeNoCount Then num_P2 += 1
                            sumArea_P2 += ClsManage.convert2zero(dr("costcenter_sale_area").ToString)
                            TotalRevenue_P2 += ClsManage.convert2zero(dr("TotalRevenue").ToString)
                            sumGross_P2 += ClsManage.convert2zero(dr("GrossProfit").ToString)
                            sumAdjGross_P2 += ClsManage.convert2zero(dr("AdjustedGrossMargin").ToString)
                            sumOPEX_P2 += ClsManage.convert2zero(dr("OPEX").ToString)
                            sumTP_P2 += ClsManage.convert2zero(dr("TradingProfit").ToString)

                            If dr("% LFL").ToString <> "N/A" Then
                                lastRevenue_P2 += ClsManage.convert2zero(dr("lastRevenue").ToString)
                                thisRevenue_P2 += ClsManage.convert2zero(dr("TotalRevenue").ToString)
                            End If
                        End If
                    End If
                Next

                'Summary 1
                'Dim sumNum1 As Integer = num_P1 + num_L1
                Dim TotalRevenue_1 As Double = TotalRevenue_P1 + TotalRevenue_L1

                Dim resultProduct_P1 As String = getRightCell(clsPfm.convert2TradingProfit(Math.Round(TotalRevenue_P1 / sumArea_P1 / month_diff, 2).ToString))
                Dim resultProduct_L1 As String = getRightCell(clsPfm.convert2TradingProfit(Math.Round(TotalRevenue_L1 / sumArea_L1 / month_diff, 2).ToString))
                Dim resultProduct1 As String = getRightCell(clsPfm.convert2TradingProfit(Math.Round((TotalRevenue_1 / (sumArea_P1 + sumArea_L1)) / month_diff, 2).ToString))

                Dim resultGross_P1 As String = getRightCell(clsPfm.convert2RoundPer(sumGross_P1 / TotalRevenue_P1))
                Dim resultGross_L1 As String = getRightCell(clsPfm.convert2RoundPer(sumGross_L1 / TotalRevenue_L1))
                Dim resultGross_Total1 As String = getRightCell(clsPfm.convert2RoundPer((sumGross_L1 + sumGross_P1) / TotalRevenue_1))

                Dim resultAdjGross_P1 As String = getRightCell(clsPfm.convert2RoundPer(sumAdjGross_P1 / TotalRevenue_P1))
                Dim resultAdjGross_L1 As String = getRightCell(clsPfm.convert2RoundPer(sumAdjGross_L1 / TotalRevenue_L1))
                Dim resultAdjGross_Total1 As String = getRightCell(clsPfm.convert2RoundPer((sumAdjGross_L1 + sumAdjGross_P1) / TotalRevenue_1))

                Dim resultOPEX_P1 As String = getRightCell(clsPfm.convert2RoundPer(sumOPEX_P1 / TotalRevenue_P1))
                Dim resultOPEX_L1 As String = getRightCell(clsPfm.convert2RoundPer(sumOPEX_L1 / TotalRevenue_L1))
                Dim resultOPEX_Total1 As String = getRightCell(clsPfm.convert2RoundPer((sumOPEX_L1 + sumOPEX_P1) / TotalRevenue_1))

                Dim resultPerTP_P1 As String = getRightCell(clsPfm.convert2RoundPer(sumTP_P1 / TotalRevenue_P1))
                Dim resultPerTP_L1 As String = getRightCell(clsPfm.convert2RoundPer(sumTP_L1 / TotalRevenue_L1))
                Dim resultPerTP_Total1 As String = getRightCell(clsPfm.convert2RoundPer((sumTP_P1 + sumTP_L1) / TotalRevenue_1))

                Dim resultTP_P1 As String = getRightCell(convert2TradingProfit(Math.Round(sumTP_P1, 2).ToString))
                Dim resultTP_L1 As String = getRightCell(convert2TradingProfit(Math.Round(sumTP_L1, 2).ToString))
                Dim resultTP_Total1 As String = getRightCell(convert2TradingProfit(Math.Round(sumTP_P1 + sumTP_L1, 2).ToString))

                Dim resultLFL_P1 As String = getRightCell(ClsManage.convert2PercenLFLGrowth((thisRevenue_P1 / lastRevenue_P1) - 1))
                Dim resultLFL_L1 As String = getRightCell(ClsManage.convert2PercenLFLGrowth((thisRevenue_L1 / lastRevenue_L1) - 1))
                Dim resultLFL_Total1 As String = getRightCell(ClsManage.convert2PercenLFLGrowth(((thisRevenue_P1 + thisRevenue_L1) / (lastRevenue_P1 + lastRevenue_L1)) - 1))

                'Summary 2
                Dim sumNum2 As Integer = num_P2 + num_L2
                Dim TotalRevenue_2 As Double = TotalRevenue_P2 + TotalRevenue_L2

                Dim resultProduct_P2 As String = getRightCell(clsPfm.convert2TradingProfit(Math.Round(TotalRevenue_P2 / sumArea_P2 / month_diff, 2).ToString))
                Dim resultProduct_L2 As String = getRightCell(clsPfm.convert2TradingProfit(Math.Round(TotalRevenue_L2 / sumArea_L2 / month_diff, 2).ToString))
                Dim resultProduct2 As String = getRightCell(clsPfm.convert2TradingProfit(Math.Round((TotalRevenue_2 / (sumArea_P2 + sumArea_L2)) / month_diff, 2).ToString))

                Dim resultGross_P2 As String = getRightCell(clsPfm.convert2RoundPer(sumGross_P2 / TotalRevenue_P2))
                Dim resultGross_L2 As String = getRightCell(clsPfm.convert2RoundPer(sumGross_L2 / TotalRevenue_L2))
                Dim resultGross_Total2 As String = getRightCell(clsPfm.convert2RoundPer((sumGross_L2 + sumGross_P2) / TotalRevenue_2))

                Dim resultAdjGross_P2 As String = getRightCell(clsPfm.convert2RoundPer(sumAdjGross_P2 / TotalRevenue_P2))
                Dim resultAdjGross_L2 As String = getRightCell(clsPfm.convert2RoundPer(sumAdjGross_L2 / TotalRevenue_L2))
                Dim resultAdjGross_Total2 As String = getRightCell(clsPfm.convert2RoundPer((sumAdjGross_L2 + sumAdjGross_P2) / TotalRevenue_2))

                Dim resultOPEX_P2 As String = getRightCell(clsPfm.convert2RoundPer(sumOPEX_P2 / TotalRevenue_P2))
                Dim resultOPEX_L2 As String = getRightCell(clsPfm.convert2RoundPer(sumOPEX_L2 / TotalRevenue_L2))
                Dim resultOPEX_Total2 As String = getRightCell(clsPfm.convert2RoundPer((sumOPEX_L2 + sumOPEX_P2) / TotalRevenue_2))

                Dim resultPerTP_P2 As String = getRightCell(clsPfm.convert2RoundPer(sumTP_P2 / TotalRevenue_P2))
                Dim resultPerTP_L2 As String = getRightCell(clsPfm.convert2RoundPer(sumTP_L2 / TotalRevenue_L2))
                Dim resultPerTP_Total2 As String = getRightCell(clsPfm.convert2RoundPer((sumTP_P2 + sumTP_L2) / TotalRevenue_2))

                Dim resultTP_P2 As String = getRightCell(convert2TradingProfit(Math.Round(sumTP_P2, 2).ToString))
                Dim resultTP_L2 As String = getRightCell(convert2TradingProfit(Math.Round(sumTP_L2, 2).ToString))
                Dim resultTP_Total2 As String = getRightCell(convert2TradingProfit(Math.Round(sumTP_P2 + sumTP_L2, 2).ToString))

                Dim resultLFL_P2 As String = getRightCell(ClsManage.convert2PercenLFLGrowth((thisRevenue_P2 / lastRevenue_P2) - 1))
                Dim resultLFL_L2 As String = getRightCell(ClsManage.convert2PercenLFLGrowth((thisRevenue_L2 / lastRevenue_L2) - 1))
                Dim resultLFL_Total2 As String = getRightCell(ClsManage.convert2PercenLFLGrowth(((thisRevenue_P2 + thisRevenue_L2) / (lastRevenue_P2 + lastRevenue_L2)) - 1))


                createCels("#0099CC", True, e, String.Format("{0}|<div style='text-align:left'>Total</div>||{1}|{2}|{3}|{4}|{5}|{6}|{7}|", (num_L2 + num_P2).ToString, resultProduct2.ToString, resultGross_Total2, resultAdjGross_Total2, resultOPEX_Total2, resultPerTP_Total2, resultTP_Total2, resultLFL_Total2))
                createCels("#0099CC", False, e, String.Format("{0}|<div style='text-align:left'>Loss Maker</div>||{1}|{2}|{3}|{4}|{5}|{6}|{7}|", num_L2.ToString, resultProduct_L2.ToString, resultGross_L2.ToString, resultAdjGross_L2.ToString, resultOPEX_L2, resultPerTP_L2, resultTP_L2, resultLFL_L2))
                createCels("#0099CC", False, e, String.Format("{0}|<div style='text-align:left'>Profit Maker</div>||{1}|{2}|{3}|{4}|{5}|{6}|{7}|", num_P2.ToString, resultProduct_P2.ToString, resultGross_P2.ToString, resultAdjGross_P2.ToString, resultOPEX_P2, resultPerTP_P2, resultTP_P2, resultLFL_P2))
                createCels("#0099CC", True, e, String.Format("{0}|<div style='text-align:left'>Summary Exc.New Stores</div>||{1}|{2}|{3}|{4}|{5}|{6}|{7}|", "", "", "", "", "", "", "", ""))

                createCels("#336600", True, e, String.Format("{0}|<div style='text-align:left'>Total</div>||{1}|{2}|{3}|{4}|{5}|{6}|{7}|", (num_L1 + num_P1).ToString, resultProduct1.ToString, resultGross_Total1, resultAdjGross_Total1, resultOPEX_Total1, resultPerTP_Total1, resultTP_Total1, resultLFL_Total1))
                createCels("#336600", False, e, String.Format("{0}|<div style='text-align:left'>Loss Maker</div>||{1}|{2}|{3}|{4}|{5}|{6}|{7}|", num_L1.ToString, resultProduct_L1.ToString, resultGross_L1.ToString, resultAdjGross_L1.ToString, resultOPEX_L1, resultPerTP_L1, resultTP_L1, resultLFL_L1))
                createCels("#336600", False, e, String.Format("{0}|<div style='text-align:left'>Profit Maker</div>||{1}|{2}|{3}|{4}|{5}|{6}|{7}|", num_P1.ToString, resultProduct_P1.ToString, resultGross_P1.ToString, resultAdjGross_P1.ToString, resultOPEX_P1, resultPerTP_P1, resultTP_P1, resultLFL_P1))
                createCels("#336600", True, e, String.Format("{0}|<div style='text-align:left'>Summary</div>||{1}|{2}|{3}|{4}|{5}|{6}|{7}|", "", "", "", "", "", "", "", ""))

            End If
        End If
    End Sub

    Public Shared Function convert2TradingProfit(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return ""
            Else
                Dim result As Double = Double.Parse(str)
                If result < 0 Then
                    Return String.Format("<span style='color:red'>{0}</span>", (-result).ToString("(#,##0)"))
                Else
                    Return result.ToString("#,##0")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getRightCell(str As String) As String
        Return String.Format("<div style='text-align:right'>{0}</div>", str)
    End Function

    Private Sub createCels(color As String, fontBold As Boolean, ByVal e As GridViewRowEventArgs, str As String)
        Try
            Dim creatCels As New SortedList
            Dim strSplit As String = "|"
            creatCels.Add("01", "" + str.Split(strSplit)(0) + "|1|1")
            creatCels.Add("02", "" + str.Split(strSplit)(1) + "|1|1")
            creatCels.Add("03", "" + str.Split(strSplit)(2) + "|1|1")
            creatCels.Add("04", "" + str.Split(strSplit)(3) + "|1|1")
            creatCels.Add("05", "" + str.Split(strSplit)(4) + "|1|1")
            creatCels.Add("06", "" + str.Split(strSplit)(5) + "|1|1")
            creatCels.Add("07", "" + str.Split(strSplit)(6) + "|1|1")
            creatCels.Add("08", "" + str.Split(strSplit)(7) + "|1|1")
            creatCels.Add("09", "" + str.Split(strSplit)(8) + "|1|1")
            creatCels.Add("10", "" + str.Split(strSplit)(9) + "|1|1")
            creatCels.Add("11", "" + str.Split(strSplit)(10) + "|1|1")
            getMultiFooter(e, creatCels, color, fontBold)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub upPG_Load(sender As Object, e As System.EventArgs) Handles upPG.Load
        Threading.Thread.Sleep(upPG.DisplayAfter)
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        Try
            ddlMonth.DataValueField = "mon_year"
            ddlMonth.DataTextField = "mon_name"
            ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
            ddlMonth.DataBind()
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub ddlYear2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear2.SelectedIndexChanged
        Try
            ddlMonth2.DataValueField = "mon_year"
            ddlMonth2.DataTextField = "mon_name"
            ddlMonth2.DataSource = ClsDB.getMtdMonth(ddlYear2.SelectedValue)
            ddlMonth2.DataBind()
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Private Sub getMultiFooter(ByVal e As GridViewRowEventArgs, ByVal getCels As SortedList, color As String, fontBold As Boolean)
        Try
            Dim row As GridViewRow
            Dim enumCels As IDictionaryEnumerator = getCels.GetEnumerator
            row = New GridViewRow(-1, -1, DataControlRowType.Footer, DataControlRowState.Normal)

            While (enumCels.MoveNext)
                Dim cont As String() = enumCels.Value.ToString.Split("|")
                Dim cell As New TableCell
                cell.RowSpan = cont(2).ToString
                cell.ColumnSpan = cont(1).ToString
                cell.Controls.Add(New LiteralControl(cont(0).ToString))
                cell.HorizontalAlign = HorizontalAlign.Center
                cell.BackColor = New Drawing.ColorConverter().ConvertFromString(color)
                cell.ForeColor = System.Drawing.Color.White
                cell.Font.Bold = fontBold
                row.Cells.Add(cell)
                e.Row.Parent.Controls.AddAt(gv.Rows.Count + 1, row)
            End While
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub getMultiHeader(ByVal e As GridViewRowEventArgs, ByVal getCels As SortedList)
        Dim row As GridViewRow
        Dim enumCels As IDictionaryEnumerator = getCels.GetEnumerator
        row = New GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal)

        While (enumCels.MoveNext)
            Dim cont As String() = enumCels.Value.ToString.Split(",")
            Dim cell As New TableCell
            cell.RowSpan = cont(2).ToString
            cell.ColumnSpan = cont(1).ToString
            cell.Controls.Add(New LiteralControl(cont(0).ToString))
            cell.HorizontalAlign = HorizontalAlign.Center
            cell.BackColor = New Drawing.ColorConverter().ConvertFromString("#CCCCCC")
            cell.ForeColor = System.Drawing.Color.Black
            cell.Font.Bold = True
            row.Cells.Add(cell)
          
            e.Row.Parent.Controls.AddAt(0, row)
        End While
    End Sub
End Class
