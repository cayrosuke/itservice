using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airod_protottype
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
          
            if (!IsPostBack)
            {
                bl add = new bl();
                int refno = add.refret();
                TextBox1.Text = refno.ToString();
                TextBox1.Enabled = false;
            


            } TextBox1.Attributes.Add("onKeyDown()", "KeyDownHandler()");
         
            
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
                bool flag = true;

                string confrim_value = Request.Form["Confirm_Value"];
                if ((TextBox4.Text=="")) {
                    Response.Write("<script>alert('Problem Cannot be Blank')</script>");
                    TextBox4.Focus();
                    flag = false;
                }
                
                if((TextBox6.Text==""))
                   
                    {Response.Write("<script>alert('Received Date Cannot be Blank')</script>");
                    TextBox6.Focus();
                    flag = false;
                   }
                
                    
                

                    if((confrim_value=="YES")&&(flag==true))
                {
                            int Ref_No = Int32.Parse(TextBox1.Text);
                            string Rec_Date = Calendar1.SelectedDate.ToShortDateString();
                            string Prob_Desc = TextBox4.Text;
                            string Type = DropDownList2.SelectedItem.Text;
                            string Remarks = TextBox3.Text;
                            string Req_Name = TextBox2.Text;
                            string Com_Type = DropDownList3.SelectedValue.ToString();
                      
                            bl c = new bl();

                            if (c.addsrvreq(Ref_No, Rec_Date, Req_Name, Prob_Desc,Type,Com_Type,Remarks))
                            {
                                Response.Write("<script> alert('Record Updated Successfully')</script>");
                                Response.Redirect("WebForm1.aspx");

                            }
         
                            else
                            { 
                                Response.Write("<script> alert('Update Unsuccessful')</script>");
                            }
                }
                    if(flag == false) {
                    Response.Write("<script> alert('Update Unsuccessful')</script>");
                    }
            }
        

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
          
            TextBox2.Focus();
            TextBox6.Text = "";
 

            Calendar1.SelectedDate = DateTime.Today;


            bl refa = new bl();

            int refno=refa.refret();
            TextBox1.Text = refno.ToString();


        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable=false;

            }
        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            TextBox6.Text = Calendar1.SelectedDate.ToShortDateString();

        }

   

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

          
           // this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }
    }
}