using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusTicket
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                slide();
            }
            
        }
        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            slide();
        }
        protected void slide()
        {
            Random r = new Random();
            int a = r.Next(1,3);
            Image1.ImageUrl = "~/Image/" + a.ToString() +".jpg";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}