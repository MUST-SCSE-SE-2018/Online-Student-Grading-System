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
    public partial class AssignmentOverview : System.Web.UI.Page
    {
        // global variable
        string stuid = "";
        string sname = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {         
            stuid = Request.QueryString["stuid"];
           
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");           
            con.Open();

            // show student's name
            string sql = "SELECT sName FROM Student WHERE stuid = '" + stuid + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                sname = cmd.ExecuteScalar().ToString();

                title.Text = "Welcome, " + sname + " !";

            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Sorry, we cannot find the teacher's name!');</script>");
                title.Text = "Welcome, teacher !";
            }

            // get the initial course id
            string cid = "";
            sql = "SELECT TOP 1 cid FROM Course WHERE stuid = '" + stuid + "'";
            SqlCommand cmd2 = new SqlCommand(sql, con);
            try
            {
                cid = cmd2.ExecuteScalar().ToString();
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }

            // initial the gpa (remain 2 bits)
            sql = "SELECT ROUND(SUM(S.grade * A.weight/100),2) FROM Submit AS S JOIN Assignment AS A ON S.stuid = '" + stuid + "' AND S.aid = A.aid AND A.cid = '" + cid + "' GROUP BY S.stuid";
            SqlCommand cmd3 = new SqlCommand(sql, con);
            try
            {
                if (cmd3.ExecuteScalar() != null) { gpa.Text = "GPA : " + cmd3.ExecuteScalar().ToString(); }          
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }

            con.Close();
        }

        protected void Detail_Click(object sender, EventArgs e)
        {
            string aid = GridView1.SelectedDataKey.Value.ToString();           
            Response.Redirect("StudentAnswer.aspx?stuid=" + stuid + "&aid=" + aid);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cid = DropDownList1.SelectedValue;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
            con.Open();

            // show the gpa (remain 2 bits)
            string sql = "SELECT ROUND(SUM(S.grade * A.weight/100),2) FROM Submit AS S JOIN Assignment AS A ON S.stuid = '" + stuid + "' AND S.aid = A.aid AND A.cid = '" + cid + "' GROUP BY S.stuid";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                if (cmd.ExecuteScalar() != null) { gpa.Text = "GPA : " + cmd.ExecuteScalar().ToString(); }
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }

            con.Close();
            
        }
    }
}