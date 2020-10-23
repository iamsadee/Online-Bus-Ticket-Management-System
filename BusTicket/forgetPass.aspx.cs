using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
namespace BusTicket
{
    public partial class forgetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void sendpassword(String password, String email,String user)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("zeroserviceasp@gmail.com", "project16038");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Forgot Password ( Zero Service )";
            msg.Body = "Dear " + user + ", Your Password is  " + password + "\n\n\nThanks & Regards\nZero Service Team";
            string toaddress = email;
            msg.To.Add(toaddress);
            string fromaddress = "Zero Service <zeroserviceasp@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);


            }
            catch
            {
                throw;
            }
        }

        protected void sendB_Click(object sender, EventArgs e)
        {
            String password;
            String username = TextBox1.Text;
            if (username != "")
            {
                SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
                conn.Open();
                String myquery = "Select * from signup where UserName='" + TextBox1.Text + "'";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Label3.Text = "Data Found";

                    password = ds.Tables[0].Rows[0]["Password"].ToString();
                    String email = ds.Tables[0].Rows[0]["Email"].ToString();
                    sendpassword(password, email, username);
                    //Label3.Text = "Your Password Has Been Sent to Registered Email Address. Check Your Mail Inbox";
                    Response.Write("<script>alert('Your Password Has Been Sent to Registered Email Address.')</script>");
                    Response.Redirect("signin.aspx");
                }
                else
                {
                    //Label3.Text = "Your Username is Not Valid or Email Not Registered";
                    Response.Write("<script>alert('Your Username is Not Valid ')</script>");

                }
                conn.Close();
            }
            else
            {
                Response.Write("<script>alert('Give UserName')</script>");
            }
        }
    }
}