Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class clsHtml

    Enum tablePart
        head = 1
        body
        foot
    End Enum

#Region "SQL"
    Public Shared Function getTempClose() As String
        Try
            Dim str As String = "" & _
            "select distinct tempc_costcenter_id from ( " & _
            "select *,CASE WHEN (tempc_start IS null and tempc_finish >= @bDate ) OR (tempc_start IS null and tempc_finish >= @eDate ) THEN 1 " & _
            "WHEN (tempc_start <= dateadd(month,1,dateadd(day,-1, @bDate)) and tempc_finish IS null) OR (tempc_start <= dateadd(month,1,dateadd(day,-1, @eDate)) and tempc_finish IS null) THEN 1 " & _
            "WHEN (tempc_start <= dateadd(month,1,dateadd(day,-1, @bDate)) and tempc_finish >= @bDate) OR (tempc_start <= dateadd(month,1,dateadd(day,-1, @eDate)) and tempc_finish >= @eDate) " & _
            "THEN 1 ELSE 0 END AS status_at from tempc) as tt where status_at = 1"

            Return str
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "MTD"
    Public Shared Function htmlModelTopic() As String
        Dim sb As New StringBuilder
        sb.Append("<table cellspacing='0' cellpadding='0' class='tball2'>")
        sb.Append("<tr style='font-weight:bold;' class='rbg0'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>{0}</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;height:31px' class='rbg1'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;{1}&nbsp;</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Number of Stores</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Total Gross Space (SQM)</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Total Selling Space (SQM)</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Productivity/SQM</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Revenue Growth-YOY</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Revenue Growth-LFL</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Revenue <span id='spaa' class='ppk' onclick=""minitb('aa');"">+</span></div></td></tr>")
        sb.Append("<tr id='aa1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sale Revenue</div></td></tr>")
        sb.Append("<tr id='aa2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Revenue</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Cost of Good Sold</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Gross Retails Profit</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Margin Adjustments <span id='spb' class='ppk' onclick=""minitb('b');"">+</span></div></td></tr>")
        sb.Append("<tr id='b1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shipping</div></td></tr>")
        sb.Append("<tr id='b2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss and Obsolescence</div></td></tr>")
        sb.Append("<tr id='b3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - stock check (Actual)</div></td></tr>")
        sb.Append("<tr id='b4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - damaged and obsolete stock (Actual)</div></td></tr>")
        sb.Append("<tr id='b5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss  (Provision)</div></td></tr>")
        sb.Append("<tr id='b6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Obsolescence (Provision)</div></td></tr>")
        sb.Append("<tr id='b7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWP</div></td></tr>")
        sb.Append("<tr id='b8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWPs - Corporate</div></td></tr>")
        sb.Append("<tr id='b9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWPs - Transferred</div></td></tr>")
        sb.Append("<tr id='b10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Selling Costs</div></td></tr>")
        sb.Append("<tr id='b11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Credit cards commission</div></td></tr>")
        sb.Append("<tr id='b12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Labelling Material</div></td></tr>")
        sb.Append("<tr id='b13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Income - COSH Funding</div></td></tr>")
        sb.Append("<tr id='b14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Income Supplier</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Adjusted Gross Retails Profit</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg4'><td align='left' class='kbg2';'><div style='width:200px;padding-left:5px;' class='pptk'>Supply Chain Costs</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Store Expenses</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Store Labour Costs <span id='spe' class='ppk' onclick=""minitb('e');"">+</span></div></td></tr>")
        sb.Append("<tr id='e1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Gross Pay</div></td></tr>")
        sb.Append("<tr id='e2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Temporary Staff Costs</div></td></tr>")
        sb.Append("<tr id='e3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Allowance</div></td></tr>")
        sb.Append("<tr id='e4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Overtime</div></td></tr>")
        sb.Append("<tr id='e5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - License fee</div></td></tr>")
        sb.Append("<tr id='e6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Bonuses/Incentives</div></td></tr>")
        sb.Append("<tr id='e7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Boots Brand ncentives</div></td></tr>")
        sb.Append("<tr id='e8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Suppliers Incentive</div></td></tr>")
        sb.Append("<tr id='e9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Provident Fund</div></td></tr>")
        sb.Append("<tr id='e10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Pension Costs</div></td></tr>")
        sb.Append("<tr id='e11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Social Security Fund</div></td></tr>")
        sb.Append("<tr id='e12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Uniforms</div></td></tr>")
        sb.Append("<tr id='e13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Employee Welfare</div></td></tr>")
        sb.Append("<tr id='e14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Benefits Employee</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Store Property Costs <span id='spf' class='ppk' onclick=""minitb('f');"">+</span></div></td></tr>")
        sb.Append("<tr id='f1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Rental</div></td></tr>")
        sb.Append("<tr id='f2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Services</div></td></tr>")
        sb.Append("<tr id='f3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Facility</div></td></tr>")
        sb.Append("<tr id='f4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property taxes</div></td></tr>")
        sb.Append("<tr id='f5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Facial taxes</div></td></tr>")
        sb.Append("<tr id='f6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Insurance</div></td></tr>")
        sb.Append("<tr id='f7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Signboard</div></td></tr>")
        sb.Append("<tr id='f8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Discount - Rent/Services/Facility</div></td></tr>")
        sb.Append("<tr id='f9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GP Commission</div></td></tr>")
        sb.Append("<tr id='f10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Amortization of Lease Right</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Depreciation <span id='spg' class='ppk' onclick=""minitb('g');"">+</span></div></td></tr>")
        sb.Append("<tr id='g1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Short Lease Building</div></td></tr>")
        sb.Append("<tr id='g2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Computer Hardware</div></td></tr>")
        sb.Append("<tr id='g3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Fixtures & Fittings</div></td></tr>")
        sb.Append("<tr id='g4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Computer Software</div></td></tr>")
        sb.Append("<tr id='g5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Office Equipment</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' class='rbg3'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Other Store Costs <span id='sph' class='ppk' onclick=""minitb('h');"">+</span></div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Service Charges and Other Fees</div></td></tr>")

        sb.Append("<tr id='h2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Bank Charges</div></td></tr>")
        sb.Append("<tr id='h3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cash Collection Charge</div></td></tr>")
        sb.Append("<tr id='h4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cleaning</div></td></tr>")
        sb.Append("<tr id='h5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Security Guards</div></td></tr>")
        sb.Append("<tr id='h6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Carriage</div></td></tr>")
        sb.Append("<tr id='h7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Licence Fees</div></td></tr>")
        sb.Append("<tr id='h8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Services Charge</div></td></tr>")
        sb.Append("<tr id='h9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Fees</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Utilities</div></td></tr>")

        sb.Append("<tr id='h11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Water</div></td></tr>")
        sb.Append("<tr id='h12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Gas/Electric</div></td></tr>")
        sb.Append("<tr id='h13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Air Cond. - Addition</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Repair and Maintenance</div></td></tr>")

        sb.Append("<tr id='h15'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Other - Fix</div></td></tr>")
        sb.Append("<tr id='h16'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Other - Unplan</div></td></tr>")
        sb.Append("<tr id='h17'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Computer - Fix</div></td></tr>")
        sb.Append("<tr id='h18'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Computer - Unplan</div></td></tr>")
        'new line
        sb.Append("<tr id='h51'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - SW Maintenance</div></td></tr>")
        sb.Append("<tr id='h52'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - HW Maintenance</div></td></tr>")

        sb.Append("<tr style='font-weight:bold' id='h19'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Professional Fee</div></td></tr>")

        sb.Append("<tr id='h20'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Marketing Research</div></td></tr>")
        sb.Append("<tr id='h21'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Fee</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h22'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Equipment, Materail and Supplies</div></td></tr>")

        sb.Append("<tr id='h23'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Printing and Stationery</div></td></tr>")
        sb.Append("<tr id='h24'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Supplies Expenses</div></td></tr>")
        sb.Append("<tr id='h25'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Equipment</div></td></tr>")
        sb.Append("<tr id='h26'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shopfitting</div></td></tr>")
        sb.Append("<tr id='h27'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Packaging and Other Material</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h28'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Business Travel Expenses</div></td></tr>")

        sb.Append("<tr id='h29'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Car Parking and Others</div></td></tr>")
        sb.Append("<tr id='h30'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Travel</div></td></tr>")
        sb.Append("<tr id='h31'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Accomodation</div></td></tr>")
        sb.Append("<tr id='h32'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Meal and Entertainment</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h33'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Insurance</div></td></tr>")

        sb.Append("<tr id='h34'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - All Risk Insurance</div></td></tr>")
        sb.Append("<tr id='h35'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Health and Life Insurance</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h36'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Penalty and Taxation</div></td></tr>")

        sb.Append("<tr id='h37'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Taxation</div></td></tr>")
        sb.Append("<tr id='h38'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Penalty</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h39'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Related Staff Cost</div></td></tr>")

        sb.Append("<tr id='h40'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Staff Conference and Training</div></td></tr>")
        sb.Append("<tr id='h41'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Training</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h42'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Communication</div></td></tr>")

        sb.Append("<tr id='h43'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Telephone Calls/Faxes</div></td></tr>")
        sb.Append("<tr id='h44'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Postage and Courier</div></td></tr>")
        'new line
        sb.Append("<tr id='h53'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - IT Telecommunications</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h45'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Expenses</div></td></tr>")

        sb.Append("<tr id='h46'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sample/Tester</div></td></tr>")
        sb.Append("<tr id='h47'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Preopening Costs</div></td></tr>")
        sb.Append("<tr id='h48'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Loss on Claim</div></td></tr>")
        sb.Append("<tr id='h49'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cash Overtage/Shortage from sales</div></td></tr>")
        sb.Append("<tr id='h50'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Miscellenous and Other</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Store Trading Profit / (Loss)</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Store Trading Profit Growth-YOY</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Store Trading Profit Growth-LFL</div></td></tr>")
        sb.Append("</table>")

        Return sb.ToString
    End Function

    Public Shared Function htmlModelItem(part As tablePart, Optional hasBorder As Boolean = False) As String

        Select Case part
            Case 1
                Dim tbHead As New StringBuilder

                'for border (ตีกรอบ)
                Dim tblClass As String = "tball2"
                If hasBorder Then
                    tblClass = "tbTotal"
                End If
                'tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
                tbHead.Append(String.Format("<TABLE cellspacing='0' cellpadding='0' class='{0}'>", tblClass))
                tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='2'><strong>{0}</strong></TD></TR>")

                'assing width this row
                tbHead.Append("<TR style='font-weight:bold;height:30px' class='rbg1'><TD align='center'><div style='width:90px'><strong>{1}</strong></div></TD><TD align='center'><div style='width:60px;'><strong>% Sale</strong></div></TD></TR>")

                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' ><strong>{2}</strong></TD><TD align='center'><div style='width:60px;'><strong></strong></div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'>{3}</TD><TD align='center' class='rbg2'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{4}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{5}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR><TD></TD><TD>&nbsp;</TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{6}</TD><TD>&nbsp;</TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{7}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR><TD></TD><TD>&nbsp;</TD></TR>")

                Return tbHead.ToString
            Case 2
                Dim tbBody As New StringBuilder
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{3}</TD><TD align='right'><div style='width:60px;'>{4}%</div></TD></TR>")
                tbBody.Append("<TR id='aa1c{1}'><TD align='right'>{6}</TD><TD align='right'><div style='width:60px;'>{7}%</div></TD></TR>")
                tbBody.Append("<TR id='aa2c{1}'><TD align='right'>{9}</TD><TD align='right'><div style='width:60px;'>{10}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'>{12}</TD><TD align='right'><div style='width:60px;'>{13}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{15}</TD><TD align='right'><div style='width:60px;'>{16}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'>{18}</TD><TD align='right'><div style='width:60px;'>{19}%</div></TD></TR>")
                tbBody.Append("<TR id='b1c{1}'><TD align='right'>{21}</TD><TD align='right'><div style='width:60px;'>{22}%</div></TD></TR>")
                tbBody.Append("<TR id='b2c{1}'><TD align='right'>{24}</TD><TD align='right'><div style='width:60px;'>{25}%</div></TD></TR>")
                tbBody.Append("<TR id='b3c{1}'><TD align='right'>{27}</TD><TD align='right'><div style='width:60px;'>{28}%</div></TD></TR>")
                tbBody.Append("<TR id='b4c{1}'><TD align='right'>{30}</TD><TD align='right'><div style='width:60px;'>{31}%</div></TD></TR>")
                tbBody.Append("<TR id='b5c{1}'><TD align='right'>{33}</TD><TD align='right'><div style='width:60px;'>{34}%</div></TD></TR>")
                tbBody.Append("<TR id='b6c{1}'><TD align='right'>{36}</TD><TD align='right'><div style='width:60px;'>{37}%</div></TD></TR>")
                tbBody.Append("<TR id='b7c{1}'><TD align='right'>{39}</TD><TD align='right'><div style='width:60px;'>{40}%</div></TD></TR>")
                tbBody.Append("<TR id='b8c{1}'><TD align='right'>{42}</TD><TD align='right'><div style='width:60px;'>{43}%</div></TD></TR>")
                tbBody.Append("<TR id='b9c{1}'><TD align='right'>{45}</TD><TD align='right'><div style='width:60px;'>{46}%</div></TD></TR>")
                tbBody.Append("<TR id='b10c{1}'><TD align='right'>{48}</TD><TD align='right'><div style='width:60px;'>{49}%</div></TD></TR>")
                tbBody.Append("<TR id='b11c{1}'><TD align='right'>{51}</TD><TD align='right'><div style='width:60px;'>{52}%</div></TD></TR>")
                tbBody.Append("<TR id='b12c{1}'><TD align='right'>{54}</TD><TD align='right'><div style='width:60px;'>{55}%</div></TD></TR>")
                tbBody.Append("<TR id='b13c{1}'><TD align='right'>{57}</TD><TD align='right'><div style='width:60px;'>{58}%</div></TD></TR>")
                tbBody.Append("<TR id='b14c{1}'><TD align='right'>{60}</TD><TD align='right'><div style='width:60px;'>{61}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{63}</TD><TD align='right'><div style='width:60px;'>{64}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg4'><TD align='right'>{66}</TD><TD align='right'><div style='width:60px;'>{67}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{69}</TD><TD align='right'><div style='width:60px;'>{70}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{72}</TD><TD align='right'><div style='width:60px;'>{73}%</div></TD></TR>")
                tbBody.Append("<TR id='e1c{1}'><TD align='right'>{75}</TD><TD align='right'><div style='width:60px;'>{76}%</div></TD></TR>")
                tbBody.Append("<TR id='e2c{1}'><TD align='right'>{78}</TD><TD align='right'><div style='width:60px;'>{79}%</div></TD></TR>")
                tbBody.Append("<TR id='e3c{1}'><TD align='right'>{81}</TD><TD align='right'><div style='width:60px;'>{82}%</div></TD></TR>")
                tbBody.Append("<TR id='e4c{1}'><TD align='right'>{84}</TD><TD align='right'><div style='width:60px;'>{85}%</div></TD></TR>")
                tbBody.Append("<TR id='e5c{1}'><TD align='right'>{87}</TD><TD align='right'><div style='width:60px;'>{88}%</div></TD></TR>")
                tbBody.Append("<TR id='e6c{1}'><TD align='right'>{90}</TD><TD align='right'><div style='width:60px;'>{91}%</div></TD></TR>")
                tbBody.Append("<TR id='e7c{1}'><TD align='right'>{93}</TD><TD align='right'><div style='width:60px;'>{94}%</div></TD></TR>")
                tbBody.Append("<TR id='e8c{1}'><TD align='right'>{96}</TD><TD align='right'><div style='width:60px;'>{97}%</div></TD></TR>")
                tbBody.Append("<TR id='e9c{1}'><TD align='right'>{99}</TD><TD align='right'><div style='width:60px;'>{100}%</div></TD></TR>")
                tbBody.Append("<TR id='e10c{1}'><TD align='right'>{102}</TD><TD align='right'><div style='width:60px;'>{103}%</div></TD></TR>")
                tbBody.Append("<TR id='e11c{1}'><TD align='right'>{105}</TD><TD align='right'><div style='width:60px;'>{106}%</div></TD></TR>")
                tbBody.Append("<TR id='e12c{1}'><TD align='right'>{108}</TD><TD align='right'><div style='width:60px;'>{109}%</div></TD></TR>")
                tbBody.Append("<TR id='e13c{1}'><TD align='right'>{111}</TD><TD align='right'><div style='width:60px;'>{112}%</div></TD></TR>")
                tbBody.Append("<TR id='e14c{1}'><TD align='right'>{114}</TD><TD align='right'><div style='width:60px;'>{115}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{117}</TD><TD align='right'><div style='width:60px;'>{118}%</div></TD></TR>")
                tbBody.Append("<TR id='f1c{1}'><TD align='right'>{120}</TD><TD align='right'><div style='width:60px;'>{121}%</div></TD></TR>")
                tbBody.Append("<TR id='f2c{1}'><TD align='right'>{123}</TD><TD align='right'><div style='width:60px;'>{124}%</div></TD></TR>")
                tbBody.Append("<TR id='f3c{1}'><TD align='right'>{126}</TD><TD align='right'><div style='width:60px;'>{127}%</div></TD></TR>")
                tbBody.Append("<TR id='f4c{1}'><TD align='right'>{129}</TD><TD align='right'><div style='width:60px;'>{130}%</div></TD></TR>")
                tbBody.Append("<TR id='f5c{1}'><TD align='right'>{132}</TD><TD align='right'><div style='width:60px;'>{133}%</div></TD></TR>")
                tbBody.Append("<TR id='f6c{1}'><TD align='right'>{135}</TD><TD align='right'><div style='width:60px;'>{136}%</div></TD></TR>")
                tbBody.Append("<TR id='f7c{1}'><TD align='right'>{138}</TD><TD align='right'><div style='width:60px;'>{139}%</div></TD></TR>")
                tbBody.Append("<TR id='f8c{1}'><TD align='right'>{141}</TD><TD align='right'><div style='width:60px;'>{142}%</div></TD></TR>")
                tbBody.Append("<TR id='f9c{1}'><TD align='right'>{144}</TD><TD align='right'><div style='width:60px;'>{145}%</div></TD></TR>")
                tbBody.Append("<TR id='f10c{1}'><TD align='right'>{147}</TD><TD align='right'><div style='width:60px;'>{148}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{150}</TD><TD align='right'><div style='width:60px;'>{151}%</div></TD></TR>")
                tbBody.Append("<TR id='g1c{1}'><TD align='right'>{153}</TD><TD align='right'><div style='width:60px;'>{154}%</div></TD></TR>")
                tbBody.Append("<TR id='g2c{1}'><TD align='right'>{156}</TD><TD align='right'><div style='width:60px;'>{157}%</div></TD></TR>")
                tbBody.Append("<TR id='g3c{1}'><TD align='right'>{159}</TD><TD align='right'><div style='width:60px;'>{160}%</div></TD></TR>")
                tbBody.Append("<TR id='g4c{1}'><TD align='right'>{162}</TD><TD align='right'><div style='width:60px;'>{163}%</div></TD></TR>")
                tbBody.Append("<TR id='g5c{1}'><TD align='right'>{165}</TD><TD align='right'><div style='width:60px;'>{166}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{168}</TD><TD align='right'><div style='width:60px;'>{169}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h1c{1}'><TD align='right'>{171}</TD><TD align='right'><div style='width:60px;'>{172}%</div></TD></TR>")

                tbBody.Append("<TR id='h2c{1}'><TD align='right'>{174}</TD><TD align='right'><div style='width:60px;'>{175}%</div></TD></TR>")
                tbBody.Append("<TR id='h3c{1}'><TD align='right'>{177}</TD><TD align='right'><div style='width:60px;'>{178}%</div></TD></TR>")
                tbBody.Append("<TR id='h4c{1}'><TD align='right'>{180}</TD><TD align='right'><div style='width:60px;'>{181}%</div></TD></TR>")
                tbBody.Append("<TR id='h5c{1}'><TD align='right'>{183}</TD><TD align='right'><div style='width:60px;'>{184}%</div></TD></TR>")
                tbBody.Append("<TR id='h6c{1}'><TD align='right'>{186}</TD><TD align='right'><div style='width:60px;'>{187}%</div></TD></TR>")
                tbBody.Append("<TR id='h7c{1}'><TD align='right'>{189}</TD><TD align='right'><div style='width:60px;'>{190}%</div></TD></TR>")
                tbBody.Append("<TR id='h8c{1}'><TD align='right'>{192}</TD><TD align='right'><div style='width:60px;'>{193}%</div></TD></TR>")
                tbBody.Append("<TR id='h9c{1}'><TD align='right'>{195}</TD><TD align='right'><div style='width:60px;'>{196}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h10c{1}'><TD align='right'>{198}</TD><TD align='right'><div style='width:60px;'>{199}%</div></TD></TR>")

                tbBody.Append("<TR id='h11c{1}'><TD align='right'>{201}</TD><TD align='right'><div style='width:60px;'>{202}%</div></TD></TR>")
                tbBody.Append("<TR id='h12c{1}'><TD align='right'>{204}</TD><TD align='right'><div style='width:60px;'>{205}%</div></TD></TR>")
                tbBody.Append("<TR id='h13c{1}'><TD align='right'>{207}</TD><TD align='right'><div style='width:60px;'>{208}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h14c{1}'><TD align='right'>{210}</TD><TD align='right'><div style='width:60px;'>{211}%</div></TD></TR>")

                tbBody.Append("<TR id='h15c{1}'><TD align='right'>{213}</TD><TD align='right'><div style='width:60px;'>{214}%</div></TD></TR>")
                tbBody.Append("<TR id='h16c{1}'><TD align='right'>{216}</TD><TD align='right'><div style='width:60px;'>{217}%</div></TD></TR>")
                tbBody.Append("<TR id='h17c{1}'><TD align='right'>{219}</TD><TD align='right'><div style='width:60px;'>{220}%</div></TD></TR>")
                tbBody.Append("<TR id='h18c{1}'><TD align='right'>{222}</TD><TD align='right'><div style='width:60px;'>{223}%</div></TD></TR>")
                'new line
                tbBody.Append("<TR id='h51c{1}'><TD align='right'>{324}</TD><TD align='right'><div style='width:60px;'>{325}%</div></TD></TR>")
                tbBody.Append("<TR id='h52c{1}'><TD align='right'>{327}</TD><TD align='right'><div style='width:60px;'>{328}%</div></TD></TR>")

                tbBody.Append("<TR style='font-weight:bold' id='h19c{1}'><TD align='right'>{225}</TD><TD align='right'><div style='width:60px;'>{226}%</div></TD></TR>")

                tbBody.Append("<TR id='h20c{1}'><TD align='right'>{228}</TD><TD align='right'><div style='width:60px;'>{229}%</div></TD></TR>")
                tbBody.Append("<TR id='h21c{1}'><TD align='right'>{231}</TD><TD align='right'><div style='width:60px;'>{232}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h22c{1}'><TD align='right'>{234}</TD><TD align='right'><div style='width:60px;'>{235}%</div></TD></TR>")

                tbBody.Append("<TR id='h23c{1}'><TD align='right'>{237}</TD><TD align='right'><div style='width:60px;'>{238}%</div></TD></TR>")
                tbBody.Append("<TR id='h24c{1}'><TD align='right'>{240}</TD><TD align='right'><div style='width:60px;'>{241}%</div></TD></TR>")
                tbBody.Append("<TR id='h25c{1}'><TD align='right'>{243}</TD><TD align='right'><div style='width:60px;'>{244}%</div></TD></TR>")
                tbBody.Append("<TR id='h26c{1}'><TD align='right'>{246}</TD><TD align='right'><div style='width:60px;'>{247}%</div></TD></TR>")
                tbBody.Append("<TR id='h27c{1}'><TD align='right'>{249}</TD><TD align='right'><div style='width:60px;'>{250}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h28c{1}'><TD align='right'>{252}</TD><TD align='right'><div style='width:60px;'>{253}%</div></TD></TR>")

                tbBody.Append("<TR id='h29c{1}'><TD align='right'>{255}</TD><TD align='right'><div style='width:60px;'>{256}%</div></TD></TR>")
                tbBody.Append("<TR id='h30c{1}'><TD align='right'>{258}</TD><TD align='right'><div style='width:60px;'>{259}%</div></TD></TR>")
                tbBody.Append("<TR id='h31c{1}'><TD align='right'>{261}</TD><TD align='right'><div style='width:60px;'>{262}%</div></TD></TR>")
                tbBody.Append("<TR id='h32c{1}'><TD align='right'>{264}</TD><TD align='right'><div style='width:60px;'>{265}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h33c{1}'><TD align='right'>{267}</TD><TD align='right'><div style='width:60px;'>{268}%</div></TD></TR>")

                tbBody.Append("<TR id='h34c{1}'><TD align='right'>{270}</TD><TD align='right'><div style='width:60px;'>{271}%</div></TD></TR>")
                tbBody.Append("<TR id='h35c{1}'><TD align='right'>{273}</TD><TD align='right'><div style='width:60px;'>{274}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h36c{1}'><TD align='right'>{276}</TD><TD align='right'><div style='width:60px;'>{277}%</div></TD></TR>")

                tbBody.Append("<TR id='h37c{1}'><TD align='right'>{279}</TD><TD align='right'><div style='width:60px;'>{280}%</div></TD></TR>")
                tbBody.Append("<TR id='h38c{1}'><TD align='right'>{282}</TD><TD align='right'><div style='width:60px;'>{283}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h39c{1}'><TD align='right'>{285}</TD><TD align='right'><div style='width:60px;'>{286}%</div></TD></TR>")

                tbBody.Append("<TR id='h40c{1}'><TD align='right'>{288}</TD><TD align='right'><div style='width:60px;'>{289}%</div></TD></TR>")
                tbBody.Append("<TR id='h41c{1}'><TD align='right'>{291}</TD><TD align='right'><div style='width:60px;'>{292}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h42c{1}'><TD align='right'>{294}</TD><TD align='right'><div style='width:60px;'>{295}%</div></TD></TR>")

                tbBody.Append("<TR id='h43c{1}'><TD align='right'>{297}</TD><TD align='right'><div style='width:60px;'>{298}%</div></TD></TR>")
                tbBody.Append("<TR id='h44c{1}'><TD align='right'>{300}</TD><TD align='right'><div style='width:60px;'>{301}%</div></TD></TR>")
                'new line
                tbBody.Append("<TR id='h53c{1}'><TD align='right'>{330}</TD><TD align='right'><div style='width:60px;'>{331}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h45c{1}'><TD align='right'>{303}</TD><TD align='right'><div style='width:60px;'>{304}%</div></TD></TR>")

                tbBody.Append("<TR id='h46c{1}'><TD align='right'>{306}</TD><TD align='right'><div style='width:60px;'>{307}%</div></TD></TR>")
                tbBody.Append("<TR id='h47c{1}'><TD align='right'>{309}</TD><TD align='right'><div style='width:60px;'>{310}%</div></TD></TR>")
                tbBody.Append("<TR id='h48c{1}'><TD align='right'>{312}</TD><TD align='right'><div style='width:60px;'>{313}%</div></TD></TR>")
                tbBody.Append("<TR id='h49c{1}'><TD align='right'>{315}</TD><TD align='right'><div style='width:60px;'>{316}%</div></TD></TR>")
                tbBody.Append("<TR id='h50c{1}'><TD align='right'>{318}</TD><TD align='right'><div style='width:60px;'>{319}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{321}</TD><TD align='right'><div style='width:60px;'>{322}%</div></TD></TR>")

                Return tbBody.ToString
            Case 3
                Dim tbFoot As New StringBuilder
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{0}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{1}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbFoot.Append("</TABLE>")

                Return tbFoot.ToString
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function htmlModelTotal(part As tablePart) As String

        Select Case part
            Case 1
                Dim tbHead As New StringBuilder
                tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='3'><strong>{0}</strong></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;height:30px;' class='rbg1'><TD align='center'><div style='width:90px'><strong>{1}</strong></div></TD><TD align='center'><div style='width:60px;'><strong>% Sale</strong></div></TD> <TD align='center'><div style='width:60px;'><strong>% YOY</strong></div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:90px'><strong>{2}</strong></div></TD><TD align='center'><div style='width:60px;'><strong></strong></div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'><div style='width:90px;'>{3}</div></TD><TD align='center' class='rbg2'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:90px'>{4}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:90px'>{5}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:90px'></div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{6}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{7}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:90px'></div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                Return tbHead.ToString
            Case 2
                Dim tbBody As New StringBuilder
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{3}</div></TD><TD align='right'><div style='width:60px;'>{4}%</div></TD><TD class='tdyoy1'>{5}</TD></TR>")
                tbBody.Append("<TR id='aa1c{1}'><TD align='right'><div style='width:90px'>{6}</div></TD><TD align='right'><div style='width:60px;'>{7}%</div></TD><TD class='tdyoy1'>{8}</TD></TR>")
                tbBody.Append("<TR id='aa2c{1}'><TD align='right'><div style='width:90px'>{9}</div></TD><TD align='right'><div style='width:60px;'>{10}%</div></TD><TD class='tdyoy1'>{11}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:90px'>{12}</div></TD><TD align='right'><div style='width:60px;'>{13}%</div></TD><TD class='tdyoy1'>{14}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{15}</div></TD><TD align='right'><div style='width:60px;'>{16}%</div></TD><TD class='tdyoy1'>{17}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:90px'>{18}</div></TD><TD align='right'><div style='width:60px;'>{19}%</div></TD><TD class='tdyoy1'>{20}</TD></TR>")
                tbBody.Append("<TR id='b1c{1}'><TD align='right'><div style='width:90px'>{21}</div></TD><TD align='right'><div style='width:60px;'>{22}%</div></TD><TD class='tdyoy1'>{23}</TD></TR>")
                tbBody.Append("<TR id='b2c{1}'><TD align='right'><div style='width:90px'>{24}</div></TD><TD align='right'><div style='width:60px;'>{25}%</div></TD><TD class='tdyoy1'>{26}</TD></TR>")
                tbBody.Append("<TR id='b3c{1}'><TD align='right'><div style='width:90px'>{27}</div></TD><TD align='right'><div style='width:60px;'>{28}%</div></TD><TD class='tdyoy1'>{29}</TD></TR>")
                tbBody.Append("<TR id='b4c{1}'><TD align='right'><div style='width:90px'>{30}</div></TD><TD align='right'><div style='width:60px;'>{31}%</div></TD><TD class='tdyoy1'>{32}</TD></TR>")
                tbBody.Append("<TR id='b5c{1}'><TD align='right'><div style='width:90px'>{33}</div></TD><TD align='right'><div style='width:60px;'>{34}%</div></TD><TD class='tdyoy1'>{35}</TD></TR>")
                tbBody.Append("<TR id='b6c{1}'><TD align='right'><div style='width:90px'>{36}</div></TD><TD align='right'><div style='width:60px;'>{37}%</div></TD><TD class='tdyoy1'>{38}</TD></TR>")
                tbBody.Append("<TR id='b7c{1}'><TD align='right'><div style='width:90px'>{39}</div></TD><TD align='right'><div style='width:60px;'>{40}%</div></TD><TD class='tdyoy1'>{41}</TD></TR>")
                tbBody.Append("<TR id='b8c{1}'><TD align='right'><div style='width:90px'>{42}</div></TD><TD align='right'><div style='width:60px;'>{43}%</div></TD><TD class='tdyoy1'>{44}</TD></TR>")
                tbBody.Append("<TR id='b9c{1}'><TD align='right'><div style='width:90px'>{45}</div></TD><TD align='right'><div style='width:60px;'>{46}%</div></TD><TD class='tdyoy1'>{47}</TD></TR>")
                tbBody.Append("<TR id='b10c{1}'><TD align='right'><div style='width:90px'>{48}</div></TD><TD align='right'><div style='width:60px;'>{49}%</div></TD><TD class='tdyoy1'>{50}</TD></TR>")
                tbBody.Append("<TR id='b11c{1}'><TD align='right'><div style='width:90px'>{51}</div></TD><TD align='right'><div style='width:60px;'>{52}%</div></TD><TD class='tdyoy1'>{53}</TD></TR>")
                tbBody.Append("<TR id='b12c{1}'><TD align='right'><div style='width:90px'>{54}</div></TD><TD align='right'><div style='width:60px;'>{55}%</div></TD><TD class='tdyoy1'>{56}</TD></TR>")
                tbBody.Append("<TR id='b13c{1}'><TD align='right'><div style='width:90px'>{57}</div></TD><TD align='right'><div style='width:60px;'>{58}%</div></TD><TD class='tdyoy1'>{59}</TD></TR>")
                tbBody.Append("<TR id='b14c{1}'><TD align='right'><div style='width:90px'>{60}</div></TD><TD align='right'><div style='width:60px;'>{61}%</div></TD><TD class='tdyoy1'>{62}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{63}</div></TD><TD align='right'><div style='width:60px;'>{64}%</div></TD><TD class='tdyoy1'>{65}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg4'><TD align='right'><div style='width:90px'>{66}</div></TD><TD align='right'><div style='width:60px;'>{67}%</div></TD><TD class='tdyoy1'>{68}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{69}</div></TD><TD align='right'><div style='width:60px;'>{70}%</div></TD><TD class='tdyoy1'>{71}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{72}</div></TD><TD align='right'><div style='width:60px;'>{73}%</div></TD><TD class='tdyoy1'>{74}</TD></TR>")
                tbBody.Append("<TR id='e1c{1}'><TD align='right'><div style='width:90px'>{75}</div></TD><TD align='right'><div style='width:60px;'>{76}%</div></TD><TD class='tdyoy1'>{77}</TD></TR>")
                tbBody.Append("<TR id='e2c{1}'><TD align='right'><div style='width:90px'>{78}</div></TD><TD align='right'><div style='width:60px;'>{79}%</div></TD><TD class='tdyoy1'>{80}</TD></TR>")
                tbBody.Append("<TR id='e3c{1}'><TD align='right'><div style='width:90px'>{81}</div></TD><TD align='right'><div style='width:60px;'>{82}%</div></TD><TD class='tdyoy1'>{83}</TD></TR>")
                tbBody.Append("<TR id='e4c{1}'><TD align='right'><div style='width:90px'>{84}</div></TD><TD align='right'><div style='width:60px;'>{85}%</div></TD><TD class='tdyoy1'>{86}</TD></TR>")
                tbBody.Append("<TR id='e5c{1}'><TD align='right'><div style='width:90px'>{87}</div></TD><TD align='right'><div style='width:60px;'>{88}%</div></TD><TD class='tdyoy1'>{89}</TD></TR>")
                tbBody.Append("<TR id='e6c{1}'><TD align='right'><div style='width:90px'>{90}</div></TD><TD align='right'><div style='width:60px;'>{91}%</div></TD><TD class='tdyoy1'>{92}</TD></TR>")
                tbBody.Append("<TR id='e7c{1}'><TD align='right'><div style='width:90px'>{93}</div></TD><TD align='right'><div style='width:60px;'>{94}%</div></TD><TD class='tdyoy1'>{95}</TD></TR>")
                tbBody.Append("<TR id='e8c{1}'><TD align='right'><div style='width:90px'>{96}</div></TD><TD align='right'><div style='width:60px;'>{97}%</div></TD><TD class='tdyoy1'>{98}</TD></TR>")
                tbBody.Append("<TR id='e9c{1}'><TD align='right'><div style='width:90px'>{99}</div></TD><TD align='right'><div style='width:60px;'>{100}%</div></TD><TD class='tdyoy1'>{101}</TD></TR>")
                tbBody.Append("<TR id='e10c{1}'><TD align='right'><div style='width:90px'>{102}</div></TD><TD align='right'><div style='width:60px;'>{103}%</div></TD><TD class='tdyoy1'>{104}</TD></TR>")
                tbBody.Append("<TR id='e11c{1}'><TD align='right'><div style='width:90px'>{105}</div></TD><TD align='right'><div style='width:60px;'>{106}%</div></TD><TD class='tdyoy1'>{107}</TD></TR>")
                tbBody.Append("<TR id='e12c{1}'><TD align='right'><div style='width:90px'>{108}</div></TD><TD align='right'><div style='width:60px;'>{109}%</div></TD><TD class='tdyoy1'>{110}</TD></TR>")
                tbBody.Append("<TR id='e13c{1}'><TD align='right'><div style='width:90px'>{111}</div></TD><TD align='right'><div style='width:60px;'>{112}%</div></TD><TD class='tdyoy1'>{113}</TD></TR>")
                tbBody.Append("<TR id='e14c{1}'><TD align='right'><div style='width:90px'>{114}</div></TD><TD align='right'><div style='width:60px;'>{115}%</div></TD><TD class='tdyoy1'>{116}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{117}</div></TD><TD align='right'><div style='width:60px;'>{118}%</div></TD><TD class='tdyoy1'>{119}</TD></TR>")
                tbBody.Append("<TR id='f1c{1}'><TD align='right'><div style='width:90px'>{120}</div></TD><TD align='right'><div style='width:60px;'>{121}%</div></TD><TD class='tdyoy1'>{122}</TD></TR>")
                tbBody.Append("<TR id='f2c{1}'><TD align='right'><div style='width:90px'>{123}</div></TD><TD align='right'><div style='width:60px;'>{124}%</div></TD><TD class='tdyoy1'>{125}</TD></TR>")
                tbBody.Append("<TR id='f3c{1}'><TD align='right'><div style='width:90px'>{126}</div></TD><TD align='right'><div style='width:60px;'>{127}%</div></TD><TD class='tdyoy1'>{128}</TD></TR>")
                tbBody.Append("<TR id='f4c{1}'><TD align='right'><div style='width:90px'>{129}</div></TD><TD align='right'><div style='width:60px;'>{130}%</div></TD><TD class='tdyoy1'>{131}</TD></TR>")
                tbBody.Append("<TR id='f5c{1}'><TD align='right'><div style='width:90px'>{132}</div></TD><TD align='right'><div style='width:60px;'>{133}%</div></TD><TD class='tdyoy1'>{134}</TD></TR>")
                tbBody.Append("<TR id='f6c{1}'><TD align='right'><div style='width:90px'>{135}</div></TD><TD align='right'><div style='width:60px;'>{136}%</div></TD><TD class='tdyoy1'>{137}</TD></TR>")
                tbBody.Append("<TR id='f7c{1}'><TD align='right'><div style='width:90px'>{138}</div></TD><TD align='right'><div style='width:60px;'>{139}%</div></TD><TD class='tdyoy1'>{140}</TD></TR>")
                tbBody.Append("<TR id='f8c{1}'><TD align='right'><div style='width:90px'>{141}</div></TD><TD align='right'><div style='width:60px;'>{142}%</div></TD><TD class='tdyoy1'>{143}</TD></TR>")
                tbBody.Append("<TR id='f9c{1}'><TD align='right'><div style='width:90px'>{144}</div></TD><TD align='right'><div style='width:60px;'>{145}%</div></TD><TD class='tdyoy1'>{146}</TD></TR>")
                tbBody.Append("<TR id='f10c{1}'><TD align='right'><div style='width:90px'>{147}</div></TD><TD align='right'><div style='width:60px;'>{148}%</div></TD><TD class='tdyoy1'>{149}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{150}</div></TD><TD align='right'><div style='width:60px;'>{151}%</div></TD><TD class='tdyoy1'>{152}</TD></TR>")
                tbBody.Append("<TR id='g1c{1}'><TD align='right'><div style='width:90px'>{153}</div></TD><TD align='right'><div style='width:60px;'>{154}%</div></TD><TD class='tdyoy1'>{155}</TD></TR>")
                tbBody.Append("<TR id='g2c{1}'><TD align='right'><div style='width:90px'>{156}</div></TD><TD align='right'><div style='width:60px;'>{157}%</div></TD><TD class='tdyoy1'>{158}</TD></TR>")
                tbBody.Append("<TR id='g3c{1}'><TD align='right'><div style='width:90px'>{159}</div></TD><TD align='right'><div style='width:60px;'>{160}%</div></TD><TD class='tdyoy1'>{161}</TD></TR>")
                tbBody.Append("<TR id='g4c{1}'><TD align='right'><div style='width:90px'>{162}</div></TD><TD align='right'><div style='width:60px;'>{163}%</div></TD><TD class='tdyoy1'>{164}</TD></TR>")
                tbBody.Append("<TR id='g5c{1}'><TD align='right'><div style='width:90px'>{165}</div></TD><TD align='right'><div style='width:60px;'>{166}%</div></TD><TD class='tdyoy1'>{167}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{168}</div></TD><TD align='right'><div style='width:60px;'>{169}%</div></TD><TD class='tdyoy1'>{170}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h1c{1}'><TD align='right'><div style='width:90px'>{171}</div></TD><TD align='right'><div style='width:60px;'>{172}%</div></TD><TD class='tdyoy1'>{173}</TD></TR>")

                tbBody.Append("<TR id='h2c{1}'><TD align='right'><div style='width:90px'>{174}</div></TD><TD align='right'><div style='width:60px;'>{175}%</div></TD><TD class='tdyoy1'>{176}</TD></TR>")
                tbBody.Append("<TR id='h3c{1}'><TD align='right'><div style='width:90px'>{177}</div></TD><TD align='right'><div style='width:60px;'>{178}%</div></TD><TD class='tdyoy1'>{179}</TD></TR>")
                tbBody.Append("<TR id='h4c{1}'><TD align='right'><div style='width:90px'>{180}</div></TD><TD align='right'><div style='width:60px;'>{181}%</div></TD><TD class='tdyoy1'>{182}</TD></TR>")
                tbBody.Append("<TR id='h5c{1}'><TD align='right'><div style='width:90px'>{183}</div></TD><TD align='right'><div style='width:60px;'>{184}%</div></TD><TD class='tdyoy1'>{185}</TD></TR>")
                tbBody.Append("<TR id='h6c{1}'><TD align='right'><div style='width:90px'>{186}</div></TD><TD align='right'><div style='width:60px;'>{187}%</div></TD><TD class='tdyoy1'>{188}</TD></TR>")
                tbBody.Append("<TR id='h7c{1}'><TD align='right'><div style='width:90px'>{189}</div></TD><TD align='right'><div style='width:60px;'>{190}%</div></TD><TD class='tdyoy1'>{191}</TD></TR>")
                tbBody.Append("<TR id='h8c{1}'><TD align='right'><div style='width:90px'>{192}</div></TD><TD align='right'><div style='width:60px;'>{193}%</div></TD><TD class='tdyoy1'>{194}</TD></TR>")
                tbBody.Append("<TR id='h9c{1}'><TD align='right'><div style='width:90px'>{195}</div></TD><TD align='right'><div style='width:60px;'>{196}%</div></TD><TD class='tdyoy1'>{197}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h10c{1}'><TD align='right'><div style='width:90px'>{198}</div></TD><TD align='right'><div style='width:60px;'>{199}%</div></TD><TD class='tdyoy1'>{200}</TD></TR>")

                tbBody.Append("<TR id='h11c{1}'><TD align='right'><div style='width:90px'>{201}</div></TD><TD align='right'><div style='width:60px;'>{202}%</div></TD><TD class='tdyoy1'>{203}</TD></TR>")
                tbBody.Append("<TR id='h12c{1}'><TD align='right'><div style='width:90px'>{204}</div></TD><TD align='right'><div style='width:60px;'>{205}%</div></TD><TD class='tdyoy1'>{206}</TD></TR>")
                tbBody.Append("<TR id='h13c{1}'><TD align='right'><div style='width:90px'>{207}</div></TD><TD align='right'><div style='width:60px;'>{208}%</div></TD><TD class='tdyoy1'>{209}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h14c{1}'><TD align='right'><div style='width:90px'>{210}</div></TD><TD align='right'><div style='width:60px;'>{211}%</div></TD><TD class='tdyoy1'>{212}</TD></TR>")

                tbBody.Append("<TR id='h15c{1}'><TD align='right'><div style='width:90px'>{213}</div></TD><TD align='right'><div style='width:60px;'>{214}%</div></TD><TD class='tdyoy1'>{215}</TD></TR>")
                tbBody.Append("<TR id='h16c{1}'><TD align='right'><div style='width:90px'>{216}</div></TD><TD align='right'><div style='width:60px;'>{217}%</div></TD><TD class='tdyoy1'>{218}</TD></TR>")
                tbBody.Append("<TR id='h17c{1}'><TD align='right'><div style='width:90px'>{219}</div></TD><TD align='right'><div style='width:60px;'>{220}%</div></TD><TD class='tdyoy1'>{221}</TD></TR>")
                tbBody.Append("<TR id='h18c{1}'><TD align='right'><div style='width:90px'>{222}</div></TD><TD align='right'><div style='width:60px;'>{223}%</div></TD><TD class='tdyoy1'>{224}</TD></TR>")
                'new line
                tbBody.Append("<TR id='h51c{1}'><TD align='right'><div style='width:90px'>{324}</div></TD><TD align='right'><div style='width:60px;'>{325}%</div></TD><TD class='tdyoy1'>{326}</TD></TR>")
                tbBody.Append("<TR id='h52c{1}'><TD align='right'><div style='width:90px'>{327}</div></TD><TD align='right'><div style='width:60px;'>{328}%</div></TD><TD class='tdyoy1'>{329}</TD></TR>")

                tbBody.Append("<TR style='font-weight:bold' id='h19c{1}'><TD align='right'><div style='width:90px'>{225}</div></TD><TD align='right'><div style='width:60px;'>{226}%</div></TD><TD class='tdyoy1'>{227}</TD></TR>")

                tbBody.Append("<TR id='h20c{1}'><TD align='right'><div style='width:90px'>{228}</div></TD><TD align='right'><div style='width:60px;'>{229}%</div></TD><TD class='tdyoy1'>{230}</TD></TR>")
                tbBody.Append("<TR id='h21c{1}'><TD align='right'><div style='width:90px'>{231}</div></TD><TD align='right'><div style='width:60px;'>{232}%</div></TD><TD class='tdyoy1'>{233}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h22c{1}'><TD align='right'><div style='width:90px'>{234}</div></TD><TD align='right'><div style='width:60px;'>{235}%</div></TD><TD class='tdyoy1'>{236}</TD></TR>")

                tbBody.Append("<TR id='h23c{1}'><TD align='right'><div style='width:90px'>{237}</div></TD><TD align='right'><div style='width:60px;'>{238}%</div></TD><TD class='tdyoy1'>{239}</TD></TR>")
                tbBody.Append("<TR id='h24c{1}'><TD align='right'><div style='width:90px'>{240}</div></TD><TD align='right'><div style='width:60px;'>{241}%</div></TD><TD class='tdyoy1'>{242}</TD></TR>")
                tbBody.Append("<TR id='h25c{1}'><TD align='right'><div style='width:90px'>{243}</div></TD><TD align='right'><div style='width:60px;'>{244}%</div></TD><TD class='tdyoy1'>{245}</TD></TR>")
                tbBody.Append("<TR id='h26c{1}'><TD align='right'><div style='width:90px'>{246}</div></TD><TD align='right'><div style='width:60px;'>{247}%</div></TD><TD class='tdyoy1'>{248}</TD></TR>")
                tbBody.Append("<TR id='h27c{1}'><TD align='right'><div style='width:90px'>{249}</div></TD><TD align='right'><div style='width:60px;'>{250}%</div></TD><TD class='tdyoy1'>{251}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h28c{1}'><TD align='right'><div style='width:90px'>{252}</div></TD><TD align='right'><div style='width:60px;'>{253}%</div></TD><TD class='tdyoy1'>{254}</TD></TR>")

                tbBody.Append("<TR id='h29c{1}'><TD align='right'><div style='width:90px'>{255}</div></TD><TD align='right'><div style='width:60px;'>{256}%</div></TD><TD class='tdyoy1'>{257}</TD></TR>")
                tbBody.Append("<TR id='h30c{1}'><TD align='right'><div style='width:90px'>{258}</div></TD><TD align='right'><div style='width:60px;'>{259}%</div></TD><TD class='tdyoy1'>{260}</TD></TR>")
                tbBody.Append("<TR id='h31c{1}'><TD align='right'><div style='width:90px'>{261}</div></TD><TD align='right'><div style='width:60px;'>{262}%</div></TD><TD class='tdyoy1'>{263}</TD></TR>")
                tbBody.Append("<TR id='h32c{1}'><TD align='right'><div style='width:90px'>{264}</div></TD><TD align='right'><div style='width:60px;'>{265}%</div></TD><TD class='tdyoy1'>{266}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h33c{1}'><TD align='right'><div style='width:90px'>{267}</div></TD><TD align='right'><div style='width:60px;'>{268}%</div></TD><TD class='tdyoy1'>{269}</TD></TR>")

                tbBody.Append("<TR id='h34c{1}'><TD align='right'><div style='width:90px'>{270}</div></TD><TD align='right'><div style='width:60px;'>{271}%</div></TD><TD class='tdyoy1'>{272}</TD></TR>")
                tbBody.Append("<TR id='h35c{1}'><TD align='right'><div style='width:90px'>{273}</div></TD><TD align='right'><div style='width:60px;'>{274}%</div></TD><TD class='tdyoy1'>{275}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h36c{1}'><TD align='right'><div style='width:90px'>{276}</div></TD><TD align='right'><div style='width:60px;'>{277}%</div></TD><TD class='tdyoy1'>{278}</TD></TR>")

                tbBody.Append("<TR id='h37c{1}'><TD align='right'><div style='width:90px'>{279}</div></TD><TD align='right'><div style='width:60px;'>{280}%</div></TD><TD class='tdyoy1'>{281}</TD></TR>")
                tbBody.Append("<TR id='h38c{1}'><TD align='right'><div style='width:90px'>{282}</div></TD><TD align='right'><div style='width:60px;'>{283}%</div></TD><TD class='tdyoy1'>{284}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h39c{1}'><TD align='right'><div style='width:90px'>{285}</div></TD><TD align='right'><div style='width:60px;'>{286}%</div></TD><TD class='tdyoy1'>{287}</TD></TR>")

                tbBody.Append("<TR id='h40c{1}'><TD align='right'><div style='width:90px'>{288}</div></TD><TD align='right'><div style='width:60px;'>{289}%</div></TD><TD class='tdyoy1'>{290}</TD></TR>")
                tbBody.Append("<TR id='h41c{1}'><TD align='right'><div style='width:90px'>{291}</div></TD><TD align='right'><div style='width:60px;'>{292}%</div></TD><TD class='tdyoy1'>{293}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h42c{1}'><TD align='right'><div style='width:90px'>{294}</div></TD><TD align='right'><div style='width:60px;'>{295}%</div></TD><TD class='tdyoy1'>{296}</TD></TR>")

                tbBody.Append("<TR id='h43c{1}'><TD align='right'><div style='width:90px'>{297}</div></TD><TD align='right'><div style='width:60px;'>{298}%</div></TD><TD class='tdyoy1'>{299}</TD></TR>")
                tbBody.Append("<TR id='h44c{1}'><TD align='right'><div style='width:90px'>{300}</div></TD><TD align='right'><div style='width:60px;'>{301}%</div></TD><TD class='tdyoy1'>{302}</TD></TR>")
                'new line
                tbBody.Append("<TR id='h53c{1}'><TD align='right'><div style='width:90px'>{330}</div></TD><TD align='right'><div style='width:60px;'>{331}%</div></TD><TD class='tdyoy1'>{332}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h45c{1}'><TD align='right'><div style='width:90px'>{303}</div></TD><TD align='right'><div style='width:60px;'>{304}%</div></TD><TD class='tdyoy1'>{305}</TD></TR>")

                tbBody.Append("<TR id='h46c{1}'><TD align='right'><div style='width:90px'>{306}</div></TD><TD align='right'><div style='width:60px;'>{307}%</div></TD><TD class='tdyoy1'>{308}</TD></TR>")
                tbBody.Append("<TR id='h47c{1}'><TD align='right'><div style='width:90px'>{309}</div></TD><TD align='right'><div style='width:60px;'>{310}%</div></TD><TD class='tdyoy1'>{311}</TD></TR>")
                tbBody.Append("<TR id='h48c{1}'><TD align='right'><div style='width:90px'>{312}</div></TD><TD align='right'><div style='width:60px;'>{313}%</div></TD><TD class='tdyoy1'>{314}</TD></TR>")
                tbBody.Append("<TR id='h49c{1}'><TD align='right'><div style='width:90px'>{315}</div></TD><TD align='right'><div style='width:60px;'>{316}%</div></TD><TD class='tdyoy1'>{317}</TD></TR>")
                tbBody.Append("<TR id='h50c{1}'><TD align='right'><div style='width:90px'>{318}</div></TD><TD align='right'><div style='width:60px;'>{319}%</div></TD><TD class='tdyoy1'>{320}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{321}</div></TD><TD align='right'><div style='width:60px;'>{322}%</div></TD><TD class='tdyoy1'>{323}</TD></TR>")
                Return tbBody.ToString
            Case 3
                Dim tbFoot As New StringBuilder
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{0}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{1}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbFoot.Append("</TABLE>")
                Return tbFoot.ToString
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function htmlModelItem2(part As tablePart) As String

        Select Case part
            Case 1
                Dim tbHead As New StringBuilder

                tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='2'><strong>{0}</strong></TD></TR>")

                'assing width this row
                tbHead.Append("<TR style='font-weight:bold;height:30px' class='rbg1'><TD align='center'><div style='width:90px'><strong>{1}</strong></div></TD><TD align='center'><div style='width:60px;'><strong>% Sale</strong></div></TD></TR>")

                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' ><strong>{2}</strong></TD><TD align='center'><div style='width:60px;'><strong></strong></div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'>{3}</TD><TD align='center' class='rbg2'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{4}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{5}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR><TD></TD><TD>&nbsp;</TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{6}</TD><TD>&nbsp;</TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{7}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR><TD></TD><TD>&nbsp;</TD></TR>")

                Return tbHead.ToString
            Case 2
                Dim tbBody As New StringBuilder
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{3}</TD><TD align='right'><div style='width:60px;'>{4}%</div></TD><TD class='tdyoy2'>{5}</TD></TR>")
                tbBody.Append("<TR id='aa1c{1}'><TD align='right'>{6}</TD><TD align='right'><div style='width:60px;'>{7}%</div></TD><TD class='tdyoy2'>{8}</TD></TR>")
                tbBody.Append("<TR id='aa2c{1}'><TD align='right'>{9}</TD><TD align='right'><div style='width:60px;'>{10}%</div></TD><TD class='tdyoy2'>{11}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'>{12}</TD><TD align='right'><div style='width:60px;'>{13}%</div></TD><TD class='tdyoy2'>{14}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{15}</TD><TD align='right'><div style='width:60px;'>{16}%</div></TD><TD class='tdyoy2'>{17}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'>{18}</TD><TD align='right'><div style='width:60px;'>{19}%</div></TD><TD class='tdyoy2'>{20}</TD></TR>")
                tbBody.Append("<TR id='b1c{1}'><TD align='right'>{21}</TD><TD align='right'><div style='width:60px;'>{22}%</div></TD><TD class='tdyoy2'>{23}</TD></TR>")
                tbBody.Append("<TR id='b2c{1}'><TD align='right'>{24}</TD><TD align='right'><div style='width:60px;'>{25}%</div></TD><TD class='tdyoy2'>{26}</TD></TR>")
                tbBody.Append("<TR id='b3c{1}'><TD align='right'>{27}</TD><TD align='right'><div style='width:60px;'>{28}%</div></TD><TD class='tdyoy2'>{29}</TD></TR>")
                tbBody.Append("<TR id='b4c{1}'><TD align='right'>{30}</TD><TD align='right'><div style='width:60px;'>{31}%</div></TD><TD class='tdyoy2'>{32}</TD></TR>")
                tbBody.Append("<TR id='b5c{1}'><TD align='right'>{33}</TD><TD align='right'><div style='width:60px;'>{34}%</div></TD><TD class='tdyoy2'>{35}</TD></TR>")
                tbBody.Append("<TR id='b6c{1}'><TD align='right'>{36}</TD><TD align='right'><div style='width:60px;'>{37}%</div></TD><TD class='tdyoy2'>{38}</TD></TR>")
                tbBody.Append("<TR id='b7c{1}'><TD align='right'>{39}</TD><TD align='right'><div style='width:60px;'>{40}%</div></TD><TD class='tdyoy2'>{41}</TD></TR>")
                tbBody.Append("<TR id='b8c{1}'><TD align='right'>{42}</TD><TD align='right'><div style='width:60px;'>{43}%</div></TD><TD class='tdyoy2'>{44}</TD></TR>")
                tbBody.Append("<TR id='b9c{1}'><TD align='right'>{45}</TD><TD align='right'><div style='width:60px;'>{46}%</div></TD><TD class='tdyoy2'>{47}</TD></TR>")
                tbBody.Append("<TR id='b10c{1}'><TD align='right'>{48}</TD><TD align='right'><div style='width:60px;'>{49}%</div></TD><TD class='tdyoy2'>{50}</TD></TR>")
                tbBody.Append("<TR id='b11c{1}'><TD align='right'>{51}</TD><TD align='right'><div style='width:60px;'>{52}%</div></TD><TD class='tdyoy2'>{53}</TD></TR>")
                tbBody.Append("<TR id='b12c{1}'><TD align='right'>{54}</TD><TD align='right'><div style='width:60px;'>{55}%</div></TD><TD class='tdyoy2'>{56}</TD></TR>")
                tbBody.Append("<TR id='b13c{1}'><TD align='right'>{57}</TD><TD align='right'><div style='width:60px;'>{58}%</div></TD><TD class='tdyoy2'>{59}</TD></TR>")
                tbBody.Append("<TR id='b14c{1}'><TD align='right'>{60}</TD><TD align='right'><div style='width:60px;'>{61}%</div></TD><TD class='tdyoy2'>{62}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{63}</TD><TD align='right'><div style='width:60px;'>{64}%</div></TD><TD class='tdyoy2'>{65}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg4'><TD align='right'>{66}</TD><TD align='right'><div style='width:60px;'>{67}%</div></TD><TD class='tdyoy2'>{68}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{69}</TD><TD align='right'><div style='width:60px;'>{70}%</div></TD><TD class='tdyoy2'>{71}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{72}</TD><TD align='right'><div style='width:60px;'>{73}%</div></TD><TD class='tdyoy2'>{74}</TD></TR>")
                tbBody.Append("<TR id='e1c{1}'><TD align='right'>{75}</TD><TD align='right'><div style='width:60px;'>{76}%</div></TD><TD class='tdyoy2'>{77}</TD></TR>")
                tbBody.Append("<TR id='e2c{1}'><TD align='right'>{78}</TD><TD align='right'><div style='width:60px;'>{79}%</div></TD><TD class='tdyoy2'>{80}</TD></TR>")
                tbBody.Append("<TR id='e3c{1}'><TD align='right'>{81}</TD><TD align='right'><div style='width:60px;'>{82}%</div></TD><TD class='tdyoy2'>{83}</TD></TR>")
                tbBody.Append("<TR id='e4c{1}'><TD align='right'>{84}</TD><TD align='right'><div style='width:60px;'>{85}%</div></TD><TD class='tdyoy2'>{86}</TD></TR>")
                tbBody.Append("<TR id='e5c{1}'><TD align='right'>{87}</TD><TD align='right'><div style='width:60px;'>{88}%</div></TD><TD class='tdyoy2'>{89}</TD></TR>")
                tbBody.Append("<TR id='e6c{1}'><TD align='right'>{90}</TD><TD align='right'><div style='width:60px;'>{91}%</div></TD><TD class='tdyoy2'>{92}</TD></TR>")
                tbBody.Append("<TR id='e7c{1}'><TD align='right'>{93}</TD><TD align='right'><div style='width:60px;'>{94}%</div></TD><TD class='tdyoy2'>{95}</TD></TR>")
                tbBody.Append("<TR id='e8c{1}'><TD align='right'>{96}</TD><TD align='right'><div style='width:60px;'>{97}%</div></TD><TD class='tdyoy2'>{98}</TD></TR>")
                tbBody.Append("<TR id='e9c{1}'><TD align='right'>{99}</TD><TD align='right'><div style='width:60px;'>{100}%</div></TD><TD class='tdyoy2'>{101}</TD></TR>")
                tbBody.Append("<TR id='e10c{1}'><TD align='right'>{102}</TD><TD align='right'><div style='width:60px;'>{103}%</div></TD><TD class='tdyoy2'>{104}</TD></TR>")
                tbBody.Append("<TR id='e11c{1}'><TD align='right'>{105}</TD><TD align='right'><div style='width:60px;'>{106}%</div></TD><TD class='tdyoy2'>{107}</TD></TR>")
                tbBody.Append("<TR id='e12c{1}'><TD align='right'>{108}</TD><TD align='right'><div style='width:60px;'>{109}%</div></TD><TD class='tdyoy2'>{110}</TD></TR>")
                tbBody.Append("<TR id='e13c{1}'><TD align='right'>{111}</TD><TD align='right'><div style='width:60px;'>{112}%</div></TD><TD class='tdyoy2'>{113}</TD></TR>")
                tbBody.Append("<TR id='e14c{1}'><TD align='right'>{114}</TD><TD align='right'><div style='width:60px;'>{115}%</div></TD><TD class='tdyoy2'>{116}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{117}</TD><TD align='right'><div style='width:60px;'>{118}%</div></TD><TD class='tdyoy2'>{119}</TD></TR>")
                tbBody.Append("<TR id='f1c{1}'><TD align='right'>{120}</TD><TD align='right'><div style='width:60px;'>{121}%</div></TD><TD class='tdyoy2'>{122}</TD></TR>")
                tbBody.Append("<TR id='f2c{1}'><TD align='right'>{123}</TD><TD align='right'><div style='width:60px;'>{124}%</div></TD><TD class='tdyoy2'>{125}</TD></TR>")
                tbBody.Append("<TR id='f3c{1}'><TD align='right'>{126}</TD><TD align='right'><div style='width:60px;'>{127}%</div></TD><TD class='tdyoy2'>{128}</TD></TR>")
                tbBody.Append("<TR id='f4c{1}'><TD align='right'>{129}</TD><TD align='right'><div style='width:60px;'>{130}%</div></TD><TD class='tdyoy2'>{131}</TD></TR>")
                tbBody.Append("<TR id='f5c{1}'><TD align='right'>{132}</TD><TD align='right'><div style='width:60px;'>{133}%</div></TD><TD class='tdyoy2'>{134}</TD></TR>")
                tbBody.Append("<TR id='f6c{1}'><TD align='right'>{135}</TD><TD align='right'><div style='width:60px;'>{136}%</div></TD><TD class='tdyoy2'>{137}</TD></TR>")
                tbBody.Append("<TR id='f7c{1}'><TD align='right'>{138}</TD><TD align='right'><div style='width:60px;'>{139}%</div></TD><TD class='tdyoy2'>{140}</TD></TR>")
                tbBody.Append("<TR id='f8c{1}'><TD align='right'>{141}</TD><TD align='right'><div style='width:60px;'>{142}%</div></TD><TD class='tdyoy2'>{143}</TD></TR>")
                tbBody.Append("<TR id='f9c{1}'><TD align='right'>{144}</TD><TD align='right'><div style='width:60px;'>{145}%</div></TD><TD class='tdyoy2'>{146}</TD></TR>")
                tbBody.Append("<TR id='f10c{1}'><TD align='right'>{147}</TD><TD align='right'><div style='width:60px;'>{148}%</div></TD><TD class='tdyoy2'>{149}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{150}</TD><TD align='right'><div style='width:60px;'>{151}%</div></TD><TD class='tdyoy2'>{152}</TD></TR>")
                tbBody.Append("<TR id='g1c{1}'><TD align='right'>{153}</TD><TD align='right'><div style='width:60px;'>{154}%</div></TD><TD class='tdyoy2'>{155}</TD></TR>")
                tbBody.Append("<TR id='g2c{1}'><TD align='right'>{156}</TD><TD align='right'><div style='width:60px;'>{157}%</div></TD><TD class='tdyoy2'>{158}</TD></TR>")
                tbBody.Append("<TR id='g3c{1}'><TD align='right'>{159}</TD><TD align='right'><div style='width:60px;'>{160}%</div></TD><TD class='tdyoy2'>{161}</TD></TR>")
                tbBody.Append("<TR id='g4c{1}'><TD align='right'>{162}</TD><TD align='right'><div style='width:60px;'>{163}%</div></TD><TD class='tdyoy2'>{164}</TD></TR>")
                tbBody.Append("<TR id='g5c{1}'><TD align='right'>{165}</TD><TD align='right'><div style='width:60px;'>{166}%</div></TD><TD class='tdyoy2'>{167}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{168}</TD><TD align='right'><div style='width:60px;'>{169}%</div></TD><TD class='tdyoy2'>{170}</TD></TR>")
                tbBody.Append("<TR id='h1c{1}'><TD align='right'>{171}</TD><TD align='right'><div style='width:60px;'>{172}%</div></TD><TD class='tdyoy2'>{173}</TD></TR>")
                tbBody.Append("<TR id='h2c{1}'><TD align='right'>{174}</TD><TD align='right'><div style='width:60px;'>{175}%</div></TD><TD class='tdyoy2'>{176}</TD></TR>")
                tbBody.Append("<TR id='h3c{1}'><TD align='right'>{177}</TD><TD align='right'><div style='width:60px;'>{178}%</div></TD><TD class='tdyoy2'>{179}</TD></TR>")
                tbBody.Append("<TR id='h4c{1}'><TD align='right'>{180}</TD><TD align='right'><div style='width:60px;'>{181}%</div></TD><TD class='tdyoy2'>{182}</TD></TR>")
                tbBody.Append("<TR id='h5c{1}'><TD align='right'>{183}</TD><TD align='right'><div style='width:60px;'>{184}%</div></TD><TD class='tdyoy2'>{185}</TD></TR>")
                tbBody.Append("<TR id='h6c{1}'><TD align='right'>{186}</TD><TD align='right'><div style='width:60px;'>{187}%</div></TD><TD class='tdyoy2'>{188}</TD></TR>")
                tbBody.Append("<TR id='h7c{1}'><TD align='right'>{189}</TD><TD align='right'><div style='width:60px;'>{190}%</div></TD><TD class='tdyoy2'>{191}</TD></TR>")
                tbBody.Append("<TR id='h8c{1}'><TD align='right'>{192}</TD><TD align='right'><div style='width:60px;'>{193}%</div></TD><TD class='tdyoy2'>{194}</TD></TR>")
                tbBody.Append("<TR id='h9c{1}'><TD align='right'>{195}</TD><TD align='right'><div style='width:60px;'>{196}%</div></TD><TD class='tdyoy2'>{197}</TD></TR>")
                tbBody.Append("<TR id='h10c{1}'><TD align='right'>{198}</TD><TD align='right'><div style='width:60px;'>{199}%</div></TD><TD class='tdyoy2'>{200}</TD></TR>")
                tbBody.Append("<TR id='h11c{1}'><TD align='right'>{201}</TD><TD align='right'><div style='width:60px;'>{202}%</div></TD><TD class='tdyoy2'>{203}</TD></TR>")
                tbBody.Append("<TR id='h12c{1}'><TD align='right'>{204}</TD><TD align='right'><div style='width:60px;'>{205}%</div></TD><TD class='tdyoy2'>{206}</TD></TR>")
                tbBody.Append("<TR id='h13c{1}'><TD align='right'>{207}</TD><TD align='right'><div style='width:60px;'>{208}%</div></TD><TD class='tdyoy2'>{209}</TD></TR>")
                tbBody.Append("<TR id='h14c{1}'><TD align='right'>{210}</TD><TD align='right'><div style='width:60px;'>{211}%</div></TD><TD class='tdyoy2'>{212}</TD></TR>")
                tbBody.Append("<TR id='h15c{1}'><TD align='right'>{213}</TD><TD align='right'><div style='width:60px;'>{214}%</div></TD><TD class='tdyoy2'>{215}</TD></TR>")
                tbBody.Append("<TR id='h16c{1}'><TD align='right'>{216}</TD><TD align='right'><div style='width:60px;'>{217}%</div></TD><TD class='tdyoy2'>{218}</TD></TR>")
                tbBody.Append("<TR id='h17c{1}'><TD align='right'>{219}</TD><TD align='right'><div style='width:60px;'>{220}%</div></TD><TD class='tdyoy2'>{221}</TD></TR>")
                tbBody.Append("<TR id='h18c{1}'><TD align='right'>{222}</TD><TD align='right'><div style='width:60px;'>{223}%</div></TD><TD class='tdyoy2'>{224}</TD></TR>")
                tbBody.Append("<TR id='h19c{1}'><TD align='right'>{225}</TD><TD align='right'><div style='width:60px;'>{226}%</div></TD><TD class='tdyoy2'>{227}</TD></TR>")
                tbBody.Append("<TR id='h20c{1}'><TD align='right'>{228}</TD><TD align='right'><div style='width:60px;'>{229}%</div></TD><TD class='tdyoy2'>{230}</TD></TR>")
                tbBody.Append("<TR id='h21c{1}'><TD align='right'>{231}</TD><TD align='right'><div style='width:60px;'>{232}%</div></TD><TD class='tdyoy2'>{233}</TD></TR>")
                tbBody.Append("<TR id='h22c{1}'><TD align='right'>{234}</TD><TD align='right'><div style='width:60px;'>{235}%</div></TD><TD class='tdyoy2'>{236}</TD></TR>")
                tbBody.Append("<TR id='h23c{1}'><TD align='right'>{237}</TD><TD align='right'><div style='width:60px;'>{238}%</div></TD><TD class='tdyoy2'>{239}</TD></TR>")
                tbBody.Append("<TR id='h24c{1}'><TD align='right'>{240}</TD><TD align='right'><div style='width:60px;'>{241}%</div></TD><TD class='tdyoy2'>{242}</TD></TR>")
                tbBody.Append("<TR id='h25c{1}'><TD align='right'>{243}</TD><TD align='right'><div style='width:60px;'>{244}%</div></TD><TD class='tdyoy2'>{245}</TD></TR>")
                tbBody.Append("<TR id='h26c{1}'><TD align='right'>{246}</TD><TD align='right'><div style='width:60px;'>{247}%</div></TD><TD class='tdyoy2'>{248}</TD></TR>")
                tbBody.Append("<TR id='h27c{1}'><TD align='right'>{249}</TD><TD align='right'><div style='width:60px;'>{250}%</div></TD><TD class='tdyoy2'>{251}</TD></TR>")
                tbBody.Append("<TR id='h28c{1}'><TD align='right'>{252}</TD><TD align='right'><div style='width:60px;'>{253}%</div></TD><TD class='tdyoy2'>{254}</TD></TR>")
                tbBody.Append("<TR id='h29c{1}'><TD align='right'>{255}</TD><TD align='right'><div style='width:60px;'>{256}%</div></TD><TD class='tdyoy2'>{257}</TD></TR>")
                tbBody.Append("<TR id='h30c{1}'><TD align='right'>{258}</TD><TD align='right'><div style='width:60px;'>{259}%</div></TD><TD class='tdyoy2'>{260}</TD></TR>")
                tbBody.Append("<TR id='h31c{1}'><TD align='right'>{261}</TD><TD align='right'><div style='width:60px;'>{262}%</div></TD><TD class='tdyoy2'>{263}</TD></TR>")
                tbBody.Append("<TR id='h32c{1}'><TD align='right'>{264}</TD><TD align='right'><div style='width:60px;'>{265}%</div></TD><TD class='tdyoy2'>{266}</TD></TR>")
                tbBody.Append("<TR id='h33c{1}'><TD align='right'>{267}</TD><TD align='right'><div style='width:60px;'>{268}%</div></TD><TD class='tdyoy2'>{269}</TD></TR>")
                tbBody.Append("<TR id='h34c{1}'><TD align='right'>{270}</TD><TD align='right'><div style='width:60px;'>{271}%</div></TD><TD class='tdyoy2'>{272}</TD></TR>")
                tbBody.Append("<TR id='h35c{1}'><TD align='right'>{273}</TD><TD align='right'><div style='width:60px;'>{274}%</div></TD><TD class='tdyoy2'>{275}</TD></TR>")
                tbBody.Append("<TR id='h36c{1}'><TD align='right'>{276}</TD><TD align='right'><div style='width:60px;'>{277}%</div></TD><TD class='tdyoy2'>{278}</TD></TR>")
                tbBody.Append("<TR id='h37c{1}'><TD align='right'>{279}</TD><TD align='right'><div style='width:60px;'>{280}%</div></TD><TD class='tdyoy2'>{281}</TD></TR>")
                tbBody.Append("<TR id='h38c{1}'><TD align='right'>{282}</TD><TD align='right'><div style='width:60px;'>{283}%</div></TD><TD class='tdyoy2'>{284}</TD></TR>")
                tbBody.Append("<TR id='h39c{1}'><TD align='right'>{285}</TD><TD align='right'><div style='width:60px;'>{286}%</div></TD><TD class='tdyoy2'>{287}</TD></TR>")
                tbBody.Append("<TR id='h40c{1}'><TD align='right'>{288}</TD><TD align='right'><div style='width:60px;'>{289}%</div></TD><TD class='tdyoy2'>{290}</TD></TR>")
                tbBody.Append("<TR id='h41c{1}'><TD align='right'>{291}</TD><TD align='right'><div style='width:60px;'>{292}%</div></TD><TD class='tdyoy2'>{293}</TD></TR>")
                tbBody.Append("<TR id='h42c{1}'><TD align='right'>{294}</TD><TD align='right'><div style='width:60px;'>{295}%</div></TD><TD class='tdyoy2'>{296}</TD></TR>")
                tbBody.Append("<TR id='h43c{1}'><TD align='right'>{297}</TD><TD align='right'><div style='width:60px;'>{298}%</div></TD><TD class='tdyoy2'>{299}</TD></TR>")
                tbBody.Append("<TR id='h44c{1}'><TD align='right'>{300}</TD><TD align='right'><div style='width:60px;'>{301}%</div></TD><TD class='tdyoy2'>{302}</TD></TR>")
                tbBody.Append("<TR id='h45c{1}'><TD align='right'>{303}</TD><TD align='right'><div style='width:60px;'>{304}%</div></TD><TD class='tdyoy2'>{305}</TD></TR>")
                tbBody.Append("<TR id='h46c{1}'><TD align='right'>{306}</TD><TD align='right'><div style='width:60px;'>{307}%</div></TD><TD class='tdyoy2'>{308}</TD></TR>")
                tbBody.Append("<TR id='h47c{1}'><TD align='right'>{309}</TD><TD align='right'><div style='width:60px;'>{310}%</div></TD><TD class='tdyoy2'>{311}</TD></TR>")
                tbBody.Append("<TR id='h48c{1}'><TD align='right'>{312}</TD><TD align='right'><div style='width:60px;'>{313}%</div></TD><TD class='tdyoy2'>{314}</TD></TR>")
                tbBody.Append("<TR id='h49c{1}'><TD align='right'>{315}</TD><TD align='right'><div style='width:60px;'>{316}%</div></TD><TD class='tdyoy2'>{317}</TD></TR>")
                tbBody.Append("<TR id='h50c{1}'><TD align='right'>{318}</TD><TD align='right'><div style='width:60px;'>{319}%</div></TD><TD class='tdyoy2'>{320}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{321}</TD><TD align='right'><div style='width:60px;'>{322}%</div></TD><TD class='tdyoy2'>{323}</TD></TR>")

                Return tbBody.ToString
            Case 3
                Dim tbFoot As New StringBuilder
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{0}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{1}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbFoot.Append("</TABLE>")

                Return tbFoot.ToString
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function htmlModelTotal2(part As tablePart) As String

        Select Case part
            Case 1
                Dim tbHead As New StringBuilder
                tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='3'><strong>{0}</strong></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;height:30px;' class='rbg1'><TD align='center'><div style='width:90px'><strong>{1}</strong></div></TD><TD align='center'><div style='width:60px;'><strong>% Sale</strong></div></TD> <TD align='center'><div style='width:60px;'><strong>% YOY</strong></div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:90px'><strong>{2}</strong></div></TD><TD align='center'><div style='width:60px;'><strong></strong></div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'><div style='width:90px;'>{3}</div></TD><TD align='center' class='rbg2'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:90px'>{4}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:90px'>{5}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:90px'></div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{6}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{7}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:90px'></div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                Return tbHead.ToString
            Case 2
                Dim tbBody As New StringBuilder
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{3}</div></TD><TD align='right'><div style='width:60px;'>{4}%</div></TD><TD class='tdyoy1'>{5}</TD></TR>")
                tbBody.Append("<TR id='aa1c{1}'><TD align='right'><div style='width:90px'>{6}</div></TD><TD align='right'><div style='width:60px;'>{7}%</div></TD><TD class='tdyoy1'>{8}</TD></TR>")
                tbBody.Append("<TR id='aa2c{1}'><TD align='right'><div style='width:90px'>{9}</div></TD><TD align='right'><div style='width:60px;'>{10}%</div></TD><TD class='tdyoy1'>{11}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:90px'>{12}</div></TD><TD align='right'><div style='width:60px;'>{13}%</div></TD><TD class='tdyoy1'>{14}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{15}</div></TD><TD align='right'><div style='width:60px;'>{16}%</div></TD><TD class='tdyoy1'>{17}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:90px'>{18}</div></TD><TD align='right'><div style='width:60px;'>{19}%</div></TD><TD class='tdyoy1'>{20}</TD></TR>")
                tbBody.Append("<TR id='b1c{1}'><TD align='right'><div style='width:90px'>{21}</div></TD><TD align='right'><div style='width:60px;'>{22}%</div></TD><TD class='tdyoy1'>{23}</TD></TR>")
                tbBody.Append("<TR id='b2c{1}'><TD align='right'><div style='width:90px'>{24}</div></TD><TD align='right'><div style='width:60px;'>{25}%</div></TD><TD class='tdyoy1'>{26}</TD></TR>")
                tbBody.Append("<TR id='b3c{1}'><TD align='right'><div style='width:90px'>{27}</div></TD><TD align='right'><div style='width:60px;'>{28}%</div></TD><TD class='tdyoy1'>{29}</TD></TR>")
                tbBody.Append("<TR id='b4c{1}'><TD align='right'><div style='width:90px'>{30}</div></TD><TD align='right'><div style='width:60px;'>{31}%</div></TD><TD class='tdyoy1'>{32}</TD></TR>")
                tbBody.Append("<TR id='b5c{1}'><TD align='right'><div style='width:90px'>{33}</div></TD><TD align='right'><div style='width:60px;'>{34}%</div></TD><TD class='tdyoy1'>{35}</TD></TR>")
                tbBody.Append("<TR id='b6c{1}'><TD align='right'><div style='width:90px'>{36}</div></TD><TD align='right'><div style='width:60px;'>{37}%</div></TD><TD class='tdyoy1'>{38}</TD></TR>")
                tbBody.Append("<TR id='b7c{1}'><TD align='right'><div style='width:90px'>{39}</div></TD><TD align='right'><div style='width:60px;'>{40}%</div></TD><TD class='tdyoy1'>{41}</TD></TR>")
                tbBody.Append("<TR id='b8c{1}'><TD align='right'><div style='width:90px'>{42}</div></TD><TD align='right'><div style='width:60px;'>{43}%</div></TD><TD class='tdyoy1'>{44}</TD></TR>")
                tbBody.Append("<TR id='b9c{1}'><TD align='right'><div style='width:90px'>{45}</div></TD><TD align='right'><div style='width:60px;'>{46}%</div></TD><TD class='tdyoy1'>{47}</TD></TR>")
                tbBody.Append("<TR id='b10c{1}'><TD align='right'><div style='width:90px'>{48}</div></TD><TD align='right'><div style='width:60px;'>{49}%</div></TD><TD class='tdyoy1'>{50}</TD></TR>")
                tbBody.Append("<TR id='b11c{1}'><TD align='right'><div style='width:90px'>{51}</div></TD><TD align='right'><div style='width:60px;'>{52}%</div></TD><TD class='tdyoy1'>{53}</TD></TR>")
                tbBody.Append("<TR id='b12c{1}'><TD align='right'><div style='width:90px'>{54}</div></TD><TD align='right'><div style='width:60px;'>{55}%</div></TD><TD class='tdyoy1'>{56}</TD></TR>")
                tbBody.Append("<TR id='b13c{1}'><TD align='right'><div style='width:90px'>{57}</div></TD><TD align='right'><div style='width:60px;'>{58}%</div></TD><TD class='tdyoy1'>{59}</TD></TR>")
                tbBody.Append("<TR id='b14c{1}'><TD align='right'><div style='width:90px'>{60}</div></TD><TD align='right'><div style='width:60px;'>{61}%</div></TD><TD class='tdyoy1'>{62}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{63}</div></TD><TD align='right'><div style='width:60px;'>{64}%</div></TD><TD class='tdyoy1'>{65}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg4'><TD align='right'><div style='width:90px'>{66}</div></TD><TD align='right'><div style='width:60px;'>{67}%</div></TD><TD class='tdyoy1'>{68}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{69}</div></TD><TD align='right'><div style='width:60px;'>{70}%</div></TD><TD class='tdyoy1'>{71}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{72}</div></TD><TD align='right'><div style='width:60px;'>{73}%</div></TD><TD class='tdyoy1'>{74}</TD></TR>")
                tbBody.Append("<TR id='e1c{1}'><TD align='right'><div style='width:90px'>{75}</div></TD><TD align='right'><div style='width:60px;'>{76}%</div></TD><TD class='tdyoy1'>{77}</TD></TR>")
                tbBody.Append("<TR id='e2c{1}'><TD align='right'><div style='width:90px'>{78}</div></TD><TD align='right'><div style='width:60px;'>{79}%</div></TD><TD class='tdyoy1'>{80}</TD></TR>")
                tbBody.Append("<TR id='e3c{1}'><TD align='right'><div style='width:90px'>{81}</div></TD><TD align='right'><div style='width:60px;'>{82}%</div></TD><TD class='tdyoy1'>{83}</TD></TR>")
                tbBody.Append("<TR id='e4c{1}'><TD align='right'><div style='width:90px'>{84}</div></TD><TD align='right'><div style='width:60px;'>{85}%</div></TD><TD class='tdyoy1'>{86}</TD></TR>")
                tbBody.Append("<TR id='e5c{1}'><TD align='right'><div style='width:90px'>{87}</div></TD><TD align='right'><div style='width:60px;'>{88}%</div></TD><TD class='tdyoy1'>{89}</TD></TR>")
                tbBody.Append("<TR id='e6c{1}'><TD align='right'><div style='width:90px'>{90}</div></TD><TD align='right'><div style='width:60px;'>{91}%</div></TD><TD class='tdyoy1'>{92}</TD></TR>")
                tbBody.Append("<TR id='e7c{1}'><TD align='right'><div style='width:90px'>{93}</div></TD><TD align='right'><div style='width:60px;'>{94}%</div></TD><TD class='tdyoy1'>{95}</TD></TR>")
                tbBody.Append("<TR id='e8c{1}'><TD align='right'><div style='width:90px'>{96}</div></TD><TD align='right'><div style='width:60px;'>{97}%</div></TD><TD class='tdyoy1'>{98}</TD></TR>")
                tbBody.Append("<TR id='e9c{1}'><TD align='right'><div style='width:90px'>{99}</div></TD><TD align='right'><div style='width:60px;'>{100}%</div></TD><TD class='tdyoy1'>{101}</TD></TR>")
                tbBody.Append("<TR id='e10c{1}'><TD align='right'><div style='width:90px'>{102}</div></TD><TD align='right'><div style='width:60px;'>{103}%</div></TD><TD class='tdyoy1'>{104}</TD></TR>")
                tbBody.Append("<TR id='e11c{1}'><TD align='right'><div style='width:90px'>{105}</div></TD><TD align='right'><div style='width:60px;'>{106}%</div></TD><TD class='tdyoy1'>{107}</TD></TR>")
                tbBody.Append("<TR id='e12c{1}'><TD align='right'><div style='width:90px'>{108}</div></TD><TD align='right'><div style='width:60px;'>{109}%</div></TD><TD class='tdyoy1'>{110}</TD></TR>")
                tbBody.Append("<TR id='e13c{1}'><TD align='right'><div style='width:90px'>{111}</div></TD><TD align='right'><div style='width:60px;'>{112}%</div></TD><TD class='tdyoy1'>{113}</TD></TR>")
                tbBody.Append("<TR id='e14c{1}'><TD align='right'><div style='width:90px'>{114}</div></TD><TD align='right'><div style='width:60px;'>{115}%</div></TD><TD class='tdyoy1'>{116}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{117}</div></TD><TD align='right'><div style='width:60px;'>{118}%</div></TD><TD class='tdyoy1'>{119}</TD></TR>")
                tbBody.Append("<TR id='f1c{1}'><TD align='right'><div style='width:90px'>{120}</div></TD><TD align='right'><div style='width:60px;'>{121}%</div></TD><TD class='tdyoy1'>{122}</TD></TR>")
                tbBody.Append("<TR id='f2c{1}'><TD align='right'><div style='width:90px'>{123}</div></TD><TD align='right'><div style='width:60px;'>{124}%</div></TD><TD class='tdyoy1'>{125}</TD></TR>")
                tbBody.Append("<TR id='f3c{1}'><TD align='right'><div style='width:90px'>{126}</div></TD><TD align='right'><div style='width:60px;'>{127}%</div></TD><TD class='tdyoy1'>{128}</TD></TR>")
                tbBody.Append("<TR id='f4c{1}'><TD align='right'><div style='width:90px'>{129}</div></TD><TD align='right'><div style='width:60px;'>{130}%</div></TD><TD class='tdyoy1'>{131}</TD></TR>")
                tbBody.Append("<TR id='f5c{1}'><TD align='right'><div style='width:90px'>{132}</div></TD><TD align='right'><div style='width:60px;'>{133}%</div></TD><TD class='tdyoy1'>{134}</TD></TR>")
                tbBody.Append("<TR id='f6c{1}'><TD align='right'><div style='width:90px'>{135}</div></TD><TD align='right'><div style='width:60px;'>{136}%</div></TD><TD class='tdyoy1'>{137}</TD></TR>")
                tbBody.Append("<TR id='f7c{1}'><TD align='right'><div style='width:90px'>{138}</div></TD><TD align='right'><div style='width:60px;'>{139}%</div></TD><TD class='tdyoy1'>{140}</TD></TR>")
                tbBody.Append("<TR id='f8c{1}'><TD align='right'><div style='width:90px'>{141}</div></TD><TD align='right'><div style='width:60px;'>{142}%</div></TD><TD class='tdyoy1'>{143}</TD></TR>")
                tbBody.Append("<TR id='f9c{1}'><TD align='right'><div style='width:90px'>{144}</div></TD><TD align='right'><div style='width:60px;'>{145}%</div></TD><TD class='tdyoy1'>{146}</TD></TR>")
                tbBody.Append("<TR id='f10c{1}'><TD align='right'><div style='width:90px'>{147}</div></TD><TD align='right'><div style='width:60px;'>{148}%</div></TD><TD class='tdyoy1'>{149}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{150}</div></TD><TD align='right'><div style='width:60px;'>{151}%</div></TD><TD class='tdyoy1'>{152}</TD></TR>")
                tbBody.Append("<TR id='g1c{1}'><TD align='right'><div style='width:90px'>{153}</div></TD><TD align='right'><div style='width:60px;'>{154}%</div></TD><TD class='tdyoy1'>{155}</TD></TR>")
                tbBody.Append("<TR id='g2c{1}'><TD align='right'><div style='width:90px'>{156}</div></TD><TD align='right'><div style='width:60px;'>{157}%</div></TD><TD class='tdyoy1'>{158}</TD></TR>")
                tbBody.Append("<TR id='g3c{1}'><TD align='right'><div style='width:90px'>{159}</div></TD><TD align='right'><div style='width:60px;'>{160}%</div></TD><TD class='tdyoy1'>{161}</TD></TR>")
                tbBody.Append("<TR id='g4c{1}'><TD align='right'><div style='width:90px'>{162}</div></TD><TD align='right'><div style='width:60px;'>{163}%</div></TD><TD class='tdyoy1'>{164}</TD></TR>")
                tbBody.Append("<TR id='g5c{1}'><TD align='right'><div style='width:90px'>{165}</div></TD><TD align='right'><div style='width:60px;'>{166}%</div></TD><TD class='tdyoy1'>{167}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{168}</div></TD><TD align='right'><div style='width:60px;'>{169}%</div></TD><TD class='tdyoy1'>{170}</TD></TR>")
                tbBody.Append("<TR id='h1c{1}'><TD align='right'><div style='width:90px'>{171}</div></TD><TD align='right'><div style='width:60px;'>{172}%</div></TD><TD class='tdyoy1'>{173}</TD></TR>")
                tbBody.Append("<TR id='h2c{1}'><TD align='right'><div style='width:90px'>{174}</div></TD><TD align='right'><div style='width:60px;'>{175}%</div></TD><TD class='tdyoy1'>{176}</TD></TR>")
                tbBody.Append("<TR id='h3c{1}'><TD align='right'><div style='width:90px'>{177}</div></TD><TD align='right'><div style='width:60px;'>{178}%</div></TD><TD class='tdyoy1'>{179}</TD></TR>")
                tbBody.Append("<TR id='h4c{1}'><TD align='right'><div style='width:90px'>{180}</div></TD><TD align='right'><div style='width:60px;'>{181}%</div></TD><TD class='tdyoy1'>{182}</TD></TR>")
                tbBody.Append("<TR id='h5c{1}'><TD align='right'><div style='width:90px'>{183}</div></TD><TD align='right'><div style='width:60px;'>{184}%</div></TD><TD class='tdyoy1'>{185}</TD></TR>")
                tbBody.Append("<TR id='h6c{1}'><TD align='right'><div style='width:90px'>{186}</div></TD><TD align='right'><div style='width:60px;'>{187}%</div></TD><TD class='tdyoy1'>{188}</TD></TR>")
                tbBody.Append("<TR id='h7c{1}'><TD align='right'><div style='width:90px'>{189}</div></TD><TD align='right'><div style='width:60px;'>{190}%</div></TD><TD class='tdyoy1'>{191}</TD></TR>")
                tbBody.Append("<TR id='h8c{1}'><TD align='right'><div style='width:90px'>{192}</div></TD><TD align='right'><div style='width:60px;'>{193}%</div></TD><TD class='tdyoy1'>{194}</TD></TR>")
                tbBody.Append("<TR id='h9c{1}'><TD align='right'><div style='width:90px'>{195}</div></TD><TD align='right'><div style='width:60px;'>{196}%</div></TD><TD class='tdyoy1'>{197}</TD></TR>")
                tbBody.Append("<TR id='h10c{1}'><TD align='right'><div style='width:90px'>{198}</div></TD><TD align='right'><div style='width:60px;'>{199}%</div></TD><TD class='tdyoy1'>{200}</TD></TR>")
                tbBody.Append("<TR id='h11c{1}'><TD align='right'><div style='width:90px'>{201}</div></TD><TD align='right'><div style='width:60px;'>{202}%</div></TD><TD class='tdyoy1'>{203}</TD></TR>")
                tbBody.Append("<TR id='h12c{1}'><TD align='right'><div style='width:90px'>{204}</div></TD><TD align='right'><div style='width:60px;'>{205}%</div></TD><TD class='tdyoy1'>{206}</TD></TR>")
                tbBody.Append("<TR id='h13c{1}'><TD align='right'><div style='width:90px'>{207}</div></TD><TD align='right'><div style='width:60px;'>{208}%</div></TD><TD class='tdyoy1'>{209}</TD></TR>")
                tbBody.Append("<TR id='h14c{1}'><TD align='right'><div style='width:90px'>{210}</div></TD><TD align='right'><div style='width:60px;'>{211}%</div></TD><TD class='tdyoy1'>{212}</TD></TR>")
                tbBody.Append("<TR id='h15c{1}'><TD align='right'><div style='width:90px'>{213}</div></TD><TD align='right'><div style='width:60px;'>{214}%</div></TD><TD class='tdyoy1'>{215}</TD></TR>")
                tbBody.Append("<TR id='h16c{1}'><TD align='right'><div style='width:90px'>{216}</div></TD><TD align='right'><div style='width:60px;'>{217}%</div></TD><TD class='tdyoy1'>{218}</TD></TR>")
                tbBody.Append("<TR id='h17c{1}'><TD align='right'><div style='width:90px'>{219}</div></TD><TD align='right'><div style='width:60px;'>{220}%</div></TD><TD class='tdyoy1'>{221}</TD></TR>")
                tbBody.Append("<TR id='h18c{1}'><TD align='right'><div style='width:90px'>{222}</div></TD><TD align='right'><div style='width:60px;'>{223}%</div></TD><TD class='tdyoy1'>{224}</TD></TR>")
                tbBody.Append("<TR id='h19c{1}'><TD align='right'><div style='width:90px'>{225}</div></TD><TD align='right'><div style='width:60px;'>{226}%</div></TD><TD class='tdyoy1'>{227}</TD></TR>")
                tbBody.Append("<TR id='h20c{1}'><TD align='right'><div style='width:90px'>{228}</div></TD><TD align='right'><div style='width:60px;'>{229}%</div></TD><TD class='tdyoy1'>{230}</TD></TR>")
                tbBody.Append("<TR id='h21c{1}'><TD align='right'><div style='width:90px'>{231}</div></TD><TD align='right'><div style='width:60px;'>{232}%</div></TD><TD class='tdyoy1'>{233}</TD></TR>")
                tbBody.Append("<TR id='h22c{1}'><TD align='right'><div style='width:90px'>{234}</div></TD><TD align='right'><div style='width:60px;'>{235}%</div></TD><TD class='tdyoy1'>{236}</TD></TR>")
                tbBody.Append("<TR id='h23c{1}'><TD align='right'><div style='width:90px'>{237}</div></TD><TD align='right'><div style='width:60px;'>{238}%</div></TD><TD class='tdyoy1'>{239}</TD></TR>")
                tbBody.Append("<TR id='h24c{1}'><TD align='right'><div style='width:90px'>{240}</div></TD><TD align='right'><div style='width:60px;'>{241}%</div></TD><TD class='tdyoy1'>{242}</TD></TR>")
                tbBody.Append("<TR id='h25c{1}'><TD align='right'><div style='width:90px'>{243}</div></TD><TD align='right'><div style='width:60px;'>{244}%</div></TD><TD class='tdyoy1'>{245}</TD></TR>")
                tbBody.Append("<TR id='h26c{1}'><TD align='right'><div style='width:90px'>{246}</div></TD><TD align='right'><div style='width:60px;'>{247}%</div></TD><TD class='tdyoy1'>{248}</TD></TR>")
                tbBody.Append("<TR id='h27c{1}'><TD align='right'><div style='width:90px'>{249}</div></TD><TD align='right'><div style='width:60px;'>{250}%</div></TD><TD class='tdyoy1'>{251}</TD></TR>")
                tbBody.Append("<TR id='h28c{1}'><TD align='right'><div style='width:90px'>{252}</div></TD><TD align='right'><div style='width:60px;'>{253}%</div></TD><TD class='tdyoy1'>{254}</TD></TR>")
                tbBody.Append("<TR id='h29c{1}'><TD align='right'><div style='width:90px'>{255}</div></TD><TD align='right'><div style='width:60px;'>{256}%</div></TD><TD class='tdyoy1'>{257}</TD></TR>")
                tbBody.Append("<TR id='h30c{1}'><TD align='right'><div style='width:90px'>{258}</div></TD><TD align='right'><div style='width:60px;'>{259}%</div></TD><TD class='tdyoy1'>{260}</TD></TR>")
                tbBody.Append("<TR id='h31c{1}'><TD align='right'><div style='width:90px'>{261}</div></TD><TD align='right'><div style='width:60px;'>{262}%</div></TD><TD class='tdyoy1'>{263}</TD></TR>")
                tbBody.Append("<TR id='h32c{1}'><TD align='right'><div style='width:90px'>{264}</div></TD><TD align='right'><div style='width:60px;'>{265}%</div></TD><TD class='tdyoy1'>{266}</TD></TR>")
                tbBody.Append("<TR id='h33c{1}'><TD align='right'><div style='width:90px'>{267}</div></TD><TD align='right'><div style='width:60px;'>{268}%</div></TD><TD class='tdyoy1'>{269}</TD></TR>")
                tbBody.Append("<TR id='h34c{1}'><TD align='right'><div style='width:90px'>{270}</div></TD><TD align='right'><div style='width:60px;'>{271}%</div></TD><TD class='tdyoy1'>{272}</TD></TR>")
                tbBody.Append("<TR id='h35c{1}'><TD align='right'><div style='width:90px'>{273}</div></TD><TD align='right'><div style='width:60px;'>{274}%</div></TD><TD class='tdyoy1'>{275}</TD></TR>")
                tbBody.Append("<TR id='h36c{1}'><TD align='right'><div style='width:90px'>{276}</div></TD><TD align='right'><div style='width:60px;'>{277}%</div></TD><TD class='tdyoy1'>{278}</TD></TR>")
                tbBody.Append("<TR id='h37c{1}'><TD align='right'><div style='width:90px'>{279}</div></TD><TD align='right'><div style='width:60px;'>{280}%</div></TD><TD class='tdyoy1'>{281}</TD></TR>")
                tbBody.Append("<TR id='h38c{1}'><TD align='right'><div style='width:90px'>{282}</div></TD><TD align='right'><div style='width:60px;'>{283}%</div></TD><TD class='tdyoy1'>{284}</TD></TR>")
                tbBody.Append("<TR id='h39c{1}'><TD align='right'><div style='width:90px'>{285}</div></TD><TD align='right'><div style='width:60px;'>{286}%</div></TD><TD class='tdyoy1'>{287}</TD></TR>")
                tbBody.Append("<TR id='h40c{1}'><TD align='right'><div style='width:90px'>{288}</div></TD><TD align='right'><div style='width:60px;'>{289}%</div></TD><TD class='tdyoy1'>{290}</TD></TR>")
                tbBody.Append("<TR id='h41c{1}'><TD align='right'><div style='width:90px'>{291}</div></TD><TD align='right'><div style='width:60px;'>{292}%</div></TD><TD class='tdyoy1'>{293}</TD></TR>")
                tbBody.Append("<TR id='h42c{1}'><TD align='right'><div style='width:90px'>{294}</div></TD><TD align='right'><div style='width:60px;'>{295}%</div></TD><TD class='tdyoy1'>{296}</TD></TR>")
                tbBody.Append("<TR id='h43c{1}'><TD align='right'><div style='width:90px'>{297}</div></TD><TD align='right'><div style='width:60px;'>{298}%</div></TD><TD class='tdyoy1'>{299}</TD></TR>")
                tbBody.Append("<TR id='h44c{1}'><TD align='right'><div style='width:90px'>{300}</div></TD><TD align='right'><div style='width:60px;'>{301}%</div></TD><TD class='tdyoy1'>{302}</TD></TR>")
                tbBody.Append("<TR id='h45c{1}'><TD align='right'><div style='width:90px'>{303}</div></TD><TD align='right'><div style='width:60px;'>{304}%</div></TD><TD class='tdyoy1'>{305}</TD></TR>")
                tbBody.Append("<TR id='h46c{1}'><TD align='right'><div style='width:90px'>{306}</div></TD><TD align='right'><div style='width:60px;'>{307}%</div></TD><TD class='tdyoy1'>{308}</TD></TR>")
                tbBody.Append("<TR id='h47c{1}'><TD align='right'><div style='width:90px'>{309}</div></TD><TD align='right'><div style='width:60px;'>{310}%</div></TD><TD class='tdyoy1'>{311}</TD></TR>")
                tbBody.Append("<TR id='h48c{1}'><TD align='right'><div style='width:90px'>{312}</div></TD><TD align='right'><div style='width:60px;'>{313}%</div></TD><TD class='tdyoy1'>{314}</TD></TR>")
                tbBody.Append("<TR id='h49c{1}'><TD align='right'><div style='width:90px'>{315}</div></TD><TD align='right'><div style='width:60px;'>{316}%</div></TD><TD class='tdyoy1'>{317}</TD></TR>")
                tbBody.Append("<TR id='h50c{1}'><TD align='right'><div style='width:90px'>{318}</div></TD><TD align='right'><div style='width:60px;'>{319}%</div></TD><TD class='tdyoy1'>{320}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{321}</div></TD><TD align='right'><div style='width:60px;'>{322}%</div></TD><TD class='tdyoy1'>{323}</TD></TR>")
                Return tbBody.ToString
            Case 3
                Dim tbFoot As New StringBuilder
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{0}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{1}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD></TD></TR>")
                tbFoot.Append("</TABLE>")
                Return tbFoot.ToString
            Case Else
                Return ""
        End Select
    End Function
#End Region

#Region "LFL Compare"

    Public Shared Function htmlLFLCompareTopic() As String
        Dim sb As New StringBuilder
        sb.Append("<table cellspacing='0' cellpadding='0' border='0' class='tball2'>")
        sb.Append("<tr style='font-weight:bold;' class='rbg0'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>{0}</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;height:31px' class='rbg1'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;{1}&nbsp;</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Number of Stores</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Total Gross Space (SQM)</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Total Selling Space (SQM)</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Productivity/SQM</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;</div></td></tr>")

        'sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Revenue Growth-YOY</div></td></tr>")
        'sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Revenue Growth-LFL</div></td></tr>")
        'sb.Append("<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Revenue <span id='spaa' class='ppk' onclick=""minitb('aa');"">+</span></div></td></tr>")
        sb.Append("<tr id='aa1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sale Revenue</div></td></tr>")
        sb.Append("<tr id='aa2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Revenue</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Cost of Good Sold</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Gross Retails Profit</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Margin Adjustments <span id='spb' class='ppk' onclick=""minitb('b');"">+</span></div></td></tr>")
        sb.Append("<tr id='b1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shipping</div></td></tr>")
        sb.Append("<tr id='b2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss and Obsolescence</div></td></tr>")
        sb.Append("<tr id='b3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - stock check (Actual)</div></td></tr>")
        sb.Append("<tr id='b4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - damaged and obsolete stock (Actual)</div></td></tr>")
        sb.Append("<tr id='b5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss  (Provision)</div></td></tr>")
        sb.Append("<tr id='b6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Obsolescence (Provision)</div></td></tr>")
        sb.Append("<tr id='b7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWP</div></td></tr>")
        sb.Append("<tr id='b8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWPs - Corporate</div></td></tr>")
        sb.Append("<tr id='b9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWPs - Transferred</div></td></tr>")
        sb.Append("<tr id='b10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Selling Costs</div></td></tr>")
        sb.Append("<tr id='b11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Credit cards commission</div></td></tr>")
        sb.Append("<tr id='b12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Labelling Material</div></td></tr>")
        sb.Append("<tr id='b13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Income - COSH Funding</div></td></tr>")
        sb.Append("<tr id='b14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Income Supplier</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Adjusted Gross Retails Profit</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg4'><td align='left' class='kbg2';'><div style='width:200px;padding-left:5px;' class='pptk'>Supply Chain Costs</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Store Expenses</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Store Labour Costs <span id='spe' class='ppk' onclick=""minitb('e');"">+</span></div></td></tr>")
        sb.Append("<tr id='e1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Gross Pay</div></td></tr>")
        sb.Append("<tr id='e2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Temporary Staff Costs</div></td></tr>")
        sb.Append("<tr id='e3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Allowance</div></td></tr>")
        sb.Append("<tr id='e4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Overtime</div></td></tr>")
        sb.Append("<tr id='e5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - License fee</div></td></tr>")
        sb.Append("<tr id='e6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Bonuses/Incentives</div></td></tr>")
        sb.Append("<tr id='e7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Boots Brand ncentives</div></td></tr>")
        sb.Append("<tr id='e8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Suppliers Incentive</div></td></tr>")
        sb.Append("<tr id='e9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Provident Fund</div></td></tr>")
        sb.Append("<tr id='e10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Pension Costs</div></td></tr>")
        sb.Append("<tr id='e11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Social Security Fund</div></td></tr>")
        sb.Append("<tr id='e12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Uniforms</div></td></tr>")
        sb.Append("<tr id='e13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Employee Welfare</div></td></tr>")
        sb.Append("<tr id='e14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Benefits Employee</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Store Property Costs <span id='spf' class='ppk' onclick=""minitb('f');"">+</span></div></td></tr>")
        sb.Append("<tr id='f1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Rental</div></td></tr>")
        sb.Append("<tr id='f2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Services</div></td></tr>")
        sb.Append("<tr id='f3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Facility</div></td></tr>")
        sb.Append("<tr id='f4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property taxes</div></td></tr>")
        sb.Append("<tr id='f5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Facial taxes</div></td></tr>")
        sb.Append("<tr id='f6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Insurance</div></td></tr>")
        sb.Append("<tr id='f7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Signboard</div></td></tr>")
        sb.Append("<tr id='f8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Discount - Rent/Services/Facility</div></td></tr>")
        sb.Append("<tr id='f9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GP Commission</div></td></tr>")
        sb.Append("<tr id='f10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Amortization of Lease Right</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Depreciation <span id='spg' class='ppk' onclick=""minitb('g');"">+</span></div></td></tr>")
        sb.Append("<tr id='g1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Short Lease Building</div></td></tr>")
        sb.Append("<tr id='g2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Computer Hardware</div></td></tr>")
        sb.Append("<tr id='g3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Fixtures & Fittings</div></td></tr>")
        sb.Append("<tr id='g4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Computer Software</div></td></tr>")
        sb.Append("<tr id='g5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Office Equipment</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' class='rbg3'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Other Store Costs <span id='sph' class='ppk' onclick=""minitb('h');"">+</span></div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Service Charges and Other Fees</div></td></tr>")

        sb.Append("<tr id='h2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Bank Charges</div></td></tr>")
        sb.Append("<tr id='h3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cash Collection Charge</div></td></tr>")
        sb.Append("<tr id='h4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cleaning</div></td></tr>")
        sb.Append("<tr id='h5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Security Guards</div></td></tr>")
        sb.Append("<tr id='h6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Carriage</div></td></tr>")
        sb.Append("<tr id='h7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Licence Fees</div></td></tr>")
        sb.Append("<tr id='h8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Services Charge</div></td></tr>")
        sb.Append("<tr id='h9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Fees</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Utilities</div></td></tr>")

        sb.Append("<tr id='h11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Water</div></td></tr>")
        sb.Append("<tr id='h12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Gas/Electric</div></td></tr>")
        sb.Append("<tr id='h13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Air Cond. - Addition</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Repair and Maintenance</div></td></tr>")

        sb.Append("<tr id='h15'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Other - Fix</div></td></tr>")
        sb.Append("<tr id='h16'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Other - Unplan</div></td></tr>")
        sb.Append("<tr id='h17'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Computer - Fix</div></td></tr>")
        sb.Append("<tr id='h18'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Computer - Unplan</div></td></tr>")
        'new line
        sb.Append("<tr id='h51'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - SW Maintenance</div></td></tr>")
        sb.Append("<tr id='h52'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - HW Maintenance</div></td></tr>")

        sb.Append("<tr style='font-weight:bold' id='h19'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Professional Fee</div></td></tr>")

        sb.Append("<tr id='h20'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Marketing Research</div></td></tr>")
        sb.Append("<tr id='h21'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Fee</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h22'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Equipment, Materail and Supplies</div></td></tr>")

        sb.Append("<tr id='h23'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Printing and Stationery</div></td></tr>")
        sb.Append("<tr id='h24'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Supplies Expenses</div></td></tr>")
        sb.Append("<tr id='h25'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Equipment</div></td></tr>")
        sb.Append("<tr id='h26'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shopfitting</div></td></tr>")
        sb.Append("<tr id='h27'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Packaging and Other Material</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h28'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Business Travel Expenses</div></td></tr>")

        sb.Append("<tr id='h29'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Car Parking and Others</div></td></tr>")
        sb.Append("<tr id='h30'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Travel</div></td></tr>")
        sb.Append("<tr id='h31'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Accomodation</div></td></tr>")
        sb.Append("<tr id='h32'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Meal and Entertainment</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h33'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Insurance</div></td></tr>")

        sb.Append("<tr id='h34'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - All Risk Insurance</div></td></tr>")
        sb.Append("<tr id='h35'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Health and Life Insurance</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h36'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Penalty and Taxation</div></td></tr>")

        sb.Append("<tr id='h37'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Taxation</div></td></tr>")
        sb.Append("<tr id='h38'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Penalty</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h39'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Related Staff Cost</div></td></tr>")

        sb.Append("<tr id='h40'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Staff Conference and Training</div></td></tr>")
        sb.Append("<tr id='h41'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Training</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h42'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Communication</div></td></tr>")

        sb.Append("<tr id='h43'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Telephone Calls/Faxes</div></td></tr>")
        sb.Append("<tr id='h44'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Postage and Courier</div></td></tr>")
        'new line
        sb.Append("<tr id='h53'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - IT Telecommunications</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h45'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Expenses</div></td></tr>")

        sb.Append("<tr id='h46'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sample/Tester</div></td></tr>")
        sb.Append("<tr id='h47'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Preopening Costs</div></td></tr>")
        sb.Append("<tr id='h48'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Loss on Claim</div></td></tr>")
        sb.Append("<tr id='h49'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cash Overtage/Shortage from sales</div></td></tr>")
        sb.Append("<tr id='h50'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Miscellenous and Other</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Store Trading Profit / (Loss)</div></td></tr>")
        'sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Store Trading Profit Growth-YOY</div></td></tr>")
        'sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Store Trading Profit Growth-LFL</div></td></tr>")
        sb.Append("</table>")

        Return sb.ToString
    End Function

    Public Shared Function htmlLFLCompareItem(part As tablePart, Optional hasBorder As Boolean = False) As String

        Select Case part
            Case 1
                Dim tbHead As New StringBuilder

                'for border (ตีกรอบ)
                Dim tblClass As String = "tball2"
                If hasBorder Then
                    tblClass = "tbTotal"
                End If
                'tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
                tbHead.Append(String.Format("<TABLE cellspacing='0' cellpadding='0' class='{0}'>", tblClass))
                tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='2'><strong>{0}</strong></TD></TR>")

                'assing width this row
                tbHead.Append("<TR style='font-weight:bold;height:30px' class='rbg1'><TD align='center'><div style='width:90px'><strong>{1}</strong></div></TD><TD align='center'><div style='width:60px;'><strong>% Sale</strong></div></TD></TR>")

                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' ><strong>{2}</strong></TD><TD align='center'><div style='width:60px;'><strong></strong></div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'>{3}</TD><TD align='center' class='rbg2'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{4}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{5}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbHead.Append("<TR><TD></TD><TD>&nbsp;</TD></TR>")
                'tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{6}</TD><TD>&nbsp;</TD></TR>")
                'tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{7}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                'tbHead.Append("<TR><TD></TD><TD>&nbsp;</TD></TR>")

                Return tbHead.ToString
            Case 2
                Dim tbBody As New StringBuilder
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{3}</TD><TD align='right'><div style='width:60px;'>{4}%</div></TD></TR>")
                tbBody.Append("<TR id='aa1c{1}'><TD align='right'>{6}</TD><TD align='right'><div style='width:60px;'>{7}%</div></TD></TR>")
                tbBody.Append("<TR id='aa2c{1}'><TD align='right'>{9}</TD><TD align='right'><div style='width:60px;'>{10}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'>{12}</TD><TD align='right'><div style='width:60px;'>{13}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{15}</TD><TD align='right'><div style='width:60px;'>{16}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'>{18}</TD><TD align='right'><div style='width:60px;'>{19}%</div></TD></TR>")
                tbBody.Append("<TR id='b1c{1}'><TD align='right'>{21}</TD><TD align='right'><div style='width:60px;'>{22}%</div></TD></TR>")
                tbBody.Append("<TR id='b2c{1}'><TD align='right'>{24}</TD><TD align='right'><div style='width:60px;'>{25}%</div></TD></TR>")
                tbBody.Append("<TR id='b3c{1}'><TD align='right'>{27}</TD><TD align='right'><div style='width:60px;'>{28}%</div></TD></TR>")
                tbBody.Append("<TR id='b4c{1}'><TD align='right'>{30}</TD><TD align='right'><div style='width:60px;'>{31}%</div></TD></TR>")
                tbBody.Append("<TR id='b5c{1}'><TD align='right'>{33}</TD><TD align='right'><div style='width:60px;'>{34}%</div></TD></TR>")
                tbBody.Append("<TR id='b6c{1}'><TD align='right'>{36}</TD><TD align='right'><div style='width:60px;'>{37}%</div></TD></TR>")
                tbBody.Append("<TR id='b7c{1}'><TD align='right'>{39}</TD><TD align='right'><div style='width:60px;'>{40}%</div></TD></TR>")
                tbBody.Append("<TR id='b8c{1}'><TD align='right'>{42}</TD><TD align='right'><div style='width:60px;'>{43}%</div></TD></TR>")
                tbBody.Append("<TR id='b9c{1}'><TD align='right'>{45}</TD><TD align='right'><div style='width:60px;'>{46}%</div></TD></TR>")
                tbBody.Append("<TR id='b10c{1}'><TD align='right'>{48}</TD><TD align='right'><div style='width:60px;'>{49}%</div></TD></TR>")
                tbBody.Append("<TR id='b11c{1}'><TD align='right'>{51}</TD><TD align='right'><div style='width:60px;'>{52}%</div></TD></TR>")
                tbBody.Append("<TR id='b12c{1}'><TD align='right'>{54}</TD><TD align='right'><div style='width:60px;'>{55}%</div></TD></TR>")
                tbBody.Append("<TR id='b13c{1}'><TD align='right'>{57}</TD><TD align='right'><div style='width:60px;'>{58}%</div></TD></TR>")
                tbBody.Append("<TR id='b14c{1}'><TD align='right'>{60}</TD><TD align='right'><div style='width:60px;'>{61}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{63}</TD><TD align='right'><div style='width:60px;'>{64}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg4'><TD align='right'>{66}</TD><TD align='right'><div style='width:60px;'>{67}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{69}</TD><TD align='right'><div style='width:60px;'>{70}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{72}</TD><TD align='right'><div style='width:60px;'>{73}%</div></TD></TR>")
                tbBody.Append("<TR id='e1c{1}'><TD align='right'>{75}</TD><TD align='right'><div style='width:60px;'>{76}%</div></TD></TR>")
                tbBody.Append("<TR id='e2c{1}'><TD align='right'>{78}</TD><TD align='right'><div style='width:60px;'>{79}%</div></TD></TR>")
                tbBody.Append("<TR id='e3c{1}'><TD align='right'>{81}</TD><TD align='right'><div style='width:60px;'>{82}%</div></TD></TR>")
                tbBody.Append("<TR id='e4c{1}'><TD align='right'>{84}</TD><TD align='right'><div style='width:60px;'>{85}%</div></TD></TR>")
                tbBody.Append("<TR id='e5c{1}'><TD align='right'>{87}</TD><TD align='right'><div style='width:60px;'>{88}%</div></TD></TR>")
                tbBody.Append("<TR id='e6c{1}'><TD align='right'>{90}</TD><TD align='right'><div style='width:60px;'>{91}%</div></TD></TR>")
                tbBody.Append("<TR id='e7c{1}'><TD align='right'>{93}</TD><TD align='right'><div style='width:60px;'>{94}%</div></TD></TR>")
                tbBody.Append("<TR id='e8c{1}'><TD align='right'>{96}</TD><TD align='right'><div style='width:60px;'>{97}%</div></TD></TR>")
                tbBody.Append("<TR id='e9c{1}'><TD align='right'>{99}</TD><TD align='right'><div style='width:60px;'>{100}%</div></TD></TR>")
                tbBody.Append("<TR id='e10c{1}'><TD align='right'>{102}</TD><TD align='right'><div style='width:60px;'>{103}%</div></TD></TR>")
                tbBody.Append("<TR id='e11c{1}'><TD align='right'>{105}</TD><TD align='right'><div style='width:60px;'>{106}%</div></TD></TR>")
                tbBody.Append("<TR id='e12c{1}'><TD align='right'>{108}</TD><TD align='right'><div style='width:60px;'>{109}%</div></TD></TR>")
                tbBody.Append("<TR id='e13c{1}'><TD align='right'>{111}</TD><TD align='right'><div style='width:60px;'>{112}%</div></TD></TR>")
                tbBody.Append("<TR id='e14c{1}'><TD align='right'>{114}</TD><TD align='right'><div style='width:60px;'>{115}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{117}</TD><TD align='right'><div style='width:60px;'>{118}%</div></TD></TR>")
                tbBody.Append("<TR id='f1c{1}'><TD align='right'>{120}</TD><TD align='right'><div style='width:60px;'>{121}%</div></TD></TR>")
                tbBody.Append("<TR id='f2c{1}'><TD align='right'>{123}</TD><TD align='right'><div style='width:60px;'>{124}%</div></TD></TR>")
                tbBody.Append("<TR id='f3c{1}'><TD align='right'>{126}</TD><TD align='right'><div style='width:60px;'>{127}%</div></TD></TR>")
                tbBody.Append("<TR id='f4c{1}'><TD align='right'>{129}</TD><TD align='right'><div style='width:60px;'>{130}%</div></TD></TR>")
                tbBody.Append("<TR id='f5c{1}'><TD align='right'>{132}</TD><TD align='right'><div style='width:60px;'>{133}%</div></TD></TR>")
                tbBody.Append("<TR id='f6c{1}'><TD align='right'>{135}</TD><TD align='right'><div style='width:60px;'>{136}%</div></TD></TR>")
                tbBody.Append("<TR id='f7c{1}'><TD align='right'>{138}</TD><TD align='right'><div style='width:60px;'>{139}%</div></TD></TR>")
                tbBody.Append("<TR id='f8c{1}'><TD align='right'>{141}</TD><TD align='right'><div style='width:60px;'>{142}%</div></TD></TR>")
                tbBody.Append("<TR id='f9c{1}'><TD align='right'>{144}</TD><TD align='right'><div style='width:60px;'>{145}%</div></TD></TR>")
                tbBody.Append("<TR id='f10c{1}'><TD align='right'>{147}</TD><TD align='right'><div style='width:60px;'>{148}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{150}</TD><TD align='right'><div style='width:60px;'>{151}%</div></TD></TR>")
                tbBody.Append("<TR id='g1c{1}'><TD align='right'>{153}</TD><TD align='right'><div style='width:60px;'>{154}%</div></TD></TR>")
                tbBody.Append("<TR id='g2c{1}'><TD align='right'>{156}</TD><TD align='right'><div style='width:60px;'>{157}%</div></TD></TR>")
                tbBody.Append("<TR id='g3c{1}'><TD align='right'>{159}</TD><TD align='right'><div style='width:60px;'>{160}%</div></TD></TR>")
                tbBody.Append("<TR id='g4c{1}'><TD align='right'>{162}</TD><TD align='right'><div style='width:60px;'>{163}%</div></TD></TR>")
                tbBody.Append("<TR id='g5c{1}'><TD align='right'>{165}</TD><TD align='right'><div style='width:60px;'>{166}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{168}</TD><TD align='right'><div style='width:60px;'>{169}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h1c{1}'><TD align='right'>{171}</TD><TD align='right'><div style='width:60px;'>{172}%</div></TD></TR>")

                tbBody.Append("<TR id='h2c{1}'><TD align='right'>{174}</TD><TD align='right'><div style='width:60px;'>{175}%</div></TD></TR>")
                tbBody.Append("<TR id='h3c{1}'><TD align='right'>{177}</TD><TD align='right'><div style='width:60px;'>{178}%</div></TD></TR>")
                tbBody.Append("<TR id='h4c{1}'><TD align='right'>{180}</TD><TD align='right'><div style='width:60px;'>{181}%</div></TD></TR>")
                tbBody.Append("<TR id='h5c{1}'><TD align='right'>{183}</TD><TD align='right'><div style='width:60px;'>{184}%</div></TD></TR>")
                tbBody.Append("<TR id='h6c{1}'><TD align='right'>{186}</TD><TD align='right'><div style='width:60px;'>{187}%</div></TD></TR>")
                tbBody.Append("<TR id='h7c{1}'><TD align='right'>{189}</TD><TD align='right'><div style='width:60px;'>{190}%</div></TD></TR>")
                tbBody.Append("<TR id='h8c{1}'><TD align='right'>{192}</TD><TD align='right'><div style='width:60px;'>{193}%</div></TD></TR>")
                tbBody.Append("<TR id='h9c{1}'><TD align='right'>{195}</TD><TD align='right'><div style='width:60px;'>{196}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h10c{1}'><TD align='right'>{198}</TD><TD align='right'><div style='width:60px;'>{199}%</div></TD></TR>")

                tbBody.Append("<TR id='h11c{1}'><TD align='right'>{201}</TD><TD align='right'><div style='width:60px;'>{202}%</div></TD></TR>")
                tbBody.Append("<TR id='h12c{1}'><TD align='right'>{204}</TD><TD align='right'><div style='width:60px;'>{205}%</div></TD></TR>")
                tbBody.Append("<TR id='h13c{1}'><TD align='right'>{207}</TD><TD align='right'><div style='width:60px;'>{208}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h14c{1}'><TD align='right'>{210}</TD><TD align='right'><div style='width:60px;'>{211}%</div></TD></TR>")

                tbBody.Append("<TR id='h15c{1}'><TD align='right'>{213}</TD><TD align='right'><div style='width:60px;'>{214}%</div></TD></TR>")
                tbBody.Append("<TR id='h16c{1}'><TD align='right'>{216}</TD><TD align='right'><div style='width:60px;'>{217}%</div></TD></TR>")
                tbBody.Append("<TR id='h17c{1}'><TD align='right'>{219}</TD><TD align='right'><div style='width:60px;'>{220}%</div></TD></TR>")
                tbBody.Append("<TR id='h18c{1}'><TD align='right'>{222}</TD><TD align='right'><div style='width:60px;'>{223}%</div></TD></TR>")
                'new line
                tbBody.Append("<TR id='h51c{1}'><TD align='right'>{324}</TD><TD align='right'><div style='width:60px;'>{325}%</div></TD></TR>")
                tbBody.Append("<TR id='h52c{1}'><TD align='right'>{327}</TD><TD align='right'><div style='width:60px;'>{328}%</div></TD></TR>")

                tbBody.Append("<TR style='font-weight:bold' id='h19c{1}'><TD align='right'>{225}</TD><TD align='right'><div style='width:60px;'>{226}%</div></TD></TR>")

                tbBody.Append("<TR id='h20c{1}'><TD align='right'>{228}</TD><TD align='right'><div style='width:60px;'>{229}%</div></TD></TR>")
                tbBody.Append("<TR id='h21c{1}'><TD align='right'>{231}</TD><TD align='right'><div style='width:60px;'>{232}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h22c{1}'><TD align='right'>{234}</TD><TD align='right'><div style='width:60px;'>{235}%</div></TD></TR>")

                tbBody.Append("<TR id='h23c{1}'><TD align='right'>{237}</TD><TD align='right'><div style='width:60px;'>{238}%</div></TD></TR>")
                tbBody.Append("<TR id='h24c{1}'><TD align='right'>{240}</TD><TD align='right'><div style='width:60px;'>{241}%</div></TD></TR>")
                tbBody.Append("<TR id='h25c{1}'><TD align='right'>{243}</TD><TD align='right'><div style='width:60px;'>{244}%</div></TD></TR>")
                tbBody.Append("<TR id='h26c{1}'><TD align='right'>{246}</TD><TD align='right'><div style='width:60px;'>{247}%</div></TD></TR>")
                tbBody.Append("<TR id='h27c{1}'><TD align='right'>{249}</TD><TD align='right'><div style='width:60px;'>{250}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h28c{1}'><TD align='right'>{252}</TD><TD align='right'><div style='width:60px;'>{253}%</div></TD></TR>")

                tbBody.Append("<TR id='h29c{1}'><TD align='right'>{255}</TD><TD align='right'><div style='width:60px;'>{256}%</div></TD></TR>")
                tbBody.Append("<TR id='h30c{1}'><TD align='right'>{258}</TD><TD align='right'><div style='width:60px;'>{259}%</div></TD></TR>")
                tbBody.Append("<TR id='h31c{1}'><TD align='right'>{261}</TD><TD align='right'><div style='width:60px;'>{262}%</div></TD></TR>")
                tbBody.Append("<TR id='h32c{1}'><TD align='right'>{264}</TD><TD align='right'><div style='width:60px;'>{265}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h33c{1}'><TD align='right'>{267}</TD><TD align='right'><div style='width:60px;'>{268}%</div></TD></TR>")

                tbBody.Append("<TR id='h34c{1}'><TD align='right'>{270}</TD><TD align='right'><div style='width:60px;'>{271}%</div></TD></TR>")
                tbBody.Append("<TR id='h35c{1}'><TD align='right'>{273}</TD><TD align='right'><div style='width:60px;'>{274}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h36c{1}'><TD align='right'>{276}</TD><TD align='right'><div style='width:60px;'>{277}%</div></TD></TR>")

                tbBody.Append("<TR id='h37c{1}'><TD align='right'>{279}</TD><TD align='right'><div style='width:60px;'>{280}%</div></TD></TR>")
                tbBody.Append("<TR id='h38c{1}'><TD align='right'>{282}</TD><TD align='right'><div style='width:60px;'>{283}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h39c{1}'><TD align='right'>{285}</TD><TD align='right'><div style='width:60px;'>{286}%</div></TD></TR>")

                tbBody.Append("<TR id='h40c{1}'><TD align='right'>{288}</TD><TD align='right'><div style='width:60px;'>{289}%</div></TD></TR>")
                tbBody.Append("<TR id='h41c{1}'><TD align='right'>{291}</TD><TD align='right'><div style='width:60px;'>{292}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h42c{1}'><TD align='right'>{294}</TD><TD align='right'><div style='width:60px;'>{295}%</div></TD></TR>")

                tbBody.Append("<TR id='h43c{1}'><TD align='right'>{297}</TD><TD align='right'><div style='width:60px;'>{298}%</div></TD></TR>")
                tbBody.Append("<TR id='h44c{1}'><TD align='right'>{300}</TD><TD align='right'><div style='width:60px;'>{301}%</div></TD></TR>")
                'new line
                tbBody.Append("<TR id='h53c{1}'><TD align='right'>{330}</TD><TD align='right'><div style='width:60px;'>{331}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h45c{1}'><TD align='right'>{303}</TD><TD align='right'><div style='width:60px;'>{304}%</div></TD></TR>")

                tbBody.Append("<TR id='h46c{1}'><TD align='right'>{306}</TD><TD align='right'><div style='width:60px;'>{307}%</div></TD></TR>")
                tbBody.Append("<TR id='h47c{1}'><TD align='right'>{309}</TD><TD align='right'><div style='width:60px;'>{310}%</div></TD></TR>")
                tbBody.Append("<TR id='h48c{1}'><TD align='right'>{312}</TD><TD align='right'><div style='width:60px;'>{313}%</div></TD></TR>")
                tbBody.Append("<TR id='h49c{1}'><TD align='right'>{315}</TD><TD align='right'><div style='width:60px;'>{316}%</div></TD></TR>")
                tbBody.Append("<TR id='h50c{1}'><TD align='right'>{318}</TD><TD align='right'><div style='width:60px;'>{319}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{321}</TD><TD align='right'><div style='width:60px;'>{322}%</div></TD></TR>")

                Return tbBody.ToString
            Case 3
                Dim tbFoot As New StringBuilder
                'tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{0}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                'tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{1}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbFoot.Append("</TABLE>")

                Return tbFoot.ToString
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function htmlGrowthLFLCompare(part As tablePart) As String 'replace Column Total

        Select Case part
            Case 1
                Dim tbHead As New StringBuilder
                tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center'><strong>{0}</strong></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;height:30px;' class='rbg1'><TD align='center'><div style='width:70px'><strong>{1}</strong></div></TD> </TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:70px'><strong>{2}</strong></div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'><div style='width:70px;'>{3}</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:70px'>{4}</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:70px'>{5}</div></TD></TR>")
                tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:70px'>&nbsp;</div></TD></TR>")
                'tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:70px'>{6}</div></TD></TR>")
                'tbHead.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:70px'>{7}</div></TD></TR>")
                'tbHead.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:70px'>&nbsp;</div></TD></TR>")
                Return tbHead.ToString
            Case 2
                Dim tbBody As New StringBuilder
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:70px'>{3}</div></TD></TR>")
                tbBody.Append("<TR id='aa1c{1}'><TD align='right'><div style='width:70px'>{6}</div></TD></TR>")
                tbBody.Append("<TR id='aa2c{1}'><TD align='right'><div style='width:70px'>{9}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:70px'>{12}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:70px'>{15}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:70px'>{18}</div></TD></TR>")
                tbBody.Append("<TR id='b1c{1}'><TD align='right'><div style='width:70px'>{21}</div></TD></TR>")
                tbBody.Append("<TR id='b2c{1}'><TD align='right'><div style='width:70px'>{24}</div></TD></TR>")
                tbBody.Append("<TR id='b3c{1}'><TD align='right'><div style='width:70px'>{27}</div></TD></TR>")
                tbBody.Append("<TR id='b4c{1}'><TD align='right'><div style='width:70px'>{30}</div></TD></TR>")
                tbBody.Append("<TR id='b5c{1}'><TD align='right'><div style='width:70px'>{33}</div></TD></TR>")
                tbBody.Append("<TR id='b6c{1}'><TD align='right'><div style='width:70px'>{36}</div></TD></TR>")
                tbBody.Append("<TR id='b7c{1}'><TD align='right'><div style='width:70px'>{39}</div></TD></TR>")
                tbBody.Append("<TR id='b8c{1}'><TD align='right'><div style='width:70px'>{42}</div></TD></TR>")
                tbBody.Append("<TR id='b9c{1}'><TD align='right'><div style='width:70px'>{45}</div></TD></TR>")
                tbBody.Append("<TR id='b10c{1}'><TD align='right'><div style='width:70px'>{48}</div></TD></TR>")
                tbBody.Append("<TR id='b11c{1}'><TD align='right'><div style='width:70px'>{51}</div></TD></TR>")
                tbBody.Append("<TR id='b12c{1}'><TD align='right'><div style='width:70px'>{54}</div></TD></TR>")
                tbBody.Append("<TR id='b13c{1}'><TD align='right'><div style='width:70px'>{57}</div></TD></TR>")
                tbBody.Append("<TR id='b14c{1}'><TD align='right'><div style='width:70px'>{60}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:70px'>{63}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg4'><TD align='right'><div style='width:70px'>{66}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:70px'>{69}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:70px'>{72}</div></TD></TR>")
                tbBody.Append("<TR id='e1c{1}'><TD align='right'><div style='width:70px'>{75}</div></TD></TR>")
                tbBody.Append("<TR id='e2c{1}'><TD align='right'><div style='width:70px'>{78}</div></TD></TR>")
                tbBody.Append("<TR id='e3c{1}'><TD align='right'><div style='width:70px'>{81}</div></TD></TR>")
                tbBody.Append("<TR id='e4c{1}'><TD align='right'><div style='width:70px'>{84}</div></TD></TR>")
                tbBody.Append("<TR id='e5c{1}'><TD align='right'><div style='width:70px'>{87}</div></TD></TR>")
                tbBody.Append("<TR id='e6c{1}'><TD align='right'><div style='width:70px'>{90}</div></TD></TR>")
                tbBody.Append("<TR id='e7c{1}'><TD align='right'><div style='width:70px'>{93}</div></TD></TR>")
                tbBody.Append("<TR id='e8c{1}'><TD align='right'><div style='width:70px'>{96}</div></TD></TR>")
                tbBody.Append("<TR id='e9c{1}'><TD align='right'><div style='width:70px'>{99}</div></TD></TR>")
                tbBody.Append("<TR id='e10c{1}'><TD align='right'><div style='width:70px'>{102}</div></TD></TR>")
                tbBody.Append("<TR id='e11c{1}'><TD align='right'><div style='width:70px'>{105}</div></TD></TR>")
                tbBody.Append("<TR id='e12c{1}'><TD align='right'><div style='width:70px'>{108}</div></TD></TR>")
                tbBody.Append("<TR id='e13c{1}'><TD align='right'><div style='width:70px'>{111}</div></TD></TR>")
                tbBody.Append("<TR id='e14c{1}'><TD align='right'><div style='width:70px'>{114}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:70px'>{117}</div></TD></TR>")
                tbBody.Append("<TR id='f1c{1}'><TD align='right'><div style='width:70px'>{120}</div></TD></TR>")
                tbBody.Append("<TR id='f2c{1}'><TD align='right'><div style='width:70px'>{123}</div></TD></TR>")
                tbBody.Append("<TR id='f3c{1}'><TD align='right'><div style='width:70px'>{126}</div></TD></TR>")
                tbBody.Append("<TR id='f4c{1}'><TD align='right'><div style='width:70px'>{129}</div></TD></TR>")
                tbBody.Append("<TR id='f5c{1}'><TD align='right'><div style='width:70px'>{132}</div></TD></TR>")
                tbBody.Append("<TR id='f6c{1}'><TD align='right'><div style='width:70px'>{135}</div></TD></TR>")
                tbBody.Append("<TR id='f7c{1}'><TD align='right'><div style='width:70px'>{138}</div></TD></TR>")
                tbBody.Append("<TR id='f8c{1}'><TD align='right'><div style='width:70px'>{141}</div></TD></TR>")
                tbBody.Append("<TR id='f9c{1}'><TD align='right'><div style='width:70px'>{144}</div></TD></TR>")
                tbBody.Append("<TR id='f10c{1}'><TD align='right'><div style='width:70px'>{147}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:70px'>{150}</div></TD></TR>")
                tbBody.Append("<TR id='g1c{1}'><TD align='right'><div style='width:70px'>{153}</div></TD></TR>")
                tbBody.Append("<TR id='g2c{1}'><TD align='right'><div style='width:70px'>{156}</div></TD></TR>")
                tbBody.Append("<TR id='g3c{1}'><TD align='right'><div style='width:70px'>{159}</div></TD></TR>")
                tbBody.Append("<TR id='g4c{1}'><TD align='right'><div style='width:70px'>{162}</div></TD></TR>")
                tbBody.Append("<TR id='g5c{1}'><TD align='right'><div style='width:70px'>{165}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:70px'>{168}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h1c{1}'><TD align='right'><div style='width:70px'>{171}</div></TD></TR>")

                tbBody.Append("<TR id='h2c{1}'><TD align='right'><div style='width:70px'>{174}</div></TD></TR>")
                tbBody.Append("<TR id='h3c{1}'><TD align='right'><div style='width:70px'>{177}</div></TD></TR>")
                tbBody.Append("<TR id='h4c{1}'><TD align='right'><div style='width:70px'>{180}</div></TD></TR>")
                tbBody.Append("<TR id='h5c{1}'><TD align='right'><div style='width:70px'>{183}</div></TD></TR>")
                tbBody.Append("<TR id='h6c{1}'><TD align='right'><div style='width:70px'>{186}</div></TD></TR>")
                tbBody.Append("<TR id='h7c{1}'><TD align='right'><div style='width:70px'>{189}</div></TD></TR>")
                tbBody.Append("<TR id='h8c{1}'><TD align='right'><div style='width:70px'>{192}</div></TD></TR>")
                tbBody.Append("<TR id='h9c{1}'><TD align='right'><div style='width:70px'>{195}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h10c{1}'><TD align='right'><div style='width:70px'>{198}</div></TD></TR>")

                tbBody.Append("<TR id='h11c{1}'><TD align='right'><div style='width:70px'>{201}</div></TD></TR>")
                tbBody.Append("<TR id='h12c{1}'><TD align='right'><div style='width:70px'>{204}</div></TD></TR>")
                tbBody.Append("<TR id='h13c{1}'><TD align='right'><div style='width:70px'>{207}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h14c{1}'><TD align='right'><div style='width:70px'>{210}</div></TD></TR>")

                tbBody.Append("<TR id='h15c{1}'><TD align='right'><div style='width:70px'>{213}</div></TD></TR>")
                tbBody.Append("<TR id='h16c{1}'><TD align='right'><div style='width:70px'>{216}</div></TD></TR>")
                tbBody.Append("<TR id='h17c{1}'><TD align='right'><div style='width:70px'>{219}</div></TD></TR>")
                tbBody.Append("<TR id='h18c{1}'><TD align='right'><div style='width:70px'>{222}</div></TD></TR>")
                'new line
                tbBody.Append("<TR id='h51c{1}'><TD align='right'><div style='width:70px'>{324}</div></TD></TR>")
                tbBody.Append("<TR id='h52c{1}'><TD align='right'><div style='width:70px'>{327}</div></TD></TR>")

                tbBody.Append("<TR style='font-weight:bold' id='h19c{1}'><TD align='right'><div style='width:70px'>{225}</div></TD></TR>")

                tbBody.Append("<TR id='h20c{1}'><TD align='right'><div style='width:70px'>{228}</div></TD></TR>")
                tbBody.Append("<TR id='h21c{1}'><TD align='right'><div style='width:70px'>{231}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h22c{1}'><TD align='right'><div style='width:70px'>{234}</div></TD></TR>")

                tbBody.Append("<TR id='h23c{1}'><TD align='right'><div style='width:70px'>{237}</div></TD></TR>")
                tbBody.Append("<TR id='h24c{1}'><TD align='right'><div style='width:70px'>{240}</div></TD></TR>")
                tbBody.Append("<TR id='h25c{1}'><TD align='right'><div style='width:70px'>{243}</div></TD></TR>")
                tbBody.Append("<TR id='h26c{1}'><TD align='right'><div style='width:70px'>{246}</div></TD></TR>")
                tbBody.Append("<TR id='h27c{1}'><TD align='right'><div style='width:70px'>{249}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h28c{1}'><TD align='right'><div style='width:70px'>{252}</div></TD></TR>")

                tbBody.Append("<TR id='h29c{1}'><TD align='right'><div style='width:70px'>{255}</div></TD></TR>")
                tbBody.Append("<TR id='h30c{1}'><TD align='right'><div style='width:70px'>{258}</div></TD></TR>")
                tbBody.Append("<TR id='h31c{1}'><TD align='right'><div style='width:70px'>{261}</div></TD></TR>")
                tbBody.Append("<TR id='h32c{1}'><TD align='right'><div style='width:70px'>{264}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h33c{1}'><TD align='right'><div style='width:70px'>{267}</div></TD></TR>")

                tbBody.Append("<TR id='h34c{1}'><TD align='right'><div style='width:70px'>{270}</div></TD></TR>")
                tbBody.Append("<TR id='h35c{1}'><TD align='right'><div style='width:70px'>{273}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h36c{1}'><TD align='right'><div style='width:70px'>{276}</div></TD></TR>")

                tbBody.Append("<TR id='h37c{1}'><TD align='right'><div style='width:70px'>{279}</div></TD></TR>")
                tbBody.Append("<TR id='h38c{1}'><TD align='right'><div style='width:70px'>{282}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h39c{1}'><TD align='right'><div style='width:70px'>{285}</div></TD></TR>")

                tbBody.Append("<TR id='h40c{1}'><TD align='right'><div style='width:70px'>{288}</div></TD></TR>")
                tbBody.Append("<TR id='h41c{1}'><TD align='right'><div style='width:70px'>{291}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h42c{1}'><TD align='right'><div style='width:70px'>{294}</div></TD></TR>")

                tbBody.Append("<TR id='h43c{1}'><TD align='right'><div style='width:70px'>{297}</div></TD></TR>")
                tbBody.Append("<TR id='h44c{1}'><TD align='right'><div style='width:70px'>{300}</div></TD></TR>")
                'new line
                tbBody.Append("<TR id='h53c{1}'><TD align='right'><div style='width:70px'>{330}</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h45c{1}'><TD align='right'><div style='width:70px'>{303}</div></TD></TR>")

                tbBody.Append("<TR id='h46c{1}'><TD align='right'><div style='width:70px'>{306}</div></TD></TR>")
                tbBody.Append("<TR id='h47c{1}'><TD align='right'><div style='width:70px'>{309}</div></TD></TR>")
                tbBody.Append("<TR id='h48c{1}'><TD align='right'><div style='width:70px'>{312}</div></TD></TR>")
                tbBody.Append("<TR id='h49c{1}'><TD align='right'><div style='width:70px'>{315}</div></TD></TR>")
                tbBody.Append("<TR id='h50c{1}'><TD align='right'><div style='width:70px'>{318}</div></TD></TR>")
                'tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:70px'>{321}</div></TD></TR>")

                tbBody.Append("<tr style='font-weight:bold;' class='rbg1'><td align='right'><div style='width:70px;padding-left:5px;' class='pptk'>{321}</div></td></tr>")
                Return tbBody.ToString
            Case 3
                Dim tbFoot As New StringBuilder
                'tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:70px'>{0}</div></TD></TR>")
                'tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:70px'>{1}</div></TD></TR>")
                tbFoot.Append("</TABLE>")
                Return tbFoot.ToString
            Case Else
                Return ""
        End Select
    End Function

#End Region

#Region "Full Performance"
    Public Shared Function htmlFullPfmTopic() As String
        Dim sb As New StringBuilder
        sb.Append("<table cellspacing='0' cellpadding='0' class='tbPFTopic'>")
        sb.Append("<tr style='font-weight:bold;' class='rbg0'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>{0}</div></td></tr>")

        sb.Append("<TR class='rbg1'><TD align='center'><div style='width:250px'>&nbsp;</div></TD></TR>")
        sb.Append("<TR style='font-weight:bold;height:30px' class='rbg1'><TD align='center' style='line-height:14.5px;'><div style='width:250px'>{1}</div></TD></TR>")

        'sb.Append("<tr class='rbg1'><td align='left'><div style='width:250px;'>&nbsp;</div></td></tr>")
        'sb.Append("<tr style='font-weight:bold;height:30px' class='rbg1'><td align='left'><div style='width:250px;'>&nbsp;{1}&nbsp;</div></td></tr>")
       
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Total Gross Space (SQM)</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Total Selling Space (SQM)</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>Productivity/SQM</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Revenue Growth-YOY</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Revenue Growth-LFL</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='kbg3'><td align='left'><div style='width:250px;padding-left:5px;'>&nbsp;</div></td></tr>")

        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Revenue <span id='spaa' class='ppk' onclick=""minitb('aa');"">+</span></div></td></tr>")
        sb.Append("<tr id='aa1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sale Revenue</div></td></tr>")
        sb.Append("<tr id='aa2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Revenue</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Cost of Good Sold</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Gross Retails Profit</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Margin Adjustments <span id='spb' class='ppk' onclick=""minitb('b');"">+</span></div></td></tr>")
        sb.Append("<tr id='b1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shipping</div></td></tr>")
        sb.Append("<tr id='b2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss and Obsolescence</div></td></tr>")
        sb.Append("<tr id='b3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - stock check (Actual)</div></td></tr>")
        sb.Append("<tr id='b4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - damaged and obsolete stock (Actual)</div></td></tr>")
        sb.Append("<tr id='b5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Loss  (Provision)</div></td></tr>")
        sb.Append("<tr id='b6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Stock Obsolescence (Provision)</div></td></tr>")
        sb.Append("<tr id='b7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWP</div></td></tr>")
        sb.Append("<tr id='b8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWPs - Corporate</div></td></tr>")
        sb.Append("<tr id='b9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GWPs - Transferred</div></td></tr>")
        sb.Append("<tr id='b10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Selling Costs</div></td></tr>")
        sb.Append("<tr id='b11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Credit cards commission</div></td></tr>")
        sb.Append("<tr id='b12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Labelling Material</div></td></tr>")
        sb.Append("<tr id='b13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Income - COSH Funding</div></td></tr>")
        sb.Append("<tr id='b14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Income Supplier</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Adjusted Gross Retails Profit</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg4'><td align='left' class='kbg2';'><div style='width:200px;padding-left:5px;' class='pptk'>Supply Chain Costs</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Total Store Expenses</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Store Labour Costs <span id='spe' class='ppk' onclick=""minitb('e');"">+</span></div></td></tr>")
        sb.Append("<tr id='e1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Gross Pay</div></td></tr>")
        sb.Append("<tr id='e2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Temporary Staff Costs</div></td></tr>")
        sb.Append("<tr id='e3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Allowance</div></td></tr>")
        sb.Append("<tr id='e4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Overtime</div></td></tr>")
        sb.Append("<tr id='e5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - License fee</div></td></tr>")
        sb.Append("<tr id='e6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Bonuses/Incentives</div></td></tr>")
        sb.Append("<tr id='e7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Boots Brand ncentives</div></td></tr>")
        sb.Append("<tr id='e8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Suppliers Incentive</div></td></tr>")
        sb.Append("<tr id='e9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Provident Fund</div></td></tr>")
        sb.Append("<tr id='e10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Pension Costs</div></td></tr>")
        sb.Append("<tr id='e11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Social Security Fund</div></td></tr>")
        sb.Append("<tr id='e12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Uniforms</div></td></tr>")
        sb.Append("<tr id='e13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Employee Welfare</div></td></tr>")
        sb.Append("<tr id='e14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Benefits Employee</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Store Property Costs <span id='spf' class='ppk' onclick=""minitb('f');"">+</span></div></td></tr>")
        sb.Append("<tr id='f1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Rental</div></td></tr>")
        sb.Append("<tr id='f2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Services</div></td></tr>")
        sb.Append("<tr id='f3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Facility</div></td></tr>")
        sb.Append("<tr id='f4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property taxes</div></td></tr>")
        sb.Append("<tr id='f5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Facial taxes</div></td></tr>")
        sb.Append("<tr id='f6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Property Insurance</div></td></tr>")
        sb.Append("<tr id='f7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Signboard</div></td></tr>")
        sb.Append("<tr id='f8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Discount - Rent/Services/Facility</div></td></tr>")
        sb.Append("<tr id='f9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - GP Commission</div></td></tr>")
        sb.Append("<tr id='f10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Amortization of Lease Right</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;' class='pptk'>Depreciation <span id='spg' class='ppk' onclick=""minitb('g');"">+</span></div></td></tr>")
        sb.Append("<tr id='g1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Short Lease Building</div></td></tr>")
        sb.Append("<tr id='g2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Computer Hardware</div></td></tr>")
        sb.Append("<tr id='g3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Fixtures & Fittings</div></td></tr>")
        sb.Append("<tr id='g4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Computer Software</div></td></tr>")
        sb.Append("<tr id='g5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Depreciation of Office Equipment</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' class='rbg3'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Other Store Costs <span id='sph' class='ppk' onclick=""minitb('h');"">+</span></div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h1'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Service Charges and Other Fees</div></td></tr>")

        sb.Append("<tr id='h2'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Bank Charges</div></td></tr>")
        sb.Append("<tr id='h3'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cash Collection Charge</div></td></tr>")
        sb.Append("<tr id='h4'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cleaning</div></td></tr>")
        sb.Append("<tr id='h5'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Security Guards</div></td></tr>")
        sb.Append("<tr id='h6'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Carriage</div></td></tr>")
        sb.Append("<tr id='h7'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Licence Fees</div></td></tr>")
        sb.Append("<tr id='h8'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Services Charge</div></td></tr>")
        sb.Append("<tr id='h9'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Fees</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h10'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Utilities</div></td></tr>")

        sb.Append("<tr id='h11'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Water</div></td></tr>")
        sb.Append("<tr id='h12'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Gas/Electric</div></td></tr>")
        sb.Append("<tr id='h13'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Air Cond. - Addition</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h14'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Repair and Maintenance</div></td></tr>")

        sb.Append("<tr id='h15'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Other - Fix</div></td></tr>")
        sb.Append("<tr id='h16'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Other - Unplan</div></td></tr>")
        sb.Append("<tr id='h17'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Computer - Fix</div></td></tr>")
        sb.Append("<tr id='h18'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - R&M Computer - Unplan</div></td></tr>")
        'new line
        sb.Append("<tr id='h51'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - SW Maintenance</div></td></tr>")
        sb.Append("<tr id='h52'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - HW Maintenance</div></td></tr>")

        sb.Append("<tr style='font-weight:bold' id='h19'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Professional Fee</div></td></tr>")

        sb.Append("<tr id='h20'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Marketing Research</div></td></tr>")
        sb.Append("<tr id='h21'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Fee</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h22'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Equipment, Materail and Supplies</div></td></tr>")

        sb.Append("<tr id='h23'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Printing and Stationery</div></td></tr>")
        sb.Append("<tr id='h24'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Supplies Expenses</div></td></tr>")
        sb.Append("<tr id='h25'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Equipment</div></td></tr>")
        sb.Append("<tr id='h26'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Shopfitting</div></td></tr>")
        sb.Append("<tr id='h27'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Packaging and Other Material</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h28'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Business Travel Expenses</div></td></tr>")

        sb.Append("<tr id='h29'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Car Parking and Others</div></td></tr>")
        sb.Append("<tr id='h30'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Travel</div></td></tr>")
        sb.Append("<tr id='h31'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Accomodation</div></td></tr>")
        sb.Append("<tr id='h32'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Meal and Entertainment</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h33'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Insurance</div></td></tr>")

        sb.Append("<tr id='h34'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - All Risk Insurance</div></td></tr>")
        sb.Append("<tr id='h35'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Health and Life Insurance</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h36'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Penalty and Taxation</div></td></tr>")

        sb.Append("<tr id='h37'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Taxation</div></td></tr>")
        sb.Append("<tr id='h38'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Penalty</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h39'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Related Staff Cost</div></td></tr>")

        sb.Append("<tr id='h40'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Staff Conference and Training</div></td></tr>")
        sb.Append("<tr id='h41'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Training</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h42'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Communication</div></td></tr>")

        sb.Append("<tr id='h43'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Telephone Calls/Faxes</div></td></tr>")
        sb.Append("<tr id='h44'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Postage and Courier</div></td></tr>")
        'new line
        sb.Append("<tr id='h53'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - IT Telecommunications</div></td></tr>")
        sb.Append("<tr style='font-weight:bold' id='h45'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Other Expenses</div></td></tr>")

        sb.Append("<tr id='h46'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Sample/Tester</div></td></tr>")
        sb.Append("<tr id='h47'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Preopening Costs</div></td></tr>")
        sb.Append("<tr id='h48'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Loss on Claim</div></td></tr>")
        sb.Append("<tr id='h49'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Cash Overtage/Shortage from sales</div></td></tr>")
        sb.Append("<tr id='h50'><td align='left' class='kbg2'><div style='width:200px;padding-left:5px;'> - Miscellenous and Other</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg1'><td align='left'><div style='width:200px;padding-left:5px;' class='pptk'>Store Trading Profit / (Loss)</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Store Trading Profit Growth-YOY</div></td></tr>")
        sb.Append("<tr style='font-weight:bold;' class='rbg2'><td align='left'><div style='width:250px;padding-left:5px;' class='pptk'>% Store Trading Profit Growth-LFL</div></td></tr>")
        sb.Append("</table>")

        Return sb.ToString
    End Function

    Public Shared Function htmlFullPfmItem(part As tablePart, Optional hasBorder As Boolean = False) As String

        Select Case part
            Case 1
                Dim tbHead As New StringBuilder

                'for border (ตีกรอบ)
                Dim tblClass As String = "tball2"
                If hasBorder Then
                    tblClass = "tbTotal"
                End If

                tbHead.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2'>")
                tbHead.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='2'><strong>{0}</strong></TD></TR>")

                Return tbHead.ToString
            Case 2
                Dim tbBody As New StringBuilder

                tbBody.Append("<TABLE cellspacing='0' cellpadding='0' class='tbPFItem1' width='100%' >")
                tbBody.Append("<TR class='rbg1'><TD align='center' colspan='2'><div style='width:150px'><strong><div>{0}</div></strong></div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;height:30px' class='rbg1'><TD align='center'><div style='width:90px'><strong><div>{2}</div></strong></div></TD><TD align='center'><div style='width:60px;'><strong>% Sale</strong></div></TD></TR>")

                'tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' ><strong>3</strong></TD><TD align='center'><div style='width:60px;'><strong></strong></div></TD></TR>")
                'tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'>4</TD><TD align='center' class='rbg2'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{333}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{334}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'>{335}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbBody.Append("<TR><TD></TD><TD>&nbsp;</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{336}</TD><TD>&nbsp;</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{337}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbBody.Append("<TR><TD></TD><TD>&nbsp;</TD></TR>")

                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{3}</TD><TD align='right'><div style='width:60px;'>{4}%</div></TD></TR>")
                tbBody.Append("<TR id='aa1c{1}'><TD align='right'>{6}</TD><TD align='right'><div style='width:60px;'>{7}%</div></TD></TR>")
                tbBody.Append("<TR id='aa2c{1}'><TD align='right'>{9}</TD><TD align='right'><div style='width:60px;'>{10}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'>{12}</TD><TD align='right'><div style='width:60px;'>{13}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{15}</TD><TD align='right'><div style='width:60px;'>{16}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'>{18}</TD><TD align='right'><div style='width:60px;'>{19}%</div></TD></TR>")
                tbBody.Append("<TR id='b1c{1}'><TD align='right'>{21}</TD><TD align='right'><div style='width:60px;'>{22}%</div></TD></TR>")
                tbBody.Append("<TR id='b2c{1}'><TD align='right'>{24}</TD><TD align='right'><div style='width:60px;'>{25}%</div></TD></TR>")
                tbBody.Append("<TR id='b3c{1}'><TD align='right'>{27}</TD><TD align='right'><div style='width:60px;'>{28}%</div></TD></TR>")
                tbBody.Append("<TR id='b4c{1}'><TD align='right'>{30}</TD><TD align='right'><div style='width:60px;'>{31}%</div></TD></TR>")
                tbBody.Append("<TR id='b5c{1}'><TD align='right'>{33}</TD><TD align='right'><div style='width:60px;'>{34}%</div></TD></TR>")
                tbBody.Append("<TR id='b6c{1}'><TD align='right'>{36}</TD><TD align='right'><div style='width:60px;'>{37}%</div></TD></TR>")
                tbBody.Append("<TR id='b7c{1}'><TD align='right'>{39}</TD><TD align='right'><div style='width:60px;'>{40}%</div></TD></TR>")
                tbBody.Append("<TR id='b8c{1}'><TD align='right'>{42}</TD><TD align='right'><div style='width:60px;'>{43}%</div></TD></TR>")
                tbBody.Append("<TR id='b9c{1}'><TD align='right'>{45}</TD><TD align='right'><div style='width:60px;'>{46}%</div></TD></TR>")
                tbBody.Append("<TR id='b10c{1}'><TD align='right'>{48}</TD><TD align='right'><div style='width:60px;'>{49}%</div></TD></TR>")
                tbBody.Append("<TR id='b11c{1}'><TD align='right'>{51}</TD><TD align='right'><div style='width:60px;'>{52}%</div></TD></TR>")
                tbBody.Append("<TR id='b12c{1}'><TD align='right'>{54}</TD><TD align='right'><div style='width:60px;'>{55}%</div></TD></TR>")
                tbBody.Append("<TR id='b13c{1}'><TD align='right'>{57}</TD><TD align='right'><div style='width:60px;'>{58}%</div></TD></TR>")
                tbBody.Append("<TR id='b14c{1}'><TD align='right'>{60}</TD><TD align='right'><div style='width:60px;'>{61}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{63}</TD><TD align='right'><div style='width:60px;'>{64}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg4'><TD align='right'>{66}</TD><TD align='right'><div style='width:60px;'>{67}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{69}</TD><TD align='right'><div style='width:60px;'>{70}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{72}</TD><TD align='right'><div style='width:60px;'>{73}%</div></TD></TR>")
                tbBody.Append("<TR id='e1c{1}'><TD align='right'>{75}</TD><TD align='right'><div style='width:60px;'>{76}%</div></TD></TR>")
                tbBody.Append("<TR id='e2c{1}'><TD align='right'>{78}</TD><TD align='right'><div style='width:60px;'>{79}%</div></TD></TR>")
                tbBody.Append("<TR id='e3c{1}'><TD align='right'>{81}</TD><TD align='right'><div style='width:60px;'>{82}%</div></TD></TR>")
                tbBody.Append("<TR id='e4c{1}'><TD align='right'>{84}</TD><TD align='right'><div style='width:60px;'>{85}%</div></TD></TR>")
                tbBody.Append("<TR id='e5c{1}'><TD align='right'>{87}</TD><TD align='right'><div style='width:60px;'>{88}%</div></TD></TR>")
                tbBody.Append("<TR id='e6c{1}'><TD align='right'>{90}</TD><TD align='right'><div style='width:60px;'>{91}%</div></TD></TR>")
                tbBody.Append("<TR id='e7c{1}'><TD align='right'>{93}</TD><TD align='right'><div style='width:60px;'>{94}%</div></TD></TR>")
                tbBody.Append("<TR id='e8c{1}'><TD align='right'>{96}</TD><TD align='right'><div style='width:60px;'>{97}%</div></TD></TR>")
                tbBody.Append("<TR id='e9c{1}'><TD align='right'>{99}</TD><TD align='right'><div style='width:60px;'>{100}%</div></TD></TR>")
                tbBody.Append("<TR id='e10c{1}'><TD align='right'>{102}</TD><TD align='right'><div style='width:60px;'>{103}%</div></TD></TR>")
                tbBody.Append("<TR id='e11c{1}'><TD align='right'>{105}</TD><TD align='right'><div style='width:60px;'>{106}%</div></TD></TR>")
                tbBody.Append("<TR id='e12c{1}'><TD align='right'>{108}</TD><TD align='right'><div style='width:60px;'>{109}%</div></TD></TR>")
                tbBody.Append("<TR id='e13c{1}'><TD align='right'>{111}</TD><TD align='right'><div style='width:60px;'>{112}%</div></TD></TR>")
                tbBody.Append("<TR id='e14c{1}'><TD align='right'>{114}</TD><TD align='right'><div style='width:60px;'>{115}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{117}</TD><TD align='right'><div style='width:60px;'>{118}%</div></TD></TR>")
                tbBody.Append("<TR id='f1c{1}'><TD align='right'>{120}</TD><TD align='right'><div style='width:60px;'>{121}%</div></TD></TR>")
                tbBody.Append("<TR id='f2c{1}'><TD align='right'>{123}</TD><TD align='right'><div style='width:60px;'>{124}%</div></TD></TR>")
                tbBody.Append("<TR id='f3c{1}'><TD align='right'>{126}</TD><TD align='right'><div style='width:60px;'>{127}%</div></TD></TR>")
                tbBody.Append("<TR id='f4c{1}'><TD align='right'>{129}</TD><TD align='right'><div style='width:60px;'>{130}%</div></TD></TR>")
                tbBody.Append("<TR id='f5c{1}'><TD align='right'>{132}</TD><TD align='right'><div style='width:60px;'>{133}%</div></TD></TR>")
                tbBody.Append("<TR id='f6c{1}'><TD align='right'>{135}</TD><TD align='right'><div style='width:60px;'>{136}%</div></TD></TR>")
                tbBody.Append("<TR id='f7c{1}'><TD align='right'>{138}</TD><TD align='right'><div style='width:60px;'>{139}%</div></TD></TR>")
                tbBody.Append("<TR id='f8c{1}'><TD align='right'>{141}</TD><TD align='right'><div style='width:60px;'>{142}%</div></TD></TR>")
                tbBody.Append("<TR id='f9c{1}'><TD align='right'>{144}</TD><TD align='right'><div style='width:60px;'>{145}%</div></TD></TR>")
                tbBody.Append("<TR id='f10c{1}'><TD align='right'>{147}</TD><TD align='right'><div style='width:60px;'>{148}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{150}</TD><TD align='right'><div style='width:60px;'>{151}%</div></TD></TR>")
                tbBody.Append("<TR id='g1c{1}'><TD align='right'>{153}</TD><TD align='right'><div style='width:60px;'>{154}%</div></TD></TR>")
                tbBody.Append("<TR id='g2c{1}'><TD align='right'>{156}</TD><TD align='right'><div style='width:60px;'>{157}%</div></TD></TR>")
                tbBody.Append("<TR id='g3c{1}'><TD align='right'>{159}</TD><TD align='right'><div style='width:60px;'>{160}%</div></TD></TR>")
                tbBody.Append("<TR id='g4c{1}'><TD align='right'>{162}</TD><TD align='right'><div style='width:60px;'>{163}%</div></TD></TR>")
                tbBody.Append("<TR id='g5c{1}'><TD align='right'>{165}</TD><TD align='right'><div style='width:60px;'>{166}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'>{168}</TD><TD align='right'><div style='width:60px;'>{169}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h1c{1}'><TD align='right'>{171}</TD><TD align='right'><div style='width:60px;'>{172}%</div></TD></TR>")

                tbBody.Append("<TR id='h2c{1}'><TD align='right'>{174}</TD><TD align='right'><div style='width:60px;'>{175}%</div></TD></TR>")
                tbBody.Append("<TR id='h3c{1}'><TD align='right'>{177}</TD><TD align='right'><div style='width:60px;'>{178}%</div></TD></TR>")
                tbBody.Append("<TR id='h4c{1}'><TD align='right'>{180}</TD><TD align='right'><div style='width:60px;'>{181}%</div></TD></TR>")
                tbBody.Append("<TR id='h5c{1}'><TD align='right'>{183}</TD><TD align='right'><div style='width:60px;'>{184}%</div></TD></TR>")
                tbBody.Append("<TR id='h6c{1}'><TD align='right'>{186}</TD><TD align='right'><div style='width:60px;'>{187}%</div></TD></TR>")
                tbBody.Append("<TR id='h7c{1}'><TD align='right'>{189}</TD><TD align='right'><div style='width:60px;'>{190}%</div></TD></TR>")
                tbBody.Append("<TR id='h8c{1}'><TD align='right'>{192}</TD><TD align='right'><div style='width:60px;'>{193}%</div></TD></TR>")
                tbBody.Append("<TR id='h9c{1}'><TD align='right'>{195}</TD><TD align='right'><div style='width:60px;'>{196}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h10c{1}'><TD align='right'>{198}</TD><TD align='right'><div style='width:60px;'>{199}%</div></TD></TR>")

                tbBody.Append("<TR id='h11c{1}'><TD align='right'>{201}</TD><TD align='right'><div style='width:60px;'>{202}%</div></TD></TR>")
                tbBody.Append("<TR id='h12c{1}'><TD align='right'>{204}</TD><TD align='right'><div style='width:60px;'>{205}%</div></TD></TR>")
                tbBody.Append("<TR id='h13c{1}'><TD align='right'>{207}</TD><TD align='right'><div style='width:60px;'>{208}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h14c{1}'><TD align='right'>{210}</TD><TD align='right'><div style='width:60px;'>{211}%</div></TD></TR>")

                tbBody.Append("<TR id='h15c{1}'><TD align='right'>{213}</TD><TD align='right'><div style='width:60px;'>{214}%</div></TD></TR>")
                tbBody.Append("<TR id='h16c{1}'><TD align='right'>{216}</TD><TD align='right'><div style='width:60px;'>{217}%</div></TD></TR>")
                tbBody.Append("<TR id='h17c{1}'><TD align='right'>{219}</TD><TD align='right'><div style='width:60px;'>{220}%</div></TD></TR>")
                tbBody.Append("<TR id='h18c{1}'><TD align='right'>{222}</TD><TD align='right'><div style='width:60px;'>{223}%</div></TD></TR>")
                'new line
                tbBody.Append("<TR id='h51c{1}'><TD align='right'>{324}</TD><TD align='right'><div style='width:60px;'>{325}%</div></TD></TR>")
                tbBody.Append("<TR id='h52c{1}'><TD align='right'>{327}</TD><TD align='right'><div style='width:60px;'>{328}%</div></TD></TR>")

                tbBody.Append("<TR style='font-weight:bold' id='h19c{1}'><TD align='right'>{225}</TD><TD align='right'><div style='width:60px;'>{226}%</div></TD></TR>")

                tbBody.Append("<TR id='h20c{1}'><TD align='right'>{228}</TD><TD align='right'><div style='width:60px;'>{229}%</div></TD></TR>")
                tbBody.Append("<TR id='h21c{1}'><TD align='right'>{231}</TD><TD align='right'><div style='width:60px;'>{232}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h22c{1}'><TD align='right'>{234}</TD><TD align='right'><div style='width:60px;'>{235}%</div></TD></TR>")

                tbBody.Append("<TR id='h23c{1}'><TD align='right'>{237}</TD><TD align='right'><div style='width:60px;'>{238}%</div></TD></TR>")
                tbBody.Append("<TR id='h24c{1}'><TD align='right'>{240}</TD><TD align='right'><div style='width:60px;'>{241}%</div></TD></TR>")
                tbBody.Append("<TR id='h25c{1}'><TD align='right'>{243}</TD><TD align='right'><div style='width:60px;'>{244}%</div></TD></TR>")
                tbBody.Append("<TR id='h26c{1}'><TD align='right'>{246}</TD><TD align='right'><div style='width:60px;'>{247}%</div></TD></TR>")
                tbBody.Append("<TR id='h27c{1}'><TD align='right'>{249}</TD><TD align='right'><div style='width:60px;'>{250}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h28c{1}'><TD align='right'>{252}</TD><TD align='right'><div style='width:60px;'>{253}%</div></TD></TR>")

                tbBody.Append("<TR id='h29c{1}'><TD align='right'>{255}</TD><TD align='right'><div style='width:60px;'>{256}%</div></TD></TR>")
                tbBody.Append("<TR id='h30c{1}'><TD align='right'>{258}</TD><TD align='right'><div style='width:60px;'>{259}%</div></TD></TR>")
                tbBody.Append("<TR id='h31c{1}'><TD align='right'>{261}</TD><TD align='right'><div style='width:60px;'>{262}%</div></TD></TR>")
                tbBody.Append("<TR id='h32c{1}'><TD align='right'>{264}</TD><TD align='right'><div style='width:60px;'>{265}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h33c{1}'><TD align='right'>{267}</TD><TD align='right'><div style='width:60px;'>{268}%</div></TD></TR>")

                tbBody.Append("<TR id='h34c{1}'><TD align='right'>{270}</TD><TD align='right'><div style='width:60px;'>{271}%</div></TD></TR>")
                tbBody.Append("<TR id='h35c{1}'><TD align='right'>{273}</TD><TD align='right'><div style='width:60px;'>{274}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h36c{1}'><TD align='right'>{276}</TD><TD align='right'><div style='width:60px;'>{277}%</div></TD></TR>")

                tbBody.Append("<TR id='h37c{1}'><TD align='right'>{279}</TD><TD align='right'><div style='width:60px;'>{280}%</div></TD></TR>")
                tbBody.Append("<TR id='h38c{1}'><TD align='right'>{282}</TD><TD align='right'><div style='width:60px;'>{283}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h39c{1}'><TD align='right'>{285}</TD><TD align='right'><div style='width:60px;'>{286}%</div></TD></TR>")

                tbBody.Append("<TR id='h40c{1}'><TD align='right'>{288}</TD><TD align='right'><div style='width:60px;'>{289}%</div></TD></TR>")
                tbBody.Append("<TR id='h41c{1}'><TD align='right'>{291}</TD><TD align='right'><div style='width:60px;'>{292}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h42c{1}'><TD align='right'>{294}</TD><TD align='right'><div style='width:60px;'>{295}%</div></TD></TR>")

                tbBody.Append("<TR id='h43c{1}'><TD align='right'>{297}</TD><TD align='right'><div style='width:60px;'>{298}%</div></TD></TR>")
                tbBody.Append("<TR id='h44c{1}'><TD align='right'>{300}</TD><TD align='right'><div style='width:60px;'>{301}%</div></TD></TR>")
                'new line
                tbBody.Append("<TR id='h53c{1}'><TD align='right'>{330}</TD><TD align='right'><div style='width:60px;'>{331}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h45c{1}'><TD align='right'>{303}</TD><TD align='right'><div style='width:60px;'>{304}%</div></TD></TR>")

                tbBody.Append("<TR id='h46c{1}'><TD align='right'>{306}</TD><TD align='right'><div style='width:60px;'>{307}%</div></TD></TR>")
                tbBody.Append("<TR id='h47c{1}'><TD align='right'>{309}</TD><TD align='right'><div style='width:60px;'>{310}%</div></TD></TR>")
                tbBody.Append("<TR id='h48c{1}'><TD align='right'>{312}</TD><TD align='right'><div style='width:60px;'>{313}%</div></TD></TR>")
                tbBody.Append("<TR id='h49c{1}'><TD align='right'>{315}</TD><TD align='right'><div style='width:60px;'>{316}%</div></TD></TR>")
                tbBody.Append("<TR id='h50c{1}'><TD align='right'>{318}</TD><TD align='right'><div style='width:60px;'>{319}%</div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'>{321}</TD><TD align='right'><div style='width:60px;'>{322}%</div></TD></TR>")

                Return tbBody.ToString
            Case 3
                Dim tbFoot As New StringBuilder
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{0}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'>{1}</TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD></TR>")
                tbFoot.Append("</TABLE>")

                Return tbFoot.ToString
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function htmlFullPfmTotal(part As tablePart, Optional showYoy As Boolean = True) As String

        Dim clsYoy As String = " class='tdyoy1' "
        If Not showYoy Then clsYoy = " class='tdyoy2' "

        Select Case part
            Case 1
                Dim tbHead As New StringBuilder
                tbHead.Append("")

                Return tbHead.ToString
            Case 2
                Dim tbBody As New StringBuilder
                tbBody.Append("<TABLE cellspacing='0' cellpadding='0' class='tbPFTotal1' width='100%' >")
                'tbBody.Append("<TABLE cellspacing='0' cellpadding='0' class='tball2' >")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='center' colspan='3'><strong>{333}</strong></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;height:30px;' class='rbg1'><TD align='center'><div style='width:90px'><strong>{334}</strong></div></TD><TD align='center'><div style='width:60px;'><strong>% Sale</strong></div></TD> <TD align='center'" + clsYoy + "><div style='width:60px;text-align:center'><strong>% YOY</strong></div></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:90px'><strong>{335}</strong></div></TD><TD align='center'><div style='width:60px;'><strong></strong></div></TD><TD" + clsYoy + "></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center' class='rbg2'><div style='width:90px;'>{336}</div></TD><TD align='center' class='rbg2'><div style='width:60px;'>&nbsp;</div></TD><TD" + clsYoy + "></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='center'><div style='width:90px'>{337}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD" + clsYoy + "></TD></TR>")

                tbBody.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:90px'></div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD" + clsYoy + "></TD></TR>")

                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{338}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD" + clsYoy + "></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{339}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD" + clsYoy + "></TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='center'><div style='width:90px'></div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD" + clsYoy + "></TD></TR>")

                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{3}</div></TD><TD align='right'><div style='width:60px;'>{4}%</div></TD><TD" + clsYoy + ">{5}</TD></TR>")
                tbBody.Append("<TR id='aa1c{1}'><TD align='right'><div style='width:90px'>{6}</div></TD><TD align='right'><div style='width:60px;'>{7}%</div></TD><TD" + clsYoy + ">{8}</TD></TR>")
                tbBody.Append("<TR id='aa2c{1}'><TD align='right'><div style='width:90px'>{9}</div></TD><TD align='right'><div style='width:60px;'>{10}%</div></TD><TD " + clsYoy + ">{11}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:90px'>{12}</div></TD><TD align='right'><div style='width:60px;'>{13}%</div></TD><TD " + clsYoy + ">{14}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{15}</div></TD><TD align='right'><div style='width:60px;'>{16}%</div></TD><TD " + clsYoy + ">{17}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;'><TD align='right'><div style='width:90px'>{18}</div></TD><TD align='right'><div style='width:60px;'>{19}%</div></TD><TD " + clsYoy + ">{20}</TD></TR>")
                tbBody.Append("<TR id='b1c{1}'><TD align='right'><div style='width:90px'>{21}</div></TD><TD align='right'><div style='width:60px;'>{22}%</div></TD><TD " + clsYoy + ">{23}</TD></TR>")
                tbBody.Append("<TR id='b2c{1}'><TD align='right'><div style='width:90px'>{24}</div></TD><TD align='right'><div style='width:60px;'>{25}%</div></TD><TD " + clsYoy + ">{26}</TD></TR>")
                tbBody.Append("<TR id='b3c{1}'><TD align='right'><div style='width:90px'>{27}</div></TD><TD align='right'><div style='width:60px;'>{28}%</div></TD><TD " + clsYoy + ">{29}</TD></TR>")
                tbBody.Append("<TR id='b4c{1}'><TD align='right'><div style='width:90px'>{30}</div></TD><TD align='right'><div style='width:60px;'>{31}%</div></TD><TD " + clsYoy + ">{32}</TD></TR>")
                tbBody.Append("<TR id='b5c{1}'><TD align='right'><div style='width:90px'>{33}</div></TD><TD align='right'><div style='width:60px;'>{34}%</div></TD><TD " + clsYoy + ">{35}</TD></TR>")
                tbBody.Append("<TR id='b6c{1}'><TD align='right'><div style='width:90px'>{36}</div></TD><TD align='right'><div style='width:60px;'>{37}%</div></TD><TD " + clsYoy + ">{38}</TD></TR>")
                tbBody.Append("<TR id='b7c{1}'><TD align='right'><div style='width:90px'>{39}</div></TD><TD align='right'><div style='width:60px;'>{40}%</div></TD><TD " + clsYoy + ">{41}</TD></TR>")
                tbBody.Append("<TR id='b8c{1}'><TD align='right'><div style='width:90px'>{42}</div></TD><TD align='right'><div style='width:60px;'>{43}%</div></TD><TD " + clsYoy + ">{44}</TD></TR>")
                tbBody.Append("<TR id='b9c{1}'><TD align='right'><div style='width:90px'>{45}</div></TD><TD align='right'><div style='width:60px;'>{46}%</div></TD><TD " + clsYoy + ">{47}</TD></TR>")
                tbBody.Append("<TR id='b10c{1}'><TD align='right'><div style='width:90px'>{48}</div></TD><TD align='right'><div style='width:60px;'>{49}%</div></TD><TD " + clsYoy + ">{50}</TD></TR>")
                tbBody.Append("<TR id='b11c{1}'><TD align='right'><div style='width:90px'>{51}</div></TD><TD align='right'><div style='width:60px;'>{52}%</div></TD><TD " + clsYoy + ">{53}</TD></TR>")
                tbBody.Append("<TR id='b12c{1}'><TD align='right'><div style='width:90px'>{54}</div></TD><TD align='right'><div style='width:60px;'>{55}%</div></TD><TD " + clsYoy + ">{56}</TD></TR>")
                tbBody.Append("<TR id='b13c{1}'><TD align='right'><div style='width:90px'>{57}</div></TD><TD align='right'><div style='width:60px;'>{58}%</div></TD><TD " + clsYoy + ">{59}</TD></TR>")
                tbBody.Append("<TR id='b14c{1}'><TD align='right'><div style='width:90px'>{60}</div></TD><TD align='right'><div style='width:60px;'>{61}%</div></TD><TD " + clsYoy + ">{62}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{63}</div></TD><TD align='right'><div style='width:60px;'>{64}%</div></TD><TD " + clsYoy + ">{65}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg4'><TD align='right'><div style='width:90px'>{66}</div></TD><TD align='right'><div style='width:60px;'>{67}%</div></TD><TD " + clsYoy + ">{68}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{69}</div></TD><TD align='right'><div style='width:60px;'>{70}%</div></TD><TD " + clsYoy + ">{71}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{72}</div></TD><TD align='right'><div style='width:60px;'>{73}%</div></TD><TD " + clsYoy + ">{74}</TD></TR>")
                tbBody.Append("<TR id='e1c{1}'><TD align='right'><div style='width:90px'>{75}</div></TD><TD align='right'><div style='width:60px;'>{76}%</div></TD><TD " + clsYoy + ">{77}</TD></TR>")
                tbBody.Append("<TR id='e2c{1}'><TD align='right'><div style='width:90px'>{78}</div></TD><TD align='right'><div style='width:60px;'>{79}%</div></TD><TD " + clsYoy + ">{80}</TD></TR>")
                tbBody.Append("<TR id='e3c{1}'><TD align='right'><div style='width:90px'>{81}</div></TD><TD align='right'><div style='width:60px;'>{82}%</div></TD><TD " + clsYoy + ">{83}</TD></TR>")
                tbBody.Append("<TR id='e4c{1}'><TD align='right'><div style='width:90px'>{84}</div></TD><TD align='right'><div style='width:60px;'>{85}%</div></TD><TD " + clsYoy + ">{86}</TD></TR>")
                tbBody.Append("<TR id='e5c{1}'><TD align='right'><div style='width:90px'>{87}</div></TD><TD align='right'><div style='width:60px;'>{88}%</div></TD><TD " + clsYoy + ">{89}</TD></TR>")
                tbBody.Append("<TR id='e6c{1}'><TD align='right'><div style='width:90px'>{90}</div></TD><TD align='right'><div style='width:60px;'>{91}%</div></TD><TD " + clsYoy + ">{92}</TD></TR>")
                tbBody.Append("<TR id='e7c{1}'><TD align='right'><div style='width:90px'>{93}</div></TD><TD align='right'><div style='width:60px;'>{94}%</div></TD><TD " + clsYoy + ">{95}</TD></TR>")
                tbBody.Append("<TR id='e8c{1}'><TD align='right'><div style='width:90px'>{96}</div></TD><TD align='right'><div style='width:60px;'>{97}%</div></TD><TD " + clsYoy + ">{98}</TD></TR>")
                tbBody.Append("<TR id='e9c{1}'><TD align='right'><div style='width:90px'>{99}</div></TD><TD align='right'><div style='width:60px;'>{100}%</div></TD><TD " + clsYoy + ">{101}</TD></TR>")
                tbBody.Append("<TR id='e10c{1}'><TD align='right'><div style='width:90px'>{102}</div></TD><TD align='right'><div style='width:60px;'>{103}%</div></TD><TD " + clsYoy + ">{104}</TD></TR>")
                tbBody.Append("<TR id='e11c{1}'><TD align='right'><div style='width:90px'>{105}</div></TD><TD align='right'><div style='width:60px;'>{106}%</div></TD><TD " + clsYoy + ">{107}</TD></TR>")
                tbBody.Append("<TR id='e12c{1}'><TD align='right'><div style='width:90px'>{108}</div></TD><TD align='right'><div style='width:60px;'>{109}%</div></TD><TD " + clsYoy + ">{110}</TD></TR>")
                tbBody.Append("<TR id='e13c{1}'><TD align='right'><div style='width:90px'>{111}</div></TD><TD align='right'><div style='width:60px;'>{112}%</div></TD><TD " + clsYoy + ">{113}</TD></TR>")
                tbBody.Append("<TR id='e14c{1}'><TD align='right'><div style='width:90px'>{114}</div></TD><TD align='right'><div style='width:60px;'>{115}%</div></TD><TD " + clsYoy + ">{116}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{117}</div></TD><TD align='right'><div style='width:60px;'>{118}%</div></TD><TD " + clsYoy + ">{119}</TD></TR>")
                tbBody.Append("<TR id='f1c{1}'><TD align='right'><div style='width:90px'>{120}</div></TD><TD align='right'><div style='width:60px;'>{121}%</div></TD><TD " + clsYoy + ">{122}</TD></TR>")
                tbBody.Append("<TR id='f2c{1}'><TD align='right'><div style='width:90px'>{123}</div></TD><TD align='right'><div style='width:60px;'>{124}%</div></TD><TD " + clsYoy + ">{125}</TD></TR>")
                tbBody.Append("<TR id='f3c{1}'><TD align='right'><div style='width:90px'>{126}</div></TD><TD align='right'><div style='width:60px;'>{127}%</div></TD><TD " + clsYoy + ">{128}</TD></TR>")
                tbBody.Append("<TR id='f4c{1}'><TD align='right'><div style='width:90px'>{129}</div></TD><TD align='right'><div style='width:60px;'>{130}%</div></TD><TD " + clsYoy + ">{131}</TD></TR>")
                tbBody.Append("<TR id='f5c{1}'><TD align='right'><div style='width:90px'>{132}</div></TD><TD align='right'><div style='width:60px;'>{133}%</div></TD><TD " + clsYoy + ">{134}</TD></TR>")
                tbBody.Append("<TR id='f6c{1}'><TD align='right'><div style='width:90px'>{135}</div></TD><TD align='right'><div style='width:60px;'>{136}%</div></TD><TD " + clsYoy + ">{137}</TD></TR>")
                tbBody.Append("<TR id='f7c{1}'><TD align='right'><div style='width:90px'>{138}</div></TD><TD align='right'><div style='width:60px;'>{139}%</div></TD><TD " + clsYoy + ">{140}</TD></TR>")
                tbBody.Append("<TR id='f8c{1}'><TD align='right'><div style='width:90px'>{141}</div></TD><TD align='right'><div style='width:60px;'>{142}%</div></TD><TD " + clsYoy + ">{143}</TD></TR>")
                tbBody.Append("<TR id='f9c{1}'><TD align='right'><div style='width:90px'>{144}</div></TD><TD align='right'><div style='width:60px;'>{145}%</div></TD><TD " + clsYoy + ">{146}</TD></TR>")
                tbBody.Append("<TR id='f10c{1}'><TD align='right'><div style='width:90px'>{147}</div></TD><TD align='right'><div style='width:60px;'>{148}%</div></TD><TD " + clsYoy + ">{149}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{150}</div></TD><TD align='right'><div style='width:60px;'>{151}%</div></TD><TD " + clsYoy + ">{152}</TD></TR>")
                tbBody.Append("<TR id='g1c{1}'><TD align='right'><div style='width:90px'>{153}</div></TD><TD align='right'><div style='width:60px;'>{154}%</div></TD><TD " + clsYoy + ">{155}</TD></TR>")
                tbBody.Append("<TR id='g2c{1}'><TD align='right'><div style='width:90px'>{156}</div></TD><TD align='right'><div style='width:60px;'>{157}%</div></TD><TD " + clsYoy + ">{158}</TD></TR>")
                tbBody.Append("<TR id='g3c{1}'><TD align='right'><div style='width:90px'>{159}</div></TD><TD align='right'><div style='width:60px;'>{160}%</div></TD><TD " + clsYoy + ">{161}</TD></TR>")
                tbBody.Append("<TR id='g4c{1}'><TD align='right'><div style='width:90px'>{162}</div></TD><TD align='right'><div style='width:60px;'>{163}%</div></TD><TD " + clsYoy + ">{164}</TD></TR>")
                tbBody.Append("<TR id='g5c{1}'><TD align='right'><div style='width:90px'>{165}</div></TD><TD align='right'><div style='width:60px;'>{166}%</div></TD><TD " + clsYoy + ">{167}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg3'><TD align='right'><div style='width:90px'>{168}</div></TD><TD align='right'><div style='width:60px;'>{169}%</div></TD><TD " + clsYoy + ">{170}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h1c{1}'><TD align='right'><div style='width:90px'>{171}</div></TD><TD align='right'><div style='width:60px;'>{172}%</div></TD><TD " + clsYoy + ">{173}</TD></TR>")

                tbBody.Append("<TR id='h2c{1}'><TD align='right'><div style='width:90px'>{174}</div></TD><TD align='right'><div style='width:60px;'>{175}%</div></TD><TD " + clsYoy + ">{176}</TD></TR>")
                tbBody.Append("<TR id='h3c{1}'><TD align='right'><div style='width:90px'>{177}</div></TD><TD align='right'><div style='width:60px;'>{178}%</div></TD><TD " + clsYoy + ">{179}</TD></TR>")
                tbBody.Append("<TR id='h4c{1}'><TD align='right'><div style='width:90px'>{180}</div></TD><TD align='right'><div style='width:60px;'>{181}%</div></TD><TD " + clsYoy + ">{182}</TD></TR>")
                tbBody.Append("<TR id='h5c{1}'><TD align='right'><div style='width:90px'>{183}</div></TD><TD align='right'><div style='width:60px;'>{184}%</div></TD><TD " + clsYoy + ">{185}</TD></TR>")
                tbBody.Append("<TR id='h6c{1}'><TD align='right'><div style='width:90px'>{186}</div></TD><TD align='right'><div style='width:60px;'>{187}%</div></TD><TD " + clsYoy + ">{188}</TD></TR>")
                tbBody.Append("<TR id='h7c{1}'><TD align='right'><div style='width:90px'>{189}</div></TD><TD align='right'><div style='width:60px;'>{190}%</div></TD><TD " + clsYoy + ">{191}</TD></TR>")
                tbBody.Append("<TR id='h8c{1}'><TD align='right'><div style='width:90px'>{192}</div></TD><TD align='right'><div style='width:60px;'>{193}%</div></TD><TD " + clsYoy + ">{194}</TD></TR>")
                tbBody.Append("<TR id='h9c{1}'><TD align='right'><div style='width:90px'>{195}</div></TD><TD align='right'><div style='width:60px;'>{196}%</div></TD><TD " + clsYoy + ">{197}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h10c{1}'><TD align='right'><div style='width:90px'>{198}</div></TD><TD align='right'><div style='width:60px;'>{199}%</div></TD><TD " + clsYoy + ">{200}</TD></TR>")

                tbBody.Append("<TR id='h11c{1}'><TD align='right'><div style='width:90px'>{201}</div></TD><TD align='right'><div style='width:60px;'>{202}%</div></TD><TD " + clsYoy + ">{203}</TD></TR>")
                tbBody.Append("<TR id='h12c{1}'><TD align='right'><div style='width:90px'>{204}</div></TD><TD align='right'><div style='width:60px;'>{205}%</div></TD><TD " + clsYoy + ">{206}</TD></TR>")
                tbBody.Append("<TR id='h13c{1}'><TD align='right'><div style='width:90px'>{207}</div></TD><TD align='right'><div style='width:60px;'>{208}%</div></TD><TD " + clsYoy + ">{209}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h14c{1}'><TD align='right'><div style='width:90px'>{210}</div></TD><TD align='right'><div style='width:60px;'>{211}%</div></TD><TD " + clsYoy + ">{212}</TD></TR>")

                tbBody.Append("<TR id='h15c{1}'><TD align='right'><div style='width:90px'>{213}</div></TD><TD align='right'><div style='width:60px;'>{214}%</div></TD><TD " + clsYoy + ">{215}</TD></TR>")
                tbBody.Append("<TR id='h16c{1}'><TD align='right'><div style='width:90px'>{216}</div></TD><TD align='right'><div style='width:60px;'>{217}%</div></TD><TD " + clsYoy + ">{218}</TD></TR>")
                tbBody.Append("<TR id='h17c{1}'><TD align='right'><div style='width:90px'>{219}</div></TD><TD align='right'><div style='width:60px;'>{220}%</div></TD><TD " + clsYoy + ">{221}</TD></TR>")
                tbBody.Append("<TR id='h18c{1}'><TD align='right'><div style='width:90px'>{222}</div></TD><TD align='right'><div style='width:60px;'>{223}%</div></TD><TD " + clsYoy + ">{224}</TD></TR>")
                'new line
                tbBody.Append("<TR id='h51c{1}'><TD align='right'><div style='width:90px'>{324}</div></TD><TD align='right'><div style='width:60px;'>{325}%</div></TD><TD " + clsYoy + ">{326}</TD></TR>")
                tbBody.Append("<TR id='h52c{1}'><TD align='right'><div style='width:90px'>{327}</div></TD><TD align='right'><div style='width:60px;'>{328}%</div></TD><TD " + clsYoy + ">{329}</TD></TR>")

                tbBody.Append("<TR style='font-weight:bold' id='h19c{1}'><TD align='right'><div style='width:90px'>{225}</div></TD><TD align='right'><div style='width:60px;'>{226}%</div></TD><TD " + clsYoy + ">{227}</TD></TR>")

                tbBody.Append("<TR id='h20c{1}'><TD align='right'><div style='width:90px'>{228}</div></TD><TD align='right'><div style='width:60px;'>{229}%</div></TD><TD " + clsYoy + ">{230}</TD></TR>")
                tbBody.Append("<TR id='h21c{1}'><TD align='right'><div style='width:90px'>{231}</div></TD><TD align='right'><div style='width:60px;'>{232}%</div></TD><TD " + clsYoy + ">{233}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h22c{1}'><TD align='right'><div style='width:90px'>{234}</div></TD><TD align='right'><div style='width:60px;'>{235}%</div></TD><TD " + clsYoy + ">{236}</TD></TR>")

                tbBody.Append("<TR id='h23c{1}'><TD align='right'><div style='width:90px'>{237}</div></TD><TD align='right'><div style='width:60px;'>{238}%</div></TD><TD " + clsYoy + ">{239}</TD></TR>")
                tbBody.Append("<TR id='h24c{1}'><TD align='right'><div style='width:90px'>{240}</div></TD><TD align='right'><div style='width:60px;'>{241}%</div></TD><TD " + clsYoy + ">{242}</TD></TR>")
                tbBody.Append("<TR id='h25c{1}'><TD align='right'><div style='width:90px'>{243}</div></TD><TD align='right'><div style='width:60px;'>{244}%</div></TD><TD " + clsYoy + ">{245}</TD></TR>")
                tbBody.Append("<TR id='h26c{1}'><TD align='right'><div style='width:90px'>{246}</div></TD><TD align='right'><div style='width:60px;'>{247}%</div></TD><TD " + clsYoy + ">{248}</TD></TR>")
                tbBody.Append("<TR id='h27c{1}'><TD align='right'><div style='width:90px'>{249}</div></TD><TD align='right'><div style='width:60px;'>{250}%</div></TD><TD " + clsYoy + ">{251}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h28c{1}'><TD align='right'><div style='width:90px'>{252}</div></TD><TD align='right'><div style='width:60px;'>{253}%</div></TD><TD " + clsYoy + ">{254}</TD></TR>")

                tbBody.Append("<TR id='h29c{1}'><TD align='right'><div style='width:90px'>{255}</div></TD><TD align='right'><div style='width:60px;'>{256}%</div></TD><TD " + clsYoy + ">{257}</TD></TR>")
                tbBody.Append("<TR id='h30c{1}'><TD align='right'><div style='width:90px'>{258}</div></TD><TD align='right'><div style='width:60px;'>{259}%</div></TD><TD " + clsYoy + ">{260}</TD></TR>")
                tbBody.Append("<TR id='h31c{1}'><TD align='right'><div style='width:90px'>{261}</div></TD><TD align='right'><div style='width:60px;'>{262}%</div></TD><TD " + clsYoy + ">{263}</TD></TR>")
                tbBody.Append("<TR id='h32c{1}'><TD align='right'><div style='width:90px'>{264}</div></TD><TD align='right'><div style='width:60px;'>{265}%</div></TD><TD " + clsYoy + ">{266}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h33c{1}'><TD align='right'><div style='width:90px'>{267}</div></TD><TD align='right'><div style='width:60px;'>{268}%</div></TD><TD " + clsYoy + ">{269}</TD></TR>")

                tbBody.Append("<TR id='h34c{1}'><TD align='right'><div style='width:90px'>{270}</div></TD><TD align='right'><div style='width:60px;'>{271}%</div></TD><TD " + clsYoy + ">{272}</TD></TR>")
                tbBody.Append("<TR id='h35c{1}'><TD align='right'><div style='width:90px'>{273}</div></TD><TD align='right'><div style='width:60px;'>{274}%</div></TD><TD " + clsYoy + ">{275}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h36c{1}'><TD align='right'><div style='width:90px'>{276}</div></TD><TD align='right'><div style='width:60px;'>{277}%</div></TD><TD " + clsYoy + ">{278}</TD></TR>")

                tbBody.Append("<TR id='h37c{1}'><TD align='right'><div style='width:90px'>{279}</div></TD><TD align='right'><div style='width:60px;'>{280}%</div></TD><TD " + clsYoy + ">{281}</TD></TR>")
                tbBody.Append("<TR id='h38c{1}'><TD align='right'><div style='width:90px'>{282}</div></TD><TD align='right'><div style='width:60px;'>{283}%</div></TD><TD " + clsYoy + ">{284}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h39c{1}'><TD align='right'><div style='width:90px'>{285}</div></TD><TD align='right'><div style='width:60px;'>{286}%</div></TD><TD " + clsYoy + ">{287}</TD></TR>")

                tbBody.Append("<TR id='h40c{1}'><TD align='right'><div style='width:90px'>{288}</div></TD><TD align='right'><div style='width:60px;'>{289}%</div></TD><TD " + clsYoy + ">{290}</TD></TR>")
                tbBody.Append("<TR id='h41c{1}'><TD align='right'><div style='width:90px'>{291}</div></TD><TD align='right'><div style='width:60px;'>{292}%</div></TD><TD " + clsYoy + ">{293}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h42c{1}'><TD align='right'><div style='width:90px'>{294}</div></TD><TD align='right'><div style='width:60px;'>{295}%</div></TD><TD " + clsYoy + ">{296}</TD></TR>")

                tbBody.Append("<TR id='h43c{1}'><TD align='right'><div style='width:90px'>{297}</div></TD><TD align='right'><div style='width:60px;'>{298}%</div></TD><TD " + clsYoy + ">{299}</TD></TR>")
                tbBody.Append("<TR id='h44c{1}'><TD align='right'><div style='width:90px'>{300}</div></TD><TD align='right'><div style='width:60px;'>{301}%</div></TD><TD " + clsYoy + ">{302}</TD></TR>")
                'new line
                tbBody.Append("<TR id='h53c{1}'><TD align='right'><div style='width:90px'>{330}</div></TD><TD align='right'><div style='width:60px;'>{331}%</div></TD><TD " + clsYoy + ">{332}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold' id='h45c{1}'><TD align='right'><div style='width:90px'>{303}</div></TD><TD align='right'><div style='width:60px;'>{304}%</div></TD><TD " + clsYoy + ">{305}</TD></TR>")

                tbBody.Append("<TR id='h46c{1}'><TD align='right'><div style='width:90px'>{306}</div></TD><TD align='right'><div style='width:60px;'>{307}%</div></TD><TD " + clsYoy + ">{308}</TD></TR>")
                tbBody.Append("<TR id='h47c{1}'><TD align='right'><div style='width:90px'>{309}</div></TD><TD align='right'><div style='width:60px;'>{310}%</div></TD><TD " + clsYoy + ">{311}</TD></TR>")
                tbBody.Append("<TR id='h48c{1}'><TD align='right'><div style='width:90px'>{312}</div></TD><TD align='right'><div style='width:60px;'>{313}%</div></TD><TD " + clsYoy + ">{314}</TD></TR>")
                tbBody.Append("<TR id='h49c{1}'><TD align='right'><div style='width:90px'>{315}</div></TD><TD align='right'><div style='width:60px;'>{316}%</div></TD><TD " + clsYoy + ">{317}</TD></TR>")
                tbBody.Append("<TR id='h50c{1}'><TD align='right'><div style='width:90px'>{318}</div></TD><TD align='right'><div style='width:60px;'>{319}%</div></TD><TD " + clsYoy + ">{320}</TD></TR>")
                tbBody.Append("<TR style='font-weight:bold;' class='rbg1'><TD align='right'><div style='width:90px'>{321}</div></TD><TD align='right'><div style='width:60px;'>{322}%</div></TD><TD " + clsYoy + ">{323}</TD></TR>")
                Return tbBody.ToString
            Case 3
                Dim tbFoot As New StringBuilder
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{0}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD" + clsYoy + "></TD></TR>")
                tbFoot.Append("<TR style='font-weight:bold;' class='rbg2'><TD align='right'><div style='width:90px'>{1}</div></TD><TD align='center'><div style='width:60px;'>&nbsp;</div></TD><TD" + clsYoy + "></TD></TR>")
                tbFoot.Append("</TABLE>")
                Return tbFoot.ToString
            Case Else
                Return ""
        End Select
    End Function

#End Region
End Class
