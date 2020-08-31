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
    public partial class rec_jobpost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindJobProfile();
            }
        }
        public void bindJobProfile()
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from jobprofile", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                ddlJp.DataValueField = "j_id";
                ddlJp.DataTextField = "j_name";
                ddlJp.DataSource = dt;
                ddlJp.DataBind();
                ddlJp.Items.Insert(0, new ListItem("--Select--","0"));
            }
        }
        
        protected void btn_submit_jobPost_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("jobpostprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action","insert");
            com.Parameters.AddWithValue("@compnayid", Session["r_id"]);
            com.Parameters.AddWithValue("@jp_jobprofile",ddlJp.SelectedValue);
            com.Parameters.AddWithValue("@jp_minExp",textMinExp.Text);
            com.Parameters.AddWithValue("@jp_maxExp", textMaxExp.Text);
            com.Parameters.AddWithValue("@minsalary", textMinSalary.Text);
            com.Parameters.AddWithValue("@maxsalary", textMaxSalary.Text);
            com.Parameters.AddWithValue("@jp_novacancy",textVacancy.Text);
            com.Parameters.AddWithValue("@jp_comment",textComment.Text);
            int i=com.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                labjobpost.Text = "Record Saved Successfully !!!";
            }
            else
            {
                labjobpost.Text = "Record not Saved Successfully !!!";
            }
        }
    }
}