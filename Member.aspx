<%@ Page Title="Member" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Project445.Member" Async="true" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .container { padding: 20px; }
        .search-bar { margin-bottom: 20px; }
        .user-profile { position: absolute; top: 100px; right: 130px; cursor: pointer; }
        .user-profile:hover .dropdown-menu { display: block; }

        .dropdown-menu {
            display: none;
            position: absolute;
            background-color: white;
            border: 1px solid #ccc;
            padding: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .dropdown-menu a {
            display: block;
            color: #007bff;
            text-decoration: none;
            margin: 5px 0;
        }

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
            <!-- User Profile Icon -->
            <div class="user-profile" runat="server" id="UserProfile">
                <img src="https://static.vecteezy.com/system/resources/previews/008/442/086/non_2x/illustration-of-human-icon-user-symbol-icon-modern-design-on-blank-background-free-vector.jpg" alt="User Profile" style="width: 50px; height: 50px; border-radius: 50%;" />
                <div class="dropdown-menu">
                    <asp:Label ID="UserNameLabel" runat="server" Text="Welcome, User"></asp:Label>
                    <a href="ChangePassword.aspx">Change Password</a>
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn" />
                </div>
            </div>

            <div class="home-button">
                <asp:LinkButton ID="HomeButton" runat="server" Text="Home" OnClick="HomeButton_Click" CssClass="btn" />
            </div>

            <!-- Search Bar Section -->
            <div class="search-bar">
                <asp:TextBox ID="SearchBox" runat="server" placeholder="Search movies..." CssClass="search-input" onkeypress="handleEnter(event)"/>
                <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
            </div>

            <h1>Welcome to the Movie Application</h1>
            <p>Discover upcoming movies and explore what's currently playing in theaters!</p>

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


        function handleEnter(event) {
            if (event.key === "Enter") {
                event.preventDefault(); // Prevent the default form submission behavior
                document.getElementById('<%= SearchButton.ClientID %>').click(); // Trigger the search button click
            }
        }
    </script>
</asp:Content>