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
    public partial class Manage_state : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindcountry();
                ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
                bindstate();
            }
        }

        public void bindcountry()
        {
            con.Open();
            SqlCommand com = new SqlCommand("countryproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "select");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            ddlCountry.DataValueField = "countryid";
            ddlCountry.DataTextField = "countryname";
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();

        }

        public void bindstate()
        {
            con.Open();
            SqlCommand com = new SqlCommand("stateproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "select");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            gv_state.DataSource = dt;
            gv_state.DataBind();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("stateproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "insert");
            com.Parameters.AddWithValue("@countryid", ddlCountry.SelectedValue);
            com.Parameters.AddWithValue("@sname", textState.Text);
            com.ExecuteNonQuery();
            con.Close();
            bindstate();
        }

        protected void gv_state_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("stateproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "delete");
            com.Parameters.AddWithValue("@sid", e.CommandArgument);
            com.ExecuteNonQuery();
            con.Close();
            bindstate();
        }
    }
}