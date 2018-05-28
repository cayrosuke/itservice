using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace airod_protottype
{
    public partial class View_Request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 10000;
           
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
     
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {   
       
              
               
            }



        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            
            var hold = Request.Form["confirm_value"];

            if (hold == "YES")
            {

                bl del = new bl();


                int Ref_No;
                HttpContext.Current.Server.ScriptTimeout = 9000;
                Server.ScriptTimeout = 900;

                Ref_No =Convert.ToInt32(DropDownList1.SelectedItem.Text);
                bool flag = del.delre(Ref_No);

                    if (flag)
                    {
                        Response.Write("<script>alert('Deleted Successfully');</script>");
                        SqlDataSource1.SelectCommand = "SELECT * FROM tbl_srvmast";
                        SqlDataSource1.DataBind();
                        SqlDataSource2.SelectCommand = "SELECT * FROM tbl_srvmast";
                        SqlDataSource2.DataBind();
                        GridView1.DataBind();
                        DropDownList1.SelectedIndex = 0;

                    }
                    else
                    {
                        Response.Write("<script>alert ('Delete Unsuccessfull');</script>");
                    }
              
                //int count = GridView1.Rows.Count;
                

                //database Helper
                //foreach( GridViewRow row in GridView1.Rows)
                //{


                //    var chk = row.FindControl("checkbox1") as CheckBox;
                //    if (chk != null)
                //    {
                //        if (chk.Checked == true)
                //        {
                //            int refnohold = int.Parse(row.Cells[1].Text);
                //            if (refnohold == 1) {
                //                Response.Write("<script> alert(' You cannot delete the First Record');</script>");
                //                Server.Transfer("ViewReq.aspx");
                //            }
                //            try
                //            {
                //                bool flag = del.delre(refnohold);
                //                chk = null;

                //                Response.Write("<script>alert('Deleted Successfully');</script>");
                //                GridView1.DataBind();
                //                DropDownList1.SelectedIndex = 0;
                //            }
                //            catch
                //            {


                //                Response.Write("<script>alert ('Delete Unsuccessfull');</script>");
                //            }

                            

                        
                //        }   
                //    } 

                //}



            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Ref_No = Convert.ToInt16(DropDownList1.SelectedItem.Text);


            SqlDataSource1.SelectCommand="Select * from tbl_srvmast WHERE Ref_No='"+Ref_No+"'";

            SqlDataSource1.DataBind();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "select * from tbl_srvmast";

            SqlDataSource1.DataBind();
        }
}
}
