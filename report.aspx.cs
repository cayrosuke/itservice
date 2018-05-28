using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports;
using System.Web.ClientServices.Providers;
using System.Data.SqlClient;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Drawing;

namespace airod_protottype
{
    public partial class report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session.Timeout = 10000;


            //int meet = retmeet1();
            //int meet1 = retmeet2();


            //double[] yyValues = { meet, meet1 };
            //string[] xxValues = { "MEET HOURS", "NOT MEET HOURS" };
            //Chart3.Series["Default1"].Points.DataBindXY(xxValues, yyValues);
            //Chart3.Series["Default1"].Points[0].Color = Color.Green;
            //Chart3.Series["Default1"].Points[1].Color = Color.Yellow;
            //Chart3.Series["Default1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            //Chart3.Legends.Add("MEET HOURS" + meet);
            //Chart3.Legends.Add("NOT MEET HOURS" + meet1);
            //Chart3.Series["Default1"].Points[0].Label = "#PERCENT" + "   MEET HOURS";
            //Chart3.Series["Default1"].Points[1].Label = "#PERCENT" + "   NOT MEET HOURS";
            //Chart3.Series["Default1"]["PieLabelStyle"] = "Disabled";
            //Chart3.Series["Default1"].IsVisibleInLegend = true;
            //Chart3.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = true;
            //Chart3.Visible = true;
            //Chart3.Enabled = true;


            //int Type = Typeret();
            //int Type1 = Typeret1();
            //int Type2 = Typeret2();


            //double[] tValues = { Type, Type1, Type2 };
            //string[] pValues = { "Priority", "Normal", "Urgent" };
            //Chart4.Series["Default3"].Points.DataBindXY(pValues, tValues);
            //Chart4.Series["Default3"].Points[0].Color = Color.Green;
            //Chart4.Series["Default3"].Points[1].Color = Color.Yellow;
            //Chart4.Series["Default3"].Points[2].Color = Color.Black;
            //Chart4.Series["Default3"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            //Chart4.Legends.Add("Priority");
            //Chart4.Legends.Add("Normal");
            //Chart4.Legends.Add("Urgent");
            //Chart4.Series["Default3"].Points[0].Label = "#PERCENT" + " PRIORITY";
            //Chart4.Series["Default3"].Points[1].Label = "#PERCENT" + " NORMAL";
            //Chart4.Series["Default3"].Points[2].Label = "#PERCENT" + " URGENT";
            //Chart4.Series["Default3"]["PieLabelStyle"] = "Disabled";
            //Chart4.Series["Default3"].IsVisibleInLegend = true;
            //Chart4.ChartAreas["ChartArea3"].Area3DStyle.Enable3D = true;
            //Chart4.Visible = true;
            //Chart4.Enabled = true;
        }

        protected int allretdata1()
        {

            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";
            using (con = new MySqlConnection(str))
            {

                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;


                }
                int num = 0;


                string sq = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='AIROD'");

                cmd.CommandText = sq;

                MySqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {

                    num++;


                }

                return num;
            }
        }

        protected int allretdata2()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }
                int num1 = 0;


                string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='AIROD AEROSPACE'");

                cmd.CommandText = sq1;
                MySqlDataReader dr1 = cmd.ExecuteReader();



                while (dr1.Read())
                {


                    num1++;

                }



                return num1;
            }
        }

        protected int allnadiret()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }
                int nadinum = 0;


                string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='NADI'");

                cmd.CommandText = sq1;
                MySqlDataReader dr1 = cmd.ExecuteReader();



                while (dr1.Read())
                {


                    nadinum++;

                }



                return nadinum;
            }
        }

        protected int allaerotechret()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }
                int aerotecnum = 0;

                string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='AIROD TECHNO POWER'");

                cmd.CommandText = sq1;
                MySqlDataReader dr1 = cmd.ExecuteReader();



                while (dr1.Read())
                {


                    aerotecnum++;

                }



                return aerotecnum;
            }
        }

        protected int allconfigret()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }
                int confignum = 0;


                string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='CONFIGMGMT'");

                cmd.CommandText = sq1;
                MySqlDataReader dr1 = cmd.ExecuteReader();



                while (dr1.Read())
                {


                    confignum++;

                }



                return confignum;
            }
        }
        protected int retdata1()
        {

            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";
            using (con = new MySqlConnection(str))
            {

                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;


                }
                int num = 0;
                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;

                    string sq = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='AIROD'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %H:%i:%s')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %H:%i:%s')");

                    cmd.CommandText = sq;

                    MySqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {

                        num++;


                    }

                }
                return num;
            }
        }

        protected int retdata2()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }
                int num1 = 0;
                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;

                    string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='AIROD AEROSPACE'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %H:%i:%s')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %H:%i:%s')");

                    cmd.CommandText = sq1;
                    MySqlDataReader dr1 = cmd.ExecuteReader();



                    while (dr1.Read())
                    {


                        num1++;

                    }


                }
                return num1;
            }
        }

        protected int nadiret()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }
                int nadinum = 0;
                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;

                    string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='NADI'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %H:%i:%s')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %H:%i:%s')");

                    cmd.CommandText = sq1;
                    MySqlDataReader dr1 = cmd.ExecuteReader();



                    while (dr1.Read())
                    {


                        nadinum++;

                    }


                }
                return nadinum;
            }
        }

        protected int aerotechret()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }
                int aerotecnum = 0;
                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;

                    string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='AIROD TECHNO POWER'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %H:%i:%s')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %H:%i:%s')");

                    cmd.CommandText = sq1;
                    MySqlDataReader dr1 = cmd.ExecuteReader();



                    while (dr1.Read())
                    {


                        aerotecnum++;

                    }


                }
                return aerotecnum;
            }
        }

        protected int configret()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }
                int confignum = 0;
                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;

                    string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Com_Type='CONFIGMGMT'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %H:%i:%s')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %H:%i:%s')");

                    cmd.CommandText = sq1;
                    MySqlDataReader dr1 = cmd.ExecuteReader();



                    while (dr1.Read())
                    {


                        confignum++;

                    }


                }
                return confignum;
            }
        }

        protected int allretmeet1()
        {

            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {

                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }




                string sq = string.Format("SELECT * FROM tbl_srvmast WHERE Remarks='Meet Hours'");

                cmd.CommandText = sq;

                MySqlDataReader dr = cmd.ExecuteReader();
                int meet = 0;

                while (dr.Read())
                {

                    meet++;


                }
                return meet;

            }
        }


        protected int allretmeet2()
        {

            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;

                }

                int meet1 = 0;




                string sql = string.Format("SELECT * FROM tbl_srvmast WHERE Remarks='Not Meet Hours'");


                cmd.CommandText = sql;
                MySqlDataReader dr1 = cmd.ExecuteReader();


                while (dr1.Read())
                {


                    meet1++;

                }

                return meet1;
            }

        }

        protected int retmeet1()
        {

            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {

                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    cmd.Connection = con;
                }

                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {


                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;


                    string sq = string.Format("SELECT * FROM tbl_srvmast WHERE Remarks='Meet Hours'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %r:%r:%r')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %r:%r:%r')" + "AND Com_Type='" + DropDownList1.SelectedItem.Text + "'" + "AND Req_Status='" + DropDownList2.SelectedItem.Text + "'");

                    cmd.CommandText = sq;

                    MySqlDataReader dr = cmd.ExecuteReader();
                    int meet = 0;

                    while (dr.Read())
                    {

                        meet++;


                    }
                    return meet;
                }
                else
                {

                    return 0;
                }
            }
        }


        protected int retmeet2()
        {

            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;

                }

                int meet1 = 0;

                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;


                    string sql = string.Format("SELECT * FROM tbl_srvmast WHERE Remarks='Not Meet Hours'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %r:%r:%r')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %r:%r:%r')" + "AND Com_Type='" + DropDownList1.SelectedItem.Text + "'" + "AND Req_Status='" + DropDownList2.SelectedItem.Text + "'");


                    cmd.CommandText = sql;
                    MySqlDataReader dr1 = cmd.ExecuteReader();


                    while (dr1.Read())
                    {


                        meet1++;

                    }

                    return meet1;
                }
                else
                {
                    return 0;
                }
            }
        }

        protected int allTyperet()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;

                }




                string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Type='Priority'");




                cmd.CommandText = sq1;
                MySqlDataReader dr1 = cmd.ExecuteReader();

                int Type1 = 0;

                while (dr1.Read())
                {


                    Type1++;

                }

                return Type1;

            }
        }



        protected int allTyperet1()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;

                }



                string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Type='Normal'");


                cmd.CommandText = sq1;
                MySqlDataReader dr1 = cmd.ExecuteReader();

                int Type2 = 0;

                while (dr1.Read())
                {


                    Type2++;

                }

                return Type2;
            }


        }
        protected int allTyperet2()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }





                string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Type='Urgent'");


                cmd.CommandText = sq1;
                MySqlDataReader dr1 = cmd.ExecuteReader();

                int Type3 = 0;

                while (dr1.Read())
                {


                    Type3++;

                }

                return Type3;
            }



        }

        protected int Typeret()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;

                }
                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;



                    string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Type='Priority'" + "AND Com_Type='" + DropDownList1.SelectedItem.Text + "'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %r:%r:%r')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %r:%r:%r')" + "AND Req_Status='" + DropDownList2.SelectedItem.Text + "'");




                    cmd.CommandText = sq1;
                    MySqlDataReader dr1 = cmd.ExecuteReader();

                    int Type1 = 0;

                    while (dr1.Read())
                    {


                        Type1++;

                    }

                    return Type1;


                }
                else
                {

                    return 0;
                }
            }
        }


        protected int Typeret1()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;

                }

                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;



                    string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Type='Normal'" + "AND Com_Type='" + DropDownList1.SelectedItem.Text + "'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %r:%r:%r')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %r:%r:%r')" + "AND Req_Status='" + DropDownList2.SelectedItem.Text + "'");


                    cmd.CommandText = sq1;
                    MySqlDataReader dr1 = cmd.ExecuteReader();

                    int Type2 = 0;

                    while (dr1.Read())
                    {


                        Type2++;

                    }

                    return Type2;
                }
                else
                {

                    return 0;
                }

            }

        }
        protected int Typeret2()
        {


            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            string str = @"server=localhost;database=airod;userid=root;password=1234;";

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }


                if ((TextBox1.Text != null) && (TextBox2.Text != null))
                {
                    string recsdate = TextBox1.Text;
                    string recedate = TextBox2.Text;



                    string sq1 = string.Format("SELECT * FROM tbl_srvmast WHERE Type='Urgent'" + "AND Com_Type='" + DropDownList1.SelectedItem.Text + "'" + "AND Rec_Date>= STR_TO_DATE('" + recsdate + "','%Y/%m/%d %r:%r:%r')" + "AND Rec_Date<= STR_TO_DATE('" + recedate + "','%Y/%m/%d %r:%r:%r')" + "AND Req_Status='" + DropDownList2.SelectedItem.Text + "'");


                    cmd.CommandText = sq1;
                    MySqlDataReader dr1 = cmd.ExecuteReader();

                    int Type3 = 0;

                    while (dr1.Read())
                    {


                        Type3++;

                    }

                    return Type3;
                }
                else
                {

                    return 0;
                }

            }
        }






        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            CrystalReportViewer1.SelectionFormula = "";
            CrystalReportViewer1.RefreshReport();
            int num = allretdata1();
            int num1 = allretdata2();
            int num2 = allnadiret();
            int num3 = allaerotechret();
            int num4 = allconfigret();


            double[] yValues = { num, num1, num2, num3, num4 };
            string[] xValues = { "AIROD", "AIROD AEROSPACE", "NADI", "TECHPOWER", "INAYAH" };
            Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
            Chart1.Series["Default"].Points[0].Color = Color.Blue;
            Chart1.Series["Default"].Points[1].Color = Color.Red;
            Chart1.Series["Default"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart1.Legends.Add("AIROD");
            Chart1.Legends.Add("AIROD AEROSPACE" + num1);
            Chart1.Series["Default"].IsVisibleInLegend = true;
            Chart1.Series["Default"].Points[0].Label = "#PERCENT" + "   AIROD";
            Chart1.Series["Default"].Points[1].Label = "#PERCENT" + "   AIROD AEROSPACE";
            Chart1.Series["Default"].Points[2].Label = "#PERCENT" + "   NADI";
            Chart1.Series["Default"].Points[3].Label = "#PERCENT" + "   TECHPOWER";
            Chart1.Series["Default"].Points[4].Label = "#PERCENT" + "   INAYAH";

            Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Visible = true;
            Chart1.Enabled = true;
            int meet = allretmeet1();
            int meet1 = allretmeet2();

            Chart3.Legends.Clear();
            Chart3.DataBind();

            double[] yyValues = { meet, meet1 };
            string[] xxValues = { "MEET HOURS", "NOT MEET HOURS" };
            Chart3.Series["Default1"].Points.DataBindXY(xxValues, yyValues);
            Chart3.Series["Default1"].Points[0].Color = Color.Green;
            Chart3.Series["Default1"].Points[1].Color = Color.Yellow;
            Chart3.Series["Default1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart3.Legends.Add("MEET HOURS" + meet);
            Chart3.Legends.Add("NOT MEET HOURS" + meet1);
            Chart3.Series["Default1"].Points[0].Label = "#PERCENT" + "   MEET HOURS";
            Chart3.Series["Default1"].Points[1].Label = "#PERCENT" + "   NOT MEET HOURS";
            Chart3.Series["Default1"]["PieLabelStyle"] = "Disabled";
            Chart3.Series["Default1"].IsVisibleInLegend = true;
            Chart3.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = true;
            Chart3.Visible = true;
            Chart3.Enabled = true;



            int Type1 = allTyperet();
            int Type2 = allTyperet1();
            int Type3 = allTyperet2();

            Chart4.Legends.Clear();
            Chart4.Series["Default3"]["PieLabelStyle"] = "Disabled";
            double[] tValues = { Type1, Type2, Type3 };
            string[] pValues = { "Priority", "Normal", "Urgent" };
            Chart4.Series["Default3"].Points.DataBindXY(pValues, tValues);
            Chart4.Series["Default3"].Points[0].Color = Color.Green;
            Chart4.Series["Default3"].Points[1].Color = Color.Yellow;
            Chart4.Series["Default3"].Points[2].Color = Color.Black;
            Chart4.Series["Default3"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart4.Legends.Add("Priority");
            Chart4.Legends.Add("Normal");
            Chart4.Legends.Add("Urgent");
            Chart4.Series["Default3"].Points[0].Label = "#PERCENT" + " PRIORITY";
            Chart4.Series["Default3"].Points[1].Label = "#PERCENT" + " NORMAL";
            Chart4.Series["Default3"].Points[2].Label = "#PERCENT" + " URGENT";

            Chart4.Series["Default3"]["PieLabelStyle"] = "Disabled";
            Chart4.Series["Default3"].IsVisibleInLegend = true;
            Chart4.ChartAreas["ChartArea3"].Area3DStyle.Enable3D = true;
            Chart4.Visible = true;
            Chart4.Enabled = true;


        }
        protected void Button4_Click(object sender, EventArgs e)
        {

            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            if (((TextBox1.Text != "") && (TextBox2.Text != "")))
            {
                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND      {tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Rec_Date}>=CDate('" + TextBox1.Text + "')" + "AND {tbl_srvmast1.Rec_Date}<=CDate('" + TextBox2.Text + "')" + "AND {tbl_srvmast1.Remarks}='" + DropDownList3.SelectedItem.Value + "'" + "AND {tbl_srvmast1.Action_By}='" + DropDownList4.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }
            else if ((((TextBox3.Text != "") && (TextBox4.Text != ""))))
            {
                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND {tbl_srvmast1.Com_Date}>=CDate('" + TextBox3.Text + "')" + "AND {tbl_srvmast1.Com_Date}<=CDate('" + TextBox4.Text + "')" + "AND {tbl_srvmast1.Remarks} = '" + DropDownList3.SelectedItem.Value + "'" + "AND {tbl_srvmast1.Req_Status} = '" + DropDownList2.SelectedItem.Value + "'" + "AND {tbl_srvmast1.Action_By}='" + DropDownList4.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }
            else
            {


                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND {tbl_srvmast1.Remarks} = '" + DropDownList3.SelectedItem.Value + "'" + "AND{tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'" + "AND {tbl_srvmast1.Action_By}='" + DropDownList4.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }


        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {



        }

        protected void Button6_Click(object sender, EventArgs e)
        {


        }

        protected void Button6_Click1(object sender, EventArgs e)
        {

        }

        protected void Button6_Click2(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            if (((TextBox1.Text != "") && (TextBox2.Text != "")))
            {
                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND      {tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Rec_Date}>=CDate('" + TextBox1.Text + "')" + "AND {tbl_srvmast1.Rec_Date}<=CDate('" + TextBox2.Text + "')";
                CrystalReportViewer1.RefreshReport();
            }
            else if ((((TextBox3.Text != "") && (TextBox4.Text != ""))))
            {
                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND {tbl_srvmast1.Com_Date}>=CDate('" + TextBox3.Text + "')" + "AND {tbl_srvmast1.Com_Date}<=CDate('" + TextBox4.Text + "')" + "AND {tbl_srvmast1.Req_Status} = '" + DropDownList2.SelectedItem.Value + "'";
                CrystalReportViewer1.RefreshReport();
            }
            else
            {


                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND {tbl_srvmast1.Remarks} = '" + DropDownList3.SelectedItem.Value + "'" + "AND{tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            if (((TextBox1.Text != "") && (TextBox2.Text != "")))
            {
                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Rec_Date}>=CDate('" + TextBox1.Text + "')" + "AND {tbl_srvmast1.Rec_Date}<=CDate('" + TextBox2.Text + "')" + "AND {tbl_srvmast1.Act_Email}='" + DropDownList5.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }
            else if ((((TextBox3.Text != "") && (TextBox4.Text != ""))))
            {
                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND {tbl_srvmast1.Com_Date}>=CDate('" + TextBox3.Text + "')" + "AND {tbl_srvmast1.Com_Date}<=CDate('" + TextBox4.Text + "')" + DropDownList3.SelectedItem.Value + "AND {tbl_srvmast1.Act_Email}='" + DropDownList5.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }
            else
            {


                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND {tbl_srvmast1.Remarks} = '" + DropDownList3.SelectedItem.Value + "'" + "AND {tbl_srvmast1.Act_Email}='" + DropDownList5.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            int num = retdata1();
            int num1 = retdata2();
            int num2 = nadiret();
            int num3 = aerotechret();
            int num4 = configret();


            double[] yValues = { num, num1, num2, num3, num4 };
            string[] xValues = { "AIROD", "AIROD AEROSPACE", "NADI", "TECHPOWER", "INAYAH" };
            Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
            Chart1.Series["Default"].Points[0].Color = Color.Blue;
            Chart1.Series["Default"].Points[1].Color = Color.Red;
            Chart1.Series["Default"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart1.Legends.Add("AIROD");
            Chart1.Legends.Add("AIROD AEROSPACE" + num1);
            Chart1.Series["Default"].IsVisibleInLegend = true;
            Chart1.Series["Default"].Points[0].Label = "#PERCENT" + "   AIROD";
            Chart1.Series["Default"].Points[1].Label = "#PERCENT" + "   AIROD AEROSPACE";
            Chart1.Series["Default"].Points[2].Label = "#PERCENT" + "   NADI";
            Chart1.Series["Default"].Points[3].Label = "#PERCENT" + "   TECHPOWER";
            Chart1.Series["Default"].Points[4].Label = "#PERCENT" + "   INAYAH";

            Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Visible = true;
            Chart1.Enabled = true;
            int meet = retmeet1();
            int meet1 = retmeet2();

            Chart3.Legends.Clear();
            Chart3.DataBind();

            double[] yyValues = { meet, meet1 };
            string[] xxValues = { "MEET HOURS", "NOT MEET HOURS" };
            Chart3.Series["Default1"].Points.DataBindXY(xxValues, yyValues);
            Chart3.Series["Default1"].Points[0].Color = Color.Green;
            Chart3.Series["Default1"].Points[1].Color = Color.Yellow;
            Chart3.Series["Default1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart3.Legends.Add("MEET HOURS" + meet);
            Chart3.Legends.Add("NOT MEET HOURS" + meet1);
            Chart3.Series["Default1"].Points[0].Label = "#PERCENT" + "   MEET HOURS";
            Chart3.Series["Default1"].Points[1].Label = "#PERCENT" + "   NOT MEET HOURS";
            Chart3.Series["Default1"]["PieLabelStyle"] = "Disabled";
            Chart3.Series["Default1"].IsVisibleInLegend = true;
            Chart3.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = true;
            Chart3.Visible = true;
            Chart3.Enabled = true;



            int Type1 = Typeret();
            int Type2 = Typeret1();
            int Type3 = Typeret2();

            Chart4.Legends.Clear();
            Chart4.Series["Default3"]["PieLabelStyle"] = "Disabled";
            double[] tValues = { Type1, Type2, Type3 };
            string[] pValues = { "Priority", "Normal", "Urgent" };
            Chart4.Series["Default3"].Points.DataBindXY(pValues, tValues);
            Chart4.Series["Default3"].Points[0].Color = Color.Green;
            Chart4.Series["Default3"].Points[1].Color = Color.Yellow;
            Chart4.Series["Default3"].Points[2].Color = Color.Black;
            Chart4.Series["Default3"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart4.Legends.Add("Priority");
            Chart4.Legends.Add("Normal");
            Chart4.Legends.Add("Urgent");
            Chart4.Series["Default3"].Points[0].Label = "#PERCENT" + " PRIORITY";
            Chart4.Series["Default3"].Points[1].Label = "#PERCENT" + " NORMAL";
            Chart4.Series["Default3"].Points[2].Label = "#PERCENT" + " URGENT";

            Chart4.Series["Default3"]["PieLabelStyle"] = "Disabled";
            Chart4.Series["Default3"].IsVisibleInLegend = true;
            Chart4.ChartAreas["ChartArea3"].Area3DStyle.Enable3D = true;
            Chart4.Visible = true;
            Chart4.Enabled = true;
            if (((TextBox1.Text != "") && (TextBox2.Text != "")))
            {
                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Rec_Date}>=CDate('" + TextBox1.Text + "')" + "AND {tbl_srvmast1.Rec_Date}<=CDate('" + TextBox2.Text + "')" + "AND {tbl_srvmast1.Act_Email}='" + DropDownList5.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }else
            if (((TextBox3.Text != "") && (TextBox4.Text != "")))
            {
                CrystalReportViewer1.SelectionFormula = "{tbl_srvmast1.Com_Type}='" + DropDownList1.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Rec_Date}>=CDate('" + TextBox3.Text + "')" + "AND {tbl_srvmast1.Rec_Date}<=CDate('" + TextBox4.Text + "')" + "AND {tbl_srvmast1.Act_Email}='" + DropDownList5.SelectedItem.Text + "'" + "AND{tbl_srvmast1.Req_Status}='" + DropDownList2.SelectedItem.Text + "'";
                CrystalReportViewer1.RefreshReport();
            }
        }
    }
}
