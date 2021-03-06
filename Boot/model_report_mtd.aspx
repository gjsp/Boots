﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="model_report_mtd.aspx.vb" Inherits="model_report" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
    function minitb(z) {
        var r = 0;
        if (z == 'b') {
            r = 14;
        }
        if (z == 'aa') {
            r = 2;
        }
        if (z == 'e') {
            r = 14;
        }
        if (z == 'f') {
            r = 10;
        }
        if (z == 'g') {
            r = 5;
        }
        if (z == 'h') {
            r = 50;
        }
        for (y = 1; y <= r; y++) {
            var x = $get('ContentPlaceHolder1_hdfIndex').value;
            if ($get(z + y).style.display == "none") {
                $get(z + y).style.display = "block";
                for (i = 1; i <= x; i++) {
                    $get(z + y + "c" + i).style.display = "block";
                }
            } else {
                $get(z + y).style.display = "none";
                for (i = 1; i <= x; i++) {
                    $get(z + y + "c" +i).style.display = "none";
                }
            }
        }
        if ($get(z + '1') != null) {
            if ($get(z + '1').style.display == "none") {
                $get('sp' + z).innerHTML = '+';
            } else {
                $get('sp' + z).innerHTML = '-';
            }
        }

    }
    function settb(z) {
        var r = 0;
        if (z == 'b') {
            r = 14;
        }
        if (z == 'e') {
            r = 14;
        }
        if (z == 'aa') {
            r = 2;
        }
        if (z == 'f') {
            r = 10;
        }
        if (z == 'g') {
            r = 5;
        }
        if (z == 'h') {
            r = 50;
        }
        for (y = 1; y <= r; y++) {
            var x = $get('ContentPlaceHolder1_hdfIndex').value;
            for (i = 1; i <= x; i++) {
                $get(z + y).style.display = "none";
                var ctrl = $get(z + y + "c" + i);
                if (ctrl != null) {
                $get(z + y + "c" + i).style.display = "none";
                }
            }
        }
    }
    //-->

  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div style="padding: 10px 10px;">
        <strong>Model Report</strong><br /><br />
        
        <div style="float: left; margin-right: .5cm">
            By
            <asp:DropDownList ID="ddlBy" runat="server" CssClass="select2">
                <asp:ListItem Text="MTD"></asp:ListItem>
                <asp:ListItem Text="YTD"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div style="float:left; margin-right:.5cm">
        <asp:UpdatePanel ID="upMonth" runat="server" RenderMode="Inline">
            <ContentTemplate>
         Date :
        <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" 
            AutoPostBack="True">
        </asp:DropDownList>
      
        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="select2">
        </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
         
        </div>
         <div style="float:left; margin-right:.5cm">
         Location : <asp:DropDownList ID="ddllo" runat="server" CssClass="select2">
        </asp:DropDownList>
        <asp:TextBox ID="TbCk" runat="server" style="display:none;"></asp:TextBox>
         </div>
         <div style="float:left; margin-right:.5cm">
        Currency Rate : <asp:DropDownList ID="ddlRate" runat="server" CssClass="select2">
        </asp:DropDownList>
         </div>
        <asp:Button ID="SearchBt" runat="server" Text="Search" Height="23px"/>
       <%-- <div align="center">
            <asp:UpdateProgress ID="upPG" runat="server">
                <ProgressTemplate>
                    <div id="divPG" align="center" valign="middle" runat="server" style="position: absolute;
                        left: 47%; padding: 10px 10px 10px 10px; visibility: visible; border-color: silver;
                        border-style: solid; border-width: 1px; background-color: White; margin-top: 10px">
                        <asp:Image ID="imgInd" ImageUrl="~/img/indicator.gif" runat="server" AlternateText="Processing" />
                        Loading ...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>--%>

    </div>
          
    <asp:Panel ID="Panel1" runat="server">
    <br />
    <asp:LinkButton ID="linkExcel" runat="server" style="color:#37a700;">Export To Excel</asp:LinkButton>
    
    <br /><br />

    <div id="temp_body" runat="server">  
    <table cellspacing='0' cellpadding='0' class='tb_block'>
      <tr>
        <td valign="top">
            <asp:Panel ID="Pftb" runat="server">
            <%--<table cellspacing='0' cellpadding='0' class='tball2'>
<tr style='font-weight:bold;' class='rbg0'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk"><asp:Label ID="lblReportName" runat="server"></asp:Label></div></td><td align='center' colspan="3"><div style='width:175px'><strong><asp:Label ID="LbMtdDate" runat="server" Text=""></asp:Label></strong></div></td></tr>
            
<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style="width:250px;padding-left:5px;"></div></td><td align='center'><div style='width:110px'><strong>Total</strong></div></td><td align='center'><div style='width:65px;'><strong>% Sale</strong></div></td><td align='center'><div style='width:85px;'><strong>% YOY</strong></div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Number of Stores (Exc.CDS)</div></td><td align='center'><div style='width:110px'><strong><asp:Label ID="LbNost" runat="server" Text=""></asp:Label></strong></div></td><td align='center'><div style='width:65px;'><strong></strong></div></td><td></td></tr>

<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Total Gross Space (SQM)</div></td><td align='center' class='rbg2'><div style='width:110px'><asp:Label ID="LbFullTgs" runat="server" Text=""></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Total Selling Space (SQM)</div></td><td align='center' class='rbg2'><div style='width:110px'><asp:Label ID="LbFullTss" runat="server" Text=""></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Productivity/SQM</div></td><td align='center' class='rbg2'><div style='width:110px'><asp:Label ID="LbFullPos" runat="server" Text=""></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>
<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style="width:250px;padding-left:5px;">&nbsp;</div></td><td align='center' class='kbg3'><div style='width:110px'></div></td><td align='center' class='kbg4'><div style='width:65px;'></div></td><td></td></tr>

<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">% Revenue Growth-YOY</div></td><td align='right' class='rbg2'><div style='width:110px'><asp:Label ID="lblRGyoy" runat="server" Text=""></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">% Revenue Growth-LFL</div></td><td align='right' class='rbg2'><div style='width:110px'><asp:Label ID="lblRGlfl" runat="server" Text=""></asp:Label></div></td><td align='center' class='rbg2'><div style='width:65px;'></div></td><td></td></tr>
<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style="width:250px;padding-left:5px;">&nbsp;</div></td><td align='center' class='kbg3'><div style='width:110px'></div></td><td align='center' class='kbg4'><div style='width:65px;'></div></td><td></td></tr>

<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Total Revenue <span id="spaa" class="ppk" onclick="minitb('aa');">+</span></div></td><td align='right'><div style='width:110px'><asp:Label ID="LbSumTotalRevenue" runat="server" Text=""></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID="LbPercTotalRevenue" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1000" runat="server"/></td></tr>
<tr id='aa1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Sale Revenue</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumRETAIL_TESPIncome" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercRETAIL_TESPIncome" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1001" runat="server"/></td></tr>
<tr id='aa2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Revenue</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherRevenue" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherRevenue" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1002" runat="server"/></td></tr>
<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Cost of Good Sold</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumCostofGoodSold" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercCostofGoodSold" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1003" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Gross Profit</div></td><td align='right'><div style='width:110px'><asp:Label ID="LbSumGrossProfit" runat="server" Text=""></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID="LbPercGrossProfit" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1004" runat="server"/></td></tr>
<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Margin Adjustments <span id="spb" class="ppk" onclick="minitb('b');">+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumMarginAdjustments" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercMarginAdjustments" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1005" runat="server"/></td></tr>
<tr id='b1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Shipping</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumShipping" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercShipping" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1006" runat="server"/></td></tr>
<tr id='b2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Stock Loss and Obsolescence</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumStockLossandObsolescence" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercStockLossandObsolescence" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1007" runat="server"/></td></tr>
<tr id='b3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - stock check (Actual)</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumInventoryAdjustment_stock" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercInventoryAdjustment_stock" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1008" runat="server"/></td></tr>
<tr id='b4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - damaged and obsolete stock (Actual)</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumInventoryAdjustment_damage" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercInventoryAdjustment_damage" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1009" runat="server"/></td></tr>
<tr id='b5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Stock Loss  (Provision)</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumStockLoss_Provision" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercStockLoss_Provision" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1010" runat="server"/></td></tr>
<tr id='b6'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Stock Obsolescence (Provision)</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumStockObsolescence_Provision" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercStockObsolescence_Provision" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1011" runat="server"/></td></tr>
<tr id='b7'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - GWP</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumGWP" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercGWP" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1012" runat="server"/></td></tr>
<tr id='b8'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - GWPs - Corporate</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumGWPs_Corporate" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercGWPs_Corporate" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1013" runat="server"/></td></tr>
<tr id='b9'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - GWPs - Transferred</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumGWPs_Transferred" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercGWPs_Transferred" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1014" runat="server"/></td></tr>
<tr id='b10'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Selling Costs</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumSellingCosts" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercSellingCosts" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1015" runat="server"/></td></tr>
<tr id='b11'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Credit cards commission</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumCreditcardscommission" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercCreditcardscommission" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1016" runat="server"/></td></tr>
<tr id='b12'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Labelling Material</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumLabellingMaterial" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercLabellingMaterial" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1017" runat="server"/></td></tr>
<tr id='b13'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Income - COSH Funding</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherIncome_COSHFunding" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherIncome_COSHFunding" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1018" runat="server"/></td></tr>
<tr id='b14'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Income Supplier</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherIncomeSupplier" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherIncomeSupplier" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1019" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Adjusted Gross Margin</div></td><td align='right'><div style='width:110px'><asp:Label ID="LbSumAdjustedGrossMargin" runat="server" Text=""></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID="LbPercAdjustedGrossMargin" runat="server" Text=""></asp:Label>%</div></td><td align='right' class="rbg2"><asp:Label ID="lblYoy1020" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left' class='kbg2' style="border-bottom:1px solid #2c2b2b;"><div style="width:200px;padding-left:5px;" class="pptk">Supply Chain Costs</div></td><td align='right' style="border-bottom:1px solid #2c2b2b;" class='kbg3'><div style='width:110px'><asp:Label ID="LbSumSupplyChainCosts" runat="server" Text=""></asp:Label></div></td><td align='right' style="border-bottom:1px solid #2c2b2b;" class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercSupplyChainCosts" runat="server" Text=""></asp:Label>%</div></td><td align='right' style="border-bottom:1px solid #2c2b2b;"><asp:Label ID="lblYoy1021" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Total Store Expenses</div></td><td align='right'><div style='width:110px'><asp:Label ID="LbSumTotalStoreExpenses" runat="server" Text=""></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID="LbPercTotalStoreExpenses" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1022" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg3'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Store Labour Costs <span id="spe" class="ppk" onclick="minitb('e');">+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumStoreLabourCosts" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercStoreLabourCosts" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1023" runat="server"/></td></tr>
<tr id='e1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Gross Pay</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumGrossPay" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercGrossPay" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1024" runat="server"/></td></tr>
<tr id='e2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Temporary Staff Costs</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumTemporaryStaffCosts" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercTemporaryStaffCosts" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1025" runat="server"/></td></tr>
<tr id='e3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Allowance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumAllowance" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercAllowance" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1026" runat="server"/></td></tr>
<tr id='e4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Overtime</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOvertime" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOvertime" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1027" runat="server"/></td></tr>
<tr id='e5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - License fee</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumLicensefee" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercLicensefee" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1028" runat="server"/></td></tr>
<tr id='e6'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Bonuses/Incentives</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumBonuses_Incentives" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercBonuses_Incentives" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1029" runat="server"/></td></tr>
<tr id='e7'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Boots Brand ncentives</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumBootsBrandncentives" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercBootsBrandncentives" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1030" runat="server"/></td></tr>
<tr id='e8'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Suppliers Incentive</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumSuppliersIncentive" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercSuppliersIncentive" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1031" runat="server"/></td></tr>
<tr id='e9'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Provident Fund</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumProvidentFund" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercProvidentFund" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1032" runat="server"/></td></tr>
<tr id='e10'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Pension Costs</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPensionCosts" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPensionCosts" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1033" runat="server"/></td></tr>
<tr id='e11'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Social Security Fund</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumSocialSecurityFund" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercSocialSecurityFund" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1034" runat="server"/></td></tr>
<tr id='e12'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Uniforms</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumUniforms" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercUniforms" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1035" runat="server"/></td></tr>
<tr id='e13'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Employee Welfare</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumEmployeeWelfare" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercEmployeeWelfare" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1036" runat="server"/></td></tr>
<tr id='e14'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Benefits Employee</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherBenefitsEmployee" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherBenefitsEmployee" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1037" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Store Property Costs <span id="spf" class="ppk" onclick="minitb('f');">+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumStorePropertyCosts" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercStorePropertyCosts" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1038" runat="server"/></td></tr>
<tr id='f1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property Rental</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPropertyRental" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPropertyRental" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1039" runat="server"/></td></tr>
<tr id='f2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property Services</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPropertyServices" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPropertyServices" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1040" runat="server"/></td></tr>
<tr id='f3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property Facility</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPropertyFacility" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPropertyFacility" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1041" runat="server"/></td></tr>
<tr id='f4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property taxes</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPropertytaxes" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPropertytaxes" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1042" runat="server"/></td></tr>
<tr id='f5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Facial taxes</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumFacialtaxes" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercFacialtaxes" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1043" runat="server"/></td></tr>
<tr id='f6'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property Insurance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPropertyInsurance" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPropertyInsurance" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1044" runat="server"/></td></tr>
<tr id='f7'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Signboard</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumSignboard" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercSignboard" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1045" runat="server"/></td></tr>
<tr id='f8'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Discount - Rent/Services/Facility</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumDiscount_Rent_Services_Facility" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercDiscount_Rent_Services_Facility" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1046" runat="server"/></td></tr>
<tr id='f9'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - GP Commission</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumGPCommission" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercGPCommission" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1047" runat="server"/></td></tr>
<tr id='f10'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Amortization of Lease Right</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumAmortizationofLeaseRight" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercAmortizationofLeaseRight" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1048" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Depreciation <span id="spg" class="ppk" onclick="minitb('g');">+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumDepreciation" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercDepreciation" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1049" runat="server"/></td></tr>
<tr id='g1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Short Lease Building</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumDepreciationofShortLeaseBuilding" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercDepreciationofShortLeaseBuilding" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1050" runat="server"/></td></tr>
<tr id='g2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Computer Hardware</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumDepreciationofComputerHardware" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercDepreciationofComputerHardware" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1051" runat="server"/></td></tr>
<tr id='g3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Fixtures & Fittings</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumDepreciationofFixturesFittings" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercDepreciationofFixturesFittings" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1052" runat="server"/></td></tr>
<tr id='g4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Computer Software</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumDepreciationofComputerSoftware" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercDepreciationofComputerSoftware" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1053" runat="server"/></td></tr>
<tr id='g5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Office Equipment</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumDepreciationofOfficeEquipment" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercDepreciationofOfficeEquipment" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1054" runat="server"/></td></tr>
<tr style='font-weight:bold' class='rbg3'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Other Store Costs <span id="sph" class="ppk" onclick="minitb('h');">+</span></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherStoreCosts" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherStoreCosts" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1055" runat="server"/></td></tr>
<tr id='h1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Service Charges and Other Fees</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumServiceChargesandOtherFees" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercServiceChargesandOtherFees" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1056" runat="server"/></td></tr>
<tr id='h2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Bank Charges</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumBankCharges" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercBankCharges" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1057" runat="server"/></td></tr>
<tr id='h3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Cash Collection Charge</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumCashCollectionCharge" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercCashCollectionCharge" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1058" runat="server"/></td></tr>
<tr id='h4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Cleaning</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumCleaning" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercCleaning" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1059" runat="server"/></td></tr>
<tr id='h5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Security Guards</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumSecurityGuards" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercSecurityGuards" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1060" runat="server"/></td></tr>
<tr id='h6'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Carriage</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumCarriage" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercCarriage" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1061" runat="server"/></td></tr>
<tr id='h7'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Licence Fees</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumLicenceFees" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercLicenceFees" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1062" runat="server"/></td></tr>
<tr id='h8'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Services Charge</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherServicesCharge" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherServicesCharge" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1063" runat="server"/></td></tr>
<tr id='h9'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Fees</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherFees" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherFees" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1064" runat="server"/></td></tr>
<tr id='h10'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Utilities</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumUtilities" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercUtilities" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1065" runat="server"/></td></tr>
<tr id='h11'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Water</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumWater" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercWater" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1066" runat="server"/></td></tr>
<tr id='h12'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Gas/Electric</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumGas_Electric" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercGas_Electric" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1067" runat="server"/></td></tr>
<tr id='h13'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Air Cond. - Addition</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumAirCond_Addition" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercAirCond_Addition" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1068" runat="server"/></td></tr>
<tr id='h14'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Repair and Maintenance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumRepairandMaintenance" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercRepairandMaintenance" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1069" runat="server"/></td></tr>
<tr id='h15'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - R&M Other - Fix</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumRMOther_Fix" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercRMOther_Fix" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1070" runat="server"/></td></tr>
<tr id='h16'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - R&M Other - Unplan</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumRMOther_Unplan" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercRMOther_Unplan" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1071" runat="server"/></td></tr>
<tr id='h17'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - R&M Computer - Fix</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumRMComputer_Fix" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercRMComputer_Fix" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1072" runat="server"/></td></tr>
<tr id='h18'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - R&M Computer - Unplan</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumRMComputer_Unplan" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercRMComputer_Unplan" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1073" runat="server"/></td></tr>
<tr id='h19'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Professional Fee</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumProfessionalFee" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercProfessionalFee" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1074" runat="server"/></td></tr>
<tr id='h20'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Marketing Research</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumMarketingResearch" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercMarketingResearch" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1075" runat="server"/></td></tr>
<tr id='h21'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Fee</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherFee" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherFee" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1076" runat="server"/></td></tr>
<tr id='h22'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Equipment, Materail and Supplies</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumEquipment_MaterailandSupplies" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercEquipment_MaterailandSupplies" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1077" runat="server"/></td></tr>
<tr id='h23'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Printing and Stationery</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPrintingandStationery" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPrintingandStationery" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1078" runat="server"/></td></tr>
<tr id='h24'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Supplies Expenses</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumSuppliesExpenses" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercSuppliesExpenses" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1079" runat="server"/></td></tr>
<tr id='h25'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Equipment</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumEquipment" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercEquipment" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1080" runat="server"/></td></tr>
<tr id='h26'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Shopfitting</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumShopfitting" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercShopfitting" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1081" runat="server"/></td></tr>
<tr id='h27'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Packaging and Other Material</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPackagingandOtherMaterial" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPackagingandOtherMaterial" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1082" runat="server"/></td></tr>
<tr id='h28'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Business Travel Expenses</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumBusinessTravelExpenses" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercBusinessTravelExpenses" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1083" runat="server"/></td></tr>
<tr id='h29'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Car Parking and Others</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumCarParkingandOthers" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercCarParkingandOthers" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1084" runat="server"/></td></tr>
<tr id='h30'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Travel</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumTravel" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercTravel" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1085" runat="server"/></td></tr>
<tr id='h31'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Accomodation</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumAccomodation" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercAccomodation" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1086" runat="server"/></td></tr>
<tr id='h32'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Meal and Entertainment</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumMealandEntertainment" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercMealandEntertainment" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1087" runat="server"/></td></tr>
<tr id='h33'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Insurance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumInsurance" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercInsurance" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1088" runat="server"/></td></tr>
<tr id='h34'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - All Risk Insurance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumAllRiskInsurance" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercAllRiskInsurance" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1089" runat="server"/></td></tr>
<tr id='h35'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Health and Life Insurance</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumHealthandLifeInsurance" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercHealthandLifeInsurance" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1090" runat="server"/></td></tr>
<tr id='h36'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Penalty and Taxation</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPenaltyandTaxation" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPenaltyandTaxation" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1091" runat="server"/></td></tr>
<tr id='h37'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Taxation</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumTaxation" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercTaxation" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1092" runat="server"/></td></tr>
<tr id='h38'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Penalty</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPenalty" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPenalty" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1093" runat="server"/></td></tr>
<tr id='h39'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Related Staff Cost></div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherRelatedStaffCost" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherRelatedStaffCost" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1094" runat="server"/></td></tr>
<tr id='h40'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Staff Conference and Training</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumStaffConferenceandTraining" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercStaffConferenceandTraining" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1095" runat="server"/></td></tr>
<tr id='h41'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Training</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumTraining" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercTraining" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1096" runat="server"/></td></tr>
<tr id='h42'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Communication</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumCommunication" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercCommunication" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1097" runat="server"/></td></tr>
<tr id='h43'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Telephone Calls/Faxes</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumTelephoneCalls_Faxes" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercTelephoneCalls_Faxes" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1098" runat="server"/></td></tr>
<tr id='h44'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Postage and Courier</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPostageandCourier" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPostageandCourier" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1099" runat="server"/></td></tr>
<tr id='h45'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Expenses</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumOtherExpenses" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercOtherExpenses" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1100" runat="server"/></td></tr>
<tr id='h46'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Sample/Tester</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumSample_Tester" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercSample_Tester" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1101" runat="server"/></td></tr>
<tr id='h47'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Preopening Costs</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumPreopeningCosts" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercPreopeningCosts" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1102" runat="server"/></td></tr>
<tr id='h48'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Loss on Claim</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumLossonClaim" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercLossonClaim" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1103" runat="server"/></td></tr>
<tr id='h49'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Cash Overtage/Shortage from sales</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumCashOvertage_Shortagefromsales" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercCashOvertage_Shortagefromsales" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1104" runat="server"/></td></tr>
<tr id='h50'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Miscellenous and Other</div></td><td align='right' class='kbg3'><div style='width:110px'><asp:Label ID="LbSumMiscellenousandOther" runat="server" Text=""></asp:Label></div></td><td align='right' class='kbg4'><div style='width:65px;'><asp:Label ID="LbPercMiscellenousandOther" runat="server" Text=""></asp:Label>%</div></td><td align='right'><asp:Label ID="lblYoy1105" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Store Trading Profit / (Loss)</div></td><td align='right'><div style='width:110px'><asp:Label ID="LbSumStoreTradingProfit__Loss" runat="server" Text=""></asp:Label></div></td><td align='right'><div style='width:65px;'><asp:Label ID="LbPercStoreTradingProfit__Loss" runat="server" Text=""></asp:Label>%</div></td><td align='right' class="rbg2"><asp:Label ID="lblYoy1106" runat="server"/></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">
    % Store Trading Profit Growth-YOY</div></td><td align='right'><div style='width:110px'><asp:Label ID="lblSTFGyoy" runat="server" Text=""></asp:Label></div></td><td align='right'><div style='width:65px;'></div></td><td align='right'></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">
    % Store Trading Profit Growth-LFL</div></td><td align='right'><div style='width:110px'><asp:Label ID="lblSTFGlfl" runat="server" Text=""></asp:Label></div></td><td align='right'><div style='width:65px;'></div></td><td align='right'></td></tr>

</table>--%>

            <table cellspacing='0' cellpadding='0' class='tball2'>
<tr style='font-weight:bold;' class='rbg0'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk"><asp:Label ID="lblReportName" runat="server"></asp:Label></div></td></tr>
            
<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style="width:250px;padding-left:5px;">&nbsp;</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Number of Stores (Exc.CDS)</div></td></tr>

<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Total Gross Space (SQM)</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Total Selling Space (SQM)</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Productivity/SQM</div></td></tr>
<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style="width:250px;padding-left:5px;">&nbsp;</div></td></tr>

<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">% Revenue Growth-YOY</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">% Revenue Growth-LFL</div></td></tr>
<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style="width:250px;padding-left:5px;">&nbsp;</div></td></tr>

<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Total Revenue <span id="spaa" class="ppk" onclick="minitb('aa');">+</span></div></td></tr>
<tr id='aa1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Sale Revenue</div></td></tr>
<tr id='aa2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Revenue</div></td></tr>
<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Cost of Good Sold</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Gross Profit</div></td></tr>
<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Margin Adjustments <span id="spb" class="ppk" onclick="minitb('b');">+</span></div></td></tr>
<tr id='b1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Shipping</div></td></tr>
<tr id='b2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Stock Loss and Obsolescence</div></td></tr>
<tr id='b3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - stock check (Actual)</div></td></tr>
<tr id='b4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - damaged and obsolete stock (Actual)</div></td></tr>
<tr id='b5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Stock Loss  (Provision)</div></td></tr>
<tr id='b6'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Stock Obsolescence (Provision)</div></td></tr>
<tr id='b7'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - GWP</div></td></tr>
<tr id='b8'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - GWPs - Corporate</div></td></tr>
<tr id='b9'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - GWPs - Transferred</div></td></tr>
<tr id='b10'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Selling Costs</div></td></tr>
<tr id='b11'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Credit cards commission</div></td></tr>
<tr id='b12'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Labelling Material</div></td></tr>
<tr id='b13'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Income - COSH Funding</div></td></tr>
<tr id='b14'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Income Supplier</div></td></tr>
<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Adjusted Gross Margin</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left' class='kbg2' style="border-bottom:1px solid #2c2b2b;"><div style="width:200px;padding-left:5px;" class="pptk">Supply Chain Costs</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Total Store Expenses</div></td></tr>
<tr style='font-weight:bold;' class='rbg3'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Store Labour Costs <span id="spe" class="ppk" onclick="minitb('e');">+</span></div></td></tr>
<tr id='e1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Gross Pay</div></td></tr>
<tr id='e2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Temporary Staff Costs</div></td></tr>
<tr id='e3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Allowance</div></td></tr>
<tr id='e4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Overtime</div></td></tr>
<tr id='e5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - License fee</div></td></tr>
<tr id='e6'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Bonuses/Incentives</div></td></tr>
<tr id='e7'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Boots Brand ncentives</div></td></tr>
<tr id='e8'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Suppliers Incentive</div></td></tr>
<tr id='e9'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Provident Fund</div></td></tr>
<tr id='e10'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Pension Costs</div></td></tr>
<tr id='e11'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Social Security Fund</div></td></tr>
<tr id='e12'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Uniforms</div></td></tr>
<tr id='e13'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Employee Welfare</div></td></tr>
<tr id='e14'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Benefits Employee</div></td></tr>
<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Store Property Costs <span id="spf" class="ppk" onclick="minitb('f');">+</span></div></td></tr>
<tr id='f1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property Rental</div></td></tr>
<tr id='f2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property Services</div></td></tr>
<tr id='f3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property Facility</div></td></tr>
<tr id='f4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property taxes</div></td></tr>
<tr id='f5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Facial taxes</div></td></tr>
<tr id='f6'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Property Insurance</div></td></tr>
<tr id='f7'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Signboard</div></td></tr>
<tr id='f8'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Discount - Rent/Services/Facility</div></td></tr>
<tr id='f9'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - GP Commission</div></td></tr>
<tr id='f10'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Amortization of Lease Right</div></td></tr>
<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Depreciation <span id="spg" class="ppk" onclick="minitb('g');">+</span></div></td></tr>
<tr id='g1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Short Lease Building</div></td></tr>
<tr id='g2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Computer Hardware</div></td></tr>
<tr id='g3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Fixtures & Fittings</div></td></tr>
<tr id='g4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Computer Software</div></td></tr>
<tr id='g5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Depreciation of Office Equipment</div></td></tr>
<tr style='font-weight:bold' class='rbg3'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Other Store Costs <span id="sph" class="ppk" onclick="minitb('h');">+</span></div></td></tr>
<tr id='h1'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Service Charges and Other Fees</div></td></tr>
<tr id='h2'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Bank Charges</div></td></tr>
<tr id='h3'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Cash Collection Charge</div></td></tr>
<tr id='h4'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Cleaning</div></td></tr>
<tr id='h5'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Security Guards</div></td></tr>
<tr id='h6'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Carriage</div></td></tr>
<tr id='h7'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Licence Fees</div></td></tr>
<tr id='h8'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Services Charge</div></td></tr>
<tr id='h9'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Fees</div></td></tr>
<tr id='h10'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Utilities</div></td></tr>
<tr id='h11'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Water</div></td></tr>
<tr id='h12'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Gas/Electric</div></td></tr>
<tr id='h13'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Air Cond. - Addition</div></td></tr>
<tr id='h14'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Repair and Maintenance</div></td></tr>
<tr id='h15'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - R&M Other - Fix</div></td></tr>
<tr id='h16'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - R&M Other - Unplan</div></td></tr>
<tr id='h17'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - R&M Computer - Fix</div></td></tr>
<tr id='h18'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - R&M Computer - Unplan</div></td></tr>
<tr id='h19'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Professional Fee</div></td></tr>
<tr id='h20'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Marketing Research</div></td></tr>
<tr id='h21'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Fee</div></td></tr>
<tr id='h22'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Equipment, Materail and Supplies</div></td></tr>
<tr id='h23'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Printing and Stationery</div></td></tr>
<tr id='h24'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Supplies Expenses</div></td></tr>
<tr id='h25'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Equipment</div></td></tr>
<tr id='h26'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Shopfitting</div></td></tr>
<tr id='h27'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Packaging and Other Material</div></td></tr>
<tr id='h28'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Business Travel Expenses</div></td></tr>
<tr id='h29'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Car Parking and Others</div></td></tr>
<tr id='h30'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Travel</div></td></tr>
<tr id='h31'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Accomodation</div></td></tr>
<tr id='h32'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Meal and Entertainment</div></td></tr>
<tr id='h33'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Insurance</div></td></tr>
<tr id='h34'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - All Risk Insurance</div></td></tr>
<tr id='h35'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Health and Life Insurance</div></td></tr>
<tr id='h36'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Penalty and Taxation</div></td></tr>
<tr id='h37'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Taxation</div></td></tr>
<tr id='h38'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Penalty</div></td></tr>
<tr id='h39'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Related Staff Cost></div></td></tr>
<tr id='h40'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Staff Conference and Training</div></td></tr>
<tr id='h41'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Training</div></td></tr>
<tr id='h42'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Communication</div></td></tr>
<tr id='h43'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Telephone Calls/Faxes</div></td></tr>
<tr id='h44'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Postage and Courier</div></td></tr>
<tr id='h45'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Expenses</div></td></tr>
<tr id='h46'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Sample/Tester</div></td></tr>
<tr id='h47'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Preopening Costs</div></td></tr>
<tr id='h48'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Loss on Claim</div></td></tr>
<tr id='h49'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Cash Overtage/Shortage from sales</div></td></tr>
<tr id='h50'><td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Miscellenous and Other</div></td></tr>
<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Store Trading Profit / (Loss)</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">
    % Store Trading Profit Growth-YOY</div></td></tr>
<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style="width:250px;padding-left:5px;" class="pptk">
    % Store Trading Profit Growth-LFL</div></td></tr>

</table>
            </asp:Panel>
         </td>
         <td valign="top">
         <asp:DataList ID="dl" runat="server"
        RepeatDirection="Horizontal" BorderWidth="0px" CellPadding="0" 
        BorderStyle="None">
        <ItemTemplate>
            <asp:Label ID="lbl" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:DataList>
         </td>
          <td>
<div class="scroll">
    <asp:DataList ID="DataList2" runat="server"
        RepeatDirection="Horizontal" BorderWidth="0px" CellPadding="0" 
        BorderStyle="None">
        <ItemTemplate>
             <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </ItemTemplate>
    </asp:DataList>
</div>
          </td>
      </tr>
    </table>
    </div>
    <asp:ObjectDataSource ID="odsMtd" runat="server" 
    SelectMethod="getSumFullMtdModel" TypeName="ClsDB" 
        OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="years" Type="String" />
        <asp:Parameter Name="mon" Type="String" />
         <asp:Parameter Name="locate" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter ConvertEmptyStringToNull="False" Name="rate" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsYtd" runat="server" 
    SelectMethod="getSumFullYtdModel" TypeName="ClsDB" 
        OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="years" Type="String" />
        <asp:Parameter Name="mon" Type="String" />
         <asp:Parameter Name="locate" Type="String" ConvertEmptyStringToNull="False" />
           <asp:Parameter Name="start_time" Type="String" />
        <asp:Parameter ConvertEmptyStringToNull="False" Name="rate" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>

         <asp:HiddenField ID="hdfExcel" runat="server" />
        <asp:HiddenField ID="hdfIndex" runat="server" />
    </asp:Panel>    

    <br />
    <br />
</asp:Content>

