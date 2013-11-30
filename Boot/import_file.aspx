<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="import_file.aspx.vb" Inherits="import_file" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:20px 0px 0px 20px">
        <asp:FileUpload ID="ExceFile" runat="server" />
        <br><br>
        <asp:Button ID="SaveBt" runat="server" Text="Import" />
        <br><br>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
        <span style="color:#cc0000;">Import complete..</span>
         </asp:Panel>
    </div>
</asp:Content>

