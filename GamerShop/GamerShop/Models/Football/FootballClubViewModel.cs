using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Football
{
    public class FootballClubViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Stadium { get; set; }
        public string CreatorName { get; set; }
        [Required]
        public ShortFootballLeagueViewModel FootballLeagueinfo { get; set;}
    }
}
