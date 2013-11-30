<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="add_budget.aspx.vb" Inherits="add_budget" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="padding:20px 0px 0px 20px;">
    <div><strong>Add Budget</strong><br><br></div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Total Revenue :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TotalRevenue_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">RETAIL (TESP) Income :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="RETAIL_TESPIncome_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Revenue :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherRevenue_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Cost of Good Sold :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="CostofGoodSold_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Gross Profit :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="GrossProfit_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">% Gross Profit :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="GrossProfit_percent_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Margin Adjustments :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="MarginAdjustments_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Shipping :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Shipping_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Stock Loss and Obsolescence :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StockLossandObsolescence_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Inventory Adjustment - stock check (Actual) :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="InventoryAdjustment_stock_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Inventory Adjustment - damaged and obsolete stock (Actual) :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="InventoryAdjustment_damage_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Stock Loss  (Provision) :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StockLoss_Provision_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Stock Obsolescence (Provision) :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StockObsolescence_Provision_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">GWP :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="GWP_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">GWPs - Corporate :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="GWPs_Corporate_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">GWPs - Transferred :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="GWPs_Transferred_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Selling Costs :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="SellingCosts_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Credit cards commission :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Creditcardscommission_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Labelling Material :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="LabellingMaterial_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Income - COSH Funding :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherIncome_COSHFunding_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Income Supplier :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherIncomeSupplier_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Adjusted Gross Margin :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="AdjustedGrossMargin_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Supply Chain Costs :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="SupplyChainCosts_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Total Store Expenses :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TotalStoreExpenses_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Store Labour Costs :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StoreLabourCosts_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Gross Pay :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="GrossPay_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Temporary Staff Costs :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TemporaryStaffCosts_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Allowance :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Allowance_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Overtime :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Overtime_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">License fee :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Licensefee_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Bonuses/Incentives :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Bonuses_Incentives_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Boots Brand ncentives :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="BootsBrandncentives_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Suppliers Incentive :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="SuppliersIncentive_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Provident Fund :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="ProvidentFund_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Pension Costs :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PensionCosts_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Social Security Fund :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="SocialSecurityFund_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Uniforms :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Uniforms_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Employee Welfare :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="EmployeeWelfare_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Benefits Employee :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherBenefitsEmployee_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Store Property Costs :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StorePropertyCosts_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Property Rental :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PropertyRental_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Property Services :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PropertyServices_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Property Facility :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PropertyFacility_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Property taxes :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Propertytaxes_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Facial taxes :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Facialtaxes_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Property Insurance :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PropertyInsurance_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Signboard :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Signboard_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Discount - Rent/Services/Facility :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Discount_Rent_Services_Facility_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">GP Commission :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="GPCommission_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Amortization of Lease Right :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="AmortizationofLeaseRight_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Depreciation :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Depreciation_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Depreciation of Short Lease Building :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="DepreciationofShortLeaseBuilding_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Depreciation of Computer Hardware :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="DepreciationofComputerHardware_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Depreciation of Fixtures & Fittings :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="DepreciationofFixturesFittings_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Depreciation of Computer Software :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="DepreciationofComputerSoftware_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Depreciation of Office Equipment :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="DepreciationofOfficeEquipment_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Store Costs :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherStoreCosts_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Service Charges and Other Fees :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="ServiceChargesandOtherFees_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Bank Charges :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="BankCharges_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Cash Collection Charge :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="CashCollectionCharge_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Cleaning :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Cleaning_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Security Guards :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="SecurityGuards_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Carriage :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Carriage_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Licence Fees :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="LicenceFees_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Services Charge :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherServicesCharge_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Fees :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherFees_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Utilities :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Utilities_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Water :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Water_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Gas/Electric :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Gas_Electric_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Air Cond. - Addition :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="AirCond_Addition_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Repair and Maintenance :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="RepairandMaintenance_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">R&M Other - Fix :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="RMOther_Fix_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">R&M Other - Unplan :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="RMOther_Unplan_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">R&M Computer - Fix :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="RMComputer_Fix_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">R&M Computer - Unplan :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="RMComputer_Unplan_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Professional Fee :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="ProfessionalFee_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Marketing Research :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="MarketingResearch_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Fee :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherFee_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Equipment, Materail and Supplies :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Equipment_MaterailandSupplies_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Printing and Stationery :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PrintingandStationery_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Supplies Expenses :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="SuppliesExpenses_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Equipment :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Equipment_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Shopfitting :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Shopfitting_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Packaging and Other Material :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PackagingandOtherMaterial_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Business Travel Expenses :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="BusinessTravelExpenses_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Car Parking and Others :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="CarParkingandOthers_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Travel :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Travel_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Accomodation :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Accomodation_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Meal and Entertainment :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="MealandEntertainment_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Insurance :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Insurance_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">All Risk Insurance :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="AllRiskInsurance_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Health and Life Insurance :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="HealthandLifeInsurance_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Penalty and Taxation :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PenaltyandTaxation_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Taxation :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Taxation_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Penalty :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Penalty_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Related Staff Cost :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherRelatedStaffCost_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Staff Conference and Training :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StaffConferenceandTraining_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Training :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Training_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Communication :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Communication_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Telephone Calls/Faxes :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TelephoneCalls_Faxes_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Postage and Courier :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PostageandCourier_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Other Expenses :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="OtherExpenses_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Sample/Tester :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Sample_Tester_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Preopening Costs :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="PreopeningCosts_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Loss on Claim :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="LossonClaim_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Cash Overtage/Shortage from sales :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="CashOvertage_Shortagefromsales_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Miscellenous and Other :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="MiscellenousandOther_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Store Trading Profit / (Loss) :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StoreTradingProfit__Loss_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">% Trading Profit / (Loss) :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TradingProfit__Loss_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Store Controllable Costs for BSC :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StoreControllableCostsforBSC_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Store Labour Cost :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="StoreLabourCost_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Utillity :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="Utillity_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;font-size:11px;">
        <div style="float:left;width:350px;text-align:right;padding-top:2px;">Repair Maintenance :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="RepairMaintenance_Txt" runat="server" CssClass="inputbox4k"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
     <div style="padding:40px 0px 20px 0px;">
        <div style="text-align:left;">
            <asp:Button ID="SaveBt" runat="server" Text="Save" /> 
            <asp:Button ID="CancelBt" runat="server" Text="Cancel" />
        </div>
    </div>
</div>
</asp:Content>

