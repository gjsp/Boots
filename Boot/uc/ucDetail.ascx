<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetail.ascx.vb" Inherits="uc_ucDetail" %>

<link href="../style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
   
</style>

 <%--<table cellspacing='0' cellpadding='0' class='tball'>
    <tr style='font-weight:bold;' class='kbg1'>
        <td align='left'><div style="width:250px;padding-left:5px;" class="pptk">Number of Stores</div></td>
        <td align='center'><div style='width:110px'><strong><asp:Label ID="LbNost" runat="server" Text=""></asp:Label></strong></div></td>
        <td align='center'><div style='width:65px;'><strong></strong></div></td>
    </tr>
    <tr style='font-weight:bold;' class='kbg1'>
        <td align='left'><div style="width:250px;padding-left:5px;"></div></td>
        <td align='center'><div style='width:110px'><strong>Total</strong></div></td>
        <td align='center'><div style='width:65px;'><strong>% Sale</strong></div></td>
    </tr>
    <tr style='font-weight:bold;'>
        <td align='left' class='kbg2'><div style="width:250px;padding-left:5px;" class="pptk">Total Gross Space (SQM)</div></td>
        <td align='center' class='kbg3'><div style='width:110px'><asp:Label ID="LbFullTgs" runat="server" Text=""></asp:Label></div></td>
        <td align='center' class='kbg4'><div style='width:65px;'></div></td></tr>
    <tr style='font-weight:bold;'>
        <td align='left' class='kbg2'><div style="width:250px;padding-left:5px;" class="pptk">Total Selling Space (SQM)</div></td>
        <td align='center' class='kbg3'><div style='width:110px'><asp:Label ID="LbFullTss" runat="server" Text=""></asp:Label></div></td>
        <td align='center' class='kbg4'><div style='width:65px;'></div></td></tr>
    <tr style='font-weight:bold;'>
        <td align='left' class='kbg2'><div style="width:250px;padding-left:5px;" class="pptk"> Productivity/SQM</div></td>
        <td align='center' class='kbg3'><div style='width:110px'><asp:Label ID="LbFullPos" runat="server" Text=""></asp:Label></div></td>
        <td align='center' class='kbg4'><div style='width:65px;'></div></td>
    </tr>
    <tr style='font-weight:bold;'>
        <td align='left' class='kbg2'><div style="width:250px;padding-left:5px;">&nbsp;</div></td>
        <td align='center' class='kbg3'><div style='width:110px'><asp:Label ID="LbMtdDate" runat="server" Text=""></asp:Label></div></td>
        <td align='center' class='kbg4'><div style='width:65px;'></div></td>
        </tr>
    <tr style='font-weight:bold;' class='kbg5'>
        <td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Total Revenue <span id="spaa" class="ppk" onclick="minitb('aa');">+</span></div></td>
        <td align='right'><div style='width:110px'>{0}</div></td>
        <td align='right'><div style='width:65px;'>%</div></td>
    </tr>
    <tr id='aa1'>
        <td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Sale Revenue</div></td>
        <td align='right' class='kbg3'><div style='width:110px'>{1}</div></td>
        <td align='right' class='kbg4'><div style='width:65px;'>%</div></td>
    </tr>
    <tr id='aa2'>
        <td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Other Revenue</div></td>
        <td align='right' class='kbg3'><div style='width:110px'>{2}</div></td>
        <td align='right' class='kbg4'><div style='width:65px;'>%</div></td>
    </tr>
        <tr style='font-weight:bold;'>
        <td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Cost of Good Sold</div></td>
        <td align='right' class='kbg3'><div style='width:110px'>{3}</div></td>
        <td align='right' class='kbg4'><div style='width:65px;'>%</div></td>
    </tr>
    <tr style='font-weight:bold;' class='kbg5'>
        <td align='left'><div style="width:200px;padding-left:5px;" class="pptk">Gross Profit</div></td>
        <td align='right'><div style='width:110px'>{4}</div></td>
        <td align='right'><div style='width:65px;'>%</div></td></tr>
    <tr style='font-weight:bold;'>
        <td align='left' class='kbg2'><div style="width:200px;padding-left:5px;" class="pptk">Margin Adjustments <span id="spb" class="ppk" onclick="minitb('b');">+</span></div></td>
        <td align='right' class='kbg3'><div style='width:110px'>{5}</div></td>
        <td align='right' class='kbg4'><div style='width:65px;'>%</div></td></tr>
    <tr id='b1'>
        <td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Shipping</div></td>
        <td align='right' class='kbg3'><div style='width:110px'>{6}</div></td>
        <td align='right' class='kbg4'><div style='width:65px;'>%</div></td></tr>
    <tr id='b2'>
        <td align='left' class='kbg2'><div style="width:200px;padding-left:5px;"> - Stock Loss and Obsolescence</div></td>
        <td align='right' class='kbg3'><div style='width:110px'>{7}</div></td>
        <td align='right' class='kbg4'><div style='width:65px;'>%</div></td>
    </tr>
</table>--%>
<div id="divHtml" runat="server">
</div>
          