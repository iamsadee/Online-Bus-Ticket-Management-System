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
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String user = userText.Text;
            String email = emailText.Text;
            String sss = "select count(UserName) from signup where UserName='" + user + "'";
            String ss = "select count(Email) from signup where Email='" + email + "'";
            SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
            SqlCommand myCommand = new SqlCommand(sss, con);
            myCommand.Connection.Open();
            SqlCommand Command = new SqlCommand(ss, con);
            //Command.Connection.Open();
            int a = (int)myCommand.ExecuteScalar();
            int b = (int)Command.ExecuteScalar();
            if (a == 0 && b == 0)
            {
                SqlCommand cm = new SqlCommand();
                String s = "insert into signup" + " values ('" + nameText.Text + "','" + emailText.Text + "','" + userText.Text + "','" + passText.Text + "','" + addressText.Text + "','" + sexCombo.SelectedItem.Value + "','" + mobText.Text + "')";
                cm.Connection = con;
                cm.CommandType = CommandType.Text;
                cm.CommandText = s;
                cm.ExecuteNonQuery();
                cm = new SqlCommand();
                s = "insert into balance values('"+user+"', 0 )";
                cm.Connection = con;
                cm.CommandType = CommandType.Text;
                cm.CommandText = s;
                cm.ExecuteNonQuery();
                Response.Write("<script>alert('Registration Done Successfully');window.location = 'Home.aspx';</script>");
                //Response.Redirect("~/Default.aspx");
                //MessageBox.Show("Registration Done Successfully");
            }
            else
            {
                if (b == 0) Response.Write("<script>alert('Give Unique UserName')</script>");
                else if (a == 0) Response.Write("<script>alert('Give Unique Email')</script>");
                else Response.Write("<script>alert('Give Unique UserName And Password')</script>");
            }
            con.Close();
        }
    }
}