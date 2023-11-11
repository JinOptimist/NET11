namespace FootballApi.VIewModels
{
    public class PaginatorViewModel<T>
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<T>  Items { get; set; }
    }
}
