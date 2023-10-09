namespace BusinessLayerInterfaces.BusinessModels.Books
{
    public class AuthorBlm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public int? YearOfDeath { get; set; }

        public virtual List<BookGetBlm> Books { get; set; }
    }
}
