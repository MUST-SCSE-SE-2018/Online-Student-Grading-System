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
    public partial class AssignmentMarking : System.Web.UI.Page
    {
        // global variable
        public static string tid = "";
        public static string stuid = "";
        public static string sname = "";
        public static string aid = "";
        public static string num = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                tid = Request.QueryString["tid"];
                stuid = Request.QueryString["stuid"];
                aid = Request.QueryString["aid"];

                string sql = "";

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
                con.Open();

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

                // display grade and comment
                sql = "SELECT grade FROM Submit WHERE stuid = '" + stuid + "' AND aid = " + aid;
                SqlCommand cmm = new SqlCommand(sql, con);
                try
                {
                    grade.Text = cmm.ExecuteScalar().ToString();
                }
                catch
                {
                    Response.Write("<script type='text/javascript'>alert('Error!');</script>");
                }

                sql = "SELECT comment FROM Submit WHERE stuid = '" + stuid + "' AND aid = " + aid;
                SqlCommand cmm2 = new SqlCommand(sql, con);
                try
                {
                    acomment.Text = cmm2.ExecuteScalar().ToString();
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
                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid WHERE Q.aid = " + aid + " AND Q.q_index = 1 AND A.stuid = '" + stuid + "'";
                        tcomment.Text = sql_command(sql, con);

                        // answer                 
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ans.Text = sql_command(sql, con);

                        break;

                    case "2":
                        q_two.Visible = true;

                        // question
                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                        q_cont.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 2";
                        q_contTwo.Text = sql_command(sql, con);

                        // comment
                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                        tcomment.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                        tcommentTwo.Text = sql_command(sql, con);

                        // answer                   
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansTwo.Text = sql_command(sql, con);

                        break;

                    case "3":
                        q_two.Visible = true;
                        q_three.Visible = true;

                        // question
                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                        q_cont.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 2";
                        q_contTwo.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 3";
                        q_contThree.Text = sql_command(sql, con);

                        // comment
                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                        tcomment.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                        tcommentTwo.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 3 AND stuid = '" + stuid + "'";
                        tcommentThree.Text = sql_command(sql, con);

                        // answer                   
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansTwo.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 3 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansThree.Text = sql_command(sql, con);

                        break;

                    case "4":
                        q_two.Visible = true;
                        q_three.Visible = true;
                        q_four.Visible = true;

                        // question
                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 1";
                        q_cont.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 2";
                        q_contTwo.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 3";
                        q_contThree.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 4";
                        q_contFour.Text = sql_command(sql, con);

                        // comment
                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                        tcomment.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                        tcommentTwo.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 3 AND stuid = '" + stuid + "'";
                        tcommentThree.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 4 AND stuid = '" + stuid + "'";
                        tcommentFour.Text = sql_command(sql, con);

                        // answer                  
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansTwo.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 3 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansThree.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 4 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansFour.Text = sql_command(sql, con);

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
                        q_contTwo.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 3";
                        q_contThree.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 4";
                        q_contFour.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 5";
                        q_contFive.Text = sql_command(sql, con);

                        // comment
                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid WHERE Q.aid = " + aid + " AND Q.q_index = 1 AND A.stuid = '" + stuid + "'";
                        tcomment.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid WHERE Q.aid = " + aid + " AND Q.q_index = 2 AND A.stuid = '" + stuid + "'";
                        tcommentTwo.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid WHERE Q.aid = " + aid + " AND Q.q_index = 3 AND A.stuid = '" + stuid + "'";
                        tcommentThree.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid WHERE Q.aid = " + aid + " AND Q.q_index = 4 AND A.stuid = '" + stuid + "'";
                        tcommentFour.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid WHERE Q.aid = " + aid + " AND Q.q_index = 5 AND A.stuid = '" + stuid + "'";
                        tcommentFive.Text = sql_command(sql, con);

                        // answer                   
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid WHERE Q.q_index = 1 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid WHERE Q.q_index = 2 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ansTwo.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid WHERE Q.q_index = 3 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ansThree.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid WHERE Q.q_index = 4 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ansFour.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid WHERE Q.q_index = 5 AND A.stuid = '" + stuid + "' AND Q.aid = " + aid;
                        ansFive.Text = sql_command(sql, con);

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
                        q_contTwo.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 3";
                        q_contThree.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 4";
                        q_contFour.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 5";
                        q_contFive.Text = sql_command(sql, con);

                        sql = "SELECT Q.content FROM Question AS Q WHERE Q.aid = " + aid + " AND Q.q_index = 6";
                        q_contSix.Text = sql_command(sql, con);

                        // comment
                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 1 AND stuid = '" + stuid + "'";
                        tcomment.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 2 AND stuid = '" + stuid + "'";
                        tcommentTwo.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 3 AND stuid = '" + stuid + "'";
                        tcommentThree.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 4 AND stuid = '" + stuid + "'";
                        tcommentFour.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 5 AND stuid = '" + stuid + "'";
                        tcommentFive.Text = sql_command(sql, con);

                        sql = "SELECT A.tcomment FROM Question AS Q JOIN Answer AS A ON A.qid = Q.qid AND Q.aid = " + aid + " AND Q.q_index = 6 AND stuid = '" + stuid + "'";
                        tcommentSix.Text = sql_command(sql, con);

                        // answer                   
                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 1 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ans.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 2 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansTwo.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 3 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansThree.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 4 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansFour.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 5 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansFive.Text = sql_command(sql, con);

                        sql = "SELECT A.content FROM Answer AS A JOIN Question AS Q ON A.qid = Q.qid AND Q.q_index = 6 AND stuid = '" + stuid + "' AND aid = " + aid;
                        ansSix.Text = sql_command(sql, con);

                        break;
                }

                con.Close();
            }

        }

        protected void Submit_Button(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
            con.Open();

            string sql = "";
            string sql_qid = "";
            string qid_1 = "";
            string qid_2 = "";
            string qid_3 = "";
            string qid_4 = "";
            string qid_5 = "";
            string qid_6 = "";
                     
            // get q_id
            if (!q_cont.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 1";
                qid_1 = sql_command(sql_qid, con);
            }
            if (!q_contTwo.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 2";
                qid_2 = sql_command(sql_qid, con);
            }
            if (!q_contThree.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 3";
                qid_3 = sql_command(sql_qid, con);
            }
            if (!q_contFour.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 4";
                qid_4 = sql_command(sql_qid, con);
            }
            if (!q_contFive.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 5";
                qid_5 = sql_command(sql_qid, con);
            }
            if (!q_contSix.Text.Equals(""))
            {
                sql_qid = "SELECT qid FROM Question WHERE aid = " + aid + " AND q_index = 6";
                qid_6 = sql_command(sql_qid, con);
            }

            // update comment
            if (!tcomment.Text.Equals(""))
            {
                sql = "UPDATE Answer SET tcomment = '" + tcomment.Text + "' WHERE qid = " + qid_1 + " AND stuid = '" + stuid + "'";
                sql_insert(sql, con);
            }
            if (!tcommentTwo.Text.Equals(""))
            {
                sql = "UPDATE Answer SET tcomment = '" + tcommentTwo.Text + "' WHERE qid = " + qid_2 + " AND stuid = '" + stuid + "'";
                sql_insert(sql, con);
            }
            if (!tcommentThree.Text.Equals(""))
            {
                sql = "UPDATE Answer SET tcomment = '" + tcommentThree.Text + "' WHERE qid = " + qid_3 + " AND stuid = '" + stuid + "'";
                sql_insert(sql, con);
            }
            if (!tcommentFour.Text.Equals(""))
            {
                sql = "UPDATE Answer SET tcomment = '" + tcommentFour.Text + "' WHERE qid = " + qid_4 + " AND stuid = '" + stuid + "'";
                sql_insert(sql, con);
            }
            if (!tcommentFive.Text.Equals(""))
            {
                sql = "UPDATE Answer SET tcomment = '" + tcommentFive.Text + "' WHERE qid = " + qid_5 + " AND stuid = '" + stuid + "'";
                sql_insert(sql, con);
            }
            if (!tcommentSix.Text.Equals(""))
            {
                sql = "UPDATE Answer SET tcomment = '" + tcommentSix.Text + "' WHERE qid = " + qid_6 + " AND stuid = '" + stuid + "'";
                sql_insert(sql, con);
            }

            // update grade and Assignment comment
            sql = "UPDATE Submit SET grade = " + grade.Text + ", comment = '" + acomment.Text + "' WHERE ( aid = " + aid + " AND stuid = '" + stuid + "' )";
            sql_insert(sql, con);

            con.Close();

            Alert("Marking Successfully!", "AssignmentManagement.aspx?tid=" + tid);
        }

        protected void Back_Button(object sender, EventArgs e)
        {
            Response.Redirect("AssignmentManagement.aspx?tid=" + tid);
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

        // insert, update, delete
        public void sql_insert(string sql, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {                
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