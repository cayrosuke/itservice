using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace airod_protottype
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Session.Timeout = 20000;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null)
            {
                string cat = string.Empty;
                string un = TextBox1.Text;
                string pwd = TextBox2.Text;
                bl c = new bl();
                try
                {
                    cat = c.verpwd(un, pwd);
                }
                catch {
                    cat = null;
                }

                if (cat == "")
                {
                    Response.Write("<script>alert('Invalid Username / Password');</script>");
                }
                else
                {
                    Session["username"] = TextBox1.Text;

                    Server.Transfer("main.aspx");

                }

            }
        }






        protected void Button3_Click(object sender, EventArgs e)
        {


            TextBox1.Text = "";
            TextBox2.Text = "";

        }

    }
   
}