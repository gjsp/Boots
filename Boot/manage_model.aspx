<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="manage_model.aspx.vb" Inherits="manage_model" %>

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
        .ktb29
        {
	        width:120px;
	        text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
<ContentTemplate>
    <div style="padding:20px 0px 0px 20px;">
    <div><strong>Manage Model</strong><br /><br /></div>
    <div><asp:Button ID="AddNewBt" runat="server" Text="Add New Model" /></div>
    <asp:Panel ID="Panel1" runat="server">
            <div style="padding-top:10px;">
                <asp:Label ID="Label1" runat="server" CssClass="lbtitle" Text="Add"></asp:Label> <asp:TextBox ID="AddTxt" runat="server" CssClass="inputbox4"></asp:TextBox>
                <asp:Button ID="AddBt" runat="server" Text="Save" />
            </div>
    </asp:Panel>
     <asp:Panel ID="Panel2" runat="server">
            <div style="padding-top:10px;">
                <asp:Label ID="Label2" runat="server" CssClass="lbtitle" Text="Edit"></asp:Label> <asp:TextBox ID="EditTxt" runat="server" CssClass="inputbox4"></asp:TextBox> Other Business 
                <asp:DropDownList ID="ddlother" runat="server">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList> <asp:Button ID="EditBt" runat="server" Text="Update" /><asp:HiddenField ID="HdID" runat="server" />
            </div>
    </asp:Panel>
    <div style="padding-top:10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" CssClass="CusTab" BorderColor="White" 
            BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" 
            DataKeyNames="store_id">
            <Columns>
                <asp:BoundField DataField="store_name" HeaderText="Model">
                <ItemStyle CssClass="ktb1" />
                </asp:BoundField>
                <asp:BoundField DataField="store_other" HeaderText="Other Business">
                <ItemStyle CssClass="ktb29" />
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
            SelectMethod="getStoreByName" TypeName="ClsDB"></asp:ObjectDataSource>
        <br />
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

