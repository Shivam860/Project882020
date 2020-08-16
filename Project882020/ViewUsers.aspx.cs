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
    public partial class ViewUsers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database_connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUser();
            }
        }

        public void BindUser()
        {
            con.Open();
            SqlCommand com = new SqlCommand("commonprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "display");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.DataBind();
            }
            else
            {
                labmsg.Text = "No Record found!!";
            }
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
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    labmsg.Text =i+ " Record Deleted   ";
                }
                else
                {
                    labmsg.Text = "Record not deleted";
                }
                BindUser();

            }
            else if (e.CommandName == "B")
            {
                Response.Redirect("Registration.aspx?edit="+e.CommandArgument);
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("commonprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "search");
            com.Parameters.AddWithValue("@name",textSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.DataBind();
                labmsg.Text = "";
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
                labmsg.Text=" NO RECORD FOUND!!";
            }
        }
    }
}