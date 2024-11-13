using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace Project445
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is already logged in; redirect if necessary
            if (User.Identity.IsAuthenticated)
            {
                // If logged in, show a message or modify controls as needed
                // Example: Show a welcome message
                // WelcomeLabel.Text = $"Welcome back, {User.Identity.Name}!";
            }
        }

        protected void MemberAccessButton_Click(object sender, EventArgs e)
        {
            // Redirect to login if not authenticated, else go to Member page
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Redirect("~/Member.aspx");
            }
        }

        protected void StaffAccessButton_Click(object sender, EventArgs e)
        {
            // Redirect to login if not authenticated, else go to Staff page
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Redirect("~/Staff.aspx");
            }
        }
    }
}