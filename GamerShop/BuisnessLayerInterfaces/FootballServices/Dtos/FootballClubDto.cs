using BusinessLayerInterfaces.BusinessModels.Football;

namespace BusinessLayerInterfaces.FootballServices.Dtos
{
    public class FootballClubDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public int IdUserCreator { get; set; }
        public ShortFootballLeagueDto League { get; set; }
    }
}
