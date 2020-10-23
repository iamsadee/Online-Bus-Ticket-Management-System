<%@ Page Title="" Language="C#" MasterPageFile="~/masteradmin.Master" AutoEventWireup="true" CodeBehind="sendoffer.aspx.cs" Inherits="BusTicket.sendoffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .div1{
           height:700px;
            width:100%;
            background-color:#66b3ff;
            background-image: url('Image/low-poly-texture-120-roundedhexagon-wwallpaper.png');
        }
        .auto-style10 {
            font-size: x-large;
        }
        .auto-style11 {
            text-align: right;
            width: 496px;
        }
        .auto-style12 {
            width: 496px;
            height: 60px;
        }
        .auto-style13 {
            font-size: large;
        }
        .auto-style14 {
            text-align: left;
            height: 60px;
        }
        .auto-style15 {
            width: 100%;
            height: 360px;
            margin-bottom: 0px;
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
        <br />
        <br />
        <table class="auto-style15">
            <tr>
                <td class="auto-style11"><strong>
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style10" Text="Total User : "></asp:Label>
                    </strong></td>
                <td><strong>
                    <asp:Label ID="Label5" runat="server" CssClass="auto-style13"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style11"><strong>
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style10" Text="Subject : "></asp:Label>
                    </strong></td>
                <td><strong>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style13" Height="27px" Width="304px"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style11"><strong>
                    <asp:Label ID="Label4" runat="server" CssClass="auto-style10" Text="Offer Message : "></asp:Label>
                    </strong></td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="253px" Width="307px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style14">&nbsp;&nbsp; <strong>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" CssClass="auto-style13" OnClick="Button3_Click" Text="Send Offer" />
                    </strong></td>
            </tr>
        </table>

    </div>
    <div class="footer">
            <h2>Copyright@ZeroService 2019 </h2>
        </div>
</asp:Content>
