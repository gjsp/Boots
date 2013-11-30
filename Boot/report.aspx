<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="report.aspx.vb" Inherits="report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 20px 0px 0px 20px">
        <div>
            <strong>Model Report</strong></div>
        <div style="padding: 0px 0px 10px 10px;">
            <div style="padding-top: 5px;">
                - <a href="report_mtd.aspx">Model Report</a></div>
            <%-- <div style="padding-top:5px;"> - <a href="model_by_store_report.aspx">Model By Store Report</a></div>--%>
            <div style="padding-top: 5px;">
                - <a href="report_mtd_format.aspx">Model By Store Report</a></div>
        </div>
        <div>
            <strong>Model By Location Report</strong></div>
        <div style="padding: 0px 0px 10px 10px;">
            <div style="padding-top: 5px;">
                - <a href="report_mtd_location.aspx">Model By Location Report</a></div>
            <%--<div style="padding-top: 5px;">
                - <a href="model_by_province_report.aspx">Province By Store Report</a></div>--%>
            <div style="padding-top: 5px;">
                - <a href="report_province.aspx">Province By Store Report</a></div>
        </div>
        <div>
            <strong>Store Report</strong></div>
        <div style="padding: 0px 0px 10px 10px;">
            <div style="padding-top: 5px;">
                - <a href="report_store.aspx">Store Report</a></div>
            <div style="padding-top: 5px;">
                - <a href="top_store_report.aspx">Top Store Report</a></div>
        </div>
        <div>
            <strong>Area Report</strong></div>
        <div style="padding: 0px 0px 10px 10px;">
            <div style="padding-top: 5px;">
                - <a href="report_model_area.aspx">Area Report</a></div>
            <%--<div style="padding-top:5px;"> - <a href="area_report_mtd.aspx">MTD Area Report</a></div>
        <div style="padding-top:5px;"> - <a href="area_report_ytd.aspx">YTD Area Report</a></div>
            <div style="padding-top: 5px;">
                - <a href="area_by_store_report.aspx">Area By Store Report</a></div>
                --%>
            <div style="padding-top: 5px;">
                - <a href="report_model_area_store.aspx">Area By Store Report</a></div>
        </div>
        <%--    <div><strong>Market Report</strong></div>
     <div style="padding:0px 0px 10px 10px;">
        <div style="padding-top:5px;"> - <a href="mtd_market_report.aspx">Mtd Market Report</a></div>
        <div style="padding-top:5px;"> - <a href="ytd_market_report.aspx">Ytd Market Report</a></div>
    </div>  
        --%>
        <asp:Panel ID="pnAdmin" runat="server">
            <div>
                <strong>LFL Report</strong></div>
            <div style="padding: 0px 0px 10px 10px;">
                <div style="padding-top: 5px;">
                    - <a href="lfl_mtd_report.aspx">MTD LFL Report</a></div>
                <div style="padding-top: 5px;">
                    - <a href="lfl_ytd_report.aspx">YTD LFL Report</a></div>
                <div style="padding-top: 5px;">
                    - <a href="lfl_by_store_report.aspx">LFL By Store Report</a></div>
                <div style="padding-top: 5px;">
                    - <a href="lfl_mtd_compare.aspx">Compare MTD LFL Report</a></div>
            </div>
            <div>
                <strong>Performance Report</strong></div>
            <div style="padding: 0px 0px 10px 10px;">
                <div style="padding-top: 5px;">
                    - <a href="report_performance.aspx">Performance Report</a></div>
                <div style="padding-top: 5px;">
                    - <a href="report_performance_full.aspx">Full Year Store Performance Report</a></div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
