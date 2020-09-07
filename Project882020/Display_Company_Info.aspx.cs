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
    public partial class Display_Company_Info : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
            }
        }
        public void BindCompany()
        {
            con.Open();
            SqlCommand com = new SqlCommand("recprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "view");
            com.Parameters.AddWithValue("@r_id", Request.QueryString["JID"]);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                labName.Text = dt.Rows[0]["r_cname"].ToString();
                labUrl.Text = dt.Rows[0]["r_url"].ToString();
                labEmail.Text = dt.Rows[0]["r_email"].ToString();
                labPerson.Text = dt.Rows[0]["r_contactperson"].ToString();
                labNum.Text = dt.Rows[0]["r_contactnumber"].ToString();
                labComm.Text = dt.Rows[0]["comment"].ToString();

            }
        }
    }
}