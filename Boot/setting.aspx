<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="setting.aspx.vb" Inherits="setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="padding:20px 0px 0px 20px">
    <div><strong>General Setting</strong></div>
    <div style="padding-left:10px;">
        <div style="padding-top:5px;"> - <a href="manage_costcenter.aspx">Manage Cost Center</a></div>
        <div style="padding-top:5px;"> - <a href="manage_data_month.aspx">Manage Month Data</a></div>
       <div style="padding-top:5px;"> - <a href="manage_model.aspx">Manage Model</a></div>
        <div style="padding-top:5px;"> - <a href="manage_province.aspx">Manage Province</a></div>
        <div style="padding-top:5px;"> - <a href="manage_region.aspx">Manage Region</a></div>
        <div style="padding-top:5px;"> - <a href="manage_area.aspx">Manage Area</a></div>
        <div style="padding-top:5px;"> - <a href="manage_currency.aspx">Manage Currency</a></div>
    </div>
   <div style="padding-top:20px;"><strong>LFL Setting</strong></div>
    <div style="padding-left:10px;">
        <div style="padding-top:5px;"> - <a href="manage_temporary.aspx">Manage Temporary Closed</a></div>
  </div>
    <%--   <div style="padding-top:20px;"><strong>Budget Setting</strong></div>
    <div style="padding-left:10px;">
        <div style="padding-top:5px;"> - <a href="manage_budget.aspx">Manage Budget</a></div>
    </div>--%>
</div>
</asp:Content>

