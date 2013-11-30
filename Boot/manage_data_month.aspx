<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="manage_data_month.aspx.vb" Inherits="manage_data_month" %>

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
	        width:350px;
	        text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:20px 0px 0px 20px;">
    <div><strong>Manage Month</strong><br /><br /></div>
    <div><a href="import_file.aspx" class="add_cost">+ Import Data</a></div>
    <div style="padding-top:10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" CssClass="CusTab" BorderColor="White" 
            BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" 
            DataKeyNames="month_time">
            <Columns>
                <asp:BoundField DataField="month_time" HeaderText="Month" 
                    DataFormatString="{0:MMMM yyyy}">
                <ItemStyle CssClass="ktb1" />
                </asp:BoundField>
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
            SelectMethod="getMonthData" TypeName="ClsDB"></asp:ObjectDataSource>
        <br />
    </div>
</div>
</asp:Content>

