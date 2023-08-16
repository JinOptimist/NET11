namespace DALInterfaces.Models
{
    public class Book: BaseModel
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
    }
}
