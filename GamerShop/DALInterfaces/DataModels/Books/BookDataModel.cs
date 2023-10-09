namespace DALInterfaces.DataModels.Books
{
    public class BookDataModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public ICollection<int> Authors { get; set; }
    }
}
