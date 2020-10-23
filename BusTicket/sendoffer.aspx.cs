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
    public partial class sendoffer : System.Web.UI.Page
    {
        static int totalemailsent;
        private void countRegistration()
        {

            String mycon = "Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True";
            String myquery = "Select count(*) from signup";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            Label5.Text = ds.Tables[0].Rows[0][0].ToString();
            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            countRegistration();
            totalemailsent = 0;
        }
        private void sendemail(String emailid, String cname, String subject, String message)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("zeroserviceasp@gmail.com", "project16038");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = subject;
            msg.Body = "Dear " + cname + " " + message + "\n\n\nThanks & Regards\nZero Service Team";
            string toaddress = emailid;
            msg.To.Add(toaddress);
            string fromaddress = "Zero Service <zeroserviceasp@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);
                totalemailsent = totalemailsent + 1;

            }
            catch
            {
                throw;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String mycon = "Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True";
            String myquery = "Select Email,UserName from signup";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int rowcounter = ds.Tables[0].Rows.Count;
            int i = 0;
            while (i < rowcounter)
            {

                sendemail(ds.Tables[0].Rows[i]["Email"].ToString(), ds.Tables[0].Rows[i]["UserName"].ToString(), TextBox1.Text, TextBox2.Text);
                i++;
            }
            String tmp = "Total Emails " + totalemailsent + " Sent to Registered Customer Successfully";
            Response.Write("<script>alert('Offer Email Send To All User');window.location = 'addbus.aspx';</script>");
        }
    }
}