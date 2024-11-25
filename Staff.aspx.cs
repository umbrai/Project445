using System;
using System.Web;
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
                // Attempt to retrieve staff from cookies
                HttpCookie staffCookie = Request.Cookies["StaffProfile"];
                if (staffCookie != null)
                {
                    Session["StaffUser"] = staffCookie["Username"];
                }
                else
                {
                    // Redirect to staff login if no session or cookie
                    Response.Redirect("StaffLogin.aspx");
                }
            }
        }
    }
}
