using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

/* Designer: 1809853Z-I011-0045 Wang Yuyang, Kennard */

namespace OSGS
{
    public partial class StudentAnswer : System.Web.UI.Page
    {
        // global variable
        public static string stuid = "";
        public static string sname = "";
        public static string aid = "";
        public static string num = "";
        public static bool halt = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            stuid = Request.QueryString["stuid"];
            aid = Request.QueryString["aid"];
            string sql = "";
          
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");            
            con.Open();

            // lock when submit = 'Y'
            sql = "SELECT stat FROM Submit WHERE aid = " + aid + " AND stuid = '" + stuid + "'";
            string submit_stat = sql_command(sql, con);

            if (submit_stat.Equals("Y"))
            {
                ans.Enabled = false;
                ans_two.Enabled = false;
                ans_three.Enabled = false;
                ans_four.Enabled = false;
                ans_five.Enabled = false;
                ans_six.Enabled = false;
                submit.Enabled = false;
            }

            // complete basic info
            sql = "SELECT sName FROM Student WHERE stuid = '" + stuid + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                sname = cmd.ExecuteScalar().ToString();
                sid.Text = stuid;
                stuname.Text = sname;              
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }

            sql = "SELECT aname FROM Assignment WHERE aid = " + aid;
            SqlCommand cmd2 = new SqlCommand(sql, con);
            try
            {
                aname.Text = cmd2.ExecuteScalar().ToString();
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }


            // check question number
            sql = "SELECT q_number FROM Assignment WHERE aid = " + aid;
            SqlCommand cmd3 = new SqlCommand(sql, con);
            try
            {
                num = cmd3.ExecuteScalar().ToString();     
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }


            // display question, comment and answer (if submit = 'Y')
            switch (num)
            {
                case "1":

                    // question
                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                    q_cont.Text = sql_command(sql, con);
                    
                    // comment
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                    tcomment.Text = sql_command(sql, con);

                    // answer
                    if (submit_stat.Equals("Y"))
                    {
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ans.Text = sql_command(sql, con);
                    }

                    break;

                case "2":
                    q_two.Visible = true;

                    // question
                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                    q_cont.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 2";
                    q_cont_two.Text = sql_command(sql, con);

                    // comment
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                    tcomment.Text = sql_command(sql, con);

                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                    tcomment_two.Text = sql_command(sql, con);

                    // answer
                    if (submit_stat.Equals("Y"))
                    {
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_two.Text = sql_command(sql, con);
                    }

                    break;
                    
                case "3":
                    q_two.Visible = true;
                    q_three.Visible = true;

                    // question
                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                    q_cont.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 2";
                    q_cont_two.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 3";
                    q_cont_three.Text = sql_command(sql, con);

                    // comment
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                    tcomment.Text = sql_command(sql, con);
                  
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                    tcomment_two.Text = sql_command(sql, con);
                 
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 3 AND stuid = '" + stuid + "'";
                    tcomment_three.Text = sql_command(sql, con);

                    // answer
                    if (submit_stat.Equals("Y"))
                    {
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_two.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 3 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_three.Text = sql_command(sql, con);
                    }

                    break;

                case "4":
                    q_two.Visible = true;
                    q_three.Visible = true;
                    q_four.Visible = true;

                    // question
                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                    q_cont.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 2";
                    q_cont_two.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 3";
                    q_cont_three.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 4";
                    q_cont_four.Text = sql_command(sql, con);

                    // comment
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                    tcomment.Text = sql_command(sql, con);
                    
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                    tcomment_two.Text = sql_command(sql, con);
                   
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 3 AND stuid = '" + stuid + "'";
                    tcomment_three.Text = sql_command(sql, con);
                    
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 4 AND stuid = '" + stuid + "'";
                    tcomment_four.Text = sql_command(sql, con);

                    // answer
                    if (submit_stat.Equals("Y"))
                    {
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_two.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 3 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_three.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 4 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_four.Text = sql_command(sql, con);
                    }

                    break;

                case "5":
                    q_two.Visible = true;
                    q_three.Visible = true;
                    q_four.Visible = true;
                    q_five.Visible = true;

                    // question
                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                    q_cont.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 2";
                    q_cont_two.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 3";
                    q_cont_three.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 4";
                    q_cont_four.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 5";
                    q_cont_five.Text = sql_command(sql, con);

                    // comment
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                    tcomment.Text = sql_command(sql, con);
                   
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                    tcomment_two.Text = sql_command(sql, con);

                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 3 AND stuid = '" + stuid + "'";
                    tcomment_three.Text = sql_command(sql, con);
                    
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 4 AND stuid = '" + stuid + "'";
                    tcomment_four.Text = sql_command(sql, con);
                   
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 5 AND stuid = '" + stuid + "'";
                    tcomment_five.Text = sql_command(sql, con);

                    // answer
                    if (submit_stat.Equals("Y"))
                    {
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ans_two.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 3 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ans_three.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 4 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ans_four.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 5 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ans_five.Text = sql_command(sql, con);
                    }

                    break;

                case "6":
                    q_two.Visible = true;
                    q_three.Visible = true;
                    q_four.Visible = true;
                    q_five.Visible = true;
                    q_six.Visible = true;

                    // question
                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                    q_cont.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 2";
                    q_cont_two.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 3";
                    q_cont_three.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 4";
                    q_cont_four.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 5";
                    q_cont_five.Text = sql_command(sql, con);

                    sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 6";
                    q_cont_six.Text = sql_command(sql, con);

                    // comment
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                    tcomment.Text = sql_command(sql, con);
                   
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                    tcomment_two.Text = sql_command(sql, con);
                   
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 3 AND stuid = '" + stuid + "'";
                    tcomment_three.Text = sql_command(sql, con);
                    
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 4 AND stuid = '" + stuid + "'";
                    tcomment_four.Text = sql_command(sql, con);
                    
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 5 AND stuid = '" + stuid + "'";
                    tcomment_five.Text = sql_command(sql, con);
                   
                    sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 6 AND stuid = '" + stuid + "'";
                    tcomment_six.Text = sql_command(sql, con);

                    // answer
                    if (submit_stat.Equals("Y"))
                    {
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_two.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 3 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_three.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 4 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_four.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 5 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_five.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 6 AND stuid = '" + stuid + "' AND aid =" + aid;
                        ans_six.Text = sql_command(sql, con);
                    }

                    break;
            }

            con.Close();
        }

        protected void Submit_Button(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");          
            con.Open();

            string sql = "";
            string sql_qid= "";
            string qid_1 = "";
            string qid_2 = "";
            string qid_3 = "";
            string qid_4 = "";
            string qid_5 = "";
            string qid_6 = "";
            int ansid = 0;
            
            // get the largest ansid
            sql = "SELECT TOP 1 ansid FROM Answer ORDER BY ansid DESC";
            ansid = int.Parse(sql_command(sql, con));

            // get q_id
            if (!q_cont.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 1";
                qid_1 = sql_command(sql_qid, con);
            }
            if (!q_cont_two.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 2";
                qid_2 = sql_command(sql_qid, con);
            }
            if (!q_cont_three.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 3";
                qid_3 = sql_command(sql_qid, con);
            }
            if (!q_cont_four.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 4";
                qid_4 = sql_command(sql_qid, con);
            }
            if (!q_cont_five.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 5";
                qid_5 = sql_command(sql_qid, con);
            }
            if (!q_cont_six.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 6";
                qid_6 = sql_command(sql_qid, con);
            }

            // insert data
            if (!ans.Text.Equals("")) {
                ansid++;
                sql = "INSERT INTO Answer(ansid, qid, stuid, content, tcomment) VALUES(" + ansid.ToString() + ", " + qid_1 + ", '" + stuid +"', '" + ans.Text + "', '')";
                sql_insert(sql, con);
            }
            if (!ans_two.Text.Equals(""))
            {
                ansid++;
                sql = "INSERT INTO Answer(ansid, qid, stuid, content, tcomment) VALUES(" + ansid.ToString() + ", " + qid_2 + ", '" + stuid + "', '" + ans_two.Text + "', '')";
                sql_insert(sql, con);
            }
            if (!ans_three.Text.Equals(""))
            {
                ansid++;
                sql = "INSERT INTO Answer(ansid, qid, stuid, content, tcomment) VALUES(" + ansid.ToString() + ", " + qid_3 + ", '" + stuid + "', '" + ans_three.Text + "', '')";
                sql_insert(sql, con);
            }
            if (!ans_four.Text.Equals(""))
            {
                ansid++;
                sql = "INSERT INTO Answer(ansid, qid, stuid, content, tcomment) VALUES(" + ansid.ToString() + ", " + qid_4 + ", '" + stuid + "', '" + ans_four.Text + "', '')";
                sql_insert(sql, con);
            }
            if (!ans_five.Text.Equals(""))
            {
                ansid++;
                sql = "INSERT INTO Answer(ansid, qid, stuid, content, tcomment) VALUES(" + ansid.ToString() + ", " + qid_5 + ", '" + stuid + "', '" + ans_five.Text + "', '')";
                sql_insert(sql, con);
            }
            if (!ans_six.Text.Equals(""))
            {
                ansid++;
                sql = "INSERT INTO Answer(ansid, qid, stuid, content, tcomment) VALUES(" + ansid.ToString() + ", " + qid_6 + ", '" + stuid + "', '" + ans_six.Text + "', '')";
                sql_insert(sql, con);
            }

            if (!halt) {

                sql = "UPDATE Submit SET stat = 'Y' WHERE aid = " + aid + " AND stuid = '" + stuid + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    cmd.ExecuteNonQuery();
                    Alert("Submit Answer Successfully!", "AssignmentOverview.aspx?stuid=" + stuid);              
                }
                catch
                {
                    Response.Write("<script type='text/javascript'>alert('Submit Fail!');</script>");
                }
                
            }

            con.Close();
        }

        protected void Back_Button(object sender, EventArgs e)
        {
            Response.Redirect("AssignmentOverview.aspx?stuid=" + stuid);
        }

        // select data, return a string
        public string sql_command(string sql, SqlConnection con)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                if (cmd.ExecuteScalar() != null) { result = cmd.ExecuteScalar().ToString(); }
                else { result = ""; }                
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }

            return result;
        }

        // insert, update and delete
        public void sql_insert(string sql, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();               
            }
            catch
            {
                halt = true;
                Response.Write("<script type='text/javascript'>alert('Insert Fail!');</script>");
            }
           
        }

        // print message and jump
        public void Alert(string str_Message, string redirect)
        {
            ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
            scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');self.location='" + redirect + "'", true);
        }
    }
}