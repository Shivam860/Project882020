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
    public partial class HomePage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUser();
            }
        }
        public void BindUser()
        {
            con.Open();
            SqlCommand com = new SqlCommand("commonprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "view");
            com.Parameters.AddWithValue("@id",Session["id"]);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Session["profile"] = dt.Rows[0]["j_name"].ToString();
                labmsg.Text = dt.Rows[0]["name"].ToString();
                gv_home.DataSource = dt;
                gv_home.DataBind();
            }
        }



        protected void gv_home_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand com = new SqlCommand("commonprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "delete");
                com.Parameters.AddWithValue("@id", Session["id"]);
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    labmsg.Text = i + " Record Deleted   ";
                }
                else
                {
                    labmsg.Text = "Record not deleted";
                }
                BindUser();

            }
            else if (e.CommandName == "B")
            {
                Response.Redirect("REG_JobSeeker.aspx?edit=" + Session["id"]);
            }
        }
    }
}