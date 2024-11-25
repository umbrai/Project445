using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
namespace Project445
{
    public partial class StaffLogin : Page
    {

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (ValidateStaffCredentials(username, password))
            {
                // Store logged-in staff in session
                Session["StaffUser"] = username;

                HttpCookie staffCookie = new HttpCookie("StaffProfile");
                staffCookie["Username"] = username;
                staffCookie.Expires = DateTime.Now.AddHours(1); // Set expiry time
                Response.Cookies.Add(staffCookie);

                // Redirect to Staff page
                Response.Redirect("Staff.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }

        private bool ValidateStaffCredentials(string username, string password)
        {
            string staffFilePath = Server.MapPath("~/App_Data/Staff.xml");
            var staffDoc = XDocument.Load(staffFilePath);

            // Validate credentials
            return staffDoc.Descendants("Member").Any(member =>
                member.Element("Username")?.Value == username &&
                member.Element("Password")?.Value == password);
        }
    }
}
