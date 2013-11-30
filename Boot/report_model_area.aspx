<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="report_model_area.aspx.vb" Inherits="report_model_area" EnableEventValidation="true" %>

<%@ Register src="uc/ucReport.ascx" tagname="ucReport" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div style="padding: 10px 10px;">
        <strong>Area Report</strong>
        <span style="font-size:11px">
        (Note : All number represents performance at retail store contribution level only, excluding stock loss & obsolete provision at warehouse, supplier income and other central cost allocation which are A&P, head office cost)
        </span>
        <br /><br />
        
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
        <uc1:ucReport ID="ucReport" runat="server" />
        
    </div>
          
 
           
</asp:Content>

