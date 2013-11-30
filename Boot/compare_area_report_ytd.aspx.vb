
Partial Class compare_area_report_ytd
    Inherits basePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Panel1.Visible = False
            ddlYear.DataValueField = "mon_year"
            ddlYear.DataTextField = "mon_year"
            ddlYear.DataSource = ClsDB.getMtdYear()
            ddlYear.DataBind()

            ddlMonth.DataValueField = "mon_year"
            ddlMonth.DataTextField = "mon_name"
            ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
            ddlMonth.DataBind()

            ClsDB.getCurrentcyToDDL(ddlRate)

            '    Dim dt As New Data.DataTable
            '    Dim dn As System.Data.DataRow
            '    Dim dataModel As Data.DataTable
            '    dataModel = ClsDB.getMtdModel


            '    For Each dr In dataModel.Rows
            '        Dim dv As Data.DataTable
            '        dv = ClsDB.getMtdModelByID(dr("cost_store"))
            '        dt.Columns.Add(dr("store_name"))
            '        dn = dt.NewRow
            '        dn(dr("store_name")) = dv.Rows(0)("sumtotal").ToString
            '        dt.Rows.Add(dn)
            '    Next


            '    'If dn Is Nothing Then
            '    '    dt.Columns.Add(dr("store_name"))
            '    '    dn = dt.NewRow
            '    '    dn(i) = dv.Rows(0)("sumtotal").ToString
            '    '    dt.Rows.Add(dn)
            '    'Else
            '    '    dn = dt.Rows(
            '    '    dn(i) = dv.Rows(0)("sumtotal").ToString
            '    '    dt.Rows.Add(dn)

            '    'End If

            '    'i += 1

            '    GridView1.DataSource = dt
            '    GridView1.DataBind()

        End If
    End Sub

    Protected Sub ddlYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYear.TextChanged
        ddlMonth.DataValueField = "mon_year"
        ddlMonth.DataTextField = "mon_name"
        ddlMonth.DataSource = ClsDB.getMtdMonth(ddlYear.SelectedValue)
        ddlMonth.DataBind()
    End Sub

    Protected Sub SearchBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchBt.Click

        Dim x_divide As String = 0
        If ddlMonth.SelectedValue < 4 Then
            x_divide = ddlMonth.SelectedValue + 9
        Else
            x_divide = ddlMonth.SelectedValue - 3
        End If
		 LbYtdDate.Text = "YTD " + x_divide + " M"
		 LbBKKYtdDate.Text = "YTD " + x_divide + " M"
		 LbUPYtdDate.Text = "YTD " + x_divide + " M"

       Panel1.Visible = True
        Pftb.Visible = True
        TbCk.Text = 0
    		LbNost.Text = 0
		LbNostBKK.Text = 0
		LbNostUP.Text = 0

            LbFullTgs.Text = 0
            LbFullTss.Text = 0
            LbFullPos.text = 0
            LbSumTotalRevenue.Text = 0
            LbSumRETAIL_TESPIncome.Text = 0
            LbSumOtherRevenue.Text = 0
            LbSumCostofGoodSold.Text = 0
            LbSumGrossProfit.Text = 0
            'LbSumGrossProfit_percent.Text = 0
            LbSumMarginAdjustments.Text = 0
            LbSumShipping.Text = 0
            LbSumStockLossandObsolescence.Text = 0
            LbSumInventoryAdjustment_stock.Text = 0
            LbSumInventoryAdjustment_damage.Text = 0
            LbSumStockLoss_Provision.Text = 0
            LbSumStockObsolescence_Provision.Text = 0
            LbSumGWP.Text = 0
            LbSumGWPs_Corporate.Text = 0
            LbSumGWPs_Transferred.Text = 0
            LbSumSellingCosts.Text = 0
            LbSumCreditcardscommission.Text = 0
            LbSumLabellingMaterial.Text = 0
            LbSumOtherIncome_COSHFunding.Text = 0
            LbSumOtherIncomeSupplier.Text = 0
            LbSumAdjustedGrossMargin.Text = 0
            LbSumSupplyChainCosts.Text = 0
            LbSumTotalStoreExpenses.Text = 0
            LbSumStoreLabourCosts.Text = 0
            LbSumGrossPay.Text = 0
            LbSumTemporaryStaffCosts.Text = 0
            LbSumAllowance.Text = 0
            LbSumOvertime.Text = 0
            LbSumLicensefee.Text = 0
            LbSumBonuses_Incentives.Text = 0
            LbSumBootsBrandncentives.Text = 0
            LbSumSuppliersIncentive.Text = 0
            LbSumProvidentFund.Text = 0
            LbSumPensionCosts.Text = 0
            LbSumSocialSecurityFund.Text = 0
            LbSumUniforms.Text = 0
            LbSumEmployeeWelfare.Text = 0
            LbSumOtherBenefitsEmployee.Text = 0
            LbSumStorePropertyCosts.Text = 0
            LbSumPropertyRental.Text = 0
            LbSumPropertyServices.Text = 0
            LbSumPropertyFacility.Text = 0
            LbSumPropertytaxes.Text = 0
            LbSumFacialtaxes.Text = 0
            LbSumPropertyInsurance.Text = 0
            LbSumSignboard.Text = 0
            LbSumDiscount_Rent_Services_Facility.Text = 0
            LbSumGPCommission.Text = 0
            LbSumAmortizationofLeaseRight.Text = 0
            LbSumDepreciation.Text = 0
            LbSumDepreciationofShortLeaseBuilding.Text = 0
            LbSumDepreciationofComputerHardware.Text = 0
            LbSumDepreciationofFixturesFittings.Text = 0
            LbSumDepreciationofComputerSoftware.Text = 0
            LbSumDepreciationofOfficeEquipment.Text = 0
            LbSumOtherStoreCosts.Text = 0
            LbSumServiceChargesandOtherFees.Text = 0
            LbSumBankCharges.Text = 0
            LbSumCashCollectionCharge.Text = 0
            LbSumCleaning.Text = 0
            LbSumSecurityGuards.Text = 0
            LbSumCarriage.Text = 0
            LbSumLicenceFees.Text = 0
            LbSumOtherServicesCharge.Text = 0
            LbSumOtherFees.Text = 0
            LbSumUtilities.Text = 0
            LbSumWater.Text = 0
            LbSumGas_Electric.Text = 0
            LbSumAirCond_Addition.Text = 0
            LbSumRepairandMaintenance.Text = 0
            LbSumRMOther_Fix.Text = 0
            LbSumRMOther_Unplan.Text = 0
            LbSumRMComputer_Fix.Text = 0
            LbSumRMComputer_Unplan.Text = 0
            LbSumProfessionalFee.Text = 0
            LbSumMarketingResearch.Text = 0
            LbSumOtherFee.Text = 0
            LbSumEquipment_MaterailandSupplies.Text = 0
            LbSumPrintingandStationery.Text = 0
            LbSumSuppliesExpenses.Text = 0
            LbSumEquipment.Text = 0
            LbSumShopfitting.Text = 0
            LbSumPackagingandOtherMaterial.Text = 0
            LbSumBusinessTravelExpenses.Text = 0
            LbSumCarParkingandOthers.Text = 0
            LbSumTravel.Text = 0
            LbSumAccomodation.Text = 0
            LbSumMealandEntertainment.Text = 0
            LbSumInsurance.Text = 0
            LbSumAllRiskInsurance.Text = 0
            LbSumHealthandLifeInsurance.Text = 0
            LbSumPenaltyandTaxation.Text = 0
            LbSumTaxation.Text = 0
            LbSumPenalty.Text = 0
            LbSumOtherRelatedStaffCost.Text = 0
            LbSumStaffConferenceandTraining.Text = 0
            LbSumTraining.Text = 0
            LbSumCommunication.Text = 0
            LbSumTelephoneCalls_Faxes.Text = 0
            LbSumPostageandCourier.Text = 0
            LbSumOtherExpenses.Text = 0
            LbSumSample_Tester.Text = 0
            LbSumPreopeningCosts.Text = 0
            LbSumLossonClaim.Text = 0
            LbSumCashOvertage_Shortagefromsales.Text = 0
            LbSumMiscellenousandOther.Text = 0
            LbSumStoreTradingProfit__Loss.Text = 0

            LbBKKFullTgs.Text = 0
            LbBKKFullTss.Text = 0
            LbBKKFullPos.text = 0
            LbBKKSumTotalRevenue.Text = 0
            LbBKKSumRETAIL_TESPIncome.Text = 0
            LbBKKSumOtherRevenue.Text = 0
            LbBKKSumCostofGoodSold.Text = 0
            LbBKKSumGrossProfit.Text = 0
            'LbBKKSumGrossProfit_percent.Text = 0
            LbBKKSumMarginAdjustments.Text = 0
            LbBKKSumShipping.Text = 0
            LbBKKSumStockLossandObsolescence.Text = 0
            LbBKKSumInventoryAdjustment_stock.Text = 0
            LbBKKSumInventoryAdjustment_damage.Text = 0
            LbBKKSumStockLoss_Provision.Text = 0
            LbBKKSumStockObsolescence_Provision.Text = 0
            LbBKKSumGWP.Text = 0
            LbBKKSumGWPs_Corporate.Text = 0
            LbBKKSumGWPs_Transferred.Text = 0
            LbBKKSumSellingCosts.Text = 0
            LbBKKSumCreditcardscommission.Text = 0
            LbBKKSumLabellingMaterial.Text = 0
            LbBKKSumOtherIncome_COSHFunding.Text = 0
            LbBKKSumOtherIncomeSupplier.Text = 0
            LbBKKSumAdjustedGrossMargin.Text = 0
            LbBKKSumSupplyChainCosts.Text = 0
            LbBKKSumTotalStoreExpenses.Text = 0
            LbBKKSumStoreLabourCosts.Text = 0
            LbBKKSumGrossPay.Text = 0
            LbBKKSumTemporaryStaffCosts.Text = 0
            LbBKKSumAllowance.Text = 0
            LbBKKSumOvertime.Text = 0
            LbBKKSumLicensefee.Text = 0
            LbBKKSumBonuses_Incentives.Text = 0
            LbBKKSumBootsBrandncentives.Text = 0
            LbBKKSumSuppliersIncentive.Text = 0
            LbBKKSumProvidentFund.Text = 0
            LbBKKSumPensionCosts.Text = 0
            LbBKKSumSocialSecurityFund.Text = 0
            LbBKKSumUniforms.Text = 0
            LbBKKSumEmployeeWelfare.Text = 0
            LbBKKSumOtherBenefitsEmployee.Text = 0
            LbBKKSumStorePropertyCosts.Text = 0
            LbBKKSumPropertyRental.Text = 0
            LbBKKSumPropertyServices.Text = 0
            LbBKKSumPropertyFacility.Text = 0
            LbBKKSumPropertytaxes.Text = 0
            LbBKKSumFacialtaxes.Text = 0
            LbBKKSumPropertyInsurance.Text = 0
            LbBKKSumSignboard.Text = 0
            LbBKKSumDiscount_Rent_Services_Facility.Text = 0
            LbBKKSumGPCommission.Text = 0
            LbBKKSumAmortizationofLeaseRight.Text = 0
            LbBKKSumDepreciation.Text = 0
            LbBKKSumDepreciationofShortLeaseBuilding.Text = 0
            LbBKKSumDepreciationofComputerHardware.Text = 0
            LbBKKSumDepreciationofFixturesFittings.Text = 0
            LbBKKSumDepreciationofComputerSoftware.Text = 0
            LbBKKSumDepreciationofOfficeEquipment.Text = 0
            LbBKKSumOtherStoreCosts.Text = 0
            LbBKKSumServiceChargesandOtherFees.Text = 0
            LbBKKSumBankCharges.Text = 0
            LbBKKSumCashCollectionCharge.Text = 0
            LbBKKSumCleaning.Text = 0
            LbBKKSumSecurityGuards.Text = 0
            LbBKKSumCarriage.Text = 0
            LbBKKSumLicenceFees.Text = 0
            LbBKKSumOtherServicesCharge.Text = 0
            LbBKKSumOtherFees.Text = 0
            LbBKKSumUtilities.Text = 0
            LbBKKSumWater.Text = 0
            LbBKKSumGas_Electric.Text = 0
            LbBKKSumAirCond_Addition.Text = 0
            LbBKKSumRepairandMaintenance.Text = 0
            LbBKKSumRMOther_Fix.Text = 0
            LbBKKSumRMOther_Unplan.Text = 0
            LbBKKSumRMComputer_Fix.Text = 0
            LbBKKSumRMComputer_Unplan.Text = 0
            LbBKKSumProfessionalFee.Text = 0
            LbBKKSumMarketingResearch.Text = 0
            LbBKKSumOtherFee.Text = 0
            LbBKKSumEquipment_MaterailandSupplies.Text = 0
            LbBKKSumPrintingandStationery.Text = 0
            LbBKKSumSuppliesExpenses.Text = 0
            LbBKKSumEquipment.Text = 0
            LbBKKSumShopfitting.Text = 0
            LbBKKSumPackagingandOtherMaterial.Text = 0
            LbBKKSumBusinessTravelExpenses.Text = 0
            LbBKKSumCarParkingandOthers.Text = 0
            LbBKKSumTravel.Text = 0
            LbBKKSumAccomodation.Text = 0
            LbBKKSumMealandEntertainment.Text = 0
            LbBKKSumInsurance.Text = 0
            LbBKKSumAllRiskInsurance.Text = 0
            LbBKKSumHealthandLifeInsurance.Text = 0
            LbBKKSumPenaltyandTaxation.Text = 0
            LbBKKSumTaxation.Text = 0
            LbBKKSumPenalty.Text = 0
            LbBKKSumOtherRelatedStaffCost.Text = 0
            LbBKKSumStaffConferenceandTraining.Text = 0
            LbBKKSumTraining.Text = 0
            LbBKKSumCommunication.Text = 0
            LbBKKSumTelephoneCalls_Faxes.Text = 0
            LbBKKSumPostageandCourier.Text = 0
            LbBKKSumOtherExpenses.Text = 0
            LbBKKSumSample_Tester.Text = 0
            LbBKKSumPreopeningCosts.Text = 0
            LbBKKSumLossonClaim.Text = 0
            LbBKKSumCashOvertage_Shortagefromsales.Text = 0
            LbBKKSumMiscellenousandOther.Text = 0
            LbBKKSumStoreTradingProfit__Loss.Text = 0

            LbUPFullTgs.Text = 0
            LbUPFullTss.Text = 0
            LbUPFullPos.text = 0
            LbUPSumTotalRevenue.Text = 0
            LbUPSumRETAIL_TESPIncome.Text = 0
            LbUPSumOtherRevenue.Text = 0
            LbUPSumCostofGoodSold.Text = 0
            LbUPSumGrossProfit.Text = 0
            'LbUPSumGrossProfit_percent.Text = 0
            LbUPSumMarginAdjustments.Text = 0
            LbUPSumShipping.Text = 0
            LbUPSumStockLossandObsolescence.Text = 0
            LbUPSumInventoryAdjustment_stock.Text = 0
            LbUPSumInventoryAdjustment_damage.Text = 0
            LbUPSumStockLoss_Provision.Text = 0
            LbUPSumStockObsolescence_Provision.Text = 0
            LbUPSumGWP.Text = 0
            LbUPSumGWPs_Corporate.Text = 0
            LbUPSumGWPs_Transferred.Text = 0
            LbUPSumSellingCosts.Text = 0
            LbUPSumCreditcardscommission.Text = 0
            LbUPSumLabellingMaterial.Text = 0
            LbUPSumOtherIncome_COSHFunding.Text = 0
            LbUPSumOtherIncomeSupplier.Text = 0
            LbUPSumAdjustedGrossMargin.Text = 0
            LbUPSumSupplyChainCosts.Text = 0
            LbUPSumTotalStoreExpenses.Text = 0
            LbUPSumStoreLabourCosts.Text = 0
            LbUPSumGrossPay.Text = 0
            LbUPSumTemporaryStaffCosts.Text = 0
            LbUPSumAllowance.Text = 0
            LbUPSumOvertime.Text = 0
            LbUPSumLicensefee.Text = 0
            LbUPSumBonuses_Incentives.Text = 0
            LbUPSumBootsBrandncentives.Text = 0
            LbUPSumSuppliersIncentive.Text = 0
            LbUPSumProvidentFund.Text = 0
            LbUPSumPensionCosts.Text = 0
            LbUPSumSocialSecurityFund.Text = 0
            LbUPSumUniforms.Text = 0
            LbUPSumEmployeeWelfare.Text = 0
            LbUPSumOtherBenefitsEmployee.Text = 0
            LbUPSumStorePropertyCosts.Text = 0
            LbUPSumPropertyRental.Text = 0
            LbUPSumPropertyServices.Text = 0
            LbUPSumPropertyFacility.Text = 0
            LbUPSumPropertytaxes.Text = 0
            LbUPSumFacialtaxes.Text = 0
            LbUPSumPropertyInsurance.Text = 0
            LbUPSumSignboard.Text = 0
            LbUPSumDiscount_Rent_Services_Facility.Text = 0
            LbUPSumGPCommission.Text = 0
            LbUPSumAmortizationofLeaseRight.Text = 0
            LbUPSumDepreciation.Text = 0
            LbUPSumDepreciationofShortLeaseBuilding.Text = 0
            LbUPSumDepreciationofComputerHardware.Text = 0
            LbUPSumDepreciationofFixturesFittings.Text = 0
            LbUPSumDepreciationofComputerSoftware.Text = 0
            LbUPSumDepreciationofOfficeEquipment.Text = 0
            LbUPSumOtherStoreCosts.Text = 0
            LbUPSumServiceChargesandOtherFees.Text = 0
            LbUPSumBankCharges.Text = 0
            LbUPSumCashCollectionCharge.Text = 0
            LbUPSumCleaning.Text = 0
            LbUPSumSecurityGuards.Text = 0
            LbUPSumCarriage.Text = 0
            LbUPSumLicenceFees.Text = 0
            LbUPSumOtherServicesCharge.Text = 0
            LbUPSumOtherFees.Text = 0
            LbUPSumUtilities.Text = 0
            LbUPSumWater.Text = 0
            LbUPSumGas_Electric.Text = 0
            LbUPSumAirCond_Addition.Text = 0
            LbUPSumRepairandMaintenance.Text = 0
            LbUPSumRMOther_Fix.Text = 0
            LbUPSumRMOther_Unplan.Text = 0
            LbUPSumRMComputer_Fix.Text = 0
            LbUPSumRMComputer_Unplan.Text = 0
            LbUPSumProfessionalFee.Text = 0
            LbUPSumMarketingResearch.Text = 0
            LbUPSumOtherFee.Text = 0
            LbUPSumEquipment_MaterailandSupplies.Text = 0
            LbUPSumPrintingandStationery.Text = 0
            LbUPSumSuppliesExpenses.Text = 0
            LbUPSumEquipment.Text = 0
            LbUPSumShopfitting.Text = 0
            LbUPSumPackagingandOtherMaterial.Text = 0
            LbUPSumBusinessTravelExpenses.Text = 0
            LbUPSumCarParkingandOthers.Text = 0
            LbUPSumTravel.Text = 0
            LbUPSumAccomodation.Text = 0
            LbUPSumMealandEntertainment.Text = 0
            LbUPSumInsurance.Text = 0
            LbUPSumAllRiskInsurance.Text = 0
            LbUPSumHealthandLifeInsurance.Text = 0
            LbUPSumPenaltyandTaxation.Text = 0
            LbUPSumTaxation.Text = 0
            LbUPSumPenalty.Text = 0
            LbUPSumOtherRelatedStaffCost.Text = 0
            LbUPSumStaffConferenceandTraining.Text = 0
            LbUPSumTraining.Text = 0
            LbUPSumCommunication.Text = 0
            LbUPSumTelephoneCalls_Faxes.Text = 0
            LbUPSumPostageandCourier.Text = 0
            LbUPSumOtherExpenses.Text = 0
            LbUPSumSample_Tester.Text = 0
            LbUPSumPreopeningCosts.Text = 0
            LbUPSumLossonClaim.Text = 0
            LbUPSumCashOvertage_Shortagefromsales.Text = 0
            LbUPSumMiscellenousandOther.Text = 0
            LbUPSumStoreTradingProfit__Loss.Text = 0

            'LbSumTradingProfit__Loss.Text = 0

			Dim start_year As String
            If ddlMonth.SelectedValue < 4 Then
                start_year = "1/4/" + (ddlYear.SelectedValue - 1).ToString
            Else
                start_year = "1/4/" + ddlYear.SelectedValue.ToString
            End If
        ObjectDataSource2.SelectParameters("rate").DefaultValue = ddlRate.SelectedValue
            ObjectDataSource2.SelectParameters("years").DefaultValue = ddlYear.SelectedValue
            ObjectDataSource2.SelectParameters("mon").DefaultValue = ddlMonth.SelectedValue
            ObjectDataSource2.SelectParameters("locate").DefaultValue = "TWO"
			ObjectDataSource2.SelectParameters("start_time").DefaultValue = start_year
            DataList2.DataBind()

            If LbSumTotalRevenue.Text <> 0 Then
                DataList2.Visible = True
                Pftb.Visible = True
                LbPercTotalRevenue.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumTotalRevenue.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercRETAIL_TESPIncome.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumRETAIL_TESPIncome.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherRevenue.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherRevenue.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercCostofGoodSold.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumCostofGoodSold.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercGrossProfit.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumGrossProfit.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
           LbPercMarginAdjustments.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumMarginAdjustments.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercShipping.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumShipping.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercStockLossandObsolescence.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumStockLossandObsolescence.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercInventoryAdjustment_stock.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumInventoryAdjustment_stock.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercInventoryAdjustment_damage.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumInventoryAdjustment_damage.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercStockLoss_Provision.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumStockLoss_Provision.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercStockObsolescence_Provision.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumStockObsolescence_Provision.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercGWP.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumGWP.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercGWPs_Corporate.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumGWPs_Corporate.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercGWPs_Transferred.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumGWPs_Transferred.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercSellingCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumSellingCosts.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercCreditcardscommission.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumCreditcardscommission.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercLabellingMaterial.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumLabellingMaterial.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherIncome_COSHFunding.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherIncome_COSHFunding.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherIncomeSupplier.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherIncomeSupplier.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercAdjustedGrossMargin.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumAdjustedGrossMargin.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercSupplyChainCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumSupplyChainCosts.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercTotalStoreExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumTotalStoreExpenses.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercStoreLabourCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumStoreLabourCosts.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercGrossPay.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumGrossPay.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercTemporaryStaffCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumTemporaryStaffCosts.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercAllowance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumAllowance.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOvertime.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOvertime.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercLicensefee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumLicensefee.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercBonuses_Incentives.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumBonuses_Incentives.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercBootsBrandncentives.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumBootsBrandncentives.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercSuppliersIncentive.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumSuppliersIncentive.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercProvidentFund.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumProvidentFund.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPensionCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPensionCosts.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercSocialSecurityFund.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumSocialSecurityFund.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercUniforms.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumUniforms.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercEmployeeWelfare.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumEmployeeWelfare.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherBenefitsEmployee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherBenefitsEmployee.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercStorePropertyCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumStorePropertyCosts.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPropertyRental.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPropertyRental.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPropertyServices.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPropertyServices.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPropertyFacility.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPropertyFacility.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPropertytaxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPropertytaxes.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercFacialtaxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumFacialtaxes.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPropertyInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPropertyInsurance.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercSignboard.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumSignboard.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumDiscount_Rent_Services_Facility.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercGPCommission.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumGPCommission.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercAmortizationofLeaseRight.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumAmortizationofLeaseRight.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercDepreciation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumDepreciation.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumDepreciationofShortLeaseBuilding.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercDepreciationofComputerHardware.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumDepreciationofComputerHardware.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercDepreciationofFixturesFittings.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumDepreciationofFixturesFittings.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercDepreciationofComputerSoftware.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumDepreciationofComputerSoftware.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumDepreciationofOfficeEquipment.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherStoreCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherStoreCosts.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercServiceChargesandOtherFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumServiceChargesandOtherFees.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercBankCharges.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumBankCharges.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercCashCollectionCharge.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumCashCollectionCharge.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercCleaning.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumCleaning.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercSecurityGuards.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumSecurityGuards.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercCarriage.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumCarriage.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercLicenceFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumLicenceFees.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherServicesCharge.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherServicesCharge.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherFees.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercUtilities.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumUtilities.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercWater.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumWater.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercGas_Electric.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumGas_Electric.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercAirCond_Addition.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumAirCond_Addition.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercRepairandMaintenance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumRepairandMaintenance.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercRMOther_Fix.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumRMOther_Fix.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercRMOther_Unplan.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumRMOther_Unplan.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercRMComputer_Fix.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumRMComputer_Fix.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercRMComputer_Unplan.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumRMComputer_Unplan.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercProfessionalFee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumProfessionalFee.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercMarketingResearch.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumMarketingResearch.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherFee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherFee.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumEquipment_MaterailandSupplies.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPrintingandStationery.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPrintingandStationery.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercSuppliesExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumSuppliesExpenses.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercEquipment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumEquipment.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercShopfitting.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumShopfitting.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPackagingandOtherMaterial.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPackagingandOtherMaterial.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercBusinessTravelExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumBusinessTravelExpenses.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercCarParkingandOthers.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumCarParkingandOthers.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercTravel.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumTravel.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercAccomodation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumAccomodation.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercMealandEntertainment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumMealandEntertainment.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumInsurance.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercAllRiskInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumAllRiskInsurance.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercHealthandLifeInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumHealthandLifeInsurance.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPenaltyandTaxation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPenaltyandTaxation.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercTaxation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumTaxation.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPenalty.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPenalty.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherRelatedStaffCost.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherRelatedStaffCost.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercStaffConferenceandTraining.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumStaffConferenceandTraining.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercTraining.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumTraining.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercCommunication.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumCommunication.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercTelephoneCalls_Faxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumTelephoneCalls_Faxes.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPostageandCourier.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPostageandCourier.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercOtherExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumOtherExpenses.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercSample_Tester.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumSample_Tester.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercPreopeningCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumPreopeningCosts.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercLossonClaim.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumLossonClaim.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumCashOvertage_Shortagefromsales.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercMiscellenousandOther.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumMiscellenousandOther.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString
                LbPercStoreTradingProfit__Loss.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumStoreTradingProfit__Loss.Text) / Convert.ToDecimal(LbSumTotalRevenue.Text)) * 100).ToString

                LbFullPos.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbSumTotalRevenue.Text) / Convert.ToDecimal(LbFullTss.Text)) / Convert.ToDecimal(x_divide)).ToString
        End If

		If LbBKKSumTotalRevenue.Text <> 0 Then
								LbBKKPercTotalRevenue.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumTotalRevenue.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercRETAIL_TESPIncome.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumRETAIL_TESPIncome.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherRevenue.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherRevenue.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercCostofGoodSold.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumCostofGoodSold.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercGrossProfit.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumGrossProfit.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
				LbBKKPercMarginAdjustments.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumMarginAdjustments.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercShipping.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumShipping.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercStockLossandObsolescence.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumStockLossandObsolescence.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercInventoryAdjustment_stock.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumInventoryAdjustment_stock.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercInventoryAdjustment_damage.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumInventoryAdjustment_damage.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercStockLoss_Provision.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumStockLoss_Provision.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercStockObsolescence_Provision.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumStockObsolescence_Provision.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercGWP.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumGWP.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercGWPs_Corporate.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumGWPs_Corporate.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercGWPs_Transferred.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumGWPs_Transferred.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercSellingCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumSellingCosts.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercCreditcardscommission.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumCreditcardscommission.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercLabellingMaterial.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumLabellingMaterial.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherIncome_COSHFunding.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherIncome_COSHFunding.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherIncomeSupplier.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherIncomeSupplier.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercAdjustedGrossMargin.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumAdjustedGrossMargin.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercSupplyChainCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumSupplyChainCosts.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercTotalStoreExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumTotalStoreExpenses.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercStoreLabourCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumStoreLabourCosts.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercGrossPay.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumGrossPay.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercTemporaryStaffCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumTemporaryStaffCosts.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercAllowance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumAllowance.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOvertime.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOvertime.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercLicensefee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumLicensefee.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercBonuses_Incentives.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumBonuses_Incentives.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercBootsBrandncentives.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumBootsBrandncentives.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercSuppliersIncentive.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumSuppliersIncentive.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercProvidentFund.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumProvidentFund.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPensionCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPensionCosts.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercSocialSecurityFund.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumSocialSecurityFund.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercUniforms.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumUniforms.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercEmployeeWelfare.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumEmployeeWelfare.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherBenefitsEmployee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherBenefitsEmployee.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercStorePropertyCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumStorePropertyCosts.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPropertyRental.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPropertyRental.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPropertyServices.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPropertyServices.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPropertyFacility.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPropertyFacility.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPropertytaxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPropertytaxes.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercFacialtaxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumFacialtaxes.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPropertyInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPropertyInsurance.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercSignboard.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumSignboard.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumDiscount_Rent_Services_Facility.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercGPCommission.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumGPCommission.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercAmortizationofLeaseRight.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumAmortizationofLeaseRight.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercDepreciation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumDepreciation.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumDepreciationofShortLeaseBuilding.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercDepreciationofComputerHardware.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumDepreciationofComputerHardware.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercDepreciationofFixturesFittings.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumDepreciationofFixturesFittings.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercDepreciationofComputerSoftware.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumDepreciationofComputerSoftware.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumDepreciationofOfficeEquipment.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherStoreCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherStoreCosts.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercServiceChargesandOtherFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumServiceChargesandOtherFees.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercBankCharges.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumBankCharges.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercCashCollectionCharge.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumCashCollectionCharge.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercCleaning.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumCleaning.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercSecurityGuards.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumSecurityGuards.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercCarriage.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumCarriage.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercLicenceFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumLicenceFees.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherServicesCharge.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherServicesCharge.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherFees.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercUtilities.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumUtilities.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercWater.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumWater.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercGas_Electric.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumGas_Electric.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercAirCond_Addition.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumAirCond_Addition.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercRepairandMaintenance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumRepairandMaintenance.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercRMOther_Fix.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumRMOther_Fix.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercRMOther_Unplan.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumRMOther_Unplan.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercRMComputer_Fix.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumRMComputer_Fix.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercRMComputer_Unplan.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumRMComputer_Unplan.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercProfessionalFee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumProfessionalFee.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercMarketingResearch.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumMarketingResearch.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherFee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherFee.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumEquipment_MaterailandSupplies.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPrintingandStationery.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPrintingandStationery.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercSuppliesExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumSuppliesExpenses.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercEquipment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumEquipment.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercShopfitting.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumShopfitting.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPackagingandOtherMaterial.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPackagingandOtherMaterial.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercBusinessTravelExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumBusinessTravelExpenses.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercCarParkingandOthers.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumCarParkingandOthers.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercTravel.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumTravel.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercAccomodation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumAccomodation.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercMealandEntertainment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumMealandEntertainment.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumInsurance.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercAllRiskInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumAllRiskInsurance.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercHealthandLifeInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumHealthandLifeInsurance.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPenaltyandTaxation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPenaltyandTaxation.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercTaxation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumTaxation.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPenalty.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPenalty.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherRelatedStaffCost.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherRelatedStaffCost.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercStaffConferenceandTraining.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumStaffConferenceandTraining.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercTraining.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumTraining.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercCommunication.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumCommunication.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercTelephoneCalls_Faxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumTelephoneCalls_Faxes.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPostageandCourier.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPostageandCourier.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercOtherExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumOtherExpenses.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercSample_Tester.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumSample_Tester.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercPreopeningCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumPreopeningCosts.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercLossonClaim.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumLossonClaim.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumCashOvertage_Shortagefromsales.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercMiscellenousandOther.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumMiscellenousandOther.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
                LbBKKPercStoreTradingProfit__Loss.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumStoreTradingProfit__Loss.Text) / Convert.ToDecimal(LbBKKSumTotalRevenue.Text)) * 100).ToString
 
            LbBKKFullPos.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbBKKSumTotalRevenue.Text) / Convert.ToDecimal(LbBKKFullTss.Text)) / Convert.ToDecimal(x_divide)).ToString

		End If

		If LbUPSumTotalRevenue.Text <> 0 Then
								LbUPPercTotalRevenue.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumTotalRevenue.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercRETAIL_TESPIncome.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumRETAIL_TESPIncome.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherRevenue.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherRevenue.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercCostofGoodSold.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumCostofGoodSold.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercGrossProfit.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumGrossProfit.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
				LbUPPercMarginAdjustments.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumMarginAdjustments.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercShipping.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumShipping.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercStockLossandObsolescence.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumStockLossandObsolescence.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercInventoryAdjustment_stock.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumInventoryAdjustment_stock.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercInventoryAdjustment_damage.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumInventoryAdjustment_damage.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercStockLoss_Provision.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumStockLoss_Provision.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercStockObsolescence_Provision.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumStockObsolescence_Provision.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercGWP.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumGWP.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercGWPs_Corporate.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumGWPs_Corporate.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercGWPs_Transferred.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumGWPs_Transferred.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercSellingCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumSellingCosts.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercCreditcardscommission.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumCreditcardscommission.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercLabellingMaterial.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumLabellingMaterial.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherIncome_COSHFunding.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherIncome_COSHFunding.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherIncomeSupplier.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherIncomeSupplier.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercAdjustedGrossMargin.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumAdjustedGrossMargin.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercSupplyChainCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumSupplyChainCosts.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercTotalStoreExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumTotalStoreExpenses.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercStoreLabourCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumStoreLabourCosts.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercGrossPay.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumGrossPay.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercTemporaryStaffCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumTemporaryStaffCosts.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercAllowance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumAllowance.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOvertime.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOvertime.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercLicensefee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumLicensefee.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercBonuses_Incentives.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumBonuses_Incentives.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercBootsBrandncentives.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumBootsBrandncentives.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercSuppliersIncentive.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumSuppliersIncentive.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercProvidentFund.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumProvidentFund.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPensionCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPensionCosts.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercSocialSecurityFund.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumSocialSecurityFund.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercUniforms.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumUniforms.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercEmployeeWelfare.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumEmployeeWelfare.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherBenefitsEmployee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherBenefitsEmployee.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercStorePropertyCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumStorePropertyCosts.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPropertyRental.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPropertyRental.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPropertyServices.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPropertyServices.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPropertyFacility.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPropertyFacility.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPropertytaxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPropertytaxes.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercFacialtaxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumFacialtaxes.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPropertyInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPropertyInsurance.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercSignboard.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumSignboard.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumDiscount_Rent_Services_Facility.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercGPCommission.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumGPCommission.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercAmortizationofLeaseRight.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumAmortizationofLeaseRight.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercDepreciation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumDepreciation.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumDepreciationofShortLeaseBuilding.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercDepreciationofComputerHardware.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumDepreciationofComputerHardware.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercDepreciationofFixturesFittings.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumDepreciationofFixturesFittings.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercDepreciationofComputerSoftware.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumDepreciationofComputerSoftware.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumDepreciationofOfficeEquipment.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherStoreCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherStoreCosts.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercServiceChargesandOtherFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumServiceChargesandOtherFees.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercBankCharges.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumBankCharges.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercCashCollectionCharge.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumCashCollectionCharge.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercCleaning.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumCleaning.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercSecurityGuards.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumSecurityGuards.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercCarriage.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumCarriage.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercLicenceFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumLicenceFees.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherServicesCharge.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherServicesCharge.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherFees.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherFees.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercUtilities.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumUtilities.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercWater.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumWater.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercGas_Electric.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumGas_Electric.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercAirCond_Addition.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumAirCond_Addition.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercRepairandMaintenance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumRepairandMaintenance.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercRMOther_Fix.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumRMOther_Fix.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercRMOther_Unplan.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumRMOther_Unplan.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercRMComputer_Fix.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumRMComputer_Fix.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercRMComputer_Unplan.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumRMComputer_Unplan.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercProfessionalFee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumProfessionalFee.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercMarketingResearch.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumMarketingResearch.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherFee.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherFee.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumEquipment_MaterailandSupplies.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPrintingandStationery.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPrintingandStationery.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercSuppliesExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumSuppliesExpenses.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercEquipment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumEquipment.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercShopfitting.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumShopfitting.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPackagingandOtherMaterial.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPackagingandOtherMaterial.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercBusinessTravelExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumBusinessTravelExpenses.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercCarParkingandOthers.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumCarParkingandOthers.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercTravel.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumTravel.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercAccomodation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumAccomodation.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercMealandEntertainment.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumMealandEntertainment.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumInsurance.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercAllRiskInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumAllRiskInsurance.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercHealthandLifeInsurance.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumHealthandLifeInsurance.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPenaltyandTaxation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPenaltyandTaxation.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercTaxation.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumTaxation.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPenalty.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPenalty.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherRelatedStaffCost.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherRelatedStaffCost.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercStaffConferenceandTraining.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumStaffConferenceandTraining.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercTraining.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumTraining.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercCommunication.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumCommunication.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercTelephoneCalls_Faxes.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumTelephoneCalls_Faxes.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPostageandCourier.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPostageandCourier.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercOtherExpenses.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumOtherExpenses.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercSample_Tester.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumSample_Tester.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercPreopeningCosts.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumPreopeningCosts.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercLossonClaim.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumLossonClaim.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumCashOvertage_Shortagefromsales.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercMiscellenousandOther.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumMiscellenousandOther.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
                LbUPPercStoreTradingProfit__Loss.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumStoreTradingProfit__Loss.Text) / Convert.ToDecimal(LbUPSumTotalRevenue.Text)) * 100).ToString
 
            LbUPFullPos.Text = ClsManage.convert2Currency((Convert.ToDecimal(LbUPSumTotalRevenue.Text) / Convert.ToDecimal(LbUPFullTss.Text)) / Convert.ToDecimal(x_divide)).ToString
            End If

        'ClsManage.Script(Page, "document.getElementById('" + hdfExcel.ClientID + "').value =  document.getElementById('" + temp_body.ClientID + "').innerHTML; ")
		ClsManage.Script(Page, "settb('b');settb('e');settb('f');settb('g');settb('h');settb('s');settb('aa');")

				 LbFullTgs.Text = ClsManage.convert2Currency3(LbFullTgs.Text)
        LbFullTss.Text = ClsManage.convert2Currency3(LbFullTss.Text)
        LbFullPos.Text = ClsManage.convert2Currency3(LbFullPos.Text)
        LbSumTotalRevenue.Text = ClsManage.convert2Currency3(LbSumTotalRevenue.Text)
        LbSumRETAIL_TESPIncome.Text = ClsManage.convert2Currency3(LbSumRETAIL_TESPIncome.Text)
        LbSumOtherRevenue.Text = ClsManage.convert2Currency3(LbSumOtherRevenue.Text)
        LbSumCostofGoodSold.Text = ClsManage.convert2Currency3(LbSumCostofGoodSold.Text)
        LbSumGrossProfit.Text = ClsManage.convert2Currency3(LbSumGrossProfit.Text)
        'LbSumGrossProfit_percent.Text = ClsManage.convert2Currency3('LbSumGrossProfit_percent.Text)
        LbSumMarginAdjustments.Text = ClsManage.convert2Currency3(LbSumMarginAdjustments.Text)
        LbSumShipping.Text = ClsManage.convert2Currency3(LbSumShipping.Text)
        LbSumStockLossandObsolescence.Text = ClsManage.convert2Currency3(LbSumStockLossandObsolescence.Text)
        LbSumInventoryAdjustment_stock.Text = ClsManage.convert2Currency3(LbSumInventoryAdjustment_stock.Text)
        LbSumInventoryAdjustment_damage.Text = ClsManage.convert2Currency3(LbSumInventoryAdjustment_damage.Text)
        LbSumStockLoss_Provision.Text = ClsManage.convert2Currency3(LbSumStockLoss_Provision.Text)
        LbSumStockObsolescence_Provision.Text = ClsManage.convert2Currency3(LbSumStockObsolescence_Provision.Text)
        LbSumGWP.Text = ClsManage.convert2Currency3(LbSumGWP.Text)
        LbSumGWPs_Corporate.Text = ClsManage.convert2Currency3(LbSumGWPs_Corporate.Text)
        LbSumGWPs_Transferred.Text = ClsManage.convert2Currency3(LbSumGWPs_Transferred.Text)
        LbSumSellingCosts.Text = ClsManage.convert2Currency3(LbSumSellingCosts.Text)
        LbSumCreditcardscommission.Text = ClsManage.convert2Currency3(LbSumCreditcardscommission.Text)
        LbSumLabellingMaterial.Text = ClsManage.convert2Currency3(LbSumLabellingMaterial.Text)
        LbSumOtherIncome_COSHFunding.Text = ClsManage.convert2Currency3(LbSumOtherIncome_COSHFunding.Text)
        LbSumOtherIncomeSupplier.Text = ClsManage.convert2Currency3(LbSumOtherIncomeSupplier.Text)
        LbSumAdjustedGrossMargin.Text = ClsManage.convert2Currency3(LbSumAdjustedGrossMargin.Text)
        LbSumSupplyChainCosts.Text = ClsManage.convert2Currency3(LbSumSupplyChainCosts.Text)
        LbSumTotalStoreExpenses.Text = ClsManage.convert2Currency3(LbSumTotalStoreExpenses.Text)
        LbSumStoreLabourCosts.Text = ClsManage.convert2Currency3(LbSumStoreLabourCosts.Text)
        LbSumGrossPay.Text = ClsManage.convert2Currency3(LbSumGrossPay.Text)
        LbSumTemporaryStaffCosts.Text = ClsManage.convert2Currency3(LbSumTemporaryStaffCosts.Text)
        LbSumAllowance.Text = ClsManage.convert2Currency3(LbSumAllowance.Text)
        LbSumOvertime.Text = ClsManage.convert2Currency3(LbSumOvertime.Text)
        LbSumLicensefee.Text = ClsManage.convert2Currency3(LbSumLicensefee.Text)
        LbSumBonuses_Incentives.Text = ClsManage.convert2Currency3(LbSumBonuses_Incentives.Text)
        LbSumBootsBrandncentives.Text = ClsManage.convert2Currency3(LbSumBootsBrandncentives.Text)
        LbSumSuppliersIncentive.Text = ClsManage.convert2Currency3(LbSumSuppliersIncentive.Text)
        LbSumProvidentFund.Text = ClsManage.convert2Currency3(LbSumProvidentFund.Text)
        LbSumPensionCosts.Text = ClsManage.convert2Currency3(LbSumPensionCosts.Text)
        LbSumSocialSecurityFund.Text = ClsManage.convert2Currency3(LbSumSocialSecurityFund.Text)
        LbSumUniforms.Text = ClsManage.convert2Currency3(LbSumUniforms.Text)
        LbSumEmployeeWelfare.Text = ClsManage.convert2Currency3(LbSumEmployeeWelfare.Text)
        LbSumOtherBenefitsEmployee.Text = ClsManage.convert2Currency3(LbSumOtherBenefitsEmployee.Text)
        LbSumStorePropertyCosts.Text = ClsManage.convert2Currency3(LbSumStorePropertyCosts.Text)
        LbSumPropertyRental.Text = ClsManage.convert2Currency3(LbSumPropertyRental.Text)
        LbSumPropertyServices.Text = ClsManage.convert2Currency3(LbSumPropertyServices.Text)
        LbSumPropertyFacility.Text = ClsManage.convert2Currency3(LbSumPropertyFacility.Text)
        LbSumPropertytaxes.Text = ClsManage.convert2Currency3(LbSumPropertytaxes.Text)
        LbSumFacialtaxes.Text = ClsManage.convert2Currency3(LbSumFacialtaxes.Text)
        LbSumPropertyInsurance.Text = ClsManage.convert2Currency3(LbSumPropertyInsurance.Text)
        LbSumSignboard.Text = ClsManage.convert2Currency3(LbSumSignboard.Text)
        LbSumDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency3(LbSumDiscount_Rent_Services_Facility.Text)
        LbSumGPCommission.Text = ClsManage.convert2Currency3(LbSumGPCommission.Text)
        LbSumAmortizationofLeaseRight.Text = ClsManage.convert2Currency3(LbSumAmortizationofLeaseRight.Text)
        LbSumDepreciation.Text = ClsManage.convert2Currency3(LbSumDepreciation.Text)
        LbSumDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency3(LbSumDepreciationofShortLeaseBuilding.Text)
        LbSumDepreciationofComputerHardware.Text = ClsManage.convert2Currency3(LbSumDepreciationofComputerHardware.Text)
        LbSumDepreciationofFixturesFittings.Text = ClsManage.convert2Currency3(LbSumDepreciationofFixturesFittings.Text)
        LbSumDepreciationofComputerSoftware.Text = ClsManage.convert2Currency3(LbSumDepreciationofComputerSoftware.Text)
        LbSumDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency3(LbSumDepreciationofOfficeEquipment.Text)
        LbSumOtherStoreCosts.Text = ClsManage.convert2Currency3(LbSumOtherStoreCosts.Text)
        LbSumServiceChargesandOtherFees.Text = ClsManage.convert2Currency3(LbSumServiceChargesandOtherFees.Text)
        LbSumBankCharges.Text = ClsManage.convert2Currency3(LbSumBankCharges.Text)
        LbSumCashCollectionCharge.Text = ClsManage.convert2Currency3(LbSumCashCollectionCharge.Text)
        LbSumCleaning.Text = ClsManage.convert2Currency3(LbSumCleaning.Text)
        LbSumSecurityGuards.Text = ClsManage.convert2Currency3(LbSumSecurityGuards.Text)
        LbSumCarriage.Text = ClsManage.convert2Currency3(LbSumCarriage.Text)
        LbSumLicenceFees.Text = ClsManage.convert2Currency3(LbSumLicenceFees.Text)
        LbSumOtherServicesCharge.Text = ClsManage.convert2Currency3(LbSumOtherServicesCharge.Text)
        LbSumOtherFees.Text = ClsManage.convert2Currency3(LbSumOtherFees.Text)
        LbSumUtilities.Text = ClsManage.convert2Currency3(LbSumUtilities.Text)
        LbSumWater.Text = ClsManage.convert2Currency3(LbSumWater.Text)
        LbSumGas_Electric.Text = ClsManage.convert2Currency3(LbSumGas_Electric.Text)
        LbSumAirCond_Addition.Text = ClsManage.convert2Currency3(LbSumAirCond_Addition.Text)
        LbSumRepairandMaintenance.Text = ClsManage.convert2Currency3(LbSumRepairandMaintenance.Text)
        LbSumRMOther_Fix.Text = ClsManage.convert2Currency3(LbSumRMOther_Fix.Text)
        LbSumRMOther_Unplan.Text = ClsManage.convert2Currency3(LbSumRMOther_Unplan.Text)
        LbSumRMComputer_Fix.Text = ClsManage.convert2Currency3(LbSumRMComputer_Fix.Text)
        LbSumRMComputer_Unplan.Text = ClsManage.convert2Currency3(LbSumRMComputer_Unplan.Text)
        LbSumProfessionalFee.Text = ClsManage.convert2Currency3(LbSumProfessionalFee.Text)
        LbSumMarketingResearch.Text = ClsManage.convert2Currency3(LbSumMarketingResearch.Text)
        LbSumOtherFee.Text = ClsManage.convert2Currency3(LbSumOtherFee.Text)
        LbSumEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency3(LbSumEquipment_MaterailandSupplies.Text)
        LbSumPrintingandStationery.Text = ClsManage.convert2Currency3(LbSumPrintingandStationery.Text)
        LbSumSuppliesExpenses.Text = ClsManage.convert2Currency3(LbSumSuppliesExpenses.Text)
        LbSumEquipment.Text = ClsManage.convert2Currency3(LbSumEquipment.Text)
        LbSumShopfitting.Text = ClsManage.convert2Currency3(LbSumShopfitting.Text)
        LbSumPackagingandOtherMaterial.Text = ClsManage.convert2Currency3(LbSumPackagingandOtherMaterial.Text)
        LbSumBusinessTravelExpenses.Text = ClsManage.convert2Currency3(LbSumBusinessTravelExpenses.Text)
        LbSumCarParkingandOthers.Text = ClsManage.convert2Currency3(LbSumCarParkingandOthers.Text)
        LbSumTravel.Text = ClsManage.convert2Currency3(LbSumTravel.Text)
        LbSumAccomodation.Text = ClsManage.convert2Currency3(LbSumAccomodation.Text)
        LbSumMealandEntertainment.Text = ClsManage.convert2Currency3(LbSumMealandEntertainment.Text)
        LbSumInsurance.Text = ClsManage.convert2Currency3(LbSumInsurance.Text)
        LbSumAllRiskInsurance.Text = ClsManage.convert2Currency3(LbSumAllRiskInsurance.Text)
        LbSumHealthandLifeInsurance.Text = ClsManage.convert2Currency3(LbSumHealthandLifeInsurance.Text)
        LbSumPenaltyandTaxation.Text = ClsManage.convert2Currency3(LbSumPenaltyandTaxation.Text)
        LbSumTaxation.Text = ClsManage.convert2Currency3(LbSumTaxation.Text)
        LbSumPenalty.Text = ClsManage.convert2Currency3(LbSumPenalty.Text)
        LbSumOtherRelatedStaffCost.Text = ClsManage.convert2Currency3(LbSumOtherRelatedStaffCost.Text)
        LbSumStaffConferenceandTraining.Text = ClsManage.convert2Currency3(LbSumStaffConferenceandTraining.Text)
        LbSumTraining.Text = ClsManage.convert2Currency3(LbSumTraining.Text)
        LbSumCommunication.Text = ClsManage.convert2Currency3(LbSumCommunication.Text)
        LbSumTelephoneCalls_Faxes.Text = ClsManage.convert2Currency3(LbSumTelephoneCalls_Faxes.Text)
        LbSumPostageandCourier.Text = ClsManage.convert2Currency3(LbSumPostageandCourier.Text)
        LbSumOtherExpenses.Text = ClsManage.convert2Currency3(LbSumOtherExpenses.Text)
        LbSumSample_Tester.Text = ClsManage.convert2Currency3(LbSumSample_Tester.Text)
        LbSumPreopeningCosts.Text = ClsManage.convert2Currency3(LbSumPreopeningCosts.Text)
        LbSumLossonClaim.Text = ClsManage.convert2Currency3(LbSumLossonClaim.Text)
        LbSumCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency3(LbSumCashOvertage_Shortagefromsales.Text)
        LbSumMiscellenousandOther.Text = ClsManage.convert2Currency3(LbSumMiscellenousandOther.Text)
        LbSumStoreTradingProfit__Loss.Text = ClsManage.convert2Currency3(LbSumStoreTradingProfit__Loss.Text)
        'LbSumTradingProfit__Loss.Text = ClsManage.convert2Currency3('LbSumTradingProfit__Loss.Text)

        LbPercTotalRevenue.Text = ClsManage.convert2Currency4(LbPercTotalRevenue.Text)
        LbPercRETAIL_TESPIncome.Text = ClsManage.convert2Currency4(LbPercRETAIL_TESPIncome.Text)
        LbPercOtherRevenue.Text = ClsManage.convert2Currency4(LbPercOtherRevenue.Text)
        LbPercCostofGoodSold.Text = ClsManage.convert2Currency4(LbPercCostofGoodSold.Text)
        LbPercGrossProfit.Text = ClsManage.convert2Currency4(LbPercGrossProfit.Text)
        LbPercMarginAdjustments.Text = ClsManage.convert2Currency4(LbPercMarginAdjustments.Text)
        LbPercShipping.Text = ClsManage.convert2Currency4(LbPercShipping.Text)
        LbPercStockLossandObsolescence.Text = ClsManage.convert2Currency4(LbPercStockLossandObsolescence.Text)
        LbPercInventoryAdjustment_stock.Text = ClsManage.convert2Currency4(LbPercInventoryAdjustment_stock.Text)
        LbPercInventoryAdjustment_damage.Text = ClsManage.convert2Currency4(LbPercInventoryAdjustment_damage.Text)
        LbPercStockLoss_Provision.Text = ClsManage.convert2Currency4(LbPercStockLoss_Provision.Text)
        LbPercStockObsolescence_Provision.Text = ClsManage.convert2Currency4(LbPercStockObsolescence_Provision.Text)
        LbPercGWP.Text = ClsManage.convert2Currency4(LbPercGWP.Text)
        LbPercGWPs_Corporate.Text = ClsManage.convert2Currency4(LbPercGWPs_Corporate.Text)
        LbPercGWPs_Transferred.Text = ClsManage.convert2Currency4(LbPercGWPs_Transferred.Text)
        LbPercSellingCosts.Text = ClsManage.convert2Currency4(LbPercSellingCosts.Text)
        LbPercCreditcardscommission.Text = ClsManage.convert2Currency4(LbPercCreditcardscommission.Text)
        LbPercLabellingMaterial.Text = ClsManage.convert2Currency4(LbPercLabellingMaterial.Text)
        LbPercOtherIncome_COSHFunding.Text = ClsManage.convert2Currency4(LbPercOtherIncome_COSHFunding.Text)
        LbPercOtherIncomeSupplier.Text = ClsManage.convert2Currency4(LbPercOtherIncomeSupplier.Text)
        LbPercAdjustedGrossMargin.Text = ClsManage.convert2Currency4(LbPercAdjustedGrossMargin.Text)
        LbPercSupplyChainCosts.Text = ClsManage.convert2Currency4(LbPercSupplyChainCosts.Text)
        LbPercTotalStoreExpenses.Text = ClsManage.convert2Currency4(LbPercTotalStoreExpenses.Text)
        LbPercStoreLabourCosts.Text = ClsManage.convert2Currency4(LbPercStoreLabourCosts.Text)
        LbPercGrossPay.Text = ClsManage.convert2Currency4(LbPercGrossPay.Text)
        LbPercTemporaryStaffCosts.Text = ClsManage.convert2Currency4(LbPercTemporaryStaffCosts.Text)
        LbPercAllowance.Text = ClsManage.convert2Currency4(LbPercAllowance.Text)
        LbPercOvertime.Text = ClsManage.convert2Currency4(LbPercOvertime.Text)
        LbPercLicensefee.Text = ClsManage.convert2Currency4(LbPercLicensefee.Text)
        LbPercBonuses_Incentives.Text = ClsManage.convert2Currency4(LbPercBonuses_Incentives.Text)
        LbPercBootsBrandncentives.Text = ClsManage.convert2Currency4(LbPercBootsBrandncentives.Text)
        LbPercSuppliersIncentive.Text = ClsManage.convert2Currency4(LbPercSuppliersIncentive.Text)
        LbPercProvidentFund.Text = ClsManage.convert2Currency4(LbPercProvidentFund.Text)
        LbPercPensionCosts.Text = ClsManage.convert2Currency4(LbPercPensionCosts.Text)
        LbPercSocialSecurityFund.Text = ClsManage.convert2Currency4(LbPercSocialSecurityFund.Text)
        LbPercUniforms.Text = ClsManage.convert2Currency4(LbPercUniforms.Text)
        LbPercEmployeeWelfare.Text = ClsManage.convert2Currency4(LbPercEmployeeWelfare.Text)
        LbPercOtherBenefitsEmployee.Text = ClsManage.convert2Currency4(LbPercOtherBenefitsEmployee.Text)
        LbPercStorePropertyCosts.Text = ClsManage.convert2Currency4(LbPercStorePropertyCosts.Text)
        LbPercPropertyRental.Text = ClsManage.convert2Currency4(LbPercPropertyRental.Text)
        LbPercPropertyServices.Text = ClsManage.convert2Currency4(LbPercPropertyServices.Text)
        LbPercPropertyFacility.Text = ClsManage.convert2Currency4(LbPercPropertyFacility.Text)
        LbPercPropertytaxes.Text = ClsManage.convert2Currency4(LbPercPropertytaxes.Text)
        LbPercFacialtaxes.Text = ClsManage.convert2Currency4(LbPercFacialtaxes.Text)
        LbPercPropertyInsurance.Text = ClsManage.convert2Currency4(LbPercPropertyInsurance.Text)
        LbPercSignboard.Text = ClsManage.convert2Currency4(LbPercSignboard.Text)
        LbPercDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency4(LbPercDiscount_Rent_Services_Facility.Text)
        LbPercGPCommission.Text = ClsManage.convert2Currency4(LbPercGPCommission.Text)
        LbPercAmortizationofLeaseRight.Text = ClsManage.convert2Currency4(LbPercAmortizationofLeaseRight.Text)
        LbPercDepreciation.Text = ClsManage.convert2Currency4(LbPercDepreciation.Text)
        LbPercDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency4(LbPercDepreciationofShortLeaseBuilding.Text)
        LbPercDepreciationofComputerHardware.Text = ClsManage.convert2Currency4(LbPercDepreciationofComputerHardware.Text)
        LbPercDepreciationofFixturesFittings.Text = ClsManage.convert2Currency4(LbPercDepreciationofFixturesFittings.Text)
        LbPercDepreciationofComputerSoftware.Text = ClsManage.convert2Currency4(LbPercDepreciationofComputerSoftware.Text)
        LbPercDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency4(LbPercDepreciationofOfficeEquipment.Text)
        LbPercOtherStoreCosts.Text = ClsManage.convert2Currency4(LbPercOtherStoreCosts.Text)
        LbPercServiceChargesandOtherFees.Text = ClsManage.convert2Currency4(LbPercServiceChargesandOtherFees.Text)
        LbPercBankCharges.Text = ClsManage.convert2Currency4(LbPercBankCharges.Text)
        LbPercCashCollectionCharge.Text = ClsManage.convert2Currency4(LbPercCashCollectionCharge.Text)
        LbPercCleaning.Text = ClsManage.convert2Currency4(LbPercCleaning.Text)
        LbPercSecurityGuards.Text = ClsManage.convert2Currency4(LbPercSecurityGuards.Text)
        LbPercCarriage.Text = ClsManage.convert2Currency4(LbPercCarriage.Text)
        LbPercLicenceFees.Text = ClsManage.convert2Currency4(LbPercLicenceFees.Text)
        LbPercOtherServicesCharge.Text = ClsManage.convert2Currency4(LbPercOtherServicesCharge.Text)
        LbPercOtherFees.Text = ClsManage.convert2Currency4(LbPercOtherFees.Text)
        LbPercUtilities.Text = ClsManage.convert2Currency4(LbPercUtilities.Text)
        LbPercWater.Text = ClsManage.convert2Currency4(LbPercWater.Text)
        LbPercGas_Electric.Text = ClsManage.convert2Currency4(LbPercGas_Electric.Text)
        LbPercAirCond_Addition.Text = ClsManage.convert2Currency4(LbPercAirCond_Addition.Text)
        LbPercRepairandMaintenance.Text = ClsManage.convert2Currency4(LbPercRepairandMaintenance.Text)
        LbPercRMOther_Fix.Text = ClsManage.convert2Currency4(LbPercRMOther_Fix.Text)
        LbPercRMOther_Unplan.Text = ClsManage.convert2Currency4(LbPercRMOther_Unplan.Text)
        LbPercRMComputer_Fix.Text = ClsManage.convert2Currency4(LbPercRMComputer_Fix.Text)
        LbPercRMComputer_Unplan.Text = ClsManage.convert2Currency4(LbPercRMComputer_Unplan.Text)
        LbPercProfessionalFee.Text = ClsManage.convert2Currency4(LbPercProfessionalFee.Text)
        LbPercMarketingResearch.Text = ClsManage.convert2Currency4(LbPercMarketingResearch.Text)
        LbPercOtherFee.Text = ClsManage.convert2Currency4(LbPercOtherFee.Text)
        LbPercEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency4(LbPercEquipment_MaterailandSupplies.Text)
        LbPercPrintingandStationery.Text = ClsManage.convert2Currency4(LbPercPrintingandStationery.Text)
        LbPercSuppliesExpenses.Text = ClsManage.convert2Currency4(LbPercSuppliesExpenses.Text)
        LbPercEquipment.Text = ClsManage.convert2Currency4(LbPercEquipment.Text)
        LbPercShopfitting.Text = ClsManage.convert2Currency4(LbPercShopfitting.Text)
        LbPercPackagingandOtherMaterial.Text = ClsManage.convert2Currency4(LbPercPackagingandOtherMaterial.Text)
        LbPercBusinessTravelExpenses.Text = ClsManage.convert2Currency4(LbPercBusinessTravelExpenses.Text)
        LbPercCarParkingandOthers.Text = ClsManage.convert2Currency4(LbPercCarParkingandOthers.Text)
        LbPercTravel.Text = ClsManage.convert2Currency4(LbPercTravel.Text)
        LbPercAccomodation.Text = ClsManage.convert2Currency4(LbPercAccomodation.Text)
        LbPercMealandEntertainment.Text = ClsManage.convert2Currency4(LbPercMealandEntertainment.Text)
        LbPercInsurance.Text = ClsManage.convert2Currency4(LbPercInsurance.Text)
        LbPercAllRiskInsurance.Text = ClsManage.convert2Currency4(LbPercAllRiskInsurance.Text)
        LbPercHealthandLifeInsurance.Text = ClsManage.convert2Currency4(LbPercHealthandLifeInsurance.Text)
        LbPercPenaltyandTaxation.Text = ClsManage.convert2Currency4(LbPercPenaltyandTaxation.Text)
        LbPercTaxation.Text = ClsManage.convert2Currency4(LbPercTaxation.Text)
        LbPercPenalty.Text = ClsManage.convert2Currency4(LbPercPenalty.Text)
        LbPercOtherRelatedStaffCost.Text = ClsManage.convert2Currency4(LbPercOtherRelatedStaffCost.Text)
        LbPercStaffConferenceandTraining.Text = ClsManage.convert2Currency4(LbPercStaffConferenceandTraining.Text)
        LbPercTraining.Text = ClsManage.convert2Currency4(LbPercTraining.Text)
        LbPercCommunication.Text = ClsManage.convert2Currency4(LbPercCommunication.Text)
        LbPercTelephoneCalls_Faxes.Text = ClsManage.convert2Currency4(LbPercTelephoneCalls_Faxes.Text)
        LbPercPostageandCourier.Text = ClsManage.convert2Currency4(LbPercPostageandCourier.Text)
        LbPercOtherExpenses.Text = ClsManage.convert2Currency4(LbPercOtherExpenses.Text)
        LbPercSample_Tester.Text = ClsManage.convert2Currency4(LbPercSample_Tester.Text)
        LbPercPreopeningCosts.Text = ClsManage.convert2Currency4(LbPercPreopeningCosts.Text)
        LbPercLossonClaim.Text = ClsManage.convert2Currency4(LbPercLossonClaim.Text)
        LbPercCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency4(LbPercCashOvertage_Shortagefromsales.Text)
        LbPercMiscellenousandOther.Text = ClsManage.convert2Currency4(LbPercMiscellenousandOther.Text)
        LbPercStoreTradingProfit__Loss.Text = ClsManage.convert2Currency4(LbPercStoreTradingProfit__Loss.Text)

		 LbBKKFullTgs.Text = ClsManage.convert2Currency3(LbBKKFullTgs.Text)
        LbBKKFullTss.Text = ClsManage.convert2Currency3(LbBKKFullTss.Text)
        LbBKKFullPos.Text = ClsManage.convert2Currency3(LbBKKFullPos.Text)
        LbBKKSumTotalRevenue.Text = ClsManage.convert2Currency3(LbBKKSumTotalRevenue.Text)
        LbBKKSumRETAIL_TESPIncome.Text = ClsManage.convert2Currency3(LbBKKSumRETAIL_TESPIncome.Text)
        LbBKKSumOtherRevenue.Text = ClsManage.convert2Currency3(LbBKKSumOtherRevenue.Text)
        LbBKKSumCostofGoodSold.Text = ClsManage.convert2Currency3(LbBKKSumCostofGoodSold.Text)
        LbBKKSumGrossProfit.Text = ClsManage.convert2Currency3(LbBKKSumGrossProfit.Text)
        'LbBKKSumGrossProfit_percent.Text = ClsManage.convert2Currency3('LbBKKSumGrossProfit_percent.Text)
        LbBKKSumMarginAdjustments.Text = ClsManage.convert2Currency3(LbBKKSumMarginAdjustments.Text)
        LbBKKSumShipping.Text = ClsManage.convert2Currency3(LbBKKSumShipping.Text)
        LbBKKSumStockLossandObsolescence.Text = ClsManage.convert2Currency3(LbBKKSumStockLossandObsolescence.Text)
        LbBKKSumInventoryAdjustment_stock.Text = ClsManage.convert2Currency3(LbBKKSumInventoryAdjustment_stock.Text)
        LbBKKSumInventoryAdjustment_damage.Text = ClsManage.convert2Currency3(LbBKKSumInventoryAdjustment_damage.Text)
        LbBKKSumStockLoss_Provision.Text = ClsManage.convert2Currency3(LbBKKSumStockLoss_Provision.Text)
        LbBKKSumStockObsolescence_Provision.Text = ClsManage.convert2Currency3(LbBKKSumStockObsolescence_Provision.Text)
        LbBKKSumGWP.Text = ClsManage.convert2Currency3(LbBKKSumGWP.Text)
        LbBKKSumGWPs_Corporate.Text = ClsManage.convert2Currency3(LbBKKSumGWPs_Corporate.Text)
        LbBKKSumGWPs_Transferred.Text = ClsManage.convert2Currency3(LbBKKSumGWPs_Transferred.Text)
        LbBKKSumSellingCosts.Text = ClsManage.convert2Currency3(LbBKKSumSellingCosts.Text)
        LbBKKSumCreditcardscommission.Text = ClsManage.convert2Currency3(LbBKKSumCreditcardscommission.Text)
        LbBKKSumLabellingMaterial.Text = ClsManage.convert2Currency3(LbBKKSumLabellingMaterial.Text)
        LbBKKSumOtherIncome_COSHFunding.Text = ClsManage.convert2Currency3(LbBKKSumOtherIncome_COSHFunding.Text)
        LbBKKSumOtherIncomeSupplier.Text = ClsManage.convert2Currency3(LbBKKSumOtherIncomeSupplier.Text)
        LbBKKSumAdjustedGrossMargin.Text = ClsManage.convert2Currency3(LbBKKSumAdjustedGrossMargin.Text)
        LbBKKSumSupplyChainCosts.Text = ClsManage.convert2Currency3(LbBKKSumSupplyChainCosts.Text)
        LbBKKSumTotalStoreExpenses.Text = ClsManage.convert2Currency3(LbBKKSumTotalStoreExpenses.Text)
        LbBKKSumStoreLabourCosts.Text = ClsManage.convert2Currency3(LbBKKSumStoreLabourCosts.Text)
        LbBKKSumGrossPay.Text = ClsManage.convert2Currency3(LbBKKSumGrossPay.Text)
        LbBKKSumTemporaryStaffCosts.Text = ClsManage.convert2Currency3(LbBKKSumTemporaryStaffCosts.Text)
        LbBKKSumAllowance.Text = ClsManage.convert2Currency3(LbBKKSumAllowance.Text)
        LbBKKSumOvertime.Text = ClsManage.convert2Currency3(LbBKKSumOvertime.Text)
        LbBKKSumLicensefee.Text = ClsManage.convert2Currency3(LbBKKSumLicensefee.Text)
        LbBKKSumBonuses_Incentives.Text = ClsManage.convert2Currency3(LbBKKSumBonuses_Incentives.Text)
        LbBKKSumBootsBrandncentives.Text = ClsManage.convert2Currency3(LbBKKSumBootsBrandncentives.Text)
        LbBKKSumSuppliersIncentive.Text = ClsManage.convert2Currency3(LbBKKSumSuppliersIncentive.Text)
        LbBKKSumProvidentFund.Text = ClsManage.convert2Currency3(LbBKKSumProvidentFund.Text)
        LbBKKSumPensionCosts.Text = ClsManage.convert2Currency3(LbBKKSumPensionCosts.Text)
        LbBKKSumSocialSecurityFund.Text = ClsManage.convert2Currency3(LbBKKSumSocialSecurityFund.Text)
        LbBKKSumUniforms.Text = ClsManage.convert2Currency3(LbBKKSumUniforms.Text)
        LbBKKSumEmployeeWelfare.Text = ClsManage.convert2Currency3(LbBKKSumEmployeeWelfare.Text)
        LbBKKSumOtherBenefitsEmployee.Text = ClsManage.convert2Currency3(LbBKKSumOtherBenefitsEmployee.Text)
        LbBKKSumStorePropertyCosts.Text = ClsManage.convert2Currency3(LbBKKSumStorePropertyCosts.Text)
        LbBKKSumPropertyRental.Text = ClsManage.convert2Currency3(LbBKKSumPropertyRental.Text)
        LbBKKSumPropertyServices.Text = ClsManage.convert2Currency3(LbBKKSumPropertyServices.Text)
        LbBKKSumPropertyFacility.Text = ClsManage.convert2Currency3(LbBKKSumPropertyFacility.Text)
        LbBKKSumPropertytaxes.Text = ClsManage.convert2Currency3(LbBKKSumPropertytaxes.Text)
        LbBKKSumFacialtaxes.Text = ClsManage.convert2Currency3(LbBKKSumFacialtaxes.Text)
        LbBKKSumPropertyInsurance.Text = ClsManage.convert2Currency3(LbBKKSumPropertyInsurance.Text)
        LbBKKSumSignboard.Text = ClsManage.convert2Currency3(LbBKKSumSignboard.Text)
        LbBKKSumDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency3(LbBKKSumDiscount_Rent_Services_Facility.Text)
        LbBKKSumGPCommission.Text = ClsManage.convert2Currency3(LbBKKSumGPCommission.Text)
        LbBKKSumAmortizationofLeaseRight.Text = ClsManage.convert2Currency3(LbBKKSumAmortizationofLeaseRight.Text)
        LbBKKSumDepreciation.Text = ClsManage.convert2Currency3(LbBKKSumDepreciation.Text)
        LbBKKSumDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency3(LbBKKSumDepreciationofShortLeaseBuilding.Text)
        LbBKKSumDepreciationofComputerHardware.Text = ClsManage.convert2Currency3(LbBKKSumDepreciationofComputerHardware.Text)
        LbBKKSumDepreciationofFixturesFittings.Text = ClsManage.convert2Currency3(LbBKKSumDepreciationofFixturesFittings.Text)
        LbBKKSumDepreciationofComputerSoftware.Text = ClsManage.convert2Currency3(LbBKKSumDepreciationofComputerSoftware.Text)
        LbBKKSumDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency3(LbBKKSumDepreciationofOfficeEquipment.Text)
        LbBKKSumOtherStoreCosts.Text = ClsManage.convert2Currency3(LbBKKSumOtherStoreCosts.Text)
        LbBKKSumServiceChargesandOtherFees.Text = ClsManage.convert2Currency3(LbBKKSumServiceChargesandOtherFees.Text)
        LbBKKSumBankCharges.Text = ClsManage.convert2Currency3(LbBKKSumBankCharges.Text)
        LbBKKSumCashCollectionCharge.Text = ClsManage.convert2Currency3(LbBKKSumCashCollectionCharge.Text)
        LbBKKSumCleaning.Text = ClsManage.convert2Currency3(LbBKKSumCleaning.Text)
        LbBKKSumSecurityGuards.Text = ClsManage.convert2Currency3(LbBKKSumSecurityGuards.Text)
        LbBKKSumCarriage.Text = ClsManage.convert2Currency3(LbBKKSumCarriage.Text)
        LbBKKSumLicenceFees.Text = ClsManage.convert2Currency3(LbBKKSumLicenceFees.Text)
        LbBKKSumOtherServicesCharge.Text = ClsManage.convert2Currency3(LbBKKSumOtherServicesCharge.Text)
        LbBKKSumOtherFees.Text = ClsManage.convert2Currency3(LbBKKSumOtherFees.Text)
        LbBKKSumUtilities.Text = ClsManage.convert2Currency3(LbBKKSumUtilities.Text)
        LbBKKSumWater.Text = ClsManage.convert2Currency3(LbBKKSumWater.Text)
        LbBKKSumGas_Electric.Text = ClsManage.convert2Currency3(LbBKKSumGas_Electric.Text)
        LbBKKSumAirCond_Addition.Text = ClsManage.convert2Currency3(LbBKKSumAirCond_Addition.Text)
        LbBKKSumRepairandMaintenance.Text = ClsManage.convert2Currency3(LbBKKSumRepairandMaintenance.Text)
        LbBKKSumRMOther_Fix.Text = ClsManage.convert2Currency3(LbBKKSumRMOther_Fix.Text)
        LbBKKSumRMOther_Unplan.Text = ClsManage.convert2Currency3(LbBKKSumRMOther_Unplan.Text)
        LbBKKSumRMComputer_Fix.Text = ClsManage.convert2Currency3(LbBKKSumRMComputer_Fix.Text)
        LbBKKSumRMComputer_Unplan.Text = ClsManage.convert2Currency3(LbBKKSumRMComputer_Unplan.Text)
        LbBKKSumProfessionalFee.Text = ClsManage.convert2Currency3(LbBKKSumProfessionalFee.Text)
        LbBKKSumMarketingResearch.Text = ClsManage.convert2Currency3(LbBKKSumMarketingResearch.Text)
        LbBKKSumOtherFee.Text = ClsManage.convert2Currency3(LbBKKSumOtherFee.Text)
        LbBKKSumEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency3(LbBKKSumEquipment_MaterailandSupplies.Text)
        LbBKKSumPrintingandStationery.Text = ClsManage.convert2Currency3(LbBKKSumPrintingandStationery.Text)
        LbBKKSumSuppliesExpenses.Text = ClsManage.convert2Currency3(LbBKKSumSuppliesExpenses.Text)
        LbBKKSumEquipment.Text = ClsManage.convert2Currency3(LbBKKSumEquipment.Text)
        LbBKKSumShopfitting.Text = ClsManage.convert2Currency3(LbBKKSumShopfitting.Text)
        LbBKKSumPackagingandOtherMaterial.Text = ClsManage.convert2Currency3(LbBKKSumPackagingandOtherMaterial.Text)
        LbBKKSumBusinessTravelExpenses.Text = ClsManage.convert2Currency3(LbBKKSumBusinessTravelExpenses.Text)
        LbBKKSumCarParkingandOthers.Text = ClsManage.convert2Currency3(LbBKKSumCarParkingandOthers.Text)
        LbBKKSumTravel.Text = ClsManage.convert2Currency3(LbBKKSumTravel.Text)
        LbBKKSumAccomodation.Text = ClsManage.convert2Currency3(LbBKKSumAccomodation.Text)
        LbBKKSumMealandEntertainment.Text = ClsManage.convert2Currency3(LbBKKSumMealandEntertainment.Text)
        LbBKKSumInsurance.Text = ClsManage.convert2Currency3(LbBKKSumInsurance.Text)
        LbBKKSumAllRiskInsurance.Text = ClsManage.convert2Currency3(LbBKKSumAllRiskInsurance.Text)
        LbBKKSumHealthandLifeInsurance.Text = ClsManage.convert2Currency3(LbBKKSumHealthandLifeInsurance.Text)
        LbBKKSumPenaltyandTaxation.Text = ClsManage.convert2Currency3(LbBKKSumPenaltyandTaxation.Text)
        LbBKKSumTaxation.Text = ClsManage.convert2Currency3(LbBKKSumTaxation.Text)
        LbBKKSumPenalty.Text = ClsManage.convert2Currency3(LbBKKSumPenalty.Text)
        LbBKKSumOtherRelatedStaffCost.Text = ClsManage.convert2Currency3(LbBKKSumOtherRelatedStaffCost.Text)
        LbBKKSumStaffConferenceandTraining.Text = ClsManage.convert2Currency3(LbBKKSumStaffConferenceandTraining.Text)
        LbBKKSumTraining.Text = ClsManage.convert2Currency3(LbBKKSumTraining.Text)
        LbBKKSumCommunication.Text = ClsManage.convert2Currency3(LbBKKSumCommunication.Text)
        LbBKKSumTelephoneCalls_Faxes.Text = ClsManage.convert2Currency3(LbBKKSumTelephoneCalls_Faxes.Text)
        LbBKKSumPostageandCourier.Text = ClsManage.convert2Currency3(LbBKKSumPostageandCourier.Text)
        LbBKKSumOtherExpenses.Text = ClsManage.convert2Currency3(LbBKKSumOtherExpenses.Text)
        LbBKKSumSample_Tester.Text = ClsManage.convert2Currency3(LbBKKSumSample_Tester.Text)
        LbBKKSumPreopeningCosts.Text = ClsManage.convert2Currency3(LbBKKSumPreopeningCosts.Text)
        LbBKKSumLossonClaim.Text = ClsManage.convert2Currency3(LbBKKSumLossonClaim.Text)
        LbBKKSumCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency3(LbBKKSumCashOvertage_Shortagefromsales.Text)
        LbBKKSumMiscellenousandOther.Text = ClsManage.convert2Currency3(LbBKKSumMiscellenousandOther.Text)
        LbBKKSumStoreTradingProfit__Loss.Text = ClsManage.convert2Currency3(LbBKKSumStoreTradingProfit__Loss.Text)
        'LbBKKSumTradingProfit__Loss.Text = ClsManage.convert2Currency3('LbBKKSumTradingProfit__Loss.Text)

        LbBKKPercTotalRevenue.Text = ClsManage.convert2Currency4(LbBKKPercTotalRevenue.Text)
        LbBKKPercRETAIL_TESPIncome.Text = ClsManage.convert2Currency4(LbBKKPercRETAIL_TESPIncome.Text)
        LbBKKPercOtherRevenue.Text = ClsManage.convert2Currency4(LbBKKPercOtherRevenue.Text)
        LbBKKPercCostofGoodSold.Text = ClsManage.convert2Currency4(LbBKKPercCostofGoodSold.Text)
        LbBKKPercGrossProfit.Text = ClsManage.convert2Currency4(LbBKKPercGrossProfit.Text)
        LbBKKPercMarginAdjustments.Text = ClsManage.convert2Currency4(LbBKKPercMarginAdjustments.Text)
        LbBKKPercShipping.Text = ClsManage.convert2Currency4(LbBKKPercShipping.Text)
        LbBKKPercStockLossandObsolescence.Text = ClsManage.convert2Currency4(LbBKKPercStockLossandObsolescence.Text)
        LbBKKPercInventoryAdjustment_stock.Text = ClsManage.convert2Currency4(LbBKKPercInventoryAdjustment_stock.Text)
        LbBKKPercInventoryAdjustment_damage.Text = ClsManage.convert2Currency4(LbBKKPercInventoryAdjustment_damage.Text)
        LbBKKPercStockLoss_Provision.Text = ClsManage.convert2Currency4(LbBKKPercStockLoss_Provision.Text)
        LbBKKPercStockObsolescence_Provision.Text = ClsManage.convert2Currency4(LbBKKPercStockObsolescence_Provision.Text)
        LbBKKPercGWP.Text = ClsManage.convert2Currency4(LbBKKPercGWP.Text)
        LbBKKPercGWPs_Corporate.Text = ClsManage.convert2Currency4(LbBKKPercGWPs_Corporate.Text)
        LbBKKPercGWPs_Transferred.Text = ClsManage.convert2Currency4(LbBKKPercGWPs_Transferred.Text)
        LbBKKPercSellingCosts.Text = ClsManage.convert2Currency4(LbBKKPercSellingCosts.Text)
        LbBKKPercCreditcardscommission.Text = ClsManage.convert2Currency4(LbBKKPercCreditcardscommission.Text)
        LbBKKPercLabellingMaterial.Text = ClsManage.convert2Currency4(LbBKKPercLabellingMaterial.Text)
        LbBKKPercOtherIncome_COSHFunding.Text = ClsManage.convert2Currency4(LbBKKPercOtherIncome_COSHFunding.Text)
        LbBKKPercOtherIncomeSupplier.Text = ClsManage.convert2Currency4(LbBKKPercOtherIncomeSupplier.Text)
        LbBKKPercAdjustedGrossMargin.Text = ClsManage.convert2Currency4(LbBKKPercAdjustedGrossMargin.Text)
        LbBKKPercSupplyChainCosts.Text = ClsManage.convert2Currency4(LbBKKPercSupplyChainCosts.Text)
        LbBKKPercTotalStoreExpenses.Text = ClsManage.convert2Currency4(LbBKKPercTotalStoreExpenses.Text)
        LbBKKPercStoreLabourCosts.Text = ClsManage.convert2Currency4(LbBKKPercStoreLabourCosts.Text)
        LbBKKPercGrossPay.Text = ClsManage.convert2Currency4(LbBKKPercGrossPay.Text)
        LbBKKPercTemporaryStaffCosts.Text = ClsManage.convert2Currency4(LbBKKPercTemporaryStaffCosts.Text)
        LbBKKPercAllowance.Text = ClsManage.convert2Currency4(LbBKKPercAllowance.Text)
        LbBKKPercOvertime.Text = ClsManage.convert2Currency4(LbBKKPercOvertime.Text)
        LbBKKPercLicensefee.Text = ClsManage.convert2Currency4(LbBKKPercLicensefee.Text)
        LbBKKPercBonuses_Incentives.Text = ClsManage.convert2Currency4(LbBKKPercBonuses_Incentives.Text)
        LbBKKPercBootsBrandncentives.Text = ClsManage.convert2Currency4(LbBKKPercBootsBrandncentives.Text)
        LbBKKPercSuppliersIncentive.Text = ClsManage.convert2Currency4(LbBKKPercSuppliersIncentive.Text)
        LbBKKPercProvidentFund.Text = ClsManage.convert2Currency4(LbBKKPercProvidentFund.Text)
        LbBKKPercPensionCosts.Text = ClsManage.convert2Currency4(LbBKKPercPensionCosts.Text)
        LbBKKPercSocialSecurityFund.Text = ClsManage.convert2Currency4(LbBKKPercSocialSecurityFund.Text)
        LbBKKPercUniforms.Text = ClsManage.convert2Currency4(LbBKKPercUniforms.Text)
        LbBKKPercEmployeeWelfare.Text = ClsManage.convert2Currency4(LbBKKPercEmployeeWelfare.Text)
        LbBKKPercOtherBenefitsEmployee.Text = ClsManage.convert2Currency4(LbBKKPercOtherBenefitsEmployee.Text)
        LbBKKPercStorePropertyCosts.Text = ClsManage.convert2Currency4(LbBKKPercStorePropertyCosts.Text)
        LbBKKPercPropertyRental.Text = ClsManage.convert2Currency4(LbBKKPercPropertyRental.Text)
        LbBKKPercPropertyServices.Text = ClsManage.convert2Currency4(LbBKKPercPropertyServices.Text)
        LbBKKPercPropertyFacility.Text = ClsManage.convert2Currency4(LbBKKPercPropertyFacility.Text)
        LbBKKPercPropertytaxes.Text = ClsManage.convert2Currency4(LbBKKPercPropertytaxes.Text)
        LbBKKPercFacialtaxes.Text = ClsManage.convert2Currency4(LbBKKPercFacialtaxes.Text)
        LbBKKPercPropertyInsurance.Text = ClsManage.convert2Currency4(LbBKKPercPropertyInsurance.Text)
        LbBKKPercSignboard.Text = ClsManage.convert2Currency4(LbBKKPercSignboard.Text)
        LbBKKPercDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency4(LbBKKPercDiscount_Rent_Services_Facility.Text)
        LbBKKPercGPCommission.Text = ClsManage.convert2Currency4(LbBKKPercGPCommission.Text)
        LbBKKPercAmortizationofLeaseRight.Text = ClsManage.convert2Currency4(LbBKKPercAmortizationofLeaseRight.Text)
        LbBKKPercDepreciation.Text = ClsManage.convert2Currency4(LbBKKPercDepreciation.Text)
        LbBKKPercDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency4(LbBKKPercDepreciationofShortLeaseBuilding.Text)
        LbBKKPercDepreciationofComputerHardware.Text = ClsManage.convert2Currency4(LbBKKPercDepreciationofComputerHardware.Text)
        LbBKKPercDepreciationofFixturesFittings.Text = ClsManage.convert2Currency4(LbBKKPercDepreciationofFixturesFittings.Text)
        LbBKKPercDepreciationofComputerSoftware.Text = ClsManage.convert2Currency4(LbBKKPercDepreciationofComputerSoftware.Text)
        LbBKKPercDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency4(LbBKKPercDepreciationofOfficeEquipment.Text)
        LbBKKPercOtherStoreCosts.Text = ClsManage.convert2Currency4(LbBKKPercOtherStoreCosts.Text)
        LbBKKPercServiceChargesandOtherFees.Text = ClsManage.convert2Currency4(LbBKKPercServiceChargesandOtherFees.Text)
        LbBKKPercBankCharges.Text = ClsManage.convert2Currency4(LbBKKPercBankCharges.Text)
        LbBKKPercCashCollectionCharge.Text = ClsManage.convert2Currency4(LbBKKPercCashCollectionCharge.Text)
        LbBKKPercCleaning.Text = ClsManage.convert2Currency4(LbBKKPercCleaning.Text)
        LbBKKPercSecurityGuards.Text = ClsManage.convert2Currency4(LbBKKPercSecurityGuards.Text)
        LbBKKPercCarriage.Text = ClsManage.convert2Currency4(LbBKKPercCarriage.Text)
        LbBKKPercLicenceFees.Text = ClsManage.convert2Currency4(LbBKKPercLicenceFees.Text)
        LbBKKPercOtherServicesCharge.Text = ClsManage.convert2Currency4(LbBKKPercOtherServicesCharge.Text)
        LbBKKPercOtherFees.Text = ClsManage.convert2Currency4(LbBKKPercOtherFees.Text)
        LbBKKPercUtilities.Text = ClsManage.convert2Currency4(LbBKKPercUtilities.Text)
        LbBKKPercWater.Text = ClsManage.convert2Currency4(LbBKKPercWater.Text)
        LbBKKPercGas_Electric.Text = ClsManage.convert2Currency4(LbBKKPercGas_Electric.Text)
        LbBKKPercAirCond_Addition.Text = ClsManage.convert2Currency4(LbBKKPercAirCond_Addition.Text)
        LbBKKPercRepairandMaintenance.Text = ClsManage.convert2Currency4(LbBKKPercRepairandMaintenance.Text)
        LbBKKPercRMOther_Fix.Text = ClsManage.convert2Currency4(LbBKKPercRMOther_Fix.Text)
        LbBKKPercRMOther_Unplan.Text = ClsManage.convert2Currency4(LbBKKPercRMOther_Unplan.Text)
        LbBKKPercRMComputer_Fix.Text = ClsManage.convert2Currency4(LbBKKPercRMComputer_Fix.Text)
        LbBKKPercRMComputer_Unplan.Text = ClsManage.convert2Currency4(LbBKKPercRMComputer_Unplan.Text)
        LbBKKPercProfessionalFee.Text = ClsManage.convert2Currency4(LbBKKPercProfessionalFee.Text)
        LbBKKPercMarketingResearch.Text = ClsManage.convert2Currency4(LbBKKPercMarketingResearch.Text)
        LbBKKPercOtherFee.Text = ClsManage.convert2Currency4(LbBKKPercOtherFee.Text)
        LbBKKPercEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency4(LbBKKPercEquipment_MaterailandSupplies.Text)
        LbBKKPercPrintingandStationery.Text = ClsManage.convert2Currency4(LbBKKPercPrintingandStationery.Text)
        LbBKKPercSuppliesExpenses.Text = ClsManage.convert2Currency4(LbBKKPercSuppliesExpenses.Text)
        LbBKKPercEquipment.Text = ClsManage.convert2Currency4(LbBKKPercEquipment.Text)
        LbBKKPercShopfitting.Text = ClsManage.convert2Currency4(LbBKKPercShopfitting.Text)
        LbBKKPercPackagingandOtherMaterial.Text = ClsManage.convert2Currency4(LbBKKPercPackagingandOtherMaterial.Text)
        LbBKKPercBusinessTravelExpenses.Text = ClsManage.convert2Currency4(LbBKKPercBusinessTravelExpenses.Text)
        LbBKKPercCarParkingandOthers.Text = ClsManage.convert2Currency4(LbBKKPercCarParkingandOthers.Text)
        LbBKKPercTravel.Text = ClsManage.convert2Currency4(LbBKKPercTravel.Text)
        LbBKKPercAccomodation.Text = ClsManage.convert2Currency4(LbBKKPercAccomodation.Text)
        LbBKKPercMealandEntertainment.Text = ClsManage.convert2Currency4(LbBKKPercMealandEntertainment.Text)
        LbBKKPercInsurance.Text = ClsManage.convert2Currency4(LbBKKPercInsurance.Text)
        LbBKKPercAllRiskInsurance.Text = ClsManage.convert2Currency4(LbBKKPercAllRiskInsurance.Text)
        LbBKKPercHealthandLifeInsurance.Text = ClsManage.convert2Currency4(LbBKKPercHealthandLifeInsurance.Text)
        LbBKKPercPenaltyandTaxation.Text = ClsManage.convert2Currency4(LbBKKPercPenaltyandTaxation.Text)
        LbBKKPercTaxation.Text = ClsManage.convert2Currency4(LbBKKPercTaxation.Text)
        LbBKKPercPenalty.Text = ClsManage.convert2Currency4(LbBKKPercPenalty.Text)
        LbBKKPercOtherRelatedStaffCost.Text = ClsManage.convert2Currency4(LbBKKPercOtherRelatedStaffCost.Text)
        LbBKKPercStaffConferenceandTraining.Text = ClsManage.convert2Currency4(LbBKKPercStaffConferenceandTraining.Text)
        LbBKKPercTraining.Text = ClsManage.convert2Currency4(LbBKKPercTraining.Text)
        LbBKKPercCommunication.Text = ClsManage.convert2Currency4(LbBKKPercCommunication.Text)
        LbBKKPercTelephoneCalls_Faxes.Text = ClsManage.convert2Currency4(LbBKKPercTelephoneCalls_Faxes.Text)
        LbBKKPercPostageandCourier.Text = ClsManage.convert2Currency4(LbBKKPercPostageandCourier.Text)
        LbBKKPercOtherExpenses.Text = ClsManage.convert2Currency4(LbBKKPercOtherExpenses.Text)
        LbBKKPercSample_Tester.Text = ClsManage.convert2Currency4(LbBKKPercSample_Tester.Text)
        LbBKKPercPreopeningCosts.Text = ClsManage.convert2Currency4(LbBKKPercPreopeningCosts.Text)
        LbBKKPercLossonClaim.Text = ClsManage.convert2Currency4(LbBKKPercLossonClaim.Text)
        LbBKKPercCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency4(LbBKKPercCashOvertage_Shortagefromsales.Text)
        LbBKKPercMiscellenousandOther.Text = ClsManage.convert2Currency4(LbBKKPercMiscellenousandOther.Text)
        LbBKKPercStoreTradingProfit__Loss.Text = ClsManage.convert2Currency4(LbBKKPercStoreTradingProfit__Loss.Text)

		 LbUPFullTgs.Text = ClsManage.convert2Currency3(LbUPFullTgs.Text)
        LbUPFullTss.Text = ClsManage.convert2Currency3(LbUPFullTss.Text)
        LbUPFullPos.Text = ClsManage.convert2Currency3(LbUPFullPos.Text)
        LbUPSumTotalRevenue.Text = ClsManage.convert2Currency3(LbUPSumTotalRevenue.Text)
        LbUPSumRETAIL_TESPIncome.Text = ClsManage.convert2Currency3(LbUPSumRETAIL_TESPIncome.Text)
        LbUPSumOtherRevenue.Text = ClsManage.convert2Currency3(LbUPSumOtherRevenue.Text)
        LbUPSumCostofGoodSold.Text = ClsManage.convert2Currency3(LbUPSumCostofGoodSold.Text)
        LbUPSumGrossProfit.Text = ClsManage.convert2Currency3(LbUPSumGrossProfit.Text)
        'LbUPSumGrossProfit_percent.Text = ClsManage.convert2Currency3('LbUPSumGrossProfit_percent.Text)
        LbUPSumMarginAdjustments.Text = ClsManage.convert2Currency3(LbUPSumMarginAdjustments.Text)
        LbUPSumShipping.Text = ClsManage.convert2Currency3(LbUPSumShipping.Text)
        LbUPSumStockLossandObsolescence.Text = ClsManage.convert2Currency3(LbUPSumStockLossandObsolescence.Text)
        LbUPSumInventoryAdjustment_stock.Text = ClsManage.convert2Currency3(LbUPSumInventoryAdjustment_stock.Text)
        LbUPSumInventoryAdjustment_damage.Text = ClsManage.convert2Currency3(LbUPSumInventoryAdjustment_damage.Text)
        LbUPSumStockLoss_Provision.Text = ClsManage.convert2Currency3(LbUPSumStockLoss_Provision.Text)
        LbUPSumStockObsolescence_Provision.Text = ClsManage.convert2Currency3(LbUPSumStockObsolescence_Provision.Text)
        LbUPSumGWP.Text = ClsManage.convert2Currency3(LbUPSumGWP.Text)
        LbUPSumGWPs_Corporate.Text = ClsManage.convert2Currency3(LbUPSumGWPs_Corporate.Text)
        LbUPSumGWPs_Transferred.Text = ClsManage.convert2Currency3(LbUPSumGWPs_Transferred.Text)
        LbUPSumSellingCosts.Text = ClsManage.convert2Currency3(LbUPSumSellingCosts.Text)
        LbUPSumCreditcardscommission.Text = ClsManage.convert2Currency3(LbUPSumCreditcardscommission.Text)
        LbUPSumLabellingMaterial.Text = ClsManage.convert2Currency3(LbUPSumLabellingMaterial.Text)
        LbUPSumOtherIncome_COSHFunding.Text = ClsManage.convert2Currency3(LbUPSumOtherIncome_COSHFunding.Text)
        LbUPSumOtherIncomeSupplier.Text = ClsManage.convert2Currency3(LbUPSumOtherIncomeSupplier.Text)
        LbUPSumAdjustedGrossMargin.Text = ClsManage.convert2Currency3(LbUPSumAdjustedGrossMargin.Text)
        LbUPSumSupplyChainCosts.Text = ClsManage.convert2Currency3(LbUPSumSupplyChainCosts.Text)
        LbUPSumTotalStoreExpenses.Text = ClsManage.convert2Currency3(LbUPSumTotalStoreExpenses.Text)
        LbUPSumStoreLabourCosts.Text = ClsManage.convert2Currency3(LbUPSumStoreLabourCosts.Text)
        LbUPSumGrossPay.Text = ClsManage.convert2Currency3(LbUPSumGrossPay.Text)
        LbUPSumTemporaryStaffCosts.Text = ClsManage.convert2Currency3(LbUPSumTemporaryStaffCosts.Text)
        LbUPSumAllowance.Text = ClsManage.convert2Currency3(LbUPSumAllowance.Text)
        LbUPSumOvertime.Text = ClsManage.convert2Currency3(LbUPSumOvertime.Text)
        LbUPSumLicensefee.Text = ClsManage.convert2Currency3(LbUPSumLicensefee.Text)
        LbUPSumBonuses_Incentives.Text = ClsManage.convert2Currency3(LbUPSumBonuses_Incentives.Text)
        LbUPSumBootsBrandncentives.Text = ClsManage.convert2Currency3(LbUPSumBootsBrandncentives.Text)
        LbUPSumSuppliersIncentive.Text = ClsManage.convert2Currency3(LbUPSumSuppliersIncentive.Text)
        LbUPSumProvidentFund.Text = ClsManage.convert2Currency3(LbUPSumProvidentFund.Text)
        LbUPSumPensionCosts.Text = ClsManage.convert2Currency3(LbUPSumPensionCosts.Text)
        LbUPSumSocialSecurityFund.Text = ClsManage.convert2Currency3(LbUPSumSocialSecurityFund.Text)
        LbUPSumUniforms.Text = ClsManage.convert2Currency3(LbUPSumUniforms.Text)
        LbUPSumEmployeeWelfare.Text = ClsManage.convert2Currency3(LbUPSumEmployeeWelfare.Text)
        LbUPSumOtherBenefitsEmployee.Text = ClsManage.convert2Currency3(LbUPSumOtherBenefitsEmployee.Text)
        LbUPSumStorePropertyCosts.Text = ClsManage.convert2Currency3(LbUPSumStorePropertyCosts.Text)
        LbUPSumPropertyRental.Text = ClsManage.convert2Currency3(LbUPSumPropertyRental.Text)
        LbUPSumPropertyServices.Text = ClsManage.convert2Currency3(LbUPSumPropertyServices.Text)
        LbUPSumPropertyFacility.Text = ClsManage.convert2Currency3(LbUPSumPropertyFacility.Text)
        LbUPSumPropertytaxes.Text = ClsManage.convert2Currency3(LbUPSumPropertytaxes.Text)
        LbUPSumFacialtaxes.Text = ClsManage.convert2Currency3(LbUPSumFacialtaxes.Text)
        LbUPSumPropertyInsurance.Text = ClsManage.convert2Currency3(LbUPSumPropertyInsurance.Text)
        LbUPSumSignboard.Text = ClsManage.convert2Currency3(LbUPSumSignboard.Text)
        LbUPSumDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency3(LbUPSumDiscount_Rent_Services_Facility.Text)
        LbUPSumGPCommission.Text = ClsManage.convert2Currency3(LbUPSumGPCommission.Text)
        LbUPSumAmortizationofLeaseRight.Text = ClsManage.convert2Currency3(LbUPSumAmortizationofLeaseRight.Text)
        LbUPSumDepreciation.Text = ClsManage.convert2Currency3(LbUPSumDepreciation.Text)
        LbUPSumDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency3(LbUPSumDepreciationofShortLeaseBuilding.Text)
        LbUPSumDepreciationofComputerHardware.Text = ClsManage.convert2Currency3(LbUPSumDepreciationofComputerHardware.Text)
        LbUPSumDepreciationofFixturesFittings.Text = ClsManage.convert2Currency3(LbUPSumDepreciationofFixturesFittings.Text)
        LbUPSumDepreciationofComputerSoftware.Text = ClsManage.convert2Currency3(LbUPSumDepreciationofComputerSoftware.Text)
        LbUPSumDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency3(LbUPSumDepreciationofOfficeEquipment.Text)
        LbUPSumOtherStoreCosts.Text = ClsManage.convert2Currency3(LbUPSumOtherStoreCosts.Text)
        LbUPSumServiceChargesandOtherFees.Text = ClsManage.convert2Currency3(LbUPSumServiceChargesandOtherFees.Text)
        LbUPSumBankCharges.Text = ClsManage.convert2Currency3(LbUPSumBankCharges.Text)
        LbUPSumCashCollectionCharge.Text = ClsManage.convert2Currency3(LbUPSumCashCollectionCharge.Text)
        LbUPSumCleaning.Text = ClsManage.convert2Currency3(LbUPSumCleaning.Text)
        LbUPSumSecurityGuards.Text = ClsManage.convert2Currency3(LbUPSumSecurityGuards.Text)
        LbUPSumCarriage.Text = ClsManage.convert2Currency3(LbUPSumCarriage.Text)
        LbUPSumLicenceFees.Text = ClsManage.convert2Currency3(LbUPSumLicenceFees.Text)
        LbUPSumOtherServicesCharge.Text = ClsManage.convert2Currency3(LbUPSumOtherServicesCharge.Text)
        LbUPSumOtherFees.Text = ClsManage.convert2Currency3(LbUPSumOtherFees.Text)
        LbUPSumUtilities.Text = ClsManage.convert2Currency3(LbUPSumUtilities.Text)
        LbUPSumWater.Text = ClsManage.convert2Currency3(LbUPSumWater.Text)
        LbUPSumGas_Electric.Text = ClsManage.convert2Currency3(LbUPSumGas_Electric.Text)
        LbUPSumAirCond_Addition.Text = ClsManage.convert2Currency3(LbUPSumAirCond_Addition.Text)
        LbUPSumRepairandMaintenance.Text = ClsManage.convert2Currency3(LbUPSumRepairandMaintenance.Text)
        LbUPSumRMOther_Fix.Text = ClsManage.convert2Currency3(LbUPSumRMOther_Fix.Text)
        LbUPSumRMOther_Unplan.Text = ClsManage.convert2Currency3(LbUPSumRMOther_Unplan.Text)
        LbUPSumRMComputer_Fix.Text = ClsManage.convert2Currency3(LbUPSumRMComputer_Fix.Text)
        LbUPSumRMComputer_Unplan.Text = ClsManage.convert2Currency3(LbUPSumRMComputer_Unplan.Text)
        LbUPSumProfessionalFee.Text = ClsManage.convert2Currency3(LbUPSumProfessionalFee.Text)
        LbUPSumMarketingResearch.Text = ClsManage.convert2Currency3(LbUPSumMarketingResearch.Text)
        LbUPSumOtherFee.Text = ClsManage.convert2Currency3(LbUPSumOtherFee.Text)
        LbUPSumEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency3(LbUPSumEquipment_MaterailandSupplies.Text)
        LbUPSumPrintingandStationery.Text = ClsManage.convert2Currency3(LbUPSumPrintingandStationery.Text)
        LbUPSumSuppliesExpenses.Text = ClsManage.convert2Currency3(LbUPSumSuppliesExpenses.Text)
        LbUPSumEquipment.Text = ClsManage.convert2Currency3(LbUPSumEquipment.Text)
        LbUPSumShopfitting.Text = ClsManage.convert2Currency3(LbUPSumShopfitting.Text)
        LbUPSumPackagingandOtherMaterial.Text = ClsManage.convert2Currency3(LbUPSumPackagingandOtherMaterial.Text)
        LbUPSumBusinessTravelExpenses.Text = ClsManage.convert2Currency3(LbUPSumBusinessTravelExpenses.Text)
        LbUPSumCarParkingandOthers.Text = ClsManage.convert2Currency3(LbUPSumCarParkingandOthers.Text)
        LbUPSumTravel.Text = ClsManage.convert2Currency3(LbUPSumTravel.Text)
        LbUPSumAccomodation.Text = ClsManage.convert2Currency3(LbUPSumAccomodation.Text)
        LbUPSumMealandEntertainment.Text = ClsManage.convert2Currency3(LbUPSumMealandEntertainment.Text)
        LbUPSumInsurance.Text = ClsManage.convert2Currency3(LbUPSumInsurance.Text)
        LbUPSumAllRiskInsurance.Text = ClsManage.convert2Currency3(LbUPSumAllRiskInsurance.Text)
        LbUPSumHealthandLifeInsurance.Text = ClsManage.convert2Currency3(LbUPSumHealthandLifeInsurance.Text)
        LbUPSumPenaltyandTaxation.Text = ClsManage.convert2Currency3(LbUPSumPenaltyandTaxation.Text)
        LbUPSumTaxation.Text = ClsManage.convert2Currency3(LbUPSumTaxation.Text)
        LbUPSumPenalty.Text = ClsManage.convert2Currency3(LbUPSumPenalty.Text)
        LbUPSumOtherRelatedStaffCost.Text = ClsManage.convert2Currency3(LbUPSumOtherRelatedStaffCost.Text)
        LbUPSumStaffConferenceandTraining.Text = ClsManage.convert2Currency3(LbUPSumStaffConferenceandTraining.Text)
        LbUPSumTraining.Text = ClsManage.convert2Currency3(LbUPSumTraining.Text)
        LbUPSumCommunication.Text = ClsManage.convert2Currency3(LbUPSumCommunication.Text)
        LbUPSumTelephoneCalls_Faxes.Text = ClsManage.convert2Currency3(LbUPSumTelephoneCalls_Faxes.Text)
        LbUPSumPostageandCourier.Text = ClsManage.convert2Currency3(LbUPSumPostageandCourier.Text)
        LbUPSumOtherExpenses.Text = ClsManage.convert2Currency3(LbUPSumOtherExpenses.Text)
        LbUPSumSample_Tester.Text = ClsManage.convert2Currency3(LbUPSumSample_Tester.Text)
        LbUPSumPreopeningCosts.Text = ClsManage.convert2Currency3(LbUPSumPreopeningCosts.Text)
        LbUPSumLossonClaim.Text = ClsManage.convert2Currency3(LbUPSumLossonClaim.Text)
        LbUPSumCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency3(LbUPSumCashOvertage_Shortagefromsales.Text)
        LbUPSumMiscellenousandOther.Text = ClsManage.convert2Currency3(LbUPSumMiscellenousandOther.Text)
        LbUPSumStoreTradingProfit__Loss.Text = ClsManage.convert2Currency3(LbUPSumStoreTradingProfit__Loss.Text)
        'LbUPSumTradingProfit__Loss.Text = ClsManage.convert2Currency3('LbUPSumTradingProfit__Loss.Text)

        LbUPPercTotalRevenue.Text = ClsManage.convert2Currency4(LbUPPercTotalRevenue.Text)
        LbUPPercRETAIL_TESPIncome.Text = ClsManage.convert2Currency4(LbUPPercRETAIL_TESPIncome.Text)
        LbUPPercOtherRevenue.Text = ClsManage.convert2Currency4(LbUPPercOtherRevenue.Text)
        LbUPPercCostofGoodSold.Text = ClsManage.convert2Currency4(LbUPPercCostofGoodSold.Text)
        LbUPPercGrossProfit.Text = ClsManage.convert2Currency4(LbUPPercGrossProfit.Text)
        LbUPPercMarginAdjustments.Text = ClsManage.convert2Currency4(LbUPPercMarginAdjustments.Text)
        LbUPPercShipping.Text = ClsManage.convert2Currency4(LbUPPercShipping.Text)
        LbUPPercStockLossandObsolescence.Text = ClsManage.convert2Currency4(LbUPPercStockLossandObsolescence.Text)
        LbUPPercInventoryAdjustment_stock.Text = ClsManage.convert2Currency4(LbUPPercInventoryAdjustment_stock.Text)
        LbUPPercInventoryAdjustment_damage.Text = ClsManage.convert2Currency4(LbUPPercInventoryAdjustment_damage.Text)
        LbUPPercStockLoss_Provision.Text = ClsManage.convert2Currency4(LbUPPercStockLoss_Provision.Text)
        LbUPPercStockObsolescence_Provision.Text = ClsManage.convert2Currency4(LbUPPercStockObsolescence_Provision.Text)
        LbUPPercGWP.Text = ClsManage.convert2Currency4(LbUPPercGWP.Text)
        LbUPPercGWPs_Corporate.Text = ClsManage.convert2Currency4(LbUPPercGWPs_Corporate.Text)
        LbUPPercGWPs_Transferred.Text = ClsManage.convert2Currency4(LbUPPercGWPs_Transferred.Text)
        LbUPPercSellingCosts.Text = ClsManage.convert2Currency4(LbUPPercSellingCosts.Text)
        LbUPPercCreditcardscommission.Text = ClsManage.convert2Currency4(LbUPPercCreditcardscommission.Text)
        LbUPPercLabellingMaterial.Text = ClsManage.convert2Currency4(LbUPPercLabellingMaterial.Text)
        LbUPPercOtherIncome_COSHFunding.Text = ClsManage.convert2Currency4(LbUPPercOtherIncome_COSHFunding.Text)
        LbUPPercOtherIncomeSupplier.Text = ClsManage.convert2Currency4(LbUPPercOtherIncomeSupplier.Text)
        LbUPPercAdjustedGrossMargin.Text = ClsManage.convert2Currency4(LbUPPercAdjustedGrossMargin.Text)
        LbUPPercSupplyChainCosts.Text = ClsManage.convert2Currency4(LbUPPercSupplyChainCosts.Text)
        LbUPPercTotalStoreExpenses.Text = ClsManage.convert2Currency4(LbUPPercTotalStoreExpenses.Text)
        LbUPPercStoreLabourCosts.Text = ClsManage.convert2Currency4(LbUPPercStoreLabourCosts.Text)
        LbUPPercGrossPay.Text = ClsManage.convert2Currency4(LbUPPercGrossPay.Text)
        LbUPPercTemporaryStaffCosts.Text = ClsManage.convert2Currency4(LbUPPercTemporaryStaffCosts.Text)
        LbUPPercAllowance.Text = ClsManage.convert2Currency4(LbUPPercAllowance.Text)
        LbUPPercOvertime.Text = ClsManage.convert2Currency4(LbUPPercOvertime.Text)
        LbUPPercLicensefee.Text = ClsManage.convert2Currency4(LbUPPercLicensefee.Text)
        LbUPPercBonuses_Incentives.Text = ClsManage.convert2Currency4(LbUPPercBonuses_Incentives.Text)
        LbUPPercBootsBrandncentives.Text = ClsManage.convert2Currency4(LbUPPercBootsBrandncentives.Text)
        LbUPPercSuppliersIncentive.Text = ClsManage.convert2Currency4(LbUPPercSuppliersIncentive.Text)
        LbUPPercProvidentFund.Text = ClsManage.convert2Currency4(LbUPPercProvidentFund.Text)
        LbUPPercPensionCosts.Text = ClsManage.convert2Currency4(LbUPPercPensionCosts.Text)
        LbUPPercSocialSecurityFund.Text = ClsManage.convert2Currency4(LbUPPercSocialSecurityFund.Text)
        LbUPPercUniforms.Text = ClsManage.convert2Currency4(LbUPPercUniforms.Text)
        LbUPPercEmployeeWelfare.Text = ClsManage.convert2Currency4(LbUPPercEmployeeWelfare.Text)
        LbUPPercOtherBenefitsEmployee.Text = ClsManage.convert2Currency4(LbUPPercOtherBenefitsEmployee.Text)
        LbUPPercStorePropertyCosts.Text = ClsManage.convert2Currency4(LbUPPercStorePropertyCosts.Text)
        LbUPPercPropertyRental.Text = ClsManage.convert2Currency4(LbUPPercPropertyRental.Text)
        LbUPPercPropertyServices.Text = ClsManage.convert2Currency4(LbUPPercPropertyServices.Text)
        LbUPPercPropertyFacility.Text = ClsManage.convert2Currency4(LbUPPercPropertyFacility.Text)
        LbUPPercPropertytaxes.Text = ClsManage.convert2Currency4(LbUPPercPropertytaxes.Text)
        LbUPPercFacialtaxes.Text = ClsManage.convert2Currency4(LbUPPercFacialtaxes.Text)
        LbUPPercPropertyInsurance.Text = ClsManage.convert2Currency4(LbUPPercPropertyInsurance.Text)
        LbUPPercSignboard.Text = ClsManage.convert2Currency4(LbUPPercSignboard.Text)
        LbUPPercDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency4(LbUPPercDiscount_Rent_Services_Facility.Text)
        LbUPPercGPCommission.Text = ClsManage.convert2Currency4(LbUPPercGPCommission.Text)
        LbUPPercAmortizationofLeaseRight.Text = ClsManage.convert2Currency4(LbUPPercAmortizationofLeaseRight.Text)
        LbUPPercDepreciation.Text = ClsManage.convert2Currency4(LbUPPercDepreciation.Text)
        LbUPPercDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency4(LbUPPercDepreciationofShortLeaseBuilding.Text)
        LbUPPercDepreciationofComputerHardware.Text = ClsManage.convert2Currency4(LbUPPercDepreciationofComputerHardware.Text)
        LbUPPercDepreciationofFixturesFittings.Text = ClsManage.convert2Currency4(LbUPPercDepreciationofFixturesFittings.Text)
        LbUPPercDepreciationofComputerSoftware.Text = ClsManage.convert2Currency4(LbUPPercDepreciationofComputerSoftware.Text)
        LbUPPercDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency4(LbUPPercDepreciationofOfficeEquipment.Text)
        LbUPPercOtherStoreCosts.Text = ClsManage.convert2Currency4(LbUPPercOtherStoreCosts.Text)
        LbUPPercServiceChargesandOtherFees.Text = ClsManage.convert2Currency4(LbUPPercServiceChargesandOtherFees.Text)
        LbUPPercBankCharges.Text = ClsManage.convert2Currency4(LbUPPercBankCharges.Text)
        LbUPPercCashCollectionCharge.Text = ClsManage.convert2Currency4(LbUPPercCashCollectionCharge.Text)
        LbUPPercCleaning.Text = ClsManage.convert2Currency4(LbUPPercCleaning.Text)
        LbUPPercSecurityGuards.Text = ClsManage.convert2Currency4(LbUPPercSecurityGuards.Text)
        LbUPPercCarriage.Text = ClsManage.convert2Currency4(LbUPPercCarriage.Text)
        LbUPPercLicenceFees.Text = ClsManage.convert2Currency4(LbUPPercLicenceFees.Text)
        LbUPPercOtherServicesCharge.Text = ClsManage.convert2Currency4(LbUPPercOtherServicesCharge.Text)
        LbUPPercOtherFees.Text = ClsManage.convert2Currency4(LbUPPercOtherFees.Text)
        LbUPPercUtilities.Text = ClsManage.convert2Currency4(LbUPPercUtilities.Text)
        LbUPPercWater.Text = ClsManage.convert2Currency4(LbUPPercWater.Text)
        LbUPPercGas_Electric.Text = ClsManage.convert2Currency4(LbUPPercGas_Electric.Text)
        LbUPPercAirCond_Addition.Text = ClsManage.convert2Currency4(LbUPPercAirCond_Addition.Text)
        LbUPPercRepairandMaintenance.Text = ClsManage.convert2Currency4(LbUPPercRepairandMaintenance.Text)
        LbUPPercRMOther_Fix.Text = ClsManage.convert2Currency4(LbUPPercRMOther_Fix.Text)
        LbUPPercRMOther_Unplan.Text = ClsManage.convert2Currency4(LbUPPercRMOther_Unplan.Text)
        LbUPPercRMComputer_Fix.Text = ClsManage.convert2Currency4(LbUPPercRMComputer_Fix.Text)
        LbUPPercRMComputer_Unplan.Text = ClsManage.convert2Currency4(LbUPPercRMComputer_Unplan.Text)
        LbUPPercProfessionalFee.Text = ClsManage.convert2Currency4(LbUPPercProfessionalFee.Text)
        LbUPPercMarketingResearch.Text = ClsManage.convert2Currency4(LbUPPercMarketingResearch.Text)
        LbUPPercOtherFee.Text = ClsManage.convert2Currency4(LbUPPercOtherFee.Text)
        LbUPPercEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency4(LbUPPercEquipment_MaterailandSupplies.Text)
        LbUPPercPrintingandStationery.Text = ClsManage.convert2Currency4(LbUPPercPrintingandStationery.Text)
        LbUPPercSuppliesExpenses.Text = ClsManage.convert2Currency4(LbUPPercSuppliesExpenses.Text)
        LbUPPercEquipment.Text = ClsManage.convert2Currency4(LbUPPercEquipment.Text)
        LbUPPercShopfitting.Text = ClsManage.convert2Currency4(LbUPPercShopfitting.Text)
        LbUPPercPackagingandOtherMaterial.Text = ClsManage.convert2Currency4(LbUPPercPackagingandOtherMaterial.Text)
        LbUPPercBusinessTravelExpenses.Text = ClsManage.convert2Currency4(LbUPPercBusinessTravelExpenses.Text)
        LbUPPercCarParkingandOthers.Text = ClsManage.convert2Currency4(LbUPPercCarParkingandOthers.Text)
        LbUPPercTravel.Text = ClsManage.convert2Currency4(LbUPPercTravel.Text)
        LbUPPercAccomodation.Text = ClsManage.convert2Currency4(LbUPPercAccomodation.Text)
        LbUPPercMealandEntertainment.Text = ClsManage.convert2Currency4(LbUPPercMealandEntertainment.Text)
        LbUPPercInsurance.Text = ClsManage.convert2Currency4(LbUPPercInsurance.Text)
        LbUPPercAllRiskInsurance.Text = ClsManage.convert2Currency4(LbUPPercAllRiskInsurance.Text)
        LbUPPercHealthandLifeInsurance.Text = ClsManage.convert2Currency4(LbUPPercHealthandLifeInsurance.Text)
        LbUPPercPenaltyandTaxation.Text = ClsManage.convert2Currency4(LbUPPercPenaltyandTaxation.Text)
        LbUPPercTaxation.Text = ClsManage.convert2Currency4(LbUPPercTaxation.Text)
        LbUPPercPenalty.Text = ClsManage.convert2Currency4(LbUPPercPenalty.Text)
        LbUPPercOtherRelatedStaffCost.Text = ClsManage.convert2Currency4(LbUPPercOtherRelatedStaffCost.Text)
        LbUPPercStaffConferenceandTraining.Text = ClsManage.convert2Currency4(LbUPPercStaffConferenceandTraining.Text)
        LbUPPercTraining.Text = ClsManage.convert2Currency4(LbUPPercTraining.Text)
        LbUPPercCommunication.Text = ClsManage.convert2Currency4(LbUPPercCommunication.Text)
        LbUPPercTelephoneCalls_Faxes.Text = ClsManage.convert2Currency4(LbUPPercTelephoneCalls_Faxes.Text)
        LbUPPercPostageandCourier.Text = ClsManage.convert2Currency4(LbUPPercPostageandCourier.Text)
        LbUPPercOtherExpenses.Text = ClsManage.convert2Currency4(LbUPPercOtherExpenses.Text)
        LbUPPercSample_Tester.Text = ClsManage.convert2Currency4(LbUPPercSample_Tester.Text)
        LbUPPercPreopeningCosts.Text = ClsManage.convert2Currency4(LbUPPercPreopeningCosts.Text)
        LbUPPercLossonClaim.Text = ClsManage.convert2Currency4(LbUPPercLossonClaim.Text)
        LbUPPercCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency4(LbUPPercCashOvertage_Shortagefromsales.Text)
        LbUPPercMiscellenousandOther.Text = ClsManage.convert2Currency4(LbUPPercMiscellenousandOther.Text)
        LbUPPercStoreTradingProfit__Loss.Text = ClsManage.convert2Currency4(LbUPPercStoreTradingProfit__Loss.Text)

		LbNost.Text = ClsManage.convert2Currency3(LbNost.Text)
		LbNostBKK.Text = ClsManage.convert2Currency3(LbNostBKK.Text)
		LbNostUP.Text = ClsManage.convert2Currency3(LbNostUP.Text)
    End Sub

    Protected Sub linkExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkExcel.Click

        Dim sw As New IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        temp_body.RenderControl(htw)
        ClsDB.ExportToExcel(htw.InnerWriter.ToString)

    End Sub

    Protected Sub DataList2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList2.ItemDataBound
        TbCk.Text = Convert.ToDecimal(TbCk.Text) + 1

        Dim x_divide As String = 0
        If ddlMonth.SelectedValue < 4 Then
            x_divide = ddlMonth.SelectedValue + 9
        Else
            x_divide = ddlMonth.SelectedValue - 3
        End If

        Dim start_year As String
        If ddlMonth.SelectedValue <= 4 Then
            start_year = "1/4/" + (ddlYear.SelectedValue - 1).ToString
        Else
            start_year = "1/4/" + ddlYear.SelectedValue.ToString
        End If

        Dim da As Data.DataTable
        da = ClsDB.getSumFullYtdModelByBangkok(ddlYear.SelectedValue, ddlMonth.SelectedValue, "1", e.Item.DataItem("store_id").ToString, start_year, ddlRate.SelectedValue)

        Dim da2 As Data.DataTable
        da2 = ClsDB.getSumFullYtdModelByBangkok(ddlYear.SelectedValue, ddlMonth.SelectedValue, "2", e.Item.DataItem("store_id").ToString, start_year, ddlRate.SelectedValue)

        Dim prosqm As String = "0.0"
        If e.Item.DataItem("sumsalearea") - da.Rows(0)("sumsalearea") <> "0" Then
            Dim prosqm1 As String = ClsManage.convert2Currency3((e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")) / (e.Item.DataItem("sumsalearea") - da.Rows(0)("sumsalearea"))).ToString()
            prosqm = ClsManage.convert2Currency3(prosqm1 / x_divide)
        End If

        Dim gossper As String = "0.0"
        If e.Item.DataItem("sumsalearea") - da.Rows(0)("sumsalearea") <> "0" Then
            gossper = ClsManage.convert2Currency3(((e.Item.DataItem("sumGrossProfit") - da.Rows(0)("sumGrossProfit")) / (e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue"))) * 100).ToString
        End If

        Dim strHtml As New StringBuilder
        Dim strTbck As String = TbCk.Text
        strHtml.Append("<TABLE cellspacing='0' cellpadding='0' class='tball'>")
        strHtml.Append("<TR style='font-weight:bold;' class='kbg1'><TD align='center'><div style='width:110px'><strong>" + da.Rows(0)("cnum").ToString + "</strong></div></TD><TD align='center' valign='middle'><div style='width:65px;'><strong></strong></div></TD><TD align='center'><div style='width:110px'><strong>" + ClsManage.convert2Currency3(e.Item.DataItem("cnum") - da.Rows(0)("cnum")).ToString + "</strong></div></TD><TD align='center' valign='middle'><div style='width:65px;'><strong></strong></div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' class='kbg1'><TD align='center' style='height:30px;'><div style='width:110px'><strong>" + e.Item.DataItem("store_name") + " (Bangkok)</strong></div></TD><TD align='center' valign='middle'><div style='width:65px;'><strong>% Sale</strong></div></TD><TD align='center'><div style='width:110px'><strong>" + e.Item.DataItem("store_name") + " (Upcountry)</strong></div></TD><TD align='center' valign='middle'><div style='width:65px;'><strong>% Sale</strong></div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' ><TD align='center'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumtotalarea")).ToString + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD align='center'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumtotalarea") - da.Rows(0)("sumtotalarea")).ToString + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' ><TD align='center'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumsalearea")).ToString + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD align='center'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumsalearea") - da.Rows(0)("sumsalearea")).ToString + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' ><TD align='center'><div style='width:110px'>" + ClsManage.convert2Currency3((da.Rows(0)("sumTotalRevenue") / Convert.ToDecimal(da.Rows(0)("sumsalearea")).ToString) / Convert.ToDecimal(x_divide)) + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD align='center'><div style='width:110px'>" + prosqm + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' ><TD align='center'><div style='width:110px'>YTD " + x_divide.ToString + " M</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD><TD align='center'><div style='width:110px'>YTD " + x_divide.ToString + " M</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumTotalRevenue")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>100.0%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>100.0%</div></TD></TR>")
        strHtml.Append("<TR id='aa1c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumRETAIL_TESPIncome")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumRETAIL_TESPIncome") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumRETAIL_TESPIncome") - da.Rows(0)("sumRETAIL_TESPIncome")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumRETAIL_TESPIncome") - da.Rows(0)("sumRETAIL_TESPIncome"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='aa2c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherRevenue")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherRevenue") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherRevenue") - da.Rows(0)("sumOtherRevenue")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherRevenue") - da.Rows(0)("sumOtherRevenue"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumCostofGoodSold")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumCostofGoodSold") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumCostofGoodSold") - da.Rows(0)("sumCostofGoodSold")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumCostofGoodSold") - da.Rows(0)("sumCostofGoodSold"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumGrossProfit")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumGrossProfit") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumGrossProfit") - da.Rows(0)("sumGrossProfit")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumGrossProfit") - da.Rows(0)("sumGrossProfit"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumMarginAdjustments")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumMarginAdjustments") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumMarginAdjustments") - da.Rows(0)("sumMarginAdjustments")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumMarginAdjustments") - da.Rows(0)("sumMarginAdjustments"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b1c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumShipping")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumShipping") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumShipping") - da.Rows(0)("sumShipping")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumShipping") - da.Rows(0)("sumShipping"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b2c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumStockLossandObsolescence")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumStockLossandObsolescence") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumStockLossandObsolescence") - da.Rows(0)("sumStockLossandObsolescence")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumStockLossandObsolescence") - da.Rows(0)("sumStockLossandObsolescence"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b3c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumInventoryAdjustment_stock")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumInventoryAdjustment_stock") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumInventoryAdjustment_stock") - da.Rows(0)("sumInventoryAdjustment_stock")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumInventoryAdjustment_stock") - da.Rows(0)("sumInventoryAdjustment_stock"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b4c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumInventoryAdjustment_damage")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumInventoryAdjustment_damage") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumInventoryAdjustment_damage") - da.Rows(0)("sumInventoryAdjustment_damage")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumInventoryAdjustment_damage") - da.Rows(0)("sumInventoryAdjustment_damage"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b5c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumStockLoss_Provision")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumStockLoss_Provision") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumStockLoss_Provision") - da.Rows(0)("sumStockLoss_Provision")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumStockLoss_Provision") - da.Rows(0)("sumStockLoss_Provision"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b6c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumStockObsolescence_Provision")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumStockObsolescence_Provision") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumStockObsolescence_Provision") - da.Rows(0)("sumStockObsolescence_Provision")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumStockObsolescence_Provision") - da.Rows(0)("sumStockObsolescence_Provision"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b7c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumGWP")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumGWP") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumGWP") - da.Rows(0)("sumGWP")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumGWP") - da.Rows(0)("sumGWP"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b8c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumGWPs_Corporate")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumGWPs_Corporate") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumGWPs_Corporate") - da.Rows(0)("sumGWPs_Corporate")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumGWPs_Corporate") - da.Rows(0)("sumGWPs_Corporate"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b9c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumGWPs_Transferred")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumGWPs_Transferred") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumGWPs_Transferred") - da.Rows(0)("sumGWPs_Transferred")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumGWPs_Transferred") - da.Rows(0)("sumGWPs_Transferred"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b10c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumSellingCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumSellingCosts") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumSellingCosts") - da.Rows(0)("sumSellingCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumSellingCosts") - da.Rows(0)("sumSellingCosts"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b11c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumCreditcardscommission")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumCreditcardscommission") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumCreditcardscommission") - da.Rows(0)("sumCreditcardscommission")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumCreditcardscommission") - da.Rows(0)("sumCreditcardscommission"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b12c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumLabellingMaterial")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumLabellingMaterial") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumLabellingMaterial") - da.Rows(0)("sumLabellingMaterial")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumLabellingMaterial") - da.Rows(0)("sumLabellingMaterial"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b13c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherIncome_COSHFunding")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherIncome_COSHFunding") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherIncome_COSHFunding") - da.Rows(0)("sumOtherIncome_COSHFunding")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherIncome_COSHFunding") - da.Rows(0)("sumOtherIncome_COSHFunding"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='b14c" + strTbck + "''><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherIncomeSupplier")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherIncomeSupplier") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherIncomeSupplier") - da.Rows(0)("sumOtherIncomeSupplier")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherIncomeSupplier") - da.Rows(0)("sumOtherIncomeSupplier"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumAdjustedGrossMargin")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumAdjustedGrossMargin") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumAdjustedGrossMargin") - da.Rows(0)("sumAdjustedGrossMargin")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumAdjustedGrossMargin") - da.Rows(0)("sumAdjustedGrossMargin"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumSupplyChainCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumSupplyChainCosts") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumSupplyChainCosts") - da.Rows(0)("sumSupplyChainCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumSupplyChainCosts") - da.Rows(0)("sumSupplyChainCosts"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumTotalStoreExpenses")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumTotalStoreExpenses") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumTotalStoreExpenses") - da.Rows(0)("sumTotalStoreExpenses")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumTotalStoreExpenses") - da.Rows(0)("sumTotalStoreExpenses"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumStoreLabourCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumStoreLabourCosts") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumStoreLabourCosts") - da.Rows(0)("sumStoreLabourCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumStoreLabourCosts") - da.Rows(0)("sumStoreLabourCosts"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e1c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumGrossPay")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumGrossPay") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumGrossPay") - da.Rows(0)("sumGrossPay")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumGrossPay") - da.Rows(0)("sumGrossPay"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e2c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumTemporaryStaffCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumTemporaryStaffCosts") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumTemporaryStaffCosts") - da.Rows(0)("sumTemporaryStaffCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumTemporaryStaffCosts") - da.Rows(0)("sumTemporaryStaffCosts"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e3c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumAllowance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumAllowance") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumAllowance") - da.Rows(0)("sumAllowance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumAllowance") - da.Rows(0)("sumAllowance"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e4c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOvertime")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOvertime") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOvertime") - da.Rows(0)("sumOvertime")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOvertime") - da.Rows(0)("sumOvertime"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e5c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumLicensefee")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumLicensefee") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumLicensefee") - da.Rows(0)("sumLicensefee")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumLicensefee") - da.Rows(0)("sumLicensefee"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e6c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumBonuses_Incentives")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumBonuses_Incentives") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumBonuses_Incentives") - da.Rows(0)("sumBonuses_Incentives")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumBonuses_Incentives") - da.Rows(0)("sumBonuses_Incentives"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e7c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumBootsBrandncentives")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumBootsBrandncentives") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumBootsBrandncentives") - da.Rows(0)("sumBootsBrandncentives")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumBootsBrandncentives") - da.Rows(0)("sumBootsBrandncentives"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e8c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumSuppliersIncentive")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumSuppliersIncentive") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumSuppliersIncentive") - da.Rows(0)("sumSuppliersIncentive")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumSuppliersIncentive") - da.Rows(0)("sumSuppliersIncentive"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e9c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumProvidentFund")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumProvidentFund") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumProvidentFund") - da.Rows(0)("sumProvidentFund")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumProvidentFund") - da.Rows(0)("sumProvidentFund"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e10c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPensionCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPensionCosts") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPensionCosts") - da.Rows(0)("sumPensionCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPensionCosts") - da.Rows(0)("sumPensionCosts"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e11c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumSocialSecurityFund")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumSocialSecurityFund") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumSocialSecurityFund") - da.Rows(0)("sumSocialSecurityFund")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumSocialSecurityFund") - da.Rows(0)("sumSocialSecurityFund"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e12c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumUniforms")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumUniforms") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumUniforms") - da.Rows(0)("sumUniforms")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumUniforms") - da.Rows(0)("sumUniforms"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e13c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumEmployeeWelfare")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumEmployeeWelfare") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumEmployeeWelfare") - da.Rows(0)("sumEmployeeWelfare")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumEmployeeWelfare") - da.Rows(0)("sumEmployeeWelfare"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='e14c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherBenefitsEmployee")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherBenefitsEmployee") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherBenefitsEmployee") - da.Rows(0)("sumOtherBenefitsEmployee")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherBenefitsEmployee") - da.Rows(0)("sumOtherBenefitsEmployee"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumStorePropertyCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumStorePropertyCosts") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumStorePropertyCosts") - da.Rows(0)("sumStorePropertyCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumStorePropertyCosts") - da.Rows(0)("sumStorePropertyCosts"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f1c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPropertyRental")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPropertyRental") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPropertyRental") - da.Rows(0)("sumPropertyRental")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPropertyRental") - da.Rows(0)("sumPropertyRental"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f2c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPropertyServices")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPropertyServices") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPropertyServices") - da.Rows(0)("sumPropertyServices")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPropertyServices") - da.Rows(0)("sumPropertyServices"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f3c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPropertyFacility")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPropertyFacility") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPropertyFacility") - da.Rows(0)("sumPropertyFacility")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPropertyFacility") - da.Rows(0)("sumPropertyFacility"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f4c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPropertytaxes")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPropertytaxes") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPropertytaxes") - da.Rows(0)("sumPropertytaxes")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPropertytaxes") - da.Rows(0)("sumPropertytaxes"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f5c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumFacialtaxes")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumFacialtaxes") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumFacialtaxes") - da.Rows(0)("sumFacialtaxes")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumFacialtaxes") - da.Rows(0)("sumFacialtaxes"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f6c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPropertyInsurance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPropertyInsurance") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPropertyInsurance") - da.Rows(0)("sumPropertyInsurance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPropertyInsurance") - da.Rows(0)("sumPropertyInsurance"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f7c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumSignboard")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumSignboard") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumSignboard") - da.Rows(0)("sumSignboard")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumSignboard") - da.Rows(0)("sumSignboard"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f8c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumDiscount_Rent_Services_Facility")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumDiscount_Rent_Services_Facility") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumDiscount_Rent_Services_Facility") - da.Rows(0)("sumDiscount_Rent_Services_Facility")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumDiscount_Rent_Services_Facility") - da.Rows(0)("sumDiscount_Rent_Services_Facility"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f9c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumGPCommission")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumGPCommission") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumGPCommission") - da.Rows(0)("sumGPCommission")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumGPCommission") - da.Rows(0)("sumGPCommission"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='f10c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumAmortizationofLeaseRight")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumAmortizationofLeaseRight") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumAmortizationofLeaseRight") - da.Rows(0)("sumAmortizationofLeaseRight")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumAmortizationofLeaseRight") - da.Rows(0)("sumAmortizationofLeaseRight"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumDepreciation")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumDepreciation") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumDepreciation") - da.Rows(0)("sumDepreciation")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumDepreciation") - da.Rows(0)("sumDepreciation"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='g1c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumDepreciationofShortLeaseBuilding")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumDepreciationofShortLeaseBuilding") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumDepreciationofShortLeaseBuilding") - da.Rows(0)("sumDepreciationofShortLeaseBuilding")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumDepreciationofShortLeaseBuilding") - da.Rows(0)("sumDepreciationofShortLeaseBuilding"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='g2c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumDepreciationofComputerHardware")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumDepreciationofComputerHardware") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumDepreciationofComputerHardware") - da.Rows(0)("sumDepreciationofComputerHardware")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumDepreciationofComputerHardware") - da.Rows(0)("sumDepreciationofComputerHardware"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='g3c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumDepreciationofFixturesFittings")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumDepreciationofFixturesFittings") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumDepreciationofFixturesFittings") - da.Rows(0)("sumDepreciationofFixturesFittings")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumDepreciationofFixturesFittings") - da.Rows(0)("sumDepreciationofFixturesFittings"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='g4c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumDepreciationofComputerSoftware")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumDepreciationofComputerSoftware") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumDepreciationofComputerSoftware") - da.Rows(0)("sumDepreciationofComputerSoftware")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumDepreciationofComputerSoftware") - da.Rows(0)("sumDepreciationofComputerSoftware"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='g5c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumDepreciationofOfficeEquipment")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumDepreciationofOfficeEquipment") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumDepreciationofOfficeEquipment") - da.Rows(0)("sumDepreciationofOfficeEquipment")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumDepreciationofOfficeEquipment") - da.Rows(0)("sumDepreciationofOfficeEquipment"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherStoreCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherStoreCosts") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherStoreCosts") - da.Rows(0)("sumOtherStoreCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherStoreCosts") - da.Rows(0)("sumOtherStoreCosts"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")

        strHtml.Append("<TR id='h1c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumServiceChargesandOtherFees")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumServiceChargesandOtherFees") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumServiceChargesandOtherFees") - da.Rows(0)("sumServiceChargesandOtherFees")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumServiceChargesandOtherFees") - da.Rows(0)("sumServiceChargesandOtherFees"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h2c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumBankCharges")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumBankCharges") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumBankCharges") - da.Rows(0)("sumBankCharges")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumBankCharges") - da.Rows(0)("sumBankCharges"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h3c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumCashCollectionCharge")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumCashCollectionCharge") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumCashCollectionCharge") - da.Rows(0)("sumCashCollectionCharge")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumCashCollectionCharge") - da.Rows(0)("sumCashCollectionCharge"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h4c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumCleaning")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumCleaning") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumCleaning") - da.Rows(0)("sumCleaning")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumCleaning") - da.Rows(0)("sumCleaning"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h5c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumSecurityGuards")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumSecurityGuards") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumSecurityGuards") - da.Rows(0)("sumSecurityGuards")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumSecurityGuards") - da.Rows(0)("sumSecurityGuards"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h6c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumCarriage")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumCarriage") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumCarriage") - da.Rows(0)("sumCarriage")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumCarriage") - da.Rows(0)("sumCarriage"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h7c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumLicenceFees")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumLicenceFees") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumLicenceFees") - da.Rows(0)("sumLicenceFees")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumLicenceFees") - da.Rows(0)("sumLicenceFees"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h8c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherServicesCharge")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherServicesCharge") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherServicesCharge") - da.Rows(0)("sumOtherServicesCharge")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherServicesCharge") - da.Rows(0)("sumOtherServicesCharge"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h9c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherFees")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherFees") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherFees") - da.Rows(0)("sumOtherFees")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherFees") - da.Rows(0)("sumOtherFees"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h10c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumUtilities")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumUtilities") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumUtilities") - da.Rows(0)("sumUtilities")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumUtilities") - da.Rows(0)("sumUtilities"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h11c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumWater")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumWater") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumWater") - da.Rows(0)("sumWater")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumWater") - da.Rows(0)("sumWater"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h12c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumGas_Electric")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumGas_Electric") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumGas_Electric") - da.Rows(0)("sumGas_Electric")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumGas_Electric") - da.Rows(0)("sumGas_Electric"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h13c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumAirCond_Addition")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumAirCond_Addition") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumAirCond_Addition") - da.Rows(0)("sumAirCond_Addition")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumAirCond_Addition") - da.Rows(0)("sumAirCond_Addition"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h14c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumRepairandMaintenance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumRepairandMaintenance") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumRepairandMaintenance") - da.Rows(0)("sumRepairandMaintenance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumRepairandMaintenance") - da.Rows(0)("sumRepairandMaintenance"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h15c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumRMOther_Fix")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumRMOther_Fix") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumRMOther_Fix") - da.Rows(0)("sumRMOther_Fix")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumRMOther_Fix") - da.Rows(0)("sumRMOther_Fix"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h16c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumRMOther_Unplan")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumRMOther_Unplan") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumRMOther_Unplan") - da.Rows(0)("sumRMOther_Unplan")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumRMOther_Unplan") - da.Rows(0)("sumRMOther_Unplan"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h17c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumRMComputer_Fix")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumRMComputer_Fix") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumRMComputer_Fix") - da.Rows(0)("sumRMComputer_Fix")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumRMComputer_Fix") - da.Rows(0)("sumRMComputer_Fix"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h18c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumRMComputer_Unplan")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumRMComputer_Unplan") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumRMComputer_Unplan") - da.Rows(0)("sumRMComputer_Unplan")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumRMComputer_Unplan") - da.Rows(0)("sumRMComputer_Unplan"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h19c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumProfessionalFee")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumProfessionalFee") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumProfessionalFee") - da.Rows(0)("sumProfessionalFee")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumProfessionalFee") - da.Rows(0)("sumProfessionalFee"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h20c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumMarketingResearch")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumMarketingResearch") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumMarketingResearch") - da.Rows(0)("sumMarketingResearch")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumMarketingResearch") - da.Rows(0)("sumMarketingResearch"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h21c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherFee")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherFee") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherFee") - da.Rows(0)("sumOtherFee")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherFee") - da.Rows(0)("sumOtherFee"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h22c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumEquipment_MaterailandSupplies")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumEquipment_MaterailandSupplies") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumEquipment_MaterailandSupplies") - da.Rows(0)("sumEquipment_MaterailandSupplies")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumEquipment_MaterailandSupplies") - da.Rows(0)("sumEquipment_MaterailandSupplies"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h23c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPrintingandStationery")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPrintingandStationery") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPrintingandStationery") - da.Rows(0)("sumPrintingandStationery")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPrintingandStationery") - da.Rows(0)("sumPrintingandStationery"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h24c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumSuppliesExpenses")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumSuppliesExpenses") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumSuppliesExpenses") - da.Rows(0)("sumSuppliesExpenses")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumSuppliesExpenses") - da.Rows(0)("sumSuppliesExpenses"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h25c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumEquipment")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumEquipment") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumEquipment") - da.Rows(0)("sumEquipment")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumEquipment") - da.Rows(0)("sumEquipment"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h26c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumShopfitting")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumShopfitting") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumShopfitting") - da.Rows(0)("sumShopfitting")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumShopfitting") - da.Rows(0)("sumShopfitting"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h27c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPackagingandOtherMaterial")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPackagingandOtherMaterial") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPackagingandOtherMaterial") - da.Rows(0)("sumPackagingandOtherMaterial")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPackagingandOtherMaterial") - da.Rows(0)("sumPackagingandOtherMaterial"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h28c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumBusinessTravelExpenses")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumBusinessTravelExpenses") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumBusinessTravelExpenses") - da.Rows(0)("sumBusinessTravelExpenses")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumBusinessTravelExpenses") - da.Rows(0)("sumBusinessTravelExpenses"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h29c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumCarParkingandOthers")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumCarParkingandOthers") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumCarParkingandOthers") - da.Rows(0)("sumCarParkingandOthers")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumCarParkingandOthers") - da.Rows(0)("sumCarParkingandOthers"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h30c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumTravel")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumTravel") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumTravel") - da.Rows(0)("sumTravel")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumTravel") - da.Rows(0)("sumTravel"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h31c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumAccomodation")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumAccomodation") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumAccomodation") - da.Rows(0)("sumAccomodation")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumAccomodation") - da.Rows(0)("sumAccomodation"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h32c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumMealandEntertainment")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumMealandEntertainment") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumMealandEntertainment") - da.Rows(0)("sumMealandEntertainment")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumMealandEntertainment") - da.Rows(0)("sumMealandEntertainment"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h33c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumInsurance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumInsurance") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumInsurance") - da.Rows(0)("sumInsurance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumInsurance") - da.Rows(0)("sumInsurance"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h34c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumAllRiskInsurance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumAllRiskInsurance") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumAllRiskInsurance") - da.Rows(0)("sumAllRiskInsurance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumAllRiskInsurance") - da.Rows(0)("sumAllRiskInsurance"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h35c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumHealthandLifeInsurance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumHealthandLifeInsurance") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumHealthandLifeInsurance") - da.Rows(0)("sumHealthandLifeInsurance")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumHealthandLifeInsurance") - da.Rows(0)("sumHealthandLifeInsurance"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h36c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPenaltyandTaxation")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPenaltyandTaxation") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPenaltyandTaxation") - da.Rows(0)("sumPenaltyandTaxation")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPenaltyandTaxation") - da.Rows(0)("sumPenaltyandTaxation"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h37c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumTaxation")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumTaxation") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumTaxation") - da.Rows(0)("sumTaxation")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumTaxation") - da.Rows(0)("sumTaxation"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h38c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPenalty")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPenalty") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPenalty") - da.Rows(0)("sumPenalty")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPenalty") - da.Rows(0)("sumPenalty"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h39c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherRelatedStaffCost")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherRelatedStaffCost") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherRelatedStaffCost") - da.Rows(0)("sumOtherRelatedStaffCost")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherRelatedStaffCost") - da.Rows(0)("sumOtherRelatedStaffCost"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h40c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumStaffConferenceandTraining")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumStaffConferenceandTraining") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumStaffConferenceandTraining") - da.Rows(0)("sumStaffConferenceandTraining")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumStaffConferenceandTraining") - da.Rows(0)("sumStaffConferenceandTraining"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h41c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumTraining")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumTraining") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumTraining") - da.Rows(0)("sumTraining")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumTraining") - da.Rows(0)("sumTraining"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h42c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumCommunication")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumCommunication") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumCommunication") - da.Rows(0)("sumCommunication")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumCommunication") - da.Rows(0)("sumCommunication"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h43c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumTelephoneCalls_Faxes")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumTelephoneCalls_Faxes") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumTelephoneCalls_Faxes") - da.Rows(0)("sumTelephoneCalls_Faxes")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumTelephoneCalls_Faxes") - da.Rows(0)("sumTelephoneCalls_Faxes"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h44c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPostageandCourier")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPostageandCourier") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPostageandCourier") - da.Rows(0)("sumPostageandCourier")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPostageandCourier") - da.Rows(0)("sumPostageandCourier"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h45c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumOtherExpenses")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumOtherExpenses") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumOtherExpenses") - da.Rows(0)("sumOtherExpenses")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumOtherExpenses") - da.Rows(0)("sumOtherExpenses"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h46c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumSample_Tester")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumSample_Tester") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumSample_Tester") - da.Rows(0)("sumSample_Tester")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumSample_Tester") - da.Rows(0)("sumSample_Tester"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h47c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumPreopeningCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumPreopeningCosts") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumPreopeningCosts") - da.Rows(0)("sumPreopeningCosts")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumPreopeningCosts") - da.Rows(0)("sumPreopeningCosts"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h48c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumLossonClaim")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumLossonClaim") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumLossonClaim") - da.Rows(0)("sumLossonClaim")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumLossonClaim") - da.Rows(0)("sumLossonClaim"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h49c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumCashOvertage_Shortagefromsales")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumCashOvertage_Shortagefromsales") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumCashOvertage_Shortagefromsales") - da.Rows(0)("sumCashOvertage_Shortagefromsales")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumCashOvertage_Shortagefromsales") - da.Rows(0)("sumCashOvertage_Shortagefromsales"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR id='h50c" + strTbck + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumMiscellenousandOther")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumMiscellenousandOther") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumMiscellenousandOther") - da.Rows(0)("sumMiscellenousandOther")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumMiscellenousandOther") - da.Rows(0)("sumMiscellenousandOther"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(da.Rows(0)("sumStoreTradingProfit__Loss")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((da.Rows(0)("sumStoreTradingProfit__Loss") / da.Rows(0)("sumTotalRevenue")) * 100).ToString + "%</div></TD><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumStoreTradingProfit__Loss") - da.Rows(0)("sumStoreTradingProfit__Loss")).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2PercenNoneZero(e.Item.DataItem("sumStoreTradingProfit__Loss") - da.Rows(0)("sumStoreTradingProfit__Loss"), e.Item.DataItem("sumTotalRevenue") - da.Rows(0)("sumTotalRevenue")).ToString + "%</div></TD></TR>")
        strHtml.Append("</TABLE>")
        CType(e.Item.FindControl("label2"), Label).Text = strHtml.ToString


        LbSumTotalRevenue.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumTotalRevenue.Text) + e.Item.DataItem("sumTotalRevenue")).ToString
        LbSumRETAIL_TESPIncome.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumRETAIL_TESPIncome.Text) + e.Item.DataItem("sumRETAIL_TESPIncome")).ToString
        LbSumOtherRevenue.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherRevenue.Text) + e.Item.DataItem("sumOtherRevenue")).ToString
        LbSumCostofGoodSold.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumCostofGoodSold.Text) + e.Item.DataItem("sumCostofGoodSold")).ToString
        LbSumGrossProfit.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumGrossProfit.Text) + e.Item.DataItem("sumGrossProfit")).ToString
        'LbSumGrossProfit_percent.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumGrossProfit_percent.Text) + e.Item.DataItem("sumGrossProfit_percent")).ToString
        LbSumMarginAdjustments.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumMarginAdjustments.Text) + e.Item.DataItem("sumMarginAdjustments")).ToString
        LbSumShipping.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumShipping.Text) + e.Item.DataItem("sumShipping")).ToString
        LbSumStockLossandObsolescence.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumStockLossandObsolescence.Text) + e.Item.DataItem("sumStockLossandObsolescence")).ToString
        LbSumInventoryAdjustment_stock.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumInventoryAdjustment_stock.Text) + e.Item.DataItem("sumInventoryAdjustment_stock")).ToString
        LbSumInventoryAdjustment_damage.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumInventoryAdjustment_damage.Text) + e.Item.DataItem("sumInventoryAdjustment_damage")).ToString
        LbSumStockLoss_Provision.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumStockLoss_Provision.Text) + e.Item.DataItem("sumStockLoss_Provision")).ToString
        LbSumStockObsolescence_Provision.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumStockObsolescence_Provision.Text) + e.Item.DataItem("sumStockObsolescence_Provision")).ToString
        LbSumGWP.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumGWP.Text) + e.Item.DataItem("sumGWP")).ToString
        LbSumGWPs_Corporate.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumGWPs_Corporate.Text) + e.Item.DataItem("sumGWPs_Corporate")).ToString
        LbSumGWPs_Transferred.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumGWPs_Transferred.Text) + e.Item.DataItem("sumGWPs_Transferred")).ToString
        LbSumSellingCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumSellingCosts.Text) + e.Item.DataItem("sumSellingCosts")).ToString
        LbSumCreditcardscommission.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumCreditcardscommission.Text) + e.Item.DataItem("sumCreditcardscommission")).ToString
        LbSumLabellingMaterial.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumLabellingMaterial.Text) + e.Item.DataItem("sumLabellingMaterial")).ToString
        LbSumOtherIncome_COSHFunding.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherIncome_COSHFunding.Text) + e.Item.DataItem("sumOtherIncome_COSHFunding")).ToString
        LbSumOtherIncomeSupplier.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherIncomeSupplier.Text) + e.Item.DataItem("sumOtherIncomeSupplier")).ToString
        LbSumAdjustedGrossMargin.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumAdjustedGrossMargin.Text) + e.Item.DataItem("sumAdjustedGrossMargin")).ToString
        LbSumSupplyChainCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumSupplyChainCosts.Text) + e.Item.DataItem("sumSupplyChainCosts")).ToString
        LbSumTotalStoreExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumTotalStoreExpenses.Text) + e.Item.DataItem("sumTotalStoreExpenses")).ToString
        LbSumStoreLabourCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumStoreLabourCosts.Text) + e.Item.DataItem("sumStoreLabourCosts")).ToString
        LbSumGrossPay.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumGrossPay.Text) + e.Item.DataItem("sumGrossPay")).ToString
        LbSumTemporaryStaffCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumTemporaryStaffCosts.Text) + e.Item.DataItem("sumTemporaryStaffCosts")).ToString
        LbSumAllowance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumAllowance.Text) + e.Item.DataItem("sumAllowance")).ToString
        LbSumOvertime.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOvertime.Text) + e.Item.DataItem("sumOvertime")).ToString
        LbSumLicensefee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumLicensefee.Text) + e.Item.DataItem("sumLicensefee")).ToString
        LbSumBonuses_Incentives.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumBonuses_Incentives.Text) + e.Item.DataItem("sumBonuses_Incentives")).ToString
        LbSumBootsBrandncentives.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumBootsBrandncentives.Text) + e.Item.DataItem("sumBootsBrandncentives")).ToString
        LbSumSuppliersIncentive.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumSuppliersIncentive.Text) + e.Item.DataItem("sumSuppliersIncentive")).ToString
        LbSumProvidentFund.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumProvidentFund.Text) + e.Item.DataItem("sumProvidentFund")).ToString
        LbSumPensionCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPensionCosts.Text) + e.Item.DataItem("sumPensionCosts")).ToString
        LbSumSocialSecurityFund.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumSocialSecurityFund.Text) + e.Item.DataItem("sumSocialSecurityFund")).ToString
        LbSumUniforms.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumUniforms.Text) + e.Item.DataItem("sumUniforms")).ToString
        LbSumEmployeeWelfare.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumEmployeeWelfare.Text) + e.Item.DataItem("sumEmployeeWelfare")).ToString
        LbSumOtherBenefitsEmployee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherBenefitsEmployee.Text) + e.Item.DataItem("sumOtherBenefitsEmployee")).ToString
        LbSumStorePropertyCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumStorePropertyCosts.Text) + e.Item.DataItem("sumStorePropertyCosts")).ToString
        LbSumPropertyRental.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPropertyRental.Text) + e.Item.DataItem("sumPropertyRental")).ToString
        LbSumPropertyServices.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPropertyServices.Text) + e.Item.DataItem("sumPropertyServices")).ToString
        LbSumPropertyFacility.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPropertyFacility.Text) + e.Item.DataItem("sumPropertyFacility")).ToString
        LbSumPropertytaxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPropertytaxes.Text) + e.Item.DataItem("sumPropertytaxes")).ToString
        LbSumFacialtaxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumFacialtaxes.Text) + e.Item.DataItem("sumFacialtaxes")).ToString
        LbSumPropertyInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPropertyInsurance.Text) + e.Item.DataItem("sumPropertyInsurance")).ToString
        LbSumSignboard.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumSignboard.Text) + e.Item.DataItem("sumSignboard")).ToString
        LbSumDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumDiscount_Rent_Services_Facility.Text) + e.Item.DataItem("sumDiscount_Rent_Services_Facility")).ToString
        LbSumGPCommission.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumGPCommission.Text) + e.Item.DataItem("sumGPCommission")).ToString
        LbSumAmortizationofLeaseRight.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumAmortizationofLeaseRight.Text) + e.Item.DataItem("sumAmortizationofLeaseRight")).ToString
        LbSumDepreciation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumDepreciation.Text) + e.Item.DataItem("sumDepreciation")).ToString
        LbSumDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumDepreciationofShortLeaseBuilding.Text) + e.Item.DataItem("sumDepreciationofShortLeaseBuilding")).ToString
        LbSumDepreciationofComputerHardware.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumDepreciationofComputerHardware.Text) + e.Item.DataItem("sumDepreciationofComputerHardware")).ToString
        LbSumDepreciationofFixturesFittings.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumDepreciationofFixturesFittings.Text) + e.Item.DataItem("sumDepreciationofFixturesFittings")).ToString
        LbSumDepreciationofComputerSoftware.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumDepreciationofComputerSoftware.Text) + e.Item.DataItem("sumDepreciationofComputerSoftware")).ToString
        LbSumDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumDepreciationofOfficeEquipment.Text) + e.Item.DataItem("sumDepreciationofOfficeEquipment")).ToString
        LbSumOtherStoreCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherStoreCosts.Text) + e.Item.DataItem("sumOtherStoreCosts")).ToString
        LbSumServiceChargesandOtherFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumServiceChargesandOtherFees.Text) + e.Item.DataItem("sumServiceChargesandOtherFees")).ToString
        LbSumBankCharges.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumBankCharges.Text) + e.Item.DataItem("sumBankCharges")).ToString
        LbSumCashCollectionCharge.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumCashCollectionCharge.Text) + e.Item.DataItem("sumCashCollectionCharge")).ToString
        LbSumCleaning.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumCleaning.Text) + e.Item.DataItem("sumCleaning")).ToString
        LbSumSecurityGuards.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumSecurityGuards.Text) + e.Item.DataItem("sumSecurityGuards")).ToString
        LbSumCarriage.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumCarriage.Text) + e.Item.DataItem("sumCarriage")).ToString
        LbSumLicenceFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumLicenceFees.Text) + e.Item.DataItem("sumLicenceFees")).ToString
        LbSumOtherServicesCharge.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherServicesCharge.Text) + e.Item.DataItem("sumOtherServicesCharge")).ToString
        LbSumOtherFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherFees.Text) + e.Item.DataItem("sumOtherFees")).ToString
        LbSumUtilities.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumUtilities.Text) + e.Item.DataItem("sumUtilities")).ToString
        LbSumWater.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumWater.Text) + e.Item.DataItem("sumWater")).ToString
        LbSumGas_Electric.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumGas_Electric.Text) + e.Item.DataItem("sumGas_Electric")).ToString
        LbSumAirCond_Addition.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumAirCond_Addition.Text) + e.Item.DataItem("sumAirCond_Addition")).ToString
        LbSumRepairandMaintenance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumRepairandMaintenance.Text) + e.Item.DataItem("sumRepairandMaintenance")).ToString
        LbSumRMOther_Fix.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumRMOther_Fix.Text) + e.Item.DataItem("sumRMOther_Fix")).ToString
        LbSumRMOther_Unplan.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumRMOther_Unplan.Text) + e.Item.DataItem("sumRMOther_Unplan")).ToString
        LbSumRMComputer_Fix.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumRMComputer_Fix.Text) + e.Item.DataItem("sumRMComputer_Fix")).ToString
        LbSumRMComputer_Unplan.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumRMComputer_Unplan.Text) + e.Item.DataItem("sumRMComputer_Unplan")).ToString
        LbSumProfessionalFee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumProfessionalFee.Text) + e.Item.DataItem("sumProfessionalFee")).ToString
        LbSumMarketingResearch.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumMarketingResearch.Text) + e.Item.DataItem("sumMarketingResearch")).ToString
        LbSumOtherFee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherFee.Text) + e.Item.DataItem("sumOtherFee")).ToString
        LbSumEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumEquipment_MaterailandSupplies.Text) + e.Item.DataItem("sumEquipment_MaterailandSupplies")).ToString
        LbSumPrintingandStationery.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPrintingandStationery.Text) + e.Item.DataItem("sumPrintingandStationery")).ToString
        LbSumSuppliesExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumSuppliesExpenses.Text) + e.Item.DataItem("sumSuppliesExpenses")).ToString
        LbSumEquipment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumEquipment.Text) + e.Item.DataItem("sumEquipment")).ToString
        LbSumShopfitting.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumShopfitting.Text) + e.Item.DataItem("sumShopfitting")).ToString
        LbSumPackagingandOtherMaterial.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPackagingandOtherMaterial.Text) + e.Item.DataItem("sumPackagingandOtherMaterial")).ToString
        LbSumBusinessTravelExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumBusinessTravelExpenses.Text) + e.Item.DataItem("sumBusinessTravelExpenses")).ToString
        LbSumCarParkingandOthers.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumCarParkingandOthers.Text) + e.Item.DataItem("sumCarParkingandOthers")).ToString
        LbSumTravel.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumTravel.Text) + e.Item.DataItem("sumTravel")).ToString
        LbSumAccomodation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumAccomodation.Text) + e.Item.DataItem("sumAccomodation")).ToString
        LbSumMealandEntertainment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumMealandEntertainment.Text) + e.Item.DataItem("sumMealandEntertainment")).ToString
        LbSumInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumInsurance.Text) + e.Item.DataItem("sumInsurance")).ToString
        LbSumAllRiskInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumAllRiskInsurance.Text) + e.Item.DataItem("sumAllRiskInsurance")).ToString
        LbSumHealthandLifeInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumHealthandLifeInsurance.Text) + e.Item.DataItem("sumHealthandLifeInsurance")).ToString
        LbSumPenaltyandTaxation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPenaltyandTaxation.Text) + e.Item.DataItem("sumPenaltyandTaxation")).ToString
        LbSumTaxation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumTaxation.Text) + e.Item.DataItem("sumTaxation")).ToString
        LbSumPenalty.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPenalty.Text) + e.Item.DataItem("sumPenalty")).ToString
        LbSumOtherRelatedStaffCost.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherRelatedStaffCost.Text) + e.Item.DataItem("sumOtherRelatedStaffCost")).ToString
        LbSumStaffConferenceandTraining.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumStaffConferenceandTraining.Text) + e.Item.DataItem("sumStaffConferenceandTraining")).ToString
        LbSumTraining.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumTraining.Text) + e.Item.DataItem("sumTraining")).ToString
        LbSumCommunication.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumCommunication.Text) + e.Item.DataItem("sumCommunication")).ToString
        LbSumTelephoneCalls_Faxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumTelephoneCalls_Faxes.Text) + e.Item.DataItem("sumTelephoneCalls_Faxes")).ToString
        LbSumPostageandCourier.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPostageandCourier.Text) + e.Item.DataItem("sumPostageandCourier")).ToString
        LbSumOtherExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumOtherExpenses.Text) + e.Item.DataItem("sumOtherExpenses")).ToString
        LbSumSample_Tester.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumSample_Tester.Text) + e.Item.DataItem("sumSample_Tester")).ToString
        LbSumPreopeningCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumPreopeningCosts.Text) + e.Item.DataItem("sumPreopeningCosts")).ToString
        LbSumLossonClaim.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumLossonClaim.Text) + e.Item.DataItem("sumLossonClaim")).ToString
        LbSumCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumCashOvertage_Shortagefromsales.Text) + e.Item.DataItem("sumCashOvertage_Shortagefromsales")).ToString
        LbSumMiscellenousandOther.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumMiscellenousandOther.Text) + e.Item.DataItem("sumMiscellenousandOther")).ToString
        LbSumStoreTradingProfit__Loss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumStoreTradingProfit__Loss.Text) + e.Item.DataItem("sumStoreTradingProfit__Loss")).ToString
        'LbSumTradingProfit__Loss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbSumTradingProfit__Loss.Text) + e.Item.DataItem("sumTradingProfit__Loss")).ToString

        LbFullTgs.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbFullTgs.Text) + e.Item.DataItem("sumtotalarea")).ToString
        LbFullTss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbFullTss.Text) + e.Item.DataItem("sumsalearea")).ToString
        LbNost.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbNost.Text) + e.Item.DataItem("cnum")).ToString

        If da.Rows.Count > 0 Then
            LbBKKSumTotalRevenue.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumTotalRevenue.Text) + da.Rows(0)("sumTotalRevenue")).ToString
            LbBKKSumRETAIL_TESPIncome.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumRETAIL_TESPIncome.Text) + da.Rows(0)("sumRETAIL_TESPIncome")).ToString
            LbBKKSumOtherRevenue.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherRevenue.Text) + da.Rows(0)("sumOtherRevenue")).ToString
            LbBKKSumCostofGoodSold.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumCostofGoodSold.Text) + da.Rows(0)("sumCostofGoodSold")).ToString
            LbBKKSumGrossProfit.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumGrossProfit.Text) + da.Rows(0)("sumGrossProfit")).ToString
            'LbBKKSumGrossProfit_percent.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumGrossProfit_percent.Text) + da.Rows(0)("sumGrossProfit_percent")).ToString
            LbBKKSumMarginAdjustments.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumMarginAdjustments.Text) + da.Rows(0)("sumMarginAdjustments")).ToString
            LbBKKSumShipping.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumShipping.Text) + da.Rows(0)("sumShipping")).ToString
            LbBKKSumStockLossandObsolescence.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumStockLossandObsolescence.Text) + da.Rows(0)("sumStockLossandObsolescence")).ToString
            LbBKKSumInventoryAdjustment_stock.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumInventoryAdjustment_stock.Text) + da.Rows(0)("sumInventoryAdjustment_stock")).ToString
            LbBKKSumInventoryAdjustment_damage.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumInventoryAdjustment_damage.Text) + da.Rows(0)("sumInventoryAdjustment_damage")).ToString
            LbBKKSumStockLoss_Provision.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumStockLoss_Provision.Text) + da.Rows(0)("sumStockLoss_Provision")).ToString
            LbBKKSumStockObsolescence_Provision.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumStockObsolescence_Provision.Text) + da.Rows(0)("sumStockObsolescence_Provision")).ToString
            LbBKKSumGWP.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumGWP.Text) + da.Rows(0)("sumGWP")).ToString
            LbBKKSumGWPs_Corporate.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumGWPs_Corporate.Text) + da.Rows(0)("sumGWPs_Corporate")).ToString
            LbBKKSumGWPs_Transferred.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumGWPs_Transferred.Text) + da.Rows(0)("sumGWPs_Transferred")).ToString
            LbBKKSumSellingCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumSellingCosts.Text) + da.Rows(0)("sumSellingCosts")).ToString
            LbBKKSumCreditcardscommission.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumCreditcardscommission.Text) + da.Rows(0)("sumCreditcardscommission")).ToString
            LbBKKSumLabellingMaterial.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumLabellingMaterial.Text) + da.Rows(0)("sumLabellingMaterial")).ToString
            LbBKKSumOtherIncome_COSHFunding.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherIncome_COSHFunding.Text) + da.Rows(0)("sumOtherIncome_COSHFunding")).ToString
            LbBKKSumOtherIncomeSupplier.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherIncomeSupplier.Text) + da.Rows(0)("sumOtherIncomeSupplier")).ToString
            LbBKKSumAdjustedGrossMargin.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumAdjustedGrossMargin.Text) + da.Rows(0)("sumAdjustedGrossMargin")).ToString
            LbBKKSumSupplyChainCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumSupplyChainCosts.Text) + da.Rows(0)("sumSupplyChainCosts")).ToString
            LbBKKSumTotalStoreExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumTotalStoreExpenses.Text) + da.Rows(0)("sumTotalStoreExpenses")).ToString
            LbBKKSumStoreLabourCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumStoreLabourCosts.Text) + da.Rows(0)("sumStoreLabourCosts")).ToString
            LbBKKSumGrossPay.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumGrossPay.Text) + da.Rows(0)("sumGrossPay")).ToString
            LbBKKSumTemporaryStaffCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumTemporaryStaffCosts.Text) + da.Rows(0)("sumTemporaryStaffCosts")).ToString
            LbBKKSumAllowance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumAllowance.Text) + da.Rows(0)("sumAllowance")).ToString
            LbBKKSumOvertime.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOvertime.Text) + da.Rows(0)("sumOvertime")).ToString
            LbBKKSumLicensefee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumLicensefee.Text) + da.Rows(0)("sumLicensefee")).ToString
            LbBKKSumBonuses_Incentives.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumBonuses_Incentives.Text) + da.Rows(0)("sumBonuses_Incentives")).ToString
            LbBKKSumBootsBrandncentives.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumBootsBrandncentives.Text) + da.Rows(0)("sumBootsBrandncentives")).ToString
            LbBKKSumSuppliersIncentive.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumSuppliersIncentive.Text) + da.Rows(0)("sumSuppliersIncentive")).ToString
            LbBKKSumProvidentFund.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumProvidentFund.Text) + da.Rows(0)("sumProvidentFund")).ToString
            LbBKKSumPensionCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPensionCosts.Text) + da.Rows(0)("sumPensionCosts")).ToString
            LbBKKSumSocialSecurityFund.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumSocialSecurityFund.Text) + da.Rows(0)("sumSocialSecurityFund")).ToString
            LbBKKSumUniforms.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumUniforms.Text) + da.Rows(0)("sumUniforms")).ToString
            LbBKKSumEmployeeWelfare.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumEmployeeWelfare.Text) + da.Rows(0)("sumEmployeeWelfare")).ToString
            LbBKKSumOtherBenefitsEmployee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherBenefitsEmployee.Text) + da.Rows(0)("sumOtherBenefitsEmployee")).ToString
            LbBKKSumStorePropertyCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumStorePropertyCosts.Text) + da.Rows(0)("sumStorePropertyCosts")).ToString
            LbBKKSumPropertyRental.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPropertyRental.Text) + da.Rows(0)("sumPropertyRental")).ToString
            LbBKKSumPropertyServices.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPropertyServices.Text) + da.Rows(0)("sumPropertyServices")).ToString
            LbBKKSumPropertyFacility.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPropertyFacility.Text) + da.Rows(0)("sumPropertyFacility")).ToString
            LbBKKSumPropertytaxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPropertytaxes.Text) + da.Rows(0)("sumPropertytaxes")).ToString
            LbBKKSumFacialtaxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumFacialtaxes.Text) + da.Rows(0)("sumFacialtaxes")).ToString
            LbBKKSumPropertyInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPropertyInsurance.Text) + da.Rows(0)("sumPropertyInsurance")).ToString
            LbBKKSumSignboard.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumSignboard.Text) + da.Rows(0)("sumSignboard")).ToString
            LbBKKSumDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumDiscount_Rent_Services_Facility.Text) + da.Rows(0)("sumDiscount_Rent_Services_Facility")).ToString
            LbBKKSumGPCommission.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumGPCommission.Text) + da.Rows(0)("sumGPCommission")).ToString
            LbBKKSumAmortizationofLeaseRight.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumAmortizationofLeaseRight.Text) + da.Rows(0)("sumAmortizationofLeaseRight")).ToString
            LbBKKSumDepreciation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumDepreciation.Text) + da.Rows(0)("sumDepreciation")).ToString
            LbBKKSumDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumDepreciationofShortLeaseBuilding.Text) + da.Rows(0)("sumDepreciationofShortLeaseBuilding")).ToString
            LbBKKSumDepreciationofComputerHardware.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumDepreciationofComputerHardware.Text) + da.Rows(0)("sumDepreciationofComputerHardware")).ToString
            LbBKKSumDepreciationofFixturesFittings.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumDepreciationofFixturesFittings.Text) + da.Rows(0)("sumDepreciationofFixturesFittings")).ToString
            LbBKKSumDepreciationofComputerSoftware.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumDepreciationofComputerSoftware.Text) + da.Rows(0)("sumDepreciationofComputerSoftware")).ToString
            LbBKKSumDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumDepreciationofOfficeEquipment.Text) + da.Rows(0)("sumDepreciationofOfficeEquipment")).ToString
            LbBKKSumOtherStoreCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherStoreCosts.Text) + da.Rows(0)("sumOtherStoreCosts")).ToString
            LbBKKSumServiceChargesandOtherFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumServiceChargesandOtherFees.Text) + da.Rows(0)("sumServiceChargesandOtherFees")).ToString
            LbBKKSumBankCharges.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumBankCharges.Text) + da.Rows(0)("sumBankCharges")).ToString
            LbBKKSumCashCollectionCharge.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumCashCollectionCharge.Text) + da.Rows(0)("sumCashCollectionCharge")).ToString
            LbBKKSumCleaning.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumCleaning.Text) + da.Rows(0)("sumCleaning")).ToString
            LbBKKSumSecurityGuards.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumSecurityGuards.Text) + da.Rows(0)("sumSecurityGuards")).ToString
            LbBKKSumCarriage.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumCarriage.Text) + da.Rows(0)("sumCarriage")).ToString
            LbBKKSumLicenceFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumLicenceFees.Text) + da.Rows(0)("sumLicenceFees")).ToString
            LbBKKSumOtherServicesCharge.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherServicesCharge.Text) + da.Rows(0)("sumOtherServicesCharge")).ToString
            LbBKKSumOtherFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherFees.Text) + da.Rows(0)("sumOtherFees")).ToString
            LbBKKSumUtilities.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumUtilities.Text) + da.Rows(0)("sumUtilities")).ToString
            LbBKKSumWater.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumWater.Text) + da.Rows(0)("sumWater")).ToString
            LbBKKSumGas_Electric.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumGas_Electric.Text) + da.Rows(0)("sumGas_Electric")).ToString
            LbBKKSumAirCond_Addition.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumAirCond_Addition.Text) + da.Rows(0)("sumAirCond_Addition")).ToString
            LbBKKSumRepairandMaintenance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumRepairandMaintenance.Text) + da.Rows(0)("sumRepairandMaintenance")).ToString
            LbBKKSumRMOther_Fix.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumRMOther_Fix.Text) + da.Rows(0)("sumRMOther_Fix")).ToString
            LbBKKSumRMOther_Unplan.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumRMOther_Unplan.Text) + da.Rows(0)("sumRMOther_Unplan")).ToString
            LbBKKSumRMComputer_Fix.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumRMComputer_Fix.Text) + da.Rows(0)("sumRMComputer_Fix")).ToString
            LbBKKSumRMComputer_Unplan.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumRMComputer_Unplan.Text) + da.Rows(0)("sumRMComputer_Unplan")).ToString
            LbBKKSumProfessionalFee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumProfessionalFee.Text) + da.Rows(0)("sumProfessionalFee")).ToString
            LbBKKSumMarketingResearch.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumMarketingResearch.Text) + da.Rows(0)("sumMarketingResearch")).ToString
            LbBKKSumOtherFee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherFee.Text) + da.Rows(0)("sumOtherFee")).ToString
            LbBKKSumEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumEquipment_MaterailandSupplies.Text) + da.Rows(0)("sumEquipment_MaterailandSupplies")).ToString
            LbBKKSumPrintingandStationery.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPrintingandStationery.Text) + da.Rows(0)("sumPrintingandStationery")).ToString
            LbBKKSumSuppliesExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumSuppliesExpenses.Text) + da.Rows(0)("sumSuppliesExpenses")).ToString
            LbBKKSumEquipment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumEquipment.Text) + da.Rows(0)("sumEquipment")).ToString
            LbBKKSumShopfitting.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumShopfitting.Text) + da.Rows(0)("sumShopfitting")).ToString
            LbBKKSumPackagingandOtherMaterial.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPackagingandOtherMaterial.Text) + da.Rows(0)("sumPackagingandOtherMaterial")).ToString
            LbBKKSumBusinessTravelExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumBusinessTravelExpenses.Text) + da.Rows(0)("sumBusinessTravelExpenses")).ToString
            LbBKKSumCarParkingandOthers.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumCarParkingandOthers.Text) + da.Rows(0)("sumCarParkingandOthers")).ToString
            LbBKKSumTravel.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumTravel.Text) + da.Rows(0)("sumTravel")).ToString
            LbBKKSumAccomodation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumAccomodation.Text) + da.Rows(0)("sumAccomodation")).ToString
            LbBKKSumMealandEntertainment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumMealandEntertainment.Text) + da.Rows(0)("sumMealandEntertainment")).ToString
            LbBKKSumInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumInsurance.Text) + da.Rows(0)("sumInsurance")).ToString
            LbBKKSumAllRiskInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumAllRiskInsurance.Text) + da.Rows(0)("sumAllRiskInsurance")).ToString
            LbBKKSumHealthandLifeInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumHealthandLifeInsurance.Text) + da.Rows(0)("sumHealthandLifeInsurance")).ToString
            LbBKKSumPenaltyandTaxation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPenaltyandTaxation.Text) + da.Rows(0)("sumPenaltyandTaxation")).ToString
            LbBKKSumTaxation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumTaxation.Text) + da.Rows(0)("sumTaxation")).ToString
            LbBKKSumPenalty.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPenalty.Text) + da.Rows(0)("sumPenalty")).ToString
            LbBKKSumOtherRelatedStaffCost.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherRelatedStaffCost.Text) + da.Rows(0)("sumOtherRelatedStaffCost")).ToString
            LbBKKSumStaffConferenceandTraining.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumStaffConferenceandTraining.Text) + da.Rows(0)("sumStaffConferenceandTraining")).ToString
            LbBKKSumTraining.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumTraining.Text) + da.Rows(0)("sumTraining")).ToString
            LbBKKSumCommunication.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumCommunication.Text) + da.Rows(0)("sumCommunication")).ToString
            LbBKKSumTelephoneCalls_Faxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumTelephoneCalls_Faxes.Text) + da.Rows(0)("sumTelephoneCalls_Faxes")).ToString
            LbBKKSumPostageandCourier.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPostageandCourier.Text) + da.Rows(0)("sumPostageandCourier")).ToString
            LbBKKSumOtherExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumOtherExpenses.Text) + da.Rows(0)("sumOtherExpenses")).ToString
            LbBKKSumSample_Tester.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumSample_Tester.Text) + da.Rows(0)("sumSample_Tester")).ToString
            LbBKKSumPreopeningCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumPreopeningCosts.Text) + da.Rows(0)("sumPreopeningCosts")).ToString
            LbBKKSumLossonClaim.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumLossonClaim.Text) + da.Rows(0)("sumLossonClaim")).ToString
            LbBKKSumCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumCashOvertage_Shortagefromsales.Text) + da.Rows(0)("sumCashOvertage_Shortagefromsales")).ToString
            LbBKKSumMiscellenousandOther.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumMiscellenousandOther.Text) + da.Rows(0)("sumMiscellenousandOther")).ToString
            LbBKKSumStoreTradingProfit__Loss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumStoreTradingProfit__Loss.Text) + da.Rows(0)("sumStoreTradingProfit__Loss")).ToString
            'LbBKKSumTradingProfit__Loss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKSumTradingProfit__Loss.Text) + da.Rows(0)("sumTradingProfit__Loss")).ToString
            LbBKKFullTgs.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKFullTgs.Text) + da.Rows(0)("sumtotalarea")).ToString
            LbBKKFullTss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbBKKFullTss.Text) + da.Rows(0)("sumsalearea")).ToString

            LbNostBKK.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbNostBKK.Text) + da.Rows(0)("cnum")).ToString

        End If

        If da2.Rows.Count > 0 Then
            LbUPSumTotalRevenue.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumTotalRevenue.Text) + da2.Rows(0)("sumTotalRevenue")).ToString
            LbUPSumRETAIL_TESPIncome.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumRETAIL_TESPIncome.Text) + da2.Rows(0)("sumRETAIL_TESPIncome")).ToString
            LbUPSumOtherRevenue.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherRevenue.Text) + da2.Rows(0)("sumOtherRevenue")).ToString
            LbUPSumCostofGoodSold.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumCostofGoodSold.Text) + da2.Rows(0)("sumCostofGoodSold")).ToString
            LbUPSumGrossProfit.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumGrossProfit.Text) + da2.Rows(0)("sumGrossProfit")).ToString
            'LbUPSumGrossProfit_percent.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumGrossProfit_percent.Text) + da2.Rows(0)("sumGrossProfit_percent")).ToString
            LbUPSumMarginAdjustments.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumMarginAdjustments.Text) + da2.Rows(0)("sumMarginAdjustments")).ToString
            LbUPSumShipping.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumShipping.Text) + da2.Rows(0)("sumShipping")).ToString
            LbUPSumStockLossandObsolescence.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumStockLossandObsolescence.Text) + da2.Rows(0)("sumStockLossandObsolescence")).ToString
            LbUPSumInventoryAdjustment_stock.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumInventoryAdjustment_stock.Text) + da2.Rows(0)("sumInventoryAdjustment_stock")).ToString
            LbUPSumInventoryAdjustment_damage.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumInventoryAdjustment_damage.Text) + da2.Rows(0)("sumInventoryAdjustment_damage")).ToString
            LbUPSumStockLoss_Provision.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumStockLoss_Provision.Text) + da2.Rows(0)("sumStockLoss_Provision")).ToString
            LbUPSumStockObsolescence_Provision.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumStockObsolescence_Provision.Text) + da2.Rows(0)("sumStockObsolescence_Provision")).ToString
            LbUPSumGWP.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumGWP.Text) + da2.Rows(0)("sumGWP")).ToString
            LbUPSumGWPs_Corporate.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumGWPs_Corporate.Text) + da2.Rows(0)("sumGWPs_Corporate")).ToString
            LbUPSumGWPs_Transferred.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumGWPs_Transferred.Text) + da2.Rows(0)("sumGWPs_Transferred")).ToString
            LbUPSumSellingCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumSellingCosts.Text) + da2.Rows(0)("sumSellingCosts")).ToString
            LbUPSumCreditcardscommission.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumCreditcardscommission.Text) + da2.Rows(0)("sumCreditcardscommission")).ToString
            LbUPSumLabellingMaterial.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumLabellingMaterial.Text) + da2.Rows(0)("sumLabellingMaterial")).ToString
            LbUPSumOtherIncome_COSHFunding.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherIncome_COSHFunding.Text) + da2.Rows(0)("sumOtherIncome_COSHFunding")).ToString
            LbUPSumOtherIncomeSupplier.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherIncomeSupplier.Text) + da2.Rows(0)("sumOtherIncomeSupplier")).ToString
            LbUPSumAdjustedGrossMargin.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumAdjustedGrossMargin.Text) + da2.Rows(0)("sumAdjustedGrossMargin")).ToString
            LbUPSumSupplyChainCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumSupplyChainCosts.Text) + da2.Rows(0)("sumSupplyChainCosts")).ToString
            LbUPSumTotalStoreExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumTotalStoreExpenses.Text) + da2.Rows(0)("sumTotalStoreExpenses")).ToString
            LbUPSumStoreLabourCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumStoreLabourCosts.Text) + da2.Rows(0)("sumStoreLabourCosts")).ToString
            LbUPSumGrossPay.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumGrossPay.Text) + da2.Rows(0)("sumGrossPay")).ToString
            LbUPSumTemporaryStaffCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumTemporaryStaffCosts.Text) + da2.Rows(0)("sumTemporaryStaffCosts")).ToString
            LbUPSumAllowance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumAllowance.Text) + da2.Rows(0)("sumAllowance")).ToString
            LbUPSumOvertime.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOvertime.Text) + da2.Rows(0)("sumOvertime")).ToString
            LbUPSumLicensefee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumLicensefee.Text) + da2.Rows(0)("sumLicensefee")).ToString
            LbUPSumBonuses_Incentives.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumBonuses_Incentives.Text) + da2.Rows(0)("sumBonuses_Incentives")).ToString
            LbUPSumBootsBrandncentives.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumBootsBrandncentives.Text) + da2.Rows(0)("sumBootsBrandncentives")).ToString
            LbUPSumSuppliersIncentive.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumSuppliersIncentive.Text) + da2.Rows(0)("sumSuppliersIncentive")).ToString
            LbUPSumProvidentFund.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumProvidentFund.Text) + da2.Rows(0)("sumProvidentFund")).ToString
            LbUPSumPensionCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPensionCosts.Text) + da2.Rows(0)("sumPensionCosts")).ToString
            LbUPSumSocialSecurityFund.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumSocialSecurityFund.Text) + da2.Rows(0)("sumSocialSecurityFund")).ToString
            LbUPSumUniforms.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumUniforms.Text) + da2.Rows(0)("sumUniforms")).ToString
            LbUPSumEmployeeWelfare.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumEmployeeWelfare.Text) + da2.Rows(0)("sumEmployeeWelfare")).ToString
            LbUPSumOtherBenefitsEmployee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherBenefitsEmployee.Text) + da2.Rows(0)("sumOtherBenefitsEmployee")).ToString
            LbUPSumStorePropertyCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumStorePropertyCosts.Text) + da2.Rows(0)("sumStorePropertyCosts")).ToString
            LbUPSumPropertyRental.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPropertyRental.Text) + da2.Rows(0)("sumPropertyRental")).ToString
            LbUPSumPropertyServices.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPropertyServices.Text) + da2.Rows(0)("sumPropertyServices")).ToString
            LbUPSumPropertyFacility.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPropertyFacility.Text) + da2.Rows(0)("sumPropertyFacility")).ToString
            LbUPSumPropertytaxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPropertytaxes.Text) + da2.Rows(0)("sumPropertytaxes")).ToString
            LbUPSumFacialtaxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumFacialtaxes.Text) + da2.Rows(0)("sumFacialtaxes")).ToString
            LbUPSumPropertyInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPropertyInsurance.Text) + da2.Rows(0)("sumPropertyInsurance")).ToString
            LbUPSumSignboard.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumSignboard.Text) + da2.Rows(0)("sumSignboard")).ToString
            LbUPSumDiscount_Rent_Services_Facility.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumDiscount_Rent_Services_Facility.Text) + da2.Rows(0)("sumDiscount_Rent_Services_Facility")).ToString
            LbUPSumGPCommission.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumGPCommission.Text) + da2.Rows(0)("sumGPCommission")).ToString
            LbUPSumAmortizationofLeaseRight.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumAmortizationofLeaseRight.Text) + da2.Rows(0)("sumAmortizationofLeaseRight")).ToString
            LbUPSumDepreciation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumDepreciation.Text) + da2.Rows(0)("sumDepreciation")).ToString
            LbUPSumDepreciationofShortLeaseBuilding.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumDepreciationofShortLeaseBuilding.Text) + da2.Rows(0)("sumDepreciationofShortLeaseBuilding")).ToString
            LbUPSumDepreciationofComputerHardware.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumDepreciationofComputerHardware.Text) + da2.Rows(0)("sumDepreciationofComputerHardware")).ToString
            LbUPSumDepreciationofFixturesFittings.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumDepreciationofFixturesFittings.Text) + da2.Rows(0)("sumDepreciationofFixturesFittings")).ToString
            LbUPSumDepreciationofComputerSoftware.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumDepreciationofComputerSoftware.Text) + da2.Rows(0)("sumDepreciationofComputerSoftware")).ToString
            LbUPSumDepreciationofOfficeEquipment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumDepreciationofOfficeEquipment.Text) + da2.Rows(0)("sumDepreciationofOfficeEquipment")).ToString
            LbUPSumOtherStoreCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherStoreCosts.Text) + da2.Rows(0)("sumOtherStoreCosts")).ToString
            LbUPSumServiceChargesandOtherFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumServiceChargesandOtherFees.Text) + da2.Rows(0)("sumServiceChargesandOtherFees")).ToString
            LbUPSumBankCharges.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumBankCharges.Text) + da2.Rows(0)("sumBankCharges")).ToString
            LbUPSumCashCollectionCharge.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumCashCollectionCharge.Text) + da2.Rows(0)("sumCashCollectionCharge")).ToString
            LbUPSumCleaning.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumCleaning.Text) + da2.Rows(0)("sumCleaning")).ToString
            LbUPSumSecurityGuards.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumSecurityGuards.Text) + da2.Rows(0)("sumSecurityGuards")).ToString
            LbUPSumCarriage.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumCarriage.Text) + da2.Rows(0)("sumCarriage")).ToString
            LbUPSumLicenceFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumLicenceFees.Text) + da2.Rows(0)("sumLicenceFees")).ToString
            LbUPSumOtherServicesCharge.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherServicesCharge.Text) + da2.Rows(0)("sumOtherServicesCharge")).ToString
            LbUPSumOtherFees.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherFees.Text) + da2.Rows(0)("sumOtherFees")).ToString
            LbUPSumUtilities.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumUtilities.Text) + da2.Rows(0)("sumUtilities")).ToString
            LbUPSumWater.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumWater.Text) + da2.Rows(0)("sumWater")).ToString
            LbUPSumGas_Electric.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumGas_Electric.Text) + da2.Rows(0)("sumGas_Electric")).ToString
            LbUPSumAirCond_Addition.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumAirCond_Addition.Text) + da2.Rows(0)("sumAirCond_Addition")).ToString
            LbUPSumRepairandMaintenance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumRepairandMaintenance.Text) + da2.Rows(0)("sumRepairandMaintenance")).ToString
            LbUPSumRMOther_Fix.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumRMOther_Fix.Text) + da2.Rows(0)("sumRMOther_Fix")).ToString
            LbUPSumRMOther_Unplan.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumRMOther_Unplan.Text) + da2.Rows(0)("sumRMOther_Unplan")).ToString
            LbUPSumRMComputer_Fix.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumRMComputer_Fix.Text) + da2.Rows(0)("sumRMComputer_Fix")).ToString
            LbUPSumRMComputer_Unplan.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumRMComputer_Unplan.Text) + da2.Rows(0)("sumRMComputer_Unplan")).ToString
            LbUPSumProfessionalFee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumProfessionalFee.Text) + da2.Rows(0)("sumProfessionalFee")).ToString
            LbUPSumMarketingResearch.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumMarketingResearch.Text) + da2.Rows(0)("sumMarketingResearch")).ToString
            LbUPSumOtherFee.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherFee.Text) + da2.Rows(0)("sumOtherFee")).ToString
            LbUPSumEquipment_MaterailandSupplies.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumEquipment_MaterailandSupplies.Text) + da2.Rows(0)("sumEquipment_MaterailandSupplies")).ToString
            LbUPSumPrintingandStationery.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPrintingandStationery.Text) + da2.Rows(0)("sumPrintingandStationery")).ToString
            LbUPSumSuppliesExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumSuppliesExpenses.Text) + da2.Rows(0)("sumSuppliesExpenses")).ToString
            LbUPSumEquipment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumEquipment.Text) + da2.Rows(0)("sumEquipment")).ToString
            LbUPSumShopfitting.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumShopfitting.Text) + da2.Rows(0)("sumShopfitting")).ToString
            LbUPSumPackagingandOtherMaterial.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPackagingandOtherMaterial.Text) + da2.Rows(0)("sumPackagingandOtherMaterial")).ToString
            LbUPSumBusinessTravelExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumBusinessTravelExpenses.Text) + da2.Rows(0)("sumBusinessTravelExpenses")).ToString
            LbUPSumCarParkingandOthers.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumCarParkingandOthers.Text) + da2.Rows(0)("sumCarParkingandOthers")).ToString
            LbUPSumTravel.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumTravel.Text) + da2.Rows(0)("sumTravel")).ToString
            LbUPSumAccomodation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumAccomodation.Text) + da2.Rows(0)("sumAccomodation")).ToString
            LbUPSumMealandEntertainment.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumMealandEntertainment.Text) + da2.Rows(0)("sumMealandEntertainment")).ToString
            LbUPSumInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumInsurance.Text) + da2.Rows(0)("sumInsurance")).ToString
            LbUPSumAllRiskInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumAllRiskInsurance.Text) + da2.Rows(0)("sumAllRiskInsurance")).ToString
            LbUPSumHealthandLifeInsurance.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumHealthandLifeInsurance.Text) + da2.Rows(0)("sumHealthandLifeInsurance")).ToString
            LbUPSumPenaltyandTaxation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPenaltyandTaxation.Text) + da2.Rows(0)("sumPenaltyandTaxation")).ToString
            LbUPSumTaxation.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumTaxation.Text) + da2.Rows(0)("sumTaxation")).ToString
            LbUPSumPenalty.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPenalty.Text) + da2.Rows(0)("sumPenalty")).ToString
            LbUPSumOtherRelatedStaffCost.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherRelatedStaffCost.Text) + da2.Rows(0)("sumOtherRelatedStaffCost")).ToString
            LbUPSumStaffConferenceandTraining.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumStaffConferenceandTraining.Text) + da2.Rows(0)("sumStaffConferenceandTraining")).ToString
            LbUPSumTraining.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumTraining.Text) + da2.Rows(0)("sumTraining")).ToString
            LbUPSumCommunication.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumCommunication.Text) + da2.Rows(0)("sumCommunication")).ToString
            LbUPSumTelephoneCalls_Faxes.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumTelephoneCalls_Faxes.Text) + da2.Rows(0)("sumTelephoneCalls_Faxes")).ToString
            LbUPSumPostageandCourier.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPostageandCourier.Text) + da2.Rows(0)("sumPostageandCourier")).ToString
            LbUPSumOtherExpenses.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumOtherExpenses.Text) + da2.Rows(0)("sumOtherExpenses")).ToString
            LbUPSumSample_Tester.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumSample_Tester.Text) + da2.Rows(0)("sumSample_Tester")).ToString
            LbUPSumPreopeningCosts.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumPreopeningCosts.Text) + da2.Rows(0)("sumPreopeningCosts")).ToString
            LbUPSumLossonClaim.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumLossonClaim.Text) + da2.Rows(0)("sumLossonClaim")).ToString
            LbUPSumCashOvertage_Shortagefromsales.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumCashOvertage_Shortagefromsales.Text) + da2.Rows(0)("sumCashOvertage_Shortagefromsales")).ToString
            LbUPSumMiscellenousandOther.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumMiscellenousandOther.Text) + da2.Rows(0)("sumMiscellenousandOther")).ToString
            LbUPSumStoreTradingProfit__Loss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumStoreTradingProfit__Loss.Text) + da2.Rows(0)("sumStoreTradingProfit__Loss")).ToString
            'LbUPSumTradingProfit__Loss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPSumTradingProfit__Loss.Text) + da2.Rows(0)("sumTradingProfit__Loss")).ToString
            LbUPFullTgs.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPFullTgs.Text) + da2.Rows(0)("sumtotalarea")).ToString
            LbUPFullTss.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbUPFullTss.Text) + da2.Rows(0)("sumsalearea")).ToString

            LbNostUP.Text = ClsManage.convert2Currency(Convert.ToDecimal(LbNostUP.Text) + da2.Rows(0)("cnum")).ToString

        End If
    End Sub
End Class
