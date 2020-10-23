<%@ Page Title="" Language="C#" MasterPageFile="~/masteradmin.Master" AutoEventWireup="true" CodeBehind="removebus.aspx.cs" Inherits="BusTicket.removebus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .div1
        {
            height:700px;
            width:100%;
            background-color:#66b3ff;
            background-image: url('Image/low-poly-texture-120-roundedhexagon-wwallpaper.png');
        }
        .auto-style10 {
            height: 39px;
        }
        .auto-style11 {
            text-align: right;
            height: 41px;
        }
        .auto-style12 {
            height: 39px;
            text-align: right;
        }
        .auto-style13 {
            font-weight: bold;
            font-size: x-small;
            margin-left: 0px;
        }
        .auto-style14 {
            width: 100%;
            height: 115px;
        }
        .footer
{
    height:50px;
    background-color:rgb(10,110,178);
    color:rgb(255,255,255);
        border-radius:5px 5px 5px 5px;

}
.footer h2
{
    padding:15px;
    text-align:center;

}
        .auto-style15 {
            text-align: right;
            height: 52px;
        }
        .auto-style16 {
            height: 52px;
        }
        .auto-style17 {
            height: 41px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div1">

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table class="auto-style14">
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Select Date :"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style10">
                    <strong>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="24px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="135px">
     <asp:ListItem Text="Select" Value="Select" />
</asp:DropDownList>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" Text="Select Time : "></asp:Label>
                &nbsp;&nbsp;
                </td>
                <td class="auto-style17">
                    <strong>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="18px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="133px">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style16">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
                    <asp:Button ID="Button3" runat="server" CssClass="auto-style13" Height="25px" OnClick="Button3_Click" Text="Remove" Width="78px" />
                    </strong></td>
            </tr>
        </table>

    </div>
    <div class="footer">
            <h2>Copyright@ZeroService 2019 </h2>
        </div>
</asp:Content>
