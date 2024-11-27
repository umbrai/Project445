<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.cs" Inherits="Project445.Home" Async="true" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Movie Home</title>
     <style>
        .container { padding: 20px; }
        .search-bar { margin-bottom: 20px; }

        /* Carousel styling */
        .carousel { position: relative; overflow: hidden; width: 100%; height: 450px; }
        .carousel-inner { display: flex; transition: transform 0.5s ease-in-out; }
        .carousel-item { 
            min-width: 100%; 
            box-sizing: border-box; 
            padding: 20px; 
            display: flex; 
            align-items: center; 
            justify-content: center;
            padding-left: 100px;
            padding-right: 75px;
        }


        /* Two-column layout for each movie item */
        .movie-card { 
            flex: 1; 
            text-align: center; 
            background-color: #f8f8f8; 
            padding: 20px; 
            border-radius: 8px; 
            display: flex; 
            align-items: center; 
            gap: 20px; 
        }

        .movie-card img { 
            width: 180px; 
            height: auto; 
            border-radius: 8px; 
        }
        
        /* Movie details column */
        .movie-details {
            flex: 2; 
            text-align: left;
        }

        .movie-details .movie-title {
            font-size: 24px; 
            color: #007bff; 
            margin-bottom: 10px;
        }

        .movie-details .movie-info {
            font-size: 18px; 
            color: #333; 
            margin-top: 10px; 
        }

        /* Navigation buttons */
        .carousel-nav { 
            position: absolute; 
            top: 50%; 
            width: 100%; 
            display: flex; 
            justify-content: space-between; 
            transform: translateY(-50%); 
        }

        .carousel-nav button { 
            background: #007bff; 
            color: white; 
            border: none; 
            padding: 10px 15px; 
            cursor: pointer; 
            border-radius: 5px; 
            font-size: 16px; 
        }
    </style>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
           


            <!-- Home Button -->
            <div class="home-button">
                <asp:LinkButton ID="HomeButton" runat="server" Text="Home" OnClick="HomeButton_Click" CssClass="btn" />
            </div>

            <!-- Search Bar Section -->
            <div class="search-bar">
                <asp:TextBox ID="SearchBox" runat="server" placeholder="Search movies..." CssClass="search-input" />
                <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
            </div>

            <h1>Welcome to the Movie Application</h1>
            <p>Discover upcoming movies and explore what's currently playing in theaters!</p>
            <div class="button-group">
                <asp:Button ID="LoginButton" runat="server" Text="Go to Login" CssClass="btn" OnClick="LoginButton_Click" />
            </div>

 <!-- Upcoming Movies Carousel -->
            <asp:Panel ID="UpcomingMoviesPanel" runat="server" Visible="false">
                <h3>Upcoming Movies</h3>
                <div class="carousel">
                    <div class="carousel-inner" id="UpcomingMoviesCarousel" runat="server"></div>
                    <div class="carousel-nav">
                        <button type="button" onclick="previousSlide('UpcomingMoviesCarousel')">Previous</button>
                        <button type="button" onclick="nextSlide('UpcomingMoviesCarousel')">Next</button>
                    </div>
                </div>
            </asp:Panel>

             <!-- Now Playing Movies Carousel -->
            <asp:Panel ID="NowPlayingMoviesPanel" runat="server" Visible="false">
                <h3>Now Playing in Theaters</h3>
                <div class="carousel">
                    <div class="carousel-inner" id="NowPlayingMoviesCarousel" runat="server"></div>
                    <div class="carousel-nav">
                        <button type="button" onclick="previousSlide('NowPlayingMoviesCarousel')">Previous</button>
                        <button type="button" onclick="nextSlide('NowPlayingMoviesCarousel')">Next</button>
                    </div>
                </div>
            </asp:Panel>

            <!-- Search Results Section -->
            <asp:Panel ID="SearchResultsPanel" runat="server" Visible="false">
                <h3>Search Results</h3>
                <div class="movie-row" id="SearchResultsSection" runat="server"></div>
            </asp:Panel>

        </div>

     <script>
         let slideIndex = {};

         function showSlide(containerId, index) {
             const carouselInner = document.getElementById(containerId);
             if (carouselInner) {
                 const totalItems = carouselInner.children.length;
                 if (totalItems > 0) {
                     slideIndex[containerId] = (index + totalItems) % totalItems;
                     carouselInner.style.transform = `translateX(-${slideIndex[containerId] * 100}%)`;
                 }
             }
         }

         function nextSlide(containerId) {
             showSlide(containerId, slideIndex[containerId] + 1);
         }

         function previousSlide(containerId) {
             showSlide(containerId, slideIndex[containerId] - 1);
         }

         setInterval(() => {
             nextSlide('UpcomingMoviesCarousel');
             nextSlide('NowPlayingMoviesCarousel');
         }, 5000);

         slideIndex['UpcomingMoviesCarousel'] = 0;
         slideIndex['NowPlayingMoviesCarousel'] = 0;
     </script>
</asp:Content>


