using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace airod_protottype
{
    public partial class fileview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path = Session["file"];
            var path1 = @"~/";

            if (path!="")
            {
                Response.Redirect(System.IO.Path.Combine(path1 + path));
            }
            else
            {

                Response.Write("<script>alert(' File not found try again');</script>");
            
            }
    }
    }
}