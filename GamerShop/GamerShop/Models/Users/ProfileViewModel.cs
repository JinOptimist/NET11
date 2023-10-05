namespace GamerShop.Models.Users
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IFormFile Avatar { get; set; }

        public decimal? CurrentJobProgress { get; set; }

        public bool IsFileReady { get; set; }
    }
}
