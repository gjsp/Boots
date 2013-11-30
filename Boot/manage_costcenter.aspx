<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="manage_costcenter.aspx.vb" Inherits="manage_costcenter" %>

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
	        width:150px;
	        text-align:center;
        }
        .ktb2
        {
	        width:180px;
	        text-align:center;
        }
         .ktb3
        {
	        width:120px;
	        text-align:center;
        }
         .ktb4
        {
	        width:120px;
	        text-align:center;
        }
         .ktb5
        {
	        width:100px;
	        text-align:center;
        }
         .ktb6
        {
	        width:50px;
	        text-align:center;
        }
         .ktb7
        {
	        width:150px;
	        text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:20px 0px 0px 20px;">
    <div><strong>Manage Cost Center</strong><br><br></div>
        <div style="padding-top:10px;">
        Search : <asp:TextBox ID="SearchTxt" runat="server"></asp:TextBox> 
    </div>
    <div style="padding-top:10px;">
        Area : <asp:DropDownList ID="ddlarea" 
            runat="server">
        </asp:DropDownList>
        Location : <asp:DropDownList ID="ddllocation" runat="server">
        </asp:DropDownList>
        Province : <asp:DropDownList ID="ddlprovince" runat="server">
        </asp:DropDownList> 
        Store : <asp:DropDownList ID="ddlstore" runat="server">
        </asp:DropDownList> 
        <asp:Button ID="Button1" runat="server" Text="Search" />
    </div>  
    <div style="padding-top:20px;"><a href="add_costcenter.aspx" class="add_cost">+ Add New Store</a></div> 
    <div style="padding-top:10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" CssClass="CusTab" BorderColor="White" 
            BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" 
            DataKeyNames="costcenter_id">
            <Columns>
                <asp:BoundField DataField="costcenter_code" HeaderText="Code">
                <ItemStyle CssClass="ktb1" />
                </asp:BoundField>
                <asp:BoundField DataField="costcenter_name" HeaderText="Name">
                 <ItemStyle CssClass="ktb2" />
                </asp:BoundField>
                <asp:BoundField DataField="store_name" HeaderText="Store">
                 <ItemStyle CssClass="ktb3" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <%# Eval("location_name")%>
                    </ItemTemplate>
                    <ItemStyle CssClass="ktb4" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Province">
                    <ItemTemplate>
                        <%# Eval("province_name")%>
                    </ItemTemplate>
                    <ItemStyle CssClass="ktb5" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Area">
                    <ItemTemplate>
                        <%# Eval("area_name")%>
                    </ItemTemplate>
                    <ItemStyle CssClass="ktb6" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Market">
                    <ItemTemplate>
                        <%# Eval("market_name")%>
                    </ItemTemplate>
                    <ItemStyle CssClass="ktb5" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Area (sqm)">
                    <ItemStyle CssClass="ktb5" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sale Area (sqm)">
                    <ItemStyle CssClass="ktb5" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Open Date">
                    <ItemTemplate>
                        <%# Eval("costcenter_opendt")%>
                    </ItemTemplate>
                    <ItemStyle CssClass="ktb5" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Block Date">
                    <ItemTemplate>
                        <%# Eval("costcenter_blockdt")%>
                    </ItemTemplate>
                    <ItemStyle CssClass="ktb5" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remark">
                    <ItemTemplate>
                        <%# Eval("costcenter_remark")%>
                    </ItemTemplate>
                    <ItemStyle CssClass="ktb7" />
                </asp:TemplateField>
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
            SelectMethod="getCostcenterBySearch" TypeName="ClsDB" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="area" Type="String" />
                <asp:Parameter Name="location" Type="String" />
                <asp:Parameter Name="province" Type="String" />
                <asp:Parameter Name="store" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
</div>
</asp:Content>