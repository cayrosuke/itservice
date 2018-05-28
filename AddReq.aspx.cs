using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net.Mail;

namespace airod_protottype
{ 
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                g.fileName = "";
            }

            CheckBox1.Checked = true;

            if (!IsPostBack)
            {
                bl add = new bl();

                try
                {
                   
                    int refno = add.refret();
                    TextBox1.Text = refno.ToString();
                    TextBox1.Enabled = false;
                }
                catch
                {

                    TextBox1.Text = "";
                }
                
            }
            TextBox3.Text = DateTime.Now.ToString();
            //TextBox3.Enabled = false;
            //add here
        }

        public static class g
        {

            public static string fileName="";
            public static string path="";
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("main.aspx");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Server.ScriptTimeout = 600;
            Server.ScriptTimeout = 500;
            bool flag = true;

            string confrim_value = Request.Form["Confirm_Value"];
            if (TextBox4.Text == "")
            {
                Response.Write("<script>alert('Problem Cannot be Blank')</script>");
                TextBox4.Focus();
                flag = false;
            }

            if (TextBox6.Text == "")
            {
                Response.Write("<script>alert('Received Date Cannot be Blank')</script>");
                TextBox6.Focus();
                flag = false;
            }

            if (TextBox7.Text == "")
            {
                Response.Write("<script>alert('Requestor Email Cannot be Blank</script>");
                TextBox7.Focus();
                flag = false;
            }

            if ((TextBox8.Text == "")&&(TextBox9.Text==""))
            {
                Response.Write("<script>alert('TimeEntries cannot be Blank')</script>");
                TextBox4.Focus();
                flag = false;
            }
            
            if ((confrim_value == "YES") && (flag == true)&&(CheckBox1.Checked==true))
            {
                int Ref_No = Int32.Parse(TextBox1.Text);
                DateTime rec_da = System.DateTime.Now;
                if((TextBox8.Text == "") || (TextBox9.Text=="")) {

                    TextBox8.Text = "00";
                    TextBox9.Text = "00";
                
                }
                string condate = TextBox6.Text + " " + TextBox8.Text + ":" + TextBox9.Text + ":" + "00";
                string Rec_Date = Convert.ToDateTime(condate).ToString("yyyy/MM/dd HH:mm:ss");

                string Prob_Desc = TextBox4.Text;
                string Type = DropDownList2.SelectedItem.Text;
                string Remarks = DropDownList6.SelectedItem.Value;
                string Req_Name = TextBox2.Text;
                string Com_Type = DropDownList3.SelectedItem.Text;
                string Req_Email = TextBox7.Text;
                string Req_Status = DropDownList4.SelectedItem.Text;
                string Act_Email = DropDownList5.SelectedItem.Text;
                string khidmat2 = ddlType.SelectedItem.Text;
                DateTime Escalate_Date = DateTime.Now;
                bool msgflag=false;

                bl c = new bl();
                try
                {
                    bool stat = c.addsrvreq(Ref_No, Rec_Date, Req_Name, Prob_Desc, Type, Com_Type, Req_Email, Req_Status, Remarks, Act_Email, khidmat2, Escalate_Date);
                    stat = c.addsrvreq1(Ref_No, Rec_Date, Req_Name, Prob_Desc, Type, Com_Type, Req_Email, Req_Status, Remarks, Act_Email, khidmat2, Escalate_Date);
                  msgflag = true;    
                    
                }


                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Request Couldnt Be Added Try Again')", true);
                }

                if (msgflag)
                {
                    Response.Write("<script>alert('Request Added Successfully');</script>");
                    
                }

                //if (Com_Type != "CONFIGMGMT")
                
                //{
                //    //email to buswani
                //    string email = "buswani@aerologica.com";
                //    System.Net.Mail.MailMessage message3 = new System.Net.Mail.MailMessage();
                //    message3.To.Add(email);
                //    message3.Subject = "Mail from IT Help Desk";
                //    message3.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");
                //    message3.Body = "Dear       : Mr. Buswani  "
                //    + Environment.NewLine
                //    + Environment.NewLine
                //    + "IT Request Received from :   " + Req_Name + "    on this Date   :" + System.DateTime.Today.ToShortDateString()
                //    + Environment.NewLine
                //    + Environment.NewLine
                //    + "Category         :  " + Type +
                //    Environment.NewLine
                //    + "Reference No     :  " + Ref_No +
                //    Environment.NewLine +
                //    "Problem Desc      :  " + Prob_Desc
                //    + Environment.NewLine
                //    + Environment.NewLine
                //    + "Thank you."
                //    + Environment.NewLine
                //    + "Regards"
                //    + Environment.NewLine
                //    + "AeroLogica Sdn Bhd  "
                //    + Environment.NewLine
                //    + "Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";
                //    System.Net.Mail.SmtpClient smtp3 = new System.Net.Mail.SmtpClient("128.2.11.11");
                //    smtp3.Port = 25;

                //    smtp3.Send(message3);
                //    //end of buswani mail message
                //}

                    //Response.Cookies[cookname] ["date"]  =Convert.ToString(System.DateTime.Now);
                    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                    message.To.Add(Act_Email);
                    message.Subject = "Mail from IT Help Desk";
                    message.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");
                    if (g.fileName != "")
                    {
                        System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(Server.MapPath((@"~/" + g.fileName)));
                        message.Attachments.Add(attach);
                    }
                    
                    message.Body = "Problem Description :  " + Prob_Desc +
                    Environment.NewLine
                    + "Reference No         :  " + Ref_No +
                    Environment.NewLine
                    + Environment.NewLine
                    + "Service Request Type :  " + khidmat2 +
                    Environment.NewLine
                    + Environment.NewLine
                    + "Company Name          :  " + Com_Type +
                    Environment.NewLine
                    + Environment.NewLine
                    +"Sent by               :  " + Req_Name +
                    Environment.NewLine
                    +"on this date          :  " + Rec_Date +
                    Environment.NewLine
                    + "Priority Rating is   :  " + Type +
                    Environment.NewLine
                    +"Please Attend to this Problem and Submit Request through Request Application Processing Software as soon as possible" +
                    Environment.NewLine
                    +Environment.NewLine 
                    +"Thank you." 
                    +Environment.NewLine
                    + "Regards" +
                    Environment.NewLine
                    +Environment.NewLine
                    + "AeroLogica Sdn Bhd  " +
                    Environment.NewLine
                    +"Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";

                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("128.2.11.11");
                    smtp.Port = 25;
                    try
                    {
                        smtp.Send(message);
                        Response.Write("<script>alert('Email Sent Successfully');</script>");
                     //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Email Sent Successfully')", true);
                  }
      
                    
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Email Couldnt be Sent ')", true);
                        
                    }

                  
                    System.Net.Mail.MailMessage message2 = new System.Net.Mail.MailMessage();
                    message2.To.Add(Req_Email);
                    message2.Subject = "Mail from IT Help Desk";
                    message2.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");
                    
                    message2.Body = "Dear       :  " + Req_Name
                    + Environment.NewLine
                    +Environment.NewLine
                    + "We acknowledge receipt of your request.Your issue has now been prioritised, and our staff has been assigned to work on it. We will update this service request with further information, as we continue to work on the request."
                    + Environment.NewLine
                    +Environment.NewLine
                    +"Category         :  " + Type +
                    Environment.NewLine
                    +"Reference No     :  " + Ref_No + 
                    Environment.NewLine+
                    "Problem Desc      :  " + Prob_Desc 
                    +Environment.NewLine
                    +Environment.NewLine
                    +"Thank you." 
                    +Environment.NewLine
                    +"Regards" 
                    +Environment.NewLine
                    +"AeroLogica Sdn Bhd  " 
                    +Environment.NewLine
                    +"Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";
                    System.Net.Mail.SmtpClient smtp2 = new System.Net.Mail.SmtpClient("128.2.11.11");
                    smtp2.Port = 25;
                 
                    try
                    {
                        smtp2.Send(message2);
                        Response.Write("<script>alert('Email sent Successfully');</script>");
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Email Sent Successfully')", true);
                    }
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Email Couldnt be Sent')", true);
                    }

                    //if (Type == "Urgent")
                    //{
                    //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                    //    Session["valdate"] = valdate;
                    //    Session["interval"] = 14400000;
                    //    Session["Act_Email"] = Act_Email;
                    //    Session["Ref_No"] = Ref_No;
                    //    Session["Prob_Desc"] = Prob_Desc;
                    //    Session["Req_Name"] = Req_Name;

                    //}

                    //if (Type == "Priority")
                    //{
                    //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                    //    Session["valdate"] = valdate;
                    //    Session["interval"] = 28800000;
                    //    Session["Act_Email"] = Act_Email;
                    //    Session["Ref_No"] = Ref_No;
                    //    Session["Prob_Desc"] = Prob_Desc;
                    //    Session["Req_Name"] = Req_Name;

                    //}
                    //if (Type == "Normal")
                    //{
                    //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                    //    Session["valdate"] = valdate;

                    //    Session["interval"] = 129600000;
                    //    Session["Act_Email"] = Act_Email;
                    //    Session["Ref_No"] = Ref_No;
                    //    Session["Prob_Desc"] = Prob_Desc;
                    //    Session["Req_Name"] = Req_Name;
                    //} 
                }


// EMAIL NO 2

            if (((confrim_value == "YES") && (flag == true)) && (CheckBox2.Checked == true))
            {
                int Ref_No = Int32.Parse(TextBox1.Text);
                DateTime rec_da = System.DateTime.Now;
                if ((TextBox8.Text == "") || (TextBox9.Text == ""))
                {

                    TextBox8.Text = "00";
                    TextBox9.Text = "00";
                }
                string condate = TextBox6.Text + " " + TextBox8.Text + ":" + TextBox9.Text + ":" + "00";
                string Rec_Date = Convert.ToDateTime(condate).ToString("yyyy/MM/dd HH:mm:ss");

                string Prob_Desc = TextBox4.Text;
                string Type = DropDownList2.SelectedItem.Text;
                string Remarks = DropDownList6.SelectedItem.Value;
                string Req_Name = TextBox2.Text;
                string Com_Type = DropDownList3.SelectedItem.Text;
                string Req_Email = TextBox7.Text;
                string Req_Status = DropDownList4.SelectedItem.Text;
                string Act_Email = DropDownList7.SelectedItem.Text;
                string khidmat2 = ddlType.SelectedItem.Text;
                DateTime Escalate_Date = DateTime.Now;

                bl c = new bl();
                try
                {
                    bool stat = c.addsrvreq(Ref_No, Rec_Date, Req_Name, Prob_Desc, Type, Com_Type, Req_Email, Req_Status, Remarks, Act_Email,khidmat2,Escalate_Date);
                   
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Request Couldnt Be Added Try Again')", true);
                }

                //Response.Cookies[cookname] ["date"]  =Convert.ToString(System.DateTime.Now);
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(Act_Email);
                message.Subject = "Mail from IT Help Desk";
                message.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");
                if (g.fileName != "")
                {
                    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(Server.MapPath((@"~/" + g.fileName)));
                    message.Attachments.Add(attach);
                }

                message.Body = "Problem Description :  " + Prob_Desc +
                Environment.NewLine
                + "Reference No        :  " + Ref_No +
                Environment.NewLine
                + Environment.NewLine
                + "Company Name        :  " + Com_Type +
                Environment.NewLine
                + Environment.NewLine
                + "Sent by             :  " + Req_Name +
                Environment.NewLine
                + "on this date        :  " + Rec_Date +
                Environment.NewLine
                + "Priority Rating is :  " + Type +
                Environment.NewLine
                + "Please Note that this Problem is also CC to         :  "+DropDownList5.Text +"         " +"        "+ DropDownList8.Text +
                Environment.NewLine
                + "Please Attend to this Problem and Submit Request through Request Application Processing Software as soon as possible" +
                Environment.NewLine
                + Environment.NewLine
                + "Thank you."
                + Environment.NewLine
                + "Regards" +
                Environment.NewLine
                + Environment.NewLine
                + "AeroLogica Sdn Bhd  " +
                Environment.NewLine
                + "Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("128.2.11.11");
                smtp.Port = 25;
                try
                {
                    smtp.Send(message);
                    Response.Write("<script>alert('Email sent to Assignee Person');</script>");

                }
                catch
                {
                    Response.Write("<script>alert('Email Couldnt be sent');</script>");
                }


                System.Net.Mail.MailMessage message2 = new System.Net.Mail.MailMessage();
                message2.To.Add(Req_Email);
                message2.Subject = "Mail from IT Help Desk";
                message2.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");

                message2.Body = "Dear       :  " + Req_Name
                + Environment.NewLine
                + Environment.NewLine
                + "We acknowledge receipt of your request.Your issue has now been prioritised, and our staff has been assigned to work on it. We will update this service request with further information, as we continue to work on the request."
                + Environment.NewLine
                + Environment.NewLine
                + "Category         :  " + Type +
                Environment.NewLine
                + "Reference No     :  " + Ref_No +
                Environment.NewLine +
                "Problem Desc      :  " + Prob_Desc
                + Environment.NewLine
                + Environment.NewLine
                + "Thank you."
                + Environment.NewLine
                + "Regards"
                + Environment.NewLine
                + "AeroLogica Sdn Bhd  "
                + Environment.NewLine
                + "Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";
                System.Net.Mail.SmtpClient smtp2 = new System.Net.Mail.SmtpClient("128.2.11.11");
                smtp2.Port = 25;

                try
                {
                    smtp2.Send(message2);
                    Response.Write("<script> alert('Email sent to Requestor');</script>");

                }
                catch
                {
                    Response.Write("<script> alert('Email Couldnt be sent');</script>");
                }


                //if (Type == "Urgent")
                //{
                //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                //    Session["valdate"] = valdate;
                //    Session["interval"] = 14400000;
                //    Session["Act_Email"] = Act_Email;
                //    Session["Ref_No"] = Ref_No;
                //    Session["Prob_Desc"] = Prob_Desc;
                //    Session["Req_Name"] = Req_Name;


                //}

                //if (Type == "Priority")
                //{
                //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                //    Session["valdate"] = valdate;
                //    Session["interval"] = 28800000;
                //    Session["Act_Email"] = Act_Email;
                //    Session["Ref_No"] = Ref_No;
                //    Session["Prob_Desc"] = Prob_Desc;
                //    Session["Req_Name"] = Req_Name;


                //}
                //if (Type == "Normal")
                //{
                //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                //    Session["valdate"] = valdate;

                //    Session["interval"] = 129600000;
                //    Session["Act_Email"] = Act_Email;
                //    Session["Ref_No"] = Ref_No;
                //    Session["Prob_Desc"] = Prob_Desc;
                //    Session["Req_Name"] = Req_Name;


                //}


                
            }
// EMAIL NO 3
            if (((confrim_value == "YES") && (flag == true)) && (CheckBox3.Checked == true))
            {
                int Ref_No = Int32.Parse(TextBox1.Text);
                DateTime rec_da = System.DateTime.Now;
                if ((TextBox8.Text == "") || (TextBox9.Text == ""))
                {

                    TextBox8.Text = "00";
                    TextBox9.Text = "00";

                }
                string condate = TextBox6.Text + " " + TextBox8.Text + ":" + TextBox9.Text + ":" + "00";
                string Rec_Date = Convert.ToDateTime(condate).ToString("yyyy/MM/dd HH:mm:ss");

                string Prob_Desc = TextBox4.Text;
                string Type = DropDownList2.SelectedItem.Text;
                string Remarks = DropDownList6.SelectedItem.Value;
                string Req_Name = TextBox2.Text;
                string Com_Type = DropDownList3.SelectedItem.Text;
                string Req_Email = TextBox7.Text;
                string Req_Status = DropDownList4.SelectedItem.Text;
                string Act_Email = DropDownList8.SelectedItem.Text;
                string khidmat2 = ddlType.SelectedItem.Text;
                DateTime Escalate_Date = DateTime.Now;
                

                bl c = new bl();
                try
                {
                    HttpContext.Current.Server.ScriptTimeout = 900000;
                    bool stat = c.addsrvreq(Ref_No, Rec_Date, Req_Name, Prob_Desc, Type, Com_Type, Req_Email, Req_Status, Remarks, Act_Email, khidmat2, Escalate_Date);
                    Response.Write("<script>alert('Request Added Successfully');</script>");
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Request Added Successfully')", true);
                }
                catch
                {
                    Response.Write("<script>alert('Request NOT Added TRY AGAIN');</script>");
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Request Not Added Try Again')", true);

                }
               
                //Response.Cookies[cookname] ["date"]  =Convert.ToString(System.DateTime.Now);
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(Act_Email);
                message.Subject = "Mail from IT Help Desk";
                message.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");
                if (g.fileName != "")
                {
                    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(Server.MapPath((@"~/" + g.fileName)));
                    message.Attachments.Add(attach);
                }

                message.Body = "Problem Description :  " + Prob_Desc +
                Environment.NewLine
                + "Reference No        :  " + Ref_No +
                Environment.NewLine
                + Environment.NewLine
                + "Company Name        :  " + Com_Type +
                Environment.NewLine
                + Environment.NewLine
                + "Sent by             :  " + Req_Name +
                Environment.NewLine
                + "on this date        :  " + Rec_Date +
                Environment.NewLine
                + "Priority Rating is :  " + Type +
                Environment.NewLine
                + "Please Attend to this Problem and Submit Request through Request Application Processing Software as soon as possible" +
                Environment.NewLine
                + "Please Note that this Problem is also Forwarded to  :  " + DropDownList5.Text + " and  " + DropDownList7.Text +
                Environment.NewLine
                + Environment.NewLine
                + "Thank you."
                + Environment.NewLine
                + "Regards" +
                Environment.NewLine
                + Environment.NewLine
                + "AeroLogica Sdn Bhd  " +
                Environment.NewLine
                + "Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("128.2.11.11");
                smtp.Port = 25;
                try
                {
                    smtp.Send(message);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Email Sent To Problem Solver')", true);

                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Email Couldnt be Sent Try Again')", true);
                }


                System.Net.Mail.MailMessage message2 = new System.Net.Mail.MailMessage();
                message2.To.Add(Req_Email);
                message2.Subject = "Mail from IT Help Desk";
                message2.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");

                message2.Body = "Dear       :  " + Req_Name
                + Environment.NewLine
                + Environment.NewLine
                + "We acknowledge receipt of your request.Your issue has now been prioritised, and our staff has been assigned to work on it. We will update this service request with further information, as we continue to work on the request."
                + Environment.NewLine
                + Environment.NewLine
                + "Category         :  " + Type +
                Environment.NewLine
                + "Reference No     :  " + Ref_No +
                Environment.NewLine +
                "Problem Desc      :  " + Prob_Desc
                + Environment.NewLine
                + Environment.NewLine
                + "Thank you."
                + Environment.NewLine
                + "Regards"
                + Environment.NewLine
                + "AeroLogica Sdn Bhd  "
                + Environment.NewLine
                + "Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";
                System.Net.Mail.SmtpClient smtp2 = new System.Net.Mail.SmtpClient("128.2.11.11");
                smtp2.Port = 25;

    
               
                try
                {
                
                    smtp2.Send(message2);
                    Response.Write("<script>alert('Email sent to Requestor');</script>");
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Email Sent To Requestor')", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Email Coulnt Be Sent Try Again')", true);
                }


                //if (Type == "Urgent")
                //{
                //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                //    Session["valdate"] = valdate;
                //    Session["interval"] = 14400000;
                //    Session["Act_Email"] = Act_Email;
                //    Session["Ref_No"] = Ref_No;
                //    Session["Prob_Desc"] = Prob_Desc;
                //    Session["Req_Name"] = Req_Name;


                //}

                //if (Type == "Priority")
                //{
                //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                //    Session["valdate"] = valdate;
                //    Session["interval"] = 28800000;
                //    Session["Act_Email"] = Act_Email;
                //    Session["Ref_No"] = Ref_No;
                //    Session["Prob_Desc"] = Prob_Desc;
                //    Session["Req_Name"] = Req_Name;


                //}
                //if (Type == "Normal")
                //{
                //    DateTime valdate = Convert.ToDateTime(Request.Cookies[cookname].Value);
                //    Session["valdate"] = valdate;

                //    Session["interval"] = 129600000;
                //    Session["Act_Email"] = Act_Email;
                //    Session["Ref_No"] = Ref_No;
                //    Session["Prob_Desc"] = Prob_Desc;
                //    Session["Req_Name"] = Req_Name;


                //}


               
            }
           Server.Transfer("AddReq.aspx");

            }

                       
            
      
        

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            TextBox2.Text = "";
            DropDownList6.SelectedItem.Value = "Meet Hours";
            TextBox4.Text = "";
            TextBox7.Text = "";
            TextBox2.Focus();
            TextBox6.Text = "";
            CheckBox1.Checked = true;

          


            bl refa = new bl();
            try
            {
                int refno = refa.refret();
                TextBox1.Text = refno.ToString();
            }
            catch {
                TextBox1.Text = ""; 
            
            }

        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable=false;

            }
        }


   

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }


    
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

          
           // this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        protected void FileUpload1_Click(object sender, ImageClickEventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.FileName != null)
                {

                    g.fileName = FileUpload1.PostedFile.FileName;
                    string[] matchextension = { ".JPG", ".JPEG",".PNG", ".pdf", ".docx", ".doc" };

                    string fileExtension = System.IO.Path.GetExtension(g.fileName);

                    if ((matchextension.Contains(fileExtension)))
                    {
                        int fileLengthInKB = FileUpload1.PostedFile.ContentLength / 2048;

                        if (fileLengthInKB <= 2048)
                        {


                            FileUpload1.SaveAs(Server.MapPath(@"~/" + g.fileName));
                        
                            //g.path = Server.MapPath(@"c:/badari/reqapp/images/" + g.fileName);

                            Response.Write("<script>alert(' File Saved Successfully');</script>");
                            FileUpload1.Dispose();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert(' Please select file attachment less than 2MB')", true);

                           

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Please select file attachment of type .Pdf .Jpg .Jpeg .png .doc .docx')", true);

                     

                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('Please select file attachment')", true);
                   

                }
            }
        }

        protected void FileView_Click(object sender, ImageClickEventArgs e)
        {


          
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {



            Session["file"] = g.fileName;

            if (g.fileName != null)
            {
                Response.Write(@"<script> window.open('fileview.aspx','Attachment View','width=400,height=400,left=500,top=150');</script>");
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('No file to display in folder/ Check file name or upload again')", true);

              
            
            }
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {

            string filepath = @"~/inetpub/wwwroot/reqapp/";
            if (g.fileName != "")
            {
                string filename = g.fileName;

                string fullfilename = filepath + filename;

                if (File.Exists(Server.MapPath(@"~\" + filename)))
                {

                    File.Delete(Server.MapPath(@"~\" + filename));
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('File Deleted Successfully')", true);

                    g.fileName = "";

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('No File to Delete/ Check whether File exists in folder')", true);
                 
                }
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript", "alert('No File to Delete/ Check whether File exists in folder')", true);
                 
              
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}