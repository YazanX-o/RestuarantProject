using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestuarantProject.App_Code;

namespace RestuarantProject.Account
{
    public partial class restuarant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the logged-in user's UserId
            string userName = User.Identity.Name;
            MembershipUser user = Membership.GetUser(userName);
            if (user == null)
            {
                lblOutput.Text = "User not found!(please register first)";
                return;
            }
            if (string.IsNullOrEmpty(TxtRestaurantName.Text))
            {
                lblOutput.Text = "Please fill Restuarant Name!!";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                TxtRestaurantName.Focus();
                return;
            }
            Guid userId = (Guid)user.ProviderUserKey;

            // Get the restaurant name from the TextBox
            string restaurantName = TxtRestaurantName.Text;

            // Insert the restaurant into the database
            CRUD mycrud = new CRUD();
            string mysql = @"INSERT INTO Resturant (UserId, RestaurantName)
                         VALUES (@UserId, @RestaurantName)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@UserId", userId);
            myPara.Add("@RestaurantName", restaurantName);
            int rtn = mycrud.InsertUpdateDelete(mysql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Operation Successful!";
            }
            else
            {
                lblOutput.Text = "Operation failed!";
            }
        
        }

        protected void btnShowOtherRatings_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowAllRatings.aspx");
        }
    }
}