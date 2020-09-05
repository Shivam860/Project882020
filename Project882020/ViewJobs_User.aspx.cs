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
    public partial class ViewJobs_User : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindViewJobPost();
                bindDDL();
            }
        }

        public void BindViewJobPost()
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
                gv_Jobuser.DataSource = dt;
                gv_Jobuser.DataBind();
               
            }
        }

        public void bindDDL()
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from jobprofile", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                ddljobuser.DataValueField = "j_id";
                ddljobuser.DataTextField = "j_name";
                ddljobuser.DataSource = dt;
                ddljobuser.DataBind();
                ddljobuser.Items.Insert(0, new ListItem("--Select--", "0"));
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
                gv_Jobuser.DataSource = dt;
                gv_Jobuser.DataBind();
               
            }
            BindViewJobPost();
        }
    }
}