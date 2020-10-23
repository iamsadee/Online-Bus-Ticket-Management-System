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
    public partial class buyPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = Session["user"].ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
            conn.Open();
            DataTable dtt = new DataTable();
            String Qu = "select balance from balance where username='" + Session["user"] + "'";
            SqlCommand cmd = new SqlCommand(Qu, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            dtt.Load(sdr);
            String bal = dtt.Rows[0][0].ToString();
            int balance=Convert.ToInt32(bal);
            String chos=DropDownList1.SelectedItem.Text;
            String trx = paytrxText.Text;
            if (trx==null)
            {
                Response.Write("<script>alert('Give Payment Trx ID')</script>");
            }
            else {
                if (chos.Equals("Get 30 TK Extra on Pay Of 1000 TK"))
                {
                    balance += 1030;
                    Qu = "update balance set balance= "+ balance+" where username='" + Session["user"] + "'";
                    cmd = new SqlCommand(Qu, conn);
                    sdr = cmd.ExecuteReader();
                    Response.Redirect("Afterlogin.aspx");
                }
                else if (chos.Equals("Get 150 TK Extra on Pay Of 3000 TK"))
                {
                    balance += 3150;
                    Qu = "update balance set balance= " + balance + " where username='" + Session["user"] + "'";
                    cmd = new SqlCommand(Qu, conn);
                    sdr = cmd.ExecuteReader();
                    Response.Redirect("Afterlogin.aspx");
                }
                else if (chos.Equals("Get 300 TK Extra on Pay Of 5500 TK"))
                {
                    balance += 5800;
                    Qu = "update balance set balance= " + balance + " where username='" + Session["user"] + "'";
                    cmd = new SqlCommand(Qu, conn);
                    sdr = cmd.ExecuteReader();
                    Response.Redirect("Afterlogin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Choose Package')</script>");
                }
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String chos = DropDownList1.SelectedItem.Text;
            if (chos.Equals("Get 30 TK Extra on Pay Of 1000 TK"))
            {
                TextBox1.Text = "1000";
            }
            else if (chos.Equals("Get 150 TK Extra on Pay Of 3000 TK"))
            {
                TextBox1.Text = "3000";
            }
            else if (chos.Equals("Get 300 TK Extra on Pay Of 5500 TK"))
            {
                TextBox1.Text = "5500";
            }
        }
    }
}