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

Public Class clsAreas
    Public Shared strcon As String = ConfigurationManager.ConnectionStrings("bootsConnectionString").ConnectionString

    Public Shared Function getAreaByStore(ByVal bDate As String, ByVal eDate As String, area_id As String, rate As String) As DataSet

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")
        Dim locate As String = ""

        Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
        Dim endDate As DateTime = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing)

        Dim mon As String = beginDate.Month.ToString
        Dim years As String = beginDate.Year.ToString

        Dim sql As String = "SELECT sm.*,area_id as store_id,area_id as costcenter_store,sm.costcenter_code as store_name,'Area '+ area_name as area_name" & _
            ",CAST(case when (lfl.SumTotalRevenue is null OR lfl.SumTotalRevenue = 0 OR sm.SumTotalRevenue = 0) then 0 else (sm.SumTotalRevenue/lfl.SumTotalRevenue)-1  end as varchar) as lfl_growth " & _
            ",CAST(case when (yoy.SumTotalRevenue is null OR yoy.SumTotalRevenue = 0 OR sm.SumTotalRevenue = 0) then 0 else (sm.SumTotalRevenue/yoy.SumTotalRevenue)-1  end as varchar) as yoy_growth " & _
            ",CAST(case when (lfl.SumStoreTradingProfit__Loss is null OR lfl.SumStoreTradingProfit__Loss = 0 OR sm.SumStoreTradingProfit__Loss = 0) then 0 else (sm.SumStoreTradingProfit__Loss-lfl.SumStoreTradingProfit__Loss)/lfl.SumStoreTradingProfit__Loss  end as varchar) as lfl_loss_growth " & _
            ",CAST(case when (yoy.SumStoreTradingProfit__Loss is null OR yoy.SumStoreTradingProfit__Loss = 0 OR sm.SumStoreTradingProfit__Loss = 0) then 0 else (sm.SumStoreTradingProfit__Loss-yoy.SumStoreTradingProfit__Loss)/yoy.SumStoreTradingProfit__Loss  end as varchar) as yoy_loss_growth " & _
            ",ISNULL(lfl.SumTotalRevenue,0) as lfl_Rev,ISNULL(lfl.SumStoreTradingProfit__Loss,0) as lfl_Loss " & _
            ",ISNULL(yoy.SumTotalRevenue,0) as yoy_Rev,ISNULL(yoy.SumStoreTradingProfit__Loss,0) as yoy_Loss " & _
            "from ( " & _
            "SELECT COUNT(DISTINCT cc.costcenter_id) as cnum,SUM(TotalRevenue)/SUM(costcenter_sale_area) as productivity, " & _
            "costcenter_total_area as Sumtotalarea,costcenter_sale_area as Sumsalearea, " & _
            " costcenter_code,costcenter_name,costcenter_areas, " & _
            "" + clsBts.columnModelSum() + "" & _
            " from " + sqlTbl + " mt,costcenter cc,store sto " & _
            " where  cc.costcenter_store = sto.store_id and sto.store_other='N' and mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt ) " & _
            " and month_time between @bDate and @eDate " & _
            " AND cc.costcenter_opendt < @sl_dt and (costcenter_areas = @area_id or @area_id = '' ) " & _
            " group by costcenter_code,costcenter_name,costcenter_areas,costcenter_total_area,costcenter_sale_area ) sm inner join area ar on sm.costcenter_areas = ar.area_id " & _
            "left  join  " & _
            "(" & _
            "	select costcenter_code,SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss  " & _
            "	from mtd m INNER JOIN costcenter c on m.costcenter_id = c.costcenter_id   " & _
            "	where month_time between costcenter_opendt and dateadd(year,-1,@eDate)  " & _
            "	and month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate)  " & _
            "	and costcenter_blockdt is null and costcenter_code not in ('" + clsHtml.getTempClose() + "')  " & _
            "	group by costcenter_code  " & _
            ") lfl on sm.costcenter_code = lfl.costcenter_code  " & _
            "left join    " & _
            "(  " & _
            "	select costcenter_code,SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss " & _
            "	from mtd m INNER JOIN costcenter c on m.costcenter_id = c.costcenter_id   " & _
            "	where month_time between dateadd(day,1-day(costcenter_opendt), costcenter_opendt) and dateadd(year,-1,@eDate)  " & _
            "	and month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate)  " & _
            "	and costcenter_blockdt is null and costcenter_code not in ('" + clsHtml.getTempClose() + "')  " & _
            "	group by costcenter_code  " & _
            ") yoy on sm.costcenter_code = yoy.costcenter_code order by costcenter_code "

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

        parameter = New SqlParameter("@bDate", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@area_id", SqlDbType.VarChar)
        parameter.Value = area_id
        cmd.Parameters.Add(parameter)

        Dim dt As New DataTable
        Dim dtlflG As New DataTable
        Dim dtPreMtd As New DataTable
        Dim da As New SqlDataAdapter(cmd)
        Try
            da.Fill(dt)

            Dim ds As New DataSet
            If dt.Rows.Count > 0 Then

                'for loop  set % Growth
                For Each dr As DataRow In dt.Rows
                    'If dr("costcenter_code").ToString = "3975" Then
                    '    Dim a As String = ""
                    'End If
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
                        'drTotal(i) = ClsManage.convert2PercenLFLGrowth(drTotal(i))
                    End If
                Next

                Dim monthDiff As Integer = 1 + DateDiff(DateInterval.Month, beginDate, endDate)
                If dt.Compute("Sum(sumsalearea)", "").ToString = "" OrElse dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "") / monthDiff
                End If
                drTotal("lfl_growth") = ClsManage.convert2PercenGrowth((dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(lfl_Rev)", "")) - 1, ClsManage.growthType.LFL)
                drTotal("yoy_growth") = ClsManage.convert2PercenGrowth((dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(yoy_Rev)", "")) - 1, ClsManage.growthType.YOY)
                drTotal("lfl_loss_growth") = ClsManage.convert2PercenGrowthTradingProfit((dt.Compute("Sum(SumStoreTradingProfit__Loss)", "") - dt.Compute("Sum(lfl_Loss)", "")) / dt.Compute("Sum(lfl_Loss)", ""), ClsManage.growthType.LFL, dt.Compute("Sum(SumStoreTradingProfit__Loss)", ""), dt.Compute("Sum(lfl_Loss)", ""))
                drTotal("yoy_loss_growth") = ClsManage.convert2PercenGrowthTradingProfit((dt.Compute("Sum(SumStoreTradingProfit__Loss)", "") - dt.Compute("Sum(yoy_Loss)", "")) / dt.Compute("Sum(yoy_Loss)", ""), ClsManage.growthType.YOY, dt.Compute("Sum(SumStoreTradingProfit__Loss)", ""), dt.Compute("Sum(yoy_Loss)", ""))

                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", ""))) ' - Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id=8").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id=8")))
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
                drTotalYoy = getYoyTotalAreaByStore(beginDate, endDate, dt, rate).Rows(2) ' ต้องแก้ให้เป็นอันเดียวกันกับ query หลัก

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

    Public Shared Function getYoyTotalAreaByStore(beginDate As Date, endDate As Date, dtData As DataTable, rate As String) As DataTable
        'In Report Column "% YOY"
        Dim area As String = ""
        Dim years As Integer = beginDate.Year
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")
        Dim sql As String = ""
        Dim costcenter_code As String = ""
        For Each dr In dtData.Rows
            If costcenter_code = "" Then
                costcenter_code = dr("costcenter_code").ToString
            Else
                costcenter_code += "," + dr("costcenter_code").ToString
            End If
        Next

        Dim sql1 As String = String.Format(" select " + clsBts.columnModelSum & _
           "," + years.ToString + " as years " & _
            "	from mtd m INNER JOIN costcenter c on m.costcenter_id = c.costcenter_id   " & _
            "	where month_time between dateadd(day,1-day(costcenter_opendt), costcenter_opendt) and @eDate  " & _
            "	and month_time between @bDate and @eDate  " & _
            "	and costcenter_blockdt is null and  costcenter_code in ('{0}')", costcenter_code)

        Dim sql2 As String = String.Format(" select " + clsBts.columnModelSum & _
            "," + (years - 1).ToString + " as years " & _
            "	from mtd m INNER JOIN costcenter c on m.costcenter_id = c.costcenter_id   " & _
            "	where month_time between dateadd(day,1-day(costcenter_opendt), costcenter_opendt) and dateadd(year,-1,@eDate)  " & _
            "	and month_time between dateadd(year,-1,@bDate) and dateadd(year,-1,@eDate)  " & _
            "	and costcenter_blockdt is null and  costcenter_code in ('{0}')", costcenter_code)


        sql = "select * from (" + sql1 + " UNION " + sql2 + ") yoy order by years DESC"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim Parameter As New SqlParameter("@bDate", SqlDbType.DateTime)
        Parameter.Value = beginDate
        cmd.Parameters.Add(Parameter)

        Parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        Parameter.Value = endDate
        cmd.Parameters.Add(Parameter)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            Dim num As Double = 0
            Dim divi As Double = 0
            Dim dr As DataRow = dt.NewRow

            For i As Integer = 0 To dt.Columns.Count - 1
                num = IIf(IsDBNull(dt.Rows(0)(i)), 0, dt.Rows(0)(i))
                divi = IIf(IsDBNull(dt.Rows(1)(i)), 0, dt.Rows(1)(i))
                If num = 0 Or divi = 0 Then
                    dr(i) = 0
                Else
                    If dt.Rows(0).Table.Columns(i).ColumnName = "SumGrossProfit" Or dt.Rows(0).Table.Columns(i).ColumnName = "SumAdjustedGrossMargin" Or dt.Rows(0).Table.Columns(i).ColumnName = "SumStoreTradingProfit__Loss" Or dt.Rows(0).Table.Columns(i).ColumnName = "SumMarginAdjustments" Then
                        Dim thisPb As Double = 0 : Dim prePb As Double = 0 : Dim pb As Double = 0
                        If Not (IsDBNull(dt.Rows(1)(0)) Or IsDBNull(dt.Rows(1)(i)) Or IsDBNull(dt.Rows(0)(0)) Or IsDBNull(dt.Rows(0)(i))) Then
                            thisPb = num / dt.Rows(0)(0)
                            prePb = divi / dt.Rows(1)(0)
                            pb = (thisPb - prePb) * 10000
                            dr(i) = pb
                        End If
                    Else
                        dr(i) = (num / divi) - 1
                    End If
                End If
            Next
            dt.Rows.Add(dr)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function
End Class
