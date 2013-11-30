<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="manage_budget.aspx.vb" Inherits="manage_budget" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .CusTab{
            font-size:11px; 
            font-family:  Tahoma, Arial, Verdana, Helvetica, sans-serif;
            background: #FFFFFF;
          }
        .CusTabHeader
        {
            background: #7cd5ff;
            color:#1b448e;
        }
        .ktb1
        {
	        width:250px;
	        text-align:center;
        }
        .ktb23
        {
	        width:50px;
	        text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
<ContentTemplate>
<div style="padding:20px 0px 0px 20px;">
    <div><strong>Manage Budget</strong><br /><br /></div>
    <div style="padding:10px 0px;">Store : <asp:DropDownList ID="ddlstore" 
            runat="server" CssClass="select2" AutoPostBack="True"></asp:DropDownList></div>
    <div><asp:Button ID="AddNewBt" runat="server" Text="Add New Budget" /></div>
    <div style="padding-top:10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" CssClass="CusTab" BorderColor="White" 
            BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" 
            DataKeyNames="id">
            <Columns>
               <asp:BoundField DataField="month_time" HeaderText="Month" 
                    DataFormatString="{0:MMMM yyyy}" NullDisplayText="None">
                <ItemStyle CssClass="ktb1" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="Imgedit" runat="server" ImageUrl="img/edit-red.png" 
                            style="height: 16px" onclick="Imgedit_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgDel" runat="server" ImageUrl="img/delete-red.png" 
                            style="height: 16px" onclick="ImgDel_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="CusTabHeader" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="getBudgById" TypeName="ClsDB" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter Name="id" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

