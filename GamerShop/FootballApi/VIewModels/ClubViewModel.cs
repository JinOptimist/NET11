using FootballApi.DatabaseStuff.DataModels.Football;
using FootballApi.DatabaseStuff.Models;

namespace FootballApi.VIewModels
{
    public class ClubViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public int IdUserCreator { get; set; }
        public ShortLeagueViewModel League { get; set; }
    }
}
