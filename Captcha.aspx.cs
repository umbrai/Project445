using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;

namespace Project445
{
    public partial class Captcha : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Generate random text
            string captchaText = GenerateRandomText(6);

            // Store the text in session
            Session["CaptchaText"] = captchaText;

            // Generate image
            using (Bitmap bitmap = new Bitmap(150, 50))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font font = new Font("Arial", 20, FontStyle.Bold);
                Rectangle rect = new Rectangle(0, 0, 150, 50);

                // Background color
                graphics.Clear(Color.LightGray);

                // Add some noise
                Random rand = new Random();
                Pen pen = new Pen(Color.Yellow);
                for (int i = 0; i < 10; i++)
                {
                    graphics.DrawLine(pen, rand.Next(0, 150), rand.Next(0, 50), rand.Next(0, 150), rand.Next(0, 50));
                }

                // Draw the text
                graphics.DrawString(captchaText, font, Brushes.Black, rect);

                // Render image to response
                Response.ContentType = "image/png";
                bitmap.Save(Response.OutputStream, ImageFormat.Png);
            }
        }

        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] buffer = new char[length];

            for (int i = 0; i < length; i++)
            {
                buffer[i] = chars[random.Next(chars.Length)];
            }

            return new string(buffer);
        }
    }
}
