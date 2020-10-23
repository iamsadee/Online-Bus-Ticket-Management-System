using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace BusTicket
{
    public partial class addbus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String from = DropDownList1.SelectedItem.Text;
            String to = DropDownList2.SelectedItem.Text;
            String date = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
            if (from!=to && date !="01/01/0001")
            {
                SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
                con.Open();
                Random rnd = new Random();
                int i = rnd.Next(100000, 999999);
                String company = TextBox1.Text;
                String coachno =company+i.ToString()+"K";
                String time = TextBox2.Text;
                String counter = TextBox4.Text;
                int fare =Convert.ToInt32(TextBox5.Text);
                String type = DropDownList3.SelectedItem.Text;
                
                SqlCommand cm = new SqlCommand();
                String s = "insert into busbook" + " values ('" + company + "','" + date + "','" + time + "','" + coachno + "','" + from + "','" + counter + "','" + to +" ', " +fare +",'"+ type +"',"+ 40 +",'" + "')";
                cm.Connection = con;
                cm.CommandType = CommandType.Text;
                cm.CommandText = s;
                cm.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Bus Added Successfully');window.location = 'addbus.aspx';</script>");
            }
            else if(date=="01/01/0001")
            {
                Response.Write("<script>alert('Select Departing Date')</script>");
            }
            else
            {
                Response.Write("<script>alert('Source & Destination Are Same')</script>");
            }
        }
    }
}