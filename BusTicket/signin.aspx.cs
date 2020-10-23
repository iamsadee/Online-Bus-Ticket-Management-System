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
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String user = userText.Text;
            String pass = passText.Text;
            if(user=="admin" && pass == "admin") {

                Response.Redirect("addbus.aspx");
            }
            else if (user != "")
            {
                //String ss = "select count(UserName) from signup where UserName='" + user + "'";
                String sss = "select Password from signup where UserName='" + user + "'";
                SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
                SqlCommand myCommand = new SqlCommand(sss, con);
                myCommand.Connection.Open();
                //Command.Connection.Open();
                String a = myCommand.ExecuteScalar().ToString();
                if (a == pass && user != "")
                {
                    Response.Write("<script>alert('Login Done')</script>");
                    Session["user"] = userText.Text;
                    Response.Redirect("Afterlogin.aspx");
                    
                }
                else
                {
                    Response.Write("<script>alert('No Account Found . Please Register')</script>");
                }
                con.Close();
            }
        }
    }
}