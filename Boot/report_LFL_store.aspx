﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="report_LFL_store.aspx.vb" Inherits="report_LFL_store" EnableEventValidation="true" %>

<%@ Register Src="~/uc/ucLFLStore.ascx" TagPrefix="uc1" TagName="ucLFLStore" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div style="padding: 10px 10px;">
        <strong>LFL By Store Report</strong>
        <span style="font-size:11px">
        (Note : All number represents performance at retail store contribution level only, excluding stock loss & obsolete provision at warehouse, supplier income and other central cost allocation which are A&P, head office cost)
        </span>
       <br /><br />
        <div style="float:left; margin-right:.5cm">
        Model <asp:DropDownList ID="ddlModel" runat="server" CssClass="select2" >
        <asp:ListItem Text = "LFL" Value="LFL"></asp:ListItem>
        <asp:ListItem Text = "Non LFL" Value="NonLFL"></asp:ListItem>
        <asp:ListItem Text = "Closed" Value="Closed"></asp:ListItem>
        <asp:ListItem Text = "New Store" Value="NewStore"></asp:ListItem>
        <asp:ListItem Text = "Other Business" Value="OtherBusiness"></asp:ListItem>
        </asp:DropDownList>
         </div>

        <div style="float: left; margin-right: .5cm">
            By
            <asp:DropDownList ID="ddlBy" runat="server" CssClass="select2" Width="80px">
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
        Currency Rate : <asp:DropDownList ID="ddlRate" runat="server" CssClass="select2">
        </asp:DropDownList>
         </div>
        <asp:Button ID="SearchBt" runat="server" Text="Search" Height="23px"/>
       <uc1:ucLFLStore runat="server" ID="ucLFLStore" />
    </div>           
</asp:Content>

