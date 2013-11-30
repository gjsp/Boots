<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="report_performance_full.aspx.vb" Inherits="report_performance_full"
    EnableEventValidation="true" %>

<%@ Register Src="uc/ucFullPerformance.ascx" TagName="ucFullPerformance" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 10px 10px;">
        <strong>Full Year Store Performance Report</strong>
        <span style="font-size:11px">
        (Note : All number represents performance at retail store contribution level only, excluding stock loss & obsolete provision at warehouse, supplier income and other central cost allocation which are A&P, head office cost)
        </span>
        <br />
        <br />
        <div style="float: left; margin-right: .5cm">
            Year :
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <div style="float: left; margin-right: .5cm">
            Currency Rate :
            <asp:DropDownList ID="ddlRate" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <asp:Button ID="SearchBt" runat="server" Text="Search" Height="23px" />
        <uc1:ucFullPerformance ID="ucFullPer" runat="server" />
    </div>
</asp:Content>
