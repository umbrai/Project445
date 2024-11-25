using System;
using System.Web.UI;

namespace Project445
{
    public partial class Staff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in as staff
            if (Session["StaffUser"] == null)
            {
                Response.Redirect("StaffLogin.aspx");
            }
        }
    }
}
