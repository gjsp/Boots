
Partial Class uc_ucDetail
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            
          

        End If
    End Sub

    Function getData() As Data.DataTable

        Dim sql As String = "select " & _
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
"SUM(RepairMaintenance) as SumRepairMaintenance From mtd where costcenter_id = 8"


        Try
            Dim dt As New Data.DataTable
            Dim da As New Data.SqlClient.SqlDataAdapter(sql, ClsDB.strcon)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub LoadPortFolio()
        Try
            Dim dt As New Data.DataTable
            dt = getData()
            If dt.Rows.Count > 0 Then
                Dim strHtml As New StringBuilder
                strHtml.Append("")
                strHtml.Append("<table cellspacing='0' cellpadding='0' class='tball'>")
                strHtml.Append("<tr style='font-weight:bold;' class='kbg5'>")
                strHtml.Append("<td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Revenue <span id='spaa' class='ppk' onclick='minitb('aa');'>+</span></div></td>")
                strHtml.Append("<td align='right'><div style='width:110px'>{0}</div></td>")
                strHtml.Append("<td align='right'><div style='width:65px;'>%</div></td>")
                strHtml.Append("</tr>")
                strHtml.Append("<tr id='aa1'>")
                strHtml.Append("<td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sale Revenue</div></td>")
                strHtml.Append("<td align='right' class='kbg3'><div style='width:110px'>{1}</div></td>")
                strHtml.Append("<td align='right' class='kbg4'><div style='width:65px;'>%</div></td>")
                strHtml.Append("</tr>")
                strHtml.Append("<tr id='aa2'>")
                strHtml.Append("<td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Revenue</div></td>")
                strHtml.Append("<td align='right' class='kbg3'><div style='width:110px'>{2}</div></td>")
                strHtml.Append("<td align='right' class='kbg4'><div style='width:65px;'>%</div></td>")
                strHtml.Append("</tr>")
                strHtml.Append("<tr style='font-weight:bold;'>")
                strHtml.Append("<td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Cost of Good Sold</div></td>")
                strHtml.Append("<td align='right' class='kbg3'><div style='width:110px'>{3}</div></td>")
                strHtml.Append("<td align='right' class='kbg4'><div style='width:65px;'>%</div></td>")
                strHtml.Append("</tr>")
                strHtml.Append("<tr style='font-weight:bold;' class='kbg5'>")
                strHtml.Append("<td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Gross Profit</div></td>")
                strHtml.Append("<td align='right'><div style='width:110px'>{4}</div></td>")
                strHtml.Append("<td align='right'><div style='width:65px;'>%</div></td></tr>")
                strHtml.Append("<tr style='font-weight:bold;'>")
                strHtml.Append("<td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Margin Adjustments <span id='spb' class='ppk' onclick='minitb('b');'>+</span></div></td>")
                strHtml.Append("<td align='right' class='kbg3'><div style='width:110px'>{5}</div></td>")
                strHtml.Append("<td align='right' class='kbg4'><div style='width:65px;'>%</div></td></tr>")
                strHtml.Append("<tr id='b1'>")
                strHtml.Append("<td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shipping</div></td>")
                strHtml.Append("<td align='right' class='kbg3'><div style='width:110px'>{6}</div></td>")
                strHtml.Append("<td align='right' class='kbg4'><div style='width:65px;'>%</div></td></tr>")
                strHtml.Append("<tr id='b2'>")
                strHtml.Append("<td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss and Obsolescence</div></td>")
                strHtml.Append("<td align='right' class='kbg3'><div style='width:110px'>{7}</div></td>")
                strHtml.Append("<td align='right' class='kbg4'><div style='width:65px;'>%</div></td>")
                strHtml.Append("</tr>")
                strHtml.Append("</table>")

                Dim str As String = String.Format(strHtml.ToString, dt.Rows(0)(0).ToString, _
                                                  strHtml.ToString, dt.Rows(0)(1).ToString, _
                                                  strHtml.ToString, dt.Rows(0)(2).ToString, _
                                                  strHtml.ToString, dt.Rows(0)(3).ToString, _
                                                  strHtml.ToString, dt.Rows(0)(4).ToString, _
                                                  strHtml.ToString, dt.Rows(0)(5).ToString, _
                                                  strHtml.ToString, dt.Rows(0)(6).ToString, _
                                                  strHtml.ToString, dt.Rows(0)(7).ToString _
                                                  )
                divHtml.InnerHtml = str


            End If
        Catch ex As Exception
            clsManage.alert(Page, ex.Message)
        End Try
    End Sub
End Class
