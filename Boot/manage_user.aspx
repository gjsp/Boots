<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="manage_user.aspx.vb" Inherits="manage_user" %>

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
	        width:200px;
	        text-align:center;
        }
        .ktb23
        {
	        width:200px;
	        text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
<ContentTemplate>
    <div style="padding:20px 0px 0px 20px;">
    <div><strong>Manage User</strong><br /><br /></div>
    <div><asp:Button ID="AddNewBt" runat="server" Text="Add New User" /></div>
    <asp:Panel ID="Panel1" runat="server">
            <div style="padding-top:10px;">
                Username <asp:TextBox ID="AddUserTxt" runat="server" CssClass="inputbox4"></asp:TextBox>
                Password <asp:TextBox ID="AddPassTxt" runat="server" CssClass="inputbox4" 
                    TextMode="Password"></asp:TextBox>
                <asp:Button ID="AddBt" runat="server" Text="Add" />
            </div>
    </asp:Panel>
     <asp:Panel ID="Panel2" runat="server">
            <div style="padding-top:10px;">
                Username <asp:TextBox ID="EditTxt" runat="server" CssClass="inputbox4" disabled="true" ></asp:TextBox>
                Password <asp:TextBox ID="EditPassTxt" runat="server" CssClass="inputbox4" 
                    TextMode="Password"></asp:TextBox>
                <asp:Button ID="EditBt" runat="server" Text="Update" /><asp:HiddenField ID="HdID" runat="server" />
            </div>
    </asp:Panel>
    <div style="padding-top:10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" CssClass="CusTab" BorderColor="White" 
            BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" 
            DataKeyNames="users_id">
            <Columns>
                <asp:BoundField DataField="users_name" HeaderText="Username">
                <ItemStyle CssClass="ktb1" />
                </asp:BoundField>
                 <asp:BoundField DataField="users_pass" HeaderText="Password">
                <ItemStyle CssClass="ktb23" />
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
            SelectMethod="getUserData" TypeName="ClsDB"></asp:ObjectDataSource>
        <br />
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

