namespace FootballApi.DatabaseStuff.DataModels.Football
{
    public class ClubDataModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public  int IdUserCreator { get; set; }
        public  ShortLeagueDataModel League { get; set; }

    }
}
