using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
namespace BusTicket
{
    public partial class printPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String orderNo = Session["ticketNo"].ToString();
            Label3.Text = orderNo;
            Label6.Text = DateTime.Now.ToString();
            Label20.Text = Session["naam"].ToString();
            Label21.Text = Session["gender"].ToString();
            Label22.Text = Session["mobnum"].ToString();
            Label23.Text = Session["tarikh"].ToString();
            Label24.Text = Session["leave"].ToString();
            Label25.Text = Session["going"].ToString();
            Label26.Text = Session["depart"].ToString();
            Label27.Text = Session["startplace"].ToString();
            Label28.Text = Session["bhara"].ToString();
            Label29.Text = Session["taka"].ToString();
            Label30.Text = Session["seatnum"].ToString();
            Label31.Text = Session["coachType"].ToString();
            Label32.Text = Session["coach"].ToString();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TicketPDF.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}