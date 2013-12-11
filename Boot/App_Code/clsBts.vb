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

Public Class clsBts
    Public Shared strcon As String = ConfigurationManager.ConnectionStrings("bootsConnectionString").ConnectionString
    Public Shared storeNoCount As String = "CDS"

    Enum FullTotal
        Total = 1
        BKK
        UPC
        Yoy
    End Enum

    Enum reportPart
        Total = 1
        Item
    End Enum

    Enum location
        Bangkok = 1
        Upcountry
    End Enum

    Enum reportType
        MTD = 1
        YTD
        ByFormat
    End Enum

    Enum reportColumn
        'start row 10 in excel
        
        TotalRevenue = 10
        RETAIL_TESPIncome = 11
        OtherRevenue = 12
        CostofGoodSold = 13
        GrossProfit = 14
        GrossProfit_percent = 15
        MarginAdjustments = 16
        Shipping = 17
        StockLossandObsolescence = 18
        InventoryAdjustment_stock = 19
        InventoryAdjustment_damage = 20
        StockLoss_Provision = 21
        StockObsolescence_Provision = 22
        GWP = 23
        GWPs_Corporate = 24
        GWPs_Transferred = 25
        SellingCosts = 26
        Creditcardscommission = 27
        LabellingMaterial = 28
        OtherIncome_COSHFunding = 29
        OtherIncomeSupplier = 30
        AdjustedGrossMargin = 31
        SupplyChainCosts = 32
        TotalStoreExpenses = 33
        StoreLabourCosts = 34
        GrossPay = 35
        TemporaryStaffCosts = 36
        Allowance = 37
        Overtime = 38
        Licensefee = 39
        Bonuses_Incentives = 40
        BootsBrandncentives = 41
        SuppliersIncentive = 42
        ProvidentFund = 43
        PensionCosts = 44
        SocialSecurityFund = 45
        Uniforms = 46
        EmployeeWelfare = 47
        OtherBenefitsEmployee = 48
        StorePropertyCosts = 49
        PropertyRental = 50
        PropertyServices = 51
        PropertyFacility = 52
        Propertytaxes = 53
        Facialtaxes = 54
        PropertyInsurance = 55
        Signboard = 56
        Discount_Rent_Services_Facility = 57
        GPCommission = 58
        AmortizationofLeaseRight = 59
        Depreciation = 60
        DepreciationofShortLeaseBuilding = 61
        DepreciationofComputerHardware = 62
        DepreciationofFixturesFittings = 63
        DepreciationofComputerSoftware = 64
        DepreciationofOfficeEquipment = 65
        OtherStoreCosts = 66
        ServiceChargesandOtherFees = 67
        BankCharges = 68
        CashCollectionCharge = 69
        Cleaning = 70
        SecurityGuards = 71
        Carriage = 72
        LicenceFees = 73
        OtherServicesCharge = 74
        OtherFees = 75
        Utilities = 76
        Water = 77
        Gas_Electric = 78
        AirCond_Addition = 79
        RepairandMaintenance = 80
        RMOther_Fix = 81
        RMOther_Unplan = 82
        RMComputer_Fix = 83
        RMComputer_Unplan = 84
        SWMaintenance = 85
        HWMaintenance = 86
        ProfessionalFee = 87
        MarketingResearch = 88
        OtherFee = 89
        Equipment_MaterailandSupplies = 90
        PrintingandStationery = 91
        SuppliesExpenses = 92
        Equipment = 93
        Shopfitting = 94
        PackagingandOtherMaterial = 95
        BusinessTravelExpenses = 96
        CarParkingandOthers = 97
        Travel = 98
        Accomodation = 99
        MealandEntertainment = 100
        Insurance = 101
        AllRiskInsurance = 102
        HealthandLifeInsurance = 103
        PenaltyandTaxation = 104
        Taxation = 105
        Penalty = 106
        OtherRelatedStaffCost = 107
        StaffConferenceandTraining = 108
        Training = 109
        Communication = 110
        TelephoneCalls_Faxes = 111
        PostageandCourier = 112
        ITTelecommunications = 113
        OtherExpenses = 114
        Sample_Tester = 115
        PreopeningCosts = 116
        LossonClaim = 117
        CashOvertage_Shortagefromsales = 118
        MiscellenousandOther = 119
        StoreTradingProfit__Loss = 120
        TradingProfit__Loss = 121
        StoreControllableCostsforBSC = 123
        StoreLabourCost = 124
        Utillity = 125
        RepairMaintenance = 126

    End Enum

#Region "Area"
    Public Shared Function getLFLGrowthArea(ByVal years As String, ByVal mon As String, by As String) As DataTable
        'store_id = format
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""

        sqlCol = "select SUM(TotalRevenue) as SumRevenue,SUM(StoreTradingProfit__Loss) as SumLoss, cb.costcenter_areas, "
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
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )  AND (sto.store_id = @store_id or @store_id = '')  " & _
" AND (cb.costcenter_location = @locate OR @locate = '' )"
        sqlCondition2 = "GROUP BY cb.costcenter_areas )g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar)  " & _
            "from mtd dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by cb.costcenter_areas )g2 on g1.costcenter_areas = g2.costcenter_areas"

        sql = "select g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2,g1.SumLoss as loss1,g2.SumLoss as loss2, g1.costcenter_areas as store_id from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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
        parameter.Value = ""
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 And by = clsBts.reportType.MTD.ToString Then
                Dim dtRGlfl As New DataTable
                dtRGlfl = dt.Clone
                Dim rev1 As Double = 0
                Dim rev2 As Double = 0
                Dim loss1 As Double = 0
                Dim loss2 As Double = 0
                Dim sumRev1 As Double = IIf(dt.Compute("Sum(rev1)", "").ToString = "", 0, dt.Compute("Sum(rev1)", ""))
                Dim sumRev2 As Double = IIf(dt.Compute("Sum(rev2)", "").ToString = "", 0, dt.Compute("Sum(rev2)", ""))
                Dim sumLoss1 As Double = IIf(dt.Compute("Sum(loss1)", "").ToString = "", 0, dt.Compute("Sum(loss1)", ""))
                Dim sumLoss2 As Double = IIf(dt.Compute("Sum(loss2)", "").ToString = "", 0, dt.Compute("Sum(loss2)", ""))

                For Each dr As DataRow In dt.Rows
                    rev1 = IIf(IsDBNull(dr(0)), 0, dr(0))
                    rev2 = IIf(IsDBNull(dr(1)), 0, dr(1))
                    loss1 = IIf(IsDBNull(dr(2)), 0, dr(2))
                    loss2 = IIf(IsDBNull(dr(3)), 0, dr(3))

                    If rev1 <> 0 And rev2 <> 0 Then
                        dr("rev1") = (rev1 / rev2) - 1
                    Else
                        dr("rev1") = 0
                    End If

                    If loss1 <> 0 And loss2 <> 0 Then
                        dr("loss1") = (loss1 / loss2) - 1
                    Else
                        dr("loss1") = 0
                    End If

                Next
                Dim drSum As DataRow = dt.NewRow
                'Sum Total Revenue
                If sumRev1 <> 0 And sumRev2 <> 0 Then
                    drSum("rev1") = (sumRev1 / sumRev2) - 1
                Else
                    drSum("rev1") = 0
                End If

                'Sum Store Trading Profit/Loss
                If sumLoss2 <> 0 And sumLoss1 <> 0 Then
                    drSum("loss1") = (sumLoss1 / sumLoss2) - 1
                Else
                    drSum("loss1") = 0
                End If

                'สมมุติให้เป็น store id = 0
                drSum("store_id") = 0

                dt.Rows.Add(drSum)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getYoyMtdArea(ByVal years As String, ByVal mon As String, by As String) As DataTable

        Dim area As String = ""
        Dim sqlTbl As String = "mtd"

        Dim sql As String = "select *  from (select COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_areas as costcenter_store, " & _
        "SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumLoss " & _
        "from " + sqlTbl + " mt,costcenter cc " & _
        "where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " + area + " " & _
        " and cc.costcenter_opendt < @sl_dt " & _
        " group by costcenter_areas ) sm,store st where sm.costcenter_store=st.store_id and st.store_other='N' order by st.store_order asc"

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

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 And by = clsBts.reportType.MTD.ToString Then
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""

                drTotal("costcenter_store") = 0
                drTotal("store_id") = 0
                drTotal("store_name") = reportPart.Total.ToString
                drTotal("SumTotalRevenue") = IIf(dt.Compute("Sum(SumTotalRevenue)", "").ToString = "", 0, dt.Compute("Sum(SumTotalRevenue)", ""))
                drTotal("SumLoss") = IIf(dt.Compute("Sum(SumLoss)", "").ToString = "", 0, dt.Compute("Sum(SumLoss)", ""))
                dt.Rows.Add(drTotal)
            End If
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getYoyYtdArea(ByVal years As String, ByVal mon As String) As DataTable

        Dim sqlTbl As String = "mtd"

        Dim sql As String = "select * from ( " & _
        "select  COUNT(DISTINCT cs.costcenter_id) as cnum, cs.costcenter_store, " & _
        "SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumLoss " & _
        "from ( " & _
        "select mt.costcenter_id, " & _
        "SUM(TotalRevenue) as TotalRevenue,SUM(StoreTradingProfit__Loss) as StoreTradingProfit__Loss  " & _
        "from ( " & _
        "select mta.* " & _
        "from " + sqlTbl + " mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "(cca.costcenter_blockdt Is null OR cca.costcenter_blockdt >= @sl_dt) And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= @start_time " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id " & _
        " and cc.costcenter_opendt < @sl_dt " & _
        "group by mt.costcenter_id " & _
        ") mt2,costcenter cs " & _
        "where mt2.costcenter_id = cs.costcenter_id " & _
        "group by cs.costcenter_areas " & _
        ") bb,store st1 " & _
        "where bb.costcenter_store = st1.store_id and st1.store_other='N' order by st1.store_order asc"



        ' Dim sql1 As String = "select *  from (select COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_areas as costcenter_store, " & _
        '"SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumLoss " & _
        '"from " + sqlTbl + " mt,costcenter cc " & _
        '"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " + area + " " & _
        '" and cc.costcenter_opendt < @sl_dt " & _
        '" group by costcenter_areas ) sm,store st where sm.costcenter_store=st.store_id and st.store_other='N' order by st.store_order asc"




        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        Dim start_date As String
        If Integer.Parse(mon) < 4 Then
            start_date = "1/4/" + (years - 1).ToString
        Else
            start_date = "1/4/" + years
        End If
        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_date, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim drTotal As DataRow = dt.NewRow
                drTotal("costcenter_store") = 0
                drTotal("store_id") = 0
                drTotal("store_name") = reportPart.Total.ToString
                drTotal("SumTotalRevenue") = IIf(dt.Compute("Sum(SumTotalRevenue)", "").ToString = "", 0, dt.Compute("Sum(SumTotalRevenue)", ""))
                drTotal("SumLoss") = IIf(dt.Compute("Sum(SumLoss)", "").ToString = "", 0, dt.Compute("Sum(SumLoss)", ""))
                dt.Rows.Add(drTotal)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            cmd.Dispose()
            da.Dispose()
        End Try
    End Function
#End Region

#Region "SqlString"
    Public Shared Function sqlTempClose() As String
        Dim sql As String = "" & _
            "select distinct tempc_costcenter_id " & _
            "from ( select *, CASE WHEN (tempc_start IS null and tempc_finish >= @thisyear ) OR (tempc_start IS null and tempc_finish >= @lastyear ) THEN 1 " & _
            "WHEN (tempc_start <= @thisyear2 and tempc_finish IS null) OR (tempc_start <= @lastyear2 and tempc_finish IS null) THEN 1 " & _
            "WHEN (tempc_start <= @thisyear2 and tempc_finish >= @thisyear) OR (tempc_start <= @lastyear2 and tempc_finish >= @lastyear) THEN 1 ELSE 0 END AS status_at from tempc) as tt " & _
            "where status_at = 1 "
        Return sql
    End Function
#End Region

#Region "columnMtd"

    Public Shared Function columnModelSum() As String
        Dim col As New StringBuilder
        col.Append("SUM(TotalRevenue) as SumTotalRevenue, ")
        col.Append("SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, ")
        col.Append("SUM(OtherRevenue) as SumOtherRevenue, ")
        col.Append("SUM(CostofGoodSold) as SumCostofGoodSold, ")
        col.Append("SUM(GrossProfit) as SumGrossProfit, ")
        'col.Append("SUM(GrossProfit_percent) as SumGrossProfit_percent, ")
        col.Append("SUM(MarginAdjustments) as SumMarginAdjustments, ")
        col.Append("SUM(Shipping) as SumShipping, ")
        col.Append("SUM(StockLossandObsolescence) as SumStockLossandObsolescence, ")
        col.Append("SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, ")
        col.Append("SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, ")
        col.Append("SUM(StockLoss_Provision) as SumStockLoss_Provision, ")
        col.Append("SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, ")
        col.Append("SUM(GWP) as SumGWP, ")
        col.Append("SUM(GWPs_Corporate) as SumGWPs_Corporate, ")
        col.Append("SUM(GWPs_Transferred) as SumGWPs_Transferred, ")
        col.Append("SUM(SellingCosts) as SumSellingCosts, ")
        col.Append("SUM(Creditcardscommission) as SumCreditcardscommission, ")
        col.Append("SUM(LabellingMaterial) as SumLabellingMaterial, ")
        col.Append("SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, ")
        col.Append("SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, ")
        col.Append("SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, ")
        col.Append("SUM(SupplyChainCosts) as SumSupplyChainCosts, ")
        col.Append("SUM(TotalStoreExpenses) as SumTotalStoreExpenses, ")
        col.Append("SUM(StoreLabourCosts) as SumStoreLabourCosts, ")
        col.Append("SUM(GrossPay) as SumGrossPay, ")
        col.Append("SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, ")
        col.Append("SUM(Allowance) as SumAllowance, ")
        col.Append("SUM(Overtime) as SumOvertime, ")
        col.Append("SUM(Licensefee) as SumLicensefee, ")
        col.Append("SUM(Bonuses_Incentives) as SumBonuses_Incentives, ")
        col.Append("SUM(BootsBrandncentives) as SumBootsBrandncentives, ")
        col.Append("SUM(SuppliersIncentive) as SumSuppliersIncentive, ")
        col.Append("SUM(ProvidentFund) as SumProvidentFund, ")
        col.Append("SUM(PensionCosts) as SumPensionCosts, ")
        col.Append("SUM(SocialSecurityFund) as SumSocialSecurityFund, ")
        col.Append("SUM(Uniforms) as SumUniforms, ")
        col.Append("SUM(EmployeeWelfare) as SumEmployeeWelfare, ")
        col.Append("SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, ")
        col.Append("SUM(StorePropertyCosts) as SumStorePropertyCosts, ")
        col.Append("SUM(PropertyRental) as SumPropertyRental, ")
        col.Append("SUM(PropertyServices) as SumPropertyServices, ")
        col.Append("SUM(PropertyFacility) as SumPropertyFacility, ")
        col.Append("SUM(Propertytaxes) as SumPropertytaxes, ")
        col.Append("SUM(Facialtaxes) as SumFacialtaxes, ")
        col.Append("SUM(PropertyInsurance) as SumPropertyInsurance, ")
        col.Append("SUM(Signboard) as SumSignboard, ")
        col.Append("SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, ")
        col.Append("SUM(GPCommission) as SumGPCommission, ")
        col.Append("SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, ")
        col.Append("SUM(Depreciation) as SumDepreciation, ")
        col.Append("SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, ")
        col.Append("SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, ")
        col.Append("SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, ")
        col.Append("SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, ")
        col.Append("SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, ")
        col.Append("SUM(OtherStoreCosts) as SumOtherStoreCosts, ")
        col.Append("SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, ")
        col.Append("SUM(BankCharges) as SumBankCharges, ")
        col.Append("SUM(CashCollectionCharge) as SumCashCollectionCharge, ")
        col.Append("SUM(Cleaning) as SumCleaning, ")
        col.Append("SUM(SecurityGuards) as SumSecurityGuards, ")
        col.Append("SUM(Carriage) as SumCarriage, ")
        col.Append("SUM(LicenceFees) as SumLicenceFees, ")
        col.Append("SUM(OtherServicesCharge) as SumOtherServicesCharge, ")
        col.Append("SUM(OtherFees) as SumOtherFees, ")
        col.Append("SUM(Utilities) as SumUtilities, ")
        col.Append("SUM(Water) as SumWater, ")
        col.Append("SUM(Gas_Electric) as SumGas_Electric, ")
        col.Append("SUM(AirCond_Addition) as SumAirCond_Addition, ")
        col.Append("SUM(RepairandMaintenance) as SumRepairandMaintenance, ")
        col.Append("SUM(RMOther_Fix) as SumRMOther_Fix, ")
        col.Append("SUM(RMOther_Unplan) as SumRMOther_Unplan, ")
        col.Append("SUM(RMComputer_Fix) as SumRMComputer_Fix, ")
        col.Append("SUM(RMComputer_Unplan) as SumRMComputer_Unplan, ")
        col.Append("SUM(ProfessionalFee) as SumProfessionalFee, ")
        col.Append("SUM(MarketingResearch) as SumMarketingResearch, ")
        col.Append("SUM(OtherFee) as SumOtherFee, ")
        col.Append("SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, ")
        col.Append("SUM(PrintingandStationery) as SumPrintingandStationery, ")
        col.Append("SUM(SuppliesExpenses) as SumSuppliesExpenses, ")
        col.Append("SUM(Equipment) as SumEquipment, ")
        col.Append("SUM(Shopfitting) as SumShopfitting, ")
        col.Append("SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, ")
        col.Append("SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, ")
        col.Append("SUM(CarParkingandOthers) as SumCarParkingandOthers, ")
        col.Append("SUM(Travel) as SumTravel, ")
        col.Append("SUM(Accomodation) as SumAccomodation, ")
        col.Append("SUM(MealandEntertainment) as SumMealandEntertainment, ")
        col.Append("SUM(Insurance) as SumInsurance, ")
        col.Append("SUM(AllRiskInsurance) as SumAllRiskInsurance, ")
        col.Append("SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, ")
        col.Append("SUM(PenaltyandTaxation) as SumPenaltyandTaxation, ")
        col.Append("SUM(Taxation) as SumTaxation, ")
        col.Append("SUM(Penalty) as SumPenalty, ")
        col.Append("SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, ")
        col.Append("SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, ")
        col.Append("SUM(Training) as SumTraining, ")
        col.Append("SUM(Communication) as SumCommunication, ")
        col.Append("SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, ")
        col.Append("SUM(PostageandCourier) as SumPostageandCourier, ")
        col.Append("SUM(OtherExpenses) as SumOtherExpenses, ")
        col.Append("SUM(Sample_Tester) as SumSample_Tester, ")
        col.Append("SUM(PreopeningCosts) as SumPreopeningCosts, ")
        col.Append("SUM(LossonClaim) as SumLossonClaim, ")
        col.Append("SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, ")
        col.Append("SUM(MiscellenousandOther) as SumMiscellenousandOther, ")
        col.Append("SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, ")
        'col.Append("SUM(TradingProfit__Loss) as SumTradingProfit__Loss, ")
        'col.Append("SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, ")
        'col.Append("SUM(StoreLabourCost) as SumStoreLabourCost, ")
        'col.Append("SUM(Utillity) as SumUtillity, ")
        'col.Append("SUM(RepairMaintenance) as SumRepairMaintenance, ")
        col.Append("SUM(SWMaintenance) as SumSWMaintenance, ")
        col.Append("SUM(HWMaintenance) as SumHWMaintenance, ")
        col.Append("SUM(ITTelecommunications) as SumITTelecommunications ")
        Return col.ToString
    End Function

    Public Shared Function columnMtdSumInSum() As String
        Dim col As New StringBuilder
        col.Append("SUM(SumTotalRevenue) as SumTotalRevenue, ")
        col.Append("SUM(SumRETAIL_TESPIncome) as SumRETAIL_TESPIncome, ")
        col.Append("SUM(SumOtherRevenue) as SumOtherRevenue, ")
        col.Append("SUM(SumCostofGoodSold) as SumCostofGoodSold, ")
        col.Append("SUM(SumGrossProfit) as SumGrossProfit, ")
        col.Append("SUM(SumMarginAdjustments) as SumMarginAdjustments, ")
        col.Append("SUM(SumShipping) as SumShipping, ")
        col.Append("SUM(SumStockLossandObsolescence) as SumStockLossandObsolescence, ")
        col.Append("SUM(SumInventoryAdjustment_stock) as SumInventoryAdjustment_stock, ")
        col.Append("SUM(SumInventoryAdjustment_damage) as SumInventoryAdjustment_damage, ")
        col.Append("SUM(SumStockLoss_Provision) as SumStockLoss_Provision, ")
        col.Append("SUM(SumStockObsolescence_Provision) as SumStockObsolescence_Provision, ")
        col.Append("SUM(SumGWP) as SumGWP, ")
        col.Append("SUM(SumGWPs_Corporate) as SumGWPs_Corporate, ")
        col.Append("SUM(SumGWPs_Transferred) as SumGWPs_Transferred, ")
        col.Append("SUM(SumSellingCosts) as SumSellingCosts, ")
        col.Append("SUM(SumCreditcardscommission) as SumCreditcardscommission, ")
        col.Append("SUM(SumLabellingMaterial) as SumLabellingMaterial, ")
        col.Append("SUM(SumOtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, ")
        col.Append("SUM(SumOtherIncomeSupplier) as SumOtherIncomeSupplier, ")
        col.Append("SUM(SumAdjustedGrossMargin) as SumAdjustedGrossMargin, ")
        col.Append("SUM(SumSupplyChainCosts) as SumSupplyChainCosts, ")
        col.Append("SUM(SumTotalStoreExpenses) as SumTotalStoreExpenses, ")
        col.Append("SUM(SumStoreLabourCosts) as SumStoreLabourCosts, ")
        col.Append("SUM(SumGrossPay) as SumGrossPay, ")
        col.Append("SUM(SumTemporaryStaffCosts) as SumTemporaryStaffCosts, ")
        col.Append("SUM(SumAllowance) as SumAllowance, ")
        col.Append("SUM(SumOvertime) as SumOvertime, ")
        col.Append("SUM(SumLicensefee) as SumLicensefee, ")
        col.Append("SUM(SumBonuses_Incentives) as SumBonuses_Incentives, ")
        col.Append("SUM(SumBootsBrandncentives) as SumBootsBrandncentives, ")
        col.Append("SUM(SumSuppliersIncentive) as SumSuppliersIncentive, ")
        col.Append("SUM(SumProvidentFund) as SumProvidentFund, ")
        col.Append("SUM(SumPensionCosts) as SumPensionCosts, ")
        col.Append("SUM(SumSocialSecurityFund) as SumSocialSecurityFund, ")
        col.Append("SUM(SumUniforms) as SumUniforms, ")
        col.Append("SUM(SumEmployeeWelfare) as SumEmployeeWelfare, ")
        col.Append("SUM(SumOtherBenefitsEmployee) as SumOtherBenefitsEmployee, ")
        col.Append("SUM(SumStorePropertyCosts) as SumStorePropertyCosts, ")
        col.Append("SUM(SumPropertyRental) as SumPropertyRental, ")
        col.Append("SUM(SumPropertyServices) as SumPropertyServices, ")
        col.Append("SUM(SumPropertyFacility) as SumPropertyFacility, ")
        col.Append("SUM(SumPropertytaxes) as SumPropertytaxes, ")
        col.Append("SUM(SumFacialtaxes) as SumFacialtaxes, ")
        col.Append("SUM(SumPropertyInsurance) as SumPropertyInsurance, ")
        col.Append("SUM(SumSignboard) as SumSignboard, ")
        col.Append("SUM(SumDiscount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, ")
        col.Append("SUM(SumGPCommission) as SumGPCommission, ")
        col.Append("SUM(SumAmortizationofLeaseRight) as SumAmortizationofLeaseRight, ")
        col.Append("SUM(SumDepreciation) as SumDepreciation, ")
        col.Append("SUM(SumDepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, ")
        col.Append("SUM(SumDepreciationofComputerHardware) as SumDepreciationofComputerHardware, ")
        col.Append("SUM(SumDepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, ")
        col.Append("SUM(SumDepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, ")
        col.Append("SUM(SumDepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, ")
        col.Append("SUM(SumOtherStoreCosts) as SumOtherStoreCosts, ")
        col.Append("SUM(SumServiceChargesandOtherFees) as SumServiceChargesandOtherFees, ")
        col.Append("SUM(SumBankCharges) as SumBankCharges, ")
        col.Append("SUM(SumCashCollectionCharge) as SumCashCollectionCharge, ")
        col.Append("SUM(SumCleaning) as SumCleaning, ")
        col.Append("SUM(SumSecurityGuards) as SumSecurityGuards, ")
        col.Append("SUM(SumCarriage) as SumCarriage, ")
        col.Append("SUM(SumLicenceFees) as SumLicenceFees, ")
        col.Append("SUM(SumOtherServicesCharge) as SumOtherServicesCharge, ")
        col.Append("SUM(SumOtherFees) as SumOtherFees, ")
        col.Append("SUM(SumUtilities) as SumUtilities, ")
        col.Append("SUM(SumWater) as SumWater, ")
        col.Append("SUM(SumGas_Electric) as SumGas_Electric, ")
        col.Append("SUM(SumAirCond_Addition) as SumAirCond_Addition, ")
        col.Append("SUM(SumRepairandMaintenance) as SumRepairandMaintenance, ")
        col.Append("SUM(SumRMOther_Fix) as SumRMOther_Fix, ")
        col.Append("SUM(SumRMOther_Unplan) as SumRMOther_Unplan, ")
        col.Append("SUM(SumRMComputer_Fix) as SumRMComputer_Fix, ")
        col.Append("SUM(SumRMComputer_Unplan) as SumRMComputer_Unplan, ")
        col.Append("SUM(SumProfessionalFee) as SumProfessionalFee, ")
        col.Append("SUM(SumMarketingResearch) as SumMarketingResearch, ")
        col.Append("SUM(SumOtherFee) as SumOtherFee, ")
        col.Append("SUM(SumEquipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, ")
        col.Append("SUM(SumPrintingandStationery) as SumPrintingandStationery, ")
        col.Append("SUM(SumSuppliesExpenses) as SumSuppliesExpenses, ")
        col.Append("SUM(SumEquipment) as SumEquipment, ")
        col.Append("SUM(SumShopfitting) as SumShopfitting, ")
        col.Append("SUM(SumPackagingandOtherMaterial) as SumPackagingandOtherMaterial, ")
        col.Append("SUM(SumBusinessTravelExpenses) as SumBusinessTravelExpenses, ")
        col.Append("SUM(SumCarParkingandOthers) as SumCarParkingandOthers, ")
        col.Append("SUM(SumTravel) as SumTravel, ")
        col.Append("SUM(SumAccomodation) as SumAccomodation, ")
        col.Append("SUM(SumMealandEntertainment) as SumMealandEntertainment, ")
        col.Append("SUM(SumInsurance) as SumInsurance, ")
        col.Append("SUM(SumAllRiskInsurance) as SumAllRiskInsurance, ")
        col.Append("SUM(SumHealthandLifeInsurance) as SumHealthandLifeInsurance, ")
        col.Append("SUM(SumPenaltyandTaxation) as SumPenaltyandTaxation, ")
        col.Append("SUM(SumTaxation) as SumTaxation, ")
        col.Append("SUM(SumPenalty) as SumPenalty, ")
        col.Append("SUM(SumOtherRelatedStaffCost) as SumOtherRelatedStaffCost, ")
        col.Append("SUM(SumStaffConferenceandTraining) as SumStaffConferenceandTraining, ")
        col.Append("SUM(SumTraining) as SumTraining, ")
        col.Append("SUM(SumCommunication) as SumCommunication, ")
        col.Append("SUM(SumTelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, ")
        col.Append("SUM(SumPostageandCourier) as SumPostageandCourier, ")
        col.Append("SUM(SumOtherExpenses) as SumOtherExpenses, ")
        col.Append("SUM(SumSample_Tester) as SumSample_Tester, ")
        col.Append("SUM(SumPreopeningCosts) as SumPreopeningCosts, ")
        col.Append("SUM(SumLossonClaim) as SumLossonClaim, ")
        col.Append("SUM(SumCashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, ")
        col.Append("SUM(SumMiscellenousandOther) as SumMiscellenousandOther, ")
        col.Append("SUM(SumStoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, ")
        'col.Append("SUM(SumTradingProfit__Loss) as SumTradingProfit__Loss, ")
        'col.Append("SUM(SumStoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, ")
        'col.Append("SUM(SumStoreLabourCost) as SumStoreLabourCost, ")
        'col.Append("SUM(SumUtillity) as SumUtillity, ")
        'col.Append("SUM(SumRepairMaintenance) as SumRepairMaintenance, ")
        col.Append("SUM(SumSWMaintenance) as SumSWMaintenance, ")
        col.Append("SUM(SumHWMaintenance) as SumHWMaintenance, ")
        col.Append("SUM(SumITTelecommunications) as SumITTelecommunications ")


        Return col.ToString
    End Function

    Private Shared Function columnModelSumEnd() As String
        Dim col As New StringBuilder
        col.Append("SumTotalRevenue, SumRETAIL_TESPIncome, SumOtherRevenue, SumCostofGoodSold, SumGrossProfit, SumMarginAdjustments,")
        col.Append("SumShipping, SumStockLossandObsolescence, SumInventoryAdjustment_stock, SumInventoryAdjustment_damage, SumStockLoss_Provision,")
        col.Append("SumStockObsolescence_Provision, SumGWP, SumGWPs_Corporate, SumGWPs_Transferred, SumSellingCosts, SumCreditcardscommission, SumLabellingMaterial,")
        col.Append("SumOtherIncome_COSHFunding, SumOtherIncomeSupplier, SumAdjustedGrossMargin, SumSupplyChainCosts, SumTotalStoreExpenses, SumStoreLabourCosts,")
        col.Append("SumGrossPay, SumTemporaryStaffCosts, SumAllowance, SumOvertime, SumLicensefee, SumBonuses_Incentives, SumBootsBrandncentives, SumSuppliersIncentive,")
        col.Append("SumProvidentFund, SumPensionCosts, SumSocialSecurityFund, SumUniforms, SumEmployeeWelfare, SumOtherBenefitsEmployee, SumStorePropertyCosts,")
        col.Append("SumPropertyRental, SumPropertyServices, SumPropertyFacility, SumPropertytaxes, SumFacialtaxes, SumPropertyInsurance, SumSignboard,")
        col.Append("SumDiscount_Rent_Services_Facility, SumGPCommission, SumAmortizationofLeaseRight, SumDepreciation, SumDepreciationofShortLeaseBuilding,")
        col.Append("SumDepreciationofComputerHardware, SumDepreciationofFixturesFittings, SumDepreciationofComputerSoftware, SumDepreciationofOfficeEquipment,")
        col.Append("SumOtherStoreCosts, SumServiceChargesandOtherFees, SumBankCharges, SumCashCollectionCharge, SumCleaning, SumSecurityGuards, SumCarriage,")
        col.Append("SumLicenceFees, SumOtherServicesCharge, SumOtherFees, SumUtilities, SumWater, SumGas_Electric, SumAirCond_Addition, SumRepairandMaintenance,")
        col.Append("SumRMOther_Fix, SumRMOther_Unplan, SumRMComputer_Fix, SumRMComputer_Unplan, SumProfessionalFee, SumMarketingResearch, SumOtherFee,")
        col.Append("SumEquipment_MaterailandSupplies, SumPrintingandStationery, SumSuppliesExpenses, SumEquipment, SumShopfitting, SumPackagingandOtherMaterial,")
        col.Append("SumBusinessTravelExpenses, SumCarParkingandOthers, SumTravel, SumAccomodation, SumMealandEntertainment, SumInsurance, SumAllRiskInsurance,")
        col.Append("SumHealthandLifeInsurance, SumPenaltyandTaxation, SumTaxation, SumPenalty, SumOtherRelatedStaffCost, SumStaffConferenceandTraining, SumTraining,")
        col.Append("SumCommunication, SumTelephoneCalls_Faxes, SumPostageandCourier, SumOtherExpenses, SumSample_Tester, SumPreopeningCosts, SumLossonClaim,")
        col.Append("SumCashOvertage_Shortagefromsales, SumMiscellenousandOther, SumStoreTradingProfit__Loss,") ' SumTradingProfit__Loss, SumStoreControllableCostsforBSC,")
        'col.Append("SumStoreLabourCost, SumUtillity, SumRepairMaintenance, ")
        col.Append("SumSWMaintenance, SumHWMaintenance, SumITTelecommunications ")
        Return col.ToString
    End Function
#End Region

#Region "Store"

    Public Shared Function getLFLGrowthByCostCenterId(ByVal years As String, ByVal mon As String, costcenter_id As String) As DataTable
        'store_id = format
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""

        sqlCol = "select SUM(TotalRevenue) as SumRevenue,SUM(StoreTradingProfit__Loss) as SumLoss,month_time, "
        sqlPtype = "ptype = cast( year(@thisyear) as varchar),cb.costcenter_id "
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
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
" AND (cb.costcenter_id = @costcenter_id )"
        sqlCondition2 = "GROUP BY month_time ,cb.costcenter_id )g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar),cb.costcenter_id  " & _
            "from mtd dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by month_time ,cb.costcenter_id )g2 on g1.costcenter_id = g2.costcenter_id"

        sql = "select g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2,g1.SumLoss as loss1,g2.SumLoss as loss2,g1.costcenter_id as store_id,cast( month( g1.month_time) as varchar)+'/' +  cast(year(g1.month_time) as varchar) as month_time from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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

        parameter = New SqlParameter("@costcenter_id", SqlDbType.VarChar)
        parameter.Value = costcenter_id
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

    Public Shared Function getYoyByCostCenterId(ByVal bDate As String, ByVal eDate As String, ByVal costcenter_id As String, rate As String) As DataTable

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sql As String = "select * from ( " & _
"select COUNT(mt.costcenter_id) as cnum, " & _
"SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumLoss, cast( month(month_time) as varchar)+'/' +  cast(year(month_time) as varchar) as month_time,mt.costcenter_id,costcenter_store  " & _
"from ( " & _
"select mta.* " & _
"from " + sqlTbl + " mta,costcenter cca " & _
" where mta.costcenter_id = cca.costcenter_id AND cca.costcenter_id = @costcenter_id AND " & _
"cca.costcenter_blockdt Is null And " & _
"mta.month_time <= @select_dt and " & _
"mta.month_time >= @start_time " & _
" union " & _
"select mtb.* " & _
"from " + sqlTbl + " mtb,costcenter ccb " & _
"where mtb.costcenter_id = ccb.costcenter_id And ccb.costcenter_id = @costcenter_id And " & _
"ccb.costcenter_blockdt >= @sl_dt and " & _
"mtb.month_time <= @select_dt and " & _
"mtb.month_time >= @start_time " & _
") mt,costcenter cc  " & _
"where mt.costcenter_id = cc.costcenter_id AND cc.costcenter_id = @costcenter_id " & _
" and cc.costcenter_opendt < @sl_dt " & _
"group by mt.month_time ,mt.costcenter_id,costcenter_store " & _
") bb,store st1 " & _
"where bb.costcenter_store = st1.store_id and st1.store_other='N' order by st1.store_order asc"


        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        'get yoy last year
        Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing).AddYears(-1)
        Dim endDate As DateTime = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing).AddYears(-1)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        'parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        'If mon = "12" Then
        '    parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        'Else
        '    parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        'End If
        parameter.Value = endDate.AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@costcenter_id", SqlDbType.VarChar)
        parameter.Value = costcenter_id
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim drTotal As DataRow = dt.NewRow
                drTotal("costcenter_store") = 0
                drTotal("store_id") = 0
                drTotal("store_name") = reportPart.Total.ToString
                drTotal("SumTotalRevenue") = IIf(dt.Compute("Sum(SumTotalRevenue)", "").ToString = "", 0, dt.Compute("Sum(SumTotalRevenue)", ""))
                drTotal("SumLoss") = IIf(dt.Compute("Sum(SumLoss)", "").ToString = "", 0, dt.Compute("Sum(SumLoss)", ""))
                drTotal("month_time") = beginDate.AddYears(1).ToString("M/yyyy")
                dt.Rows.Add(drTotal)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            cmd.Dispose()
            da.Dispose()
        End Try
    End Function

    Public Shared Function getYoyTotalByCostCenterId(ByVal bDate As String, ByVal eDate As String, ByVal costCenter_id As String, rate As String) As DataTable
        'In Report Column "% YOY"
        Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
        Dim endDate As DateTime = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing)

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sqlCon As String = ""
        Dim sql As String = ""
        Dim sqlCon1 As String = ""
        Dim sqlCon2 As String = ""
        Dim sqlCol As String = ""

        sqlCol = "SELECT " + columnModelSum()
        sqlCon1 = String.Format(",{0} as years " & _
"from " + sqlTbl + " mt,costcenter cc,store st " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  AND " & _
"month_time between @begin_dt and @end_dt " & _
" and cc.costcenter_opendt < @sl_dt and cc.costcenter_id = @costcenter_id " & _
" and cc.costcenter_store=st.store_id and st.store_other='N' ", endDate.Year)

        sqlCon2 = String.Format(",{0} as years " & _
"from " + sqlTbl + " mt,costcenter cc,store st " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt2 )  AND " & _
"month_time between @begin_dt2 and @end_dt2  " & _
" and cc.costcenter_opendt < @sl_dt2 and cc.costcenter_id = @costcenter_id " & _
" and cc.costcenter_store=st.store_id and st.store_other='N' ", endDate.Year - 1)

        sql = "select * from (" + sqlCol + sqlCon1 + " UNION " + sqlCol + sqlCon2 + ") yoy order by years DESC"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)


        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
        parameter.Value = endDate.AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        parameter.Value = endDate.AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@begin_dt", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@end_dt", SqlDbType.DateTime)
        parameter.Value = endDate.AddMonths(1).AddDays(-1)
        cmd.Parameters.Add(parameter)

        'paramiter2
        parameter = New SqlParameter("@block_dt2", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1).AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt2", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1).AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@begin_dt2", SqlDbType.DateTime)
        parameter.Value = beginDate.AddYears(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@end_dt2", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1).AddMonths(1).AddDays(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@costcenter_id", SqlDbType.VarChar)
        parameter.Value = costCenter_id
        cmd.Parameters.Add(parameter)

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
                            If dt.Rows(0)(0) = 0 Or dt.Rows(1)(0) = 0 Then
                                dr(i) = 0
                            Else
                                thisPb = num / dt.Rows(0)(0)
                                prePb = divi / dt.Rows(1)(0)
                                pb = (thisPb - prePb) * 10000
                                dr(i) = pb
                            End If

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

    Public Shared Function getStore(ByVal bDate As String, ByVal eDate As String, ByVal cost_id As String, Optional rate As String = "") As DataSet

        Dim years As String = eDate.Split("/")(1)
        Dim mon As String = eDate.Split("/")(0)

        Dim start_time As String = "1/" + bDate
        Dim end_time As String = "1/" + eDate
        Dim totalDate As DateTime = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing).AddYears(1) 'สมมุุติให้ total

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sql As String = "SELECT *,'N/A' as lfl_growth,'0.0%' as yoy_growth,'N/A' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
        "SELECT month_time, COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store ,costcenter_store as store_id,costcenter_code as store_code,costcenter_name as store_name, " & _
        "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area) end as productivity," & _
        "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
        "" + columnModelSum() + "" & _
        " from " + sqlTbl + " mt,costcenter cc " & _
        "where mt.costcenter_id = cc.costcenter_id and cc.costcenter_id='" + cost_id + "' and mt.month_time >='" + DateTime.ParseExact(bDate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(eDate, "M/yyyy", Nothing) + "' " & _
        "group by month_time,costcenter_store,costcenter_code,costcenter_name) sm order by sm.month_time asc "


        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(end_time, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing).AddMonths(1)
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable

        Try
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

                Dim monthDiff As Integer = 1 + DateDiff(DateInterval.Month, DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing), DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing))
                If dt.Compute("Sum(sumsalearea)", "").ToString = "" OrElse dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = (dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")) / monthDiff
                End If

            '3 column ต้องเท่ากันทุก ทุกเดือน
            drTotal("cnum") = 1 'only 1
            drTotal("sumsalearea") = dt.Rows(0)("sumsalearea")
            drTotal("Sumtotalarea") = dt.Rows(0)("Sumtotalarea")

            drTotal("store_id") = 0
            drTotal("costcenter_store") = 0
            drTotal("store_name") = reportPart.Total.ToString
            drTotal("month_time") = totalDate
            dt.Rows.Add(drTotal)

            'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
            'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
            Dim colStoreId As String = "store_id"
            Dim colRev1 As String = "rev1"
            Dim colRev2 As String = "rev2"
            Dim colLoss1 As String = "loss1"
            Dim colLoss2 As String = "loss2"

            Dim dtLFL As New DataTable
            Dim store_id As String = ""
            Dim dtTemp As New DataTable : dtTemp = Nothing

            Dim endDate As DateTime = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing)
            Dim tempDate As DateTime = DateTime.ParseExact(end_time, ClsManage.formatDateTime, Nothing)

            While (tempDate >= endDate)
                dtLFL = getLFLGrowthByCostCenterId(tempDate.Year, tempDate.Month, cost_id)

                If dtTemp Is Nothing Then
                    dtTemp = dtLFL
                Else
                    dtTemp.Merge(dtLFL)
                End If
                tempDate = tempDate.AddMonths(-1)
            End While

            dtLFL = dtTemp
            'summary last row
            Dim drSum As DataRow = dtLFL.NewRow
            drSum(colRev1) = IIf(dtLFL.Compute("Sum(" + colRev1 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colRev1 + ")", ""))
            drSum(colRev2) = IIf(dtLFL.Compute("Sum(" + colRev2 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colRev2 + ")", ""))
            drSum(colLoss1) = IIf(dtLFL.Compute("Sum(" + colLoss1 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colLoss1 + ")", ""))
            drSum(colLoss2) = IIf(dtLFL.Compute("Sum(" + colLoss2 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colLoss2 + ")", ""))
            drSum(colStoreId) = 0  'สมมุติให้เป็น store id = 0
            drSum("month_time") = totalDate.ToString("M/yyyy")
            dtLFL.Rows.Add(drSum)

            'Dividing each row
            Dim rev1 As Double = 0 : Dim rev2 As Double = 0 : Dim loss1 As Double = 0 : Dim loss2 As Double = 0
            For Each dr As DataRow In dtLFL.Rows
                rev1 = IIf(IsDBNull(dr(0)), 0, dr(0))
                rev2 = IIf(IsDBNull(dr(1)), 0, dr(1))
                loss1 = IIf(IsDBNull(dr(2)), 0, dr(2))
                loss2 = IIf(IsDBNull(dr(3)), 0, dr(3))

                If rev1 <> 0 And rev2 <> 0 Then
                    dr(colRev1) = (rev1 / rev2) - 1
                Else
                    dr(colRev1) = 0
                End If

                If loss1 <> 0 And loss2 <> 0 Then
                    dr(colLoss1) = (loss1 / loss2) - 1
                Else
                    dr(colLoss1) = 0
                End If
            Next

            'change condition from store_id to month_time 
            store_id = ""
            If dtLFL.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If Not IsDBNull(dr("month_time")) = True Then
                        store_id = CDate(dr("month_time")).ToString("M/yyyy")
                    Else
                        store_id = ""
                    End If

                    If dtLFL.Select("month_time = '" + store_id + "' ").Length > 0 Then
                        dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(dtLFL.Select("month_time = '" + store_id + "' ")(0)(colRev1))
                        dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(dtLFL.Select("month_time = '" + store_id + "' ")(0)(colLoss1))
                    Else
                        If dr("store_name") = clsBts.reportPart.Total.ToString Then
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If

                    End If
                Next
            Else

            End If

            'Cal YOY Growth ( Columns --> % Revenue Growth-YOY" in report in Report )
            'Cal YOY Loss Growth ( Columns --> % Store Trading Profit Growth-YOY in Report )
            Dim dtPreYtd As New DataTable
            dtPreYtd = getYoyByCostCenterId(start_time, end_time, cost_id, rate)

            rev1 = 0 : rev2 = 0 : loss1 = 0 : loss2 = 0
            Dim costcenterStore As String = ""
            If dtPreYtd.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows

                    If Not IsDBNull(dr("month_time")) = True Then
                        costcenterStore = CDate(dr("month_time")).AddYears(-1).ToString("M/yyyy") 'Addyear for compare
                    Else
                        costcenterStore = ""
                    End If

                    If dtPreYtd.Select("month_time = '" + costcenterStore + "' ").Length > 0 Then
                        rev1 = IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
                        rev2 = IIf(IsDBNull(dtPreYtd.Select("month_time = '" + costcenterStore + "' ")(0)("SumTotalRevenue")), 0, dtPreYtd.Select("month_time = '" + costcenterStore + "' ")(0)("SumTotalRevenue"))

                        loss1 = IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))
                        loss2 = IIf(IsDBNull(dtPreYtd.Select("month_time = '" + costcenterStore + "' ")(0)("SumLoss")), 0, dtPreYtd.Select("month_time = '" + costcenterStore + "' ")(0)("SumLoss"))

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
            End If

            Dim ds As New DataSet
            Dim dtTotal As New DataTable
            dtTotal = dt.Clone
            'แยก row ที่เป็น total ออกไปอีก table
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("costcenter_store") = 0 Then
                    dtTotal.ImportRow(dt.Rows(i))
                    dt.Rows(i).Delete()
                End If
            Next
            dt.AcceptChanges()
            ds.Tables.Add(dt)
            ds.Tables(0).TableName = reportPart.Item.ToString

            'Add Total YOY
            Dim drTotalYoy As Data.DataRow
            'drTotalYoy = clsBts.getYoyYtdTotal(years, mon, "", rate).Rows(2)
            drTotalYoy = getYoyTotalByCostCenterId(start_time, end_time, cost_id, rate).Rows(2)
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
            ds.Tables(1).TableName = reportPart.Total.ToString
            dt.Dispose() : dtTotal.Dispose()
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

#End Region

#Region "Province By Store Report"
    Public Shared Function getLFLGrowthByProvince(ByVal years As String, ByVal mon As String, province_id As String) As DataTable
        'store_id = format
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""

        sqlCol = "select SUM(TotalRevenue) as SumRevenue,SUM(StoreTradingProfit__Loss) as SumLoss,month_time, "
        sqlPtype = "ptype = cast( year(@thisyear) as varchar),cb.costcenter_id "
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
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
" AND (cb.costcenter_province = @costcenter_province )"
        sqlCondition2 = "GROUP BY month_time ,cb.costcenter_province,cb.costcenter_id)g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar),cb.costcenter_id  " & _
            "from mtd dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by month_time ,cb.costcenter_id )g2 on g1.costcenter_id = g2.costcenter_id"

        sql = "select g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2,g1.SumLoss as loss1,g2.SumLoss as loss2,g1.costcenter_id as store_id,cast( month( g1.month_time) as varchar)+'/' +  cast(year(g1.month_time) as varchar) as month_time from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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

        parameter = New SqlParameter("@costcenter_province", SqlDbType.Int)
        parameter.Value = province_id
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

    Public Shared Function getProvince(ByVal bDate As String, ByVal eDate As String, ByVal province_id As String, Optional rate As String = "") As DataSet

        Dim years As String = eDate.Split("/")(1)
        Dim mon As String = eDate.Split("/")(0)

        Dim sqlCost_id As String = ""
        If province_id <> "" Then
            sqlCost_id = "and cc.costcenter_province=" + province_id
        End If

        Dim start_time As String = "1/" + bDate
        Dim end_time As String = "1/" + eDate
        Dim totalDate As DateTime = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing).AddYears(1) 'สมมุุติให้ total

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sql As String = "SELECT *,'N/A' as lfl_growth,'0.0%' as yoy_growth,'N/A' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
        "SELECT getdate() as month_time ,COUNT(DISTINCT cc.costcenter_id) as cnum ,costcenter_province as costcenter_store," & _
        "cc.costcenter_id as store_id,costcenter_code as store_code,costcenter_name as store_name, " & _
        "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area) end as productivity," & _
        "costcenter_total_area as Sumtotalarea,costcenter_sale_area as Sumsalearea, " & _
        "" + columnModelSum() + "" & _
        " from " + sqlTbl + " mt,costcenter cc " & _
        "where mt.costcenter_id = cc.costcenter_id " + sqlCost_id & _
        "and mt.month_time >='" + DateTime.ParseExact(bDate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(eDate, "M/yyyy", Nothing) + "' " & _
        "and costcenter_opendt <= dateadd(day,-1,dateadd(month,1,@start_time)) " & _
        "group by cc.costcenter_id, costcenter_province,costcenter_code,costcenter_name,costcenter_total_area,costcenter_sale_area) sm order by store_code asc "

        'and costcenter_opendt <= dateadd(day,-1,dateadd(month,1,@bDate)) >>> ดูการเปิดร้านจากเดือน ไม่สนใจวัน เลยสร้างเงื่อนไขให้เป็นวันสุดท้่ายของเดือน
        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(end_time, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing).AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@cost_id", SqlDbType.VarChar)
        parameter.Value = province_id
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable

        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then

                ''for loop  set % Growth
                'For Each dr As DataRow In dt.Rows
                '    'If dr("costcenter_code").ToString = "3975" Then
                '    '    Dim a As String = ""
                '    'End If
                '    dr("lfl_growth") = ClsManage.convert2PercenGrowth(dr("lfl_growth"), ClsManage.growthType.LFL)
                '    dr("yoy_growth") = ClsManage.convert2PercenGrowth(dr("yoy_growth"), ClsManage.growthType.YOY)
                '    dr("lfl_loss_growth") = ClsManage.convert2PercenGrowthTradingProfit(dr("lfl_loss_growth"), ClsManage.growthType.LFL, dr("SumStoreTradingProfit__Loss"), dr("lfl_Loss"))
                '    dr("yoy_loss_growth") = ClsManage.convert2PercenGrowthTradingProfit(dr("yoy_loss_growth"), ClsManage.growthType.YOY, dr("SumStoreTradingProfit__Loss"), dr("yoy_Loss"))
                'Next

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

                Dim monthDiff As Integer = 1 + DateDiff(DateInterval.Month, DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing), DateTime.ParseExact(end_time, ClsManage.formatDateTime, Nothing))
                If dt.Compute("Sum(sumsalearea)", "").ToString = "" OrElse dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = (dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")) / monthDiff
                End If

                '3 column ต้องเท่ากันทุก ทุกเดือน
                drTotal("cnum") = dt.Compute("Sum(cnum)", "")
                drTotal("sumsalearea") = dt.Compute("Sum(sumsalearea)", "") ' dt.Rows(0)("sumsalearea")
                drTotal("Sumtotalarea") = dt.Compute("Sum(Sumtotalarea)", "") ' dt.Rows(0)("Sumtotalarea")

                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = reportPart.Total.ToString
                drTotal("month_time") = totalDate
                dt.Rows.Add(drTotal)

                'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
                'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
                Dim colStoreId As String = "store_id"
                Dim colRev1 As String = "rev1"
                Dim colRev2 As String = "rev2"
                Dim colLoss1 As String = "loss1"
                Dim colLoss2 As String = "loss2"

                Dim dtLFL As New DataTable
                Dim store_id As String = ""
                Dim dtTemp As New DataTable : dtTemp = Nothing

                Dim endDate As DateTime = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing)
                Dim tempDate As DateTime = DateTime.ParseExact(end_time, ClsManage.formatDateTime, Nothing)

                While (tempDate >= endDate)
                    dtLFL = getLFLGrowthByProvince(tempDate.Year, tempDate.Month, province_id)

                    If dtTemp Is Nothing Then
                        dtTemp = dtLFL
                    Else
                        dtTemp.Merge(dtLFL)
                    End If
                    tempDate = tempDate.AddMonths(-1)
                End While

                dtLFL = dtTemp
                'summary last row
                Dim drSum As DataRow = dtLFL.NewRow
                drSum(colRev1) = IIf(dtLFL.Compute("Sum(" + colRev1 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colRev1 + ")", ""))
                drSum(colRev2) = IIf(dtLFL.Compute("Sum(" + colRev2 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colRev2 + ")", ""))
                drSum(colLoss1) = IIf(dtLFL.Compute("Sum(" + colLoss1 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colLoss1 + ")", ""))
                drSum(colLoss2) = IIf(dtLFL.Compute("Sum(" + colLoss2 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colLoss2 + ")", ""))
                drSum(colStoreId) = 0  'สมมุติให้เป็น store id = 0
                drSum("month_time") = totalDate.ToString("M/yyyy")
                dtLFL.Rows.Add(drSum)

                'Dividing each row
                Dim rev1 As Double = 0 : Dim rev2 As Double = 0 : Dim loss1 As Double = 0 : Dim loss2 As Double = 0
                For Each dr As DataRow In dtLFL.Rows
                    rev1 = IIf(IsDBNull(dr(0)), 0, dr(0))
                    rev2 = IIf(IsDBNull(dr(1)), 0, dr(1))
                    loss1 = IIf(IsDBNull(dr(2)), 0, dr(2))
                    loss2 = IIf(IsDBNull(dr(3)), 0, dr(3))

                    If rev1 <> 0 And rev2 <> 0 Then
                        dr(colRev1) = (rev1 / rev2) - 1
                    Else
                        dr(colRev1) = 0
                    End If

                    If loss1 <> 0 And loss2 <> 0 Then
                        dr(colLoss1) = (loss1 / loss2) - 1
                    Else
                        dr(colLoss1) = 0
                    End If
                Next

                'change condition from store_id =  costcenter_id
                store_id = ""
                If dtLFL.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        store_id = dr("store_id").ToString
                        If dtLFL.Select("store_id = '" + store_id + "' ").Length > 0 Then
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(dtLFL.Select("store_id = '" + store_id + "' ")(0)(colRev1))
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(dtLFL.Select("store_id = '" + store_id + "' ")(0)(colLoss1))
                        Else
                            If dr("store_name") = clsBts.reportPart.Total.ToString Then
                                dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
                                dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            End If

                        End If
                    Next
                Else

                End If

                'Cal YOY Growth ( Columns --> % Revenue Growth-YOY" in report in Report )
                'Cal YOY Loss Growth ( Columns --> % Store Trading Profit Growth-YOY in Report )
                Dim dtPreYtd As New DataTable
                dtPreYtd = getYoyByProvinceId(start_time, end_time, province_id, rate)

                rev1 = 0 : rev2 = 0 : loss1 = 0 : loss2 = 0
                Dim costcenterStore As String = ""
                If dtPreYtd.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        costcenterStore = dr("store_id").ToString
                        If dtPreYtd.Select("costcenter_id = '" + costcenterStore + "' ").Length > 0 Then
                            rev1 = IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
                            rev2 = IIf(IsDBNull(dtPreYtd.Select("costcenter_id = '" + costcenterStore + "' ")(0)("SumTotalRevenue")), 0, dtPreYtd.Select("costcenter_id = '" + costcenterStore + "' ")(0)("SumTotalRevenue"))

                            loss1 = IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))
                            loss2 = IIf(IsDBNull(dtPreYtd.Select("costcenter_id = '" + costcenterStore + "' ")(0)("SumLoss")), 0, dtPreYtd.Select("costcenter_id = '" + costcenterStore + "' ")(0)("SumLoss"))

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
            End If

            Dim ds As New DataSet
            Dim dtTotal As New DataTable
            dtTotal = dt.Clone
            'แยก row ที่เป็น total ออกไปอีก table22
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("costcenter_store") = 0 Then
                    dtTotal.ImportRow(dt.Rows(i))
                    dt.Rows(i).Delete()
                End If
            Next
            dt.AcceptChanges()
            ds.Tables.Add(dt)
            ds.Tables(0).TableName = reportPart.Item.ToString

            'Add Total YOY
            Dim drTotalYoy As Data.DataRow
            'drTotalYoy = clsBts.getYoyYtdTotal(years, mon, "", rate).Rows(2)
            drTotalYoy = getYoyTotalByProvinceId(start_time, end_time, province_id, rate).Rows(2)
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
            ds.Tables(1).TableName = reportPart.Total.ToString
            dt.Dispose() : dtTotal.Dispose()
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getYoyByProvinceId(ByVal bDate As String, ByVal eDate As String, ByVal province_id As String, rate As String) As DataTable

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sql As String = "select * from ( " & _
"select COUNT(mt.costcenter_id) as cnum, " & _
"SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumLoss, cast( month(month_time) as varchar)+'/' +  cast(year(month_time) as varchar) as month_time,mt.costcenter_id,costcenter_store  " & _
"from ( " & _
"select mta.* " & _
"from " + sqlTbl + " mta,costcenter cca " & _
" where mta.costcenter_id = cca.costcenter_id AND cca.costcenter_province = @province_id AND " & _
"cca.costcenter_blockdt Is null And " & _
"mta.month_time <= @select_dt and " & _
"mta.month_time >= @start_time " & _
" union " & _
"select mtb.* " & _
"from " + sqlTbl + " mtb,costcenter ccb " & _
"where mtb.costcenter_id = ccb.costcenter_id And ccb.costcenter_province = @province_id And " & _
"ccb.costcenter_blockdt >= @sl_dt and " & _
"mtb.month_time <= @select_dt and " & _
"mtb.month_time >= @start_time " & _
") mt,costcenter cc  " & _
"where mt.costcenter_id = cc.costcenter_id AND cc.costcenter_province = @province_id " & _
" and cc.costcenter_opendt < @sl_dt " & _
"group by mt.month_time ,mt.costcenter_id,costcenter_store " & _
") bb,store st1 " & _
"where bb.costcenter_store = st1.store_id and st1.store_other='N' order by st1.store_order asc"


        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        'get yoy last year
        Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing).AddYears(-1)
        Dim endDate As DateTime = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing).AddYears(-1)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
      
        parameter.Value = endDate.AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@province_id", SqlDbType.VarChar)
        parameter.Value = province_id
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim drTotal As DataRow = dt.NewRow
                drTotal("costcenter_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_id") = 0
                drTotal("store_name") = reportPart.Total.ToString
                drTotal("SumTotalRevenue") = IIf(dt.Compute("Sum(SumTotalRevenue)", "").ToString = "", 0, dt.Compute("Sum(SumTotalRevenue)", ""))
                drTotal("SumLoss") = IIf(dt.Compute("Sum(SumLoss)", "").ToString = "", 0, dt.Compute("Sum(SumLoss)", ""))
                drTotal("month_time") = beginDate.AddYears(1).ToString("M/yyyy")
                dt.Rows.Add(drTotal)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            cmd.Dispose()
            da.Dispose()
        End Try
    End Function

    Public Shared Function getYoyTotalByProvinceId(ByVal bDate As String, ByVal eDate As String, ByVal province_id As String, rate As String) As DataTable
        'In Report Column "% YOY"
        Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
        Dim endDate As DateTime = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing)

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sqlCon As String = ""
        Dim sql As String = ""
        Dim sqlCon1 As String = ""
        Dim sqlCon2 As String = ""
        Dim sqlCol As String = ""

        sqlCol = "SELECT " + columnModelSum()
        sqlCon1 = String.Format(",{0} as years " & _
"from " + sqlTbl + " mt,costcenter cc,store st " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  AND " & _
"month_time between @begin_dt and @end_dt " & _
" and cc.costcenter_opendt < @sl_dt and cc.costcenter_province = @costcenter_province " & _
" and cc.costcenter_store=st.store_id and st.store_other='N' ", endDate.Year)

        sqlCon2 = String.Format(",{0} as years " & _
"from " + sqlTbl + " mt,costcenter cc,store st " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt2 )  AND " & _
"month_time between @begin_dt2 and @end_dt2  " & _
" and cc.costcenter_opendt < @sl_dt2 and cc.costcenter_province = @costcenter_province " & _
" and cc.costcenter_store=st.store_id and st.store_other='N' ", endDate.Year - 1)

        sql = "select * from (" + sqlCol + sqlCon1 + " UNION " + sqlCol + sqlCon2 + ") yoy order by years DESC"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)


        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
        parameter.Value = endDate.AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        parameter.Value = endDate.AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@begin_dt", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@end_dt", SqlDbType.DateTime)
        parameter.Value = endDate.AddMonths(1).AddDays(-1)
        cmd.Parameters.Add(parameter)

        'paramiter2
        parameter = New SqlParameter("@block_dt2", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1).AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt2", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1).AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@begin_dt2", SqlDbType.DateTime)
        parameter.Value = beginDate.AddYears(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@end_dt2", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1).AddMonths(1).AddDays(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@costcenter_province", SqlDbType.VarChar)
        parameter.Value = province_id
        cmd.Parameters.Add(parameter)

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
                            If dt.Rows(0)(0) = 0 Or dt.Rows(1)(0) = 0 Then
                                dr(i) = 0
                            Else
                                thisPb = num / dt.Rows(0)(0)
                                prePb = divi / dt.Rows(1)(0)
                                pb = (thisPb - prePb) * 10000
                                dr(i) = pb
                            End If

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

#End Region

#Region "Main Report"

    Public Shared Function getModelMtd(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String) As DataSet

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sql As String = "SELECT *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
            "SELECT COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store,SUM(TotalRevenue)/SUM(costcenter_sale_area) as productivity, " & _
            "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
            "" + columnModelSum() + "" & _
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
                drTotal("store_name") = reportPart.Total.ToString
                dt.Rows.Add(drTotal)

                'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
                'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
                Dim strore_id As String = ""
                dtlflG = getLFLGrowth(years, mon, locate)

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
                dtPreMtd = getYoyMtd(years - 1, mon, locate, rate)
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
                ds.Tables(0).TableName = reportPart.Item.ToString

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
                ds.Tables(1).TableName = reportPart.Total.ToString

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

    Public Shared Function getModelLocation(ByVal years As String, ByVal mon As String, rate As String, toDateBy As String) As DataSet
        Try
            Select Case toDateBy
                Case reportType.MTD.ToString
                    Return getModelMtdLocation(years, mon, rate, _
                                               getModelMtd(years, mon, "", rate), _
                                               getModelMtd(years, mon, location.Bangkok, rate), _
                                               getModelMtd(years, mon, location.Upcountry, rate))
                Case reportType.YTD.ToString
                    Return getModelMtdLocation(years, mon, rate, _
                                              getModelYtd(years, mon, "", rate), _
                                              getModelYtd(years, mon, location.Bangkok, rate), _
                                              getModelYtd(years, mon, location.Upcountry, rate))
                Case Else
                    Return Nothing
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Shared Function getModelMtdLocation(ByVal years As String, ByVal mon As String, rate As String, dsTal As DataSet, dsBk As DataSet, dsUc As DataSet) As DataSet

        'Create 3 dataset -->All,bangkok,upcountry
        'แยก เป็นสอง table total , item เอามารวมกันไว้เป็น dataset
        'เรียงลำดับใน item ให้จับเป็นคู่ ตาม format in dsTal

        Dim dtBk As New DataTable
        Dim dtUc As New DataTable
        Dim dtItem As New DataTable
        Dim dtTal As New DataTable

        Try
            'dsTal = getModelMtd(years, mon, "", rate)
            'dsBk = getModelMtd(years, mon, location.Bangkok, rate)
            'dsUc = getModelMtd(years, mon, location.Upcountry, rate)

            dtBk = dsBk.Tables(reportPart.Item.ToString)
            Dim colBk As New DataColumn("location_id", Type.GetType("System.Int32"))
            colBk.DefaultValue = 1
            dtBk.Columns.Add(colBk)

            dtUc = dsUc.Tables(reportPart.Item.ToString)
            Dim colUc As New DataColumn("location_id", Type.GetType("System.Int32"))
            colUc.DefaultValue = 2
            dtUc.Columns.Add(colUc)

            dtBk.Merge(dtUc)
            dtItem = dtBk.Clone
            Dim store_id As String = "" : Dim locationName As String = ""

            For Each dr As DataRow In dsTal.Tables(reportPart.Item.ToString).Rows
                store_id = dr("store_id").ToString
                'add sum for each location
                dtItem.ImportRow(dr)
                dtItem.Rows(dtItem.Rows.Count - 1)("store_name") = dr("store_name").ToString + "<br/>(Total)" ' String.Format("</br>({0})", locationName + "..")

                For i As Integer = 1 To 2
                    locationName = IIf(i = 1, location.Bangkok.ToString, location.Upcountry.ToString)
                    If dtBk.Select("store_id = " + store_id + " and location_id = " + i.ToString + " ").Length > 0 Then
                        dtItem.ImportRow(dtBk.Select("store_id = " + dr("store_id").ToString + " and location_id = " + i.ToString + " ")(0))
                        dtItem.Rows(dtItem.Rows.Count - 1)("store_name") = dr("store_name").ToString + String.Format("<br/>({0})", locationName)
                    Else
                        Dim drItem As DataRow = dtItem.NewRow
                        drItem("store_id") = store_id
                        drItem("location_id") = i
                        drItem("cnum") = 0
                        drItem("store_name") = dr("store_name").ToString + String.Format("<br/>({0})", locationName)
                        drItem("productivity") = 0
                        For j As Integer = 0 To drItem.ItemArray.Count - 1
                            If drItem.Table.Columns(j).ColumnName.Contains("Sum") Then
                                drItem(j) = 0
                            End If
                            If drItem.Table.Columns(j).ColumnName.Contains("growth") Then
                                drItem(j) = "0.0%"
                            End If
                        Next
                        dtItem.Rows.Add(drItem)
                    End If
                Next
            Next
            dsTal.Tables(reportPart.Total.ToString).Rows(0)("store_name") = "Total<br/>(All)"
            dsBk.Tables(reportPart.Total.ToString).Rows(0)("store_name") = "Total" + String.Format("<br/>({0})", location.Bangkok.ToString)
            dsUc.Tables(reportPart.Total.ToString).Rows(0)("store_name") = "Total" + String.Format("<br/>({0})", location.Upcountry.ToString)

            'set store_id
            dsBk.Tables(reportPart.Total.ToString).Rows(0)("store_id") = -1
            dsBk.Tables(reportPart.Total.ToString).Rows(1)("store_id") = -1
            dsUc.Tables(reportPart.Total.ToString).Rows(0)("store_id") = -2
            dsUc.Tables(reportPart.Total.ToString).Rows(1)("store_id") = -2

            dtTal = dsTal.Tables(reportPart.Total.ToString)
            dtTal.Merge(dsBk.Tables(reportPart.Total.ToString))
            dtTal.Merge(dsUc.Tables(reportPart.Total.ToString))

            dsTal.Tables.Clear()
            dsTal.Tables.Add(dtItem)

            dsTal.Tables.Add(dtTal)
            Return dsTal

        Catch ex As Exception
            Throw ex
        Finally
            dsTal.Dispose()
            dsBk.Dispose()
            dsUc.Dispose()
            dtBk.Dispose()
            dtUc.Dispose()
            dtItem.Dispose()
            dtTal.Dispose()
        End Try
    End Function

    Public Shared Function getModelYtd(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String) As DataSet

        Dim start_time As String = ""
        If mon < 4 Then
            start_time = "1/4/" + (years - 1).ToString
        Else
            start_time = "1/4/" + years
        End If

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        If locate <> "" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
        "   select  COUNT(DISTINCT cs.costcenter_id) as cnum, cs.costcenter_store, " & _
        "	SUM(cs.costcenter_total_area) as Sumtotalarea,  " & _
        "	SUM(cs.costcenter_sale_area) as Sumsalearea,  " & _
  "(SUM(SumTotalRevenue)/SUM(cs.costcenter_sale_area))/(DATEDIFF(month,@start_time,@select_dt)+1) as productivity, " & _
  "" + columnMtdSumInSum() + "" & _
        " from ( " & _
        "select mt.costcenter_id, " & _
  "SUM(costcenter_total_area) as sumtotalarea, " & _
  "SUM(costcenter_sale_area) as sumsalearea, " & _
  "" + columnModelSum() + "" & _
        " from ( " & _
        "select mta.* " & _
        "from " + sqlTbl + " mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "cca.costcenter_blockdt Is null and " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= @start_time   " & _
        " union " & _
        "select mtb.* " & _
        "from " + sqlTbl + " mtb,costcenter ccb " & _
        "where mtb.costcenter_id = ccb.costcenter_id And " & _
        "ccb.costcenter_blockdt >= @sl_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= @start_time  " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id " & _
        " " + area + " " & _
        " and cc.costcenter_opendt < @sl_dt " & _
        "group by mt.costcenter_id " & _
        ") mt2,costcenter cs " & _
        "where mt2.costcenter_id = cs.costcenter_id " & _
        "group by cs.costcenter_store " & _
        ") bb,store st1 " & _
        "where bb.costcenter_store = st1.store_id and st1.store_other='N' order by store_order"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If

        cmd.Parameters.Add(parameter)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable

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

                Dim monthDiff As Integer = 1 + DateDiff(DateInterval.Month, DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing), DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing))
                If dt.Compute("Sum(sumsalearea)", "").ToString = "" OrElse dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = (dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")) / monthDiff
                End If
                drTotal("cnum") = IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", "")) - IIf(dt.Compute("Sum(cnum)", "store_id=8").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id=8"))

                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = reportPart.Total.ToString
                dt.Rows.Add(drTotal)

                'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
                'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
                Dim colStoreId As String = "store_id"
                Dim colRev1 As String = "rev1"
                Dim colRev2 As String = "rev2"
                Dim colLoss1 As String = "loss1"
                Dim colLoss2 As String = "loss2"

                Dim dtLFL As New DataTable
                Dim store_id As String = ""
                Dim beginYear As Integer = years
                Dim beginMon As Integer = 4
                Dim dtTemp As New DataTable : dtTemp = Nothing

                If Integer.Parse(mon) < 4 Then
                    beginYear = Integer.Parse(years) - 1
                End If
                Dim endDate As DateTime = DateTime.ParseExact(("1/" + beginMon.ToString + "/" + beginYear.ToString), ClsManage.formatDateTime, Nothing)
                Dim tempDate As DateTime = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)

                While (tempDate >= endDate)
                    dtLFL = getLFLGrowthForYtd(tempDate.Year, tempDate.Month, locate)

                    If dtTemp Is Nothing Then
                        dtTemp = dtLFL
                    Else
                        dtTemp.Merge(dtLFL)
                    End If
                    tempDate = tempDate.AddMonths(-1)
                End While
                dtLFL = Nothing
                dtLFL = dtTemp.Clone
                Dim iRow As Integer = -1
                For Each drTemp As DataRow In dtTemp.Rows
                    store_id = drTemp(colStoreId).ToString
                    If dtLFL.Select("store_id = " + store_id + " ").Length = 0 Then
                        dtLFL.ImportRow(drTemp)
                    Else
                        'Find duplicate rows for summary
                        For i = 0 To dtLFL.Rows.Count - 1
                            If store_id = dtLFL.Rows(i)(colStoreId) Then
                                iRow = i
                                Exit For
                            End If
                        Next
                        dtLFL.Rows(iRow)(colRev1) += drTemp(colRev1)
                        dtLFL.Rows(iRow)(colRev2) += drTemp(colRev2)
                        dtLFL.Rows(iRow)(colLoss1) += drTemp(colLoss1)
                        dtLFL.Rows(iRow)(colLoss2) += drTemp(colLoss2)
                    End If
                Next

                'summary last row
                Dim drSum As DataRow = dtLFL.NewRow
                drSum(colRev1) = IIf(dtLFL.Compute("Sum(" + colRev1 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colRev1 + ")", ""))
                drSum(colRev2) = IIf(dtLFL.Compute("Sum(" + colRev2 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colRev2 + ")", ""))
                drSum(colLoss1) = IIf(dtLFL.Compute("Sum(" + colLoss1 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colLoss1 + ")", ""))
                drSum(colLoss2) = IIf(dtLFL.Compute("Sum(" + colLoss2 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colLoss2 + ")", ""))
                drSum(colStoreId) = 0  'สมมุติให้เป็น store id = 0
                dtLFL.Rows.Add(drSum)

                'Dividing each row
                Dim rev1 As Double = 0 : Dim rev2 As Double = 0 : Dim loss1 As Double = 0 : Dim loss2 As Double = 0
                For Each dr As DataRow In dtLFL.Rows
                    rev1 = IIf(IsDBNull(dr(0)), 0, dr(0))
                    rev2 = IIf(IsDBNull(dr(1)), 0, dr(1))
                    loss1 = IIf(IsDBNull(dr(2)), 0, dr(2))
                    loss2 = IIf(IsDBNull(dr(3)), 0, dr(3))

                    If rev1 <> 0 And rev2 <> 0 Then
                        dr(colRev1) = (rev1 / rev2) - 1
                    Else
                        dr(colRev1) = 0
                    End If

                    If loss1 <> 0 And loss2 <> 0 Then
                        dr(colLoss1) = (loss1 / loss2) - 1
                    Else
                        dr(colLoss1) = 0
                    End If
                Next

                store_id = ""
                If dtLFL.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        store_id = dr(colStoreId).ToString
                        If dtLFL.Select("store_id = " + store_id + " ").Length > 0 Then
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(dtLFL.Select("store_id = " + store_id + " ")(0)(colRev1))
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(dtLFL.Select("store_id = " + store_id + " ")(0)(colLoss1))
                        Else
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If
                    Next
                End If

                'Cal YOY Growth ( Columns --> % Revenue Growth-YOY" in report in Report )
                'Cal YOY Loss Growth ( Columns --> % Store Trading Profit Growth-YOY in Report )
                Dim dtPreYtd As New DataTable
                dtPreYtd = getYoyYtd(years - 1, mon, locate, rate)

                rev1 = 0 : rev2 = 0 : loss1 = 0 : loss2 = 0
                Dim costcenterStore As String = ""
                If dtPreYtd.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        costcenterStore = dr("costcenter_store").ToString

                        If dtPreYtd.Select("costcenter_store = " + costcenterStore + " ").Length > 0 Then
                            rev1 = IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
                            rev2 = IIf(IsDBNull(dtPreYtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue")), 0, dtPreYtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue"))

                            loss1 = IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))
                            loss2 = IIf(IsDBNull(dtPreYtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss")), 0, dtPreYtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss"))

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
                'แยก row ที่เป็น total ออกไปอีก table
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("costcenter_store") = 0 Then
                        dtTotal.ImportRow(dt.Rows(i))
                        dt.Rows(i).Delete()
                    End If
                Next
                dt.AcceptChanges()
                ds.Tables.Add(dt)
                ds.Tables(0).TableName = reportPart.Item.ToString

                'Add Total YOY
                Dim drTotalYoy As Data.DataRow
                drTotalYoy = clsBts.getYoyYtdTotal(years, mon, locate, rate).Rows(2)

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
                ds.Tables(1).TableName = reportPart.Total.ToString
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

    Public Shared Function getModelMtdArea(ByVal years As String, ByVal mon As String, rate As String) As DataSet

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")
        Dim locate As String = ""

        Dim sql As String = "SELECT sm.*,area_id as store_id,area_id as costcenter_store,'Area '+ area_name as store_name," & _
            "'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
            "SELECT COUNT(DISTINCT cc.costcenter_id) as cnum,SUM(TotalRevenue)/SUM(costcenter_sale_area) as productivity, " & _
            "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
            " costcenter_areas , " & _
            "" + columnModelSum() + "" & _
            " from " + sqlTbl + " mt,costcenter cc,store sto " & _
            " where  cc.costcenter_store = sto.store_id and sto.store_other='N' and mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt ) and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " & _
            " AND cc.costcenter_opendt < @sl_dt " & _
            " group by costcenter_areas ) sm,area ar where sm.costcenter_areas=ar.area_id"

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
                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", ""))) ' - Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id=8").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id=8")))
                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = reportPart.Total.ToString
                dt.Rows.Add(drTotal)

                'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
                'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
                Dim strore_id As String = ""
                dtlflG = getLFLGrowthArea(years, mon, clsBts.reportType.MTD.ToString)

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
                dtPreMtd = getYoyMtdArea(years - 1, mon, clsBts.reportType.MTD.ToString)
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
                ds.Tables(0).TableName = reportPart.Item.ToString

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
                ds.Tables(1).TableName = reportPart.Total.ToString

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

    Public Shared Function getModelYtdArea(ByVal years As String, ByVal mon As String, rate As String) As DataSet

        Dim locate As String = ""
        Dim start_time As String = ""
        If mon < 4 Then
            start_time = "1/4/" + (years - 1).ToString
        Else
            start_time = "1/4/" + years
        End If

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        If locate <> "" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select bb.*,area_id as store_id,area_id as costcenter_store,'Area '+ area_name as store_name," & _
            "'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
        "   select  COUNT(DISTINCT cs.costcenter_id) as cnum,cs.costcenter_areas, " & _
        "	SUM(cs.costcenter_total_area) as Sumtotalarea,  " & _
        "	SUM(cs.costcenter_sale_area) as Sumsalearea,  " & _
  "(SUM(SumTotalRevenue)/SUM(cs.costcenter_sale_area))/(DATEDIFF(month,@start_time,@select_dt)+1) as productivity, " & _
  "" + columnMtdSumInSum() + "" & _
        " from ( " & _
        "select mt.costcenter_id, " & _
  "SUM(costcenter_total_area) as sumtotalarea, " & _
  "SUM(costcenter_sale_area) as sumsalearea, " & _
  "" + columnModelSum() + "" & _
        "from ( " & _
        "select mta.* " & _
        "from " + sqlTbl + " mta,costcenter cca,store sto1 " & _
        " where mta.costcenter_id = cca.costcenter_id And cca.costcenter_store = sto1.store_id and sto1.store_other='N' and " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= @start_time " & _
        " union " & _
        "select mtb.* " & _
        "from " + sqlTbl + " mtb,costcenter ccb,store sto2 " & _
        "where mtb.costcenter_id = ccb.costcenter_id And ccb.costcenter_store = sto2.store_id and sto2.store_other='N' and " & _
        "ccb.costcenter_blockdt >= @sl_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= @start_time " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id  " & _
        " and cc.costcenter_opendt < @sl_dt " & _
        "group by mt.costcenter_id " & _
        ") mt2,costcenter cs " & _
        "where mt2.costcenter_id = cs.costcenter_id " & _
        "group by cs.costcenter_areas " & _
        ") bb,area ar " & _
        "where bb.costcenter_areas=ar.area_id "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If

        cmd.Parameters.Add(parameter)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable

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

                Dim monthDiff As Integer = 1 + DateDiff(DateInterval.Month, DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing), DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing))
                If dt.Compute("Sum(sumsalearea)", "").ToString = "" OrElse dt.Compute("Sum(sumsalearea)", "") = 0 Then
                    drTotal("productivity") = 0
                Else
                    drTotal("productivity") = (dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")) / monthDiff
                End If
                drTotal("cnum") = IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", "")) '- IIf(dt.Compute("Sum(cnum)", "store_id=8").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id=8"))

                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = reportPart.Total.ToString
                dt.Rows.Add(drTotal)

                'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
                'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
                Dim colStoreId As String = "store_id"
                Dim colRev1 As String = "rev1"
                Dim colRev2 As String = "rev2"
                Dim colLoss1 As String = "loss1"
                Dim colLoss2 As String = "loss2"

                Dim dtLFL As New DataTable
                Dim store_id As String = ""
                Dim beginYear As Integer = years
                Dim beginMon As Integer = 4
                Dim dtTemp As New DataTable : dtTemp = Nothing

                If Integer.Parse(mon) < 4 Then
                    beginYear = Integer.Parse(years) - 1
                End If
                Dim endDate As DateTime = DateTime.ParseExact(("1/" + beginMon.ToString + "/" + beginYear.ToString), ClsManage.formatDateTime, Nothing)
                Dim tempDate As DateTime = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)

                While (tempDate >= endDate)
                    dtLFL = getLFLGrowthArea(tempDate.Year, tempDate.Month, clsBts.reportType.YTD.ToString)

                    If dtTemp Is Nothing Then
                        dtTemp = dtLFL
                    Else
                        dtTemp.Merge(dtLFL)
                    End If
                    tempDate = tempDate.AddMonths(-1)
                End While
                dtLFL = Nothing
                dtLFL = dtTemp.Clone
                Dim iRow As Integer = -1
                For Each drTemp As DataRow In dtTemp.Rows
                    store_id = drTemp(colStoreId).ToString
                    If dtLFL.Select("store_id = " + store_id + " ").Length = 0 Then
                        dtLFL.ImportRow(drTemp)
                    Else
                        'Find duplicate rows for summary
                        For i = 0 To dtLFL.Rows.Count - 1
                            If store_id = dtLFL.Rows(i)(colStoreId) Then
                                iRow = i
                                Exit For
                            End If
                        Next
                        dtLFL.Rows(iRow)(colRev1) += drTemp(colRev1)
                        dtLFL.Rows(iRow)(colRev2) += drTemp(colRev2)
                        dtLFL.Rows(iRow)(colLoss1) += drTemp(colLoss1)
                        dtLFL.Rows(iRow)(colLoss2) += drTemp(colLoss2)
                    End If
                Next

                'summary last row
                Dim drSum As DataRow = dtLFL.NewRow
                drSum(colRev1) = IIf(dtLFL.Compute("Sum(" + colRev1 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colRev1 + ")", ""))
                drSum(colRev2) = IIf(dtLFL.Compute("Sum(" + colRev2 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colRev2 + ")", ""))
                drSum(colLoss1) = IIf(dtLFL.Compute("Sum(" + colLoss1 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colLoss1 + ")", ""))
                drSum(colLoss2) = IIf(dtLFL.Compute("Sum(" + colLoss2 + ")", "").ToString = "", 0, dtLFL.Compute("Sum(" + colLoss2 + ")", ""))
                drSum(colStoreId) = 0  'สมมุติให้เป็น store id = 0
                dtLFL.Rows.Add(drSum)

                'Dividing each row
                Dim rev1 As Double = 0 : Dim rev2 As Double = 0 : Dim loss1 As Double = 0 : Dim loss2 As Double = 0
                For Each dr As DataRow In dtLFL.Rows
                    rev1 = IIf(IsDBNull(dr(0)), 0, dr(0))
                    rev2 = IIf(IsDBNull(dr(1)), 0, dr(1))
                    loss1 = IIf(IsDBNull(dr(2)), 0, dr(2))
                    loss2 = IIf(IsDBNull(dr(3)), 0, dr(3))

                    If rev1 <> 0 And rev2 <> 0 Then
                        dr(colRev1) = (rev1 / rev2) - 1
                    Else
                        dr(colRev1) = 0
                    End If

                    If loss1 <> 0 And loss2 <> 0 Then
                        dr(colLoss1) = (loss1 / loss2) - 1
                    Else
                        dr(colLoss1) = 0
                    End If
                Next

                store_id = ""
                If dtLFL.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        store_id = dr(colStoreId).ToString
                        If dtLFL.Select("store_id = " + store_id + " ").Length > 0 Then
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(dtLFL.Select("store_id = " + store_id + " ")(0)(colRev1))
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(dtLFL.Select("store_id = " + store_id + " ")(0)(colLoss1))
                        Else
                            dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(0)
                            dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                        End If
                    Next
                End If



                'Cal YOY Growth ( Columns --> % Revenue Growth-YOY" in report in Report )
                'Cal YOY Loss Growth ( Columns --> % Store Trading Profit Growth-YOY in Report )
                Dim dtPreYtd As New DataTable
                'dtPreYtd = getYoyYtdArea(years - 1, mon)
                dtTemp = Nothing
                tempDate = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
                While (tempDate >= endDate)
                    dtPreYtd = getYoyMtdArea(tempDate.Year - 1, tempDate.Month, clsBts.reportType.YTD.ToString)
                    If dtTemp Is Nothing Then
                        dtTemp = dtPreYtd
                    Else
                        dtTemp.Merge(dtPreYtd)
                    End If
                    tempDate = tempDate.AddMonths(-1)
                End While
                dtPreYtd = Nothing
                dtPreYtd = dtTemp.Clone
                iRow = -1

                For Each drTemp As DataRow In dtTemp.Rows
                    store_id = drTemp(colStoreId).ToString
                    If dtPreYtd.Select("store_id = " + store_id + " ").Length = 0 Then
                        dtPreYtd.ImportRow(drTemp)
                    Else
                        'Find duplicate rows for summary
                        For i = 0 To dtLFL.Rows.Count - 1
                            If store_id = dtLFL.Rows(i)(colStoreId) Then
                                iRow = i
                                Exit For
                            End If
                        Next
                        dtPreYtd.Rows(iRow)("SumTotalRevenue") += drTemp("SumTotalRevenue")
                        dtPreYtd.Rows(iRow)("SumLoss") += drTemp("SumLoss")

                    End If
                Next

                Dim drPreYtdTotal As DataRow = dtPreYtd.NewRow
                drPreYtdTotal("costcenter_store") = 0
                drPreYtdTotal("store_id") = 0
                drPreYtdTotal("store_name") = reportPart.Total.ToString
                drPreYtdTotal("SumTotalRevenue") = IIf(dtPreYtd.Compute("Sum(SumTotalRevenue)", "").ToString = "", 0, dtPreYtd.Compute("Sum(SumTotalRevenue)", ""))
                drPreYtdTotal("SumLoss") = IIf(dtPreYtd.Compute("Sum(SumLoss)", "").ToString = "", 0, dtPreYtd.Compute("Sum(SumLoss)", ""))
                dtPreYtd.Rows.Add(drPreYtdTotal)

                rev1 = 0 : rev2 = 0 : loss1 = 0 : loss2 = 0
                Dim costcenterStore As String = ""
                If dtPreYtd.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        costcenterStore = dr("costcenter_store").ToString

                        If dtPreYtd.Select("costcenter_store = " + costcenterStore + " ").Length > 0 Then
                            rev1 = IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
                            rev2 = IIf(IsDBNull(dtPreYtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue")), 0, dtPreYtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumTotalRevenue"))

                            loss1 = IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))
                            loss2 = IIf(IsDBNull(dtPreYtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss")), 0, dtPreYtd.Select("costcenter_store = " + costcenterStore + " ")(0)("SumLoss"))

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
                'แยก row ที่เป็น total ออกไปอีก table
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("costcenter_store") = 0 Then
                        dtTotal.ImportRow(dt.Rows(i))
                        dt.Rows(i).Delete()
                    End If
                Next
                dt.AcceptChanges()
                ds.Tables.Add(dt)
                ds.Tables(0).TableName = reportPart.Item.ToString

                'Add Total YOY
                Dim drTotalYoy As Data.DataRow
                drTotalYoy = clsBts.getYoyYtdTotal(years, mon, locate, rate).Rows(2)

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
                ds.Tables(1).TableName = reportPart.Total.ToString
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

    Public Shared Function getModelByFormat(ByVal bDate As String, ByVal eDate As String, locate As String, store_id As String, rate As String) As DataSet

        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")
        Dim beginDate As DateTime = DateTime.ParseExact(bDate, ClsManage.formatDateTime, Nothing)
        Dim endDate As DateTime = DateTime.ParseExact(eDate, ClsManage.formatDateTime, Nothing)
        Dim years As String = endDate.Year.ToString
        Dim mon As String = endDate.Month.ToString
        '
        Dim sql As String = "SELECT sm.*,sm.costcenter_code as store_id,sm.costcenter_code as costcenter_store, costcenter_name as store_name," & _
            "'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
            "SELECT COUNT(DISTINCT cc.costcenter_id) as cnum," & _
            "case when SUM(costcenter_sale_area) = 0 then 0 else SUM(TotalRevenue)/SUM(costcenter_sale_area) end as productivity, " & _
            "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
            " costcenter_code , " & _
            "" + columnModelSum() + "" & _
            " from " + sqlTbl + " mt,costcenter cc,store sto " & _
            " where  cc.costcenter_store = sto.store_id and sto.store_other='N' and mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )" & _
            " and month_time between @beginDate and @endDate " & _
            " AND cc.costcenter_opendt < @sl_dt and " & _
            " (cc.costcenter_store = @store_id or @store_id='') and (cc.costcenter_location=@locate or @locate='') " & _
            " group by costcenter_code ) sm,costcenter c where sm.costcenter_code=c.costcenter_code order by sm.costcenter_code asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
        parameter.Value = endDate.AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        parameter.Value = endDate.AddMonths(1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@beginDate", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@endDate", SqlDbType.DateTime)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@store_id", SqlDbType.VarChar)
        parameter.Value = store_id
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
                drTotal("cnum") = Integer.Parse(IIf(dt.Compute("Sum(cnum)", "").ToString = "", 0, dt.Compute("Sum(cnum)", ""))) ' - Integer.Parse(IIf(dt.Compute("Sum(cnum)", "store_id=8").ToString = "", 0, dt.Compute("Sum(cnum)", "store_id=8")))
                drTotal("store_id") = 0
                drTotal("costcenter_store") = 0
                drTotal("store_name") = reportPart.Total.ToString
                dt.Rows.Add(drTotal)

                'Cal LFL Growth ( Columns --> % Revenue Growth-LFL" in report in Report )
                'Cal LFL Loss Growth ( Columns --> % Store Trading Profit Growth-LFL in Report )
                Dim lfl_store_id As String = ""
                dtlflG = getLFLGrowthByFormat(beginDate, endDate, locate, store_id)

                Dim sumRev1 As Double = 0 : Dim sumRev2 As Double = 0
                Dim sumLoss1 As Double = 0 : Dim sumLoss2 As Double = 0
                Dim drLFL As DataRow
                Dim rev1 As Double = 0
                Dim rev2 As Double = 0
                Dim loss1 As Double = 0
                Dim loss2 As Double = 0

                If dtlflG.Rows.Count > 0 Then
                    Dim lfl As Double = 0
                    Dim loss As Double = 0
                    For Each dr As DataRow In dt.Rows
                        lfl_store_id = dr("store_id").ToString

                        If dtlflG.Select("store_id = " + lfl_store_id + " ").Length > 0 Then

                            drLFL = dtlflG.Select("store_id = " + lfl_store_id + " ")(0)
                            rev1 = drLFL("rev1")
                            rev2 = drLFL("rev2")
                            loss1 = drLFL("loss1")
                            loss2 = drLFL("loss2")

                            'only by Format For summary
                            If lfl_store_id = "0" Then
                                lfl = (sumRev1 / sumRev2) - 1
                                loss = (sumLoss1 / sumLoss2) - 1

                                'ถ้าปีที่แล้วติดลบ ต้อง *-1
                                If sumLoss2 < 0 Then loss = -loss

                                dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(lfl)
                                dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(loss)
                            Else
                                If rev1 <> 0 And rev2 <> 0 Then
                                    lfl = (rev1 / rev2) - 1
                                    dr("lfl_growth") = ClsManage.convert2PercenLFLGrowth(lfl)
                                Else
                                    dr("lfl_growth") = ClsManage.msgLFLNone
                                End If
                                If loss1 <> 0 And loss2 <> 0 Then
                                    loss = (loss1 / loss2) - 1

                                    'ถ้าปีที่แล้วติดลบ ต้อง *-1
                                    If loss2 < 0 Then loss = -loss

                                    dr("lfl_loss_growth") = ClsManage.convert2PercenLFLGrowth(loss)
                                Else
                                    dr("lfl_loss_growth") = ClsManage.msgLFLNone
                                End If

                                If rev1 <> 0 And rev2 <> 0 Then
                                    sumRev1 += rev1 : sumRev2 += rev2
                                End If
                                If loss1 <> 0 And loss2 <> 0 Then
                                    sumLoss1 += loss1 : sumLoss2 += loss2
                                End If
                            End If

                        Else
                            dr("lfl_growth") = ClsManage.msgLFLNone ' ClsManage.convert2PercenLFLGrowth(0)
                            dr("lfl_loss_growth") = ClsManage.msgLFLNone 'ClsManage.convert2PercenLFLGrowth(0)
                        End If
                    Next
                End If

            'Cal YOY Growth ( Columns --> % Revenue Growth-YOY" in report in Report )
            'Cal YOY Loss Growth ( Columns --> % Store Trading Profit Growth-YOY in Report )
                dtPreMtd = getYoyMtdByFormat(beginDate, endDate, locate, store_id, rate)
                rev1 = 0
                rev2 = 0
                loss1 = 0
                loss2 = 0
                Dim yoyLoss As Double = 0
                Dim drYOY As DataRow
            Dim costcenterStore As String = ""
                If dtPreMtd.Rows.Count > 0 Then
                    sumRev1 = 0 : sumRev2 = 0 : sumLoss1 = 0 : sumLoss2 = 0
                    For Each dr As DataRow In dt.Rows
                        costcenterStore = dr("costcenter_store").ToString
                        If dtPreMtd.Select("costcenter_store = " + costcenterStore + " ").Length > 0 Then

                            drYOY = dtPreMtd.Select("costcenter_store = " + costcenterStore + " ")(0)
                            rev1 = IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
                            rev2 = drYOY("SumTotalRevenue")
                            loss1 = IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))
                            loss2 = drYOY("SumLoss")

                            'only By Format ต้องหา sum ที่มีใน costcenter store --> ต้อง sum อีกรอบ
                            If costcenterStore = "0" Then
                                If sumRev1 <> 0 And sumRev2 <> 0 Then
                                    dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((sumRev1 / sumRev2) - 1)
                                Else
                                    dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
                                End If

                                If sumLoss1 <> 0 And sumLoss2 <> 0 Then
                                    'ถ้าปีที่แล้วติดลบ ต้อง *-1
                                    yoyLoss = (sumLoss1 / sumLoss2) - 1
                                    If sumLoss2 < 0 Then yoyLoss = -yoyLoss
                                    dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(yoyLoss)
                                Else
                                    dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                                End If
                            Else
                                If rev1 <> 0 And rev2 <> 0 Then
                                    dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth((rev1 / rev2) - 1)
                                Else
                                    dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(0)
                                End If

                                If loss1 <> 0 And loss2 <> 0 Then
                                    'ถ้าปีที่แล้วติดลบ ต้อง *-1
                                    yoyLoss = (loss1 / loss2) - 1
                                    If loss2 < 0 Then yoyLoss = -yoyLoss
                                    dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(yoyLoss)
                                Else
                                    dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(0)
                                End If

                                If rev1 <> 0 And rev2 <> 0 Then
                                    sumRev1 += rev1 : sumRev2 += rev2
                                End If
                                If loss1 <> 0 And loss2 <> 0 Then
                                    sumLoss1 += loss1 : sumLoss2 += loss2
                                End If

                            End If
                        Else
                            'YOY เพิ่มขึ้น เป็น 100%(1=100%) ตลอดเพราะปีที่แล้ว ไม่มีค่า
                            dr("yoy_growth") = ClsManage.convert2PercenLFLGrowth(1)
                            dr("yoy_loss_growth") = ClsManage.convert2PercenLFLGrowth(1)

                            '*** Only YOY ถ้าปีที่แล้วไม่มี ต้องบวกปีนี้เข้าไปด้วย
                            sumRev1 += IIf(IsDBNull(dr("SumTotalRevenue")), 0, dr("SumTotalRevenue"))
                            sumLoss1 += IIf(IsDBNull(dr("SumStoreTradingProfit__Loss")), 0, dr("SumStoreTradingProfit__Loss"))

                        End If
                    Next
                End If
                Dim dtTotal As New DataTable
                dtTotal = dt.Clone
                If dt.Rows.Count > 0 Then
                    dtTotal.ImportRow(dt.Select("costcenter_store = 0")(0))
                    dt.Rows(dt.Rows.Count - 1).Delete()
                    dt.AcceptChanges()
                End If
                ds.Tables.Add(dt)
                ds.Tables(0).TableName = reportPart.Item.ToString

                'Add Total YOY
                Dim drTotalYoy As Data.DataRow
                drTotalYoy = clsBts.getYoyMtdTotalByFormat(beginDate, endDate, locate, rate, store_id).Rows(2)

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
                ds.Tables(1).TableName = reportPart.Total.ToString

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
#End Region

#Region "Sum Report YTD"

    Public Shared Function getLFLGrowthForYtd(ByVal years As String, ByVal mon As String, locate As String) As DataTable
        'store_id = format
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""

        sqlCol = "select SUM(TotalRevenue) as SumRevenue,SUM(StoreTradingProfit__Loss) as SumLoss, sto.store_id, "
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
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )  AND (sto.store_id = @store_id or @store_id = '')  " & _
" AND (cb.costcenter_location = @locate OR @locate = '' )"
        sqlCondition2 = "GROUP BY sto.store_id )g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar)  " & _
            "from mtd dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by sto.store_id )g2 on g1.store_id = g2.store_id"

        sql = "select g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2,g1.SumLoss as loss1,g2.SumLoss as loss2, g1.store_id from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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

    Public Shared Function getYoyYtd(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String) As DataTable

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        If locate <> "" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select * from ( " & _
        "select  COUNT(DISTINCT cs.costcenter_id) as cnum, cs.costcenter_store, " & _
        "SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumLoss " & _
        "from ( " & _
        "select mt.costcenter_id, " & _
        "SUM(TotalRevenue) as TotalRevenue,SUM(StoreTradingProfit__Loss) as StoreTradingProfit__Loss  " & _
        "from ( " & _
        "select mta.* " & _
        "from " + sqlTbl + " mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= @start_time " & _
        " union " & _
        "select mtb.* " & _
        "from " + sqlTbl + " mtb,costcenter ccb " & _
        "where mtb.costcenter_id = ccb.costcenter_id And " & _
        "ccb.costcenter_blockdt >= @sl_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= @start_time " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id " & _
        " " + area + " " & _
        " and cc.costcenter_opendt < @sl_dt " & _
        "group by mt.costcenter_id " & _
        ") mt2,costcenter cs " & _
        "where mt2.costcenter_id = cs.costcenter_id " & _
        "group by cs.costcenter_store " & _
        ") bb,store st1 " & _
        "where bb.costcenter_store = st1.store_id and st1.store_other='N' order by st1.store_order asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        Dim start_date As String
        If Integer.Parse(mon) < 4 Then
            start_date = "1/4/" + (years - 1).ToString
        Else
            start_date = "1/4/" + years
        End If
        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(start_date, ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim drTotal As DataRow = dt.NewRow
                drTotal("costcenter_store") = 0
                drTotal("store_id") = 0
                drTotal("store_name") = reportPart.Total.ToString
                drTotal("SumTotalRevenue") = IIf(dt.Compute("Sum(SumTotalRevenue)", "").ToString = "", 0, dt.Compute("Sum(SumTotalRevenue)", ""))
                drTotal("SumLoss") = IIf(dt.Compute("Sum(SumLoss)", "").ToString = "", 0, dt.Compute("Sum(SumLoss)", ""))
                dt.Rows.Add(drTotal)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            cmd.Dispose()
            da.Dispose()
        End Try
    End Function

#End Region

#Region "Sub Report MTD"

    Public Shared Function getLFLGrowth(ByVal years As String, ByVal mon As String, locate As String) As DataTable
        'store_id = format
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""

        sqlCol = "select SUM(TotalRevenue) as SumRevenue,SUM(StoreTradingProfit__Loss) as SumLoss, sto.store_id, "
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
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )  AND (sto.store_id = @store_id or @store_id = '')  " & _
" AND (cb.costcenter_location = @locate OR @locate = '' )"
        sqlCondition2 = "GROUP BY sto.store_id )g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar)  " & _
            "from mtd dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by sto.store_id )g2 on g1.store_id = g2.store_id"

        sql = "select g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2,g1.SumLoss as loss1,g2.SumLoss as loss2, g1.store_id from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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
            If dt.Rows.Count > 0 Then
                Dim dtRGlfl As New DataTable
                dtRGlfl = dt.Clone
                Dim rev1 As Double = 0
                Dim rev2 As Double = 0
                Dim loss1 As Double = 0
                Dim loss2 As Double = 0
                Dim sumRev1 As Double = IIf(dt.Compute("Sum(rev1)", "").ToString = "", 0, dt.Compute("Sum(rev1)", ""))
                Dim sumRev2 As Double = IIf(dt.Compute("Sum(rev2)", "").ToString = "", 0, dt.Compute("Sum(rev2)", ""))
                Dim sumLoss1 As Double = IIf(dt.Compute("Sum(loss1)", "").ToString = "", 0, dt.Compute("Sum(loss1)", ""))
                Dim sumLoss2 As Double = IIf(dt.Compute("Sum(loss2)", "").ToString = "", 0, dt.Compute("Sum(loss2)", ""))

                For Each dr As DataRow In dt.Rows
                    rev1 = IIf(IsDBNull(dr(0)), 0, dr(0))
                    rev2 = IIf(IsDBNull(dr(1)), 0, dr(1))
                    loss1 = IIf(IsDBNull(dr(2)), 0, dr(2))
                    loss2 = IIf(IsDBNull(dr(3)), 0, dr(3))

                    If rev1 <> 0 And rev2 <> 0 Then
                        dr("rev1") = (rev1 / rev2) - 1
                    Else
                        dr("rev1") = 0
                    End If

                    If loss1 <> 0 And loss2 <> 0 Then
                        dr("loss1") = (loss1 / loss2) - 1
                    Else
                        dr("loss1") = 0
                    End If

                Next
                Dim drSum As DataRow = dt.NewRow
                'Sum Total Revenue
                If sumRev1 <> 0 And sumRev2 <> 0 Then
                    drSum("rev1") = (sumRev1 / sumRev2) - 1
                Else
                    drSum("rev1") = 0
                End If

                'Sum Store Trading Profit/Loss
                If sumLoss2 <> 0 And sumLoss1 <> 0 Then
                    drSum("loss1") = (sumLoss1 / sumLoss2) - 1
                Else
                    drSum("loss1") = 0
                End If

                'สมมุติให้เป็น store id = 0
                drSum("store_id") = 0

                dt.Rows.Add(drSum)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getYoyMtd(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String) As DataTable

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        If locate <> "" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select *  from (select COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store, " & _
        "SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumLoss " & _
        "from " + sqlTbl + " mt,costcenter cc " & _
        "where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " + area + " " & _
        " and cc.costcenter_opendt < @sl_dt " & _
        " group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id and st.store_other='N' order by st.store_order asc"


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

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""

                drTotal("costcenter_store") = 0
                drTotal("store_id") = 0
                drTotal("store_name") = reportPart.Total.ToString
                drTotal("SumTotalRevenue") = IIf(dt.Compute("Sum(SumTotalRevenue)", "").ToString = "", 0, dt.Compute("Sum(SumTotalRevenue)", ""))
                drTotal("SumLoss") = IIf(dt.Compute("Sum(SumLoss)", "").ToString = "", 0, dt.Compute("Sum(SumLoss)", ""))
                dt.Rows.Add(drTotal)
            End If
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getYoyMtdTotal(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String) As DataTable
        'In Report Column "% YOY"
        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        If locate <> "" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If
        Dim sqlCon As String = ""
        Dim sql As String = ""
        Dim sqlCon1 As String = ""
        Dim sqlCon2 As String = ""
        Dim sqlCol As String = ""

        sqlCol = "SELECT " + columnModelSum()
        sqlCon1 = "," + years + " as years " & _
"from " + sqlTbl + " mt,costcenter cc,store st " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " + area + " " & _
" and cc.costcenter_opendt < @sl_dt " & _
" and cc.costcenter_store=st.store_id and st.store_other='N'"

        sqlCon2 = "," + (years - 1).ToString + " as years " & _
"from " + sqlTbl + " mt,costcenter cc,store st " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt2 )  and year(month_time) = '" + (years - 1).ToString + "' and month(month_time) = '" + mon + "' " + area + " " & _
" and cc.costcenter_opendt < @sl_dt2 " & _
" and cc.costcenter_store=st.store_id and st.store_other='N'"

        sql = "select * from (" + sqlCol + sqlCon1 + " UNION " + sqlCol + sqlCon2 + ") yoy order by years DESC"

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

        years = years - 1
        'paramiter2
        parameter = New SqlParameter("@block_dt2", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt2", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

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

    Public Shared Function getYoyYtdTotal(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String) As DataTable

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        If locate <> "" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sqlCon As String = ""
        Dim sql As String = ""
        Dim sqlCon1 As String = ""
        Dim sqlCon2 As String = ""

        sqlCon1 = "select bb.*," + years + " as years from ( " & _
        "   select cs.costcenter_store," & _
        "" + columnMtdSumInSum() + "" & _
        " from ( select " & _
        "" + columnModelSum() + "" & _
        ",mt.costcenter_id " & _
        "from ( " & _
        "select mta.* " & _
        "from " + sqlTbl + " mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= @start_time   " & _
        " union " & _
        "select mtb.* " & _
        "from " + sqlTbl + " mtb,costcenter ccb " & _
        "where mtb.costcenter_id = ccb.costcenter_id And " & _
        "ccb.costcenter_blockdt >= @sl_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= @start_time  " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id " & _
        " " + area + " " & _
        " and cc.costcenter_opendt < @sl_dt " & _
        "group by mt.costcenter_id " & _
        ") mt2,costcenter cs " & _
        "where mt2.costcenter_id = cs.costcenter_id " & _
        "group by cs.costcenter_store " & _
        ") bb,store st1 " & _
        "where bb.costcenter_store = st1.store_id and st1.store_other='N'"

        sqlCon2 = "select bb.*," + (years - 1).ToString + " as years from ( " & _
         "   select  cs.costcenter_store," & _
        "" + columnMtdSumInSum() + "" & _
         "from ( select " & _
         "" + columnModelSum() + "" & _
        ", mt.costcenter_id " & _
         "from ( " & _
         "select mta.* " & _
         "from " + sqlTbl + " mta,costcenter cca " & _
         " where mta.costcenter_id = cca.costcenter_id And " & _
         "cca.costcenter_blockdt Is null And " & _
         "mta.month_time <= @select_dt2 and " & _
         "mta.month_time >= @start_time2   " & _
         " union " & _
         "select mtb.* " & _
         "from " + sqlTbl + " mtb,costcenter ccb " & _
         "where mtb.costcenter_id = ccb.costcenter_id And " & _
         "ccb.costcenter_blockdt >= @sl_dt2 and " & _
         "mtb.month_time <= @select_dt2 and " & _
         "mtb.month_time >= @start_time2  " & _
         ") mt,costcenter cc  " & _
         "where mt.costcenter_id = cc.costcenter_id " & _
         " " + area + " " & _
         " and cc.costcenter_opendt < @sl_dt2 " & _
         "group by mt.costcenter_id " & _
         ") mt2,costcenter cs " & _
         "where mt2.costcenter_id = cs.costcenter_id " & _
         "group by cs.costcenter_store " & _
         ") bb,store st1 " & _
         "where bb.costcenter_store = st1.store_id and st1.store_other='N'"

        sql = "select " + columnModelSumEnd() + ",years from (" + sqlCon1 + " UNION " + sqlCon2 + ") yoy order by years DESC"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@start_time", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(IIf(Integer.Parse(mon) < 4, "1/4/" + (years - 1).ToString, "1/4/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        years = years - 1
        'paramiter2
        parameter = New SqlParameter("@select_dt2", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@start_time2", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(IIf(Integer.Parse(mon) < 4, "1/4/" + (years - 1).ToString, "1/4/" + years), ClsManage.formatDateTime, Nothing)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt2", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable

        Try
            da.Fill(dt)
            Dim dtSum As New DataTable : dtSum = dt.Clone
            If dt.Rows.Count > 0 Then

                Dim drSum As DataRow = dtSum.NewRow
                Dim drSum2 As DataRow = dtSum.NewRow
                Dim colName As String = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    colName = drSum.Table.Columns(i).ColumnName
                    If colName.Contains("Sum") Then
                        drSum(i) = IIf(dt.Compute("Sum(" + colName + ")", "years=" + (years + 1).ToString + "").ToString = "", 0, dt.Compute("Sum(" + colName + ")", "years=" + (years + 1).ToString + ""))
                        drSum2(i) = IIf(dt.Compute("Sum(" + colName + ")", "years=" + years.ToString + "").ToString = "", 0, dt.Compute("Sum(" + colName + ")", "years=" + years.ToString + ""))
                    End If
                Next
                drSum("years") = years + 1
                drSum2("years") = years

                dtSum.Rows.Add(drSum)
                dtSum.Rows.Add(drSum2)

                Dim num As Double = 0
                Dim divi As Double = 0
                Dim dr As DataRow = dtSum.NewRow

                For i As Integer = 0 To dt.Columns.Count - 2
                    num = IIf(IsDBNull(dtSum.Rows(0)(i)), 0, dtSum.Rows(0)(i))
                    divi = IIf(IsDBNull(dtSum.Rows(1)(i)), 0, dtSum.Rows(1)(i))
                    If num = 0 Or divi = 0 Then
                        dr(i) = 0
                    Else
                        If dt.Rows(0).Table.Columns(i).ColumnName = "SumGrossProfit" Or dt.Rows(0).Table.Columns(i).ColumnName = "SumAdjustedGrossMargin" Or dt.Rows(0).Table.Columns(i).ColumnName = "SumStoreTradingProfit__Loss" Or dt.Rows(0).Table.Columns(i).ColumnName = "SumMarginAdjustments" Then
                            Dim thisPb As Double = 0 : Dim prePb As Double = 0 : Dim pb As Double = 0
                            If Not (IsDBNull(dtSum.Rows(1)(0)) Or IsDBNull(dtSum.Rows(1)(i)) Or IsDBNull(dtSum.Rows(0)(0)) Or IsDBNull(dtSum.Rows(0)(i))) Then
                                thisPb = num / dtSum.Rows(0)(0)
                                prePb = divi / dtSum.Rows(1)(0)
                                pb = (thisPb - prePb) * 10000
                                dr(i) = pb
                            End If
                        Else
                            dr(i) = (num / divi) - 1
                        End If
                    End If
                Next

                dr("years") = 0
                dtSum.Rows.Add(dr)
            End If
            Return dtSum
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

#End Region

#Region "By Format"
    Public Shared Function getLFLGrowthByFormat2(ByVal years As String, ByVal mon As String, locate As String) As DataTable
        'store_id = format
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""

        sqlCol = "select SUM(TotalRevenue) as SumRevenue,SUM(StoreTradingProfit__Loss) as SumLoss, sto.store_id, "
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
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )  AND (sto.store_id = @store_id or @store_id = '')  " & _
" AND (cb.costcenter_location = @locate OR @locate = '' )"
        sqlCondition2 = "GROUP BY sto.store_id )g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar)  " & _
            "from mtd dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by sto.store_id )g2 on g1.store_id = g2.store_id"

        sql = "select g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2,g1.SumLoss as loss1,g2.SumLoss as loss2, g1.store_id from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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
            If dt.Rows.Count > 0 Then
                Dim dtRGlfl As New DataTable
                dtRGlfl = dt.Clone
                Dim rev1 As Double = 0
                Dim rev2 As Double = 0
                Dim loss1 As Double = 0
                Dim loss2 As Double = 0
                Dim sumRev1 As Double = IIf(dt.Compute("Sum(rev1)", "").ToString = "", 0, dt.Compute("Sum(rev1)", ""))
                Dim sumRev2 As Double = IIf(dt.Compute("Sum(rev2)", "").ToString = "", 0, dt.Compute("Sum(rev2)", ""))
                Dim sumLoss1 As Double = IIf(dt.Compute("Sum(loss1)", "").ToString = "", 0, dt.Compute("Sum(loss1)", ""))
                Dim sumLoss2 As Double = IIf(dt.Compute("Sum(loss2)", "").ToString = "", 0, dt.Compute("Sum(loss2)", ""))

                For Each dr As DataRow In dt.Rows
                    rev1 = IIf(IsDBNull(dr(0)), 0, dr(0))
                    rev2 = IIf(IsDBNull(dr(1)), 0, dr(1))
                    loss1 = IIf(IsDBNull(dr(2)), 0, dr(2))
                    loss2 = IIf(IsDBNull(dr(3)), 0, dr(3))

                    If rev1 <> 0 And rev2 <> 0 Then
                        dr("rev1") = (rev1 / rev2) - 1
                    Else
                        dr("rev1") = 0
                    End If

                    If loss1 <> 0 And loss2 <> 0 Then
                        dr("loss1") = (loss1 / loss2) - 1
                    Else
                        dr("loss1") = 0
                    End If

                Next
                Dim drSum As DataRow = dt.NewRow
                'Sum Total Revenue
                If sumRev1 <> 0 And sumRev2 <> 0 Then
                    drSum("rev1") = (sumRev1 / sumRev2) - 1
                Else
                    drSum("rev1") = 0
                End If

                'Sum Store Trading Profit/Loss
                If sumLoss2 <> 0 And sumLoss1 <> 0 Then
                    drSum("loss1") = (sumLoss1 / sumLoss2) - 1
                Else
                    drSum("loss1") = 0
                End If

                'สมมุติให้เป็น store id = 0
                drSum("store_id") = 0

                dt.Rows.Add(drSum)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getLFLGrowthByFormat(beginDate As DateTime, endDate As DateTime, locate As String, store_id As String) As DataTable
        'store_id = format
        Dim years As String = beginDate.Year
        Dim mon As String = beginDate.Month
        Dim lastyear As String = beginDate.Year - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlPtype As String = ""

        sqlCol = "select SUM(TotalRevenue) as SumRevenue,SUM(StoreTradingProfit__Loss) as SumLoss, cb.costcenter_code as store_id , "
        sqlPtype = "ptype = cast( year(@thisyear) as varchar) "
        sqlCondition1 = "" & _
"from ( select mt1.* from mtd mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time between @thisBeginDate and @thisEndDate " & _
"and mt1.TotalRevenue <> '0' and ct.costcenter_opendt <  @lastBeginDate " & _
"and mt1.costcenter_id not in ( " + sqlTempClose() + " ) " & _
" ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )  AND (sto.store_id = @store_id or @store_id = '')  " & _
" AND (cb.costcenter_location = @locate OR @locate = '' )"
        sqlCondition2 = "GROUP BY cb.costcenter_code )g1 inner join( " + sqlCol + _
            "ptype = cast( year(@lastyear) as varchar)  " & _
            "from mtd dd,costcenter cb,store sto where dd.costcenter_id = cb.costcenter_id and dd.month_time between @lastBeginDate and @lastEndDate  " & _
            "and cb.costcenter_store = sto.store_id and sto.store_other = 'N' " & _
            "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") group by cb.costcenter_code )g2 on g1.store_id = g2.store_id"

        sql = "select 0.0 as lfl,0.0 as loss, g1.SumRevenue as Rev1 ,g2.SumRevenue as Rev2,g1.SumLoss as loss1,g2.SumLoss as loss2, g1.store_id from (" + sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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
        'If mon < 4 Then
        '    parameter.Value = DateTime.ParseExact(("1/4/" + lastyear), ClsManage.formatDateTime, Nothing)
        'Else
        '    parameter.Value = DateTime.ParseExact(("1/4/" + years), ClsManage.formatDateTime, Nothing)
        'End If
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@store_id", SqlDbType.VarChar)
        parameter.Value = store_id
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@locate", SqlDbType.VarChar)
        parameter.Value = locate
        cmd.Parameters.Add(parameter)


        parameter = New SqlParameter("@thisBeginDate", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@thisEndDate", SqlDbType.DateTime)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@lastBeginDate", SqlDbType.DateTime)
        parameter.Value = beginDate.AddYears(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@lastEndDate", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1)
        cmd.Parameters.Add(parameter)


        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim dtRGlfl As New DataTable
                dtRGlfl = dt.Clone
                Dim rev1 As Double = 0
                Dim rev2 As Double = 0
                Dim loss1 As Double = 0
                Dim loss2 As Double = 0
                'Dim sumRev1 As Double = IIf(dt.Compute("Sum(rev1)", "").ToString = "", 0, dt.Compute("Sum(rev1)", ""))
                'Dim sumRev2 As Double = IIf(dt.Compute("Sum(rev2)", "").ToString = "", 0, dt.Compute("Sum(rev2)", ""))
                'Dim sumLoss1 As Double = IIf(dt.Compute("Sum(loss1)", "").ToString = "", 0, dt.Compute("Sum(loss1)", ""))
                'Dim sumLoss2 As Double = IIf(dt.Compute("Sum(loss2)", "").ToString = "", 0, dt.Compute("Sum(loss2)", ""))

                For Each dr As DataRow In dt.Rows
                    rev1 = IIf(IsDBNull(dr("rev1")), 0, dr("rev1"))
                    rev2 = IIf(IsDBNull(dr("rev2")), 0, dr("rev2"))
                    loss1 = IIf(IsDBNull(dr("loss1")), 0, dr("loss1"))
                    loss2 = IIf(IsDBNull(dr("loss2")), 0, dr("loss2"))

                    If rev1 <> 0 And rev2 <> 0 Then
                        dr("lfl") = (rev1 / rev2) - 1
                    Else
                        dr("lfl") = 0
                    End If

                    If loss1 <> 0 And loss2 <> 0 Then
                        dr("loss") = (loss1 / loss2) - 1
                    Else
                        dr("loss") = 0
                    End If

                Next
                Dim drSum As DataRow = dt.NewRow
                'สมมุติให้เป็น store id = 0
                drSum("lfl") = 0
                drSum("loss") = 0
                drSum("rev1") = 0
                drSum("rev2") = 0
                drSum("loss1") = 0
                drSum("loss2") = 0
                drSum("store_id") = 0

                dt.Rows.Add(drSum)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getYoyMtdByFormat(beginDate As DateTime, endDate As DateTime, ByVal locate As String, store_id As String, rate As String) As DataTable

        Dim years As String = beginDate.Year - 1
        Dim mon As String = beginDate.Month
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        'Total ต้อง
        '************* "where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt ) " & _
        'chanage costcenter_store --> costcenter_store
        Dim sql As String = "select sm.*,c.costcenter_code as costcenter_store,c.costcenter_code as store_id,c.costcenter_name as store_name " & _
        "from (select COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_code, " & _
        "SUM(TotalRevenue) as SumTotalRevenue,SUM(StoreTradingProfit__Loss) as SumLoss " & _
        "from " + sqlTbl + " mt,costcenter cc " & _
        "where mt.costcenter_id = cc.costcenter_id " & _
        " and month_time between @beginDate and @endDate " & _
        " and (cc.costcenter_location = @locate OR @locate = '' )" & _
        " and cc.costcenter_opendt < @beginDate " & _
        " group by costcenter_code  ) sm,store st ,costcenter c " & _
        " where sm.costcenter_code = c.costcenter_code and c.costcenter_store=st.store_id and st.store_other='N' and ( c.costcenter_blockdt is null or c.costcenter_blockdt >= @block_dt ) " & _
        " and (st.store_id = @store_id OR @store_id = '' )" & _
        "order by c.costcenter_code asc "

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

        parameter = New SqlParameter("@beginDate", SqlDbType.DateTime)
        parameter.Value = beginDate.AddYears(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@endDate", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1).AddMonths(1).AddDays(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@locate", SqlDbType.VarChar)
        parameter.Value = locate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@store_id", SqlDbType.VarChar)
        parameter.Value = store_id
        cmd.Parameters.Add(parameter)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim drTotal As DataRow = dt.NewRow
                Dim colName As String = ""

                drTotal("costcenter_store") = 0
                drTotal("store_id") = 0
                drTotal("store_name") = reportPart.Total.ToString
                drTotal("SumTotalRevenue") = IIf(dt.Compute("Sum(SumTotalRevenue)", "").ToString = "", 0, dt.Compute("Sum(SumTotalRevenue)", ""))
                drTotal("SumLoss") = IIf(dt.Compute("Sum(SumLoss)", "").ToString = "", 0, dt.Compute("Sum(SumLoss)", ""))
                dt.Rows.Add(drTotal)
            End If
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getYoyMtdTotalByFormat(beginDate As DateTime, endDate As DateTime, ByVal locate As String, rate As String, store_id As String) As DataTable
        'In Report Column "% YOY"
        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        Dim sqlCon As String = ""
        Dim sql As String = ""
        Dim sqlCon1 As String = ""
        Dim sqlCon2 As String = ""
        Dim sqlCol As String = ""
        Dim years As String = beginDate.Year.ToString
        Dim mon As String = beginDate.Month.ToString

        sqlCol = "SELECT " + columnModelSum()
        sqlCon1 = "," + years + " as years " & _
"from " + sqlTbl + " mt,costcenter cc,store st " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt ) " & _
" and month_time between @beginDate and @endDate " & _
" and (cc.costcenter_location = @locate OR @locate = '' ) " & _
" and (st.store_id = @store_id or @store_id = '') " & _
" and cc.costcenter_opendt < @beginDate " & _
" and cc.costcenter_store=st.store_id and st.store_other='N'"

        sqlCon2 = "," + (years - 1).ToString + " as years " & _
"from " + sqlTbl + " mt,costcenter cc,store st " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt2 ) " & _
" and month_time between @beginDate and @endDate " & _
" and (cc.costcenter_location = @locate OR @locate = '' ) " & _
" and (st.store_id = @store_id or @store_id = '') " & _
" and cc.costcenter_opendt < @beginDate " & _
" and cc.costcenter_store=st.store_id and st.store_other='N'"

        sql = "select * from (" + sqlCol + sqlCon1 + " UNION " + sqlCol + sqlCon2 + ") yoy order by years DESC"

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

        years = years - 1
        'paramiter2
        parameter = New SqlParameter("@block_dt2", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@sl_dt2", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@locate", SqlDbType.VarChar)
        parameter.Value = locate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@store_id", SqlDbType.VarChar)
        parameter.Value = store_id
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@beginDate", SqlDbType.DateTime)
        parameter.Value = beginDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@endDate", SqlDbType.DateTime)
        parameter.Value = endDate
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@beginDate2", SqlDbType.DateTime)
        parameter.Value = beginDate.AddYears(-1)
        cmd.Parameters.Add(parameter)

        parameter = New SqlParameter("@endDate2", SqlDbType.DateTime)
        parameter.Value = endDate.AddYears(-1)
        cmd.Parameters.Add(parameter)



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
#End Region

#Region "Export"
    Public Shared Sub ExportToExcel(ByVal data_temp As String, Optional excelName As String = "MTD_Model_Report")

        ''HttpContext.Current.Response.ClearContent()
        ''HttpContext.Current.Response.Charset = ""
        ''HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode
        ''HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
        ''HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & excelName & ".xls")
        ''HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        ''HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        ''HttpContext.Current.Response.Write(data_temp)
        ''HttpContext.Current.Response.End()



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

        data_temp = data_temp.Replace("class='rbg0'", "style='color: #FFFFFF;background: #376091' ")
        data_temp = data_temp.Replace("class='rbg1'", "style='color: #FFFFFF;background: #376091' ")
        data_temp = data_temp.Replace("class='rbg2'", "style='color: #000000;background: #B8CCE4' ")
        data_temp = data_temp.Replace("class='rbg3'", "style='color: #000000;background: #FFFF99' ")
        data_temp = data_temp.Replace("class='rbg4'", "style='color: #000000;background: #B8CCE4' ")

        data_temp = data_temp.Replace("class='tdyoy1'", "style='text-align:right';")
        data_temp = data_temp.Replace("class='tball2'", "style='font-family:Arial;font-size:13px;border-bottom:1px solid #2c2b2b;'")
        data_temp = data_temp.Replace("class='tbTotal'", "style='font-family:Arial;font-size:13px;border-bottom:1px solid #2c2b2b;border-left:2.5px solid #2c2b2b;'")
        data_temp = data_temp.Replace("<table", "<style> TD { mso-number-format:\@; } </style> <table ")

        HttpContext.Current.Response.Output.Write(data_temp)
        HttpContext.Current.Response.Flush()
        HttpContext.Current.Response.End()

    End Sub
#End Region
End Class
