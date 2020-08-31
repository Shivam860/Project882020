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
    public partial class rec_HomePage : System.Web.UI.Page
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
            SqlCommand com = new SqlCommand("recprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "view");
            com.Parameters.AddWithValue("@r_id", Session["r_id"]);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {

                lbmsg.Text = dt.Rows[0]["r_cname"].ToString();
                gv_recuter.DataSource = dt;
                gv_recuter.DataBind();
            }
        }
        protected void gv_recuter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand com = new SqlCommand("recprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "delete");
                com.Parameters.AddWithValue("@r_id", Session["r_id"]);
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    lbmsg.Text = i + " Record Deleted   ";
                }
                else
                {
                    lbmsg.Text = "Record not deleted";
                }
                BindUser();
            }
            else if (e.CommandName == "B")
            {
                Response.Redirect("REG_JobRecruter.aspx?edit=" + Session["r_id"]);
            }
        }
    }
}