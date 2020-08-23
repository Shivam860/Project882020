using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project882020
{
    public partial class Regrestration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("REG_JobSeeker.aspx");
        }

        protected void btn_rec_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("REG_JobRecruter.aspx");
        }
    }
}