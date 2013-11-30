<%@ Page Language="VB" AutoEventWireup="false" CodeFile="log_in.aspx.vb" Inherits="log_in" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Login Page</title>
<style type="text/css">
    body{
        background:url(img/bg_log.jpg) #0f1844 top center no-repeat;
        }
        
</style>
</head>
<body>
    <form id="form_index" runat="server">
        <div id="main" style="margin:0 auto; width:280px;">
        <div style="margin-top:390px; text-align: center;">
        <div style="background-color:#FFFFFF;border:1px solid #0977ff;padding:25px 0px 15px 17px;">
        <table>
            <tbody>
                <tr>
                    <td align="center" style="text-align: right">
                        <asp:Label ID="lbl_username" runat="server" Text="Username : " 
                            ForeColor="#003366" Font-Bold="False" Font-Size="14px" Font-Names="Arial"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txt_username" runat="server" Width="150px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="text-align: right">
                    </td>
                    <td style="text-align: left">
                        <asp:RequiredFieldValidator ID="rfv_username" runat="server" ControlToValidate="txt_username"
                            Display="Dynamic" ErrorMessage="Username is require !!!"
                            SetFocusOnError="True" Font-Size="12px" ForeColor="#FF3300" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="text-align: right">
                        <asp:Label ID="lbl_password" runat="server" Text="Password : " 
                            ForeColor="#003366" Font-Bold="False" Font-Size="14px" Font-Names="Arial"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txt_password" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="text-align: left">
                        <asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="txt_password"
                            Display="Dynamic" ErrorMessage="Password is require !!!"
                            SetFocusOnError="True" Font-Size="12px" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="padding:5px 0px 0px 15px;text-align:center;"><asp:Button ID="btn_submit" runat="server" Text="Login" /></div>
                    </td>
                </tr>
                              
            </tbody>
        </table>
            </div>
        <div style="color:#fd4100;padding-top: 8px; padding-bottom: 10px; font-family: Tahoma,Arial, Helvetica, sans-serif; font-size: 14px; font-weight: bold;">
        Store Contribution Report</div>
       </div>
    </div>
    </form>
</body>
</html>
