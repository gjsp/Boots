<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="report_store.aspx.vb" Inherits="report_store" EnableEventValidation="true" %>


<%@ Register src="uc/ucStore.ascx" tagname="ucStore" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div style="padding: 10px 10px;">
        <strong>Store Report</strong>
        <span style="font-size:11px">
        (Note : All number represents performance at retail store contribution level only, excluding stock loss & obsolete provision at warehouse, supplier income and other central cost allocation which are A&P, head office cost)
        </span>
       <br /><br />
        
        <div style="float: left; margin-right: .5cm">
            Store :
            <asp:DropDownList ID="ddlstore" runat="server" CssClass="select2">
        </asp:DropDownList>
        </div>

        <div style="float:left; margin-right:.5cm">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
             From :<asp:DropDownList ID="ddlMonth" runat="server" CssClass="select2">
        </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" AutoPostBack="True">
        </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp; To :
                <asp:DropDownList ID="ddlMonth2" runat="server" CssClass="select2">
            </asp:DropDownList>
                <asp:DropDownList ID="ddlYear2" runat="server" CssClass="select2" AutoPostBack="True">
            </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>   
    
        </div>          

       
         <div style="float:left; margin-right:.5cm">
        Currency Rate : <asp:DropDownList ID="ddlRate" runat="server" CssClass="select2">
        </asp:DropDownList>
         </div>
        <asp:Button ID="SearchBt" runat="server" Text="Search" Height="23px"/>
            
        <uc1:ucStore ID="ucStore1" runat="server" />
      
      
    </div>
          
 
           
</asp:Content>

