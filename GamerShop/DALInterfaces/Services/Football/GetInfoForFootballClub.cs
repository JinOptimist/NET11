using AngleSharp;
using AngleSharp.Dom;
using DALInterfaces.Models;
using DALInterfaces.Models.Football;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Football;

namespace GamerShop.Services.Football
{
    public class GetInfoForFootballClub
    {

        private string TitleUrl = "https://www.globalfootballrankings.com";

        IFootballLeagueRepository _footballLeagueRepository;
        IFootballClubRepository _footballClubRepository;
        IUserRepository _userRepository;
        User Creator;

        public GetInfoForFootballClub(IFootballClubRepository footballClubRepository, IFootballLeagueRepository footballLeagueRepository, IUserRepository userRepository)
        {
            _footballLeagueRepository = footballLeagueRepository;
            _footballClubRepository = footballClubRepository;
            _userRepository = userRepository;
            Creator = _userRepository.GetAll().First(x => x.Name == "Admin");
        }

        public void GetSaveAndParseFootballLuagesAndClubs(int countLeague)
        {
            IDocument titlePage = GetPage(TitleUrl).Result;

            var itemSelector = titlePage.QuerySelectorAll("td");

            foreach (var item in itemSelector)
            {
                if (!item.IsFirstChild())
                {
                    continue;
                }
                if (countLeague == 0)
                {
                    break;
                }
                var ligName = item.QuerySelector("a");
                var ligCountry = item.QuerySelector("span").GetAttribute("title");
                _footballLeagueRepository.Save(new FootballLeague
                {
                    Country = ligCountry,
                    Name = $"{ligName.TextContent}  {ligCountry}",
                    ShortName = ligName.TextContent,
                    UserCreator = Creator
                });
                GetAndParceClubs($"{TitleUrl}{ligName.GetAttribute("href")}", _footballLeagueRepository.GetLast());
                countLeague--;
            };

        }


        private void GetAndParceClubs(string url, FootballLeague footballLeague)
        {
            var clubs = new List<FootballClub>();
            IDocument titlePage = GetPage(url).Result;
            var itemSelector = titlePage.QuerySelectorAll("td");
            foreach (var item in itemSelector)
            {
                if (!item.IsFirstChild())
                {
                    continue;
                }
                if (item.TextContent.IndexOf("Best") != -1)
                {
                    continue;
                }
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

