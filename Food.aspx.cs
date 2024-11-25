using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Project445
{
    public partial class Food : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the list of menu items
                var menuItems = GetMenuItems();

                // Bind the data to the GridView
                gvMenuItems.DataSource = menuItems;
                gvMenuItems.DataBind();
            }
        }

        private List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem
                {
                    Name = "Hotdogs",
                    Price = 3.50m,
                    ImageUrl = "https://www.foodandwine.com/thmb/FERhwFz2hJrCkgtDZmkz_rHaCrA=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/best-hot-dogs-in-every-state-FT-BLOG1020-6e025500cefb480ba986b163792ec790.jpg"
                },
                new MenuItem
                {
                    Name = "Nachos",
                    Price = 4.00m,
                    ImageUrl = "https://paleogrubs.com/wp-content/uploads/2014/03/paleonachos.jpg"
                },
                new MenuItem
                {
                    Name = "Pizza",
                    Price = 5.00m,
                    ImageUrl = "https://www.abeautifulplate.com/wp-content/uploads/2015/08/the-best-homemade-margherita-pizza-1-4.jpg"
                },
                new MenuItem
                {
                    Name = "Popcorn",
                    Price = 2.50m,
                    ImageUrl = "https://www.cookingclassy.com/wp-content/uploads/2012/11/caramel+popcorn+2.jpg"
                },
                new MenuItem
                {
                    Name = "Loaded French Fries",
                    Price = 4.50m,
                    ImageUrl = "https://therecipecritic.com/wp-content/uploads/2023/02/loaded-fries-4.jpg"
                },
                new MenuItem
                {
                    Name = "Chicken Strips",
                    Price = 6.00m,
                    ImageUrl = "https://i0.wp.com/danieldiver.net/wp-content/uploads/2020/12/20201201_1835045512609713577942212.jpg?fit=2000%2C2000&ssl=1"
                },
                                new MenuItem
                {
                    Name = "Strawberry Slushie",
                    Price = 2.00m,
                    ImageUrl = "https://www.atipsygiraffe.com/wp-content/uploads/2017/02/Strawberry-Thyme-Slushie-Valentine-Cocktail-4.jpg"
                },
                new MenuItem
                {
                    Name = "Vanilla Slushie",
                    Price = 2.00m,
                    ImageUrl = "https://thetoastedpinenut.com/wp-content/uploads/2018/07/IMG_7013-2.jpg"
                },
                new MenuItem
                {
                    Name = "Raspberry Slushie",
                    Price = 2.00m,
                    ImageUrl = "https://tropeaka.com/cdn/shop/articles/Raspberry-Slushie-01_1600x.jpg?v=1607922607"
                },
                new MenuItem
                {
                    Name = "Pepsi",
                    Price = 1.50m,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0558/6413/1764/files/Pepsi_Logo_Design_History_Evolution_0_1024x1024.jpg?v=1692893776"
                },
                new MenuItem
                {
                    Name = "Coca Cola",
                    Price = 1.50m,
                    ImageUrl = "https://i.redd.it/fancy-an-ice-cold-coke-v0-mu50yho7lx6c1.png?width=1024&format=png&auto=webp&s=fcc1b0d9019c0121af9dd59a324846698932ee2c"
                },
                new MenuItem
                {
                    Name = "Mountain Dew",
                    Price = 1.50m,
                    ImageUrl = "https://www.preparedfoods.com/ext/resources/images/2017/MountainDew17_900.jpg?1484696850"
                },
                new MenuItem
                {
                    Name = "Sprite",
                    Price = 1.50m,
                    ImageUrl = "https://i.pinimg.com/originals/70/20/72/702072207f576205e485feb7c31bf84b.jpg"
                },
                new MenuItem
                {
                    Name = "Root Beer",
                    Price = 1.50m,
                    ImageUrl = "https://www.thedailymeal.com/img/gallery/14-best-root-beers-ranked/aw-1676307645.jpg"
                },
                new MenuItem
                {
                    Name = "M&Ms",
                    Price = 1.00m,
                    ImageUrl = "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-760w,f_auto,q_auto:best/rockcms/2022-01/MMs-te-4-220120-52089c.jpg"
                },
                new MenuItem
                {
                    Name = "Dibs",
                    Price = 1.50m,
                    ImageUrl = "https://roseandmikes.com/cdn/shop/products/large_8dc063dc-0384-42a5-af34-f7a84bb4c17a_800x.jpg?v=1601827725"
                },
                new MenuItem
                {
                    Name = "Whoppers",
                    Price = 1.20m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71AyhPaEvYL.jpg"
                },
                new MenuItem
                {
                    Name = "Twizzlers",
                    Price = 1.00m,
                    ImageUrl = "https://de2wfhoo6xqi5.cloudfront.net/orig/cc6/d4e/8faed74bd690444eea64e2431f2f0e42b3.jpg"
                },
                new MenuItem
                {
                    Name = "Snickers",
                    Price = 1.20m,
                    ImageUrl = "https://roseandmikes.com/cdn/shop/products/F2F17C77-2823-4919-BB8B-3CC9727AC829_800x.jpg?v=1596511998"
                },
                new MenuItem
                {
                    Name = "Sour Patch",
                    Price = 1.20m,
                    ImageUrl = "https://m.media-amazon.com/images/I/81Ogy5wPtYL.jpg"
                }
            };
        }
    }
}
