<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="true" MaintainScrollPositionOnPostback="true" CodeFile="report_performance.aspx.vb"
    Inherits="report_performance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <link href="scroll/GridviewScroll.css" rel="stylesheet" type="text/css" />
    <script src="scroll/gridviewScroll.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        function gridviewScroll() {
            $('#ContentPlaceHolder1_gv').gridviewScroll({

                width: screen.width - 50,
                height: 400,
                freezesize: 2,
                arrowsize: 30,
                varrowtopimg: "Images/arrowvt.png",
                varrowbottomimg: "Images/arrowvb.png",
                harrowleftimg: "Images/arrowhl.png",
                harrowrightimg: "Images/arrowhr.png",
                headerrowcount: 1
            });
        }
        function pageLoad() {
            gridviewScroll();
            if ($get('ContentPlaceHolder1_ddlBy').selectedIndex == 2) {
                $get('divEndDate').style.display = 'block';
            } else {
                $get('divEndDate').style.display = 'none';
            }
        }

        function swepDate(ddl) {
            if ($get(ddl.id).selectedIndex == 2) {
                $get('divEndDate').style.display = 'block';
            } else {
                $get('divEndDate').style.display = 'none';
            }
        }
             
    </script>
    <style type="text/css">
        .GridviewScrollC1Header TH, .GridviewScrollC1Header TD
        {
            font-weight: bold;
            background-color: #376091;
            color: #FFFFFF;
        }
        .GridviewScrollC1Item TD
        {
            font-size: 11px;
            border-bottom: 1px solid #2c2b2b;
            color: #000000;
        }
        .GridviewScrollC1Pager
        {
            border-top: 1px solid #AAAAAA;
            background-color: #FFFFFF;
        }
        .GridviewScrollC1Pager TD
        {
            padding-top: 3px;
            font-size: 14px;
            padding-left: 5px;
            padding-right: 5px;
        }
        .GridviewScrollC1Pager A
        {
            color: #666666;
        }
        .GridviewScrollC1Pager SPAN
        {
            font-size: 16px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 10px 10px;">
        <strong>Performance Report</strong> 
       <span style="font-size:11px">
        (Note : All number represents performance at retail store contribution level only, excluding stock loss & obsolete provision at warehouse, supplier income and other central cost allocation which are A&P, head office cost)
        </span>
        <br />
        <br />
        <div style="float: left; margin-right: .5cm">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <div style="margin-right: .5cm">
                                    By
                                    <asp:DropDownList ID="ddlBy" runat="server" CssClass="select2" Width="80px">
                                        <asp:ListItem Text="MTD"></asp:ListItem>
                                        <asp:ListItem Text="YTD"></asp:ListItem>
                                        <asp:ListItem Text="Custom"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <div>
                                    Date :
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="select2">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <div id="divEndDate" style="display: none">
                                    &nbsp;&nbsp; To :
                                    <asp:DropDownList ID="ddlMonth2" runat="server" CssClass="select2">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYear2" runat="server" CssClass="select2" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <div style="margin-right: .5cm">
                                    Currency Rate :
                                    <asp:DropDownList ID="ddlRate" runat="server" CssClass="select2">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <asp:Button ID="SearchBt" runat="server" Text="Search" Height="23px" />
                            </td>
                            <td>
                                <div align="center">
                                    <asp:UpdateProgress ID="upPG" runat="server">
                                        <ProgressTemplate>
                                            <div id="divPG" align="center" valign="middle" runat="server" style="position: absolute;
                                                left: 47%; padding: 5px 10px 10px 10px; visibility: visible; border-color: silver;
                                                border-style: solid; border-width: 1px; background-color: White; margin-top: 10px">
                                                <asp:Image ID="imgInd" ImageUrl="~/img/indicator.gif" runat="server" AlternateText="Processing" />
                                                Loading ...
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style="clear: both">
    </div>
    <div style="margin: .5cm">
            <div id="dv_excel" style="display:none">
            <asp:LinkButton ID="linkExcel" runat="server" Style="color: #37a700;">Export To Excel</asp:LinkButton>
            <br />
       </div>
       <br />
            <asp:UpdatePanel ID="upGv" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Font-Bold="False"
                        Width="99%" GridLines="Vertical" Font-Names="Tahoma" Font-Size="10pt" CellPadding="1"
                        HeaderStyle-Height="45px" CellSpacing="1">
                        <Columns>
                            <asp:BoundField DataField="costcenter_code" HeaderText="Store No.">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="costcenter_name" HeaderText="Name" />
                            <asp:BoundField DataField="store_name" HeaderText="Store Format" />
                            <asp:BoundField DataField="saleRevenue" HeaderText="Revenue" DataFormatString="{0:#,000.00}">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Productivity" HeaderText="Productivity/ SQM/MTH" DataFormatString="{0:#,000.00}">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="% Gross Profit" HeaderText="% Gross Profit">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="% Adj Gross Profit" HeaderText="% Adj Gross Profit">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="% OPEX" HeaderText="% OPEX">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="% Trading Profit/Loss" HeaderText="% Trading Profit/Loss">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TradingProfit" HeaderText="Trading Profit(THB)" DataFormatString="{0:#,000.00}">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="% LFL" HeaderText="% LFL">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="costcenter_opendt" HeaderText="Open Date" DataFormatString="{0:d-MMM-yy}">
                                <HeaderStyle Width="110px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="GridviewScrollC1Header" />
                        <RowStyle CssClass="GridviewScrollC1Item" />
                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ods" runat="server" SelectMethod="getPerformance" TypeName="clsPfm">
                        <SelectParameters>
                            <asp:Parameter ConvertEmptyStringToNull="False" Name="by" Type="String" />
                            <asp:Parameter Name="bDate" Type="DateTime" />
                            <asp:Parameter Name="eDate" Type="DateTime" />
                            <asp:Parameter ConvertEmptyStringToNull="False" Name="rate" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
      
    </div>
</asp:Content>
