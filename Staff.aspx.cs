using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace Project445
{
    public partial class Staff : System.Web.UI.Page
    {
        private const string StaffFilePath = "~/App_Data/Staff.xml";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie staffCookie = Request.Cookies["StaffProfile"];
                if (staffCookie != null && staffCookie["Username"] != null)
                {
                    string username = staffCookie["Username"];
                    lblLoggedInUser.Text = $"Welcome, {username}";
                }
                else
                {
                    Response.Redirect("StaffLogin.aspx");
                }

                LoadStaff();
            }
        }

        protected void UserIcon_Click(object sender, EventArgs e)
        {
            userOptionsPanel.Visible = !userOptionsPanel.Visible; // Toggle visibility
        }



        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the staff profile cookie
            if (Request.Cookies["StaffProfile"] != null)
            {
                HttpCookie staffCookie = new HttpCookie("StaffProfile");
                staffCookie.Expires = DateTime.Now.AddDays(-1); // Expire the cookie
                Response.Cookies.Add(staffCookie);
            }

            // Redirect to login page
            Response.Redirect("StaffLogin.aspx");
        }




        private void LoadStaff()
        {
            if (File.Exists(Server.MapPath(StaffFilePath)))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath(StaffFilePath));
                gvStaff.DataSource = ds;
                gvStaff.DataBind();
            }
        }

        protected void AddStaff_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Username and password are required.";
                return;
            }

            string encryptedPassword = EncryptPassword(password);

            string path = Server.MapPath(StaffFilePath);
            XmlDocument doc = new XmlDocument();

            // Check if the file exists; create a new root if it doesn't.
            if (!File.Exists(path))
            {
                XmlElement root = doc.CreateElement("Staff");
                doc.AppendChild(root);
            }
            else
            {
                doc.Load(path);
            }

            // Prevent duplicate usernames
            XmlNode existingUser = doc.SelectSingleNode($"//StaffMember[Username='{username}']");
            if (existingUser != null)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "A staff member with this username already exists.";
                return;
            }

            // Add the new staff member
            XmlElement staffMemberElement = doc.CreateElement("StaffMember");
            XmlElement usernameElement = doc.CreateElement("Username");
            usernameElement.InnerText = username;
            XmlElement passwordElement = doc.CreateElement("Password");
            passwordElement.InnerText = encryptedPassword;

            staffMemberElement.AppendChild(usernameElement);
            staffMemberElement.AppendChild(passwordElement);
            doc.DocumentElement.AppendChild(staffMemberElement);

            // Save the updated XML document
            try
            {
                doc.Save(path);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Staff member added successfully!";
                txtUsername.Text = "";
                txtPassword.Text = "";
                LoadStaff();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = $"Error saving staff member: {ex.Message}";
            }
        }

        protected void gvStaff_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string usernameToDelete = e.CommandArgument.ToString();

                string path = Server.MapPath(StaffFilePath);
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(path);

                    // Find and remove the staff member
                    XmlNode userNode = doc.SelectSingleNode($"//StaffMember[Username='{usernameToDelete}']");
                    if (userNode != null)
                    {
                        doc.DocumentElement.RemoveChild(userNode);
                        doc.Save(path);
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Staff member deleted successfully.";
                        LoadStaff();
                    }
                    else
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Staff member not found.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = $"Error deleting staff member: {ex.Message}";
                }
            }
        }

        protected void gvStaff_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string usernameToDelete = gvStaff.DataKeys[e.RowIndex].Value.ToString();

            string path = Server.MapPath(StaffFilePath);
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(path);

                // Find and remove the staff member
                XmlNode userNode = doc.SelectSingleNode($"//StaffMember[Username='{usernameToDelete}']");
                if (userNode != null)
                {
                    doc.DocumentElement.RemoveChild(userNode);
                    doc.Save(path);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Staff member deleted successfully.";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Staff member not found.";
                }

                // Refresh the GridView
                LoadStaff();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = $"Error deleting staff member: {ex.Message}";
            }
        }



        private string EncryptPassword(string plainTextPassword)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(plainTextPassword);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

    }
}
