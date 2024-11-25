using System;
using System.Data;
using System.IO;
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
                LoadStaff();
            }
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
                lblMessage.Text = "Username and password are required.";
                return;
            }

            string encryptedPassword = EncryptPassword(password);

            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath(StaffFilePath);

            if (!File.Exists(path))
            {
                XmlElement root = doc.CreateElement("Staff");
                doc.AppendChild(root);
            }
            else
            {
                doc.Load(path);
            }

            XmlElement userElement = doc.CreateElement("User");
            XmlElement usernameElement = doc.CreateElement("Username");
            usernameElement.InnerText = username;
            XmlElement passwordElement = doc.CreateElement("Password");
            passwordElement.InnerText = encryptedPassword;

            userElement.AppendChild(usernameElement);
            userElement.AppendChild(passwordElement);
            doc.DocumentElement.AppendChild(userElement);

            doc.Save(path);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Staff added successfully!";
            txtUsername.Text = "";
            txtPassword.Text = "";

            LoadStaff();
        }

        protected void gvStaff_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string usernameToDelete = e.CommandArgument.ToString();

                XmlDocument doc = new XmlDocument();
                string path = Server.MapPath(StaffFilePath);
                doc.Load(path);

                XmlNode userNode = doc.SelectSingleNode($"//User[Username='{usernameToDelete}']");
                if (userNode != null)
                {
                    doc.DocumentElement.RemoveChild(userNode);
                    doc.Save(path);
                    LoadStaff();
                }
            }
        }

        private string EncryptPassword(string password)
        {
            // Replace this with your DLL encryption function
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
