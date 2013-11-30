<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="manage_currency.aspx.vb" Inherits="manage_currency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function showRate(ddl) {
            var enabled = ddl.options[ddl.selectedIndex].value
            if (enabled == 'month') {
                div_rate.style.display = 'block';
            } else {
                div_rate.style.display = 'none';
            }
        }
    </script>
    <style type="text/css">
        .CusTab
        {
            font-size: 11px;
            font-family: Tahoma, Arial, Verdana, Helvetica, sans-serif;
            background: #FFFFFF;
        }
        .CusTabHeader
        {
            background: #7cd5ff;
            color: #1b448e;
        }
        .ktb0
        {
            width: 100px;
            text-align: center;
        }
        .ktb1
        {
            width: 250px;
            text-align: center;
        }
        .ktb23
        {
            width: 50px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <div style="padding: 20px 0px 0px 20px;">
                <div>
                    <strong>Manage Currency</strong><br />
                    <br />
                </div>
                <div>
                    <asp:Button ID="AddNewBt" runat="server" Text="Add New Currentcy" /></div>
                <asp:Panel ID="Panel1" runat="server">
                    <div style="padding-top: 10px;">
                        <%--<asp:Label ID="Label1" runat="server" CssClass="lbtitle" Text="Add New Currentcy"></asp:Label>--%>
                        <div style="float: left; margin-left: 10px;">
                            Currency
                            <asp:TextBox ID="AddTxt" runat="server" CssClass="inputbox4"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 10px;">
                            Country
                            <asp:TextBox ID="AddCountryTxt" runat="server" CssClass="inputbox4"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 10px;">
                            Rate
                            <asp:TextBox ID="AddRateTxt" MaxLength="7" runat="server" CssClass="inputbox4"></asp:TextBox>
                        </div>
                        <asp:Button ID="AddBt" runat="server" Text="Save" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server">
                    <div style="padding-top: 10px;">
                        <asp:HiddenField ID="HdID" runat="server" />
                        <asp:HiddenField ID="HdTemp" runat="server" />
                        <%--<asp:Label ID="Label2" runat="server" CssClass="lbtitle" Text="Edit"></asp:Label>--%>
                        <div style="float: left; margin-left: 10px;">
                            Currency
                            <asp:TextBox ID="EditTxt" runat="server" CssClass="inputbox4"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 10px;">
                            Country
                            <asp:TextBox ID="EditCountryTxt" runat="server" CssClass="inputbox4"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 10px;">
                            Rate
                            <asp:TextBox ID="EditRateTxt" runat="server" CssClass="inputbox4" MaxLength="5"></asp:TextBox>
                        </div>
                         <div style="float: left; margin-left: 10px;">
                            <asp:Button ID="EditBt" runat="server" Text="Update" />
                             <asp:Button ID="btnCancelUpdate" runat="server" Text="Cancel" />
                        </div>
                        <div style="clear:both"></div>
                        <br />
                        <fieldset><legend style="color:#1b448e;">Currency Rate Per Month</legend>
                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" Width="100px">
                        </asp:DropDownList>
                        <asp:Button ID="btnAddRate" runat="server" Text="Edit" Width="60px" />
                        <asp:Button ID="btnSaveRate" runat="server" Text="Save" Width="60px" Enabled="false" />
                            <asp:Button ID="btnDelRate" runat="server" Text="Delete" Visible="false" 
                                Width="60px" />
                        <br />
                        <div id="div_rate" style="display: block">
                            <asp:GridView ID="gvMonthRate" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2"
                                CssClass="CusTab" BorderColor="White" BorderStyle="Solid" BorderWidth="1px">
                                <RowStyle  Height="22" />
                                <Columns>
                                    <asp:BoundField DataField="cr_month" ItemStyle-CssClass="ktb0" HeaderText="Month">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cr_rate" HeaderText="Currency Rate">
                                        <ItemStyle CssClass="ktb0" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Currency Rate" Visible="false" ItemStyle-CssClass="ktb0">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRate" runat="server" CssClass="inputbox4" MaxLength="7" Width="100px"
                                                Text='<%# Bind("cr_rate") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="CusTabHeader" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getCurrentcyRate"
                                TypeName="ClsDB" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="HdID" Name="name" PropertyName="Value" Type="String" />
                                    <asp:ControlParameter ControlID="ddlYear" Name="year" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="HdTemp" Name="tempRate" PropertyName="Value" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
</fieldset>
                    </div>
                    <div style="padding-top: 10px;">
                    </div>
                </asp:Panel>
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                        CssClass="CusTab" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="crc_name">
                        <Columns>
                            <asp:BoundField DataField="crc_name" HeaderText="Currentcy">
                                <ItemStyle CssClass="ktb1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="crc_country" ItemStyle-CssClass="ktb1" HeaderText="Country" />
                            <asp:BoundField DataField="crc_rate" ItemStyle-CssClass="ktb0" HeaderText="Currency Rate" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="Imgedit" runat="server" ImageUrl="img/edit-red.png" Style="height: 16px"
                                        OnClick="Imgedit_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgDel" runat="server" ImageUrl="img/delete-red.png" Style="height: 16px"
                                        OnClick="ImgDel_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="CusTabHeader" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getCurrentcy"
                        TypeName="ClsDB"></asp:ObjectDataSource>
                    <br />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
