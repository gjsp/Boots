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

Public Class ClsDB
    Public Shared strcon As String = ConfigurationManager.ConnectionStrings("bootsConnectionString").ConnectionString
    Private Shared colSelSum As String = ""
#Region "columnMtd"



    Private Shared Function columnSumMtd() As String
        Dim col As New StringBuilder
        col.Append("SumTotalRevenue, SumRETAIL_TESPIncome, SumOtherRevenue, SumCostofGoodSold, SumGrossProfit, SumGrossProfit_percent, SumMarginAdjustments,")
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
        col.Append("SumCashOvertage_Shortagefromsales, SumMiscellenousandOther, SumStoreTradingProfit__Loss, SumTradingProfit__Loss, SumStoreControllableCostsforBSC,")
        col.Append("SumStoreLabourCost, SumUtillity, SumRepairMaintenance ")
        Return col.ToString
    End Function

    Private Shared Function columnMtd() As String
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
        col.Append("SUM(TradingProfit__Loss) as SumTradingProfit__Loss, ")
        col.Append("SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, ")
        col.Append("SUM(StoreLabourCost) as SumStoreLabourCost, ")
        col.Append("SUM(Utillity) as SumUtillity, ")
        col.Append("SUM(RepairMaintenance) as SumRepairMaintenance ")
        Return col.ToString
    End Function

    Private Shared Function htmlTopicTable() As String
        Dim sb As New StringBuilder
        sb.Append("<table cellspacing='0' cellpadding='0' class='tball2'>")
        sb.Append("<tr style='font-weight:bold;' class='rbg0'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:250px;padding-left:5px;'></div></td><td align='center'><div style='width:110px'><strong>Total</strong></div></td><td align='center'><div style='width:65px;'><strong>% Sale</strong></div></td><td align='center'><div style='width:85px;'><strong>% YOY</strong></div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Number of Stores (Exc.CDS)</div></td><td align='center'><div style='width:110px'><strong><asp:Label ID='LbNost' runat='server' Text=''></asp:Label></strong></div></td><td align='center'><div style='width:65px;'><strong></strong></div></td><td></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Total Gross Space (SQM)</div></td><td align='center' class='rbg2'><div style='width:110px'><asp:Label ID='LbFullTgs' runat='server' Text=''></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Total Selling Space (SQM)</div></td><td align='center' class='rbg2'><div style='width:110px'><asp:Label ID='LbFullTss' runat='server' Text=''></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Productivity/SQM</div></td><td align='center' class='rbg2'><div style='width:110px'><asp:Label ID='LbFullPos' runat='server' Text=''></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;</div></td><td align='center' class='kbg3'><div style='width:110px'></div></td><td align='center' class='kbg4'><div style='width:65px;'></div></td><td></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Revenue Growth-YOY</div></td><td align='right' class='rbg2'><div style='width:110px'><asp:Label ID='lblRGyoy' runat='server' Text=''></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Revenue Growth-LFL</div></td><td align='right' class='rbg2'><div style='width:110px'><asp:Label ID='lblRGlfl' runat='server' Text=''></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;</div></td><td align='center' class='kbg3'><div style='width:110px'></div></td><td align='center' class='kbg4'><div style='width:65px;'></div></td><td></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Revenue <span id='spaa' class='ppk' onclick='minitb('aa');'>+</span></div></td><td align='right'><div style='width:110px'><asp:Label ID='LbSumTotalRevenue' runat='server' Text=''></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID='LbPercTotalRevenue' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1000' runat='server'/></td></tr>")
        sb.Append("<tr id='aa1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sale Revenue</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumRETAIL_TESPIncome' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercRETAIL_TESPIncome' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1001' runat='server'/></td></tr>")
        sb.Append("<tr id='aa2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Revenue</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherRevenue' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherRevenue' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1002' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Cost of Good Sold</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumCostofGoodSold' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercCostofGoodSold' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1003' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Gross Profit</div></td><td align='right'><div style='width:110px'><asp:Label ID='LbSumGrossProfit' runat='server' Text=''></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID='LbPercGrossProfit' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1004' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Margin Adjustments <span id='spb' class='ppk' onclick='minitb('b');'>+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumMarginAdjustments' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercMarginAdjustments' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1005' runat='server'/></td></tr>")
        sb.Append("<tr id='b1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shipping</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumShipping' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercShipping' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1006' runat='server'/></td></tr>")
        sb.Append("<tr id='b2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss and Obsolescence</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumStockLossandObsolescence' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercStockLossandObsolescence' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1007' runat='server'/></td></tr>")
        sb.Append("<tr id='b3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - stock check (Actual)</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumInventoryAdjustment_stock' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercInventoryAdjustment_stock' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1008' runat='server'/></td></tr>")
        sb.Append("<tr id='b4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - damaged and obsolete stock (Actual)</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumInventoryAdjustment_damage' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercInventoryAdjustment_damage' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1009' runat='server'/></td></tr>")
        sb.Append("<tr id='b5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss  (Provision)</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumStockLoss_Provision' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercStockLoss_Provision' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1010' runat='server'/></td></tr>")
        sb.Append("<tr id='b6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Obsolescence (Provision)</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumStockObsolescence_Provision' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercStockObsolescence_Provision' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1011' runat='server'/></td></tr>")
        sb.Append("<tr id='b7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWP</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumGWP' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercGWP' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1012' runat='server'/></td></tr>")
        sb.Append("<tr id='b8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWPs - Corporate</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumGWPs_Corporate' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercGWPs_Corporate' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1013' runat='server'/></td></tr>")
        sb.Append("<tr id='b9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWPs - Transferred</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumGWPs_Transferred' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercGWPs_Transferred' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1014' runat='server'/></td></tr>")
        sb.Append("<tr id='b10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Selling Costs</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumSellingCosts' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercSellingCosts' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1015' runat='server'/></td></tr>")
        sb.Append("<tr id='b11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Credit cards commission</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumCreditcardscommission' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercCreditcardscommission' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1016' runat='server'/></td></tr>")
        sb.Append("<tr id='b12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Labelling Material</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumLabellingMaterial' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercLabellingMaterial' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1017' runat='server'/></td></tr>")
        sb.Append("<tr id='b13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Income - COSH Funding</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherIncome_COSHFunding' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherIncome_COSHFunding' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1018' runat='server'/></td></tr>")
        sb.Append("<tr id='b14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Income Supplier</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherIncomeSupplier' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherIncomeSupplier' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1019' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Adjusted Gross Margin</div></td><td align='right'><div style='width:110px'><asp:Label ID='LbSumAdjustedGrossMargin' runat='server' Text=''></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID='LbPercAdjustedGrossMargin' runat='server' Text=''></asp:Label>%</div></td><td align='right' class='rbg2'><asp:Label ID='lblYoy1020' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left' class='kbg2' style='border-bottom:1px solid #2c2b2b;'><div style='width:200px;padding-left:5px;' class='pptk'>Supply Chain Costs</div></td><td align='right' style='border-bottom:1px solid #2c2b2b;' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumSupplyChainCosts' runat='server' Text=''></asp:Label></div></td><td align='right' style='border-bottom:1px solid #2c2b2b;' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercSupplyChainCosts' runat='server' Text=''></asp:Label>%</div></td><td align='right' style='border-bottom:1px solid #2c2b2b;'><asp:Label ID='lblYoy1021' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Store Expenses</div></td><td align='right'><div style='width:110px'><asp:Label ID='LbSumTotalStoreExpenses' runat='server' Text=''></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID='LbPercTotalStoreExpenses' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1022' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Store Labour Costs <span id='spe' class='ppk' onclick='minitb('e');'>+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumStoreLabourCosts' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercStoreLabourCosts' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1023' runat='server'/></td></tr>")
        sb.Append("<tr id='e1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Gross Pay</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumGrossPay' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercGrossPay' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1024' runat='server'/></td></tr>")
        sb.Append("<tr id='e2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Temporary Staff Costs</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumTemporaryStaffCosts' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercTemporaryStaffCosts' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1025' runat='server'/></td></tr>")
        sb.Append("<tr id='e3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Allowance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumAllowance' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercAllowance' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1026' runat='server'/></td></tr>")
        sb.Append("<tr id='e4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Overtime</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOvertime' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOvertime' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1027' runat='server'/></td></tr>")
        sb.Append("<tr id='e5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - License fee</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumLicensefee' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercLicensefee' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1028' runat='server'/></td></tr>")
        sb.Append("<tr id='e6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Bonuses/Incentives</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumBonuses_Incentives' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercBonuses_Incentives' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1029' runat='server'/></td></tr>")
        sb.Append("<tr id='e7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Boots Brand ncentives</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumBootsBrandncentives' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercBootsBrandncentives' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1030' runat='server'/></td></tr>")
        sb.Append("<tr id='e8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Suppliers Incentive</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumSuppliersIncentive' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercSuppliersIncentive' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1031' runat='server'/></td></tr>")
        sb.Append("<tr id='e9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Provident Fund</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumProvidentFund' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercProvidentFund' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1032' runat='server'/></td></tr>")
        sb.Append("<tr id='e10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Pension Costs</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPensionCosts' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPensionCosts' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1033' runat='server'/></td></tr>")
        sb.Append("<tr id='e11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Social Security Fund</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumSocialSecurityFund' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercSocialSecurityFund' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1034' runat='server'/></td></tr>")
        sb.Append("<tr id='e12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Uniforms</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumUniforms' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercUniforms' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1035' runat='server'/></td></tr>")
        sb.Append("<tr id='e13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Employee Welfare</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumEmployeeWelfare' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercEmployeeWelfare' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1036' runat='server'/></td></tr>")
        sb.Append("<tr id='e14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Benefits Employee</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherBenefitsEmployee' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherBenefitsEmployee' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1037' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Store Property Costs <span id='spf' class='ppk' onclick='minitb('f');'>+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumStorePropertyCosts' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercStorePropertyCosts' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1038' runat='server'/></td></tr>")
        sb.Append("<tr id='f1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Rental</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPropertyRental' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPropertyRental' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1039' runat='server'/></td></tr>")
        sb.Append("<tr id='f2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Services</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPropertyServices' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPropertyServices' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1040' runat='server'/></td></tr>")
        sb.Append("<tr id='f3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Facility</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPropertyFacility' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPropertyFacility' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1041' runat='server'/></td></tr>")
        sb.Append("<tr id='f4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property taxes</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPropertytaxes' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPropertytaxes' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1042' runat='server'/></td></tr>")
        sb.Append("<tr id='f5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Facial taxes</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumFacialtaxes' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercFacialtaxes' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1043' runat='server'/></td></tr>")
        sb.Append("<tr id='f6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Insurance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPropertyInsurance' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPropertyInsurance' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1044' runat='server'/></td></tr>")
        sb.Append("<tr id='f7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Signboard</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumSignboard' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercSignboard' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1045' runat='server'/></td></tr>")
        sb.Append("<tr id='f8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Discount - Rent/Services/Facility</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumDiscount_Rent_Services_Facility' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercDiscount_Rent_Services_Facility' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1046' runat='server'/></td></tr>")
        sb.Append("<tr id='f9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GP Commission</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumGPCommission' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercGPCommission' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1047' runat='server'/></td></tr>")
        sb.Append("<tr id='f10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Amortization of Lease Right</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumAmortizationofLeaseRight' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercAmortizationofLeaseRight' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1048' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Depreciation <span id='spg' class='ppk' onclick='minitb('g');'>+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumDepreciation' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercDepreciation' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1049' runat='server'/></td></tr>")
        sb.Append("<tr id='g1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Short Lease Building</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumDepreciationofShortLeaseBuilding' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercDepreciationofShortLeaseBuilding' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1050' runat='server'/></td></tr>")
        sb.Append("<tr id='g2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Computer Hardware</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumDepreciationofComputerHardware' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercDepreciationofComputerHardware' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1051' runat='server'/></td></tr>")
        sb.Append("<tr id='g3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Fixtures & Fittings</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumDepreciationofFixturesFittings' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercDepreciationofFixturesFittings' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1052' runat='server'/></td></tr>")
        sb.Append("<tr id='g4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Computer Software</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumDepreciationofComputerSoftware' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercDepreciationofComputerSoftware' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1053' runat='server'/></td></tr>")
        sb.Append("<tr id='g5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Office Equipment</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumDepreciationofOfficeEquipment' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercDepreciationofOfficeEquipment' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1054' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold' class='rbg3'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Other Store Costs <span id='sph' class='ppk' onclick='minitb('h');'>+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherStoreCosts' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherStoreCosts' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1055' runat='server'/></td></tr>")
        sb.Append("<tr id='h1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Service Charges and Other Fees</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumServiceChargesandOtherFees' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercServiceChargesandOtherFees' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1056' runat='server'/></td></tr>")
        sb.Append("<tr id='h2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Bank Charges</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumBankCharges' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercBankCharges' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1057' runat='server'/></td></tr>")
        sb.Append("<tr id='h3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cash Collection Charge</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumCashCollectionCharge' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercCashCollectionCharge' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1058' runat='server'/></td></tr>")
        sb.Append("<tr id='h4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cleaning</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumCleaning' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercCleaning' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1059' runat='server'/></td></tr>")
        sb.Append("<tr id='h5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Security Guards</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumSecurityGuards' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercSecurityGuards' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1060' runat='server'/></td></tr>")
        sb.Append("<tr id='h6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Carriage</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumCarriage' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercCarriage' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1061' runat='server'/></td></tr>")
        sb.Append("<tr id='h7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Licence Fees</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumLicenceFees' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercLicenceFees' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1062' runat='server'/></td></tr>")
        sb.Append("<tr id='h8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Services Charge</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherServicesCharge' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherServicesCharge' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1063' runat='server'/></td></tr>")
        sb.Append("<tr id='h9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Fees</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherFees' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherFees' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1064' runat='server'/></td></tr>")
        sb.Append("<tr id='h10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Utilities</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumUtilities' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercUtilities' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1065' runat='server'/></td></tr>")
        sb.Append("<tr id='h11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Water</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumWater' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercWater' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1066' runat='server'/></td></tr>")
        sb.Append("<tr id='h12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Gas/Electric</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumGas_Electric' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercGas_Electric' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1067' runat='server'/></td></tr>")
        sb.Append("<tr id='h13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Air Cond. - Addition</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumAirCond_Addition' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercAirCond_Addition' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1068' runat='server'/></td></tr>")
        sb.Append("<tr id='h14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Repair and Maintenance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumRepairandMaintenance' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercRepairandMaintenance' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1069' runat='server'/></td></tr>")
        sb.Append("<tr id='h15'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Other - Fix</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumRMOther_Fix' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercRMOther_Fix' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1070' runat='server'/></td></tr>")
        sb.Append("<tr id='h16'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Other - Unplan</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumRMOther_Unplan' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercRMOther_Unplan' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1071' runat='server'/></td></tr>")
        sb.Append("<tr id='h17'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Computer - Fix</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumRMComputer_Fix' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercRMComputer_Fix' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1072' runat='server'/></td></tr>")
        sb.Append("<tr id='h18'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Computer - Unplan</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumRMComputer_Unplan' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercRMComputer_Unplan' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1073' runat='server'/></td></tr>")
        sb.Append("<tr id='h19'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Professional Fee</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumProfessionalFee' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercProfessionalFee' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1074' runat='server'/></td></tr>")
        sb.Append("<tr id='h20'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Marketing Research</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumMarketingResearch' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercMarketingResearch' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1075' runat='server'/></td></tr>")
        sb.Append("<tr id='h21'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Fee</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherFee' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherFee' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1076' runat='server'/></td></tr>")
        sb.Append("<tr id='h22'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Equipment, Materail and Supplies</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumEquipment_MaterailandSupplies' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercEquipment_MaterailandSupplies' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1077' runat='server'/></td></tr>")
        sb.Append("<tr id='h23'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Printing and Stationery</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPrintingandStationery' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPrintingandStationery' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1078' runat='server'/></td></tr>")
        sb.Append("<tr id='h24'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Supplies Expenses</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumSuppliesExpenses' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercSuppliesExpenses' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1079' runat='server'/></td></tr>")
        sb.Append("<tr id='h25'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Equipment</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumEquipment' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercEquipment' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1080' runat='server'/></td></tr>")
        sb.Append("<tr id='h26'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shopfitting</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumShopfitting' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercShopfitting' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1081' runat='server'/></td></tr>")
        sb.Append("<tr id='h27'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Packaging and Other Material</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPackagingandOtherMaterial' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPackagingandOtherMaterial' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1082' runat='server'/></td></tr>")
        sb.Append("<tr id='h28'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Business Travel Expenses</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumBusinessTravelExpenses' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercBusinessTravelExpenses' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1083' runat='server'/></td></tr>")
        sb.Append("<tr id='h29'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Car Parking and Others</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumCarParkingandOthers' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercCarParkingandOthers' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1084' runat='server'/></td></tr>")
        sb.Append("<tr id='h30'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Travel</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumTravel' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercTravel' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1085' runat='server'/></td></tr>")
        sb.Append("<tr id='h31'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Accomodation</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumAccomodation' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercAccomodation' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1086' runat='server'/></td></tr>")
        sb.Append("<tr id='h32'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Meal and Entertainment</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumMealandEntertainment' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercMealandEntertainment' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1087' runat='server'/></td></tr>")
        sb.Append("<tr id='h33'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Insurance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumInsurance' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercInsurance' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1088' runat='server'/></td></tr>")
        sb.Append("<tr id='h34'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - All Risk Insurance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumAllRiskInsurance' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercAllRiskInsurance' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1089' runat='server'/></td></tr>")
        sb.Append("<tr id='h35'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Health and Life Insurance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumHealthandLifeInsurance' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercHealthandLifeInsurance' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1090' runat='server'/></td></tr>")
        sb.Append("<tr id='h36'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Penalty and Taxation</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPenaltyandTaxation' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPenaltyandTaxation' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1091' runat='server'/></td></tr>")
        sb.Append("<tr id='h37'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Taxation</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumTaxation' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercTaxation' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1092' runat='server'/></td></tr>")
        sb.Append("<tr id='h38'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Penalty</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPenalty' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPenalty' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1093' runat='server'/></td></tr>")
        sb.Append("<tr id='h39'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Related Staff Cost></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherRelatedStaffCost' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherRelatedStaffCost' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1094' runat='server'/></td></tr>")
        sb.Append("<tr id='h40'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Staff Conference and Training</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumStaffConferenceandTraining' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercStaffConferenceandTraining' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1095' runat='server'/></td></tr>")
        sb.Append("<tr id='h41'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Training</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumTraining' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercTraining' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1096' runat='server'/></td></tr>")
        sb.Append("<tr id='h42'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Communication</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumCommunication' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercCommunication' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1097' runat='server'/></td></tr>")
        sb.Append("<tr id='h43'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Telephone Calls/Faxes</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumTelephoneCalls_Faxes' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercTelephoneCalls_Faxes' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1098' runat='server'/></td></tr>")
        sb.Append("<tr id='h44'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Postage and Courier</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPostageandCourier' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPostageandCourier' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1099' runat='server'/></td></tr>")
        sb.Append("<tr id='h45'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Expenses</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumOtherExpenses' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercOtherExpenses' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1100' runat='server'/></td></tr>")
        sb.Append("<tr id='h46'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sample/Tester</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumSample_Tester' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercSample_Tester' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1101' runat='server'/></td></tr>")
        sb.Append("<tr id='h47'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Preopening Costs</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumPreopeningCosts' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercPreopeningCosts' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1102' runat='server'/></td></tr>")
        sb.Append("<tr id='h48'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Loss on Claim</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumLossonClaim' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercLossonClaim' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1103' runat='server'/></td></tr>")
        sb.Append("<tr id='h49'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cash Overtage/Shortage from sales</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumCashOvertage_Shortagefromsales' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercCashOvertage_Shortagefromsales' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1104' runat='server'/></td></tr>")
        sb.Append("<tr id='h50'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Miscellenous and Other</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID='LbSumMiscellenousandOther' runat='server' Text=''></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID='LbPercMiscellenousandOther' runat='server' Text=''></asp:Label>%</div></td><td align='right'><asp:Label ID='lblYoy1105' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Store Trading Profit / (Loss)</div></td><td align='right'><div style='width:110px'><asp:Label ID='LbSumStoreTradingProfit__Loss' runat='server' Text=''></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID='LbPercStoreTradingProfit__Loss' runat='server' Text=''></asp:Label>%</div></td><td align='right' class='rbg2'><asp:Label ID='lblYoy1106' runat='server'/></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Store Trading Profit Growth-YOY</div></td><td align='right'><div style='width:110px'><asp:Label ID='lblSTFGyoy' runat='server' Text=''></asp:Label></div></td><td align='right'><div style='width:65px;'></div></td><td align='right'></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Store Trading Profit Growth-LFL</div></td><td align='right'><div style='width:110px'><asp:Label ID='lblSTFGlfl' runat='server' Text=''></asp:Label></div></td><td align='right'><div style='width:65px;'></div></td><td align='right'></td></tr>")
        sb.Append("</table>")
        Return sb.ToString
    End Function
#End Region


#Region "New Function"
    Public Shared Sub getFormatToDDL(ddl As DropDownList)
        Dim sql As String = "select store_id,store_name  from store where store_other = 'N' order by store_name"
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(sql, strcon)
        Try
            da.Fill(dt)
            ddl.DataSource = dt
            ddl.DataValueField = "store_id"
            ddl.DataTextField = "store_name"
            ddl.DataBind()
            ddl.Items.Insert(0, New ListItem("-- All --", ""))
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
        End Try
    End Sub
#End Region

#Region "Currency"
    Public Shared Sub getCurrentcyToDDL(ddl As DropDownList)
        Dim sql As String = "select crc_name + ' - ' + crc_country as name,crc_name from currency"
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(sql, strcon)
        Try
            da.Fill(dt)
            ddl.DataSource = dt
            ddl.DataValueField = "crc_name"
            ddl.DataTextField = "name"
            ddl.DataBind()
            ddl.Items.Insert(0, New ListItem("THB - Thailand", ""))
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
        End Try
    End Sub

    Public Shared Function getCurrentcy() As DataTable

        Dim sql As String = "select * from currency"
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(sql, strcon)
        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
        End Try
    End Function

    Public Shared Function InsertCurrentcy(ByVal name As String, country As String, rate As Double) As Integer
        Try
            Dim con As New SqlConnection(strcon)
            Dim sql As String = String.Format("insert into currency(crc_name,crc_country,crc_rate) values (@crc_name,@crc_country,@crc_rate)")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@crc_name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@crc_country", SqlDbType.VarChar)
            parameter.Value = country
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@crc_rate", SqlDbType.Decimal)
            parameter.Value = rate
            cmd.Parameters.Add(parameter)

            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function InsertCurrentcyRate(ByVal name As String, rate As String(), year As Integer) As Integer
        Try
            Dim con As New SqlConnection(strcon)
            Dim sqlDel As String = "Delete from currency_rate where crc_name = '{0}' AND cr_year  = {1} AND cr_month between 4 and 12; " + _
                                   "Delete from currency_rate where crc_name = '{0}' AND cr_year  = {2} AND cr_month between 1 and 3; "
            Dim sqlInsert As String = "insert into currency_rate(crc_name,cr_rate,cr_month,cr_year) values (@crc_name,{2},{0},{1}); "
            Dim sql As String = ""
            For i = 1 To 12
                'Start Month 4 --> 3 next year
                If i < 10 Then
                    sql += String.Format(sqlInsert, i + 3, year, rate(i - 1))
                Else
                    sql += String.Format(sqlInsert, i - 9, year + 1, rate(i - 1))
                End If
            Next

            sqlDel = String.Format(sqlDel, name, year, year + 1)
            sql = sqlDel + sql

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@crc_name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function getCurrentcyByName(ByVal name As String) As DataTable

        Dim sql As String = "select * from currency  where crc_name = '" + name + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getCurrentcyRate(ByVal name As String, year As Integer, Optional tempRate As String = "") As DataTable

        Dim sql As String = String.Format("select RIGHT('00'+ cast(cr_month as varchar),2) + '/' + cast(cr_year as varchar) as cr_month ,cr_rate from currency_rate where crc_name='{0}' and ((cr_year={1} AND cr_month between 4 and 12) OR (cr_year={2} AND cr_month between 1 and 3)) order by cr_year asc,cast(cr_month as int) asc ", name, year, year + 1)

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            If Not tempRate = "" Then
                Dim dr As DataRow
                For index = 1 To 12
                    dr = dt.NewRow
                    If index < 10 Then
                        dr("cr_month") = Format((index + 3), "00") + "/" + year.ToString
                    Else
                        dr("cr_month") = Format((index - 9), "00") + "/" + (year + 1).ToString
                    End If
                    dr("cr_rate") = tempRate
                    dt.Rows.Add(dr)
                Next
            End If
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateCurrentcy(id As String, ByVal name As String, ByVal country As String, rate As Double) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update currency set crc_name=@crc_name,crc_country = @crc_country,crc_rate = @crc_rate where crc_name='" + id + "'")
            Dim cmd As New SqlCommand(sql, con)

            Dim parameter As New SqlParameter("@crc_name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@crc_country", SqlDbType.VarChar)
            parameter.Value = country
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@crc_rate", SqlDbType.Decimal)
            parameter.Value = rate
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function DelCurrencyById(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        'Delete 2 tables
        Dim sql As String = String.Format("Delete from currency where crc_name='{0}';Delete from currency_rate where crc_name = '{0}'", id)

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function DelCurrencyRate(ByVal name As String, year As Integer) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete from currency_rate where crc_name = '{0}' AND cr_year  = {1} AND cr_month between 4 and 12; " + _
                                  "Delete from currency_rate where crc_name = '{0}' AND cr_year  = {2} AND cr_month between 1 and 3;"
        sql = String.Format(sql, name, year, year + 1)

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Shared Function getRate(ByVal name As String, year As Integer, Optional mon As String = "") As DataTable

        Dim sql As String = String.Format("select crc_name,crc_rate,0 as cr_month,0 as cr_year from currency where crc_name = '{0}' UNION " & _
                                          "select * from (" & _
                                                "select crc_name,cr_rate,cr_month,cr_year from currency_rate " & _
                                                "where crc_name='{0}' and ((cr_year={1} AND cr_month between 4 and 12) OR (cr_year={2} AND cr_month between 1 and 3)) " & _
                                          ") as rate where cr_month = '{3}' or '{3}' = '' ", name, year, year + 1, mon)

        Dim da As New SqlDataAdapter(sql, strcon)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
            da.Dispose()
        End Try
    End Function
#End Region

#Region "Costcenter"
    Public Shared Function getCostcenter() As DataTable

        Dim sql As String = "select * from costcenter order by costcenter_code asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getCostcenterInReport() As DataTable

        Dim sql As String = "select costcenter_id,costcenter_code + ' ('+ costcenter_name+ ')' as con_name from costcenter order by costcenter_code asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getCostcenterBySearch(ByVal title As String, ByVal area As String, ByVal location As String, ByVal province As String, ByVal store As String) As DataTable
        Dim s_area As String = ""
        Dim s_location As String = ""
        Dim s_province As String = ""
        Dim s_title As String = ""
        Dim s_store As String = ""

        If area <> "0" And area IsNot Nothing Then
            s_area = " and cc.costcenter_areas ='" + area + "' "
        End If

        If location <> "0" And location IsNot Nothing Then
            s_location = " and cc.costcenter_location ='" + location + "' "
        End If

        If province <> "0" And province IsNot Nothing Then
            s_province = " and cc.costcenter_province ='" + province + "' "
        End If

        If store <> "0" And store IsNot Nothing Then
            s_store = " and cc.costcenter_store ='" + store + "' "
        End If

        Dim sql As String = "select * from costcenter cc,store st,location la,province pv,area ar,market mr where cc.costcenter_market = mr.market_id and cc.costcenter_store = st.store_id and cc.costcenter_areas = ar.area_id and cc.costcenter_location = la.location_id and cc.costcenter_province = pv.province_id and cc.costcenter_code LIKE '%'+'" + title + "'+'%' " + s_area + s_location + s_province + s_store + "order by CONVERT(varchar, cc.costcenter_code) desc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getCostcenterByDesc() As DataTable

        Dim sql As String = "select * from costcenter cc,store st,location la,province pv,area ar,market mr where cc.costcenter_market = mr.market_id and cc.costcenter_store = st.store_id and cc.costcenter_areas = ar.area_id and cc.costcenter_location = la.location_id and cc.costcenter_province = pv.province_id order by cc.costcenter_code desc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getCostcenterByid(ByVal id As String) As DataTable

        Dim sql As String = "select * from costcenter where costcenter_id=" + id

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getCostcenterByCode(ByVal code As String) As DataTable

        Dim sql As String = "select * from costcenter where costcenter_code='" + code + "'"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DelCostcenter(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete from costcenter where costcenter_id=" + id

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function InsertCostcenter(ByVal code As String, ByVal name As String, ByVal store As String, ByVal location As String, ByVal province As String, ByVal sale_area As String, ByVal total_area As String, ByVal opendt As String, ByVal area_id As String, ByVal blocked As String, ByVal market As String, ByVal remark As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into costcenter(costcenter_code,costcenter_name,costcenter_store,costcenter_total_area,costcenter_sale_area,costcenter_province,costcenter_location,costcenter_areas,costcenter_market,costcenter_opendt,costcenter_blockdt,costcenter_remark) values(@code,@name,@store,@total_area,@sale_area,@province,@location,@area_id,@market,'" + DateTime.ParseExact(opendt, ClsManage.formatDateTime, Nothing) + "',@blockdt,@remark)")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@code", SqlDbType.VarChar)
            parameter.Value = code
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@store", SqlDbType.VarChar)
            parameter.Value = store
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@location", SqlDbType.VarChar)
            parameter.Value = location
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@blocked", SqlDbType.VarChar)
            parameter.Value = blocked
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@province", SqlDbType.VarChar)
            parameter.Value = province
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@remark", SqlDbType.VarChar)
            parameter.Value = remark
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@market", SqlDbType.VarChar)
            parameter.Value = market
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@area_id", SqlDbType.VarChar)
            parameter.Value = area_id
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@sale_area", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(sale_area)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@total_area", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(total_area)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@blockdt", SqlDbType.DateTime)
            If blocked <> "" Then
                parameter.Value = DateTime.ParseExact(blocked, "M/yyyy", Nothing)
            Else
                parameter.Value = DBNull.Value
            End If

            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function UpdateCostcenter(ByVal id As String, ByRef code As String, ByVal name As String, ByVal store As String, ByVal location As String, ByVal province As String, ByVal sale_area As String, ByVal total_area As String, ByVal opendt As String, ByVal area_id As String, ByVal blocked As String, ByVal market As String, ByVal remark As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update costcenter set costcenter_code=@code,costcenter_name=@name,costcenter_store=@store,costcenter_total_area=@total_area,costcenter_sale_area=@sale_area,costcenter_province=@province,costcenter_location=@location,costcenter_areas=@area_id,costcenter_market=@market,costcenter_opendt='" + DateTime.ParseExact(opendt, ClsManage.formatDateTime, Nothing) + "',costcenter_blockdt=@blockdt,costcenter_remark=@remark where costcenter_id=" + id)

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@code", SqlDbType.VarChar)
            parameter.Value = code
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@store", SqlDbType.VarChar)
            parameter.Value = store
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@location", SqlDbType.VarChar)
            parameter.Value = location
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@area_id", SqlDbType.VarChar)
            parameter.Value = area_id
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@market", SqlDbType.VarChar)
            parameter.Value = market
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@province", SqlDbType.VarChar)
            parameter.Value = province
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@remark", SqlDbType.VarChar)
            parameter.Value = remark
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@sale_area", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(sale_area)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@total_area", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(total_area)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@blockdt", SqlDbType.DateTime)
            If blocked <> "" Then
                parameter.Value = DateTime.ParseExact(blocked, ClsManage.formatDateTime, Nothing)
            Else
                parameter.Value = DBNull.Value
            End If

            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "Month"
    Public Shared Function getMonthData() As DataTable

        Dim sql As String = "select month_time from mtd group by month_time order by month_time DESC"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DelMonthData(ByVal month As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete from mtd where month_time='" + month + "'"

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function getMonthBydate(ByVal data As String) As DataTable

        Dim sql As String = "select month_time from mtd where month_time=@data "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@data", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(data, ClsManage.formatDateTime, Nothing)
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

#Region "Store"
    Public Shared Function getStore() As DataTable

        Dim sql As String = "select * from store order by store_name asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getStoreById(ByVal id As String) As DataTable

        Dim sql As String = "select * from store where store_id='" + id + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getStoreByName() As DataTable

        Dim sql As String = "select * from store order by store_name asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DelStoreById(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete from store where store_id=" + id

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function getStoreByTime(ByVal years As String, ByVal mon As String) As DataTable

        Dim sql As String = "select count (*) as count_store from (select distinct ct.costcenter_store from mtd mt,costcenter ct where mt.costcenter_id = ct.costcenter_id and year(mt.month_time) = '" + years + "' and month(mt.month_time) = '" + mon + "') as ss"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertStore(ByVal name As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into store(store_name,store_other) values(@name,'N')")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function UpdateStore(ByVal id As String, ByVal name As String, ByVal other As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update store set store_name=@name,store_other=@other where store_id=" + id)

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@other", SqlDbType.VarChar)
            parameter.Value = other
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "Area"
    Public Shared Function getArea() As DataTable

        Dim sql As String = "select * from area order by CONVERT(INT, area_name) asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getAreaById(ByVal id As String) As DataTable

        Dim sql As String = "select * from area where area_id='" + id + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DelAreaById(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete area where area_id=" + id

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function InsertArea(ByVal name As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into area(area_name) values(@name)")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function UpdateArea(ByVal id As String, ByVal name As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update area set area_name=@name where area_id=" + id)

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "Temporary"

    Public Shared Function getTempcById(ByVal id As String) As DataTable

        Dim sql As String = "select * from tempc where tempc_costcenter_id='" + id + "' order by tempc_finish "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getTempcByTid(ByVal id As String) As DataTable

        Dim sql As String = "select * from tempc where tempc_id='" + id + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertTempc(ByVal id As String, ByVal start As String, ByVal finish As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into tempc(tempc_start,tempc_finish,tempc_costcenter_id) values(@start,@finish,'" + id + "')")

            Dim cmd As New SqlCommand(sql, con)

            Dim parameter = New SqlParameter("@start", SqlDbType.DateTime)
            If start <> "" Then
                parameter.Value = DateTime.ParseExact(start, ClsManage.formatDateTime, Nothing)
            Else
                parameter.Value = DBNull.Value
            End If
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@finish", SqlDbType.DateTime)
            If finish <> "" Then
                parameter.Value = DateTime.ParseExact(finish, ClsManage.formatDateTime, Nothing)
            Else
                parameter.Value = DBNull.Value
            End If
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function DelTempcById(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete tempc where tempc_id=" + id

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function UpdateTempc(ByVal id As String, ByVal start As String, ByVal finish As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update tempc set tempc_start=@start,tempc_finish=@finish where tempc_id=" + id)

            Dim cmd As New SqlCommand(sql, con)

            Dim parameter = New SqlParameter("@start", SqlDbType.DateTime)
            If start <> "" Then
                parameter.Value = DateTime.ParseExact(start, ClsManage.formatDateTime, Nothing)
            Else
                parameter.Value = DBNull.Value
            End If
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@finish", SqlDbType.DateTime)
            If finish <> "" Then
                parameter.Value = DateTime.ParseExact(finish, ClsManage.formatDateTime, Nothing)
            Else
                parameter.Value = DBNull.Value
            End If
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Market"
    Public Shared Function getMarket() As DataTable

        Dim sql As String = "select * from market order by market_id asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

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

#Region "Location"
    Public Shared Function getLocation() As DataTable

        Dim sql As String = "select * from location order by location_name asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getLocationById(ByVal id As String) As DataTable

        Dim sql As String = "select * from location where location_id='" + id + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DelLocationById(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete from location where location_id=" + id

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function InsertLocation(ByVal name As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into location(location_name) values(@name)")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function UpdateLocation(ByVal id As String, ByVal name As String, ByVal active As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update location set location_name=@name,location_active=@active where location_id=" + id)

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@active", SqlDbType.VarChar)
            parameter.Value = active
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Region"
    Public Shared Function getRegion() As DataTable

        Dim sql As String = "select * from region order by region_name asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getRegionById(ByVal id As String) As DataTable

        Dim sql As String = "select * from region where region_id='" + id + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DelRegionById(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete from region where region_id=" + id

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function InsertRegion(ByVal name As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into region(region_name) values(@name)")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function UpdateRegion(ByVal id As String, ByVal name As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update region set region_name=@name where region_id=" + id)

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)


            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Province"

    Public Shared Function getProvince() As DataTable

        Dim sql As String = "select * from province order by province_id asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getProvinceOname() As DataTable

        Dim sql As String = "select * from province order by province_name asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getProvinceById(ByVal id As String) As DataTable

        Dim sql As String = "select * from province where province_id='" + id + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DelProvinceById(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete from province where province_id=" + id

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function InsertProvince(ByVal name As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into province(province_name) values(@name)")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function UpdateProvince(ByVal id As String, ByVal name As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update province set province_name=@name where province_id=" + id)

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)


            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "mtd"
    Public Shared Function InsertMTD(ByVal costcenter_id As String, ByVal TotalRevenue As String, ByVal RETAIL_TESPIncome As String, ByVal OtherRevenue As String, ByVal CostofGoodSold As String, ByVal GrossProfit As String, ByVal GrossProfit_percent As String, ByVal MarginAdjustments As String, ByVal Shipping As String, ByVal StockLossandObsolescence As String, ByVal InventoryAdjustment_stock As String, ByVal InventoryAdjustment_damage As String, ByVal StockLoss_Provision As String, ByVal StockObsolescence_Provision As String, ByVal GWP As String, ByVal GWPs_Corporate As String, ByVal GWPs_Transferred As String, ByVal SellingCosts As String, ByVal Creditcardscommission As String, ByVal LabellingMaterial As String, ByVal OtherIncome_COSHFunding As String, ByVal OtherIncomeSupplier As String, ByVal AdjustedGrossMargin As String, ByVal SupplyChainCosts As String, ByVal TotalStoreExpenses As String, ByVal StoreLabourCosts As String, ByVal GrossPay As String, ByVal TemporaryStaffCosts As String, ByVal Allowance As String, ByVal Overtime As String, ByVal Licensefee As String, ByVal Bonuses_Incentives As String, ByVal BootsBrandncentives As String, ByVal SuppliersIncentive As String, ByVal ProvidentFund As String, ByVal PensionCosts As String, ByVal SocialSecurityFund As String, ByVal Uniforms As String, ByVal EmployeeWelfare As String, ByVal OtherBenefitsEmployee As String, ByVal StorePropertyCosts As String, ByVal PropertyRental As String, ByVal PropertyServices As String, ByVal PropertyFacility As String, ByVal Propertytaxes As String, ByVal Facialtaxes As String, ByVal PropertyInsurance As String, ByVal Signboard As String, ByVal Discount_Rent_Services_Facility As String, ByVal GPCommission As String, ByVal AmortizationofLeaseRight As String, ByVal Depreciation As String, ByVal DepreciationofShortLeaseBuilding As String, ByVal DepreciationofComputerHardware As String, ByVal DepreciationofFixturesFittings As String, ByVal DepreciationofComputerSoftware As String, ByVal DepreciationofOfficeEquipment As String, ByVal OtherStoreCosts As String, ByVal ServiceChargesandOtherFees As String, ByVal BankCharges As String, ByVal CashCollectionCharge As String, ByVal Cleaning As String, ByVal SecurityGuards As String, ByVal Carriage As String, ByVal LicenceFees As String, ByVal OtherServicesCharge As String, ByVal OtherFees As String, ByVal Utilities As String, ByVal Water As String, ByVal Gas_Electric As String, ByVal AirCond_Addition As String, ByVal RepairandMaintenance As String, ByVal RMOther_Fix As String, ByVal RMOther_Unplan As String, ByVal RMComputer_Fix As String, ByVal RMComputer_Unplan As String, ByVal ProfessionalFee As String, ByVal MarketingResearch As String, ByVal OtherFee As String, ByVal Equipment_MaterailandSupplies As String, ByVal PrintingandStationery As String, ByVal SuppliesExpenses As String, ByVal Equipment As String, ByVal Shopfitting As String, ByVal PackagingandOtherMaterial As String, ByVal BusinessTravelExpenses As String, ByVal CarParkingandOthers As String, ByVal Travel As String, ByVal Accomodation As String, ByVal MealandEntertainment As String, ByVal Insurance As String, ByVal AllRiskInsurance As String, ByVal HealthandLifeInsurance As String, ByVal PenaltyandTaxation As String, ByVal Taxation As String, ByVal Penalty As String, ByVal OtherRelatedStaffCost As String, ByVal StaffConferenceandTraining As String, ByVal Training As String, ByVal Communication As String, ByVal TelephoneCalls_Faxes As String, ByVal PostageandCourier As String, ByVal OtherExpenses As String, ByVal Sample_Tester As String, ByVal PreopeningCosts As String, ByVal LossonClaim As String, ByVal CashOvertage_Shortagefromsales As String, ByVal MiscellenousandOther As String, ByVal StoreTradingProfit__Loss As String, ByVal TradingProfit__Loss As String, ByVal StoreControllableCostsforBSC As String, ByVal StoreLabourCost As String, ByVal Utillity As String, ByVal RepairMaintenance As String, SWMaintenance As String, HWMaintenance As String, ITTelecommunications As String, ByVal month_time As DateTime) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("INSERT INTO mtd(costcenter_id,TotalRevenue,RETAIL_TESPIncome,OtherRevenue,CostofGoodSold,GrossProfit" & _
                                              ",GrossProfit_percent,MarginAdjustments,Shipping,StockLossandObsolescence,InventoryAdjustment_stock," & _
                                              "InventoryAdjustment_damage,StockLoss_Provision,StockObsolescence_Provision,GWP,GWPs_Corporate,GWPs_Transferred" & _
                                              ",SellingCosts,Creditcardscommission,LabellingMaterial,OtherIncome_COSHFunding,OtherIncomeSupplier,AdjustedGrossMargin" & _
                                              ",SupplyChainCosts,TotalStoreExpenses,StoreLabourCosts,GrossPay,TemporaryStaffCosts,Allowance,Overtime,Licensefee," & _
                                              "Bonuses_Incentives,BootsBrandncentives,SuppliersIncentive,ProvidentFund,PensionCosts,SocialSecurityFund,Uniforms," & _
                                              "EmployeeWelfare,OtherBenefitsEmployee,StorePropertyCosts,PropertyRental,PropertyServices,PropertyFacility,Propertytaxes," & _
                                              "Facialtaxes,PropertyInsurance,Signboard,Discount_Rent_Services_Facility,GPCommission,AmortizationofLeaseRight," & _
                                              "Depreciation,DepreciationofShortLeaseBuilding,DepreciationofComputerHardware,DepreciationofFixturesFittings," & _
                                              "DepreciationofComputerSoftware,DepreciationofOfficeEquipment,OtherStoreCosts,ServiceChargesandOtherFees,BankCharges" & _
                                              ",CashCollectionCharge,Cleaning,SecurityGuards,Carriage,LicenceFees,OtherServicesCharge,OtherFees,Utilities,Water" & _
                                              ",Gas_Electric,AirCond_Addition,RepairandMaintenance,RMOther_Fix,RMOther_Unplan,RMComputer_Fix,RMComputer_Unplan" & _
                                              ",ProfessionalFee,MarketingResearch,OtherFee,Equipment_MaterailandSupplies,PrintingandStationery,SuppliesExpenses" & _
                                              ",Equipment,Shopfitting,PackagingandOtherMaterial,BusinessTravelExpenses,CarParkingandOthers,Travel,Accomodation" & _
                                              ",MealandEntertainment,Insurance,AllRiskInsurance,HealthandLifeInsurance,PenaltyandTaxation,Taxation,Penalty," & _
                                              "OtherRelatedStaffCost,StaffConferenceandTraining,Training,Communication,TelephoneCalls_Faxes,PostageandCourier," & _
                                              "OtherExpenses,Sample_Tester,PreopeningCosts,LossonClaim,CashOvertage_Shortagefromsales,MiscellenousandOther," & _
                                              "StoreTradingProfit__Loss,TradingProfit__Loss,StoreControllableCostsforBSC,StoreLabourCost,Utillity,RepairMaintenance," & _
                                              "SWMaintenance,HWMaintenance,ITTelecommunications" & _
                                              ",month_time) VALUES('" + costcenter_id + "',@TotalRevenue,@RETAIL_TESPIncome,@OtherRevenue,@CostofGoodSold,@GrossProfit," & _
                                              "@GrossProfit_percent,@MarginAdjustments,@Shipping,@StockLossandObsolescence,@InventoryAdjustment_stock," & _
                                              "@InventoryAdjustment_damage,@StockLoss_Provision,@StockObsolescence_Provision,@GWP,@GWPs_Corporate,@GWPs_Transferred" & _
                                              ",@SellingCosts,@Creditcardscommission,@LabellingMaterial,@OtherIncome_COSHFunding,@OtherIncomeSupplier," & _
                                              "@AdjustedGrossMargin,@SupplyChainCosts,@TotalStoreExpenses,@StoreLabourCosts,@GrossPay,@TemporaryStaffCosts," & _
                                              "@Allowance,@Overtime,@Licensefee,@Bonuses_Incentives,@BootsBrandncentives,@SuppliersIncentive,@ProvidentFund," & _
                                              "@PensionCosts,@SocialSecurityFund,@Uniforms,@EmployeeWelfare,@OtherBenefitsEmployee,@StorePropertyCosts," & _
                                              "@PropertyRental,@PropertyServices,@PropertyFacility,@Propertytaxes,@Facialtaxes,@PropertyInsurance,@Signboard," & _
                                              "@Discount_Rent_Services_Facility,@GPCommission,@AmortizationofLeaseRight,@Depreciation,@DepreciationofShortLeaseBuilding," & _
                                              "@DepreciationofComputerHardware,@DepreciationofFixturesFittings,@DepreciationofComputerSoftware," & _
                                              "@DepreciationofOfficeEquipment,@OtherStoreCosts,@ServiceChargesandOtherFees,@BankCharges,@CashCollectionCharge," & _
                                              "@Cleaning,@SecurityGuards,@Carriage,@LicenceFees,@OtherServicesCharge,@OtherFees,@Utilities,@Water,@Gas_Electric," & _
                                              "@AirCond_Addition,@RepairandMaintenance,@RMOther_Fix,@RMOther_Unplan,@RMComputer_Fix,@RMComputer_Unplan," & _
                                              "@ProfessionalFee,@MarketingResearch,@OtherFee,@Equipment_MaterailandSupplies,@PrintingandStationery,@SuppliesExpenses," & _
                                              "@Equipment,@Shopfitting,@PackagingandOtherMaterial,@BusinessTravelExpenses,@CarParkingandOthers,@Travel,@Accomodation," & _
                                              "@MealandEntertainment,@Insurance,@AllRiskInsurance,@HealthandLifeInsurance,@PenaltyandTaxation,@Taxation,@Penalty," & _
                                              "@OtherRelatedStaffCost,@StaffConferenceandTraining,@Training,@Communication,@TelephoneCalls_Faxes,@PostageandCourier," & _
                                              "@OtherExpenses,@Sample_Tester,@PreopeningCosts,@LossonClaim,@CashOvertage_Shortagefromsales,@MiscellenousandOther," & _
                                              "@StoreTradingProfit__Loss,@TradingProfit__Loss,@StoreControllableCostsforBSC,@StoreLabourCost,@Utillity,@RepairMaintenance," & _
                                              "@SWMaintenance,@HWMaintenance,@ITTelecommunications," & _
                                              "'" + DateTime.ParseExact(month_time, ClsManage.formatDateTime, Nothing) + "')")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@TotalRevenue", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(TotalRevenue)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RETAIL_TESPIncome", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RETAIL_TESPIncome)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherRevenue", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherRevenue)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@CostofGoodSold", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(CostofGoodSold)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GrossProfit", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GrossProfit)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GrossProfit_percent", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Percent(GrossProfit_percent)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@MarginAdjustments", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(MarginAdjustments)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Shipping", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Shipping)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StockLossandObsolescence", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StockLossandObsolescence)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@InventoryAdjustment_stock", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(InventoryAdjustment_stock)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@InventoryAdjustment_damage", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(InventoryAdjustment_damage)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StockLoss_Provision", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StockLoss_Provision)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StockObsolescence_Provision", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StockObsolescence_Provision)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GWP", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GWP)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GWPs_Corporate", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GWPs_Corporate)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GWPs_Transferred", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GWPs_Transferred)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SellingCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SellingCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Creditcardscommission", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Creditcardscommission)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@LabellingMaterial", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(LabellingMaterial)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherIncome_COSHFunding", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherIncome_COSHFunding)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherIncomeSupplier", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherIncomeSupplier)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@AdjustedGrossMargin", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(AdjustedGrossMargin)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SupplyChainCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SupplyChainCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@TotalStoreExpenses", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(TotalStoreExpenses)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StoreLabourCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StoreLabourCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GrossPay", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GrossPay)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@TemporaryStaffCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(TemporaryStaffCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Allowance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Allowance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Overtime", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Overtime)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Licensefee", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Licensefee)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Bonuses_Incentives", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Bonuses_Incentives)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@BootsBrandncentives", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(BootsBrandncentives)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SuppliersIncentive", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SuppliersIncentive)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@ProvidentFund", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(ProvidentFund)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PensionCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PensionCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SocialSecurityFund", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SocialSecurityFund)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Uniforms", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Uniforms)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@EmployeeWelfare", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(EmployeeWelfare)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherBenefitsEmployee", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherBenefitsEmployee)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StorePropertyCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StorePropertyCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PropertyRental", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PropertyRental)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PropertyServices", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PropertyServices)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PropertyFacility", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PropertyFacility)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Propertytaxes", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Propertytaxes)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Facialtaxes", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Facialtaxes)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PropertyInsurance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PropertyInsurance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Signboard", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Signboard)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Discount_Rent_Services_Facility", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Discount_Rent_Services_Facility)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GPCommission", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GPCommission)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@AmortizationofLeaseRight", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(AmortizationofLeaseRight)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Depreciation", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Depreciation)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofShortLeaseBuilding", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofShortLeaseBuilding)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofComputerHardware", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofComputerHardware)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofFixturesFittings", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofFixturesFittings)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofComputerSoftware", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofComputerSoftware)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofOfficeEquipment", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofOfficeEquipment)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherStoreCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherStoreCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@ServiceChargesandOtherFees", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(ServiceChargesandOtherFees)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@BankCharges", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(BankCharges)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@CashCollectionCharge", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(CashCollectionCharge)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Cleaning", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Cleaning)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SecurityGuards", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SecurityGuards)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Carriage", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Carriage)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@LicenceFees", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(LicenceFees)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherServicesCharge", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherServicesCharge)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherFees", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherFees)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Utilities", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Utilities)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Water", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Water)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Gas_Electric", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Gas_Electric)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@AirCond_Addition", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(AirCond_Addition)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RepairandMaintenance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RepairandMaintenance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RMOther_Fix", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RMOther_Fix)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RMOther_Unplan", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RMOther_Unplan)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RMComputer_Fix", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RMComputer_Fix)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RMComputer_Unplan", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RMComputer_Unplan)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@ProfessionalFee", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(ProfessionalFee)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@MarketingResearch", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(MarketingResearch)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherFee", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherFee)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Equipment_MaterailandSupplies", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Equipment_MaterailandSupplies)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PrintingandStationery", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PrintingandStationery)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SuppliesExpenses", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SuppliesExpenses)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Equipment", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Equipment)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Shopfitting", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Shopfitting)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PackagingandOtherMaterial", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PackagingandOtherMaterial)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@BusinessTravelExpenses", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(BusinessTravelExpenses)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@CarParkingandOthers", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(CarParkingandOthers)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Travel", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Travel)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Accomodation", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Accomodation)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@MealandEntertainment", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(MealandEntertainment)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Insurance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Insurance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@AllRiskInsurance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(AllRiskInsurance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@HealthandLifeInsurance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(HealthandLifeInsurance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PenaltyandTaxation", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PenaltyandTaxation)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Taxation", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Taxation)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Penalty", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Penalty)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherRelatedStaffCost", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherRelatedStaffCost)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StaffConferenceandTraining", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StaffConferenceandTraining)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Training", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Training)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Communication", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Communication)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@TelephoneCalls_Faxes", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(TelephoneCalls_Faxes)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PostageandCourier", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PostageandCourier)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherExpenses", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherExpenses)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Sample_Tester", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Sample_Tester)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PreopeningCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PreopeningCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@LossonClaim", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(LossonClaim)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@CashOvertage_Shortagefromsales", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(CashOvertage_Shortagefromsales)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@MiscellenousandOther", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(MiscellenousandOther)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StoreTradingProfit__Loss", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StoreTradingProfit__Loss)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@TradingProfit__Loss", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Percent(TradingProfit__Loss)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StoreControllableCostsforBSC", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StoreControllableCostsforBSC)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StoreLabourCost", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StoreLabourCost)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Utillity", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Utillity)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RepairMaintenance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RepairMaintenance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SWMaintenance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SWMaintenance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@HWMaintenance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(HWMaintenance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@ITTelecommunications", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(ITTelecommunications)
            cmd.Parameters.Add(parameter)


            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function InsertYTD(ByVal costcenter_id As String, ByVal TotalRevenue As String, ByVal RETAIL_TESPIncome As String, ByVal OtherRevenue As String, ByVal CostofGoodSold As String, ByVal GrossProfit As String, ByVal GrossProfit_percent As String, ByVal MarginAdjustments As String, ByVal Shipping As String, ByVal StockLossandObsolescence As String, ByVal InventoryAdjustment_stock As String, ByVal InventoryAdjustment_damage As String, ByVal StockLoss_Provision As String, ByVal StockObsolescence_Provision As String, ByVal GWP As String, ByVal GWPs_Corporate As String, ByVal GWPs_Transferred As String, ByVal SellingCosts As String, ByVal Creditcardscommission As String, ByVal LabellingMaterial As String, ByVal OtherIncome_COSHFunding As String, ByVal OtherIncomeSupplier As String, ByVal AdjustedGrossMargin As String, ByVal SupplyChainCosts As String, ByVal TotalStoreExpenses As String, ByVal StoreLabourCosts As String, ByVal GrossPay As String, ByVal TemporaryStaffCosts As String, ByVal Allowance As String, ByVal Overtime As String, ByVal Licensefee As String, ByVal Bonuses_Incentives As String, ByVal BootsBrandncentives As String, ByVal SuppliersIncentive As String, ByVal ProvidentFund As String, ByVal PensionCosts As String, ByVal SocialSecurityFund As String, ByVal Uniforms As String, ByVal EmployeeWelfare As String, ByVal OtherBenefitsEmployee As String, ByVal StorePropertyCosts As String, ByVal PropertyRental As String, ByVal PropertyServices As String, ByVal PropertyFacility As String, ByVal Propertytaxes As String, ByVal Facialtaxes As String, ByVal PropertyInsurance As String, ByVal Signboard As String, ByVal Discount_Rent_Services_Facility As String, ByVal GPCommission As String, ByVal AmortizationofLeaseRight As String, ByVal Depreciation As String, ByVal DepreciationofShortLeaseBuilding As String, ByVal DepreciationofComputerHardware As String, ByVal DepreciationofFixturesFittings As String, ByVal DepreciationofComputerSoftware As String, ByVal DepreciationofOfficeEquipment As String, ByVal OtherStoreCosts As String, ByVal ServiceChargesandOtherFees As String, ByVal BankCharges As String, ByVal CashCollectionCharge As String, ByVal Cleaning As String, ByVal SecurityGuards As String, ByVal Carriage As String, ByVal LicenceFees As String, ByVal OtherServicesCharge As String, ByVal OtherFees As String, ByVal Utilities As String, ByVal Water As String, ByVal Gas_Electric As String, ByVal AirCond_Addition As String, ByVal RepairandMaintenance As String, ByVal RMOther_Fix As String, ByVal RMOther_Unplan As String, ByVal RMComputer_Fix As String, ByVal RMComputer_Unplan As String, ByVal ProfessionalFee As String, ByVal MarketingResearch As String, ByVal OtherFee As String, ByVal Equipment_MaterailandSupplies As String, ByVal PrintingandStationery As String, ByVal SuppliesExpenses As String, ByVal Equipment As String, ByVal Shopfitting As String, ByVal PackagingandOtherMaterial As String, ByVal BusinessTravelExpenses As String, ByVal CarParkingandOthers As String, ByVal Travel As String, ByVal Accomodation As String, ByVal MealandEntertainment As String, ByVal Insurance As String, ByVal AllRiskInsurance As String, ByVal HealthandLifeInsurance As String, ByVal PenaltyandTaxation As String, ByVal Taxation As String, ByVal Penalty As String, ByVal OtherRelatedStaffCost As String, ByVal StaffConferenceandTraining As String, ByVal Training As String, ByVal Communication As String, ByVal TelephoneCalls_Faxes As String, ByVal PostageandCourier As String, ByVal OtherExpenses As String, ByVal Sample_Tester As String, ByVal PreopeningCosts As String, ByVal LossonClaim As String, ByVal CashOvertage_Shortagefromsales As String, ByVal MiscellenousandOther As String, ByVal StoreTradingProfit__Loss As String, ByVal TradingProfit__Loss As String, ByVal StoreControllableCostsforBSC As String, ByVal StoreLabourCost As String, ByVal Utillity As String, ByVal RepairMaintenance As String, ByVal month_time As DateTime) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("INSERT INTO ytd(costcenter_id,TotalRevenue,RETAIL_TESPIncome,OtherRevenue,CostofGoodSold,GrossProfit" & _
                                              ",GrossProfit_percent,MarginAdjustments,Shipping,StockLossandObsolescence,InventoryAdjustment_stock," & _
                                              "InventoryAdjustment_damage,StockLoss_Provision,StockObsolescence_Provision,GWP,GWPs_Corporate,GWPs_Transferred" & _
                                              ",SellingCosts,Creditcardscommission,LabellingMaterial,OtherIncome_COSHFunding,OtherIncomeSupplier,AdjustedGrossMargin" & _
                                              ",SupplyChainCosts,TotalStoreExpenses,StoreLabourCosts,GrossPay,TemporaryStaffCosts,Allowance,Overtime,Licensefee," & _
                                              "Bonuses_Incentives,BootsBrandncentives,SuppliersIncentive,ProvidentFund,PensionCosts,SocialSecurityFund,Uniforms," & _
                                              "EmployeeWelfare,OtherBenefitsEmployee,StorePropertyCosts,PropertyRental,PropertyServices,PropertyFacility,Propertytaxes," & _
                                              "Facialtaxes,PropertyInsurance,Signboard,Discount_Rent_Services_Facility,GPCommission,AmortizationofLeaseRight," & _
                                              "Depreciation,DepreciationofShortLeaseBuilding,DepreciationofComputerHardware,DepreciationofFixturesFittings," & _
                                              "DepreciationofComputerSoftware,DepreciationofOfficeEquipment,OtherStoreCosts,ServiceChargesandOtherFees,BankCharges" & _
                                              ",CashCollectionCharge,Cleaning,SecurityGuards,Carriage,LicenceFees,OtherServicesCharge,OtherFees,Utilities,Water" & _
                                              ",Gas_Electric,AirCond_Addition,RepairandMaintenance,RMOther_Fix,RMOther_Unplan,RMComputer_Fix,RMComputer_Unplan" & _
                                              ",ProfessionalFee,MarketingResearch,OtherFee,Equipment_MaterailandSupplies,PrintingandStationery,SuppliesExpenses" & _
                                              ",Equipment,Shopfitting,PackagingandOtherMaterial,BusinessTravelExpenses,CarParkingandOthers,Travel,Accomodation" & _
                                              ",MealandEntertainment,Insurance,AllRiskInsurance,HealthandLifeInsurance,PenaltyandTaxation,Taxation,Penalty," & _
                                              "OtherRelatedStaffCost,StaffConferenceandTraining,Training,Communication,TelephoneCalls_Faxes,PostageandCourier," & _
                                              "OtherExpenses,Sample_Tester,PreopeningCosts,LossonClaim,CashOvertage_Shortagefromsales,MiscellenousandOther," & _
                                              "StoreTradingProfit__Loss,TradingProfit__Loss,StoreControllableCostsforBSC,StoreLabourCost,Utillity,RepairMaintenance" & _
                                              ",month_time) VALUES('" + costcenter_id + "',@TotalRevenue,@RETAIL_TESPIncome,@OtherRevenue,@CostofGoodSold,@GrossProfit," & _
                                              "@GrossProfit_percent,@MarginAdjustments,@Shipping,@StockLossandObsolescence,@InventoryAdjustment_stock," & _
                                              "@InventoryAdjustment_damage,@StockLoss_Provision,@StockObsolescence_Provision,@GWP,@GWPs_Corporate,@GWPs_Transferred" & _
                                              ",@SellingCosts,@Creditcardscommission,@LabellingMaterial,@OtherIncome_COSHFunding,@OtherIncomeSupplier," & _
                                              "@AdjustedGrossMargin,@SupplyChainCosts,@TotalStoreExpenses,@StoreLabourCosts,@GrossPay,@TemporaryStaffCosts," & _
                                              "@Allowance,@Overtime,@Licensefee,@Bonuses_Incentives,@BootsBrandncentives,@SuppliersIncentive,@ProvidentFund," & _
                                              "@PensionCosts,@SocialSecurityFund,@Uniforms,@EmployeeWelfare,@OtherBenefitsEmployee,@StorePropertyCosts," & _
                                              "@PropertyRental,@PropertyServices,@PropertyFacility,@Propertytaxes,@Facialtaxes,@PropertyInsurance,@Signboard," & _
                                              "@Discount_Rent_Services_Facility,@GPCommission,@AmortizationofLeaseRight,@Depreciation,@DepreciationofShortLeaseBuilding," & _
                                              "@DepreciationofComputerHardware,@DepreciationofFixturesFittings,@DepreciationofComputerSoftware," & _
                                              "@DepreciationofOfficeEquipment,@OtherStoreCosts,@ServiceChargesandOtherFees,@BankCharges,@CashCollectionCharge," & _
                                              "@Cleaning,@SecurityGuards,@Carriage,@LicenceFees,@OtherServicesCharge,@OtherFees,@Utilities,@Water,@Gas_Electric," & _
                                              "@AirCond_Addition,@RepairandMaintenance,@RMOther_Fix,@RMOther_Unplan,@RMComputer_Fix,@RMComputer_Unplan," & _
                                              "@ProfessionalFee,@MarketingResearch,@OtherFee,@Equipment_MaterailandSupplies,@PrintingandStationery,@SuppliesExpenses," & _
                                              "@Equipment,@Shopfitting,@PackagingandOtherMaterial,@BusinessTravelExpenses,@CarParkingandOthers,@Travel,@Accomodation," & _
                                              "@MealandEntertainment,@Insurance,@AllRiskInsurance,@HealthandLifeInsurance,@PenaltyandTaxation,@Taxation,@Penalty," & _
                                              "@OtherRelatedStaffCost,@StaffConferenceandTraining,@Training,@Communication,@TelephoneCalls_Faxes,@PostageandCourier," & _
                                              "@OtherExpenses,@Sample_Tester,@PreopeningCosts,@LossonClaim,@CashOvertage_Shortagefromsales,@MiscellenousandOther," & _
                                              "@StoreTradingProfit__Loss,@TradingProfit__Loss,@StoreControllableCostsforBSC,@StoreLabourCost,@Utillity,@RepairMaintenance" & _
                                              ",'" + DateTime.ParseExact(month_time, ClsManage.formatDateTime, Nothing) + "')")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@TotalRevenue", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(TotalRevenue)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RETAIL_TESPIncome", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RETAIL_TESPIncome)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherRevenue", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherRevenue)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@CostofGoodSold", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(CostofGoodSold)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GrossProfit", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GrossProfit)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GrossProfit_percent", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Percent(GrossProfit_percent)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@MarginAdjustments", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(MarginAdjustments)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Shipping", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Shipping)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StockLossandObsolescence", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StockLossandObsolescence)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@InventoryAdjustment_stock", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(InventoryAdjustment_stock)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@InventoryAdjustment_damage", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(InventoryAdjustment_damage)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StockLoss_Provision", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StockLoss_Provision)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StockObsolescence_Provision", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StockObsolescence_Provision)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GWP", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GWP)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GWPs_Corporate", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GWPs_Corporate)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GWPs_Transferred", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GWPs_Transferred)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SellingCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SellingCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Creditcardscommission", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Creditcardscommission)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@LabellingMaterial", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(LabellingMaterial)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherIncome_COSHFunding", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherIncome_COSHFunding)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherIncomeSupplier", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherIncomeSupplier)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@AdjustedGrossMargin", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(AdjustedGrossMargin)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SupplyChainCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SupplyChainCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@TotalStoreExpenses", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(TotalStoreExpenses)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StoreLabourCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StoreLabourCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GrossPay", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GrossPay)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@TemporaryStaffCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(TemporaryStaffCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Allowance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Allowance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Overtime", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Overtime)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Licensefee", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Licensefee)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Bonuses_Incentives", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Bonuses_Incentives)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@BootsBrandncentives", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(BootsBrandncentives)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SuppliersIncentive", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SuppliersIncentive)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@ProvidentFund", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(ProvidentFund)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PensionCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PensionCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SocialSecurityFund", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SocialSecurityFund)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Uniforms", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Uniforms)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@EmployeeWelfare", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(EmployeeWelfare)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherBenefitsEmployee", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherBenefitsEmployee)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StorePropertyCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StorePropertyCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PropertyRental", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PropertyRental)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PropertyServices", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PropertyServices)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PropertyFacility", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PropertyFacility)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Propertytaxes", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Propertytaxes)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Facialtaxes", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Facialtaxes)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PropertyInsurance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PropertyInsurance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Signboard", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Signboard)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Discount_Rent_Services_Facility", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Discount_Rent_Services_Facility)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@GPCommission", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(GPCommission)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@AmortizationofLeaseRight", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(AmortizationofLeaseRight)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Depreciation", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Depreciation)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofShortLeaseBuilding", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofShortLeaseBuilding)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofComputerHardware", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofComputerHardware)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofFixturesFittings", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofFixturesFittings)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofComputerSoftware", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofComputerSoftware)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@DepreciationofOfficeEquipment", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(DepreciationofOfficeEquipment)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherStoreCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherStoreCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@ServiceChargesandOtherFees", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(ServiceChargesandOtherFees)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@BankCharges", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(BankCharges)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@CashCollectionCharge", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(CashCollectionCharge)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Cleaning", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Cleaning)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SecurityGuards", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SecurityGuards)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Carriage", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Carriage)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@LicenceFees", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(LicenceFees)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherServicesCharge", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherServicesCharge)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherFees", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherFees)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Utilities", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Utilities)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Water", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Water)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Gas_Electric", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Gas_Electric)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@AirCond_Addition", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(AirCond_Addition)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RepairandMaintenance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RepairandMaintenance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RMOther_Fix", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RMOther_Fix)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RMOther_Unplan", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RMOther_Unplan)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RMComputer_Fix", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RMComputer_Fix)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RMComputer_Unplan", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RMComputer_Unplan)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@ProfessionalFee", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(ProfessionalFee)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@MarketingResearch", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(MarketingResearch)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherFee", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherFee)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Equipment_MaterailandSupplies", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Equipment_MaterailandSupplies)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PrintingandStationery", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PrintingandStationery)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@SuppliesExpenses", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(SuppliesExpenses)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Equipment", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Equipment)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Shopfitting", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Shopfitting)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PackagingandOtherMaterial", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PackagingandOtherMaterial)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@BusinessTravelExpenses", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(BusinessTravelExpenses)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@CarParkingandOthers", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(CarParkingandOthers)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Travel", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Travel)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Accomodation", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Accomodation)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@MealandEntertainment", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(MealandEntertainment)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Insurance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Insurance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@AllRiskInsurance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(AllRiskInsurance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@HealthandLifeInsurance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(HealthandLifeInsurance)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PenaltyandTaxation", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PenaltyandTaxation)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Taxation", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Taxation)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Penalty", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Penalty)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherRelatedStaffCost", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherRelatedStaffCost)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StaffConferenceandTraining", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StaffConferenceandTraining)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Training", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Training)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Communication", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Communication)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@TelephoneCalls_Faxes", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(TelephoneCalls_Faxes)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PostageandCourier", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PostageandCourier)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@OtherExpenses", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(OtherExpenses)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Sample_Tester", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Sample_Tester)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@PreopeningCosts", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(PreopeningCosts)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@LossonClaim", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(LossonClaim)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@CashOvertage_Shortagefromsales", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(CashOvertage_Shortagefromsales)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@MiscellenousandOther", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(MiscellenousandOther)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StoreTradingProfit__Loss", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StoreTradingProfit__Loss)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@TradingProfit__Loss", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Percent(TradingProfit__Loss)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StoreControllableCostsforBSC", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StoreControllableCostsforBSC)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@StoreLabourCost", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(StoreLabourCost)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@Utillity", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(Utillity)
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@RepairMaintenance", SqlDbType.Decimal)
            parameter.Value = ClsManage.convert2Currency(RepairMaintenance)
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "EXCEL"
    Public Shared Function GetFileExtension(ByVal FileName As String) As String
        Return FileName.Substring(InStrRev(FileName, "."), Len(FileName) - InStrRev(FileName, ".")).ToUpper
    End Function
    Public Shared Function IsExcel(ByVal FileName As String) As Boolean
        Select Case GetFileExtension(FileName).ToLower
            Case "xls", "xlsx"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Shared Function InsertLog(ByVal tmpfile As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into log_import(log_name,log_dt) values('files/excel/" + tmpfile + "',getdate())")

            Dim cmd As New SqlCommand(sql, con)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "Login"

    Public Shared Function getUserLogin(ByVal username As String, ByVal password As String) As DataTable

        Dim sql As String = "SELECT * " & _
                            " FROM  users " & _
                            " Where (users_name = @user_name) AND (users_pass=@password) "


        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Try
            Dim parameter As New SqlParameter("@user_name", SqlDbType.VarChar, 50)
            parameter.Value = username
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@password", SqlDbType.VarChar, 50)
            parameter.Value = password
            cmd.Parameters.Add(parameter)


            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Report"
    Public Shared Function getMtdModel() As DataTable

        Dim sql As String = "select distinct cc.costcenter_store as cost_store,st.store_name as store_name from mtd mt,costcenter cc,store st where mt.costcenter_id = cc.costcenter_id and cc.costcenter_store = st.store_id and year(month_time) = '2011' and month(month_time) = '11' order by cost_store asc "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getMtdYear() As DataTable

        Dim sql As String = "select distinct YEAR(month_time) as mon_year from mtd order by mon_year desc "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getMtdMonth(ByVal years As String) As DataTable

        Dim sql As String = "select distinct MONTH(month_time) as mon_year,DATENAME(month,month_time) as mon_name from mtd where YEAR(month_time)='" + years + "' order by mon_year desc "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getTest() As DataTable

        Dim sql As String = " select * from mtd mt,costcenter cc where mt.costcenter_id = cc.costcenter_id and cc.costcenter_blockdt = '1/2/2012'  and year(month_time) = '2012' and month(month_time) = '1'   "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
            End Try
    End Function

    Public Shared Function getSumMtdModel(ByVal years As String, ByVal mon As String, ByVal locate As String) As DataTable

        Dim area As String = ""

        If locate <> "ALL" And locate <> "TWO" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select * from (select costcenter_store,SUM(TotalRevenue) as sumtotal, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(RETAIL_TESPIncome) as sumretail, " & _
"SUM(OtherRevenue) as sumOtherRevenue, " & _
"SUM(CostofGoodSold) as sumCostofGoodSold, " & _
"SUM(GrossProfit) as sumGrossProfit, " & _
"SUM(MarginAdjustments) as sumMarginAdjustments, " & _
"SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as sumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as sumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as sumStoreLabourCosts, " & _
"SUM(StorePropertyCosts) as sumStorePropertyCosts, " & _
"SUM(Depreciation) as sumDepreciation, " & _
"SUM(OtherStoreCosts) as sumOtherStoreCosts, " & _
"SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss " & _
"from mtd mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt > @block_dt ) and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " + area + " " & _
"group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
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

    Public Shared Function getSumYtdModel(ByVal years As String, ByVal mon As String, ByVal locate As String, ByVal start_time As String) As DataTable

        Dim area As String = ""

        If locate <> "ALL" And locate <> "TWO" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select * from ( " & _
        "   select cs.costcenter_store,SUM(sumtotal) as sumtotal, " & _
        "	SUM(cs.costcenter_total_area) as sumtotalarea,  " & _
        "	SUM(cs.costcenter_sale_area) as sumsalearea,  " & _
        "	SUM(sumretail) as sumretail,  " & _
        "	SUM(sumOtherRevenue) as sumOtherRevenue,  " & _
        "	SUM(sumCostofGoodSold) as sumCostofGoodSold,  " & _
        "	SUM(sumGrossProfit) as sumGrossProfit,  " & _
        "	SUM(sumMarginAdjustments) as sumMarginAdjustments,  " & _
        "	SUM(sumAdjustedGrossMargin) as sumAdjustedGrossMargin,  " & _
        "	SUM(sumSupplyChainCosts) as sumSupplyChainCosts,  " & _
        "	SUM(sumTotalStoreExpenses) as sumTotalStoreExpenses,  " & _
        "	SUM(sumStoreLabourCosts) as sumStoreLabourCosts,  " & _
        "	SUM(sumStorePropertyCosts) as sumStorePropertyCosts,  " & _
        "	SUM(sumDepreciation) as sumDepreciation,  " & _
        "	SUM(sumOtherStoreCosts) as sumOtherStoreCosts, " & _
        "	SUM(sumStoreTradingProfit__Loss) as sumStoreTradingProfit__Loss  " & _
        "from ( " & _
        "select mt.costcenter_id,SUM(TotalRevenue) as sumtotal,  " & _
        "	SUM(costcenter_total_area) as sumtotalarea,  " & _
        "	SUM(costcenter_sale_area) as sumsalearea,  " & _
        "	SUM(RETAIL_TESPIncome) as sumretail,  " & _
        "	SUM(OtherRevenue) as sumOtherRevenue,  " & _
        "	SUM(CostofGoodSold) as sumCostofGoodSold,  " & _
        "	SUM(GrossProfit) as sumGrossProfit,  " & _
        "	SUM(MarginAdjustments) as sumMarginAdjustments,  " & _
        "	SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin,  " & _
        "	SUM(SupplyChainCosts) as sumSupplyChainCosts,  " & _
        "	SUM(TotalStoreExpenses) as sumTotalStoreExpenses,  " & _
        "	SUM(StoreLabourCosts) as sumStoreLabourCosts,  " & _
        "	SUM(StorePropertyCosts) as sumStorePropertyCosts,  " & _
        "	SUM(Depreciation) as sumDepreciation,  " & _
        "	SUM(OtherStoreCosts) as sumOtherStoreCosts,  " & _
        "	SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss  " & _
        "from ( " & _
        "select mta.* " & _
        "from mtd mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'   " & _
        " union " & _
        "select mtb.* " & _
        "from mtd mtb,costcenter ccb " & _
        "where mtb.costcenter_id = ccb.costcenter_id And " & _
        "ccb.costcenter_blockdt > @select_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'  " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id  " & _
        " " + area + " " & _
        "group by mt.costcenter_id " & _
        ") mt2,costcenter cs " & _
        "where mt2.costcenter_id = cs.costcenter_id " & _
        "group by cs.costcenter_store " & _
        ") bb,store st1 " & _
        "where bb.costcenter_store = st1.store_id "

        '        Dim sql As String = "select * from (select costcenter_store,SUM(TotalRevenue) as sumtotal, " & _
        '"SUM(costcenter_total_area) as sumtotalarea, " & _
        '"SUM(costcenter_sale_area) as sumsalearea, " & _
        '"SUM(RETAIL_TESPIncome) as sumretail, " & _
        '"SUM(OtherRevenue) as sumOtherRevenue, " & _
        '"SUM(CostofGoodSold) as sumCostofGoodSold, " & _
        '"SUM(GrossProfit) as sumGrossProfit, " & _
        '"SUM(MarginAdjustments) as sumMarginAdjustments, " & _
        '"SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin, " & _
        '"SUM(SupplyChainCosts) as sumSupplyChainCosts, " & _
        '"SUM(TotalStoreExpenses) as sumTotalStoreExpenses, " & _
        '"SUM(StoreLabourCosts) as sumStoreLabourCosts, " & _
        '"SUM(StorePropertyCosts) as sumStorePropertyCosts, " & _
        '"SUM(Depreciation) as sumDepreciation, " & _
        '"SUM(OtherStoreCosts) as sumOtherStoreCosts, " & _
        '"SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss " & _
        '"from mtd mt,costcenter cc " & _
        '"where mt.costcenter_id = cc.costcenter_id and cc.costcenter_blockdt <= '" + DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing) + "' and month_time <= '" + DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing) + "' and month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "' " + area + " " & _
        '"group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
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

    Public Shared Function getSumFullYtdModel(ByVal years As String, ByVal mon As String, ByVal locate As String, ByVal start_time As String, Optional rate As String = "") As DataTable

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        If locate <> "" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
        "   select  COUNT(DISTINCT cs.costcenter_id) as cnum, cs.costcenter_store, " & _
        "	SUM(cs.costcenter_total_area) as sumtotalarea,  " & _
        "	SUM(cs.costcenter_sale_area) as sumsalearea,  " & _
  "(SUM(SumTotalRevenue)/SUM(cs.costcenter_sale_area))/(DATEDIFF(month,@start_time,@select_dt)+1) as productivity, " & _
  "SUM(SumTotalRevenue) as SumTotalRevenue, " & _
  "SUM(SumRETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
  "SUM(SumOtherRevenue) as SumOtherRevenue, " & _
  "SUM(SumCostofGoodSold) as SumCostofGoodSold, " & _
  "SUM(SumGrossProfit) as SumGrossProfit, " & _
  "SUM(SumGrossProfit_percent) as SumGrossProfit_percent, " & _
  "SUM(SumMarginAdjustments) as SumMarginAdjustments, " & _
  "SUM(SumShipping) as SumShipping, " & _
  "SUM(SumStockLossandObsolescence) as SumStockLossandObsolescence, " & _
  "SUM(SumInventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
  "SUM(SumInventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
  "SUM(SumStockLoss_Provision) as SumStockLoss_Provision, " & _
  "SUM(SumStockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
  "SUM(SumGWP) as SumGWP, " & _
  "SUM(SumGWPs_Corporate) as SumGWPs_Corporate, " & _
  "SUM(SumGWPs_Transferred) as SumGWPs_Transferred, " & _
  "SUM(SumSellingCosts) as SumSellingCosts, " & _
  "SUM(SumCreditcardscommission) as SumCreditcardscommission, " & _
  "SUM(SumLabellingMaterial) as SumLabellingMaterial, " & _
  "SUM(SumOtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
  "SUM(SumOtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
  "SUM(SumAdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
  "SUM(SumSupplyChainCosts) as SumSupplyChainCosts, " & _
  "SUM(SumTotalStoreExpenses) as SumTotalStoreExpenses, " & _
  "SUM(SumStoreLabourCosts) as SumStoreLabourCosts, " & _
  "SUM(SumGrossPay) as SumGrossPay, " & _
  "SUM(SumTemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
  "SUM(SumAllowance) as SumAllowance, " & _
  "SUM(SumOvertime) as SumOvertime, " & _
  "SUM(SumLicensefee) as SumLicensefee, " & _
  "SUM(SumBonuses_Incentives) as SumBonuses_Incentives, " & _
  "SUM(SumBootsBrandncentives) as SumBootsBrandncentives, " & _
  "SUM(SumSuppliersIncentive) as SumSuppliersIncentive, " & _
  "SUM(SumProvidentFund) as SumProvidentFund, " & _
  "SUM(SumPensionCosts) as SumPensionCosts, " & _
  "SUM(SumSocialSecurityFund) as SumSocialSecurityFund, " & _
  "SUM(SumUniforms) as SumUniforms, " & _
  "SUM(SumEmployeeWelfare) as SumEmployeeWelfare, " & _
  "SUM(SumOtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
  "SUM(SumStorePropertyCosts) as SumStorePropertyCosts, " & _
  "SUM(SumPropertyRental) as SumPropertyRental, " & _
  "SUM(SumPropertyServices) as SumPropertyServices, " & _
  "SUM(SumPropertyFacility) as SumPropertyFacility, " & _
  "SUM(SumPropertytaxes) as SumPropertytaxes, " & _
  "SUM(SumFacialtaxes) as SumFacialtaxes, " & _
  "SUM(SumPropertyInsurance) as SumPropertyInsurance, " & _
  "SUM(SumSignboard) as SumSignboard, " & _
  "SUM(SumDiscount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
  "SUM(SumGPCommission) as SumGPCommission, " & _
  "SUM(SumAmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
  "SUM(SumDepreciation) as SumDepreciation, " & _
  "SUM(SumDepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
  "SUM(SumDepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
  "SUM(SumDepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
  "SUM(SumDepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
  "SUM(SumDepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
  "SUM(SumOtherStoreCosts) as SumOtherStoreCosts, " & _
  "SUM(SumServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
  "SUM(SumBankCharges) as SumBankCharges, " & _
  "SUM(SumCashCollectionCharge) as SumCashCollectionCharge, " & _
  "SUM(SumCleaning) as SumCleaning, " & _
  "SUM(SumSecurityGuards) as SumSecurityGuards, " & _
  "SUM(SumCarriage) as SumCarriage, " & _
  "SUM(SumLicenceFees) as SumLicenceFees, " & _
  "SUM(SumOtherServicesCharge) as SumOtherServicesCharge, " & _
  "SUM(SumOtherFees) as SumOtherFees, " & _
  "SUM(SumUtilities) as SumUtilities, " & _
  "SUM(SumWater) as SumWater, " & _
  "SUM(SumGas_Electric) as SumGas_Electric, " & _
  "SUM(SumAirCond_Addition) as SumAirCond_Addition, " & _
  "SUM(SumRepairandMaintenance) as SumRepairandMaintenance, " & _
  "SUM(SumRMOther_Fix) as SumRMOther_Fix, " & _
  "SUM(SumRMOther_Unplan) as SumRMOther_Unplan, " & _
  "SUM(SumRMComputer_Fix) as SumRMComputer_Fix, " & _
  "SUM(SumRMComputer_Unplan) as SumRMComputer_Unplan, " & _
  "SUM(SumProfessionalFee) as SumProfessionalFee, " & _
  "SUM(SumMarketingResearch) as SumMarketingResearch, " & _
  "SUM(SumOtherFee) as SumOtherFee, " & _
  "SUM(SumEquipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
  "SUM(SumPrintingandStationery) as SumPrintingandStationery, " & _
  "SUM(SumSuppliesExpenses) as SumSuppliesExpenses, " & _
  "SUM(SumEquipment) as SumEquipment, " & _
  "SUM(SumShopfitting) as SumShopfitting, " & _
  "SUM(SumPackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
  "SUM(SumBusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
  "SUM(SumCarParkingandOthers) as SumCarParkingandOthers, " & _
  "SUM(SumTravel) as SumTravel, " & _
  "SUM(SumAccomodation) as SumAccomodation, " & _
  "SUM(SumMealandEntertainment) as SumMealandEntertainment, " & _
  "SUM(SumInsurance) as SumInsurance, " & _
  "SUM(SumAllRiskInsurance) as SumAllRiskInsurance, " & _
  "SUM(SumHealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
  "SUM(SumPenaltyandTaxation) as SumPenaltyandTaxation, " & _
  "SUM(SumTaxation) as SumTaxation, " & _
  "SUM(SumPenalty) as SumPenalty, " & _
  "SUM(SumOtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
  "SUM(SumStaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
  "SUM(SumTraining) as SumTraining, " & _
  "SUM(SumCommunication) as SumCommunication, " & _
  "SUM(SumTelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
  "SUM(SumPostageandCourier) as SumPostageandCourier, " & _
  "SUM(SumOtherExpenses) as SumOtherExpenses, " & _
  "SUM(SumSample_Tester) as SumSample_Tester, " & _
  "SUM(SumPreopeningCosts) as SumPreopeningCosts, " & _
  "SUM(SumLossonClaim) as SumLossonClaim, " & _
  "SUM(SumCashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
  "SUM(SumMiscellenousandOther) as SumMiscellenousandOther, " & _
  "SUM(SumStoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
  "SUM(SumTradingProfit__Loss) as SumTradingProfit__Loss, " & _
  "SUM(SumStoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
  "SUM(SumStoreLabourCost) as SumStoreLabourCost, " & _
  "SUM(SumUtillity) as SumUtillity, " & _
  "SUM(SumRepairMaintenance) as SumRepairMaintenance " & _
        "from ( " & _
        "select mt.costcenter_id, " & _
  "SUM(costcenter_total_area) as sumtotalarea, " & _
  "SUM(costcenter_sale_area) as sumsalearea, " & _
  "SUM(TotalRevenue) as SumTotalRevenue, " & _
  "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
  "SUM(OtherRevenue) as SumOtherRevenue, " & _
  "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
  "SUM(GrossProfit) as SumGrossProfit, " & _
  "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
  "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
  "SUM(Shipping) as SumShipping, " & _
  "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
  "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
  "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
  "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
  "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
  "SUM(GWP) as SumGWP, " & _
  "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
  "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
  "SUM(SellingCosts) as SumSellingCosts, " & _
  "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
  "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
  "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
  "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
  "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
  "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
  "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
  "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
  "SUM(GrossPay) as SumGrossPay, " & _
  "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
  "SUM(Allowance) as SumAllowance, " & _
  "SUM(Overtime) as SumOvertime, " & _
  "SUM(Licensefee) as SumLicensefee, " & _
  "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
  "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
  "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
  "SUM(ProvidentFund) as SumProvidentFund, " & _
  "SUM(PensionCosts) as SumPensionCosts, " & _
  "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
  "SUM(Uniforms) as SumUniforms, " & _
  "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
  "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
  "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
  "SUM(PropertyRental) as SumPropertyRental, " & _
  "SUM(PropertyServices) as SumPropertyServices, " & _
  "SUM(PropertyFacility) as SumPropertyFacility, " & _
  "SUM(Propertytaxes) as SumPropertytaxes, " & _
  "SUM(Facialtaxes) as SumFacialtaxes, " & _
  "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
  "SUM(Signboard) as SumSignboard, " & _
  "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
  "SUM(GPCommission) as SumGPCommission, " & _
  "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
  "SUM(Depreciation) as SumDepreciation, " & _
  "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
  "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
  "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
  "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
  "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
  "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
  "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
  "SUM(BankCharges) as SumBankCharges, " & _
  "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
  "SUM(Cleaning) as SumCleaning, " & _
  "SUM(SecurityGuards) as SumSecurityGuards, " & _
  "SUM(Carriage) as SumCarriage, " & _
  "SUM(LicenceFees) as SumLicenceFees, " & _
  "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
  "SUM(OtherFees) as SumOtherFees, " & _
  "SUM(Utilities) as SumUtilities, " & _
  "SUM(Water) as SumWater, " & _
  "SUM(Gas_Electric) as SumGas_Electric, " & _
  "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
  "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
  "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
  "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
  "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
  "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
  "SUM(ProfessionalFee) as SumProfessionalFee, " & _
  "SUM(MarketingResearch) as SumMarketingResearch, " & _
  "SUM(OtherFee) as SumOtherFee, " & _
  "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
  "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
  "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
  "SUM(Equipment) as SumEquipment, " & _
  "SUM(Shopfitting) as SumShopfitting, " & _
  "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
  "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
  "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
  "SUM(Travel) as SumTravel, " & _
  "SUM(Accomodation) as SumAccomodation, " & _
  "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
  "SUM(Insurance) as SumInsurance, " & _
  "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
  "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
  "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
  "SUM(Taxation) as SumTaxation, " & _
  "SUM(Penalty) as SumPenalty, " & _
  "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
  "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
  "SUM(Training) as SumTraining, " & _
  "SUM(Communication) as SumCommunication, " & _
  "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
  "SUM(PostageandCourier) as SumPostageandCourier, " & _
  "SUM(OtherExpenses) as SumOtherExpenses, " & _
  "SUM(Sample_Tester) as SumSample_Tester, " & _
  "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
  "SUM(LossonClaim) as SumLossonClaim, " & _
  "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
  "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
  "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
  "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
  "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
  "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
  "SUM(Utillity) as SumUtillity, " & _
  "SUM(RepairMaintenance) as SumRepairMaintenance " & _
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
        "where bb.costcenter_store = st1.store_id and st1.store_other='N' order by st1.store_order asc"

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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
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
                'Dim dtLflResult As New DataTable : dtLflResult = Nothing

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
                drSum(colRev1) = dtLFL.Compute("Sum(" + colRev1 + ")", "")
                drSum(colRev2) = dtLFL.Compute("Sum(" + colRev2 + ")", "")
                drSum(colLoss1) = dtLFL.Compute("Sum(" + colLoss1 + ")", "")
                drSum(colLoss2) = dtLFL.Compute("Sum(" + colLoss2 + ")", "")
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

                'YOY
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
            End If

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumMtdArea(ByVal years As String, ByVal mon As String) As DataTable

        Dim sql As String = "select * from (select costcenter_areas,SUM(TotalRevenue) as sumtotal, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(RETAIL_TESPIncome) as sumretail, " & _
"SUM(OtherRevenue) as sumOtherRevenue, " & _
"SUM(CostofGoodSold) as sumCostofGoodSold, " & _
"SUM(GrossProfit) as sumGrossProfit, " & _
"SUM(MarginAdjustments) as sumMarginAdjustments, " & _
"SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as sumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as sumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as sumStoreLabourCosts, " & _
"SUM(StorePropertyCosts) as sumStorePropertyCosts, " & _
"SUM(Depreciation) as sumDepreciation, " & _
"SUM(OtherStoreCosts) as sumOtherStoreCosts, " & _
"SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss " & _
"from mtd mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt > @block_dt ) and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " & _
"group by costcenter_areas ) sm,area ar where sm.costcenter_areas=ar.area_id "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
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

    Public Shared Function getSumYtdArea(ByVal years As String, ByVal mon As String, ByVal start_time As String) As DataTable

        Dim sql As String = "select * from ( " & _
      "   select cs.costcenter_areas,SUM(sumtotal) as sumtotal, " & _
      "	SUM(cs.costcenter_total_area) as sumtotalarea,  " & _
      "	SUM(cs.costcenter_sale_area) as sumsalearea,  " & _
      "	SUM(sumretail) as sumretail,  " & _
      "	SUM(sumOtherRevenue) as sumOtherRevenue,  " & _
      "	SUM(sumCostofGoodSold) as sumCostofGoodSold,  " & _
      "	SUM(sumGrossProfit) as sumGrossProfit,  " & _
      "	SUM(sumMarginAdjustments) as sumMarginAdjustments,  " & _
      "	SUM(sumAdjustedGrossMargin) as sumAdjustedGrossMargin,  " & _
      "	SUM(sumSupplyChainCosts) as sumSupplyChainCosts,  " & _
      "	SUM(sumTotalStoreExpenses) as sumTotalStoreExpenses,  " & _
      "	SUM(sumStoreLabourCosts) as sumStoreLabourCosts,  " & _
      "	SUM(sumStorePropertyCosts) as sumStorePropertyCosts,  " & _
      "	SUM(sumDepreciation) as sumDepreciation,  " & _
      "	SUM(sumOtherStoreCosts) as sumOtherStoreCosts, " & _
      "	SUM(sumStoreTradingProfit__Loss) as sumStoreTradingProfit__Loss  " & _
      "from ( " & _
      "select mt.costcenter_id,SUM(TotalRevenue) as sumtotal,  " & _
      "	SUM(costcenter_total_area) as sumtotalarea,  " & _
      "	SUM(costcenter_sale_area) as sumsalearea,  " & _
      "	SUM(RETAIL_TESPIncome) as sumretail,  " & _
      "	SUM(OtherRevenue) as sumOtherRevenue,  " & _
      "	SUM(CostofGoodSold) as sumCostofGoodSold,  " & _
      "	SUM(GrossProfit) as sumGrossProfit,  " & _
      "	SUM(MarginAdjustments) as sumMarginAdjustments,  " & _
      "	SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin,  " & _
      "	SUM(SupplyChainCosts) as sumSupplyChainCosts,  " & _
      "	SUM(TotalStoreExpenses) as sumTotalStoreExpenses,  " & _
      "	SUM(StoreLabourCosts) as sumStoreLabourCosts,  " & _
      "	SUM(StorePropertyCosts) as sumStorePropertyCosts,  " & _
      "	SUM(Depreciation) as sumDepreciation,  " & _
      "	SUM(OtherStoreCosts) as sumOtherStoreCosts,  " & _
      "	SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss  " & _
        "from ( " & _
        "select mta.* " & _
        "from mtd mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'   " & _
        " union " & _
        "select mtb.* " & _
        "from mtd mtb,costcenter ccb " & _
        "where mtb.costcenter_id = ccb.costcenter_id And " & _
        "ccb.costcenter_blockdt > @select_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'  " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id  " & _
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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullYtdArea(ByVal years As String, ByVal mon As String, ByVal start_time As String, Optional rate As String = "") As DataTable

        Dim sql As String = "select * from ( " & _
      "   select COUNT(DISTINCT cs.costcenter_id) as cnum, cs.costcenter_areas, " & _
             "	SUM(cs.costcenter_total_area) as sumtotalarea,  " & _
        "	SUM(cs.costcenter_sale_area) as sumsalearea,  " & _
  "SUM(SumTotalRevenue) as SumTotalRevenue, " & _
  "SUM(SumRETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
  "SUM(SumOtherRevenue) as SumOtherRevenue, " & _
  "SUM(SumCostofGoodSold) as SumCostofGoodSold, " & _
  "SUM(SumGrossProfit) as SumGrossProfit, " & _
  "SUM(SumGrossProfit_percent) as SumGrossProfit_percent, " & _
  "SUM(SumMarginAdjustments) as SumMarginAdjustments, " & _
  "SUM(SumShipping) as SumShipping, " & _
  "SUM(SumStockLossandObsolescence) as SumStockLossandObsolescence, " & _
  "SUM(SumInventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
  "SUM(SumInventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
  "SUM(SumStockLoss_Provision) as SumStockLoss_Provision, " & _
  "SUM(SumStockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
  "SUM(SumGWP) as SumGWP, " & _
  "SUM(SumGWPs_Corporate) as SumGWPs_Corporate, " & _
  "SUM(SumGWPs_Transferred) as SumGWPs_Transferred, " & _
  "SUM(SumSellingCosts) as SumSellingCosts, " & _
  "SUM(SumCreditcardscommission) as SumCreditcardscommission, " & _
  "SUM(SumLabellingMaterial) as SumLabellingMaterial, " & _
  "SUM(SumOtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
  "SUM(SumOtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
  "SUM(SumAdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
  "SUM(SumSupplyChainCosts) as SumSupplyChainCosts, " & _
  "SUM(SumTotalStoreExpenses) as SumTotalStoreExpenses, " & _
  "SUM(SumStoreLabourCosts) as SumStoreLabourCosts, " & _
  "SUM(SumGrossPay) as SumGrossPay, " & _
  "SUM(SumTemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
  "SUM(SumAllowance) as SumAllowance, " & _
  "SUM(SumOvertime) as SumOvertime, " & _
  "SUM(SumLicensefee) as SumLicensefee, " & _
  "SUM(SumBonuses_Incentives) as SumBonuses_Incentives, " & _
  "SUM(SumBootsBrandncentives) as SumBootsBrandncentives, " & _
  "SUM(SumSuppliersIncentive) as SumSuppliersIncentive, " & _
  "SUM(SumProvidentFund) as SumProvidentFund, " & _
  "SUM(SumPensionCosts) as SumPensionCosts, " & _
  "SUM(SumSocialSecurityFund) as SumSocialSecurityFund, " & _
  "SUM(SumUniforms) as SumUniforms, " & _
  "SUM(SumEmployeeWelfare) as SumEmployeeWelfare, " & _
  "SUM(SumOtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
  "SUM(SumStorePropertyCosts) as SumStorePropertyCosts, " & _
  "SUM(SumPropertyRental) as SumPropertyRental, " & _
  "SUM(SumPropertyServices) as SumPropertyServices, " & _
  "SUM(SumPropertyFacility) as SumPropertyFacility, " & _
  "SUM(SumPropertytaxes) as SumPropertytaxes, " & _
  "SUM(SumFacialtaxes) as SumFacialtaxes, " & _
  "SUM(SumPropertyInsurance) as SumPropertyInsurance, " & _
  "SUM(SumSignboard) as SumSignboard, " & _
  "SUM(SumDiscount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
  "SUM(SumGPCommission) as SumGPCommission, " & _
  "SUM(SumAmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
  "SUM(SumDepreciation) as SumDepreciation, " & _
  "SUM(SumDepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
  "SUM(SumDepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
  "SUM(SumDepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
  "SUM(SumDepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
  "SUM(SumDepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
  "SUM(SumOtherStoreCosts) as SumOtherStoreCosts, " & _
  "SUM(SumServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
  "SUM(SumBankCharges) as SumBankCharges, " & _
  "SUM(SumCashCollectionCharge) as SumCashCollectionCharge, " & _
  "SUM(SumCleaning) as SumCleaning, " & _
  "SUM(SumSecurityGuards) as SumSecurityGuards, " & _
  "SUM(SumCarriage) as SumCarriage, " & _
  "SUM(SumLicenceFees) as SumLicenceFees, " & _
  "SUM(SumOtherServicesCharge) as SumOtherServicesCharge, " & _
  "SUM(SumOtherFees) as SumOtherFees, " & _
  "SUM(SumUtilities) as SumUtilities, " & _
  "SUM(SumWater) as SumWater, " & _
  "SUM(SumGas_Electric) as SumGas_Electric, " & _
  "SUM(SumAirCond_Addition) as SumAirCond_Addition, " & _
  "SUM(SumRepairandMaintenance) as SumRepairandMaintenance, " & _
  "SUM(SumRMOther_Fix) as SumRMOther_Fix, " & _
  "SUM(SumRMOther_Unplan) as SumRMOther_Unplan, " & _
  "SUM(SumRMComputer_Fix) as SumRMComputer_Fix, " & _
  "SUM(SumRMComputer_Unplan) as SumRMComputer_Unplan, " & _
  "SUM(SumProfessionalFee) as SumProfessionalFee, " & _
  "SUM(SumMarketingResearch) as SumMarketingResearch, " & _
  "SUM(SumOtherFee) as SumOtherFee, " & _
  "SUM(SumEquipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
  "SUM(SumPrintingandStationery) as SumPrintingandStationery, " & _
  "SUM(SumSuppliesExpenses) as SumSuppliesExpenses, " & _
  "SUM(SumEquipment) as SumEquipment, " & _
  "SUM(SumShopfitting) as SumShopfitting, " & _
  "SUM(SumPackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
  "SUM(SumBusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
  "SUM(SumCarParkingandOthers) as SumCarParkingandOthers, " & _
  "SUM(SumTravel) as SumTravel, " & _
  "SUM(SumAccomodation) as SumAccomodation, " & _
  "SUM(SumMealandEntertainment) as SumMealandEntertainment, " & _
  "SUM(SumInsurance) as SumInsurance, " & _
  "SUM(SumAllRiskInsurance) as SumAllRiskInsurance, " & _
  "SUM(SumHealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
  "SUM(SumPenaltyandTaxation) as SumPenaltyandTaxation, " & _
  "SUM(SumTaxation) as SumTaxation, " & _
  "SUM(SumPenalty) as SumPenalty, " & _
  "SUM(SumOtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
  "SUM(SumStaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
  "SUM(SumTraining) as SumTraining, " & _
  "SUM(SumCommunication) as SumCommunication, " & _
  "SUM(SumTelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
  "SUM(SumPostageandCourier) as SumPostageandCourier, " & _
  "SUM(SumOtherExpenses) as SumOtherExpenses, " & _
  "SUM(SumSample_Tester) as SumSample_Tester, " & _
  "SUM(SumPreopeningCosts) as SumPreopeningCosts, " & _
  "SUM(SumLossonClaim) as SumLossonClaim, " & _
  "SUM(SumCashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
  "SUM(SumMiscellenousandOther) as SumMiscellenousandOther, " & _
  "SUM(SumStoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
  "SUM(SumTradingProfit__Loss) as SumTradingProfit__Loss, " & _
  "SUM(SumStoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
  "SUM(SumStoreLabourCost) as SumStoreLabourCost, " & _
  "SUM(SumUtillity) as SumUtillity, " & _
  "SUM(SumRepairMaintenance) as SumRepairMaintenance " & _
        "from ( " & _
        "select mt.costcenter_id, " & _
  "SUM(costcenter_total_area) as sumtotalarea, " & _
  "SUM(costcenter_sale_area) as sumsalearea, " & _
  "SUM(TotalRevenue) as SumTotalRevenue, " & _
  "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
  "SUM(OtherRevenue) as SumOtherRevenue, " & _
  "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
  "SUM(GrossProfit) as SumGrossProfit, " & _
  "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
  "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
  "SUM(Shipping) as SumShipping, " & _
  "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
  "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
  "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
  "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
  "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
  "SUM(GWP) as SumGWP, " & _
  "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
  "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
  "SUM(SellingCosts) as SumSellingCosts, " & _
  "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
  "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
  "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
  "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
  "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
  "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
  "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
  "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
  "SUM(GrossPay) as SumGrossPay, " & _
  "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
  "SUM(Allowance) as SumAllowance, " & _
  "SUM(Overtime) as SumOvertime, " & _
  "SUM(Licensefee) as SumLicensefee, " & _
  "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
  "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
  "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
  "SUM(ProvidentFund) as SumProvidentFund, " & _
  "SUM(PensionCosts) as SumPensionCosts, " & _
  "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
  "SUM(Uniforms) as SumUniforms, " & _
  "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
  "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
  "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
  "SUM(PropertyRental) as SumPropertyRental, " & _
  "SUM(PropertyServices) as SumPropertyServices, " & _
  "SUM(PropertyFacility) as SumPropertyFacility, " & _
  "SUM(Propertytaxes) as SumPropertytaxes, " & _
  "SUM(Facialtaxes) as SumFacialtaxes, " & _
  "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
  "SUM(Signboard) as SumSignboard, " & _
  "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
  "SUM(GPCommission) as SumGPCommission, " & _
  "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
  "SUM(Depreciation) as SumDepreciation, " & _
  "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
  "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
  "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
  "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
  "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
  "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
  "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
  "SUM(BankCharges) as SumBankCharges, " & _
  "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
  "SUM(Cleaning) as SumCleaning, " & _
  "SUM(SecurityGuards) as SumSecurityGuards, " & _
  "SUM(Carriage) as SumCarriage, " & _
  "SUM(LicenceFees) as SumLicenceFees, " & _
  "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
  "SUM(OtherFees) as SumOtherFees, " & _
  "SUM(Utilities) as SumUtilities, " & _
  "SUM(Water) as SumWater, " & _
  "SUM(Gas_Electric) as SumGas_Electric, " & _
  "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
  "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
  "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
  "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
  "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
  "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
  "SUM(ProfessionalFee) as SumProfessionalFee, " & _
  "SUM(MarketingResearch) as SumMarketingResearch, " & _
  "SUM(OtherFee) as SumOtherFee, " & _
  "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
  "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
  "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
  "SUM(Equipment) as SumEquipment, " & _
  "SUM(Shopfitting) as SumShopfitting, " & _
  "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
  "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
  "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
  "SUM(Travel) as SumTravel, " & _
  "SUM(Accomodation) as SumAccomodation, " & _
  "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
  "SUM(Insurance) as SumInsurance, " & _
  "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
  "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
  "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
  "SUM(Taxation) as SumTaxation, " & _
  "SUM(Penalty) as SumPenalty, " & _
  "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
  "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
  "SUM(Training) as SumTraining, " & _
  "SUM(Communication) as SumCommunication, " & _
  "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
  "SUM(PostageandCourier) as SumPostageandCourier, " & _
  "SUM(OtherExpenses) as SumOtherExpenses, " & _
  "SUM(Sample_Tester) as SumSample_Tester, " & _
  "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
  "SUM(LossonClaim) as SumLossonClaim, " & _
  "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
  "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
  "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
  "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
  "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
  "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
  "SUM(Utillity) as SumUtillity, " & _
  "SUM(RepairMaintenance) as SumRepairMaintenance " & _
       "from ( " & _
        "select mta.* " & _
        "from v_mtd('" + rate + "') mta,costcenter cca,store sto1 " & _
        " where mta.costcenter_id = cca.costcenter_id And cca.costcenter_store = sto1.store_id and sto1.store_other='N' and " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'   " & _
        " union " & _
        "select mtb.* " & _
        "from v_mtd('" + rate + "') mtb,costcenter ccb,store sto2 " & _
        "where mtb.costcenter_id = ccb.costcenter_id And ccb.costcenter_store = sto2.store_id and sto2.store_other='N' and " & _
        "ccb.costcenter_blockdt >= @sl_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'  " & _
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

        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
        If mon = "12" Then
            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
        Else
            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
        End If
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

    Public Shared Function getSumFullMtdArea(ByVal years As String, ByVal mon As String, Optional rate As String = "") As DataTable

        Dim sql As String = "select * from (select COUNT(DISTINCT cc.costcenter_id) as cnum,costcenter_areas, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance " & _
"from v_mtd('" + rate + "') mt,costcenter cc,store sto " & _
"where  cc.costcenter_store = sto.store_id and sto.store_other='N' and mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt ) and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " & _
" and cc.costcenter_opendt < @sl_dt " & _
"group by costcenter_areas ) sm,area ar where sm.costcenter_areas=ar.area_id "

        '" from " + sqlTbl + " mt,costcenter cc " & _
        '    " where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "'  " & _
        '    " AND (cc.costcenter_location = @locate OR @locate = '' )" & _
        '    " AND cc.costcenter_opendt < @sl_dt " & _
        '    " group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id and st.store_other='N' order by st.store_order asc"

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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumMtdMarket(ByVal years As String, ByVal mon As String) As DataTable

        Dim sql As String = "select * from (select costcenter_market,SUM(TotalRevenue) as sumtotal, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(RETAIL_TESPIncome) as sumretail, " & _
"SUM(OtherRevenue) as sumOtherRevenue, " & _
"SUM(CostofGoodSold) as sumCostofGoodSold, " & _
"SUM(GrossProfit) as sumGrossProfit, " & _
"SUM(MarginAdjustments) as sumMarginAdjustments, " & _
"SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as sumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as sumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as sumStoreLabourCosts, " & _
"SUM(StorePropertyCosts) as sumStorePropertyCosts, " & _
"SUM(Depreciation) as sumDepreciation, " & _
"SUM(OtherStoreCosts) as sumOtherStoreCosts, " & _
"SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss " & _
"from mtd mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt > @block_dt ) and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " & _
"group by costcenter_market ) sm,market mr where sm.costcenter_market=mr.market_id "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
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

    Public Shared Function getSumYtdMarket(ByVal years As String, ByVal mon As String, ByVal start_time As String) As DataTable

        Dim sql As String = "select * from ( " & _
"   select cs.costcenter_market,SUM(sumtotal) as sumtotal, " & _
"	SUM(cs.costcenter_total_area) as sumtotalarea,  " & _
"	SUM(cs.costcenter_sale_area) as sumsalearea,  " & _
"	SUM(sumretail) as sumretail,  " & _
"	SUM(sumOtherRevenue) as sumOtherRevenue,  " & _
"	SUM(sumCostofGoodSold) as sumCostofGoodSold,  " & _
"	SUM(sumGrossProfit) as sumGrossProfit,  " & _
"	SUM(sumMarginAdjustments) as sumMarginAdjustments,  " & _
"	SUM(sumAdjustedGrossMargin) as sumAdjustedGrossMargin,  " & _
"	SUM(sumSupplyChainCosts) as sumSupplyChainCosts,  " & _
"	SUM(sumTotalStoreExpenses) as sumTotalStoreExpenses,  " & _
"	SUM(sumStoreLabourCosts) as sumStoreLabourCosts,  " & _
"	SUM(sumStorePropertyCosts) as sumStorePropertyCosts,  " & _
"	SUM(sumDepreciation) as sumDepreciation,  " & _
"	SUM(sumOtherStoreCosts) as sumOtherStoreCosts, " & _
"	SUM(sumStoreTradingProfit__Loss) as sumStoreTradingProfit__Loss  " & _
"from ( " & _
"select mt.costcenter_id,SUM(TotalRevenue) as sumtotal,  " & _
"	SUM(costcenter_total_area) as sumtotalarea,  " & _
"	SUM(costcenter_sale_area) as sumsalearea,  " & _
"	SUM(RETAIL_TESPIncome) as sumretail,  " & _
"	SUM(OtherRevenue) as sumOtherRevenue,  " & _
"	SUM(CostofGoodSold) as sumCostofGoodSold,  " & _
"	SUM(GrossProfit) as sumGrossProfit,  " & _
"	SUM(MarginAdjustments) as sumMarginAdjustments,  " & _
"	SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin,  " & _
"	SUM(SupplyChainCosts) as sumSupplyChainCosts,  " & _
"	SUM(TotalStoreExpenses) as sumTotalStoreExpenses,  " & _
"	SUM(StoreLabourCosts) as sumStoreLabourCosts,  " & _
"	SUM(StorePropertyCosts) as sumStorePropertyCosts,  " & _
"	SUM(Depreciation) as sumDepreciation,  " & _
"	SUM(OtherStoreCosts) as sumOtherStoreCosts,  " & _
"	SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss  " & _
    "from ( " & _
        "select mta.* " & _
        "from mtd mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'   " & _
        " union " & _
        "select mtb.* " & _
        "from mtd mtb,costcenter ccb " & _
        "where mtb.costcenter_id = ccb.costcenter_id And " & _
        "ccb.costcenter_blockdt > @select_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'  " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id  " & _
"group by mt.costcenter_id " & _
") mt2,costcenter cs " & _
"where mt2.costcenter_id = cs.costcenter_id " & _
"group by cs.costcenter_market " & _
") bb,market mr " & _
"where bb.costcenter_market=mr.market_id "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
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

    Public Shared Function getSumFullYtdMarket(ByVal years As String, ByVal mon As String, ByVal start_time As String) As DataTable

        Dim sql As String = "select * from ( " & _
"   select COUNT(DISTINCT cs.costcenter_id) as cnum, cs.costcenter_market, " & _
             "	SUM(cs.costcenter_total_area) as sumtotalarea,  " & _
        "	SUM(cs.costcenter_sale_area) as sumsalearea,  " & _
  "SUM(SumTotalRevenue) as SumTotalRevenue, " & _
  "SUM(SumRETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
  "SUM(SumOtherRevenue) as SumOtherRevenue, " & _
  "SUM(SumCostofGoodSold) as SumCostofGoodSold, " & _
  "SUM(SumGrossProfit) as SumGrossProfit, " & _
  "SUM(SumGrossProfit_percent) as SumGrossProfit_percent, " & _
  "SUM(SumMarginAdjustments) as SumMarginAdjustments, " & _
  "SUM(SumShipping) as SumShipping, " & _
  "SUM(SumStockLossandObsolescence) as SumStockLossandObsolescence, " & _
  "SUM(SumInventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
  "SUM(SumInventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
  "SUM(SumStockLoss_Provision) as SumStockLoss_Provision, " & _
  "SUM(SumStockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
  "SUM(SumGWP) as SumGWP, " & _
  "SUM(SumGWPs_Corporate) as SumGWPs_Corporate, " & _
  "SUM(SumGWPs_Transferred) as SumGWPs_Transferred, " & _
  "SUM(SumSellingCosts) as SumSellingCosts, " & _
  "SUM(SumCreditcardscommission) as SumCreditcardscommission, " & _
  "SUM(SumLabellingMaterial) as SumLabellingMaterial, " & _
  "SUM(SumOtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
  "SUM(SumOtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
  "SUM(SumAdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
  "SUM(SumSupplyChainCosts) as SumSupplyChainCosts, " & _
  "SUM(SumTotalStoreExpenses) as SumTotalStoreExpenses, " & _
  "SUM(SumStoreLabourCosts) as SumStoreLabourCosts, " & _
  "SUM(SumGrossPay) as SumGrossPay, " & _
  "SUM(SumTemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
  "SUM(SumAllowance) as SumAllowance, " & _
  "SUM(SumOvertime) as SumOvertime, " & _
  "SUM(SumLicensefee) as SumLicensefee, " & _
  "SUM(SumBonuses_Incentives) as SumBonuses_Incentives, " & _
  "SUM(SumBootsBrandncentives) as SumBootsBrandncentives, " & _
  "SUM(SumSuppliersIncentive) as SumSuppliersIncentive, " & _
  "SUM(SumProvidentFund) as SumProvidentFund, " & _
  "SUM(SumPensionCosts) as SumPensionCosts, " & _
  "SUM(SumSocialSecurityFund) as SumSocialSecurityFund, " & _
  "SUM(SumUniforms) as SumUniforms, " & _
  "SUM(SumEmployeeWelfare) as SumEmployeeWelfare, " & _
  "SUM(SumOtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
  "SUM(SumStorePropertyCosts) as SumStorePropertyCosts, " & _
  "SUM(SumPropertyRental) as SumPropertyRental, " & _
  "SUM(SumPropertyServices) as SumPropertyServices, " & _
  "SUM(SumPropertyFacility) as SumPropertyFacility, " & _
  "SUM(SumPropertytaxes) as SumPropertytaxes, " & _
  "SUM(SumFacialtaxes) as SumFacialtaxes, " & _
  "SUM(SumPropertyInsurance) as SumPropertyInsurance, " & _
  "SUM(SumSignboard) as SumSignboard, " & _
  "SUM(SumDiscount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
  "SUM(SumGPCommission) as SumGPCommission, " & _
  "SUM(SumAmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
  "SUM(SumDepreciation) as SumDepreciation, " & _
  "SUM(SumDepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
  "SUM(SumDepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
  "SUM(SumDepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
  "SUM(SumDepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
  "SUM(SumDepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
  "SUM(SumOtherStoreCosts) as SumOtherStoreCosts, " & _
  "SUM(SumServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
  "SUM(SumBankCharges) as SumBankCharges, " & _
  "SUM(SumCashCollectionCharge) as SumCashCollectionCharge, " & _
  "SUM(SumCleaning) as SumCleaning, " & _
  "SUM(SumSecurityGuards) as SumSecurityGuards, " & _
  "SUM(SumCarriage) as SumCarriage, " & _
  "SUM(SumLicenceFees) as SumLicenceFees, " & _
  "SUM(SumOtherServicesCharge) as SumOtherServicesCharge, " & _
  "SUM(SumOtherFees) as SumOtherFees, " & _
  "SUM(SumUtilities) as SumUtilities, " & _
  "SUM(SumWater) as SumWater, " & _
  "SUM(SumGas_Electric) as SumGas_Electric, " & _
  "SUM(SumAirCond_Addition) as SumAirCond_Addition, " & _
  "SUM(SumRepairandMaintenance) as SumRepairandMaintenance, " & _
  "SUM(SumRMOther_Fix) as SumRMOther_Fix, " & _
  "SUM(SumRMOther_Unplan) as SumRMOther_Unplan, " & _
  "SUM(SumRMComputer_Fix) as SumRMComputer_Fix, " & _
  "SUM(SumRMComputer_Unplan) as SumRMComputer_Unplan, " & _
  "SUM(SumProfessionalFee) as SumProfessionalFee, " & _
  "SUM(SumMarketingResearch) as SumMarketingResearch, " & _
  "SUM(SumOtherFee) as SumOtherFee, " & _
  "SUM(SumEquipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
  "SUM(SumPrintingandStationery) as SumPrintingandStationery, " & _
  "SUM(SumSuppliesExpenses) as SumSuppliesExpenses, " & _
  "SUM(SumEquipment) as SumEquipment, " & _
  "SUM(SumShopfitting) as SumShopfitting, " & _
  "SUM(SumPackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
  "SUM(SumBusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
  "SUM(SumCarParkingandOthers) as SumCarParkingandOthers, " & _
  "SUM(SumTravel) as SumTravel, " & _
  "SUM(SumAccomodation) as SumAccomodation, " & _
  "SUM(SumMealandEntertainment) as SumMealandEntertainment, " & _
  "SUM(SumInsurance) as SumInsurance, " & _
  "SUM(SumAllRiskInsurance) as SumAllRiskInsurance, " & _
  "SUM(SumHealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
  "SUM(SumPenaltyandTaxation) as SumPenaltyandTaxation, " & _
  "SUM(SumTaxation) as SumTaxation, " & _
  "SUM(SumPenalty) as SumPenalty, " & _
  "SUM(SumOtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
  "SUM(SumStaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
  "SUM(SumTraining) as SumTraining, " & _
  "SUM(SumCommunication) as SumCommunication, " & _
  "SUM(SumTelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
  "SUM(SumPostageandCourier) as SumPostageandCourier, " & _
  "SUM(SumOtherExpenses) as SumOtherExpenses, " & _
  "SUM(SumSample_Tester) as SumSample_Tester, " & _
  "SUM(SumPreopeningCosts) as SumPreopeningCosts, " & _
  "SUM(SumLossonClaim) as SumLossonClaim, " & _
  "SUM(SumCashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
  "SUM(SumMiscellenousandOther) as SumMiscellenousandOther, " & _
  "SUM(SumStoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
  "SUM(SumTradingProfit__Loss) as SumTradingProfit__Loss, " & _
  "SUM(SumStoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
  "SUM(SumStoreLabourCost) as SumStoreLabourCost, " & _
  "SUM(SumUtillity) as SumUtillity, " & _
  "SUM(SumRepairMaintenance) as SumRepairMaintenance " & _
        "from ( " & _
        "select mt.costcenter_id, " & _
  "SUM(costcenter_total_area) as sumtotalarea, " & _
  "SUM(costcenter_sale_area) as sumsalearea, " & _
  "SUM(TotalRevenue) as SumTotalRevenue, " & _
  "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
  "SUM(OtherRevenue) as SumOtherRevenue, " & _
  "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
  "SUM(GrossProfit) as SumGrossProfit, " & _
  "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
  "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
  "SUM(Shipping) as SumShipping, " & _
  "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
  "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
  "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
  "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
  "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
  "SUM(GWP) as SumGWP, " & _
  "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
  "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
  "SUM(SellingCosts) as SumSellingCosts, " & _
  "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
  "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
  "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
  "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
  "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
  "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
  "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
  "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
  "SUM(GrossPay) as SumGrossPay, " & _
  "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
  "SUM(Allowance) as SumAllowance, " & _
  "SUM(Overtime) as SumOvertime, " & _
  "SUM(Licensefee) as SumLicensefee, " & _
  "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
  "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
  "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
  "SUM(ProvidentFund) as SumProvidentFund, " & _
  "SUM(PensionCosts) as SumPensionCosts, " & _
  "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
  "SUM(Uniforms) as SumUniforms, " & _
  "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
  "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
  "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
  "SUM(PropertyRental) as SumPropertyRental, " & _
  "SUM(PropertyServices) as SumPropertyServices, " & _
  "SUM(PropertyFacility) as SumPropertyFacility, " & _
  "SUM(Propertytaxes) as SumPropertytaxes, " & _
  "SUM(Facialtaxes) as SumFacialtaxes, " & _
  "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
  "SUM(Signboard) as SumSignboard, " & _
  "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
  "SUM(GPCommission) as SumGPCommission, " & _
  "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
  "SUM(Depreciation) as SumDepreciation, " & _
  "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
  "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
  "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
  "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
  "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
  "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
  "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
  "SUM(BankCharges) as SumBankCharges, " & _
  "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
  "SUM(Cleaning) as SumCleaning, " & _
  "SUM(SecurityGuards) as SumSecurityGuards, " & _
  "SUM(Carriage) as SumCarriage, " & _
  "SUM(LicenceFees) as SumLicenceFees, " & _
  "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
  "SUM(OtherFees) as SumOtherFees, " & _
  "SUM(Utilities) as SumUtilities, " & _
  "SUM(Water) as SumWater, " & _
  "SUM(Gas_Electric) as SumGas_Electric, " & _
  "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
  "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
  "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
  "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
  "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
  "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
  "SUM(ProfessionalFee) as SumProfessionalFee, " & _
  "SUM(MarketingResearch) as SumMarketingResearch, " & _
  "SUM(OtherFee) as SumOtherFee, " & _
  "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
  "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
  "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
  "SUM(Equipment) as SumEquipment, " & _
  "SUM(Shopfitting) as SumShopfitting, " & _
  "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
  "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
  "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
  "SUM(Travel) as SumTravel, " & _
  "SUM(Accomodation) as SumAccomodation, " & _
  "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
  "SUM(Insurance) as SumInsurance, " & _
  "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
  "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
  "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
  "SUM(Taxation) as SumTaxation, " & _
  "SUM(Penalty) as SumPenalty, " & _
  "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
  "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
  "SUM(Training) as SumTraining, " & _
  "SUM(Communication) as SumCommunication, " & _
  "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
  "SUM(PostageandCourier) as SumPostageandCourier, " & _
  "SUM(OtherExpenses) as SumOtherExpenses, " & _
  "SUM(Sample_Tester) as SumSample_Tester, " & _
  "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
  "SUM(LossonClaim) as SumLossonClaim, " & _
  "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
  "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
  "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
  "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
  "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
  "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
  "SUM(Utillity) as SumUtillity, " & _
  "SUM(RepairMaintenance) as SumRepairMaintenance " & _
   "from ( " & _
        "select mta.* " & _
        "from mtd mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'   " & _
        " union " & _
        "select mtb.* " & _
        "from mtd mtb,costcenter ccb " & _
        "where mtb.costcenter_id = ccb.costcenter_id And " & _
        "ccb.costcenter_blockdt >= @sl_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'  " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id  " & _
                " and cc.costcenter_opendt < @sl_dt " & _
"group by mt.costcenter_id " & _
") mt2,costcenter cs " & _
"where mt2.costcenter_id = cs.costcenter_id " & _
"group by cs.costcenter_market " & _
") bb,market mr " & _
"where bb.costcenter_market=mr.market_id "

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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullMtdMarket(ByVal years As String, ByVal mon As String) As DataTable

        Dim sql As String = "select * from (select COUNT(DISTINCT cc.costcenter_id) as cnum,costcenter_market, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance " & _
"from mtd mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt ) and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " & _
" and cc.costcenter_opendt < @sl_dt " & _
"group by costcenter_market ) sm,market mr where sm.costcenter_market=mr.market_id "

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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumMtdModelByCost(ByVal fdate As String, ByVal tdate As String, ByVal cost_id As String) As DataTable

        Dim sql As String = "select * from (select month_time,SUM(TotalRevenue) as sumtotal, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(RETAIL_TESPIncome) as sumretail, " & _
"SUM(OtherRevenue) as sumOtherRevenue, " & _
"SUM(CostofGoodSold) as sumCostofGoodSold, " & _
"SUM(GrossProfit) as sumGrossProfit, " & _
"SUM(MarginAdjustments) as sumMarginAdjustments, " & _
"SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as sumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as sumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as sumStoreLabourCosts, " & _
"SUM(StorePropertyCosts) as sumStorePropertyCosts, " & _
"SUM(Depreciation) as sumDepreciation, " & _
"SUM(OtherStoreCosts) as sumOtherStoreCosts, " & _
"SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss " & _
"from mtd mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and cc.costcenter_id='" + cost_id + "' and mt.month_time >='" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
"group by month_time ) sm order by sm.month_time asc "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumMtdModelByBangkok(ByVal years As String, ByVal mon As String, ByVal locate As String, ByVal store As String) As DataTable

        Dim area As String = ""

        If locate <> "ALL" And locate <> "TWO" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select * from (select costcenter_store,SUM(TotalRevenue) as sumtotal, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(RETAIL_TESPIncome) as sumretail, " & _
"SUM(OtherRevenue) as sumOtherRevenue, " & _
"SUM(CostofGoodSold) as sumCostofGoodSold, " & _
"SUM(GrossProfit) as sumGrossProfit, " & _
"SUM(MarginAdjustments) as sumMarginAdjustments, " & _
"SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as sumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as sumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as sumStoreLabourCosts, " & _
"SUM(StorePropertyCosts) as sumStorePropertyCosts, " & _
"SUM(Depreciation) as sumDepreciation, " & _
"SUM(OtherStoreCosts) as sumOtherStoreCosts, " & _
"SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss " & _
"from mtd mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt > @block_dt ) and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " + area + " " & _
"group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id and sm.costcenter_store=" + store

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
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

    Public Shared Function getSumYtdModelByBangkok(ByVal years As String, ByVal mon As String, ByVal locate As String, ByVal store As String, ByVal start_time As String) As DataTable

        Dim area As String = ""

        If locate <> "ALL" And locate <> "TWO" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select * from ( " & _
       "   select cs.costcenter_store,SUM(sumtotal) as sumtotal, " & _
       "	SUM(cs.costcenter_total_area) as sumtotalarea,  " & _
       "	SUM(cs.costcenter_sale_area) as sumsalearea,  " & _
       "	SUM(sumretail) as sumretail,  " & _
       "	SUM(sumOtherRevenue) as sumOtherRevenue,  " & _
       "	SUM(sumCostofGoodSold) as sumCostofGoodSold,  " & _
       "	SUM(sumGrossProfit) as sumGrossProfit,  " & _
       "	SUM(sumMarginAdjustments) as sumMarginAdjustments,  " & _
       "	SUM(sumAdjustedGrossMargin) as sumAdjustedGrossMargin,  " & _
       "	SUM(sumSupplyChainCosts) as sumSupplyChainCosts,  " & _
       "	SUM(sumTotalStoreExpenses) as sumTotalStoreExpenses,  " & _
       "	SUM(sumStoreLabourCosts) as sumStoreLabourCosts,  " & _
       "	SUM(sumStorePropertyCosts) as sumStorePropertyCosts,  " & _
       "	SUM(sumDepreciation) as sumDepreciation,  " & _
       "	SUM(sumOtherStoreCosts) as sumOtherStoreCosts, " & _
       "	SUM(sumStoreTradingProfit__Loss) as sumStoreTradingProfit__Loss  " & _
       "from ( " & _
       "select mt.costcenter_id,SUM(TotalRevenue) as sumtotal,  " & _
       "	SUM(costcenter_total_area) as sumtotalarea,  " & _
       "	SUM(costcenter_sale_area) as sumsalearea,  " & _
       "	SUM(RETAIL_TESPIncome) as sumretail,  " & _
       "	SUM(OtherRevenue) as sumOtherRevenue,  " & _
       "	SUM(CostofGoodSold) as sumCostofGoodSold,  " & _
       "	SUM(GrossProfit) as sumGrossProfit,  " & _
       "	SUM(MarginAdjustments) as sumMarginAdjustments,  " & _
       "	SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin,  " & _
       "	SUM(SupplyChainCosts) as sumSupplyChainCosts,  " & _
       "	SUM(TotalStoreExpenses) as sumTotalStoreExpenses,  " & _
       "	SUM(StoreLabourCosts) as sumStoreLabourCosts,  " & _
       "	SUM(StorePropertyCosts) as sumStorePropertyCosts,  " & _
       "	SUM(Depreciation) as sumDepreciation,  " & _
       "	SUM(OtherStoreCosts) as sumOtherStoreCosts,  " & _
       "	SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss  " & _
       "from ( " & _
        "select mta.* " & _
        "from mtd mta,costcenter cca " & _
        " where mta.costcenter_id = cca.costcenter_id And " & _
        "cca.costcenter_blockdt Is null And " & _
        "mta.month_time <= @select_dt and " & _
        "mta.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'   " & _
        " union " & _
        "select mtb.* " & _
        "from mtd mtb,costcenter ccb " & _
        "where mtb.costcenter_id = ccb.costcenter_id And " & _
        "ccb.costcenter_blockdt > @select_dt and " & _
        "mtb.month_time <= @select_dt and " & _
        "mtb.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'  " & _
        ") mt,costcenter cc  " & _
        "where mt.costcenter_id = cc.costcenter_id  " & _
       " " + area + " " & _
       "group by mt.costcenter_id " & _
       ") mt2,costcenter cs " & _
       "where mt2.costcenter_id = cs.costcenter_id " & _
       "group by cs.costcenter_store " & _
       ") bb,store st1 " & _
       "where bb.costcenter_store = st1.store_id and bb.costcenter_store=" + store

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Dim parameter As New SqlParameter("@select_dt", SqlDbType.DateTime)
        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
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

#Region "MTD"

    Public Shared Function getSumFullYtdModelByBangkok(ByVal years As String, ByVal mon As String, ByVal locate As String, ByVal store As String, ByVal start_time As String, Optional rate As String = "") As DataTable

        Dim area As String = ""

        If locate <> "ALL" And locate <> "TWO" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select * from ( " & _
         "   select COUNT(DISTINCT cs.costcenter_id) as cnum, cs.costcenter_store, " & _
         "	SUM(cs.costcenter_total_area) as sumtotalarea,  " & _
         "	SUM(cs.costcenter_sale_area) as sumsalearea,  " & _
   "SUM(SumTotalRevenue) as SumTotalRevenue, " & _
   "SUM(SumRETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
   "SUM(SumOtherRevenue) as SumOtherRevenue, " & _
   "SUM(SumCostofGoodSold) as SumCostofGoodSold, " & _
   "SUM(SumGrossProfit) as SumGrossProfit, " & _
   "SUM(SumGrossProfit_percent) as SumGrossProfit_percent, " & _
   "SUM(SumMarginAdjustments) as SumMarginAdjustments, " & _
   "SUM(SumShipping) as SumShipping, " & _
   "SUM(SumStockLossandObsolescence) as SumStockLossandObsolescence, " & _
   "SUM(SumInventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
   "SUM(SumInventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
   "SUM(SumStockLoss_Provision) as SumStockLoss_Provision, " & _
   "SUM(SumStockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
   "SUM(SumGWP) as SumGWP, " & _
   "SUM(SumGWPs_Corporate) as SumGWPs_Corporate, " & _
   "SUM(SumGWPs_Transferred) as SumGWPs_Transferred, " & _
   "SUM(SumSellingCosts) as SumSellingCosts, " & _
   "SUM(SumCreditcardscommission) as SumCreditcardscommission, " & _
   "SUM(SumLabellingMaterial) as SumLabellingMaterial, " & _
   "SUM(SumOtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
   "SUM(SumOtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
   "SUM(SumAdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
   "SUM(SumSupplyChainCosts) as SumSupplyChainCosts, " & _
   "SUM(SumTotalStoreExpenses) as SumTotalStoreExpenses, " & _
   "SUM(SumStoreLabourCosts) as SumStoreLabourCosts, " & _
   "SUM(SumGrossPay) as SumGrossPay, " & _
   "SUM(SumTemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
   "SUM(SumAllowance) as SumAllowance, " & _
   "SUM(SumOvertime) as SumOvertime, " & _
   "SUM(SumLicensefee) as SumLicensefee, " & _
   "SUM(SumBonuses_Incentives) as SumBonuses_Incentives, " & _
   "SUM(SumBootsBrandncentives) as SumBootsBrandncentives, " & _
   "SUM(SumSuppliersIncentive) as SumSuppliersIncentive, " & _
   "SUM(SumProvidentFund) as SumProvidentFund, " & _
   "SUM(SumPensionCosts) as SumPensionCosts, " & _
   "SUM(SumSocialSecurityFund) as SumSocialSecurityFund, " & _
   "SUM(SumUniforms) as SumUniforms, " & _
   "SUM(SumEmployeeWelfare) as SumEmployeeWelfare, " & _
   "SUM(SumOtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
   "SUM(SumStorePropertyCosts) as SumStorePropertyCosts, " & _
   "SUM(SumPropertyRental) as SumPropertyRental, " & _
   "SUM(SumPropertyServices) as SumPropertyServices, " & _
   "SUM(SumPropertyFacility) as SumPropertyFacility, " & _
   "SUM(SumPropertytaxes) as SumPropertytaxes, " & _
   "SUM(SumFacialtaxes) as SumFacialtaxes, " & _
   "SUM(SumPropertyInsurance) as SumPropertyInsurance, " & _
   "SUM(SumSignboard) as SumSignboard, " & _
   "SUM(SumDiscount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
   "SUM(SumGPCommission) as SumGPCommission, " & _
   "SUM(SumAmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
   "SUM(SumDepreciation) as SumDepreciation, " & _
   "SUM(SumDepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
   "SUM(SumDepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
   "SUM(SumDepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
   "SUM(SumDepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
   "SUM(SumDepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
   "SUM(SumOtherStoreCosts) as SumOtherStoreCosts, " & _
   "SUM(SumServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
   "SUM(SumBankCharges) as SumBankCharges, " & _
   "SUM(SumCashCollectionCharge) as SumCashCollectionCharge, " & _
   "SUM(SumCleaning) as SumCleaning, " & _
   "SUM(SumSecurityGuards) as SumSecurityGuards, " & _
   "SUM(SumCarriage) as SumCarriage, " & _
   "SUM(SumLicenceFees) as SumLicenceFees, " & _
   "SUM(SumOtherServicesCharge) as SumOtherServicesCharge, " & _
   "SUM(SumOtherFees) as SumOtherFees, " & _
   "SUM(SumUtilities) as SumUtilities, " & _
   "SUM(SumWater) as SumWater, " & _
   "SUM(SumGas_Electric) as SumGas_Electric, " & _
   "SUM(SumAirCond_Addition) as SumAirCond_Addition, " & _
   "SUM(SumRepairandMaintenance) as SumRepairandMaintenance, " & _
   "SUM(SumRMOther_Fix) as SumRMOther_Fix, " & _
   "SUM(SumRMOther_Unplan) as SumRMOther_Unplan, " & _
   "SUM(SumRMComputer_Fix) as SumRMComputer_Fix, " & _
   "SUM(SumRMComputer_Unplan) as SumRMComputer_Unplan, " & _
   "SUM(SumProfessionalFee) as SumProfessionalFee, " & _
   "SUM(SumMarketingResearch) as SumMarketingResearch, " & _
   "SUM(SumOtherFee) as SumOtherFee, " & _
   "SUM(SumEquipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
   "SUM(SumPrintingandStationery) as SumPrintingandStationery, " & _
   "SUM(SumSuppliesExpenses) as SumSuppliesExpenses, " & _
   "SUM(SumEquipment) as SumEquipment, " & _
   "SUM(SumShopfitting) as SumShopfitting, " & _
   "SUM(SumPackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
   "SUM(SumBusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
   "SUM(SumCarParkingandOthers) as SumCarParkingandOthers, " & _
   "SUM(SumTravel) as SumTravel, " & _
   "SUM(SumAccomodation) as SumAccomodation, " & _
   "SUM(SumMealandEntertainment) as SumMealandEntertainment, " & _
   "SUM(SumInsurance) as SumInsurance, " & _
   "SUM(SumAllRiskInsurance) as SumAllRiskInsurance, " & _
   "SUM(SumHealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
   "SUM(SumPenaltyandTaxation) as SumPenaltyandTaxation, " & _
   "SUM(SumTaxation) as SumTaxation, " & _
   "SUM(SumPenalty) as SumPenalty, " & _
   "SUM(SumOtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
   "SUM(SumStaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
   "SUM(SumTraining) as SumTraining, " & _
   "SUM(SumCommunication) as SumCommunication, " & _
   "SUM(SumTelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
   "SUM(SumPostageandCourier) as SumPostageandCourier, " & _
   "SUM(SumOtherExpenses) as SumOtherExpenses, " & _
   "SUM(SumSample_Tester) as SumSample_Tester, " & _
   "SUM(SumPreopeningCosts) as SumPreopeningCosts, " & _
   "SUM(SumLossonClaim) as SumLossonClaim, " & _
   "SUM(SumCashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
   "SUM(SumMiscellenousandOther) as SumMiscellenousandOther, " & _
   "SUM(SumStoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
   "SUM(SumTradingProfit__Loss) as SumTradingProfit__Loss, " & _
   "SUM(SumStoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
   "SUM(SumStoreLabourCost) as SumStoreLabourCost, " & _
   "SUM(SumUtillity) as SumUtillity, " & _
   "SUM(SumRepairMaintenance) as SumRepairMaintenance " & _
         "from ( " & _
         "select mt.costcenter_id, " & _
   "SUM(costcenter_total_area) as sumtotalarea, " & _
   "SUM(costcenter_sale_area) as sumsalearea, " & _
   "SUM(TotalRevenue) as SumTotalRevenue, " & _
   "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
   "SUM(OtherRevenue) as SumOtherRevenue, " & _
   "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
   "SUM(GrossProfit) as SumGrossProfit, " & _
   "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
   "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
   "SUM(Shipping) as SumShipping, " & _
   "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
   "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
   "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
   "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
   "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
   "SUM(GWP) as SumGWP, " & _
   "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
   "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
   "SUM(SellingCosts) as SumSellingCosts, " & _
   "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
   "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
   "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
   "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
   "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
   "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
   "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
   "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
   "SUM(GrossPay) as SumGrossPay, " & _
   "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
   "SUM(Allowance) as SumAllowance, " & _
   "SUM(Overtime) as SumOvertime, " & _
   "SUM(Licensefee) as SumLicensefee, " & _
   "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
   "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
   "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
   "SUM(ProvidentFund) as SumProvidentFund, " & _
   "SUM(PensionCosts) as SumPensionCosts, " & _
   "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
   "SUM(Uniforms) as SumUniforms, " & _
   "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
   "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
   "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
   "SUM(PropertyRental) as SumPropertyRental, " & _
   "SUM(PropertyServices) as SumPropertyServices, " & _
   "SUM(PropertyFacility) as SumPropertyFacility, " & _
   "SUM(Propertytaxes) as SumPropertytaxes, " & _
   "SUM(Facialtaxes) as SumFacialtaxes, " & _
   "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
   "SUM(Signboard) as SumSignboard, " & _
   "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
   "SUM(GPCommission) as SumGPCommission, " & _
   "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
   "SUM(Depreciation) as SumDepreciation, " & _
   "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
   "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
   "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
   "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
   "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
   "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
   "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
   "SUM(BankCharges) as SumBankCharges, " & _
   "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
   "SUM(Cleaning) as SumCleaning, " & _
   "SUM(SecurityGuards) as SumSecurityGuards, " & _
   "SUM(Carriage) as SumCarriage, " & _
   "SUM(LicenceFees) as SumLicenceFees, " & _
   "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
   "SUM(OtherFees) as SumOtherFees, " & _
   "SUM(Utilities) as SumUtilities, " & _
   "SUM(Water) as SumWater, " & _
   "SUM(Gas_Electric) as SumGas_Electric, " & _
   "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
   "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
   "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
   "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
   "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
   "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
   "SUM(ProfessionalFee) as SumProfessionalFee, " & _
   "SUM(MarketingResearch) as SumMarketingResearch, " & _
   "SUM(OtherFee) as SumOtherFee, " & _
   "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
   "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
   "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
   "SUM(Equipment) as SumEquipment, " & _
   "SUM(Shopfitting) as SumShopfitting, " & _
   "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
   "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
   "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
   "SUM(Travel) as SumTravel, " & _
   "SUM(Accomodation) as SumAccomodation, " & _
   "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
   "SUM(Insurance) as SumInsurance, " & _
   "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
   "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
   "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
   "SUM(Taxation) as SumTaxation, " & _
   "SUM(Penalty) as SumPenalty, " & _
   "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
   "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
   "SUM(Training) as SumTraining, " & _
   "SUM(Communication) as SumCommunication, " & _
   "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
   "SUM(PostageandCourier) as SumPostageandCourier, " & _
   "SUM(OtherExpenses) as SumOtherExpenses, " & _
   "SUM(Sample_Tester) as SumSample_Tester, " & _
   "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
   "SUM(LossonClaim) as SumLossonClaim, " & _
   "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
   "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
   "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
   "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
   "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
   "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
   "SUM(Utillity) as SumUtillity, " & _
   "SUM(RepairMaintenance) as SumRepairMaintenance " & _
          "from ( " & _
         "select mta.* " & _
         "from v_mtd('" + rate + "') mta,costcenter cca " & _
         " where mta.costcenter_id = cca.costcenter_id And " & _
         "cca.costcenter_blockdt Is null And " & _
         "mta.month_time <= @select_dt and " & _
         "mta.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'   " & _
         " union " & _
         "select mtb.* " & _
         "from v_mtd('" + rate + "') mtb,costcenter ccb " & _
         "where mtb.costcenter_id = ccb.costcenter_id And " & _
         "ccb.costcenter_blockdt >= @sl_dt and " & _
         "mtb.month_time <= @select_dt and " & _
         "mtb.month_time >= '" + DateTime.ParseExact(start_time, ClsManage.formatDateTime, Nothing) + "'  " & _
         ") mt,costcenter cc  " & _
         "where mt.costcenter_id = cc.costcenter_id " & _
         " " + area + " " & _
         " and cc.costcenter_opendt < @sl_dt " & _
         "group by mt.costcenter_id " & _
         ") mt2,costcenter cs " & _
         "where mt2.costcenter_id = cs.costcenter_id " & _
         "group by cs.costcenter_store " & _
         ") bb,store st1 " & _
         "where bb.costcenter_store = st1.store_id and bb.costcenter_store=" + store

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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullMtdModel(ByVal years As String, ByVal mon As String, ByVal locate As String, rate As String, Optional total As Boolean = False) As DataTable

        Dim area As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")

        'If locate <> "ALL" And locate <> "TWO" Then
        '    area = " and cc.costcenter_location='" + locate + "' "
        'End If

        Dim sql As String = "SELECT *,'0.0%' as lfl_growth,'0.0%' as yoy_growth,'0.0%' as lfl_loss_growth,'0.0%' as yoy_loss_growth from ( " & _
            "SELECT COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store,SUM(TotalRevenue)/SUM(costcenter_sale_area) as productivity, " & _
            "SUM(costcenter_total_area) as Sumtotalarea,SUM(costcenter_sale_area) as Sumsalearea, " & _
            "" + columnMtd() + "" & _
            " from " + sqlTbl + " mt,costcenter cc " & _
            " where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "'  " & _
            " AND (cc.costcenter_location = @locate OR @locate = '' )" & _
            " AND cc.costcenter_opendt < @sl_dt " & _
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

        parameter = New SqlParameter("@locate", SqlDbType.VarChar)
        parameter.Value = locate
        cmd.Parameters.Add(parameter)

        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                'Add row for total
                If total = True Then
                    Dim dtTotal As New DataTable
                    dtTotal = dt.Clone

                    Dim drTotal As DataRow = dtTotal.NewRow
                    Dim colName As String = ""
                    For i As Integer = 0 To dt.Columns.Count - 1
                        colName = drTotal.Table.Columns(i).ColumnName
                        If colName.Contains("Sum") Then
                            drTotal(i) = dt.Compute("Sum(" + colName + ")", "")
                        ElseIf colName.Contains("growth") Then
                            drTotal(i) = "0.000%"
                        End If
                    Next
                    drTotal("cnum") = Integer.Parse(dt.Compute("Sum(cnum)", "")) - Integer.Parse(dt.Compute("Sum(cnum)", "store_id=8"))
                    drTotal("productivity") = dt.Compute("Sum(SumTotalRevenue)", "") / dt.Compute("Sum(sumsalearea)", "")
                    drTotal("store_id") = 0
                    drTotal("costcenter_store") = 0
                    drTotal("store_name") = "Total"
                    dtTotal.Rows.InsertAt(drTotal, 0)

                    Return dtTotal

                End If


                Dim dtlflG As New DataTable
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

                'YOY
                Dim dtPreMtd As New DataTable
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
            End If
            Return dt

        Catch ex As Exception
            Throw ex
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
  "SUM(SumTotalRevenue) as SumTotalRevenue, " & _
  "SUM(SumRETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
  "SUM(SumOtherRevenue) as SumOtherRevenue, " & _
  "SUM(SumCostofGoodSold) as SumCostofGoodSold, " & _
  "SUM(SumGrossProfit) as SumGrossProfit, " & _
  "SUM(SumGrossProfit_percent) as SumGrossProfit_percent, " & _
  "SUM(SumMarginAdjustments) as SumMarginAdjustments, " & _
  "SUM(SumShipping) as SumShipping, " & _
  "SUM(SumStockLossandObsolescence) as SumStockLossandObsolescence, " & _
  "SUM(SumInventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
  "SUM(SumInventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
  "SUM(SumStockLoss_Provision) as SumStockLoss_Provision, " & _
  "SUM(SumStockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
  "SUM(SumGWP) as SumGWP, " & _
  "SUM(SumGWPs_Corporate) as SumGWPs_Corporate, " & _
  "SUM(SumGWPs_Transferred) as SumGWPs_Transferred, " & _
  "SUM(SumSellingCosts) as SumSellingCosts, " & _
  "SUM(SumCreditcardscommission) as SumCreditcardscommission, " & _
  "SUM(SumLabellingMaterial) as SumLabellingMaterial, " & _
  "SUM(SumOtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
  "SUM(SumOtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
  "SUM(SumAdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
  "SUM(SumSupplyChainCosts) as SumSupplyChainCosts, " & _
  "SUM(SumTotalStoreExpenses) as SumTotalStoreExpenses, " & _
  "SUM(SumStoreLabourCosts) as SumStoreLabourCosts, " & _
  "SUM(SumGrossPay) as SumGrossPay, " & _
  "SUM(SumTemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
  "SUM(SumAllowance) as SumAllowance, " & _
  "SUM(SumOvertime) as SumOvertime, " & _
  "SUM(SumLicensefee) as SumLicensefee, " & _
  "SUM(SumBonuses_Incentives) as SumBonuses_Incentives, " & _
  "SUM(SumBootsBrandncentives) as SumBootsBrandncentives, " & _
  "SUM(SumSuppliersIncentive) as SumSuppliersIncentive, " & _
  "SUM(SumProvidentFund) as SumProvidentFund, " & _
  "SUM(SumPensionCosts) as SumPensionCosts, " & _
  "SUM(SumSocialSecurityFund) as SumSocialSecurityFund, " & _
  "SUM(SumUniforms) as SumUniforms, " & _
  "SUM(SumEmployeeWelfare) as SumEmployeeWelfare, " & _
  "SUM(SumOtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
  "SUM(SumStorePropertyCosts) as SumStorePropertyCosts, " & _
  "SUM(SumPropertyRental) as SumPropertyRental, " & _
  "SUM(SumPropertyServices) as SumPropertyServices, " & _
  "SUM(SumPropertyFacility) as SumPropertyFacility, " & _
  "SUM(SumPropertytaxes) as SumPropertytaxes, " & _
  "SUM(SumFacialtaxes) as SumFacialtaxes, " & _
  "SUM(SumPropertyInsurance) as SumPropertyInsurance, " & _
  "SUM(SumSignboard) as SumSignboard, " & _
  "SUM(SumDiscount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
  "SUM(SumGPCommission) as SumGPCommission, " & _
  "SUM(SumAmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
  "SUM(SumDepreciation) as SumDepreciation, " & _
  "SUM(SumDepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
  "SUM(SumDepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
  "SUM(SumDepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
  "SUM(SumDepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
  "SUM(SumDepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
  "SUM(SumOtherStoreCosts) as SumOtherStoreCosts, " & _
  "SUM(SumServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
  "SUM(SumBankCharges) as SumBankCharges, " & _
  "SUM(SumCashCollectionCharge) as SumCashCollectionCharge, " & _
  "SUM(SumCleaning) as SumCleaning, " & _
  "SUM(SumSecurityGuards) as SumSecurityGuards, " & _
  "SUM(SumCarriage) as SumCarriage, " & _
  "SUM(SumLicenceFees) as SumLicenceFees, " & _
  "SUM(SumOtherServicesCharge) as SumOtherServicesCharge, " & _
  "SUM(SumOtherFees) as SumOtherFees, " & _
  "SUM(SumUtilities) as SumUtilities, " & _
  "SUM(SumWater) as SumWater, " & _
  "SUM(SumGas_Electric) as SumGas_Electric, " & _
  "SUM(SumAirCond_Addition) as SumAirCond_Addition, " & _
  "SUM(SumRepairandMaintenance) as SumRepairandMaintenance, " & _
  "SUM(SumRMOther_Fix) as SumRMOther_Fix, " & _
  "SUM(SumRMOther_Unplan) as SumRMOther_Unplan, " & _
  "SUM(SumRMComputer_Fix) as SumRMComputer_Fix, " & _
  "SUM(SumRMComputer_Unplan) as SumRMComputer_Unplan, " & _
  "SUM(SumProfessionalFee) as SumProfessionalFee, " & _
  "SUM(SumMarketingResearch) as SumMarketingResearch, " & _
  "SUM(SumOtherFee) as SumOtherFee, " & _
  "SUM(SumEquipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
  "SUM(SumPrintingandStationery) as SumPrintingandStationery, " & _
  "SUM(SumSuppliesExpenses) as SumSuppliesExpenses, " & _
  "SUM(SumEquipment) as SumEquipment, " & _
  "SUM(SumShopfitting) as SumShopfitting, " & _
  "SUM(SumPackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
  "SUM(SumBusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
  "SUM(SumCarParkingandOthers) as SumCarParkingandOthers, " & _
  "SUM(SumTravel) as SumTravel, " & _
  "SUM(SumAccomodation) as SumAccomodation, " & _
  "SUM(SumMealandEntertainment) as SumMealandEntertainment, " & _
  "SUM(SumInsurance) as SumInsurance, " & _
  "SUM(SumAllRiskInsurance) as SumAllRiskInsurance, " & _
  "SUM(SumHealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
  "SUM(SumPenaltyandTaxation) as SumPenaltyandTaxation, " & _
  "SUM(SumTaxation) as SumTaxation, " & _
  "SUM(SumPenalty) as SumPenalty, " & _
  "SUM(SumOtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
  "SUM(SumStaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
  "SUM(SumTraining) as SumTraining, " & _
  "SUM(SumCommunication) as SumCommunication, " & _
  "SUM(SumTelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
  "SUM(SumPostageandCourier) as SumPostageandCourier, " & _
  "SUM(SumOtherExpenses) as SumOtherExpenses, " & _
  "SUM(SumSample_Tester) as SumSample_Tester, " & _
  "SUM(SumPreopeningCosts) as SumPreopeningCosts, " & _
  "SUM(SumLossonClaim) as SumLossonClaim, " & _
  "SUM(SumCashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
  "SUM(SumMiscellenousandOther) as SumMiscellenousandOther, " & _
  "SUM(SumStoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
  "SUM(SumTradingProfit__Loss) as SumTradingProfit__Loss, " & _
  "SUM(SumStoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
  "SUM(SumStoreLabourCost) as SumStoreLabourCost, " & _
  "SUM(SumUtillity) as SumUtillity, " & _
  "SUM(SumRepairMaintenance) as SumRepairMaintenance " & _
        "from ( " & _
  "select SUM(TotalRevenue) as SumTotalRevenue, " & _
  "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
  "SUM(OtherRevenue) as SumOtherRevenue, " & _
  "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
  "SUM(GrossProfit) as SumGrossProfit, " & _
  "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
  "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
  "SUM(Shipping) as SumShipping, " & _
  "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
  "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
  "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
  "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
  "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
  "SUM(GWP) as SumGWP, " & _
  "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
  "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
  "SUM(SellingCosts) as SumSellingCosts, " & _
  "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
  "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
  "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
  "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
  "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
  "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
  "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
  "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
  "SUM(GrossPay) as SumGrossPay, " & _
  "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
  "SUM(Allowance) as SumAllowance, " & _
  "SUM(Overtime) as SumOvertime, " & _
  "SUM(Licensefee) as SumLicensefee, " & _
  "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
  "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
  "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
  "SUM(ProvidentFund) as SumProvidentFund, " & _
  "SUM(PensionCosts) as SumPensionCosts, " & _
  "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
  "SUM(Uniforms) as SumUniforms, " & _
  "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
  "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
  "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
  "SUM(PropertyRental) as SumPropertyRental, " & _
  "SUM(PropertyServices) as SumPropertyServices, " & _
  "SUM(PropertyFacility) as SumPropertyFacility, " & _
  "SUM(Propertytaxes) as SumPropertytaxes, " & _
  "SUM(Facialtaxes) as SumFacialtaxes, " & _
  "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
  "SUM(Signboard) as SumSignboard, " & _
  "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
  "SUM(GPCommission) as SumGPCommission, " & _
  "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
  "SUM(Depreciation) as SumDepreciation, " & _
  "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
  "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
  "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
  "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
  "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
  "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
  "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
  "SUM(BankCharges) as SumBankCharges, " & _
  "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
  "SUM(Cleaning) as SumCleaning, " & _
  "SUM(SecurityGuards) as SumSecurityGuards, " & _
  "SUM(Carriage) as SumCarriage, " & _
  "SUM(LicenceFees) as SumLicenceFees, " & _
  "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
  "SUM(OtherFees) as SumOtherFees, " & _
  "SUM(Utilities) as SumUtilities, " & _
  "SUM(Water) as SumWater, " & _
  "SUM(Gas_Electric) as SumGas_Electric, " & _
  "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
  "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
  "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
  "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
  "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
  "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
  "SUM(ProfessionalFee) as SumProfessionalFee, " & _
  "SUM(MarketingResearch) as SumMarketingResearch, " & _
  "SUM(OtherFee) as SumOtherFee, " & _
  "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
  "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
  "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
  "SUM(Equipment) as SumEquipment, " & _
  "SUM(Shopfitting) as SumShopfitting, " & _
  "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
  "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
  "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
  "SUM(Travel) as SumTravel, " & _
  "SUM(Accomodation) as SumAccomodation, " & _
  "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
  "SUM(Insurance) as SumInsurance, " & _
  "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
  "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
  "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
  "SUM(Taxation) as SumTaxation, " & _
  "SUM(Penalty) as SumPenalty, " & _
  "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
  "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
  "SUM(Training) as SumTraining, " & _
  "SUM(Communication) as SumCommunication, " & _
  "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
  "SUM(PostageandCourier) as SumPostageandCourier, " & _
  "SUM(OtherExpenses) as SumOtherExpenses, " & _
  "SUM(Sample_Tester) as SumSample_Tester, " & _
  "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
  "SUM(LossonClaim) as SumLossonClaim, " & _
  "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
  "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
  "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
  "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
  "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
  "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
  "SUM(Utillity) as SumUtillity, " & _
  "SUM(RepairMaintenance) as SumRepairMaintenance, mt.costcenter_id " & _
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
   "SUM(SumTotalRevenue) as SumTotalRevenue, " & _
   "SUM(SumRETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
   "SUM(SumOtherRevenue) as SumOtherRevenue, " & _
   "SUM(SumCostofGoodSold) as SumCostofGoodSold, " & _
   "SUM(SumGrossProfit) as SumGrossProfit, " & _
   "SUM(SumGrossProfit_percent) as SumGrossProfit_percent, " & _
   "SUM(SumMarginAdjustments) as SumMarginAdjustments, " & _
   "SUM(SumShipping) as SumShipping, " & _
   "SUM(SumStockLossandObsolescence) as SumStockLossandObsolescence, " & _
   "SUM(SumInventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
   "SUM(SumInventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
   "SUM(SumStockLoss_Provision) as SumStockLoss_Provision, " & _
   "SUM(SumStockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
   "SUM(SumGWP) as SumGWP, " & _
   "SUM(SumGWPs_Corporate) as SumGWPs_Corporate, " & _
   "SUM(SumGWPs_Transferred) as SumGWPs_Transferred, " & _
   "SUM(SumSellingCosts) as SumSellingCosts, " & _
   "SUM(SumCreditcardscommission) as SumCreditcardscommission, " & _
   "SUM(SumLabellingMaterial) as SumLabellingMaterial, " & _
   "SUM(SumOtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
   "SUM(SumOtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
   "SUM(SumAdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
   "SUM(SumSupplyChainCosts) as SumSupplyChainCosts, " & _
   "SUM(SumTotalStoreExpenses) as SumTotalStoreExpenses, " & _
   "SUM(SumStoreLabourCosts) as SumStoreLabourCosts, " & _
   "SUM(SumGrossPay) as SumGrossPay, " & _
   "SUM(SumTemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
   "SUM(SumAllowance) as SumAllowance, " & _
   "SUM(SumOvertime) as SumOvertime, " & _
   "SUM(SumLicensefee) as SumLicensefee, " & _
   "SUM(SumBonuses_Incentives) as SumBonuses_Incentives, " & _
   "SUM(SumBootsBrandncentives) as SumBootsBrandncentives, " & _
   "SUM(SumSuppliersIncentive) as SumSuppliersIncentive, " & _
   "SUM(SumProvidentFund) as SumProvidentFund, " & _
   "SUM(SumPensionCosts) as SumPensionCosts, " & _
   "SUM(SumSocialSecurityFund) as SumSocialSecurityFund, " & _
   "SUM(SumUniforms) as SumUniforms, " & _
   "SUM(SumEmployeeWelfare) as SumEmployeeWelfare, " & _
   "SUM(SumOtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
   "SUM(SumStorePropertyCosts) as SumStorePropertyCosts, " & _
   "SUM(SumPropertyRental) as SumPropertyRental, " & _
   "SUM(SumPropertyServices) as SumPropertyServices, " & _
   "SUM(SumPropertyFacility) as SumPropertyFacility, " & _
   "SUM(SumPropertytaxes) as SumPropertytaxes, " & _
   "SUM(SumFacialtaxes) as SumFacialtaxes, " & _
   "SUM(SumPropertyInsurance) as SumPropertyInsurance, " & _
   "SUM(SumSignboard) as SumSignboard, " & _
   "SUM(SumDiscount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
   "SUM(SumGPCommission) as SumGPCommission, " & _
   "SUM(SumAmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
   "SUM(SumDepreciation) as SumDepreciation, " & _
   "SUM(SumDepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
   "SUM(SumDepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
   "SUM(SumDepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
   "SUM(SumDepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
   "SUM(SumDepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
   "SUM(SumOtherStoreCosts) as SumOtherStoreCosts, " & _
   "SUM(SumServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
   "SUM(SumBankCharges) as SumBankCharges, " & _
   "SUM(SumCashCollectionCharge) as SumCashCollectionCharge, " & _
   "SUM(SumCleaning) as SumCleaning, " & _
   "SUM(SumSecurityGuards) as SumSecurityGuards, " & _
   "SUM(SumCarriage) as SumCarriage, " & _
   "SUM(SumLicenceFees) as SumLicenceFees, " & _
   "SUM(SumOtherServicesCharge) as SumOtherServicesCharge, " & _
   "SUM(SumOtherFees) as SumOtherFees, " & _
   "SUM(SumUtilities) as SumUtilities, " & _
   "SUM(SumWater) as SumWater, " & _
   "SUM(SumGas_Electric) as SumGas_Electric, " & _
   "SUM(SumAirCond_Addition) as SumAirCond_Addition, " & _
   "SUM(SumRepairandMaintenance) as SumRepairandMaintenance, " & _
   "SUM(SumRMOther_Fix) as SumRMOther_Fix, " & _
   "SUM(SumRMOther_Unplan) as SumRMOther_Unplan, " & _
   "SUM(SumRMComputer_Fix) as SumRMComputer_Fix, " & _
   "SUM(SumRMComputer_Unplan) as SumRMComputer_Unplan, " & _
   "SUM(SumProfessionalFee) as SumProfessionalFee, " & _
   "SUM(SumMarketingResearch) as SumMarketingResearch, " & _
   "SUM(SumOtherFee) as SumOtherFee, " & _
   "SUM(SumEquipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
   "SUM(SumPrintingandStationery) as SumPrintingandStationery, " & _
   "SUM(SumSuppliesExpenses) as SumSuppliesExpenses, " & _
   "SUM(SumEquipment) as SumEquipment, " & _
   "SUM(SumShopfitting) as SumShopfitting, " & _
   "SUM(SumPackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
   "SUM(SumBusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
   "SUM(SumCarParkingandOthers) as SumCarParkingandOthers, " & _
   "SUM(SumTravel) as SumTravel, " & _
   "SUM(SumAccomodation) as SumAccomodation, " & _
   "SUM(SumMealandEntertainment) as SumMealandEntertainment, " & _
   "SUM(SumInsurance) as SumInsurance, " & _
   "SUM(SumAllRiskInsurance) as SumAllRiskInsurance, " & _
   "SUM(SumHealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
   "SUM(SumPenaltyandTaxation) as SumPenaltyandTaxation, " & _
   "SUM(SumTaxation) as SumTaxation, " & _
   "SUM(SumPenalty) as SumPenalty, " & _
   "SUM(SumOtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
   "SUM(SumStaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
   "SUM(SumTraining) as SumTraining, " & _
   "SUM(SumCommunication) as SumCommunication, " & _
   "SUM(SumTelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
   "SUM(SumPostageandCourier) as SumPostageandCourier, " & _
   "SUM(SumOtherExpenses) as SumOtherExpenses, " & _
   "SUM(SumSample_Tester) as SumSample_Tester, " & _
   "SUM(SumPreopeningCosts) as SumPreopeningCosts, " & _
   "SUM(SumLossonClaim) as SumLossonClaim, " & _
   "SUM(SumCashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
   "SUM(SumMiscellenousandOther) as SumMiscellenousandOther, " & _
   "SUM(SumStoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
   "SUM(SumTradingProfit__Loss) as SumTradingProfit__Loss, " & _
   "SUM(SumStoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
   "SUM(SumStoreLabourCost) as SumStoreLabourCost, " & _
   "SUM(SumUtillity) as SumUtillity, " & _
   "SUM(SumRepairMaintenance) as SumRepairMaintenance " & _
         "from ( " & _
         "select SUM(TotalRevenue) as SumTotalRevenue, " & _
   "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
   "SUM(OtherRevenue) as SumOtherRevenue, " & _
   "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
   "SUM(GrossProfit) as SumGrossProfit, " & _
   "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
   "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
   "SUM(Shipping) as SumShipping, " & _
   "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
   "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
   "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
   "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
   "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
   "SUM(GWP) as SumGWP, " & _
   "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
   "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
   "SUM(SellingCosts) as SumSellingCosts, " & _
   "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
   "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
   "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
   "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
   "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
   "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
   "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
   "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
   "SUM(GrossPay) as SumGrossPay, " & _
   "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
   "SUM(Allowance) as SumAllowance, " & _
   "SUM(Overtime) as SumOvertime, " & _
   "SUM(Licensefee) as SumLicensefee, " & _
   "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
   "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
   "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
   "SUM(ProvidentFund) as SumProvidentFund, " & _
   "SUM(PensionCosts) as SumPensionCosts, " & _
   "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
   "SUM(Uniforms) as SumUniforms, " & _
   "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
   "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
   "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
   "SUM(PropertyRental) as SumPropertyRental, " & _
   "SUM(PropertyServices) as SumPropertyServices, " & _
   "SUM(PropertyFacility) as SumPropertyFacility, " & _
   "SUM(Propertytaxes) as SumPropertytaxes, " & _
   "SUM(Facialtaxes) as SumFacialtaxes, " & _
   "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
   "SUM(Signboard) as SumSignboard, " & _
   "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
   "SUM(GPCommission) as SumGPCommission, " & _
   "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
   "SUM(Depreciation) as SumDepreciation, " & _
   "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
   "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
   "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
   "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
   "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
   "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
   "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
   "SUM(BankCharges) as SumBankCharges, " & _
   "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
   "SUM(Cleaning) as SumCleaning, " & _
   "SUM(SecurityGuards) as SumSecurityGuards, " & _
   "SUM(Carriage) as SumCarriage, " & _
   "SUM(LicenceFees) as SumLicenceFees, " & _
   "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
   "SUM(OtherFees) as SumOtherFees, " & _
   "SUM(Utilities) as SumUtilities, " & _
   "SUM(Water) as SumWater, " & _
   "SUM(Gas_Electric) as SumGas_Electric, " & _
   "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
   "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
   "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
   "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
   "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
   "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
   "SUM(ProfessionalFee) as SumProfessionalFee, " & _
   "SUM(MarketingResearch) as SumMarketingResearch, " & _
   "SUM(OtherFee) as SumOtherFee, " & _
   "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
   "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
   "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
   "SUM(Equipment) as SumEquipment, " & _
   "SUM(Shopfitting) as SumShopfitting, " & _
   "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
   "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
   "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
   "SUM(Travel) as SumTravel, " & _
   "SUM(Accomodation) as SumAccomodation, " & _
   "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
   "SUM(Insurance) as SumInsurance, " & _
   "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
   "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
   "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
   "SUM(Taxation) as SumTaxation, " & _
   "SUM(Penalty) as SumPenalty, " & _
   "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
   "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
   "SUM(Training) as SumTraining, " & _
   "SUM(Communication) as SumCommunication, " & _
   "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
   "SUM(PostageandCourier) as SumPostageandCourier, " & _
   "SUM(OtherExpenses) as SumOtherExpenses, " & _
   "SUM(Sample_Tester) as SumSample_Tester, " & _
   "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
   "SUM(LossonClaim) as SumLossonClaim, " & _
   "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
   "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
   "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
   "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
   "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
   "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
   "SUM(Utillity) as SumUtillity, " & _
   "SUM(RepairMaintenance) as SumRepairMaintenance, mt.costcenter_id " & _
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

        sql = "select " + columnSumMtd() + ",years from (" + sqlCon1 + " UNION " + sqlCon2 + ") yoy order by years DESC"

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

        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Dim dtSum As New DataTable : dtSum = dt.Clone
            If dt.Rows.Count > 0 Then
                Dim drSum As DataRow = dtSum.NewRow
                Dim drSum2 As DataRow = dtSum.NewRow
                Dim colName As String = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    colName = drSum.Table.Columns(i).ColumnName
                    If colName.Contains("Sum") Then
                        drSum(i) = dt.Compute("Sum(" + colName + ")", "years=" + (years + 1).ToString + "")
                        drSum2(i) = dt.Compute("Sum(" + colName + ")", "years=" + years.ToString + "")
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
                        dr(i) = (num / divi) - 1
                    End If
                Next
                dr("years") = 0
                dtSum.Rows.Add(dr)
            End If
            Return dtSum

        Catch ex As Exception
            Throw ex
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

        sqlCol = "SELECT " + columnMtd()
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

        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
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

                    If dt.Rows(0).Table.Columns(i).ColumnName = "SumGrossProfit" Or dt.Rows(0).Table.Columns(i).ColumnName = "SumAdjustedGrossMargin" Or dt.Rows(0).Table.Columns(i).ColumnName = "SumStoreTradingProfit__Loss" Then

                        Dim thisPb As Double = 0 : Dim prePb As Double = 0 : Dim pb As Double = 0
                        If Not (IsDBNull(dt.Rows(1)(0)) Or IsDBNull(dt.Rows(1)(i)) Or IsDBNull(dt.Rows(0)(0)) Or IsDBNull(dt.Rows(0)(i))) Then
                            thisPb = dt.Rows(0)(i) / dt.Rows(0)(0)
                            prePb = dt.Rows(1)(i) / dt.Rows(1)(0)
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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
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

    Public Shared Function getSumFullMtdByCost(ByVal fdate As String, ByVal tdate As String, ByVal cost_id As String, Optional rate As String = "") As DataTable

        Dim sql As String = "select * from (select month_time, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance " & _
"from v_mtd('" + rate + "') mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and cc.costcenter_id='" + cost_id + "' and mt.month_time >='" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
"group by month_time ) sm order by sm.month_time asc "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumMFulltdModelByBangkok(ByVal years As String, ByVal mon As String, ByVal locate As String, ByVal store As String, Optional rate As String = "") As DataTable

        Dim area As String = ""

        If locate <> "ALL" And locate <> "TWO" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        Dim sql As String = "select * from (select COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance " & _
"from v_mtd('" + rate + "') mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt ) and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " + area + " " & _
" and cc.costcenter_opendt < @sl_dt " & _
"group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id and sm.costcenter_store=" + store

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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getMtdModelByID(ByVal id As String) As DataTable

        Dim sql As String = " select SUM(TotalRevenue) as sumtotal, " & _
" SUM(RETAIL_TESPIncome) as sumretail, " & _
" SUM(OtherRevenue) as sumOtherRevenue, " & _
" SUM(CostofGoodSold) as sumCostofGoodSold, " & _
" SUM(GrossProfit) as sumGrossProfit, " & _
" SUM(MarginAdjustments) as sumMarginAdjustments, " & _
" SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin, " & _
" SUM(SupplyChainCosts) as sumSupplyChainCosts, " & _
" SUM(TotalStoreExpenses) as sumTotalStoreExpenses, " & _
" SUM(StoreLabourCosts) as sumStoreLabourCosts, " & _
" SUM(StorePropertyCosts) as StorePropertyCosts, " & _
" SUM(Depreciation) as Depreciation, " & _
" SUM(OtherStoreCosts) as OtherStoreCosts, " & _
" SUM(StoreTradingProfit__Loss) as StoreTradingProfit__Loss " & _
" from mtd mt,costcenter cc " & _
" where mt.costcenter_id = cc.costcenter_id and year(month_time) = '2011' and month(month_time) = '11' and costcenter_store='" + id + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumModelByStore(ByVal fdate As String, ByVal tdate As String, ByVal cost_id As String) As DataTable

        Dim sql As String = "select sm.*, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code,SUM(TotalRevenue) as sumtotal, " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(RETAIL_TESPIncome) as sumretail, " & _
"SUM(OtherRevenue) as sumOtherRevenue, " & _
"SUM(CostofGoodSold) as sumCostofGoodSold, " & _
"SUM(GrossProfit) as sumGrossProfit, " & _
"SUM(MarginAdjustments) as sumMarginAdjustments, " & _
"SUM(AdjustedGrossMargin) as sumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as sumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as sumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as sumStoreLabourCosts, " & _
"SUM(StorePropertyCosts) as sumStorePropertyCosts, " & _
"SUM(Depreciation) as sumDepreciation, " & _
"SUM(OtherStoreCosts) as sumOtherStoreCosts, " & _
"SUM(StoreTradingProfit__Loss) as sumStoreTradingProfit__Loss " & _
"from " & _
"( " & _
"select mta.* " & _
"from mtd mta,costcenter cca " & _
" where mta.costcenter_id = cca.costcenter_id And " & _
"cca.costcenter_blockdt Is null And " & _
"mta.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
"mta.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'   " & _
" union " & _
"select mtb.* " & _
"from mtd mtb,costcenter ccb " & _
"where mtb.costcenter_id = ccb.costcenter_id And " & _
"ccb.costcenter_blockdt > '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
"mtb.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
"mtb.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'  " & _
")" & _
" mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and cc.costcenter_store='" + cost_id + "' " & _
"group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code order by sm.costcenter_code asc "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullModelByStore(ByVal fdate As String, ByVal tdate As String, ByVal cost_id As String, ByVal locate As String, Optional rate As String = "") As DataTable

        Dim area As String = ""
        Dim store As String = ""

        If locate <> "ALL" And locate <> "TWO" Then
            area = " and cc.costcenter_location='" + locate + "' "
        End If

        If cost_id <> "ALL" Then
            store = " and cc.costcenter_store='" + cost_id + "' "
        End If

        Dim sql As String = ""
        If fdate = tdate Then
            sql = "select sm.*, ctt.costcenter_name, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code, " & _
   "SUM(TotalRevenue) as SumTotalRevenue, " & _
   "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
   "SUM(OtherRevenue) as SumOtherRevenue, " & _
   "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
   "SUM(GrossProfit) as SumGrossProfit, " & _
   "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
   "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
   "SUM(Shipping) as SumShipping, " & _
   "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
   "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
   "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
   "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
   "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
   "SUM(GWP) as SumGWP, " & _
   "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
   "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
   "SUM(SellingCosts) as SumSellingCosts, " & _
   "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
   "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
   "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
   "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
   "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
   "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
   "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
   "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
   "SUM(GrossPay) as SumGrossPay, " & _
   "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
   "SUM(Allowance) as SumAllowance, " & _
   "SUM(Overtime) as SumOvertime, " & _
   "SUM(Licensefee) as SumLicensefee, " & _
   "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
   "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
   "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
   "SUM(ProvidentFund) as SumProvidentFund, " & _
   "SUM(PensionCosts) as SumPensionCosts, " & _
   "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
   "SUM(Uniforms) as SumUniforms, " & _
   "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
   "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
   "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
   "SUM(PropertyRental) as SumPropertyRental, " & _
   "SUM(PropertyServices) as SumPropertyServices, " & _
   "SUM(PropertyFacility) as SumPropertyFacility, " & _
   "SUM(Propertytaxes) as SumPropertytaxes, " & _
   "SUM(Facialtaxes) as SumFacialtaxes, " & _
   "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
   "SUM(Signboard) as SumSignboard, " & _
   "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
   "SUM(GPCommission) as SumGPCommission, " & _
   "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
   "SUM(Depreciation) as SumDepreciation, " & _
   "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
   "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
   "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
   "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
   "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
   "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
   "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
   "SUM(BankCharges) as SumBankCharges, " & _
   "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
   "SUM(Cleaning) as SumCleaning, " & _
   "SUM(SecurityGuards) as SumSecurityGuards, " & _
   "SUM(Carriage) as SumCarriage, " & _
   "SUM(LicenceFees) as SumLicenceFees, " & _
   "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
   "SUM(OtherFees) as SumOtherFees, " & _
   "SUM(Utilities) as SumUtilities, " & _
   "SUM(Water) as SumWater, " & _
   "SUM(Gas_Electric) as SumGas_Electric, " & _
   "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
   "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
   "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
   "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
   "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
   "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
   "SUM(ProfessionalFee) as SumProfessionalFee, " & _
   "SUM(MarketingResearch) as SumMarketingResearch, " & _
   "SUM(OtherFee) as SumOtherFee, " & _
   "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
   "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
   "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
   "SUM(Equipment) as SumEquipment, " & _
   "SUM(Shopfitting) as SumShopfitting, " & _
   "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
   "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
   "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
   "SUM(Travel) as SumTravel, " & _
   "SUM(Accomodation) as SumAccomodation, " & _
   "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
   "SUM(Insurance) as SumInsurance, " & _
   "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
   "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
   "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
   "SUM(Taxation) as SumTaxation, " & _
   "SUM(Penalty) as SumPenalty, " & _
   "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
   "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
   "SUM(Training) as SumTraining, " & _
   "SUM(Communication) as SumCommunication, " & _
   "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
   "SUM(PostageandCourier) as SumPostageandCourier, " & _
   "SUM(OtherExpenses) as SumOtherExpenses, " & _
   "SUM(Sample_Tester) as SumSample_Tester, " & _
   "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
   "SUM(LossonClaim) as SumLossonClaim, " & _
   "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
   "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
   "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
   "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
   "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
   "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
   "SUM(Utillity) as SumUtillity, " & _
   "SUM(RepairMaintenance) as SumRepairMaintenance " & _
  "from v_mtd('" + rate + "') mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' )  and month_time = '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
" " + area + " and cc.costcenter_opendt < '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' " + store + " " & _
 "group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code order by sm.costcenter_code asc "

        Else
            sql = "select sm.*, ctt.costcenter_name, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code, " & _
    "SUM(TotalRevenue) as SumTotalRevenue, " & _
    "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    "SUM(OtherRevenue) as SumOtherRevenue, " & _
    "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    "SUM(GrossProfit) as SumGrossProfit, " & _
    "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    "SUM(Shipping) as SumShipping, " & _
    "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    "SUM(GWP) as SumGWP, " & _
    "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    "SUM(SellingCosts) as SumSellingCosts, " & _
    "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    "SUM(GrossPay) as SumGrossPay, " & _
    "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    "SUM(Allowance) as SumAllowance, " & _
    "SUM(Overtime) as SumOvertime, " & _
    "SUM(Licensefee) as SumLicensefee, " & _
    "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    "SUM(ProvidentFund) as SumProvidentFund, " & _
    "SUM(PensionCosts) as SumPensionCosts, " & _
    "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    "SUM(Uniforms) as SumUniforms, " & _
    "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    "SUM(PropertyRental) as SumPropertyRental, " & _
    "SUM(PropertyServices) as SumPropertyServices, " & _
    "SUM(PropertyFacility) as SumPropertyFacility, " & _
    "SUM(Propertytaxes) as SumPropertytaxes, " & _
    "SUM(Facialtaxes) as SumFacialtaxes, " & _
    "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    "SUM(Signboard) as SumSignboard, " & _
    "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    "SUM(GPCommission) as SumGPCommission, " & _
    "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    "SUM(Depreciation) as SumDepreciation, " & _
    "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    "SUM(BankCharges) as SumBankCharges, " & _
    "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    "SUM(Cleaning) as SumCleaning, " & _
    "SUM(SecurityGuards) as SumSecurityGuards, " & _
    "SUM(Carriage) as SumCarriage, " & _
    "SUM(LicenceFees) as SumLicenceFees, " & _
    "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    "SUM(OtherFees) as SumOtherFees, " & _
    "SUM(Utilities) as SumUtilities, " & _
    "SUM(Water) as SumWater, " & _
    "SUM(Gas_Electric) as SumGas_Electric, " & _
    "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    "SUM(ProfessionalFee) as SumProfessionalFee, " & _
    "SUM(MarketingResearch) as SumMarketingResearch, " & _
    "SUM(OtherFee) as SumOtherFee, " & _
    "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    "SUM(Equipment) as SumEquipment, " & _
    "SUM(Shopfitting) as SumShopfitting, " & _
    "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    "SUM(Travel) as SumTravel, " & _
    "SUM(Accomodation) as SumAccomodation, " & _
    "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    "SUM(Insurance) as SumInsurance, " & _
    "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    "SUM(Taxation) as SumTaxation, " & _
    "SUM(Penalty) as SumPenalty, " & _
    "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    "SUM(Training) as SumTraining, " & _
    "SUM(Communication) as SumCommunication, " & _
    "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    "SUM(PostageandCourier) as SumPostageandCourier, " & _
    "SUM(OtherExpenses) as SumOtherExpenses, " & _
    "SUM(Sample_Tester) as SumSample_Tester, " & _
    "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    "SUM(LossonClaim) as SumLossonClaim, " & _
    "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    "SUM(Utillity) as SumUtillity, " & _
    "SUM(RepairMaintenance) as SumRepairMaintenance " & _
    "from " & _
    "( " & _
    "select mta.* " & _
    "from v_mtd('" + rate + "') mta,costcenter cca " & _
    " where mta.costcenter_id = cca.costcenter_id And " & _
    "cca.costcenter_blockdt Is null And " & _
    "mta.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
    "mta.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'   " & _
    " union " & _
    "select mtb.* " & _
    "from v_mtd('" + rate + "') mtb,costcenter ccb " & _
    "where mtb.costcenter_id = ccb.costcenter_id And " & _
    "ccb.costcenter_blockdt >= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' and " & _
    "mtb.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
    "mtb.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'  " & _
    ")" & _
    " mt,costcenter cc " & _
    "where mt.costcenter_id = cc.costcenter_id " + area + " and cc.costcenter_opendt < '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' " + store + " and mt.month_time >='" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
    "group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code order by sm.costcenter_code asc "

        End If

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
    Public Shared Function getSumFullModelByProvince(ByVal fdate As String, ByVal tdate As String, ByVal province As String, Optional rate As String = "") As DataTable

        Dim pv As String = ""

        If province <> "ALL" Then
            pv = " and cc.costcenter_province='" + province + "' "
        End If

        Dim sql As String = ""
        If fdate = tdate Then
            sql = "select sm.*, ctt.costcenter_name, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code, " & _
   "SUM(TotalRevenue) as SumTotalRevenue, " & _
   "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
   "SUM(OtherRevenue) as SumOtherRevenue, " & _
   "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
   "SUM(GrossProfit) as SumGrossProfit, " & _
   "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
   "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
   "SUM(Shipping) as SumShipping, " & _
   "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
   "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
   "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
   "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
   "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
   "SUM(GWP) as SumGWP, " & _
   "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
   "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
   "SUM(SellingCosts) as SumSellingCosts, " & _
   "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
   "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
   "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
   "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
   "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
   "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
   "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
   "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
   "SUM(GrossPay) as SumGrossPay, " & _
   "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
   "SUM(Allowance) as SumAllowance, " & _
   "SUM(Overtime) as SumOvertime, " & _
   "SUM(Licensefee) as SumLicensefee, " & _
   "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
   "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
   "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
   "SUM(ProvidentFund) as SumProvidentFund, " & _
   "SUM(PensionCosts) as SumPensionCosts, " & _
   "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
   "SUM(Uniforms) as SumUniforms, " & _
   "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
   "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
   "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
   "SUM(PropertyRental) as SumPropertyRental, " & _
   "SUM(PropertyServices) as SumPropertyServices, " & _
   "SUM(PropertyFacility) as SumPropertyFacility, " & _
   "SUM(Propertytaxes) as SumPropertytaxes, " & _
   "SUM(Facialtaxes) as SumFacialtaxes, " & _
   "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
   "SUM(Signboard) as SumSignboard, " & _
   "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
   "SUM(GPCommission) as SumGPCommission, " & _
   "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
   "SUM(Depreciation) as SumDepreciation, " & _
   "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
   "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
   "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
   "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
   "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
   "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
   "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
   "SUM(BankCharges) as SumBankCharges, " & _
   "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
   "SUM(Cleaning) as SumCleaning, " & _
   "SUM(SecurityGuards) as SumSecurityGuards, " & _
   "SUM(Carriage) as SumCarriage, " & _
   "SUM(LicenceFees) as SumLicenceFees, " & _
   "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
   "SUM(OtherFees) as SumOtherFees, " & _
   "SUM(Utilities) as SumUtilities, " & _
   "SUM(Water) as SumWater, " & _
   "SUM(Gas_Electric) as SumGas_Electric, " & _
   "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
   "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
   "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
   "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
   "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
   "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
   "SUM(ProfessionalFee) as SumProfessionalFee, " & _
   "SUM(MarketingResearch) as SumMarketingResearch, " & _
   "SUM(OtherFee) as SumOtherFee, " & _
   "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
   "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
   "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
   "SUM(Equipment) as SumEquipment, " & _
   "SUM(Shopfitting) as SumShopfitting, " & _
   "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
   "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
   "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
   "SUM(Travel) as SumTravel, " & _
   "SUM(Accomodation) as SumAccomodation, " & _
   "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
   "SUM(Insurance) as SumInsurance, " & _
   "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
   "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
   "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
   "SUM(Taxation) as SumTaxation, " & _
   "SUM(Penalty) as SumPenalty, " & _
   "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
   "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
   "SUM(Training) as SumTraining, " & _
   "SUM(Communication) as SumCommunication, " & _
   "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
   "SUM(PostageandCourier) as SumPostageandCourier, " & _
   "SUM(OtherExpenses) as SumOtherExpenses, " & _
   "SUM(Sample_Tester) as SumSample_Tester, " & _
   "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
   "SUM(LossonClaim) as SumLossonClaim, " & _
   "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
   "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
   "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
   "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
   "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
   "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
   "SUM(Utillity) as SumUtillity, " & _
   "SUM(RepairMaintenance) as SumRepairMaintenance " & _
  "from v_mtd('" + rate + "') mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' )  and month_time = '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
" " + pv + " and cc.costcenter_opendt < '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' " & _
 "group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code order by sm.costcenter_code asc "

        Else
            sql = "select sm.*, ctt.costcenter_name, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code, " & _
    "SUM(TotalRevenue) as SumTotalRevenue, " & _
    "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    "SUM(OtherRevenue) as SumOtherRevenue, " & _
    "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    "SUM(GrossProfit) as SumGrossProfit, " & _
    "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    "SUM(Shipping) as SumShipping, " & _
    "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    "SUM(GWP) as SumGWP, " & _
    "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    "SUM(SellingCosts) as SumSellingCosts, " & _
    "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    "SUM(GrossPay) as SumGrossPay, " & _
    "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    "SUM(Allowance) as SumAllowance, " & _
    "SUM(Overtime) as SumOvertime, " & _
    "SUM(Licensefee) as SumLicensefee, " & _
    "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    "SUM(ProvidentFund) as SumProvidentFund, " & _
    "SUM(PensionCosts) as SumPensionCosts, " & _
    "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    "SUM(Uniforms) as SumUniforms, " & _
    "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    "SUM(PropertyRental) as SumPropertyRental, " & _
    "SUM(PropertyServices) as SumPropertyServices, " & _
    "SUM(PropertyFacility) as SumPropertyFacility, " & _
    "SUM(Propertytaxes) as SumPropertytaxes, " & _
    "SUM(Facialtaxes) as SumFacialtaxes, " & _
    "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    "SUM(Signboard) as SumSignboard, " & _
    "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    "SUM(GPCommission) as SumGPCommission, " & _
    "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    "SUM(Depreciation) as SumDepreciation, " & _
    "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    "SUM(BankCharges) as SumBankCharges, " & _
    "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    "SUM(Cleaning) as SumCleaning, " & _
    "SUM(SecurityGuards) as SumSecurityGuards, " & _
    "SUM(Carriage) as SumCarriage, " & _
    "SUM(LicenceFees) as SumLicenceFees, " & _
    "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    "SUM(OtherFees) as SumOtherFees, " & _
    "SUM(Utilities) as SumUtilities, " & _
    "SUM(Water) as SumWater, " & _
    "SUM(Gas_Electric) as SumGas_Electric, " & _
    "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    "SUM(ProfessionalFee) as SumProfessionalFee, " & _
    "SUM(MarketingResearch) as SumMarketingResearch, " & _
    "SUM(OtherFee) as SumOtherFee, " & _
    "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    "SUM(Equipment) as SumEquipment, " & _
    "SUM(Shopfitting) as SumShopfitting, " & _
    "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    "SUM(Travel) as SumTravel, " & _
    "SUM(Accomodation) as SumAccomodation, " & _
    "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    "SUM(Insurance) as SumInsurance, " & _
    "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    "SUM(Taxation) as SumTaxation, " & _
    "SUM(Penalty) as SumPenalty, " & _
    "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    "SUM(Training) as SumTraining, " & _
    "SUM(Communication) as SumCommunication, " & _
    "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    "SUM(PostageandCourier) as SumPostageandCourier, " & _
    "SUM(OtherExpenses) as SumOtherExpenses, " & _
    "SUM(Sample_Tester) as SumSample_Tester, " & _
    "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    "SUM(LossonClaim) as SumLossonClaim, " & _
    "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    "SUM(Utillity) as SumUtillity, " & _
    "SUM(RepairMaintenance) as SumRepairMaintenance " & _
    "from " & _
    "( " & _
    "select mta.* " & _
    "from v_mtd('" + rate + "') mta,costcenter cca " & _
    " where mta.costcenter_id = cca.costcenter_id And " & _
    "cca.costcenter_blockdt Is null And " & _
    "mta.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
    "mta.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'   " & _
    " union " & _
    "select mtb.* " & _
    "from v_mtd('" + rate + "') mtb,costcenter ccb " & _
    "where mtb.costcenter_id = ccb.costcenter_id And " & _
    "ccb.costcenter_blockdt >= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' and " & _
    "mtb.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
    "mtb.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'  " & _
    ")" & _
    " mt,costcenter cc " & _
    "where mt.costcenter_id = cc.costcenter_id " + pv + " and cc.costcenter_opendt < '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "'  and mt.month_time >='" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
    "group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code order by sm.costcenter_code asc "

        End If

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullModelByArea(ByVal fdate As String, ByVal tdate As String, ByVal area As String, Optional rate As String = "") As DataTable

        Dim pv As String = ""

        If area <> "ALL" Then
            pv = " and cc.costcenter_areas='" + area + "' "
        End If

        Dim sql As String = ""
        If fdate = tdate Then
            sql = "select sm.*, ctt.costcenter_name, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code, " & _
   "SUM(TotalRevenue) as SumTotalRevenue, " & _
   "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
   "SUM(OtherRevenue) as SumOtherRevenue, " & _
   "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
   "SUM(GrossProfit) as SumGrossProfit, " & _
   "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
   "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
   "SUM(Shipping) as SumShipping, " & _
   "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
   "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
   "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
   "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
   "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
   "SUM(GWP) as SumGWP, " & _
   "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
   "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
   "SUM(SellingCosts) as SumSellingCosts, " & _
   "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
   "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
   "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
   "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
   "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
   "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
   "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
   "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
   "SUM(GrossPay) as SumGrossPay, " & _
   "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
   "SUM(Allowance) as SumAllowance, " & _
   "SUM(Overtime) as SumOvertime, " & _
   "SUM(Licensefee) as SumLicensefee, " & _
   "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
   "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
   "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
   "SUM(ProvidentFund) as SumProvidentFund, " & _
   "SUM(PensionCosts) as SumPensionCosts, " & _
   "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
   "SUM(Uniforms) as SumUniforms, " & _
   "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
   "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
   "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
   "SUM(PropertyRental) as SumPropertyRental, " & _
   "SUM(PropertyServices) as SumPropertyServices, " & _
   "SUM(PropertyFacility) as SumPropertyFacility, " & _
   "SUM(Propertytaxes) as SumPropertytaxes, " & _
   "SUM(Facialtaxes) as SumFacialtaxes, " & _
   "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
   "SUM(Signboard) as SumSignboard, " & _
   "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
   "SUM(GPCommission) as SumGPCommission, " & _
   "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
   "SUM(Depreciation) as SumDepreciation, " & _
   "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
   "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
   "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
   "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
   "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
   "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
   "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
   "SUM(BankCharges) as SumBankCharges, " & _
   "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
   "SUM(Cleaning) as SumCleaning, " & _
   "SUM(SecurityGuards) as SumSecurityGuards, " & _
   "SUM(Carriage) as SumCarriage, " & _
   "SUM(LicenceFees) as SumLicenceFees, " & _
   "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
   "SUM(OtherFees) as SumOtherFees, " & _
   "SUM(Utilities) as SumUtilities, " & _
   "SUM(Water) as SumWater, " & _
   "SUM(Gas_Electric) as SumGas_Electric, " & _
   "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
   "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
   "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
   "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
   "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
   "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
   "SUM(ProfessionalFee) as SumProfessionalFee, " & _
   "SUM(MarketingResearch) as SumMarketingResearch, " & _
   "SUM(OtherFee) as SumOtherFee, " & _
   "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
   "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
   "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
   "SUM(Equipment) as SumEquipment, " & _
   "SUM(Shopfitting) as SumShopfitting, " & _
   "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
   "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
   "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
   "SUM(Travel) as SumTravel, " & _
   "SUM(Accomodation) as SumAccomodation, " & _
   "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
   "SUM(Insurance) as SumInsurance, " & _
   "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
   "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
   "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
   "SUM(Taxation) as SumTaxation, " & _
   "SUM(Penalty) as SumPenalty, " & _
   "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
   "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
   "SUM(Training) as SumTraining, " & _
   "SUM(Communication) as SumCommunication, " & _
   "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
   "SUM(PostageandCourier) as SumPostageandCourier, " & _
   "SUM(OtherExpenses) as SumOtherExpenses, " & _
   "SUM(Sample_Tester) as SumSample_Tester, " & _
   "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
   "SUM(LossonClaim) as SumLossonClaim, " & _
   "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
   "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
   "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
   "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
   "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
   "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
   "SUM(Utillity) as SumUtillity, " & _
   "SUM(RepairMaintenance) as SumRepairMaintenance " & _
  "from v_mtd('" + rate + "') mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' )  and month_time = '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
" " + pv + " and cc.costcenter_opendt < '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' " & _
 "group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code order by sm.costcenter_code asc "

        Else
            sql = "select sm.*, ctt.costcenter_name, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code, " & _
    "SUM(TotalRevenue) as SumTotalRevenue, " & _
    "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    "SUM(OtherRevenue) as SumOtherRevenue, " & _
    "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    "SUM(GrossProfit) as SumGrossProfit, " & _
    "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    "SUM(Shipping) as SumShipping, " & _
    "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    "SUM(GWP) as SumGWP, " & _
    "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    "SUM(SellingCosts) as SumSellingCosts, " & _
    "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    "SUM(GrossPay) as SumGrossPay, " & _
    "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    "SUM(Allowance) as SumAllowance, " & _
    "SUM(Overtime) as SumOvertime, " & _
    "SUM(Licensefee) as SumLicensefee, " & _
    "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    "SUM(ProvidentFund) as SumProvidentFund, " & _
    "SUM(PensionCosts) as SumPensionCosts, " & _
    "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    "SUM(Uniforms) as SumUniforms, " & _
    "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    "SUM(PropertyRental) as SumPropertyRental, " & _
    "SUM(PropertyServices) as SumPropertyServices, " & _
    "SUM(PropertyFacility) as SumPropertyFacility, " & _
    "SUM(Propertytaxes) as SumPropertytaxes, " & _
    "SUM(Facialtaxes) as SumFacialtaxes, " & _
    "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    "SUM(Signboard) as SumSignboard, " & _
    "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    "SUM(GPCommission) as SumGPCommission, " & _
    "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    "SUM(Depreciation) as SumDepreciation, " & _
    "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    "SUM(BankCharges) as SumBankCharges, " & _
    "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    "SUM(Cleaning) as SumCleaning, " & _
    "SUM(SecurityGuards) as SumSecurityGuards, " & _
    "SUM(Carriage) as SumCarriage, " & _
    "SUM(LicenceFees) as SumLicenceFees, " & _
    "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    "SUM(OtherFees) as SumOtherFees, " & _
    "SUM(Utilities) as SumUtilities, " & _
    "SUM(Water) as SumWater, " & _
    "SUM(Gas_Electric) as SumGas_Electric, " & _
    "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    "SUM(ProfessionalFee) as SumProfessionalFee, " & _
    "SUM(MarketingResearch) as SumMarketingResearch, " & _
    "SUM(OtherFee) as SumOtherFee, " & _
    "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    "SUM(Equipment) as SumEquipment, " & _
    "SUM(Shopfitting) as SumShopfitting, " & _
    "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    "SUM(Travel) as SumTravel, " & _
    "SUM(Accomodation) as SumAccomodation, " & _
    "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    "SUM(Insurance) as SumInsurance, " & _
    "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    "SUM(Taxation) as SumTaxation, " & _
    "SUM(Penalty) as SumPenalty, " & _
    "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    "SUM(Training) as SumTraining, " & _
    "SUM(Communication) as SumCommunication, " & _
    "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    "SUM(PostageandCourier) as SumPostageandCourier, " & _
    "SUM(OtherExpenses) as SumOtherExpenses, " & _
    "SUM(Sample_Tester) as SumSample_Tester, " & _
    "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    "SUM(LossonClaim) as SumLossonClaim, " & _
    "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    "SUM(Utillity) as SumUtillity, " & _
    "SUM(RepairMaintenance) as SumRepairMaintenance " & _
    "from " & _
    "( " & _
    "select mta.* " & _
    "from v_mtd('" + rate + "') mta,costcenter cca " & _
    " where mta.costcenter_id = cca.costcenter_id And " & _
    "cca.costcenter_blockdt Is null And " & _
    "mta.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
    "mta.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'   " & _
    " union " & _
    "select mtb.* " & _
    "from v_mtd('" + rate + "') mtb,costcenter ccb " & _
    "where mtb.costcenter_id = ccb.costcenter_id And " & _
    "ccb.costcenter_blockdt >= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' and " & _
    "mtb.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
    "mtb.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'  " & _
    ")" & _
    " mt,costcenter cc " & _
    "where mt.costcenter_id = cc.costcenter_id " + pv + " and cc.costcenter_opendt < '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "'  and mt.month_time >='" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
    "group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code order by sm.costcenter_code asc "

        End If

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullModelByTop(ByVal fdate As String, ByVal tdate As String, ByVal type As String, ByVal name As String, ByVal num As String, Optional rate As String = "") As DataTable

        Dim pv As String = ""

        Dim sql As String = ""
        If fdate = tdate Then
            sql = "select top " + num.ToString + " sm.*, ctt.costcenter_name, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code, " & _
   "SUM(TotalRevenue) as SumTotalRevenue, " & _
   "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
   "SUM(OtherRevenue) as SumOtherRevenue, " & _
   "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
   "SUM(GrossProfit) as SumGrossProfit, " & _
   "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
   "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
   "SUM(Shipping) as SumShipping, " & _
   "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
   "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
   "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
   "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
   "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
   "SUM(GWP) as SumGWP, " & _
   "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
   "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
   "SUM(SellingCosts) as SumSellingCosts, " & _
   "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
   "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
   "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
   "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
   "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
   "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
   "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
   "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
   "SUM(GrossPay) as SumGrossPay, " & _
   "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
   "SUM(Allowance) as SumAllowance, " & _
   "SUM(Overtime) as SumOvertime, " & _
   "SUM(Licensefee) as SumLicensefee, " & _
   "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
   "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
   "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
   "SUM(ProvidentFund) as SumProvidentFund, " & _
   "SUM(PensionCosts) as SumPensionCosts, " & _
   "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
   "SUM(Uniforms) as SumUniforms, " & _
   "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
   "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
   "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
   "SUM(PropertyRental) as SumPropertyRental, " & _
   "SUM(PropertyServices) as SumPropertyServices, " & _
   "SUM(PropertyFacility) as SumPropertyFacility, " & _
   "SUM(Propertytaxes) as SumPropertytaxes, " & _
   "SUM(Facialtaxes) as SumFacialtaxes, " & _
   "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
   "SUM(Signboard) as SumSignboard, " & _
   "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
   "SUM(GPCommission) as SumGPCommission, " & _
   "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
   "SUM(Depreciation) as SumDepreciation, " & _
   "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
   "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
   "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
   "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
   "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
   "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
   "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
   "SUM(BankCharges) as SumBankCharges, " & _
   "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
   "SUM(Cleaning) as SumCleaning, " & _
   "SUM(SecurityGuards) as SumSecurityGuards, " & _
   "SUM(Carriage) as SumCarriage, " & _
   "SUM(LicenceFees) as SumLicenceFees, " & _
   "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
   "SUM(OtherFees) as SumOtherFees, " & _
   "SUM(Utilities) as SumUtilities, " & _
   "SUM(Water) as SumWater, " & _
   "SUM(Gas_Electric) as SumGas_Electric, " & _
   "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
   "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
   "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
   "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
   "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
   "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
   "SUM(ProfessionalFee) as SumProfessionalFee, " & _
   "SUM(MarketingResearch) as SumMarketingResearch, " & _
   "SUM(OtherFee) as SumOtherFee, " & _
   "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
   "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
   "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
   "SUM(Equipment) as SumEquipment, " & _
   "SUM(Shopfitting) as SumShopfitting, " & _
   "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
   "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
   "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
   "SUM(Travel) as SumTravel, " & _
   "SUM(Accomodation) as SumAccomodation, " & _
   "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
   "SUM(Insurance) as SumInsurance, " & _
   "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
   "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
   "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
   "SUM(Taxation) as SumTaxation, " & _
   "SUM(Penalty) as SumPenalty, " & _
   "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
   "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
   "SUM(Training) as SumTraining, " & _
   "SUM(Communication) as SumCommunication, " & _
   "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
   "SUM(PostageandCourier) as SumPostageandCourier, " & _
   "SUM(OtherExpenses) as SumOtherExpenses, " & _
   "SUM(Sample_Tester) as SumSample_Tester, " & _
   "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
   "SUM(LossonClaim) as SumLossonClaim, " & _
   "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
   "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
   "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
   "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
   "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
   "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
   "SUM(Utillity) as SumUtillity, " & _
   "SUM(RepairMaintenance) as SumRepairMaintenance " & _
  "from v_mtd('" + rate + "') mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' )  and month_time = '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
" " + pv + " and cc.costcenter_opendt < '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' " & _
 "group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code " & _
 "and SumTotalRevenue <> 0 " & _
 "order by " + name.ToString + " " + type.ToString + " "

        Else
            sql = "select top " + num.ToString + " sm.*, ctt.costcenter_name, ctt.costcenter_total_area as sumtotalarea,  ctt.costcenter_sale_area as sumsalearea from (select costcenter_code, " & _
    "SUM(TotalRevenue) as SumTotalRevenue, " & _
    "SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    "SUM(OtherRevenue) as SumOtherRevenue, " & _
    "SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    "SUM(GrossProfit) as SumGrossProfit, " & _
    "SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    "SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    "SUM(Shipping) as SumShipping, " & _
    "SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    "SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    "SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    "SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    "SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    "SUM(GWP) as SumGWP, " & _
    "SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    "SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    "SUM(SellingCosts) as SumSellingCosts, " & _
    "SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    "SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    "SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    "SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    "SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    "SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    "SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    "SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    "SUM(GrossPay) as SumGrossPay, " & _
    "SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    "SUM(Allowance) as SumAllowance, " & _
    "SUM(Overtime) as SumOvertime, " & _
    "SUM(Licensefee) as SumLicensefee, " & _
    "SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    "SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    "SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    "SUM(ProvidentFund) as SumProvidentFund, " & _
    "SUM(PensionCosts) as SumPensionCosts, " & _
    "SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    "SUM(Uniforms) as SumUniforms, " & _
    "SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    "SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    "SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    "SUM(PropertyRental) as SumPropertyRental, " & _
    "SUM(PropertyServices) as SumPropertyServices, " & _
    "SUM(PropertyFacility) as SumPropertyFacility, " & _
    "SUM(Propertytaxes) as SumPropertytaxes, " & _
    "SUM(Facialtaxes) as SumFacialtaxes, " & _
    "SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    "SUM(Signboard) as SumSignboard, " & _
    "SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    "SUM(GPCommission) as SumGPCommission, " & _
    "SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    "SUM(Depreciation) as SumDepreciation, " & _
    "SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    "SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    "SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    "SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    "SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    "SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    "SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    "SUM(BankCharges) as SumBankCharges, " & _
    "SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    "SUM(Cleaning) as SumCleaning, " & _
    "SUM(SecurityGuards) as SumSecurityGuards, " & _
    "SUM(Carriage) as SumCarriage, " & _
    "SUM(LicenceFees) as SumLicenceFees, " & _
    "SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    "SUM(OtherFees) as SumOtherFees, " & _
    "SUM(Utilities) as SumUtilities, " & _
    "SUM(Water) as SumWater, " & _
    "SUM(Gas_Electric) as SumGas_Electric, " & _
    "SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    "SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    "SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    "SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    "SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    "SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    "SUM(ProfessionalFee) as SumProfessionalFee, " & _
    "SUM(MarketingResearch) as SumMarketingResearch, " & _
    "SUM(OtherFee) as SumOtherFee, " & _
    "SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    "SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    "SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    "SUM(Equipment) as SumEquipment, " & _
    "SUM(Shopfitting) as SumShopfitting, " & _
    "SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    "SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    "SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    "SUM(Travel) as SumTravel, " & _
    "SUM(Accomodation) as SumAccomodation, " & _
    "SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    "SUM(Insurance) as SumInsurance, " & _
    "SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    "SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    "SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    "SUM(Taxation) as SumTaxation, " & _
    "SUM(Penalty) as SumPenalty, " & _
    "SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    "SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    "SUM(Training) as SumTraining, " & _
    "SUM(Communication) as SumCommunication, " & _
    "SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    "SUM(PostageandCourier) as SumPostageandCourier, " & _
    "SUM(OtherExpenses) as SumOtherExpenses, " & _
    "SUM(Sample_Tester) as SumSample_Tester, " & _
    "SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    "SUM(LossonClaim) as SumLossonClaim, " & _
    "SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    "SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    "SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    "SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    "SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    "SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    "SUM(Utillity) as SumUtillity, " & _
    "SUM(RepairMaintenance) as SumRepairMaintenance " & _
    "from " & _
    "( " & _
    "select mta.* " & _
    "from v_mtd('" + rate + "') mta,costcenter cca " & _
    " where mta.costcenter_id = cca.costcenter_id And " & _
    "cca.costcenter_blockdt Is null And " & _
    "mta.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
    "mta.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'   " & _
    " union " & _
    "select mtb.* " & _
    "from v_mtd('" + rate + "') mtb,costcenter ccb " & _
    "where mtb.costcenter_id = ccb.costcenter_id And " & _
    "ccb.costcenter_blockdt >= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "' and " & _
    "mtb.month_time <= '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' and " & _
    "mtb.month_time >= '" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "'  " & _
    ")" & _
    " mt,costcenter cc " & _
    "where mt.costcenter_id = cc.costcenter_id " + pv + " and cc.costcenter_opendt < '" + DateTime.ParseExact(tdate, "M/yyyy", Nothing).AddMonths(1) + "'  and mt.month_time >='" + DateTime.ParseExact(fdate, "M/yyyy", Nothing) + "' and mt.month_time <='" + DateTime.ParseExact(tdate, "M/yyyy", Nothing) + "' " & _
    "group by costcenter_code ) sm, costcenter ctt where sm.costcenter_code = ctt.costcenter_code " & _
    "and SumTotalRevenue <> 0 " & _
    "order by " + name.ToString + " " + type.ToString + " "

        End If

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullStoreOrder(ByVal years As String, ByVal mon As String, ByVal type As String, ByVal name As String, ByVal num As String) As DataTable

        Dim sql As String = "select top " + num.ToString + " costcenter_code,costcenter_name, " & _
"costcenter_total_area as sumtotalarea, " & _
"costcenter_sale_area as sumsalearea, " & _
"TotalRevenue as SumTotalRevenue, " & _
"RETAIL_TESPIncome as SumRETAIL_TESPIncome, " & _
"OtherRevenue as SumOtherRevenue, " & _
"CostofGoodSold as SumCostofGoodSold, " & _
"GrossProfit as SumGrossProfit, " & _
"GrossProfit_percent as SumGrossProfit_percent, " & _
"MarginAdjustments as SumMarginAdjustments, " & _
"Shipping as SumShipping, " & _
"StockLossandObsolescence as SumStockLossandObsolescence, " & _
"InventoryAdjustment_stock as SumInventoryAdjustment_stock, " & _
"InventoryAdjustment_damage as SumInventoryAdjustment_damage, " & _
"StockLoss_Provision as SumStockLoss_Provision, " & _
"StockObsolescence_Provision as SumStockObsolescence_Provision, " & _
"GWP as SumGWP, " & _
"GWPs_Corporate as SumGWPs_Corporate, " & _
"GWPs_Transferred as SumGWPs_Transferred, " & _
"SellingCosts as SumSellingCosts, " & _
"Creditcardscommission as SumCreditcardscommission, " & _
"LabellingMaterial as SumLabellingMaterial, " & _
"OtherIncome_COSHFunding as SumOtherIncome_COSHFunding, " & _
"OtherIncomeSupplier as SumOtherIncomeSupplier, " & _
"AdjustedGrossMargin as SumAdjustedGrossMargin, " & _
"SupplyChainCosts as SumSupplyChainCosts, " & _
"TotalStoreExpenses as SumTotalStoreExpenses, " & _
"StoreLabourCosts as SumStoreLabourCosts, " & _
"GrossPay as SumGrossPay, " & _
"TemporaryStaffCosts as SumTemporaryStaffCosts, " & _
"Allowance as SumAllowance, " & _
"Overtime as SumOvertime, " & _
"Licensefee as SumLicensefee, " & _
"Bonuses_Incentives as SumBonuses_Incentives, " & _
"BootsBrandncentives as SumBootsBrandncentives, " & _
"SuppliersIncentive as SumSuppliersIncentive, " & _
"ProvidentFund as SumProvidentFund, " & _
"PensionCosts as SumPensionCosts, " & _
"SocialSecurityFund as SumSocialSecurityFund, " & _
"Uniforms as SumUniforms, " & _
"EmployeeWelfare as SumEmployeeWelfare, " & _
"OtherBenefitsEmployee as SumOtherBenefitsEmployee, " & _
"StorePropertyCosts as SumStorePropertyCosts, " & _
"PropertyRental as SumPropertyRental, " & _
"PropertyServices as SumPropertyServices, " & _
"PropertyFacility as SumPropertyFacility, " & _
"Propertytaxes as SumPropertytaxes, " & _
"Facialtaxes as SumFacialtaxes, " & _
"PropertyInsurance as SumPropertyInsurance, " & _
"Signboard as SumSignboard, " & _
"Discount_Rent_Services_Facility as SumDiscount_Rent_Services_Facility, " & _
"GPCommission as SumGPCommission, " & _
"AmortizationofLeaseRight as SumAmortizationofLeaseRight, " & _
"Depreciation as SumDepreciation, " & _
"DepreciationofShortLeaseBuilding as SumDepreciationofShortLeaseBuilding, " & _
"DepreciationofComputerHardware as SumDepreciationofComputerHardware, " & _
"DepreciationofFixturesFittings as SumDepreciationofFixturesFittings, " & _
"DepreciationofComputerSoftware as SumDepreciationofComputerSoftware, " & _
"DepreciationofOfficeEquipment as SumDepreciationofOfficeEquipment, " & _
"OtherStoreCosts as SumOtherStoreCosts, " & _
"ServiceChargesandOtherFees as SumServiceChargesandOtherFees, " & _
"BankCharges as SumBankCharges, " & _
"CashCollectionCharge as SumCashCollectionCharge, " & _
"Cleaning as SumCleaning, " & _
"SecurityGuards as SumSecurityGuards, " & _
"Carriage as SumCarriage, " & _
"LicenceFees as SumLicenceFees, " & _
"OtherServicesCharge as SumOtherServicesCharge, " & _
"OtherFees as SumOtherFees, " & _
"Utilities as SumUtilities, " & _
"Water as SumWater, " & _
"Gas_Electric as SumGas_Electric, " & _
"AirCond_Addition as SumAirCond_Addition, " & _
"RepairandMaintenance as SumRepairandMaintenance, " & _
"RMOther_Fix as SumRMOther_Fix, " & _
"RMOther_Unplan as SumRMOther_Unplan, " & _
"RMComputer_Fix as SumRMComputer_Fix, " & _
"RMComputer_Unplan as SumRMComputer_Unplan, " & _
"ProfessionalFee as SumProfessionalFee, " & _
"MarketingResearch as SumMarketingResearch, " & _
"OtherFee as SumOtherFee, " & _
"Equipment_MaterailandSupplies as SumEquipment_MaterailandSupplies, " & _
"PrintingandStationery as SumPrintingandStationery, " & _
"SuppliesExpenses as SumSuppliesExpenses, " & _
"Equipment as SumEquipment, " & _
"Shopfitting as SumShopfitting, " & _
"PackagingandOtherMaterial as SumPackagingandOtherMaterial, " & _
"BusinessTravelExpenses as SumBusinessTravelExpenses, " & _
"CarParkingandOthers as SumCarParkingandOthers, " & _
"Travel as SumTravel, " & _
"Accomodation as SumAccomodation, " & _
"MealandEntertainment as SumMealandEntertainment, " & _
"Insurance as SumInsurance, " & _
"AllRiskInsurance as SumAllRiskInsurance, " & _
"HealthandLifeInsurance as SumHealthandLifeInsurance, " & _
"PenaltyandTaxation as SumPenaltyandTaxation, " & _
"Taxation as SumTaxation, " & _
"Penalty as SumPenalty, " & _
"OtherRelatedStaffCost as SumOtherRelatedStaffCost, " & _
"StaffConferenceandTraining as SumStaffConferenceandTraining, " & _
"Training as SumTraining, " & _
"Communication as SumCommunication, " & _
"TelephoneCalls_Faxes as SumTelephoneCalls_Faxes, " & _
"PostageandCourier as SumPostageandCourier, " & _
"OtherExpenses as SumOtherExpenses, " & _
"Sample_Tester as SumSample_Tester, " & _
"PreopeningCosts as SumPreopeningCosts, " & _
"LossonClaim as SumLossonClaim, " & _
"CashOvertage_Shortagefromsales as SumCashOvertage_Shortagefromsales, " & _
"MiscellenousandOther as SumMiscellenousandOther, " & _
"StoreTradingProfit__Loss as SumStoreTradingProfit__Loss, " & _
"TradingProfit__Loss as SumTradingProfit__Loss, " & _
"StoreControllableCostsforBSC as SumStoreControllableCostsforBSC, " & _
"StoreLabourCost as SumStoreLabourCost, " & _
"Utillity as SumUtillity, " & _
"RepairMaintenance as SumRepairMaintenance " & _
"from mtd mt,costcenter cc " & _
"where mt.costcenter_id = cc.costcenter_id  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " & _
"order by " + name.ToString + " " + type.ToString + " "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullCompareMtdLflByStoreByYear(ByVal years As String, ByVal mon As String, type As String, store_id As String, Optional rate As String = "") As DataTable
        Try
            ''Explain code
            ''วนลูปหาแต่ล่ะเดือน ได้เท่าไรเอามาบวกกัน จากเดือนมากสุด ถึง เดือนน้อยสุด
            ''แล้วมาหา % growth ที่หลัง
            If years Is Nothing Then Return Nothing
            Dim beginYear As Integer = years
            Dim beginMon As Integer = 4
            Dim dtTemp1 As New DataTable : Dim dtTemp2 As New DataTable
            dtTemp1 = Nothing : dtTemp2 = Nothing

            If mon < 4 Then
                beginYear = Integer.Parse(years) - 1
            End If
            Dim endDate As DateTime = DateTime.ParseExact(("1/" + beginMon.ToString + "/" + beginYear.ToString), ClsManage.formatDateTime, Nothing)
            Dim tempDate As DateTime = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)

            Dim dt As New DataTable
            While (tempDate >= endDate)
                dt = getSumFullCompareMtdLflByStoreByMonth(tempDate.Year, tempDate.Month, type, store_id, rate, "n")
                If dtTemp1 Is Nothing Then
                    dtTemp1 = dt.Clone
                    dtTemp2 = dt.Clone
                End If
                dtTemp1.ImportRow(dt.Rows(0))
                dtTemp2.ImportRow(dt.Rows(1))
                tempDate = tempDate.AddMonths(-1)
            End While

            dt.Dispose()
            Dim dtResult As New DataTable
            dtResult = dtTemp1.Clone

            'ใส่มา 1 rows ก่อน
            dtResult.ImportRow(dtTemp1.Rows(0))
            dtResult.ImportRow(dtTemp2.Rows(0))

            With dtTemp1
                For i As Integer = 1 To .Rows.Count - 1 'ข้าม row แรกไป
                    For j As Integer = 2 To .Columns.Count - 3
                        dtResult.Rows(0)(j) += IIf(IsDBNull(.Rows(i)(j)), 0, .Rows(i)(j))
                    Next
                Next
            End With

            With dtTemp2
                For i As Integer = 1 To .Rows.Count - 1 'ข้าม row แรกไป
                    For j As Integer = 2 To .Columns.Count - 3
                        dtResult.Rows(1)(j) += IIf(IsDBNull(.Rows(i)(j)), 0, .Rows(i)(j))
                    Next
                Next
            End With

            If dtResult.Rows.Count > 0 Then
                Dim num As String = ""
                Dim divi As String = ""
                Dim dr As DataRow = dtResult.NewRow

                For i As Integer = 2 To dtResult.Columns.Count - 3
                    num = dtResult.Rows(0)(i).ToString
                    divi = dtResult.Rows(1)(i).ToString
                    If Not (num = "" Or divi = "") Then
                        If Double.Parse(divi) <> 0 Then
                            dr(i) = (num / divi) - 1
                        Else
                            dr(i) = 0
                        End If
                    Else
                        dr(i) = 0
                    End If
                Next
                dr("ptype") = type
                dtResult.Rows.Add(dr)
            End If


            Return dtResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullCompareMtdLflByStoreByMonth(ByVal years As String, ByVal mon As String, type As String, store_id As String, Optional rate As String = "", Optional growth As String = "y") As DataTable

        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sqlCol As String = ""
        Dim sql As String = ""
        Dim sqlCondition1 As String = ""
        Dim sqlCondition2 As String = ""
        Dim sqlTbl As String = IIf(rate = "", "mtd", "v_mtd('" + rate + "')")
        Dim sqlPtype As String = ""

        sqlCol = "select " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
"COUNT(dd.costcenter_id) as SumCostCenter, "

        Select Case type
            Case ClsManage.lflType.LFL.ToString
                sqlPtype = "ptype = '" + ClsManage.lflType.LFL.ToString + " '+ cast( year(@thisyear) as varchar) "
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
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )  AND (sto.store_id = @store_id or @store_id = '')"
                sqlCondition2 = " UNION " + sqlCol + _
                    "ptype = '" + ClsManage.lflType.LFL.ToString + " '+ cast( year(@lastyear) as varchar)  " & _
                    "from " + sqlTbl + " dd,costcenter cb where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear " & _
                    "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") order by ptype DESC"


            Case ClsManage.lflType.NonLFL.ToString
                sqlPtype = "ptype = '" + ClsManage.lflType.NonLFL.ToString + " '+ cast( year(@thisyear) as varchar) "
                sqlCondition1 = "" & _
"from ( " & _
"select * from " + sqlTbl + " mtdz " & _
"where mtdz.month_time = @thisyear and mtdz.costcenter_id not in ( " & _
" select cb.costcenter_id from ( select mt1.* from " + sqlTbl + " mt1 " & _
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
" ) ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear  and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
" ) ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear   AND (sto.store_id = @store_id or @store_id = '')"
                sqlCondition2 = " UNION " + sqlCol + _
                    "ptype = '" + ClsManage.lflType.NonLFL.ToString + " '+ cast( year(@lastyear) as varchar)  " & _
                    "from " + sqlTbl + " dd,costcenter cb where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear " & _
                    "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") order by ptype DESC"

            Case ClsManage.lflType.Closed.ToString
                sqlPtype = "ptype = '" + ClsManage.lflType.Closed.ToString + " '+ cast( year(@thisyear) as varchar) "
                sqlCondition1 = "from " + sqlTbl + " dd,costcenter cb,store sto " & _
                    "where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and dd.month_time = @thisyear and  cb.costcenter_blockdt <= @thisyear2 AND (sto.store_id = @store_id or @store_id = '')"
                sqlCondition2 = " UNION " + sqlCol + _
                    "ptype = '" + ClsManage.lflType.Closed.ToString + " '+ cast( year(@lastyear) as varchar)  " & _
                    "from " + sqlTbl + " dd,costcenter cb where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear " & _
                    "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") order by ptype DESC"

            Case ClsManage.lflType.OtherBusiness.ToString
                sqlPtype = "ptype = 'OB '+ cast( year(@thisyear) as varchar) "
                sqlCondition1 = "from " + sqlTbl + " dd,costcenter cb,store sto " & _
                    "where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto.store_id and sto.store_other = 'Y' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) AND (sto.store_id = @store_id or @store_id = '')"
                sqlCondition2 = " UNION " + sqlCol + _
                    "ptype = 'OB '+ cast( year(@lastyear) as varchar)  " & _
                    "from " + sqlTbl + " dd,costcenter cb where dd.costcenter_id = cb.costcenter_id and dd.month_time = @lastyear " & _
                    "and dd.costcenter_id in(SELECT dd.costcenter_id " + sqlCondition1 + ") order by ptype DESC"
        End Select

        sql = sqlCol + sqlPtype + sqlCondition1 + sqlCondition2
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
        parameter.Value = store_id
        cmd.Parameters.Add(parameter)

        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)

            ''set 0 ถ้าเป็น null ใน code จะไม่โชว์ และ error
            For Each dr As DataRow In dt.Rows
                If IsDBNull(dr("SumTotalRevenue")) Then
                    For i As Integer = 0 To dt.Columns.Count - 3
                        dr(i) = 0.0
                    Next
                End If
            Next

            If dt.Rows.Count > 0 And growth = "y" Then
                Dim num As String = ""
                Dim divi As String = ""
                Dim dr As DataRow = dt.NewRow

                For i As Integer = 0 To dt.Columns.Count - 2
                    num = dt.Rows(0)(i).ToString
                    divi = dt.Rows(1)(i).ToString
                    If Not (num = "" Or divi = "") Then
                        If Double.Parse(divi) <> 0 Then
                            dr(i) = (num / divi) - 1
                        Else
                            dr(i) = 0
                        End If
                    Else
                        dr(i) = 0
                    End If
                Next
                dr("ptype") = type
                dt.Rows.Add(dr)
            End If
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

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

        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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

        Try
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim dtRGlfl As New DataTable
                dtRGlfl = dt.Clone
                Dim rev1 As Double = 0
                Dim rev2 As Double = 0
                Dim loss1 As Double = 0
                Dim loss2 As Double = 0
                Dim sumRev1 As Double = dt.Compute("Sum(rev1)", "")
                Dim sumRev2 As Double = dt.Compute("Sum(rev2)", "")
                Dim sumLoss1 As Double = dt.Compute("Sum(loss1)", "")
                Dim sumLoss2 As Double = dt.Compute("Sum(loss2)", "")

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
        End Try
    End Function

    Public Shared Function getLFLGrowthYtdTotal(ByVal years As String, ByVal mon As String, locate As String) As DataTable
        Try
            Dim dtLFL As New DataTable
            Dim colRev1 As String = "rev1"
            Dim colRev2 As String = "rev2"
            Dim colLoss1 As String = "loss1"
            Dim colLoss2 As String = "loss2"
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

            Dim dr As DataRow = dtLFL.NewRow
            Dim sumRev1 As Double = dtTemp.Compute("SUM(" + colRev1 + ")", "")
            Dim sumRev2 As Double = dtTemp.Compute("SUM(" + colRev2 + ")", "")
            Dim sumloss1 As Double = dtTemp.Compute("SUM(" + colLoss1 + ")", "")
            Dim sumloss2 As Double = dtTemp.Compute("SUM(" + colLoss2 + ")", "")

            dr(colRev1) = (sumRev1 / sumRev2) - 1
            dr(colLoss1) = (sumloss1 / sumloss2) - 1
            dtLFL.Rows.Add(dr)

            Return dtLFL
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '    Public Shared Function getYOYGrowth_(ByVal years As String, ByVal mon As String, ByVal locate As String) As DataTable

    '        Dim area As String = ""

    '        If locate <> "ALL" And locate <> "TWO" Then
    '            area = " and cc.costcenter_location='" + locate + "' "
    '        End If

    '        Dim sql As String = "select SUM(TotalRevenue) as SumTotalRevenue, " & _
    '"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    '"SUM(OtherRevenue) as SumOtherRevenue, " & _
    '"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    '"SUM(GrossProfit) as SumGrossProfit, " & _
    '"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    '"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    '"SUM(Shipping) as SumShipping, " & _
    '"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    '"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    '"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    '"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    '"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    '"SUM(GWP) as SumGWP, " & _
    '"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    '"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    '"SUM(SellingCosts) as SumSellingCosts, " & _
    '"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    '"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    '"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    '"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    '"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    '"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    '"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    '"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    '"SUM(GrossPay) as SumGrossPay, " & _
    '"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    '"SUM(Allowance) as SumAllowance, " & _
    '"SUM(Overtime) as SumOvertime, " & _
    '"SUM(Licensefee) as SumLicensefee, " & _
    '"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    '"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    '"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    '"SUM(ProvidentFund) as SumProvidentFund, " & _
    '"SUM(PensionCosts) as SumPensionCosts, " & _
    '"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    '"SUM(Uniforms) as SumUniforms, " & _
    '"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    '"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    '"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    '"SUM(PropertyRental) as SumPropertyRental, " & _
    '"SUM(PropertyServices) as SumPropertyServices, " & _
    '"SUM(PropertyFacility) as SumPropertyFacility, " & _
    '"SUM(Propertytaxes) as SumPropertytaxes, " & _
    '"SUM(Facialtaxes) as SumFacialtaxes, " & _
    '"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    '"SUM(Signboard) as SumSignboard, " & _
    '"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    '"SUM(GPCommission) as SumGPCommission, " & _
    '"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    '"SUM(Depreciation) as SumDepreciation, " & _
    '"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    '"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    '"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    '"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    '"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    '"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    '"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    '"SUM(BankCharges) as SumBankCharges, " & _
    '"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    '"SUM(Cleaning) as SumCleaning, " & _
    '"SUM(SecurityGuards) as SumSecurityGuards, " & _
    '"SUM(Carriage) as SumCarriage, " & _
    '"SUM(LicenceFees) as SumLicenceFees, " & _
    '"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    '"SUM(OtherFees) as SumOtherFees, " & _
    '"SUM(Utilities) as SumUtilities, " & _
    '"SUM(Water) as SumWater, " & _
    '"SUM(Gas_Electric) as SumGas_Electric, " & _
    '"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    '"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    '"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    '"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    '"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    '"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    '"SUM(ProfessionalFee) as SumProfessionalFee, " & _
    '"SUM(MarketingResearch) as SumMarketingResearch, " & _
    '"SUM(OtherFee) as SumOtherFee, " & _
    '"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    '"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    '"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    '"SUM(Equipment) as SumEquipment, " & _
    '"SUM(Shopfitting) as SumShopfitting, " & _
    '"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    '"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    '"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    '"SUM(Travel) as SumTravel, " & _
    '"SUM(Accomodation) as SumAccomodation, " & _
    '"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    '"SUM(Insurance) as SumInsurance, " & _
    '"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    '"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    '"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    '"SUM(Taxation) as SumTaxation, " & _
    '"SUM(Penalty) as SumPenalty, " & _
    '"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    '"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    '"SUM(Training) as SumTraining, " & _
    '"SUM(Communication) as SumCommunication, " & _
    '"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    '"SUM(PostageandCourier) as SumPostageandCourier, " & _
    '"SUM(OtherExpenses) as SumOtherExpenses, " & _
    '"SUM(Sample_Tester) as SumSample_Tester, " & _
    '"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    '"SUM(LossonClaim) as SumLossonClaim, " & _
    '"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    '"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    '"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    '"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    '"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    '"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    '"SUM(Utillity) as SumUtillity, " & _
    '"SUM(RepairMaintenance) as SumRepairMaintenance " & _
    '"from mtd mt,costcenter cc " & _
    '"where mt.costcenter_id = cc.costcenter_id and ( cc.costcenter_blockdt is null or cc.costcenter_blockdt >= @block_dt )  and year(month_time) = '" + years + "' and month(month_time) = '" + mon + "' " + area + " " & _
    '" and cc.costcenter_opendt < @sl_dt " & _
    '" group by costcenter_store ) sm,store st where sm.costcenter_store=st.store_id and st.store_other='N' order by st.store_order asc"

    '        Dim con As New SqlConnection(strcon)
    '        Dim cmd As New SqlCommand(sql, con)

    '        Dim parameter As New SqlParameter("@block_dt", SqlDbType.DateTime)
    '        If mon = "12" Then
    '            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
    '        Else
    '            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
    '        End If
    '        cmd.Parameters.Add(parameter)

    '        parameter = New SqlParameter("@sl_dt", SqlDbType.DateTime)
    '        If mon = "12" Then
    '            parameter.Value = DateTime.ParseExact(("1/1/" + (CInt(years) + 1).ToString), ClsManage.formatDateTime, Nothing)
    '        Else
    '            parameter.Value = DateTime.ParseExact(("1/" + (CInt(mon) + 1).ToString + "/" + years), ClsManage.formatDateTime, Nothing)
    '        End If
    '        cmd.Parameters.Add(parameter)

    '        Try

    '            Dim da As New SqlDataAdapter(cmd)
    '            Dim dt As New DataTable

    '            da.Fill(dt)
    '            If dt.Rows.Count > 0 Then
    '                Dim dtlflG As New DataTable
    '                dtlflG = getLFLGrowth(years, mon, locate)
    '                If dtlflG.Rows.Count > 0 Then
    '                    For Each dr As DataRow In dt.Rows
    '                        If dtlflG.Select("store_id = " + dr("store_id").ToString + " ").Length > 0 Then
    '                            dr("lfl_growth") = dtlflG.Select("store_id = " + dr("store_id").ToString + " ")(0)(0)
    '                        Else
    '                            dr("lfl_growth") = 0
    '                        End If
    '                    Next
    '                End If
    '            End If

    '            Return dt

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    Public Shared Function getSumFullMtdLflByStoreByMonth(ByVal years As String, ByVal mon As String, type As String, Optional rate As String = "") As DataTable

        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        Dim sql As String = ""
        Dim sql_condition As String = ""

        Select Case type
            Case "LFL"
                sql_condition = "from ( select mt1.* from v_mtd('" + rate + "') mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"LEFT JOIN v_mtd('" + rate + "') mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
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
" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 )"
            Case "NonLFL"
                sql_condition = "from ( " & _
"select * from v_mtd('" + rate + "') mtdz " & _
"where mtdz.month_time = @thisyear and mtdz.costcenter_id not in ( " & _
" select cb.costcenter_id from ( select mt1.* from v_mtd('" + rate + "') mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"LEFT JOIN v_mtd('" + rate + "') mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
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
" ) ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear  and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
" ) ) dd,costcenter cb,store sto1 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto1.store_id and sto1.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear "
            Case "Closed"
                sql_condition = "from v_mtd('" + rate + "') dd,costcenter cb,store sto2 " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto2.store_id and sto2.store_other = 'N' and dd.month_time = @thisyear and  cb.costcenter_blockdt <= @thisyear2 "
            Case "NewStore"
                sql_condition = "from v_mtd('" + rate + "') dd,costcenter cb,store sto3 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto3.store_id and sto3.store_other = 'N' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
"and cb.costcenter_opendt >= @openyear "
            Case "OtherBusiness"
                sql_condition = "from v_mtd('" + rate + "') dd,costcenter cb,store sto4 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto4.store_id and sto4.store_other = 'Y' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) "
        End Select

        sql = "" & _
"select  " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
"costcenter_code,costcenter_name " & _
" " + sql_condition + "" & _
"GROUP BY costcenter_code,costcenter_name order by cb.costcenter_code asc"


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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullMtdLflByStore(ByVal years As String, ByVal mon As String, years2 As String, mon2 As String, type As String, Optional rate As String = "") As DataTable
        Try
            If years Is Nothing Then Return Nothing
            'วนลูปทั้งหมดเก็บไว้ก่อน แล้ว sum ที่หลัง
            'ถ้าเป็นstoreใหม่ add new ถ้าซ้ำให้ sum
            Dim dt As New DataTable
            Dim dtTemp As New DataTable
            Dim beginDate As DateTime = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
            Dim endDate As DateTime = DateTime.ParseExact(("1/" + mon2 + "/" + years2), ClsManage.formatDateTime, Nothing)

            Dim tempDate As DateTime = beginDate
            dtTemp = getSumFullMtdLflByStoreByMonth(beginDate.Year, beginDate.Month, type, rate)
            If beginDate = endDate Then Return dtTemp
            tempDate = tempDate.AddMonths(1)

            While (tempDate <= endDate)
                dt = getSumFullMtdLflByStoreByMonth(tempDate.Year, tempDate.Month, type, rate)
                For r = 0 To dt.Rows.Count - 1
                    dtTemp.ImportRow(dt.Rows(r))
                Next
                tempDate = tempDate.AddMonths(1)
            End While

            dt.Dispose()
            Dim dtResult As New DataTable
            dtResult = dtTemp.Clone
            'set primary key for find key
            Dim primaryKey(0) As DataColumn
            primaryKey(0) = dtResult.Columns("costcenter_code")
            dtResult.PrimaryKey = primaryKey
            Dim store_code As String = ""

            For Each dr As DataRow In dtTemp.Rows

                If dtResult.Rows.Count = 0 Then
                    dtResult.ImportRow(dr)
                Else
                    If dtResult.Rows.Find(dr("costcenter_code").ToString) Is Nothing Then
                        dtResult.ImportRow(dr)
                    Else
                        store_code = dr("costcenter_code").ToString
                        Dim iRow As Integer = 0
                        'Find duplicate rows for summary
                        For i = 0 To dtResult.Rows.Count - 1
                            If store_code = dtResult.Rows(i)("costcenter_code") Then
                                iRow = i
                                Exit For
                            End If
                        Next

                        For c = 0 To dtResult.Columns.Count - 1
                            If Not (dr.Table.Columns(c).ColumnName = "costcenter_code" Or dr.Table.Columns(c).ColumnName = "costcenter_name") Then
                                dtResult.Rows(iRow)(c) = IIf(IsDBNull(dtResult.Rows(iRow)(c)), 0, dtResult.Rows(iRow)(c)) + IIf(IsDBNull(dr(c)), 0, dr(c))
                            End If
                        Next
                    End If
                End If
            Next

            Return dtResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullMtdLfl(ByVal years As String, ByVal mon As String, Optional rate As String = "") As DataTable
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1
        '"select * from (select COUNT(DISTINCT cc.costcenter_id) as cnum, costcenter_store, " & _
        Dim sqlTbl As String = "mtd"  '"v_mtd('" + rate + "')" 
        Dim sql As String = "select " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
"COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'LFL' ,xx = '5' " & _
"from ( select mt1.* from " + sqlTbl + " mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"LEFT JOIN " + sqlTbl + " mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
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
"union select " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
"COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'Non LFL' ,xx='4' " & _
"from ( " & _
"select * from " + sqlTbl + " mtdz " & _
"where mtdz.month_time = @thisyear and mtdz.costcenter_id not in ( " & _
" select cb.costcenter_id from ( select mt1.* from " + sqlTbl + " mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"LEFT JOIN " + sqlTbl + " mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
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
" ) ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear  and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
" ) ) dd,costcenter cb,store sto1 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto1.store_id and sto1.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear " & _
"union select " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
"COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'Closed' ,xx='3' " & _
"from " + sqlTbl + " dd,costcenter cb,store sto2 " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto2.store_id and sto2.store_other = 'N' and dd.month_time = @thisyear and  cb.costcenter_blockdt <= @thisyear2 " & _
"union select " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
"COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'New Store' ,xx='2' " & _
"from " + sqlTbl + " dd,costcenter cb,store sto3 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto3.store_id and sto3.store_other = 'N' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
"and cb.costcenter_opendt >= @openyear " & _
"union select " & _
"SUM(costcenter_total_area) as sumtotalarea, " & _
"SUM(costcenter_sale_area) as sumsalearea, " & _
"SUM(TotalRevenue) as SumTotalRevenue, " & _
"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
"SUM(OtherRevenue) as SumOtherRevenue, " & _
"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
"SUM(GrossProfit) as SumGrossProfit, " & _
"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
"SUM(Shipping) as SumShipping, " & _
"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
"SUM(GWP) as SumGWP, " & _
"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
"SUM(SellingCosts) as SumSellingCosts, " & _
"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
"SUM(GrossPay) as SumGrossPay, " & _
"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
"SUM(Allowance) as SumAllowance, " & _
"SUM(Overtime) as SumOvertime, " & _
"SUM(Licensefee) as SumLicensefee, " & _
"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
"SUM(ProvidentFund) as SumProvidentFund, " & _
"SUM(PensionCosts) as SumPensionCosts, " & _
"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
"SUM(Uniforms) as SumUniforms, " & _
"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
"SUM(PropertyRental) as SumPropertyRental, " & _
"SUM(PropertyServices) as SumPropertyServices, " & _
"SUM(PropertyFacility) as SumPropertyFacility, " & _
"SUM(Propertytaxes) as SumPropertytaxes, " & _
"SUM(Facialtaxes) as SumFacialtaxes, " & _
"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
"SUM(Signboard) as SumSignboard, " & _
"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
"SUM(GPCommission) as SumGPCommission, " & _
"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
"SUM(Depreciation) as SumDepreciation, " & _
"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
"SUM(BankCharges) as SumBankCharges, " & _
"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
"SUM(Cleaning) as SumCleaning, " & _
"SUM(SecurityGuards) as SumSecurityGuards, " & _
"SUM(Carriage) as SumCarriage, " & _
"SUM(LicenceFees) as SumLicenceFees, " & _
"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
"SUM(OtherFees) as SumOtherFees, " & _
"SUM(Utilities) as SumUtilities, " & _
"SUM(Water) as SumWater, " & _
"SUM(Gas_Electric) as SumGas_Electric, " & _
"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
"SUM(ProfessionalFee) as SumProfessionalFee, " & _
"SUM(MarketingResearch) as SumMarketingResearch, " & _
"SUM(OtherFee) as SumOtherFee, " & _
"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
"SUM(Equipment) as SumEquipment, " & _
"SUM(Shopfitting) as SumShopfitting, " & _
"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
"SUM(Travel) as SumTravel, " & _
"SUM(Accomodation) as SumAccomodation, " & _
"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
"SUM(Insurance) as SumInsurance, " & _
"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
"SUM(Taxation) as SumTaxation, " & _
"SUM(Penalty) as SumPenalty, " & _
"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
"SUM(Training) as SumTraining, " & _
"SUM(Communication) as SumCommunication, " & _
"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
"SUM(PostageandCourier) as SumPostageandCourier, " & _
"SUM(OtherExpenses) as SumOtherExpenses, " & _
"SUM(Sample_Tester) as SumSample_Tester, " & _
"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
"SUM(LossonClaim) as SumLossonClaim, " & _
"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
"SUM(Utillity) as SumUtillity, " & _
"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
"COUNT(dd.costcenter_id) as SumCostCenter, " & _
"ptype = 'Other Business' ,xx='1' " & _
"from " + sqlTbl + " dd,costcenter cb,store sto4 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto4.store_id and sto4.store_other = 'Y' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
"order by xx desc "


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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            If Not rate = "" Then
                Dim currencyRate As Double = 1
                If dt.Rows.Count > 0 Then
                    Dim dtRate As New Data.DataTable
                    dtRate = getRate(rate, years, mon)
                    If dtRate.Rows.Count > 0 Then
                        If dtRate.Rows.Count = 2 Then
                            currencyRate = dtRate.Rows(1)("crc_rate")
                        Else
                            currencyRate = dtRate.Rows(0)("crc_rate")
                        End If
                    End If
                    For Each dr As DataRow In dt.Rows
                        For Each dc As DataColumn In dt.Columns
                            If dc.ColumnName.ToString.ToLower.Contains("sum") Then
                                If Not (dc.ColumnName = "sumtotalarea" Or dc.ColumnName = "sumsalearea") Then
                                    dr(dc.ColumnName) = dr(dc.ColumnName) / currencyRate
                                End If
                            ElseIf dc.ColumnName = "productivity" Then
                                dr(dc.ColumnName) = dr(dc.ColumnName) / currencyRate
                            End If
                        Next
                    Next
                End If
            End If
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getSumFullYtdLfl(ByVal years As String, ByVal mon As String, Optional rate As String = "") As DataTable
        Try
            If years Is Nothing Then Return Nothing
            Dim dt As New DataTable
            Dim beginYear As Integer = years
            Dim beginMon As Integer = 4
            Dim dtTemp As New DataTable
            dtTemp = Nothing

            If mon < 4 Then
                beginYear = Integer.Parse(years) - 1
            End If
            Dim tempDate As DateTime = DateTime.ParseExact(("1/" + beginMon.ToString + "/" + beginYear.ToString), ClsManage.formatDateTime, Nothing)
            Dim endDate As DateTime = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)

            'Start month 4
            If mon = 4 Then Return getSumFullMtdLfl(beginYear, beginMon, rate)

            Dim dtLFL As New DataTable : Dim dtNonLFL As New DataTable : Dim dtClosed As New DataTable : Dim dtNew As New DataTable : Dim dtOB As New DataTable
            dtLFL = getCountFullMtdLFL(beginYear, beginMon).Clone : dtNonLFL = dtLFL.Clone : dtClosed = dtLFL.Clone : dtNew = dtLFL.Clone : dtOB = dtLFL.Clone

            'while start month 5
            While (tempDate <= endDate)
                dt = getSumFullMtdLfl(tempDate.Year, tempDate.Month, rate)
                If dtTemp Is Nothing Then
                    dtTemp = dt
                Else
                    'loop for summary values
                    For r = 0 To dt.Rows.Count - 1
                        For c = 0 To dt.Columns.Count - 1
                            If dt.Rows(r)("SumCostCenter") <> 0 Then
                                If dt.Columns(c).ColumnName <> "sumtotalarea" And dt.Columns(c).ColumnName <> "sumsalearea" And dt.Columns(c).ColumnName <> "sumcostcenter" And dt.Columns(c).ColumnName <> "ptype" Then
                                    dtTemp.Rows(r)(c) = IIf(IsDBNull(dtTemp.Rows(r)(c)), 0, dtTemp.Rows(r)(c)) + IIf(IsDBNull(dt.Rows(r)(c)), 0, dt.Rows(r)(c))
                                ElseIf dtTemp.Rows(r)(c) Is DBNull.Value Then
                                    dtTemp.Rows(r)(c) = 0
                                End If
                            End If
                        Next
                    Next
                End If

                dt = New DataTable
                dt = getCountFullMtdLFL(tempDate.Year, tempDate.Month)
                For Each dr As DataRow In dt.Rows
                    Select Case dr(dt.Columns(1).ColumnName)
                        Case "LFL"
                            dtLFL.ImportRow(dr)
                        Case "Non LFL"
                            dtNonLFL.ImportRow(dr)
                        Case "Closed"
                            dtClosed.ImportRow(dr)
                        Case "New Store"
                            dtNew.ImportRow(dr)
                        Case "Other Business"
                            dtOB.ImportRow(dr)
                    End Select
                Next
                tempDate = tempDate.AddMonths(1)
            End While
            dt.Dispose()

            'find count store not duplicate in all ytd
            Dim columnNames As String() = {dtLFL.Columns(0).ColumnName}
            Dim countLFL As String = dtLFL.DefaultView.ToTable(True, columnNames).Rows.Count.ToString
            Dim countNon As String = dtNonLFL.DefaultView.ToTable(True, columnNames).Rows.Count.ToString
            Dim countClosed As String = dtClosed.DefaultView.ToTable(True, columnNames).Rows.Count.ToString
            Dim countNew As String = dtNew.DefaultView.ToTable(True, columnNames).Rows.Count.ToString
            Dim countOB As String = dtOB.DefaultView.ToTable(True, columnNames).Rows.Count.ToString

            dtTemp.Rows(0)("sumcostcenter") = countLFL
            dtTemp.Rows(1)("sumcostcenter") = countNon
            dtTemp.Rows(2)("sumcostcenter") = countClosed
            dtTemp.Rows(3)("sumcostcenter") = countNew
            dtTemp.Rows(4)("sumcostcenter") = countOB

            Return dtTemp
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getCountFullMtdLFL(ByVal years As String, ByVal mon As String) As DataTable
        'this function for count store (distinct)
        If years Is Nothing Then Return Nothing
        Dim lastyear As String = years - 1

        Dim sql As String = "select dd.costcenter_id,ptype = 'LFL'" & _
"from ( select mt1.* from mtd mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"LEFT JOIN mtd mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
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
" UNION" & _
" select dd.costcenter_id,ptype = 'Non LFL' " & _
"from ( " & _
"select * from mtd mtdz " & _
"where mtdz.month_time = @thisyear and mtdz.costcenter_id not in ( " & _
" select cb.costcenter_id from ( select mt1.* from mtd mt1 " & _
"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
"LEFT JOIN mtd mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
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
" ) ) dd,costcenter cb,store sto " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear  and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
" ) ) dd,costcenter cb,store sto1 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto1.store_id and sto1.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
" and cb.costcenter_opendt < @openyear " & _
"UNION " & _
"select dd.costcenter_id,ptype = 'Closed' " & _
"from mtd dd,costcenter cb,store sto2 " & _
"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto2.store_id and sto2.store_other = 'N' and dd.month_time = @thisyear and  cb.costcenter_blockdt <= @thisyear2 " & _
"UNION " & _
"select dd.costcenter_id,ptype = 'New Store' " & _
"from mtd dd,costcenter cb,store sto3 " & _
"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto3.store_id and sto3.store_other = 'N' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
"and cb.costcenter_opendt >= @openyear "



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

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '    Public Shared Function getSumFullYtdLfl(ByVal years As String, ByVal mon As String) As DataTable

    '        Dim lastyear As String = years - 1
    '        Dim sql As String = "select " & _
    '"SUM(costcenter_total_area) as sumtotalarea, " & _
    '"SUM(costcenter_sale_area) as sumsalearea, " & _
    '"SUM(TotalRevenue) as SumTotalRevenue, " & _
    '"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    '"SUM(OtherRevenue) as SumOtherRevenue, " & _
    '"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    '"SUM(GrossProfit) as SumGrossProfit, " & _
    '"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    '"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    '"SUM(Shipping) as SumShipping, " & _
    '"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    '"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    '"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    '"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    '"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    '"SUM(GWP) as SumGWP, " & _
    '"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    '"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    '"SUM(SellingCosts) as SumSellingCosts, " & _
    '"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    '"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    '"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    '"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    '"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    '"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    '"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    '"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    '"SUM(GrossPay) as SumGrossPay, " & _
    '"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    '"SUM(Allowance) as SumAllowance, " & _
    '"SUM(Overtime) as SumOvertime, " & _
    '"SUM(Licensefee) as SumLicensefee, " & _
    '"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    '"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    '"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    '"SUM(ProvidentFund) as SumProvidentFund, " & _
    '"SUM(PensionCosts) as SumPensionCosts, " & _
    '"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    '"SUM(Uniforms) as SumUniforms, " & _
    '"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    '"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    '"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    '"SUM(PropertyRental) as SumPropertyRental, " & _
    '"SUM(PropertyServices) as SumPropertyServices, " & _
    '"SUM(PropertyFacility) as SumPropertyFacility, " & _
    '"SUM(Propertytaxes) as SumPropertytaxes, " & _
    '"SUM(Facialtaxes) as SumFacialtaxes, " & _
    '"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    '"SUM(Signboard) as SumSignboard, " & _
    '"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    '"SUM(GPCommission) as SumGPCommission, " & _
    '"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    '"SUM(Depreciation) as SumDepreciation, " & _
    '"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    '"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    '"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    '"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    '"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    '"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    '"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    '"SUM(BankCharges) as SumBankCharges, " & _
    '"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    '"SUM(Cleaning) as SumCleaning, " & _
    '"SUM(SecurityGuards) as SumSecurityGuards, " & _
    '"SUM(Carriage) as SumCarriage, " & _
    '"SUM(LicenceFees) as SumLicenceFees, " & _
    '"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    '"SUM(OtherFees) as SumOtherFees, " & _
    '"SUM(Utilities) as SumUtilities, " & _
    '"SUM(Water) as SumWater, " & _
    '"SUM(Gas_Electric) as SumGas_Electric, " & _
    '"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    '"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    '"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    '"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    '"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    '"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    '"SUM(ProfessionalFee) as SumProfessionalFee, " & _
    '"SUM(MarketingResearch) as SumMarketingResearch, " & _
    '"SUM(OtherFee) as SumOtherFee, " & _
    '"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    '"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    '"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    '"SUM(Equipment) as SumEquipment, " & _
    '"SUM(Shopfitting) as SumShopfitting, " & _
    '"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    '"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    '"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    '"SUM(Travel) as SumTravel, " & _
    '"SUM(Accomodation) as SumAccomodation, " & _
    '"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    '"SUM(Insurance) as SumInsurance, " & _
    '"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    '"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    '"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    '"SUM(Taxation) as SumTaxation, " & _
    '"SUM(Penalty) as SumPenalty, " & _
    '"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    '"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    '"SUM(Training) as SumTraining, " & _
    '"SUM(Communication) as SumCommunication, " & _
    '"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    '"SUM(PostageandCourier) as SumPostageandCourier, " & _
    '"SUM(OtherExpenses) as SumOtherExpenses, " & _
    '"SUM(Sample_Tester) as SumSample_Tester, " & _
    '"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    '"SUM(LossonClaim) as SumLossonClaim, " & _
    '"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    '"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    '"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    '"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    '"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    '"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    '"SUM(Utillity) as SumUtillity, " & _
    '"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
    '"COUNT(dd.costcenter_id) as SumCostCenter, " & _
    '"ptype = 'LFL' ,xx = '5' " & _
    '"from ( select mt1.* from mtd mt1 " & _
    '"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
    '"LEFT JOIN mtd mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
    '"where (mt1.month_time between @openyear and  @thisyear) " & _
    '"and mt2.month_time = @lastyear and " & _
    '"mt1.TotalRevenue <> '0' and  mt2.TotalRevenue <> '0' and " & _
    '"mt1.costcenter_id not in ( " & _
    '"select distinct tempc_costcenter_id from ( " & _
    '"select *, " & _
    '"CASE " & _
    '"WHEN (tempc_start IS null and tempc_finish >= @thisyear ) OR (tempc_start IS null and tempc_finish >= @lastyear ) THEN 1 " & _
    '"WHEN (tempc_start <= @thisyear2 and tempc_finish IS null) OR (tempc_start <= @lastyear2 and tempc_finish IS null) THEN 1 " & _
    '"WHEN (tempc_start <= @thisyear2 and tempc_finish >= @thisyear) OR (tempc_start <= @lastyear2 and tempc_finish >= @lastyear) THEN 1 " & _
    '"ELSE 0 " & _
    '"END AS status_at " & _
    '"from tempc) as tt " & _
    '"where status_at = 1 " & _
    '") ) dd,costcenter cb,store sto " & _
    '"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
    '" and cb.costcenter_opendt < @openyear and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
    '"union select " & _
    '"SUM(costcenter_total_area) as sumtotalarea, " & _
    '"SUM(costcenter_sale_area) as sumsalearea, " & _
    '"SUM(TotalRevenue) as SumTotalRevenue, " & _
    '"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    '"SUM(OtherRevenue) as SumOtherRevenue, " & _
    '"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    '"SUM(GrossProfit) as SumGrossProfit, " & _
    '"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    '"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    '"SUM(Shipping) as SumShipping, " & _
    '"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    '"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    '"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    '"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    '"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    '"SUM(GWP) as SumGWP, " & _
    '"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    '"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    '"SUM(SellingCosts) as SumSellingCosts, " & _
    '"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    '"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    '"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    '"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    '"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    '"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    '"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    '"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    '"SUM(GrossPay) as SumGrossPay, " & _
    '"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    '"SUM(Allowance) as SumAllowance, " & _
    '"SUM(Overtime) as SumOvertime, " & _
    '"SUM(Licensefee) as SumLicensefee, " & _
    '"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    '"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    '"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    '"SUM(ProvidentFund) as SumProvidentFund, " & _
    '"SUM(PensionCosts) as SumPensionCosts, " & _
    '"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    '"SUM(Uniforms) as SumUniforms, " & _
    '"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    '"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    '"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    '"SUM(PropertyRental) as SumPropertyRental, " & _
    '"SUM(PropertyServices) as SumPropertyServices, " & _
    '"SUM(PropertyFacility) as SumPropertyFacility, " & _
    '"SUM(Propertytaxes) as SumPropertytaxes, " & _
    '"SUM(Facialtaxes) as SumFacialtaxes, " & _
    '"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    '"SUM(Signboard) as SumSignboard, " & _
    '"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    '"SUM(GPCommission) as SumGPCommission, " & _
    '"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    '"SUM(Depreciation) as SumDepreciation, " & _
    '"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    '"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    '"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    '"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    '"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    '"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    '"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    '"SUM(BankCharges) as SumBankCharges, " & _
    '"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    '"SUM(Cleaning) as SumCleaning, " & _
    '"SUM(SecurityGuards) as SumSecurityGuards, " & _
    '"SUM(Carriage) as SumCarriage, " & _
    '"SUM(LicenceFees) as SumLicenceFees, " & _
    '"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    '"SUM(OtherFees) as SumOtherFees, " & _
    '"SUM(Utilities) as SumUtilities, " & _
    '"SUM(Water) as SumWater, " & _
    '"SUM(Gas_Electric) as SumGas_Electric, " & _
    '"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    '"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    '"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    '"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    '"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    '"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    '"SUM(ProfessionalFee) as SumProfessionalFee, " & _
    '"SUM(MarketingResearch) as SumMarketingResearch, " & _
    '"SUM(OtherFee) as SumOtherFee, " & _
    '"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    '"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    '"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    '"SUM(Equipment) as SumEquipment, " & _
    '"SUM(Shopfitting) as SumShopfitting, " & _
    '"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    '"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    '"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    '"SUM(Travel) as SumTravel, " & _
    '"SUM(Accomodation) as SumAccomodation, " & _
    '"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    '"SUM(Insurance) as SumInsurance, " & _
    '"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    '"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    '"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    '"SUM(Taxation) as SumTaxation, " & _
    '"SUM(Penalty) as SumPenalty, " & _
    '"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    '"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    '"SUM(Training) as SumTraining, " & _
    '"SUM(Communication) as SumCommunication, " & _
    '"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    '"SUM(PostageandCourier) as SumPostageandCourier, " & _
    '"SUM(OtherExpenses) as SumOtherExpenses, " & _
    '"SUM(Sample_Tester) as SumSample_Tester, " & _
    '"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    '"SUM(LossonClaim) as SumLossonClaim, " & _
    '"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    '"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    '"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    '"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    '"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    '"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    '"SUM(Utillity) as SumUtillity, " & _
    '"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
    '"COUNT(dd.costcenter_id) as SumCostCenter, " & _
    '"ptype = 'Non LFL' ,xx='4' " & _
    '"from ( " & _
    '"select * from mtd mtdz " & _
    '"where mtdz.month_time = @thisyear and mtdz.costcenter_id not in ( " & _
    '" select cb.costcenter_id from ( select mt1.* from mtd mt1 " & _
    '"LEFT JOIN costcenter ct ON (mt1.costcenter_id=ct.costcenter_id) " & _
    '"LEFT JOIN mtd mt2 ON (mt2.costcenter_id=ct.costcenter_id) " & _
    '"where mt1.month_time = @thisyear and mt2.month_time = @lastyear and " & _
    '"mt1.TotalRevenue <> '0' and  mt2.TotalRevenue <> '0' and " & _
    '"mt1.costcenter_id not in ( " & _
    '"select distinct tempc_costcenter_id from ( " & _
    '"select *, " & _
    '"CASE " & _
    '"WHEN (tempc_start IS null and tempc_finish >= @thisyear ) OR (tempc_start IS null and tempc_finish >= @lastyear ) THEN 1 " & _
    '"WHEN (tempc_start <= @thisyear2 and tempc_finish IS null) OR (tempc_start <= @lastyear2 and tempc_finish IS null) THEN 1 " & _
    '"WHEN (tempc_start <= @thisyear2 and tempc_finish >= @thisyear) OR (tempc_start <= @lastyear2 and tempc_finish >= @lastyear) THEN 1 " & _
    '"ELSE 0 " & _
    '"END AS status_at " & _
    '"from tempc) as tt " & _
    '"where status_at = 1 " & _
    '" ) ) dd,costcenter cb,store sto " & _
    '"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto.store_id and sto.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
    '" and cb.costcenter_opendt < @openyear  and not ( cb.costcenter_opendt > @lastyear and cb.costcenter_opendt <= @lastyear2 ) " & _
    '" ) ) dd,costcenter cb,store sto1 " & _
    '"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto1.store_id and sto1.store_other = 'N' and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
    '" and cb.costcenter_opendt < @openyear " & _
    '"union select " & _
    '"SUM(costcenter_total_area) as sumtotalarea, " & _
    '"SUM(costcenter_sale_area) as sumsalearea, " & _
    '"SUM(TotalRevenue) as SumTotalRevenue, " & _
    '"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    '"SUM(OtherRevenue) as SumOtherRevenue, " & _
    '"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    '"SUM(GrossProfit) as SumGrossProfit, " & _
    '"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    '"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    '"SUM(Shipping) as SumShipping, " & _
    '"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    '"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    '"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    '"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    '"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    '"SUM(GWP) as SumGWP, " & _
    '"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    '"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    '"SUM(SellingCosts) as SumSellingCosts, " & _
    '"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    '"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    '"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    '"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    '"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    '"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    '"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    '"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    '"SUM(GrossPay) as SumGrossPay, " & _
    '"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    '"SUM(Allowance) as SumAllowance, " & _
    '"SUM(Overtime) as SumOvertime, " & _
    '"SUM(Licensefee) as SumLicensefee, " & _
    '"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    '"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    '"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    '"SUM(ProvidentFund) as SumProvidentFund, " & _
    '"SUM(PensionCosts) as SumPensionCosts, " & _
    '"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    '"SUM(Uniforms) as SumUniforms, " & _
    '"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    '"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    '"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    '"SUM(PropertyRental) as SumPropertyRental, " & _
    '"SUM(PropertyServices) as SumPropertyServices, " & _
    '"SUM(PropertyFacility) as SumPropertyFacility, " & _
    '"SUM(Propertytaxes) as SumPropertytaxes, " & _
    '"SUM(Facialtaxes) as SumFacialtaxes, " & _
    '"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    '"SUM(Signboard) as SumSignboard, " & _
    '"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    '"SUM(GPCommission) as SumGPCommission, " & _
    '"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    '"SUM(Depreciation) as SumDepreciation, " & _
    '"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    '"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    '"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    '"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    '"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    '"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    '"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    '"SUM(BankCharges) as SumBankCharges, " & _
    '"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    '"SUM(Cleaning) as SumCleaning, " & _
    '"SUM(SecurityGuards) as SumSecurityGuards, " & _
    '"SUM(Carriage) as SumCarriage, " & _
    '"SUM(LicenceFees) as SumLicenceFees, " & _
    '"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    '"SUM(OtherFees) as SumOtherFees, " & _
    '"SUM(Utilities) as SumUtilities, " & _
    '"SUM(Water) as SumWater, " & _
    '"SUM(Gas_Electric) as SumGas_Electric, " & _
    '"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    '"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    '"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    '"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    '"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    '"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    '"SUM(ProfessionalFee) as SumProfessionalFee, " & _
    '"SUM(MarketingResearch) as SumMarketingResearch, " & _
    '"SUM(OtherFee) as SumOtherFee, " & _
    '"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    '"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    '"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    '"SUM(Equipment) as SumEquipment, " & _
    '"SUM(Shopfitting) as SumShopfitting, " & _
    '"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    '"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    '"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    '"SUM(Travel) as SumTravel, " & _
    '"SUM(Accomodation) as SumAccomodation, " & _
    '"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    '"SUM(Insurance) as SumInsurance, " & _
    '"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    '"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    '"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    '"SUM(Taxation) as SumTaxation, " & _
    '"SUM(Penalty) as SumPenalty, " & _
    '"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    '"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    '"SUM(Training) as SumTraining, " & _
    '"SUM(Communication) as SumCommunication, " & _
    '"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    '"SUM(PostageandCourier) as SumPostageandCourier, " & _
    '"SUM(OtherExpenses) as SumOtherExpenses, " & _
    '"SUM(Sample_Tester) as SumSample_Tester, " & _
    '"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    '"SUM(LossonClaim) as SumLossonClaim, " & _
    '"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    '"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    '"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    '"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    '"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    '"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    '"SUM(Utillity) as SumUtillity, " & _
    '"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
    '"COUNT(dd.costcenter_id) as SumCostCenter, " & _
    '"ptype = 'Closed' ,xx='3' " & _
    '"from mtd dd,costcenter cb,store sto2 " & _
    '"where dd.costcenter_id = cb.costcenter_id and cb.costcenter_store = sto2.store_id and sto2.store_other = 'N' " & _
    '"and (dd.month_time between @openyear and @thisyear) " &
    '"and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
    '"and cb.costcenter_opendt >= @openyear " & _
    '"union select " & _
    '"SUM(costcenter_total_area) as sumtotalarea, " & _
    '"SUM(costcenter_sale_area) as sumsalearea, " & _
    '"SUM(TotalRevenue) as SumTotalRevenue, " & _
    '"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    '"SUM(OtherRevenue) as SumOtherRevenue, " & _
    '"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    '"SUM(GrossProfit) as SumGrossProfit, " & _
    '"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    '"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    '"SUM(Shipping) as SumShipping, " & _
    '"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    '"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    '"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    '"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    '"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    '"SUM(GWP) as SumGWP, " & _
    '"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    '"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    '"SUM(SellingCosts) as SumSellingCosts, " & _
    '"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    '"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    '"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    '"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    '"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    '"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    '"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    '"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    '"SUM(GrossPay) as SumGrossPay, " & _
    '"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    '"SUM(Allowance) as SumAllowance, " & _
    '"SUM(Overtime) as SumOvertime, " & _
    '"SUM(Licensefee) as SumLicensefee, " & _
    '"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    '"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    '"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    '"SUM(ProvidentFund) as SumProvidentFund, " & _
    '"SUM(PensionCosts) as SumPensionCosts, " & _
    '"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    '"SUM(Uniforms) as SumUniforms, " & _
    '"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    '"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    '"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    '"SUM(PropertyRental) as SumPropertyRental, " & _
    '"SUM(PropertyServices) as SumPropertyServices, " & _
    '"SUM(PropertyFacility) as SumPropertyFacility, " & _
    '"SUM(Propertytaxes) as SumPropertytaxes, " & _
    '"SUM(Facialtaxes) as SumFacialtaxes, " & _
    '"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    '"SUM(Signboard) as SumSignboard, " & _
    '"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    '"SUM(GPCommission) as SumGPCommission, " & _
    '"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    '"SUM(Depreciation) as SumDepreciation, " & _
    '"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    '"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    '"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    '"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    '"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    '"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    '"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    '"SUM(BankCharges) as SumBankCharges, " & _
    '"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    '"SUM(Cleaning) as SumCleaning, " & _
    '"SUM(SecurityGuards) as SumSecurityGuards, " & _
    '"SUM(Carriage) as SumCarriage, " & _
    '"SUM(LicenceFees) as SumLicenceFees, " & _
    '"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    '"SUM(OtherFees) as SumOtherFees, " & _
    '"SUM(Utilities) as SumUtilities, " & _
    '"SUM(Water) as SumWater, " & _
    '"SUM(Gas_Electric) as SumGas_Electric, " & _
    '"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    '"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    '"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    '"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    '"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    '"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    '"SUM(ProfessionalFee) as SumProfessionalFee, " & _
    '"SUM(MarketingResearch) as SumMarketingResearch, " & _
    '"SUM(OtherFee) as SumOtherFee, " & _
    '"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    '"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    '"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    '"SUM(Equipment) as SumEquipment, " & _
    '"SUM(Shopfitting) as SumShopfitting, " & _
    '"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    '"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    '"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    '"SUM(Travel) as SumTravel, " & _
    '"SUM(Accomodation) as SumAccomodation, " & _
    '"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    '"SUM(Insurance) as SumInsurance, " & _
    '"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    '"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    '"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    '"SUM(Taxation) as SumTaxation, " & _
    '"SUM(Penalty) as SumPenalty, " & _
    '"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    '"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    '"SUM(Training) as SumTraining, " & _
    '"SUM(Communication) as SumCommunication, " & _
    '"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    '"SUM(PostageandCourier) as SumPostageandCourier, " & _
    '"SUM(OtherExpenses) as SumOtherExpenses, " & _
    '"SUM(Sample_Tester) as SumSample_Tester, " & _
    '"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    '"SUM(LossonClaim) as SumLossonClaim, " & _
    '"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    '"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    '"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    '"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    '"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    '"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    '"SUM(Utillity) as SumUtillity, " & _
    '"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
    '"COUNT(dd.costcenter_id) as SumCostCenter, " & _
    '"ptype = 'New Store' ,xx='2' " & _
    '"from mtd dd,costcenter cb,store sto3 " & _
    '"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto3.store_id and sto3.store_other = 'N' " & _
    '"and (dd.month_time between @openyear and @thisyear) " &
    '"and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
    '"and cb.costcenter_opendt >= @openyear " & _
    '"union select " & _
    '"SUM(costcenter_total_area) as sumtotalarea, " & _
    '"SUM(costcenter_sale_area) as sumsalearea, " & _
    '"SUM(TotalRevenue) as SumTotalRevenue, " & _
    '"SUM(RETAIL_TESPIncome) as SumRETAIL_TESPIncome, " & _
    '"SUM(OtherRevenue) as SumOtherRevenue, " & _
    '"SUM(CostofGoodSold) as SumCostofGoodSold, " & _
    '"SUM(GrossProfit) as SumGrossProfit, " & _
    '"SUM(GrossProfit_percent) as SumGrossProfit_percent, " & _
    '"SUM(MarginAdjustments) as SumMarginAdjustments, " & _
    '"SUM(Shipping) as SumShipping, " & _
    '"SUM(StockLossandObsolescence) as SumStockLossandObsolescence, " & _
    '"SUM(InventoryAdjustment_stock) as SumInventoryAdjustment_stock, " & _
    '"SUM(InventoryAdjustment_damage) as SumInventoryAdjustment_damage, " & _
    '"SUM(StockLoss_Provision) as SumStockLoss_Provision, " & _
    '"SUM(StockObsolescence_Provision) as SumStockObsolescence_Provision, " & _
    '"SUM(GWP) as SumGWP, " & _
    '"SUM(GWPs_Corporate) as SumGWPs_Corporate, " & _
    '"SUM(GWPs_Transferred) as SumGWPs_Transferred, " & _
    '"SUM(SellingCosts) as SumSellingCosts, " & _
    '"SUM(Creditcardscommission) as SumCreditcardscommission, " & _
    '"SUM(LabellingMaterial) as SumLabellingMaterial, " & _
    '"SUM(OtherIncome_COSHFunding) as SumOtherIncome_COSHFunding, " & _
    '"SUM(OtherIncomeSupplier) as SumOtherIncomeSupplier, " & _
    '"SUM(AdjustedGrossMargin) as SumAdjustedGrossMargin, " & _
    '"SUM(SupplyChainCosts) as SumSupplyChainCosts, " & _
    '"SUM(TotalStoreExpenses) as SumTotalStoreExpenses, " & _
    '"SUM(StoreLabourCosts) as SumStoreLabourCosts, " & _
    '"SUM(GrossPay) as SumGrossPay, " & _
    '"SUM(TemporaryStaffCosts) as SumTemporaryStaffCosts, " & _
    '"SUM(Allowance) as SumAllowance, " & _
    '"SUM(Overtime) as SumOvertime, " & _
    '"SUM(Licensefee) as SumLicensefee, " & _
    '"SUM(Bonuses_Incentives) as SumBonuses_Incentives, " & _
    '"SUM(BootsBrandncentives) as SumBootsBrandncentives, " & _
    '"SUM(SuppliersIncentive) as SumSuppliersIncentive, " & _
    '"SUM(ProvidentFund) as SumProvidentFund, " & _
    '"SUM(PensionCosts) as SumPensionCosts, " & _
    '"SUM(SocialSecurityFund) as SumSocialSecurityFund, " & _
    '"SUM(Uniforms) as SumUniforms, " & _
    '"SUM(EmployeeWelfare) as SumEmployeeWelfare, " & _
    '"SUM(OtherBenefitsEmployee) as SumOtherBenefitsEmployee, " & _
    '"SUM(StorePropertyCosts) as SumStorePropertyCosts, " & _
    '"SUM(PropertyRental) as SumPropertyRental, " & _
    '"SUM(PropertyServices) as SumPropertyServices, " & _
    '"SUM(PropertyFacility) as SumPropertyFacility, " & _
    '"SUM(Propertytaxes) as SumPropertytaxes, " & _
    '"SUM(Facialtaxes) as SumFacialtaxes, " & _
    '"SUM(PropertyInsurance) as SumPropertyInsurance, " & _
    '"SUM(Signboard) as SumSignboard, " & _
    '"SUM(Discount_Rent_Services_Facility) as SumDiscount_Rent_Services_Facility, " & _
    '"SUM(GPCommission) as SumGPCommission, " & _
    '"SUM(AmortizationofLeaseRight) as SumAmortizationofLeaseRight, " & _
    '"SUM(Depreciation) as SumDepreciation, " & _
    '"SUM(DepreciationofShortLeaseBuilding) as SumDepreciationofShortLeaseBuilding, " & _
    '"SUM(DepreciationofComputerHardware) as SumDepreciationofComputerHardware, " & _
    '"SUM(DepreciationofFixturesFittings) as SumDepreciationofFixturesFittings, " & _
    '"SUM(DepreciationofComputerSoftware) as SumDepreciationofComputerSoftware, " & _
    '"SUM(DepreciationofOfficeEquipment) as SumDepreciationofOfficeEquipment, " & _
    '"SUM(OtherStoreCosts) as SumOtherStoreCosts, " & _
    '"SUM(ServiceChargesandOtherFees) as SumServiceChargesandOtherFees, " & _
    '"SUM(BankCharges) as SumBankCharges, " & _
    '"SUM(CashCollectionCharge) as SumCashCollectionCharge, " & _
    '"SUM(Cleaning) as SumCleaning, " & _
    '"SUM(SecurityGuards) as SumSecurityGuards, " & _
    '"SUM(Carriage) as SumCarriage, " & _
    '"SUM(LicenceFees) as SumLicenceFees, " & _
    '"SUM(OtherServicesCharge) as SumOtherServicesCharge, " & _
    '"SUM(OtherFees) as SumOtherFees, " & _
    '"SUM(Utilities) as SumUtilities, " & _
    '"SUM(Water) as SumWater, " & _
    '"SUM(Gas_Electric) as SumGas_Electric, " & _
    '"SUM(AirCond_Addition) as SumAirCond_Addition, " & _
    '"SUM(RepairandMaintenance) as SumRepairandMaintenance, " & _
    '"SUM(RMOther_Fix) as SumRMOther_Fix, " & _
    '"SUM(RMOther_Unplan) as SumRMOther_Unplan, " & _
    '"SUM(RMComputer_Fix) as SumRMComputer_Fix, " & _
    '"SUM(RMComputer_Unplan) as SumRMComputer_Unplan, " & _
    '"SUM(ProfessionalFee) as SumProfessionalFee, " & _
    '"SUM(MarketingResearch) as SumMarketingResearch, " & _
    '"SUM(OtherFee) as SumOtherFee, " & _
    '"SUM(Equipment_MaterailandSupplies) as SumEquipment_MaterailandSupplies, " & _
    '"SUM(PrintingandStationery) as SumPrintingandStationery, " & _
    '"SUM(SuppliesExpenses) as SumSuppliesExpenses, " & _
    '"SUM(Equipment) as SumEquipment, " & _
    '"SUM(Shopfitting) as SumShopfitting, " & _
    '"SUM(PackagingandOtherMaterial) as SumPackagingandOtherMaterial, " & _
    '"SUM(BusinessTravelExpenses) as SumBusinessTravelExpenses, " & _
    '"SUM(CarParkingandOthers) as SumCarParkingandOthers, " & _
    '"SUM(Travel) as SumTravel, " & _
    '"SUM(Accomodation) as SumAccomodation, " & _
    '"SUM(MealandEntertainment) as SumMealandEntertainment, " & _
    '"SUM(Insurance) as SumInsurance, " & _
    '"SUM(AllRiskInsurance) as SumAllRiskInsurance, " & _
    '"SUM(HealthandLifeInsurance) as SumHealthandLifeInsurance, " & _
    '"SUM(PenaltyandTaxation) as SumPenaltyandTaxation, " & _
    '"SUM(Taxation) as SumTaxation, " & _
    '"SUM(Penalty) as SumPenalty, " & _
    '"SUM(OtherRelatedStaffCost) as SumOtherRelatedStaffCost, " & _
    '"SUM(StaffConferenceandTraining) as SumStaffConferenceandTraining, " & _
    '"SUM(Training) as SumTraining, " & _
    '"SUM(Communication) as SumCommunication, " & _
    '"SUM(TelephoneCalls_Faxes) as SumTelephoneCalls_Faxes, " & _
    '"SUM(PostageandCourier) as SumPostageandCourier, " & _
    '"SUM(OtherExpenses) as SumOtherExpenses, " & _
    '"SUM(Sample_Tester) as SumSample_Tester, " & _
    '"SUM(PreopeningCosts) as SumPreopeningCosts, " & _
    '"SUM(LossonClaim) as SumLossonClaim, " & _
    '"SUM(CashOvertage_Shortagefromsales) as SumCashOvertage_Shortagefromsales, " & _
    '"SUM(MiscellenousandOther) as SumMiscellenousandOther, " & _
    '"SUM(StoreTradingProfit__Loss) as SumStoreTradingProfit__Loss, " & _
    '"SUM(TradingProfit__Loss) as SumTradingProfit__Loss, " & _
    '"SUM(StoreControllableCostsforBSC) as SumStoreControllableCostsforBSC, " & _
    '"SUM(StoreLabourCost) as SumStoreLabourCost, " & _
    '"SUM(Utillity) as SumUtillity, " & _
    '"SUM(RepairMaintenance) as SumRepairMaintenance, " & _
    '"COUNT(dd.costcenter_id) as SumCostCenter, " & _
    '"ptype = 'New Store' ,xx='1' " & _
    '"from mtd dd,costcenter cb,store sto4 " & _
    '"where dd.costcenter_id = cb.costcenter_id  and cb.costcenter_store = sto4.store_id and sto4.store_other = 'Y' and dd.month_time = @thisyear and ( cb.costcenter_blockdt is null or cb.costcenter_blockdt > @thisyear2 ) " & _
    '"order by xx desc "


    '        Dim con As New SqlConnection(strcon)
    '        Dim cmd As New SqlCommand(sql, con)

    '        Dim parameter As New SqlParameter("@thisyear", SqlDbType.DateTime)
    '        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing)
    '        cmd.Parameters.Add(parameter)

    '        parameter = New SqlParameter("@lastyear", SqlDbType.DateTime)
    '        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + lastyear), ClsManage.formatDateTime, Nothing)
    '        cmd.Parameters.Add(parameter)

    '        parameter = New SqlParameter("@thisyear2", SqlDbType.DateTime)
    '        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + years), ClsManage.formatDateTime, Nothing).AddMonths(1).AddDays(-1)
    '        cmd.Parameters.Add(parameter)

    '        parameter = New SqlParameter("@lastyear2", SqlDbType.DateTime)
    '        parameter.Value = DateTime.ParseExact(("1/" + mon + "/" + lastyear), ClsManage.formatDateTime, Nothing).AddMonths(1).AddDays(-1)
    '        cmd.Parameters.Add(parameter)

    '        parameter = New SqlParameter("@openyear", SqlDbType.DateTime)
    '        If mon < 4 Then
    '            parameter.Value = DateTime.ParseExact(("1/4/" + lastyear), ClsManage.formatDateTime, Nothing)
    '        Else
    '            parameter.Value = DateTime.ParseExact(("1/4/" + years), ClsManage.formatDateTime, Nothing)
    '        End If
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

#Region "Export"

    Public Shared Sub ExportToExcel2(ByVal data_temp As String, Optional excelName As String = "MTD_Model_Report")
        HttpContext.Current.Response.ClearContent()
        HttpContext.Current.Response.Charset = ""
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + excelName + ".xls")
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"

        Dim StringWrite As New System.IO.StringWriter
        Dim HtmlWrite As New System.Web.UI.HtmlTextWriter(StringWrite)

        Dim htmlbody As String = ""
        htmlbody += data_temp

        HttpContext.Current.Response.Write(htmlbody)
        HttpContext.Current.Response.End()
    End Sub

    Public Shared Sub ExportToExcel(ByVal data_temp As String, Optional excelName As String = "MTD_Model_Report")

        HttpContext.Current.Response.ClearContent()
        HttpContext.Current.Response.Charset = ""
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode
        HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & excelName & ".xls")
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        HttpContext.Current.Response.Write(data_temp)
        HttpContext.Current.Response.End()
    End Sub
#End Region

#Region "Users"
    Public Shared Function getUserData() As DataTable

        Dim sql As String = "select * from users where users_type='NORMAL' order by users_name asc"

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getUserDataById(ByVal id As String) As DataTable

        Dim sql As String = "select * from users where users_type='NORMAL' and users_id='" + id + "' "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getUserDataByName(ByVal name As String) As DataTable


        Dim sql As String = "SELECT * " & _
                          " FROM  users " & _
                          " Where (users_name = @user_name)"


        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)
        Try
            Dim parameter As New SqlParameter("@user_name", SqlDbType.VarChar, 50)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function InsertUserData(ByVal name As String, ByVal pass As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("insert into users(users_name,users_pass,users_type) values(@name,@pass,'NORMAL')")

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            parameter.Value = name
            cmd.Parameters.Add(parameter)

            parameter = New SqlParameter("@pass", SqlDbType.VarChar)
            parameter.Value = pass
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function DelUsersDataById(ByVal id As String) As Integer

        Dim con As New SqlConnection(strcon)
        Dim sql As String = "Delete from users where users_id=" + id

        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandText = sql
        con.Open()
        Try

            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return result

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function

    Public Shared Function UpdateUserdata(ByVal id As String, ByVal pass As String) As Integer
        Try
            Dim con As New SqlConnection(strcon)

            Dim sql As String = String.Format("update users set users_pass=@pass where users_id=" + id)

            Dim cmd As New SqlCommand(sql, con)
            Dim parameter As New SqlParameter("@pass", SqlDbType.VarChar)
            parameter.Value = pass
            cmd.Parameters.Add(parameter)

            cmd.CommandText = sql
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()

            Return result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "budget"
    Public Shared Function getBudgById(ByVal id As String) As DataTable

        Dim sql As String = "select * from budget where costcenter_id='" + id + "' order by month_time asc "

        Dim con As New SqlConnection(strcon)
        Dim cmd As New SqlCommand(sql, con)

        Try

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertBudget(ByVal TotalRevenue As String, ByVal RETAIL_TESPIncome As String, ByVal OtherRevenue As String, ByVal CostofGoodSold As String, ByVal GrossProfit As String, ByVal GrossProfit_percent As String, ByVal MarginAdjustments As String, ByVal Shipping As String, ByVal StockLossandObsolescence As String, ByVal InventoryAdjustment_stock As String, ByVal InventoryAdjustment_damage As String, ByVal StockLoss_Provision As String, ByVal StockObsolescence_Provision As String, ByVal GWP As String, ByVal GWPs_Corporate As String, ByVal GWPs_Transferred As String, ByVal SellingCosts As String, ByVal Creditcardscommission As String, ByVal LabellingMaterial As String, ByVal OtherIncome_COSHFunding As String, ByVal OtherIncomeSupplier As String, ByVal AdjustedGrossMargin As String, ByVal SupplyChainCosts As String, ByVal TotalStoreExpenses As String, ByVal StoreLabourCosts As String, ByVal GrossPay As String, ByVal TemporaryStaffCosts As String, ByVal Allowance As String, ByVal Overtime As String, ByVal Licensefee As String, ByVal Bonuses_Incentives As String, ByVal BootsBrandncentives As String, ByVal SuppliersIncentive As String, ByVal ProvidentFund As String, ByVal PensionCosts As String, ByVal SocialSecurityFund As String, ByVal Uniforms As String, ByVal EmployeeWelfare As String, ByVal OtherBenefitsEmployee As String, ByVal StorePropertyCosts As String, ByVal PropertyRental As String, ByVal PropertyServices As String, ByVal PropertyFacility As String, ByVal Propertytaxes As String, ByVal Facialtaxes As String, ByVal PropertyInsurance As String, ByVal Signboard As String, ByVal Discount_Rent_Services_Facility As String, ByVal GPCommission As String, ByVal AmortizationofLeaseRight As String, ByVal Depreciation As String, ByVal DepreciationofShortLeaseBuilding As String, ByVal DepreciationofComputerHardware As String, ByVal DepreciationofFixturesFittings As String, ByVal DepreciationofComputerSoftware As String, ByVal DepreciationofOfficeEquipment As String, ByVal OtherStoreCosts As String, ByVal ServiceChargesandOtherFees As String, ByVal BankCharges As String, ByVal CashCollectionCharge As String, ByVal Cleaning As String, ByVal SecurityGuards As String, ByVal Carriage As String, ByVal LicenceFees As String, ByVal OtherServicesCharge As String, ByVal OtherFees As String, ByVal Utilities As String, ByVal Water As String, ByVal Gas_Electric As String, ByVal AirCond_Addition As String, ByVal RepairandMaintenance As String, ByVal RMOther_Fix As String, ByVal RMOther_Unplan As String, ByVal RMComputer_Fix As String, ByVal RMComputer_Unplan As String, ByVal ProfessionalFee As String, ByVal MarketingResearch As String, ByVal OtherFee As String, ByVal Equipment_MaterailandSupplies As String, ByVal PrintingandStationery As String, ByVal SuppliesExpenses As String, ByVal Equipment As String, ByVal Shopfitting As String, ByVal PackagingandOtherMaterial As String, ByVal BusinessTravelExpenses As String, ByVal CarParkingandOthers As String, ByVal Travel As String, ByVal Accomodation As String, ByVal MealandEntertainment As String, ByVal Insurance As String, ByVal AllRiskInsurance As String, ByVal HealthandLifeInsurance As String, ByVal PenaltyandTaxation As String, ByVal Taxation As String, ByVal Penalty As String, ByVal OtherRelatedStaffCost As String, ByVal StaffConferenceandTraining As String, ByVal Training As String, ByVal Communication As String, ByVal TelephoneCalls_Faxes As String, ByVal PostageandCourier As String, ByVal OtherExpenses As String, ByVal Sample_Tester As String, ByVal PreopeningCosts As String, ByVal LossonClaim As String, ByVal CashOvertage_Shortagefromsales As String, ByVal MiscellenousandOther As String, ByVal StoreTradingProfit__Loss As String, ByVal TradingProfit__Loss As String, ByVal StoreControllableCostsforBSC As String, ByVal StoreLabourCost As String, ByVal Utillity As String, ByVal RepairMaintenance As String) As Integer
        Try
            '        Dim con As New SqlConnection(strcon)

            '        Dim sql As String = String.Format("insert into province(province_name) values(@name)")

            '        Dim cmd As New SqlCommand(sql, con)
            '        Dim parameter As New SqlParameter("@name", SqlDbType.VarChar)
            '        parameter.Value = name
            '        cmd.Parameters.Add(parameter)

            '        cmd.CommandText = sql
            '        con.Open()
            '        Dim result As Integer = cmd.ExecuteNonQuery()
            '        con.Close()

            '        Return result

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region


End Class
