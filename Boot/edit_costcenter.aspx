<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="edit_costcenter.aspx.vb" Inherits="edit_costcenter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="padding:20px 0px 0px 20px;">
    <div><strong>Edit Cost Center</strong><br /><br /></div>
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Code :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TxtCode" runat="server" CssClass="inputbox4"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Name :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TxtName" runat="server" CssClass="inputbox5"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Store :</div>
        <div style="float:left;width:200px;padding-left:20px;">
            <asp:DropDownList ID="ddlStore" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <div style="clear:both;"></div>
    </div>
     <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Location :</div>
        <div style="float:left;width:200px;padding-left:20px;">
            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Province :</div>
        <div style="float:left;width:200px;padding-left:20px;">
            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Area :</div>
        <div style="float:left;width:200px;padding-left:20px;">
            <asp:DropDownList ID="ddlArea" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Market :</div>
        <div style="float:left;width:200px;padding-left:20px;">
            <asp:DropDownList ID="ddlMarket" runat="server" CssClass="select2">
            </asp:DropDownList>
        </div>
        <div style="clear:both;"></div>
    </div>
     <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Total Area (sqm) :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TxtTotal" runat="server" CssClass="inputbox4"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
     <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Sale Area (sqm) :</div>
        <div style="float:left;width:200px;padding-left:20px;"><asp:TextBox ID="TxtSale" runat="server" CssClass="inputbox4"></asp:TextBox></div>
        <div style="clear:both;"></div>
    </div>
     <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Open Date :</div>
        <div style="float:left;width:300px;padding-left:20px;"> 
            <div style="float:left;">
                <asp:TextBox ID="TxtOpendt" runat="server" CssClass="inputbox4" />
            </div>
            <div style="float:left;">
                <cc1:CalendarExtender ID="TxtOpendt_CalendarExtender" runat="server" 
                TargetControlID="TxtOpendt" Format="d/M/yyyy" PopupButtonID="ImageBt1" >
                </cc1:CalendarExtender>
            </div>
&nbsp;<asp:ImageButton ID="ImageBt1" runat="server" ImageUrl="img/calendar-day.png" Width="20px" Height="20px"/>
            <div style="clear:both;"></div>
         </div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Remark :</div>
        <div style="float:left;width:200px;padding-left:20px;">
            <asp:TextBox ID="RemarkTxt" runat="server" Height="47px" TextMode="MultiLine" 
                Width="191px" style="border:#587c8a 1px solid;"></asp:TextBox>
        </div>
        <div style="clear:both;"></div>
    </div>
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Blocked :</div>
        <div style="float:left;width:200px;padding-left:20px;">
            <asp:DropDownList ID="ddlblock" runat="server" CssClass="select2" AutoPostBack="True">
                <asp:ListItem Value="Y">YES</asp:ListItem>
                <asp:ListItem Value="N">NO</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="clear:both;"></div>
    </div>
    <asp:Panel ID="Pbl" runat="server">
    <div style="padding-top:10px;">
        <div style="float:left;width:150px;text-align:right;padding-top:2px;">Blocked Date :</div>
        <div style="float:left;width:200px;padding-left:20px;">
            <div style="float:left;">
                <asp:TextBox ID="TxtBlockdt" runat="server" CssClass="inputbox4" />
            </div>
            <div style="float:left;">
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                TargetControlID="TxtBlockdt" Format="d/M/yyyy" PopupButtonID="ImageButton2" >
                </cc1:CalendarExtender>
            </div>
&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/calendar-day.png" Width="20px" Height="20px"/>
            <div style="clear:both;"></div> 
        </div>
        <div style="clear:both;"></div>
    </div>
    </asp:Panel>
     <div style="padding-top:25px;">
        <div style="text-align:left;">
            <asp:Button ID="SaveBt" runat="server" Text="Update" /> 
            <asp:Button ID="CancelBt" runat="server" Text="Cancel" />
        </div>
    </div>
</div>
</asp:Content>

