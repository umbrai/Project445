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
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Validate the provided credentials
                if (ValidateStaffCredentials(username, password))
                {
                    // Store the logged-in staff user in the session
                    Session["StaffUser"] = username;

                    // Create a cookie for the staff profile
                    HttpCookie staffCookie = new HttpCookie("StaffProfile");
                    staffCookie["Username"] = username;
                    staffCookie.Expires = DateTime.Now.AddHours(1); // Set cookie expiry time
                    Response.Cookies.Add(staffCookie);

                    // Debugging output to verify credentials
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Login successful. Redirecting to Staff page...";

                    // Redirect to the Staff page
                    Response.Redirect("Staff.aspx", false);
                    Context.ApplicationInstance.CompleteRequest(); // Ensure redirect completes properly
                }
                else
                {
                    // Display an error message for invalid credentials
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you can replace this with actual logging logic)
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "An error occurred during login. Please try again.";

                // Optionally log exception details
                System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
            }
        }


        private string EncryptPassword(string plainTextPassword)
        {
            // More secure encryption logic using SHA256 hashing
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainTextPassword));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool ValidateStaffCredentials(string username, string password)
        {
            string staffFilePath = Server.MapPath("~/App_Data/Staff.xml");

            if (!File.Exists(staffFilePath))
            {
                return false; // Return false if the Staff.xml file doesn't exist
            }

            var staffDoc = XDocument.Load(staffFilePath);

            // Hash the provided password to match the stored hash
            string encryptedPassword = EncryptPassword(password);

            // Validate credentials
            return staffDoc.Descendants("StaffMember").Any(member =>
                member.Element("Username")?.Value == username &&
                member.Element("Password")?.Value == encryptedPassword);
        }


    }
}
