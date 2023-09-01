using DALInterfaces.Models.Football;

namespace BusinessLayerInterfaces.BusinessModels.Football
{
    public class FootballClubBlm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public ShortFootballLeagueBLM ShortFootballLeagueInfo { get; set; }
        public UserBlm Creator { get; set; }
    }
}
