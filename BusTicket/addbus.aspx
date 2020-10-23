<%@ Page Title="" Language="C#" MasterPageFile="~/masteradmin.Master" AutoEventWireup="true" CodeBehind="addbus.aspx.cs" Inherits="BusTicket.addbus" %>
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
            width: 100%;
        }
        .auto-style10 {
            font-weight: bold;
            font-size: medium;
        }
        .auto-style12 {
            text-align: right;
            width: 452px;
            height: 6px;
        }
        
        .auto-style13 {
            text-align: justify;
            height: 6px;
        }
        
        .auto-style14 {
            font-size: medium;
        }
        .auto-style16 {
            font-weight: bold;
            text-align: right;
            width: 452px;
            font-size: medium;
        height: 4px;
    }
        
    .auto-style18 {
        width: 100%;
        height: 526px;
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
        .auto-style20 {
            font-weight: bold;
            text-align: right;
            width: 452px;
            height: 5px;
        }
        .auto-style31 {
            text-align: justify;
            font-size: medium;
            height: 10px;
        }
        .auto-style33 {
            height: 683px;
            width: 100%;
            background-color: #00ccff;
            background-image: url('Image/low-poly-texture-120-roundedhexagon-wwallpaper.png');
        }
        .auto-style35 {
            text-align: justify;
            font-size: medium;
            height: 7px;
        }
        .auto-style41 {
            text-align: justify;
            font-size: medium;
            height: 5px;
        }
        .auto-style43 {
            text-align: justify;
            font-size: medium;
            height: 6px;
        }
        .auto-style45 {
        font-weight: bold;
        text-align: right;
        width: 452px;
        height: 7px;
    }
    .auto-style46 {
        font-weight: bold;
        text-align: right;
        width: 452px;
        height: 8px;
    }
    .auto-style47 {
        text-align: justify;
        font-size: medium;
        height: 8px;
    }
    .auto-style48 {
        font-weight: bold;
        text-align: right;
        width: 452px;
        height: 6px;
    }
    .auto-style49 {
        font-weight: bold;
        text-align: right;
        width: 452px;
        height: 10px;
    }
        .auto-style51 {
            text-align: justify;
            font-size: medium;
            height: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style33" >

        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="auto-style18">
            <tr>
                <td class="auto-style12">
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Company Name : " CssClass="auto-style10"></asp:Label>
                </td>
                <td class="auto-style43"><strong><span class="auto-style14">&nbsp;&nbsp;</span><asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="237px" CssClass="auto-style14"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp; 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="* Fill Company Name" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style48">
                    <asp:Label ID="Label3" runat="server" Text="Departing Date : " CssClass="auto-style14"></asp:Label>
                </td>
                <td class="auto-style13">
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20">
                    <asp:Label ID="Label4" runat="server" Text="Departing Time : " CssClass="auto-style14"></asp:Label>
                </td>
                <td class="auto-style41"><strong>
                    <asp:TextBox ID="TextBox2" runat="server" Width="250px" CssClass="auto-style14"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="* Fill Departing Time" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </strong></td>
            </tr>
            
            <tr>
                <td class="auto-style45">
                    <asp:Label ID="Label6" runat="server" Text="From :" CssClass="auto-style14"></asp:Label>
                </td>
                <td class="auto-style35"><strong>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="District" DataValueField="District" CssClass="auto-style14">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project3rdConnectionString %>" SelectCommand="SELECT [District] FROM [Dist]"></asp:SqlDataSource>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style46">
                    <asp:Label ID="Label7" runat="server" Text="To : " CssClass="auto-style14"></asp:Label>
                </td>
                <td class="auto-style47"><strong>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="District" DataValueField="District" CssClass="auto-style14">
                    </asp:DropDownList>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style48">
                    <asp:Label ID="Label8" runat="server" Text="Starting Counter : " CssClass="auto-style14"></asp:Label>
                </td>
                <td class="auto-style43"><strong>
                    <asp:TextBox ID="TextBox4" runat="server" Width="250px" CssClass="auto-style14"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="* Fill Starting Counter" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style20">
                    <asp:Label ID="Label9" runat="server" Text="Fare : " CssClass="auto-style14"></asp:Label>
                </td>
                <td class="auto-style41"><strong>
                    <asp:TextBox ID="TextBox5" runat="server" Width="250px" CssClass="auto-style14"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="* Fare Cant be blank" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style49">
                    <asp:Label ID="Label10" runat="server" Text="Coach Type : " CssClass="auto-style14"></asp:Label>
                </td>
                <td class="auto-style31"><strong>
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="auto-style14" Width="259px">
                        <asp:ListItem>AC</asp:ListItem>
                        <asp:ListItem>Non-AC</asp:ListItem>
                    </asp:DropDownList>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style16"></td>
                <td class="auto-style51"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" CssClass="auto-style10" OnClick="Button3_Click" Text="ADD" />
                    </strong></td>
            </tr>
        </table>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   

    </div> 
    <div class="footer">
            <h2>Copyright@ZeroService 2019 </h2>
        </div>
</asp:Content>
