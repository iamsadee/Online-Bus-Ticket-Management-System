using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
namespace BusTicket
{
    public partial class masterPage3 : System.Web.UI.MasterPage
    {
        String tarikh;
        static int[] bookedseat;
        static int[] tempbookseat;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                slide();
                bookedseat = new int[45];
                tempbookseat = new int[45];
            }
            if(Session["user"]!=null)
            {
                welcomeLabel.Text = "Welcome " + Session["user"].ToString();
            }

        }
        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            slide();
        }
        protected void slide()
        {
            Random r = new Random();
            int a = r.Next(1, 3);
            Image1.ImageUrl = "~/Image/" + a.ToString() + ".jpg";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void src_btn_Click(object sender, EventArgs e)
        {
            //export();
            String leave = leavingdrop.SelectedItem.Value;
            Session["leave"]= leave;
            tarikh = date.SelectedDate.ToString("MM/dd/yyyy");
            String going = goingdrop.SelectedItem.Value;
            Session["going"] = going;
            String coach = coachdrop.SelectedItem.Value;
            Session["coach"]=coach ;
            Session["tarikh"] = tarikh;
            string query = "select  Company_Name,Departing_Time,Coach_No,Leaving_From,Starting_Counter,Going_To,Fare,Coach_Type,Seat_Available from busbook where Leaving_From='" + leave + "' AND Coach_Type='" + coach + "' AND Going_To='" + going + "' AND Departing_Date='" + tarikh + "'";
            BlindData(query);

        }
        protected void BlindData(String query)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                
                //String query = "select Company_Name,Departing_Time,Coach_No,Leaving_From,Starting_Counter,Going_To,Fare,Coach_Type,Seat_Available from busbook where Leaving_From='" +leave+"' AND Going_To='" + going + "' AND Departing_Date='" + tarikh + "' Coach_Type='" + coach + "'";
                
                con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch {
               
            }
            finally
            {
                dt.Dispose();
                con.Close();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String coach = GridView1.SelectedRow.Cells[3].Text.ToString();
            Session["coach"] = coach;
            SqlConnection conn= new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
            conn.Open();
            DataTable dtt = new DataTable();
            tarikh = Session["tarikh"].ToString();
            String Qu = "select Book_Seat,Fare,Departing_Time,Coach_Type,Starting_Counter,Seat_Available from busbook where Departing_Date='" + tarikh+"' and Coach_No='"+coach+"'";
            SqlCommand cmd = new SqlCommand(Qu, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            dtt.Load(sdr);
            String seat = dtt.Rows[0][0].ToString();
            String bhara = dtt.Rows[0][1].ToString();
            Session["seat"] = seat;
            Session["bhara"] = bhara;
            Session["depart"] = dtt.Rows[0][2].ToString();
            Session["coachType"] = dtt.Rows[0][3].ToString();
            Session["startplace"] = dtt.Rows[0][4].ToString();
            Session["seatavailable"] = dtt.Rows[0][5].ToString();
           //naamText.Text = bhara;
            conn.Close();
            for(int i=1;i<=40;i++)
            {
                tempbookseat[i] = 0;
                bookedseat[i] = 0;
            }
            String[] tempArr = new String[45];
            int j = 1;
            String tmp = null;
            String ano = null;
            String ki = null;
            String sit = seat;
            for (int i = 0; i < sit.Length; i++)
            {
                ano += sit[i];
                if (i % 2 == 1)
                {
                    tmp += sit[i];
                    tempArr[j] = tmp;
                    ki += tmp;
                    j++;
                    tmp = null;
                }
                else tmp += sit[i];
            }
            //busseat.Text = cnt.ToString();
            already_booked();
           
            ModalPopupExtender1.Show();
        }
        protected void ocultarModalCommand(Object sender, EventArgs e)
        {
             ModalPopupExtender1.Hide();
        }
        protected void already_booked()
        {
            seatNoText.Text = "";
            fareText.Text = "";
            userNameText.Text = Session["user"].ToString();
            SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
            conn.Open();
            DataTable dtt = new DataTable();
            String username = Session["user"].ToString();
            String Qu = "select Name,Mob,Sex from signup where UserName='" + username + "'";
            SqlCommand cmd = new SqlCommand(Qu, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            dtt.Load(sdr);
            String bookernaam = dtt.Rows[0][0].ToString();
            String mobnum = dtt.Rows[0][1].ToString();
            Session["gender"] = dtt.Rows[0][2].ToString();
            Session["naam"] = bookernaam;
            naamText.Text = bookernaam;
            mobileText.Text = mobnum;
            Session["mobnum"] = mobnum;
            Random ran = new Random();
            int number = ran.Next(999999,100000000);
            String TicketNo = "EP"+ number.ToString();
            Session["ticketNo"] = TicketNo;
            ticketnumText.Text = TicketNo;
            String bkash = "Make Bkash Payment To +8801515294513 To Counter No: 1";
            bkashLabel.Text = bkash;
            String sit = Session["seat"].ToString();
            int cnt = (sit.Length)/2;
            String[] tempArr=new String[45];
            int j = 1;
            String tmp=null;
            String ano = null;
            String ki = null;
            for(int i=0;i<sit.Length;i++)
            {
                ano += sit[i];
                if (i % 2 == 1)
                {
                    tmp += sit[i];
                    tempArr[j] = tmp;
                    ki += tmp;
                    j++;
                    tmp = null;
                }
                else tmp += sit[i];
            }
            
            for(int k=1;k< j;k++)
            {
                if(tempArr[k]=="A1")
                {
                    bookedseat[1]= 1;
                    A1.BackColor = System.Drawing.Color.Red;
                    A1.Enabled = false;
                }
                else if(tempArr[k]=="A2")
                {
                    bookedseat[2] = 1;
                    A2.BackColor = System.Drawing.Color.Red;
                    A2.Enabled = false;
                }
                else if (tempArr[k] == "A3")
                {
                    bookedseat[3] = 1;
                    A3.BackColor = System.Drawing.Color.Red;
                    A3.Enabled = false;
                }
                else if (tempArr[k] == "A4")
                {
                    bookedseat[4] = 1;
                    A4.BackColor = System.Drawing.Color.Red;
                    A4.Enabled = false;
                }
                else if (tempArr[k] == "B1")
                {
                    bookedseat[5] = 1;
                    B1.BackColor = System.Drawing.Color.Red;
                    B1.Enabled = false;
                }
                else if (tempArr[k] == "B2")
                {
                    bookedseat[6] = 1;
                    B2.BackColor = System.Drawing.Color.Red;
                    B2.Enabled = false;
                }
                else if (tempArr[k] == "B3")
                {
                    bookedseat[7] = 1;
                    B3.BackColor = System.Drawing.Color.Red;
                    B3.Enabled = false;
                }
                else if (tempArr[k] == "B4")
                {
                    bookedseat[8] = 1;
                    B4.BackColor = System.Drawing.Color.Red;
                    B4.Enabled = false;
                }
                else if (tempArr[k] == "C1")
                {
                    bookedseat[9] = 1;
                    C1.BackColor = System.Drawing.Color.Red;
                    C1.Enabled = false;
                }
                else if (tempArr[k] == "C2")
                {
                    bookedseat[10] = 1;
                    C2.BackColor = System.Drawing.Color.Red;
                    C2.Enabled = false;
                }
                else if (tempArr[k] == "C3")
                {
                    bookedseat[11] = 1;
                    C3.BackColor = System.Drawing.Color.Red;
                    C3.Enabled = false;
                }
                else if (tempArr[k] == "C4")
                {
                    bookedseat[12] = 1;
                    C4.BackColor = System.Drawing.Color.Red;
                    C4.Enabled = false;
                }
                else if (tempArr[k] == "D1")
                {
                    bookedseat[13] = 1;
                    D1.BackColor = System.Drawing.Color.Red;
                    D1.Enabled = false;
                }
                else if (tempArr[k] == "D2")
                {
                    bookedseat[14] = 1;
                    D2.BackColor = System.Drawing.Color.Red;
                    D2.Enabled = false;
                }
                else if (tempArr[k] == "D3")
                {
                    bookedseat[15] = 1;
                    D3.BackColor = System.Drawing.Color.Red;
                    D3.Enabled = false;
                }
                else if (tempArr[k] == "D4")
                {
                    bookedseat[16] = 1;
                    D4.BackColor = System.Drawing.Color.Red;
                    D4.Enabled = false;
                }
                else if (tempArr[k] == "E1")
                {
                    bookedseat[17] = 1;
                    E1.BackColor = System.Drawing.Color.Red;
                    E1.Enabled = false;
                }
                else if (tempArr[k] == "E2")
                {
                    bookedseat[18] = 1;
                    E2.BackColor = System.Drawing.Color.Red;
                    E2.Enabled = false;
                }
                else if (tempArr[k] == "E3")
                {
                    bookedseat[19] = 1;
                    E3.BackColor = System.Drawing.Color.Red;
                    E3.Enabled = false;
                }
                else if (tempArr[k] == "E4")
                {
                    bookedseat[20] = 1;
                    E4.BackColor = System.Drawing.Color.Red;
                    E4.Enabled = false;
                }
                else if (tempArr[k] == "F1")
                {
                    bookedseat[21] = 1;
                    F1.BackColor = System.Drawing.Color.Red;
                    F1.Enabled = false;
                }
                else if (tempArr[k] == "F2")
                {
                    bookedseat[22] = 1;
                    F2.BackColor = System.Drawing.Color.Red;
                    F2.Enabled = false;
                }
                else if (tempArr[k] == "F3")
                {
                    bookedseat[23] = 1;
                    F3.BackColor = System.Drawing.Color.Red;
                    F3.Enabled = false;
                }
                else if (tempArr[k] == "F4")
                {
                    bookedseat[24] = 1;
                    F4.BackColor = System.Drawing.Color.Red;
                    F4.Enabled = false;
                }
                else if (tempArr[k] == "G1")
                {
                    bookedseat[25] = 1;
                    G1.BackColor = System.Drawing.Color.Red;
                    G1.Enabled = false;
                }
                else if (tempArr[k] == "G2")
                {
                    bookedseat[26] = 1;
                    G2.BackColor = System.Drawing.Color.Red;
                    G2.Enabled = false;
                }
                else if (tempArr[k] == "G3")
                {
                    bookedseat[27] = 1;
                    G3.BackColor = System.Drawing.Color.Red;
                    G3.Enabled = false;
                }
                else if (tempArr[k] == "G4")
                {
                    bookedseat[28] = 1;
                    G4.BackColor = System.Drawing.Color.Red;
                    G4.Enabled = false;
                }
                else if (tempArr[k] == "H1")
                {
                    bookedseat[29] = 1;
                    H1.BackColor = System.Drawing.Color.Red;
                    H1.Enabled = false;
                }
                else if (tempArr[k] == "H2")
                {
                    bookedseat[30] = 1;
                    H2.BackColor = System.Drawing.Color.Red;
                    H2.Enabled = false;
                }
                else if (tempArr[k] == "H3")
                {
                    bookedseat[31] = 1;
                    H3.BackColor = System.Drawing.Color.Red;
                    H3.Enabled = false;
                }
                else if (tempArr[k] == "H4")
                {
                    bookedseat[32] = 1;
                    H4.BackColor = System.Drawing.Color.Red;
                    H4.Enabled = false;
                }
                else if (tempArr[k] == "I1")
                {
                    bookedseat[33] = 1;
                    I1.BackColor = System.Drawing.Color.Red;
                    I1.Enabled = false;
                }
                else if (tempArr[k] == "I2")
                {
                    bookedseat[34] = 1;
                    I2.BackColor = System.Drawing.Color.Red;
                    I2.Enabled = false;
                }
                else if (tempArr[k] == "I3")
                {
                    bookedseat[35] = 1;
                    I3.BackColor = System.Drawing.Color.Red;
                    I3.Enabled = false;
                }
                else if (tempArr[k] == "I4")
                {
                    bookedseat[36] = 1;
                    I4.BackColor = System.Drawing.Color.Red;
                    I4.Enabled = false;

                }
                else if (tempArr[k] == "J1")
                {
                    bookedseat[37] = 1;
                    J1.BackColor = System.Drawing.Color.Red;
                    J1.Enabled = false;
                }
                else if (tempArr[k] == "J2")
                {
                    bookedseat[38] = 1;
                    J2.BackColor = System.Drawing.Color.Red;
                    J2.Enabled = false;
                }
                else if (tempArr[k] == "J3")
                {
                    bookedseat[39] = 1;
                    J3.BackColor = System.Drawing.Color.Red;
                    J3.Enabled = false;
                }
                else if (tempArr[k] == "J4")
                {
                    bookedseat[40] = 1;
                    J4.BackColor = System.Drawing.Color.Red;
                    J4.Enabled = false;
                }
            }
            for(int k=1;k<=40;k++)
            {
                if(bookedseat[k]==0)
                {
                    if(k==1)
                    {
                        A1.BackColor = System.Drawing.Color.Gray;
                        A1.Enabled = true;
                    }
                    else if(k==2)
                    {
                        A2.BackColor = System.Drawing.Color.Gray;
                        A2.Enabled = true;
                    }
                    else if (k == 3)
                    {
                        A3.BackColor = System.Drawing.Color.Gray;
                        A3.Enabled = true;
                    }
                    else if (k == 4)
                    {
                        A4.BackColor = System.Drawing.Color.Gray;
                        A4.Enabled = true;
                    }
                    else if (k == 5)
                    {
                        B1.BackColor = System.Drawing.Color.Gray;
                        B1.Enabled = true;
                    }
                    else if (k == 6)
                    {
                        B2.BackColor = System.Drawing.Color.Gray;
                        B2.Enabled = true;
                    }
                    else if (k == 7)
                    {
                        B3.BackColor = System.Drawing.Color.Gray;
                        B3.Enabled = true;
                    }
                    else if (k == 8)
                    {
                        B4.BackColor = System.Drawing.Color.Gray;
                        B4.Enabled = true;
                    }
                    else if (k == 9)
                    {
                        C1.BackColor = System.Drawing.Color.Gray;
                        C1.Enabled = true;
                    }
                    else if (k == 10)
                    {
                        C2.BackColor = System.Drawing.Color.Gray;
                        C2.Enabled = true;
                    }
                    else if (k == 11)
                    {
                        C3.BackColor = System.Drawing.Color.Gray;
                        C3.Enabled = true;
                    }
                    else if (k == 12)
                    {
                        C4.BackColor = System.Drawing.Color.Gray;
                        C4.Enabled = true;
                    }
                    else if (k == 13)
                    {
                        D1.BackColor = System.Drawing.Color.Gray;
                        D1.Enabled = true;
                    }
                    else if (k == 14)
                    {
                        D2.BackColor = System.Drawing.Color.Gray;
                        D2.Enabled = true;
                    }
                    else if (k == 15)
                    {
                        D3.BackColor = System.Drawing.Color.Gray;
                        D3.Enabled = true;
                    }
                    else if (k == 16)
                    {
                        D4.BackColor = System.Drawing.Color.Gray;
                        D4.Enabled = true;
                    }
                    else if (k == 17)
                    {
                        E1.BackColor = System.Drawing.Color.Gray;
                        E1.Enabled = true;
                    }
                    else if (k == 18)
                    {
                        E2.BackColor = System.Drawing.Color.Gray;
                        E2.Enabled = true;
                    }
                    else if (k == 19)
                    {
                        E3.BackColor = System.Drawing.Color.Gray;
                        E3.Enabled = true;
                    }
                    else if (k == 20)
                    {
                        E4.BackColor = System.Drawing.Color.Gray;
                        E4.Enabled = true;
                    }
                    else if (k == 21)
                    {
                        F1.BackColor = System.Drawing.Color.Gray;
                        F1.Enabled = true;
                    }
                    else if (k == 22)
                    {
                        F2.BackColor = System.Drawing.Color.Gray;
                        F2.Enabled = true;
                    }
                    else if (k == 23)
                    {
                        F3.BackColor = System.Drawing.Color.Gray;
                        F3.Enabled = true;
                    }
                    else if (k == 24)
                    {
                        F4.BackColor = System.Drawing.Color.Gray;
                        F4.Enabled = true;
                    }
                    else if (k == 25)
                    {
                        G1.BackColor = System.Drawing.Color.Gray;
                        G1.Enabled = true;
                    }
                    else if (k == 26)
                    {
                        G2.BackColor = System.Drawing.Color.Gray;
                        G2.Enabled = true;
                    }
                    else if (k == 27)
                    {
                        G3.BackColor = System.Drawing.Color.Gray;
                        G3.Enabled = true;
                    }
                    else if (k == 28)
                    {
                        G4.BackColor = System.Drawing.Color.Gray;
                        G4.Enabled = true;
                    }
                    else if (k == 29)
                    {
                        H1.BackColor = System.Drawing.Color.Gray;
                        H1.Enabled = true;
                    }
                    else if (k == 30)
                    {
                        H2.BackColor = System.Drawing.Color.Gray;
                        H2.Enabled = true;
                    }
                    else if (k == 31)
                    {
                        H3.BackColor = System.Drawing.Color.Gray;
                        H3.Enabled = true;
                    }
                    else if (k == 32)
                    {
                        H4.BackColor = System.Drawing.Color.Gray;
                        H4.Enabled = true;
                    }
                    else if (k == 33)
                    {
                        I1.BackColor = System.Drawing.Color.Gray;
                        I1.Enabled = true;
                    }
                    else if (k == 34)
                    {
                        I2.BackColor = System.Drawing.Color.Gray;
                        I2.Enabled = true;
                    }
                    else if (k == 35)
                    {
                        I3.BackColor = System.Drawing.Color.Gray;
                        I3.Enabled = true;
                    }
                    else if (k == 36)
                    {
                        I4.BackColor = System.Drawing.Color.Gray;
                        I4.Enabled = true;
                    }
                    else if (k == 37)
                    {
                        J1.BackColor = System.Drawing.Color.Gray;
                        J1.Enabled = true;
                    }
                    else if (k == 38)
                    {
                        J2.BackColor = System.Drawing.Color.Gray;
                        J2.Enabled = true;
                    }
                    else if (k == 39)
                    {
                        J3.BackColor = System.Drawing.Color.Gray;
                        J3.Enabled = true;
                    }
                    else if (k == 40)
                    {
                        J4.BackColor = System.Drawing.Color.Gray;
                        J4.Enabled = true;
                    }
                }
            }

        }
        protected void seat_no()
        {
            String seatnum=null;
            int no_of_seat=0;
            for(int i=1;i<= 40;i++)
            {
                if(tempbookseat[i]==1)
                {
                    int x = i % 4;
                    if (x == 0) x = 4;
                    no_of_seat++;
                    int y = i / 4;
                    if (i % 4 != 0) y++;
                    int k = 1;
                    for(char j='A';j<='J';j++)
                    {
                        if(y==k)
                        {
                            seatnum += j;
                            seatnum +=x.ToString();
                            seatnum += " ";
                            break;
                        }
                        k++;
                    }
                }
            }
            seatNoText.Text = seatnum;
            int taka = Convert.ToInt32(Session["bhara"]) * no_of_seat;
            Session["taka"] = taka;
            fareText.Text = taka.ToString();
            Session["seatnum"] = seatnum;
            trxidText.Text = "";
        }
        protected void A4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[4] == 0)
            {
                A4.BackColor = System.Drawing.Color.Green;
                tempbookseat[4] = 1;

            }
            else
            {
                A4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[4] = 0;
            }
            seat_no();
        }

        protected void A1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[1] == 0)
            {
                A1.BackColor = System.Drawing.Color.Green;
                tempbookseat[1] = 1;

            }
            else
            {
                A1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[1] = 0;
            }
            seat_no();
        }

        protected void A2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[2] == 0)
            {
                A2.BackColor = System.Drawing.Color.Green;
                tempbookseat[2] = 1;

            }
            else
            {
                A2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[2] = 0;
            }
            seat_no();
        }

        protected void A3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[3] == 0)
            {
                A3.BackColor = System.Drawing.Color.Green;
                tempbookseat[3] = 1;

            }
            else
            {
                A3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[3] = 0;
            }
            seat_no();
        }

        protected void B1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[5] == 0)
            {
                B1.BackColor = System.Drawing.Color.Green;
                tempbookseat[5] = 1;

            }
            else
            {
                B1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[5] = 0;
            }
            seat_no();
        }

        protected void B2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[6] == 0)
            {
                B2.BackColor = System.Drawing.Color.Green;
                tempbookseat[6] = 1;

            }
            else
            {
                B2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[6] = 0;
            }
            seat_no();
        }

        protected void B3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[7] == 0)
            {
                B3.BackColor = System.Drawing.Color.Green;
                tempbookseat[7] = 1;

            }
            else
            {
                B3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[7] = 0;
            }
            seat_no();
        }

        protected void B4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[8] == 0)
            {
                B4.BackColor = System.Drawing.Color.Green;
                tempbookseat[8] = 1;

            }
            else
            {
                B4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[8] = 0;
            }
            seat_no();
        }

        protected void C1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[9] == 0)
            {
                C1.BackColor = System.Drawing.Color.Green;
                tempbookseat[9] = 1;

            }
            else
            {
                C1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[9] = 0;
            }
            seat_no();
        }

        protected void C2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[10] == 0)
            {
                C2.BackColor = System.Drawing.Color.Green;
                tempbookseat[10] = 1;

            }
            else
            {
                C2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[10] = 0;
            }
            seat_no();
        }

        protected void C3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[11] == 0)
            {
                C3.BackColor = System.Drawing.Color.Green;
                tempbookseat[11] = 1;

            }
            else
            {
                C3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[11] = 0;
            }
            seat_no();
        }

        protected void C4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[12] == 0)
            {
                C4.BackColor = System.Drawing.Color.Green;
                tempbookseat[12] = 1;

            }
            else
            {
                C4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[12] = 0;
            }
            seat_no();
        }

        protected void D1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[13] == 0)
            {
                D1.BackColor = System.Drawing.Color.Green;
                tempbookseat[13] = 1;

            }
            else
            {
                D1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[13] = 0;
            }
            seat_no();
        }

        protected void D2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[14] == 0)
            {
                D2.BackColor = System.Drawing.Color.Green;
                tempbookseat[14] = 1;

            }
            else
            {
                D2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[14] = 0;
            }
            seat_no();
        }

        protected void D3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[15] == 0)
            {
                D3.BackColor = System.Drawing.Color.Green;
                tempbookseat[15] = 1;

            }
            else
            {
                D3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[15] = 0;
            }
            seat_no();
        }

        protected void D4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[16] == 0)
            {
                D4.BackColor = System.Drawing.Color.Green;
                tempbookseat[16] = 1;

            }
            else
            {
                D4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[16] = 0;
            }
            seat_no();
        }

        protected void E1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[17] == 0)
            {
                E1.BackColor = System.Drawing.Color.Green;
                tempbookseat[17] = 1;

            }
            else
            {
                E1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[17] = 0;
            }
            seat_no();
        }

        protected void E2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[18] == 0)
            {
                E2.BackColor = System.Drawing.Color.Green;
                tempbookseat[18] = 1;

            }
            else
            {
                E2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[18] = 0;
            }
            seat_no();
        }

        protected void E3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[19] == 0)
            {
                E3.BackColor = System.Drawing.Color.Green;
                tempbookseat[19] = 1;

            }
            else
            {
                E3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[19] = 0;
            }
            seat_no();
        }

        protected void E4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[20] == 0)
            {
                E4.BackColor = System.Drawing.Color.Green;
                tempbookseat[20] = 1;

            }
            else
            {
                E4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[20] = 0;
            }
            seat_no();
        }

        protected void F1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[21] == 0)
            {
                F1.BackColor = System.Drawing.Color.Green;
                tempbookseat[21] = 1;

            }
            else
            {
                F1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[21] = 0;
            }
            seat_no();
        }

        protected void F2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[22] == 0)
            {
                F2.BackColor = System.Drawing.Color.Green;
                tempbookseat[22] = 1;

            }
            else
            {
                F2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[22] = 0;
            }
            seat_no();
        }

        protected void F3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[23] == 0)
            {
                F3.BackColor = System.Drawing.Color.Green;
                tempbookseat[23] = 1;

            }
            else
            {
                F3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[23] = 0;
            }
            seat_no();
        }

        protected void F4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[24] == 0)
            {
                F4.BackColor = System.Drawing.Color.Green;
                tempbookseat[24] = 1;

            }
            else
            {
                F4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[24] = 0;
            }
            seat_no();
        }

        protected void G1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[25] == 0)
            {
                G1.BackColor = System.Drawing.Color.Green;
                tempbookseat[25] = 1;

            }
            else
            {
                G1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[25] = 0;
            }
            seat_no();
        }

        protected void G2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[26] == 0)
            {
                G2.BackColor = System.Drawing.Color.Green;
                tempbookseat[26] = 1;

            }
            else
            {
                G2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[26] = 0;
            }
            seat_no();
        }

        protected void G3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[27] == 0)
            {
                G3.BackColor = System.Drawing.Color.Green;
                tempbookseat[27] = 1;

            }
            else
            {
                G3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[27] = 0;
            }
            seat_no();
        }

        protected void G4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[28] == 0)
            {
                G4.BackColor = System.Drawing.Color.Green;
                tempbookseat[28] = 1;

            }
            else
            {
                G4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[28] = 0;
            }
            seat_no();
        }

        protected void H1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[29] == 0)
            {
                H1.BackColor = System.Drawing.Color.Green;
                tempbookseat[29] = 1;

            }
            else
            {
                H1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[29] = 0;
            }
            seat_no();
        }

        protected void H2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[30] == 0)
            {
                H2.BackColor = System.Drawing.Color.Green;
                tempbookseat[30] = 1;

            }
            else
            {
                H2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[30] = 0;
            }
            seat_no();
        }

        protected void H3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[31] == 0)
            {
                H3.BackColor = System.Drawing.Color.Green;
                tempbookseat[31] = 1;

            }
            else
            {
                H3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[31] = 0;
            }
            seat_no();
        }

        protected void H4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[32] == 0)
            {
                H4.BackColor = System.Drawing.Color.Green;
                tempbookseat[32] = 1;

            }
            else
            {
                H4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[32] = 0;
            }
            seat_no();
        }

        protected void I1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[33] == 0)
            {
                I1.BackColor = System.Drawing.Color.Green;
                tempbookseat[33] = 1;

            }
            else
            {
                I1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[33] = 0;
            }
            seat_no();
        }

        protected void I2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[34] == 0)
            {
                I2.BackColor = System.Drawing.Color.Green;
                tempbookseat[34] = 1;

            }
            else
            {
                I2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[34] = 0;
            }
            seat_no();
        }

        protected void I3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[35] == 0)
            {
                I3.BackColor = System.Drawing.Color.Green;
                tempbookseat[35] = 1;

            }
            else
            {
                I3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[35] = 0;
            }
            seat_no();
        }

        protected void I4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[36] == 0)
            {
                I4.BackColor = System.Drawing.Color.Green;
                tempbookseat[36] = 1;

            }
            else
            {
                I4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[36] = 0;
            }
            seat_no();
        }

        protected void J1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[37] == 0)
            {
                J1.BackColor = System.Drawing.Color.Green;
                tempbookseat[37] = 1;

            }
            else
            {
                J1.BackColor = System.Drawing.Color.Gray;
                tempbookseat[37] = 0;
            }
            seat_no();
        }

        protected void J2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[38] == 0)
            {
                J2.BackColor = System.Drawing.Color.Green;
                tempbookseat[38] = 1;

            }
            else
            {
                J2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[38] = 0;
            }
            seat_no();
        }

        protected void J3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[39] == 0)
            {
                J3.BackColor = System.Drawing.Color.Green;
                tempbookseat[39] = 1;

            }
            else
            {
                J3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[39] = 0;
            }
            seat_no();
        }

        protected void J4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[40] == 0)
            {
                J4.BackColor = System.Drawing.Color.Green;
                tempbookseat[40] = 1;

            }
            else
            {
                J4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[40] = 0;
            }
            seat_no();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String filter = DropDownList1.SelectedItem.Text.ToString();
            
            if(filter.Equals("Price High To Low"))
            {
                
                string query = "select  Company_Name,Departing_Time,Coach_No,Leaving_From,Starting_Counter,Going_To,Fare,Coach_Type,Seat_Available from busbook where Leaving_From='" + Session["leave"].ToString() + "' AND Coach_Type='" + Session["coach"].ToString() + "' AND Going_To='" + Session["going"].ToString() + "' AND Departing_Date='" + Session["tarikh"].ToString() + "'order by Fare desc";
                BlindData(query);
            }
            else if(filter.Equals("Price Low To High"))
            {
                String leave = leavingdrop.SelectedItem.Value;
                tarikh = date.SelectedDate.ToString("MM/dd/yyyy");
                String going = goingdrop.SelectedItem.Value;
                String coach = coachdrop.SelectedItem.Value;
                Session["tarikh"] = tarikh;
                string query = "select  Company_Name,Departing_Time,Coach_No,Leaving_From,Starting_Counter,Going_To,Fare,Coach_Type,Seat_Available from busbook where Leaving_From='" + leave + "' AND Coach_Type='" + coach + "' AND Going_To='" + going + "' AND Departing_Date='" + tarikh + "'ORDER BY Fare asc";
                BlindData(query);
            }
        }

        protected void seatNoText_TextChanged(object sender, EventArgs e)
        {

        }
        protected void payNowButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Project3rd; Integrated Security = True");
            conn.Open();
            DataTable dtt = new DataTable();
            String Qu = "select balance from balance where username='" + Session["user"] + "'";
            SqlCommand cmd = new SqlCommand(Qu, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            dtt.Load(sdr);
            String bal = dtt.Rows[0][0].ToString();
            sdr.Dispose();
            int balance = Convert.ToInt32(bal);
            String trxid = trxidText.Text;
            String seatFare = Session["taka"].ToString();
            if(trxid.Equals("") || seatFare.Equals("") || seatFare.Equals("0"))
            {
                Response.Write("<script>alert('Give Payment Trxid')</script>");
            }
            else if(trxid.Equals(Session["user"].ToString()) && balance>= Convert.ToInt32(seatFare))
            {
                balance -= Convert.ToInt32(seatFare);
                Qu = "update balance set balance= " + balance + " where username='" + Session["user"] + "'";
                SqlCommand cm = new SqlCommand(Qu, conn);
                SqlDataReader sd = cm.ExecuteReader();
                sd.Dispose();
                String seat = Session["seat"].ToString();
                String tmp = null;
                String seatnum = Session["seatnum"].ToString();
                for (int i = 0; i < seat.Length; i++)
                {
                    if (seat[i] != ' ')
                        tmp += seat[i];
                }
                for (int i = 0; i < seatnum.Length; i++)
                {
                    if (seatnum[i] != ' ')
                        tmp += seatnum[i];
                }
                int rem = 40 - (tmp.Length / 2);
                String query = "update busbook set Book_Seat='" + tmp + "',Seat_Available= " + rem + " where Coach_No='" + Session["coach"].ToString() + "'";
                SqlCommand cmdd = new SqlCommand(query, conn);
                cmdd.ExecuteReader();
                conn.Close();
                Response.Write("<script>");
                Response.Write("window.open('printPDF.aspx','_blank')");
                Response.Write("</script>");
            }
            else if(trxid.Equals(Session["user"].ToString()) && balance < Convert.ToInt32(seatFare))
            {
                Response.Write("<script>alert('Insufficient Balance in Pay Card ID')</script>");
            }
            else 
            {
                String seat = Session["seat"].ToString();
                String tmp = null;
                String seatnum=Session["seatnum"].ToString();
                for(int i=0;i<seat.Length;i++)
                {
                    if (seat[i] != ' ')
                        tmp += seat[i];
                }
                for (int i = 0; i < seatnum.Length; i++)
                {
                    if (seatnum[i] != ' ')
                        tmp += seatnum[i];
                }
                int rem = 40 - (tmp.Length/2);
                String query = "update busbook set Book_Seat='" + tmp+ "',Seat_Available= " + rem + " where Coach_No='" + Session["coach"].ToString() + "'";
                cmd = new SqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                Response.Write("<script>");
                Response.Write("window.open('printPDF.aspx','_blank')");
                Response.Write("</script>");
            }
            //fareText.Text = "sadee";
        }
    }
}