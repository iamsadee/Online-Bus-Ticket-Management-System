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
    public partial class removebus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
                string com = "Select distinct Departing_Date from busbook";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "Departing_Date";
                DropDownList1.DataBind();
                con.Close();
                chk();
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void chk()
        {
            String x = DropDownList1.SelectedItem.Text;
            SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
            string com = "Select distinct Departing_Time from busbook where Departing_Date= '" + x + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Departing_Time";
            DropDownList2.DataValueField = "Departing_Time";
            DropDownList2.DataBind();
            con.Close();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String x = DropDownList1.SelectedItem.Text;
            SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
            string com = "Select distinct Departing_Time from busbook where Departing_Date= '"+ x +"'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Departing_Time";
            DropDownList2.DataValueField = "Departing_Time";
            DropDownList2.DataBind();
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
            con.Open();
            SqlCommand cm = new SqlCommand();
            String s = "delete busbook where Departing_Date= '"+DropDownList1.SelectedItem.Text+"' and Departing_Time= '"+DropDownList2.SelectedItem.Text+"'";
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = s;
            cm.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Bus Removed Successfully');window.location = 'removebus.aspx';</script>");
        }
    }
}