namespace DALInterfaces.Models.Football
{
    public class FootballLeague : BaseModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }
        public virtual  ICollection<FootballClub> footballClubs { get; set; }
        public virtual User UserCreator { get; set; }   
    }
}
