using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airod_protottype
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string ordnohyp = string.Empty;
                ordnohyp = Request.QueryString["Order_No"];
                bl SHWGRID = new bl();

                GridView2.DataSource = SHWGRID.showgrid(ordnohyp);
                GridView2.DataBind();
                GridView2.Enabled = true;
                GridView2.Visible = true;

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string hypsel = ((HyperLink)GridView1.SelectedRow.Cells[1].Controls[0]).Text;



        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            



        }

        protected void GridView3_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            
                if (e.CommandName == "ProdBtn")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView3.Rows[index];
                    HyperLink hl = (HyperLink)row.FindControl("HyperLink1");
                    string ordno = hl.Text;
                    //   int n = hl.TabIndex;
                    // TableCell sitenamecell = row.Cells[n];
                    // string orderno = sitenamecell.Text;
                    bl SHWGRID = new bl();
                    GridView2.DataSource = SHWGRID.showgrid(ordno);
                    GridView2.DataBind();
                    GridView2.Enabled = true;
                    GridView2.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + SHWGRID.showgrid(ordno) + "', 400, 950 , 40 ,true); </script>", false);
                }

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
                    if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(e.Row.RowIndex == 0)
           e.Row.Style.Add("height","60px");
        }
        }
    }
}