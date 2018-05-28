using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airod_protottype
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cid = Request.QueryString["order_no"];
            
            bl tabsho = new bl();
            GridView1.DataSource = tabsho.showgrid(cid);
            GridView1.DataBind();
            GridView1.Enabled = true;
            GridView1.Visible = true;
        }
    }
}