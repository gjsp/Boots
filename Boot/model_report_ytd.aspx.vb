
Partial Class model_report_ytd
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


            ddllo.DataValueField = "location_id"
            ddllo.DataTextField = "location_name"
            ddllo.DataSource = ClsDB.getLocation()
            ddllo.DataBind()
            ddllo.Items.Add(New ListItem("All", "ALL"))
            ddllo.SelectedValue = "ALL"

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

        Panel1.Visible = True
        Pftb.Visible = True
        TbCk.Text = 0

        LbNost.Text = 0

        LbYtdDate.Text = "YTD " + x_divide + " M"
        LbFullTgs.Text = 0
        LbFullTss.Text = 0
        LbFullPos.Text = 0
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
        'LbSumTradingProfit__Loss.Text = 0

        Dim start_year As String
        If ddlMonth.SelectedValue < 4 Then
            start_year = "1/4/" + (ddlYear.SelectedValue - 1).ToString
        Else
            start_year = "1/4/" + ddlYear.SelectedValue.ToString
        End If

        ObjectDataSource2.SelectParameters("years").DefaultValue = ddlYear.SelectedValue
        ObjectDataSource2.SelectParameters("mon").DefaultValue = ddlMonth.SelectedValue
        ObjectDataSource2.SelectParameters("locate").DefaultValue = ddllo.SelectedValue
        ObjectDataSource2.SelectParameters("start_time").DefaultValue = start_year
        ObjectDataSource2.SelectParameters("rate").DefaultValue = ddlRate.SelectedValue
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
        ClsManage.Script(Page, "settb('b');settb('e');settb('f');settb('g');settb('h');settb('s');settb('aa');")
        'ClsManage.Script(Page, "document.getElementById('" + hdfExcel.ClientID + "').value =  document.getElementById('" + temp_body.ClientID + "').innerHTML; ")

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

        LbNost.Text = ClsManage.convert2Currency3(LbNost.Text)
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

        CType(e.Item.FindControl("label2"), Label).Text = "<TABLE cellspacing='0' cellpadding='0' class='tball'>" + _
            "<TR style='font-weight:bold;' class='kbg1'><TD align='center'><div style='width:110px'><strong>" + e.Item.DataItem("cnum").ToString + "</strong></div></TD><TD align='center'><div style='width:65px;'><strong></strong></div></TD></TR>" + _
                "<TR style='font-weight:bold;' class='kbg1'><TD align='center'><div style='width:110px'><strong>" + e.Item.DataItem("store_name") + "</strong></div></TD><TD align='center'><div style='width:65px;'><strong>% Sale</strong></div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='center'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumtotalarea").ToString).ToString + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='center'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("sumsalearea").ToString).ToString + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='center'><div style='width:110px'>" + ClsManage.convert2Currency3((e.Item.DataItem("SumTotalRevenue") / e.Item.DataItem("sumsalearea")) / Convert.ToDecimal(x_divide)).ToString + "</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='center'><div style='width:110px'>YTD " + x_divide.ToString + " M</div></TD><TD align='center'><div style='width:65px;'>&nbsp;</div></TD></TR>" + _
    "<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumTotalRevenue").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumTotalRevenue") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='aa1c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumRETAIL_TESPIncome").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumRETAIL_TESPIncome") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='aa2c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherRevenue").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherRevenue") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumCostofGoodSold").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumCostofGoodSold") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumGrossProfit").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumGrossProfit") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumMarginAdjustments").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumMarginAdjustments") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b1c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumShipping").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumShipping") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b2c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumStockLossandObsolescence").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumStockLossandObsolescence") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b3c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumInventoryAdjustment_stock").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumInventoryAdjustment_stock") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b4c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumInventoryAdjustment_damage").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumInventoryAdjustment_damage") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b5c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumStockLoss_Provision").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumStockLoss_Provision") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b6c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumStockObsolescence_Provision").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumStockObsolescence_Provision") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b7c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumGWP").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumGWP") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b8c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumGWPs_Corporate").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumGWPs_Corporate") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b9c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumGWPs_Transferred").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumGWPs_Transferred") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b10c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumSellingCosts").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumSellingCosts") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b11c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumCreditcardscommission").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumCreditcardscommission") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b12c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumLabellingMaterial").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumLabellingMaterial") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b13c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherIncome_COSHFunding").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherIncome_COSHFunding") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='b14c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherIncomeSupplier").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherIncomeSupplier") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumAdjustedGrossMargin").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumAdjustedGrossMargin") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumSupplyChainCosts").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumSupplyChainCosts") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumTotalStoreExpenses").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumTotalStoreExpenses") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumStoreLabourCosts").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumStoreLabourCosts") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e1c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumGrossPay").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumGrossPay") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e2c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumTemporaryStaffCosts").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumTemporaryStaffCosts") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e3c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumAllowance").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumAllowance") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e4c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOvertime").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOvertime") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e5c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumLicensefee").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumLicensefee") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e6c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumBonuses_Incentives").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumBonuses_Incentives") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e7c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumBootsBrandncentives").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumBootsBrandncentives") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e8c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumSuppliersIncentive").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumSuppliersIncentive") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e9c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumProvidentFund").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumProvidentFund") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e10c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPensionCosts").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPensionCosts") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e11c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumSocialSecurityFund").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumSocialSecurityFund") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e12c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumUniforms").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumUniforms") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e13c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumEmployeeWelfare").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumEmployeeWelfare") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='e14c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherBenefitsEmployee").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherBenefitsEmployee") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumStorePropertyCosts").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumStorePropertyCosts") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f1c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPropertyRental").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPropertyRental") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f2c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPropertyServices").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPropertyServices") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f3c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPropertyFacility").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPropertyFacility") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f4c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPropertytaxes").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPropertytaxes") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f5c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumFacialtaxes").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumFacialtaxes") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f6c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPropertyInsurance").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPropertyInsurance") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f7c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumSignboard").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumSignboard") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f8c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumDiscount_Rent_Services_Facility").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumDiscount_Rent_Services_Facility") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f9c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumGPCommission").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumGPCommission") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='f10c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumAmortizationofLeaseRight").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumAmortizationofLeaseRight") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumDepreciation").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumDepreciation") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='g1c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumDepreciationofShortLeaseBuilding").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumDepreciationofShortLeaseBuilding") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='g2c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumDepreciationofComputerHardware").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumDepreciationofComputerHardware") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='g3c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumDepreciationofFixturesFittings").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumDepreciationofFixturesFittings") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='g4c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumDepreciationofComputerSoftware").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumDepreciationofComputerSoftware") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='g5c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumDepreciationofOfficeEquipment").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumDepreciationofOfficeEquipment") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherStoreCosts").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherStoreCosts") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h1c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumServiceChargesandOtherFees").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumServiceChargesandOtherFees") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h2c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumBankCharges").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumBankCharges") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h3c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumCashCollectionCharge").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumCashCollectionCharge") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h4c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumCleaning").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumCleaning") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h5c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumSecurityGuards").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumSecurityGuards") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h6c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumCarriage").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumCarriage") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h7c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumLicenceFees").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumLicenceFees") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h8c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherServicesCharge").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherServicesCharge") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h9c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherFees").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherFees") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h10c" + TbCk.Text + "'><TD a9ign='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumUtilities").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumUtilities") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h11c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumWater").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumWater") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h12c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumGas_Electric").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumGas_Electric") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h13c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumAirCond_Addition").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumAirCond_Addition") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h14c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumRepairandMaintenance").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumRepairandMaintenance") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h15c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumRMOther_Fix").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumRMOther_Fix") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h16c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumRMOther_Unplan").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumRMOther_Unplan") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h17c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumRMComputer_Fix").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumRMComputer_Fix") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h18c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumRMComputer_Unplan").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumRMComputer_Unplan") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h19c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumProfessionalFee").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumProfessionalFee") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h20c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumMarketingResearch").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumMarketingResearch") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h21c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherFee").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherFee") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h22c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumEquipment_MaterailandSupplies").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumEquipment_MaterailandSupplies") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h23c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPrintingandStationery").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPrintingandStationery") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h24c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumSuppliesExpenses").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumSuppliesExpenses") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h25c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumEquipment").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumEquipment") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h26c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumShopfitting").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumShopfitting") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h27c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPackagingandOtherMaterial").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPackagingandOtherMaterial") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h28c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumBusinessTravelExpenses").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumBusinessTravelExpenses") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h29c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumCarParkingandOthers").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumCarParkingandOthers") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h30c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumTravel").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumTravel") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h31c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumAccomodation").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumAccomodation") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h32c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumMealandEntertainment").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumMealandEntertainment") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h33c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumInsurance").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumInsurance") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h34c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumAllRiskInsurance").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumAllRiskInsurance") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h35c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumHealthandLifeInsurance").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumHealthandLifeInsurance") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h36c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPenaltyandTaxation").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPenaltyandTaxation") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h37c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumTaxation").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumTaxation") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h38c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPenalty").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPenalty") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h39c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherRelatedStaffCost").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherRelatedStaffCost") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h40c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumStaffConferenceandTraining").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumStaffConferenceandTraining") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h41c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumTraining").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumTraining") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h42c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumCommunication").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumCommunication") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h43c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumTelephoneCalls_Faxes").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumTelephoneCalls_Faxes") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h44c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPostageandCourier").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPostageandCourier") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h45c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumOtherExpenses").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumOtherExpenses") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h46c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumSample_Tester").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumSample_Tester") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h47c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumPreopeningCosts").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumPreopeningCosts") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h48c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumLossonClaim").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumLossonClaim") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h49c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumCashOvertage_Shortagefromsales").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumCashOvertage_Shortagefromsales") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR id='h50c" + TbCk.Text + "'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumMiscellenousandOther").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumMiscellenousandOther") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "<TR style='font-weight:bold;' class='kbg5'><TD align='right'><div style='width:110px'>" + ClsManage.convert2Currency3(e.Item.DataItem("SumStoreTradingProfit__Loss").ToString).ToString + "</div></TD><TD align='right'><div style='width:65px;'>" + ClsManage.convert2Currency4((e.Item.DataItem("SumStoreTradingProfit__Loss") / e.Item.DataItem("SumTotalRevenue")) * 100).ToString + "%</div></TD></TR>" + _
    "</TABLE>"
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

    End Sub

   
End Class
