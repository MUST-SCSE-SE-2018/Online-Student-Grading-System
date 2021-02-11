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
    public partial class StuOverview : System.Web.UI.Page
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

            // show the teacher's name
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

            // transfer value by GET method
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
                
            }
            else if(RadioButtonList1.SelectedIndex == 1)
            {
                Response.Redirect("AssignmentManagement.aspx?tid=" + tid);
            }
            else
            {
                RegisterButton_Click();
            }
        }

    }
}