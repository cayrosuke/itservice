using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace airod_protottype
{

    public partial class WebForm6 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                TextBox7.Text = DateTime.Today.ToShortDateString();
                //TextBox7.Enabled = false;
                bl mod = new bl();

                int refno = 1;

                MySqlDataReader dd = null;

                try
                {
                    dd = mod.modreq(refno);
                    TextB.Text = dd.GetString("Req_Name");
                    TextBox5.Text = dd.GetString("Prob_Desc");
                    TextBox6.Text = dd.GetDateTime("Rec_Date").ToString("dd/MM/yyyy");
                    acttak.Text = dd.GetString("Action");
                    //TextBox14 .Text  = dd.GetString("Act_date");
                    string comtype = dd.GetString("Com_Type");
                    string airod = "AIROD";
                    string nadi = "NADI";
                    string ae = "AIROD AEROSPACE TECHNOLOGY";
                    string at = "AIROD TECHNO POWER";
                    string ina = "INAYAH";
                    string adc = "AVIATION DESIGN CENTRE";
                    string al = "AEROLOGICA";

                    if (string.Compare(comtype, airod) == 0)
                    {
                        DropDownList3.SelectedValue = "AIROD";

                    }
                    if (string.Compare(comtype, airod) == 0)
                    {
                        DropDownList3.SelectedIndex = 0;

                    } if (string.Compare(comtype, nadi) == 0)
                    {
                        DropDownList3.SelectedIndex = 1;

                    } if (string.Compare(comtype, ae) == 0)
                    {
                        DropDownList3.SelectedIndex = 3;

                    } if (string.Compare(comtype, at) == 0)
                    {
                        DropDownList3.SelectedIndex = 4;

                    } if (string.Compare(comtype, ina) == 0)
                    {
                        DropDownList3.SelectedIndex = 2;

                    } if (string.Compare(comtype, adc) == 0)
                    {
                        DropDownList3.SelectedIndex = 5;
                    } if (string.Compare(comtype, al) == 0)
                    {
                        DropDownList3.SelectedIndex = 6;
                    }
                    if (dd["Req_Email"] != System.DBNull.Value)
                    {
                        TextBox9.Text = dd.GetString("Req_Email");
                    }
                    if (dd["Act_Email"] == "tfarzlan@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "FARZLAN";
                    }
                    else if (dd["Act_Email"] == "afrah@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "AFRAH";
                    }
                    else if (dd["Act_Email"] == "nabkhan@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "NABHAN";
                    }
                    else if (dd["Act_Email"] == "buswani@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "";
                    }
                    else if (dd["Act_Email"] == "khairilimran@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "KHAIRIL";
                    }
                    else if (dd["Act_Email"] == "fawwaz@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "FAWWAZ";
                    }
                    else if (dd["Act_Email"] == "kuan@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "KUAN";
                    }
                    else if (dd["Act_Email"] == "norasikin@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "";
                    }
                    else if (dd["Act_Email"] == "khalidsn@aerologica.com")
                    {
                        DropDownList2.SelectedValue = "KHALID";
                    }

                }

                catch
                {
                    dd = null;

                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            bl mod = new bl();

            int refno = int.Parse(DropDownList1.SelectedItem.Text);

            MySqlDataReader dd = null;

            try
            {

                dd = mod.modreq(refno);
                if (dd["Req_Status"] != System.DBNull.Value)
                {
                    DropDownList4.SelectedValue = dd.GetString("Req_Status");
                }

                if (dd["ServiceType"] != System.DBNull.Value)
                {
                    ddlType.SelectedValue = dd.GetString("ServiceType");
                }
                //if (dd["Remarks"] != System.DBNull.Value)
                //{

                //    //DropDownList5.SelectedValue = dd.GetString("Remarks");
                //}

                if (dd["Action"] != System.DBNull.Value)
                {

                    acttak.Text = dd.GetString("Action");

                }
                TextB.Text = dd.GetString("Req_Name");
                TextBox5.Text = dd.GetString("Prob_Desc");
                if (dd["Req_Time"] != System.DBNull.Value)
                {
                    TextBox11.Text = dd.GetInt16("Req_Time").ToString();
                }
                if (dd["Req_Email"] != System.DBNull.Value)
                {

                    TextBox9.Text = dd.GetString("Req_Email");
                }
                else
                {
                    TextBox9.Text = "";
                }
                string comtype = string.Empty;
                if (dd["Com_Type"] != System.DBNull.Value)
                {
                    comtype = dd.GetString("Com_Type");
                }
                DateTime hours = Convert.ToDateTime(dd["Rec_Date"]);

                if ((hours) != null)
                {

                    TextBox12.Text = Convert.ToString((hours).Hour);
                    TextBox13.Text = Convert.ToString((hours).Minute);
                }

                TextBox14.Text = dd.GetString("Escalate_Date");

                //To calculate escalate time       
                DateTime escalate = Convert.ToDateTime(dd["Escalate_Date"]);
                string a = dd.GetString("Escalate_Date");
                DateTime date_now = DateTime.Now;
                string total;

                if (TextBox11.Text == null) //If no value or data
                {
                    TimeSpan diff = date_now - escalate;
                    double diffInHours = diff.TotalHours;
                    //TextBox11.Text = diff.ToString(@"hh\.mm");
                    //total = String.Format("{0:0.00}", diff.TotalMinutes);
                    //total = String.Format("{0:00}:{1:00}:{2:00}", diff.Hours, diff.Minutes, diff.Seconds);
                    //total = String.Format("{0} days, {1} hours, {2} minutes,", diff.Days, diff.Hours, diff.Minutes);
                    //TextBox11.Text = diff.ToString("hh:mm");
                    TextBox11.Text = diffInHours.ToString("0");
                }

                else
                {
                    TextBox11.Text = "";
                    TextBox11.Text = dd.GetString("Req_Time"); //Data from DB
                }
                //end calculation
                //From Req_Time -  Meet Hours OR Not Meet Hours
                string Type = dd.GetString("Type");
                string Remarks = "";
                double d = double.Parse(TextBox11.Text);

                if (Type == "Normal")
                {
                    if ((d >= 0.00) && (d <= 38.00))
                    {
                        Remarks = "Meet Hours";
                    }
                    else
                    {
                        Remarks = "Not Meet Hours";
                    }
                    //TextBox7.Text = Type + "" + Remarks;   
                }
                if (Type == "Priority")
                {
                    if ((d >= 0.00) && (d <= 8.00))
                    {
                        Remarks = "Meet Hours";
                    }
                    else
                    {
                        Remarks = "Not Meet Hours";
                    }
                    //TextBox7.Text = Type + "" + Remarks;
                }
                if (Type == "Urgent")
                {
                    if ((d >= 0.00) && (d <= 4.00))
                    {
                        Remarks = "Meet Hours";
                    }
                    else
                    {
                        Remarks = "Not Meet Hours";
                    }
                    //TextBox7.Text = Type + "" + Remarks;
                }

                //end calculation
                string airod = "AIROD";
                string nadi = "NADI";
                string ae = "AIROD AEROSPACE TECHNOLOGY";
                string at = "AIROD TECHNO POWER";
                string cm = "CONGIMGMT";
                string ina = "INAYAH";
                string adc = "AVIATION DESIGN CENTRE";
                string al = "AEROLOGICA";

                if (string.Compare(comtype, airod) == 0)
                {
                    DropDownList3.SelectedValue = "AIROD";

                }
                if (string.Compare(comtype, cm) == 0)
                {
                    DropDownList3.SelectedValue = "CONFIGMGMT";

                }
                if (string.Compare(comtype, airod) == 0)
                {
                    DropDownList3.SelectedIndex = 0;

                } if (string.Compare(comtype, nadi) == 0)
                {
                    DropDownList3.SelectedIndex = 1;

                } if (string.Compare(comtype, ae) == 0)
                {
                    DropDownList3.SelectedIndex = 3;

                } if (string.Compare(comtype, at) == 0)
                {
                    DropDownList3.SelectedIndex = 4;

                } if (string.Compare(comtype, ina) == 0)
                {
                    DropDownList3.SelectedIndex = 2;

                } if (string.Compare(comtype, adc) == 0)
                {
                    DropDownList3.SelectedIndex = 5;
                } if (string.Compare(comtype, al) == 0)
                {
                    DropDownList3.SelectedIndex = 6;
                }

                if (dd["Act_Email"] == "tfarzlan@aerologica.com")
                {
                    DropDownList2.SelectedValue = "FARZLAN";
                }
                else if (dd["Act_Email"] == "afrah@aerologica.com")
                {
                    DropDownList2.SelectedValue = "AFRAH";
                }
                else if (dd["Act_Email"] == "nabkhan@aerologica.com")
                {
                    DropDownList2.SelectedValue = "NABHAN";
                }
                else if (dd["Act_Email"] == "buswani@aerologica.com")
                {
                    DropDownList2.SelectedValue = "";
                }
                else if (dd["Act_Email"] == "khairilimran@aerologica.com")
                {
                    DropDownList2.SelectedValue = "KHAIRIL";
                }
                else if (dd["Act_Email"] == "fawwaz@aerologica.com")
                {
                    DropDownList2.SelectedValue = "FAWWAZ";
                }
                else if (dd["Act_Email"] == "kuan@aerologica.com")
                {
                    DropDownList2.SelectedValue = "KUAN";
                }
                else if (dd["Act_Email"] == "norasikin@aerologica.com")
                {
                    DropDownList2.SelectedValue = "";
                }
                else if (dd["Act_Email"] == "khalidsn@aerologica.com")
                {
                    DropDownList2.SelectedValue = "KHALID";
                }
                else if (dd["Act_Email"] == "farisya@aerologica.com")
                {
                    DropDownList2.SelectedValue = "FARISYA";
                }
                else if (dd["Act_Email"] == "redzuan@aerologica.com")
                {
                    DropDownList2.SelectedValue = "REDZUAN";
                }
                else if (dd["Act_Email"] == "kamisah@aerologica.com")
                {
                    DropDownList2.SelectedValue = "KAMISAH";
                }
                else if (dd["Act_Email"] == "norhaslinda@aerologica.com")
                {
                    DropDownList2.SelectedValue = "HASLINDA";
                }
                else if (dd["Act_Email"] == "shamil@aerologica.com")
                {
                    DropDownList2.SelectedValue = "SHAMIL";
                }

            }
            catch { dd = null; }
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
            bl mod = new bl();

            int refno = int.Parse(DropDownList1.SelectedItem.Text);

            MySqlDataReader dd = null;

            try
            {

                dd = mod.modreq(refno);
                acttak.Text = "";
                TextB.Text = dd.GetString("Req_Name");
                TextBox5.Text = dd.GetString("Prob_Desc");
                TextBox6.Text = dd.GetDateTime("Rec_Date").ToString("dd/MM/yyyy");
                TextBox6.Enabled = false;
                if (dd["Req_Status"] != System.DBNull.Value)
                {
                    DropDownList4.SelectedItem.Text = dd.GetString("Req_Status");
                }
                //if (dd["Remarks"] != System.DBNull.Value)
                //{

                //    DropDownList5.SelectedValue = dd.GetString("Remarks");
                //}

                if (dd["Action"] != System.DBNull.Value)
                {
                    acttak.Text = dd.GetString("Action");
                }

                string comtype = string.Empty;
                if (dd["Com_Type"] != System.DBNull.Value)
                {
                    comtype = dd.GetString("Com_Type");
                }

                //To calculate escalate time    
                DateTime escalate;
                if (TextBox14.Text == "")
                {
                    escalate = DateTime.Now;
                    TextBox14.Text = escalate.ToString();
                }
                else
                {
                    escalate = Convert.ToDateTime(dd["Escalate_Date"]);
                }

                DateTime date_now = DateTime.Now;
                int count = 0;

                if (TextBox11.Text == "".Trim()) //If no value or data
                {
                    for (var i = escalate; i < date_now; i = i.AddHours(1))
                    {
                        if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (i.TimeOfDay.Hours >= 8 && i.TimeOfDay.Hours < 16)
                            {
                                count++;
                            }
                        }
                    }
                    TextBox11.Text = count.ToString();
                }
                else
                {
                    TextBox11.Text = "";
                    TextBox11.Text = dd.GetString("Req_Time"); //Data from DB
                }
                //end calculation


                string airod = "AIROD";
                string nadi = "NADI";
                string ae = "AIROD AEROSPACE TECHNOLOGY";
                string at = "AIROD TECHNO POWER";
                string cm = "CONFIGMGMT";
                string ina = "INAYAH";
                string adc = "AVIATION DESIGN CENTRE";
                string al = "AEROLOGICA";

                if (dd["Req_Status"] != System.DBNull.Value)
                {
                    DropDownList4.SelectedValue = dd.GetString("Req_Status");
                }

                if (string.Compare(comtype, airod) == 0)
                {
                    DropDownList3.SelectedValue = "AIROD";

                }
                if (string.Compare(comtype, cm) == 0)
                {
                    DropDownList3.SelectedValue = "CONFIGMGMT";

                }
                if (string.Compare(comtype, airod) == 0)
                {
                    DropDownList3.SelectedIndex = 0;

                } if (string.Compare(comtype, nadi) == 0)
                {
                    DropDownList3.SelectedIndex = 1;

                } if (string.Compare(comtype, ae) == 0)
                {
                    DropDownList3.SelectedIndex = 3;

                } if (string.Compare(comtype, at) == 0)
                {
                    DropDownList3.SelectedIndex = 4;

                } if (string.Compare(comtype, ina) == 0)
                {
                    DropDownList3.SelectedIndex = 2;

                } if (string.Compare(comtype, adc) == 0)
                {
                    DropDownList3.SelectedIndex = 5;
                } if (string.Compare(comtype, al) == 0)
                {
                    DropDownList3.SelectedIndex = 6;
                }

                string actemail = dd["Act_Email"].ToString();

                if (actemail == "tfarzlan@aerologica.com")
                {
                    DropDownList2.SelectedValue = "FARZLAN";
                }
                else if (actemail == "afrah@aerologica.com")
                {
                    DropDownList2.SelectedValue = "AFRAH";
                }
                else if (actemail == "nabkhan@aerologica.com")
                {
                    DropDownList2.SelectedValue = "NABHAN";
                }
                else if (actemail == "buswani@aerologica.com")
                {
                    DropDownList2.SelectedValue = "";
                }
                else if (actemail == "khairilimran@aerologica.com")
                {
                    DropDownList2.SelectedValue = "KHAIRIL";
                }
                else if (actemail == "fawwaz@aerologica.com")
                {
                    DropDownList2.SelectedValue = "FAWWAZ";
                }
                else if (actemail == "kuan@aerologica.com")
                {
                    DropDownList2.SelectedValue = "KUAN";
                }
                else if (actemail == "norasikin@aerologica.com")
                {
                    DropDownList2.SelectedValue = "";
                }
                else if (actemail == "khalidsn@aerologica.com")
                {
                    DropDownList2.SelectedValue = "KHALID";
                }
                else if (actemail == "farisya@aerologica.com")
                {
                    DropDownList2.SelectedValue = "FARISYA";
                }
                else if (actemail == "redzuan@aerologica.com")
                {
                    DropDownList2.SelectedValue = "REDZUAN";
                }
                else if (actemail == "kamisah@aerologica.com")
                {
                    DropDownList2.SelectedValue = "KAMISAH";
                }
                else if (actemail == "norhaslinda@aerologica.com")
                {
                    DropDownList2.SelectedValue = "HASLINDA";
                }
                else if (actemail == "shamil@aerologica.com")
                {
                    DropDownList2.SelectedValue = "SHAMIL";
                }
                else if (actemail == "rozaidi@aerologica.com")
                {
                    DropDownList2.SelectedValue = "ROZAIDI";
                }
                else if (actemail == "afiq.wahab@aerologica.com")
                {
                    DropDownList2.SelectedValue = "AFIQ";
                }
                else if (actemail == "suhaila@aerologica.com")
                {
                    DropDownList2.SelectedValue = "SUHAILA";
                }
                else if (actemail == "ikram.ahmad@aerologica.com")
                {
                    DropDownList2.SelectedValue = "IKRAM";
                }
            }
            catch
            {

                dd = null;
            }
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Server.ScriptTimeout = 900000;
            acttak.Text = "";
            TextB.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox12.Text = "00";
            TextBox13.Text = "00";
            DropDownList1.Focus();
            DropDownList1.SelectedIndex = 0;

            bl mod = new bl();

            int refno = 1;

            MySqlDataReader dd = null;
            try
            {
                dd = mod.modreq(refno);
                if (dd["Action"] != System.DBNull.Value)
                {
                    acttak.Text = dd.GetString("Action");
                }
                TextB.Text = dd.GetString("Req_Name");
                TextBox5.Text = dd.GetString("Prob_Desc");
                TextBox6.Text = dd.GetDateTime("Rec_Date").ToString("dd/MM/yyyy");
                DropDownList4.SelectedItem.Text = dd.GetString("Req_Status");
                TextBox11.Text = "";
                if (dd["Req_Email"] != System.DBNull.Value)
                {
                    TextBox9.Text = dd.GetString("Req_Email");
                }
                else
                {
                    TextBox9.Text = "";
                }

                string comtype = dd.GetString("Com_Type");
                string airod = "AIROD";
                string nadi = "NADI";
                string ae = "AIROD AEROSPACE TECHNOLOGY";
                string at = "AIROD TECHNO POWER";
                string ina = "INAYAH";
                string adc = "AVIATION DESIGN CENTRE";
                string al = "AEROLOGICA";

                if (string.Compare(comtype, airod) == 0)
                {
                    DropDownList3.SelectedIndex = 0;

                } if (string.Compare(comtype, nadi) == 0)
                {
                    DropDownList3.SelectedIndex = 1;

                } if (string.Compare(comtype, adc) == 0)
                {
                    DropDownList3.SelectedIndex = 5;

                }
                if (string.Compare(comtype, ae) == 0)
                {
                    DropDownList3.SelectedIndex = 3;

                } if (string.Compare(comtype, at) == 0)
                {
                    DropDownList3.SelectedIndex = 4;

                } if (string.Compare(comtype, ina) == 0)
                {
                    DropDownList3.SelectedIndex = 2;
                } if (string.Compare(comtype, al) == 0)
                {
                    DropDownList3.SelectedIndex = 6;
                }


            }
            catch
            {
                dd = null;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Server.ScriptTimeout = 900000;
            string val = Request.Form["confirm_value"];
            //string val1=string.Empty;
            //string jsScript = "";
            //jsScript += "var answer=confirm(\'Action Already Taken do you want to modify?\');\n";
            //jsScript += "if(answer){\n";
            //jsScript += "'" + val1 + "'='YES'}\n";

            bl mod = new bl();

            int refno = int.Parse(DropDownList1.SelectedItem.Text);

            MySqlDataReader dd = null;
            dd = mod.modreq(refno);

            if (val == "YES")
            {

                if (acttak != null)
                {

                }
                bl upd = new bl();
                int Ref_No = int.Parse(DropDownList1.SelectedItem.Text);

                string Req_Name = TextB.Text;
                string Com_Type = DropDownList3.SelectedItem.Text;
                string Prob_Desc = TextBox5.Text;
                string Rec_Date = null;
                //string Rec_Date = Convert.ToDateTime(TextBox6.Text).ToString("yyyy/MM/dd hh:mm:ss");


                if ((TextBox12.Text == "") || (TextBox13.Text == ""))
                {

                    string Rec_Date1 = Convert.ToDateTime(TextBox6.Text).ToShortDateString() + " " + "00" + ":" + "00";
                    Rec_Date = Convert.ToDateTime(Rec_Date1).ToString("yyyy/MM/dd hh:mm:ss");
                }
                else
                {
                    string Rec_Date1 = Convert.ToDateTime(TextBox6.Text).ToShortDateString() + " " + TextBox12.Text + ":" + TextBox13.Text;
                    Rec_Date = Convert.ToDateTime(Rec_Date1).ToString("yyyy/MM/dd hh:mm:ss");
                }

                string Req_Email = TextBox9.Text;
                string Action = acttak.Text;
                string Action_By = DropDownList2.SelectedItem.Text;
                string Remarks = DropDownList5.SelectedItem.Value; //select manual for REMARKS and save data in "tbl_srvmast"
                string Com_Date = Convert.ToDateTime(TextBox7.Text).ToString("yyyy/MM/dd hh:mm:ss"); //select manual by user and save data in "tbl_srvmast"
                string Req_Status = DropDownList4.SelectedItem.Text;
                float Req_Times = Convert.ToInt32(TextBox11.Text);
                string servType = ddlType.SelectedItem.Text;

                DateTime Com_Dates = DateTime.Now; //complete date save in tbl_srvmast1 only
                DateTime escalate;

                //to calculate escalate time
                if (dd["Escalate_Date"].ToString() == "".Trim())
                {
                   escalate = DateTime.Now;
                   TextBox14.Text = escalate.ToString();
                }
                else
                {
                    escalate = Convert.ToDateTime(dd["Escalate_Date"]);
                }

                DateTime date_now = DateTime.Now;
                
                //Automation REMARK for bos only and save in TABLE "tbl_srvmast1"
                string Type = dd.GetString("Type");
                string Remark = "";
                double d = double.Parse(TextBox11.Text); //time comparison

                if (Type == "Normal")
                {
                    if ((d >= 0.00) && (d <= 38.00))
                    {
                        Remark = "Meet Hours";
                    }
                    else
                    {
                        Remark = "Not Meet Hours";
                    }
                    //TextBox7.Text = Type + "" + Remarks;
                }

                if (Type == "Priority")
                {
                    if ((d >= 0.00) && (d <= 8.00))
                    {
                        Remark = "Meet Hours";
                    }
                    else
                    {
                        Remark = "Not Meet Hours";
                    }
                    //TextBox7.Text = Type + "" + Remarks;
                }
                if (Type == "Urgent")
                {
                    if ((d >= 0.00) && (d <= 4.00))
                    {
                        Remark = "Meet Hours";
                    }
                    else
                    {
                        Remark = "Not Meet Hours";
                    }
                    //TextBox7.Text = Type + "" + Remarks;
                }
                //end calculation
                bool stat = false;
                try
                {
                    HttpContext.Current.Server.ScriptTimeout = 9000;
                    Server.ScriptTimeout = 900;

                    stat = upd.updreq(Ref_No, Req_Name, Com_Type, Prob_Desc, Rec_Date, Req_Email, Req_Status, Action, Action_By, Com_Date, Remarks, Req_Times, servType); //table for audit reference
                    stat = upd.updreq1(Ref_No, Req_Name, Com_Type, Prob_Desc, Rec_Date, Req_Email, Req_Status, Action, Action_By, Com_Dates, Remark, Req_Times, servType); //table for BUSWANI reference


                    if (stat)
                    {
                        Response.Write("<script>alert('UPDATED SUCCESSFULLY');</script>");
                        //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "myscript", "alert('MODIFIED SUCCESSFULLY')", true);
                        string formattedcomdate = Convert.ToDateTime(Com_Date).ToShortDateString();
                        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                        message.To.Add(Req_Email);
                        message.Subject = "Mail from Aerologica Service Team";
                        message.From = new System.Net.Mail.MailAddress("itservice@aerologica.com");
                        message.Body = "Respected   :     " + Req_Name +
                        Environment.NewLine
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Type of Service Request:   " + servType
                        + Environment.NewLine
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Your Problem Description:  " + Prob_Desc + "   has now been solved."
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Action Description : " + Action
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Action Taken By Aerologica IT Personnel: " + Action_By
                        + Environment.NewLine
                        + Environment.NewLine
                        + "on this date : " + formattedcomdate
                        + Environment.NewLine
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Thank you."
                        + Environment.NewLine
                        + "AeroLogica Sdn Bhd"
                        + Environment.NewLine
                        + "Tel No: 03 -7846 5112    Ext No: 273 / 314 /317  ";
                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("128.2.11.11");
                        smtp.Port = 25;

                        try
                        {
                            Response.Write("<script>alert('Email sent to Requestor Successfully');</script>");
                            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript1", "alert('Email Sent Successfully')", true);
                            smtp.Send(message);
                        }
                        catch
                        {
                            Response.Write("<script>alert('Email COULDNT BE sent to Requestor');</script>");
                            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myscript2", "alert('Email Couldnt be Sent')", true);

                        }
                    }

                }
                catch
                {
                    Response.Write("<script>alert('COULDNT UPDATE THE RECORD TRY AGAIN');</script>");
                    stat = false;
                }
            }

        }


        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}