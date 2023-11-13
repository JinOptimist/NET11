using FootballApi.DatabaseStuff.Models;

namespace FootballApi.VIewModels
{
    public class LeagueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }
        public int IdUserCreator { get; set; }
    }
}