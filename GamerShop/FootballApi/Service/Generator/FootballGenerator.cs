using AngleSharp;
using AngleSharp.Dom;
using FootballApi.DatabaseStuff.Models;
using FootballApi.DatabaseStuff.Repositories.Clubs;
using FootballApi.DatabaseStuff.Repositories.Leagues;

namespace FootballApi.Service.Generator
{
    public class FootballGenerator
    {

        const string TitleUrl = "https://www.globalfootballrankings.com";

        private ILeagueRepository _footballLeagueRepository;
        private IClubRepository _footballClubRepository;
       
        public FootballGenerator(IClubRepository footballClubRepository, ILeagueRepository footballLeagueRepository)
        {
            _footballLeagueRepository = footballLeagueRepository;
            _footballClubRepository = footballClubRepository;
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
                _footballLeagueRepository.Save(new League
                {
                    Country = ligCountry,
                    Name = $"{ligName.TextContent}  {ligCountry}",
                    ShortName = ligName.TextContent,
                    IdUserCreator = 1
                });
                FillInfoAboutClubs($"{TitleUrl}{ligName.GetAttribute("href")}", _footballLeagueRepository.GetLast());

            }

        }


        private void FillInfoAboutClubs(string url, League footballLeague)
        {
            var clubs = new List<Club>();
            IDocument titlePage = GetPage(url).Result;
            var itemList = titlePage.QuerySelectorAll("td")
                                    .Where(x => x.IsFirstChild() & !x.TextContent.Contains("Best"))
                                    .ToList();


            for (int i = 0; i < itemList.Count(); i++)
            {
                var item = itemList[i];
                var club = item.QuerySelector("a");
                var name = club.TextContent;
                
                clubs.Add(new Club
                {
                    Name = name,
                    Stadium = $"{name} Stadium",
                    League = footballLeague,
                    IdUserCreator = 1
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

