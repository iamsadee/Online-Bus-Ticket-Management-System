<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogin.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="BusTicket.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .div1
        {
            height:700px;
            width:100%;
            background-color:#66b3ff;
            background-image: url('Image/low-poly-texture-120-roundedhexagon-wwallpaper.png');
        }
        .auto-style9 {
            margin-left: 40%;
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
        <div>
        &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/Image/Capture.JPG" Height="213px" Width="268px"  CssClass="auto-style9" />
   
</div>
        <h2>
            Zero Service Online Bus Booking System Developed By Sadee Ibn Sultan , CSE , MBSTU </br>
            It is done only for Project purpose . </br >
            My Project Cordinator is : </br>
            Md.Mahfuz Reza Sir</br >
Assistant Professor  </br >
Dept of CSE           </br >
MBSTU.</br >

        </h2>   
             </div>
    <div class="footer">
            <h2>Copyright@ZeroService 2019 </h2>
        </div>
    
</asp:Content>
