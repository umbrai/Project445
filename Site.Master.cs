using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project445
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetActiveClass(string page)
        {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            return currentPage.Equals(page, StringComparison.OrdinalIgnoreCase) ? "active" : string.Empty;
        }
    }
}