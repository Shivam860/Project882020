using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project882020
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
       

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (ddlselect.SelectedValue=="1") {
                con.Open();
                SqlCommand com = new SqlCommand("commonprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                com.Parameters.AddWithValue("@action", "login");
                com.Parameters.AddWithValue("@email", textEmail.Text);
                com.Parameters.AddWithValue("@password", textpass.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                com.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["id"] = dt.Rows[0]["id"].ToString();
                    Response.Redirect("HomePage.aspx");
                    labmsg.Text = "Login Successful";
                }
                else
                {
                    labmsg.Text = "You have enter Incorrect Email or Password";
                }
            }
            else if (ddlselect.SelectedValue == "2")
            {
                con.Open();
                SqlCommand com = new SqlCommand("recprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                com.Parameters.AddWithValue("@action", "login");
                com.Parameters.AddWithValue("@r_email", textEmail.Text);
                com.Parameters.AddWithValue("@r_password", textpass.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                com.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    
                    Session["r_id"] = dt.Rows[0]["r_id"].ToString();
                    Response.Redirect("rec_HomePage.aspx");
                    labmsg.Text = "Login Successful";
                }
                else
                {
                    labmsg.Text = "You have enter Incoorrect Email or Password";
                }
            }
            else if (ddlselect.SelectedValue == "3")
            {
                con.Open();
                SqlCommand com = new SqlCommand("adminproc", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                com.Parameters.AddWithValue("@action", "login");
                com.Parameters.AddWithValue("@a_email", textEmail.Text);
                com.Parameters.AddWithValue("@a_password", textpass.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                com.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["a_id"] = dt.Rows[0]["a_id"].ToString();
                    Response.Redirect("Home_admin.aspx");
                    labmsg.Text = "Login Successful";
                }
                else
                {
                    labmsg.Text = "You have enter Incoorrect Email or Password";
                }
            }

        }
        
    }
}