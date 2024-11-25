using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;

namespace Project445
{
    public partial class Login : Page
    {
        private const string MemberFilePath = "~/App_Data/Member.xml";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtLoginUserID.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            if (AuthenticateMember(userId, password))
            {
                // Store the logged-in user in the session
                Session["LoggedInUser"] = userId;

                // Redirect to the Member page
                Response.Redirect("Member.aspx", false);
                Context.ApplicationInstance.CompleteRequest(); // Ensure redirection completes
            }
            else
            {
                lblLoginMessage.ForeColor = System.Drawing.Color.Red;
                lblLoginMessage.Text = "Invalid user ID or password.";
            }
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblRegisterMessage.Text = ""; // Clear previous messages

            string userId = txtRegisterUserID.Text.Trim();
            string password = txtRegisterPassword.Text.Trim();
            string captcha = txtRegisterCaptcha.Text.Trim();

            // Validate CAPTCHA
            string captchaText = Session["CaptchaText"] as string;
            if (string.IsNullOrEmpty(captchaText) || !captcha.Equals(captchaText, StringComparison.OrdinalIgnoreCase))
            {
                lblRegisterMessage.ForeColor = System.Drawing.Color.Red;
                lblRegisterMessage.Text = "Invalid CAPTCHA. Please try again.";
                return;
            }

            // Add user to XML
            try
            {
                AddMember(userId, password);
                lblRegisterMessage.ForeColor = System.Drawing.Color.Green;
                lblRegisterMessage.Text = "Registration successful!";
            }
            catch (Exception ex)
            {
                lblRegisterMessage.ForeColor = System.Drawing.Color.Red;
                lblRegisterMessage.Text = $"Error: {ex.Message}";
            }
        }

        private bool AuthenticateMember(string userId, string password)
        {
            string filePath = Server.MapPath(MemberFilePath);

            if (!File.Exists(filePath))
            {
                lblLoginMessage.Text = "No registered users found. Please register.";
                return false;
            }

            string hashedPassword = HashPassword(password);

            XDocument doc = XDocument.Load(filePath);

            return doc.Descendants("Member")
                      .Any(m => m.Element("UserName")?.Value == userId &&
                                m.Element("PasswordHash")?.Value == hashedPassword);
        }


        private void AddMember(string userId, string password)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
                throw new Exception("User ID and password cannot be empty.");

            string filePath = Server.MapPath(MemberFilePath);
            string hashedPassword = HashPassword(password);

            XDocument doc;

            if (File.Exists(filePath))
            {
                doc = XDocument.Load(filePath);
            }
            else
            {
                doc = new XDocument(new XElement("Members"));
            }

            // Check if the user already exists
            if (doc.Descendants("Member").Any(m => m.Element("UserName")?.Value == userId))
                throw new Exception("User ID already exists.");

            XElement newMember = new XElement("Member",
                new XElement("UserName", userId),
                new XElement("PasswordHash", hashedPassword)
            );
            doc.Root.Add(newMember);
            doc.Save(filePath);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
