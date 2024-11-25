using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Project445
{
    public partial class Memberships : Page
    {
        // Membership costs
        private const decimal ThreeMonthCost = 80.00m;
        private const decimal SixMonthCost = 150.00m;
        private const decimal OneYearCost = 300.00m;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the list of memberships
                var memberships = GetMemberships();

                // Bind the data to the GridView
                gvMemberships.DataSource = memberships;
                gvMemberships.DataBind();
            }
        }

        private List<Membership> GetMemberships()
        {
            return new List<Membership>
            {
                new Membership
                {
                    Name = "Three Month Membership",
                    Duration = "3 Months",
                    Description = "Enjoy access to all our facilities for three months.",
                    Price = ThreeMonthCost
                },
                new Membership
                {
                    Name = "Six Month Membership",
                    Duration = "6 Months",
                    Description = "Enjoy access to all our facilities for six months.",
                    Price = SixMonthCost
                },
                new Membership
                {
                    Name = "One Year Membership",
                    Duration = "1 Year",
                    Description = "Enjoy access to all our facilities for one full year.",
                    Price = OneYearCost
                }
            };
        }
    }
}
