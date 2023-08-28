namespace BusinessLayerInterfaces.BusinessModels
{
    public class PaginatorBlm<T>
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
