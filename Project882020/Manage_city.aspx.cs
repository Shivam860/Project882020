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
    public partial class Manage_city : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindcountry();
                ddlState.Enabled = false;
                ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
                bindcity();
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
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));

        }

  

        public void bindstate()
        {
            con.Open();
            SqlCommand com = new SqlCommand("stateproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "selectbycountry");
            com.Parameters.AddWithValue("@countryid", ddlCountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            ddlState.DataValueField = "sid";
            ddlState.DataTextField = "sname";
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void bindcity()
        {
            con.Open();
            SqlCommand com = new SqlCommand("cityproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "select");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            gv_city.DataSource = dt;
            gv_city.DataBind();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("cityproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "insert");
            com.Parameters.AddWithValue("@sid", ddlState.SelectedValue);
            com.Parameters.AddWithValue("@cname", textCity.Text);
            com.ExecuteNonQuery();
            con.Close();
            bindcity();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlState.Enabled = true;
            bindstate();
        }

        protected void gv_city_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("cityproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "delete");
            com.Parameters.AddWithValue("@cid", e.CommandArgument);
            com.ExecuteNonQuery();
            con.Close();
            bindcity();
        }
    }
}