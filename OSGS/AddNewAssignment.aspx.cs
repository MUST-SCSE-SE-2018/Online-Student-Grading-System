using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

/* Designer: 1809853Z-I011-0045 Wang Yuyang, Kennard */

namespace OSGS
{ 
    public partial class AddNewAssignment : System.Web.UI.Page
    {
        // global variable     
        int max_q_number = 6;
        public static int q_number = 1; // do not allow initialization      
        public static int num = 1; // final question number 
        public static string tid = "";
        public static string aid = "";
        public static string qid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            tid = Request.QueryString["tid"];
            aid = Request.QueryString["aid"];
            qid = Request.QueryString["qid"];
        }

        protected void Add_Button(object sender, EventArgs e)
        {
            if (q_number < max_q_number)
            {
                q_number++;

                switch (q_number)
                {
                    case 2:
                        Que2.Visible = true;
                        break;
                    case 3:
                        Que3.Visible = true;
                        break;
                    case 4:
                        Que4.Visible = true;
                        break;
                    case 5:
                        Que5.Visible = true;
                        break;
                    case 6:
                        Que6.Visible = true;
                        break;
                }
            }
            
        }

        protected void Delete_Button(object sender, EventArgs e)
        {
            if (q_number > 1)
            {
                switch (q_number)
                {
                    case 2:
                        Que2.Visible = false;
                        break;
                    case 3:
                        Que3.Visible = false;
                        break;
                    case 4:
                        Que4.Visible = false;
                        break;
                    case 5:
                        Que5.Visible = false;
                        break;
                    case 6:
                        Que6.Visible = false;
                        break;
                }

                q_number--;
            }
        }

        protected void Create_Button(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
            con.Open();

            string sql_que = "INSERT INTO Question(qid, q_index, aid, content) VALUES (" + qid + ", 1, " + aid + ", '" + Q_one.Text + "')";
           
            if (Q_two.Text != "") {
                int tmp = int.Parse(qid) + 1;
                qid = tmp.ToString(); 
                sql_que += ", (" + qid + ", 2, " + aid + ", '" + Q_two.Text + "')"; 
                num++; 
            }

            if (Q_three.Text != "") {
                int tmp = int.Parse(qid) + 1;
                qid = tmp.ToString();
                sql_que += ", (" + qid + ", 3, " + aid + ", '" + Q_three.Text + "')";
                num++; 
            }

            if (Q_four.Text != "") {
                int tmp = int.Parse(qid) + 1;
                qid = tmp.ToString();
                sql_que += ", (" + qid + ", 4, " + aid + ", '" + Q_four.Text + "')";
                num++; 
            }

            if (Q_five.Text != "") {
                int tmp = int.Parse(qid) + 1;
                qid = tmp.ToString();
                sql_que += ", (" + qid + ", 5, " + aid + ", '" + Q_five.Text + "')";
                num++; 
            }

            if (Q_six.Text != "") {
                int tmp = int.Parse(qid) + 1;
                qid = tmp.ToString();
                sql_que += ", (" + qid + ", 6, " + aid + ", '" + Q_six.Text + "')";
                num++; 
            }

            string sql_assign = "INSERT INTO Assignment(aid, aname, cid, q_number, [weight], tid, deadline) VALUES(" + aid + ", '" +
                aname.Text + "', '" + cid.Text + "', " + num.ToString() +", " + weight.Text +", '" + tid + "', '" + ddl.Text +"')";

            string sql = sql_assign + ";" + sql_que;
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
                Alert("Create Assignment Successfully!", "AssignmentManagement.aspx?tid=" + tid);
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Create Assignment Fail! Please retry it.');</script>");
            }

            // create submit
            // get subid
            sql = "SELECT TOP 1 subid FROM Submit ORDER BY subid DESC";
            int subid = 0;
            SqlCommand cmd2 = new SqlCommand(sql, con);
            try
            {
                subid = (int)cmd2.ExecuteScalar();             
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error! Please retry it.');</script>");
            }

            // get stuid set
            sql = "SELECT stuid FROM Course WHERE cid = '" + cid.Text + "'";
            SqlCommand cmd3 = new SqlCommand(sql, con);

            // insert into Table Submit
            using (SqlDataReader reader = cmd3.ExecuteReader())
            {
                // reference: https://docs.microsoft.com/zh-tw/dotnet/api/system.data.sqlclient.sqldatareader?view=dotnet-plat-ext-5.0
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
                conn.Open();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    IDataRecord tmp = (IDataRecord)reader;
                    subid++;
                    string sql1 = "INSERT INTO Submit(subid, aid, stuid, grade, comment, stat) VALUES(" + subid.ToString() + ", " + aid + ", '" + tmp[0].ToString() + "', 0.0, ' ', 'N')";
                    SqlCommand cmd4 = new SqlCommand(sql1, conn);
                    try
                    {
                        cmd4.ExecuteNonQuery();
                    }
                    catch
                    {
                        Response.Write("<script type='text/javascript'>alert('Fail Insert! Please retry it.');</script>");
                    }
                }

                reader.Close();
                conn.Close();
            }
       
            con.Close();
        }

        protected void Back_Button(object sender, EventArgs e)
        {
            Response.Redirect("AssignmentManagement.aspx?tid=" + tid);
        }

        // print message and jump
        public void Alert(string str_Message, string redirect)
        {
            ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
            scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');self.location='" + redirect + "'", true);
        }
    }
}