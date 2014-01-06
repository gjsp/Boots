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

    Public Shared Function getTempCloseLFL() As String 'add year -1
        Try
         
            Dim str As String = "" & _
            "select distinct tempc_costcenter_id from ( " & _
            "select *,CASE WHEN (tempc_start IS null and tempc_finish >= @bDate ) OR (tempc_start IS null and tempc_finish >= dateadd(year,-1, @eDate) ) THEN 1 " & _
            "WHEN (tempc_start <= dateadd(month,1,dateadd(day,-1, @bDate)) and tempc_finish IS null) OR (tempc_start <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) and tempc_finish IS null) THEN 1 " & _
            "WHEN (tempc_start <= dateadd(month,1,dateadd(day,-1, @bDate)) and tempc_finish >= @bDate) OR (tempc_start <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) and tempc_finish >= dateadd(year,-1, @eDate)) " & _
            "THEN 1 ELSE 0 END AS status_at from tempc) as tt where status_at = 1"

            Return str
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function getMtdLFL(bDate As DateTime, eDate As DateTime, rate As String) As DataSet

        Dim lastyear As String = bDate.Year - 1
        Dim mon As String = bDate.Month.ToString
        Dim years As String = bDate.Year.ToString

        '"select * from (select COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store, " & _
        Dim sqlTbl As String = "mtd"  '"v_mtd('" + rate + "')" 

        Dim sqlCol2 As String = "SELECT COUNT(DISTINCT dd.costcenter_id) as cnum, " & _
           "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
           "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area)  end as productivity, "

        Dim sqlCol As String = "SELECT COUNT(DISTINCT m.costcenter_id) as cnum, " & _
            "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
            "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area)  end as productivity, "
        '" costcenter_code,costcenter_name, "

        Dim sqlCount_closed As String = "select count(distinct costcenter_id) from mtd " & _
                    "where month_time  between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
                    "and costcenter_id in ( " & _
                    "	select costcenter_id from costcenter " & _
                    "	where costcenter_blockdt between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
                    "	and costcenter_store in (select store_id from store where store_other = 'N')  " & _
                    ")"

        Dim sqlCol_closed As String = "SELECT (" + sqlCount_closed + ") as cnum, " & _
          "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
          "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area)  end as productivity, "

        Dim sqlLFL As String = "from mtd dd left JOIN costcenter c ON dd.costcenter_id=c.costcenter_id " & _
"where dd.month_time between @bDate and @eDate and totalRevenue <> 0 and c.costcenter_opendt <=  dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) )  " & _
"and c.costcenter_opendt < @openyear and not ( c.costcenter_opendt > dateadd(year,-1, @eDate) and c.costcenter_opendt <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) ) " & _
"and dd.costcenter_id not in (" + getTempCloseLFL() + ") "

        Dim sql As String = "SELECT *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
"" + sqlCol2 + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=5,store_id = 5,store_name = 'LFL' " & _
"" + sqlLFL + "" & _
"union " & _
"" + sqlCol2 + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=4,store_id = 4,store_name = 'Non LFL' " & _
"from mtd dd left JOIN costcenter c ON dd.costcenter_id=c.costcenter_id  " & _
"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and @eDate " & _
"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) ) " & _
"and c.costcenter_opendt < @openyear " & _
"and c.costcenter_id not in( select c.costcenter_id " + sqlLFL + ") " & _
"union " & _
"" + sqlCol_closed + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=3,store_id = 3,store_name = 'Closed' " & _
"from  mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
"and c.costcenter_blockdt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
"and year(month_time) = year(costcenter_blockdt) and month(month_time) = month(costcenter_blockdt) " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=2,store_id = 2,store_name = 'New Store' " & _
"from mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and @eDate " & _
"and c.costcenter_opendt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=1,store_id = 1,store_name = 'Other Business' " & _
"from mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'Y') " & _
"and m.month_time = @bDate " & _
")LFL order by store_id desc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        'Dim parameter As New SqlParameter("@thisyear", SqlDbType.DateTime)
        'parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        'cmd.Parameters.Add(parameter)

        'parameter = New SqlParameter("@lastyear", SqlDbType.DateTime)
        'parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + lastyear), ClsManage.formatDateTime, Nothing)
        'cmd.Parameters.Add(parameter)

        'parameter = New SqlParameter("@thisyear2", SqlDbType.DateTime)
        'parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing).AddMonths(1).AddDays(-1)
        'cmd.Parameters.Add(parameter)

        'parameter = New SqlParameter("@lastyear2", SqlDbType.DateTime)
        'parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + lastyear), ClsManage.formatDateTime, Nothing).AddMonths(1).AddDays(-1)
        'cmd.Parameters.Add(parameter)

        Dim parameter As New SqlParameter("@openyear", SqlDbType.DateTime)
        If mon < 4 Then
            parameter.Value = DateTime.ParseExact(("1/4/" + lastyear), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/4/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@bDate", SqlDbType.DateTime)
        parameter.Value = bDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        parameter.Value = eDate
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

                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id <> 1").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id <> 1"))) 'excude
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

#Region "YTD"
    Public Shared Function getYtdLFL(bDate As DateTime, eDate As DateTime, rate As String) As DataSet
        Try
            Dim dt As New DataTable
            Dim beginYear As Integer = bDate.Year
            Dim beginMon As Integer = 4
            Dim dtTemp As New DataTable
            dtTemp = Nothing

            If bDate.Month < 4 Then
                beginYear = bDate.Year - 1
            End If
            Dim tempDate As DateTime = bDate
            Dim endDate As DateTime = eDate

            'Start month 4
            If eDate.Month = 4 Then Return getMtdLFL(eDate, eDate, rate)

            Dim dtLFL As New DataTable : Dim dtNonLFL As New DataTable : Dim dtClosed As New DataTable : Dim dtNew As New DataTable : Dim dtOB As New DataTable
            'dtLFL = getCountFullMtdLFL(beginYear, beginMon).Clone
            dtNonLFL = dtLFL.Clone : dtClosed = dtLFL.Clone : dtNew = dtLFL.Clone : dtOB = dtLFL.Clone

            'while start month 5
            While (tempDate <= endDate)
                dt = getMtdLFLEachMonth(tempDate, tempDate, rate)
                If dtTemp Is Nothing Then
                    dtTemp = dt
                Else
                    'loop for summary values
                    For r = 0 To dt.Rows.Count - 1
                        For c = 0 To dt.Columns.Count - 1
                            If dt.Columns(c).ColumnName.Contains("Sum") Then
                                If dt.Columns(c).ColumnName <> "sumtotalarea" And dt.Columns(c).ColumnName <> "sumsalearea" Then
                                    dtTemp.Rows(r)(c) = IIf(IsDBNull(dtTemp.Rows(r)(c)), 0, dtTemp.Rows(r)(c)) + IIf(IsDBNull(dt.Rows(r)(c)), 0, dt.Rows(r)(c))
                                ElseIf dtTemp.Rows(r)(c) Is DBNull.Value Then
                                    dtTemp.Rows(r)(c) = 0
                                End If
                            End If

                        Next
                    Next
                End If

                'dt = New DataTable
                'dt = getMtdLFLEachMonth(tempDate.Year, tempDate.Month)
                'For Each dr As DataRow In dt.Rows
                '    Select Case dr(dt.Columns(1).ColumnName)
                '        Case "LFL"
                '            dtLFL.ImportRow(dr)
                '        Case "Non LFL"
                '            dtNonLFL.ImportRow(dr)
                '        Case "Closed"
                '            dtClosed.ImportRow(dr)
                '        Case "New Store"
                '            dtNew.ImportRow(dr)
                '        Case "Other Business"
                '            dtOB.ImportRow(dr)
                '    End Select
                'Next
                tempDate = tempDate.AddMonths(1)
            End While
            dt.Dispose()

            ''find count store not duplicate in all ytd
            'Dim columnNames As String() = {dtLFL.Columns(0).ColumnName}
            'Dim countLFL As String = dtLFL.DefaultView.ToTable(True, columnNames).Rows.Count.ToString
            'Dim countNon As String = dtNonLFL.DefaultView.ToTable(True, columnNames).Rows.Count.ToString
            'Dim countClosed As String = dtClosed.DefaultView.ToTable(True, columnNames).Rows.Count.ToString
            'Dim countNew As String = dtNew.DefaultView.ToTable(True, columnNames).Rows.Count.ToString
            'Dim countOB As String = dtOB.DefaultView.ToTable(True, columnNames).Rows.Count.ToString

            'dtTemp.Rows(0)("cnum") = countLFL
            'dtTemp.Rows(1)("cnum") = countNon
            'dtTemp.Rows(2)("cnum") = countClosed
            'dtTemp.Rows(3)("cnum") = countNew
            'dtTemp.Rows(4)("cnum") = countOB

            ''''''''''''
            Dim ds As New DataSet
            dt = dtTemp
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

                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id <> 1").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id <> 1"))) 'excude
                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = clsBts.reportPart.Total.ToString
                dt.Rows.Add(drTotal)

                Dim dtTotal As New DataTable
                dtTotal = dt.Clone
                dtTotal.ImportRow(dt.Select("costcenter_store = 0")(0))
                dt.Rows(dt.Rows.Count - 1).Delete()
                dt.AcceptChanges()

                ds.Tables.Add(dt)
                ds.Tables(0).TableName = clsBts.reportPart.Item.ToString

                'Add Total YOY
                Dim drTotalYoy As Data.DataRow
                drTotalYoy = clsBts.getYoyMtdTotal(bDate.Year, bDate.Month, "", rate).Rows(2)

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

    Public Shared Function getMtdLFLEachMonth(bDate As DateTime, eDate As DateTime, rate As String) As DataTable

        'หาแต่ละเดือนใน mtd มาบวกกัน
        Dim lastyear As String = bDate.Year - 1
        Dim mon As String = bDate.Month.ToString
        Dim years As String = bDate.Year.ToString

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sqlCol2 As String = "SELECT COUNT(DISTINCT dd.costcenter_id) as cnum, " & _
           "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
           "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area)  end as productivity, "

        Dim sqlCol As String = "SELECT COUNT(DISTINCT m.costcenter_id) as cnum, " & _
            "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
            "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area)  end as productivity, "

        Dim sqlCount_closed As String = "select count(distinct costcenter_id) from mtd " & _
                    "where month_time  between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
                    "and costcenter_id in ( " & _
                    "	select costcenter_id from costcenter " & _
                    "	where costcenter_blockdt between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
                    "	and costcenter_store in (select store_id from store where store_other = 'N')  " & _
                    ")"

        Dim sqlCol_closed As String = "SELECT (" + sqlCount_closed + ") as cnum, " & _
          "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
          "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area)  end as productivity, "

        Dim sqlLFL As String = "from mtd dd left JOIN costcenter c ON dd.costcenter_id=c.costcenter_id " & _
"where dd.month_time between @bDate and @eDate and totalRevenue <> 0 and c.costcenter_opendt <=  dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) )  " & _
"and c.costcenter_opendt < @openyear and not ( c.costcenter_opendt > dateadd(year,-1, @eDate) and c.costcenter_opendt <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) ) " & _
"and dd.costcenter_id not in (" + getTempCloseLFL() + ") "

        Dim sql As String = "SELECT *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
"" + sqlCol2 + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=5,store_id = 5,store_name = 'LFL' " & _
"" + sqlLFL + "" & _
"union " & _
"" + sqlCol2 + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=4,store_id = 4,store_name = 'Non LFL' " & _
"from mtd dd left JOIN costcenter c ON dd.costcenter_id=c.costcenter_id  " & _
"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and @eDate " & _
"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) ) " & _
"and c.costcenter_opendt < @openyear " & _
"and c.costcenter_id not in( select c.costcenter_id " + sqlLFL + ") " & _
"union " & _
"" + sqlCol_closed + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=3,store_id = 3,store_name = 'Closed' " & _
"from  mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
"and c.costcenter_blockdt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
"and year(month_time) = year(costcenter_blockdt) and month(month_time) = month(costcenter_blockdt) " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=2,store_id = 2,store_name = 'New Store' " & _
"from mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and @eDate " & _
"and c.costcenter_opendt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=1,store_id = 1,store_name = 'Other Business' " & _
"from mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'Y') " & _
"and m.month_time = @bDate " & _
")LFL order by store_id desc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@openyear", SqlDbType.DateTime)
        If mon < 4 Then
            parameter.Value = DateTime.ParseExact(("1/4/" + lastyear), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/4/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@bDate", SqlDbType.DateTime)
        parameter.Value = bDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        parameter.Value = eDate
        cmd.Parameters.Add(parameter)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region
End Class
