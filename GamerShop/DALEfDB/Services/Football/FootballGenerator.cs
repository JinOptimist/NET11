using AngleSharp;
using AngleSharp.Dom;
using DALInterfaces.Models;
using DALInterfaces.Models.Football;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Football;

namespace GamerShop.Services.Football
{
    public class FootballGenerator
    {

        const string TitleUrl = "https://www.globalfootballrankings.com";

        private IFootballLeagueRepository _footballLeagueRepository;
        private IFootballClubRepository _footballClubRepository;
        private IUserRepository _userRepository;
        private User Creator;

        public FootballGenerator(IFootballClubRepository footballClubRepository, IFootballLeagueRepository footballLeagueRepository, IUserRepository userRepository)
        {
            _footballLeagueRepository = footballLeagueRepository;
            _footballClubRepository = footballClubRepository;
            _userRepository = userRepository;
            Creator = _userRepository.GetUserByName("Admin") ?? _userRepository.Get(1);
        }

        public void FillInfoAboutLeagues(int countLeague)
        {
            IDocument titlePage = GetPage(TitleUrl).Result;

            var itemSelector = titlePage.QuerySelectorAll("td");
            var itemList = itemSelector
                           .Where(x => x.IsFirstChild())
                           .Take(countLeague)
                           .ToList();

            for (int i = 0; i < itemList.Count(); i++)
            {
                var item = itemList[i];
                var ligName = item.QuerySelector("a");
                var ligCountry = item.QuerySelector("span").GetAttribute("title");
                _footballLeagueRepository.Save(new FootballLeague
                {
                    Country = ligCountry,
                    Name = $"{ligName.TextContent}  {ligCountry}",
                    ShortName = ligName.TextContent,
                    UserCreator = Creator
                });
                FillInfoAboutClubs($"{TitleUrl}{ligName.GetAttribute("href")}", _footballLeagueRepository.GetLast());

            }

        }


        private void FillInfoAboutClubs(string url, FootballLeague footballLeague)
        {
            var clubs = new List<FootballClub>();
            IDocument titlePage = GetPage(url).Result;
            var itemList = titlePage.QuerySelectorAll("td")
                                    .Where(x => x.IsFirstChild() & !x.TextContent.Contains("Best"))
                                    .ToList();


            for (int i = 0; i < itemList.Count(); i++)
            {
                var item = itemList[i];
                var club = item.QuerySelector("a");
                var name = club.TextContent;
                
                clubs.Add(new FootballClub
                {
                    Name = name,
                    Stadium = $"{name} Stadium",
                    League = footballLeague,
                    UserCreator = Creator
                });

            }
            _footballClubRepository.SaveRange(clubs);

        }

        public async Task<IDocument> GetPage(string url)
        {
            var config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context = BrowsingContext.New(config);
            return await context.OpenAsync(url);
        }

    }



}

