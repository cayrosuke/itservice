using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Handlers;

namespace airod_protottype
{
    public partial class master_service_request : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null) 
            {
                Response.Redirect("login.aspx");
            
            }

           
        //    Timer1.Enabled = true;

            
        //    if (Session["interval"] != null)
        //    {
        //        //var datecom = Session["date"];
        //        //var interval = Session["interval"];
        //        //DateTime recdate = Convert.ToDateTime(Session["valdate"]);
        //        //DateTime todate = System.DateTime.Now;
        //        //var resdate = todate - recdate;
        //        //interval =Convert.ToInt32(resdate) * 3600000;

        //        Timer1.Interval = 3600000;
        //        Timer1.Tick += new EventHandler<EventArgs>(Timer1_Tick);
        //        Timer1.Enabled = true;
                
        //    }
       
           
        //}
     

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{int i = 0;
        //    i = i - 1;

        //    if (i < 0)
        //    {
        //        HttpCookie cookfind = new HttpCookie();
               
                
               
               
        //       }
        //        string Req_Name = Session["Req_Name"].ToString();
        //        string Act_Email = Session["Act_Email"].ToString();
        //        int Ref_No = Convert.ToInt32(Session["Ref_No"]);
        //        string Prob_Desc = Session["Prob_Desc"].ToString();
        //        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        //        message.To.Add(Act_Email);
        //        message.Subject = "Mail from IT Help Desk- Reminder for any pending Requests from your side";
        //        message.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");
        //        message.Body = "Problem Description :    " + Prob_Desc +
        //        "                                                                                                                                                                                                                             " +
        //        "                                                                                                                                                                                                                             " +
        //        "Reference No:   " + Ref_No  +
        //        "                                                                                                                                                                                                                             " +
        //        "Sent by  :       " + Req_Name +
        //        "         is in URGENT status.Please check and confirm whether this Issue is pending from your side.                                                                                                                                                                                                                             " +
        //        "If it is pending Please Attend to this Problem and Submit Request through Request Application Processing Software :  End of Message"
        //        + "Thank you." + "                                                                                                                                                                                                                 "
        //        + "Regards" + "                                                                                                                                                                                                                   "
        //        + "AeroLogica Sdn Bhd  " + "                                                                                                                                                                                                       "
        //        + "Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("128.2.11.11");
        //        smtp.Port = 25;
        //        try
        //        {
        //            smtp.Send(message);
        //            Response.Write("<script>alert('Email sent to Assignee Person')</script>");

        //        }
        //        catch
        //        {
        //            Response.Write("<script>alert('Email Couldnt be sent')</script>");
        //        }
        //                Timer1.Enabled = false;
        //    }

        }
         
      

    

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            string holder = string.Empty;

            holder = Menu1.SelectedItem.Value;

            if (holder == "Add Requests")
            {
                Server.Transfer("AddReq.aspx");
            }

            if (holder == "Modify Requests")
            {
                Server.Transfer("ModReq.aspx");
            }
            if (holder == "View Requests")
            {
                Server.Transfer("ViewReq.aspx");
            }

            if (holder == "View Reports")
            {
                Server.Transfer("report.aspx");
            
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {


            Session.Abandon();
            Session.Clear();
            Response.Redirect("login.aspx");
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {

        }
    }
}