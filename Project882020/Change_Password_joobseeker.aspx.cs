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
    public partial class Change_Password_joobseeker : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_changePass_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("commonprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "Change_Password");
            com.Parameters.AddWithValue("@name", textNewPass.Text);
            com.Parameters.AddWithValue("@id",Session["id"]);
            com.Parameters.AddWithValue("@password", textOldPass.Text);
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i > 0) {
                Response.Redirect("Logout.aspx");
            }
            else
            {
                labmsg.Text = "Password Not Change !!!";
            }
        }
    }
}