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
    public partial class RegisterNew : System.Web.UI.Page
    {
        string tid = "";
        string index = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButtonList1.AutoPostBack = true;
            tid = Request.QueryString["tid"];
            index = Request.QueryString["index"];
        }

        protected void Register_Button(object sender, EventArgs e)
        {
            // insert data into the database
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
            con.Open();

            if (RadioButtonList1.SelectedIndex == 0)
            {               
                string sql = "INSERT INTO Course(indexNumber, cid, cName, stuid, tid) VALUES(" + index + ", '" + cID.Text + "', '" + cName.Text + "', '" + stuID.Text + "', '" + tid + "')";
                SqlCommand cmd = new SqlCommand(sql, con);

                try
                {
                    cmd.ExecuteNonQuery();                    
                    Alert("Register Course Successfully!", "StuOverview.aspx?tid=" + tid);
                }
                catch
                {
                    Response.Write("<script type='text/javascript'>alert('Register Fail! Please retry it.');</script>");
                    stuID.Text = "";
                    cID.Text = "";
                    cName.Text = "";
                }
                
            }
            else
            {
                string sql = "INSERT INTO Student(stuid, sName, psw, emailAddress) VALUES('" + stuID.Text + "', '" + stuName.Text + "', '" + psw.Text + "', '" + email.Text + "');";
                sql += " INSERT INTO Course(indexNumber, cid, cName, stuid, tid) VALUES(" + index + ", '" + cID.Text + "', '" + cName.Text + "', '" + stuID.Text + "', '" + tid + "')";
                SqlCommand cmd = new SqlCommand(sql, con);

                try
                {
                    cmd.ExecuteNonQuery();
                    Alert("Register New Student Successfully!", "StuOverview.aspx?tid=" + tid);                  
                }
                catch
                {
                    Response.Write("<script type='text/javascript'>alert('Register Fail! Please retry it.');</script>");
                    stuID.Text = "";
                    stuName.Text = "";
                    psw.Text = "";
                    email.Text = "";
                    cID.Text = "";
                    cName.Text = "";
                }
            }

            con.Close();

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                option.Visible = false;
            }
            else
            {
                option.Visible = true;
            }
        }

        protected void Cancel_Button(object sender, EventArgs e)
        {
            Response.Redirect("StuOverview.aspx?tid=" + tid);
        }

        // print message and jump
        // reference: https://www.cnblogs.com/mic86/articles/1779921.html
        public void Alert(string str_Message, string redirect)
        {
            ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
            scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');self.location='" + redirect + "'", true);
        }
    }
}