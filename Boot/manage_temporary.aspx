<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="manage_temporary.aspx.vb" Inherits="manage_temporary" %>

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
    <div><strong>Manage Temporary Closed</strong><br /><br /></div>
    <div style="padding:10px 0px;">Store : <asp:DropDownList ID="ddlstore" 
            runat="server" CssClass="select2" AutoPostBack="True"></asp:DropDownList></div>
    <div><asp:Button ID="AddNewBt" runat="server" Text="Add New Temporary Closed" /></div>
    <asp:Panel ID="Panel1" runat="server">
            <div style="padding-top:15px;">
                    <strong><asp:Label ID="AddTxt" runat="server" CssClass="lbtitle" Text="Add"></asp:Label></strong>
            </div>
            <div style="padding:5px 0 15px 0;"> 
                <div style="float:left;margin-left:10px;">
                    Start <asp:TextBox ID="TxtOpendt" runat="server" CssClass="inputbox45" />
                </div>
                <div style="float:left;">
                    <cc1:CalendarExtender ID="TxtOpendt_CalendarExtender" runat="server" 
                    TargetControlID="TxtOpendt" Format="d/M/yyyy" PopupButtonID="ImageBt1" >
                    </cc1:CalendarExtender>
                     &nbsp;<asp:ImageButton ID="ImageBt1" runat="server" ImageUrl="img/calendar-day.png" Width="20px" Height="20px"/>
                </div>
                 <div style="float:left;margin-left:5px;">
                    End <asp:TextBox ID="TxtEnddt" runat="server" CssClass="inputbox45" />
                </div>
                <div style="float:left;">
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="TxtEnddt" Format="d/M/yyyy" PopupButtonID="ImageBt2" >
                    </cc1:CalendarExtender>
                     &nbsp;<asp:ImageButton ID="ImageBt2" runat="server" ImageUrl="img/calendar-day.png" Width="20px" Height="20px"/>
                </div>
                 <div style="float:left;margin-left:10px;">
                     <asp:Button ID="AddBt" runat="server" Text="Save" />
                </div>
                <div style="clear:both;"></div>
            </div>
    </asp:Panel>
     <asp:Panel ID="Panel2" runat="server">
            <div style="padding-top:15px;">
                    <strong><asp:Label ID="Label1" runat="server" CssClass="lbtitle" Text="Edit"></asp:Label></strong>
            </div>
            <div style="padding:5px 0 15px 0;"> 
                <div style="float:left;margin-left:10px;">
                    Start <asp:TextBox ID="TxtEOpendt" runat="server" CssClass="inputbox45" />
                </div>
                <div style="float:left;">
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                    TargetControlID="TxtEOpendt" Format="d/M/yyyy" PopupButtonID="ImageButton1" >
                    </cc1:CalendarExtender>
                     &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/calendar-day.png" Width="20px" Height="20px"/>
                </div>
                 <div style="float:left;margin-left:5px;">
                    End <asp:TextBox ID="TxtEEnddt" runat="server" CssClass="inputbox45" />
                </div>
                <div style="float:left;">
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                    TargetControlID="TxtEEnddt" Format="d/M/yyyy" PopupButtonID="ImageButton2" >
                    </cc1:CalendarExtender>
                     &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/calendar-day.png" Width="20px" Height="20px"/>
                </div>
                 <div style="float:left;margin-left:10px;">
                     <asp:Button ID="EditBt" runat="server" Text="Update" /><asp:HiddenField ID="HdID" runat="server" />
                </div>
                <div style="clear:both;"></div>
            </div>
    </asp:Panel>
    <div style="padding-top:10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" CssClass="CusTab" BorderColor="White" 
            BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" 
            DataKeyNames="tempc_id">
            <Columns>
               <asp:BoundField DataField="tempc_start" HeaderText="Start Date" 
                    DataFormatString="{0:d/M/yyyy}" NullDisplayText="None">
                <ItemStyle CssClass="ktb1" />
                </asp:BoundField>
                 <asp:BoundField DataField="tempc_finish" HeaderText="End Date" DataFormatString="{0:d/M/yyyy}" NullDisplayText="None">
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
            SelectMethod="getTempcById" TypeName="ClsDB" 
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


