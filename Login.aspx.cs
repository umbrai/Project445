using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Project445
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelTextCaptcha.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Validate the text-based CAPTCHA
            string captchaText = Session["CaptchaText"] as string;
            string userCaptchaInput = txtCaptcha.Text.Trim();

            if (string.IsNullOrEmpty(captchaText) || !userCaptchaInput.Equals(captchaText, StringComparison.OrdinalIgnoreCase))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "CAPTCHA validation failed. Please try again.";
                txtCaptcha.Text = ""; // Clear the CAPTCHA input field
                return;
            }

            // Perform user authentication with password encryption
            string userId = txtUserID.Text.Trim();
            string password = txtPassword.Text.Trim();
            string encryptedPassword = EncryptPassword(password);

            if (IsAuthenticated(userId, encryptedPassword))
            {
                // Successful login
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid user ID or password.";
            }
        }

        private bool IsAuthenticated(string userId, string encryptedPassword)
        {
            // Replace with actual authentication logic (e.g., check against a database)
            const string validUserId = "user123";
            const string validEncryptedPassword = "b2e98ad6f6eb8508dd6a14cfa704bad7"; // Precomputed hash for "pass123"

            return userId.Equals(validUserId, StringComparison.OrdinalIgnoreCase) && encryptedPassword == validEncryptedPassword;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower(); // Return hash as a hexadecimal string
            }
        }
    }
}
