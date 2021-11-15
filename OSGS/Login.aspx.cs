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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButtonList1.AutoPostBack = true;          
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                loginType.Text = "Teacher's ID :";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                loginType.Text = "Student's ID :";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");          
            con.Open();

            string sql = "";
            if (RadioButtonList1.SelectedIndex == 0) { sql = "SELECT COUNT(*) FROM Teacher WHERE tid = '" + TextBox1.Text + "' AND psw = '" + TextBox2.Text + "'"; } // teacher login
            else { sql = "SELECT COUNT(*) FROM Student WHERE stuid = '" + TextBox1.Text + "' AND psw = '" + TextBox2.Text + "'"; }  // student login

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                Int32 success = (Int32)cmd.ExecuteScalar();

                if (success > 0)
                {
                    if (RadioButtonList1.SelectedIndex == 0) { Response.Redirect("StuOverview.aspx?tid=" + TextBox1.Text); } // teacher login
                    else { Response.Redirect("AssignmentOverview.aspx?stuid=" + TextBox1.Text); } // student login              
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('Login Fail! Please check your ID and password.');</script>");
                }
            }
            catch
            {               
                Response.Write("<script type='text/javascript'>alert('Login Fail! Please check your ID and password.');</script>");          
            }

            con.Close();

            // reset
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

    }
}