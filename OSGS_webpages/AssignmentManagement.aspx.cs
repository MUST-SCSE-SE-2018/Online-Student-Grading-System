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
    public partial class AssignmentManagement : System.Web.UI.Page
    {
        // global variable
        string tid = "";
        string tname = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButtonList1.AutoPostBack = true;
            tid = Request.QueryString["tid"];

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
            string sql = "SELECT tName FROM Teacher WHERE tid = '" + tid + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                tname = cmd.ExecuteScalar().ToString();

                title.Text = "Welcome, " + tname + " !";

            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Sorry, we cannot find the teacher's name!');</script>");
                title.Text = "Welcome, teacher !";
            }

            con.Close();
        }

        protected void RegisterButton_Click()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
            string sql = "SELECT TOP 1 indexNumber FROM Course ORDER BY indexNumber DESC"; // get the last one
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                Int32 index = (Int32)cmd.ExecuteScalar() + 1;
                Response.Redirect("RegisterNew.aspx?tid=" + tid + "&index=" + index);
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }

            con.Close();

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                Response.Redirect("StuOverview.aspx?tid=" + tid);
            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {

            }
            else
            {
                RegisterButton_Click();
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Int32 aid_num = 0;
            Int32 qid_num = 0;

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
            string sql1 = "SELECT TOP 1 aid FROM Assignment ORDER BY aid DESC"; // get the last one
            string sql2 = "SELECT TOP 1 qid FROM Question ORDER BY qid DESC"; // get the last one
            con.Open();
            SqlCommand cmd1 = new SqlCommand(sql1, con);

            try
            {
                aid_num = (Int32)cmd1.ExecuteScalar() + 1;
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }

            SqlCommand cmd2 = new SqlCommand(sql2, con);

            try
            {
                qid_num = (Int32)cmd2.ExecuteScalar() + 1;               
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('Error!');</script>");
            }

            con.Close();

            Response.Redirect("AddNewAssignment.aspx?tid=" + tid + "&aid=" + aid_num.ToString() + "&qid=" + qid_num.ToString());
        }

        protected void Detail_Click(object sender, EventArgs e)
        {
            string aid = GridView1.SelectedDataKey.Values[0].ToString();
            string stuid = GridView1.SelectedDataKey.Values[1].ToString();
            Response.Redirect("AssignmentMarking.aspx?stuid=" + stuid + "&aid=" + aid + "&tid=" + tid);
        }
    }
}