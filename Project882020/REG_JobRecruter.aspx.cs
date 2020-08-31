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
    public partial class REG_JobRecruter : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                ddlstate.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlcity.Enabled = false;
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            if (Request.QueryString["edit"] != null && Request.QueryString["edit"] != "")
            {
                if (!IsPostBack)
                {
                    edit();
                }
            }

        }

        public void edit()
        {
            con.Open();
            SqlCommand com = new SqlCommand("commonprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "edit");
            com.Parameters.AddWithValue("@id", Request.QueryString["edit"]);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {

            }
        }
        public void BindCountry()
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
            if (dt.Rows.Count > 0)
            {
                ddlcountry.DataValueField = "countryid";
                ddlcountry.DataTextField = "countryname";
                ddlcountry.DataSource = dt;
                ddlcountry.DataBind();
                ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        public void BindState()
        {
            con.Open();
            SqlCommand com = new SqlCommand("stateproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "selectbycountry");
            com.Parameters.AddWithValue("@countryid", ddlcountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                ddlstate.DataValueField = "sid";
                ddlstate.DataTextField = "sname";
                ddlstate.DataSource = dt;
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, new ListItem("--Select", "0"));
            }


        }

        public void BindCity()
        {
            con.Open();
            SqlCommand com = new SqlCommand("cityproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "selectbystate");
            com.Parameters.AddWithValue("@sid",ddlstate.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                ddlcity.DataValueField = "cid";
                ddlcity.DataTextField = "cname";
                ddlcity.DataSource = dt;
                ddlcity.DataBind();
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
            }

        }
        public void clear()
        {
            textName.Text = "";
            textEmail.Text = "";
            textComment.Text = "";
            textAddress.Text = "";
            textNumber.Text = "";
            textPerson.Text = "";
            textURL.Text = "";
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            ddlstate.Enabled = false;
            ddlcity.SelectedValue = "0";
            ddlcity.Enabled = false;
            textPass.Text = "";
            Btn_save_recruter.Text = "Submit";
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlstate.Enabled = true;
            BindState();
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlcity.Enabled = true;
            BindCity();
        }

        protected void Btn_save_recruter_Click(object sender, EventArgs e)
        {

            if (Btn_save_recruter.Text == "Submit")
            {
                con.Open();
                SqlCommand com = new SqlCommand("recprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "insert");
                com.Parameters.AddWithValue("@r_cname", textName.Text);
                com.Parameters.AddWithValue("@r_url", textURL.Text);
                com.Parameters.AddWithValue("@r_email", textEmail.Text);
                com.Parameters.AddWithValue("@r_password", textPass.Text);
                com.Parameters.AddWithValue("@r_contactperson", textPerson.Text);
                com.Parameters.AddWithValue("@r_contactnumber", textNumber.Text);
                com.Parameters.AddWithValue("@r_country", ddlcountry.SelectedValue);
                com.Parameters.AddWithValue("@r_state", ddlstate.SelectedValue);
                com.Parameters.AddWithValue("@r_city", ddlcity.SelectedValue);
                com.Parameters.AddWithValue("@r_companyaddress", textAddress.Text);
                com.Parameters.AddWithValue("@comment", textComment.Text);
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    labmsg.Text = i + " Record Inserted";

                }
                else
                {
                    labmsg.Text = "Record not Inserted";
                }
            }
            else if (Btn_save_recruter.Text == "update")
            {
                con.Open();
                SqlCommand com = new SqlCommand("recprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "update");
                com.Parameters.AddWithValue("@r_cname", textName.Text);
                com.Parameters.AddWithValue("@r_url", textURL.Text);
                com.Parameters.AddWithValue("@r_email", textEmail.Text);
                com.Parameters.AddWithValue("@r_password", textPass.Text);
                com.Parameters.AddWithValue("@r_contactperson", textPerson.Text);
                com.Parameters.AddWithValue("@r_contactnumber", textNumber.Text);
                com.Parameters.AddWithValue("@r_country", ddlcountry.SelectedValue);
                com.Parameters.AddWithValue("@r_state", ddlstate.SelectedValue);
                com.Parameters.AddWithValue("@r_city", ddlcity.SelectedValue);
                com.Parameters.AddWithValue("@r_companyaddress", textAddress.Text);
                com.Parameters.AddWithValue("@comment", textComment.Text);
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    labmsg.Text = i + " Record Inserted";

                }
                else
                {
                    labmsg.Text = "Record not Inserted";
                }
            }
            clear();
        }
    }
}