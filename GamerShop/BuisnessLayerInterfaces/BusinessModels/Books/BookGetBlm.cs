namespace BusinessLayerInterfaces.BusinessModels.Books
{
    public class BookGetBlm
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public virtual ICollection<ShortAuthorBlm> Authors { get; set; }
    }
}
