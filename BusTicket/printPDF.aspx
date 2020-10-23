<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="printPDF.aspx.cs" Inherits="BusTicket.printPDF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">   
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="height: 100px;width: 100%; text-align: center;">
        <img src="F:\Project\BusTicket\BusTicket\Image\Capture.JPG" alt="Zero" style="width:100px;height:100px;">
    </div>
        <div style="height: 120px; width: 100%;">
            <div style="height: 120px;width: 50%;float:left;">

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <strong>
            <asp:Label ID="Label1" runat="server"  Text="Order No: " CssClass="auto-style10" style="font-size: small"></asp:Label>
                </strong>&nbsp;&nbsp; <strong>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style10" style="font-size: small"></asp:Label>
&nbsp;&nbsp; </strong>&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <strong>
            <asp:Label ID="Label2" runat="server"  Text="Company Name: " CssClass="auto-style10" style="font-size: small"></asp:Label>
                </strong>&nbsp;&nbsp;&nbsp;&nbsp;
            <strong>
            <asp:Label ID="Label4" runat="server" Text="Zero Service" CssClass="auto-style10" style="font-size: small"></asp:Label>
                </strong>&nbsp;<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <strong>
            <asp:Label ID="Label5" runat="server"  Text="Date : " CssClass="auto-style10" style="font-size: small"></asp:Label>
            </strong>&nbsp;&nbsp;
            <strong>
            <asp:Label ID="Label6" runat="server" CssClass="auto-style10" style="font-size: small"></asp:Label>


            </strong>
                </div>
            <div style="height: 120px;width: 50%;float: left;text-align: right;">

            </div>


        </div>
        <div style="width:100%;height:500px;">

            <table style="width:100%;">
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label7" runat="server" Text="Name: " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label20" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label8" runat="server" Text="Gender : " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label21" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label9" runat="server" Text="Mobile :  " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="height: 23px; text-align: left; font-size: small;"><strong>
                        <asp:Label ID="Label22" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label10" runat="server" Text="Journey Date : " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label23" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label11" runat="server" Text="From :" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label24" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label12" runat="server" Text="To : " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label25" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label13" runat="server" Text="Departure Time : " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label26" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label14" runat="server" Text="Take Off  :" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label27" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label15" runat="server" Text="Seat Fare :" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label28" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label16" runat="server" Text="Total Fare : " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label29" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label17" runat="server" Text="Seat No :" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label30" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label18" runat="server" Text="Coach Type : " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label31" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; font-size: small;"><strong>
                        <asp:Label ID="Label19" runat="server" Text="Coach No : " CssClass="auto-style10"></asp:Label>
                        </strong></td>
                    <td style="text-align: left;font-size: small;"><strong>
                        <asp:Label ID="Label32" runat="server" CssClass="auto-style10"></asp:Label>
                        </strong></td>
                </tr>
            </table>

        </div>
    </div>
        </form>
</body>
</html>
