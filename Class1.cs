using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Transactions;

public class bl
{

    MySqlConnection con = new MySqlConnection();
    MySqlCommand cmd = new MySqlCommand();



    String str = "server=localhost;database=airod;userid=root;password=;";
    public bl()
    {
        //con = new MySql.Data.MySqlClient.MySqlConnection("LocalMySqlServer");

        //string connStr = ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;
        con = new MySqlConnection(str);
        cmd = new MySqlCommand();
        cmd.CommandTimeout = 900000;
        HttpContext.Current.Server.ScriptTimeout = 900000;

        if (con.State == ConnectionState.Closed)
        {

            con.Open();

        }

        cmd.Connection = con;



        //con = new SqlConnection(connStr);
        //cmd = new SqlCommand();
        //con.Open();
        //cmd.Connection = con;

    }


    //public DataTable showgrid(string ordno)
    //{

    //    string sql = string.Format("select * from tbl_salesdetail where order_no='{0}'", ordno);
    //    SqlDataAdapter adap = new SqlDataAdapter(sql, con);
    //    DataTable tab = new DataTable();
    //    adap.Fill(tab);
    //    return tab;
    //}


    public string verpwd(string un, string pwd)
    {
        HttpContext.Current.Server.ScriptTimeout = 900000;
        using (con = new MySqlConnection(str))
        {
            if (con.State == ConnectionState.Closed)
            {

                con.Open();

            }
            string u = string.Empty;
            string sql = string.Format("select * from tbl_userdata where User_Name='{0}' and Pass_Word='{1}'", un, pwd);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            //SqlDataReader dr = cmd.ExecuteReader();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                u = dr["User_Name"].ToString();
                dr.Close();
            }
            cmd.CommandTimeout = 50000;
            return u; 

        }
    }


    public int refret()
    {
        HttpContext.Current.Server.ScriptTimeout = 900000;
        using (con = new MySqlConnection(str))
        {
            if (con.State == ConnectionState.Closed)
            {

                con.Open();

            }

            int refno = 0;


            string sql = string.Format("select * from tbl_srvmast order by Ref_No DESC");
            cmd.CommandText = sql;
            cmd.CommandTimeout = 50000;
            cmd.ExecuteNonQuery();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                refno = dr.GetInt32("Ref_No");
                refno = refno + 1;


            }
            con.Close();
            
            return refno;



        }
    }

    public MySqlDataReader modreq(int refno)
    {
        HttpContext.Current.Server.ScriptTimeout = 900000;
        using (con = new MySqlConnection(str))
        {
            if (con.State == ConnectionState.Closed)
            {

                con.Open();

            }
            bl modreq = new bl();
            string sql = string.Format("select * from tbl_srvmast where Ref_No='{0}'", refno);
            cmd.CommandText = sql;
            cmd.CommandTimeout = 50000;
            cmd.ExecuteNonQuery();

            MySqlDataReader dr = (cmd.ExecuteReader());

            if (dr.Read())
            {
                con.Close();
                return dr;

            }
            else
            {
                return null;

            }


        }
    }
    public bool updreq(int Ref_No, string Req_Name, String Com_Type, String Prob_Desc, string Rec_Date, String Req_Email, String Req_Status, String Action, string Action_By, string Com_Date, String Remarks, float Req_Time,string servType)
    {
        HttpContext.Current.Server.ScriptTimeout = 900000;
      

            using (con = new MySqlConnection(str))
            {
               

                    MySqlCommand command = con.CreateCommand();
                    command.CommandTimeout = 50000;

                    if (con.State == ConnectionState.Closed)
                    {

                        con.Open();
                    }
                    command.CommandText = "UPDATE airod.tbl_srvmast SET Req_Name = @Req_Name, Com_Type = @Com_Type, Prob_Desc = @Prob_Desc,Rec_Date = STR_TO_DATE(@Rec_Date,'%Y/%m/%d %H:%i:%s'),Req_Email = @Req_Email, Req_Status=@Req_Status, Action = @Action, Action_By = @Action_By, Com_Date = STR_TO_DATE(@Com_Date,'%Y/%m/%d %H:%i:%s'), Remarks = @Remarks, Req_Time=@Req_Time, ServiceType=@ServiceType WHERE Ref_No = @Ref_No";

                    command.Parameters.AddWithValue("@Ref_No", Ref_No);
                    command.Parameters.AddWithValue("@Req_Name", Req_Name);
                    command.Parameters.AddWithValue("@Com_Type", Com_Type);
                    command.Parameters.AddWithValue("@Prob_Desc", Prob_Desc);
                    command.Parameters.AddWithValue("@Rec_Date", Rec_Date);
                    command.Parameters.AddWithValue("@Req_Email", Req_Email);
                    command.Parameters.AddWithValue("@Req_Status", Req_Status);
                    command.Parameters.AddWithValue("@Action", Action);
                    command.Parameters.AddWithValue("@Action_By", Action_By);
                    command.Parameters.AddWithValue("@Com_Date", Com_Date);
                    command.Parameters.AddWithValue("@Remarks", Remarks);
                    command.Parameters.AddWithValue("@Req_Time", Req_Time);
                    command.Parameters.AddWithValue("@ServiceType", servType);
                    command.CommandTimeout = 500000;
                    command.ExecuteNonQuery();
                    
                    con.Close();
                    return true;

                }
            }

    public bool updreq1(int Ref_No, string Req_Name, String Com_Type, String Prob_Desc, string Rec_Date, String Req_Email, String Req_Status, String Action, string Action_By, DateTime Com_Date, String Remarks, float Req_Time, string servType)
    {
        HttpContext.Current.Server.ScriptTimeout = 900000;


        using (con = new MySqlConnection(str))
        {


            MySqlCommand command = con.CreateCommand();
            command.CommandTimeout = 50000;

            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }
            command.CommandText = "UPDATE airod.tbl_srvmast1 SET Req_Name = @Req_Name, Com_Type = @Com_Type, Prob_Desc = @Prob_Desc,Rec_Date = STR_TO_DATE(@Rec_Date,'%Y/%m/%d %H:%i:%s'),Req_Email = @Req_Email, Req_Status=@Req_Status, Action = @Action, Action_By = @Action_By, Com_Date = @Com_Date, Remarks = @Remarks, Req_Time=@Req_Time, ServiceType=@ServiceType WHERE Ref_No = @Ref_No";

            command.Parameters.AddWithValue("@Ref_No", Ref_No);
            command.Parameters.AddWithValue("@Req_Name", Req_Name);
            command.Parameters.AddWithValue("@Com_Type", Com_Type);
            command.Parameters.AddWithValue("@Prob_Desc", Prob_Desc);
            command.Parameters.AddWithValue("@Rec_Date", Rec_Date);
            command.Parameters.AddWithValue("@Req_Email", Req_Email);
            command.Parameters.AddWithValue("@Req_Status", Req_Status);
            command.Parameters.AddWithValue("@Action", Action);
            command.Parameters.AddWithValue("@Action_By", Action_By);
            command.Parameters.AddWithValue("@Com_Date", Com_Date);
            command.Parameters.AddWithValue("@Remarks", Remarks);
            command.Parameters.AddWithValue("@Req_Time", Req_Time);
            command.Parameters.AddWithValue("@ServiceType", servType);
            command.CommandTimeout = 500000;
            command.ExecuteNonQuery();

            con.Close();
            return true;

        }
    }

      
    
    
    public bool delre(int Ref_No)
    {
        HttpContext.Current.Server.ScriptTimeout = 900000;
        using (TransactionScope transactionscope = new TransactionScope())
        {

            using (con = new MySqlConnection(str))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();


                }


                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM tbl_srvmast where Ref_No=@Ref_No";
                cmd.Parameters.AddWithValue("@Ref_No", Ref_No);
                cmd.CommandTimeout = 50000;
                cmd.ExecuteNonQuery();
                transactionscope.Complete();
                con.Close();
                return true;


            }
        }


    }


    public bool addsrvreq(int Ref_No, string Rec_Date, string Req_Name, string Prob_Desc, string Type, string Com_Type, string Req_Email, string Req_Status, string Remarks, string Act_Email, string khidmat, DateTime Escalate_Date)
    {
        



            using (con = new MySqlConnection(str))
            {
                
                

                    HttpContext.Current.Server.ScriptTimeout = 900000;

                    if (con.State == ConnectionState.Closed)
                    {

                        con.Open();

                    }
                    MySqlCommand command = con.CreateCommand();
                    command.CommandText = @"INSERT INTO airod.tbl_srvmast(Ref_No,Rec_Date,Req_Name,Prob_Desc,Type,Com_Type,Req_Email,Req_Status,Remarks,Act_Email,ServiceType, Escalate_Date) VALUES (@Ref_No,STR_TO_DATE(@Rec_Date,'%Y/%m/%d %H:%i:%s'),@Req_Name,@Prob_Desc,@Type,@Com_Type,@Req_Email,@Req_Status,@Remarks,@Act_Email,@ServiceType,@Escalate_Date)";

                    //command.CommandText = "INSERT INTO airod.tbl_srvmast(Ref_No,Req_Name,Prob_Desc,Type,Com_Type,Req_Email,Req_Status,Remarks) VALUES (@Ref_No,@Req_Name,@Prob_Desc,@Type,@Com_Type,@Req_Email,@Req_Status,@Remarks)";
                    // command.CommandText = "INSERT INTO airod.tbl_srvmast(Ref_No)VALUES(@Ref_No)";
                    command.Parameters.AddWithValue("@Ref_No", Ref_No);
                    command.Parameters.AddWithValue("@Rec_Date", Rec_Date);
                    command.Parameters.AddWithValue("@Req_Name", Req_Name);
                    command.Parameters.AddWithValue("@Prob_Desc", Prob_Desc);
                    command.Parameters.AddWithValue("@Type", Type);
                    command.Parameters.AddWithValue("@Com_Type", Com_Type);
                    command.Parameters.AddWithValue("@Req_Email", Req_Email);
                    command.Parameters.AddWithValue("@Req_Status", Req_Status);
                    command.Parameters.AddWithValue("@Remarks", Remarks);
                    command.Parameters.AddWithValue("@Act_Email", Act_Email);
                    command.Parameters.AddWithValue("@ServiceType", khidmat);
                    command.Parameters.AddWithValue("@Escalate_Date", @Escalate_Date);
                    command.CommandTimeout = 50000;
                    command.ExecuteNonQuery();
               
                    con.Close();
                    return true;





                    //public bool prodemp(string val1, string val2, string val3, string val4, string un)
                    //{

                    //    try
                    //    {
                    //        string sql = string.Format("update userdata set role1='{0}', role2='{1}', role3='{2}', role4='{3}' where User_Name='{4}'", val1, val2, val3, val4, un);
                    //        cmd.CommandText = sql;
                    //        cmd.ExecuteNonQuery();
                    //        return true;
                    //    }

                    //    catch(SqlException e)
                    //    {
                    //        return false;
                    //    }
                    //}

                }

            }
    public bool addsrvreq1(int Ref_No, string Rec_Date, string Req_Name, string Prob_Desc, string Type, string Com_Type, string Req_Email, string Req_Status, string Remarks, string Act_Email, string khidmat, DateTime Escalate_Date)
    {

        using (con = new MySqlConnection(str))
        {

            HttpContext.Current.Server.ScriptTimeout = 900000;

            if (con.State == ConnectionState.Closed)
            {

                con.Open();

            }
            MySqlCommand command = con.CreateCommand();
            command.CommandText = @"INSERT INTO airod.tbl_srvmast1(Ref_No,Rec_Date,Req_Name,Prob_Desc,Type,Com_Type,Req_Email,Req_Status,Remarks,Act_Email,ServiceType,Escalate_Date) VALUES (@Ref_No,STR_TO_DATE(@Rec_Date,'%Y/%m/%d %H:%i:%s'),@Req_Name,@Prob_Desc,@Type,@Com_Type,@Req_Email,@Req_Status,@Remarks,@Act_Email,@ServiceType,@Escalate_Date)";

            //command.CommandText = "INSERT INTO airod.tbl_srvmast(Ref_No,Req_Name,Prob_Desc,Type,Com_Type,Req_Email,Req_Status,Remarks) VALUES (@Ref_No,@Req_Name,@Prob_Desc,@Type,@Com_Type,@Req_Email,@Req_Status,@Remarks)";
            // command.CommandText = "INSERT INTO airod.tbl_srvmast(Ref_No)VALUES(@Ref_No)";
            command.Parameters.AddWithValue("@Ref_No", Ref_No);
            command.Parameters.AddWithValue("@Rec_Date", Rec_Date);
            command.Parameters.AddWithValue("@Req_Name", Req_Name);
            command.Parameters.AddWithValue("@Prob_Desc", Prob_Desc);
            command.Parameters.AddWithValue("@Type", Type);
            command.Parameters.AddWithValue("@Com_Type", Com_Type);
            command.Parameters.AddWithValue("@Req_Email", Req_Email);
            command.Parameters.AddWithValue("@Req_Status", Req_Status);
            command.Parameters.AddWithValue("@Remarks", Remarks);
            command.Parameters.AddWithValue("@Act_Email", Act_Email);
            command.Parameters.AddWithValue("@ServiceType", khidmat);
            command.Parameters.AddWithValue("@Escalate_Date", @Escalate_Date);
            command.CommandTimeout = 50000;
            command.ExecuteNonQuery();

            con.Close();
            return true;

        }

    }
}
    



