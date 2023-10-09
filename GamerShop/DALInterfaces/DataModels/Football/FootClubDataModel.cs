namespace DALInterfaces.DataModels.Football
{
    public class FootClubDataModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public  UserDataModel UserCreator { get; set; }
        public  ShortFootballLeagueDataModel League { get; set; }

    }
}
