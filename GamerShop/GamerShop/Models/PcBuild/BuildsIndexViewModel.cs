namespace GamerShop.Models.PcBuild
{
    public class BuildsIndexViewModel
    {
        public string UserName { get; set; }
        public string? UserPhotoPath { get; set; }
        public string? BuildPhotoPath { get; set; }
        public string BuildName { get; set; }
        public string Processor { get; set; }
        public List<string>? GPU { get; set; }
        public string Price { get; set; }
        public string Rating { get; set; }
    }
}
