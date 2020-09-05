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
    public partial class Manage_JobPost_Admin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindManageJobPost();
            }
        }

        public void BindManageJobPost()
        {
            con.Open();
            SqlCommand com = new SqlCommand("procjobpost", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "display");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gv_Jobpost_admin.DataSource = dt;
                gv_Jobpost_admin.DataBind();
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("procjobpost", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "search");
            com.Parameters.AddWithValue("@j_name", textSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gv_Jobpost_admin.DataSource = dt;
                gv_Jobpost_admin.DataBind();
                
            }
           
        }
    }
}