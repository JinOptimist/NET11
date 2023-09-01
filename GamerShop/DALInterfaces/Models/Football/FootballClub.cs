namespace DALInterfaces.Models.Football
{
    public class FootballClub : BaseModel
    {
        public string Name { get; set; }
        public string Stadium { get; set; }
        public int Creator { get; set; }
        public virtual FootballLeague League { get; set; }

    }
}
