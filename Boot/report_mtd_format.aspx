<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="report_mtd_format.aspx.vb" Inherits="report_mtd_format" EnableEventValidation="true" %>

<%@ Register Src="uc/ucReport.ascx" TagName="ucReport" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 10px 10px;">
        <strong>Model By Store Report</strong>
        <span style="font-size:11px">
        (Note : All number represents performance at retail store contribution level only, excluding stock loss & obsolete provision at warehouse, supplier income and other central cost allocation which are A&P, head office cost)
        </span>
       <br />
        <br />
        <div style="float: left; margin-right: .5cm">
            Model :
            <asp:DropDownList ID="ddlstore" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <div style="float: left; margin-right: .5cm">
            Location :
            <asp:DropDownList ID="ddllo" runat="server" CssClass="select2">
            </asp:DropDownList>
            <asp:TextBox ID="TbCk" runat="server" Style="display: none;"></asp:TextBox>
        </div>
        <div style="float: left; margin-right: .5cm">
            Currency Rate :
            <asp:DropDownList ID="ddlRate" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
         <br />
        <br />
        <div style="float: left; margin-right: .5cm">
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
            <asp:TextBox ID="TextBox1" runat="server" Style="display: none;"></asp:TextBox>
            <asp:TextBox ID="TbCD" runat="server" Style="display: none;"></asp:TextBox>
            <asp:TextBox ID="TbCk2" runat="server" Style="display: none;"></asp:TextBox>
            <asp:TextBox ID="TbCSale" runat="server" Style="display: none;"></asp:TextBox>
        </div>
        <asp:Button ID="SearchBt" runat="server" Text="Search" Height="23px" />
        <uc1:ucReport ID="ucModel" runat="server" />
    </div>
</asp:Content>
