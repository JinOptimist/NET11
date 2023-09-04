namespace DALInterfaces.Models.Football
{
    public class FootballClub : BaseModel
    {
        public string Name { get; set; }
        public string Stadium { get; set; }
        public virtual User UserCreator { get; set; }
        public virtual FootballLeague League { get; set; }

    }
}
