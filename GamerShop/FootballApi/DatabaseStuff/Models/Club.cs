namespace FootballApi.DatabaseStuff.Models
{
    public class Club : BaseModel
    {
        public string Name { get; set; }
        public string Stadium { get; set; }
        public  int IdUserCreator { get; set; }
        public virtual League League { get; set; }

    }
}
