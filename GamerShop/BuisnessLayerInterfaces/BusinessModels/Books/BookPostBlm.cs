namespace BusinessLayerInterfaces.BusinessModels.Books
{
    public class BookPostBlm
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public int CreatorId { get; set; }
    }
}
