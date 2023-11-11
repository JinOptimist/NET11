namespace BusinessLayerInterfaces.Common.Dtos
{
    public class PaginatorDto<T>
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<T> Items { get; set; }
    }
}
