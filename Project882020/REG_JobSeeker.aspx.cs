using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace Project882020
{
    public partial class REG_JobSeeker : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourse();
                BindCountry();
                ddlstate.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlcity.Enabled = false;
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
                Bindjp();


            }
            if (Request.QueryString["edit"] != null && Request.QueryString["edit"]!="")
            {
                if (!IsPostBack)
                {
                    Edit();
                }
            }
        }

        public void Edit()
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
                textName.Text = dt.Rows[0]["name"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                textEmail.Text = dt.Rows[0]["email"].ToString();
                ddlcourse.SelectedValue = dt.Rows[0]["course"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
                ddlstate.Enabled = true;
                BindState();
                ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
                ddlcity.Enabled = true;
                BindCity();
                textpass.Text = dt.Rows[0]["password"].ToString();
                ddlcity.SelectedValue = dt.Rows[0]["city"].ToString();
                btn_submit.Text = "Update";
            }
            
        }

        public void BindCourse()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select * from tblcourse", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                ddlcourse.DataValueField = "c_id";
                ddlcourse.DataTextField = "c_name";
                ddlcourse.DataSource = dt;
                ddlcourse.DataBind();
                ddlcourse.Items.Insert(0, new ListItem("--Select--", "0"));
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
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
            }


        }

        public void BindCity()
        {
            con.Open();
            SqlCommand com = new SqlCommand("cityproc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "selectbystate");
            com.Parameters.AddWithValue("@sid", ddlstate.SelectedValue);
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
        public void Bindjp()
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
                ddlregjp.DataValueField = "j_id";
                ddlregjp.DataTextField = "j_name";
                ddlregjp.DataSource = dt;
                ddlregjp.DataBind();
                ddlregjp.Items.Insert(0, new ListItem("--Select--", "0"));
            }

        }
        public void clear()
        {
            textName.Text = "";
            rblgender.ClearSelection();
            textEmail.Text = "";
            ddlcourse.SelectedValue = "0";
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            ddlstate.Enabled = false;
            ddlcity.SelectedValue = "0";
            ddlcity.Enabled = false;
            ddlregjp.SelectedValue = "0";
            textpass.Text = "";
            btn_submit.Text = "Submit";
        }

        
        protected void btn_submit_Click(object sender, EventArgs e)
        {

            if (btn_submit.Text == "Submit")
            {
                string FN = "";
                FN = Path.GetFileName(imgProfile.PostedFile.FileName);
                imgProfile.SaveAs(Server.MapPath("Profile_Image" + "//" + FN));

                con.Open();
                SqlCommand com = new SqlCommand("commonprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "insert");
                com.Parameters.AddWithValue("@name", textName.Text);
                com.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                com.Parameters.AddWithValue("@email", textEmail.Text);
                com.Parameters.AddWithValue("@course", ddlcourse.SelectedValue);
                com.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                com.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                com.Parameters.AddWithValue("@password", textpass.Text);
                com.Parameters.AddWithValue("@jobProfile", ddlregjp.SelectedValue);
                com.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                com.Parameters.AddWithValue("@pimage", FN);
                int i=com.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    labmsg.Text =i + " Record Inserted";
                }
                else
                {
                    labmsg.Text = "Record not Inserted";
                }
                
            }
            else if (btn_submit.Text == "Update")
            {
                con.Open();
                SqlCommand com = new SqlCommand("commonprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "update");
                com.Parameters.AddWithValue("@id", Request.QueryString["edit"]);
                com.Parameters.AddWithValue("@name", textName.Text);
                com.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                com.Parameters.AddWithValue("@email", textEmail.Text);
                com.Parameters.AddWithValue("@course", ddlcourse.SelectedValue);
                com.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                com.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                com.Parameters.AddWithValue("@jobProfile", ddlregjp.SelectedValue);
                com.Parameters.AddWithValue("@password", textpass.Text);
                com.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    labmsg.Text = "Record not Updated";
                }
                ddlstate.Enabled = false;
                ddlcity.Enabled = false;
                
                btn_submit.Text = "Submit";
            }
            
            clear();
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
    }
}