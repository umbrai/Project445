using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Project445.MovieService;

namespace Project445
{
    public partial class Member : System.Web.UI.Page
    {
        private readonly Service1Client _movieServiceClient = new Service1Client();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUser"] == null)
            {
                // Attempt to retrieve user from cookies
                HttpCookie userCookie = Request.Cookies["UserProfile"];
                if (userCookie != null)
                {
                    Session["LoggedInUser"] = userCookie["UserID"];
                }
                else
                {
                    // Redirect to login if no session or cookie
                    Response.Redirect("Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                UserNameLabel.Text = $"Welcome, {Session["LoggedInUser"]}";
                await LoadUpcomingMovies();
                await LoadNowPlayingMovies();
            }
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            // Redirect to Home (refresh page)
            Response.Redirect("Member.aspx");
        }

        protected async void SearchButton_Click(object sender, EventArgs e)
        {
            UpcomingMoviesPanel.Visible = false;
            NowPlayingMoviesPanel.Visible = false;

            var query = SearchBox.Text.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                var searchResults = await Task.Run(() => _movieServiceClient.SearchMovies(query));
                DisplayMovies(searchResults, SearchResultsSection);
                SearchResultsPanel.Visible = searchResults.Length > 0; // Only show if there are search results
            }
            else
            {
                SearchResultsPanel.Visible = false; // Hide if no search query
            }
        }

        private async Task LoadUpcomingMovies()
        {
            var upcomingMovies = await Task.FromResult(_movieServiceClient.GetUpcomingMovies());
            DisplayMovies(upcomingMovies, UpcomingMoviesCarousel);
            UpcomingMoviesPanel.Visible = upcomingMovies.Length > 0;
        }

        private async Task LoadNowPlayingMovies()
        {
            var nowPlayingMovies = await Task.Run(() => _movieServiceClient.GetNowPlayingMovies());
            DisplayMovies(nowPlayingMovies, NowPlayingMoviesCarousel);
            NowPlayingMoviesPanel.Visible = nowPlayingMovies.Length > 0;
        }

        private void DisplayMovies(Movie[] movies, System.Web.UI.HtmlControls.HtmlGenericControl carouselInner)
        {
            carouselInner.Controls.Clear();
            foreach (var movie in movies)
            {
                var carouselItem = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                carouselItem.Attributes["class"] = "carousel-item";

                var movieCard = new Panel { CssClass = "movie-card" };

                // Use FullPosterPath directly for the image URL
                var img = new Image
                {
                    ImageUrl = movie.FullPosterPath,

                    AlternateText = movie.Title,
                    CssClass = "movie-image"
                };

                //Response.Write($"<p>FullPosterPath: {movie.FullPosterPath}</p>");

                var title = new Label { Text = $"<strong>{movie.Title}</strong>", CssClass = "movie-info" };
                var releaseDate = new Label { Text = $"Release Date: {movie.ReleaseDate}", CssClass = "movie-info" };
                var description = new Label { Text = $"Description: {movie.Overview}", CssClass = "movie-info" };
                var rating = new Label { Text = $"Rating: {movie.VoteAverage}/10", CssClass = "movie-info" };

                movieCard.Controls.Add(img);
                movieCard.Controls.Add(title);
                movieCard.Controls.Add(releaseDate);
                movieCard.Controls.Add(description);
                movieCard.Controls.Add(rating);

                carouselItem.Controls.Add(movieCard);
                carouselInner.Controls.Add(carouselItem);
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.Clear();
            Session.Abandon();

            // Clear cookies
            if (Request.Cookies["UserProfile"] != null)
            {
                HttpCookie cookie = new HttpCookie("UserProfile")
                {
                    Expires = DateTime.Now.AddDays(-1) // Expire the cookie
                };
                Response.Cookies.Add(cookie);
            }

            // Redirect to Login page
            Response.Redirect("Home.aspx");
        }

    }

    

}
