﻿using System;
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
    public partial class Manage_JobRecruter : System.Web.UI.Page
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
            SqlCommand com = new SqlCommand("recprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "display");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                
                gv_manager_recruter.DataSource = dt;
                gv_manager_recruter.DataBind();
            }
        }

       

        protected void btn_search_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("recprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "search");
            com.Parameters.AddWithValue("@r_cname", textSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gv_manager_recruter.DataSource = dt;
                gv_manager_recruter.DataBind();
                labmasg.Text = "";
            }
            else
            {
                gv_manager_recruter.DataSource = null;
                gv_manager_recruter.DataBind();
                labmasg.Text = " NO RECORD FOUND!!";
            }
        }

        protected void gv_manager_recruter_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
                con.Open();
                SqlCommand com = new SqlCommand("recprocedure", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@action", "update_status");
                com.Parameters.AddWithValue("@r_id",e.CommandArgument);
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    labmasg.Text = i + " Status Updated  ";
                }
                else
                {
                    labmasg.Text = "status not updated";
                }
            
        }
    }
}