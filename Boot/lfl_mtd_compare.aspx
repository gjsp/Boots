<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="lfl_mtd_compare.aspx.vb" Inherits="lfl_mtd_compare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                var x = $get('ContentPlaceHolder1_TbCk').value;
                if ($get(z + y).style.display == "none") {
                    $get(z + y).style.display = "";
                    for (i = 1; i <= x; i++) {
                        $get(z + y + "c" + i).style.display = "";
                    }
                } else {
                    $get(z + y).style.display = "none";
                    for (i = 1; i <= x; i++) {
                        $get(z + y + "c" + i).style.display = "none";
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
                var x = $get('ContentPlaceHolder1_TbCk').value;
                for (i = 1; i <= x; i++) {
                    $get(z + y).style.display = "none";
                    $get(z + y + "c" + i).style.display = "none";
                }
            }
        }
        //-->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 10px 10px;">
        <strong>Compare MTD LFL Report</strong>
        <span style="font-size:11px">
        (Note : All number represents performance at retail store contribution level only, excluding stock loss & obsolete provision at warehouse, supplier income and other central cost allocation which are A&P, head office cost)
        </span>
       <br />
        <br/>
        <div style="float: left; margin-right: .5cm">
            Store
            <asp:DropDownList ID="ddlModel" runat="server" CssClass="select2">
                <asp:ListItem Text="LFL" Value="LFL"></asp:ListItem>
                <asp:ListItem Text="Non LFL" Value="NonLFL"></asp:ListItem>
                <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                <asp:ListItem Text="Other Business" Value="OtherBusiness"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="float: left; margin-right: .5cm">
            Format
            <asp:DropDownList ID="ddlFormat" runat="server" CssClass="select2">
                
            </asp:DropDownList>
        </div>
        <div style="float: left; margin-right: .5cm">
            By
            <asp:DropDownList ID="ddlBy" runat="server" CssClass="select2">
                <asp:ListItem Text="MTD"></asp:ListItem>
                <asp:ListItem Text="YTD"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="float: left; margin-right: .5cm">
            Date :
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="select2">
            </asp:DropDownList>
            <asp:TextBox ID="TbCk" runat="server" Style="display: none;"></asp:TextBox>
        </div>
        <div style="float: left; margin-right: .5cm">
            Currency Rate :
            <asp:DropDownList ID="ddlRate" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <asp:Button ID="SearchBt" runat="server" Text="Search" Height="23px" />
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <br />
        <asp:LinkButton ID="linkExcel" runat="server" Style="color: #37a700;">Export</asp:LinkButton>
        <br />
        <br />
        <div id="temp_body" runat="server">
            <table cellspacing='0' cellpadding='0' class='tb_block'>
                <tr>
                    <td valign="top">
                        <asp:Panel ID="Pftb" runat="server">
                            <table cellspacing='0' cellpadding='0' class='tball'>
                                <tr style='font-weight: bold;' class='kbg1'>
                                    <td align='left'>
                                        <div style="width: 250px; padding-left: 5px;" class="pptk">
                                            Number of Stores</div>
                                    </td>
                                   
                                </tr>
                                <tr style='font-weight: bold;' class='kbg1'>
                                    <td align='left'>
                                        <div style="width: 250px; padding-left: 5px;">
                                        &nbsp;
                                        </div>
                                    </td>
                                   
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 250px; padding-left: 5px;" class="pptk">
                                            Total Gross Space (SQM)</div>
                                    </td>
                                    
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 250px; padding-left: 5px;" class="pptk">
                                            Total Selling Space (SQM)</div>
                                    </td>
                                    
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 250px; padding-left: 5px;" class="pptk">
                                            Productivity/SQM</div>
                                    </td>
                                   
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 250px; padding-left: 5px;">
                                            &nbsp;</div>
                                    </td>
                                    
                                </tr>
                                <tr style='font-weight: bold;' class='kbg5'>
                                    <td align='left'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Total Revenue <span id="spaa" class="ppk" onclick="minitb('aa');">+</span></div>
                                    </td>
                                   
                                </tr>
                                <tr id='aa1'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Sale Revenue</div>
                                    </td>
                                  
                                </tr>
                                <tr id='aa2'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Revenue</div>
                                    </td>
                                   
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Cost of Good Sold</div>
                                    </td>
                                    
                                </tr>
                                <tr style='font-weight: bold;' class='kbg5'>
                                    <td align='left'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Gross Retails Profit</div>
                                    </td>
                                   
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Margin Adjustments <span id="spb" class="ppk" onclick="minitb('b');">+</span></div>
                                    </td>
                                   
                                </tr>
                                <tr id='b1'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Shipping</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b2'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Stock Loss and Obsolescence</div>
                                    </td>
                                    
                                </tr>
                                <tr id='b3'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Stock Check (Actual)</div>
                                    </td>
                                  
                                </tr>
                                <tr id='b4'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Damaged and Obsolete Stock (Actual)</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b5'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Stock Loss (Provision)</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b6'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Stock Obsolescence (Provision)</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b7'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - GWP</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b8'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - GWPs - Corporate</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b9'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - GWPs - Transferred</div>
                                    </td>
                                  
                                </tr>
                                <tr id='b10'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Selling Costs</div>
                                    </td>
                                    
                                </tr>
                                <tr id='b11'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Credit Cards Commission</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b12'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Labelling Material</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b13'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Income - COSH Funding</div>
                                    </td>
                                   
                                </tr>
                                <tr id='b14'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Income Supplier</div>
                                    </td>
                                  
                                </tr>
                                <tr style='font-weight: bold;' class='kbg5'>
                                    <td align='left'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Adjusted Gross Retails Profit</div>
                                    </td>
                                   
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Supply Chain Costs</div>
                                    </td>
                                 
                                </tr>
                                <tr style='font-weight: bold;' class='kbg5'>
                                    <td align='left'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Total Store Expenses</div>
                                    </td>
                                  
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Store Labour Costs <span id="spe" class="ppk" onclick="minitb('e');">+</span></div>
                                    </td>
                                 
                                </tr>
                                <tr id='e1'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Gross Pay</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e2'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Temporary Staff Costs</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e3'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Allowance</div>
                                    </td>
                                 
                                </tr>
                                <tr id='e4'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Overtime</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e5'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - License Fee</div>
                                    </td>
                                  
                                </tr>
                                <tr id='e6'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Bonuses/Incentives</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e7'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Boots Brand ncentives</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e8'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Suppliers Incentive</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e9'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Provident Fund</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e10'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Pension Costs</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e11'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Social Security Fund</div>
                                    </td>
                                    
                                </tr>
                                <tr id='e12'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Uniforms</div>
                                    </td>
                                   
                                </tr>
                                <tr id='e13'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Employee Welfare</div>
                                    </td>
                                  
                                </tr>
                                <tr id='e14'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Benefits Employee</div>
                                    </td>
                                 
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Store Property Costs <span id="spf" class="ppk" onclick="minitb('f');">+</span></div>
                                    </td>
                                   
                                </tr>
                                <tr id='f1'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Property Rental</div>
                                    </td>
                                  
                                </tr>
                                <tr id='f2'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Property Services</div>
                                    </td>
                                  
                                </tr>
                                <tr id='f3'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Property Facility</div>
                                    </td>
                                   
                                </tr>
                                <tr id='f4'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Property Taxes</div>
                                    </td>
                                   
                                </tr>
                                <tr id='f5'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Facial Taxes</div>
                                    </td>
                                   
                                </tr>
                                <tr id='f6'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Property Insurance</div>
                                    </td>
                                   
                                </tr>
                                <tr id='f7'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Signboard</div>
                                    </td>
                                   
                                </tr>
                                <tr id='f8'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Discount - Rent/Services/Facility</div>
                                    </td>
                                   
                                </tr>
                                <tr id='f9'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - GP Commission</div>
                                    </td>
                                  
                                </tr>
                                <tr id='f10'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Amortization of Lease Right</div>
                                    </td>
                                  
                                </tr>
                                <tr style='font-weight: bold;'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Depreciation <span id="spg" class="ppk" onclick="minitb('g');">+</span></div>
                                    </td>
                                   
                                </tr>
                                <tr id='g1'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Depreciation of Short Lease Building</div>
                                    </td>
                                   
                                </tr>
                                <tr id='g2'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Depreciation of Computer Hardware</div>
                                    </td>
                                   
                                </tr>
                                <tr id='g3'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Depreciation of Fixtures & Fittings</div>
                                    </td>
                                   
                                </tr>
                                <tr id='g4'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Depreciation of Computer Software</div>
                                    </td>
                                  
                                </tr>
                                <tr id='g5'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Depreciation of Office Equipment</div>
                                    </td>
                                   
                                </tr>
                                <tr style='font-weight: bold;' class='kbg2'>
                                    <td align='left'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Other Store Costs <span id="sph" class="ppk" onclick="minitb('h');">+</span></div>
                                    </td>
                                   
                                </tr>
                                <tr id='h1'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Service Charges and Other Fees</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h2'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Bank Charges</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h3'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Cash Collection Charge</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h4'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Cleaning</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h5'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Security Guards</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h6'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Carriage</div>
                                    </td>
                                  
                                </tr>
                                <tr id='h7'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Licence Fees</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h8'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Services Charge</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h9'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Fees</div>
                                    </td>
                                  
                                </tr>
                                <tr id='h10'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Utilities</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h11'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Water</div>
                                    </td>
                                  
                                </tr>
                                <tr id='h12'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Gas/Electric</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h13'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Air Cond. - Addition</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h14'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Repair and Maintenance</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h15'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - R&M Other - Fix</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h16'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - R&M Other - Unplan</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h17'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - R&M Computer - Fix</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h18'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - R&M Computer - Unplan</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h19'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Professional Fee</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h20'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Marketing Research</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h21'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Fee</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h22'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Equipment, Materail and Supplies</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h23'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Printing and Stationery</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h24'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Supplies Expenses</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h25'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Equipment</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h26'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Shopfitting</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h27'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Packaging and Other Material</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h28'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Business Travel Expenses</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h29'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Car Parking and Others</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h30'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Travel</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h31'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Accomodation</div>
                                    </td>
                                  
                                </tr>
                                <tr id='h32'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Meal and Entertainment</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h33'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Insurance</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h34'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - All Risk Insurance</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h35'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Health and Life Insurance</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h36'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Penalty and Taxation</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h37'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Taxation</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h38'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Penalty</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h39'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Related Staff Cost</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h40'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Staff Conference and Training</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h41'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Training</div>
                                    </td>
                                  
                                </tr>
                                <tr id='h42'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Communication</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h43'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Telephone Calls/Faxes</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h44'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Postage and Courier</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h45'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Other Expenses</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h46'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Sample/Tester</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h47'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Preopening Costs</div>
                                    </td>
                                    
                                </tr>
                                <tr id='h48'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Loss on Claim</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h49'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Cash Over/Shortage from sales</div>
                                    </td>
                                   
                                </tr>
                                <tr id='h50'>
                                    <td align='left' class='kbg2'>
                                        <div style="width: 200px; padding-left: 5px;">
                                            - Miscellenous and Other</div>
                                    </td>
                                    
                                </tr>
                                <tr style='font-weight: bold;' class='kbg5'>
                                    <td align='left'>
                                        <div style="width: 200px; padding-left: 5px;" class="pptk">
                                            Store Trading Profit / (Loss)</div>
                                    </td>
                                   
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td>
                        <div class="scroll3">
                            <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal"
                                BorderWidth="0px" CellPadding="0" BorderStyle="None" CssClass="k-right-border">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <asp:ObjectDataSource ID="odsMonth" runat="server" SelectMethod="getSumFullCompareMtdLflByStoreByMonth"
            TypeName="ClsDB" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter Name="years" Type="String" />
                <asp:Parameter Name="mon" Type="String" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="store_id" Type="String" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="rate" Type="String" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="growth" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="odsYear" runat="server" SelectMethod="getSumFullCompareMtdLflByStoreByYear"
            TypeName="ClsDB" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter Name="years" Type="String" />
                <asp:Parameter Name="mon" Type="String" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="store_id" Type="String" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="rate" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="hdfExcel" runat="server" />
    </asp:Panel>
    <br />
    <br />
</asp:Content>
