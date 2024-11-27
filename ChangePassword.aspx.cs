using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace Project445
{
    public partial class ChangePassword : Page
    {
        private const string MemberFilePath = "~/App_Data/Member.xml";

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmNewPassword = txtConfirmNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmNewPassword))
            {
                lblMessage.Text = "All fields are required.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                lblMessage.Text = "New passwords do not match.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string userId = Session["LoggedInUser"]?.ToString();
            if (string.IsNullOrEmpty(userId))
            {
                lblMessage.Text = "You must be logged in to change your password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string filePath = Server.MapPath(MemberFilePath);

            if (!File.Exists(filePath))
            {
                lblMessage.Text = "Member data not found.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                XDocument doc = XDocument.Load(filePath);
                XElement userElement = doc.Descendants("Member")
                                          .FirstOrDefault(m => m.Element("UserName")?.Value == userId);

                if (userElement == null)
                {
                    lblMessage.Text = "User not found.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string hashedCurrentPassword = SecurityLibrary.Class1.ComputeSHA256Hash(currentPassword);
                if (userElement.Element("PasswordHash")?.Value != hashedCurrentPassword)
                {
                    lblMessage.Text = "Current password is incorrect.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string hashedNewPassword = SecurityLibrary.Class1.ComputeSHA256Hash(newPassword);
                userElement.Element("PasswordHash").Value = hashedNewPassword;
                doc.Save(filePath);

                lblMessage.Text = "Password changed successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
