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
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourse();
                BindCountry();
                BindUser();
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
            ddlcourse.DataValueField = "c_id";
            ddlcourse.DataTextField = "c_name";
            ddlcourse.DataSource = dt;
            ddlcourse.DataBind();
            ddlcourse.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select * from tblcountry", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            ddlcountry.DataValueField = "country_id";
            ddlcountry.DataTextField = "country_name";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindState()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select * from tblstate where country_id='"+ddlcountry.SelectedValue+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            ddlstate.DataValueField = "state_id";
            ddlstate.DataTextField = "state_name";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void clear()
        {
            textName.Text = "";
            rblgender.ClearSelection();
            textEmail.Text = "";
            ddlcourse.SelectedValue = "0";
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            textpass.Text = "";
            btn_submit.Text = "Submit";
        }

        public void BindUser()
        {
            con.Open();
            SqlCommand com = new SqlCommand("commonprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action","display");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            gv.DataSource = dt;
            gv.DataBind();
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (btn_submit.Text == "Submit")
            {
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
                com.ExecuteNonQuery();
                con.Close();
                
            }
            else if (btn_submit.Text == "Update")
            {
                con.Open();
                SqlCommand com = new SqlCommand("commonprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "update");
                com.Parameters.AddWithValue("@id", ViewState["id"]);
                com.Parameters.AddWithValue("@name", textName.Text);
                com.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                com.Parameters.AddWithValue("@email", textEmail.Text);
                com.Parameters.AddWithValue("@course", ddlcourse.SelectedValue);
                com.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                com.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                com.Parameters.AddWithValue("@password", textpass.Text);
                com.ExecuteNonQuery();
                con.Close();
                
                btn_submit.Text = "Submit";
            }
            BindUser();
            clear();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand com = new SqlCommand("commonprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "delete");
                com.Parameters.AddWithValue("@id", e.CommandArgument);
                com.ExecuteNonQuery();
                con.Close();
                BindUser();
            }
            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand com = new SqlCommand("commonprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "edit");
                com.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                com.ExecuteNonQuery();
                con.Close();
                textName.Text = dt.Rows[0]["name"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                textEmail.Text = dt.Rows[0]["email"].ToString();
                ddlcourse.SelectedValue = dt.Rows[0]["course"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
                ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
                textpass.Text = dt.Rows[0]["password"].ToString();
                btn_submit.Text = "Update";
                ViewState["id"] = e.CommandArgument;
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }
    }
}