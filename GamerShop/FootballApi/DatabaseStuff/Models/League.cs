namespace FootballApi.DatabaseStuff.Models 
{ 

    public class League : BaseModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }
        public int IdUserCreator { get; set; }
        public virtual  ICollection<Club> Clubs { get; set; }
        
    }
}
