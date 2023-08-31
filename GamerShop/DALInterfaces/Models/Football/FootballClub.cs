namespace DALInterfaces.Models.Football
{
    public class FootballClub : BaseModel
    {
        public string Name { get; set; }
        public string Stadium { get; set; }
        public string? Country { get; set; }
        public int Creator { get; set; }

    }
}
