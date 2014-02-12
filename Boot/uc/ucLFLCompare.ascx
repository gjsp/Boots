<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucLFLCompare.ascx.vb" Inherits="ucLFLCompare" %>

<link href="../style.css" rel="stylesheet" type="text/css" />
<script src="../js/function.js" type="text/javascript"></script>

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
            r = 53;
        }
        for (y = 1; y <= r; y++) {
            var x = $get('<%=hdfIndex.clientId %>').value;
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
            r = 53;
        }
        for (y = 1; y <= r; y++) {
            var x = $get('<%=hdfIndex.clientId %>').value;
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
<asp:Panel ID="pnMain" runat="server" Visible = "false">
    <br />
    <asp:LinkButton ID="linkExcel" runat="server" Style="color: #37a700">Export To Excel</asp:LinkButton>
    <br />
    <br />
    <div id="temp_body" runat="server">
        <table cellspacing='0' cellpadding='0' class='tb_block' style="max-width:800px">
            <tr>
                <td style="vertical-align:top">
                        <asp:Label ID="lblTopicTable" runat="server"></asp:Label>
                </td>
                <td style="vertical-align:top">
                    <div id="div_item" runat="server" class="scroll3">
                        <asp:DataList ID="dlItem" runat="server" RepeatDirection="Horizontal" BorderWidth="0px"
                            CellPadding="0" BorderStyle="None">
                            <ItemTemplate>
                                <asp:Label ID="lbl" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </td>
                <td style="vertical-align:top">
                    <asp:DataList ID="dlTotal" runat="server" RepeatDirection="Horizontal" BorderWidth="0px"
                        CellPadding="0" BorderStyle="None">
                        <ItemTemplate>
                            <asp:Label ID="lbl" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdfIndex" runat="server" />
</asp:Panel>
<asp:Panel ID="pnNothing" runat="server" Visible = "false">
    <br />
 <asp:Label ID="lblNodata" runat="server" Text=""></asp:Label>
</asp:Panel>