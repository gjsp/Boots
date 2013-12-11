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

Public Class clsProvince
    Public Shared strcon As String = ConfigurationManager.ConnectionStrings("bootsConnectionString").ConnectionString

    Public Shared Function getProvince(ByVal bDate As String, ByVal eDate As String, ByVal province_id As String, Optional rate As String = "") As DataSet

        Dim years As String = eDate.Split("/")(1)
        Dim mon As String = eDate.Split("/")(0)

        Dim sqlCost_id As String = ""
        If province_id <> "" Then
            sqlCost_id = "and cc.costcenter_province=" + province_id
        End If

        Dim start_time As String = "1/" + bDate
        Dim end_time As String = "1/" + eDate
        Dim beginDate As DateTime = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing)
        Dim endDate As DateTime = DateTime.ParseExact(end_time, ClsManage.formatDateTime, Nothing)
        Dim totalDate As DateTime = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing).AddYears(1) 'สมมุุติให้ total
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sql As String = "" & _
        "SELECT sm.* " & _
        "    ,CAST(case when (lfl.SumTotalRevenue is null OR lfl.SumTotalRevenue = 0 OR sm.SumTotalRevenue = 0) then 0 else (sm.SumTotalRevenue/lfl.SumTotalRevenue)-1  end as varchar) as lfl_growth" & _
        "    ,CAST(case when (yoy.SumTotalRevenue is null OR yoy.SumTotalRevenue = 0 OR sm.SumTotalRevenue = 0) then 0 else (sm.SumTotalRevenue/yoy.SumTotalRevenue)-1  end as varchar) as yoy_growth " & _
        "    ,CAST(case when (lfl.SumStoreTradingProfit__Loss is null OR lfl.SumStoreTradingProfit__Loss = 0 OR sm.SumStoreTradingProfit__Loss = 0) then 0 else (sm.SumStoreTradingProfit__Loss-lfl.SumStoreTradingProfit__Loss)/lfl.SumStoreTradingProfit__Loss  end as varchar) as lfl_loss_growth " & _
        "    ,CAST(case when (yoy.SumStoreTradingProfit__Loss is null OR yoy.SumStoreTradingProfit__Loss = 0 OR sm.SumStoreTradingProfit__Loss = 0) then 0 else (sm.SumStoreTradingProfit__Loss-yoy.SumStoreTradingProfit__Loss)/yoy.SumStoreTradingProfit__Loss  end as varchar) as yoy_loss_growth " & _
        "    ,ISNULL(lfl.SumTotalRevenue,0) as lfl_Rev,ISNULL(lfl.SumStoreTradingProfit__Loss,0) as lfl_Loss " & _
        "    ,ISNULL(yoy.SumTotalRevenue,0) as yoy_Rev,ISNULL(yoy.SumStoreTradingProfit__Loss,0) as yoy_Loss " & _
        "from ( " & _
        "SELECT getdate() as month_time ,COUNT(DISTINCT cc.costcenter_id) as cnum ,costcenter_province as costcenter_store," & _
        "cc.costcenter_id as store_id,costcenter_code as store_code,costcenter_name as store_name,costcenter_code, " & _
        "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area) end as productivity," & _
        "costcenter_total_area as Sumtotalarea,costcenter_sale_area as Sumsalearea," & _
        "" + clsBts.columnModelSum() + "" & _
         " from " + sqlTbl + " mt,costcenter cc " & _
        "where mt.costcenter_id = cc.costcenter_id " + sqlCost_id & _
        "and mt.month_time >='" + DateTime.ParseExact(bDate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(eDate, "M/yyyy", Nothing) + "' " & _
        "and costcenter_opendt <= dateadd(day,-1,dateadd(month,1,@start_time)) " & _
        "group by cc.costcenter_id, costcenter_province,costcenter_code,costcenter_name,costcenter_total_area,costcenter_sale_area" & _
        ") sm " & _
            "left  join  " & _
            "(" & _
            "	select costcenter_code,SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss  " & _
            "	from mtd m INNER JOIN costcenter c on m.costcenter_id = c.costcenter_id   " & _
            "	where month_time between costcenter_opendt and dateadd(year,-1,@eDate)  " & _
            "	and month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate)  " & _
            "	and costcenter_blockdt is null and costcenter_code not in (" + clsHtml.getTempClose() + ")  " & _
            "	group by costcenter_code  " & _
            ") lfl on sm.costcenter_code = lfl.costcenter_code  " & _
            "left join    " & _
            "(  " & _
            "	select costcenter_code,SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss " & _
            "	from mtd m INNER JOIN costcenter c on m.costcenter_id = c.costcenter_id   " & _
            "	where month_time between dateadd(day,1-day(costcenter_opendt), costcenter_opendt) and dateadd(year,-1,@eDate)  " & _
            "	and month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate)  " & _
            "	and costcenter_blockdt is null and costcenter_code not in (" + clsHtml.getTempClose() + ")  " & _
            "	group by costcenter_code  " & _
            ") yoy on sm.costcenter_code = yoy.costcenter_code order by costcenter_code "

        'and costcenter_opendt <= dateadd(day,-1,dateadd(month,1,@bDate)) >>> ดูการเปิดร้านจากเดือน ไม่สนใจวัน เลยสร้างเงื่อนไขให้เป็นวันสุดท้่ายของเดือน
        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@bDate", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable

        Try
            da.Fill(dt)
            Dim ds As New DataSet
            If dt.Rows.Count > 0 Then

                'for loop  set % Growth
                For Each dr As DataRow In dt.Rows
                    dr("lfl_growth") = ClsManage.convert2PercenGrowth(dr("lfl_growth"), ClsManage.growthType.LFL)
                    dr("yoy_growth") = ClsManage.convert2PercenGrowth(dr("yoy_growth"), ClsManage.growthType.YOY)
                    dr("lfl_loss_growth") = ClsManage.convert2PercenGrowthTradingProfit(dr("lfl_loss_growth"), ClsManage.growthType.LFL, dr("SumStoreTradingProfit__Loss"), dr("lfl_Loss"))
                    dr("yoy_loss_growth") = ClsManage.convert2PercenGrowthTradingProfit(dr("yoy_loss_growth"), ClsManage.growthType.YOY, dr("SumStoreTradingProfit__Loss"), dr("yoy_Loss"))
                Next

                'Add row for total 
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    colName = drTotal.Table.Columns(i).ColumnName
                    If colName.Contains("Sum") Then
                        drTotal(i) = IIf(dt.Compute("Sum(" + colName + ")", "").ToString = "", 0, dt.Compute("Sum(" + colName + ")", ""))
                    ElseIf colName.Contains("growth") Then
                        'drTotal(i) = "0.0%"
                    End If
                Next

                Dim monthDiff As Integer = 1 + DateDiff(DateInterval.Month, beginDate, endDate)
                If dt.Compute("Sum(sumsalearea)", "").ToString = "" OrElse dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = (dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")) / monthDiff
                End If

                drTotal("lfl_growth") = ClsManage.convert2PercenGrowth((dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(lfl_Rev)", "")) - 1, ClsManage.growthType.LFL)
                drTotal("yoy_growth") = ClsManage.convert2PercenGrowth((dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(yoy_Rev)", "")) - 1, ClsManage.growthType.YOY)
                drTotal("lfl_loss_growth") = ClsManage.convert2PercenGrowthTradingProfit((dt.Compute("Sum(SumStoreTradingProfit__Loss)", "") - dt.Compute("Sum(lfl_Loss)", "")) / dt.Compute("Sum(lfl_Loss)", ""), ClsManage.growthType.LFL, dt.Compute("Sum(SumStoreTradingProfit__Loss)", ""), dt.Compute("Sum(lfl_Loss)", ""))
                drTotal("yoy_loss_growth") = ClsManage.convert2PercenGrowthTradingProfit((dt.Compute("Sum(SumStoreTradingProfit__Loss)", "") - dt.Compute("Sum(yoy_Loss)", "")) / dt.Compute("Sum(yoy_Loss)", ""), ClsManage.growthType.YOY, dt.Compute("Sum(SumStoreTradingProfit__Loss)", ""), dt.Compute("Sum(yoy_Loss)", ""))


                '3 column ต้องเท่ากันทุก ทุกเดือน
                drTotal("cnum") = dt.Compute("Sum(cnum)", "")
                drTotal("sumsalearea") = dt.Compute("Sum(sumsalearea)", "") ' dt.Rows(0)("sumsalearea")
                drTotal("Sumtotalarea") = dt.Compute("Sum(Sumtotalarea)", "") ' dt.Rows(0)("Sumtotalarea")

                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = clsBts.reportPart.Total.ToString
                drTotal("month_time") = totalDate
                dt.Rows.Add(drTotal)

                Dim dtTotal As New DataTable
                dtTotal = dt.Clone
                'แยก row ที่เป็น total ออกไปอีก table
                dtTotal.ImportRow(dt.Select("costcenter_store = 0")(0))
                dt.Rows(dt.Rows.Count - 1).Delete()
                dt.AcceptChanges()
                ds.Tables.Add(dt)
                ds.Tables(0).TableName = clsBts.reportPart.Item.ToString

                'Add Total YOY
                Dim drTotalYoy As Data.DataRow
                'drTotalYoy = clsBts.getYoyYtdTotal(years, mon, "", rate).Rows(2)
                drTotalYoy = clsBts.getYoyTotalByProvinceId(start_time, end_time, province_id, rate).Rows(2) ' ต้องแก้ให้เป็นอันเดียวกันกับ query หลัก
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
                dt.Dispose() : dtTotal.Dispose()
            End If
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function
End Class
