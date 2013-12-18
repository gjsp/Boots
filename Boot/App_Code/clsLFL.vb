Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net.Mail.SmtpClient
Imports System.Net.Mail
Imports System.Configuration.ConfigurationManager

Public Class clsLFL
    Public Shared strcon As String = ConfigurationManager.ConnectionStrings("bootsConnectionString").ConnectionString

    Public Shared Function getSumFullMtdLfl(ByVal years As String, ByVal mon As String, Optional rate As String = "") As DataSet
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1

        Dim bDate As String = "01/" + mon + "/" + years
        Dim eDate As String = "01/" + mon + "/" + years
        Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
        Dim endDate As DateTime = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing)

        '"select * from (select COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store, " & _
        Dim sqlTbl As String = "mtd"  '"v_mtd('" + rate + "')" 
        Dim sqlCol As String = "SELECT COUNT(DISTINCT dd.costcenter_id) as cnum, " & _
            "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
            "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area)  end as productivity, "
        '" costcenter_code,costcenter_name, "

        Dim sql As String = "SELECT *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'LFL' ,xx = '5',costcenter_store=5,store_id = 5,store_name = 'LFL' " & _
"from ( select mt1.* from " + sqlTbl + " mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"LEFT JOIN " + sqlTbl + " mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
"mt1.TotalRevenue <> '0' and ct.costcenter_opendt <=  @lastyear2 and " & _
"mt1.costcenter_id not in (" + clsHtml.getTempClose() + ") ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'Non LFL' ,xx='4',costcenter_store=4,store_id = 4,store_name = 'Non LFL' " & _
"from ( " & _
"select * from " + sqlTbl + " mtdz " & _
"where mtdz.month_time = @thisyear and mtdz.costcenter_id not in ( " & _
" select cb.costcenter_id from ( select mt1.* from " + sqlTbl + " mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"LEFT JOIN " + sqlTbl + " mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
"mt1.TotalRevenue <> '0' and ct.costcenter_opendt <=  @lastyear2 and " & _
"mt1.costcenter_id not in (" + clsHtml.getTempClose() + ") ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear  and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
" ) ) dd,costcenter cb,store sto1 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto1.store_id and sto1.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'Closed' ,xx='3',costcenter_store=3,store_id = 3,store_name = 'Closed' " & _
"from " + sqlTbl + " dd,costcenter cb,store sto2 " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto2.store_id and sto2.store_other = 'N' and dd.month_time = @thisyear and  cb.costcenter_blockdt <= @thisyear2 " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'New Store' ,xx='2',costcenter_store=2,store_id = 2,store_name = 'New Store' " & _
"from " + sqlTbl + " dd,costcenter cb,store sto3 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto3.store_id and sto3.store_other = 'N' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
"and cb.costcenter_opendt >= @openyear " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'Other Business' ,xx='1',costcenter_store=1,store_id = 1,store_name = 'Other Business' " & _
"from " + sqlTbl + " dd,costcenter cb,store sto4 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto4.store_id and sto4.store_other = 'Y' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
")LFL order by xx desc"


        '"order by xx desc "


        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@thisyear", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@lastyear", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + lastyear), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@thisyear2", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing).AddMonths(1).AddDays(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@lastyear2", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + lastyear), ClsManage.formatDateTime, Nothing).AddMonths(1).AddDays(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@openyear", SqlDbType.DateTime)
        If mon < 4 Then
            parameter.Value = DateTime.ParseExact(("1/4/" + lastyear), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/4/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@bDate", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Dim dtlflG As New DataTable
            Dim dtPreMtd As New DataTable
            Dim ds As New DataSet
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                'Add row for total 
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    colName = drTotal.Table.Columns(i).ColumnName
                    If colName.Contains("Sum") Then
                        drTotal(i) = IIf(dt.Compute("Sum(" + colName + ")", "").ToString = "", 0, dt.Compute("Sum(" + colName + ")", ""))
                    ElseIf colName.Contains("growth") Then
                        drTotal(i) = "0.0%"
                    End If
                Next

                If dt.Compute("Sum(sumsalearea)", "").ToString = "" Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")
                End If
                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", "")))
                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = clsBts.reportPart.Total.ToString
                dt.Rows.Add(drTotal)

                ''Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
                ''Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
                'Dim strore_id As String = ""
                'dtlflG = clsBts.getLFLGrowth(years, mon, "")

                'Dim sumNum As Double = 0
                'Dim sumDivi As Double = 0
                'If dtlflG.Rows.Count > 0 Then
                '    For Each dr As DataRow In dt.Rows
                '        strore_id = dr("store_id").ToString
                '        sumNum += dr(0)
                '        sumDivi += dr(1)
                '        If dtlflG.Select("store_id = " + strore_id + " ").Length > 0 Then
                '            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(dtlflG.Select("store_id = " + strore_id + " ")(0)("rev1"))
                '            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(dtlflG.Select("store_id = " + strore_id + " ")(0)("loss1"))
                '        Else
                '            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
                '            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                '        End If
                '    Next
                'End If

                ''Cal YOY Growth ( Columns --> % Revenue Growth-YOY" in report in Report )
                ''Cal YOY Loss Growth ( Columns --> % Store Trading Profit Growth-YOY in Report )
                'dtPreMtd = clsBts.getYoyMtd(years - 1, mon, "", rate)
                'Dim rev1 As Double = 0
                'Dim rev2 As Double = 0
                'Dim loss1 As Double = 0
                'Dim loss2 As Double = 0
                'Dim costcenterStore As String = ""
                'If dtPreMtd.Rows.Count > 0 Then
                '    For Each dr As DataRow In dt.Rows
                '        costcenterStore = dr("costcenter_store").ToString
                '        If dtPreMtd.Select("costcenter_store = " + costcenterStore + " ").Length > 0 Then
                '            rev1 = IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
                '            rev2 = IIf(IsDBNull(dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue")), 0, dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue"))

                '            loss1 = IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))
                '            loss2 = IIf(IsDBNull(dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss")), 0, dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss"))

                '            If rev1 <> 0 And rev2 <> 0 Then
                '                dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((rev1 / rev2) - 1)
                '            Else
                '                dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
                '            End If

                '            If loss1 <> 0 And loss2 <> 0 Then
                '                dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((loss1 / loss2) - 1)
                '            Else
                '                dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                '            End If
                '        Else
                '            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
                '            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                '        End If

                '    Next
                'End If

                Dim dtTotal As New DataTable
                dtTotal = dt.Clone
                dtTotal.ImportRow(dt.Select("costcenter_store = 0")(0))
                dt.Rows(dt.Rows.Count - 1).Delete()
                dt.AcceptChanges()

                ds.Tables.Add(dt)
                ds.Tables(0).TableName = clsBts.reportPart.Item.ToString

                'Add Total YOY
                Dim drTotalYoy As Data.DataRow
                drTotalYoy = clsBts.getYoyMtdTotal(years, mon, "", rate).Rows(2)

                Dim drNewTotalYoy As DataRow = dtTotal.NewRow
                For i As Integer = 0 To drTotalYoy.Table.Columns.Count - 1
                    If drTotalYoy.Table.Columns(i).ColumnName.Contains("Sum") Then
                        drNewTotalYoy(drTotalYoy.Table.Columns(i).ColumnName) = 0 'drTotalYoy(drTotalYoy.Table.Columns(i).ColumnName)
                    End If
                Next
                drNewTotalYoy("cnum") = 0
                drNewTotalYoy("store_id") = 0
                drNewTotalYoy("costcenter_store") = 0
                drNewTotalYoy("store_name") = "TotalYoy"
                dtTotal.Rows.Add(drNewTotalYoy)

                ds.Tables.Add(dtTotal)
                ds.Tables(1).TableName = clsBts.reportPart.Total.ToString

            End If
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getModelMtd(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String) As DataSet

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sql As String = "SELECT *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
            "SELECT COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store,SUM(TotalRevenue)/SUM(costcenter_sale_area) as productivity, " & _
            "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
            "" + clsBts.columnModelSum() + "" & _
            " from " + sqlTbl + " mt,costcenter cc " & _
            " where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "'  " & _
            " AND (cc.costcenter_location = @locate OR @locate = '' )" & _
            " AND cc.costcenter_opendt < @sl_dt " & _
            " group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id and st.store_other='N' order by store_order "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@locate", SqlDbType.VarChar)
        parameter.Value = locate
        cmd.Parameters.Add(parameter)

        Dim dt As New DataTable
        Dim dtlflG As New DataTable
        Dim dtPreMtd As New DataTable
        Dim da As New SqlDataAdapter(cmd)
        Try
            da.Fill(dt)
            Dim ds As New DataSet
            If dt.Rows.Count > 0 Then

                'Add row for total 
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    colName = drTotal.Table.Columns(i).ColumnName
                    If colName.Contains("Sum") Then
                        drTotal(i) = IIf(dt.Compute("Sum(" + colName + ")", "").ToString = "", 0, dt.Compute("Sum(" + colName + ")", ""))
                    ElseIf colName.Contains("growth") Then
                        drTotal(i) = "0.000%"
                    End If
                Next


                If dt.Compute("Sum(sumsalearea)", "").ToString = "" Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")
                End If
                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", ""))) - Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id=8").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id=8")))
                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = clsBts.reportPart.Total.ToString
                dt.Rows.Add(drTotal)

                'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
                'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
                Dim strore_id As String = ""
                dtlflG = clsBts.getLFLGrowth(years, mon, locate)

                Dim sumNum As Double = 0
                Dim sumDivi As Double = 0
                If dtlflG.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        strore_id = dr("store_id").ToString
                        sumNum += dr(0)
                        sumDivi += dr(1)
                        If dtlflG.Select("store_id = " + strore_id + " ").Length > 0 Then
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(dtlflG.Select("store_id = " + strore_id + " ")(0)("rev1"))
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(dtlflG.Select("store_id = " + strore_id + " ")(0)("loss1"))
                        Else
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If
                    Next
                End If

                'Cal YOY Growth ( Columns --> % Revenue Growth-YOY" in report in Report )
                'Cal YOY Loss Growth ( Columns --> % Store Trading Profit Growth-YOY in Report )
                dtPreMtd = clsBts.getYoyMtd(years - 1, mon, locate, rate)
                Dim rev1 As Double = 0
                Dim rev2 As Double = 0
                Dim loss1 As Double = 0
                Dim loss2 As Double = 0
                Dim costcenterStore As String = ""
                If dtPreMtd.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        costcenterStore = dr("costcenter_store").ToString
                        If dtPreMtd.Select("costcenter_store = " + costcenterStore + " ").Length > 0 Then
                            rev1 = IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
                            rev2 = IIf(IsDBNull(dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue")), 0, dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue"))

                            loss1 = IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))
                            loss2 = IIf(IsDBNull(dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss")), 0, dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss"))

                            If rev1 <> 0 And rev2 <> 0 Then
                                dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((rev1 / rev2) - 1)
                            Else
                                dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            End If

                            If loss1 <> 0 And loss2 <> 0 Then
                                dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((loss1 / loss2) - 1)
                            Else
                                dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            End If
                        Else
                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If

                    Next
                End If
                Dim dtTotal As New DataTable
                dtTotal = dt.Clone
                dtTotal.ImportRow(dt.Select("costcenter_store = 0")(0))
                dt.Rows(dt.Rows.Count - 1).Delete()
                dt.AcceptChanges()

                ds.Tables.Add(dt)
                ds.Tables(0).TableName = clsBts.reportPart.Item.ToString

                'Add Total YOY
                Dim drTotalYoy As Data.DataRow
                drTotalYoy = clsBts.getYoyMtdTotal(years, mon, locate, rate).Rows(2)

                Dim drNewTotalYoy As DataRow = dtTotal.NewRow
                For i As Integer = 0 To drTotalYoy.Table.Columns.Count - 1
                    If drTotalYoy.Table.Columns(i).ColumnName.Contains("Sum") Then
                        drNewTotalYoy(drTotalYoy.Table.Columns(i).ColumnName) = drTotalYoy(drTotalYoy.Table.Columns(i).ColumnName)
                    End If
                Next
                drNewTotalYoy("cnum") = 0
                drNewTotalYoy("store_id") = 0
                drNewTotalYoy("costcenter_store") = 0
                drNewTotalYoy("store_name") = "TotalYoy"
                dtTotal.Rows.Add(drNewTotalYoy)

                ds.Tables.Add(dtTotal)
                ds.Tables(1).TableName = clsBts.reportPart.Total.ToString

            End If
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            dtlflG.Dispose()
            dtPreMtd.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function
End Class
