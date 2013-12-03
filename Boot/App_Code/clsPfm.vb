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

Public Class clsPfm
    Public Shared strcon As String = ConfigurationManager.ConnectionStrings("bootsConnectionString").ConnectionString

    Public Shared Function getFullyear(dd As DateTime, lastyear As Boolean) As String
        Dim str As String = ""
        If lastyear = True Then
            If dd.Month < 4 Then
                str = "FY" + dd.AddYears(-1).ToString("yy") + dd.ToString("/yy") + " & FY" + dd.AddYears(-2).ToString("yy") + dd.AddYears(-1).ToString("/yy")
            Else
                str = "FY" + dd.AddYears(0).ToString("yy") + dd.AddYears(1).ToString("/yy") + " & FY" + dd.AddYears(-1).ToString("yy") + dd.AddYears(0).ToString("/yy")
            End If
        Else
            If dd.Month < 4 Then
                str = "FY" + dd.AddYears(-1).ToString("yy") + dd.ToString("/yy")
            Else
                str = "FY" + dd.AddYears(0).ToString("yy") + dd.AddYears(1).ToString("/yy")
            End If
        End If
        Return str
    End Function

    Public Shared Function getPerformance(by As String, bDate As DateTime, eDate As DateTime, rate As String) As DataTable
        '* ดึง costcenter ทั้งหมดมา แยก เป็น 2ชุด 
        '1ชุดที่อยู่ใน วันที่ที่เลือก --> InDate = y
        '2ชุดที่ไม่อยู่ในวันที่ที่เลือก --> InDate = n
        'AND  (costcenter.costcenter_blockdt IS NULL OR costcenter.costcenter_blockdt > @eDate2) --> เงื่อนไขนี้คือ ห้ามมีวันที่ block หรือ มากกว่าวันสุดท้ายที่เลือก
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "') mtd")
        Dim beginNewStoreDate As DateTime = Nothing

        If by = clsBts.reportType.MTD.ToString Then
            eDate = bDate

            '*** case mtd  เฉพาะ new store ต้องเริ่มต้นด้วนเดือน Apr
            beginNewStoreDate = DateTime.ParseExact(("1/4/" + bDate.Year.ToString), ClsManage.formatDateTime, Nothing)
            If eDate.Month <= 4 Then beginNewStoreDate = beginNewStoreDate.AddYears(-1)
        ElseIf by = clsBts.reportType.YTD.ToString Then
            eDate = bDate
            bDate = DateTime.ParseExact(("1/4/" + bDate.Year.ToString), ClsManage.formatDateTime, Nothing)
            If eDate.Month < 4 Then
                bDate = bDate.AddYears(-1)
            End If
            beginNewStoreDate = bDate 'start date same MTD
        Else 'custom
            beginNewStoreDate = bDate
        End If
        Dim sql As String = "" & _
"SELECT   mtd.TotalRevenue, " & _
"                     case when lfl.TotalRevenue is null then  0 else lfl.TotalRevenue END AS lastRevenue, " & _
"					  costcenter.costcenter_code , " & _
"					  costcenter.costcenter_name , " & _
"					  store.store_name, " & _
"                     mtd.saleRevenue," & _
"                     CASE WHEN costcenter_sale_area = 0 THEN 0 ELSE CAST( mtd.TotalRevenue / costcenter_sale_area/(DATEDIFF(month,@bDate,@eDate)+1)  AS DECIMAL(18,2)) END AS [Productivity], " & _
"                     CASE WHEN mtd.TotalRevenue = 0 THEN '0.0%' ELSE CAST( CAST((mtd.GrossProfit/mtd.TotalRevenue)*100 as DECIMAL(18,1)) as varchar) + '%' END AS [% Gross Profit], " & _
"                     CASE WHEN mtd.TotalRevenue = 0 THEN '0.0%' ELSE CAST( CAST((mtd.AdjustedGrossMargin/mtd.TotalRevenue)*100 as DECIMAL(18,1)) as varchar) + '%' END AS [% Adj Gross Profit], " & _
"                     CASE WHEN mtd.TotalRevenue = 0 THEN '0.0%' ELSE CAST(CAST(((mtd.SupplyChainCosts + mtd.TotalStoreExpenses) / mtd.TotalRevenue) * 100 as DECIMAL(18,1)) as varchar)+ '%' END AS [% OPEX], " & _
"                     CASE WHEN mtd.TotalRevenue = 0 THEN '0.0%' ELSE CAST(CAST((mtd.StoreTradingProfit__Loss / mtd.TotalRevenue) * 100 as DECIMAL(18,1)) as varchar)+ '%' END AS [% Trading Profit/Loss], " & _
"					  CASE WHEN (lfl.TotalRevenue = 0 or lfl.TotalRevenue is null) THEN 'N/A' ELSE CAST(CAST((mtd.TotalRevenue/lfl.TotalRevenue)-1 AS DECIMAL(18,1)) AS varchar)+ '%' END AS [% LFL], " & _
"					  costcenter.costcenter_opendt ,mtd.GrossProfit,mtd.AdjustedGrossMargin,mtd.SupplyChainCosts + mtd.TotalStoreExpenses AS OPEX,CAST(mtd.StoreTradingProfit__Loss  as DECIMAL(18,2)) AS TradingProfit, " & _
"                     costcenter_sale_area,DATEDIFF(month,@bDate,@eDate)+1 as monthdiff,mtd.SupplyChainCosts + mtd.TotalStoreExpenses as OPEX, " & _
"					  CASE WHEN costcenter.costcenter_opendt  BETWEEN @beginNewStoreDate and DATEADD(day,-1,DATEADD(month,1,@eDate)) THEN 'y2' " & _
"                          WHEN costcenter.costcenter_opendt  BETWEEN DATEADD(year,-1,@beginNewStoreDate) and DATEADD(day,-1,@beginNewStoreDate) THEN 'y1' " & _
"                     ELSE 'n' END AS InDate " & _
" FROM       (" & _
"				SELECT costcenter_id,SUM(TotalRevenue) AS TotalRevenue,SUM(RETAIL_TESPIncome) AS saleRevenue,SUM(GrossProfit) AS GrossProfit,SUM(AdjustedGrossMargin) AS AdjustedGrossMargin, " & _
"				SUM(SupplyChainCosts) AS SupplyChainCosts,SUM(StoreTradingProfit__Loss) AS StoreTradingProfit__Loss,SUM(TotalStoreExpenses) as TotalStoreExpenses " & _
"				FROM " + sqlTbl + " WHERE mtd.month_time BETWEEN @bDate and @eDate GROUP BY costcenter_id " & _
"			 )   mtd RIGHT JOIN " & _
"                      costcenter ON mtd.costcenter_id = costcenter.costcenter_id INNER JOIN " & _
"                      store ON costcenter.costcenter_store = store.store_id and store.store_other = 'N'  " & _
"                      LEFT JOIN " & _
"                      ( " & _
"						SELECT costcenter_id,SUM(TotalRevenue) AS TotalRevenue,SUM(RETAIL_TESPIncome) as saleRevenue,SUM(GrossProfit) AS GrossProfit,SUM(AdjustedGrossMargin) AS AdjustedGrossMargin," & _
"						SUM(SupplyChainCosts) AS SupplyChainCosts,SUM(StoreTradingProfit__Loss) AS StoreTradingProfit__Loss,SUM(TotalStoreExpenses) as TotalStoreExpenses " & _
"						FROM " + sqlTbl + " WHERE mtd.month_time BETWEEN DATEADD(year,-1,@bDate)  and DATEADD(year,-1,@eDate)" & _
"						GROUP BY costcenter_id" & _
"                      )lfl ON lfl.costcenter_id = mtd.costcenter_id" & _
" WHERE  mtd.TotalRevenue is not null " & _
"	   AND costcenter.costcenter_opendt  < DATEADD(month,1,@eDate)" & _
"	   AND  (costcenter.costcenter_blockdt IS NULL OR costcenter.costcenter_blockdt > DATEADD(day,-1,DATEADD(month,1,@eDate)) )" & _
" ORDER BY InDate,mtd.StoreTradingProfit__Loss DESC"
        'AND mtd.TotalRevenue <> 0 
        Dim dt As New DataTable
        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cmd)

        Dim parameter As New SqlParameter("@bDate", SqlDbType.DateTime)
        parameter.Value = bDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        parameter.Value = eDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@beginNewStoreDate", SqlDbType.DateTime)
        parameter.Value = beginNewStoreDate
        cmd.Parameters.Add(parameter)

        Try
            da.Fill(dt)
            Return dt
            'If dt.Rows.Count > 0 Then
            '    Dim costcenter_code As String = ""
            '    Dim colCostcenter_code As String = "costcenter_code"
            '    Dim colRev1 As String = "rev1"
            '    Dim colRev2 As String = "rev2"

            '    Dim dtLFL As New DataTable
            '    Dim dtTemp As New DataTable : dtTemp = Nothing
            '    Dim tempDate As DateTime = bDate

            '    While (tempDate <= eDate)
            '        dtLFL = getLFLGrowthPfmByMonth(tempDate.Year, tempDate.Month, rate)
            '        If dtTemp Is Nothing Then
            '            dtTemp = dtLFL
            '        Else
            '            dtTemp.Merge(dtLFL)
            '        End If
            '        tempDate = tempDate.AddMonths(1)
            '    End While

            '    dtLFL = Nothing
            '    dtLFL = dtTemp.Clone
            '    Dim iRow As Integer = -1
            '    For Each drTemp As DataRow In dtTemp.Rows
            '        costcenter_code = drTemp(colCostcenter_code).ToString
            '        If dtLFL.Select("costcenter_code = " + costcenter_code + " ").Length = 0 Then
            '            dtLFL.ImportRow(drTemp)
            '        Else
            '            'Find duplicate rows for summary
            '            For i = 0 To dtLFL.Rows.Count - 1
            '                If costcenter_code = dtLFL.Rows(i)(colCostcenter_code) Then
            '                    iRow = i
            '                    Exit For
            '                End If
            '            Next
            '            dtLFL.Rows(iRow)(colRev1) += drTemp(colRev1)
            '            dtLFL.Rows(iRow)(colRev2) += drTemp(colRev2)
            '        End If
            '    Next

            '    Dim rev1 As Double = 0
            '    Dim rev2 As Double = 0
            '    If dtLFL.Rows.Count > 0 Then
            '        For Each dr As DataRow In dt.Rows
            '            If dtLFL.Select("costcenter_code = '" + dr("costcenter_code").ToString + "'").Length > 0 Then
            '                dr("lastRevenue") = dtLFL.Select("costcenter_code = '" + dr("costcenter_code").ToString + "'")(0)("rev2")
            '                'dr("TotalRevenue") = dtLFL.Select("costcenter_code = '" + dr("costcenter_code").ToString + "'")(0)("rev1")

            '                If dr("lastRevenue") = 0 Or dr("lastRevenue") - 1 = 0 Then
            '                    dr("% LFL") = "N/A"
            '                    dr("lastRevenue") = 0
            '                Else
            '                    dr("% LFL") = ClsManage.convert2PercenLFLGrowth((dr("TotalRevenue") / dr("lastRevenue") - 1))
            '                End If
            '            Else
            '                dr("% LFL") = "N/A"
            '                dr("lastRevenue") = 0
            '            End If
            '        Next
            '    End If
            'End If
            'Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try

    End Function

    Public Shared Function convert2RoundPer(ByVal num As Double) As String
        Try
            Return Math.Round(num * 100, 1).ToString("###0.0") + "%"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getLFLGrowthPfmByMonth(ByVal years As String, ByVal mon As String, rate As String) As DataTable
        'store_id = format
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""
        Dim locate As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "') ")

        sqlCol = "select SUM(TotalRevenue) as SumRevenue, cb.costcenter_code, "
        sqlPtype = "ptype = cast( year(@thisyear) as varchar) "
        sqlCondition1 = "" & _
"from ( select mt1.* from " + sqlTbl + " mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and " & _
"mt1.TotalRevenue <> '0' and ct.costcenter_opendt <=  @lastyear2 and " & _
"mt1.costcenter_id not in ( " & _
"select distinct tempc_costcenter_id from ( " & _
"select *, " & _
"CASE " & _
"WHEN (tempc_start IS null and tempc_finish >= @thisyear ) OR (tempc_start IS null and tempc_finish >= @lastyear ) THEN 1 " & _
"WHEN (tempc_start <= @thisyear2 and tempc_finish IS null) OR (tempc_start <= @lastyear2 and tempc_finish IS null) THEN 1 " & _
"WHEN (tempc_start <= @thisyear2 and tempc_finish >= @thisyear) OR (tempc_start <= @lastyear2 and tempc_finish >= @lastyear) THEN 1 " & _
"ELSE 0 " & _
"END AS status_at " & _
"from tempc) as tt " & _
"where status_at = 1 " & _
") ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )  AND (sto.store_id = @store_id or @store_id = '')  " & _
" AND (cb.costcenter_location = @locate OR @locate = '' )"
        sqlCondition2 = "GROUP BY cb.costcenter_code )g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar)  " & _
            "from " + sqlTbl + " dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by cb.costcenter_code )g2 on g1.costcenter_code = g2.costcenter_code"

        sql = "select g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2, g1.costcenter_code from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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

        parameter = New SqlParameter("@store_id", SqlDbType.VarChar)
        parameter.Value = ""
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@locate", SqlDbType.VarChar)
        parameter.Value = locate
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function convert2RoundLFL(ByVal num As Double) As String
        Try
            Return Math.Round(num - 1, 1).ToString("###0.0") + "%"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function convert2TradingProfit(ByVal str As String) As String
        Try
            str = Replace(str, " ", "")
            If str = "" Or str Is Nothing Then
                Return ""
            Else
                Dim result As Double = Double.Parse(str)
                If result < 0 Then
                    Return (-result).ToString("#,##0")
                Else
                    Return result.ToString("#,##0")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "Full Year Report"
    Private Shared Function columnMtdFull() As String
        Dim col As New StringBuilder
        col.Append("TotalRevenue as SumTotalRevenue, ")
        col.Append("RETAIL_TESPIncome as SumRETAIL_TESPIncome, ")
        col.Append("OtherRevenue as SumOtherRevenue, ")
        col.Append("CostofGoodSold as SumCostofGoodSold, ")
        col.Append("GrossProfit as SumGrossProfit, ")
        col.Append("MarginAdjustments as SumMarginAdjustments, ")
        col.Append("Shipping as SumShipping, ")
        col.Append("StockLossandObsolescence as SumStockLossandObsolescence, ")
        col.Append("InventoryAdjustment_stock as SumInventoryAdjustment_stock, ")
        col.Append("InventoryAdjustment_damage as SumInventoryAdjustment_damage, ")
        col.Append("StockLoss_Provision as SumStockLoss_Provision, ")
        col.Append("StockObsolescence_Provision as SumStockObsolescence_Provision, ")
        col.Append("GWP as SumGWP, ")
        col.Append("GWPs_Corporate as SumGWPs_Corporate, ")
        col.Append("GWPs_Transferred as SumGWPs_Transferred, ")
        col.Append("SellingCosts as SumSellingCosts, ")
        col.Append("Creditcardscommission as SumCreditcardscommission, ")
        col.Append("LabellingMaterial as SumLabellingMaterial, ")
        col.Append("OtherIncome_COSHFunding as SumOtherIncome_COSHFunding, ")
        col.Append("OtherIncomeSupplier as SumOtherIncomeSupplier, ")
        col.Append("AdjustedGrossMargin as SumAdjustedGrossMargin, ")
        col.Append("SupplyChainCosts as SumSupplyChainCosts, ")
        col.Append("TotalStoreExpenses as SumTotalStoreExpenses, ")
        col.Append("StoreLabourCosts as SumStoreLabourCosts, ")
        col.Append("GrossPay as SumGrossPay, ")
        col.Append("TemporaryStaffCosts as SumTemporaryStaffCosts, ")
        col.Append("Allowance as SumAllowance, ")
        col.Append("Overtime as SumOvertime, ")
        col.Append("Licensefee as SumLicensefee, ")
        col.Append("Bonuses_Incentives as SumBonuses_Incentives, ")
        col.Append("BootsBrandncentives as SumBootsBrandncentives, ")
        col.Append("SuppliersIncentive as SumSuppliersIncentive, ")
        col.Append("ProvidentFund as SumProvidentFund, ")
        col.Append("PensionCosts as SumPensionCosts, ")
        col.Append("SocialSecurityFund as SumSocialSecurityFund, ")
        col.Append("Uniforms as SumUniforms, ")
        col.Append("EmployeeWelfare as SumEmployeeWelfare, ")
        col.Append("OtherBenefitsEmployee as SumOtherBenefitsEmployee, ")
        col.Append("StorePropertyCosts as SumStorePropertyCosts, ")
        col.Append("PropertyRental as SumPropertyRental, ")
        col.Append("PropertyServices as SumPropertyServices, ")
        col.Append("PropertyFacility as SumPropertyFacility, ")
        col.Append("Propertytaxes as SumPropertytaxes, ")
        col.Append("Facialtaxes as SumFacialtaxes, ")
        col.Append("PropertyInsurance as SumPropertyInsurance, ")
        col.Append("Signboard as SumSignboard, ")
        col.Append("Discount_Rent_Services_Facility as SumDiscount_Rent_Services_Facility, ")
        col.Append("GPCommission as SumGPCommission, ")
        col.Append("AmortizationofLeaseRight as SumAmortizationofLeaseRight, ")
        col.Append("Depreciation as SumDepreciation, ")
        col.Append("DepreciationofShortLeaseBuilding as SumDepreciationofShortLeaseBuilding, ")
        col.Append("DepreciationofComputerHardware as SumDepreciationofComputerHardware, ")
        col.Append("DepreciationofFixturesFittings as SumDepreciationofFixturesFittings, ")
        col.Append("DepreciationofComputerSoftware as SumDepreciationofComputerSoftware, ")
        col.Append("DepreciationofOfficeEquipment as SumDepreciationofOfficeEquipment, ")
        col.Append("OtherStoreCosts as SumOtherStoreCosts, ")
        col.Append("ServiceChargesandOtherFees as SumServiceChargesandOtherFees, ")
        col.Append("BankCharges as SumBankCharges, ")
        col.Append("CashCollectionCharge as SumCashCollectionCharge, ")
        col.Append("Cleaning as SumCleaning, ")
        col.Append("SecurityGuards as SumSecurityGuards, ")
        col.Append("Carriage as SumCarriage, ")
        col.Append("LicenceFees as SumLicenceFees, ")
        col.Append("OtherServicesCharge as SumOtherServicesCharge, ")
        col.Append("OtherFees as SumOtherFees, ")
        col.Append("Utilities as SumUtilities, ")
        col.Append("Water as SumWater, ")
        col.Append("Gas_Electric as SumGas_Electric, ")
        col.Append("AirCond_Addition as SumAirCond_Addition, ")
        col.Append("RepairandMaintenance as SumRepairandMaintenance, ")
        col.Append("RMOther_Fix as SumRMOther_Fix, ")
        col.Append("RMOther_Unplan as SumRMOther_Unplan, ")
        col.Append("RMComputer_Fix as SumRMComputer_Fix, ")
        col.Append("RMComputer_Unplan as SumRMComputer_Unplan, ")
        col.Append("ProfessionalFee as SumProfessionalFee, ")
        col.Append("MarketingResearch as SumMarketingResearch, ")
        col.Append("OtherFee as SumOtherFee, ")
        col.Append("Equipment_MaterailandSupplies as SumEquipment_MaterailandSupplies, ")
        col.Append("PrintingandStationery as SumPrintingandStationery, ")
        col.Append("SuppliesExpenses as SumSuppliesExpenses, ")
        col.Append("Equipment as SumEquipment, ")
        col.Append("Shopfitting as SumShopfitting, ")
        col.Append("PackagingandOtherMaterial as SumPackagingandOtherMaterial, ")
        col.Append("BusinessTravelExpenses as SumBusinessTravelExpenses, ")
        col.Append("CarParkingandOthers as SumCarParkingandOthers, ")
        col.Append("Travel as SumTravel, ")
        col.Append("Accomodation as SumAccomodation, ")
        col.Append("MealandEntertainment as SumMealandEntertainment, ")
        col.Append("Insurance as SumInsurance, ")
        col.Append("AllRiskInsurance as SumAllRiskInsurance, ")
        col.Append("HealthandLifeInsurance as SumHealthandLifeInsurance, ")
        col.Append("PenaltyandTaxation as SumPenaltyandTaxation, ")
        col.Append("Taxation as SumTaxation, ")
        col.Append("Penalty as SumPenalty, ")
        col.Append("OtherRelatedStaffCost as SumOtherRelatedStaffCost, ")
        col.Append("StaffConferenceandTraining as SumStaffConferenceandTraining, ")
        col.Append("Training as SumTraining, ")
        col.Append("Communication as SumCommunication, ")
        col.Append("TelephoneCalls_Faxes as SumTelephoneCalls_Faxes, ")
        col.Append("PostageandCourier as SumPostageandCourier, ")
        col.Append("OtherExpenses as SumOtherExpenses, ")
        col.Append("Sample_Tester as SumSample_Tester, ")
        col.Append("PreopeningCosts as SumPreopeningCosts, ")
        col.Append("LossonClaim as SumLossonClaim, ")
        col.Append("CashOvertage_Shortagefromsales as SumCashOvertage_Shortagefromsales, ")
        col.Append("MiscellenousandOther as SumMiscellenousandOther, ")
        col.Append("StoreTradingProfit__Loss as SumStoreTradingProfit__Loss, ")

        col.Append("SWMaintenance as SumSWMaintenance, ")
        col.Append("HWMaintenance as SumHWMaintenance, ")
        col.Append("ITTelecommunications as SumITTelecommunications ")
        Return col.ToString
    End Function

    Public Shared Function getLFLGrowthPerFull(ByVal years As String, ByVal mon As String) As DataTable
        'store_id = format
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""

        sqlCol = "select SUM(TotalRevenue) as SumRevenue,SUM(StoreTradingProfit__Loss) as SumLoss, cb.costcenter_location, "
        sqlPtype = "ptype = cast( year(@thisyear) as varchar) "
        sqlCondition1 = "" & _
"from ( select mt1.* from mtd mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and " & _
"mt1.TotalRevenue <> '0' and ct.costcenter_opendt <=  @lastyear2 and " & _
"mt1.costcenter_id not in ( " & _
"select distinct tempc_costcenter_id from ( " & _
"select *, " & _
"CASE " & _
"WHEN (tempc_start IS null and tempc_finish >= @thisyear ) OR (tempc_start IS null and tempc_finish >= @lastyear ) THEN 1 " & _
"WHEN (tempc_start <= @thisyear2 and tempc_finish IS null) OR (tempc_start <= @lastyear2 and tempc_finish IS null) THEN 1 " & _
"WHEN (tempc_start <= @thisyear2 and tempc_finish >= @thisyear) OR (tempc_start <= @lastyear2 and tempc_finish >= @lastyear) THEN 1 " & _
"ELSE 0 " & _
"END AS status_at " & _
"from tempc) as tt " & _
"where status_at = 1 " & _
") ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )  "

        sqlCondition2 = "GROUP BY cb.costcenter_location )g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar)  " & _
            "from mtd dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by cb.costcenter_location )g2 on g1.costcenter_location = g2.costcenter_location"

        sql = "select g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2,g1.SumLoss as loss1,g2.SumLoss as loss2, g1.costcenter_location as location_id from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getTotalPerFull(dt As DataTable, location_id As String) As DataTable
        'find จำนวน ปีที่มี
        Dim maxLoaction As Integer = 0
        Dim locationName As String = "Total"
        Dim locationCount As Integer = 0
        Dim maxCountMonth As Integer() = {0}
        Dim dtTemp As DataTable = dt.Clone

        If location_id = "1" Then
            locationName = "BKK"
        ElseIf location_id = "2" Then
            locationName = "UPC"
        End If

        For Each drMaxyear As DataRow In dt.Rows
            If drMaxyear("store_id").ToString <> "0" Then  ' only not total
                If location_id = "0" Then 'all
                    If drMaxyear("yearno").ToString = "1" Then locationCount += 1
                    dtTemp.ImportRow(drMaxyear)
                    If CInt(drMaxyear("yearno").ToString) > maxLoaction Then
                        maxLoaction = CInt(drMaxyear("yearno").ToString)
                    End If

                Else
                    If drMaxyear("location_id") = location_id Then
                        If drMaxyear("yearno").ToString = "1" Then locationCount += 1
                        dtTemp.ImportRow(drMaxyear)
                        If CInt(drMaxyear("yearno").ToString) > maxLoaction Then
                            maxLoaction = CInt(drMaxyear("yearno").ToString)
                        End If
                    End If
                End If
            End If
        Next

        'Add row for total 
        Dim drTotal As DataRow
        Dim colName As String = ""
        Dim condition As String = "" 'location = 0 --> condition=""

        For j = 1 To maxLoaction
            drTotal = dt.NewRow
            For i As Integer = 0 To dt.Columns.Count - 1
                colName = drTotal.Table.Columns(i).ColumnName
                condition = String.Format("yearno={0}", j.ToString)

                If colName.Contains("Sum") Then
                    drTotal(i) = IIf(dtTemp.Compute("Sum(" + colName + ")", condition).ToString = "", 0, dtTemp.Compute("Sum(" + colName + ")", condition))
                ElseIf colName.Contains("growth") Then
                    drTotal(i) = "0.000%"
                Else

                End If
            Next
            Dim rankNo As String() = {"th", "st", "nd", "rd"}
            Dim countMonthForProductivity As Integer  ' = IIf(drTotal("yearno").ToString = "1", drTotal("count_month") + 1, drTotal("count_month"))

            drTotal("location_count") = locationCount.ToString
            drTotal("location_name") = locationName
            'drTotal("rankyear") = j.ToString + IIf(j > 3, rankNo(0), rankNo(j)) + " Yr"
            If j > 3 Then
                drTotal("rankyear") = j.ToString + rankNo(0) + " Yr"
            Else
                drTotal("rankyear") = j.ToString + rankNo(j) + " Yr"
            End If
            'drTotal("beginDate") = dtTemp.Rows(j)("beginDate")
            drTotal("yearno") = locationName + j.ToString
            drTotal("store_id") = 0
            drTotal("location_id") = location_id
            drTotal("costcenter_store") = 0
            drTotal("store_name") = clsBts.reportPart.Total.ToString
            drTotal("count_month") = dtTemp.Compute("max(count_month)", condition)
            drTotal("costcenter_total_area") = dtTemp.Compute("sum(costcenter_total_area)", condition)
            drTotal("costcenter_sale_area") = dtTemp.Compute("sum(costcenter_sale_area)", condition)

            countMonthForProductivity = IIf(drTotal("yearno").ToString.Contains("1"), drTotal("count_month") - 1, drTotal("count_month")) ' เอาจำนวนเดือนที่มากสุด ของปีนั้น
            drTotal("productivity") = IIf(drTotal("Sumsalearea") = 0, 0, drTotal("SumTotalRevenue") / drTotal("costcenter_sale_area") / countMonthForProductivity) ' dtTemp("SumTotalRevenue") / dtTemp("Sumsalearea")

            dt.Rows.Add(drTotal)
        Next
        Return dt
    End Function

    Public Shared Function setPerFullLFLGrowth(dt As DataTable, beginDate As DateTime) As DataTable

        Dim endDate As DateTime = beginDate.AddYears(1).AddDays(-1)
        '"costcenter_code, id,month_time,month(month_time) as iMonth,year(month_time) as iYear, TotalRevenue, StoreTradingProfit__Loss,0 as yearno,0 as location_id,0 as yoy,0 as lfl " & _TotalRevenue,StoreTradingProfit__Loss

        Dim sql As String = "select  " & _
        "month(month_time) as iMonth,year(month_time) as iYear,0 as yearno,0 as location_id,0 as yoy,0 as lfl,costcenter_code, " + columnMtdFull() + _
        "from mtd m INNER JOIN costcenter c on m.costcenter_id = c.costcenter_id " & _
        "where month_time >= @bDate and costcenter_blockdt is null and costcenter_opendt between @bDate and @eDate order by costcenter_code"
        Dim dtLFL As New DataTable
        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cmd)
        Try
            Dim parameter As New SqlParameter("@bDate", SqlDbType.DateTime)
            parameter.Value = beginDate
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
            parameter.Value = endDate
            cmd.Parameters.Add(parameter)

            da.Fill(dtLFL)
            If dtLFL.Rows.Count > 0 Then

                Dim rev1 As Double = 0 : Dim rev2 As Double = 0 : Dim loss1 As Double = 0 : Dim loss2 As Double = 0
                Dim rev2SecondYearYoy As Double = 0 : Dim loss2SecondYearYoy As Double = 0
                Dim eDate As DateTime : Dim tempDate As DateTime
                Dim dtSumGrowth As DataTable = dtLFL.Clone : Dim drSumGrowth As DataRow = dtSumGrowth.NewRow
                Dim dtSumSecondYearYoy As DataTable = dtLFL.Clone : Dim drSecondYearYoy As DataRow = dtSumGrowth.NewRow
                Dim condition As String = ""
                Dim dtYoy As New DataTable
                dtYoy = dt.Clone

                For Each dr As DataRow In dt.Rows
                    '** first year No LFL,yoy Growth 

                    If dr("yearno").ToString.Contains("1") Then
                        dr("lfl_growth") = ClsManage.msgLFLNone
                        dr("yoy_growth") = ClsManage.msgLFLNone
                        dr("lfl_loss_growth") = ClsManage.msgLFLNone
                        dr("yoy_loss_growth") = ClsManage.msgLFLNone
                    End If

                    '** second year LFL เทียบกับเดือนของปีที่แล้ว แต่ yoy ต้องเทียบเดือนแรกด้วย
                    rev2 = 0 : loss2 = 0
                    rev2SecondYearYoy = 0 : loss2SecondYearYoy = 0
                    If dr("yearno").ToString <> "1" And dr("store_id").ToString <> "0" Then
                        tempDate = dr("beginDate") : eDate = dr("endDate")
                        'only second year yoy
                        If dr("yearno").ToString = "2" Then
                            Dim secondYearYoyDate As DateTime = tempDate.AddMonths(-1)
                            condition = String.Format("costcenter_code={0} and iMonth={1} and iYear={2}", dr("costcenter_code").ToString, secondYearYoyDate.Month, secondYearYoyDate.Year - 1)
                            drSecondYearYoy = dtLFL.NewRow
                            drSecondYearYoy = dtLFL.Select(condition)(0)
                            drSecondYearYoy("yearno") = dr("yearno")
                            drSecondYearYoy("location_id") = dr("location_id")
                            dtSumSecondYearYoy.ImportRow(drSecondYearYoy)

                            rev2SecondYearYoy = drSecondYearYoy("SumTotalRevenue")
                            loss2SecondYearYoy = drSecondYearYoy("SumStoreTradingProfit__Loss")
                        End If

                        If dr("yearno").ToString = "3" Then
                            Dim x As String = ""
                        End If

                        While tempDate < eDate
                            condition = String.Format("costcenter_code={0} and iMonth={1} and iYear={2}", dr("costcenter_code").ToString, tempDate.Month, tempDate.Year - 1)
                            drSumGrowth = dtLFL.NewRow
                            drSumGrowth = dtLFL.Select(condition)(0)
                            drSumGrowth("yearno") = dr("yearno")
                            drSumGrowth("location_id") = dr("location_id")
                            dtSumGrowth.ImportRow(drSumGrowth)

                            rev2 += drSumGrowth("SumTotalRevenue")
                            loss2 += drSumGrowth("SumStoreTradingProfit__Loss")

                            tempDate = tempDate.AddMonths(1)
                        End While

                        rev1 = dr("SumTotalRevenue")
                        loss1 = dr("SumStoreTradingProfit__Loss")

                        If rev1 <> 0 And rev2 <> 0 Then
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth((rev1 / rev2) - 1)
                            rev2SecondYearYoy = rev2 + rev2SecondYearYoy
                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((rev1 / rev2SecondYearYoy) - 1)
                        Else
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If

                        If loss1 <> 0 And loss2 <> 0 Then
                            'check ว่า มากขึ้นหรือน้อยลง
                            dr("lfl_loss_growth") = ClsManage.convert2PercenGrowthLoss(loss1, loss2)
                            loss2 = loss2 + loss2SecondYearYoy
                            dr("yoy_loss_growth") = ClsManage.convert2PercenGrowthLoss(loss1, loss2)
                        Else
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If
                    End If

                    'Summary
                    If Not dr("yearno").ToString.Contains("1") And dr("store_id").ToString = "0" Then '
                        rev1 = dr("SumTotalRevenue")
                        loss1 = dr("SumStoreTradingProfit__Loss")

                        If dr("location_name").ToString = clsBts.FullTotal.Total.ToString Then
                            condition = String.Format("yearno={0} ", dr("rankyear").ToString.Substring(0, 1))
                        Else
                            condition = String.Format("yearno={0} and location_id={1}", dr("rankyear").ToString.Substring(0, 1), dr("location_id"))
                        End If

                        rev2 = IIf(dtSumGrowth.Compute("Sum(SumTotalRevenue)", condition).ToString = "", 0, dtSumGrowth.Compute("Sum(SumTotalRevenue)", condition))
                        loss2 = IIf(dtSumGrowth.Compute("Sum(SumStoreTradingProfit__Loss)", condition).ToString = "", 0, dtSumGrowth.Compute("Sum(SumStoreTradingProfit__Loss)", condition))
                        rev2SecondYearYoy = IIf(dtSumSecondYearYoy.Compute("Sum(SumTotalRevenue)", condition).ToString = "", 0, dtSumSecondYearYoy.Compute("Sum(SumTotalRevenue)", condition))
                        loss2SecondYearYoy = IIf(dtSumSecondYearYoy.Compute("Sum(SumStoreTradingProfit__Loss)", condition).ToString = "", 0, dtSumSecondYearYoy.Compute("Sum(SumStoreTradingProfit__Loss)", condition))

                        If rev1 <> 0 And rev2 <> 0 Then
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth((rev1 / rev2) - 1)
                            rev2SecondYearYoy = rev2 + rev2SecondYearYoy
                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((rev1 / rev2SecondYearYoy) - 1)
                        Else
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If

                        If loss1 <> 0 And loss2 <> 0 Then
                            'check ว่า มากขึ้นหรือน้อยลง
                            dr("lfl_loss_growth") = ClsManage.convert2PercenGrowthLoss(loss1, loss2)
                            loss2 = loss2 + loss2SecondYearYoy
                            dr("yoy_loss_growth") = ClsManage.convert2PercenGrowthLoss(loss1, loss2)
                        Else
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If

                        'Set Total YOY Column
                        Dim drFullTotalYoy As DataRow = dtYoy.NewRow
                        Dim num As Double = 0 : Dim divi As Double = 0 : Dim divi2 As Double = 0
                        Dim columnName As String = "" : Dim sumName As String = ""

                        For i As Integer = 0 To dtLFL.Columns.Count - 1
                            columnName = dtLFL.Columns(i).ColumnName

                            If columnName.Contains("Sum") Then
                                sumName = "Sum(" + columnName + ")"

                                num = dr(columnName)
                                divi = IIf(dtSumGrowth.Compute(sumName, condition).ToString = "", 0, dtSumGrowth.Compute(sumName, condition))
                                divi2 = IIf(dtSumSecondYearYoy.Compute(sumName, condition).ToString = "", 0, dtSumSecondYearYoy.Compute(sumName, condition))
                                divi = divi + divi2

                                If num = 0 Or divi = 0 Then
                                    drFullTotalYoy(columnName) = 0
                                Else
                                    If columnName = "SumGrossProfit" Or columnName = "SumAdjustedGrossMargin" Or columnName = "SumStoreTradingProfit__Loss" Or columnName = "SumMarginAdjustments" Then
                                        Dim thisPb As Double = 0 : Dim prePb As Double = 0 : Dim pb As Double = 0
                                        thisPb = num / rev1
                                        prePb = divi / rev2
                                        pb = (thisPb - prePb) * 10000
                                        drFullTotalYoy(columnName) = pb
                                    Else
                                        drFullTotalYoy(columnName) = (num / divi) - 1
                                    End If
                                End If
                            End If
                        Next

                        drFullTotalYoy("location_id") = dr("location_id").ToString
                        drFullTotalYoy("location_count") = dr("location_count").ToString
                        drFullTotalYoy("location_name") = dr("location_name").ToString
                        drFullTotalYoy("rankyear") = dr("rankyear").ToString
                        drFullTotalYoy("yearno") = dr("yearno").ToString + "Yoy"
                        drFullTotalYoy("store_id") = 0
                        drFullTotalYoy("costcenter_store") = 0
                        drFullTotalYoy("store_name") = clsBts.reportPart.Total.ToString + "Yoy"

                        dtYoy.Rows.Add(drFullTotalYoy)



                    End If
                Next
                dt.Merge(dtYoy)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function

    Public Shared Function getPerformanceFull(ByVal bDate As String, rate As String) As DataSet

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")
        Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
        Dim endDate As DateTime = beginDate.AddYears(1).AddDays(-1)
        Dim years As String = endDate.Year.ToString
        Dim mon As String = endDate.Month.ToString

        Dim nDate As DateTime = DateTime.ParseExact("1/" + Now.Month.ToString + "/" + Now.Year.ToString, ClsManage.formatDateTime, Nothing)
        Dim iMonth As Long = DateDiff(DateInterval.Month, beginDate, nDate)

        Dim sql As String = "" & _
  "select * " & _
  ",case when costcenter_sale_area = 0 then 0 when count_month-1 = 0 then 0 when substring(cast(rankyear as varchar),6,1) = '1' then SumTotalRevenue/costcenter_sale_area/(count_month-1)  else SumTotalRevenue/costcenter_sale_area/count_month end as productivity " & _
  ",'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth " & _
  ",substring(cast(rankyear as varchar),6,1) as yearno,'' as location_count " &
  "from ( " & _
  "select rankyear,costcenter_code,beginDate," & _
  "case when  dateadd(day,1-day(endDate),endDate) > max(month_time) then dateadd(day,-1, dateadd(month,1,max(month_time))) else endDate end as endDate, " & _
  "DATEDIFF(month,beginDate,max(month_time))+1 as count_month," & _
  "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
  "" + clsBts.columnModelSum() + "" & _
  "from " & _
  "	(" & _
  "		select  " & _
  "		case when month_time between dateadd(day,1-day(costcenter_opendt), costcenter_opendt) and dateadd(day,-day(costcenter_opendt), dateadd(month,13,costcenter_opendt)) " & _
  "				then dateadd(day,1-day(costcenter_opendt), costcenter_opendt)" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,13,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,25,costcenter_opendt))" & _
  "				then dateadd(day,1-day(costcenter_opendt), dateadd(month,13,costcenter_opendt))" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,25,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,37,costcenter_opendt))" & _
  "				then dateadd(day,1-day(costcenter_opendt), dateadd(month,25,costcenter_opendt))" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,37,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,49,costcenter_opendt))" & _
  "				then dateadd(day,1-day(costcenter_opendt), dateadd(month,37,costcenter_opendt))" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,49,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,61,costcenter_opendt))" & _
  "				then dateadd(day,1-day(costcenter_opendt), dateadd(month,49,costcenter_opendt))" & _
  "		else 0 end as beginDate," & _
  "		case when month_time between dateadd(day,1-day(costcenter_opendt), costcenter_opendt) and dateadd(day,-day(costcenter_opendt), dateadd(month,13,costcenter_opendt)) " & _
  "				then dateadd(day,-day(costcenter_opendt), dateadd(month,13,costcenter_opendt))" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,13,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,25,costcenter_opendt))" & _
  "				then dateadd(day,-day(costcenter_opendt), dateadd(month,25,costcenter_opendt))" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,25,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,37,costcenter_opendt))" & _
  "				then dateadd(day,-day(costcenter_opendt), dateadd(month,37,costcenter_opendt))" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,37,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,49,costcenter_opendt))" & _
  "				then dateadd(day,-day(costcenter_opendt), dateadd(month,49,costcenter_opendt))" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,49,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,61,costcenter_opendt))" & _
  "				then dateadd(day,-day(costcenter_opendt), dateadd(month,61,costcenter_opendt))" & _
  "		else 0 end as endDate," & _
  "		case when month_time between dateadd(day,1-day(costcenter_opendt), costcenter_opendt) and dateadd(day,-day(costcenter_opendt), dateadd(month,13,costcenter_opendt)) " & _
  "				then costcenter_code + '01'" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,13,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,25,costcenter_opendt))" & _
  "				then costcenter_code + '02'" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,25,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,37,costcenter_opendt))" & _
  "				then costcenter_code + '03'" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,37,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,49,costcenter_opendt))" & _
  "				then costcenter_code + '04'" & _
  "			 when month_time between dateadd(day,1-day(costcenter_opendt), dateadd(month,49,costcenter_opendt)) AND dateadd(day,-day(costcenter_opendt), dateadd(month,61,costcenter_opendt))" & _
  "				then costcenter_code + '05'" & _
  "		else '0' end as rankyear," & _
  "		costcenter_code,costcenter_sale_area,costcenter_total_area,m.*" & _
  "		from mtd m INNER JOIN costcenter c on m.costcenter_id = c.costcenter_id" & _
  "		where month_time >= @bDate and costcenter_blockdt is null and costcenter_opendt between @bDate and @eDate " & _
  "	)sumYear	" & _
  "	where rankyear <> 0" & _
  "	group by rankyear,costcenter_code,beginDate,endDate " & _
  ")p " & _
  "inner join costcenter c on p.costcenter_code = c.costcenter_code " & _
  "inner join store s on s.store_id = c.costcenter_store  and s.store_other='N' " & _
  "inner join location l on l.location_id = c.costcenter_location " & _
  "order by c.costcenter_opendt,rankyear"

        'and costcenter_code in (4153,4154,4178,4180)

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@bDate", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@eDate", SqlDbType.DateTime)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)


        Dim dt As New DataTable
        Dim dtlflG As New DataTable
        Dim dtPreMtd As New DataTable
        Dim da As New SqlDataAdapter(cmd)
        Try
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                dt = getTotalPerFull(dt, 0)
                If dt.Select("location_id = '1'").Length > 0 And dt.Select("location_id = '2'").Length > 0 Then
                    dt = getTotalPerFull(dt, 1)
                    dt = getTotalPerFull(dt, 2)
                End If

                'Set New LFL
                dt = setPerFullLFLGrowth(dt, beginDate)
            End If

            Dim ds As New DataSet
            Dim dtItem As New DataTable : Dim dtTotal As New DataTable
            dtItem = dt.Clone : dtTotal = dt.Clone

            'แยก row ที่เป็น total ออกไปอีก table
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("costcenter_store") = 0 Then
                    dtTotal.ImportRow(dt.Rows(i))
                Else
                    dtItem.ImportRow(dt.Rows(i))
                End If
            Next
            dt.Dispose()
            ds.Tables.Add(dtItem)
            ds.Tables(0).TableName = clsBts.reportPart.Item.ToString

            ''Add Total YOY
            'Dim drFullTotalYoy As DataRow
            'Dim drNewFullTotalYoy As DataRow

            'For i As Integer = 0 To dtTotal.Rows.Count - 1
            '    drFullTotalYoy = clsBts.getYoyYtdTotal(years, mon, IIf(dtTotal.Rows(i)("location_id").ToString = "0", "", dtTotal.Rows(i)("location_id").ToString), rate).Rows(2)
            '    drNewFullTotalYoy = dtTotal.NewRow
            '    For j As Integer = 0 To drFullTotalYoy.Table.Columns.Count - 1
            '        If drFullTotalYoy.Table.Columns(j).ColumnName.Contains("Sum") Then
            '            drNewFullTotalYoy(drFullTotalYoy.Table.Columns(j).ColumnName) = drFullTotalYoy(drFullTotalYoy.Table.Columns(j).ColumnName)
            '        End If
            '    Next
            '    drNewFullTotalYoy("location_id") = dtTotal.Rows(i)("location_id").ToString
            '    drNewFullTotalYoy("location_count") = dtTotal.Rows(i)("location_count").ToString
            '    drNewFullTotalYoy("location_name") = dtTotal.Rows(i)("location_name").ToString
            '    drNewFullTotalYoy("rankyear") = dtTotal.Rows(i)("rankyear").ToString
            '    drNewFullTotalYoy("yearno") = dtTotal.Rows(i)("yearno").ToString + "Yoy"
            '    drNewFullTotalYoy("store_id") = 0
            '    drNewFullTotalYoy("costcenter_store") = 0
            '    drNewFullTotalYoy("store_name") = clsBts.reportPart.Total.ToString + "Yoy"
            '    dtTotal.Rows.Add(drNewFullTotalYoy)
            'Next


            'Dim drTotalYoy As Data.DataRow
            'drTotalYoy = clsBts.getYoyYtdTotal(years, mon, "", rate).Rows(2)

            'Dim drNewTotalYoy As DataRow


            'drNewTotalYoy = dtTotal.NewRow
            'For i As Integer = 0 To drTotalYoy.Table.Columns.Count - 1
            '    If drTotalYoy.Table.Columns(i).ColumnName.Contains("Sum") Then
            '        drNewTotalYoy(drTotalYoy.Table.Columns(i).ColumnName) = drTotalYoy(drTotalYoy.Table.Columns(i).ColumnName)
            '    End If
            'Next
            'drNewTotalYoy("location_id") = 0
            'drNewTotalYoy("store_id") = 0
            'drNewTotalYoy("costcenter_store") = 0
            'drNewTotalYoy("store_name") = "TotalYoy"
            'dtTotal.Rows.Add(drNewTotalYoy)

            ds.Tables.Add(dtTotal)
            ds.Tables(1).TableName = clsBts.reportPart.Total.ToString
            dtTotal.Dispose()
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

    Public Shared Sub getDDLFullYear(ddl As DropDownList)
        Dim sql As String = "select distinct YEAR(month_time) as years, " & _
            "'Y.' + cast((YEAR(month_time) ) as varchar)+'/'+ substring( cast(YEAR(month_time)+1 as varchar),3,2)  as fullyear " & _
            "from mtd order by years desc "
        Try

            Using da As New SqlDataAdapter(sql, strcon)
                Using dt As New Data.DataTable
                    da.Fill(dt)
                    ddl.DataValueField = "years"
                    ddl.DataTextField = "fullyear"
                    ddl.DataSource = dt
                    ddl.DataBind()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Export Perpormance"
    Public Shared Sub ExportToExcel(ByVal data_temp As String, Optional excelName As String = "Performance_Report")

        'Copy From Bts Class

        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.Buffer = True
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode
        HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & excelName & ".xls")
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        HttpContext.Current.Response.Charset = String.Empty
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        Dim sw As System.IO.StringWriter = New System.IO.StringWriter()
        Dim hw As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(sw)

        'Change ' to "
        data_temp = data_temp.Replace("class=""GridviewScrollC1Header""", "style='color: #FFFFFF;background: #376091' ")
        data_temp = data_temp.Replace("<table", "<style> TD { mso-number-format:\@; } </style> <table ")

        HttpContext.Current.Response.Output.Write(data_temp)
        HttpContext.Current.Response.Flush()
        HttpContext.Current.Response.End()

    End Sub
#End Region

End Class
