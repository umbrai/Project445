using System;

namespace Project445
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Any additional initialization logic can go here
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Redirect to the Login page
            Response.Redirect("Login.aspx");
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            // Redirect to the Home page without login
            Response.Redirect("Home.aspx");
        }
    }
}
