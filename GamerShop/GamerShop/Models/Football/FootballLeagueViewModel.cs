using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Football
{
    public class FootballLeagueViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string Counrty { get; set; }
    }
}
