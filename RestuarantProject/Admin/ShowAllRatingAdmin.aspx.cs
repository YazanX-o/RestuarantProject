using RestuarantProject.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestuarantProject.Admin
{
    public partial class ShowAllRatingAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateGvIntern();
        }

        protected void populateGvIntern()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from Resturant";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvShowAllRatings.DataSource = dr;
            gvShowAllRatings.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("restuarant.aspx");
        }
    }
}