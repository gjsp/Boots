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

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sqlCol As String = "SELECT COUNT(DISTINCT m.costcenter_id) as cnum, " & _
            "ISNULL(SUM(costcenter_total_area),0) as Sumtotalarea,ISNULL(SUM(costcenter_sale_area),0) as Sumsalearea, " & _
            "case when SUM(costcenter_sale_area) = 0 then 0 else ISNULL(SUM(TotalRevenue)/SUM(costcenter_sale_area),0)  end as productivity,ISNULL(SUM(lastRevenue),0) as lastRevenue,ISNULL(SUM(lastLoss),0) as lastLoss, "

        Dim sqlCount_closed As String = "select count(distinct costcenter_id) from mtd " & _
            "where month_time  between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
            "and costcenter_id in ( " & _
            "	select costcenter_id from costcenter " & _
            "	where costcenter_blockdt between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
            "	and costcenter_store in (select store_id from store where store_other = 'N')  " & _
            ")"

        'Dim sqlCount_closed As String = "select  count(distinct m.costcenter_id) as cnum " & _
        '        "from  mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
        '        "where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
        '        "and month_time between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) and RETAIL_TESPIncome <> 0 " & _
        '        "and costcenter_blockdt is not null and costcenter_blockdt < dateadd(month,1, @eDate)"

        Dim sqlCol_closed As String = "SELECT (" + sqlCount_closed + ") as cnum, " & _
          "ISNULL(SUM(costcenter_total_area),0) as Sumtotalarea,ISNULL(SUM(costcenter_sale_area),0) as Sumsalearea, " & _
          "case when SUM(costcenter_sale_area) = 0 then 0 else ISNULL(SUM(TotalRevenue)/SUM(costcenter_sale_area),0)  end as productivity,ISNULL(SUM(lastRevenue),0) as lastRevenue,ISNULL(SUM(lastLoss),0) as lastLoss,"

        Dim sqlLFL As String = "from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id " & _
"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
"where m.month_time between @bDate and @eDate and m.totalRevenue <> 0 and c.costcenter_opendt <=  dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) )  " & _
"and c.costcenter_opendt < @openyear and not ( c.costcenter_opendt > dateadd(year,-1, @eDate) and c.costcenter_opendt <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) ) " & _
"and m.costcenter_id not in (" + getTempCloseLFL() + ") "

        'LFL Growth only 'N/A'
        Dim sql As String = "SELECT *,'N/A' as lfl_growth,'N/A' as yoy_growth,'N/A' as lfl_loss_growth,'N/A' as yoy_loss_growth from ( " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=5,store_id = 5,store_name = 'LFL' " & _
"" + sqlLFL + "" & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=4,store_id = 4,store_name = 'Non LFL' " & _
"from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id  " & _
"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and @eDate " & _
"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) ) " & _
"and c.costcenter_opendt < @openyear " & _
"and c.costcenter_id not in( select c.costcenter_id " + sqlLFL + ") " & _
"union " & _
"" + sqlCol_closed + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=3,store_id = 3,store_name = 'Closed' " & _
"from (" & _
"	select m.*,costcenter_sale_area,costcenter_total_area" & _
"	from  " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id  " & _
"	where c.costcenter_store in (select store_id from store where store_other = 'N')" & _
"	and month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate))" & _
"	and costcenter_blockdt is not null and costcenter_blockdt < dateadd(month,1, @eDate)" & _
")m1 right join (" & _
"	SELECT  month_time, c.costcenter_id, ISNULL(RETAIL_TESPIncome, 0) AS lastRevenue, ISNULL(StoreTradingProfit__Loss, 0) AS lastLoss" & _
"    FROM  " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id" & _
"    WHERE      (month_time = DATEADD(year, - 1, @bDate))" & _
"    and costcenter_blockdt is not null and costcenter_blockdt <  dateadd(month,1, @eDate)" & _
")m2 on m1.costcenter_id = m2.costcenter_id  and RETAIL_TESPIncome <> 0 " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=2,store_id = 2,store_name = 'New Store' " & _
"from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and @eDate " & _
"and c.costcenter_opendt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=1,store_id = 1,store_name = 'Other Business' " & _
"from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'Y') " & _
"and m.month_time = @bDate " & _
")LFL order by store_id desc"


        ''sql Closed old
        '"" + sqlCol + "" & _
        '"" + clsBts.columnModelSum() + "" & _
        '",costcenter_store=4,store_id = 4,store_name = 'Non LFL' " & _
        '"from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id  " & _
        '"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
        '"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
        '"and month_time between @bDate and @eDate " & _
        '"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) ) " & _
        '"and c.costcenter_opendt < @openyear " & _
        '"and c.costcenter_id not in( select c.costcenter_id " + sqlLFL + ") " & _

        sql = sql.Replace("SUM(TotalRevenue)", "SUM(RETAIL_TESPIncome)")
        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@openyear", SqlDbType.DateTime)
        If bDate.Month < 4 Then
            parameter.Value = DateTime.ParseExact(("1/4/" + (bDate.Year - 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/4/" + bDate.Year.ToString), ClsManage.formatDateTime, Nothing)
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
                'Cal Growth YOY,Default = N/A
                For Each dr As DataRow In dt.Rows
                    If dr("store_name") = "LFL" Or dr("store_name") = "Non LFL" Or dr("store_name") = "Other Business" Then
                        If dr("lastRevenue") <> 0 And dr("SumTotalRevenue") <> 0 Then
                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((dr("SumTotalRevenue") / dr("lastRevenue")) - 1)
                        End If
                        If dr("lastLoss") <> 0 And dr("SumStoreTradingProfit__Loss") <> 0 Then
                            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((dr("SumStoreTradingProfit__Loss") / dr("lastLoss")) - 1)
                        End If
                    End If
                Next

                'Add row for total 
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    colName = drTotal.Table.Columns(i).ColumnName
                    If colName.Contains("Sum") Then
                        drTotal(i) = IIf(dt.Compute("Sum(" + colName + ")", "").ToString = "", 0, dt.Compute("Sum(" + colName + ")", ""))
                    End If
                Next

                If dt.Compute("Sum(sumsalearea)", "").ToString = "" Or dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")
                End If
                Dim filter As String = "store_id<>2 and store_id<>3"
                Dim revFilter As Double = dt.Compute("Sum(SumTotalRevenue)", filter)
                Dim lastRevFilter As Double = dt.Compute("Sum(lastRevenue)", filter)
                Dim lossFilter As Double = dt.Compute("Sum(SumStoreTradingProfit__Loss)", filter)
                Dim lastLossFilter As Double = dt.Compute("Sum(lastLoss)", filter)

                drTotal("lfl_growth") = ClsManage.msgLFLNone
                drTotal("lfl_loss_growth") = ClsManage.msgLFLNone
                drTotal("yoy_growth") = ClsManage.msgLFLNone
                drTotal("yoy_loss_growth") = ClsManage.msgLFLNone
                If revFilter <> 0 And lastRevFilter <> 0 Then
                    drTotal("yoy_growth") = ClsManage.convert2PercenLFLGrowth((revFilter / lastRevFilter) - 1)
                End If
                If lossFilter <> 0 And lastLossFilter <> 0 Then
                    drTotal("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((lossFilter / lastLossFilter) - 1)
                End If

                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id <> 1").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id <> 1"))) 'excude Other Business
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
                'Dim drTotalYoy As Data.DataRow
                'drTotalYoy = clsBts.getYoyMtdTotal(years, mon, "", rate).Rows(2)

                Dim drNewTotalYoy As DataRow = dtTotal.NewRow
                'For i As Integer = 0 To drTotalYoy.Table.Columns.Count - 1
                '    If drTotalYoy.Table.Columns(i).ColumnName.Contains("Sum") Then
                '        drNewTotalYoy(drTotalYoy.Table.Columns(i).ColumnName) = 0 'drTotalYoy(drTotalYoy.Table.Columns(i).ColumnName)
                '    End If
                'Next
                For i As Integer = 0 To drNewTotalYoy.Table.Columns.Count - 1
                    If dtTotal.Columns(i).ColumnName.Contains("Sum") Then
                        drNewTotalYoy(dtTotal.Columns(i).ColumnName) = 0
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

    'Public Shared Function getModelMtd(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String) As DataSet

    '    Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

    '    Dim sql As String = "SELECT *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
    '        "SELECT COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store,SUM(TotalRevenue)/SUM(costcenter_sale_area) as productivity, " & _
    '        "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
    '        "" + clsBts.columnModelSum() + "" & _
    '        " from " + sqlTbl + " mt,costcenter cc " & _
    '        " where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "'  " & _
    '        " AND (cc.costcenter_location = @locate OR @locate = '' )" & _
    '        " AND cc.costcenter_opendt < @sl_dt " & _
    '        " group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id and st.store_other='N' order by store_order "

    '    Dim con As New SqlConnection(strcon)
    '    Dim cmd As New SqlCommand(sql, con)

    '    Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
    '    If mon = "12" Then
    '        parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
    '    Else
    '        parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
    '    End If
    '    cmd.Parameters.Add(parameter)

    '    parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
    '    If mon = "12" Then
    '        parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
    '    Else
    '        parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
    '    End If
    '    cmd.Parameters.Add(parameter)

    '    parameter = New SqlParameter("@locate", SqlDbType.VarChar)
    '    parameter.Value = locate
    '    cmd.Parameters.Add(parameter)

    '    Dim dt As New DataTable
    '    Dim dtlflG As New DataTable
    '    Dim dtPreMtd As New DataTable
    '    Dim da As New SqlDataAdapter(cmd)
    '    Try
    '        da.Fill(dt)
    '        Dim ds As New DataSet
    '        If dt.Rows.Count > 0 Then

    '            'Add row for total 
    '            Dim drTotal As DataRow = dt.NewRow
    '            Dim colName As String = ""
    '            For i As Integer = 0 To dt.Columns.Count - 1
    '                colName = drTotal.Table.Columns(i).ColumnName
    '                If colName.Contains("Sum") Then
    '                    drTotal(i) = IIf(dt.Compute("Sum(" + colName + ")", "").ToString = "", 0, dt.Compute("Sum(" + colName + ")", ""))
    '                ElseIf colName.Contains("growth") Then
    '                    drTotal(i) = "0.000%"
    '                End If
    '            Next


    '            If dt.Compute("Sum(sumsalearea)", "").ToString = "" Then
    '                drTotal("productivity") = 0
    '            Else
    '                drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")
    '            End If
    '            drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", ""))) - Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id=8").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id=8")))
    '            drTotal("store_id") = 0
    '            drTotal("costcenter_store") = 0
    '            drTotal("store_name") = clsBts.reportPart.Total.ToString
    '            dt.Rows.Add(drTotal)

    '            'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
    '            'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
    '            Dim strore_id As String = ""
    '            dtlflG = clsBts.getLFLGrowth(years, mon, locate)

    '            Dim sumNum As Double = 0
    '            Dim sumDivi As Double = 0
    '            If dtlflG.Rows.Count > 0 Then
    '                For Each dr As DataRow In dt.Rows
    '                    strore_id = dr("store_id").ToString
    '                    sumNum += dr(0)
    '                    sumDivi += dr(1)
    '                    If dtlflG.Select("store_id = " + strore_id + " ").Length > 0 Then
    '                        dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(dtlflG.Select("store_id = " + strore_id + " ")(0)("rev1"))
    '                        dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(dtlflG.Select("store_id = " + strore_id + " ")(0)("loss1"))
    '                    Else
    '                        dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
    '                        dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
    '                    End If
    '                Next
    '            End If

    '            'Cal YOY Growth ( Columns --> % Revenue Growth-YOY" in report in Report )
    '            'Cal YOY Loss Growth ( Columns --> % Store Trading Profit Growth-YOY in Report )
    '            dtPreMtd = clsBts.getYoyMtd(years - 1, mon, locate, rate)
    '            Dim rev1 As Double = 0
    '            Dim rev2 As Double = 0
    '            Dim loss1 As Double = 0
    '            Dim loss2 As Double = 0
    '            Dim costcenterStore As String = ""
    '            If dtPreMtd.Rows.Count > 0 Then
    '                For Each dr As DataRow In dt.Rows
    '                    costcenterStore = dr("costcenter_store").ToString
    '                    If dtPreMtd.Select("costcenter_store = " + costcenterStore + " ").Length > 0 Then
    '                        rev1 = IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
    '                        rev2 = IIf(IsDBNull(dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue")), 0, dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue"))

    '                        loss1 = IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))
    '                        loss2 = IIf(IsDBNull(dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss")), 0, dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss"))

    '                        If rev1 <> 0 And rev2 <> 0 Then
    '                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((rev1 / rev2) - 1)
    '                        Else
    '                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
    '                        End If

    '                        If loss1 <> 0 And loss2 <> 0 Then
    '                            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((loss1 / loss2) - 1)
    '                        Else
    '                            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
    '                        End If
    '                    Else
    '                        dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
    '                        dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
    '                    End If

    '                Next
    '            End If
    '            Dim dtTotal As New DataTable
    '            dtTotal = dt.Clone
    '            dtTotal.ImportRow(dt.Select("costcenter_store = 0")(0))
    '            dt.Rows(dt.Rows.Count - 1).Delete()
    '            dt.AcceptChanges()

    '            ds.Tables.Add(dt)
    '            ds.Tables(0).TableName = clsBts.reportPart.Item.ToString

    '            'Add Total YOY
    '            Dim drTotalYoy As Data.DataRow
    '            drTotalYoy = clsBts.getYoyMtdTotal(years, mon, locate, rate).Rows(2)

    '            Dim drNewTotalYoy As DataRow = dtTotal.NewRow
    '            For i As Integer = 0 To drTotalYoy.Table.Columns.Count - 1
    '                If drTotalYoy.Table.Columns(i).ColumnName.Contains("Sum") Then
    '                    drNewTotalYoy(drTotalYoy.Table.Columns(i).ColumnName) = drTotalYoy(drTotalYoy.Table.Columns(i).ColumnName)
    '                End If
    '            Next
    '            drNewTotalYoy("cnum") = 0
    '            drNewTotalYoy("store_id") = 0
    '            drNewTotalYoy("costcenter_store") = 0
    '            drNewTotalYoy("store_name") = "TotalYoy"
    '            dtTotal.Rows.Add(drNewTotalYoy)

    '            ds.Tables.Add(dtTotal)
    '            ds.Tables(1).TableName = clsBts.reportPart.Total.ToString

    '        End If
    '        Return ds
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        dt.Dispose()
    '        dtlflG.Dispose()
    '        dtPreMtd.Dispose()
    '        da.Dispose()
    '        cmd.Dispose()
    '    End Try
    'End Function

#Region "YTD"

    Public Shared Function getYtdLFL(bDate As DateTime, eDate As DateTime, rate As String) As DataSet
        Try
            If eDate.Month = 4 Then Return getMtdLFL(eDate, eDate, rate)
            Dim dt As New DataTable

            Dim dtTemp As New DataTable
            dtTemp = Nothing
            Dim tempDate As DateTime = eDate

            'while from end date >> begin date
            While (tempDate >= bDate)
                dt = getMtdLFLEachMonth(tempDate, tempDate, rate)
                If dtTemp Is Nothing Then
                    dtTemp = dt
                Else
                    'loop for summary values
                    'SumTotalArea and SumSaleArea for YTD >>เอาเดือนที่เลือก ที่เป็น mtd มาโชว์ คือเดือน eDate
                    For r = 0 To dt.Rows.Count - 1
                        For c = 0 To dt.Columns.Count - 1
                            If dt.Columns(c).ColumnName.Contains("Sum") Then
                                If dt.Columns(c).ColumnName <> "Sumtotalarea" And dt.Columns(c).ColumnName <> "Sumsalearea" Then
                                    dtTemp.Rows(r)(c) = IIf(IsDBNull(dtTemp.Rows(r)(c)), 0, dtTemp.Rows(r)(c)) + IIf(IsDBNull(dt.Rows(r)(c)), 0, dt.Rows(r)(c))
                                ElseIf dtTemp.Rows(r)(c) Is DBNull.Value Then
                                    dtTemp.Rows(r)(c) = 0
                                End If
                            ElseIf dt.Columns(c).ColumnName.Contains("last") Then 'lastRevenue,lastLoss
                                dtTemp.Rows(r)(c) = IIf(IsDBNull(dtTemp.Rows(r)(c)), 0, dtTemp.Rows(r)(c)) + IIf(IsDBNull(dt.Rows(r)(c)), 0, dt.Rows(r)(c))
                            End If
                        Next
                    Next
                End If

                ''** For count store
                'dt = New DataTable
                'dt = getCountMtdLFLEachMonth(tempDate)
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
                ''**
                tempDate = tempDate.AddMonths(-1)
            End While
            dt.Dispose()

            ''*** find count store not duplicate in all ytd
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
            ''***

            Dim monthDiff As Integer = 1 + DateDiff(DateInterval.Month, bDate, eDate)
            For Each dr As DataRow In dtTemp.Rows
                'cal Productivity
                If dr("SumTotalRevenue") = 0 OrElse dr("Sumsalearea") = 0 Then
                    dr("productivity") = 0
                Else
                    dr("productivity") = (dr("SumTotalRevenue") / dr("Sumsalearea")) / monthDiff
                End If

                'Cal Growth YOY,Default = N/A
                If dr("store_name") = "LFL" Or dr("store_name") = "Non LFL" Or dr("store_name") = "Other Business" Then
                    If dr("lastRevenue") <> 0 And dr("SumTotalRevenue") <> 0 Then
                        dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((dr("SumTotalRevenue") / dr("lastRevenue")) - 1)
                    End If
                    If dr("lastLoss") <> 0 And dr("SumStoreTradingProfit__Loss") <> 0 Then
                        dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((dr("SumStoreTradingProfit__Loss") / dr("lastLoss")) - 1)
                    End If
                End If

                'If dr("store_name") = "Closed" Then
                '    dr("cnum") = getCountClosedYtdLFL(bDate, eDate).ToString
                'End If
            Next

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
                    End If
                Next

                If dt.Compute("Sum(sumsalearea)", "").ToString = "" Or dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "") / monthDiff
                End If

                Dim filter As String = ""
                Dim revFilter As Double = dt.Compute("Sum(SumTotalRevenue)", filter)
                Dim lastRevFilter As Double = dt.Compute("Sum(lastRevenue)", filter)
                Dim lossFilter As Double = dt.Compute("Sum(SumStoreTradingProfit__Loss)", filter)
                Dim lastLossFilter As Double = dt.Compute("Sum(lastLoss)", filter)

                drTotal("lfl_growth") = ClsManage.msgLFLNone
                drTotal("lfl_loss_growth") = ClsManage.msgLFLNone
                If revFilter <> 0 And lastRevFilter <> 0 Then
                    drTotal("yoy_growth") = ClsManage.convert2PercenLFLGrowth((revFilter / lastRevFilter) - 1)
                End If
                If lossFilter <> 0 And lastLossFilter <> 0 Then
                    drTotal("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((lossFilter / lastLossFilter) - 1)
                End If

                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id <> 1").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id <> 1"))) 'ไม่รวม other
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
                Dim drNewTotalYoy As DataRow = dtTotal.NewRow
                For i As Integer = 0 To drNewTotalYoy.Table.Columns.Count - 1
                    If dtTotal.Columns(i).ColumnName.Contains("Sum") Then
                        drNewTotalYoy(dtTotal.Columns(i).ColumnName) = 0
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
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sqlCol As String = "SELECT COUNT(DISTINCT m.costcenter_id) as cnum, " & _
            "ISNULL(SUM(costcenter_total_area),0) as Sumtotalarea,ISNULL(SUM(costcenter_sale_area),0) as Sumsalearea, " & _
            "case when SUM(costcenter_sale_area) = 0 then 0 else ISNULL(SUM(TotalRevenue)/SUM(costcenter_sale_area),0)  end as productivity,ISNULL(SUM(lastRevenue),0) as lastRevenue,ISNULL(SUM(lastLoss),0) as lastLoss, "

        Dim sqlCount_closed As String = "select count(distinct costcenter_id) from mtd " & _
            "where month_time  between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
            "and costcenter_id in ( " & _
            "	select costcenter_id from costcenter " & _
            "	where costcenter_blockdt between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
            "	and costcenter_store in (select store_id from store where store_other = 'N')  " & _
            ")"

        'Dim sqlCount_closed As String = "select  count(distinct m.costcenter_id) as cnum " & _
        '        "from  mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
        '        "where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
        '        "and month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate)) and RETAIL_TESPIncome <> 0 " & _
        '        "and costcenter_blockdt is not null and costcenter_blockdt < dateadd(month,1, @eDate)"

        ' User function getCountClosedYtdLFL หาจำนวนที่หลัง
        Dim sqlCol_closed As String = "SELECT (" + sqlCount_closed + ") as cnum, " & _
          "ISNULL(SUM(costcenter_total_area),0) as Sumtotalarea,ISNULL(SUM(costcenter_sale_area),0) as Sumsalearea, " & _
          "case when SUM(costcenter_sale_area) = 0 then 0 else ISNULL(SUM(TotalRevenue)/SUM(costcenter_sale_area),0)  end as productivity,ISNULL(SUM(lastRevenue),0) as lastRevenue,ISNULL(SUM(lastLoss),0) as lastLoss,"

        Dim sqlLFL As String = "from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id " & _
"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
"where m.month_time between @bDate and @eDate and m.totalRevenue <> 0 and c.costcenter_opendt <=  dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) )  " & _
"and c.costcenter_opendt < @openyear and not ( c.costcenter_opendt > dateadd(year,-1, @eDate) and c.costcenter_opendt <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) ) " & _
"and m.costcenter_id not in (" + getTempCloseLFL() + ") "

        Dim sql As String = "SELECT *,'N/A' as lfl_growth,'N/A' as yoy_growth,'N/A' as lfl_loss_growth,'N/A' as yoy_loss_growth from ( " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=5,store_id = 5,store_name = 'LFL' " & _
"" + sqlLFL + "" & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=4,store_id = 4,store_name = 'Non LFL' " & _
"from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id  " & _
"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from mtd where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and @eDate " & _
"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) ) " & _
"and c.costcenter_opendt < @openyear " & _
"and c.costcenter_id not in( select c.costcenter_id " + sqlLFL + ") " & _
"union " & _
"" + sqlCol_closed + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=3,store_id = 3,store_name = 'Closed' " & _
"from (" & _
"	select m.*,costcenter_sale_area,costcenter_total_area" & _
"	from  " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id  " & _
"	where c.costcenter_store in (select store_id from store where store_other = 'N')" & _
"	and month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate))" & _
"	and costcenter_blockdt is not null and costcenter_blockdt < dateadd(month,1, @eDate)" & _
")m1 right join (" & _
"	SELECT  month_time, c.costcenter_id, ISNULL(RETAIL_TESPIncome, 0) AS lastRevenue, ISNULL(StoreTradingProfit__Loss, 0) AS lastLoss" & _
"    FROM  " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id" & _
"    WHERE      (month_time = DATEADD(year, - 1, @bDate))" & _
"    and costcenter_blockdt is not null and costcenter_blockdt <  dateadd(month,1, @eDate)" & _
")m2 on m1.costcenter_id = m2.costcenter_id  and RETAIL_TESPIncome <> 0 " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=2,store_id = 2,store_name = 'New Store' " & _
"from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
"and month_time between @bDate and @eDate " & _
"and c.costcenter_opendt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
"union " & _
"" + sqlCol + "" & _
"" + clsBts.columnModelSum() + "" & _
",costcenter_store=1,store_id = 1,store_name = 'Other Business' " & _
"from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
"left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
"and c.costcenter_store in (select store_id from store where store_other = 'Y') " & _
"and m.month_time = @bDate " & _
")LFL order by store_id desc"

        sql = sql.Replace("SUM(TotalRevenue)", "SUM(RETAIL_TESPIncome)")
        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@openyear", SqlDbType.DateTime)
        If bDate.Month < 4 Then
            parameter.Value = DateTime.ParseExact(("1/4/" + (bDate.Year - 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/4/" + bDate.Year.ToString), ClsManage.formatDateTime, Nothing)
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

    'Public Shared Function getCountClosedYtdLFL(bDate As DateTime, eDate As DateTime) As Integer

    '    'For Only Count Closed
    '    Dim sql As String =
    '"select   distinct m.costcenter_id " & _
    '"from  mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id  " & _
    '"where c.costcenter_store in (select store_id from store where store_other = 'N')  " & _
    '"and month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate)) and RETAIL_TESPIncome <> 0 " & _
    '"and costcenter_blockdt is not null and costcenter_blockdt < dateadd(month,1, @eDate)"

    '    Dim con As New SqlConnection(strcon)
    '    Dim cmd As New SqlCommand(sql, con)

    '    Dim parameter As New SqlParameter("@bDate", SqlDbType.DateTime)
    '    parameter.Value = bDate
    '    cmd.Parameters.Add(parameter)

    '    parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
    '    parameter.Value = eDate
    '    cmd.Parameters.Add(parameter)

    '    Try
    '        Dim da As New SqlDataAdapter(cmd)
    '        Dim dt As New DataTable
    '        da.Fill(dt)
    '        Return dt.Rows.Count

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    '    Public Shared Function getCountMtdLFLEachMonth(bDate As DateTime) As DataTable

    '        'For Only Count LFL
    '        Dim eDate As DateTime = bDate
    '        Dim lastyear As String = bDate.Year - 1
    '        Dim mon As String = bDate.Month.ToString
    '        Dim years As String = bDate.Year.ToString

    '        Dim sqlLFL As String = "from mtd m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id " & _
    '"where m.month_time between @bDate and @eDate and totalRevenue <> 0 and c.costcenter_opendt <=  dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) " & _
    '"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
    '"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) )  " & _
    '"and c.costcenter_opendt < @openyear and not ( c.costcenter_opendt > dateadd(year,-1, @eDate) and c.costcenter_opendt <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) ) " & _
    '"and m.costcenter_id not in (" + getTempCloseLFL() + ") "

    '        Dim sql As String =
    '"SELECT m.costcenter_id,store_name = 'LFL' " & _
    '"" + sqlLFL + "" & _
    '"union " & _
    '"SELECT m.costcenter_id,store_name = 'Non LFL' " & _
    '"from mtd m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id  " & _
    '"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
    '"and month_time between @bDate and @eDate " & _
    '"and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) ) " & _
    '"and c.costcenter_opendt < @openyear " & _
    '"and c.costcenter_id not in( select c.costcenter_id " + sqlLFL + ") " & _
    '"union " & _
    '"SELECT m.costcenter_id,store_name = 'Closed' " & _
    '"from  mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
    '"where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
    '"and month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
    '"and c.costcenter_blockdt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
    '"and year(month_time) = year(costcenter_blockdt) and month(month_time) = month(costcenter_blockdt) " & _
    '"union " & _
    '"SELECT m.costcenter_id,store_name = 'New Store' " & _
    '"from mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
    '"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
    '"and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
    '"and month_time between @bDate and @eDate " & _
    '"and c.costcenter_opendt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
    '"union " & _
    '"SELECT m.costcenter_id,store_name = 'Other Business' " & _
    '"from mtd m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
    '"where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
    '"and c.costcenter_store in (select store_id from store where store_other = 'Y') " & _
    '"and m.month_time = @bDate "

    '        Dim con As New SqlConnection(strcon)
    '        Dim cmd As New SqlCommand(sql, con)

    '        Dim parameter As New SqlParameter("@openyear", SqlDbType.DateTime)
    '        If mon < 4 Then
    '            parameter.Value = DateTime.ParseExact(("1/4/" + lastyear), ClsManage.formatDateTime, Nothing)
    '        Else
    '            parameter.Value = DateTime.ParseExact(("1/4/" + years), ClsManage.formatDateTime, Nothing)
    '        End If
    '        cmd.Parameters.Add(parameter)

    '        parameter = New SqlParameter("@bDate", SqlDbType.DateTime)
    '        parameter.Value = bDate
    '        cmd.Parameters.Add(parameter)

    '        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
    '        parameter.Value = eDate
    '        cmd.Parameters.Add(parameter)

    '        Try
    '            Dim da As New SqlDataAdapter(cmd)
    '            Dim dt As New DataTable
    '            da.Fill(dt)
    '            Return dt

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function


#End Region

#Region "By Store"

    Private Shared Function columnModelSum_LFL_store() As String
        Dim col As New StringBuilder
        col.Append("ISNULL(RETAIL_TESPIncome,0) as SumTotalRevenue, ") ' Only LFL RETAIL_TESPIncome = TotalRevenue
        col.Append("ISNULL(RETAIL_TESPIncome,0) as SumRETAIL_TESPIncome, ")
        col.Append("ISNULL(OtherRevenue,0) as SumOtherRevenue, ")
        col.Append("ISNULL(CostofGoodSold,0) as SumCostofGoodSold, ")
        col.Append("ISNULL(GrossProfit,0) as SumGrossProfit, ")
        'col.Append("ISNULL(GrossProfit_percent,0) as SumGrossProfit_percent, ")
        col.Append("ISNULL(MarginAdjustments,0) as SumMarginAdjustments, ")
        col.Append("ISNULL(Shipping,0) as SumShipping, ")
        col.Append("ISNULL(StockLossandObsolescence,0) as SumStockLossandObsolescence, ")
        col.Append("ISNULL(InventoryAdjustment_stock,0) as SumInventoryAdjustment_stock, ")
        col.Append("ISNULL(InventoryAdjustment_damage,0) as SumInventoryAdjustment_damage, ")
        col.Append("ISNULL(StockLoss_Provision,0) as SumStockLoss_Provision, ")
        col.Append("ISNULL(StockObsolescence_Provision,0) as SumStockObsolescence_Provision, ")
        col.Append("ISNULL(GWP,0) as SumGWP, ")
        col.Append("ISNULL(GWPs_Corporate,0) as SumGWPs_Corporate, ")
        col.Append("ISNULL(GWPs_Transferred,0) as SumGWPs_Transferred, ")
        col.Append("ISNULL(SellingCosts,0) as SumSellingCosts, ")
        col.Append("ISNULL(Creditcardscommission,0) as SumCreditcardscommission, ")
        col.Append("ISNULL(LabellingMaterial,0) as SumLabellingMaterial, ")
        col.Append("ISNULL(OtherIncome_COSHFunding,0) as SumOtherIncome_COSHFunding, ")
        col.Append("ISNULL(OtherIncomeSupplier,0) as SumOtherIncomeSupplier, ")
        col.Append("ISNULL(AdjustedGrossMargin,0) as SumAdjustedGrossMargin, ")
        col.Append("ISNULL(SupplyChainCosts,0) as SumSupplyChainCosts, ")
        col.Append("ISNULL(TotalStoreExpenses,0) as SumTotalStoreExpenses, ")
        col.Append("ISNULL(StoreLabourCosts,0) as SumStoreLabourCosts, ")
        col.Append("ISNULL(GrossPay,0) as SumGrossPay, ")
        col.Append("ISNULL(TemporaryStaffCosts,0) as SumTemporaryStaffCosts, ")
        col.Append("ISNULL(Allowance,0) as SumAllowance, ")
        col.Append("ISNULL(Overtime,0) as SumOvertime, ")
        col.Append("ISNULL(Licensefee,0) as SumLicensefee, ")
        col.Append("ISNULL(Bonuses_Incentives,0) as SumBonuses_Incentives, ")
        col.Append("ISNULL(BootsBrandncentives,0) as SumBootsBrandncentives, ")
        col.Append("ISNULL(SuppliersIncentive,0) as SumSuppliersIncentive, ")
        col.Append("ISNULL(ProvidentFund,0) as SumProvidentFund, ")
        col.Append("ISNULL(PensionCosts,0) as SumPensionCosts, ")
        col.Append("ISNULL(SocialSecurityFund,0) as SumSocialSecurityFund, ")
        col.Append("ISNULL(Uniforms,0) as SumUniforms, ")
        col.Append("ISNULL(EmployeeWelfare,0) as SumEmployeeWelfare, ")
        col.Append("ISNULL(OtherBenefitsEmployee,0) as SumOtherBenefitsEmployee, ")
        col.Append("ISNULL(StorePropertyCosts,0) as SumStorePropertyCosts, ")
        col.Append("ISNULL(PropertyRental,0) as SumPropertyRental, ")
        col.Append("ISNULL(PropertyServices,0) as SumPropertyServices, ")
        col.Append("ISNULL(PropertyFacility,0) as SumPropertyFacility, ")
        col.Append("ISNULL(Propertytaxes,0) as SumPropertytaxes, ")
        col.Append("ISNULL(Facialtaxes,0) as SumFacialtaxes, ")
        col.Append("ISNULL(PropertyInsurance,0) as SumPropertyInsurance, ")
        col.Append("ISNULL(Signboard,0) as SumSignboard, ")
        col.Append("ISNULL(Discount_Rent_Services_Facility,0) as SumDiscount_Rent_Services_Facility, ")
        col.Append("ISNULL(GPCommission,0) as SumGPCommission, ")
        col.Append("ISNULL(AmortizationofLeaseRight,0) as SumAmortizationofLeaseRight, ")
        col.Append("ISNULL(Depreciation,0) as SumDepreciation, ")
        col.Append("ISNULL(DepreciationofShortLeaseBuilding,0) as SumDepreciationofShortLeaseBuilding, ")
        col.Append("ISNULL(DepreciationofComputerHardware,0) as SumDepreciationofComputerHardware, ")
        col.Append("ISNULL(DepreciationofFixturesFittings,0) as SumDepreciationofFixturesFittings, ")
        col.Append("ISNULL(DepreciationofComputerSoftware,0) as SumDepreciationofComputerSoftware, ")
        col.Append("ISNULL(DepreciationofOfficeEquipment,0) as SumDepreciationofOfficeEquipment, ")
        col.Append("ISNULL(OtherStoreCosts,0) as SumOtherStoreCosts, ")
        col.Append("ISNULL(ServiceChargesandOtherFees,0) as SumServiceChargesandOtherFees, ")
        col.Append("ISNULL(BankCharges,0) as SumBankCharges, ")
        col.Append("ISNULL(CashCollectionCharge,0) as SumCashCollectionCharge, ")
        col.Append("ISNULL(Cleaning,0) as SumCleaning, ")
        col.Append("ISNULL(SecurityGuards,0) as SumSecurityGuards, ")
        col.Append("ISNULL(Carriage,0) as SumCarriage, ")
        col.Append("ISNULL(LicenceFees,0) as SumLicenceFees, ")
        col.Append("ISNULL(OtherServicesCharge,0) as SumOtherServicesCharge, ")
        col.Append("ISNULL(OtherFees,0) as SumOtherFees, ")
        col.Append("ISNULL(Utilities,0) as SumUtilities, ")
        col.Append("ISNULL(Water,0) as SumWater, ")
        col.Append("ISNULL(Gas_Electric,0) as SumGas_Electric, ")
        col.Append("ISNULL(AirCond_Addition,0) as SumAirCond_Addition, ")
        col.Append("ISNULL(RepairandMaintenance,0) as SumRepairandMaintenance, ")
        col.Append("ISNULL(RMOther_Fix,0) as SumRMOther_Fix, ")
        col.Append("ISNULL(RMOther_Unplan,0) as SumRMOther_Unplan, ")
        col.Append("ISNULL(RMComputer_Fix,0) as SumRMComputer_Fix, ")
        col.Append("ISNULL(RMComputer_Unplan,0) as SumRMComputer_Unplan, ")
        col.Append("ISNULL(ProfessionalFee,0) as SumProfessionalFee, ")
        col.Append("ISNULL(MarketingResearch,0) as SumMarketingResearch, ")
        col.Append("ISNULL(OtherFee,0) as SumOtherFee, ")
        col.Append("ISNULL(Equipment_MaterailandSupplies,0) as SumEquipment_MaterailandSupplies, ")
        col.Append("ISNULL(PrintingandStationery,0) as SumPrintingandStationery, ")
        col.Append("ISNULL(SuppliesExpenses,0) as SumSuppliesExpenses, ")
        col.Append("ISNULL(Equipment,0) as SumEquipment, ")
        col.Append("ISNULL(Shopfitting,0) as SumShopfitting, ")
        col.Append("ISNULL(PackagingandOtherMaterial,0) as SumPackagingandOtherMaterial, ")
        col.Append("ISNULL(BusinessTravelExpenses,0) as SumBusinessTravelExpenses, ")
        col.Append("ISNULL(CarParkingandOthers,0) as SumCarParkingandOthers, ")
        col.Append("ISNULL(Travel,0) as SumTravel, ")
        col.Append("ISNULL(Accomodation,0) as SumAccomodation, ")
        col.Append("ISNULL(MealandEntertainment,0) as SumMealandEntertainment, ")
        col.Append("ISNULL(Insurance,0) as SumInsurance, ")
        col.Append("ISNULL(AllRiskInsurance,0) as SumAllRiskInsurance, ")
        col.Append("ISNULL(HealthandLifeInsurance,0) as SumHealthandLifeInsurance, ")
        col.Append("ISNULL(PenaltyandTaxation,0) as SumPenaltyandTaxation, ")
        col.Append("ISNULL(Taxation,0) as SumTaxation, ")
        col.Append("ISNULL(Penalty,0) as SumPenalty, ")
        col.Append("ISNULL(OtherRelatedStaffCost,0) as SumOtherRelatedStaffCost, ")
        col.Append("ISNULL(StaffConferenceandTraining,0) as SumStaffConferenceandTraining, ")
        col.Append("ISNULL(Training,0) as SumTraining, ")
        col.Append("ISNULL(Communication,0) as SumCommunication, ")
        col.Append("ISNULL(TelephoneCalls_Faxes,0) as SumTelephoneCalls_Faxes, ")
        col.Append("ISNULL(PostageandCourier,0) as SumPostageandCourier, ")
        col.Append("ISNULL(OtherExpenses,0) as SumOtherExpenses, ")
        col.Append("ISNULL(Sample_Tester,0) as SumSample_Tester, ")
        col.Append("ISNULL(PreopeningCosts,0) as SumPreopeningCosts, ")
        col.Append("ISNULL(LossonClaim,0) as SumLossonClaim, ")
        col.Append("ISNULL(CashOvertage_Shortagefromsales,0) as SumCashOvertage_Shortagefromsales, ")
        col.Append("ISNULL(MiscellenousandOther,0) as SumMiscellenousandOther, ")
        col.Append("ISNULL(StoreTradingProfit__Loss,0) as SumStoreTradingProfit__Loss, ")
        'col.Append("ISNULL(TradingProfit__Loss,0) as SumTradingProfit__Loss, ")
        'col.Append("ISNULL(StoreControllableCostsforBSC,0) as SumStoreControllableCostsforBSC, ")
        'col.Append("ISNULL(StoreLabourCost,0) as SumStoreLabourCost, ")
        'col.Append("ISNULL(Utillity,0) as SumUtillity, ")
        'col.Append("ISNULL(RepairMaintenance,0) as SumRepairMaintenance, ")
        col.Append("ISNULL(SWMaintenance,0) as SumSWMaintenance, ")
        col.Append("ISNULL(HWMaintenance,0) as SumHWMaintenance, ")
        col.Append("ISNULL(ITTelecommunications,0) as SumITTelecommunications ")
        Return col.ToString
    End Function

    Public Shared Function getMtdLFLByStore(bDate As DateTime, eDate As DateTime, model As String, rate As String) As DataSet
        Try
            Dim ds As New DataSet
            Dim dt As New DataTable
            dt = getMtdLFLByStoreEachMonth(bDate, eDate, model, rate)
            If dt.Rows.Count > 0 Then
                'Cal Growth YOY,Default = N/A
                For Each dr As DataRow In dt.Rows
                    If dr("model") = "LFL" Or dr("model") = "Non LFL" Or dr("model") = "Other Business" Then
                        If dr("lastRevenue") <> 0 And dr("SumTotalRevenue") <> 0 Then
                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((dr("SumTotalRevenue") / dr("lastRevenue")) - 1)
                        End If
                        If dr("lastLoss") <> 0 And dr("SumStoreTradingProfit__Loss") <> 0 Then
                            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((dr("SumStoreTradingProfit__Loss") / dr("lastLoss")) - 1)
                        End If
                    End If
                Next

                'Add row for total 
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    colName = drTotal.Table.Columns(i).ColumnName
                    If colName.Contains("Sum") Then
                        drTotal(i) = IIf(dt.Compute("Sum(" + colName + ")", "").ToString = "", 0, dt.Compute("Sum(" + colName + ")", ""))
                    End If
                Next

                If dt.Compute("Sum(sumsalearea)", "").ToString = "" Or dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")
                End If
                Dim filter As String = ""
                Dim revFilter As Double = dt.Compute("Sum(SumTotalRevenue)", filter)
                Dim lastRevFilter As Double = dt.Compute("Sum(lastRevenue)", filter)
                Dim lossFilter As Double = dt.Compute("Sum(SumStoreTradingProfit__Loss)", filter)
                Dim lastLossFilter As Double = dt.Compute("Sum(lastLoss)", filter)

                drTotal("lfl_growth") = ClsManage.msgLFLNone
                drTotal("lfl_loss_growth") = ClsManage.msgLFLNone
                drTotal("yoy_growth") = ClsManage.msgLFLNone
                drTotal("yoy_loss_growth") = ClsManage.msgLFLNone

                If model = ClsManage.lflType.LFL.ToString Or model = ClsManage.lflType.NonLFL.ToString Or model = ClsManage.lflType.OtherBusiness.ToString Then
                    If revFilter <> 0 And lastRevFilter <> 0 Then
                        drTotal("yoy_growth") = ClsManage.convert2PercenLFLGrowth((revFilter / lastRevFilter) - 1)
                    End If
                    If lossFilter <> 0 And lastLossFilter <> 0 Then
                        drTotal("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((lossFilter / lastLossFilter) - 1)
                    End If
                End If

                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", "")))
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

                ''Add Total YOY
                Dim drNewTotalYoy As DataRow = dtTotal.NewRow
                For i As Integer = 0 To drNewTotalYoy.Table.Columns.Count - 1
                    If dtTotal.Columns(i).ColumnName.Contains("Sum") Then
                        drNewTotalYoy(dtTotal.Columns(i).ColumnName) = 0
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

    Public Shared Function getMtdLFLByStoreEachMonth(bDate As DateTime, eDate As DateTime, model As String, rate As String) As DataTable

        Dim sql As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        'LFL Growth only 'N/A'
        Dim sqlCol As String = "SELECT " + columnModelSum_LFL_store() + ",'N/A' as lfl_growth,'N/A' as yoy_growth,'N/A' as lfl_loss_growth,'N/A' as yoy_loss_growth," & _
            "1 as cnum,c.costcenter_total_area as Sumtotalarea,c.costcenter_sale_area  as Sumsalearea, " & _
            "case when c.costcenter_sale_area = 0 then 0 else ISNULL(TotalRevenue/c.costcenter_sale_area,0)  end as productivity," & _
            "ISNULL(lastRevenue,0) as lastRevenue,ISNULL(lastLoss,0) as lastLoss,c.costcenter_code as costcenter_store,c.costcenter_code as store_id,c.costcenter_name as store_name "

        Dim sqlOrder As String = "order by c.costcenter_code asc"

        Dim sqlLFL As String = "" & _
            "from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id " & _
            "left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
            "where m.month_time between @bDate and @eDate and m.totalRevenue <> 0 and c.costcenter_opendt <=  dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) " & _
            "and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
            "and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) )  " & _
            "and c.costcenter_opendt < @openyear and not ( c.costcenter_opendt > dateadd(year,-1, @eDate) and c.costcenter_opendt <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) ) " & _
            "and m.costcenter_id not in (" + getTempCloseLFL() + ") "

        Dim sqlNon As String = "" & _
            ",model = 'Non LFL' " & _
            "from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id  " & _
            "left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
            "where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
            "and month_time between @bDate and @eDate " & _
            "and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) ) " & _
            "and c.costcenter_opendt < @openyear " & _
            "and c.costcenter_id not in( select c.costcenter_id " + sqlLFL + ") "

        Dim sqlClosed As String = "" & _
            ",model = 'Closed' " & _
            "from (" & _
            "	select m.*,costcenter_sale_area,costcenter_total_area" & _
            "	from  " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id  " & _
            "	where c.costcenter_store in (select store_id from store where store_other = 'N')" & _
            "	and month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate))" & _
            "	and costcenter_blockdt is not null and costcenter_blockdt < dateadd(month,1, @eDate)" & _
            ")m1 right join (" & _
            "	SELECT  month_time, c.costcenter_id, ISNULL(RETAIL_TESPIncome, 0) AS lastRevenue, ISNULL(StoreTradingProfit__Loss, 0) AS lastLoss" & _
            "    FROM  " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id" & _
            "    WHERE      (month_time = DATEADD(year, - 1, @bDate))" & _
            "    and costcenter_blockdt is not null and costcenter_blockdt <  dateadd(month,1, @eDate)" & _
            ")m2 on m1.costcenter_id = m2.costcenter_id  inner join costcenter c on m1.costcenter_id = c.costcenter_id and TotalRevenue <> 0"

        Dim sqlNew As String = "" & _
            ",model = 'New Store' " & _
            "from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
            "left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
            "where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
            "and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
            "and month_time between @bDate and @eDate " & _
            "and c.costcenter_opendt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) "

        Dim sqlOther As String = "" & _
            ",model = 'Other Business' " & _
            "from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
            "left join (select costcenter_id,ISNULL(RETAIL_TESPIncome,0) as lastRevenue,ISNULL(StoreTradingProfit__Loss,0) as lastLoss from " + sqlTbl + " where month_time = dateadd(year,-1,@bDate) )m2 ON m2.costcenter_id=c.costcenter_id " & _
            "where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
            "and c.costcenter_store in (select store_id from store where store_other = 'Y') " & _
            "and m.month_time = @bDate "

        Select Case model
            Case "LFL"
                sql = ",model = 'LFL' " + sqlLFL
            Case "NonLFL"
                sql = sqlNon
            Case "Closed"
                sql = sqlClosed
            Case "NewStore"
                sql = sqlNew
            Case "OtherBusiness"
                sql = sqlOther
        End Select
        sql = sqlCol + sql + sqlOrder

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@openyear", SqlDbType.DateTime)
        If bDate.Month < 4 Then
            parameter.Value = DateTime.ParseExact(("1/4/" + (bDate.Year - 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/4/" + bDate.Year.ToString), ClsManage.formatDateTime, Nothing)
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

    Public Shared Function getYtdLFLByStore(bDate As DateTime, eDate As DateTime, model As String, rate As String) As DataSet
        Try
            If eDate.Month = 4 Then Return getMtdLFLByStore(eDate, eDate, model, rate)
            Dim dt As New DataTable
            Dim dtTemp As New DataTable
            dtTemp = Nothing
            Dim tempDate As DateTime = eDate

            'while from end date >> begin date
            While (tempDate >= bDate)
                dt = getMtdLFLByStoreEachMonth(tempDate, tempDate, model, rate)
                If dtTemp Is Nothing Then
                    dtTemp = dt
                Else
                    'จำนวนที่มาเปรียบเที่ยบแต่ละเดือน มีไม่เท่ากัน
                    dtTemp.Merge(dt)
                    'loop for summary values
                    'SumTotalArea and SumSaleArea for YTD >>เอาเดือนที่เลือก ที่เป็น mtd มาโชว์ คือเดือน eDate
                    'For r = 0 To dt.Rows.Count - 1
                    '    For c = 0 To dt.Columns.Count - 1

                    '        If dt.Columns(c).ColumnName.Contains("Sum") Then
                    '            If dt.Columns(c).ColumnName <> "Sumtotalarea" And dt.Columns(c).ColumnName <> "Sumsalearea" Then
                    '                dtTemp.Rows(r)(c) = IIf(IsDBNull(dtTemp.Rows(r)(c)), 0, dtTemp.Rows(r)(c)) + IIf(IsDBNull(dt.Rows(r)(c)), 0, dt.Rows(r)(c))
                    '            ElseIf dtTemp.Rows(r)(c) Is DBNull.Value Then
                    '                dtTemp.Rows(r)(c) = 0
                    '            End If
                    '        ElseIf dt.Columns(c).ColumnName.Contains("last") Then 'lastRevenue,lastLoss
                    '            dtTemp.Rows(r)(c) = IIf(IsDBNull(dtTemp.Rows(r)(c)), 0, dtTemp.Rows(r)(c)) + IIf(IsDBNull(dt.Rows(r)(c)), 0, dt.Rows(r)(c))
                    '        End If
                    '    Next
                    'Next

                    'dtLFL.Select("costcenter_code = '" + dr("costcenter_code").ToString + "'").Length > 0
                    'dr("lastRevenue") = dtLFL.Select("costcenter_code = '" + dr("costcenter_code").ToString + "'")(0)("rev2")
                    'Dim sumValue As Double = 0 : Dim sumValueTemp As Double = 0
                    'For Each dr As DataRow In dt.Rows
                    '    If dtTemp.Select("store_id = '" + dr("store_id").ToString + "'").Length > 0 Then
                    '        'dtTemp.Select("store_id = '" + dr("store_id").ToString + "'")("SumTotalRevenue") = dr("SumTotalRevenue")
                    '        For Each dc As DataColumn In dt.Columns
                    '            If dc.ColumnName.Contains("Sum") Or dc.ColumnName.Contains("last") Then
                    '                sumValue = IIf(IsDBNull(dr(dc.ColumnName)), 0, dr(dc.ColumnName))
                    '                sumValueTemp = IIf(IsDBNull(dtTemp.Select("store_id = '" + dr("store_id").ToString + "'")(0)(dc.ColumnName)), 0, dtTemp.Select("store_id = '" + dr("store_id").ToString + "'")(0)(dc.ColumnName))
                    '                dtTemp.Select("store_id = '" + dr("store_id").ToString + "'")(0)(dc.ColumnName) = sumValueTemp + sumValue
                    '            End If
                    '        Next
                    '    End If
                    'Next
                End If
                tempDate = tempDate.AddMonths(-1)
            End While

            dt = New DataTable
            dt = dtTemp.Clone
            Dim sumValue As Double = 0 : Dim sumValueTemp As Double = 0
            Dim store_id As String = ""
            Dim colStore_id As String = "store_id"
            Dim iRow As Integer

            For Each drTemp As DataRow In dtTemp.Rows
                store_id = drTemp(colStore_id).ToString
                If dt.Select("store_id = '" + store_id + "' ").Length = 0 Then
                    dt.ImportRow(drTemp)
                Else
                    'Find duplicate rows for summary
                    For i = 0 To dt.Rows.Count - 1
                        If store_id = dt.Rows(i)(colStore_id) Then
                            iRow = i
                            Exit For
                        End If
                    Next
                    For Each dc As DataColumn In dt.Columns
                        If dc.ColumnName <> "Sumtotalarea" And dc.ColumnName <> "Sumsalearea" Then
                            If dc.ColumnName.Contains("Sum") Or dc.ColumnName.Contains("last") Then
                                dt.Rows(iRow)(dc.ColumnName) += drTemp(dc.ColumnName)
                            Else
                                dt.Rows(iRow)(dc.ColumnName) = drTemp(dc.ColumnName)
                            End If
                        End If
                    Next
                End If
            Next
            dtTemp = New DataTable
            dtTemp = dt
            dt.Dispose()


            Dim monthDiff As Integer = 1 + DateDiff(DateInterval.Month, bDate, eDate)
            For Each dr As DataRow In dtTemp.Rows
                'cal Productivity
                If dr("SumTotalRevenue") = 0 OrElse dr("Sumsalearea") = 0 Then
                    dr("productivity") = 0
                Else
                    dr("productivity") = (dr("SumTotalRevenue") / dr("Sumsalearea")) / monthDiff
                End If

                'Cal Growth YOY,Default = N/A
                If dr("model") = "LFL" Or dr("model") = "Non LFL" Or dr("model") = "Other Business" Then
                    If dr("lastRevenue") <> 0 And dr("SumTotalRevenue") <> 0 Then
                        dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((dr("SumTotalRevenue") / dr("lastRevenue")) - 1)
                    End If
                    If dr("lastLoss") <> 0 And dr("SumStoreTradingProfit__Loss") <> 0 Then
                        dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((dr("SumStoreTradingProfit__Loss") / dr("lastLoss")) - 1)
                    End If
                End If
            Next

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
                    End If
                Next

                If dt.Compute("Sum(sumsalearea)", "").ToString = "" Or dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "") / monthDiff
                End If

                Dim filter As String = ""
                Dim revFilter As Double = dt.Compute("Sum(SumTotalRevenue)", filter)
                Dim lastRevFilter As Double = dt.Compute("Sum(lastRevenue)", filter)
                Dim lossFilter As Double = dt.Compute("Sum(SumStoreTradingProfit__Loss)", filter)
                Dim lastLossFilter As Double = dt.Compute("Sum(lastLoss)", filter)

                drTotal("lfl_growth") = ClsManage.msgLFLNone
                drTotal("lfl_loss_growth") = ClsManage.msgLFLNone
                If model = ClsManage.lflType.LFL.ToString Or model = ClsManage.lflType.NonLFL.ToString Or model = ClsManage.lflType.OtherBusiness.ToString Then
                    If revFilter <> 0 And lastRevFilter <> 0 Then
                        drTotal("yoy_growth") = ClsManage.convert2PercenLFLGrowth((revFilter / lastRevFilter) - 1)
                    End If
                    If lossFilter <> 0 And lastLossFilter <> 0 Then
                        drTotal("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth((lossFilter / lastLossFilter) - 1)
                    End If
                Else
                    drTotal("yoy_growth") = ClsManage.msgLFLNone
                    drTotal("yoy_loss_growth") = ClsManage.msgLFLNone
                End If

                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", "")))
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
                Dim drNewTotalYoy As DataRow = dtTotal.NewRow
                For i As Integer = 0 To drNewTotalYoy.Table.Columns.Count - 1
                    If dtTotal.Columns(i).ColumnName.Contains("Sum") Then
                        drNewTotalYoy(dtTotal.Columns(i).ColumnName) = 0
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
#End Region

#Region "Compare"

    Public Shared Function getMtdLFLCompare(bDate As DateTime, eDate As DateTime, model As String, rate As String, store_format As String) As DataSet
        Try
            Dim ds As New DataSet
            Dim dt As New DataTable
            dt = getMtdLFLCompareEachMonth(bDate, eDate, model, rate, store_format)
            If dt.Rows.Count > 0 Then
                'Cal %Growth
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    colName = drTotal.Table.Columns(i).ColumnName
                    If colName.Contains("Sum") Then
                        If colName <> "Sumtotalarea" And colName <> "Sumsalearea" Then
                            If dt.Rows(1)(colName) = 0 Then
                                drTotal(i) = 0
                            Else
                                drTotal(i) = (dt.Rows(0)(colName) / dt.Rows(1)(colName)) - 1
                            End If
                        End If
                    End If
                Next

                drTotal("productivity") = 0
                drTotal("cnum") = 0
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

                ds.Tables.Add(dtTotal)
                ds.Tables(1).TableName = clsBts.reportPart.Total.ToString

            End If
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getMtdLFLCompareEachMonth(bDate As DateTime, eDate As DateTime, model As String, rate As String, store_format As String) As DataTable

        'ส่วนที่เปรียบเทียบกันของปีที่แล้ว ต้องเอาปีปัจจุบันเป็นตัวตั้ง
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")
        Dim sql As String = ""

        Dim typeYear As String = ""
        Dim topicYear As String = ""
        Dim topicYearLast As String = ""
        If Integer.Parse(bDate.Month) < 4 Then
            typeYear = model + " " + Convert.ToString(bDate.Year - 1).Substring(2, 2) + bDate.Year.ToString.Substring(2, 2)
            topicYear = MonthName(bDate.Month, True).ToString + " " + Convert.ToString(bDate.Year - 1).Substring(2, 2) + bDate.Year.ToString.Substring(2, 2)
        Else
            typeYear = model + " " + bDate.Year.ToString.Substring(2, 2) + (bDate.Year + 1).ToString.Substring(2, 2)
            topicYear = MonthName(bDate.Month, True).ToString + " " + bDate.Year.ToString.Substring(2, 2) + (bDate.Year + 1).ToString.Substring(2, 2)
        End If
        topicYearLast = MonthName(bDate.Month, True).ToString + " " + Convert.ToString(topicYear.Substring(topicYear.Length - 4, 2) - 1) + Convert.ToString(topicYear.Substring(topicYear.Length - 2, 2) - 1)

        Dim sqlCol As String = "" & _
            "SELECT COUNT(DISTINCT m.costcenter_id) as cnum,typeyear = '" + typeYear + "',topicyear = '" + topicYear + "'," & _
            "ISNULL(SUM(c.costcenter_total_area),0) as Sumtotalarea,ISNULL(SUM(c.costcenter_sale_area),0) as Sumsalearea, " & _
            "case when SUM(c.costcenter_sale_area) = 0 then 0 else ISNULL(SUM(TotalRevenue)/SUM(c.costcenter_sale_area),0)  end as productivity," + clsBts.columnModelSum()
        Dim sqlCol_last As String = "" & _
            "SELECT COUNT(DISTINCT m.costcenter_id) as cnum,typeyear = '" + typeYear + "',topicyear = '" + topicYearLast + "'," & _
            "ISNULL(SUM(c.costcenter_total_area),0) as Sumtotalarea,ISNULL(SUM(c.costcenter_sale_area),0) as Sumsalearea, " & _
            "case when SUM(c.costcenter_sale_area) = 0 then 0 else ISNULL(SUM(TotalRevenue)/SUM(c.costcenter_sale_area),0)  end as productivity," + clsBts.columnModelSum()


        'Dim sqlCount_closed As String = "select count(distinct costcenter_id) from mtd " & _
        '    "where month_time  between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
        '    "and costcenter_id in ( " & _
        '    "	select costcenter_id from costcenter " & _
        '    "	where costcenter_blockdt between @openyear and dateadd(month,1,dateadd(day,-1,@eDate)) " & _
        '    "	and costcenter_store in (select store_id from store where store_other = 'N')  " & _
        '    ")"
        
        Dim sqlCol_closed As String = "SELECT count(c.costcenter_id) as cnum, " & _
          "ISNULL(SUM(costcenter_total_area),0) as Sumtotalarea,ISNULL(SUM(costcenter_sale_area),0) as Sumsalearea, " & _
          "case when SUM(costcenter_sale_area) = 0 then 0 else ISNULL(SUM(TotalRevenue)/SUM(costcenter_sale_area),0)  end as productivity," + clsBts.columnModelSum()

        Dim sqlLFL As String = "from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id " & _
            "where m.month_time between @bDate and @eDate and m.totalRevenue <> 0 and c.costcenter_opendt <=  dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) " & _
            "and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
            "and (c.costcenter_store = @store_id or @store_id='') " & _
            "and ( c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) )  " & _
            "and c.costcenter_opendt < @openyear and not ( c.costcenter_opendt > dateadd(year,-1, @eDate) and c.costcenter_opendt <= dateadd(year,-1,dateadd(month,1,dateadd(day,-1, @eDate))) ) " & _
            "and m.costcenter_id not in (" + getTempCloseLFL() + ") "
        Dim sqlLFL_last As String = "from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id " & _
            "where month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate) " & _
            "and m.costcenter_id in (select c.costcenter_id " + sqlLFL + ")"

        Dim sqlNon As String = "" & _
            "from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id  " & _
            "where c.costcenter_store in (select store_id from store where store_other = 'N') " & _
            "and (c.costcenter_store = @store_id or @store_id='') " & _
            "and month_time between @bDate and @eDate " & _
            "and (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(month,1,dateadd(day,-1, @bDate)) ) " & _
            "and c.costcenter_opendt < @openyear " & _
            "and c.costcenter_id not in( select c.costcenter_id " + sqlLFL + ") "
        Dim sqlNon_last As String = "from " + sqlTbl + " m left JOIN costcenter c ON m.costcenter_id=c.costcenter_id " & _
           "where month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate)" & _
           "and m.costcenter_id in (select c.costcenter_id " + sqlNon + ")"

        Dim sqlClosed As String = "" & _
            "from  " + sqlTbl + "  m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
            "where month_time between @bDate and dateadd(day,-1,dateadd(month,1, @eDate)) " & _
            "and c.costcenter_store in (select store_id from store where store_other = 'N')" & _
            "and costcenter_blockdt is not null and costcenter_blockdt < dateadd(month,1, @eDate) " & _
            "and TotalRevenue <> 0 "

        Dim sqlClosed_last As String = "" & _
            "from  " + sqlTbl + "  m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
            "where month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate) " & _
            "and m.costcenter_id in (select c.costcenter_id " + sqlClosed + ")"

        Dim sqlNew As String = "" & _
            "from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
            "where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
            "and c.costcenter_store in (select store_id from store where store_other = 'N') " & _
            "and month_time between @bDate and @eDate " & _
            "and c.costcenter_opendt between @openyear and dateadd(day,-1,dateadd(month,1, @eDate)) "

        Dim sqlNew_last As String = "" & _
            "from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
            "where month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate) " & _
            "and m.costcenter_id in (select c.costcenter_id " + sqlNew + ")"


        Dim sqlOther As String = "" & _
            "from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
            "where (c.costcenter_blockdt is null or c.costcenter_blockdt > dateadd(day,-1,dateadd(month,1, @eDate)) ) " & _
            "and c.costcenter_store in (select store_id from store where store_other = 'Y') " & _
            "and (c.costcenter_store = @store_id or @store_id='') " & _
            "and m.month_time = @bDate "
        Dim sqlOther_last As String = "" & _
             "from " + sqlTbl + " m inner join costcenter c on m.costcenter_id = c.costcenter_id " & _
            "where m.month_time = dateadd(year,-1,@bDate)  " & _
            "and m.costcenter_id in (select c.costcenter_id " + sqlOther + ")"

        Dim slqOrder As String = "order by topicyear desc"

        Dim sqlCol_extend As String = ""
        Select Case model
            Case "LFL"
                sqlCol_extend = ",model = 'LFL',store_name = 'LFL',store_id = 5,costcenter_store = 5"
                sql = sqlCol + sqlCol_extend + sqlLFL + " UNION " + sqlCol_last + sqlCol_extend + sqlLFL_last + slqOrder
            Case "NonLFL"
                sqlCol_extend = ",model = 'Non LFL',store_name = 'Non LFL',store_id = 4,costcenter_store = 4"
                sql = sqlCol + sqlCol_extend + sqlNon + " UNION " + sqlCol_last + sqlCol_extend + sqlNon_last + slqOrder
            Case "Closed"
                sqlCol_extend = ",model = 'Closed',store_name = 'Closed',store_id = 3,costcenter_store = 3 "
                sql = sqlCol + sqlCol_extend + sqlClosed + " UNION " + sqlCol_last + sqlCol_extend + sqlClosed_last + slqOrder
            Case "NewStore"
                sqlCol_extend = ",model = 'NewStore',store_name = 'NewStore',store_id = 2,costcenter_store = 2 "
                sql = sqlCol + sqlCol_extend + sqlNew + " UNION " + sqlCol_last + sqlCol_extend + sqlNew_last + slqOrder
            Case "OtherBusiness"
                sqlCol_extend = ",model = 'Other Business',store_name = 'Other Business',store_id = 1,costcenter_store = 1"
                sql = sqlCol + sqlCol_extend + sqlOther + " UNION " + sqlCol_last + sqlCol_extend + sqlOther_last + slqOrder
        End Select

        sql = sql.Replace("SUM(TotalRevenue)", "SUM(RETAIL_TESPIncome)")
        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@openyear", SqlDbType.DateTime)
        If bDate.Month < 4 Then
            parameter.Value = DateTime.ParseExact(("1/4/" + (bDate.Year - 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/4/" + bDate.Year.ToString), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@bDate", SqlDbType.DateTime)
        parameter.Value = bDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        parameter.Value = eDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@store_id", SqlDbType.VarChar)
        parameter.Value = store_format
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

    Public Shared Function getYtdLFLCompare(bDate As DateTime, eDate As DateTime, model As String, rate As String, store_format As String) As DataSet
        Try
            If eDate.Month = 4 Then Return getMtdLFLCompare(bDate, eDate, model, rate, store_format)
            Dim ds As New DataSet
            Dim dt As New DataTable
            dt = getYtdLFLCompareMerge(bDate, eDate, model, rate, store_format)

            'Add row for total 
            Dim drTotal As DataRow = dt.NewRow
            Dim colName As String = ""
            For i As Integer = 0 To dt.Columns.Count - 1
                colName = drTotal.Table.Columns(i).ColumnName
                If colName.Contains("Sum") Then
                    If colName <> "Sumtotalarea" And colName <> "Sumsalearea" Then
                        If dt.Rows(1)(colName) = 0 Then
                            drTotal(i) = 0
                        Else
                            drTotal(i) = (dt.Rows(0)(colName) / dt.Rows(1)(colName)) - 1
                        End If
                    End If
                End If
            Next

            drTotal("productivity") = 0
            drTotal("cnum") = 0
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

            ds.Tables.Add(dtTotal)
            ds.Tables(1).TableName = clsBts.reportPart.Total.ToString

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getYtdLFLCompareMerge(bDate As DateTime, eDate As DateTime, model As String, rate As String, store_format As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim dtTemp As New DataTable
            dtTemp = Nothing
            Dim tempDate As DateTime = eDate

            'while from end date >> begin date
            While (tempDate >= bDate)
                dt = getMtdLFLCompareEachMonth(tempDate, tempDate, model, rate, store_format)
                If dtTemp Is Nothing Then
                    dtTemp = dt
                Else
                    'dtTemp.Merge(dt)
                    For Each dc As DataColumn In dtTemp.Columns
                        If dc.ColumnName <> "Sumtotalarea" And dc.ColumnName <> "Sumsalearea" Then
                            If dc.ColumnName.Contains("Sum") Then

                                dtTemp.Rows(0)(dc.ColumnName) += dt.Rows(0)(dc.ColumnName)
                                dtTemp.Rows(1)(dc.ColumnName) += dt.Rows(1)(dc.ColumnName)
                           
                            End If
                        End If
                    Next

                    If dt.Rows(0)("store_name") = "Closed" Then
                        dtTemp.Rows(0)("cnum") += dt.Rows(0)("cnum")
                        dtTemp.Rows(1)("cnum") += dt.Rows(1)("cnum")
                    End If
                End If
                tempDate = tempDate.AddMonths(-1)
            End While

            ''Summary to dt
            'dt = New DataTable
            'dt = dtTemp.Clone
            'For Each drTemp As DataRow In dtTemp.Rows
            '    If dt.Rows.Count = 0 Then
            '        dt.ImportRow(drTemp)
            '    Else
            '        For Each dc As DataColumn In dtTemp.Columns
            '            If dc.ColumnName <> "Sumtotalarea" And dc.ColumnName <> "Sumsalearea" Then
            '                If dc.ColumnName.Contains("Sum") Then
            '                    dt.Rows(0)(dc.ColumnName) += drTemp(dc.ColumnName)
            '                Else
            '                    dt.Rows(0)(dc.ColumnName) = drTemp(dc.ColumnName)
            '                End If
            '            End If
            '        Next
            '    End If
            'Next
            'dtTemp.Dispose()
            Return dtTemp
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
