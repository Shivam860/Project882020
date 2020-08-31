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
    public partial class Manage_country : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindcountry();
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
            gv_country.DataSource=dt;
            gv_country.DataBind();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("countryproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action","insert");
            com.Parameters.AddWithValue("@countryname",textCountry.Text);
            com.ExecuteNonQuery();
            con.Close();
            bindcountry();
        }

        protected void gv_country_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("countryproc",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "delete");
            com.Parameters.AddWithValue("@countryid",e.CommandArgument);
            com.ExecuteNonQuery();
            con.Close();
            bindcountry();
        }
    }
}